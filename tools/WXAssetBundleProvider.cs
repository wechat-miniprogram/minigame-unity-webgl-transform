#if UNITY_2022_1_OR_NEWER
#define UNLOAD_BUNDLE_ASYNC
#endif

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.Exceptions;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.Util;
using WeChatWASM;

namespace UnityEngine.ResourceManagement
{
    internal class WXWebRequestQueueOperation
    {
        private bool m_Completed = false;
        public UnityWebRequestAsyncOperation Result;
        public Action<UnityWebRequestAsyncOperation> OnComplete;

        public bool IsDone
        {
            get { return m_Completed || Result != null; }
        }

        internal UnityWebRequest m_WebRequest;

        public WXWebRequestQueueOperation(UnityWebRequest request)
        {
            m_WebRequest = request;
        }

        internal void Complete(UnityWebRequestAsyncOperation asyncOp)
        {
            m_Completed = true;
            Result = asyncOp;
            OnComplete?.Invoke(Result);
        }
    }

    internal static class WebRequestQueue
    {
        internal static int s_MaxRequest = 500;
        internal static Queue<WXWebRequestQueueOperation> s_QueuedOperations =
            new Queue<WXWebRequestQueueOperation>();
        internal static List<UnityWebRequestAsyncOperation> s_ActiveRequests =
            new List<UnityWebRequestAsyncOperation>();

        public static void SetMaxConcurrentRequests(int maxRequests)
        {
            if (maxRequests < 1)
                throw new ArgumentException("MaxRequests must be 1 or greater.", "maxRequests");
            s_MaxRequest = maxRequests;
        }

        public static WXWebRequestQueueOperation QueueRequest(UnityWebRequest request)
        {
            WXWebRequestQueueOperation queueOperation = new WXWebRequestQueueOperation(request);
            if (s_ActiveRequests.Count < s_MaxRequest)
            {
                UnityWebRequestAsyncOperation webRequestAsyncOp = null;
                try
                {
                    webRequestAsyncOp = request.SendWebRequest();
                    s_ActiveRequests.Add(webRequestAsyncOp);

                    if (webRequestAsyncOp.isDone)
                        OnWebAsyncOpComplete(webRequestAsyncOp);
                    else
                        webRequestAsyncOp.completed += OnWebAsyncOpComplete;
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }

                queueOperation.Complete(webRequestAsyncOp);
            }
            else
                s_QueuedOperations.Enqueue(queueOperation);

            return queueOperation;
        }

        internal static void WaitForRequestToBeActive(
            WXWebRequestQueueOperation request,
            int millisecondsTimeout
        )
        {
            var completedRequests = new List<UnityWebRequestAsyncOperation>();
            while (s_QueuedOperations.Contains(request))
            {
                completedRequests.Clear();
                foreach (UnityWebRequestAsyncOperation webRequestAsyncOp in s_ActiveRequests)
                {
                    if (WXUnityWebRequestUtilities.IsAssetBundleDownloaded(webRequestAsyncOp))
                        completedRequests.Add(webRequestAsyncOp);
                }
                foreach (UnityWebRequestAsyncOperation webRequestAsyncOp in completedRequests)
                {
                    bool requestIsActive = s_QueuedOperations.Peek() == request;
                    webRequestAsyncOp.completed -= OnWebAsyncOpComplete;
                    OnWebAsyncOpComplete(webRequestAsyncOp);
                    if (requestIsActive)
                        return;
                }
                System.Threading.Thread.Sleep(millisecondsTimeout);
            }
        }

        private static void OnWebAsyncOpComplete(AsyncOperation operation)
        {
            s_ActiveRequests.Remove((operation as UnityWebRequestAsyncOperation));

            if (s_QueuedOperations.Count > 0)
            {
                var nextQueuedOperation = s_QueuedOperations.Dequeue();
                var webRequestAsyncOp = nextQueuedOperation.m_WebRequest.SendWebRequest();
                webRequestAsyncOp.completed += OnWebAsyncOpComplete;
                s_ActiveRequests.Add(webRequestAsyncOp);
                nextQueuedOperation.Complete(webRequestAsyncOp);
            }
        }
    }
}

namespace UnityEngine.ResourceManagement.ResourceProviders
{
    [DisplayName("Assets from WXBundles Provider")]
    public class WXBundledAssetProvider : ResourceProviderBase
    {
        internal class InternalOp
        {
            AssetBundle m_AssetBundle;
            AssetBundleRequest m_PreloadRequest;
            AssetBundleRequest m_RequestOperation;
            object m_Result;
            ProvideHandle m_ProvideHandle;
            string subObjectName = null;

            internal static T LoadBundleFromDependecies<T>(IList<object> results)
                where T : class, IAssetBundleResource
            {
                if (results == null || results.Count == 0)
                    return default(T);

                IAssetBundleResource bundle = null;
                bool firstBundleWrapper = true;
                for (int i = 0; i < results.Count; i++)
                {
                    var abWrapper = results[i] as IAssetBundleResource;
                    if (abWrapper != null)
                    {
                        //only use the first asset bundle, even if it is invalid
                        abWrapper.GetAssetBundle();
                        if (firstBundleWrapper)
                            bundle = abWrapper;
                        firstBundleWrapper = false;
                    }
                }

                return bundle as T;
            }

            public void Start(ProvideHandle provideHandle)
            {
                provideHandle.SetProgressCallback(ProgressCallback);
                provideHandle.SetWaitForCompletionCallback(WaitForCompletionHandler);
                subObjectName = null;
                m_ProvideHandle = provideHandle;
                m_RequestOperation = null;
                List<object> deps = new List<object>(); // TODO: garbage. need to pass actual count and reuse the list
                m_ProvideHandle.GetDependencies(deps);
                var bundleResource = LoadBundleFromDependecies<IAssetBundleResource>(deps);
                if (bundleResource == null)
                {
                    m_ProvideHandle.Complete<AssetBundle>(
                        null,
                        false,
                        new Exception(
                            "Unable to load dependent bundle from location "
                                + m_ProvideHandle.Location
                        )
                    );
                }
                else
                {
                    m_AssetBundle = bundleResource.GetAssetBundle();
                    if (m_AssetBundle == null)
                    {
                        m_ProvideHandle.Complete<AssetBundle>(
                            null,
                            false,
                            new Exception(
                                "Unable to load dependent bundle from location "
                                    + m_ProvideHandle.Location
                            )
                        );
                        return;
                    }

                    var assetBundleResource = bundleResource as WXAssetBundleResource;
                    if (assetBundleResource != null)
                        m_PreloadRequest = assetBundleResource.GetAssetPreloadRequest();
                    if (m_PreloadRequest == null || m_PreloadRequest.isDone)
                        BeginAssetLoad();
                    else
                        m_PreloadRequest.completed += operation => BeginAssetLoad();
                }
            }

            internal static bool ExtractKeyAndSubKey(
                object keyObj,
                out string mainKey,
                out string subKey
            )
            {
                var key = keyObj as string;
                if (key != null)
                {
                    var i = key.IndexOf('[');
                    if (i > 0)
                    {
                        var j = key.LastIndexOf(']');
                        if (j > i)
                        {
                            mainKey = key.Substring(0, i);
                            subKey = key.Substring(i + 1, j - (i + 1));
                            return true;
                        }
                    }
                }
                mainKey = null;
                subKey = null;
                return false;
            }

            private void BeginAssetLoad()
            {
                if (m_AssetBundle == null)
                {
                    m_ProvideHandle.Complete<AssetBundle>(
                        null,
                        false,
                        new Exception(
                            "Unable to load dependent bundle from location "
                                + m_ProvideHandle.Location
                        )
                    );
                }
                else
                {
                    var assetPath = m_ProvideHandle.ResourceManager.TransformInternalId(
                        m_ProvideHandle.Location
                    );
                    if (m_ProvideHandle.Type.IsArray)
                    {
#if !UNITY_2021_1_OR_NEWER
                        if (AsyncOperationHandle.IsWaitingForCompletion)
                        {
                            GetArrayResult(
                                m_AssetBundle.LoadAssetWithSubAssets(
                                    assetPath,
                                    m_ProvideHandle.Type.GetElementType()
                                )
                            );
                            CompleteOperation();
                        }
                        else
#endif
                            m_RequestOperation = m_AssetBundle.LoadAssetWithSubAssetsAsync(
                                assetPath,
                                m_ProvideHandle.Type.GetElementType()
                            );
                    }
                    else if (
                        m_ProvideHandle.Type.IsGenericType
                        && typeof(IList<>) == m_ProvideHandle.Type.GetGenericTypeDefinition()
                    )
                    {
#if !UNITY_2021_1_OR_NEWER
                        if (AsyncOperationHandle.IsWaitingForCompletion)
                        {
                            GetListResult(
                                m_AssetBundle.LoadAssetWithSubAssets(
                                    assetPath,
                                    m_ProvideHandle.Type.GetGenericArguments()[0]
                                )
                            );
                            CompleteOperation();
                        }
                        else
#endif
                            m_RequestOperation = m_AssetBundle.LoadAssetWithSubAssetsAsync(
                                assetPath,
                                m_ProvideHandle.Type.GetGenericArguments()[0]
                            );
                    }
                    else
                    {
                        if (ExtractKeyAndSubKey(assetPath, out string mainPath, out string subKey))
                        {
                            subObjectName = subKey;
#if !UNITY_2021_1_OR_NEWER
                            if (AsyncOperationHandle.IsWaitingForCompletion)
                            {
                                GetAssetSubObjectResult(
                                    m_AssetBundle.LoadAssetWithSubAssets(
                                        mainPath,
                                        m_ProvideHandle.Type
                                    )
                                );
                                CompleteOperation();
                            }
                            else
#endif
                                m_RequestOperation = m_AssetBundle.LoadAssetWithSubAssetsAsync(
                                    mainPath,
                                    m_ProvideHandle.Type
                                );
                        }
                        else
                        {
#if !UNITY_2021_1_OR_NEWER
                            if (AsyncOperationHandle.IsWaitingForCompletion)
                            {
                                GetAssetResult(
                                    m_AssetBundle.LoadAsset(assetPath, m_ProvideHandle.Type)
                                );
                                CompleteOperation();
                            }
                            else
#endif
                                m_RequestOperation = m_AssetBundle.LoadAssetAsync(
                                    assetPath,
                                    m_ProvideHandle.Type
                                );
                        }
                    }

                    if (m_RequestOperation != null)
                    {
                        if (m_RequestOperation.isDone)
                            ActionComplete(m_RequestOperation);
                        else
                            m_RequestOperation.completed += ActionComplete;
                    }
                }
            }

            private bool WaitForCompletionHandler()
            {
                if (m_PreloadRequest != null && !m_PreloadRequest.isDone)
                    return m_PreloadRequest.asset == null;
                if (m_Result != null)
                    return true;
                if (m_RequestOperation == null)
                    return false;
                if (m_RequestOperation.isDone)
                    return true;
                return m_RequestOperation.asset != null;
            }

            private void ActionComplete(AsyncOperation obj)
            {
                if (m_RequestOperation != null)
                {
                    if (m_ProvideHandle.Type.IsArray)
                        GetArrayResult(m_RequestOperation.allAssets);
                    else if (
                        m_ProvideHandle.Type.IsGenericType
                        && typeof(IList<>) == m_ProvideHandle.Type.GetGenericTypeDefinition()
                    )
                        GetListResult(m_RequestOperation.allAssets);
                    else if (string.IsNullOrEmpty(subObjectName))
                        GetAssetResult(m_RequestOperation.asset);
                    else
                        GetAssetSubObjectResult(m_RequestOperation.allAssets);
                }
                CompleteOperation();
            }

            private void GetArrayResult(Object[] allAssets)
            {
                m_Result = ResourceManagerConfig.CreateArrayResult(m_ProvideHandle.Type, allAssets);
            }

            private void GetListResult(Object[] allAssets)
            {
                m_Result = ResourceManagerConfig.CreateListResult(m_ProvideHandle.Type, allAssets);
            }

            private void GetAssetResult(Object asset)
            {
                m_Result =
                    (asset != null && m_ProvideHandle.Type.IsAssignableFrom(asset.GetType()))
                        ? asset
                        : null;
            }

            private void GetAssetSubObjectResult(Object[] allAssets)
            {
                foreach (var o in allAssets)
                {
                    if (o.name == subObjectName)
                    {
                        if (m_ProvideHandle.Type.IsAssignableFrom(o.GetType()))
                        {
                            m_Result = o;
                            break;
                        }
                    }
                }
            }

            void CompleteOperation()
            {
                Exception e =
                    m_Result == null
                        ? new Exception(
                            $"Unable to load asset of type {m_ProvideHandle.Type} from location {m_ProvideHandle.Location}."
                        )
                        : null;
                m_ProvideHandle.Complete(m_Result, m_Result != null, e);
            }

            public float ProgressCallback()
            {
                return m_RequestOperation != null ? m_RequestOperation.progress : 0.0f;
            }
        }

        /// <inheritdoc/>
        public override void Provide(ProvideHandle provideHandle)
        {
            new InternalOp().Start(provideHandle);
        }
    }

    internal class WXAssetBundleResource : IAssetBundleResource, IUpdateReceiver
    {
        internal enum LoadType
        {
            None,
            Local,
            Web
        }

        AssetBundle m_AssetBundle;
        DownloadHandlerWXAssetBundle m_downloadHandler;
        AsyncOperation m_RequestOperation;
        WXWebRequestQueueOperation m_WebRequestQueueOperation;
        internal ProvideHandle m_ProvideHandle;
        internal AssetBundleRequestOptions m_Options;

        [NonSerialized]
        bool m_WebRequestCompletedCallbackCalled = false;
        int m_Retries;
        long m_BytesToDownload;
        long m_DownloadedBytes;
        bool m_Completed = false;
#if UNLOAD_BUNDLE_ASYNC
        AssetBundleUnloadOperation m_UnloadOperation;
#endif
        const int k_WaitForWebRequestMainThreadSleep = 1;
        string m_TransformedInternalId;
        AssetBundleRequest m_PreloadRequest;
        bool m_PreloadCompleted = false;
        ulong m_LastDownloadedByteCount = 0;
        float m_TimeoutTimer = 0;
        int m_TimeoutOverFrames = 0;

        private bool HasTimedOut => m_TimeoutTimer >= m_Options.Timeout && m_TimeoutOverFrames > 5;

        internal long BytesToDownload
        {
            get
            {
                if (m_BytesToDownload == -1)
                {
                    if (m_Options != null)
                        m_BytesToDownload = m_Options.ComputeSize(
                            m_ProvideHandle.Location,
                            m_ProvideHandle.ResourceManager
                        );
                    else
                        m_BytesToDownload = 0;
                }
                return m_BytesToDownload;
            }
        }

        internal UnityWebRequest CreateWebRequest(IResourceLocation loc)
        {
            var url = m_ProvideHandle.ResourceManager.TransformInternalId(loc);
            return CreateWebRequest(url);
        }

        internal UnityWebRequest CreateWebRequest(string url)
        {
            if (m_Options == null)
                return WXAssetBundle.GetAssetBundle(url);
            UnityWebRequest webRequest;
            if (!string.IsNullOrEmpty(m_Options.Hash))
            {
                CachedAssetBundle cachedBundle = new CachedAssetBundle(
                    m_Options.BundleName,
                    Hash128.Parse(m_Options.Hash)
                );
#if ENABLE_CACHING
                if (m_Options.UseCrcForCachedBundle || !Caching.IsVersionCached(cachedBundle))
                    webRequest = UnityWebRequestAssetBundle.GetAssetBundle(
                        url,
                        cachedBundle,
                        m_Options.Crc
                    );
                else
                    webRequest = UnityWebRequestAssetBundle.GetAssetBundle(url, cachedBundle);
#else
                webRequest = UnityWebRequestAssetBundle.GetAssetBundle(
                    url,
                    cachedBundle,
                    m_Options.Crc
                );
#endif
            }
            else
                webRequest = WXAssetBundle.GetAssetBundle(url, m_Options.Crc);
            if (m_Options.RedirectLimit > 0)
                webRequest.redirectLimit = m_Options.RedirectLimit;
            if (m_ProvideHandle.ResourceManager.CertificateHandlerInstance != null)
            {
                webRequest.certificateHandler = m_ProvideHandle
                    .ResourceManager
                    .CertificateHandlerInstance;
                webRequest.disposeCertificateHandlerOnDispose = false;
            }

            m_ProvideHandle.ResourceManager.WebRequestOverride?.Invoke(webRequest);
            return webRequest;
        }

        internal AssetBundleRequest GetAssetPreloadRequest()
        {
            if (m_PreloadCompleted || GetAssetBundle() == null)
                return null;

            if (m_Options.AssetLoadMode == AssetLoadMode.AllPackedAssetsAndDependencies)
            {
#if !UNITY_2021_1_OR_NEWER
                if (AsyncOperationHandle.IsWaitingForCompletion)
                {
                    m_AssetBundle.LoadAllAssets();
                    m_PreloadCompleted = true;
                    return null;
                }
#endif
                if (m_PreloadRequest == null)
                {
                    m_PreloadRequest = m_AssetBundle.LoadAllAssetsAsync();
                    m_PreloadRequest.completed += operation => m_PreloadCompleted = true;
                }
                return m_PreloadRequest;
            }

            return null;
        }

        float PercentComplete()
        {
            return m_RequestOperation != null ? m_RequestOperation.progress : 0.0f;
        }

        DownloadStatus GetDownloadStatus()
        {
            if (m_Options == null)
                return default;
            var status = new DownloadStatus()
            {
                TotalBytes = BytesToDownload,
                IsDone = PercentComplete() >= 1f
            };
            if (BytesToDownload > 0)
            {
                if (
                    m_WebRequestQueueOperation != null
                    && string.IsNullOrEmpty(m_WebRequestQueueOperation.m_WebRequest.error)
                )
                    m_DownloadedBytes = (long)(
                        m_WebRequestQueueOperation.m_WebRequest.downloadedBytes
                    );
                else if (
                    m_RequestOperation != null
                    && m_RequestOperation is UnityWebRequestAsyncOperation operation
                    && string.IsNullOrEmpty(operation.webRequest.error)
                )
                    m_DownloadedBytes = (long)operation.webRequest.downloadedBytes;
            }

            status.DownloadedBytes = m_DownloadedBytes;
            return status;
        }

        /// <summary>
        /// Get the asset bundle object managed by this resource.  This call may force the bundle to load if not already loaded.
        /// </summary>
        /// <returns>The asset bundle.</returns>
        public AssetBundle GetAssetBundle()
        {
            if (m_AssetBundle == null)
            {
                if (m_downloadHandler != null)
                {
                    m_AssetBundle = m_downloadHandler.assetBundle;
                    m_downloadHandler.Dispose();
                    m_downloadHandler = null;
                }
                else if (m_RequestOperation is WXAssetBundleRequest)
                {
                    m_AssetBundle = (m_RequestOperation as WXAssetBundleRequest).assetBundle;
                }
            }
            return m_AssetBundle;
        }

#if UNLOAD_BUNDLE_ASYNC
        void OnUnloadOperationComplete(AsyncOperation op)
        {
            m_UnloadOperation = null;
            BeginOperation();
        }
#endif

#if UNLOAD_BUNDLE_ASYNC
        internal void Start(ProvideHandle provideHandle, AssetBundleUnloadOperation unloadOp)
#else
        internal void Start(ProvideHandle provideHandle)
#endif
        {
            m_Retries = 0;
            m_AssetBundle = null;
            m_downloadHandler = null;
            m_RequestOperation = null;
            m_WebRequestCompletedCallbackCalled = false;
            m_ProvideHandle = provideHandle;
            m_Options = m_ProvideHandle.Location.Data as AssetBundleRequestOptions;
            m_BytesToDownload = -1;
            m_ProvideHandle.SetProgressCallback(PercentComplete);
            m_ProvideHandle.SetDownloadProgressCallbacks(GetDownloadStatus);
            m_ProvideHandle.SetWaitForCompletionCallback(WaitForCompletionHandler);
#if UNLOAD_BUNDLE_ASYNC
            m_UnloadOperation = unloadOp;
            if (m_UnloadOperation != null && !m_UnloadOperation.isDone)
                m_UnloadOperation.completed += OnUnloadOperationComplete;
            else
#endif
            BeginOperation();
        }

        private bool WaitForCompletionHandler()
        {
#if UNLOAD_BUNDLE_ASYNC
            if (m_UnloadOperation != null && !m_UnloadOperation.isDone)
            {
                m_UnloadOperation.completed -= OnUnloadOperationComplete;
                m_UnloadOperation.WaitForCompletion();
                m_UnloadOperation = null;
                BeginOperation();
            }
#endif

            if (m_RequestOperation == null)
            {
                if (m_WebRequestQueueOperation == null)
                    return false;
                else
                    WebRequestQueue.WaitForRequestToBeActive(
                        m_WebRequestQueueOperation,
                        k_WaitForWebRequestMainThreadSleep
                    );
            }

            //We don't want to wait for request op to complete if it's a LoadFromFileAsync. Only UWR will complete in a tight loop like this.
            if (m_RequestOperation is UnityWebRequestAsyncOperation op)
            {
                while (!WXUnityWebRequestUtilities.IsAssetBundleDownloaded(op))
                    System.Threading.Thread.Sleep(k_WaitForWebRequestMainThreadSleep);
            }

            if (
                m_RequestOperation is UnityWebRequestAsyncOperation
                && !m_WebRequestCompletedCallbackCalled
            )
            {
                WebRequestOperationCompleted(m_RequestOperation);
                m_RequestOperation.completed -= WebRequestOperationCompleted;
            }

            var assetBundle = GetAssetBundle();
            if (!m_Completed && m_RequestOperation.isDone)
            {
                m_ProvideHandle.Complete(this, m_AssetBundle != null, null);
                m_Completed = true;
            }

            return m_Completed;
        }

        void AddCallbackInvokeIfDone(AsyncOperation operation, Action<AsyncOperation> callback)
        {
            if (operation.isDone)
                callback(operation);
            else
                operation.completed += callback;
        }

        internal static void GetLoadInfo(
            ProvideHandle handle,
            out LoadType loadType,
            out string path
        )
        {
            GetLoadInfo(handle.Location, handle.ResourceManager, out loadType, out path);
        }

        internal static void GetLoadInfo(
            IResourceLocation location,
            ResourceManager resourceManager,
            out LoadType loadType,
            out string path
        )
        {
            var options = location?.Data as AssetBundleRequestOptions;
            if (options == null)
            {
                loadType = LoadType.None;
                path = null;
                return;
            }

            path = resourceManager.TransformInternalId(location);
            if (Application.platform == RuntimePlatform.Android && path.StartsWith("jar:"))
                loadType = options.UseUnityWebRequestForLocalBundles
                    ? LoadType.Web
                    : LoadType.Local;
            else if (ResourceManagerConfig.ShouldPathUseWebRequest(path))
                loadType = LoadType.Web;
            else if (options.UseUnityWebRequestForLocalBundles)
            {
                path = "file:///" + Path.GetFullPath(path);
                loadType = LoadType.Web;
            }
            else
                loadType = LoadType.Local;
            //Debug.Log(loadType);
            //Debug.Log(path);
        }

        private void BeginOperation()
        {
            m_DownloadedBytes = 0;
            GetLoadInfo(m_ProvideHandle, out LoadType loadType, out m_TransformedInternalId);

            if (loadType == LoadType.Local)
            {
#if !UNITY_2021_1_OR_NEWER
                if (AsyncOperationHandle.IsWaitingForCompletion)
                    CompleteBundleLoad(
                        AssetBundle.LoadFromFile(
                            m_TransformedInternalId,
                            m_Options == null ? 0 : m_Options.Crc
                        )
                    );
                else
#endif
                {
                    m_RequestOperation = AssetBundle.LoadFromFileAsync(
                        m_TransformedInternalId,
                        m_Options == null ? 0 : m_Options.Crc
                    );
                    AddCallbackInvokeIfDone(m_RequestOperation, LocalRequestOperationCompleted);
                }
            }
            else if (loadType == LoadType.Web)
            {
                m_WebRequestCompletedCallbackCalled = false;
                var req = CreateWebRequest(m_TransformedInternalId);
#if ENABLE_ASYNC_ASSETBUNDLE_UWR
                Debug.LogError("ENABLE_ASYNC_ASSETBUNDLE_UWR");
                Debug.LogError(!(m_ProvideHandle.Location is DownloadOnlyLocation));
                ((DownloadHandlerAssetBundle)req.downloadHandler).autoLoadAssetBundle = !(
                    m_ProvideHandle.Location is DownloadOnlyLocation
                );
#endif
                req.disposeDownloadHandlerOnDispose = false;

                m_WebRequestQueueOperation = WebRequestQueue.QueueRequest(req);
                if (m_WebRequestQueueOperation.IsDone)
                    BeginWebRequestOperation(m_WebRequestQueueOperation.Result);
                else
                    m_WebRequestQueueOperation.OnComplete += asyncOp =>
                        BeginWebRequestOperation(asyncOp);
            }
            else
            {
                m_RequestOperation = null;
                m_ProvideHandle.Complete<WXAssetBundleResource>(
                    null,
                    false,
                    new RemoteProviderException(
                        string.Format(
                            "Invalid path in AssetBundleProvider: '{0}'.",
                            m_TransformedInternalId
                        ),
                        m_ProvideHandle.Location
                    )
                );
                m_Completed = true;
            }
        }

        private void BeginWebRequestOperation(AsyncOperation asyncOp)
        {
            m_TimeoutTimer = 0;
            m_TimeoutOverFrames = 0;
            m_LastDownloadedByteCount = 0;
            m_RequestOperation = asyncOp;
            if (m_RequestOperation == null || m_RequestOperation.isDone)
                WebRequestOperationCompleted(m_RequestOperation);
            else
            {
                if (m_Options.Timeout > 0)
                    m_ProvideHandle.ResourceManager.AddUpdateReceiver(this);
                m_RequestOperation.completed += WebRequestOperationCompleted;
            }
        }

        public void Update(float unscaledDeltaTime)
        {
            if (
                m_RequestOperation != null
                && m_RequestOperation is UnityWebRequestAsyncOperation operation
                && !operation.isDone
            )
            {
                if (m_LastDownloadedByteCount != operation.webRequest.downloadedBytes)
                {
                    m_TimeoutTimer = 0;
                    m_TimeoutOverFrames = 0;
                    m_LastDownloadedByteCount = operation.webRequest.downloadedBytes;
                }
                else
                {
                    m_TimeoutTimer += unscaledDeltaTime;
                    if (HasTimedOut)
                        operation.webRequest.Abort();
                    m_TimeoutOverFrames++;
                }
            }
        }

        private void LocalRequestOperationCompleted(AsyncOperation op)
        {
            CompleteBundleLoad((op as WXAssetBundleRequest).assetBundle);
        }

        private void CompleteBundleLoad(AssetBundle bundle)
        {
            m_AssetBundle = bundle;
            if (m_AssetBundle != null)
                m_ProvideHandle.Complete(this, true, null);
            else
                m_ProvideHandle.Complete<WXAssetBundleResource>(
                    null,
                    false,
                    new RemoteProviderException(
                        string.Format(
                            "Invalid path in AssetBundleProvider: '{0}'.",
                            m_TransformedInternalId
                        ),
                        m_ProvideHandle.Location
                    )
                );
            m_Completed = true;
        }

        private void WebRequestOperationCompleted(AsyncOperation op)
        {
            if (m_WebRequestCompletedCallbackCalled)
                return;

            if (m_Options.Timeout > 0)
                m_ProvideHandle.ResourceManager.RemoveUpdateReciever(this);

            m_WebRequestCompletedCallbackCalled = true;
            UnityWebRequestAsyncOperation remoteReq = op as UnityWebRequestAsyncOperation;
            var webReq = remoteReq?.webRequest;
            m_downloadHandler = webReq?.downloadHandler as DownloadHandlerWXAssetBundle;
            WXUnityWebRequestResult uwrResult = null;
            if (
                webReq != null
                && !WXUnityWebRequestUtilities.RequestHasErrors(webReq, out uwrResult)
            )
            {
                if (!m_Completed)
                {
                    m_ProvideHandle.Complete(this, true, null);
                    m_Completed = true;
                }
#if ENABLE_CACHING
                if (
                    !string.IsNullOrEmpty(m_Options.Hash)
                    && m_Options.ClearOtherCachedVersionsWhenLoaded
                )
                    Caching.ClearOtherCachedVersions(
                        m_Options.BundleName,
                        Hash128.Parse(m_Options.Hash)
                    );
#endif
            }
            else
            {
                if (HasTimedOut)
                    uwrResult.Error = "Request timeout";
                webReq = m_WebRequestQueueOperation.m_WebRequest;
                if (uwrResult == null)
                    uwrResult = new WXUnityWebRequestResult(
                        m_WebRequestQueueOperation.m_WebRequest
                    );

                m_downloadHandler = webReq.downloadHandler as DownloadHandlerWXAssetBundle;
                m_downloadHandler.Dispose();
                m_downloadHandler = null;
                bool forcedRetry = false;
                string message =
                    $"Web request failed, retrying ({m_Retries}/{m_Options.RetryCount})...\n{uwrResult}";
#if ENABLE_CACHING
                if (!string.IsNullOrEmpty(m_Options.Hash))
                {
                    CachedAssetBundle cab = new CachedAssetBundle(
                        m_Options.BundleName,
                        Hash128.Parse(m_Options.Hash)
                    );
                    if (Caching.IsVersionCached(cab))
                    {
                        message =
                            $"Web request failed to load from cache. The cached AssetBundle will be cleared from the cache and re-downloaded. Retrying...\n{uwrResult}";
                        Caching.ClearCachedVersion(cab.name, cab.hash);
                        if (m_Options.RetryCount == 0 && m_Retries == 0)
                        {
                            Debug.LogFormat(message);
                            BeginOperation();
                            m_Retries++; //Will prevent us from entering an infinite loop of retrying if retry count is 0
                            forcedRetry = true;
                        }
                    }
                }
#endif
                if (!forcedRetry)
                {
                    if (m_Retries < m_Options.RetryCount && uwrResult.ShouldRetryDownloadError())
                    {
                        m_Retries++;
                        Debug.LogFormat(message);
                        BeginOperation();
                    }
                    else
                    {
                        var exception = new WXRemoteProviderException(
                            $"Unable to load asset bundle from : {webReq.url}",
                            m_ProvideHandle.Location,
                            uwrResult
                        );
                        m_ProvideHandle.Complete<WXAssetBundleResource>(null, false, exception);
                        m_Completed = true;
                    }
                }
            }
            webReq.Dispose();
        }

        /// <summary>
        /// Unloads all resources associated with this asset bundle.
        /// </summary>
#if UNLOAD_BUNDLE_ASYNC
        public bool Unload(out AssetBundleUnloadOperation unloadOp)
#else
        public void Unload()
#endif
        {
#if UNLOAD_BUNDLE_ASYNC
            unloadOp = null;
            if (m_AssetBundle != null)
            {
                unloadOp = m_AssetBundle.UnloadAsync(true);
                m_AssetBundle = null;
            }
#else
            if (m_AssetBundle != null)
            {
                m_AssetBundle.WXUnload(true);
                m_AssetBundle = null;
            }
#endif
            if (m_downloadHandler != null)
            {
                m_downloadHandler.Dispose();
                m_downloadHandler = null;
            }
            m_RequestOperation = null;
#if UNLOAD_BUNDLE_ASYNC
            return unloadOp != null;
#endif
        }
    }

    /// <summary>
    /// IResourceProvider for asset bundles.  Loads bundles via UnityWebRequestAssetBundle API if the internalId starts with "http".  If not, it will load the bundle via AssetBundle.LoadFromFileAsync.
    /// </summary>
    [DisplayName("WXAssetBundle Provider")]
    public class WXAssetBundleProvider : ResourceProviderBase
    {
#if UNLOAD_BUNDLE_ASYNC
        static Dictionary<string, AssetBundleUnloadOperation> m_UnloadingBundles =
            new Dictionary<string, AssetBundleUnloadOperation>();
        internal static int UnloadingAssetBundleCount => m_UnloadingBundles.Count;
        internal static int AssetBundleCount =>
            AssetBundle.GetAllLoadedAssetBundles().Count() - UnloadingAssetBundleCount;

        internal static void WaitForAllUnloadingBundlesToComplete()
        {
            if (UnloadingAssetBundleCount > 0)
            {
                var bundles = m_UnloadingBundles.Values.ToArray();
                foreach (var b in bundles)
                    b.WaitForCompletion();
            }
        }
#else
        internal static void WaitForAllUnloadingBundlesToComplete() { }
#endif

        /// <inheritdoc/>
        public override void Provide(ProvideHandle providerInterface)
        {
#if UNLOAD_BUNDLE_ASYNC
            if (
                m_UnloadingBundles.TryGetValue(
                    providerInterface.Location.InternalId,
                    out var unloadOp
                )
            )
            {
                if (unloadOp.isDone)
                    unloadOp = null;
            }
            new WXAssetBundleResource().Start(providerInterface, unloadOp);
#else
            new WXAssetBundleResource().Start(providerInterface);
#endif
        }

        /// <inheritdoc/>
        public override Type GetDefaultType(IResourceLocation location)
        {
            return typeof(IAssetBundleResource);
        }

        /// <summary>
        /// Releases the asset bundle via AssetBundle.Unload(true).
        /// </summary>
        /// <param name="location">The location of the asset to release</param>
        /// <param name="asset">The asset in question</param>
        public override void Release(IResourceLocation location, object asset)
        {
            if (location == null)
                throw new ArgumentNullException("location");
            if (asset == null)
            {
                Debug.LogWarningFormat(
                    "Releasing null asset bundle from location {0}.  This is an indication that the bundle failed to load.",
                    location
                );
                return;
            }
            var bundle = asset as WXAssetBundleResource;
            if (bundle != null)
            {
#if UNLOAD_BUNDLE_ASYNC
                if (bundle.Unload(out var unloadOp))
                {
                    m_UnloadingBundles.Add(location.InternalId, unloadOp);
                    unloadOp.completed += op => m_UnloadingBundles.Remove(location.InternalId);
                }
#else
                bundle.Unload();
#endif
                return;
            }
        }
    }
}

namespace UnityEngine.ResourceManagement.Exceptions
{
    /// <summary>
    /// Class representing an error occured during an operation that remotely fetch data.
    /// </summary>
    public class WXRemoteProviderException : ProviderException
    {
        /// <summary>
        /// Creates a new instance of <see cref="ProviderException"/>.
        /// </summary>
        /// <param name="message">A message describing the error.</param>
        /// <param name="location">The resource location that the operation was trying to provide.</param>
        /// <param name="uwrResult">The result of the unity web request, if any.</param>
        /// <param name="innerException">The exception that caused the error, if any.</param>
        public WXRemoteProviderException(
            string message,
            IResourceLocation location = null,
            WXUnityWebRequestResult uwrResult = null,
            Exception innerException = null
        )
            : base(message, location, innerException)
        {
            WebRequestResult = uwrResult;
        }

        ///<inheritdoc/>
        public override string Message => this.ToString();

        /// <summary>
        /// The result of the unity web request, if any.
        /// </summary>
        public WXUnityWebRequestResult WebRequestResult { get; }

        /// <summary>Provides a new string object describing the exception.</summary>
        /// <returns>A newly allocated managed string.</returns>
        public override string ToString()
        {
            if (WebRequestResult != null)
                return $"{GetType().Name} : {base.Message}\nUnityWebRequest result : {WebRequestResult}\n{InnerException}";
            else
                return base.ToString();
        }
    }
}

namespace UnityEngine.ResourceManagement.Util
{
    internal class WXUnityWebRequestUtilities
    {
        public static bool RequestHasErrors(
            UnityWebRequest webReq,
            out WXUnityWebRequestResult result
        )
        {
            result = null;
            if (webReq == null || !webReq.isDone)
                return false;

#if UNITY_2020_1_OR_NEWER
            switch (webReq.result)
            {
                case UnityWebRequest.Result.InProgress:
                case UnityWebRequest.Result.Success:
                    return false;
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                case UnityWebRequest.Result.DataProcessingError:
                    result = new WXUnityWebRequestResult(webReq);
                    return true;
                default:
                    throw new NotImplementedException(
                        $"Cannot determine whether UnityWebRequest succeeded or not from result : {webReq.result}"
                    );
            }
#else
            var isError = webReq.isHttpError || webReq.isNetworkError;
            if (isError)
                result = new UnityWebRequestResult(webReq);

            return isError;
#endif
        }

        internal static bool IsAssetBundleDownloaded(UnityWebRequestAsyncOperation op)
        {
#if ENABLE_ASYNC_ASSETBUNDLE_UWR
            var handler = (DownloadHandlerAssetBundle)op.webRequest.downloadHandler;
            if (handler != null && handler.autoLoadAssetBundle)
                return handler.isDownloadComplete;
#endif
            return op.isDone;
        }
    }

    /// <summary>
    /// Container class for the result of a unity web request.
    /// </summary>
    public class WXUnityWebRequestResult
    {
        /// <summary>
        /// Creates a new instance of <see cref="UnityWebRequestResult"/>.
        /// </summary>
        /// <param name="request">The unity web request.</param>
        public WXUnityWebRequestResult(UnityWebRequest request)
        {
            string error = request.error;
#if UNITY_2020_1_OR_NEWER
            if (
                request.result == UnityWebRequest.Result.DataProcessingError
                && request.downloadHandler != null
            )
            {
                // https://docs.unity3d.com/ScriptReference/Networking.DownloadHandler-error.html
                // When a UnityWebRequest ends with the result, UnityWebRequest.Result.DataProcessingError, the message describing the error is in the download handler
                error = $"{error} : {request.downloadHandler.error}";
            }

            Result = request.result;
#endif
            Error = error;
            ResponseCode = request.responseCode;
            Method = request.method;
            Url = request.url;
        }

        /// <summary>Provides a new string object describing the result.</summary>
        /// <returns>A newly allocated managed string.</returns>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();

#if UNITY_2020_1_OR_NEWER
            sb.AppendLine($"{Result} : {Error}");
#else
            if (!string.IsNullOrEmpty(Error))
                sb.AppendLine(Error);
#endif
            if (ResponseCode > 0)
                sb.AppendLine($"ResponseCode : {ResponseCode}, Method : {Method}");
            sb.AppendLine($"url : {Url}");

            return sb.ToString();
        }

        /// <summary>
        /// A string explaining the error that occured.
        /// </summary>
        public string Error { get; internal set; }

        /// <summary>
        /// The numeric HTTP response code returned by the server, if any.
        /// See <a href="https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest-responseCode.html">documentation</a> for more details.
        /// </summary>
        public long ResponseCode { get; }

#if UNITY_2020_1_OR_NEWER
        /// <summary>
        /// The outcome of the request.
        /// </summary>
        public UnityWebRequest.Result Result { get; }
#endif

        /// <summary>
        /// The HTTP verb used by this UnityWebRequest, such as GET or POST.
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// The target url of the request.
        /// </summary>
        public string Url { get; }

        internal bool ShouldRetryDownloadError()
        {
            if (string.IsNullOrEmpty(Error))
                return true;

            if (
                Error == "Request aborted"
                || Error == "Unable to write data"
                || Error == "Malformed URL"
                || Error == "Out of memory"
                || Error == "Encountered invalid redirect (missing Location header?)"
                || Error == "Cannot modify request at this time"
                || Error == "Unsupported Protocol"
                || Error == "Destination host has an erroneous SSL certificate"
                || Error == "Unable to load SSL Cipher for verification"
                || Error == "SSL CA certificate error"
                || Error == "Unrecognized content-encoding"
                || Error == "Request already transmitted"
                || Error == "Invalid HTTP Method"
                || Error == "Header name contains invalid characters"
                || Error == "Header value contains invalid characters"
                || Error == "Cannot override system-specified headers"
            )
                return false;

            /* Errors that can be retried:
                "Unknown Error":
                "No Internet Connection"
                "Backend Initialization Error":
                "Cannot resolve proxy":
                "Cannot resolve destination host":
                "Cannot connect to destination host":
                "Access denied":
                "Generic/unknown HTTP error":
                "Unable to read data":
                "Request timeout":
                "Error during HTTP POST transmission":
                "Unable to complete SSL connection":
                "Redirect limit exceeded":
                "Received no data in response":
                "Destination host does not support SSL":
                "Failed to transmit data":
                "Failed to receive data":
                "Login failed":
                "SSL shutdown failed":
                "Redirect limit is invalid":
                "Not implemented":
                "Data Processing Error, see Download Handler error":
             */
            return true;
        }
    }
}
