using UnityEngine;
using System.Runtime.InteropServices;
using System;
using LitJson;
using System.Collections.Generic;

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

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVibrateShort(string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVibrateLong(string s, string f, string c);

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
        private static extern void WXLogin(string s, string f, string c);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXCheckSession(string s, string f, string c);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXAuthorize(string scope, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXGetUserInfo(bool withCredentials, string lang, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXGetSystemLanguage();

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXGetSystemInfo(string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXGetSystemInfoSync();


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateUserInfoButton(int x, int y, int width, int height, string lang, bool withCredentials);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXUpdateShareMenu(string conf, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXShowShareMenu(string conf, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXHideShareMenu(string conf, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXShareAppMessage(string conf);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern bool WXSetMessageToFriendQuery(int num);

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
        private static extern void WXOnShareTimeline(string conf, bool needCallback);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXOnAddToFavorites(string conf, bool needCallbac);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXOffShareTimeline();

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXOffShareAppMessage();

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXOffAddToFavorites();

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXGetShareInfo(string conf, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXAuthPrivateMessage(string conf, string s, string f, string c);

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
        private static extern string WXGetLaunchOptionsSync();

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateFixedBottomMiddleBannerAd(string adUnitId, int adIntervals, int height);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXDataContextPostMessage(string msg);

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXShowOpenData(IntPtr id, int x, int y, int width, int height);
#else
        void WXShowOpenData(IntPtr id, int x, int y, int width, int height)
        {
            Debug.Log("已展示排行榜，具体显示请在开发者工具中体验。");
        }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXHideOpenData();
#else
        void WXHideOpenData()
        {
            Debug.Log("已关闭排行榜，具体显示请在开发者工具中体验。");
        }
#endif

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXUpdateKeyboard(string value, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXShowKeyboard(string conf, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXHideKeyboard(string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXSetUserCloudStorage(string list, string s, string f, string c);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXRemoveUserCloudStorage(string list, string s, string f, string c);

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
        private static extern void WXRequestMidasPayment(string conf, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXRequestMidasFriendPayment(string conf, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXGetNetworkType(string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXSetKeepScreenOn(bool keepScreenOn, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXExitMiniProgram(string s, string f, string c);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXOpenCustomerServiceConversation(string conf, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCreateVideo(string conf);

        


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
#else
        private static uint WXGetTotalMemorySize() { return 0; }
        private static uint WXGetTotalStackSize() { return 0; }
        private static uint WXGetStaticMemorySize() { return 0; }
        private static uint WXGetDynamicMemorySize() { return 0; }
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

        public void LoginResponseCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<WXLoginResponse>(msg);
        }

        public void CloudCallFunctionResponseCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<WXCloudCallFunctionResponse>(msg);
        }

        public void UserInfoResponseCallback(string msg)
        {
            WXCallBackHandler.InvokeUserInfoResponseCallback(msg);
        }

        public void UserInfoButtonOnTapCallback(string msg)
        {
            WXCallBackHandler.InvokeUserInfoButtonCallback(msg);
        }

        public void GetNetworkTypeCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<GetNetworkTypeResponse>(msg);
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

        public void OnShareTimelineCallback()
        {
            onShareTimelineCallback?.Invoke();
        }

        public void OnAddToFavoritesCallback()
        {
            onAddToFavoritesCallback?.Invoke();
        }


        public void ShareInfoResponseCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<WXShareInfoResponse>(msg);
        }

        public void AuthPrivateMessageFormatCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<WXAuthPrivateMessageResponse>(msg);
        }


        public void ADOnErrorCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXADErrorResponse>(msg);
            var ad = WXBaseAd.Dict[res.callbackId];
            if (ad != null)
            {
                ad.onErrorAction?.Invoke(res);
            }
        }

        public void ADOnLoadCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXBaseResponse>(msg);
            var ad = WXBaseAd.Dict[res.callbackId];
            if (ad != null)
            {
                ad.onLoadActon?.Invoke();
            }
        }


        public void ADOnResizeCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXADResizeResponse>(msg);
            var ad = (IWXAdResizable)WXBaseAd.Dict[res.callbackId];
            if (ad != null)
            {
                ad.OnResizeCallback(res);
            }
        }

        public void ADOnVideoCloseCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXRewardedVideoAdOnCloseResponse>(msg);
            var ad = (IWXAdVideoCloseable)WXBaseAd.Dict[res.callbackId];

            if (ad != null)
            {
                ad.OnCloseCallback(res);
            }
        }

        public void ADOnCloseCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXBaseResponse>(msg);
            var ad = (IWXADCloseable)WXBaseAd.Dict[res.callbackId];

            if (ad != null)
            {
                ad.OnCloseCallback();
            }
        }


        public void ADLoadErrorCallback(string msg)
        {
            WXCallBackHandler.InvokeResponseCallback<WXADErrorResponse>(msg);
        }


        public void OnShowCallback(string msg)
        {
            if (onShowAction != null)
            {
                var res = JsonUtility.FromJson<WXOnShowResponse>(msg);
                res.referrerInfo = JsonUtility.FromJson<ReferrerInfo>(res.referrerInfoRaw);
                onShowAction?.Invoke(res);
            }
        }


        public void OnHideCallback()
        {
            onHideAction?.Invoke();
        }


        public void SysInfoResponseCallback(string msg)
        {
            WXCallBackHandler.InvokeSysInfoResponseCallback(msg);
        }


        public void OnKeyboardInputCallBack(string msg)
        {
            onKeyboardInputAction?.Invoke(msg);
        }

        public void OnKeyboardConfirmCallBack(string msg)
        {
            onKeyboardConfirmAction?.Invoke(msg);
        }

        public void OnKeyboardCompleteCallBack(string msg)
        {
            onKeyboardCompleteAction?.Invoke(msg);
        }

        public void OnAudioInterruptionEndCallback()
        {
            audioInterruptionEndAction?.Invoke();
        }

        public void OnAudioInterruptionBeginCallback()
        {
            audioInterruptionBeginAction?.Invoke();
        }


        public void OnTouchStartCallBack(string msg)
        {
            if (onTouchStartAction != null)
            {
                TouchEvent e = JsonMapper.ToObject<TouchEvent>(msg);
                onTouchStartAction.Invoke(e);
            }
        }

        public void OnTouchEndCallBack(string msg)
        {
            if (onTouchEndAction != null)
            {
                TouchEvent e = JsonMapper.ToObject<TouchEvent>(msg);
                onTouchEndAction.Invoke(e);
            }

        }

        public void OnTouchMoveCallBack(string msg)
        {
            if (onTouchMoveAction != null)
            {
                TouchEvent e = JsonMapper.ToObject<TouchEvent>(msg);
                onTouchMoveAction.Invoke(e);
            }

        }

        public void OnAudioCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXBaseResponse>(msg);
            var audio = WXInnerAudioContext.Dict[res.callbackId];
            audio._HandleCallBack(res.errMsg);
        }

        public void WXPreDownloadAudiosCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXBaseResponse>(msg);
            int.TryParse(res.callbackId, out int id);
            var action = PreDownloadAudiosAction[id];
            action.Invoke(res.errMsg == "0" ? 0 : 1);
        }

        public void OnVideoCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXVideoCallback>(msg);
            var video = WXVideo._Dict[res.callbackId];
            video._HandleCallBack(res);
        }


        public void WXOnNetworkStatusChangeCallback(string msg) {
            if (onNetworkStatusChange !=null) {
                NetworkStatus networkStatus = JsonUtility.FromJson<NetworkStatus>(msg);
                onNetworkStatusChange.Invoke(networkStatus);
            }
        }


        public void ReadFileCallback(string msg)
        {
            WXFileSystemManager.HanldReadFileCallback(msg);
        }



        #endregion



        #region 初始化SDK
        public void InitSDK(Action<int> callback)
        {

            initCallback = callback;

            WXInitializeSDK(Application.unityVersion);

        }


        private Action<int> initCallback;



        #endregion

        #region 振动

        public void VibrateShort(Action<WXTextResponse> succCallback = null, Action<WXTextResponse> failCallback = null, Action<WXTextResponse> compCallback = null)
        {
            WXVibrateShort(WXCallBackHandler.Add(succCallback), WXCallBackHandler.Add(failCallback), WXCallBackHandler.Add(compCallback));
        }



        public void VibrateLong(Action<WXTextResponse> succCallback = null, Action<WXTextResponse> failCallback = null, Action<WXTextResponse> compCallback = null)
        {
            WXVibrateLong(WXCallBackHandler.Add(succCallback), WXCallBackHandler.Add(failCallback), WXCallBackHandler.Add(compCallback));
        }



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



        #region 登录

        public void Login(Action<WXLoginResponse> succCallback = null, Action<WXLoginResponse> failCallback = null, Action<WXLoginResponse> compCallback = null)
        {
            WXLogin(WXCallBackHandler.Add(succCallback), WXCallBackHandler.Add(failCallback), WXCallBackHandler.Add(compCallback));
        }



        public void CheckSession(Action<WXTextResponse> succCallback = null, Action<WXTextResponse> failCallback = null, Action<WXTextResponse> compCallback = null)
        {
            WXCheckSession(WXCallBackHandler.Add(succCallback), WXCallBackHandler.Add(failCallback), WXCallBackHandler.Add(compCallback));
        }



        public void Authorize(string scope, Action<WXTextResponse> succCallback, Action<WXTextResponse> failCallback, Action<WXTextResponse> compCallback)
        {
            WXAuthorize(scope, WXCallBackHandler.Add(succCallback), WXCallBackHandler.Add(failCallback), WXCallBackHandler.Add(compCallback));
        }

        #endregion


        #region 用户信息

        public void GetUserInfo(bool withCredentials, string lang, Action<WXUserInfoResponse> succCallback, Action<WXUserInfoResponse> failCallback, Action<WXUserInfoResponse> compCallback = null)
        {
            WXGetUserInfo(withCredentials, lang, WXCallBackHandler.Add(succCallback), WXCallBackHandler.Add(failCallback), WXCallBackHandler.Add(compCallback));
        }


        public WXUserInfoButton CreateUserInfoButton(int x, int y, int width, int height, string lang, bool withCredentials)
        {
            string id = WXCreateUserInfoButton(x, y, width, height, lang, withCredentials);

            var button = new WXUserInfoButton(id);

            WXUserInfoButton.Dict.Add(id, button);

            return button;

        }


        #endregion


        #region 系统


        public string GetSystemLanguage()
        {
            return WXGetSystemLanguage();
        }

        public void GetSystemInfo(WXBaseActionParam<WXSystemInfo> param)
        {
            WXGetSystemInfo(WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }


        public WXSystemInfo GetSystemInfoSync()
        {
            string str = WXGetSystemInfoSync();
            WXSystemInfo res = JsonUtility.FromJson<WXSystemInfo>(str);
            res.safeArea = JsonUtility.FromJson<WXSafeArea>(res.safeAreaRaw);
            return res;
        }

        private Action audioInterruptionBeginAction;
        private Action audioInterruptionEndAction;

        public void OnAudioInterruptionBegin(Action action)
        {
            audioInterruptionBeginAction += action;
        }

        public void OnAudioInterruptionEnd(Action action)
        {
            audioInterruptionEndAction += action;
        }

        public void OffAudioInterruptionEnd(Action action)
        {
            if (action == null)
            {
                audioInterruptionEndAction = action;
            }
            else
            {
                audioInterruptionEndAction -= action;
            }

        }
        public void OffAudioInterruptionBegin(Action action)
        {
            if (action == null)
            {
                audioInterruptionBeginAction = action;
            }
            else
            {
                audioInterruptionBeginAction -= action;
            }

        }


        #endregion


        #region 分享转发

        private Action<Action<WXShareAppMessageParam>> onShareAppMessageCallback;
        private Action onShareTimelineCallback;
        private Action onAddToFavoritesCallback;


        public void UpdateShareMenu(WXUpdateShareMenuParam param)
        {
            if (param == null)
            {
                param = new WXUpdateShareMenuParam();
            }
            if (param.templateInfo != null)
            {
                var list = param.templateInfo.parameterList;
                string[] strList = new string[list.Length];
                for (var i = 0; i < list.Length; i++)
                {
                    strList[i] = JsonUtility.ToJson(list[i]);
                }
                param.templateInfoRaw = strList;
            }
            WXUpdateShareMenu(JsonUtility.ToJson(param), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        public void ShowShareMenu(WXShowShareMenuParam param)
        {
            if (param == null)
            {
                param = new WXShowShareMenuParam();
            }
            WXShowShareMenu(JsonUtility.ToJson(param), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        public void HideShareMenu(WXHideShareMenuParam param = null)
        {
            if (param == null)
            {
                param = new WXHideShareMenuParam();
            }
            WXHideShareMenu(JsonUtility.ToJson(param), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        public void ShareAppMessage(WXShareAppMessageParam param = null)
        {
            if (param == null)
            {
                param = new WXShareAppMessageParam();
            }
            WXShareAppMessage(JsonUtility.ToJson(param));
        }

        public void OnShareAppMessage(WXShareAppMessageParam defaultParam, Action<Action<WXShareAppMessageParam>> action)
        {
            if (defaultParam == null)
            {
                defaultParam = new WXShareAppMessageParam();
            }
            WXOnShareAppMessage(JsonUtility.ToJson(defaultParam), action != null);
            onShareAppMessageCallback = action;
        }

        public void OffShareAppMessage()
        {
            WXOffShareAppMessage();
        }

        public bool SetMessageToFriendQuery(int shareMessageToFriendScene)
        {
            return WXSetMessageToFriendQuery(shareMessageToFriendScene);
        }


        public void OnShareTimeline(WXShareTimelineParam param, Action action = null)
        {
            if (param == null)
            {
                param = new WXShareTimelineParam();
            }
            onShareTimelineCallback = action;
            WXOnShareTimeline(JsonUtility.ToJson(param), action != null);
        }

        public void OffShareTimeline()
        {
            WXOffShareTimeline();
        }


        public void OnAddToFavorites(WXAddToFavoritesParam param, Action action = null)
        {
            if (param == null)
            {
                param = new WXAddToFavoritesParam();
            }
            onAddToFavoritesCallback = action;
            WXOnAddToFavorites(JsonUtility.ToJson(param), action != null);
        }

        public void OffAddToFavorites()
        {
            WXOffAddToFavorites();
        }


        public void GetShareInfo(WXGetShareInfoParam param)
        {
            if (param == null)
            {
                Debug.LogError("GetShareInfo 参数不能为空！shareTicket 必须要传！");
                param = new WXGetShareInfoParam();
            }
            WXGetShareInfo(JsonUtility.ToJson(param), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }



        public void AuthPrivateMessage(WXAuthPrivateMessageParam param)
        {
            if (param == null)
            {
                param = new WXAuthPrivateMessageParam();
            }
            WXAuthPrivateMessage(JsonUtility.ToJson(param), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
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


        #region 生命周期

        private Action<WXOnShowResponse> onShowAction;

        private Action onHideAction;

        public void OnShow(Action<WXOnShowResponse> action)
        {
            onShowAction += action;
        }

        public void OffShow(Action<WXOnShowResponse> action = null)
        {
            if (action == null)
            {
                onShowAction = null;
            }
            else
            {
                onShowAction -= action;
            }
        }

        public void OnHide(Action action)
        {
            onHideAction += action;
        }

        public void OffHide(Action action = null)
        {
            if (action == null)
            {
                onHideAction = null;
            }
            else
            {
                onHideAction -= action;
            }
        }

        public WXOnShowResponse GetLaunchOptionsSync()
        {
            string msg = WXGetLaunchOptionsSync();
            var res = JsonUtility.FromJson<WXOnShowResponse>(msg);
            res.referrerInfo = JsonUtility.FromJson<ReferrerInfo>(res.referrerInfoRaw);
            return res;
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

        public void SetUserCloudStorage(SetUserCloudStorageParam param)
        {

            WXSetUserCloudStorage(JsonMapper.ToJson(param.KVDataList), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        public void RemoveUserCloudStorage(RemoveUserCloudStorageParam param)
        {

            WXRemoveUserCloudStorage(JsonMapper.ToJson(param.keyList), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }


        #endregion

        #region 输入法

        Action<string> onKeyboardInputAction;

        Action<string> onKeyboardConfirmAction;

        Action<string> onKeyboardCompleteAction;



        public void UpdateKeyboard(WXUpdateKeyboardParam param)
        {
            WXUpdateKeyboard(param.value, WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        public void ShowKeyboard(WXShowKeyboardParam param)
        {
            WXShowKeyboard(JsonUtility.ToJson(param), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        public void HideKeyboard(WXBaseActionParam<WXTextResponse> param)
        {
            if (param == null)
            {
                param = new WXBaseActionParam<WXTextResponse>();
            }
            WXHideKeyboard(WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        public void OnKeyboardInput(Action<string> action)
        {
            onKeyboardInputAction += action;
        }

        public void OnKeyboardConfirm(Action<string> action)
        {
            onKeyboardConfirmAction += action;
        }

        public void OnKeyboardComplete(Action<string> action)
        {
            onKeyboardCompleteAction += action;
        }

        public void OffKeyboardInput(Action<string> action = null)
        {
            if (action == null)
            {
                onKeyboardInputAction = null;
            }
            else
            {
                onKeyboardInputAction -= action;
            }
        }

        public void OffKeyboardConfirm(Action<string> action = null)
        {
            if (action == null)
            {
                onKeyboardConfirmAction = null;
            }
            else
            {
                onKeyboardConfirmAction -= action;
            }
        }

        public void OffKeyboardComplete(Action<string> action = null)
        {
            if (action == null)
            {
                onKeyboardCompleteAction = null;
            }
            else
            {
                onKeyboardCompleteAction -= action;
            }
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


        #region 触摸事件

        private Action<TouchEvent> onTouchStartAction;

        private Action<TouchEvent> onTouchEndAction;

        private Action<TouchEvent> onTouchMoveAction;

        public void OnTouchStart(Action<TouchEvent> action)
        {
            onTouchStartAction += action;
        }

        public void OnTouchEnd(Action<TouchEvent> action)
        {
            onTouchEndAction += action;
        }

        public void OnTouchMove(Action<TouchEvent> action)
        {
            onTouchMoveAction += action;
        }


        public void OffTouchStart(Action<TouchEvent> action = null)
        {
            if (action == null)
            {
                onTouchStartAction = null;
            }
            else
            {
                onTouchStartAction -= action;
            }
        }

        public void OffTouchEnd(Action<TouchEvent> action = null)
        {
            if (action == null)
            {
                onTouchEndAction = null;
            }
            else
            {
                onTouchEndAction -= action;
            }
        }


        public void OffTouchMove(Action<TouchEvent> action = null)
        {
            if (action == null)
            {
                onTouchMoveAction = null;
            }
            else
            {
                onTouchMoveAction -= action;
            }
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

            #endif
            var rd = UnityEngine.Random.Range(0f, 1000000f);
            var id2 = rd.ToString() + param.src;
            return new WXInnerAudioContext(id2, param);

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

#endif
            var rd = UnityEngine.Random.Range(0f, 1000000f);
            var id2 = rd.ToString() + param.src;
            return new WXVideo(id2, param);
        }
        #endregion

        #region 虚拟支付


        public void RequestMidasPayment(RequestMidasPaymentParam param)
        {
            WXRequestMidasPayment(JsonUtility.ToJson(param), WXLongCallBackHandler.Add(param.success), WXLongCallBackHandler.Add(param.fail), WXLongCallBackHandler.Add(param.complete));
        }

        public void RequestMidasFriendPayment(RequestMidasFriendPaymentParam param)
        {
            WXRequestMidasFriendPayment(JsonUtility.ToJson(param), WXLongCallBackHandler.Add(param.success), WXLongCallBackHandler.Add(param.fail), WXLongCallBackHandler.Add(param.complete));
        }

#endregion

#region 网络

        private Action<NetworkStatus> onNetworkStatusChange;
        public void OnNetworkStatusChange(Action<NetworkStatus> action)
        {
            onNetworkStatusChange += action;
        }

        public void OffNetworkStatusChange(Action<NetworkStatus> action = null) {
            if (action == null)
            {
                onNetworkStatusChange = null;
            }
            else
            {
                onNetworkStatusChange -= action;
            }
        }


        public void GetNetworkType(GetNetworkTypeParam param)
        {
            WXGetNetworkType(WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

#endregion

#region 屏幕
        public void SetKeepScreenOn(SetKeepScreenOnParam param)
        {
            WXSetKeepScreenOn(param.keepScreenOn, WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }
        #endregion

        #region 跳转
        public void ExitMiniProgram(WXBaseActionParam<WXTextResponse> param)
        {
            WXExitMiniProgram(WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
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

        public void LogMem()
        {
            var total = GetTotalMemorySize() / 1024 / 1024;
            var dynamic = WXGetDynamicMemorySize() / 1024 / 1024;
            var staticMem = WXGetStaticMemorySize() / 1024 / 1024;
            Debug.Log(string.Format("WebGL Memory - Total: {0}MB, Dynamic: {1}MB, Static: {2}MB", total, dynamic, staticMem));
        }
        #endregion


        #region 客服消息
        public void OpenCustomerServiceConversation(CustomerServiceConversationParam param = null)
        {
            if (param == null)
            {
                param = new CustomerServiceConversationParam();
            }
            WXOpenCustomerServiceConversation(JsonUtility.ToJson(param),WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }
        #endregion

    }
}

