#if UNITY_WEBGL || UNITY_EDITOR
using System;
using UnityEngine;

namespace WeChatWASM
{
    /// <summary>
    /// 微信SDK对外暴露的API
    /// </summary>
    public class WXBase
    {
#region env

        /// <summary>
        /// Gets 微信提供了一个用户文件目录给开发者，开发者对这个目录有完全自由的读写权限。通过 WX.env.USER_DATA_PATH 可以获取到这个目录的路径。
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
        /// Gets 云函数
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
        /// 上报游戏自定义场景的错误信息
        /// </summary>
        /// <param name="sceneId"></param>
        /// <param name="errorType">错误类型, 取值范围0-10000</param>
        /// <param name="errStr">错误信息</param>
        /// <param name="extJsonStr">上报的额外信息，json序列化字符串</param>
        public static void ReportGameSceneError(int sceneId, int errorType = 0, string errStr = "", string extJsonStr = "")
        {
            WXSDKManagerHandler.Instance.ReportGameSceneError(sceneId, errorType, errStr, extJsonStr);
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
        public static void StorageSetStringSync(string key, string value = "")
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

#region 用户信息

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

#region 分享转发

        /// <summary>
        /// 监听用户点击右上角菜单的「转发」按钮时触发的事件
        /// </summary>
        /// <param name="defaultParam">默认的设置内容</param>
        /// <param name="action">用户点击右上角菜单的「转发」按钮时触发的事件的回调函数，请在回调后三秒内，触发 Action<WXShareAppMessageParam>返回设置的内容,否则会使用 defaultParam</param>
        public static void OnShareAppMessage(WXShareAppMessageParam defaultParam, Action<Action<WXShareAppMessageParam>> action = null)
        {
            WXSDKManagerHandler.Instance.OnShareAppMessage(defaultParam, action);
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
        /// 创建原生模板广告组件 详细参见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createCustomAd.html
        /// </summary>
        /// <param name="param"></param>
        /// <returns>广告操作对象，https://developers.weixin.qq.com/minigame/dev/api/ad/CustomAd.html </returns>
        public static WXCustomAd CreateCustomAd(WXCreateCustomAdParam param)
        {
            return WXSDKManagerHandler.Instance.CreateCustomAd(param);
        }
#endregion

#region 游戏对局回放

        /// <summary>
        /// [[GameRecorder](https://developers.weixin.qq.com/minigame/dev/api/game-recorder/GameRecorder.html) wx.getGameRecorder()](https://developers.weixin.qq.com/minigame/dev/api/game-recorder/wx.getGameRecorder.html)
        ///
        /// 需要基础库： `2.26.1`
        /// 需要客户端： 安卓>=`8.0.28`，目前只支持安卓
        /// 获取全局唯一的游戏画面录制对象
        /// </summary>
        /// <returns></returns>
        public static WXGameRecorder GetGameRecorder()
        {
            return WXSDKManagerHandler.Instance.GetGameRecorder();
        }
#endregion

#region 相机

        /// <summary>
        /// [[WXCamera](https://developers.weixin.qq.com/minigame/dev/api/media/camera/Camera.html) wx.createCamera(Object object)](https://developers.weixin.qq.com/minigame/dev/api/media/camera/wx.createCamera.html)
        /// 需要基础库： `2.9.0`
        /// 创建相机
        /// </summary>
        /// <returns></returns>
        public static WXCamera CreateCamera(CreateCameraOption param)
        {
            return WXSDKManagerHandler.Instance.CreateCamera(param);
        }
#endregion

#region 录音

        /// <summary>
        /// [[RecorderManager](https://developers.weixin.qq.com/minigame/dev/api/media/recorder/RecorderManager.html) wx.getRecorderManager()](https://developers.weixin.qq.com/minigame/dev/api/media/recorder/wx.getRecorderManager.html)
        /// 需要基础库： `1.6.0`
        /// 获取**全局唯一**的录音管理器 RecorderManager
        /// </summary>
        /// <returns></returns>
        public static WXRecorderManager GetRecorderManager()
        {
            return WXSDKManagerHandler.Instance.GetRecorderManager();
        }
#endregion

#region 社交组件
        public static WXChat CreateMiniGameChat(WXChatOptions options = null)
        {
            return WXSDKManagerHandler.Instance.CreateMiniGameChat(options);
        }
#endregion

#region 上传文件

        /// <summary>
        /// [[UploadTask](https://developers.weixin.qq.com/minigame/dev/api/network/upload/UploadTask.html) wx.uploadFile(Object object)](https://developers.weixin.qq.com/minigame/dev/api/network/upload/wx.uploadFile.html)
        /// 将本地资源上传到服务器。客户端发起一个 HTTPS POST 请求，其中 `content-type` 为 `multipart/form-data`。使用前请注意阅读[相关说明](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/network.html)。
        /// **示例代码**
        /// ```js
        /// wx.chooseImage({
        /// success (res) {
        /// const tempFilePaths = res.tempFilePaths
        /// wx.uploadFile({
        /// url: 'https://example.weixin.qq.com/upload', //仅为示例，非真实的接口地址
        /// filePath: tempFilePaths[0],
        /// name: 'file',
        /// formData: {
        /// 'user': 'test'
        /// },
        /// success (res){
        /// const data = res.data
        /// //do something
        /// }
        /// })
        /// }
        /// })
        /// ```
        /// </summary>
        /// <returns></returns>
        public static WXUploadTask UploadFile(UploadFileOption option)
        {
            return WXSDKManagerHandler.Instance.UploadFile(option);
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

#endregion

#region 音频

        /// <summary>
        /// InnerAudioContext 实例，可通过 WX.CreateInnerAudioContext 接口获取实例。注意，音频播放过程中，可能被系统中断，可通过 WX.OnAudioInterruptionBegin、WX.OnAudioInterruptionEnd事件来处理这种情况。详见：https://developers.weixin.qq.com/minigame/dev/api/media/audio/InnerAudioContext.html
        /// 使用参考文档：https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/AudioOptimization.md
        /// </summary>
        ///
        /// <returns></returns><example>
        // var music = WX.CreateInnerAudioContext(new InnerAudioContextParam() {
        //    src = "Assets/Audio/Chill_1.wav",
        //    needDownload = true //表示等下载完之后再播放，便于后续复用，无延迟
        // });
        // music.OnCanplay(() =>
        // {
        //    Debug.Log("OnCanplay");
        //    music.Play();
        // });
        // </example>
        public static WXInnerAudioContext CreateInnerAudioContext(InnerAudioContextParam param = null)
        {
            return WXSDKManagerHandler.Instance.CreateInnerAudioContext(param);
        }

        /// <summary>
        /// 音频为网络请求，可能会有延迟，所以可以先调用这个接口预先下载音频缓存到本地，避免延迟
        /// </summary>
        /// <param name="pathList">音频的地址数组,如 { "Assets/Audio/0.wav", "Assets/Audio/1.wav" } </param>
        /// <param name="action">全部音频下载完成后回调，返回码为0表示下载完成</param>
        /// <example>
        ///     string[] a = { "Assets/Audio/0.wav", "Assets/Audio/1.wav" };
        // WX.PreDownloadAudios(a, (code) =>
        //            {
        //                Debug.Log("Downloaded" + code);
        //                if (code == 0)
        //                {
        //                    var music0 = WX.CreateInnerAudioContext(new InnerAudioContextParam()
        //                    {
        //                        src = "Assets/Audio/0.wav"
        //                    });
        //        music0.Play();
        // var music1 = WX.CreateInnerAudioContext(new InnerAudioContextParam()
        //                    {
        //                        src = "Assets/Audio/1.wav"
        //                    });
        //        music1.Play();
        //                }
        // });
        // </example>
        public static void PreDownloadAudios(string[] pathList, Action<int> action)
        {
            WXSDKManagerHandler.Instance.PreDownloadAudios(pathList, action);
        }
#endregion

#region 视频

        /// <summary>
        /// 创建视频，详见 https://developers.weixin.qq.com/minigame/dev/api/media/video/wx.createVideo.html
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static WXVideo CreateVideo(WXCreateVideoParam param)
        {
            return WXSDKManagerHandler.Instance.CreateVideo(param);
        }

#endregion

#region 性能

        /// <summary>
        /// 获取当前UnityHeap总内存(峰值)
        /// </summary>
        /// <returns></returns>
        public static uint GetTotalMemorySize()
        {
            return WXSDKManagerHandler.Instance.GetTotalMemorySize();
        }

        /// <summary>
        /// 获取当前UnityHeap Stack大小
        /// </summary>
        /// <returns></returns>
        public static uint GetTotalStackSize()
        {
            return WXSDKManagerHandler.Instance.GetTotalStackSize();
        }

        /// <summary>
        /// 获取当前UnityHeap静态内存
        /// </summary>
        /// <returns></returns>
        public static uint GetStaticMemorySize()
        {
            return WXSDKManagerHandler.Instance.GetStaticMemorySize();
        }

        /// <summary>
        /// 获取当前UnityHeap动态内存
        /// </summary>
        /// <returns></returns>
        public static uint GetDynamicMemorySize()
        {
            return WXSDKManagerHandler.Instance.GetDynamicMemorySize();
        }

        /// <summary>
        /// 获取当前UnityHeap动态内存
        /// </summary>
        /// <returns></returns>
        public static uint GetUsedMemorySize()
        {
            return WXSDKManagerHandler.Instance.GetUsedMemorySize();
        }

        /// <summary>
        /// 获取当前UnityHeap动态内存
        /// </summary>
        /// <returns></returns>
        public static uint GetUnAllocatedMemorySize()
        {
            return WXSDKManagerHandler.Instance.GetUnAllocatedMemorySize();
        }

        /// <summary>
        /// 打印UnityHeap内存
        /// </summary>
        public static void LogUnityHeapMem()
        {
            WXSDKManagerHandler.Instance.LogUnityHeapMem();
        }

#region WXAssetBundle

        /// <summary>
        /// 获取当前AssetBundle在JS内存中的数量
        /// </summary>
        /// <returns></returns>
        public static uint GetBundleNumberInMemory()
        {
            return WXSDKManagerHandler.Instance.GetBundleNumberInMemory();
        }

        /// <summary>
        /// 获取当前AssetBundle在磁盘中不可清理的数量
        /// </summary>
        /// <returns></returns>
        public static uint GetBundleNumberOnDisk()
        {
            return WXSDKManagerHandler.Instance.GetBundleNumberOnDisk();
        }

        /// <summary>
        /// 获取当前AssetBundle在JS内存中的体积
        /// </summary>
        /// <returns></returns>
        public static uint GetBundleSizeInMemory()
        {
            return WXSDKManagerHandler.Instance.GetBundleSizeInMemory();
        }

        /// <summary>
        /// 获取当前AssetBundle在磁盘中不可清理的体积
        /// </summary>
        /// <returns></returns>
        public static uint GetBundleSizeOnDisk()
        {
            return WXSDKManagerHandler.Instance.GetBundleSizeOnDisk();
        }
#endregion

        /// <summary>
        /// 打开性能面板
        /// </summary>
        public static void OpenProfileStats()
        {
            WXSDKManagerHandler.Instance.OpenProfileStats();
        }

        /// <summary>
        /// ProfilingMemory内存Dump
        /// </summary>
        public static void ProfilingMemoryDump()
        {
            WXSDKManagerHandler.Instance.ProfilingMemoryDump();
        }
#endregion

#region 调试

        /// <summary>
        /// 写 debug 日志，同 https://developers.weixin.qq.com/minigame/dev/api/base/debug/LogManager.debug.html
        /// </summary>
        /// <param name="str"></param>
        public static void LogManagerDebug(string str)
        {
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
        /// <returns></returns>
        public static bool IsCloudTest()
        {
            return WXSDKManagerHandler.Instance.IsCloudTest();
        }
#endregion

#region 清理文件缓存

        /// <summary>
        /// 游戏异常时，使用本接口清理资源缓存
        /// </summary>
        public static void CleanAllFileCache(Action<bool> action = null)
        {
            WXSDKManagerHandler.Instance.CleanAllFileCache(action);
        }

        /// <summary>
        /// 当空间不足时，清理指定大小缓存，按文件最近访问时间排序
        /// </summary>
        /// <param name="fileSize">需要清理的文件大小，单位bytes</param>
        public static void CleanFileCache(int fileSize, Action<ReleaseResult> action = null)
        {
            WXSDKManagerHandler.Instance.CleanFileCache(fileSize, action);
        }

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="path">需要清理的文件路径，支持完整路径，也支持StreamingAssets/filepath格式</param>
        public static void RemoveFile(string path, Action<bool> action = null)
        {
            WXSDKManagerHandler.Instance.RemoveFile(path, action);
        }

        /// <summary>
        /// Gets bundle、纹理等自动缓存的目录
        /// </summary>
        /// <value>
        /// Bundle、纹理等自动缓存的目录
        /// </value>
        public static string PluginCachePath
        {
            get
            {
                return WXSDKManagerHandler.PluginCachePath;
            }
        }

        /// <summary>
        /// 获取文件的本地缓存路径，若无缓存，可进行预下载
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetCachePath(string url)
        {
            return WXSDKManagerHandler.Instance.GetCachePath(url);
        }

#endregion

        /// <summary>
        /// 获取启动loader的启动数据
        /// </summary>
        /// <param name="action"></param>
        public static void OnLaunchProgress(Action<LaunchEvent> action = null)
        {
            WXSDKManagerHandler.Instance.OnLaunchProgress(action);
        }

        public static void UncaughtException()
        {
            WXSDKManagerHandler.Instance.UncaughtException();
        }

#region 交互

        /// <summary>
        /// 创建游戏圈按钮，详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/game-club/wx.createGameClubButton.html
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static WXGameClubButton CreateGameClubButton(WXCreateGameClubButtonParam param)
        {
            return WXSDKManagerHandler.Instance.CreateGameClubButton(param);
        }

#endregion

#region UDP
        public static int CreateUDPSocket(string ip, int remotePort, int bindPort = 0)
        {
            return WXSDKManagerHandler.Instance.CreateUDPSocket(ip, remotePort, bindPort);
        }

        public static void CloseUDPSocket(int socketId)
        {
            WXSDKManagerHandler.Instance.CloseUDPSocket(socketId);
        }

        public static void SendUDPSocket(int socketId, byte[] buffer, int offset, int length)
        {
            WXSDKManagerHandler.Instance.SendUDPSocket(socketId, buffer, offset, length);
        }
#endregion

#region 插件配置
        public static void SetDataCDN(string path)
        {
            WXSDKManagerHandler.Instance.SetDataCDN(path);
        }

        public static void SetPreloadList(string[] paths)
        {
            WXSDKManagerHandler.Instance.SetPreloadList(paths);
        }
#endregion

        /// <summary>
        /// 获取文件的本地缓存路径，若无缓存，可进行预下载
        /// </summary>
        /// <param name="fallbackUrl">系统字体不可用时，游戏自己提供的ttf文件地址</param>
        /// <param name="callback">字体资源回调</param>
        /// <returns></returns>
        public static void GetWXFont(string fallbackUrl, Action<Font> callback)
        {
            WeChatWASM.WXFont.GetFontData(new GetFontParam
            {
                fallbackUrl = fallbackUrl,
                success = (succ) =>
                {
                    var inFontData = succ.binData;
                    var ascent = succ.ascent;
                    var descent = succ.descent;
                    var lineGap = succ.lineGap;
                    var unitsPerEm = succ.unitsPerEm;
                    // 未经过充分测试，目前看fontSize不决定最终字体大小，此处只是为了换算lineHeight。如果游戏使用有问题，可以考虑让游戏侧传入字体大小
                    var fSize = 16;
                    var abBytes = Unity.FontABTool.UnityFontABTool.PacKFontAB(inFontData, "WXFont", fSize * (Math.Abs(ascent) + Math.Abs(descent) + Math.Abs(lineGap)), fSize, fSize * ascent, fSize * descent);
                    try
                    {
                        var ab = AssetBundle.LoadFromMemory(abBytes);
                        if (ab != null)
                        {
                            Font[] fonts = ab.LoadAllAssets<Font>();
                            if (fonts.Length != 0)
                            {
                                WriteLog($"Load font from ab. abBytes:{abBytes.Length}");
                                callback.Invoke(fonts[0]);
                            }
                            else
                            {
                                WriteWarn($"LoadAllAssets failed, abBytes:{abBytes.Length}, fonts: {fonts.Length}");
                                callback.Invoke(null);
                            }
                            ab.Unload(false);
                        }
                        else
                        {
                            WriteWarn($"LoadFromMemory failed, Length: {abBytes.Length}");
                            callback.Invoke(null);
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteWarn($"GetWXFont Exception, ex:{ex.ToString()}");
                        callback.Invoke(null);
                    }
                },
                fail = (fail) =>
                {
                    WriteWarn($"GetFontData fail {fail.errMsg}");
                    callback.Invoke(null);
                },
            });
        }
    }
}
#endif
