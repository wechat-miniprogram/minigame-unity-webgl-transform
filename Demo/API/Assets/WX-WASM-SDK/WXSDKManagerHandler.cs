using UnityEngine;
using System.Runtime.InteropServices;
using System;
using LitJson;
using System.Collections.Generic;
using UnityEngine.Scripting;
using AOT;

namespace WeChatWASM
{
    public class WXSDKManagerHandler : MonoBehaviour
    {

        #region Instance

        private static WXSDKManagerHandler instance = null;


        public static WXSDKManagerHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    if (!Application.isPlaying)
                    {
                        Debug.LogError("不支持在非播放模式下调用WX接口");
                        return null;
                    }
                    instance = new GameObject(typeof(WXSDKManagerHandler).Name).AddComponent<WXSDKManagerHandler>();
                    DontDestroyOnLoad(instance.gameObject);
                     #if UNITY_UI_FAIRYGUI || UNITY_UI_UGUI || UNITY_UI_NGUI
                        UnityDumper monkeyInstance = new GameObject("monkeyInstance").AddComponent(typeof(UnityDumper)) as UnityDumper;
                        DontDestroyOnLoad(monkeyInstance.gameObject);
                        SetUnityUIType("unity_ui");
                    #else
                        SetUnityUIType("unity_no_ui");
                    #endif
                }
                return instance;
            }
        }

        private static WXEnv env = null;

        public static WXEnv Env
        {
            get
            {
                if (env == null)
                {
                    env = new WXEnv();
                }
                return env;
            }
        }

        private static Cloud _cloud = null;

        public static Cloud cloud
        {
            get
            {
                if (_cloud == null)
                {
                    _cloud = new Cloud();
                }
                return _cloud;
            }
        }


        protected void OnDestroy()
        {
            if (instance != null)
                instance = null;
        }

        #endregion




        #region C#调用JS桥接方法

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXInitializeSDK(string s);
#else
        private void WXInitializeSDK(string s)
        {
            initCallback(200);
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXStorageSetIntSync(string key, int value);
#else
        void WXStorageSetIntSync(string key, int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key, value);
        }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern int WXStorageGetIntSync(string key, int defaultValue);
#else
        int WXStorageGetIntSync(string key, int defaultValue)
        {
            return UnityEngine.PlayerPrefs.GetInt(key,defaultValue);
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXStorageSetStringSync(string key, string value);
#else
        void WXStorageSetStringSync(string key, string value)
        {
            UnityEngine.PlayerPrefs.SetString(key, value);
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string WXStorageGetStringSync(string key, string defaultValue);
#else
        string WXStorageGetStringSync(string key, string defaultValue)
        {
            return UnityEngine.PlayerPrefs.GetString(key, defaultValue);
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXStorageSetFloatSync(string key, float value);
#else
        void WXStorageSetFloatSync(string key, float value)
        {
            UnityEngine.PlayerPrefs.SetFloat(key, value);
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern float WXStorageGetFloatSync(string key, float defaultValue);
#else
        float WXStorageGetFloatSync(string key, float defaultValue)
        {
            return UnityEngine.PlayerPrefs.GetFloat(key, defaultValue);
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXStorageDeleteAllSync();
#else
        void WXStorageDeleteAllSync()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXStorageDeleteKeySync(string key);
#else
        void WXStorageDeleteKeySync(string key)
        {
            UnityEngine.PlayerPrefs.DeleteKey(key);
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern bool WXStorageHasKeySync(string key);
#else
        bool WXStorageHasKeySync(string key)
        {
            return UnityEngine.PlayerPrefs.HasKey(key);
        }
#endif



#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateUserInfoButton(int x, int y, int width, int height, string lang, bool withCredentials);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXOnShareAppMessage(string conf, bool isPromise);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXOnShareAppMessageResolve(string conf);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateBannerAd(string conf);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateRewardedVideoAd(string conf);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateInterstitialAd(string conf);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateGridAd(string conf);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateCustomAd(string conf);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXADStyleChange(string id, string key, int value);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXShowAd(string id, string succ, string fail);
#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXShowAd2(string id, string branchId, string branchDim, string succ, string fail);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXHideAd(string id, string succ, string fail);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern int WXADGetStyleValue(string id, string key);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern int WXADDestroy(string id);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern int WXADLoad(string id, string succ, string fail);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateFixedBottomMiddleBannerAd(string adUnitId, int adIntervals, int height);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXDataContextPostMessage(string msg);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXShowOpenData(IntPtr id, int x, int y, int width, int height);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXHideOpenData();


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXReportGameStart();

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXSetGameStage(int stageType);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXReportGameStageCostTime(int costTime, string extJsonStr);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXReportGameStageError(int errorType, string errStr, string extJsonStr);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXWriteLog(string str);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXWriteWarn(string str);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXHideLoadingPage();

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXPreloadConcurrent(int count);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXReportUserBehaviorBranchAnalytics(string branchId, string branchDim, int eventType);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateInnerAudioContext(string src, bool loop, float startTime, bool autoplay, float volume, float playbackRate, bool needDownload);



#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXPreDownloadAudios(string paths, int num);
#else
        private static void WXPreDownloadAudios(string paths, int num)
        {
            var action = PreDownloadAudiosAction[num];
            action.Invoke(0);
        }
#endif

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXSetDataCDN(string path);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXSetPreloadList(string paths);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateVideo(string conf);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateGameClubButton(string conf);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXGameClubStyleChangeInt(string id, string key, int value);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXGameClubStyleChangeStr(string id, string key, string value);




#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void SetUnityUIType(string paths);
#else
        private static void SetUnityUIType(string paths) { }
#endif
        #endregion

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern uint WXGetTotalMemorySize();

        [DllImport("__Internal")]
        private static extern uint WXGetTotalStackSize();

        [DllImport("__Internal")]
        private static extern uint WXGetStaticMemorySize();

        [DllImport("__Internal")]
        private static extern uint WXGetDynamicMemorySize();

        [DllImport("__Internal")]
        private static extern uint WXGetUsedMemorySize();

        [DllImport("__Internal")]
        private static extern uint WXGetUnAllocatedMemorySize();

        [DllImport("__Internal")]
        private static extern void WXLogManagerDebug(string str);

        [DllImport("__Internal")]
        private static extern void WXLogManagerInfo(string str);

        [DllImport("__Internal")]
        private static extern void WXLogManagerLog(string str);

        [DllImport("__Internal")]
        private static extern void WXLogManagerWarn(string str);

        [Preserve]
        [DllImport("__Internal")]
        private static extern void WXPointer_stringify_adaptor();


#else
        private static uint WXGetTotalMemorySize() { return 0; }
        private static uint WXGetTotalStackSize() { return 0; }
        private static uint WXGetStaticMemorySize() { return 0; }
        private static uint WXGetDynamicMemorySize() { return 0; }
        private static uint WXGetUsedMemorySize() { return 0; }
        private static uint WXGetUnAllocatedMemorySize() { return 0; }

        private static void WXLogManagerDebug(string str) {
            Debug.Log(str);
        }

        private static void WXLogManagerInfo(string str)
        {
            Debug.Log(str);
        }

        private static void WXLogManagerLog(string str)
        {
            Debug.Log(str);
        }

        private static void WXLogManagerWarn(string str)
        {
            Debug.LogWarning(str);
        }

#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern bool WXIsCloudTest();
#else
        private static bool WXIsCloudTest() { return false; }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXUncaughtException();
#else
        private static void WXUncaughtException() {; }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern int WXCreateUDPSocket(string ip, int remotePort, int bindPort);
#else
        private int WXCreateUDPSocket(string ip, int remotePort, int bindPort)
        {
            throw new NotImplementedException();
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXCloseUDPSocket(int socketId);
#else
        private void WXCloseUDPSocket(int socketId)
        {
            throw new NotImplementedException();
        }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXSendUDPSocket(int socketId, byte[] buffer, int offset, int length);
#else
        private void WXSendUDPSocket(int socketId, byte[] buffer, int offset, int length)
        {
            throw new NotImplementedException();
        }
#endif


#if UNITY_WEBGL && !UNITY_EDITOR

        public delegate void OnMessageCallback(int instanceId, IntPtr msgPtr, int msgSize);
        public delegate void OnErrorCallback(int instanceId, IntPtr errorPtr);
        public delegate void OnCloseCallback(int instanceId, IntPtr reasonPtr);
        [DllImport("__Internal")]
        public static extern void WXUDPSocketSetOnMessage(OnMessageCallback callback);
        [DllImport("__Internal")]
        public static extern void WXUDPSocketSetOnClose(OnCloseCallback callback);
        [DllImport("__Internal")]
        public static extern void WXUDPSocketSetOnError(OnErrorCallback callback);

        [MonoPInvokeCallback(typeof(OnMessageCallback))]
        public static void DelegateOnMessageEvent(int instanceId, IntPtr msgPtr, int msgSize)
        {
            
           var bytes = new byte[msgSize];
           Marshal.Copy(msgPtr, bytes, 0, msgSize);
           UDPSocketManager.Instance.OnMessage(instanceId, bytes);
        }
        [MonoPInvokeCallback(typeof(OnCloseCallback))]
        public static void DelegateOnCloseEvent(int instanceId, IntPtr reasonPtr)
        {
            string reason = Marshal.PtrToStringAuto(reasonPtr);
            UDPSocketManager.Instance.OnClose(instanceId, reason);
        }
        [MonoPInvokeCallback(typeof(OnErrorCallback))]
        public static void DelegateOnErrorEvent(int instanceId, IntPtr errorPtr)
        {
            string errorMsg = Marshal.PtrToStringAuto(errorPtr);
            UDPSocketManager.Instance.OnError(instanceId, errorMsg);
        }
  
#endif


        #region JS回调

        public void Inited(int code)
        {
            initCallback(code);
        }

        public void TextResponseCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<WXTextResponse>(msg);
        }

        public void TextResponseLongCallback(string msg)
        {
            WXLongCallBackHandler.InvokeResponseCallback<WXTextResponse>(msg);
        }


        public void CloudCallFunctionResponseCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<WXCloudCallFunctionResponse>(msg);
        }


        public void UserInfoButtonOnTapCallback(string msg)
        {
            WXCallBackHandler.InvokeUserInfoButtonCallback(msg);
        }

        public void OnShareAppMessageCallback()
        {
            onShareAppMessageCallback?.Invoke((WXShareAppMessageParam param) =>
            {
                if (param == null)
                {
                    param = new WXShareAppMessageParam();
                }
                WXOnShareAppMessageResolve(JsonUtility.ToJson(param));
            });

        }


        public void ADOnErrorCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXADErrorResponse>(msg);
            if (WXBaseAd.Dict.ContainsKey(res.callbackId))
            {
                WXBaseAd.Dict[res.callbackId].onErrorAction?.Invoke(res);
            }
        }

        public void ADOnLoadCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXADLoadResponse>(msg);
            if (WXBaseAd.Dict.ContainsKey(res.callbackId))
            {
                WXBaseAd.Dict[res.callbackId].onLoadActon?.Invoke(res);
            }
        }


        public void ADOnResizeCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXADResizeResponse>(msg);

            if (WXBaseAd.Dict.ContainsKey(res.callbackId))
            {
                var ad = (IWXAdResizable)WXBaseAd.Dict[res.callbackId];
                ad.OnResizeCallback(res);
            }
        }

        public void ADOnVideoCloseCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXRewardedVideoAdOnCloseResponse>(msg);


            if (WXBaseAd.Dict.ContainsKey(res.callbackId))
            {
                var ad = (IWXAdVideoCloseable)WXBaseAd.Dict[res.callbackId];
                ad.OnCloseCallback(res);
            }
        }

        public void ADOnCloseCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXBaseResponse>(msg);


            if (WXBaseAd.Dict.ContainsKey(res.callbackId))
            {
                var ad = (IWXADCloseable)WXBaseAd.Dict[res.callbackId];
                ad.OnCloseCallback();
            }
        }


        public void ADLoadErrorCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<WXADErrorResponse>(msg);
        }


        public void OnGameClubButtonCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXBaseResponse>(msg);

            if (WXGameClubButton.Dict.ContainsKey(res.callbackId)) {
                var gameClubButton = WXGameClubButton.Dict[res.callbackId];
                gameClubButton._HandleCallBack(res.errMsg);
            }

        }

        public void OnAudioCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXBaseResponse>(msg);

            if (WXInnerAudioContext.Dict.ContainsKey(res.callbackId)) {
                var audio = WXInnerAudioContext.Dict[res.callbackId];
                audio._HandleCallBack(res.errMsg);
            }

        }

        public void WXPreDownloadAudiosCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXBaseResponse>(msg);
            int.TryParse(res.callbackId, out int id);
            if (PreDownloadAudiosAction.ContainsKey(id)) {
                var action = PreDownloadAudiosAction[id];
                action.Invoke(res.errMsg == "0" ? 0 : 1);
            }

        }

        public void OnVideoCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXVideoCallback>(msg);
            if (WXVideo._Dict.ContainsKey(res.callbackId)) {
                var video = WXVideo._Dict[res.callbackId];
                video._HandleCallBack(res);
            }

        }

        public void ReadFileCallback(string msg)
        {
            WXFileSystemManager.HandleReadFileCallback(msg);
        }

        public void StatCallback(string msg)
        {
            WXFileSystemManager.HandleStatCallback(msg);
        }

        public void ToTempFilePathCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<ToTempFilePathParamSuccessCallbackResult>(msg);
        }

#endregion



        #region 初始化SDK
        public void InitSDK(Action<int> callback)
        {

            initCallback = callback;

            WXInitializeSDK(Application.unityVersion);

#if UNITY_WEBGL && !UNITY_EDITOR
            WXUDPSocketSetOnMessage(DelegateOnMessageEvent);
            WXUDPSocketSetOnClose(DelegateOnCloseEvent);
            WXUDPSocketSetOnError(DelegateOnErrorEvent);
#endif
        }


        private Action<int> initCallback;



#endregion




#region 本地存储
        // 更多关于存储的隔离策略和清理策略说明可以查看这里 https://developers.weixin.qq.com/minigame/dev/guide/base-ability/storage.html

        /*
         * @description 同步设置int型数据存储，
         * @param key 键名
         * @param value 数值
         */
        public void StorageSetIntSync(string key, int value)
        {
            WXStorageSetIntSync(key, value);
        }


        /*
         * @description 同步获取之前设置过的int型数据，
         * @param key 键名
         * @param defaultValue 默认值
         * @returns 异常的和空时候会返回默认值
         */
        public int StorageGetIntSync(string key, int defaultValue)
        {
            return WXStorageGetIntSync(key, defaultValue);
        }



        /*
         * @description 同步设置string型数据存储，
         * @param key 键名
         * @param value 数值
         */
        public void StorageSetStringSync(string key, string value)
        {
            WXStorageSetStringSync(key, value);
        }


        /*
         * @description 同步获取之前设置过的string型数据，
         * @param key 键名
         * @param defaultValue 默认值
         * @returns 异常的和空时候会返回默认值
         */
        public string StorageGetStringSync(string key, string defaultValue)
        {
            return WXStorageGetStringSync(key, defaultValue);
        }


        /*
         * @description 同步设置float型数据存储，
         * @param key 键名
         * @param value 数值
         */
        public void StorageSetFloatSync(string key, float value)
        {
            WXStorageSetFloatSync(key, value);
        }


        /*
         * @description 同步获取之前设置过的float型数据，
         * @param key 键名
         * @param defaultValue 默认值
         * @returns 异常的和空时候会返回默认值
         */
        public float StorageGetFloatSync(string key, float defaultValue)
        {
            return WXStorageGetFloatSync(key, defaultValue);
        }

        /*
         * @description 同步删除所有数据
         */
        public void StorageDeleteAllSync()
        {
            WXStorageDeleteAllSync();
        }



        /*
         * @description 同步删除对应一个key的数据
         * @param key 键名
         */
        public void StorageDeleteKeySync(string key)
        {
            WXStorageDeleteKeySync(key);
        }


        public bool StorageHasKeySync(string key)
        {
            return WXStorageHasKeySync(key);
        }

#endregion



#region 用户信息


        public WXUserInfoButton CreateUserInfoButton(int x, int y, int width, int height, string lang, bool withCredentials)
        {
            string id = WXCreateUserInfoButton(x, y, width, height, lang, withCredentials);

            var button = new WXUserInfoButton(id);

            WXUserInfoButton.Dict.Add(id, button);

            return button;

        }


#endregion



#region 分享转发

        private Action<Action<WXShareAppMessageParam>> onShareAppMessageCallback;

        public void OnShareAppMessage(WXShareAppMessageParam defaultParam, Action<Action<WXShareAppMessageParam>> action)
        {
            if (defaultParam == null)
            {
                defaultParam = new WXShareAppMessageParam();
            }
            WXOnShareAppMessage(JsonUtility.ToJson(defaultParam), action != null);
            onShareAppMessageCallback = action;
        }

#endregion


#region 广告

        public WXBannerAd CreateBannerAd(WXCreateBannerAdParam param)
        {
            if (param == null)
            {
                param = new WXCreateBannerAdParam();
            }
            param.styleRaw = JsonUtility.ToJson(param.style);

            string id = WXCreateBannerAd(JsonUtility.ToJson(param));

            return new WXBannerAd(id, param.style);
        }

        public WXBannerAd CreateFixedBottomMiddleBannerAd(string adUnitId, int adIntervals, int height)
        {
            string id = WXCreateFixedBottomMiddleBannerAd(adUnitId, adIntervals, height);

            return new WXBannerAd(id, new Style()
            {
                height = height
            });

        }


        public WXRewardedVideoAd CreateRewardedVideoAd(WXCreateRewardedVideoAdParam param)
        {
            if (param == null)
            {
                param = new WXCreateRewardedVideoAdParam();
            }

            string id = WXCreateRewardedVideoAd(JsonUtility.ToJson(param));

            return new WXRewardedVideoAd(id);
        }

        public WXInterstitialAd CreateInterstitialAd(WXCreateInterstitialAdParam param)
        {

            if (param == null)
            {
                param = new WXCreateInterstitialAdParam();
            }
            string id = WXCreateInterstitialAd(JsonUtility.ToJson(param));

            return new WXInterstitialAd(id);
        }

        public WXGridAd CreateGridAd(WXCreateGridAdParam param)
        {
            if (param == null)
            {
                param = new WXCreateGridAdParam();
            }
            param.styleRaw = JsonUtility.ToJson(param.style);

            string id = WXCreateGridAd(JsonUtility.ToJson(param));

            return new WXGridAd(id, param.style);
        }

        public WXCustomAd CreateCustomAd(WXCreateCustomAdParam param)
        {
            if (param == null)
            {
                param = new WXCreateCustomAdParam();
            }
            param.styleRaw = JsonUtility.ToJson(param.style);

            string id = WXCreateCustomAd(JsonUtility.ToJson(param));

            return new WXCustomAd(id, param.style);
        }

        public void ADStyleChange(string id, string key, int value)
        {
            WXADStyleChange(id, key, value);
        }

        public void ShowAd(string id, string succ, string fail)
        {
            WXShowAd(id, succ, fail);
        }

        internal int CreateUDPSocket(string ip, int remotePort, int bindPort)
        {
            return WXCreateUDPSocket(ip, remotePort, bindPort);
        }

        internal void CloseUDPSocket(int socketId)
        {
            WXCloseUDPSocket(socketId);
        }

        internal void SendUDPSocket(int socketId, byte[] buffer, int offset, int length)
        {
            WXSendUDPSocket(socketId, buffer, offset, length);
        } 

        public void ShowAd(string id, string branchId, string branchDim, string succ, string fail)
        {
            WXShowAd2(id, branchId, branchDim, succ, fail);
        }

        public void HideAd(string id, string succ = "", string fail = "")
        {
            WXHideAd(id, succ, fail);
        }

        public int ADGetStyleValue(string id, string key)
        {
            return WXADGetStyleValue(id, key);
        }

        public void ADDestroy(string id)
        {
            WXADDestroy(id);
        }

        public void ADLoad(string id, string succ, string fail)
        {
            WXADLoad(id, succ, fail);
        }

#endregion


#region 开放数据域，排行榜这一类

        public void OpenDataContextPostMessage(string msg)
        {
            WXDataContextPostMessage(msg);
        }


        public void ShowOpenData(Texture texture, int x, int y, int width, int height)
        {
            WXShowOpenData(texture.GetNativeTexturePtr(), x, y, width, height);
        }


        public void HideOpenData()
        {
            WXHideOpenData();
        }



#endregion


#region 游戏上报

        public void ReportGameStart()
        {
            WXReportGameStart();
        }

        public void SetGameStage(int stageType)
        {
            WXSetGameStage(stageType);
        }

        public void ReportGameStageCostTime(int costTime, string extJsonStr)
        {
            WXReportGameStageCostTime(costTime, extJsonStr);
        }

        public void ReportGameStageError(int errorType, string errStr, string extJsonStr)
        {
            WXReportGameStageError(errorType, errStr, extJsonStr);
        }

        public void WriteLog(string str)
        {
            WXWriteLog(str);
        }

        public void WriteWarn(string str)
        {
            WXWriteWarn(str);
        }

        public void HideLoadingPage()
        {
            WXHideLoadingPage();
        }

        public void PreloadConcurrent(int count)
        {
            WXPreloadConcurrent(count);
        }

        public void ReportUserBehaviorBranchAnalytics(string branchId, string branchDim, int eventType)
        {
            WXReportUserBehaviorBranchAnalytics(branchId, branchDim, eventType);
        }

#endregion


#region 音频
        public WXInnerAudioContext CreateInnerAudioContext(InnerAudioContextParam param = null)
        {
            if (param == null)
            {
                param = new InnerAudioContextParam();
            }
#if UNITY_WEBGL && !UNITY_EDITOR
            var id = WXCreateInnerAudioContext(param.src, param.loop, param.startTime, param.autoplay, param.volume, param.playbackRate, param.needDownload);
            return new WXInnerAudioContext(id, param);
#else
            var rd = UnityEngine.Random.Range(0f, 1000000f);
            var id2 = rd.ToString() + param.src;
            return new WXInnerAudioContext(id2, param);
#endif
        }

        private static Dictionary<int, Action<int>> PreDownloadAudiosAction = new Dictionary<int, Action<int>>();


        public void PreDownloadAudios(string[] pathList, Action<int> action)
        {
            int num = PreDownloadAudiosAction.Count;
            PreDownloadAudiosAction.Add(num, action);
            WXPreDownloadAudios(string.Join(",", pathList), num);
        }

#endregion

#region 视频
        public WXVideo CreateVideo(WXCreateVideoParam param)
        {

#if UNITY_WEBGL && !UNITY_EDITOR
            var id = WXCreateVideo(JsonUtility.ToJson(param));
            return new WXVideo(id, param);

#else
            var rd = UnityEngine.Random.Range(0f, 1000000f);
            var id2 = rd.ToString() + param.src;
            return new WXVideo(id2, param);
#endif
        }
#endregion


#region 性能
        public uint GetTotalMemorySize()
        {
            return WXGetTotalMemorySize();
        }
        public uint GetTotalStackSize()
        {
            return WXGetStaticMemorySize();
        }
        public uint GetStaticMemorySize()
        {
            return WXGetStaticMemorySize();
        }
        public uint GetDynamicMemorySize()
        {
            return WXGetDynamicMemorySize();
        }
        public uint GetUsedMemorySize()
        {
            return WXGetUsedMemorySize();
        }
        public uint GetUnAllocatedMemorySize()
        {
            return WXGetUnAllocatedMemorySize();
        }
        public void LogUnityHeapMem()
        {
            const uint sizeInMB = 1024 * 1024;
            var total = GetTotalMemorySize() / sizeInMB;
            var dynamic = WXGetDynamicMemorySize() / sizeInMB;
            Debug.Log($"WebGL Memory - Total:{total}MB, Dynamic:{dynamic}MB, " +
                $"MonoUsedSize:{UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong() / sizeInMB}MB," +
                $"MonoHeapSize:{UnityEngine.Profiling.Profiler.GetMonoHeapSizeLong() / sizeInMB}MB");

        }

        public void OpenProfileStats()
        {
            this.gameObject.AddComponent<WXProfileStatsScript>();
        }
        #endregion


#region 用户日志(MP后台可下载的用户日志)

        public void LogManagerDebug(string str)
        {
            WXLogManagerDebug(str);
        }

        public void LogManagerInfo(string str)
        {
            WXLogManagerInfo(str);
        }

        public void LogManagerLog(string str)
        {
            WXLogManagerLog(str);
        }

        public void LogManagerWarn(string str)
        {
            WXLogManagerWarn(str);
        }
#endregion

#region 云测试
        public bool IsCloudTest()
        {
            return WXIsCloudTest();
        }
#endregion

#region 异常上报
        public void UncaughtException()
        {
            WXUncaughtException();
        }
        #endregion




        #region 交互


        public WXGameClubButton CreateGameClubButton(WXCreateGameClubButtonParam param)
        {

#if UNITY_WEBGL && !UNITY_EDITOR
            param.styleRaw = JsonUtility.ToJson(param.style);
            var id = WXCreateGameClubButton(JsonUtility.ToJson(param));
            return new WXGameClubButton(id, param.style);
#else
            var id = UnityEngine.Random.Range(0f, 1000000f).ToString();
            return new WXGameClubButton(id, param.style);
#endif
        }

        public void GameClubStyleChangeInt(string id, string key, int value)
        {
            WXGameClubStyleChangeInt(id, key, value);
        }

        public void GameClubStyleChangeStr(string id, string key, string value)
        {
            WXGameClubStyleChangeStr(id, key, value);
        }

        #endregion

        #region 文件缓存清理
        public void CleanAllFileCache(Action<bool> action)
        {
        new WXFileCacheCleanTask(true, action);
        }
		public void CleanAllFileCacheCallback(string msg) {
			if (!string.IsNullOrEmpty(msg)) {
				var res = JsonUtility.FromJson<FileCacheCommonParams>(msg);
				var id = res.callbackId;
				var result = res.result;
				if (WXFileCacheCleanTask.Dict.ContainsKey(id)) {
					WXFileCacheCleanTask.Dict[id].OnCleanAllFileCacheAction?.Invoke(result);
					WXFileCacheCleanTask.Dict.Remove(id);
				}
			}
		}
        public void CleanFileCache(int fileSize, Action<ReleaseResult> action)
        {
            new WXFileCacheCleanTask(fileSize, action);
        }
		public void CleanFileCacheCallback(string msg) {
			if (!string.IsNullOrEmpty(msg)) {
				var res = JsonUtility.FromJson<CleanFileCacheParams>(msg);
				var id = res.callbackId;
				var result = res.result;
				if (WXFileCacheCleanTask.Dict.ContainsKey(id)) {
					WXFileCacheCleanTask.Dict[id].OnCleanFileCacheAction?.Invoke(result);
					WXFileCacheCleanTask.Dict.Remove(id);
				}
			}
		}
        public void RemoveFile(string path, Action<bool> action)
        {
			new WXFileCacheCleanTask(path, action);
        }
		public void RemoveFileCallback(string msg) {
			if (!string.IsNullOrEmpty(msg)) {
				var res = JsonUtility.FromJson<FileCacheCommonParams>(msg);
				var id = res.callbackId;
				var result = res.result;
				if (WXFileCacheCleanTask.Dict.ContainsKey(id)) {
					WXFileCacheCleanTask.Dict[id].OnRemoveFileAction?.Invoke(result);
					WXFileCacheCleanTask.Dict.Remove(id);
				}
			}
		}
        #endregion

        public void OnLaunchProgress(Action<LaunchEvent> action)
        {
            new WXLaunchEventListener(action);
        }

        public void OnLaunchProgressCallback(string msg) {
            if (!string.IsNullOrEmpty(msg)) {
				var result = JsonUtility.FromJson<LaunchProgressParams>(msg);
				var id = result.callbackId;
				var res = result.res;
				if (WXLaunchEventListener.Dict.ContainsKey(id)) {
					WXLaunchEventListener.Dict[id].OnLaunchProgressAction?.Invoke(JsonMapper.ToObject<LaunchEvent>(res));
				}
			}
        }

        public void RemoveLaunchProgressCallback(string msg) {
            if (!string.IsNullOrEmpty(msg)) {
				var result = JsonUtility.FromJson<WXBaseResponse>(msg);
				var id = result.callbackId;
				if (WXLaunchEventListener.Dict.ContainsKey(id)) {
					WXLaunchEventListener.Dict.Remove(id);
				}
			}
        }

        #region
        public void SetDataCDN(string path) {
            if (!string.IsNullOrEmpty(path)) {
                WXSetDataCDN(path);
            }
        }
        public void SetPreloadList(string[] paths) {
            if (paths.Length > 0) {
                WXSetPreloadList(string.Join(",", paths));
            }
        }
        #endregion


        #if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]    
        private static extern void WX_SetPreferredFramesPerSecond(double fps);
        #else
        private static void WX_SetPreferredFramesPerSecond(double fps) { Application.targetFrameRate = (int)(fps); }
        #endif
        public void SetPreferredFramesPerSecond(double fps)
        {
    
                WX_SetPreferredFramesPerSecond(fps);
        }
    
        #if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern string WXCameraCreateCamera(string option);
        #else
        private static string WXCameraCreateCamera(string option) { Debug.Log("需要在真机环境创建"); return ""; }
        #endif
        private Dictionary<string, WXCamera> CameraList = new Dictionary<string, WXCamera>();
        public WXCamera CreateCamera(CreateCameraOption option)
        {
            var id = WXCameraCreateCamera(JsonMapper.ToJson(option));
            var obj = new WXCamera(id);
            CameraList.Add(id,obj);
            return obj; 
        }
    
        public void CameraOnAuthCancelCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                if(!WXCamera.OnAuthCancelActionList.ContainsKey(id)){
                    return;
                }
                WXCamera.OnAuthCancelActionList[id]?.Invoke();
            }
        }

        #if UNITY_WEBGL
            [DllImport("__Internal")]
        #endif
        private static extern string WXCameraArrayBuffer(byte[] data, string callbackId);

        public void CameraOnCameraFrameCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                var res = jsCallback.res;
                if(!WXCamera.OnCameraFrameActionList.ContainsKey(id)){
                    return;
                }
                var result = JsonMapper.ToObject<OnCameraFrameCallbackResult>(res);
                var arrayBuffer = new byte[result.width * result.height * 4];
                WXCameraArrayBuffer(arrayBuffer, id);
                var obj = new OnCameraFrameCallbackResult()
                {
                    width = result.width,
                    height = result.height,
                    data = arrayBuffer
                };
                WXCamera.OnCameraFrameActionList[id]?.Invoke(obj);
            }
        }

        public void CameraOnStopCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                if(!WXCamera.OnStopActionList.ContainsKey(id)){
                    return;
                }
                WXCamera.OnStopActionList[id]?.Invoke();
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WX_GetRecorderManager();
        private Dictionary<string, WXRecorderManager> RecorderManagerList = new Dictionary<string, WXRecorderManager>();
        public WXRecorderManager GetRecorderManager()
        {
            var id = WX_GetRecorderManager();
            var obj = new WXRecorderManager(id);
            RecorderManagerList.Add(id,obj);
            return obj; 
        }

        public void _OnRecorderErrorCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                if(!WXRecorderManager.OnRecorderErrorActionList.ContainsKey(id)){
                    return;
                }
                WXRecorderManager.OnRecorderErrorActionList[id]?.Invoke();
            }
        }

        #if UNITY_WEBGL
            [DllImport("__Internal")]
        #endif
        private static extern string WXRecorderArrayBuffer(byte[] data, string callbackId);
        
        public void _OnRecorderFrameRecordedCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                var res = jsCallback.res;
                if(!WXRecorderManager.OnRecorderFrameRecordedActionList.ContainsKey(id)){
                    return;
                }
                var result = JsonMapper.ToObject<OnFrameRecordedBufferCallbackResult>(res);
                var arrayBuffer = new byte[result.frameBufferLength];
                WXRecorderArrayBuffer(arrayBuffer, id);
                var obj = new OnFrameRecordedCallbackResult()
                {
                    isLastFrame = result.isLastFrame,
                    frameBuffer = arrayBuffer
                };
                WXRecorderManager.OnRecorderFrameRecordedActionList[id]?.Invoke(obj);
            }
        }
        
        public void _OnRecorderInterruptionBeginCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                if(!WXRecorderManager.OnRecorderInterruptionBeginActionList.ContainsKey(id)){
                    return;
                }
                WXRecorderManager.OnRecorderInterruptionBeginActionList[id]?.Invoke();
            }
        }
        
        public void _OnRecorderInterruptionEndCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                if(!WXRecorderManager.OnRecorderInterruptionEndActionList.ContainsKey(id)){
                    return;
                }
                WXRecorderManager.OnRecorderInterruptionEndActionList[id]?.Invoke();
            }
        }
        
        public void _OnRecorderPauseCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                if(!WXRecorderManager.OnRecorderPauseActionList.ContainsKey(id)){
                    return;
                }
                WXRecorderManager.OnRecorderPauseActionList[id]?.Invoke();
            }
        }
        
        public void _OnRecorderStartCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                if(!WXRecorderManager.OnRecorderStartActionList.ContainsKey(id)){
                    return;
                }
                WXRecorderManager.OnRecorderStartActionList[id]?.Invoke();
            }
        }
        
        public void _OnRecorderStopCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                var res = jsCallback.res;
                if(!WXRecorderManager.OnRecorderStopActionList.ContainsKey(id)){
                    return;
                }
                var result = JsonMapper.ToObject<OnStopCallbackResult>(res);
                WXRecorderManager.OnRecorderStopActionList[id]?.Invoke(result);
            }
        }
        
        public void _OnRecorderResumeCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                if(!WXRecorderManager.OnRecorderResumeActionList.ContainsKey(id)){
                    return;
                }
                WXRecorderManager.OnRecorderResumeActionList[id]?.Invoke();
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WX_UploadFile(string option, string id);
        private Dictionary<string, UploadFileOption> UploadTaskList = new Dictionary<string, UploadFileOption>();
        public WXUploadTask UploadFile(UploadFileOption option)
        {
            string id = GetCallbackId(UploadTaskList);
            var callback = new UploadFileOption(){
                success = option.success,
                fail = option.fail,
                complete = option.complete
            };
            UploadTaskList.Add( id, callback );
            var succ = option.success;
            var fail = option.fail;
            var comp = option.complete;
            option.success = null;
            option.fail = null;
            option.complete = null;
            var conf = JsonMapper.ToJson(option);
            option.success = succ;
            option.fail = fail;
            option.complete = comp;
            WX_UploadFile(conf, id);
            var obj = new WXUploadTask(id);
            return obj; 
        }
        
        public void UploadFileCallback(string msg) {
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                var type = jsCallback.type;
                var res = jsCallback.res;
                if(UploadTaskList.ContainsKey(id)){
                    var item = UploadTaskList[id];
                    if(type == "complete"){
                        item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                        item.complete = null;
                    }else{
                        if(type == "success"){
                            item.success?.Invoke(JsonMapper.ToObject<UploadFileSuccessCallbackResult>(res));
                        }
                        else if(type == "fail"){
                            item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                        }
                        item.success = null;
                        item.fail = null;
                    }
                    if(item.complete == null && item.success == null && item.fail == null){
                        UploadTaskList.Remove(id);
                    }
                }
            }
        }
    
        public void _OnHeadersReceivedCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                var res = jsCallback.res;
                if(!WXUploadTask.OnHeadersReceivedActionList.ContainsKey(id)){
                    return;
                }
                var result = JsonMapper.ToObject<OnHeadersReceivedCallbackResult>(msg);
                WXUploadTask.OnHeadersReceivedActionList[id]?.Invoke(result);
            }
        }
    
        public void _OnProgressUpdateCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
                var id = jsCallback.callbackId;
                var res = jsCallback.res;
                if(!WXUploadTask.OnProgressUpdateActionList.ContainsKey(id)){
                    return;
                }
                var result = JsonMapper.ToObject<UploadTaskOnProgressUpdateCallbackResult>(msg);
                WXUploadTask.OnProgressUpdateActionList[id]?.Invoke(result);
            }
        }
    
    public static string GetCallbackId<T>(Dictionary<string, T> dict) {
        var id = dict.Count;
        var res = (id + UnityEngine.Random.value).ToString();
        while (dict.ContainsKey(res))
        {
            id++;
            res = (id + UnityEngine.Random.value).ToString();
        }
        return res;
    }
    public void AddCardCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && AddCardOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(AddCardOptionList.ContainsKey(id)){
                var item = AddCardOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<AddCardSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    AddCardOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_AddCard(string conf, string callbackId);
    #else
    private void WX_AddCard(string conf, string callbackId){}
    #endif

    private Dictionary<string, AddCardOption> AddCardOptionList;
    public void AddCard(AddCardOption option)
    {
        if(AddCardOptionList == null){
            AddCardOptionList = new Dictionary<string, AddCardOption>();
        }
        string id = GetCallbackId(AddCardOptionList);
        var callback = new AddCardOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        AddCardOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_AddCard(conf,id);
    }
    public void AuthPrivateMessageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && AuthPrivateMessageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(AuthPrivateMessageOptionList.ContainsKey(id)){
                var item = AuthPrivateMessageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<AuthPrivateMessageSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    AuthPrivateMessageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_AuthPrivateMessage(string conf, string callbackId);
    #else
    private void WX_AuthPrivateMessage(string conf, string callbackId){}
    #endif

    private Dictionary<string, AuthPrivateMessageOption> AuthPrivateMessageOptionList;
    public void AuthPrivateMessage(AuthPrivateMessageOption option)
    {
        if(AuthPrivateMessageOptionList == null){
            AuthPrivateMessageOptionList = new Dictionary<string, AuthPrivateMessageOption>();
        }
        string id = GetCallbackId(AuthPrivateMessageOptionList);
        var callback = new AuthPrivateMessageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        AuthPrivateMessageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_AuthPrivateMessage(conf,id);
    }
    public void AuthorizeCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && AuthorizeOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(AuthorizeOptionList.ContainsKey(id)){
                var item = AuthorizeOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    AuthorizeOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_Authorize(string conf, string callbackId);
    #else
    private void WX_Authorize(string conf, string callbackId){}
    #endif

    private Dictionary<string, AuthorizeOption> AuthorizeOptionList;
    public void Authorize(AuthorizeOption option)
    {
        if(AuthorizeOptionList == null){
            AuthorizeOptionList = new Dictionary<string, AuthorizeOption>();
        }
        string id = GetCallbackId(AuthorizeOptionList);
        var callback = new AuthorizeOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        AuthorizeOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_Authorize(conf,id);
    }
    public void CheckIsUserAdvisedToRestCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && CheckIsUserAdvisedToRestOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(CheckIsUserAdvisedToRestOptionList.ContainsKey(id)){
                var item = CheckIsUserAdvisedToRestOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<CheckIsUserAdvisedToRestSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    CheckIsUserAdvisedToRestOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_CheckIsUserAdvisedToRest(string conf, string callbackId);
    #else
    private void WX_CheckIsUserAdvisedToRest(string conf, string callbackId){}
    #endif

    private Dictionary<string, CheckIsUserAdvisedToRestOption> CheckIsUserAdvisedToRestOptionList;
    public void CheckIsUserAdvisedToRest(CheckIsUserAdvisedToRestOption option)
    {
        if(CheckIsUserAdvisedToRestOptionList == null){
            CheckIsUserAdvisedToRestOptionList = new Dictionary<string, CheckIsUserAdvisedToRestOption>();
        }
        string id = GetCallbackId(CheckIsUserAdvisedToRestOptionList);
        var callback = new CheckIsUserAdvisedToRestOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        CheckIsUserAdvisedToRestOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_CheckIsUserAdvisedToRest(conf,id);
    }
    public void CheckSessionCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && CheckSessionOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(CheckSessionOptionList.ContainsKey(id)){
                var item = CheckSessionOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    CheckSessionOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_CheckSession(string conf, string callbackId);
    #else
    private void WX_CheckSession(string conf, string callbackId){}
    #endif

    private Dictionary<string, CheckSessionOption> CheckSessionOptionList;
    public void CheckSession(CheckSessionOption option)
    {
        if(CheckSessionOptionList == null){
            CheckSessionOptionList = new Dictionary<string, CheckSessionOption>();
        }
        string id = GetCallbackId(CheckSessionOptionList);
        var callback = new CheckSessionOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        CheckSessionOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_CheckSession(conf,id);
    }
    public void ChooseImageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ChooseImageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ChooseImageOptionList.ContainsKey(id)){
                var item = ChooseImageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<ChooseImageSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ChooseImageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ChooseImage(string conf, string callbackId);
    #else
    private void WX_ChooseImage(string conf, string callbackId){}
    #endif

    private Dictionary<string, ChooseImageOption> ChooseImageOptionList;
    public void ChooseImage(ChooseImageOption option)
    {
        if(ChooseImageOptionList == null){
            ChooseImageOptionList = new Dictionary<string, ChooseImageOption>();
        }
        string id = GetCallbackId(ChooseImageOptionList);
        var callback = new ChooseImageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ChooseImageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ChooseImage(conf,id);
    }
    public void CloseBLEConnectionCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && CloseBLEConnectionOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(CloseBLEConnectionOptionList.ContainsKey(id)){
                var item = CloseBLEConnectionOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    CloseBLEConnectionOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_CloseBLEConnection(string conf, string callbackId);
    #else
    private void WX_CloseBLEConnection(string conf, string callbackId){}
    #endif

    private Dictionary<string, CloseBLEConnectionOption> CloseBLEConnectionOptionList;
    public void CloseBLEConnection(CloseBLEConnectionOption option)
    {
        if(CloseBLEConnectionOptionList == null){
            CloseBLEConnectionOptionList = new Dictionary<string, CloseBLEConnectionOption>();
        }
        string id = GetCallbackId(CloseBLEConnectionOptionList);
        var callback = new CloseBLEConnectionOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        CloseBLEConnectionOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_CloseBLEConnection(conf,id);
    }
    public void CloseBluetoothAdapterCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && CloseBluetoothAdapterOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(CloseBluetoothAdapterOptionList.ContainsKey(id)){
                var item = CloseBluetoothAdapterOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    CloseBluetoothAdapterOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_CloseBluetoothAdapter(string conf, string callbackId);
    #else
    private void WX_CloseBluetoothAdapter(string conf, string callbackId){}
    #endif

    private Dictionary<string, CloseBluetoothAdapterOption> CloseBluetoothAdapterOptionList;
    public void CloseBluetoothAdapter(CloseBluetoothAdapterOption option)
    {
        if(CloseBluetoothAdapterOptionList == null){
            CloseBluetoothAdapterOptionList = new Dictionary<string, CloseBluetoothAdapterOption>();
        }
        string id = GetCallbackId(CloseBluetoothAdapterOptionList);
        var callback = new CloseBluetoothAdapterOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        CloseBluetoothAdapterOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_CloseBluetoothAdapter(conf,id);
    }
    public void CloseSocketCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && CloseSocketOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(CloseSocketOptionList.ContainsKey(id)){
                var item = CloseSocketOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    CloseSocketOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_CloseSocket(string conf, string callbackId);
    #else
    private void WX_CloseSocket(string conf, string callbackId){}
    #endif

    private Dictionary<string, CloseSocketOption> CloseSocketOptionList;
    public void CloseSocket(CloseSocketOption option)
    {
        if(CloseSocketOptionList == null){
            CloseSocketOptionList = new Dictionary<string, CloseSocketOption>();
        }
        string id = GetCallbackId(CloseSocketOptionList);
        var callback = new CloseSocketOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        CloseSocketOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_CloseSocket(conf,id);
    }
    public void CreateBLEConnectionCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && CreateBLEConnectionOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(CreateBLEConnectionOptionList.ContainsKey(id)){
                var item = CreateBLEConnectionOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    CreateBLEConnectionOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_CreateBLEConnection(string conf, string callbackId);
    #else
    private void WX_CreateBLEConnection(string conf, string callbackId){}
    #endif

    private Dictionary<string, CreateBLEConnectionOption> CreateBLEConnectionOptionList;
    public void CreateBLEConnection(CreateBLEConnectionOption option)
    {
        if(CreateBLEConnectionOptionList == null){
            CreateBLEConnectionOptionList = new Dictionary<string, CreateBLEConnectionOption>();
        }
        string id = GetCallbackId(CreateBLEConnectionOptionList);
        var callback = new CreateBLEConnectionOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        CreateBLEConnectionOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_CreateBLEConnection(conf,id);
    }
    public void CreateBLEPeripheralServerCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && CreateBLEPeripheralServerOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(CreateBLEPeripheralServerOptionList.ContainsKey(id)){
                var item = CreateBLEPeripheralServerOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<CreateBLEPeripheralServerSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    CreateBLEPeripheralServerOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_CreateBLEPeripheralServer(string conf, string callbackId);
    #else
    private void WX_CreateBLEPeripheralServer(string conf, string callbackId){}
    #endif

    private Dictionary<string, CreateBLEPeripheralServerOption> CreateBLEPeripheralServerOptionList;
    public void CreateBLEPeripheralServer(CreateBLEPeripheralServerOption option)
    {
        if(CreateBLEPeripheralServerOptionList == null){
            CreateBLEPeripheralServerOptionList = new Dictionary<string, CreateBLEPeripheralServerOption>();
        }
        string id = GetCallbackId(CreateBLEPeripheralServerOptionList);
        var callback = new CreateBLEPeripheralServerOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        CreateBLEPeripheralServerOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_CreateBLEPeripheralServer(conf,id);
    }
    public void ExitMiniProgramCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ExitMiniProgramOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ExitMiniProgramOptionList.ContainsKey(id)){
                var item = ExitMiniProgramOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ExitMiniProgramOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ExitMiniProgram(string conf, string callbackId);
    #else
    private void WX_ExitMiniProgram(string conf, string callbackId){}
    #endif

    private Dictionary<string, ExitMiniProgramOption> ExitMiniProgramOptionList;
    public void ExitMiniProgram(ExitMiniProgramOption option)
    {
        if(ExitMiniProgramOptionList == null){
            ExitMiniProgramOptionList = new Dictionary<string, ExitMiniProgramOption>();
        }
        string id = GetCallbackId(ExitMiniProgramOptionList);
        var callback = new ExitMiniProgramOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ExitMiniProgramOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ExitMiniProgram(conf,id);
    }
    public void ExitVoIPChatCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ExitVoIPChatOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ExitVoIPChatOptionList.ContainsKey(id)){
                var item = ExitVoIPChatOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ExitVoIPChatOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ExitVoIPChat(string conf, string callbackId);
    #else
    private void WX_ExitVoIPChat(string conf, string callbackId){}
    #endif

    private Dictionary<string, ExitVoIPChatOption> ExitVoIPChatOptionList;
    public void ExitVoIPChat(ExitVoIPChatOption option)
    {
        if(ExitVoIPChatOptionList == null){
            ExitVoIPChatOptionList = new Dictionary<string, ExitVoIPChatOption>();
        }
        string id = GetCallbackId(ExitVoIPChatOptionList);
        var callback = new ExitVoIPChatOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ExitVoIPChatOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ExitVoIPChat(conf,id);
    }
    public void FaceDetectCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && FaceDetectOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(FaceDetectOptionList.ContainsKey(id)){
                var item = FaceDetectOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<FaceDetectSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    FaceDetectOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_FaceDetect(string conf, string callbackId);
    #else
    private void WX_FaceDetect(string conf, string callbackId){}
    #endif

    private Dictionary<string, FaceDetectOption> FaceDetectOptionList;
    public void FaceDetect(FaceDetectOption option)
    {
        if(FaceDetectOptionList == null){
            FaceDetectOptionList = new Dictionary<string, FaceDetectOption>();
        }
        string id = GetCallbackId(FaceDetectOptionList);
        var callback = new FaceDetectOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        FaceDetectOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_FaceDetect(conf,id);
    }
    public void GetAvailableAudioSourcesCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetAvailableAudioSourcesOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetAvailableAudioSourcesOptionList.ContainsKey(id)){
                var item = GetAvailableAudioSourcesOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetAvailableAudioSourcesSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetAvailableAudioSourcesOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetAvailableAudioSources(string conf, string callbackId);
    #else
    private void WX_GetAvailableAudioSources(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetAvailableAudioSourcesOption> GetAvailableAudioSourcesOptionList;
    public void GetAvailableAudioSources(GetAvailableAudioSourcesOption option)
    {
        if(GetAvailableAudioSourcesOptionList == null){
            GetAvailableAudioSourcesOptionList = new Dictionary<string, GetAvailableAudioSourcesOption>();
        }
        string id = GetCallbackId(GetAvailableAudioSourcesOptionList);
        var callback = new GetAvailableAudioSourcesOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetAvailableAudioSourcesOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetAvailableAudioSources(conf,id);
    }
    public void GetBLEDeviceCharacteristicsCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetBLEDeviceCharacteristicsOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetBLEDeviceCharacteristicsOptionList.ContainsKey(id)){
                var item = GetBLEDeviceCharacteristicsOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetBLEDeviceCharacteristicsSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetBLEDeviceCharacteristicsOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetBLEDeviceCharacteristics(string conf, string callbackId);
    #else
    private void WX_GetBLEDeviceCharacteristics(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetBLEDeviceCharacteristicsOption> GetBLEDeviceCharacteristicsOptionList;
    public void GetBLEDeviceCharacteristics(GetBLEDeviceCharacteristicsOption option)
    {
        if(GetBLEDeviceCharacteristicsOptionList == null){
            GetBLEDeviceCharacteristicsOptionList = new Dictionary<string, GetBLEDeviceCharacteristicsOption>();
        }
        string id = GetCallbackId(GetBLEDeviceCharacteristicsOptionList);
        var callback = new GetBLEDeviceCharacteristicsOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetBLEDeviceCharacteristicsOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetBLEDeviceCharacteristics(conf,id);
    }
    public void GetBLEDeviceRSSICallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetBLEDeviceRSSIOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetBLEDeviceRSSIOptionList.ContainsKey(id)){
                var item = GetBLEDeviceRSSIOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetBLEDeviceRSSISuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetBLEDeviceRSSIOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetBLEDeviceRSSI(string conf, string callbackId);
    #else
    private void WX_GetBLEDeviceRSSI(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetBLEDeviceRSSIOption> GetBLEDeviceRSSIOptionList;
    public void GetBLEDeviceRSSI(GetBLEDeviceRSSIOption option)
    {
        if(GetBLEDeviceRSSIOptionList == null){
            GetBLEDeviceRSSIOptionList = new Dictionary<string, GetBLEDeviceRSSIOption>();
        }
        string id = GetCallbackId(GetBLEDeviceRSSIOptionList);
        var callback = new GetBLEDeviceRSSIOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetBLEDeviceRSSIOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetBLEDeviceRSSI(conf,id);
    }
    public void GetBLEDeviceServicesCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetBLEDeviceServicesOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetBLEDeviceServicesOptionList.ContainsKey(id)){
                var item = GetBLEDeviceServicesOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetBLEDeviceServicesSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetBLEDeviceServicesOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetBLEDeviceServices(string conf, string callbackId);
    #else
    private void WX_GetBLEDeviceServices(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetBLEDeviceServicesOption> GetBLEDeviceServicesOptionList;
    public void GetBLEDeviceServices(GetBLEDeviceServicesOption option)
    {
        if(GetBLEDeviceServicesOptionList == null){
            GetBLEDeviceServicesOptionList = new Dictionary<string, GetBLEDeviceServicesOption>();
        }
        string id = GetCallbackId(GetBLEDeviceServicesOptionList);
        var callback = new GetBLEDeviceServicesOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetBLEDeviceServicesOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetBLEDeviceServices(conf,id);
    }
    public void GetBLEMTUCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetBLEMTUOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetBLEMTUOptionList.ContainsKey(id)){
                var item = GetBLEMTUOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetBLEMTUSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetBLEMTUOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetBLEMTU(string conf, string callbackId);
    #else
    private void WX_GetBLEMTU(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetBLEMTUOption> GetBLEMTUOptionList;
    public void GetBLEMTU(GetBLEMTUOption option)
    {
        if(GetBLEMTUOptionList == null){
            GetBLEMTUOptionList = new Dictionary<string, GetBLEMTUOption>();
        }
        string id = GetCallbackId(GetBLEMTUOptionList);
        var callback = new GetBLEMTUOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetBLEMTUOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetBLEMTU(conf,id);
    }
    public void GetBatteryInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetBatteryInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetBatteryInfoOptionList.ContainsKey(id)){
                var item = GetBatteryInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetBatteryInfoSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetBatteryInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetBatteryInfo(string conf, string callbackId);
    #else
    private void WX_GetBatteryInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetBatteryInfoOption> GetBatteryInfoOptionList;
    public void GetBatteryInfo(GetBatteryInfoOption option)
    {
        if(GetBatteryInfoOptionList == null){
            GetBatteryInfoOptionList = new Dictionary<string, GetBatteryInfoOption>();
        }
        string id = GetCallbackId(GetBatteryInfoOptionList);
        var callback = new GetBatteryInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetBatteryInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetBatteryInfo(conf,id);
    }
    public void GetBeaconsCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetBeaconsOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetBeaconsOptionList.ContainsKey(id)){
                var item = GetBeaconsOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BeaconError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetBeaconsSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BeaconError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetBeaconsOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetBeacons(string conf, string callbackId);
    #else
    private void WX_GetBeacons(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetBeaconsOption> GetBeaconsOptionList;
    public void GetBeacons(GetBeaconsOption option)
    {
        if(GetBeaconsOptionList == null){
            GetBeaconsOptionList = new Dictionary<string, GetBeaconsOption>();
        }
        string id = GetCallbackId(GetBeaconsOptionList);
        var callback = new GetBeaconsOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetBeaconsOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetBeacons(conf,id);
    }
    public void GetBluetoothAdapterStateCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetBluetoothAdapterStateOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetBluetoothAdapterStateOptionList.ContainsKey(id)){
                var item = GetBluetoothAdapterStateOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetBluetoothAdapterStateSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetBluetoothAdapterStateOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetBluetoothAdapterState(string conf, string callbackId);
    #else
    private void WX_GetBluetoothAdapterState(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetBluetoothAdapterStateOption> GetBluetoothAdapterStateOptionList;
    public void GetBluetoothAdapterState(GetBluetoothAdapterStateOption option)
    {
        if(GetBluetoothAdapterStateOptionList == null){
            GetBluetoothAdapterStateOptionList = new Dictionary<string, GetBluetoothAdapterStateOption>();
        }
        string id = GetCallbackId(GetBluetoothAdapterStateOptionList);
        var callback = new GetBluetoothAdapterStateOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetBluetoothAdapterStateOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetBluetoothAdapterState(conf,id);
    }
    public void GetBluetoothDevicesCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetBluetoothDevicesOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetBluetoothDevicesOptionList.ContainsKey(id)){
                var item = GetBluetoothDevicesOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetBluetoothDevicesSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetBluetoothDevicesOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetBluetoothDevices(string conf, string callbackId);
    #else
    private void WX_GetBluetoothDevices(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetBluetoothDevicesOption> GetBluetoothDevicesOptionList;
    public void GetBluetoothDevices(GetBluetoothDevicesOption option)
    {
        if(GetBluetoothDevicesOptionList == null){
            GetBluetoothDevicesOptionList = new Dictionary<string, GetBluetoothDevicesOption>();
        }
        string id = GetCallbackId(GetBluetoothDevicesOptionList);
        var callback = new GetBluetoothDevicesOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetBluetoothDevicesOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetBluetoothDevices(conf,id);
    }
    public void GetChannelsLiveInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetChannelsLiveInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetChannelsLiveInfoOptionList.ContainsKey(id)){
                var item = GetChannelsLiveInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetChannelsLiveInfoSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetChannelsLiveInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetChannelsLiveInfo(string conf, string callbackId);
    #else
    private void WX_GetChannelsLiveInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetChannelsLiveInfoOption> GetChannelsLiveInfoOptionList;
    public void GetChannelsLiveInfo(GetChannelsLiveInfoOption option)
    {
        if(GetChannelsLiveInfoOptionList == null){
            GetChannelsLiveInfoOptionList = new Dictionary<string, GetChannelsLiveInfoOption>();
        }
        string id = GetCallbackId(GetChannelsLiveInfoOptionList);
        var callback = new GetChannelsLiveInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetChannelsLiveInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetChannelsLiveInfo(conf,id);
    }
    public void GetChannelsLiveNoticeInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetChannelsLiveNoticeInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetChannelsLiveNoticeInfoOptionList.ContainsKey(id)){
                var item = GetChannelsLiveNoticeInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetChannelsLiveNoticeInfoSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetChannelsLiveNoticeInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetChannelsLiveNoticeInfo(string conf, string callbackId);
    #else
    private void WX_GetChannelsLiveNoticeInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetChannelsLiveNoticeInfoOption> GetChannelsLiveNoticeInfoOptionList;
    public void GetChannelsLiveNoticeInfo(GetChannelsLiveNoticeInfoOption option)
    {
        if(GetChannelsLiveNoticeInfoOptionList == null){
            GetChannelsLiveNoticeInfoOptionList = new Dictionary<string, GetChannelsLiveNoticeInfoOption>();
        }
        string id = GetCallbackId(GetChannelsLiveNoticeInfoOptionList);
        var callback = new GetChannelsLiveNoticeInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetChannelsLiveNoticeInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetChannelsLiveNoticeInfo(conf,id);
    }
    public void GetClipboardDataCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetClipboardDataOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetClipboardDataOptionList.ContainsKey(id)){
                var item = GetClipboardDataOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetClipboardDataSuccessCallbackOption>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetClipboardDataOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetClipboardData(string conf, string callbackId);
    #else
    private void WX_GetClipboardData(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetClipboardDataOption> GetClipboardDataOptionList;
    public void GetClipboardData(GetClipboardDataOption option)
    {
        if(GetClipboardDataOptionList == null){
            GetClipboardDataOptionList = new Dictionary<string, GetClipboardDataOption>();
        }
        string id = GetCallbackId(GetClipboardDataOptionList);
        var callback = new GetClipboardDataOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetClipboardDataOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetClipboardData(conf,id);
    }
    public void GetConnectedBluetoothDevicesCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetConnectedBluetoothDevicesOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetConnectedBluetoothDevicesOptionList.ContainsKey(id)){
                var item = GetConnectedBluetoothDevicesOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetConnectedBluetoothDevicesSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetConnectedBluetoothDevicesOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetConnectedBluetoothDevices(string conf, string callbackId);
    #else
    private void WX_GetConnectedBluetoothDevices(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetConnectedBluetoothDevicesOption> GetConnectedBluetoothDevicesOptionList;
    public void GetConnectedBluetoothDevices(GetConnectedBluetoothDevicesOption option)
    {
        if(GetConnectedBluetoothDevicesOptionList == null){
            GetConnectedBluetoothDevicesOptionList = new Dictionary<string, GetConnectedBluetoothDevicesOption>();
        }
        string id = GetCallbackId(GetConnectedBluetoothDevicesOptionList);
        var callback = new GetConnectedBluetoothDevicesOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetConnectedBluetoothDevicesOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetConnectedBluetoothDevices(conf,id);
    }
    public void GetExtConfigCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetExtConfigOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetExtConfigOptionList.ContainsKey(id)){
                var item = GetExtConfigOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetExtConfigSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetExtConfigOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetExtConfig(string conf, string callbackId);
    #else
    private void WX_GetExtConfig(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetExtConfigOption> GetExtConfigOptionList;
    public void GetExtConfig(GetExtConfigOption option)
    {
        if(GetExtConfigOptionList == null){
            GetExtConfigOptionList = new Dictionary<string, GetExtConfigOption>();
        }
        string id = GetCallbackId(GetExtConfigOptionList);
        var callback = new GetExtConfigOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetExtConfigOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetExtConfig(conf,id);
    }
    public void GetFileInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && WxGetFileInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(WxGetFileInfoOptionList.ContainsKey(id)){
                var item = WxGetFileInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<WxGetFileInfoSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    WxGetFileInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetFileInfo(string conf, string callbackId);
    #else
    private void WX_GetFileInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, WxGetFileInfoOption> WxGetFileInfoOptionList;
    public void GetFileInfo(WxGetFileInfoOption option)
    {
        if(WxGetFileInfoOptionList == null){
            WxGetFileInfoOptionList = new Dictionary<string, WxGetFileInfoOption>();
        }
        string id = GetCallbackId(WxGetFileInfoOptionList);
        var callback = new WxGetFileInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        WxGetFileInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetFileInfo(conf,id);
    }
    public void GetGroupEnterInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetGroupEnterInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetGroupEnterInfoOptionList.ContainsKey(id)){
                var item = GetGroupEnterInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetGroupEnterInfoSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetGroupEnterInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetGroupEnterInfo(string conf, string callbackId);
    #else
    private void WX_GetGroupEnterInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetGroupEnterInfoOption> GetGroupEnterInfoOptionList;
    public void GetGroupEnterInfo(GetGroupEnterInfoOption option)
    {
        if(GetGroupEnterInfoOptionList == null){
            GetGroupEnterInfoOptionList = new Dictionary<string, GetGroupEnterInfoOption>();
        }
        string id = GetCallbackId(GetGroupEnterInfoOptionList);
        var callback = new GetGroupEnterInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetGroupEnterInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetGroupEnterInfo(conf,id);
    }
    public void GetLocalIPAddressCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetLocalIPAddressOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetLocalIPAddressOptionList.ContainsKey(id)){
                var item = GetLocalIPAddressOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetLocalIPAddressSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetLocalIPAddressOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetLocalIPAddress(string conf, string callbackId);
    #else
    private void WX_GetLocalIPAddress(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetLocalIPAddressOption> GetLocalIPAddressOptionList;
    public void GetLocalIPAddress(GetLocalIPAddressOption option)
    {
        if(GetLocalIPAddressOptionList == null){
            GetLocalIPAddressOptionList = new Dictionary<string, GetLocalIPAddressOption>();
        }
        string id = GetCallbackId(GetLocalIPAddressOptionList);
        var callback = new GetLocalIPAddressOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetLocalIPAddressOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetLocalIPAddress(conf,id);
    }
    public void GetLocationCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetLocationOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetLocationOptionList.ContainsKey(id)){
                var item = GetLocationOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetLocationSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetLocationOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetLocation(string conf, string callbackId);
    #else
    private void WX_GetLocation(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetLocationOption> GetLocationOptionList;
    public void GetLocation(GetLocationOption option)
    {
        if(GetLocationOptionList == null){
            GetLocationOptionList = new Dictionary<string, GetLocationOption>();
        }
        string id = GetCallbackId(GetLocationOptionList);
        var callback = new GetLocationOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetLocationOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetLocation(conf,id);
    }
    public void GetNetworkTypeCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetNetworkTypeOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetNetworkTypeOptionList.ContainsKey(id)){
                var item = GetNetworkTypeOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetNetworkTypeSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetNetworkTypeOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetNetworkType(string conf, string callbackId);
    #else
    private void WX_GetNetworkType(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetNetworkTypeOption> GetNetworkTypeOptionList;
    public void GetNetworkType(GetNetworkTypeOption option)
    {
        if(GetNetworkTypeOptionList == null){
            GetNetworkTypeOptionList = new Dictionary<string, GetNetworkTypeOption>();
        }
        string id = GetCallbackId(GetNetworkTypeOptionList);
        var callback = new GetNetworkTypeOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetNetworkTypeOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetNetworkType(conf,id);
    }
    public void GetScreenBrightnessCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetScreenBrightnessOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetScreenBrightnessOptionList.ContainsKey(id)){
                var item = GetScreenBrightnessOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetScreenBrightnessSuccessCallbackOption>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetScreenBrightnessOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetScreenBrightness(string conf, string callbackId);
    #else
    private void WX_GetScreenBrightness(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetScreenBrightnessOption> GetScreenBrightnessOptionList;
    public void GetScreenBrightness(GetScreenBrightnessOption option)
    {
        if(GetScreenBrightnessOptionList == null){
            GetScreenBrightnessOptionList = new Dictionary<string, GetScreenBrightnessOption>();
        }
        string id = GetCallbackId(GetScreenBrightnessOptionList);
        var callback = new GetScreenBrightnessOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetScreenBrightnessOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetScreenBrightness(conf,id);
    }
    public void GetSettingCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetSettingOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetSettingOptionList.ContainsKey(id)){
                var item = GetSettingOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetSettingSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetSettingOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetSetting(string conf, string callbackId);
    #else
    private void WX_GetSetting(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetSettingOption> GetSettingOptionList;
    public void GetSetting(GetSettingOption option)
    {
        if(GetSettingOptionList == null){
            GetSettingOptionList = new Dictionary<string, GetSettingOption>();
        }
        string id = GetCallbackId(GetSettingOptionList);
        var callback = new GetSettingOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetSettingOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetSetting(conf,id);
    }
    public void GetShareInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetShareInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetShareInfoOptionList.ContainsKey(id)){
                var item = GetShareInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetGroupEnterInfoSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetShareInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetShareInfo(string conf, string callbackId);
    #else
    private void WX_GetShareInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetShareInfoOption> GetShareInfoOptionList;
    public void GetShareInfo(GetShareInfoOption option)
    {
        if(GetShareInfoOptionList == null){
            GetShareInfoOptionList = new Dictionary<string, GetShareInfoOption>();
        }
        string id = GetCallbackId(GetShareInfoOptionList);
        var callback = new GetShareInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetShareInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetShareInfo(conf,id);
    }
    public void GetStorageInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetStorageInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetStorageInfoOptionList.ContainsKey(id)){
                var item = GetStorageInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetStorageInfoSuccessCallbackOption>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetStorageInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetStorageInfo(string conf, string callbackId);
    #else
    private void WX_GetStorageInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetStorageInfoOption> GetStorageInfoOptionList;
    public void GetStorageInfo(GetStorageInfoOption option)
    {
        if(GetStorageInfoOptionList == null){
            GetStorageInfoOptionList = new Dictionary<string, GetStorageInfoOption>();
        }
        string id = GetCallbackId(GetStorageInfoOptionList);
        var callback = new GetStorageInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetStorageInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetStorageInfo(conf,id);
    }
    public void GetSystemInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetSystemInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetSystemInfoOptionList.ContainsKey(id)){
                var item = GetSystemInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<SystemInfo>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetSystemInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetSystemInfo(string conf, string callbackId);
    #else
    private void WX_GetSystemInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetSystemInfoOption> GetSystemInfoOptionList;
    public void GetSystemInfo(GetSystemInfoOption option)
    {
        if(GetSystemInfoOptionList == null){
            GetSystemInfoOptionList = new Dictionary<string, GetSystemInfoOption>();
        }
        string id = GetCallbackId(GetSystemInfoOptionList);
        var callback = new GetSystemInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetSystemInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetSystemInfo(conf,id);
    }
    public void GetSystemInfoAsyncCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetSystemInfoAsyncOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetSystemInfoAsyncOptionList.ContainsKey(id)){
                var item = GetSystemInfoAsyncOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<SystemInfo>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetSystemInfoAsyncOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetSystemInfoAsync(string conf, string callbackId);
    #else
    private void WX_GetSystemInfoAsync(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetSystemInfoAsyncOption> GetSystemInfoAsyncOptionList;
    public void GetSystemInfoAsync(GetSystemInfoAsyncOption option)
    {
        if(GetSystemInfoAsyncOptionList == null){
            GetSystemInfoAsyncOptionList = new Dictionary<string, GetSystemInfoAsyncOption>();
        }
        string id = GetCallbackId(GetSystemInfoAsyncOptionList);
        var callback = new GetSystemInfoAsyncOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetSystemInfoAsyncOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetSystemInfoAsync(conf,id);
    }
    public void GetUserInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetUserInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetUserInfoOptionList.ContainsKey(id)){
                var item = GetUserInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetUserInfoSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetUserInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetUserInfo(string conf, string callbackId);
    #else
    private void WX_GetUserInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetUserInfoOption> GetUserInfoOptionList;
    public void GetUserInfo(GetUserInfoOption option)
    {
        if(GetUserInfoOptionList == null){
            GetUserInfoOptionList = new Dictionary<string, GetUserInfoOption>();
        }
        string id = GetCallbackId(GetUserInfoOptionList);
        var callback = new GetUserInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetUserInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetUserInfo(conf,id);
    }
    public void GetUserInteractiveStorageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetUserInteractiveStorageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetUserInteractiveStorageOptionList.ContainsKey(id)){
                var item = GetUserInteractiveStorageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetUserInteractiveStorageSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GetUserInteractiveStorageFailCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetUserInteractiveStorageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetUserInteractiveStorage(string conf, string callbackId);
    #else
    private void WX_GetUserInteractiveStorage(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetUserInteractiveStorageOption> GetUserInteractiveStorageOptionList;
    public void GetUserInteractiveStorage(GetUserInteractiveStorageOption option)
    {
        if(GetUserInteractiveStorageOptionList == null){
            GetUserInteractiveStorageOptionList = new Dictionary<string, GetUserInteractiveStorageOption>();
        }
        string id = GetCallbackId(GetUserInteractiveStorageOptionList);
        var callback = new GetUserInteractiveStorageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetUserInteractiveStorageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetUserInteractiveStorage(conf,id);
    }
    public void GetWeRunDataCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetWeRunDataOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetWeRunDataOptionList.ContainsKey(id)){
                var item = GetWeRunDataOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetWeRunDataSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetWeRunDataOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetWeRunData(string conf, string callbackId);
    #else
    private void WX_GetWeRunData(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetWeRunDataOption> GetWeRunDataOptionList;
    public void GetWeRunData(GetWeRunDataOption option)
    {
        if(GetWeRunDataOptionList == null){
            GetWeRunDataOptionList = new Dictionary<string, GetWeRunDataOption>();
        }
        string id = GetCallbackId(GetWeRunDataOptionList);
        var callback = new GetWeRunDataOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetWeRunDataOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetWeRunData(conf,id);
    }
    public void HideKeyboardCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && HideKeyboardOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(HideKeyboardOptionList.ContainsKey(id)){
                var item = HideKeyboardOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    HideKeyboardOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_HideKeyboard(string conf, string callbackId);
    #else
    private void WX_HideKeyboard(string conf, string callbackId){}
    #endif

    private Dictionary<string, HideKeyboardOption> HideKeyboardOptionList;
    public void HideKeyboard(HideKeyboardOption option)
    {
        if(HideKeyboardOptionList == null){
            HideKeyboardOptionList = new Dictionary<string, HideKeyboardOption>();
        }
        string id = GetCallbackId(HideKeyboardOptionList);
        var callback = new HideKeyboardOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        HideKeyboardOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_HideKeyboard(conf,id);
    }
    public void HideLoadingCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && HideLoadingOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(HideLoadingOptionList.ContainsKey(id)){
                var item = HideLoadingOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    HideLoadingOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_HideLoading(string conf, string callbackId);
    #else
    private void WX_HideLoading(string conf, string callbackId){}
    #endif

    private Dictionary<string, HideLoadingOption> HideLoadingOptionList;
    public void HideLoading(HideLoadingOption option)
    {
        if(HideLoadingOptionList == null){
            HideLoadingOptionList = new Dictionary<string, HideLoadingOption>();
        }
        string id = GetCallbackId(HideLoadingOptionList);
        var callback = new HideLoadingOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        HideLoadingOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_HideLoading(conf,id);
    }
    public void HideShareMenuCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && HideShareMenuOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(HideShareMenuOptionList.ContainsKey(id)){
                var item = HideShareMenuOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    HideShareMenuOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_HideShareMenu(string conf, string callbackId);
    #else
    private void WX_HideShareMenu(string conf, string callbackId){}
    #endif

    private Dictionary<string, HideShareMenuOption> HideShareMenuOptionList;
    public void HideShareMenu(HideShareMenuOption option)
    {
        if(HideShareMenuOptionList == null){
            HideShareMenuOptionList = new Dictionary<string, HideShareMenuOption>();
        }
        string id = GetCallbackId(HideShareMenuOptionList);
        var callback = new HideShareMenuOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        HideShareMenuOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_HideShareMenu(conf,id);
    }
    public void HideToastCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && HideToastOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(HideToastOptionList.ContainsKey(id)){
                var item = HideToastOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    HideToastOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_HideToast(string conf, string callbackId);
    #else
    private void WX_HideToast(string conf, string callbackId){}
    #endif

    private Dictionary<string, HideToastOption> HideToastOptionList;
    public void HideToast(HideToastOption option)
    {
        if(HideToastOptionList == null){
            HideToastOptionList = new Dictionary<string, HideToastOption>();
        }
        string id = GetCallbackId(HideToastOptionList);
        var callback = new HideToastOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        HideToastOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_HideToast(conf,id);
    }
    public void InitFaceDetectCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && InitFaceDetectOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(InitFaceDetectOptionList.ContainsKey(id)){
                var item = InitFaceDetectOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    InitFaceDetectOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_InitFaceDetect(string conf, string callbackId);
    #else
    private void WX_InitFaceDetect(string conf, string callbackId){}
    #endif

    private Dictionary<string, InitFaceDetectOption> InitFaceDetectOptionList;
    public void InitFaceDetect(InitFaceDetectOption option)
    {
        if(InitFaceDetectOptionList == null){
            InitFaceDetectOptionList = new Dictionary<string, InitFaceDetectOption>();
        }
        string id = GetCallbackId(InitFaceDetectOptionList);
        var callback = new InitFaceDetectOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        InitFaceDetectOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_InitFaceDetect(conf,id);
    }
    public void IsBluetoothDevicePairedCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && IsBluetoothDevicePairedOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(IsBluetoothDevicePairedOptionList.ContainsKey(id)){
                var item = IsBluetoothDevicePairedOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    IsBluetoothDevicePairedOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_IsBluetoothDevicePaired(string conf, string callbackId);
    #else
    private void WX_IsBluetoothDevicePaired(string conf, string callbackId){}
    #endif

    private Dictionary<string, IsBluetoothDevicePairedOption> IsBluetoothDevicePairedOptionList;
    public void IsBluetoothDevicePaired(IsBluetoothDevicePairedOption option)
    {
        if(IsBluetoothDevicePairedOptionList == null){
            IsBluetoothDevicePairedOptionList = new Dictionary<string, IsBluetoothDevicePairedOption>();
        }
        string id = GetCallbackId(IsBluetoothDevicePairedOptionList);
        var callback = new IsBluetoothDevicePairedOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        IsBluetoothDevicePairedOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_IsBluetoothDevicePaired(conf,id);
    }
    public void JoinVoIPChatCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && JoinVoIPChatOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(JoinVoIPChatOptionList.ContainsKey(id)){
                var item = JoinVoIPChatOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<JoinVoIPChatError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<JoinVoIPChatSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<JoinVoIPChatError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    JoinVoIPChatOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_JoinVoIPChat(string conf, string callbackId);
    #else
    private void WX_JoinVoIPChat(string conf, string callbackId){}
    #endif

    private Dictionary<string, JoinVoIPChatOption> JoinVoIPChatOptionList;
    public void JoinVoIPChat(JoinVoIPChatOption option)
    {
        if(JoinVoIPChatOptionList == null){
            JoinVoIPChatOptionList = new Dictionary<string, JoinVoIPChatOption>();
        }
        string id = GetCallbackId(JoinVoIPChatOptionList);
        var callback = new JoinVoIPChatOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        JoinVoIPChatOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_JoinVoIPChat(conf,id);
    }
    public void LoginCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && LoginOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(LoginOptionList.ContainsKey(id)){
                var item = LoginOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<LoginSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    LoginOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_Login(string conf, string callbackId);
    #else
    private void WX_Login(string conf, string callbackId){}
    #endif

    private Dictionary<string, LoginOption> LoginOptionList;
    public void Login(LoginOption option)
    {
        if(LoginOptionList == null){
            LoginOptionList = new Dictionary<string, LoginOption>();
        }
        string id = GetCallbackId(LoginOptionList);
        var callback = new LoginOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        LoginOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_Login(conf,id);
    }
    public void MakeBluetoothPairCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && MakeBluetoothPairOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(MakeBluetoothPairOptionList.ContainsKey(id)){
                var item = MakeBluetoothPairOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    MakeBluetoothPairOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_MakeBluetoothPair(string conf, string callbackId);
    #else
    private void WX_MakeBluetoothPair(string conf, string callbackId){}
    #endif

    private Dictionary<string, MakeBluetoothPairOption> MakeBluetoothPairOptionList;
    public void MakeBluetoothPair(MakeBluetoothPairOption option)
    {
        if(MakeBluetoothPairOptionList == null){
            MakeBluetoothPairOptionList = new Dictionary<string, MakeBluetoothPairOption>();
        }
        string id = GetCallbackId(MakeBluetoothPairOptionList);
        var callback = new MakeBluetoothPairOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        MakeBluetoothPairOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_MakeBluetoothPair(conf,id);
    }
    public void NavigateToMiniProgramCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && NavigateToMiniProgramOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(NavigateToMiniProgramOptionList.ContainsKey(id)){
                var item = NavigateToMiniProgramOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    NavigateToMiniProgramOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_NavigateToMiniProgram(string conf, string callbackId);
    #else
    private void WX_NavigateToMiniProgram(string conf, string callbackId){}
    #endif

    private Dictionary<string, NavigateToMiniProgramOption> NavigateToMiniProgramOptionList;
    public void NavigateToMiniProgram(NavigateToMiniProgramOption option)
    {
        if(NavigateToMiniProgramOptionList == null){
            NavigateToMiniProgramOptionList = new Dictionary<string, NavigateToMiniProgramOption>();
        }
        string id = GetCallbackId(NavigateToMiniProgramOptionList);
        var callback = new NavigateToMiniProgramOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        NavigateToMiniProgramOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_NavigateToMiniProgram(conf,id);
    }
    public void NotifyBLECharacteristicValueChangeCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && NotifyBLECharacteristicValueChangeOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(NotifyBLECharacteristicValueChangeOptionList.ContainsKey(id)){
                var item = NotifyBLECharacteristicValueChangeOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    NotifyBLECharacteristicValueChangeOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_NotifyBLECharacteristicValueChange(string conf, string callbackId);
    #else
    private void WX_NotifyBLECharacteristicValueChange(string conf, string callbackId){}
    #endif

    private Dictionary<string, NotifyBLECharacteristicValueChangeOption> NotifyBLECharacteristicValueChangeOptionList;
    public void NotifyBLECharacteristicValueChange(NotifyBLECharacteristicValueChangeOption option)
    {
        if(NotifyBLECharacteristicValueChangeOptionList == null){
            NotifyBLECharacteristicValueChangeOptionList = new Dictionary<string, NotifyBLECharacteristicValueChangeOption>();
        }
        string id = GetCallbackId(NotifyBLECharacteristicValueChangeOptionList);
        var callback = new NotifyBLECharacteristicValueChangeOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        NotifyBLECharacteristicValueChangeOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_NotifyBLECharacteristicValueChange(conf,id);
    }
    public void OpenBluetoothAdapterCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenBluetoothAdapterOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenBluetoothAdapterOptionList.ContainsKey(id)){
                var item = OpenBluetoothAdapterOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenBluetoothAdapterOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenBluetoothAdapter(string conf, string callbackId);
    #else
    private void WX_OpenBluetoothAdapter(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenBluetoothAdapterOption> OpenBluetoothAdapterOptionList;
    public void OpenBluetoothAdapter(OpenBluetoothAdapterOption option)
    {
        if(OpenBluetoothAdapterOptionList == null){
            OpenBluetoothAdapterOptionList = new Dictionary<string, OpenBluetoothAdapterOption>();
        }
        string id = GetCallbackId(OpenBluetoothAdapterOptionList);
        var callback = new OpenBluetoothAdapterOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenBluetoothAdapterOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenBluetoothAdapter(conf,id);
    }
    public void OpenCardCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenCardOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenCardOptionList.ContainsKey(id)){
                var item = OpenCardOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenCardOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenCard(string conf, string callbackId);
    #else
    private void WX_OpenCard(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenCardOption> OpenCardOptionList;
    public void OpenCard(OpenCardOption option)
    {
        if(OpenCardOptionList == null){
            OpenCardOptionList = new Dictionary<string, OpenCardOption>();
        }
        string id = GetCallbackId(OpenCardOptionList);
        var callback = new OpenCardOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenCardOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenCard(conf,id);
    }
    public void OpenChannelsActivityCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenChannelsActivityOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenChannelsActivityOptionList.ContainsKey(id)){
                var item = OpenChannelsActivityOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenChannelsActivityOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenChannelsActivity(string conf, string callbackId);
    #else
    private void WX_OpenChannelsActivity(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenChannelsActivityOption> OpenChannelsActivityOptionList;
    public void OpenChannelsActivity(OpenChannelsActivityOption option)
    {
        if(OpenChannelsActivityOptionList == null){
            OpenChannelsActivityOptionList = new Dictionary<string, OpenChannelsActivityOption>();
        }
        string id = GetCallbackId(OpenChannelsActivityOptionList);
        var callback = new OpenChannelsActivityOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenChannelsActivityOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenChannelsActivity(conf,id);
    }
    public void OpenChannelsEventCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenChannelsEventOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenChannelsEventOptionList.ContainsKey(id)){
                var item = OpenChannelsEventOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenChannelsEventOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenChannelsEvent(string conf, string callbackId);
    #else
    private void WX_OpenChannelsEvent(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenChannelsEventOption> OpenChannelsEventOptionList;
    public void OpenChannelsEvent(OpenChannelsEventOption option)
    {
        if(OpenChannelsEventOptionList == null){
            OpenChannelsEventOptionList = new Dictionary<string, OpenChannelsEventOption>();
        }
        string id = GetCallbackId(OpenChannelsEventOptionList);
        var callback = new OpenChannelsEventOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenChannelsEventOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenChannelsEvent(conf,id);
    }
    public void OpenChannelsLiveCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenChannelsLiveOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenChannelsLiveOptionList.ContainsKey(id)){
                var item = OpenChannelsLiveOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenChannelsLiveOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenChannelsLive(string conf, string callbackId);
    #else
    private void WX_OpenChannelsLive(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenChannelsLiveOption> OpenChannelsLiveOptionList;
    public void OpenChannelsLive(OpenChannelsLiveOption option)
    {
        if(OpenChannelsLiveOptionList == null){
            OpenChannelsLiveOptionList = new Dictionary<string, OpenChannelsLiveOption>();
        }
        string id = GetCallbackId(OpenChannelsLiveOptionList);
        var callback = new OpenChannelsLiveOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenChannelsLiveOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenChannelsLive(conf,id);
    }
    public void OpenChannelsUserProfileCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenChannelsUserProfileOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenChannelsUserProfileOptionList.ContainsKey(id)){
                var item = OpenChannelsUserProfileOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenChannelsUserProfileOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenChannelsUserProfile(string conf, string callbackId);
    #else
    private void WX_OpenChannelsUserProfile(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenChannelsUserProfileOption> OpenChannelsUserProfileOptionList;
    public void OpenChannelsUserProfile(OpenChannelsUserProfileOption option)
    {
        if(OpenChannelsUserProfileOptionList == null){
            OpenChannelsUserProfileOptionList = new Dictionary<string, OpenChannelsUserProfileOption>();
        }
        string id = GetCallbackId(OpenChannelsUserProfileOptionList);
        var callback = new OpenChannelsUserProfileOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenChannelsUserProfileOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenChannelsUserProfile(conf,id);
    }
    public void OpenCustomerServiceConversationCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenCustomerServiceConversationOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenCustomerServiceConversationOptionList.ContainsKey(id)){
                var item = OpenCustomerServiceConversationOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenCustomerServiceConversationOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenCustomerServiceConversation(string conf, string callbackId);
    #else
    private void WX_OpenCustomerServiceConversation(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenCustomerServiceConversationOption> OpenCustomerServiceConversationOptionList;
    public void OpenCustomerServiceConversation(OpenCustomerServiceConversationOption option)
    {
        if(OpenCustomerServiceConversationOptionList == null){
            OpenCustomerServiceConversationOptionList = new Dictionary<string, OpenCustomerServiceConversationOption>();
        }
        string id = GetCallbackId(OpenCustomerServiceConversationOptionList);
        var callback = new OpenCustomerServiceConversationOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenCustomerServiceConversationOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenCustomerServiceConversation(conf,id);
    }
    public void OpenSettingCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenSettingOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenSettingOptionList.ContainsKey(id)){
                var item = OpenSettingOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<OpenSettingSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenSettingOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenSetting(string conf, string callbackId);
    #else
    private void WX_OpenSetting(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenSettingOption> OpenSettingOptionList;
    public void OpenSetting(OpenSettingOption option)
    {
        if(OpenSettingOptionList == null){
            OpenSettingOptionList = new Dictionary<string, OpenSettingOption>();
        }
        string id = GetCallbackId(OpenSettingOptionList);
        var callback = new OpenSettingOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenSettingOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenSetting(conf,id);
    }
    public void PreviewImageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && PreviewImageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(PreviewImageOptionList.ContainsKey(id)){
                var item = PreviewImageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    PreviewImageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_PreviewImage(string conf, string callbackId);
    #else
    private void WX_PreviewImage(string conf, string callbackId){}
    #endif

    private Dictionary<string, PreviewImageOption> PreviewImageOptionList;
    public void PreviewImage(PreviewImageOption option)
    {
        if(PreviewImageOptionList == null){
            PreviewImageOptionList = new Dictionary<string, PreviewImageOption>();
        }
        string id = GetCallbackId(PreviewImageOptionList);
        var callback = new PreviewImageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        PreviewImageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_PreviewImage(conf,id);
    }
    public void PreviewMediaCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && PreviewMediaOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(PreviewMediaOptionList.ContainsKey(id)){
                var item = PreviewMediaOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    PreviewMediaOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_PreviewMedia(string conf, string callbackId);
    #else
    private void WX_PreviewMedia(string conf, string callbackId){}
    #endif

    private Dictionary<string, PreviewMediaOption> PreviewMediaOptionList;
    public void PreviewMedia(PreviewMediaOption option)
    {
        if(PreviewMediaOptionList == null){
            PreviewMediaOptionList = new Dictionary<string, PreviewMediaOption>();
        }
        string id = GetCallbackId(PreviewMediaOptionList);
        var callback = new PreviewMediaOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        PreviewMediaOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_PreviewMedia(conf,id);
    }
    public void ReadBLECharacteristicValueCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ReadBLECharacteristicValueOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ReadBLECharacteristicValueOptionList.ContainsKey(id)){
                var item = ReadBLECharacteristicValueOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ReadBLECharacteristicValueOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ReadBLECharacteristicValue(string conf, string callbackId);
    #else
    private void WX_ReadBLECharacteristicValue(string conf, string callbackId){}
    #endif

    private Dictionary<string, ReadBLECharacteristicValueOption> ReadBLECharacteristicValueOptionList;
    public void ReadBLECharacteristicValue(ReadBLECharacteristicValueOption option)
    {
        if(ReadBLECharacteristicValueOptionList == null){
            ReadBLECharacteristicValueOptionList = new Dictionary<string, ReadBLECharacteristicValueOption>();
        }
        string id = GetCallbackId(ReadBLECharacteristicValueOptionList);
        var callback = new ReadBLECharacteristicValueOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ReadBLECharacteristicValueOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ReadBLECharacteristicValue(conf,id);
    }
    public void RemoveStorageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && RemoveStorageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(RemoveStorageOptionList.ContainsKey(id)){
                var item = RemoveStorageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    RemoveStorageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_RemoveStorage(string conf, string callbackId);
    #else
    private void WX_RemoveStorage(string conf, string callbackId){}
    #endif

    private Dictionary<string, RemoveStorageOption> RemoveStorageOptionList;
    public void RemoveStorage(RemoveStorageOption option)
    {
        if(RemoveStorageOptionList == null){
            RemoveStorageOptionList = new Dictionary<string, RemoveStorageOption>();
        }
        string id = GetCallbackId(RemoveStorageOptionList);
        var callback = new RemoveStorageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        RemoveStorageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_RemoveStorage(conf,id);
    }
    public void RemoveUserCloudStorageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && RemoveUserCloudStorageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(RemoveUserCloudStorageOptionList.ContainsKey(id)){
                var item = RemoveUserCloudStorageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    RemoveUserCloudStorageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_RemoveUserCloudStorage(string conf, string callbackId);
    #else
    private void WX_RemoveUserCloudStorage(string conf, string callbackId){}
    #endif

    private Dictionary<string, RemoveUserCloudStorageOption> RemoveUserCloudStorageOptionList;
    public void RemoveUserCloudStorage(RemoveUserCloudStorageOption option)
    {
        if(RemoveUserCloudStorageOptionList == null){
            RemoveUserCloudStorageOptionList = new Dictionary<string, RemoveUserCloudStorageOption>();
        }
        string id = GetCallbackId(RemoveUserCloudStorageOptionList);
        var callback = new RemoveUserCloudStorageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        RemoveUserCloudStorageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_RemoveUserCloudStorage(conf,id);
    }
    public void RequestMidasFriendPaymentCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && RequestMidasFriendPaymentOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(RequestMidasFriendPaymentOptionList.ContainsKey(id)){
                var item = RequestMidasFriendPaymentOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<MidasFriendPaymentError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<RequestMidasFriendPaymentSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<MidasFriendPaymentError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    RequestMidasFriendPaymentOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_RequestMidasFriendPayment(string conf, string callbackId);
    #else
    private void WX_RequestMidasFriendPayment(string conf, string callbackId){}
    #endif

    private Dictionary<string, RequestMidasFriendPaymentOption> RequestMidasFriendPaymentOptionList;
    public void RequestMidasFriendPayment(RequestMidasFriendPaymentOption option)
    {
        if(RequestMidasFriendPaymentOptionList == null){
            RequestMidasFriendPaymentOptionList = new Dictionary<string, RequestMidasFriendPaymentOption>();
        }
        string id = GetCallbackId(RequestMidasFriendPaymentOptionList);
        var callback = new RequestMidasFriendPaymentOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        RequestMidasFriendPaymentOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_RequestMidasFriendPayment(conf,id);
    }
    public void RequestMidasPaymentCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && RequestMidasPaymentOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(RequestMidasPaymentOptionList.ContainsKey(id)){
                var item = RequestMidasPaymentOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<MidasPaymentError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<MidasPaymentError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    RequestMidasPaymentOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_RequestMidasPayment(string conf, string callbackId);
    #else
    private void WX_RequestMidasPayment(string conf, string callbackId){}
    #endif

    private Dictionary<string, RequestMidasPaymentOption> RequestMidasPaymentOptionList;
    public void RequestMidasPayment(RequestMidasPaymentOption option)
    {
        if(RequestMidasPaymentOptionList == null){
            RequestMidasPaymentOptionList = new Dictionary<string, RequestMidasPaymentOption>();
        }
        string id = GetCallbackId(RequestMidasPaymentOptionList);
        var callback = new RequestMidasPaymentOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        RequestMidasPaymentOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_RequestMidasPayment(conf,id);
    }
    public void RequestSubscribeMessageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && RequestSubscribeMessageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(RequestSubscribeMessageOptionList.ContainsKey(id)){
                var item = RequestSubscribeMessageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<RequestSubscribeMessageSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<RequestSubscribeMessageFailCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    RequestSubscribeMessageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_RequestSubscribeMessage(string conf, string callbackId);
    #else
    private void WX_RequestSubscribeMessage(string conf, string callbackId){}
    #endif

    private Dictionary<string, RequestSubscribeMessageOption> RequestSubscribeMessageOptionList;
    public void RequestSubscribeMessage(RequestSubscribeMessageOption option)
    {
        if(RequestSubscribeMessageOptionList == null){
            RequestSubscribeMessageOptionList = new Dictionary<string, RequestSubscribeMessageOption>();
        }
        string id = GetCallbackId(RequestSubscribeMessageOptionList);
        var callback = new RequestSubscribeMessageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        RequestSubscribeMessageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_RequestSubscribeMessage(conf,id);
    }
    public void RequestSubscribeSystemMessageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && RequestSubscribeSystemMessageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(RequestSubscribeSystemMessageOptionList.ContainsKey(id)){
                var item = RequestSubscribeSystemMessageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<RequestSubscribeSystemMessageSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<RequestSubscribeMessageFailCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    RequestSubscribeSystemMessageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_RequestSubscribeSystemMessage(string conf, string callbackId);
    #else
    private void WX_RequestSubscribeSystemMessage(string conf, string callbackId){}
    #endif

    private Dictionary<string, RequestSubscribeSystemMessageOption> RequestSubscribeSystemMessageOptionList;
    public void RequestSubscribeSystemMessage(RequestSubscribeSystemMessageOption option)
    {
        if(RequestSubscribeSystemMessageOptionList == null){
            RequestSubscribeSystemMessageOptionList = new Dictionary<string, RequestSubscribeSystemMessageOption>();
        }
        string id = GetCallbackId(RequestSubscribeSystemMessageOptionList);
        var callback = new RequestSubscribeSystemMessageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        RequestSubscribeSystemMessageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_RequestSubscribeSystemMessage(conf,id);
    }
    public void SaveFileToDiskCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SaveFileToDiskOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SaveFileToDiskOptionList.ContainsKey(id)){
                var item = SaveFileToDiskOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SaveFileToDiskOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SaveFileToDisk(string conf, string callbackId);
    #else
    private void WX_SaveFileToDisk(string conf, string callbackId){}
    #endif

    private Dictionary<string, SaveFileToDiskOption> SaveFileToDiskOptionList;
    public void SaveFileToDisk(SaveFileToDiskOption option)
    {
        if(SaveFileToDiskOptionList == null){
            SaveFileToDiskOptionList = new Dictionary<string, SaveFileToDiskOption>();
        }
        string id = GetCallbackId(SaveFileToDiskOptionList);
        var callback = new SaveFileToDiskOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SaveFileToDiskOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SaveFileToDisk(conf,id);
    }
    public void SaveImageToPhotosAlbumCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SaveImageToPhotosAlbumOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SaveImageToPhotosAlbumOptionList.ContainsKey(id)){
                var item = SaveImageToPhotosAlbumOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SaveImageToPhotosAlbumOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SaveImageToPhotosAlbum(string conf, string callbackId);
    #else
    private void WX_SaveImageToPhotosAlbum(string conf, string callbackId){}
    #endif

    private Dictionary<string, SaveImageToPhotosAlbumOption> SaveImageToPhotosAlbumOptionList;
    public void SaveImageToPhotosAlbum(SaveImageToPhotosAlbumOption option)
    {
        if(SaveImageToPhotosAlbumOptionList == null){
            SaveImageToPhotosAlbumOptionList = new Dictionary<string, SaveImageToPhotosAlbumOption>();
        }
        string id = GetCallbackId(SaveImageToPhotosAlbumOptionList);
        var callback = new SaveImageToPhotosAlbumOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SaveImageToPhotosAlbumOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SaveImageToPhotosAlbum(conf,id);
    }
    public void ScanCodeCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ScanCodeOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ScanCodeOptionList.ContainsKey(id)){
                var item = ScanCodeOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<ScanCodeSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ScanCodeOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ScanCode(string conf, string callbackId);
    #else
    private void WX_ScanCode(string conf, string callbackId){}
    #endif

    private Dictionary<string, ScanCodeOption> ScanCodeOptionList;
    public void ScanCode(ScanCodeOption option)
    {
        if(ScanCodeOptionList == null){
            ScanCodeOptionList = new Dictionary<string, ScanCodeOption>();
        }
        string id = GetCallbackId(ScanCodeOptionList);
        var callback = new ScanCodeOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ScanCodeOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ScanCode(conf,id);
    }
    public void SendSocketMessageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SendSocketMessageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SendSocketMessageOptionList.ContainsKey(id)){
                var item = SendSocketMessageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SendSocketMessageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SendSocketMessage(string conf, string callbackId);
    #else
    private void WX_SendSocketMessage(string conf, string callbackId){}
    #endif

    private Dictionary<string, SendSocketMessageOption> SendSocketMessageOptionList;
    public void SendSocketMessage(SendSocketMessageOption option)
    {
        if(SendSocketMessageOptionList == null){
            SendSocketMessageOptionList = new Dictionary<string, SendSocketMessageOption>();
        }
        string id = GetCallbackId(SendSocketMessageOptionList);
        var callback = new SendSocketMessageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SendSocketMessageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SendSocketMessage(conf,id);
    }
    public void SetBLEMTUCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetBLEMTUOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetBLEMTUOptionList.ContainsKey(id)){
                var item = SetBLEMTUOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<SetBLEMTUSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<SetBLEMTUFailCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetBLEMTUOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetBLEMTU(string conf, string callbackId);
    #else
    private void WX_SetBLEMTU(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetBLEMTUOption> SetBLEMTUOptionList;
    public void SetBLEMTU(SetBLEMTUOption option)
    {
        if(SetBLEMTUOptionList == null){
            SetBLEMTUOptionList = new Dictionary<string, SetBLEMTUOption>();
        }
        string id = GetCallbackId(SetBLEMTUOptionList);
        var callback = new SetBLEMTUOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetBLEMTUOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetBLEMTU(conf,id);
    }
    public void SetClipboardDataCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetClipboardDataOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetClipboardDataOptionList.ContainsKey(id)){
                var item = SetClipboardDataOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetClipboardDataOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetClipboardData(string conf, string callbackId);
    #else
    private void WX_SetClipboardData(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetClipboardDataOption> SetClipboardDataOptionList;
    public void SetClipboardData(SetClipboardDataOption option)
    {
        if(SetClipboardDataOptionList == null){
            SetClipboardDataOptionList = new Dictionary<string, SetClipboardDataOption>();
        }
        string id = GetCallbackId(SetClipboardDataOptionList);
        var callback = new SetClipboardDataOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetClipboardDataOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetClipboardData(conf,id);
    }
    public void SetEnableDebugCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetEnableDebugOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetEnableDebugOptionList.ContainsKey(id)){
                var item = SetEnableDebugOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetEnableDebugOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetEnableDebug(string conf, string callbackId);
    #else
    private void WX_SetEnableDebug(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetEnableDebugOption> SetEnableDebugOptionList;
    public void SetEnableDebug(SetEnableDebugOption option)
    {
        if(SetEnableDebugOptionList == null){
            SetEnableDebugOptionList = new Dictionary<string, SetEnableDebugOption>();
        }
        string id = GetCallbackId(SetEnableDebugOptionList);
        var callback = new SetEnableDebugOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetEnableDebugOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetEnableDebug(conf,id);
    }
    public void SetInnerAudioOptionCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetInnerAudioOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetInnerAudioOptionList.ContainsKey(id)){
                var item = SetInnerAudioOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetInnerAudioOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetInnerAudioOption(string conf, string callbackId);
    #else
    private void WX_SetInnerAudioOption(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetInnerAudioOption> SetInnerAudioOptionList;
    public void SetInnerAudioOption(SetInnerAudioOption option)
    {
        if(SetInnerAudioOptionList == null){
            SetInnerAudioOptionList = new Dictionary<string, SetInnerAudioOption>();
        }
        string id = GetCallbackId(SetInnerAudioOptionList);
        var callback = new SetInnerAudioOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetInnerAudioOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetInnerAudioOption(conf,id);
    }
    public void SetKeepScreenOnCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetKeepScreenOnOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetKeepScreenOnOptionList.ContainsKey(id)){
                var item = SetKeepScreenOnOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetKeepScreenOnOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetKeepScreenOn(string conf, string callbackId);
    #else
    private void WX_SetKeepScreenOn(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetKeepScreenOnOption> SetKeepScreenOnOptionList;
    public void SetKeepScreenOn(SetKeepScreenOnOption option)
    {
        if(SetKeepScreenOnOptionList == null){
            SetKeepScreenOnOptionList = new Dictionary<string, SetKeepScreenOnOption>();
        }
        string id = GetCallbackId(SetKeepScreenOnOptionList);
        var callback = new SetKeepScreenOnOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetKeepScreenOnOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetKeepScreenOn(conf,id);
    }
    public void SetMenuStyleCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetMenuStyleOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetMenuStyleOptionList.ContainsKey(id)){
                var item = SetMenuStyleOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetMenuStyleOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetMenuStyle(string conf, string callbackId);
    #else
    private void WX_SetMenuStyle(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetMenuStyleOption> SetMenuStyleOptionList;
    public void SetMenuStyle(SetMenuStyleOption option)
    {
        if(SetMenuStyleOptionList == null){
            SetMenuStyleOptionList = new Dictionary<string, SetMenuStyleOption>();
        }
        string id = GetCallbackId(SetMenuStyleOptionList);
        var callback = new SetMenuStyleOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetMenuStyleOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetMenuStyle(conf,id);
    }
    public void SetScreenBrightnessCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetScreenBrightnessOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetScreenBrightnessOptionList.ContainsKey(id)){
                var item = SetScreenBrightnessOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetScreenBrightnessOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetScreenBrightness(string conf, string callbackId);
    #else
    private void WX_SetScreenBrightness(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetScreenBrightnessOption> SetScreenBrightnessOptionList;
    public void SetScreenBrightness(SetScreenBrightnessOption option)
    {
        if(SetScreenBrightnessOptionList == null){
            SetScreenBrightnessOptionList = new Dictionary<string, SetScreenBrightnessOption>();
        }
        string id = GetCallbackId(SetScreenBrightnessOptionList);
        var callback = new SetScreenBrightnessOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetScreenBrightnessOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetScreenBrightness(conf,id);
    }
    public void SetStatusBarStyleCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetStatusBarStyleOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetStatusBarStyleOptionList.ContainsKey(id)){
                var item = SetStatusBarStyleOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetStatusBarStyleOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetStatusBarStyle(string conf, string callbackId);
    #else
    private void WX_SetStatusBarStyle(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetStatusBarStyleOption> SetStatusBarStyleOptionList;
    public void SetStatusBarStyle(SetStatusBarStyleOption option)
    {
        if(SetStatusBarStyleOptionList == null){
            SetStatusBarStyleOptionList = new Dictionary<string, SetStatusBarStyleOption>();
        }
        string id = GetCallbackId(SetStatusBarStyleOptionList);
        var callback = new SetStatusBarStyleOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetStatusBarStyleOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetStatusBarStyle(conf,id);
    }
    public void SetUserCloudStorageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && SetUserCloudStorageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(SetUserCloudStorageOptionList.ContainsKey(id)){
                var item = SetUserCloudStorageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    SetUserCloudStorageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_SetUserCloudStorage(string conf, string callbackId);
    #else
    private void WX_SetUserCloudStorage(string conf, string callbackId){}
    #endif

    private Dictionary<string, SetUserCloudStorageOption> SetUserCloudStorageOptionList;
    public void SetUserCloudStorage(SetUserCloudStorageOption option)
    {
        if(SetUserCloudStorageOptionList == null){
            SetUserCloudStorageOptionList = new Dictionary<string, SetUserCloudStorageOption>();
        }
        string id = GetCallbackId(SetUserCloudStorageOptionList);
        var callback = new SetUserCloudStorageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        SetUserCloudStorageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_SetUserCloudStorage(conf,id);
    }
    public void ShowActionSheetCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ShowActionSheetOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ShowActionSheetOptionList.ContainsKey(id)){
                var item = ShowActionSheetOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<ShowActionSheetSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ShowActionSheetOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ShowActionSheet(string conf, string callbackId);
    #else
    private void WX_ShowActionSheet(string conf, string callbackId){}
    #endif

    private Dictionary<string, ShowActionSheetOption> ShowActionSheetOptionList;
    public void ShowActionSheet(ShowActionSheetOption option)
    {
        if(ShowActionSheetOptionList == null){
            ShowActionSheetOptionList = new Dictionary<string, ShowActionSheetOption>();
        }
        string id = GetCallbackId(ShowActionSheetOptionList);
        var callback = new ShowActionSheetOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ShowActionSheetOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ShowActionSheet(conf,id);
    }
    public void ShowKeyboardCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ShowKeyboardOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ShowKeyboardOptionList.ContainsKey(id)){
                var item = ShowKeyboardOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ShowKeyboardOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ShowKeyboard(string conf, string callbackId);
    #else
    private void WX_ShowKeyboard(string conf, string callbackId){}
    #endif

    private Dictionary<string, ShowKeyboardOption> ShowKeyboardOptionList;
    public void ShowKeyboard(ShowKeyboardOption option)
    {
        if(ShowKeyboardOptionList == null){
            ShowKeyboardOptionList = new Dictionary<string, ShowKeyboardOption>();
        }
        string id = GetCallbackId(ShowKeyboardOptionList);
        var callback = new ShowKeyboardOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ShowKeyboardOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ShowKeyboard(conf,id);
    }
    public void ShowLoadingCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ShowLoadingOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ShowLoadingOptionList.ContainsKey(id)){
                var item = ShowLoadingOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ShowLoadingOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ShowLoading(string conf, string callbackId);
    #else
    private void WX_ShowLoading(string conf, string callbackId){}
    #endif

    private Dictionary<string, ShowLoadingOption> ShowLoadingOptionList;
    public void ShowLoading(ShowLoadingOption option)
    {
        if(ShowLoadingOptionList == null){
            ShowLoadingOptionList = new Dictionary<string, ShowLoadingOption>();
        }
        string id = GetCallbackId(ShowLoadingOptionList);
        var callback = new ShowLoadingOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ShowLoadingOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ShowLoading(conf,id);
    }
    public void ShowModalCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ShowModalOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ShowModalOptionList.ContainsKey(id)){
                var item = ShowModalOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<ShowModalSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ShowModalOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ShowModal(string conf, string callbackId);
    #else
    private void WX_ShowModal(string conf, string callbackId){}
    #endif

    private Dictionary<string, ShowModalOption> ShowModalOptionList;
    public void ShowModal(ShowModalOption option)
    {
        if(ShowModalOptionList == null){
            ShowModalOptionList = new Dictionary<string, ShowModalOption>();
        }
        string id = GetCallbackId(ShowModalOptionList);
        var callback = new ShowModalOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ShowModalOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ShowModal(conf,id);
    }
    public void ShowShareImageMenuCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ShowShareImageMenuOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ShowShareImageMenuOptionList.ContainsKey(id)){
                var item = ShowShareImageMenuOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ShowShareImageMenuOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ShowShareImageMenu(string conf, string callbackId);
    #else
    private void WX_ShowShareImageMenu(string conf, string callbackId){}
    #endif

    private Dictionary<string, ShowShareImageMenuOption> ShowShareImageMenuOptionList;
    public void ShowShareImageMenu(ShowShareImageMenuOption option)
    {
        if(ShowShareImageMenuOptionList == null){
            ShowShareImageMenuOptionList = new Dictionary<string, ShowShareImageMenuOption>();
        }
        string id = GetCallbackId(ShowShareImageMenuOptionList);
        var callback = new ShowShareImageMenuOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ShowShareImageMenuOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ShowShareImageMenu(conf,id);
    }
    public void ShowShareMenuCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ShowShareMenuOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ShowShareMenuOptionList.ContainsKey(id)){
                var item = ShowShareMenuOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ShowShareMenuOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ShowShareMenu(string conf, string callbackId);
    #else
    private void WX_ShowShareMenu(string conf, string callbackId){}
    #endif

    private Dictionary<string, ShowShareMenuOption> ShowShareMenuOptionList;
    public void ShowShareMenu(ShowShareMenuOption option)
    {
        if(ShowShareMenuOptionList == null){
            ShowShareMenuOptionList = new Dictionary<string, ShowShareMenuOption>();
        }
        string id = GetCallbackId(ShowShareMenuOptionList);
        var callback = new ShowShareMenuOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ShowShareMenuOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ShowShareMenu(conf,id);
    }
    public void ShowToastCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && ShowToastOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(ShowToastOptionList.ContainsKey(id)){
                var item = ShowToastOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    ShowToastOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_ShowToast(string conf, string callbackId);
    #else
    private void WX_ShowToast(string conf, string callbackId){}
    #endif

    private Dictionary<string, ShowToastOption> ShowToastOptionList;
    public void ShowToast(ShowToastOption option)
    {
        if(ShowToastOptionList == null){
            ShowToastOptionList = new Dictionary<string, ShowToastOption>();
        }
        string id = GetCallbackId(ShowToastOptionList);
        var callback = new ShowToastOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        ShowToastOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_ShowToast(conf,id);
    }
    public void StartAccelerometerCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StartAccelerometerOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StartAccelerometerOptionList.ContainsKey(id)){
                var item = StartAccelerometerOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StartAccelerometerOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StartAccelerometer(string conf, string callbackId);
    #else
    private void WX_StartAccelerometer(string conf, string callbackId){}
    #endif

    private Dictionary<string, StartAccelerometerOption> StartAccelerometerOptionList;
    public void StartAccelerometer(StartAccelerometerOption option)
    {
        if(StartAccelerometerOptionList == null){
            StartAccelerometerOptionList = new Dictionary<string, StartAccelerometerOption>();
        }
        string id = GetCallbackId(StartAccelerometerOptionList);
        var callback = new StartAccelerometerOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StartAccelerometerOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StartAccelerometer(conf,id);
    }
    public void StartBeaconDiscoveryCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StartBeaconDiscoveryOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StartBeaconDiscoveryOptionList.ContainsKey(id)){
                var item = StartBeaconDiscoveryOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BeaconError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BeaconError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BeaconError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StartBeaconDiscoveryOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StartBeaconDiscovery(string conf, string callbackId);
    #else
    private void WX_StartBeaconDiscovery(string conf, string callbackId){}
    #endif

    private Dictionary<string, StartBeaconDiscoveryOption> StartBeaconDiscoveryOptionList;
    public void StartBeaconDiscovery(StartBeaconDiscoveryOption option)
    {
        if(StartBeaconDiscoveryOptionList == null){
            StartBeaconDiscoveryOptionList = new Dictionary<string, StartBeaconDiscoveryOption>();
        }
        string id = GetCallbackId(StartBeaconDiscoveryOptionList);
        var callback = new StartBeaconDiscoveryOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StartBeaconDiscoveryOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StartBeaconDiscovery(conf,id);
    }
    public void StartBluetoothDevicesDiscoveryCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StartBluetoothDevicesDiscoveryOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StartBluetoothDevicesDiscoveryOptionList.ContainsKey(id)){
                var item = StartBluetoothDevicesDiscoveryOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StartBluetoothDevicesDiscoveryOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StartBluetoothDevicesDiscovery(string conf, string callbackId);
    #else
    private void WX_StartBluetoothDevicesDiscovery(string conf, string callbackId){}
    #endif

    private Dictionary<string, StartBluetoothDevicesDiscoveryOption> StartBluetoothDevicesDiscoveryOptionList;
    public void StartBluetoothDevicesDiscovery(StartBluetoothDevicesDiscoveryOption option)
    {
        if(StartBluetoothDevicesDiscoveryOptionList == null){
            StartBluetoothDevicesDiscoveryOptionList = new Dictionary<string, StartBluetoothDevicesDiscoveryOption>();
        }
        string id = GetCallbackId(StartBluetoothDevicesDiscoveryOptionList);
        var callback = new StartBluetoothDevicesDiscoveryOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StartBluetoothDevicesDiscoveryOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StartBluetoothDevicesDiscovery(conf,id);
    }
    public void StartCompassCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StartCompassOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StartCompassOptionList.ContainsKey(id)){
                var item = StartCompassOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StartCompassOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StartCompass(string conf, string callbackId);
    #else
    private void WX_StartCompass(string conf, string callbackId){}
    #endif

    private Dictionary<string, StartCompassOption> StartCompassOptionList;
    public void StartCompass(StartCompassOption option)
    {
        if(StartCompassOptionList == null){
            StartCompassOptionList = new Dictionary<string, StartCompassOption>();
        }
        string id = GetCallbackId(StartCompassOptionList);
        var callback = new StartCompassOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StartCompassOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StartCompass(conf,id);
    }
    public void StartDeviceMotionListeningCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StartDeviceMotionListeningOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StartDeviceMotionListeningOptionList.ContainsKey(id)){
                var item = StartDeviceMotionListeningOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StartDeviceMotionListeningOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StartDeviceMotionListening(string conf, string callbackId);
    #else
    private void WX_StartDeviceMotionListening(string conf, string callbackId){}
    #endif

    private Dictionary<string, StartDeviceMotionListeningOption> StartDeviceMotionListeningOptionList;
    public void StartDeviceMotionListening(StartDeviceMotionListeningOption option)
    {
        if(StartDeviceMotionListeningOptionList == null){
            StartDeviceMotionListeningOptionList = new Dictionary<string, StartDeviceMotionListeningOption>();
        }
        string id = GetCallbackId(StartDeviceMotionListeningOptionList);
        var callback = new StartDeviceMotionListeningOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StartDeviceMotionListeningOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StartDeviceMotionListening(conf,id);
    }
    public void StartGyroscopeCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StartGyroscopeOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StartGyroscopeOptionList.ContainsKey(id)){
                var item = StartGyroscopeOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StartGyroscopeOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StartGyroscope(string conf, string callbackId);
    #else
    private void WX_StartGyroscope(string conf, string callbackId){}
    #endif

    private Dictionary<string, StartGyroscopeOption> StartGyroscopeOptionList;
    public void StartGyroscope(StartGyroscopeOption option)
    {
        if(StartGyroscopeOptionList == null){
            StartGyroscopeOptionList = new Dictionary<string, StartGyroscopeOption>();
        }
        string id = GetCallbackId(StartGyroscopeOptionList);
        var callback = new StartGyroscopeOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StartGyroscopeOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StartGyroscope(conf,id);
    }
    public void StopAccelerometerCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StopAccelerometerOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StopAccelerometerOptionList.ContainsKey(id)){
                var item = StopAccelerometerOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StopAccelerometerOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StopAccelerometer(string conf, string callbackId);
    #else
    private void WX_StopAccelerometer(string conf, string callbackId){}
    #endif

    private Dictionary<string, StopAccelerometerOption> StopAccelerometerOptionList;
    public void StopAccelerometer(StopAccelerometerOption option)
    {
        if(StopAccelerometerOptionList == null){
            StopAccelerometerOptionList = new Dictionary<string, StopAccelerometerOption>();
        }
        string id = GetCallbackId(StopAccelerometerOptionList);
        var callback = new StopAccelerometerOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StopAccelerometerOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StopAccelerometer(conf,id);
    }
    public void StopBeaconDiscoveryCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StopBeaconDiscoveryOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StopBeaconDiscoveryOptionList.ContainsKey(id)){
                var item = StopBeaconDiscoveryOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BeaconError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BeaconError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BeaconError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StopBeaconDiscoveryOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StopBeaconDiscovery(string conf, string callbackId);
    #else
    private void WX_StopBeaconDiscovery(string conf, string callbackId){}
    #endif

    private Dictionary<string, StopBeaconDiscoveryOption> StopBeaconDiscoveryOptionList;
    public void StopBeaconDiscovery(StopBeaconDiscoveryOption option)
    {
        if(StopBeaconDiscoveryOptionList == null){
            StopBeaconDiscoveryOptionList = new Dictionary<string, StopBeaconDiscoveryOption>();
        }
        string id = GetCallbackId(StopBeaconDiscoveryOptionList);
        var callback = new StopBeaconDiscoveryOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StopBeaconDiscoveryOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StopBeaconDiscovery(conf,id);
    }
    public void StopBluetoothDevicesDiscoveryCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StopBluetoothDevicesDiscoveryOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StopBluetoothDevicesDiscoveryOptionList.ContainsKey(id)){
                var item = StopBluetoothDevicesDiscoveryOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StopBluetoothDevicesDiscoveryOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StopBluetoothDevicesDiscovery(string conf, string callbackId);
    #else
    private void WX_StopBluetoothDevicesDiscovery(string conf, string callbackId){}
    #endif

    private Dictionary<string, StopBluetoothDevicesDiscoveryOption> StopBluetoothDevicesDiscoveryOptionList;
    public void StopBluetoothDevicesDiscovery(StopBluetoothDevicesDiscoveryOption option)
    {
        if(StopBluetoothDevicesDiscoveryOptionList == null){
            StopBluetoothDevicesDiscoveryOptionList = new Dictionary<string, StopBluetoothDevicesDiscoveryOption>();
        }
        string id = GetCallbackId(StopBluetoothDevicesDiscoveryOptionList);
        var callback = new StopBluetoothDevicesDiscoveryOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StopBluetoothDevicesDiscoveryOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StopBluetoothDevicesDiscovery(conf,id);
    }
    public void StopCompassCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StopCompassOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StopCompassOptionList.ContainsKey(id)){
                var item = StopCompassOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StopCompassOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StopCompass(string conf, string callbackId);
    #else
    private void WX_StopCompass(string conf, string callbackId){}
    #endif

    private Dictionary<string, StopCompassOption> StopCompassOptionList;
    public void StopCompass(StopCompassOption option)
    {
        if(StopCompassOptionList == null){
            StopCompassOptionList = new Dictionary<string, StopCompassOption>();
        }
        string id = GetCallbackId(StopCompassOptionList);
        var callback = new StopCompassOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StopCompassOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StopCompass(conf,id);
    }
    public void StopDeviceMotionListeningCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StopDeviceMotionListeningOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StopDeviceMotionListeningOptionList.ContainsKey(id)){
                var item = StopDeviceMotionListeningOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StopDeviceMotionListeningOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StopDeviceMotionListening(string conf, string callbackId);
    #else
    private void WX_StopDeviceMotionListening(string conf, string callbackId){}
    #endif

    private Dictionary<string, StopDeviceMotionListeningOption> StopDeviceMotionListeningOptionList;
    public void StopDeviceMotionListening(StopDeviceMotionListeningOption option)
    {
        if(StopDeviceMotionListeningOptionList == null){
            StopDeviceMotionListeningOptionList = new Dictionary<string, StopDeviceMotionListeningOption>();
        }
        string id = GetCallbackId(StopDeviceMotionListeningOptionList);
        var callback = new StopDeviceMotionListeningOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StopDeviceMotionListeningOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StopDeviceMotionListening(conf,id);
    }
    public void StopFaceDetectCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StopFaceDetectOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StopFaceDetectOptionList.ContainsKey(id)){
                var item = StopFaceDetectOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StopFaceDetectOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StopFaceDetect(string conf, string callbackId);
    #else
    private void WX_StopFaceDetect(string conf, string callbackId){}
    #endif

    private Dictionary<string, StopFaceDetectOption> StopFaceDetectOptionList;
    public void StopFaceDetect(StopFaceDetectOption option)
    {
        if(StopFaceDetectOptionList == null){
            StopFaceDetectOptionList = new Dictionary<string, StopFaceDetectOption>();
        }
        string id = GetCallbackId(StopFaceDetectOptionList);
        var callback = new StopFaceDetectOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StopFaceDetectOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StopFaceDetect(conf,id);
    }
    public void StopGyroscopeCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StopGyroscopeOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StopGyroscopeOptionList.ContainsKey(id)){
                var item = StopGyroscopeOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StopGyroscopeOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StopGyroscope(string conf, string callbackId);
    #else
    private void WX_StopGyroscope(string conf, string callbackId){}
    #endif

    private Dictionary<string, StopGyroscopeOption> StopGyroscopeOptionList;
    public void StopGyroscope(StopGyroscopeOption option)
    {
        if(StopGyroscopeOptionList == null){
            StopGyroscopeOptionList = new Dictionary<string, StopGyroscopeOption>();
        }
        string id = GetCallbackId(StopGyroscopeOptionList);
        var callback = new StopGyroscopeOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StopGyroscopeOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StopGyroscope(conf,id);
    }
    public void UpdateKeyboardCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && UpdateKeyboardOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(UpdateKeyboardOptionList.ContainsKey(id)){
                var item = UpdateKeyboardOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    UpdateKeyboardOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_UpdateKeyboard(string conf, string callbackId);
    #else
    private void WX_UpdateKeyboard(string conf, string callbackId){}
    #endif

    private Dictionary<string, UpdateKeyboardOption> UpdateKeyboardOptionList;
    public void UpdateKeyboard(UpdateKeyboardOption option)
    {
        if(UpdateKeyboardOptionList == null){
            UpdateKeyboardOptionList = new Dictionary<string, UpdateKeyboardOption>();
        }
        string id = GetCallbackId(UpdateKeyboardOptionList);
        var callback = new UpdateKeyboardOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        UpdateKeyboardOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_UpdateKeyboard(conf,id);
    }
    public void UpdateShareMenuCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && UpdateShareMenuOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(UpdateShareMenuOptionList.ContainsKey(id)){
                var item = UpdateShareMenuOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    UpdateShareMenuOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_UpdateShareMenu(string conf, string callbackId);
    #else
    private void WX_UpdateShareMenu(string conf, string callbackId){}
    #endif

    private Dictionary<string, UpdateShareMenuOption> UpdateShareMenuOptionList;
    public void UpdateShareMenu(UpdateShareMenuOption option)
    {
        if(UpdateShareMenuOptionList == null){
            UpdateShareMenuOptionList = new Dictionary<string, UpdateShareMenuOption>();
        }
        string id = GetCallbackId(UpdateShareMenuOptionList);
        var callback = new UpdateShareMenuOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        UpdateShareMenuOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_UpdateShareMenu(conf,id);
    }
    public void UpdateVoIPChatMuteConfigCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && UpdateVoIPChatMuteConfigOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(UpdateVoIPChatMuteConfigOptionList.ContainsKey(id)){
                var item = UpdateVoIPChatMuteConfigOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    UpdateVoIPChatMuteConfigOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_UpdateVoIPChatMuteConfig(string conf, string callbackId);
    #else
    private void WX_UpdateVoIPChatMuteConfig(string conf, string callbackId){}
    #endif

    private Dictionary<string, UpdateVoIPChatMuteConfigOption> UpdateVoIPChatMuteConfigOptionList;
    public void UpdateVoIPChatMuteConfig(UpdateVoIPChatMuteConfigOption option)
    {
        if(UpdateVoIPChatMuteConfigOptionList == null){
            UpdateVoIPChatMuteConfigOptionList = new Dictionary<string, UpdateVoIPChatMuteConfigOption>();
        }
        string id = GetCallbackId(UpdateVoIPChatMuteConfigOptionList);
        var callback = new UpdateVoIPChatMuteConfigOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        UpdateVoIPChatMuteConfigOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_UpdateVoIPChatMuteConfig(conf,id);
    }
    public void UpdateWeChatAppCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && UpdateWeChatAppOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(UpdateWeChatAppOptionList.ContainsKey(id)){
                var item = UpdateWeChatAppOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    UpdateWeChatAppOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_UpdateWeChatApp(string conf, string callbackId);
    #else
    private void WX_UpdateWeChatApp(string conf, string callbackId){}
    #endif

    private Dictionary<string, UpdateWeChatAppOption> UpdateWeChatAppOptionList;
    public void UpdateWeChatApp(UpdateWeChatAppOption option)
    {
        if(UpdateWeChatAppOptionList == null){
            UpdateWeChatAppOptionList = new Dictionary<string, UpdateWeChatAppOption>();
        }
        string id = GetCallbackId(UpdateWeChatAppOptionList);
        var callback = new UpdateWeChatAppOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        UpdateWeChatAppOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_UpdateWeChatApp(conf,id);
    }
    public void VibrateLongCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && VibrateLongOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(VibrateLongOptionList.ContainsKey(id)){
                var item = VibrateLongOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    VibrateLongOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_VibrateLong(string conf, string callbackId);
    #else
    private void WX_VibrateLong(string conf, string callbackId){}
    #endif

    private Dictionary<string, VibrateLongOption> VibrateLongOptionList;
    public void VibrateLong(VibrateLongOption option)
    {
        if(VibrateLongOptionList == null){
            VibrateLongOptionList = new Dictionary<string, VibrateLongOption>();
        }
        string id = GetCallbackId(VibrateLongOptionList);
        var callback = new VibrateLongOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        VibrateLongOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_VibrateLong(conf,id);
    }
    public void VibrateShortCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && VibrateShortOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(VibrateShortOptionList.ContainsKey(id)){
                var item = VibrateShortOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    VibrateShortOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_VibrateShort(string conf, string callbackId);
    #else
    private void WX_VibrateShort(string conf, string callbackId){}
    #endif

    private Dictionary<string, VibrateShortOption> VibrateShortOptionList;
    public void VibrateShort(VibrateShortOption option)
    {
        if(VibrateShortOptionList == null){
            VibrateShortOptionList = new Dictionary<string, VibrateShortOption>();
        }
        string id = GetCallbackId(VibrateShortOptionList);
        var callback = new VibrateShortOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        VibrateShortOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_VibrateShort(conf,id);
    }
    public void WriteBLECharacteristicValueCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && WriteBLECharacteristicValueOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(WriteBLECharacteristicValueOptionList.ContainsKey(id)){
                var item = WriteBLECharacteristicValueOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<BluetoothError>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    WriteBLECharacteristicValueOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_WriteBLECharacteristicValue(string conf, string callbackId);
    #else
    private void WX_WriteBLECharacteristicValue(string conf, string callbackId){}
    #endif

    private Dictionary<string, WriteBLECharacteristicValueOption> WriteBLECharacteristicValueOptionList;
    public void WriteBLECharacteristicValue(WriteBLECharacteristicValueOption option)
    {
        if(WriteBLECharacteristicValueOptionList == null){
            WriteBLECharacteristicValueOptionList = new Dictionary<string, WriteBLECharacteristicValueOption>();
        }
        string id = GetCallbackId(WriteBLECharacteristicValueOptionList);
        var callback = new WriteBLECharacteristicValueOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        WriteBLECharacteristicValueOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_WriteBLECharacteristicValue(conf,id);
    }
    public void StartGameLiveCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && StartGameLiveOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(StartGameLiveOptionList.ContainsKey(id)){
                var item = StartGameLiveOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    StartGameLiveOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_StartGameLive(string conf, string callbackId);
    #else
    private void WX_StartGameLive(string conf, string callbackId){}
    #endif

    private Dictionary<string, StartGameLiveOption> StartGameLiveOptionList;
    public void StartGameLive(StartGameLiveOption option)
    {
        if(StartGameLiveOptionList == null){
            StartGameLiveOptionList = new Dictionary<string, StartGameLiveOption>();
        }
        string id = GetCallbackId(StartGameLiveOptionList);
        var callback = new StartGameLiveOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        StartGameLiveOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_StartGameLive(conf,id);
    }
    public void CheckGameLiveEnabledCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && CheckGameLiveEnabledOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(CheckGameLiveEnabledOptionList.ContainsKey(id)){
                var item = CheckGameLiveEnabledOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<CheckGameLiveEnabledSuccessCallbackOption>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    CheckGameLiveEnabledOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_CheckGameLiveEnabled(string conf, string callbackId);
    #else
    private void WX_CheckGameLiveEnabled(string conf, string callbackId){}
    #endif

    private Dictionary<string, CheckGameLiveEnabledOption> CheckGameLiveEnabledOptionList;
    public void CheckGameLiveEnabled(CheckGameLiveEnabledOption option)
    {
        if(CheckGameLiveEnabledOptionList == null){
            CheckGameLiveEnabledOptionList = new Dictionary<string, CheckGameLiveEnabledOption>();
        }
        string id = GetCallbackId(CheckGameLiveEnabledOptionList);
        var callback = new CheckGameLiveEnabledOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        CheckGameLiveEnabledOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_CheckGameLiveEnabled(conf,id);
    }
    public void GetUserCurrentGameliveInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetUserCurrentGameliveInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetUserCurrentGameliveInfoOptionList.ContainsKey(id)){
                var item = GetUserCurrentGameliveInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetUserCurrentGameliveInfoSuccessCallbackOption>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetUserCurrentGameliveInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetUserCurrentGameliveInfo(string conf, string callbackId);
    #else
    private void WX_GetUserCurrentGameliveInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetUserCurrentGameliveInfoOption> GetUserCurrentGameliveInfoOptionList;
    public void GetUserCurrentGameliveInfo(GetUserCurrentGameliveInfoOption option)
    {
        if(GetUserCurrentGameliveInfoOptionList == null){
            GetUserCurrentGameliveInfoOptionList = new Dictionary<string, GetUserCurrentGameliveInfoOption>();
        }
        string id = GetCallbackId(GetUserCurrentGameliveInfoOptionList);
        var callback = new GetUserCurrentGameliveInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetUserCurrentGameliveInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetUserCurrentGameliveInfo(conf,id);
    }
    public void GetUserRecentGameLiveInfoCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetUserRecentGameLiveInfoOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetUserRecentGameLiveInfoOptionList.ContainsKey(id)){
                var item = GetUserRecentGameLiveInfoOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetUserGameLiveDetailsSuccessCallbackOption>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetUserRecentGameLiveInfoOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetUserRecentGameLiveInfo(string conf, string callbackId);
    #else
    private void WX_GetUserRecentGameLiveInfo(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetUserRecentGameLiveInfoOption> GetUserRecentGameLiveInfoOptionList;
    public void GetUserRecentGameLiveInfo(GetUserRecentGameLiveInfoOption option)
    {
        if(GetUserRecentGameLiveInfoOptionList == null){
            GetUserRecentGameLiveInfoOptionList = new Dictionary<string, GetUserRecentGameLiveInfoOption>();
        }
        string id = GetCallbackId(GetUserRecentGameLiveInfoOptionList);
        var callback = new GetUserRecentGameLiveInfoOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetUserRecentGameLiveInfoOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetUserRecentGameLiveInfo(conf,id);
    }
    public void GetUserGameLiveDetailsCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && GetUserGameLiveDetailsOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(GetUserGameLiveDetailsOptionList.ContainsKey(id)){
                var item = GetUserGameLiveDetailsOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GetUserGameLiveDetailsSuccessCallbackOption>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    GetUserGameLiveDetailsOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetUserGameLiveDetails(string conf, string callbackId);
    #else
    private void WX_GetUserGameLiveDetails(string conf, string callbackId){}
    #endif

    private Dictionary<string, GetUserGameLiveDetailsOption> GetUserGameLiveDetailsOptionList;
    public void GetUserGameLiveDetails(GetUserGameLiveDetailsOption option)
    {
        if(GetUserGameLiveDetailsOptionList == null){
            GetUserGameLiveDetailsOptionList = new Dictionary<string, GetUserGameLiveDetailsOption>();
        }
        string id = GetCallbackId(GetUserGameLiveDetailsOptionList);
        var callback = new GetUserGameLiveDetailsOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        GetUserGameLiveDetailsOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetUserGameLiveDetails(conf,id);
    }
    public void OpenChannelsLiveCollectionCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && OpenChannelsLiveCollectionOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(OpenChannelsLiveCollectionOptionList.ContainsKey(id)){
                var item = OpenChannelsLiveCollectionOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    OpenChannelsLiveCollectionOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenChannelsLiveCollection(string conf, string callbackId);
    #else
    private void WX_OpenChannelsLiveCollection(string conf, string callbackId){}
    #endif

    private Dictionary<string, OpenChannelsLiveCollectionOption> OpenChannelsLiveCollectionOptionList;
    public void OpenChannelsLiveCollection(OpenChannelsLiveCollectionOption option)
    {
        if(OpenChannelsLiveCollectionOptionList == null){
            OpenChannelsLiveCollectionOptionList = new Dictionary<string, OpenChannelsLiveCollectionOption>();
        }
        string id = GetCallbackId(OpenChannelsLiveCollectionOptionList);
        var callback = new OpenChannelsLiveCollectionOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        OpenChannelsLiveCollectionOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenChannelsLiveCollection(conf,id);
    }
    public void OpenPageCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && openPageOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(openPageOptionList.ContainsKey(id)){
                var item = openPageOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    openPageOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_OpenPage(string conf, string callbackId);
    #else
    private void WX_OpenPage(string conf, string callbackId){}
    #endif

    private Dictionary<string, openPageOption> openPageOptionList;
    public void OpenPage(openPageOption option)
    {
        if(openPageOptionList == null){
            openPageOptionList = new Dictionary<string, openPageOption>();
        }
        string id = GetCallbackId(openPageOptionList);
        var callback = new openPageOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        openPageOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_OpenPage(conf,id);
    }
    public void GetGameClubDataCallback(string msg) {
        if (!string.IsNullOrEmpty(msg) && getGameClubDataOptionList != null)
        {
            var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
            var id = jsCallback.callbackId;
            var type = jsCallback.type;
            var res = jsCallback.res;
            if(getGameClubDataOptionList.ContainsKey(id)){
                var item = getGameClubDataOptionList[id];
                if(type == "complete"){
                    item.complete?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    item.complete = null;
                }else{
                    if(type == "success"){
                        item.success?.Invoke(JsonMapper.ToObject<getGameClubDataSuccessCallbackResult>(res));
                    }
                    else if(type == "fail"){
                        item.fail?.Invoke(JsonMapper.ToObject<GeneralCallbackResult>(res));
                    }
                    item.success = null;
                    item.fail = null;
                }
                if(item.complete == null && item.success == null && item.fail == null){
                    getGameClubDataOptionList.Remove(id);
                }
            }
        }
    }

    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void WX_GetGameClubData(string conf, string callbackId);
    #else
    private void WX_GetGameClubData(string conf, string callbackId){}
    #endif

    private Dictionary<string, getGameClubDataOption> getGameClubDataOptionList;
    public void GetGameClubData(getGameClubDataOption option)
    {
        if(getGameClubDataOptionList == null){
            getGameClubDataOptionList = new Dictionary<string, getGameClubDataOption>();
        }
        string id = GetCallbackId(getGameClubDataOptionList);
        var callback = new getGameClubDataOption(){
            success = option.success,
            fail = option.fail,
            complete = option.complete
        };
        getGameClubDataOptionList.Add( id, callback );
        var succ = option.success;
        var fail = option.fail;
        var comp = option.complete;
        option.success = null;
        option.fail = null;
        option.complete = null;
        var conf = JsonMapper.ToJson(option);
        option.success = succ;
        option.fail = fail;
        option.complete = comp;
        WX_GetGameClubData(conf,id);
    }

    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_RestartMiniProgram();

    public void RestartMiniProgram()
    {
            WX_RestartMiniProgram();
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_RemoveStorageSync(string key);
    
    public void RemoveStorageSync(string key)
    {

            WX_RemoveStorageSync(key);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_ReportEvent(string eventId,string data);
    
    public void ReportEvent<T>(string eventId,T data)
    {

            WX_ReportEvent(eventId,JsonMapper.ToJson(data));
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_ReportMonitor(string name,double value);
    
    public void ReportMonitor(string name,double value)
    {

            WX_ReportMonitor(name,value);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_ReportPerformance(double id,double value,string dimensions);
    
    public void ReportPerformance(double id,double value,string dimensions)
    {

            WX_ReportPerformance(id,value,dimensions);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_ReportUserBehaviorBranchAnalytics(string option);
    
    public void ReportUserBehaviorBranchAnalytics(ReportUserBehaviorBranchAnalyticsOption option)
    {

            WX_ReportUserBehaviorBranchAnalytics(JsonMapper.ToJson(option));
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_ReserveChannelsLive(string option);
    
    public void ReserveChannelsLive(ReserveChannelsLiveOption option)
    {

            WX_ReserveChannelsLive(JsonMapper.ToJson(option));
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_RevokeBufferURL(string url);
    
    public void RevokeBufferURL(string url)
    {

            WX_RevokeBufferURL(url);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_SetStorageSync(string key,string data,bool encrypt);
    
    public void SetStorageSync<T>(string key,T data,bool encrypt)
    {

            WX_SetStorageSync(key,JsonMapper.ToJson(data),encrypt);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_ShareAppMessage(string option);
    
    public void ShareAppMessage(ShareAppMessageOption option)
    {

            WX_ShareAppMessage(JsonMapper.ToJson(option));
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_TriggerGC();

    public void TriggerGC()
    {
            WX_TriggerGC();
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_StopDownloadTexture();

    public void StopDownloadTexture()
    {
            WX_StopDownloadTexture();
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_StarDownloadTexture();

    public void StarDownloadTexture()
    {
            WX_StarDownloadTexture();
    }

    public void _OnAccelerometerChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnAccelerometerChangeCallbackResult>(msg);
            OnAccelerometerChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnAccelerometerChange();
    private Action<OnAccelerometerChangeCallbackResult> OnAccelerometerChangeAction;
    public void OnAccelerometerChange(Action<OnAccelerometerChangeCallbackResult> result)
    {
        if(OnAccelerometerChangeAction == null){
            WX_OnAccelerometerChange();
        }
        OnAccelerometerChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffAccelerometerChange();
    public void OffAccelerometerChange(Action<OnAccelerometerChangeCallbackResult> result)
    {
        if(result == null){
            OnAccelerometerChangeAction = null;
        }else{
            OnAccelerometerChangeAction-=result;
        }
        if(OnAccelerometerChangeAction == null){
            WX_OffAccelerometerChange();
        }
    }
    public void _OnAudioInterruptionBeginCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<GeneralCallbackResult>(msg);
            OnAudioInterruptionBeginAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnAudioInterruptionBegin();
    private Action<GeneralCallbackResult> OnAudioInterruptionBeginAction;
    public void OnAudioInterruptionBegin(Action<GeneralCallbackResult> res)
    {
        if(OnAudioInterruptionBeginAction == null){
            WX_OnAudioInterruptionBegin();
        }
        OnAudioInterruptionBeginAction+=res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffAudioInterruptionBegin();
    public void OffAudioInterruptionBegin(Action<GeneralCallbackResult> res)
    {
        if(res == null){
            OnAudioInterruptionBeginAction = null;
        }else{
            OnAudioInterruptionBeginAction-=res;
        }
        if(OnAudioInterruptionBeginAction == null){
            WX_OffAudioInterruptionBegin();
        }
    }
    public void _OnAudioInterruptionEndCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<GeneralCallbackResult>(msg);
            OnAudioInterruptionEndAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnAudioInterruptionEnd();
    private Action<GeneralCallbackResult> OnAudioInterruptionEndAction;
    public void OnAudioInterruptionEnd(Action<GeneralCallbackResult> res)
    {
        if(OnAudioInterruptionEndAction == null){
            WX_OnAudioInterruptionEnd();
        }
        OnAudioInterruptionEndAction+=res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffAudioInterruptionEnd();
    public void OffAudioInterruptionEnd(Action<GeneralCallbackResult> res)
    {
        if(res == null){
            OnAudioInterruptionEndAction = null;
        }else{
            OnAudioInterruptionEndAction-=res;
        }
        if(OnAudioInterruptionEndAction == null){
            WX_OffAudioInterruptionEnd();
        }
    }
    public void _OnBLECharacteristicValueChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnBLECharacteristicValueChangeCallbackResult>(msg);
            OnBLECharacteristicValueChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnBLECharacteristicValueChange();
    private Action<OnBLECharacteristicValueChangeCallbackResult> OnBLECharacteristicValueChangeAction;
    public void OnBLECharacteristicValueChange(Action<OnBLECharacteristicValueChangeCallbackResult> result)
    {
        if(OnBLECharacteristicValueChangeAction == null){
            WX_OnBLECharacteristicValueChange();
        }
        OnBLECharacteristicValueChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffBLECharacteristicValueChange();
    public void OffBLECharacteristicValueChange(Action<OnBLECharacteristicValueChangeCallbackResult> result)
    {
        if(result == null){
            OnBLECharacteristicValueChangeAction = null;
        }else{
            OnBLECharacteristicValueChangeAction-=result;
        }
        if(OnBLECharacteristicValueChangeAction == null){
            WX_OffBLECharacteristicValueChange();
        }
    }
    public void _OnBLEConnectionStateChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnBLEConnectionStateChangeCallbackResult>(msg);
            OnBLEConnectionStateChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnBLEConnectionStateChange();
    private Action<OnBLEConnectionStateChangeCallbackResult> OnBLEConnectionStateChangeAction;
    public void OnBLEConnectionStateChange(Action<OnBLEConnectionStateChangeCallbackResult> result)
    {
        if(OnBLEConnectionStateChangeAction == null){
            WX_OnBLEConnectionStateChange();
        }
        OnBLEConnectionStateChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffBLEConnectionStateChange();
    public void OffBLEConnectionStateChange(Action<OnBLEConnectionStateChangeCallbackResult> result)
    {
        if(result == null){
            OnBLEConnectionStateChangeAction = null;
        }else{
            OnBLEConnectionStateChangeAction-=result;
        }
        if(OnBLEConnectionStateChangeAction == null){
            WX_OffBLEConnectionStateChange();
        }
    }
    public void _OnBLEMTUChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnBLEMTUChangeCallbackResult>(msg);
            OnBLEMTUChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnBLEMTUChange();
    private Action<OnBLEMTUChangeCallbackResult> OnBLEMTUChangeAction;
    public void OnBLEMTUChange(Action<OnBLEMTUChangeCallbackResult> result)
    {
        if(OnBLEMTUChangeAction == null){
            WX_OnBLEMTUChange();
        }
        OnBLEMTUChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffBLEMTUChange();
    public void OffBLEMTUChange(Action<OnBLEMTUChangeCallbackResult> result)
    {
        if(result == null){
            OnBLEMTUChangeAction = null;
        }else{
            OnBLEMTUChangeAction-=result;
        }
        if(OnBLEMTUChangeAction == null){
            WX_OffBLEMTUChange();
        }
    }
    public void _OnBLEPeripheralConnectionStateChangedCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnBLEPeripheralConnectionStateChangedCallbackResult>(msg);
            OnBLEPeripheralConnectionStateChangedAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnBLEPeripheralConnectionStateChanged();
    private Action<OnBLEPeripheralConnectionStateChangedCallbackResult> OnBLEPeripheralConnectionStateChangedAction;
    public void OnBLEPeripheralConnectionStateChanged(Action<OnBLEPeripheralConnectionStateChangedCallbackResult> result)
    {
        if(OnBLEPeripheralConnectionStateChangedAction == null){
            WX_OnBLEPeripheralConnectionStateChanged();
        }
        OnBLEPeripheralConnectionStateChangedAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffBLEPeripheralConnectionStateChanged();
    public void OffBLEPeripheralConnectionStateChanged(Action<OnBLEPeripheralConnectionStateChangedCallbackResult> result)
    {
        if(result == null){
            OnBLEPeripheralConnectionStateChangedAction = null;
        }else{
            OnBLEPeripheralConnectionStateChangedAction-=result;
        }
        if(OnBLEPeripheralConnectionStateChangedAction == null){
            WX_OffBLEPeripheralConnectionStateChanged();
        }
    }
    public void _OnBeaconServiceChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnBeaconServiceChangeCallbackResult>(msg);
            OnBeaconServiceChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnBeaconServiceChange();
    private Action<OnBeaconServiceChangeCallbackResult> OnBeaconServiceChangeAction;
    public void OnBeaconServiceChange(Action<OnBeaconServiceChangeCallbackResult> result)
    {
        if(OnBeaconServiceChangeAction == null){
            WX_OnBeaconServiceChange();
        }
        OnBeaconServiceChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffBeaconServiceChange();
    public void OffBeaconServiceChange(Action<OnBeaconServiceChangeCallbackResult> result)
    {
        if(result == null){
            OnBeaconServiceChangeAction = null;
        }else{
            OnBeaconServiceChangeAction-=result;
        }
        if(OnBeaconServiceChangeAction == null){
            WX_OffBeaconServiceChange();
        }
    }
    public void _OnBeaconUpdateCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnBeaconUpdateCallbackResult>(msg);
            OnBeaconUpdateAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnBeaconUpdate();
    private Action<OnBeaconUpdateCallbackResult> OnBeaconUpdateAction;
    public void OnBeaconUpdate(Action<OnBeaconUpdateCallbackResult> result)
    {
        if(OnBeaconUpdateAction == null){
            WX_OnBeaconUpdate();
        }
        OnBeaconUpdateAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffBeaconUpdate();
    public void OffBeaconUpdate(Action<OnBeaconUpdateCallbackResult> result)
    {
        if(result == null){
            OnBeaconUpdateAction = null;
        }else{
            OnBeaconUpdateAction-=result;
        }
        if(OnBeaconUpdateAction == null){
            WX_OffBeaconUpdate();
        }
    }
    public void _OnBluetoothAdapterStateChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnBluetoothAdapterStateChangeCallbackResult>(msg);
            OnBluetoothAdapterStateChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnBluetoothAdapterStateChange();
    private Action<OnBluetoothAdapterStateChangeCallbackResult> OnBluetoothAdapterStateChangeAction;
    public void OnBluetoothAdapterStateChange(Action<OnBluetoothAdapterStateChangeCallbackResult> result)
    {
        if(OnBluetoothAdapterStateChangeAction == null){
            WX_OnBluetoothAdapterStateChange();
        }
        OnBluetoothAdapterStateChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffBluetoothAdapterStateChange();
    public void OffBluetoothAdapterStateChange(Action<OnBluetoothAdapterStateChangeCallbackResult> result)
    {
        if(result == null){
            OnBluetoothAdapterStateChangeAction = null;
        }else{
            OnBluetoothAdapterStateChangeAction-=result;
        }
        if(OnBluetoothAdapterStateChangeAction == null){
            WX_OffBluetoothAdapterStateChange();
        }
    }
    public void _OnBluetoothDeviceFoundCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnBluetoothDeviceFoundCallbackResult>(msg);
            OnBluetoothDeviceFoundAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnBluetoothDeviceFound();
    private Action<OnBluetoothDeviceFoundCallbackResult> OnBluetoothDeviceFoundAction;
    public void OnBluetoothDeviceFound(Action<OnBluetoothDeviceFoundCallbackResult> result)
    {
        if(OnBluetoothDeviceFoundAction == null){
            WX_OnBluetoothDeviceFound();
        }
        OnBluetoothDeviceFoundAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffBluetoothDeviceFound();
    public void OffBluetoothDeviceFound(Action<OnBluetoothDeviceFoundCallbackResult> result)
    {
        if(result == null){
            OnBluetoothDeviceFoundAction = null;
        }else{
            OnBluetoothDeviceFoundAction-=result;
        }
        if(OnBluetoothDeviceFoundAction == null){
            WX_OffBluetoothDeviceFound();
        }
    }
    public void _OnCompassChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnCompassChangeCallbackResult>(msg);
            OnCompassChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnCompassChange();
    private Action<OnCompassChangeCallbackResult> OnCompassChangeAction;
    public void OnCompassChange(Action<OnCompassChangeCallbackResult> result)
    {
        if(OnCompassChangeAction == null){
            WX_OnCompassChange();
        }
        OnCompassChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffCompassChange();
    public void OffCompassChange(Action<OnCompassChangeCallbackResult> result)
    {
        if(result == null){
            OnCompassChangeAction = null;
        }else{
            OnCompassChangeAction-=result;
        }
        if(OnCompassChangeAction == null){
            WX_OffCompassChange();
        }
    }
    public void _OnDeviceMotionChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnDeviceMotionChangeCallbackResult>(msg);
            OnDeviceMotionChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnDeviceMotionChange();
    private Action<OnDeviceMotionChangeCallbackResult> OnDeviceMotionChangeAction;
    public void OnDeviceMotionChange(Action<OnDeviceMotionChangeCallbackResult> result)
    {
        if(OnDeviceMotionChangeAction == null){
            WX_OnDeviceMotionChange();
        }
        OnDeviceMotionChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffDeviceMotionChange();
    public void OffDeviceMotionChange(Action<OnDeviceMotionChangeCallbackResult> result)
    {
        if(result == null){
            OnDeviceMotionChangeAction = null;
        }else{
            OnDeviceMotionChangeAction-=result;
        }
        if(OnDeviceMotionChangeAction == null){
            WX_OffDeviceMotionChange();
        }
    }
    public void _OnDeviceOrientationChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnDeviceOrientationChangeCallbackResult>(msg);
            OnDeviceOrientationChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnDeviceOrientationChange();
    private Action<OnDeviceOrientationChangeCallbackResult> OnDeviceOrientationChangeAction;
    public void OnDeviceOrientationChange(Action<OnDeviceOrientationChangeCallbackResult> result)
    {
        if(OnDeviceOrientationChangeAction == null){
            WX_OnDeviceOrientationChange();
        }
        OnDeviceOrientationChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffDeviceOrientationChange();
    public void OffDeviceOrientationChange(Action<OnDeviceOrientationChangeCallbackResult> result)
    {
        if(result == null){
            OnDeviceOrientationChangeAction = null;
        }else{
            OnDeviceOrientationChangeAction-=result;
        }
        if(OnDeviceOrientationChangeAction == null){
            WX_OffDeviceOrientationChange();
        }
    }
    public void _OnErrorCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<WxOnErrorCallbackResult>(msg);
            OnErrorAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnError();
    private Action<WxOnErrorCallbackResult> OnErrorAction;
    public void OnError(Action<WxOnErrorCallbackResult> result)
    {
        if(OnErrorAction == null){
            WX_OnError();
        }
        OnErrorAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffError();
    public void OffError(Action<WxOnErrorCallbackResult> result)
    {
        if(result == null){
            OnErrorAction = null;
        }else{
            OnErrorAction-=result;
        }
        if(OnErrorAction == null){
            WX_OffError();
        }
    }
    public void _OnGyroscopeChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnGyroscopeChangeCallbackResult>(msg);
            OnGyroscopeChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnGyroscopeChange();
    private Action<OnGyroscopeChangeCallbackResult> OnGyroscopeChangeAction;
    public void OnGyroscopeChange(Action<OnGyroscopeChangeCallbackResult> result)
    {
        if(OnGyroscopeChangeAction == null){
            WX_OnGyroscopeChange();
        }
        OnGyroscopeChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffGyroscopeChange();
    public void OffGyroscopeChange(Action<OnGyroscopeChangeCallbackResult> result)
    {
        if(result == null){
            OnGyroscopeChangeAction = null;
        }else{
            OnGyroscopeChangeAction-=result;
        }
        if(OnGyroscopeChangeAction == null){
            WX_OffGyroscopeChange();
        }
    }
    public void _OnHideCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<GeneralCallbackResult>(msg);
            OnHideAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnHide();
    private Action<GeneralCallbackResult> OnHideAction;
    public void OnHide(Action<GeneralCallbackResult> res)
    {
        if(OnHideAction == null){
            WX_OnHide();
        }
        OnHideAction+=res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffHide();
    public void OffHide(Action<GeneralCallbackResult> res)
    {
        if(res == null){
            OnHideAction = null;
        }else{
            OnHideAction-=res;
        }
        if(OnHideAction == null){
            WX_OffHide();
        }
    }
    public void _OnInteractiveStorageModifiedCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<string>(msg);
            OnInteractiveStorageModifiedAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnInteractiveStorageModified();
    private Action<string> OnInteractiveStorageModifiedAction;
    public void OnInteractiveStorageModified(Action<string> res)
    {
        if(OnInteractiveStorageModifiedAction == null){
            WX_OnInteractiveStorageModified();
        }
        OnInteractiveStorageModifiedAction+=res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffInteractiveStorageModified();
    public void OffInteractiveStorageModified(Action<string> res)
    {
        if(res == null){
            OnInteractiveStorageModifiedAction = null;
        }else{
            OnInteractiveStorageModifiedAction-=res;
        }
        if(OnInteractiveStorageModifiedAction == null){
            WX_OffInteractiveStorageModified();
        }
    }
    public void _OnKeyDownCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnKeyDownCallbackResult>(msg);
            OnKeyDownAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnKeyDown();
    private Action<OnKeyDownCallbackResult> OnKeyDownAction;
    public void OnKeyDown(Action<OnKeyDownCallbackResult> result)
    {
        if(OnKeyDownAction == null){
            WX_OnKeyDown();
        }
        OnKeyDownAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffKeyDown();
    public void OffKeyDown(Action<OnKeyDownCallbackResult> result)
    {
        if(result == null){
            OnKeyDownAction = null;
        }else{
            OnKeyDownAction-=result;
        }
        if(OnKeyDownAction == null){
            WX_OffKeyDown();
        }
    }
    public void _OnKeyUpCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnKeyDownCallbackResult>(msg);
            OnKeyUpAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnKeyUp();
    private Action<OnKeyDownCallbackResult> OnKeyUpAction;
    public void OnKeyUp(Action<OnKeyDownCallbackResult> result)
    {
        if(OnKeyUpAction == null){
            WX_OnKeyUp();
        }
        OnKeyUpAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffKeyUp();
    public void OffKeyUp(Action<OnKeyDownCallbackResult> result)
    {
        if(result == null){
            OnKeyUpAction = null;
        }else{
            OnKeyUpAction-=result;
        }
        if(OnKeyUpAction == null){
            WX_OffKeyUp();
        }
    }
    public void _OnKeyboardCompleteCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnKeyboardInputCallbackResult>(msg);
            OnKeyboardCompleteAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnKeyboardComplete();
    private Action<OnKeyboardInputCallbackResult> OnKeyboardCompleteAction;
    public void OnKeyboardComplete(Action<OnKeyboardInputCallbackResult> result)
    {
        if(OnKeyboardCompleteAction == null){
            WX_OnKeyboardComplete();
        }
        OnKeyboardCompleteAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffKeyboardComplete();
    public void OffKeyboardComplete(Action<OnKeyboardInputCallbackResult> result)
    {
        if(result == null){
            OnKeyboardCompleteAction = null;
        }else{
            OnKeyboardCompleteAction-=result;
        }
        if(OnKeyboardCompleteAction == null){
            WX_OffKeyboardComplete();
        }
    }
    public void _OnKeyboardConfirmCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnKeyboardInputCallbackResult>(msg);
            OnKeyboardConfirmAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnKeyboardConfirm();
    private Action<OnKeyboardInputCallbackResult> OnKeyboardConfirmAction;
    public void OnKeyboardConfirm(Action<OnKeyboardInputCallbackResult> result)
    {
        if(OnKeyboardConfirmAction == null){
            WX_OnKeyboardConfirm();
        }
        OnKeyboardConfirmAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffKeyboardConfirm();
    public void OffKeyboardConfirm(Action<OnKeyboardInputCallbackResult> result)
    {
        if(result == null){
            OnKeyboardConfirmAction = null;
        }else{
            OnKeyboardConfirmAction-=result;
        }
        if(OnKeyboardConfirmAction == null){
            WX_OffKeyboardConfirm();
        }
    }
    public void _OnKeyboardHeightChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnKeyboardHeightChangeCallbackResult>(msg);
            OnKeyboardHeightChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnKeyboardHeightChange();
    private Action<OnKeyboardHeightChangeCallbackResult> OnKeyboardHeightChangeAction;
    public void OnKeyboardHeightChange(Action<OnKeyboardHeightChangeCallbackResult> result)
    {
        if(OnKeyboardHeightChangeAction == null){
            WX_OnKeyboardHeightChange();
        }
        OnKeyboardHeightChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffKeyboardHeightChange();
    public void OffKeyboardHeightChange(Action<OnKeyboardHeightChangeCallbackResult> result)
    {
        if(result == null){
            OnKeyboardHeightChangeAction = null;
        }else{
            OnKeyboardHeightChangeAction-=result;
        }
        if(OnKeyboardHeightChangeAction == null){
            WX_OffKeyboardHeightChange();
        }
    }
    public void _OnKeyboardInputCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnKeyboardInputCallbackResult>(msg);
            OnKeyboardInputAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnKeyboardInput();
    private Action<OnKeyboardInputCallbackResult> OnKeyboardInputAction;
    public void OnKeyboardInput(Action<OnKeyboardInputCallbackResult> result)
    {
        if(OnKeyboardInputAction == null){
            WX_OnKeyboardInput();
        }
        OnKeyboardInputAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffKeyboardInput();
    public void OffKeyboardInput(Action<OnKeyboardInputCallbackResult> result)
    {
        if(result == null){
            OnKeyboardInputAction = null;
        }else{
            OnKeyboardInputAction-=result;
        }
        if(OnKeyboardInputAction == null){
            WX_OffKeyboardInput();
        }
    }
    public void _OnMemoryWarningCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnMemoryWarningCallbackResult>(msg);
            OnMemoryWarningAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnMemoryWarning();
    private Action<OnMemoryWarningCallbackResult> OnMemoryWarningAction;
    public void OnMemoryWarning(Action<OnMemoryWarningCallbackResult> result)
    {
        if(OnMemoryWarningAction == null){
            WX_OnMemoryWarning();
        }
        OnMemoryWarningAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffMemoryWarning();
    public void OffMemoryWarning(Action<OnMemoryWarningCallbackResult> result)
    {
        if(result == null){
            OnMemoryWarningAction = null;
        }else{
            OnMemoryWarningAction-=result;
        }
        if(OnMemoryWarningAction == null){
            WX_OffMemoryWarning();
        }
    }
    public void _OnMessageCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<string>(msg);
            OnMessageAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnMessage();
    private Action<string> OnMessageAction;
    public void OnMessage(Action<string> res)
    {
        if(OnMessageAction == null){
            WX_OnMessage();
        }
        OnMessageAction+=res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffMessage();
    public void OffMessage(Action<string> res)
    {
        if(res == null){
            OnMessageAction = null;
        }else{
            OnMessageAction-=res;
        }
        if(OnMessageAction == null){
            WX_OffMessage();
        }
    }
    public void _OnNetworkStatusChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnNetworkStatusChangeCallbackResult>(msg);
            OnNetworkStatusChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnNetworkStatusChange();
    private Action<OnNetworkStatusChangeCallbackResult> OnNetworkStatusChangeAction;
    public void OnNetworkStatusChange(Action<OnNetworkStatusChangeCallbackResult> result)
    {
        if(OnNetworkStatusChangeAction == null){
            WX_OnNetworkStatusChange();
        }
        OnNetworkStatusChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffNetworkStatusChange();
    public void OffNetworkStatusChange(Action<OnNetworkStatusChangeCallbackResult> result)
    {
        if(result == null){
            OnNetworkStatusChangeAction = null;
        }else{
            OnNetworkStatusChangeAction-=result;
        }
        if(OnNetworkStatusChangeAction == null){
            WX_OffNetworkStatusChange();
        }
    }
    public void _OnNetworkWeakChangeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnNetworkWeakChangeCallbackResult>(msg);
            OnNetworkWeakChangeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnNetworkWeakChange();
    private Action<OnNetworkWeakChangeCallbackResult> OnNetworkWeakChangeAction;
    public void OnNetworkWeakChange(Action<OnNetworkWeakChangeCallbackResult> result)
    {
        if(OnNetworkWeakChangeAction == null){
            WX_OnNetworkWeakChange();
        }
        OnNetworkWeakChangeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffNetworkWeakChange();
    public void OffNetworkWeakChange(Action<OnNetworkWeakChangeCallbackResult> result)
    {
        if(result == null){
            OnNetworkWeakChangeAction = null;
        }else{
            OnNetworkWeakChangeAction-=result;
        }
        if(OnNetworkWeakChangeAction == null){
            WX_OffNetworkWeakChange();
        }
    }
    public void _OnShareMessageToFriendCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnShareMessageToFriendCallbackResult>(msg);
            OnShareMessageToFriendAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnShareMessageToFriend();
    private Action<OnShareMessageToFriendCallbackResult> OnShareMessageToFriendAction;
    public void OnShareMessageToFriend(Action<OnShareMessageToFriendCallbackResult> result)
    {
        if(OnShareMessageToFriendAction == null){
            WX_OnShareMessageToFriend();
        }
        OnShareMessageToFriendAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffShareMessageToFriend();
    public void OffShareMessageToFriend(Action<OnShareMessageToFriendCallbackResult> result)
    {
        if(result == null){
            OnShareMessageToFriendAction = null;
        }else{
            OnShareMessageToFriendAction-=result;
        }
        if(OnShareMessageToFriendAction == null){
            WX_OffShareMessageToFriend();
        }
    }
    public void _OnShowCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnShowCallbackResult>(msg);
            OnShowAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnShow();
    private Action<OnShowCallbackResult> OnShowAction;
    public void OnShow(Action<OnShowCallbackResult> result)
    {
        if(OnShowAction == null){
            WX_OnShow();
        }
        OnShowAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffShow();
    public void OffShow(Action<OnShowCallbackResult> result)
    {
        if(result == null){
            OnShowAction = null;
        }else{
            OnShowAction-=result;
        }
        if(OnShowAction == null){
            WX_OffShow();
        }
    }
    public void _OnSocketCloseCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<SocketTaskOnCloseCallbackResult>(msg);
            OnSocketCloseAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnSocketClose();
    private Action<SocketTaskOnCloseCallbackResult> OnSocketCloseAction;
    public void OnSocketClose(Action<SocketTaskOnCloseCallbackResult> result)
    {
        if(OnSocketCloseAction == null){
            WX_OnSocketClose();
        }
        OnSocketCloseAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffSocketClose();
    public void OffSocketClose(Action<SocketTaskOnCloseCallbackResult> result)
    {
        if(result == null){
            OnSocketCloseAction = null;
        }else{
            OnSocketCloseAction-=result;
        }
        if(OnSocketCloseAction == null){
            WX_OffSocketClose();
        }
    }
    public void _OnSocketErrorCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<GeneralCallbackResult>(msg);
            OnSocketErrorAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnSocketError();
    private Action<GeneralCallbackResult> OnSocketErrorAction;
    public void OnSocketError(Action<GeneralCallbackResult> result)
    {
        if(OnSocketErrorAction == null){
            WX_OnSocketError();
        }
        OnSocketErrorAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffSocketError();
    public void OffSocketError(Action<GeneralCallbackResult> result)
    {
        if(result == null){
            OnSocketErrorAction = null;
        }else{
            OnSocketErrorAction-=result;
        }
        if(OnSocketErrorAction == null){
            WX_OffSocketError();
        }
    }
    public void _OnSocketMessageCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<SocketTaskOnMessageCallbackResult>(msg);
            OnSocketMessageAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnSocketMessage();
    private Action<SocketTaskOnMessageCallbackResult> OnSocketMessageAction;
    public void OnSocketMessage(Action<SocketTaskOnMessageCallbackResult> result)
    {
        if(OnSocketMessageAction == null){
            WX_OnSocketMessage();
        }
        OnSocketMessageAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffSocketMessage();
    public void OffSocketMessage(Action<SocketTaskOnMessageCallbackResult> result)
    {
        if(result == null){
            OnSocketMessageAction = null;
        }else{
            OnSocketMessageAction-=result;
        }
        if(OnSocketMessageAction == null){
            WX_OffSocketMessage();
        }
    }
    public void _OnSocketOpenCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnSocketOpenCallbackResult>(msg);
            OnSocketOpenAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnSocketOpen();
    private Action<OnSocketOpenCallbackResult> OnSocketOpenAction;
    public void OnSocketOpen(Action<OnSocketOpenCallbackResult> result)
    {
        if(OnSocketOpenAction == null){
            WX_OnSocketOpen();
        }
        OnSocketOpenAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffSocketOpen();
    public void OffSocketOpen(Action<OnSocketOpenCallbackResult> result)
    {
        if(result == null){
            OnSocketOpenAction = null;
        }else{
            OnSocketOpenAction-=result;
        }
        if(OnSocketOpenAction == null){
            WX_OffSocketOpen();
        }
    }
    public void _OnTouchCancelCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnTouchStartCallbackResult>(msg);
            OnTouchCancelAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnTouchCancel();
    private Action<OnTouchStartCallbackResult> OnTouchCancelAction;
    public void OnTouchCancel(Action<OnTouchStartCallbackResult> result)
    {
        if(OnTouchCancelAction == null){
            WX_OnTouchCancel();
        }
        OnTouchCancelAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffTouchCancel();
    public void OffTouchCancel(Action<OnTouchStartCallbackResult> result)
    {
        if(result == null){
            OnTouchCancelAction = null;
        }else{
            OnTouchCancelAction-=result;
        }
        if(OnTouchCancelAction == null){
            WX_OffTouchCancel();
        }
    }
    public void _OnTouchEndCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnTouchStartCallbackResult>(msg);
            OnTouchEndAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnTouchEnd();
    private Action<OnTouchStartCallbackResult> OnTouchEndAction;
    public void OnTouchEnd(Action<OnTouchStartCallbackResult> result)
    {
        if(OnTouchEndAction == null){
            WX_OnTouchEnd();
        }
        OnTouchEndAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffTouchEnd();
    public void OffTouchEnd(Action<OnTouchStartCallbackResult> result)
    {
        if(result == null){
            OnTouchEndAction = null;
        }else{
            OnTouchEndAction-=result;
        }
        if(OnTouchEndAction == null){
            WX_OffTouchEnd();
        }
    }
    public void _OnTouchMoveCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnTouchStartCallbackResult>(msg);
            OnTouchMoveAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnTouchMove();
    private Action<OnTouchStartCallbackResult> OnTouchMoveAction;
    public void OnTouchMove(Action<OnTouchStartCallbackResult> result)
    {
        if(OnTouchMoveAction == null){
            WX_OnTouchMove();
        }
        OnTouchMoveAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffTouchMove();
    public void OffTouchMove(Action<OnTouchStartCallbackResult> result)
    {
        if(result == null){
            OnTouchMoveAction = null;
        }else{
            OnTouchMoveAction-=result;
        }
        if(OnTouchMoveAction == null){
            WX_OffTouchMove();
        }
    }
    public void _OnTouchStartCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnTouchStartCallbackResult>(msg);
            OnTouchStartAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnTouchStart();
    private Action<OnTouchStartCallbackResult> OnTouchStartAction;
    public void OnTouchStart(Action<OnTouchStartCallbackResult> result)
    {
        if(OnTouchStartAction == null){
            WX_OnTouchStart();
        }
        OnTouchStartAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffTouchStart();
    public void OffTouchStart(Action<OnTouchStartCallbackResult> result)
    {
        if(result == null){
            OnTouchStartAction = null;
        }else{
            OnTouchStartAction-=result;
        }
        if(OnTouchStartAction == null){
            WX_OffTouchStart();
        }
    }
    public void _OnUnhandledRejectionCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnUnhandledRejectionCallbackResult>(msg);
            OnUnhandledRejectionAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnUnhandledRejection();
    private Action<OnUnhandledRejectionCallbackResult> OnUnhandledRejectionAction;
    public void OnUnhandledRejection(Action<OnUnhandledRejectionCallbackResult> result)
    {
        if(OnUnhandledRejectionAction == null){
            WX_OnUnhandledRejection();
        }
        OnUnhandledRejectionAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffUnhandledRejection();
    public void OffUnhandledRejection(Action<OnUnhandledRejectionCallbackResult> result)
    {
        if(result == null){
            OnUnhandledRejectionAction = null;
        }else{
            OnUnhandledRejectionAction-=result;
        }
        if(OnUnhandledRejectionAction == null){
            WX_OffUnhandledRejection();
        }
    }
    public void _OnUserCaptureScreenCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<GeneralCallbackResult>(msg);
            OnUserCaptureScreenAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnUserCaptureScreen();
    private Action<GeneralCallbackResult> OnUserCaptureScreenAction;
    public void OnUserCaptureScreen(Action<GeneralCallbackResult> res)
    {
        if(OnUserCaptureScreenAction == null){
            WX_OnUserCaptureScreen();
        }
        OnUserCaptureScreenAction+=res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffUserCaptureScreen();
    public void OffUserCaptureScreen(Action<GeneralCallbackResult> res)
    {
        if(res == null){
            OnUserCaptureScreenAction = null;
        }else{
            OnUserCaptureScreenAction-=res;
        }
        if(OnUserCaptureScreenAction == null){
            WX_OffUserCaptureScreen();
        }
    }
    public void _OnVoIPChatInterruptedCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnVoIPChatInterruptedCallbackResult>(msg);
            OnVoIPChatInterruptedAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnVoIPChatInterrupted();
    private Action<OnVoIPChatInterruptedCallbackResult> OnVoIPChatInterruptedAction;
    public void OnVoIPChatInterrupted(Action<OnVoIPChatInterruptedCallbackResult> result)
    {
        if(OnVoIPChatInterruptedAction == null){
            WX_OnVoIPChatInterrupted();
        }
        OnVoIPChatInterruptedAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffVoIPChatInterrupted();
    public void OffVoIPChatInterrupted(Action<OnVoIPChatInterruptedCallbackResult> result)
    {
        if(result == null){
            OnVoIPChatInterruptedAction = null;
        }else{
            OnVoIPChatInterruptedAction-=result;
        }
        if(OnVoIPChatInterruptedAction == null){
            WX_OffVoIPChatInterrupted();
        }
    }
    public void _OnVoIPChatMembersChangedCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnVoIPChatMembersChangedCallbackResult>(msg);
            OnVoIPChatMembersChangedAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnVoIPChatMembersChanged();
    private Action<OnVoIPChatMembersChangedCallbackResult> OnVoIPChatMembersChangedAction;
    public void OnVoIPChatMembersChanged(Action<OnVoIPChatMembersChangedCallbackResult> result)
    {
        if(OnVoIPChatMembersChangedAction == null){
            WX_OnVoIPChatMembersChanged();
        }
        OnVoIPChatMembersChangedAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffVoIPChatMembersChanged();
    public void OffVoIPChatMembersChanged(Action<OnVoIPChatMembersChangedCallbackResult> result)
    {
        if(result == null){
            OnVoIPChatMembersChangedAction = null;
        }else{
            OnVoIPChatMembersChangedAction-=result;
        }
        if(OnVoIPChatMembersChangedAction == null){
            WX_OffVoIPChatMembersChanged();
        }
    }
    public void _OnVoIPChatSpeakersChangedCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnVoIPChatSpeakersChangedCallbackResult>(msg);
            OnVoIPChatSpeakersChangedAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnVoIPChatSpeakersChanged();
    private Action<OnVoIPChatSpeakersChangedCallbackResult> OnVoIPChatSpeakersChangedAction;
    public void OnVoIPChatSpeakersChanged(Action<OnVoIPChatSpeakersChangedCallbackResult> result)
    {
        if(OnVoIPChatSpeakersChangedAction == null){
            WX_OnVoIPChatSpeakersChanged();
        }
        OnVoIPChatSpeakersChangedAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffVoIPChatSpeakersChanged();
    public void OffVoIPChatSpeakersChanged(Action<OnVoIPChatSpeakersChangedCallbackResult> result)
    {
        if(result == null){
            OnVoIPChatSpeakersChangedAction = null;
        }else{
            OnVoIPChatSpeakersChangedAction-=result;
        }
        if(OnVoIPChatSpeakersChangedAction == null){
            WX_OffVoIPChatSpeakersChanged();
        }
    }
    public void _OnVoIPChatStateChangedCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnVoIPChatStateChangedCallbackResult>(msg);
            OnVoIPChatStateChangedAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnVoIPChatStateChanged();
    private Action<OnVoIPChatStateChangedCallbackResult> OnVoIPChatStateChangedAction;
    public void OnVoIPChatStateChanged(Action<OnVoIPChatStateChangedCallbackResult> result)
    {
        if(OnVoIPChatStateChangedAction == null){
            WX_OnVoIPChatStateChanged();
        }
        OnVoIPChatStateChangedAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffVoIPChatStateChanged();
    public void OffVoIPChatStateChanged(Action<OnVoIPChatStateChangedCallbackResult> result)
    {
        if(result == null){
            OnVoIPChatStateChangedAction = null;
        }else{
            OnVoIPChatStateChangedAction-=result;
        }
        if(OnVoIPChatStateChangedAction == null){
            WX_OffVoIPChatStateChanged();
        }
    }
    public void _OnWindowResizeCallback(string msg){
        if (!string.IsNullOrEmpty(msg))
        {
            var res = JsonMapper.ToObject<OnWindowResizeCallbackResult>(msg);
            OnWindowResizeAction?.Invoke(res);
        }
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnWindowResize();
    private Action<OnWindowResizeCallbackResult> OnWindowResizeAction;
    public void OnWindowResize(Action<OnWindowResizeCallbackResult> result)
    {
        if(OnWindowResizeAction == null){
            WX_OnWindowResize();
        }
        OnWindowResizeAction+=result;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffWindowResize();
    public void OffWindowResize(Action<OnWindowResizeCallbackResult> result)
    {
        if(result == null){
            OnWindowResizeAction = null;
        }else{
            OnWindowResizeAction-=result;
        }
        if(OnWindowResizeAction == null){
            WX_OffWindowResize();
        }
    }

    public void _OnAddToFavoritesCallback(string msg){
            OnAddToFavoritesAction?.Invoke((OnAddToFavoritesCallbackResult param) =>
                {
                    if (param == null)
                    {
                        param = new OnAddToFavoritesCallbackResult();
                    }
                    WX_OnAddToFavorites_Resolve(JsonMapper.ToJson(param));
                });

    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnAddToFavorites_Resolve(string conf);
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnAddToFavorites();
    private Action<Action<OnAddToFavoritesCallbackResult>> OnAddToFavoritesAction;
    public void OnAddToFavorites(Action<Action<OnAddToFavoritesCallbackResult>> callback)
        {
            OnAddToFavoritesAction=callback;
            WX_OnAddToFavorites();
        }    
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffAddToFavorites();
    public void OffAddToFavorites(Action<Action<OnAddToFavoritesCallbackResult>> callback)
    {
        if(callback == null){
            OnAddToFavoritesAction = null;
        }else{
            OnAddToFavoritesAction-=callback;
        }
        if(OnAddToFavoritesAction == null){
            WX_OffAddToFavorites();
        }
    }
    public void _OnCopyUrlCallback(string msg){
            OnCopyUrlAction?.Invoke((OnCopyUrlCallbackResult param) =>
                {
                    if (param == null)
                    {
                        param = new OnCopyUrlCallbackResult();
                    }
                    WX_OnCopyUrl_Resolve(JsonMapper.ToJson(param));
                });

    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnCopyUrl_Resolve(string conf);
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnCopyUrl();
    private Action<Action<OnCopyUrlCallbackResult>> OnCopyUrlAction;
    public void OnCopyUrl(Action<Action<OnCopyUrlCallbackResult>> callback)
        {
            OnCopyUrlAction=callback;
            WX_OnCopyUrl();
        }    
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffCopyUrl();
    public void OffCopyUrl(Action<Action<OnCopyUrlCallbackResult>> callback)
    {
        if(callback == null){
            OnCopyUrlAction = null;
        }else{
            OnCopyUrlAction-=callback;
        }
        if(OnCopyUrlAction == null){
            WX_OffCopyUrl();
        }
    }
    public void _OnHandoffCallback(string msg){
            OnHandoffAction?.Invoke((OnHandoffCallbackResult param) =>
                {
                    if (param == null)
                    {
                        param = new OnHandoffCallbackResult();
                    }
                    WX_OnHandoff_Resolve(JsonMapper.ToJson(param));
                });

    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnHandoff_Resolve(string conf);
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnHandoff();
    private Action<Action<OnHandoffCallbackResult>> OnHandoffAction;
    public void OnHandoff(Action<Action<OnHandoffCallbackResult>> callback)
        {
            OnHandoffAction=callback;
            WX_OnHandoff();
        }    
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffHandoff();
    public void OffHandoff(Action<Action<OnHandoffCallbackResult>> callback)
    {
        if(callback == null){
            OnHandoffAction = null;
        }else{
            OnHandoffAction-=callback;
        }
        if(OnHandoffAction == null){
            WX_OffHandoff();
        }
    }
    public void _OnShareTimelineCallback(string msg){
            OnShareTimelineAction?.Invoke((OnShareTimelineCallbackResult param) =>
                {
                    if (param == null)
                    {
                        param = new OnShareTimelineCallbackResult();
                    }
                    WX_OnShareTimeline_Resolve(JsonMapper.ToJson(param));
                });

    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnShareTimeline_Resolve(string conf);
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnShareTimeline();
    private Action<Action<OnShareTimelineCallbackResult>> OnShareTimelineAction;
    public void OnShareTimeline(Action<Action<OnShareTimelineCallbackResult>> callback)
        {
            OnShareTimelineAction=callback;
            WX_OnShareTimeline();
        }    
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffShareTimeline();
    public void OffShareTimeline(Action<Action<OnShareTimelineCallbackResult>> callback)
    {
        if(callback == null){
            OnShareTimelineAction = null;
        }else{
            OnShareTimelineAction-=callback;
        }
        if(OnShareTimelineAction == null){
            WX_OffShareTimeline();
        }
    }
    public void _OnGameLiveStateChangeCallback(string msg){
            if (!string.IsNullOrEmpty(msg))
            {
                var res = JsonMapper.ToObject<OnGameLiveStateChangeCallbackResult>(msg);
                OnGameLiveStateChangeAction?.Invoke(res,(OnGameLiveStateChangeCallbackResponse param) =>
                {
                    if (param == null)
                    {
                        param = new OnGameLiveStateChangeCallbackResponse();
                    }
                    WX_OnGameLiveStateChange_Resolve(JsonMapper.ToJson(param));
                });
            }

    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnGameLiveStateChange_Resolve(string conf);
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OnGameLiveStateChange();
    private Action<OnGameLiveStateChangeCallbackResult,Action<OnGameLiveStateChangeCallbackResponse>> OnGameLiveStateChangeAction;
    public void OnGameLiveStateChange(Action<OnGameLiveStateChangeCallbackResult,Action<OnGameLiveStateChangeCallbackResponse>> callback)
        {
            OnGameLiveStateChangeAction=callback;
            WX_OnGameLiveStateChange();
        }    
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern void WX_OffGameLiveStateChange();
    public void OffGameLiveStateChange(Action<OnGameLiveStateChangeCallbackResult,Action<OnGameLiveStateChangeCallbackResponse>> callback)
    {
        if(callback == null){
            OnGameLiveStateChangeAction = null;
        }else{
            OnGameLiveStateChangeAction-=callback;
        }
        if(OnGameLiveStateChangeAction == null){
            WX_OffGameLiveStateChange();
        }
    }

    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern bool WX_SetHandoffQuery(string query);
    public bool SetHandoffQuery(string query)
    {
        var res = WX_SetHandoffQuery(query);
        return res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetAccountInfoSync();
    public AccountInfo GetAccountInfoSync()
    {
        var res = WX_GetAccountInfoSync();
        return JsonMapper.ToObject<AccountInfo>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetBatteryInfoSync();
    public GetBatteryInfoSyncResult GetBatteryInfoSync()
    {
        var res = WX_GetBatteryInfoSync();
        return JsonMapper.ToObject<GetBatteryInfoSyncResult>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetEnterOptionsSync();
    public EnterOptionsGame GetEnterOptionsSync()
    {
        var res = WX_GetEnterOptionsSync();
        return JsonMapper.ToObject<EnterOptionsGame>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetExptInfoSync(string keys);
    public T GetExptInfoSync<T>(string[] keys)
    {
        var res = WX_GetExptInfoSync(JsonMapper.ToJson(keys));
        return JsonMapper.ToObject<T>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetExtConfigSync();
    public T GetExtConfigSync<T>()
    {
        var res = WX_GetExtConfigSync();
        return JsonMapper.ToObject<T>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetLaunchOptionsSync();
    public LaunchOptionsGame GetLaunchOptionsSync()
    {
        var res = WX_GetLaunchOptionsSync();
        return JsonMapper.ToObject<LaunchOptionsGame>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetMenuButtonBoundingClientRect();
    public ClientRect GetMenuButtonBoundingClientRect()
    {
        var res = WX_GetMenuButtonBoundingClientRect();
        return JsonMapper.ToObject<ClientRect>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetStorageInfoSync();
    public GetStorageInfoSyncOption GetStorageInfoSync()
    {
        var res = WX_GetStorageInfoSync();
        return JsonMapper.ToObject<GetStorageInfoSyncOption>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetSystemInfoSync();
    public SystemInfo GetSystemInfoSync()
    {
        var res = WX_GetSystemInfoSync();
        return JsonMapper.ToObject<SystemInfo>(res);
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern bool WX_SetCursor(string path,double x,double y);
    public bool SetCursor(string path,double x,double y)
    {
        var res = WX_SetCursor(path,x,y);
        return res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern bool WX_SetMessageToFriendQuery(string option);
    public bool SetMessageToFriendQuery(SetMessageToFriendQueryOption option)
    {
        var res = WX_SetMessageToFriendQuery(JsonMapper.ToJson(option));
        return res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern double WX_GetTextLineHeight(string option);
    public double GetTextLineHeight(GetTextLineHeightOption option)
    {
        var res = WX_GetTextLineHeight(JsonMapper.ToJson(option));
        return res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_LoadFont(string path);
    public string LoadFont(string path)
    {
        var res = WX_LoadFont(path);
        return res;
    }
    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetGameLiveState();
    public GameLiveState GetGameLiveState()
    {
        var res = WX_GetGameLiveState();
        return JsonMapper.ToObject<GameLiveState>(res);
    }

    #if UNITY_WEBGL
    [DllImport("__Internal")]
    #endif
    private static extern string WX_GetUpdateManager();
    private Dictionary<string, UpdateManager> UpdateManagerList = new Dictionary<string, UpdateManager>();
    public UpdateManager GetUpdateManager()
    {
        var id = WX_GetUpdateManager();
        var obj = new UpdateManager(id);
        UpdateManagerList.Add(id,obj);
        return obj; 
    }


#if UNITY_WEBGL
[DllImport("__Internal")]
#endif
private static extern void WX_ApplyUpdate(string id);          
public void ApplyUpdate(string id){
    WX_ApplyUpdate(id);
}

public void _OnCheckForUpdateCallback(string msg){
    if (!string.IsNullOrEmpty(msg))
    {
        var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
        var id = jsCallback.callbackId;
        var res = jsCallback.res;
        if(!OnCheckForUpdateActionList.ContainsKey(id)){
            return;
        }
        var result = JsonMapper.ToObject<OnCheckForUpdateCallbackResult>(msg);
        OnCheckForUpdateActionList[id]?.Invoke(result);
    }
}
#if UNITY_WEBGL
[DllImport("__Internal")]
#endif
private static extern void WX_OnCheckForUpdate(string id);
private Dictionary<string,Action<OnCheckForUpdateCallbackResult>> OnCheckForUpdateActionList;
public void OnCheckForUpdate(string id,Action<OnCheckForUpdateCallbackResult> callback){
    if(OnCheckForUpdateActionList == null){
        OnCheckForUpdateActionList = new Dictionary<string,Action<OnCheckForUpdateCallbackResult>>();
    }
    if(OnCheckForUpdateActionList.ContainsKey(id)){
        OnCheckForUpdateActionList[id] += callback;
    }else{
        OnCheckForUpdateActionList.Add(id,callback);
        WX_OnCheckForUpdate(id);
    }
}

public void _OnUpdateFailedCallback(string msg){
    if (!string.IsNullOrEmpty(msg))
    {
        var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
        var id = jsCallback.callbackId;
        var res = jsCallback.res;
        if(!OnUpdateFailedActionList.ContainsKey(id)){
            return;
        }
        var result = JsonMapper.ToObject<GeneralCallbackResult>(msg);
        OnUpdateFailedActionList[id]?.Invoke(result);
    }
}
#if UNITY_WEBGL
[DllImport("__Internal")]
#endif
private static extern void WX_OnUpdateFailed(string id);
private Dictionary<string,Action<GeneralCallbackResult>> OnUpdateFailedActionList;
public void OnUpdateFailed(string id,Action<GeneralCallbackResult> callback){
    if(OnUpdateFailedActionList == null){
        OnUpdateFailedActionList = new Dictionary<string,Action<GeneralCallbackResult>>();
    }
    if(OnUpdateFailedActionList.ContainsKey(id)){
        OnUpdateFailedActionList[id] += callback;
    }else{
        OnUpdateFailedActionList.Add(id,callback);
        WX_OnUpdateFailed(id);
    }
}

public void _OnUpdateReadyCallback(string msg){
    if (!string.IsNullOrEmpty(msg))
    {
        var jsCallback = JsonUtility.FromJson<WXJSCallback>(msg);
        var id = jsCallback.callbackId;
        var res = jsCallback.res;
        if(!OnUpdateReadyActionList.ContainsKey(id)){
            return;
        }
        var result = JsonMapper.ToObject<GeneralCallbackResult>(msg);
        OnUpdateReadyActionList[id]?.Invoke(result);
    }
}
#if UNITY_WEBGL
[DllImport("__Internal")]
#endif
private static extern void WX_OnUpdateReady(string id);
private Dictionary<string,Action<GeneralCallbackResult>> OnUpdateReadyActionList;
public void OnUpdateReady(string id,Action<GeneralCallbackResult> callback){
    if(OnUpdateReadyActionList == null){
        OnUpdateReadyActionList = new Dictionary<string,Action<GeneralCallbackResult>>();
    }
    if(OnUpdateReadyActionList.ContainsKey(id)){
        OnUpdateReadyActionList[id] += callback;
    }else{
        OnUpdateReadyActionList.Add(id,callback);
        WX_OnUpdateReady(id);
    }
}

    }
}