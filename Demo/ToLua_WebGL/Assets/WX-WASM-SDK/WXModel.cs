using System;
using UnityEngine.Scripting;

namespace WeChatWASM
{
    public class WXBaseResponse
    {
        public string callbackId; //回调id,调用者不需要关注
        public string errMsg;   //失败示例 getUserInfo:fail auth deny; 成功示例 getUserInfo:ok
    }

    public class WXBaseActionParam<T>
    {
        public Action<T> success;  //接口调用成功的回调函数
        public Action<T> fail;   //接口调用失败的回调函数	
        public Action<T> complete;  //接口调用结束的回调函数（调用成功、失败都会执行）
    }



    public class WXTextResponse : WXBaseResponse
    {
        public int errCode;
    }

    public class WXReadFileResponse : WXBaseResponse
    {
        /// <summary>
        /// 如果返回二进制，则数据在这个字段
        /// </summary>
        public byte[] binData;
        /// <summary>
        /// 如果返回的是字符串，则数据在这个字段
        /// </summary>
        public string stringData;
    }

    public class WXUserInfoResponse : WXBaseResponse
    {
        // 具提说明可以参考 https://developers.weixin.qq.com/minigame/dev/api/open-api/user-info/wx.getUserInfo.html
        public int errCode; // 0为成功，非零为失败
        public string signature; //使用 sha1( rawData + sessionkey ) 得到字符串，用于校验用户信息，详见 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html
        public string encryptedData; //包括敏感数据在内的完整用户信息的加密数据，详见 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#%E5%8A%A0%E5%AF%86%E6%95%B0%E6%8D%AE%E8%A7%A3%E5%AF%86%E7%AE%97%E6%B3%95
        public string iv; //加密算法的初始向量，详见 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#%E5%8A%A0%E5%AF%86%E6%95%B0%E6%8D%AE%E8%A7%A3%E5%AF%86%E7%AE%97%E6%B3%95
        public string cloudID; //敏感数据对应的云 ID，开通云开发的小程序才会返回，可通过云调用直接获取开放数据，详细见云调用直接获取开放数据 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#method-cloud
        public WXUserInfo userInfo; //用户信息对象，不包含 openid 等敏感信息
        public string userInfoRaw; //userinfo的序列化

    }

    public class WXShareInfoResponse : WXBaseResponse
    {
        // 具提说明可以参考 https://developers.weixin.qq.com/minigame/dev/api/share/wx.getShareInfo.html
        public string encryptedData;
        public string iv;
        public string cloudID;
    }

    public class WXAuthPrivateMessageResponse : WXBaseResponse
    {

        public string encryptedData;
        public string iv;
        public bool valid;
    }

    public class WXADErrorResponse : WXBaseResponse
    { // 具提说明可以参考 https://developers.weixin.qq.com/minigame/dev/api/ad/BannerAd.onError.html
        public int errCode;
    }

    public class WXADResizeResponse : WXBaseResponse
    { // 具提说明可以参考 https://developers.weixin.qq.com/minigame/dev/api/ad/BannerAd.onResize.html
        public int width;
        public int height;
    }

    public class WXRewardedVideoAdOnCloseResponse : WXBaseResponse
    {
        /// <summary>
        /// 视频是否是在用户完整观看的情况下被关闭的,详见 https://developers.weixin.qq.com/minigame/dev/api/ad/RewardedVideoAd.onClose.html
        /// </summary>
        public bool isEnded;
    }

    /// <summary>
    /// 小游戏回到前台的事件的回调函数里返回的数据,详见 https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html
    /// </summary>
    public class WXOnShowResponse
    {
        public string scene;
        /// <summary>
        /// JS版里的query对象序列化成的JSON字符串
        /// </summary>
        public string queryRaw;
        public string shareTicket;
        public ReferrerInfo referrerInfo;
        /// <summary>
        /// 该字段没用
        /// </summary>
        public string referrerInfoRaw;
    }

    /// <summary>
    /// 云函数回调 https://developers.weixin.qq.com/minigame/dev/wxcloud/reference-sdk-api/functions/Cloud.callFunction.html
    /// </summary>
    public class WXCloudCallFunctionResponse : WXBaseResponse {
        /// <summary>
        /// 后端返回的经过json序列化后的数据
        /// </summary>
        public string result;
        public string requestID;
    }


    public struct ReferrerInfo
    {
        public string appid;
        /// <summary>
        /// 对应JS版里的 extraData，这里序列化成JSON字符串
        /// </summary>
        public string extraDataRaw;
    }


    public struct WXUserInfo
    {
        /// <summary>
        /// 详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/user-info/UserInfo.html
        /// </summary>
        public string nickName;
        public string avatarUrl;
        public string country;
        public string province;
        public string city;
        public string language;
        public int gender;
    }


    public struct WXSafeArea
    {
        public int left;
        public int right;
        public int top;
        public int bottom;
        public int width;
        public int height;
    }

    public class WXAccountInfo : WXBaseResponse
    {
        public WXAccountInfoMiniProgram miniProgram;
        public string miniProgramRaw;
        public WXAccountInfoPlugin plugin;
        public string pluginRaw;
    }


    public struct WXAccountInfoMiniProgram
    {
        public string appId;
        public string envVersion;
    }

    public struct WXAccountInfoPlugin
    {
        public string appId;
        public string version;
    }

        /// <summary>
        /// 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.updateShareMenu.html
        /// </summary>
    public class WXUpdateShareMenuParam : WXBaseActionParam<WXTextResponse>
    {

        public bool withShareTicket;
        public bool isUpdatableMessage;
        public string activityId;
        public string toDoActivityId;
        public bool isPrivateMessage;
        public TemplateInfo templateInfo;
        /// <summary>
        ///  // 该字段不需要传
        /// </summary>
        public string[] templateInfoRaw;
    }


    public class TemplateInfo
    {
        public TemplateInfoItem[] parameterList;
    }

    public class TemplateInfoItem
    {
        public string name;
        public string value;
    }


    public class WXShowShareMenuParam : WXBaseActionParam<WXTextResponse>
    {
        // 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.showShareMenu.html
        public bool withShareTicket;
        public string[] menus;
    }

    public class WXHideShareMenuParam : WXBaseActionParam<WXTextResponse>
    {
        // 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.hideShareMenu.html
        public string[] menus;
    }

    public class WXShareAppMessageParam
    {
        // 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.shareAppMessage.html
        public string title;
        public string imageUrl;
        public string query;
        public string imageUrlId;
        public bool toCurrentGroup;
        public string path;
    }

    public class WXShareTimelineParam
    {
        // 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.onShareTimeline.html
        public string title;
        public string imageUrl;
        public string query;
        public string path;
    }

    public class WXAddToFavoritesParam
    {
        // 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.onAddToFavorites.html
        public string title;
        public string imageUrl;
        public string query;
        public bool disableForward;
    }


    public class WXGetShareInfoParam : WXBaseActionParam<WXShareInfoResponse>
    {
        // 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.getShareInfo.html
        public string shareTicket;
        public int timeout;
    }

    public class WXAuthPrivateMessageParam : WXBaseActionParam<WXShareInfoResponse>
    {
        // 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/share/wx.authPrivateMessage.html
        public string shareTicket;
    }

    /// <summary>
    /// 创建 banner 广告组件参数，参数详见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createBannerAd.html
    /// </summary>
    public class WXCreateBannerAdParam
    {
        public string adUnitId;
        public int adIntervals;
        public Style style;
        public string styleRaw; //该字段不需要传
    }

    /// <summary>
    /// 创建激励视频广告组件参数，参数详见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createRewardedVideoAd.html
    /// </summary>
    public class WXCreateRewardedVideoAdParam
    {
        public string adUnitId;
        public bool multiton;
    }

    /// <summary>
    /// 创建插屏广告组件参数,参数详见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createInterstitialAd.html
    /// </summary>
    public class WXCreateInterstitialAdParam
    {
        public string adUnitId;
    }

    /// <summary>
    /// 创建格子广告参数，参数详见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createGridAd.html
    /// </summary>
    public class WXCreateGridAdParam
    {
        public string adUnitId;
        public int adIntervals;
        public string adTheme;
        public int gridCount;
        public Style style;
        public string styleRaw; //该字段不需要传 
    }

    /// <summary>
    /// 创建原生模板广告参数，参数详见 https://developers.weixin.qq.com/minigame/dev/api/ad/wx.createCustomAd.html
    /// </summary>
    public class WXCreateCustomAdParam
    {
        public string adUnitId;
        public int adIntervals;
        public CustomStyle style;
        public string styleRaw; //该字段不需要传 
    }

    public struct Style
    {
        public int left;
        public int top;
        public int width;
        public int height;
    }

    /// <summary>
    /// 原生模板广告组件的样式
    /// </summary>
    public struct CustomStyle
    {
        /// <summary>
        /// 原生模板广告组件的左上角横坐标
        /// </summary>
        public int left;
        /// <summary>
        /// 原生模板广告组件的左上角纵坐标
        /// </summary>
        public int top;
        /// <summary>
        /// 原生模板广告组件是否固定屏幕位置（不跟随屏幕滚动）, 相当于JS api里的 fixed
        /// </summary>
        public bool isFixed;
    }

    /// <summary>
    /// 将当前 Canvas 保存为一个临时文件,详见 https://developers.weixin.qq.com/minigame/dev/api/render/canvas/Canvas.toTempFilePathSync.html
    /// </summary>
    public class WXToTempFilePathParam
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int destWidth;
        public int destHeight;
        public string fileType;
        public int quality;
    }

    /// <summary>
    /// 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/ui/keyboard/wx.updateKeyboard.html
    /// </summary>
    public class WXUpdateKeyboardParam : WXBaseActionParam<WXTextResponse>
    {
        public string value;
    }

    /// <summary>
    /// 各字段说明详见这里，https://developers.weixin.qq.com/minigame/dev/api/ui/keyboard/wx.showKeyboard.html
    /// </summary>
    public class WXShowKeyboardParam : WXBaseActionParam<WXTextResponse>
    {
        public string defaultValue;
        public int maxLength;
        public bool multiple;
        public bool confirmHold;
        public string confirmType;

    }

    /// <summary>
    /// 对用户托管数据进行写数据操作。允许同时写多组 KV 数据。详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.setUserCloudStorage.html
    /// </summary>
    public class SetUserCloudStorageParam : WXBaseActionParam<WXTextResponse>
    {
        public KVData[] KVDataList;
    }


    /// <summary>
    /// 删除用户托管数据当中对应 key 的数据。详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.removeUserCloudStorage.html
    /// </summary>
    public class RemoveUserCloudStorageParam : WXBaseActionParam<WXTextResponse>
    {

        public string[] keyList;
    }

    /// <summary>
    /// https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.access.html
    /// </summary>
    public class AccessParam : WXBaseActionParam<WXTextResponse>
    {
        public string path;
    }

    /// <summary>
    /// https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.unlink.html
    /// </summary>
    public class UnlinkParam : WXBaseActionParam<WXTextResponse>
    {
        public string filePath;
    }

    /// <summary>
    /// https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.mkdir.html
    /// </summary>
    public class MkdirParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 创建的目录路径 (本地路径)
        /// </summary>
        public string dirPath;
        /// <summary>
        /// 是否在递归创建该目录的上级目录后再创建该目录。如果对应的上级目录已经存在，则不创建该上级目录。如 dirPath 为 a/b/c/d 且 recursive 为 true，将创建 a 目录，再在 a 目录下创建 b 目录，以此类推直至创建 a/b/c 目录下的 d 目录。
        /// </summary>
        public bool recursive = false;
    }

    /// <summary>
    /// https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.copyFile.html
    /// </summary>
    public class CopyFileParam : WXBaseActionParam<WXTextResponse>
    {
        public string srcPath;
        public string destPath;
    }

    [Preserve]
    public class TouchEvent
    {
        /// <summary>
        /// 当前所有触摸点的列表
        /// </summary>
        public Touch[] touches;
        /// <summary>
        /// 触发此次事件的触摸点列表,可以通过这个知道触发当前通知的事件的位置
        /// </summary>
        public Touch[] changedTouches;
        /// <summary>
        /// 事件触发时的时间戳
        /// </summary>
        public long timeStamp;
    }


    /// <summary>
    /// 调用云函数 https://developers.weixin.qq.com/minigame/dev/wxcloud/reference-sdk-api/functions/Cloud.callFunction.html
    /// </summary>
    public class CallFunctionParam : WXBaseActionParam<WXCloudCallFunctionResponse>
    {
        public string name;
        /// <summary>
        /// 这里请将数据json序列化为字符串再赋值到data
        /// </summary>
        public string data;
        public CallFunctionConf config;
    }

    public class CallFunctionConf
    {
        public string env;
    }

    /// <summary>
    /// 云函数初始化 https://developers.weixin.qq.com/minigame/dev/wxcloud/reference-sdk-api/init/client.init.html
    /// </summary>
    public class CallFunctionInitParam
    {
        /// <summary>
        /// 必填，环境ID，指定接下来调用 API 时访问哪个环境的云资源
        /// </summary>
        public string env;
        /// <summary>
        /// 是否在将用户访问记录到用户管理中，在控制台中可见
        /// </summary>
        public bool traceUser;
    }

    public class InnerAudioContextParam
    {
        /// <summary>
        /// 音频资源的地址，用于直接播放。可以设置为网络地址，或者unity中的本地路径如 Assets/xx.wav，运行时会自动和配置的音频地址前缀做拼接得到最终线上地址
        /// </summary>
        public string src = "";
        /// <summary>
        /// 是否循环播放,默认为 false
        /// </summary>
        public bool loop = false;
        /// <summary>
        /// 开始播放的位置（单位：s），默认为 0
        /// </summary>
        public float startTime = 0;
        /// <summary>
        /// 是否自动开始播放，默认为 false
        /// </summary>
        public bool autoplay = false;
        /// <summary>
        /// 音量。范围 0~1。默认为 1
        /// </summary>
        public float volume = 1;
        /// <summary>
        /// 播放速度。范围 0.5-2.0，默认为 1。
        /// </summary>
        public float playbackRate = 1;
        /// <summary>
        /// 下载音频，设置为true后，会完全下载后再触发OnCanplay，方便后续音频复用，避免延迟
        /// </summary>
        public bool needDownload = false;
    }

    /// <summary>
    /// 发起米大师支付参数，详见 https://developers.weixin.qq.com/minigame/dev/api/midas-payment/wx.requestMidasPayment.html 
    /// </summary>
    public class RequestMidasPaymentParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 支付的类型，不同的支付类型有各自额外要传的附加参数。
        /// </summary>
        public string mode = "";
        /// <summary>
        /// 环境配置
        /// </summary>
        public int env = 0;
        /// <summary>
        /// 在米大师侧申请的应用 id
        /// </summary>
        public string offerId = "";
        /// <summary>
        /// 币种
        /// </summary>
        public string currencyType = "";
        /// <summary>
        /// 申请接入时的平台，platform 与应用id有关
        /// </summary>
        public string platform = "";
        /// <summary>
        /// 购买数量。mode=game 时必填。购买数量。
        /// </summary>
        public int buyQuantity = 0;
        /// <summary>
        /// 分区 ID
        /// </summary>
        public string zoneId = "1";
    }

    /// <summary>
    /// 发起米大师朋友礼物索要参数，详见 https://developers.weixin.qq.com/minigame/dev/api/midas-payment/wx.requestMidasFriendPayment.html
    /// </summary>
    public class RequestMidasFriendPaymentParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 支付的类型，不同的支付类型有各自额外要传的附加参数。
        /// </summary>
        public string mode = "";
        /// <summary>
        /// 环境配置
        /// </summary>
        public int env = 0;
        /// <summary>
        /// 在米大师侧申请的应用 id
        /// </summary>
        public string offerId = "";
        /// <summary>
        /// 币种
        /// </summary>
        public string currencyType = "";
        /// <summary>
        /// 申请接入时的平台，platform 与应用id有关
        /// </summary>
        public string platform = "";
        /// <summary>
        /// 购买数量。mode=game 时必填。购买数量。
        /// </summary>
        public int buyQuantity = 0;
        /// <summary>
        /// 分区 ID
        /// </summary>
        public string zoneId = "1";
        /// <summary>
        /// 开发者业务订单号，每个订单号只能使用一次，重复使用会失败。要求32个字符内，只能是数字、大小写字母、符号 _-|*@
        /// </summary>
        public string outTradeNo = "";
        /// <summary>
        /// 随机字符串，长度应小于 128
        /// </summary>
        public string nonceStr = "";
        /// <summary>
        /// 生成这个随机字符串的 UNIX 时间戳（精确到秒）
        /// </summary>
        public int timeStamp;
        /// <summary>
        /// 签名
        /// </summary>
        public string signature = "";

    }

    /// <summary>
    /// 网络状态变化事件的回调参数，详见 https://developers.weixin.qq.com/minigame/dev/api/device/network/wx.onNetworkStatusChange.html
    /// </summary>
    public class NetworkStatus {
        /// <summary>
        /// 当前是否有网络连接
        /// </summary>
        public bool isConnected;
        /// <summary>
        /// 网络类型
        /// </summary>
        public string networkType;
    }

    public class GetNetworkTypeResponse : WXBaseResponse
    {
        /// <summary>
        /// 网络类型
        /// </summary>
        public string networkType;
        /// <summary>
        /// 信号强弱，单位 dbm
        /// </summary>
        public int signalStrength;
    }

    public class GetNetworkTypeParam : WXBaseActionParam<GetNetworkTypeResponse> {

    }


    public class SetKeepScreenOnParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 是否保持屏幕常亮
        /// </summary>
        public bool keepScreenOn;
    }

    public class WriteFileParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 要写入的文件路径 (本地路径)
        /// </summary>
        public string filePath;
        /// <summary>
        /// 要写入的二进制数据
        /// </summary>
        public byte[] data;
        /// <summary>
        /// 指定写入文件的字符编码
        /// </summary>
        public string encoding = "utf8";

    }

    public class WriteFileStringParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 要写入的文件路径 (本地路径)
        /// </summary>
        public string filePath;
        /// <summary>
        /// 要写入的二进制数据
        /// </summary>
        public string data;
        /// <summary>
        /// 指定写入文件的字符编码
        /// </summary>
        public string encoding = "utf8";

    }



    public class ReadFileParam : WXBaseActionParam<WXReadFileResponse>
    {
        /// <summary>
        /// 要读取的文件的路径 (本地路径)
        /// </summary>
        public string filePath;
        /// <summary>
        /// 指定读取文件的字符编码，如果不传 encoding，则以 ArrayBuffer 格式读取文件的二进制内容
        /// </summary>
        public string encoding;
    }

    public class WXReadFileCallback : WXTextResponse
    {
        public string data;
        public int byteLength;
    }


    public class CustomerServiceConversationParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 会话来源
        /// </summary>
        public string sessionFrom;
        /// <summary>
        /// 是否显示会话内消息卡片，设置此参数为 true，用户进入客服会话会在右下角显示"可能要发送的小程序"提示，用户点击后可以快速发送小程序消息
        /// </summary>
        public bool showMessageCard;
        /// <summary>
        /// 会话内消息卡片标题
        /// </summary>
        public string sendMessageTitle;
        /// <summary>
        /// 会话内消息卡片路径
        /// </summary>
        public string sendMessagePath;
        /// <summary>
        /// 会话内消息卡片图片路径
        /// </summary>
        public string sendMessageImg;
    }


    public class WXVideoCallback : WXTextResponse
    {
        /// <summary>
        /// 当前的播放位置，单位为秒
        /// </summary>
        public float position;
        /// <summary>
        /// 视频的总时长，单位为秒
        /// </summary>
        public float duration;
        /// <summary>
        /// 当前的缓冲进度，缓冲进度区间为 (0~100]，100表示缓冲完成
        /// </summary>
        public int buffered;
    }

    public class WXVideoProgress
    {
        /// <summary>
        /// 视频的总时长，单位为秒
        /// </summary>
        public float duration;
        /// <summary>
        /// 当前的缓冲进度，缓冲进度区间为 (0~100]，100表示缓冲完成
        /// </summary>
        public int buffered;
    }

    public class WXVideoTimeUpdate
    {
        /// <summary>
        /// 当前的播放位置，单位为秒
        /// </summary>
        public float position;
        /// <summary>
        /// 视频的总时长，单位为秒
        /// </summary>
        public float duration;
    }


    //创建视频，详见 https://developers.weixin.qq.com/minigame/dev/api/media/video/wx.createVideo.html
    public class WXCreateVideoParam
    {
        /// <summary>
        /// 视频的左上角横坐标
        /// </summary>
        public int x=0;
        /// <summary>
        /// 视频的左上角纵坐标
        /// </summary>
        public int y=0;
        /// <summary>
        /// 视频的宽度
        /// </summary>
        public int width=300;
        /// <summary>
        /// 视频的高度
        /// </summary>
        public int height=100;
        /// <summary>
        /// 视频的资源地址
        /// </summary>
        public string src;
        /// <summary>
        /// 视频的封面
        /// </summary>
        public string poster;
        /// <summary>
        /// 视频的初始播放位置，单位为 s 秒
        /// </summary>
        public int initialTime;
        /// <summary>
        /// 视频的播放速率，有效值有 0.5、0.8、1.0、1.25、1.5
        /// </summary>
        public float playbackRate=1.0f;
        /// <summary>
        /// 视频是否为直播
        /// </summary>
        public bool live;
        /// <summary>
        /// 视频的缩放模式
        /// </summary>
        public string objectFit= "contain";
        /// <summary>
        /// 视频是否显示控件
        /// </summary>
        public bool controls = true;
        /// <summary>
        /// 是否显示视频底部进度条
        /// </summary>
        public bool showProgress = true;
        /// <summary>
        /// 是否显示控制栏的进度条
        /// </summary>
        public bool showProgressInControlMode = true;
        /// <summary>
        /// 视频背景颜色
        /// </summary>
        public string backgroundColor ="#000000";
        /// <summary>
        /// 视频是否自动播放
        /// </summary>
        public bool autoplay;
        /// <summary>
        /// 视频是否是否循环播放
        /// </summary>
        public bool loop;
        /// <summary>
        /// 视频是否禁音播放
        /// </summary>
        public bool muted;
        /// <summary>
        /// 视频是否遵循系统静音开关设置（仅iOS）
        /// </summary>
        public bool obeyMuteSwitch;
        /// <summary>
        /// 是否启用手势控制播放进度	
        /// </summary>
        public bool enableProgressGesture = true;
        /// <summary>
        /// 是否开启双击播放的手势	
        /// </summary>
        public bool enablePlayGesture;
        /// <summary>
        /// 是否显示视频中央的播放按钮
        /// </summary>
        public bool showCenterPlayBtn = true;
        /// <summary>
        /// 视频是否显示在游戏画布之下
        /// </summary>
        public bool underGameView;
    }


    public class WXClipboardParam : WXBaseActionParam<WXTextResponse>
    {
        public string data;
    }

    public class WXClipboardResponse : WXTextResponse
    {
        public string data;
    }

    public enum WXToastIcon {
        /// <summary>
        /// 显示成功图标，此时 title 文本最多显示 7 个汉字长度
        /// </summary>
        success,
        /// <summary>
        /// 显示失败图标，此时 title 文本最多显示 7 个汉字长度
        /// </summary>
        error,
        /// <summary>
        /// 显示加载图标，此时 title 文本最多显示 7 个汉字长度
        /// </summary>
        loading,
        /// <summary>
        /// 不显示图标，此时 title 文本最多可显示两行
        /// </summary>
        none
    }

    public class WXShowToastParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 提示的内容
        /// </summary>
        public string title;
        /// <summary>
        /// 图标
        /// </summary>
        public WXToastIcon icon = WXToastIcon.success;
        /// <summary>
        /// 提示的延迟时间
        /// </summary>
        public int duration = 1500;
        /// <summary>
        /// 是否显示透明蒙层，防止触摸穿透
        /// </summary>
        public bool mask = false;

    }

    public class WXModalResponse : WXTextResponse
    {
        /// <summary>
        /// editable 为 true 时，用户输入的文本
        /// </summary>
        public string content;
        /// <summary>
        /// 为 true 时，表示用户点击了确定按钮
        /// </summary>
        public bool confirm;
        /// <summary>
        /// 为 true 时，表示用户点击了取消（用于 Android 系统区分点击蒙层关闭还是点击取消按钮关闭）
        /// </summary>
        public bool cancel;
    }

    public class WXShowModalParam : WXBaseActionParam<WXModalResponse>
    {
        /// <summary>
        /// 提示的内容
        /// </summary>
        public string title;
        /// <summary>
        /// 提示的内容
        /// </summary>
        public string content;
        /// <summary>
        /// 是否显示取消按钮
        /// </summary>
        public bool showCancel = true;
        /// <summary>
        /// 取消按钮的文字，最多 4 个字符	
        /// </summary>
        public string cancelText = "取消";
        /// <summary>
        /// 	取消按钮的文字颜色，必须是 16 进制格式的颜色字符串
        /// </summary>
        public string cancelColor = "#000000";
        /// <summary>
        /// 确认按钮的文字，最多 4 个字符
        /// </summary>
        public string confirmText = "确定";
        /// <summary>
        /// 确认按钮的文字颜色，必须是 16 进制格式的颜色字符串
        /// </summary>
        public string confirmColor = "#576B95";
        /// <summary>
        /// 是否显示输入框
        /// </summary>
        public bool editable = false;
        /// <summary>
        /// 显示输入框时的提示文本
        /// </summary>
        public string placeholderText;
    }

    public class WXShowLoadingParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 提示的内容
        /// </summary>
        public string title;
        /// <summary>
        /// 是否显示透明蒙层，防止触摸穿透
        /// </summary>
        public bool mask = false;

    }

    public enum EnvVersion {
        /// <summary>
        /// 开发版
        /// </summary>
        develop,
        /// <summary>
        /// 体验版
        /// </summary>
        trial,
        /// <summary>
        /// 正式版
        /// </summary>
        release
    }

    /// <summary>
    /// 跳转小程序参数，https://developers.weixin.qq.com/minigame/dev/api/navigate/wx.navigateToMiniProgram.html
    /// </summary>
    public class WXNavigateToMiniProgramParam : WXBaseActionParam<WXTextResponse>
    {
        /// <summary>
        /// 必填，要打开的小程序 appId
        /// </summary>
        public string appId;
        /// <summary>
        /// 打开的页面路径，如果为空则打开首页。
        /// </summary>
        public string path;
        /// <summary>
        /// 需要传递给目标小程序的数据
        /// </summary>
        public object extraData;
        public string extraDataRaw; // 该字段不需要传值
        /// <summary>
        /// 要打开的小程序版本，默认release
        /// </summary>
        public EnvVersion envVersion = EnvVersion.release;
        /// <summary>
        /// 小程序链接，当传递该参数后，可以不传 appId 和 path。链接可以通过【小程序菜单】->【复制链接】获取。
        /// </summary>
        public string shortLink;
    }

    public enum GameClubButtonType
    {
        /// <summary>
        /// 可以设置背景色和文本的按钮
        /// </summary>
        text,
        /// <summary>
        /// 只能设置背景贴图的按钮，背景贴图会直接拉伸到按钮的宽高
        /// </summary>
        image
    }
    public enum GameClubButtonTextAlign
    {
        /// <summary>
        /// 居左
        /// </summary>
        left,
        /// <summary>
        /// 居中
        /// </summary>
        center,
        /// <summary>
        /// 居右
        /// </summary>
        right,
    }
    public struct GameClubButtonStyle
    {
        public int left;
        public int top;
        public int width;
        public int height;
        public string backgroundColor;
        public string borderColor;
        public int borderWidth;
        public int borderRadius;
        public string color;
        public GameClubButtonTextAlign textAlign;
        public int fontSize;
        public int lineHeight;
    }
    public enum GameClubButtonIcon
    {
        green,
        white,
        dark,
        light,
    }
    /// <summary>
    /// 创建游戏圈参数，详见 https://developers.weixin.qq.com/minigame/dev/api/open-api/game-club/wx.createGameClubButton.html
    /// </summary>
    public class WXCreateGameClubButtonParam
    {
        /// <summary>
        /// 必填，按钮类型
        /// </summary>
        public GameClubButtonType type;
        /// <summary>
        /// 按钮上的文本，仅当 type 为 text 时有效
        /// </summary>
        public string text;
        /// <summary>
        /// 按钮的背景图片，仅当 type 为 image 时有效
        /// </summary>
        public string image;
        /// <summary>
        /// 必填，按钮的样式
        /// </summary>
        public GameClubButtonStyle style;
        public string styleRaw;
        /// <summary>
        /// 必填，游戏圈按钮的图标，仅当 object.type 参数为 image 时有效。
        /// </summary>
        public GameClubButtonIcon icon;
    }

    public class WXRequestSubscribeSystemMessageResponse : WXTextResponse
    {
        /// <summary>
        /// 系统订阅消息类型，值为"accept"、"reject"、"ban"，"accept", "" 表示用户同意订阅该类型对应的模板消息，"reject"表示用户拒绝订阅该类型对应的模板消息，"ban"表示已被后台封禁, ""表示没有调用该类型请求。例如 { errMsg: "requestSubscribeSystemMessage:ok", SYS_MSG_TYPE_INTERACTIVE: "accept" } 表示用户同意订阅'SYS_MSG_TYPE_INTERACTIVE'这条消息
        /// </summary>
        public string SYS_MSG_TYPE_INTERACTIVE;
        public string SYS_MSG_TYPE_RANK;
    }

    /// <summary>
    /// state 值包括'accept'、'reject'、'ban'、'filter'。'accept'表示用户同意订阅该条id对应的模板消息，'reject'表示用户拒绝订阅该条id对应的模板消息，'ban'表示已被后台封禁，'filter'表示该模板因为模板标题同名被后台过滤。例如 {  TemplateId: "zun-LzcQyW-edafCVvzPkK4de2Rllr1fFpw2A_x0oXE", state : "accept"} 表示用户同意订阅zun-LzcQyW-edafCVvzPkK4de2Rllr1fFpw2A_x0oXE这条消息
    /// </summary>
    public class WXSubscribeMessageItem {
        public string TemplateId;
        public string state;
    }

    public class WXRequestSubscribeMessageResponse : WXTextResponse
    {
        /// <summary>
        /// 跟官网返回格式不一样，以这里为准
        /// </summary>
        public WXSubscribeMessageItem[] resItems;
    }

    public class WXRequestSubscribeSystemMessageParam : WXBaseActionParam<WXRequestSubscribeSystemMessageResponse>
    {
        public string[] msgTypeList;

    }

}