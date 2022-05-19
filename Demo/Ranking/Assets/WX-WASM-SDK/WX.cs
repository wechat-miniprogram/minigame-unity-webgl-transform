using UnityEngine;
using System;

namespace WeChatWASM
{
    /// <summary>
    /// 微信SDK对外暴露的API
    /// </summary>
    public class WX
    {

        #region env
        /// <summary>
        /// 微信提供了一个用户文件目录给开发者，开发者对这个目录有完全自由的读写权限。通过 WX.env.USER_DATA_PATH 可以获取到这个目录的路径。
        /// </summary>
        public static WXEnv env
        {
            get
            {
                return WXSDKManagerHandler.Env;
            }
        }
        #endregion


        #region cloud
        /// <summary>
        /// 云函数
        /// </summary>
        public static Cloud cloud
        {
            get
            {
                return WXSDKManagerHandler.cloud;
            }
        }
        #endregion



        #region 初始化SDK
        /// <summary>
        /// 初始化SDK
        /// </summary>
        /// <param name="callback">初始化完毕后回调，请回调后再执行游戏主逻辑</param>
        public static void InitSDK(Action<int> callback)
        {

            WXSDKManagerHandler.Instance.InitSDK(callback);

        }
        #endregion

        #region 数据上报

        /// <summary>
        /// 游戏开始运行时上报
        /// </summary>
        public static void ReportGameStart()
        {
            WXSDKManagerHandler.Instance.ReportGameStart();
        }

        /// <summary>
        /// 设置游戏当前阶段，通知插件侧游戏当前所处阶段，便于用户退出或异常发生时，独立域插件能上报游戏当前阶段
        /// </summary>
        /// <param name="stageType">自定义的阶段id，id>=200, id<=10000</param>
        public static void SetGameStage(int stageType)
        {
            WXSDKManagerHandler.Instance.SetGameStage(stageType);
        }

        /// <summary>
        /// 上报当前自定义阶段耗时
        /// </summary>
        /// <param name="costTime">自定义阶段耗时，没有就传0</param>
        /// <param name="extJsonStr">上报的额外信息，json序列化字符串</param>
        public static void ReportGameStageCostTime(int costTime, string extJsonStr)
        {
            WXSDKManagerHandler.Instance.ReportGameStageCostTime(costTime, extJsonStr);
        }

        /// <summary>
        /// 上报当前自定义阶段错误信息
        /// </summary>
        /// <param name="errorType">错误类型, 取值范围0-10000</param>
        /// <param name="errStr">错误信息</param>
        /// <param name="extJsonStr">上报的额外信息，json序列化字符串</param>
        public static void ReportGameStageError(int errorType, string errStr, string extJsonStr)
        {
            WXSDKManagerHandler.Instance.ReportGameStageError(errorType, errStr, extJsonStr);
        }

        /// <summary>
        /// 向日志管理器中写log
        /// 日志管理器文档：https://developers.weixin.qq.com/minigame/dev/api/base/debug/LogManager.html
        /// </summary>
        /// <param name="str">log信息</param>
        public static void WriteLog(string str)
        {
            WXSDKManagerHandler.Instance.WriteLog(str);
        }

        /// <summary>
        /// 向日志管理器中写warn
        /// 日志管理器文档：https://developers.weixin.qq.com/minigame/dev/api/base/debug/LogManager.html
        /// </summary>
        /// <param name="str">warn信息</param>
        public static void WriteWarn(string str)
        {
            WXSDKManagerHandler.Instance.WriteWarn(str);
        }

        public static void HideLoadingPage()
        {
            WXSDKManagerHandler.Instance.HideLoadingPage();
        }

        /// <summary>
        /// 控制预载并发数
        /// </summary>
        /// <param name="count">并发数，取值范围[1, 10]</param>
        public static void PreloadConcurrent(int count)
        {
            WXSDKManagerHandler.Instance.PreloadConcurrent(count);
        }

        /// <summary>
        /// 用于分支相关的UI组件（一般是按钮）相关事件的上报，事件目前有曝光、点击两种
        /// </summary>
        /// <param name="branchId">分支ID，在「小程序管理后台」获取</param>
        /// <param name="branchDim">自定义维度</param>
        /// <param name="eventType">事件类型，1：曝光； 2：点击</param>
        public static void ReportUserBehaviorBranchAnalytics(string branchId, string branchDim, int eventType)
        {
            WXSDKManagerHandler.Instance.ReportUserBehaviorBranchAnalytics(branchId, branchDim, eventType);
        }

        #endregion


        #region 振动

        /*
         * @description 使手机发生较短时间的振动（15 ms）
         * @param succCallback 接口调用成功的回调函数
         * @param failCallback 接口调用失败的回调函数
         * @param compCallback 接口调用结束的回调函数（调用成功、失败都会执行）
         */
        public static void VibrateShort(Action<WXTextResponse> succCallback = null, Action<WXTextResponse> failCallback = null, Action<WXTextResponse> compCallback = null)
        {
            WXSDKManagerHandler.Instance.VibrateShort(succCallback, failCallback, compCallback);
        }


        /*
         * @description 使手机发生较长时间的振动（400 ms)
         * @param succCallback 接口调用成功的回调函数
         * @param failCallback 接口调用失败的回调函数
         * @param compCallback 接口调用结束的回调函数（调用成功、失败都会执行）
         */
        public static void VibrateLong(Action<WXTextResponse> succCallback = null, Action<WXTextResponse> failCallback = null, Action<WXTextResponse> compCallback = null)
        {

            WXSDKManagerHandler.Instance.VibrateLong(succCallback, failCallback, compCallback);
        }

        #endregion


        #region 本地存储
        // 更多关于存储的隔离策略和清理策略说明可以查看这里 https://developers.weixin.qq.com/minigame/dev/guide/base-ability/storage.html

        /*
         * @description 同步设置int型数据存储，
         * @param key 键名
         * @param value 数值
         */
        public static void StorageSetIntSync(string key, int value)
        {
            WXSDKManagerHandler.Instance.StorageSetIntSync(key, value);
        }


        /*
         * @description 同步获取之前设置过的int型数据，
         * @param key 键名
         * @param defaultValue 默认值
         * @returns 异常的和空时候会返回默认值
         */
        public static int StorageGetIntSync(string key, int defaultValue)
        {
            return WXSDKManagerHandler.Instance.StorageGetIntSync(key, defaultValue);
        }



        /*
         * @description 同步设置string型数据存储，
         * @param key 键名
         * @param value 数值
         */
        public static void StorageSetStringSync(string key, string value)
        {
            WXSDKManagerHandler.Instance.StorageSetStringSync(key, value);
        }


        /*
         * @description 同步获取之前设置过的string型数据，
         * @param key 键名
         * @param defaultValue 默认值
         * @returns 异常的和空时候会返回默认值
         */
        public static string StorageGetStringSync(string key, string defaultValue)
        {
            return WXSDKManagerHandler.Instance.StorageGetStringSync(key, defaultValue);
        }


        /*
         * @description 同步设置float型数据存储，
         * @param key 键名
         * @param value 数值
         */
        public static void StorageSetFloatSync(string key, float value)
        {
            WXSDKManagerHandler.Instance.StorageSetFloatSync(key, value);
        }


        /*
         * @description 同步获取之前设置过的float型数据，
         * @param key 键名
         * @param defaultValue 默认值
         * @returns 异常的和空时候会返回默认值
         */
        public static float StorageGetFloatSync(string key, float defaultValue)
        {
            return WXSDKManagerHandler.Instance.StorageGetFloatSync(key, defaultValue);
        }

        /*
         * @description 同步删除所有数据
         */
        public static void StorageDeleteAllSync()
        {
            WXSDKManagerHandler.Instance.StorageDeleteAllSync();
        }



        /*
         * @description 同步删除对应一个key的数据
         * @param key 键名
         */
        public static void StorageDeleteKeySync(string key)
        {
            WXSDKManagerHandler.Instance.StorageDeleteKeySync(key);
        }


        /*
         * @description 判断一个key是否有值
         * @param key 键名
         * @returns true：有，false：没有
         */
        public static bool StorageHasKeySync(string key)
        {
            return WXSDKManagerHandler.Instance.StorageHasKeySync(key);
        }

        #endregion



        #region 登录

        /*
         * @description 调用接口获取登录凭证（code）。通过凭证进而换取用户登录态信息，包括用户的唯一标识（openid）及本次登录的会话密钥（session_key）等。用户数据的加解密通讯需要依赖会话密钥完成。更多使用方法详见 小程序登录。https://developers.weixin.qq.com/minigame/dev/guide/open-ability/login.html
         * @param succCallback 接口调用成功的回调函数
         * @param failCallback 接口调用失败的回调函数
         * @param compCallback 接口调用结束的回调函数（调用成功、失败都会执行）
         */

        public static void Login(Action<WXLoginResponse> succCallback = null, Action<WXLoginResponse> failCallback = null, Action<WXLoginResponse> compCallback = null)
        {
            WXSDKManagerHandler.Instance.Login(succCallback, failCallback, compCallback);

        }

        /*
         * @description 检查登录态是否过期。通过 WXSDKManager.Login 接口获得的用户登录态拥有一定的时效性。用户越久未使用小程序，用户登录态越有可能失效。反之如果用户一直在使用小程序，则用户登录态一直保持有效。具体时效逻辑由微信维护，对开发者透明。开发者只需要调用 WXSDKManager.CheckSession 接口检测当前用户登录态是否有效。

登录态过期后开发者可以再调用 WXSDKManager.Login 获取新的用户登录态。调用成功说明当前 session_key 未过期，调用失败说明 session_key 已过期。
         * @param succCallback 接口调用成功的回调函数
         * @param failCallback 接口调用失败的回调函数
         * @param compCallback 接口调用结束的回调函数（调用成功、失败都会执行）
         */
        public static void CheckSession(Action<WXTextResponse> succCallback = null, Action<WXTextResponse> failCallback = null, Action<WXTextResponse> compCallback = null)
        {
            WXSDKManagerHandler.Instance.CheckSession(succCallback, failCallback, compCallback);
        }


        /*
         * @description 提前向用户发起授权请求。调用后会立刻弹窗询问用户是否同意授权小程序使用某项功能或获取用户的某些数据，但不会实际调用对应接口。如果用户之前已经同意授权，则不会出现弹窗，直接返回成功。
         * @param scope 需要获取权限的 scope, 获取用户信息用 “scope.userInfo”，详见 https://developers.weixin.qq.com/minigame/dev/guide/framework/authorize.html#scope-%E5%88%97%E8%A1%A8
         * @param succCallback 接口调用成功的回调函数
         * @param failCallback 接口调用失败的回调函数
         * @param compCallback 接口调用结束的回调函数（调用成功、失败都会执行）
         */
        public static void Authorize(string scope, Action<WXTextResponse> succCallback = null, Action<WXTextResponse> failCallback = null, Action<WXTextResponse> compCallback = null)
        {
            WXSDKManagerHandler.Instance.Authorize(scope, succCallback, failCallback, compCallback);
        }


        #endregion


        #region 用户信息

        /// <summary>
        /// 获取用户信息。调用前需要调用 WX.Authorize 用户授权 scope.userInfo。详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/user-info/wx.getUserInfo.html
        /// </summary>
        /// <param name="withCredentials">是否带上登录态信息。当 withCredentials 为 true 时，要求此前有调用过 wx.login 且登录态尚未过期，此时返回的数据会包含 encryptedData, iv 等敏感信息；当 withCredentials 为 false 时，不要求有登录态，返回的数据不包含 encryptedData, iv 等敏感信息。</param>
        /// <param name="lang">显示用户信息的语言 可取（en,zh_CN,zh_TW）的一个</param>
        /// <param name="succCallback">接口调用成功的回调函数</param>
        /// <param name="failCallback">接口调用失败的回调函数</param>
        /// <param name="compCallback">接口调用结束的回调函数（调用成功、失败都会执行）</param>
        public static void GetUserInfo(bool withCredentials, string lang, Action<WXUserInfoResponse> succCallback, Action<WXUserInfoResponse> failCallback = null, Action<WXUserInfoResponse> compCallback = null)
        {
            WXSDKManagerHandler.Instance.GetUserInfo(withCredentials, lang, succCallback, failCallback, compCallback);
        }


        /// <summary>
        /// 创建用户信息按钮,这里是在屏幕上额外创建一块透明区域，其为点击区域，用户点击后，就会请求用户授权获取用户信息。游戏中的该区域最好为按钮区域，这样就能看起来用户是在点击游戏中的按钮
        /// </summary>
        /// <param name="x">x 左上角横坐标（以屏幕左上角为0）</param>
        /// <param name="y">y 左上角纵坐标（以屏幕左上角为0）</param>
        /// <param name="width">区域宽度</param>
        /// <param name="height">区域高度</param>
        /// <param name="lang">显示用户信息的语言 可取（en,zh_CN,zh_TW）的一个</param>
        /// <param name="withCredentials">是否带上登录态信息。当 withCredentials 为 true 时，要求此前有调用过 wx.login 且登录态尚未过期，此时返回的数据会包含 encryptedData, iv 等敏感信息；当 withCredentials 为 false 时，不要求有登录态，返回的数据不包含 encryptedData, iv 等敏感信息。</param>
        /// <returns>返回对象用于后续控制该透明区域的点击，展示和隐藏等行为</returns>
        public static WXUserInfoButton CreateUserInfoButton(int x, int y, int width, int height, string lang, bool withCredentials)
        {
            return WXSDKManagerHandler.Instance.CreateUserInfoButton(x, y, width, height, lang, withCredentials);
        }

        #endregion


        #region 系统

        /// <summary>
        /// 获取微信客户端语言
        /// </summary>
        /// <returns>返回值同Application.systemLanguage.ToString(), 但是因为ios中 Application.systemLanguage.ToString()返回数值类型的字符串，所以增加一个返回字母类型字符串的函数，而且该值跟随微信语言设置</returns>
        public static string GetSystemLanguage()
        {
            return WXSDKManagerHandler.Instance.GetSystemLanguage();
        }



        /// <summary>
        /// 异步获取系统信息,Unity的Application.platform返回的是WebGLPlayer区分不了平台，可以通过这个api来区分平台
        /// </summary>
        /// <param name="param">回调函数，回调参数可参考 https://developers.weixin.qq.com/minigame/dev/api/base/system/system-info/wx.getSystemInfo.html </param>
        public static void GetSystemInfo(WXBaseActionParam<WXSystemInfo> param)
        {
            WXSDKManagerHandler.Instance.GetSystemInfo(param);
        }

        /// <summary>
        /// 同步版本获取系统信息,Unity的Application.platform返回的是WebGLPlayer区分不了平台，可以通过这个api来区分平台
        /// </summary>
        /// <param name="param">回调函数，回调参数可参考 https://developers.weixin.qq.com/minigame/dev/api/base/system/system-info/wx.getSystemInfo.html </param>
        ///
        public static WXSystemInfo GetSystemInfoSync()
        {
            return WXSDKManagerHandler.Instance.GetSystemInfoSync();
        }

        /// <summary>
        /// 监听音频因为受到系统占用而被中断开始事件。以下场景会触发此事件：闹钟、电话、FaceTime 通话、微信语音聊天、微信视频聊天。此事件触发后，小程序内所有音频会暂停。
        /// </summary>
        /// <param name="action">音频因为受到系统占用而被中断开始事件的回调函数</param>
        public static void OnAudioInterruptionBegin(Action action)
        {
            WXSDKManagerHandler.Instance.OnAudioInterruptionBegin(action);
        }

        /// <summary>
        /// 监听音频中断结束事件。在收到 onAudioInterruptionBegin 事件之后，小程序内所有音频会暂停，收到此事件之后才可再次播放成功
        /// </summary>
        /// <param name="action">音频中断结束事件的回调函数</param>
        public static void OnAudioInterruptionEnd(Action action)
        {
            WXSDKManagerHandler.Instance.OnAudioInterruptionEnd(action);
        }

        /// <summary>
        /// 取消监听音频中断结束事件
        /// </summary>
        /// <param name="action">音频中断结束事件的回调函数</param>
        public static void OffAudioInterruptionEnd(Action action = null)
        {
            WXSDKManagerHandler.Instance.OffAudioInterruptionEnd(action);

        }

        /// <summary>
        /// 取消监听音频因为受到系统占用而被中断开始事件
        /// </summary>
        /// <param name="action">音频因为受到系统占用而被中断开始事件的回调函数</param>
        public static void OffAudioInterruptionBegin(Action action = null)
        {
            WXSDKManagerHandler.Instance.OffAudioInterruptionBegin(action);
        }


        #endregion


        #region 分享转发

        /// <summary>
        /// 更新转发属性
        /// </summary>
        /// <param name="param">param各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.updateShareMenu.html  </param>
        public static void UpdateShareMenu(WXUpdateShareMenuParam param = null)
        {
            WXSDKManagerHandler.Instance.UpdateShareMenu(param);
        }

        /// <summary>
        /// 显示当前页面的转发按钮
        /// </summary>
        /// <param name="param">param各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.showShareMenu.html  </param>
        public static void ShowShareMenu(WXShowShareMenuParam param = null)
        {
            WXSDKManagerHandler.Instance.ShowShareMenu(param);
        }

        /// <summary>
        /// 隐藏当前页面的转发按钮
        /// </summary>
        /// <param name="param">param各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.hideShareMenu.html </param>
        public static void HideShareMenu(WXHideShareMenuParam param = null)
        {
            WXSDKManagerHandler.Instance.HideShareMenu(param);
        }

        /// <summary>
        /// 设置 ShareMessageToFriend 接口 query 字段的值
        /// </summary>
        /// <param name="shareMessageToFriendScene">需要传递的代表场景的数字，需要在 0 - 50 之间。 1-50都是开发者自定义场景值，用法可以自行决定的 。</param>
        /// <returns>是否设置成功</returns>
        public static bool SetMessageToFriendQuery(int shareMessageToFriendScene)
        {
            return WXSDKManagerHandler.Instance.SetMessageToFriendQuery(shareMessageToFriendScene);
        }

        /// <summary>
        /// 主动拉起转发，进入选择通讯录界面。
        /// </summary>
        /// <param name="param">param各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.shareAppMessage.html </param>
        public static void ShareAppMessage(WXShareAppMessageParam param = null)
        {
            WXSDKManagerHandler.Instance.ShareAppMessage(param);
        }

        /// <summary>
        /// 监听用户点击右上角菜单的「转发」按钮时触发的事件
        /// </summary>
        /// <param name="defaultParam">默认的设置内容</param>
        /// <param name="action">用户点击右上角菜单的「转发」按钮时触发的事件的回调函数，请在回调后三秒内，触发 Action<WXShareAppMessageParam>返回设置的内容,否则会使用 defaultParam</param>
        public static void OnShareAppMessage(WXShareAppMessageParam defaultParam, Action<Action<WXShareAppMessageParam>> action = null)
        {
            WXSDKManagerHandler.Instance.OnShareAppMessage(defaultParam, action);
        }


        /// <summary>
        /// 取消监听用户点击右上角菜单的「分享到朋友圈」按钮时触发的事件
        /// </summary>
        public static void OffShareAppMessage()
        {
            WXSDKManagerHandler.Instance.OffShareAppMessage();
        }


        /// <summary>
        /// 监听用户点击右上角菜单的「分享到朋友圈」按钮时触发的事件。本接口为 Beta 版本，暂只在 Android 平台支持。
        /// </summary>
        /// <param name="param"设置详见 https://developers.weixin.qq.com/minigame/dev/api/share/wx.onShareTimeline.html></param>
        /// <param name="action">用户点击右上角菜单的「分享到朋友圈」按钮时触发的事件的回调函数</param>
        public static void OnShareTimeline(WXShareTimelineParam param, Action action = null)
        {
            WXSDKManagerHandler.Instance.OnShareTimeline(param, action);
        }


        /// <summary>
        /// 取消监听用户点击右上角菜单的「分享到朋友圈」按钮时触发的事件
        /// </summary>
        public static void OffShareTimeline()
        {
            WXSDKManagerHandler.Instance.OffShareTimeline();
        }


        /// <summary>
        /// 监听用户点击菜单「收藏」按钮时触发的事件（安卓7.0.15起支持，iOS 暂不支持）
        /// </summary>
        /// <param name="param">详见 https://developers.weixin.qq.com/minigame/dev/api/share/wx.onAddToFavorites.html</param>
        /// <param name="action">用户点击菜单「收藏」按钮时触发的事件的回调函数</param>
        public static void OnAddToFavorites(WXAddToFavoritesParam param, Action action = null)
        {
            WXSDKManagerHandler.Instance.OnAddToFavorites(param, action);
        }


        /// <summary>
        /// 取消监听用户点击菜单「收藏」按钮时触发的事件
        /// </summary>
        public static void OffAddToFavorites()
        {
            WXSDKManagerHandler.Instance.OffAddToFavorites();
        }


        /// <summary>
        /// 获取转发详细信息
        /// </summary>
        /// <param name="param">设置详见 https://developers.weixin.qq.com/minigame/dev/api/share/wx.getShareInfo.html </param>
        public static void GetShareInfo(WXGetShareInfoParam param)
        {
            WXSDKManagerHandler.Instance.GetShareInfo(param);
        }

        /// <summary>
        /// 验证私密消息。用法详情见 小程序私密消息使用指南 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/private-message.html
        /// </summary>
        /// <param name="param">设置详见 https://developers.weixin.qq.com/minigame/dev/api/share/wx.authPrivateMessage.html</param>
        public static void AuthPrivateMessage(WXAuthPrivateMessageParam param)
        {
            WXSDKManagerHandler.Instance.AuthPrivateMessage(param);
        }

        #endregion

        #region 广告

        /// <summary>
        /// banner 广告组件。banner 广告组件是一个原生组件，层级比普通组件高。banner 广告组件默认是隐藏的，需要调用 BannerAd.show() 将其显示。banner 广告会根据开发者设置的宽度进行等比缩放，缩放后的尺寸将通过 BannerAd.onResize() 事件中提供。 使用可参考 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/ad/banner-ad.html
        /// </summary>
        /// <param name="param">param各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createBannerAd.html </param>
        /// <returns>对banner广告做操作的对象，详见 https://developers.weixin.qq.com/minigame/dev/api/ad/BannerAd.html </returns>
        /// <example>
        /// // 底部banner广告示例
        ///        var sysInfo = WX.GetSystemInfoSync();
        ///         var banner = WX.CreateBannerAd(new WXCreateBannerAdParam()
        ///         {
        ///             adUnitId = "adunit-2e20328227ca771b",
        ///            adIntervals = 30,
        ///             style = new Style()
        ///             {
        ///                 left = 0,
        ///                 top = sysInfo.windowHeight - 100,
        ///                 width = sysInfo.windowWidth,
        ///                 height = 100
        ///             }
        ///        });
        ///         banner.OnError((WXADErrorResponse res)=>
        ///         {
        ///             Debug.Log("bannerad error response");
        ///         });
        ///         banner.OnLoad(()=> {
        ///             banner.Show();
        ///         });
        ///     banner.OnResize((WXADResizeResponse res) =>
        ///     {
        ///         //拉取的广告可能跟设置的不一样，需要动态调整位置
        ///         banner.style.top = sysInfo.windowHeight - res.height;
        ///     });
        /// </example>
        public static WXBannerAd CreateBannerAd(WXCreateBannerAdParam param)
        {
            return WXSDKManagerHandler.Instance.CreateBannerAd(param);
        }

        /// <summary>
        /// 这个方法提供一个固定在底部,且固定高度，且水平居中的bannerAd,此方法不需要再手动监听OnResize事件调整位置了
        /// </summary>
        /// <param name="adUnitId">广告单元 id</param>
        /// <param name="adIntervals">广告自动刷新的间隔时间，单位为秒，参数值必须大于等于30（该参数不传入时 Banner 广告不会自动刷新）</param>
        /// <param name="height">要固定的高度</param>
        /// <returns>对banner广告做操作的对象，详见 https://developers.weixin.qq.com/minigame/dev/api/ad/BannerAd.html </returns>
        public static WXBannerAd CreateFixedBottomMiddleBannerAd(string adUnitId, int adIntervals, int height)
        {
            return WXSDKManagerHandler.Instance.CreateFixedBottomMiddleBannerAd(adUnitId, adIntervals, height);
        }


        /// <summary>
        /// 激励视频广告 详细参见 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/ad/rewarded-video-ad.html
        /// </summary>
        /// <param name="param"></param>
        /// <returns>广告操作对象，https://developers.weixin.qq.com/minigame/dev/api/ad/RewardedVideoAd.html </returns>
        public static WXRewardedVideoAd CreateRewardedVideoAd(WXCreateRewardedVideoAdParam param)
        {
            return WXSDKManagerHandler.Instance.CreateRewardedVideoAd(param);
        }

        /// <summary>
        /// 创建插屏广告组件 详细参见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createInterstitialAd.html
        /// </summary>
        /// <param name="param"></param>
        /// <returns>广告操作对象，https://developers.weixin.qq.com/minigame/dev/api/ad/InterstitialAd.html </returns>
        public static WXInterstitialAd CreateInterstitialAd(WXCreateInterstitialAdParam param)
        {
            return WXSDKManagerHandler.Instance.CreateInterstitialAd(param);
        }



        /// <summary>
        /// Grid 广告 详细参见 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/ad/grid-ad.html
        /// </summary>
        /// <param name="param">详细参见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createGridAd.html </param>
        /// <returns>广告操作对象，https://developers.weixin.qq.com/minigame/dev/api/ad/GridAd.html </returns>
        public static WXGridAd CreateGridAd(WXCreateGridAdParam param)
        {
            return WXSDKManagerHandler.Instance.CreateGridAd(param);
        }

        /// <summary>
        /// 创建原生模板广告组件 详细参见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createCustomAd.html
        /// </summary>
        /// <param name="param"></param>
        /// <returns>广告操作对象，https://developers.weixin.qq.com/minigame/dev/api/ad/CustomAd.html </returns>
        public static WXCustomAd CreateCustomAd(WXCreateCustomAdParam param)
        {
            return WXSDKManagerHandler.Instance.CreateCustomAd(param);
        }


        #endregion




        #region 生命周期
        /// <summary>
        /// 监听小游戏回到前台的事件
        /// </summary>
        /// <param name="action">小游戏回到前台的事件的回调函数</param>
        public static void OnShow(Action<WXOnShowResponse> action)
        {
            WXSDKManagerHandler.Instance.OnShow(action);
        }


        /// <summary>
        /// 取消监听小游戏回到前台的事件
        /// </summary>
        /// <param name="action">小游戏回到前台的事件的回调函数,为空的话会取消之前添加的全部监听</param>
        public static void OffShow(Action<WXOnShowResponse> action = null)
        {
            WXSDKManagerHandler.Instance.OffShow(action);
        }

        /// <summary>
        /// 监听小游戏隐藏到后台事件。锁屏、按 HOME 键退到桌面、显示在聊天顶部等操作会触发此事件。
        /// </summary>
        /// <param name="action">小游戏隐藏到后台事件的回调函数</param>
        public static void OnHide(Action action)
        {
            WXSDKManagerHandler.Instance.OnHide(action);
        }


        /// <summary>
        /// 取消监听小游戏隐藏到后台事件
        /// </summary>
        /// <param name="action">小游戏隐藏到后台事件的回调函数,为空的话会取消之前添加的全部监听</param>
        public static void OffHide(Action action = null)
        {
            WXSDKManagerHandler.Instance.OffHide(action);
        }


        /// <summary>
        /// 获取小游戏冷启动时的参数。热启动参数通过 OnShow 接口获取。
        /// </summary>
        /// <returns>返回数据详见，https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.getLaunchOptionsSync.html </returns>
        public static WXOnShowResponse GetLaunchOptionsSync()
        {
            return WXSDKManagerHandler.Instance.GetLaunchOptionsSync();
        }
        #endregion


        #region 文件
        /// <summary>
        /// 获取全局唯一的文件管理器 详见 https://developers.weixin.qq.com/minigame/dev/guide/base-ability/file-system.html
        /// </summary>
        /// <returns>返回数据详见，https://developers.weixin.qq.com/minigame/dev/api/file/wx.getFileSystemManager.html </returns>
        /// <example>
        /// // 在本地用户文件目录下创建一个文件 share.jpg,文件名可以自己随便取，写入内容为图片二进制内容 bytes
        ///  var fs = WX.GetFileSystemManager();
        ///  fs.WriteFileSync(WX.env.USER_DATA_PATH+"/share.jpg", bytes);
        /// </example>
        public static WXFileSystemManager GetFileSystemManager()
        {
            return new WXFileSystemManager();
        }
        #endregion


        #region 开放数据域，关系链，排行榜这一类

        /// <summary>
        /// 获取开放数据域，关系链相关可以参看 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/open-data.html
        /// </summary>
        /// <returns>开放数据域对象</returns>
        public static WXOpenDataContext GetOpenDataContext()
        {
            return new WXOpenDataContext();
        }


        /// <summary>
        /// 展示开放数据域
        /// </summary>
        /// <param name="texture">用来占位的纹理，前端绘制的开放域数据会自动替换这一纹理，因为客户顿纹理映射倒立问题，这一纹理请设置rotationX为180才能正常展示。</param>
        /// <param name="x">占位对应屏幕左上角横坐标</param>
        /// <param name="y">占位对应屏幕左上角纵坐标，注意左上角为（0，0）</param>
        /// <param name="width">占位对应的宽度</param>
        /// <param name="height">占位对应的高度</param>
        public static void ShowOpenData(Texture texture, int x, int y, int width, int height)
        {
            WXSDKManagerHandler.Instance.ShowOpenData(texture, x, y, width, height);
        }

        /// <summary>
        /// 关闭开放数据域
        /// </summary>
        public static void HideOpenData()
        {
            WXSDKManagerHandler.Instance.HideOpenData();
        }

        /// <summary>
        /// 对用户托管数据进行写数据操作。允许同时写多组 KV 数据。详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.setUserCloudStorage.html
        /// </summary>
        /// <param name="param"></param>
        public static void SetUserCloudStorage(SetUserCloudStorageParam param)
        {
            WXSDKManagerHandler.Instance.SetUserCloudStorage(param);
        }

        /// <summary>
        /// 删除用户托管数据当中对应 key 的数据。 详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.removeUserCloudStorage.html
        /// </summary>
        /// <param name="param"></param>
        public static void RemoveUserCloudStorage(RemoveUserCloudStorageParam param)
        {
            WXSDKManagerHandler.Instance.RemoveUserCloudStorage(param);
        }

        #endregion

        #region 输入法

        /// <summary>
        /// 更新键盘输入框内容。只有当键盘处于拉起状态时才会产生效果,https://developers.weixin.qq.com/minigame/dev/api/ui/keyboard/wx.updateKeyboard.html
        /// </summary>
        public static void UpdateKeyboard(WXUpdateKeyboardParam param)
        {
            WXSDKManagerHandler.Instance.UpdateKeyboard(param);
        }

        /// <summary>
        /// 显示键盘,https://developers.weixin.qq.com/minigame/dev/api/ui/keyboard/wx.showKeyboard.html
        /// </summary>
        public static void ShowKeyboard(WXShowKeyboardParam param)
        {
            WXSDKManagerHandler.Instance.ShowKeyboard(param);
        }

        /// <summary>
        /// 隐藏键盘,https://developers.weixin.qq.com/minigame/dev/api/ui/keyboard/wx.hideKeyboard.html
        /// </summary>
        public static void HideKeyboard(WXBaseActionParam<WXTextResponse> param = null)
        {
            WXSDKManagerHandler.Instance.HideKeyboard(param);
        }

        /// <summary>
        /// 监听键盘输入事件
        /// </summary>
        /// <param name="action"></param>
        public static void OnKeyboardInput(Action<string> action)
        {
            WXSDKManagerHandler.Instance.OnKeyboardInput(action);
        }

        /// <summary>
        /// 监听用户点击键盘 Confirm 按钮时的事件
        /// </summary>
        /// <param name="action"></param>
        public static void OnKeyboardConfirm(Action<string> action)
        {
            WXSDKManagerHandler.Instance.OnKeyboardConfirm(action);
        }

        /// <summary>
        /// 监听监听键盘收起的事件
        /// </summary>
        /// <param name="action"></param>
        public static void OnKeyboardComplete(Action<string> action)
        {
            WXSDKManagerHandler.Instance.OnKeyboardComplete(action);
        }

        /// <summary>
        /// 取消监听键盘输入事件
        /// </summary>
        /// <param name="action"></param>
        public static void OffKeyboardInput(Action<string> action = null)
        {
            WXSDKManagerHandler.Instance.OffKeyboardInput(action);
        }

        /// <summary>
        /// 取消监听用户点击键盘 Confirm 按钮时的事件
        /// </summary>
        /// <param name="action"></param>
        public static void OffKeyboardConfirm(Action<string> action = null)
        {
            WXSDKManagerHandler.Instance.OffKeyboardConfirm(action);
        }

        /// <summary>
        /// 取消监听监听键盘收起的事件
        /// </summary>
        /// <param name="action"></param>
        public static void OffKeyboardComplete(Action<string> action = null)
        {
            WXSDKManagerHandler.Instance.OffKeyboardComplete(action);
        }

        #endregion




        #region 触摸事件
        /// <summary>
        /// 监听开始触摸事件
        /// </summary>
        /// <param name="action">开始触摸事件的回调函数</param>
        public static void OnTouchStart(Action<TouchEvent> action)
        {
            WXSDKManagerHandler.Instance.OnTouchStart(action);
        }

        /// <summary>
        /// 监听触摸结束事件
        /// </summary>
        /// <param name="action">触摸结束事件的回调函数</param>
        public static void OnTouchEnd(Action<TouchEvent> action)
        {
            WXSDKManagerHandler.Instance.OnTouchEnd(action);
        }

        /// <summary>
        /// 监听触点移动事件
        /// </summary>
        /// <param name="action">触点移动事件的回调函数</param>
        public static void OnTouchMove(Action<TouchEvent> action)
        {
            WXSDKManagerHandler.Instance.OnTouchMove(action);
        }


        /// <summary>
        /// 取消监听开始触摸事件
        /// </summary>
        /// <param name="action">开始触摸事件的回调函数</param>
        public static void OffTouchStart(Action<TouchEvent> action = null)
        {
            WXSDKManagerHandler.Instance.OffTouchStart(action);
        }

        /// <summary>
        /// 取消监听触摸结束事件
        /// </summary>
        /// <param name="action">触摸结束事件的回调函数</param>
        public static void OffTouchEnd(Action<TouchEvent> action = null)
        {
            WXSDKManagerHandler.Instance.OffTouchEnd(action);
        }

        /// <summary>
        /// 取消监听触点移动事件
        /// </summary>
        /// <param name="action">触点移动事件的回调函数</param>
        public static void OffTouchMove(Action<TouchEvent> action = null)
        {
            WXSDKManagerHandler.Instance.OffTouchMove(action);
        }

        #endregion

        #region 音频
        /// <summary>
        /// InnerAudioContext 实例，可通过 WX.CreateInnerAudioContext 接口获取实例。注意，音频播放过程中，可能被系统中断，可通过 WX.OnAudioInterruptionBegin、WX.OnAudioInterruptionEnd事件来处理这种情况。详见：https://developers.weixin.qq.com/minigame/dev/api/media/audio/InnerAudioContext.html
        /// </summary>
        /// <example>
        //var music = WX.CreateInnerAudioContext(new InnerAudioContextParam() {
        //    src = "Assets/Audio/Chill_1.wav",
        //    needDownload = true //表示等下载完之后再播放，便于后续复用，无延迟
        //});
        //music.OnCanplay(() =>
        //{
        //    Debug.Log("OnCanplay");
        //    music.Play();
        //});
        /// </example>
        public static WXInnerAudioContext CreateInnerAudioContext(InnerAudioContextParam param = null)
        {
            return WXSDKManagerHandler.Instance.CreateInnerAudioContext(param);
        }

        /// <summary>
        /// 音频为网络请求，可能会有延迟，所以可以先调用这个接口预先下载音频缓存到本地，避免延迟
        /// </summary>
        /// <param name="pathList">音频的地址数组,如 { "Assets/Audio/0.wav", "Assets/Audio/1.wav" } </param>
        /// <param name="action">全部音频下载完成后回调，返回码为0表示下载完成</param>
        ///<example>
        ///     string[] a = { "Assets/Audio/0.wav", "Assets/Audio/1.wav" };
        //        WX.PreDownloadAudios(a, (code) =>
        //            {
        //                Debug.Log("Downloaded" + code);
        //                if (code == 0)
        //                {
        //                    var music0 = WX.CreateInnerAudioContext(new InnerAudioContextParam()
        //                    {
        //                        src = "Assets/Audio/0.wav"
        //                    });
        //        music0.Play();

        //                    var music1 = WX.CreateInnerAudioContext(new InnerAudioContextParam()
        //                    {
        //                        src = "Assets/Audio/1.wav"
        //                    });
        //        music1.Play();
        //                }
        //});
        /// </example>
        public static void PreDownloadAudios(string[] pathList, Action<int> action)
        {
            WXSDKManagerHandler.Instance.PreDownloadAudios(pathList, action);
        }
        #endregion

        /// <summary>
        /// 创建视频，详见 https://developers.weixin.qq.com/minigame/dev/api/media/video/wx.createVideo.html
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        #region 视频
        public static WXVideo CreateVideo(WXCreateVideoParam param) {
            return WXSDKManagerHandler.Instance.CreateVideo(param);
        }


        /// <summary>
        /// 适合几秒d短音频播放
        /// </summary>
        public static WXShortAudioPlayer ShortAudioPlayer = WXShortAudioPlayer.Instance;

        #endregion


        #region 虚拟支付

        /// <summary>
        /// 发起米大师支付, 详见 https://developers.weixin.qq.com/minigame/dev/api/midas-payment/wx.requestMidasPayment.html
        /// </summary>
        /// <param name="param"></param>
        public static void RequestMidasPayment(RequestMidasPaymentParam param) {
            WXSDKManagerHandler.Instance.RequestMidasPayment(param);
        }


        /// <summary>
        /// 发起米大师朋友礼物索要, 详见 https://developers.weixin.qq.com/minigame/dev/api/midas-payment/wx.requestMidasFriendPayment.html
        /// <param name="param"></param>
        public static void RequestMidasFriendPayment(RequestMidasFriendPaymentParam param)
        {
            WXSDKManagerHandler.Instance.RequestMidasFriendPayment(param);
        }

        #endregion


        #region 网络
        /// <summary>
        /// 监听网络状态变化事件,详见 https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.onNetworkStatusChange.html
        /// </summary>
        /// <param name="action"></param>
        /// <example>
        /// WX.OnNetworkStatusChange((status)=> {
        ///     Debug.Log("isCon:"+status.isConnected);
        ///     Debug.Log("networkType:" + status.networkType);
        /// });
        /// </example>
        public static void OnNetworkStatusChange(Action<NetworkStatus> action) {
            WXSDKManagerHandler.Instance.OnNetworkStatusChange(action);
        }

        /// <summary>
        /// 取消监听网络状态变化事件，参数为空，则取消所有的事件监听。,详见 https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.offNetworkStatusChange.html
        /// </summary>
        /// <param name="action"></param>
        public static void OffNetworkStatusChange(Action<NetworkStatus> action = null)
        {
            WXSDKManagerHandler.Instance.OffNetworkStatusChange(action);
        }

        /// <summary>
        /// 获取网络类型, 详见 https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.getNetworkType.html
        /// </summary>
        /// <example>
        /// WX.GetNetworkType(new GetNetworkTypeParam()
        /// {
        ///      success = (res) =>
        ///      {
        ///         Debug.Log("GetNetworkType:" + res.networkType);
        ///      },
        ///      complete = (res) => {
        ///         Debug.Log("GetNetworkType complete:" + res.errMsg);
        ///      }
        ///  });
        /// </example>
        public static void GetNetworkType(GetNetworkTypeParam param) {
            WXSDKManagerHandler.Instance.GetNetworkType(param);
        }
        #endregion

        #region 屏幕
        /// <summary>
        /// 设置是否保持常亮状态。仅在当前小程序生效，离开小程序后设置失效。详见 https://developers.weixin.qq.com/minigame/dev/api/device/screen/wx.setKeepScreenOn.html
        /// </summary>
        /// <example>
        ///  WX.SetKeepScreenOn(new SetKeepScreenOnParam()
        ///  {
        ///     keepScreenOn = true,
        ///     success = (res) => {
        ///         Debug.Log("SetKeepScreenOn success:"+res.errMsg);
        ///     }
        ///  });
        /// </example>>
        public static void SetKeepScreenOn(SetKeepScreenOnParam param) {
            WXSDKManagerHandler.Instance.SetKeepScreenOn(param);
        }
        #endregion


        #region 跳转
        /// <summary>
        /// 跳转小程序，详见 https://developers.weixin.qq.com/minigame/dev/api/navigate/wx.navigateToMiniProgram.html
        /// </summary>
        /// <param name="param"></param>
        public static void NavigateToMiniProgram(WXNavigateToMiniProgramParam param)
        {
            WXSDKManagerHandler.Instance.NavigateToMiniProgram(param);
        }
        /// <summary>
        /// 退出当前小程序。必须有点击行为才能调用成功。详见 https://developers.weixin.qq.com/minigame/dev/api/navigate/wx.exitMiniProgram.html
        /// </summary>
        /// <param name="param"></param>
        public static void ExitMiniProgram(WXBaseActionParam<WXTextResponse> param) {
            WXSDKManagerHandler.Instance.ExitMiniProgram(param);
        }
        #endregion

        #region 性能
        /// <summary>
        /// 获取当前UnityHeap总内存(峰值)
        /// </summary>
        public static uint GetTotalMemorySize()
        {
            return WXSDKManagerHandler.Instance.GetTotalMemorySize();
        }
        /// <summary>
        /// 获取当前UnityHeap Stack大小
        /// </summary>
        public static uint GetTotalStackSize()
        {
            return WXSDKManagerHandler.Instance.GetTotalStackSize();
        }
        /// <summary>
        /// 获取当前UnityHeap静态内存
        /// </summary>
        public static uint GetStaticMemorySize()
        {
            return WXSDKManagerHandler.Instance.GetStaticMemorySize();
        }
        /// <summary>
        /// 获取当前UnityHeap动态内存
        /// </summary>
        public static uint GetDynamicMemorySize()
        {
            return WXSDKManagerHandler.Instance.GetDynamicMemorySize();
        }
        /// <summary>
        /// 打印UnityHeap内存
        /// </summary>
        public static void LogUnityHeapMem()
        {
            WXSDKManagerHandler.Instance.LogUnityHeapMem();
        }        
        #endregion


        #region 客服消息
        /// <summary>
        /// 进入客服会话。要求在用户发生过至少一次 touch 事件后才能调用。后台接入方式与小程序一致，详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/customer-message/wx.openCustomerServiceConversation.html
        /// </summary>
        /// <param name="param"></param>
        public static void OpenCustomerServiceConversation(CustomerServiceConversationParam param = null) {
            WXSDKManagerHandler.Instance.OpenCustomerServiceConversation(param);
        }
        #endregion


        #region 调试
        /// <summary>
        /// 写 debug 日志，同 https://developers.weixin.qq.com/minigame/dev/api/base/debug/LogManager.debug.html
        /// </summary>
        /// <param name="str"></param>
        public static void LogManagerDebug(string str) {
            WXSDKManagerHandler.Instance.LogManagerDebug(str);
        }

        /// <summary>
        /// 写 info 日志，同 https://developers.weixin.qq.com/minigame/dev/api/base/debug/LogManager.info.html
        /// </summary>
        /// <param name="str"></param>
        public static void LogManagerInfo(string str)
        {
            WXSDKManagerHandler.Instance.LogManagerInfo(str);
        }


        /// <summary>
        /// 写 log 日志，同 https://developers.weixin.qq.com/minigame/dev/api/base/debug/LogManager.log.html
        /// </summary>
        /// <param name="str"></param>
        public static void LogManagerLog(string str)
        {
            WXSDKManagerHandler.Instance.LogManagerLog(str);
        }


        /// <summary>
        /// 写 warn 日志，同 https://developers.weixin.qq.com/minigame/dev/api/base/debug/LogManager.warn.html
        /// </summary>
        /// <param name="str"></param>
        public static void LogManagerWarn(string str)
        {
            WXSDKManagerHandler.Instance.LogManagerWarn(str);
        }

        #endregion

        #region 云测试
        /// <summary>
		/// 是否小游戏云测试环境
		/// </summary>
        public static bool IsCloudTest()
        {
            return WXSDKManagerHandler.Instance.IsCloudTest();
        }
        #endregion

        public static void UncaughtException()
        {
            WXSDKManagerHandler.Instance.UncaughtException();
        }


        #region 剪切板
        /// <summary>
        /// 设置系统剪贴板的内容。调用成功后，会弹出 toast 提示"内容已复制"，持续 1.5s ，详见 https://developers.weixin.qq.com/minigame/dev/api/device/clipboard/wx.setClipboardData.html
        /// </summary>
        /// <param name="param"></param>
        public static void SetClipboardData(WXClipboardParam param) {
            WXSDKManagerHandler.Instance.SetClipboardData(param);
        }

        /// <summary>
        /// 获取系统剪贴板的内容, 详见 https://developers.weixin.qq.com/minigame/dev/api/device/clipboard/wx.getClipboardData.html
        /// </summary>
        /// <param name="param"></param>
        public static void GetClipboardData(WXBaseActionParam<WXClipboardResponse> param)
        {
            WXSDKManagerHandler.Instance.GetClipboardData(param);
        }
        #endregion

        #region 交互
        /// <summary>
        /// 显示消息提示框,详见  https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showToast.html
        /// </summary>
        /// <param name="param"></param>
        public static void ShowToast(WXShowToastParam param) {
            WXSDKManagerHandler.Instance.ShowToast(param);
        }

        /// <summary>
        /// 隐藏消息提示框,详见  https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showToast.html
        /// </summary>
        /// <param name="param"></param>
        public static void HideToast(WXBaseActionParam<WXTextResponse> param)
        {
            WXSDKManagerHandler.Instance.HideToast(param);
        }


        /// <summary>
        /// 显示模态对话框，详见 https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showModal.html
        /// </summary>
        /// <param name="param"></param>
        public static void ShowModal(WXShowModalParam param)
        {
            WXSDKManagerHandler.Instance.ShowModal(param);
        }

        /// <summary>
        /// 显示 loading 提示框。需主动调用 wx.hideLoading 才能关闭提示框,详见 https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.showLoading.html
        /// </summary>
        /// <param name="param"></param>
        public static void ShowLoading(WXShowLoadingParam param) {
            WXSDKManagerHandler.Instance.ShowLoading(param);
        }

        /// <summary>
        /// 隐藏 loading 提示框,详见  https://developers.weixin.qq.com/minigame/dev/api/ui/interaction/wx.hideLoading.html
        /// </summary>
        /// <param name="param"></param>
        public static void HideLoading(WXBaseActionParam<WXTextResponse> param)
        {
            WXSDKManagerHandler.Instance.HideLoading(param);
        }

        /// <summary>
        /// 创建游戏圈按钮，详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/game-club/wx.createGameClubButton.html
        /// </summary>
        /// <param name="param"></param>
        public static WXGameClubButton CreateGameClubButton(WXCreateGameClubButtonParam param)
        {
            return WXSDKManagerHandler.Instance.CreateGameClubButton(param);
        }

        #endregion

        /*
        #region 订阅
        /// <summary>
        /// 调起小游戏系统订阅消息界面，返回用户订阅消息的操作结果。当用户勾选了订阅面板中的“总是保持以上选择，不再询问”时，模板消息会被添加到用户的小游戏设置页，通过 WX.GetSetting 接口可获取用户对相关模板消息的订阅状态,详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/subscribe-message/wx.requestSubscribeSystemMessage.html
        /// </summary>
        /// <param name="param"></param>
        public static void RequestSubscribeSystemMessage(WXRequestSubscribeSystemMessageParam param) {
            WXSDKManagerHandler.Instance.RequestSubscribeSystemMessage(param);
        }
        #endregion
        */

    }
}

