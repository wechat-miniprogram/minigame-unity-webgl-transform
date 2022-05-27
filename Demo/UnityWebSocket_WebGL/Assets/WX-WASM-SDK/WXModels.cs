using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
namespace WeChatWASM
{
    [Preserve]
    public class WXJSCallback
    {
        public string callbackId;
        public string type;
        public string res;
    }

    [Preserve]
    public class AccountInfo {
            /// <summary> 
            /// 小程序帐号信息
            /// </summary>
                public MiniProgram miniProgram;
            /// <summary> 
            /// 插件帐号信息（仅在插件中调用时包含这一项）
            /// </summary>
                public Plugin plugin;
    }
    [Preserve]
    public class MiniProgram {
            /// <summary> 
            /// 小程序 appId
            /// </summary>
                public string appId;
            /// <summary> 
            /// 需要基础库： `2.10.0`
            /// 小程序版本
            /// 可选值：
            /// - 'develop': 开发版;
            /// - 'trial': 体验版;
            /// - 'release': 正式版;
            /// </summary>
                public string envVersion;
            /// <summary> 
            /// 需要基础库： `2.10.2`
            /// 线上小程序版本号
            /// </summary>
                public string version;
    }
    [Preserve]
    public class Plugin {
            /// <summary> 
            /// 插件 appId
            /// </summary>
                public string appId;
            /// <summary> 
            /// 插件版本号
            /// </summary>
                public string version;
    }
    [Preserve]
    public class GetBatteryInfoSyncResult {
            /// <summary> 
            /// 是否正在充电中
            /// </summary>
                public bool isCharging;
            /// <summary> 
            /// 设备电量，范围 1 - 100
            /// </summary>
                public double level;
    }
    [Preserve]
    public class EnterOptionsGame {
            /// <summary> 
            /// 启动小游戏的 query 参数
            /// </summary>
                public Dictionary<string,string> query;
            /// <summary> 
            /// 来源信息。从另一个小程序、公众号或 App 进入小程序时返回。否则返回 `{}`。(参见后文注意)
            /// </summary>
                public EnterOptionsGameReferrerInfo referrerInfo;
            /// <summary> 
            /// 启动小游戏的[场景值](https://developers.weixin.qq.com/minigame/dev/guide/framework/scene.html)
            /// </summary>
                public double scene;
            /// <summary> 
            /// 从微信群聊/单聊打开小程序时，chatType 表示具体微信群聊/单聊类型
            /// 可选值：
            /// - 1: 微信联系人单聊;
            /// - 2: 企业微信联系人单聊;
            /// - 3: 普通微信群聊;
            /// - 4: 企业微信互通群聊;
            /// </summary>
                public double chatType;
            /// <summary> 
            /// shareTicket，详见[获取更多转发信息](#)
            /// </summary>
                public string shareTicket;
    }
    [Preserve]
    public class EnterOptionsGameReferrerInfo {
            /// <summary> 
            /// 来源小程序、公众号或 App 的 appId
            /// </summary>
                public string appId;
            /// <summary> 
            /// 来源小程序传过来的数据，scene=1037或1038时支持
            /// </summary>
                public Dictionary<string,string> extraData;
            /// <summary> 
            /// 从小游戏直播间里的挂件入口打开小游戏时，开发者可从启动参数中获取当前直播的直播间Id和直播者openId*
            /// </summary>
                public GameLiveInfo gameLiveInfo;
    }
    [Preserve]
    public class GameLiveInfo {
            /// <summary> 
            /// 直播者 openId
            /// </summary>
                public string streamerOpenId;
            /// <summary> 
            /// 直播间 id
            /// </summary>
                public string feedId;
    }
    [Preserve]
    public class LaunchOptionsGame {
            /// <summary> 
            /// 启动小游戏的 query 参数
            /// </summary>
                public Dictionary<string,string> query;
            /// <summary> 
            /// 来源信息。从另一个小程序、公众号或 App 进入小程序时返回。否则返回 `{}`。(参见后文注意)
            /// </summary>
                public EnterOptionsGameReferrerInfo referrerInfo;
            /// <summary> 
            /// 启动小游戏的[场景值](https://developers.weixin.qq.com/minigame/dev/devtools/interface/scene.html)
            /// </summary>
                public double scene;
            /// <summary> 
            /// 从微信群聊/单聊打开小程序时，chatType 表示具体微信群聊/单聊类型
            /// 可选值：
            /// - 1: 微信联系人单聊;
            /// - 2: 企业微信联系人单聊;
            /// - 3: 普通微信群聊;
            /// - 4: 企业微信互通群聊;
            /// </summary>
                public double chatType;
            /// <summary> 
            /// shareTicket，详见[获取更多转发信息](#)
            /// </summary>
                public string shareTicket;
    }
    [Preserve]
    public class ClientRect {
            /// <summary> 
            /// 下边界坐标，单位：px
            /// </summary>
                public double bottom;
            /// <summary> 
            /// 高度，单位：px
            /// </summary>
                public double height;
            /// <summary> 
            /// 左边界坐标，单位：px
            /// </summary>
                public double left;
            /// <summary> 
            /// 右边界坐标，单位：px
            /// </summary>
                public double right;
            /// <summary> 
            /// 上边界坐标，单位：px
            /// </summary>
                public double top;
            /// <summary> 
            /// 宽度，单位：px
            /// </summary>
                public double width;
    }
    [Preserve]
    public class GetStorageInfoSyncOption {
            /// <summary> 
            /// 当前占用的空间大小, 单位 KB
            /// </summary>
                public double currentSize;
            /// <summary> 
            /// 当前 storage 中所有的 key
            /// </summary>
                public string[] keys;
            /// <summary> 
            /// 限制的空间大小，单位 KB
            /// </summary>
                public double limitSize;
    }
    [Preserve]
    public class SystemInfo {
            /// <summary> 
            /// 需要基础库： `1.1.0`
            /// 客户端基础库版本
            /// </summary>
                public string SDKVersion;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 允许微信使用相册的开关（仅 iOS 有效）
            /// </summary>
                public bool albumAuthorized;
            /// <summary> 
            /// 需要基础库： `1.8.0`
            /// 设备性能等级（仅 Android）。取值为：-2 或 0（该设备无法运行小游戏），-1（性能未知），>=1（设备性能值，该值越高，设备性能越好，目前最高不到50）
            /// </summary>
                public double benchmarkLevel;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 蓝牙的系统开关
            /// </summary>
                public bool bluetoothEnabled;
            /// <summary> 
            /// 需要基础库： `1.5.0`
            /// 设备品牌
            /// </summary>
                public string brand;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 允许微信使用摄像头的开关
            /// </summary>
                public bool cameraAuthorized;
            /// <summary> 
            /// 设备方向
            /// 可选值：
            /// - 'portrait': 竖屏;
            /// - 'landscape': 横屏;
            /// </summary>
                public string deviceOrientation;
            /// <summary> 
            /// 需要基础库： `2.15.0`
            /// 是否已打开调试。可通过右上角菜单或 [wx.setEnableDebug](https://developers.weixin.qq.com/minigame/dev/api/base/debug/wx.setEnableDebug.html) 打开调试。
            /// </summary>
                public bool enableDebug;
            /// <summary> 
            /// 需要基础库： `1.5.0`
            /// 用户字体大小（单位px）。以微信客户端「我-设置-通用-字体大小」中的设置为准
            /// </summary>
                public double fontSizeSetting;
            /// <summary> 
            /// 需要基础库： `2.12.3`
            /// 当前小程序运行的宿主环境
            /// </summary>
                public Host host;
            /// <summary> 
            /// 微信设置的语言
            /// </summary>
                public string language;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 允许微信使用定位的开关
            /// </summary>
                public bool locationAuthorized;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 地理位置的系统开关
            /// </summary>
                public bool locationEnabled;
            /// <summary> 
            /// `true` 表示模糊定位，`false` 表示精确定位，仅 iOS 支持
            /// </summary>
                public bool locationReducedAccuracy;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 允许微信使用麦克风的开关
            /// </summary>
                public bool microphoneAuthorized;
            /// <summary> 
            /// 设备型号。新机型刚推出一段时间会显示unknown，微信会尽快进行适配。
            /// </summary>
                public string model;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 允许微信通知带有提醒的开关（仅 iOS 有效）
            /// </summary>
                public bool notificationAlertAuthorized;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 允许微信通知的开关
            /// </summary>
                public bool notificationAuthorized;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 允许微信通知带有标记的开关（仅 iOS 有效）
            /// </summary>
                public bool notificationBadgeAuthorized;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// 允许微信通知带有声音的开关（仅 iOS 有效）
            /// </summary>
                public bool notificationSoundAuthorized;
            /// <summary> 
            /// 需要基础库： `2.19.3`
            /// 允许微信使用日历的开关
            /// </summary>
                public bool phoneCalendarAuthorized;
            /// <summary> 
            /// 设备像素比
            /// </summary>
                public double pixelRatio;
            /// <summary> 
            /// 客户端平台
            /// </summary>
                public string platform;
            /// <summary> 
            /// 需要基础库： `2.7.0`
            /// 在竖屏正方向下的安全区域
            /// </summary>
                public SafeArea safeArea;
            /// <summary> 
            /// 需要基础库： `1.1.0`
            /// 屏幕高度，单位px
            /// </summary>
                public double screenHeight;
            /// <summary> 
            /// 需要基础库： `1.1.0`
            /// 屏幕宽度，单位px
            /// </summary>
                public double screenWidth;
            /// <summary> 
            /// 需要基础库： `1.9.0`
            /// 状态栏的高度，单位px
            /// </summary>
                public double statusBarHeight;
            /// <summary> 
            /// 操作系统及版本
            /// </summary>
                public string system;
            /// <summary> 
            /// 微信版本号
            /// </summary>
                public string version;
            /// <summary> 
            /// 需要基础库： `2.6.0`
            /// Wi-Fi 的系统开关
            /// </summary>
                public bool wifiEnabled;
            /// <summary> 
            /// 可使用窗口高度，单位px
            /// </summary>
                public double windowHeight;
            /// <summary> 
            /// 可使用窗口宽度，单位px
            /// </summary>
                public double windowWidth;
            /// <summary> 
            /// 需要基础库： `2.11.0`
            /// 系统当前主题，取值为`light`或`dark`，全局配置`"darkmode":true`时才能获取，否则为 undefined （不支持小游戏）
            /// 可选值：
            /// - 'dark': 深色主题;
            /// - 'light': 浅色主题;
            /// </summary>
                public string theme;
    }
    [Preserve]
    public class Host {
            /// <summary> 
            /// 宿主 app 对应的 appId
            /// </summary>
                public string appId;
    }
    [Preserve]
    public class SafeArea {
            /// <summary> 
            /// 安全区域右下角纵坐标
            /// </summary>
                public double bottom;
            /// <summary> 
            /// 安全区域的高度，单位逻辑像素
            /// </summary>
                public double height;
            /// <summary> 
            /// 安全区域左上角横坐标
            /// </summary>
                public double left;
            /// <summary> 
            /// 安全区域右下角横坐标
            /// </summary>
                public double right;
            /// <summary> 
            /// 安全区域左上角纵坐标
            /// </summary>
                public double top;
            /// <summary> 
            /// 安全区域的宽度，单位逻辑像素
            /// </summary>
                public double width;
    }
    [Preserve]
    public class OnCheckForUpdateCallbackResult {
            /// <summary> 
            /// 是否有新版本
            /// </summary>
                public bool hasUpdate;
    }
    [Preserve]
    public class GeneralCallbackResult {
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
    }
    [Preserve]
    public class SetMessageToFriendQueryOption {
            /// <summary> 
            /// 需要传递的代表场景的数字，需要在 0 - 50 之间
            /// </summary>
                public double shareMessageToFriendScene;
    }
    [Preserve]
    public class GetTextLineHeightOption {
            /// <summary> 
            /// 字体名称
            /// </summary>
                public string fontFamily;
            /// <summary> 
            /// 文本的内容
            /// </summary>
                public string text;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 字号
            /// </summary>
                public double fontSize;
            /// <summary> 
            /// 字体样式
            /// 可选值：
            /// - 'normal': 正常;
            /// - 'italic': 斜体;
            /// </summary>
                public string fontStyle;
            /// <summary> 
            /// 字重
            /// 可选值：
            /// - 'normal': 正常;
            /// - 'bold': 粗体;
            /// </summary>
                public string fontWeight;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class AddCardOption {
            /// <summary> 
            /// 需要添加的卡券列表
            /// </summary>
                public AddCardRequestInfo[] cardList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<AddCardSuccessCallbackResult> success;
    }
    [Preserve]
    public class AddCardRequestInfo {
            /// <summary> 
            /// 卡券的扩展参数。需将 CardExt 对象 JSON 序列化为**字符串**传入
            /// </summary>
                public string cardExt;
            /// <summary> 
            /// 卡券 ID
            /// </summary>
                public string cardId;
    }
    [Preserve]
    public class AddCardSuccessCallbackResult {
            /// <summary> 
            /// 卡券添加结果列表
            /// </summary>
                public AddCardResponseInfo[] cardList;

                public string errMsg;
    }
    [Preserve]
    public class AddCardResponseInfo {
            /// <summary> 
            /// 卡券的扩展参数，结构请参考下文
            /// </summary>
                public string cardExt;
            /// <summary> 
            /// 用户领取到卡券的 ID
            /// </summary>
                public string cardId;
            /// <summary> 
            /// 加密 code，为用户领取到卡券的code加密后的字符串，解密请参照：[code 解码接口](https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1499332673_Unm7V)
            /// </summary>
                public string code;
            /// <summary> 
            /// 是否成功
            /// </summary>
                public bool isSuccess;
    }
    [Preserve]
    public class AuthPrivateMessageOption {
            /// <summary> 
            /// shareTicket。可以从 wx.onShow 中获取。详情 [shareTicket](#)
            /// </summary>
                public string shareTicket;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<AuthPrivateMessageSuccessCallbackResult> success;
    }
    [Preserve]
    public class AuthPrivateMessageSuccessCallbackResult {
            /// <summary> 
            /// 经过加密的activityId，解密后可得到原始的activityId。若解密后得到的activityId可以与开发者后台的活动id对应上则验证通过，否则表明valid字段不可靠（被篡改） 详细见[加密数据解密算法](https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/signature.html)
            /// </summary>
                public string encryptedData;
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 加密算法的初始向量，详细见[加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html)
            /// </summary>
                public string iv;
            /// <summary> 
            /// 验证是否通过
            /// </summary>
                public bool valid;
    }
    [Preserve]
    public class AuthorizeOption {
            /// <summary> 
            /// 需要获取权限的 scope，详见 [scope 列表](https://developers.weixin.qq.com/minigame/dev/guide/framework/authorize.html#scope-列表)
            /// </summary>
                public string scope;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class CheckHandoffEnabledOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<CheckHandoffEnabledSuccessCallbackResult> success;
    }
    [Preserve]
    public class CheckHandoffEnabledSuccessCallbackResult {
            /// <summary> 
            /// 错误码，0未知，1用户取消，2电脑未登录，3电脑版本过低，4暂未支持
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 是否可以进行接力
            /// </summary>
                public bool isEnabled;

                public string errMsg;
    }
    [Preserve]
    public class CheckIsUserAdvisedToRestOption {
            /// <summary> 
            /// 今天已经玩游戏的时间，单位：秒
            /// </summary>
                public double todayPlayedTime;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<CheckIsUserAdvisedToRestSuccessCallbackResult> success;
    }
    [Preserve]
    public class CheckIsUserAdvisedToRestSuccessCallbackResult {
            /// <summary> 
            /// 是否建议用户休息
            /// </summary>
                public bool result;

                public string errMsg;
    }
    [Preserve]
    public class CheckSessionOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ChooseImageOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 最多可以选择的图片张数
            /// </summary>
                public double count;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 所选的图片的尺寸
            /// 可选值：
            /// - 'original': 原图;
            /// - 'compressed': 压缩图;
            /// </summary>
                public Array sizeType;
            /// <summary> 
            /// 选择图片的来源
            /// 可选值：
            /// - 'album': 从相册选图;
            /// - 'camera': 使用相机;
            /// </summary>
                public Array sourceType;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<ChooseImageSuccessCallbackResult> success;
    }
    [Preserve]
    public class ChooseImageSuccessCallbackResult {
            /// <summary> 
            /// 图片的本地临时文件路径列表 (本地路径)
            /// </summary>
                public string[] tempFilePaths;
            /// <summary> 
            /// 需要基础库： `1.2.0`
            /// 图片的本地临时文件列表
            /// </summary>
                public ImageFile[] tempFiles;

                public string errMsg;
    }
    [Preserve]
    public class ImageFile {
            /// <summary> 
            /// 本地临时文件路径 (本地路径)
            /// </summary>
                public string path;
            /// <summary> 
            /// 本地临时文件大小，单位 B
            /// </summary>
                public double size;
    }
    [Preserve]
    public class CloseBLEConnectionOption {
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
    }
    [Preserve]
    public class BluetoothError {
            /// <summary> 
            /// 错误信息
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | 0 | ok | 正常 |
            /// | -1 | already connect | 已连接 |
            /// | 10000 | not init | 未初始化蓝牙适配器 |
            /// | 10001 | not available | 当前蓝牙适配器不可用 |
            /// | 10002 | no device | 没有找到指定设备 |
            /// | 10003 | connection fail | 连接失败 |
            /// | 10004 | no service | 没有找到指定服务 |
            /// | 10005 | no characteristic | 没有找到指定特征 |
            /// | 10006 | no connection | 当前连接已断开 |
            /// | 10007 | property not support | 当前特征不支持此操作 |
            /// | 10008 | system error | 其余所有系统上报的异常 |
            /// | 10009 | system not support | Android 系统特有，系统版本低于 4.3 不支持 BLE |
            /// | 10012 | operate time out | 连接超时 |
            /// | 10013 | invalid_data | 连接 deviceId 为空或者是格式不正确 |
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 错误码
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | 0 | ok | 正常 |
            /// | -1 | already connect | 已连接 |
            /// | 10000 | not init | 未初始化蓝牙适配器 |
            /// | 10001 | not available | 当前蓝牙适配器不可用 |
            /// | 10002 | no device | 没有找到指定设备 |
            /// | 10003 | connection fail | 连接失败 |
            /// | 10004 | no service | 没有找到指定服务 |
            /// | 10005 | no characteristic | 没有找到指定特征 |
            /// | 10006 | no connection | 当前连接已断开 |
            /// | 10007 | property not support | 当前特征不支持此操作 |
            /// | 10008 | system error | 其余所有系统上报的异常 |
            /// | 10009 | system not support | Android 系统特有，系统版本低于 4.3 不支持 BLE |
            /// | 10012 | operate time out | 连接超时 |
            /// | 10013 | invalid_data | 连接 deviceId 为空或者是格式不正确 |
            /// </summary>
                public double errCode;
    }
    [Preserve]
    public class CloseBluetoothAdapterOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
    }
    [Preserve]
    public class CloseSocketOption {
            /// <summary> 
            /// 一个数字值表示关闭连接的状态号，表示连接被关闭的原因。
            /// </summary>
                public double code;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 一个可读的字符串，表示连接被关闭的原因。这个字符串必须是不长于 123 字节的 UTF-8 文本（不是字符）。
            /// </summary>
                public string reason;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class CreateBLEConnectionOption {
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
            /// <summary> 
            /// 超时时间，单位 ms，不填表示不会超时
            /// </summary>
                public double timeout;
    }
    [Preserve]
    public class CreateBLEPeripheralServerOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<CreateBLEPeripheralServerSuccessCallbackResult> success;
    }
    [Preserve]
    public class CreateBLEPeripheralServerSuccessCallbackResult {
            /// <summary> 
            /// [BLEPeripheralServer](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.html)
            /// 外围设备的服务端。
            /// </summary>
                public BLEPeripheralServer server;

                public string errMsg;
    }
    [Preserve]
    public class BLEPeripheralServer {
            /// <summary> 
            /// [BLEPeripheralServer.addService(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.addService.html)
            /// 需要基础库： `2.10.3`
            /// 添加服务。
            /// </summary>
                public void addService(AddServiceOption option){}
            /// <summary> 
            /// [BLEPeripheralServer.offCharacteristicReadRequest(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.offCharacteristicReadRequest.html)
            /// 需要基础库： `2.10.3`
            /// 取消监听已连接的设备请求读当前外围设备的特征值事件
            /// </summary>
                public void offCharacteristicReadRequest(Action<OnCharacteristicReadRequestCallbackResult> callback){}
            /// <summary> 
            /// [BLEPeripheralServer.offCharacteristicSubscribed(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.offCharacteristicSubscribed.html)
            /// 需要基础库： `2.13.0`
            /// 取消监听特征订阅事件
            /// </summary>
                public void offCharacteristicSubscribed(Action<OnCharacteristicSubscribedCallbackResult> callback){}
            /// <summary> 
            /// [BLEPeripheralServer.offCharacteristicUnsubscribed(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.offCharacteristicUnsubscribed.html)
            /// 需要基础库： `2.13.0`
            /// 取消监听取消特征订阅事件
            /// </summary>
                public void offCharacteristicUnsubscribed(Action<OnCharacteristicSubscribedCallbackResult> callback){}
            /// <summary> 
            /// [BLEPeripheralServer.offCharacteristicWriteRequest(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.offCharacteristicWriteRequest.html)
            /// 需要基础库： `2.10.3`
            /// 取消监听已连接的设备请求写当前外围设备的特征值事件
            /// </summary>
                public void offCharacteristicWriteRequest(Action<OnCharacteristicWriteRequestCallbackResult> callback){}
            /// <summary> 
            /// [BLEPeripheralServer.onCharacteristicReadRequest(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.onCharacteristicReadRequest.html)
            /// 需要基础库： `2.10.3`
            /// 监听已连接的设备请求读当前外围设备的特征值事件。收到该消息后需要立刻调用 [writeCharacteristicValue](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.writeCharacteristicValue.html) 写回数据，否则主机不会收到响应。
            /// </summary>
                public void onCharacteristicReadRequest(Action<OnCharacteristicReadRequestCallbackResult> callback){}
            /// <summary> 
            /// [BLEPeripheralServer.onCharacteristicSubscribed(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.onCharacteristicSubscribed.html)
            /// 需要基础库： `2.13.0`
            /// 监听特征订阅事件，仅 iOS 支持。
            /// </summary>
                public void onCharacteristicSubscribed(Action<OnCharacteristicSubscribedCallbackResult> callback){}
            /// <summary> 
            /// [BLEPeripheralServer.onCharacteristicUnsubscribed(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.onCharacteristicUnsubscribed.html)
            /// 需要基础库： `2.13.0`
            /// 监听取消特征订阅事件，仅 iOS 支持。
            /// </summary>
                public void onCharacteristicUnsubscribed(Action<OnCharacteristicSubscribedCallbackResult> callback){}
            /// <summary> 
            /// [BLEPeripheralServer.onCharacteristicWriteRequest(function callback)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.onCharacteristicWriteRequest.html)
            /// 需要基础库： `2.10.3`
            /// 监听已连接的设备请求写当前外围设备的特征值事件。收到该消息后需要立刻调用 [writeCharacteristicValue](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.writeCharacteristicValue.html) 写回数据，否则主机不会收到响应。
            /// </summary>
                public void onCharacteristicWriteRequest(Action<OnCharacteristicWriteRequestCallbackResult> callback){}
            /// <summary> 
            /// [BLEPeripheralServer.removeService(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.removeService.html)
            /// 需要基础库： `2.10.3`
            /// 移除服务。
            /// </summary>
                public void removeService(RemoveServiceOption option){}
            /// <summary> 
            /// [BLEPeripheralServer.startAdvertising(Object Object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.startAdvertising.html)
            /// 需要基础库： `2.10.3`
            /// 开始广播本地创建的外围设备。
            /// **注意**
            /// - Android 8.0.9 开始，支持直接使用 16/32/128 位 UUID；
            /// - Android 8.0.9 以下版本只支持 128 位 UUID，使用 16/32 位的 UUID 时需要进行补位（系统会自动识别是否属于预分配区间），可以参考[蓝牙指南](#)；
            /// - iOS 必须直接使用 16 位的 UUID，不能补位到 128 位，否则系统组包时仍会按照 128 位传输。iOS 暂不支持 32 位 UUID。
            /// - iOS 同时只能发起一个广播，安卓支持同时发起多个广播。
            /// - 传 beacon 参数时，不能同时传入 deviceName，serviceUuids，manufacturerData 参数。
            /// </summary>
                public void startAdvertising(StartAdvertisingObject Object){}
            /// <summary> 
            /// [BLEPeripheralServer.stopAdvertising(Object object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.stopAdvertising.html)
            /// 需要基础库： `2.10.3`
            /// 停止广播。
            /// </summary>
                public void stopAdvertising(StopAdvertisingOption option){}
            /// <summary> 
            /// [BLEPeripheralServer.writeCharacteristicValue(Object Object)](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.writeCharacteristicValue.html)
            /// 需要基础库： `2.10.3`
            /// 往指定特征写入二进制数据值，并通知已连接的主机，从机的特征值已发生变化，该接口会处理是走回包还是走订阅。
            /// </summary>
                public void writeCharacteristicValue(WriteCharacteristicValueObject Object){}
    }
    [Preserve]
    public class AddServiceOption {
            /// <summary> 
            /// 描述service的Object
            /// </summary>
                public BLEPeripheralService service;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class BLEPeripheralService {
            /// <summary> 
            /// characteristics列表
            /// </summary>
                public Characteristic[] characteristics;
            /// <summary> 
            /// 蓝牙服务的 UUID
            /// </summary>
                public string uuid;
    }
    [Preserve]
    public class Characteristic {
            /// <summary> 
            /// characteristic 的 UUID
            /// </summary>
                public string uuid;
            /// <summary> 
            /// 描述符数据
            /// </summary>
                public Descriptor[] descriptors;
            /// <summary> 
            /// 特征权限
            /// </summary>
                public CharacteristicPermission permission;
            /// <summary> 
            /// 特征支持的操作
            /// </summary>
                public CharacteristicProperties properties;
            /// <summary> 
            /// 特征对应的二进制值
            /// </summary>
                public byte[] value;
    }
    [Preserve]
    public class Descriptor {
            /// <summary> 
            /// Descriptor 的 UUID
            /// </summary>
                public string uuid;
            /// <summary> 
            /// 描述符的权限
            /// </summary>
                public DescriptorPermission permission;
            /// <summary> 
            /// 描述符数据
            /// </summary>
                public byte[] value;
    }
    [Preserve]
    public class DescriptorPermission {
            /// <summary> 
            /// 读
            /// </summary>
                public bool read;
            /// <summary> 
            /// 写
            /// </summary>
                public bool write;
    }
    [Preserve]
    public class CharacteristicPermission {
            /// <summary> 
            /// 加密读请求
            /// </summary>
                public bool readEncryptionRequired;
            /// <summary> 
            /// 可读
            /// </summary>
                public bool readable;
            /// <summary> 
            /// 加密写请求
            /// </summary>
                public bool writeEncryptionRequired;
            /// <summary> 
            /// 可写
            /// </summary>
                public bool writeable;
    }
    [Preserve]
    public class CharacteristicProperties {
            /// <summary> 
            /// 回包
            /// </summary>
                public bool indicate;
            /// <summary> 
            /// 订阅
            /// </summary>
                public bool notify;
            /// <summary> 
            /// 读
            /// </summary>
                public bool read;
            /// <summary> 
            /// 写
            /// </summary>
                public bool write;
            /// <summary> 
            /// 无回复写
            /// </summary>
                public bool writeNoResponse;
    }
    [Preserve]
    public class OnCharacteristicReadRequestCallbackResult {
            /// <summary> 
            /// 唯一标识码，调用 [writeCharacteristicValue](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.writeCharacteristicValue.html) 时使用
            /// </summary>
                public double callbackId;
            /// <summary> 
            /// 蓝牙特征的 UUID
            /// </summary>
                public string characteristicId;
            /// <summary> 
            /// 蓝牙特征对应服务的 UUID
            /// </summary>
                public string serviceId;
    }
    [Preserve]
    public class OnCharacteristicSubscribedCallbackResult {
            /// <summary> 
            /// 蓝牙特征的 UUID
            /// </summary>
                public string characteristicId;
            /// <summary> 
            /// 蓝牙特征对应服务的 UUID
            /// </summary>
                public string serviceId;
    }
    [Preserve]
    public class OnCharacteristicWriteRequestCallbackResult {
            /// <summary> 
            /// 唯一标识码，调用 [writeCharacteristicValue](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-peripheral/BLEPeripheralServer.writeCharacteristicValue.html) 时使用
            /// </summary>
                public double callbackId;
            /// <summary> 
            /// 蓝牙特征的 UUID
            /// </summary>
                public string characteristicId;
            /// <summary> 
            /// 蓝牙特征对应服务的 UUID
            /// </summary>
                public string serviceId;
            /// <summary> 
            /// 请求写入特征的二进制数据值
            /// </summary>
                public byte[] value;
    }
    [Preserve]
    public class RemoveServiceOption {
            /// <summary> 
            /// service 的 UUID
            /// </summary>
                public string serviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StartAdvertisingObject {
            /// <summary> 
            /// 广播自定义参数
            /// </summary>
                public AdvertiseReqObj advertiseRequest;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 广播功率
            /// 可选值：
            /// - 'low': 功率低;
            /// - 'medium': 功率适中;
            /// - 'high': 功率高;
            /// </summary>
                public string powerLevel;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class AdvertiseReqObj {
            /// <summary> 
            /// 需要基础库： `2.20.1`
            /// 以 beacon 设备形式广播的参数。
            /// </summary>
                public BeaconInfoObj beacon;
            /// <summary> 
            /// 当前设备是否可连接
            /// </summary>
                public bool connectable;
            /// <summary> 
            /// 广播中 deviceName 字段，默认为空
            /// </summary>
                public string deviceName;
            /// <summary> 
            /// 广播的制造商信息。仅安卓支持，iOS 因系统限制无法定制。
            /// </summary>
                public ManufacturerData[] manufacturerData;
            /// <summary> 
            /// 要广播的服务 UUID 列表。使用 16/32 位 UUID 时请参考注意事项。
            /// </summary>
                public string[] serviceUuids;
    }
    [Preserve]
    public class BeaconInfoObj {
            /// <summary> 
            /// Beacon 设备的主 ID
            /// </summary>
                public double major;
            /// <summary> 
            /// Beacon 设备的次 ID
            /// </summary>
                public double minor;
            /// <summary> 
            /// Beacon 设备广播的 UUID
            /// </summary>
                public string uuid;
            /// <summary> 
            /// 用于判断距离设备 1 米时 RSSI 大小的参考值
            /// </summary>
                public double measuredPower;
    }
    [Preserve]
    public class ManufacturerData {
            /// <summary> 
            /// 制造商ID，0x 开头的十六进制
            /// </summary>
                public string manufacturerId;
            /// <summary> 
            /// 制造商信息
            /// </summary>
                public byte[] manufacturerSpecificData;
    }
    [Preserve]
    public class StopAdvertisingOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class WriteCharacteristicValueObject {
            /// <summary> 
            /// 蓝牙特征的 UUID
            /// </summary>
                public string characteristicId;
            /// <summary> 
            /// 是否需要通知主机 value 已更新
            /// </summary>
                public bool needNotify;
            /// <summary> 
            /// 蓝牙特征对应服务的 UUID
            /// </summary>
                public string serviceId;
            /// <summary> 
            /// characteristic 对应的二进制值
            /// </summary>
                public byte[] value;
            /// <summary> 
            /// 可选，处理回包时使用
            /// </summary>
                public double callbackId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ExitMiniProgramOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ExitVoIPChatOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class FaceDetectOption {
            /// <summary> 
            /// 图像像素点数据，每四项表示一个像素点的 RGBA
            /// </summary>
                public byte[] frameBuffer;
            /// <summary> 
            /// 图像高度
            /// </summary>
                public double height;
            /// <summary> 
            /// 图像宽度
            /// </summary>
                public double width;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 是否返回当前图像的人脸角度信息
            /// </summary>
                public bool enableAngle;
            /// <summary> 
            /// 是否返回当前图像的人脸的置信度（可表示器官遮挡情况）
            /// </summary>
                public bool enableConf;
            /// <summary> 
            /// 是否返回多张人脸的信息
            /// </summary>
                public bool enableMultiFace;
            /// <summary> 
            /// 是否返回当前图像的人脸（106 个点）
            /// </summary>
                public bool enablePoint;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<FaceDetectSuccessCallbackResult> success;
    }
    [Preserve]
    public class FaceDetectSuccessCallbackResult {
            /// <summary> 
            /// 人脸角度信息，取值范围 [-1, 1]，数值越接近 0 表示越正对摄像头
            /// </summary>
                public FaceAngel angleArray;
            /// <summary> 
            /// 人脸置信度，取值范围 [0, 1]，数值越大置信度越高（遮挡越少）
            /// </summary>
                public FaceConf confArray;
            /// <summary> 
            /// 脸部正方框数值，对象包含 height, weight, originX, originY 四个属性
            /// </summary>
                public Dictionary<string,string> detectRect;
            /// <summary> 
            /// 多人模式（enableMultiFace）下的人脸信息，每个对象包含上述其它属性
            /// </summary>
                public Dictionary<string,string> faceInfo;
            /// <summary> 
            /// 人脸 106 个点位置数组，数组每个对象包含 x 和 y
            /// </summary>
                public Dictionary<string,string> pointArray;
            /// <summary> 
            /// 脸部中心点横坐标，检测不到人脸则为 -1
            /// </summary>
                public double x;
            /// <summary> 
            /// 脸部中心点纵坐标，检测不到人脸则为 -1
            /// </summary>
                public double y;

                public string errMsg;
    }
    [Preserve]
    public class FaceAngel {
            /// <summary> 
            /// 仰俯角（点头）
            /// </summary>
                public double pitch;
            /// <summary> 
            /// 翻滚角（左右倾）
            /// </summary>
                public double roll;
            /// <summary> 
            /// 偏航角（摇头）
            /// </summary>
                public double yaw;
    }
    [Preserve]
    public class FaceConf {
            /// <summary> 
            /// 整体可信度
            /// </summary>
                public double global;
            /// <summary> 
            /// 左眼可信度
            /// </summary>
                public double leftEye;
            /// <summary> 
            /// 嘴巴可信度
            /// </summary>
                public double mouth;
            /// <summary> 
            /// 鼻子可信度
            /// </summary>
                public double nose;
            /// <summary> 
            /// 右眼可信度
            /// </summary>
                public double rightEye;
    }
    [Preserve]
    public class GetAvailableAudioSourcesOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetAvailableAudioSourcesSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetAvailableAudioSourcesSuccessCallbackResult {
            /// <summary> 
            /// 支持的音频输入源列表，可在 [RecorderManager.start()](https://developers.weixin.qq.com/minigame/dev/api/media/recorder/RecorderManager.start.html) 接口中使用。返回值定义参考 https://developer.android.com/reference/kotlin/android/media/MediaRecorder.AudioSource
            /// 可选值：
            /// - 'auto': 自动设置，默认使用手机麦克风，插上耳麦后自动切换使用耳机麦克风，所有平台适用;
            /// - 'buildInMic': 手机麦克风，仅限 iOS;
            /// - 'headsetMic': 耳机麦克风，仅限 iOS;
            /// - 'mic': 麦克风（没插耳麦时是手机麦克风，插耳麦时是耳机麦克风），仅限 Android;
            /// - 'camcorder': 同 mic，适用于录制音视频内容，仅限 Android;
            /// - 'voice_communication': 同 mic，适用于实时沟通，仅限 Android;
            /// - 'voice_recognition': 同 mic，适用于语音识别，仅限 Android;
            /// </summary>
                public Array audioSources;

                public string errMsg;
    }
    [Preserve]
    public class GetBLEDeviceCharacteristicsOption {
            /// <summary> 
            /// 蓝牙设备 id。需要已经通过 [wx.createBLEConnection](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.createBLEConnection.html) 建立连接
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 蓝牙服务 UUID。需要先调用 [wx.getBLEDeviceServices](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.getBLEDeviceServices.html) 获取
            /// </summary>
                public string serviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetBLEDeviceCharacteristicsSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetBLEDeviceCharacteristicsSuccessCallbackResult {
            /// <summary> 
            /// 设备特征列表
            /// </summary>
                public BLECharacteristic[] characteristics;

                public string errMsg;
    }
    [Preserve]
    public class BLECharacteristic {
            /// <summary> 
            /// 该特征支持的操作类型
            /// </summary>
                public BLECharacteristicProperties properties;
            /// <summary> 
            /// 蓝牙设备特征的 UUID
            /// </summary>
                public string uuid;
    }
    [Preserve]
    public class BLECharacteristicProperties {
            /// <summary> 
            /// 该特征是否支持 indicate 操作
            /// </summary>
                public bool indicate;
            /// <summary> 
            /// 该特征是否支持 notify 操作
            /// </summary>
                public bool notify;
            /// <summary> 
            /// 该特征是否支持 read 操作
            /// </summary>
                public bool read;
            /// <summary> 
            /// 该特征是否支持 write 操作
            /// </summary>
                public bool write;
    }
    [Preserve]
    public class GetBLEDeviceRSSIOption {
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetBLEDeviceRSSISuccessCallbackResult> success;
    }
    [Preserve]
    public class GetBLEDeviceRSSISuccessCallbackResult {
            /// <summary> 
            /// 信号强度，单位 dBm
            /// </summary>
                public double RSSI;

                public string errMsg;
    }
    [Preserve]
    public class GetBLEDeviceServicesOption {
            /// <summary> 
            /// 蓝牙设备 id。需要已经通过 [wx.createBLEConnection](https://developers.weixin.qq.com/minigame/dev/api/device/bluetooth-ble/wx.createBLEConnection.html) 建立连接
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetBLEDeviceServicesSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetBLEDeviceServicesSuccessCallbackResult {
            /// <summary> 
            /// 设备服务列表
            /// </summary>
                public BLEService[] services;

                public string errMsg;
    }
    [Preserve]
    public class BLEService {
            /// <summary> 
            /// 该服务是否为主服务
            /// </summary>
                public bool isPrimary;
            /// <summary> 
            /// 蓝牙设备服务的 UUID
            /// </summary>
                public string uuid;
    }
    [Preserve]
    public class GetBLEMTUOption {
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetBLEMTUSuccessCallbackResult> success;
            /// <summary> 
            /// 写模式 （iOS 特有参数）
            /// 可选值：
            /// - 'write': 有回复写;
            /// - 'writeNoResponse': 无回复写;
            /// </summary>
                public string writeType;
    }
    [Preserve]
    public class GetBLEMTUSuccessCallbackResult {
            /// <summary> 
            /// 最大传输单元
            /// </summary>
                public double mtu;

                public string errMsg;
    }
    [Preserve]
    public class GetBatteryInfoOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetBatteryInfoSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetBatteryInfoSuccessCallbackResult {
            /// <summary> 
            /// 是否正在充电中
            /// </summary>
                public bool isCharging;
            /// <summary> 
            /// 设备电量，范围 1 - 100
            /// </summary>
                public double level;

                public string errMsg;
    }
    [Preserve]
    public class GetBeaconsOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BeaconError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BeaconError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetBeaconsSuccessCallbackResult> success;
    }
    [Preserve]
    public class BeaconError {
            /// <summary> 
            /// 错误信息
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | 0 | ok | 正常 |
            /// | 11000 | unsupport | 系统或设备不支持 |
            /// | 11001 | bluetooth service unavailable | 蓝牙服务不可用 |
            /// | 11002 | location service unavailable | 位置服务不可用 |
            /// | 11003 | already start | 已经开始搜索 |
            /// | 11004 | not startBeaconDiscovery | 还未开始搜索 |
            /// | 11005 | system error | 系统错误 |
            /// | 11006 | invalid data | 参数不正确 |
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 错误码
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | 0 | ok | 正常 |
            /// | 11000 | unsupport | 系统或设备不支持 |
            /// | 11001 | bluetooth service unavailable | 蓝牙服务不可用 |
            /// | 11002 | location service unavailable | 位置服务不可用 |
            /// | 11003 | already start | 已经开始搜索 |
            /// | 11004 | not startBeaconDiscovery | 还未开始搜索 |
            /// | 11005 | system error | 系统错误 |
            /// | 11006 | invalid data | 参数不正确 |
            /// </summary>
                public double errCode;
    }
    [Preserve]
    public class GetBeaconsSuccessCallbackResult {
            /// <summary> 
            /// Beacon 设备列表
            /// </summary>
                public BeaconInfo[] beacons;

                public string errMsg;
    }
    [Preserve]
    public class BeaconInfo {
            /// <summary> 
            /// Beacon 设备的距离，单位 m。iOS 上，proximity 为 0 时，accuracy 为 -1。
            /// </summary>
                public double accuracy;
            /// <summary> 
            /// Beacon 设备的主 ID
            /// </summary>
                public double major;
            /// <summary> 
            /// Beacon 设备的次 ID
            /// </summary>
                public double minor;
            /// <summary> 
            /// 表示设备距离的枚举值（仅iOS）
            /// 可选值：
            /// - 0: 信号太弱不足以计算距离，或非 iOS 设备;
            /// - 1: 十分近;
            /// - 2: 比较近;
            /// - 3: 远;
            /// </summary>
                public double proximity;
            /// <summary> 
            /// 表示设备的信号强度，单位 dBm
            /// </summary>
                public double rssi;
            /// <summary> 
            /// Beacon 设备广播的 UUID
            /// </summary>
                public string uuid;
    }
    [Preserve]
    public class GetBluetoothAdapterStateOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetBluetoothAdapterStateSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetBluetoothAdapterStateSuccessCallbackResult {
            /// <summary> 
            /// 蓝牙适配器是否可用
            /// </summary>
                public bool available;
            /// <summary> 
            /// 是否正在搜索设备
            /// </summary>
                public bool discovering;

                public string errMsg;
    }
    [Preserve]
    public class GetBluetoothDevicesOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetBluetoothDevicesSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetBluetoothDevicesSuccessCallbackResult {
            /// <summary> 
            /// UUID 对应的已连接设备列表
            /// </summary>
                public BlueToothDevice[] devices;

                public string errMsg;
    }
    [Preserve]
    public class BlueToothDevice {
            /// <summary> 
            /// 当前蓝牙设备的信号强度，单位 dBm
            /// </summary>
                public double RSSI;
            /// <summary> 
            /// 当前蓝牙设备的广播数据段中的 ManufacturerData 数据段。
            /// </summary>
                public byte[] advertisData;
            /// <summary> 
            /// 当前蓝牙设备的广播数据段中的 ServiceUUIDs 数据段
            /// </summary>
                public string[] advertisServiceUUIDs;
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 当前蓝牙设备的广播数据段中的 LocalName 数据段
            /// </summary>
                public string localName;
            /// <summary> 
            /// 蓝牙设备名称，某些设备可能没有
            /// </summary>
                public string name;
            /// <summary> 
            /// 当前蓝牙设备的广播数据段中的 ServiceData 数据段
            /// </summary>
                public Dictionary<string,string> serviceData;
    }
    [Preserve]
    public class GetChannelsLiveInfoOption {
            /// <summary> 
            /// 视频号 id，以“sph”开头的id，可在视频号助手获取
            /// </summary>
                public string finderUserName;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetChannelsLiveInfoSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetChannelsLiveInfoSuccessCallbackResult {
            /// <summary> 
            /// 直播主题
            /// </summary>
                public string description;
            /// <summary> 
            /// 直播 feedId
            /// </summary>
                public string feedId;
            /// <summary> 
            /// 视频号头像
            /// </summary>
                public string headUrl;
            /// <summary> 
            /// 视频号昵称
            /// </summary>
                public string nickname;
            /// <summary> 
            /// 直播 nonceId
            /// </summary>
                public string nonceId;
            /// <summary> 
            /// 直播状态，2直播中，3直播结束
            /// </summary>
                public double status;

                public string errMsg;
    }
    [Preserve]
    public class GetChannelsLiveNoticeInfoOption {
            /// <summary> 
            /// 视频号 id，以“sph”开头的id，可在视频号助手获取
            /// </summary>
                public string finderUserName;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetChannelsLiveNoticeInfoSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetChannelsLiveNoticeInfoSuccessCallbackResult {
            /// <summary> 
            /// 直播封面
            /// </summary>
                public string headUrl;
            /// <summary> 
            /// 视频号昵称
            /// </summary>
                public string nickname;
            /// <summary> 
            /// 预告 id
            /// </summary>
                public string noticeId;
            /// <summary> 
            /// 是否可预约
            /// </summary>
                public bool reservable;
            /// <summary> 
            /// 开始时间
            /// </summary>
                public string startTime;
            /// <summary> 
            /// 预告状态：0可用 1取消 2已用
            /// </summary>
                public double status;

                public string errMsg;
    }
    [Preserve]
    public class GetClipboardDataOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetClipboardDataSuccessCallbackOption> success;
    }
    [Preserve]
    public class GetClipboardDataSuccessCallbackOption {
            /// <summary> 
            /// 剪贴板的内容
            /// </summary>
                public string data;
    }
    [Preserve]
    public class GetConnectedBluetoothDevicesOption {
            /// <summary> 
            /// 蓝牙设备主服务的 UUID 列表（支持 16/32/128 位 UUID）
            /// </summary>
                public string[] services;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetConnectedBluetoothDevicesSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetConnectedBluetoothDevicesSuccessCallbackResult {
            /// <summary> 
            /// 搜索到的设备列表
            /// </summary>
                public BluetoothDeviceInfo[] devices;

                public string errMsg;
    }
    [Preserve]
    public class BluetoothDeviceInfo {
            /// <summary> 
            /// 用于区分设备的 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 蓝牙设备名称，某些设备可能没有
            /// </summary>
                public string name;
    }
    [Preserve]
    public class GetExtConfigOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetExtConfigSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetExtConfigSuccessCallbackResult {
            /// <summary> 
            /// 第三方平台自定义的数据
            /// </summary>
                public Dictionary<string,string> extConfig;

                public string errMsg;
    }
    [Preserve]
    public class WxGetFileInfoOption {
            /// <summary> 
            /// 本地文件路径 (本地路径)
            /// </summary>
                public string filePath;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 计算文件摘要的算法
            /// 可选值：
            /// - 'md5': md5 算法;
            /// - 'sha1': sha1 算法;
            /// </summary>
                public string digestAlgorithm;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<WxGetFileInfoSuccessCallbackResult> success;
    }
    [Preserve]
    public class WxGetFileInfoSuccessCallbackResult {
            /// <summary> 
            /// 按照传入的 digestAlgorithm 计算得出的的文件摘要
            /// </summary>
                public string digest;
            /// <summary> 
            /// 文件大小，以字节为单位
            /// </summary>
                public double size;

                public string errMsg;
    }
    [Preserve]
    public class GetFriendCloudStorageOption {
            /// <summary> 
            /// 要拉取的 key 列表
            /// </summary>
                public string[] keyList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetFriendCloudStorageSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetFriendCloudStorageSuccessCallbackResult {
            /// <summary> 
            /// 同玩好友的托管数据
            /// </summary>
                public UserGameData[] data;

                public string errMsg;
    }
    [Preserve]
    public class UserGameData {
            /// <summary> 
            /// 用户的托管 KV 数据列表
            /// </summary>
                public KVData[] KVDataList;
            /// <summary> 
            /// 用户的微信头像 url
            /// </summary>
                public string avatarUrl;
            /// <summary> 
            /// 用户的微信昵称
            /// </summary>
                public string nickname;
            /// <summary> 
            /// 用户的 openid
            /// </summary>
                public string openid;
    }
    [Preserve]
    public class KVData {
            /// <summary> 
            /// 数据的 key
            /// </summary>
                public string key;
            /// <summary> 
            /// 数据的 value
            /// </summary>
                public string value;
    }
    [Preserve]
    public class GetGroupCloudStorageOption {
            /// <summary> 
            /// 要拉取的 key 列表
            /// </summary>
                public string[] keyList;
            /// <summary> 
            /// 群分享对应的 shareTicket
            /// </summary>
                public string shareTicket;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetGroupCloudStorageSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetGroupCloudStorageSuccessCallbackResult {
            /// <summary> 
            /// 群同玩成员的托管数据
            /// </summary>
                public UserGameData[] data;

                public string errMsg;
    }
    [Preserve]
    public class GetGroupEnterInfoOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetGroupEnterInfoSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetGroupEnterInfoSuccessCallbackResult {
            /// <summary> 
            /// 需要基础库： `2.7.0`
            /// 敏感数据对应的云 ID，开通[云开发](https://developers.weixin.qq.com/minigame/dev/wxcloud/basis/getting-started.html)的小程序才会返回，可通过云调用直接获取开放数据，详细见[云调用直接获取开放数据](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#method-cloud)
            /// </summary>
                public string cloudID;
            /// <summary> 
            /// 包括敏感数据在内的完整转发信息的加密数据，详细见[加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html)
            /// </summary>
                public string encryptedData;
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 加密算法的初始向量，详细见[加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html)
            /// </summary>
                public string iv;
    }
    [Preserve]
    public class GetGroupInfoOption {
            /// <summary> 
            /// 群 openGId，可通过 `wx.getShareInfo` 获取
            /// </summary>
                public string openGId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetGroupInfoSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetGroupInfoSuccessCallbackResult {
            /// <summary> 
            /// 群名称
            /// </summary>
                public string name;

                public string errMsg;
    }
    [Preserve]
    public class GetLocalIPAddressOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetLocalIPAddressSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetLocalIPAddressSuccessCallbackResult {
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 本机局域网IP地址
            /// </summary>
                public string localip;
    }
    [Preserve]
    public class GetLocationOption {
            /// <summary> 
            /// 需要基础库： `1.6.0`
            /// 传入 true 会返回高度信息，由于获取高度需要较高精确度，会减慢接口返回速度
            /// </summary>
                public bool altitude;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.9.0`
            /// 高精度定位超时时间(ms)，指定时间内返回最高精度，该值3000ms以上高精度定位才有效果
            /// </summary>
                public double highAccuracyExpireTime;
            /// <summary> 
            /// 需要基础库： `2.9.0`
            /// 开启高精度定位
            /// </summary>
                public bool isHighAccuracy;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetLocationSuccessCallbackResult> success;
            /// <summary> 
            /// wgs84 返回 gps 坐标，gcj02 返回可用于 wx.openLocation 的坐标
            /// </summary>
                public string type;
    }
    [Preserve]
    public class GetLocationSuccessCallbackResult {
            /// <summary> 
            /// 位置的精确度，反应与真实位置之间的接近程度，可以理解成10即与真实位置相差10m，越小越精确
            /// </summary>
                public double accuracy;
            /// <summary> 
            /// 需要基础库： `1.2.0`
            /// 高度，单位 m
            /// </summary>
                public double altitude;
            /// <summary> 
            /// 需要基础库： `1.2.0`
            /// 水平精度，单位 m
            /// </summary>
                public double horizontalAccuracy;
            /// <summary> 
            /// 纬度，范围为 -90~90，负数表示南纬
            /// </summary>
                public double latitude;
            /// <summary> 
            /// 经度，范围为 -180~180，负数表示西经
            /// </summary>
                public double longitude;
            /// <summary> 
            /// 速度，单位 m/s
            /// </summary>
                public double speed;
            /// <summary> 
            /// 需要基础库： `1.2.0`
            /// 垂直精度，单位 m（Android 无法获取，返回 0）
            /// </summary>
                public double verticalAccuracy;

                public string errMsg;
    }
    [Preserve]
    public class GetNetworkTypeOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetNetworkTypeSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetNetworkTypeSuccessCallbackResult {
            /// <summary> 
            /// 网络类型
            /// 可选值：
            /// - 'wifi': wifi 网络;
            /// - '2g': 2g 网络;
            /// - '3g': 3g 网络;
            /// - '4g': 4g 网络;
            /// - '5g': 5g 网络;
            /// - 'unknown': Android 下不常见的网络类型;
            /// - 'none': 无网络;
            /// </summary>
                public string networkType;
            /// <summary> 
            /// 信号强弱，单位 dbm
            /// </summary>
                public double signalStrength;

                public string errMsg;
    }
    [Preserve]
    public class GetPotentialFriendListOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetPotentialFriendListSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetPotentialFriendListSuccessCallbackResult {
            /// <summary> 
            /// 可能对游戏感兴趣的未注册好友名单
            /// </summary>
                public FriendInfo[] list;

                public string errMsg;
    }
    [Preserve]
    public class FriendInfo {
            /// <summary> 
            /// 用户的微信头像 url
            /// </summary>
                public string avatarUrl;
            /// <summary> 
            /// 用户的微信昵称
            /// </summary>
                public string nickname;
            /// <summary> 
            /// 用户 openid
            /// </summary>
                public string openid;
    }
    [Preserve]
    public class GetScreenBrightnessOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetScreenBrightnessSuccessCallbackOption> success;
    }
    [Preserve]
    public class GetScreenBrightnessSuccessCallbackOption {
            /// <summary> 
            /// 屏幕亮度值，范围 0 ~ 1，0 最暗，1 最亮
            /// </summary>
                public double value;
    }
    [Preserve]
    public class GetSettingOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetSettingSuccessCallbackResult> success;
            /// <summary> 
            /// 需要基础库： `2.10.1`
            /// 是否同时获取用户订阅消息的订阅状态，默认不获取。注意：withSubscriptions 只返回用户勾选过订阅面板中的“总是保持以上选择，不再询问”的订阅消息。
            /// </summary>
                public bool withSubscriptions;
    }
    [Preserve]
    public class GetSettingSuccessCallbackResult {
            /// <summary> 
            /// [AuthSetting](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/AuthSetting.html)
            /// 用户授权结果
            /// </summary>
                public AuthSetting authSetting;
            /// <summary> 
            /// [SubscriptionsSetting](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/SubscriptionsSetting.html)
            /// 需要基础库： `2.10.1`
            /// 用户订阅消息设置，接口参数`withSubscriptions`值为`true`时才会返回。
            /// </summary>
                public SubscriptionsSetting subscriptionsSetting;
            /// <summary> 
            /// [AuthSetting](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/AuthSetting.html)
            /// 在插件中调用时，当前宿主小程序的用户授权结果
            /// </summary>
                public AuthSetting miniprogramAuthSetting;

                public string errMsg;
    }
    [Preserve]
    public class AuthSetting: Dictionary<string, bool>{
            /// <summary> 
            /// 是否授权使用你的微信朋友信息，对应开放数据域内的 [wx.getFriendCloudStorage](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getFriendCloudStorage.html) 、[wx.getGroupCloudStorage](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getGroupCloudStorage.html) 、[wx.getGroupInfo](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getGroupInfo.html) 、[wx.getPotentialFriendList](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getPotentialFriendList.html) 、[wx.getUserCloudStorageKeys](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getUserCloudStorageKeys.html) 、[wx.getUserInfo](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/OpenDataContext-wx.getUserInfo.html)  、[GameServerManager.getFriendsStateData](https://developers.weixin.qq.com/minigame/dev/api/game-server-manager/GameServerManager.getFriendsStateData.html) 接口，以及主域内的 [wx.getUserInteractiveStorage](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.getUserInteractiveStorage.html) 接口。
            /// </summary>
            /// scope.WxFriendInteraction
            /// <summary> 
            /// 是否授权用户信息，对应接口 [wx.getUserInfo](https://developers.weixin.qq.com/minigame/dev/api/open-api/user-info/wx.getUserInfo.html)
            /// </summary>
            /// scope.userInfo
            /// <summary> 
            /// 是否授权地理位置，对应接口 [wx.getLocation](https://developers.weixin.qq.com/minigame/dev/api/location/wx.getLocation.html)
            /// </summary>
            /// scope.userLocation
            /// <summary> 
            /// 是否授权微信运动步数，对应接口 [wx.getWeRunData](https://developers.weixin.qq.com/minigame/dev/api/open-api/werun/wx.getWeRunData.html)
            /// </summary>
            /// scope.werun
            /// <summary> 
            /// 是否授权保存到相册，对应接口 [wx.saveImageToPhotosAlbum](https://developers.weixin.qq.com/minigame/dev/api/media/image/wx.saveImageToPhotosAlbum.html)
            /// </summary>
            /// scope.writePhotosAlbum
    }
    [Preserve]
    public class SubscriptionsSetting {
            /// <summary> 
            /// 订阅消息总开关，true为开启，false为关闭
            /// </summary>
                public bool mainSwitch;
            /// <summary> 
            /// 每一项订阅消息的订阅状态。itemSettings对象的键为**一次性订阅消息的模板id**或**系统订阅消息的类型**，值为'accept'、'reject'、'ban'中的其中一种。'accept'表示用户同意订阅这条消息，'reject'表示用户拒绝订阅这条消息，'ban'表示已被后台封禁。一次性订阅消息使用方法详见 [wx.requestSubscribeMessage](https://developers.weixin.qq.com/minigame/dev/api/open-api/subscribe-message/wx.requestSubscribeMessage.html)，永久订阅消息（仅小游戏可用）使用方法详见[wx.requestSubscribeSystemMessage](https://developers.weixin.qq.com/minigame/dev/api/open-api/subscribe-message/wx.requestSubscribeSystemMessage.html)
            /// ## 注意事项
            /// - itemSettings 只返回用户勾选过订阅面板中的“总是保持以上选择，不再询问”的订阅消息。
            /// </summary>
                public Dictionary<string,string> itemSettings;
    }
    [Preserve]
    public class GetShareInfoOption {
            /// <summary> 
            /// shareTicket
            /// </summary>
                public string shareTicket;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetGroupEnterInfoSuccessCallbackResult> success;
            /// <summary> 
            /// 需要基础库： `1.9.90`
            /// 超时时间，单位 ms
            /// </summary>
                public double timeout;
    }
    [Preserve]
    public class GetStorageInfoOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetStorageInfoSuccessCallbackOption> success;
    }
    [Preserve]
    public class GetStorageInfoSuccessCallbackOption {
            /// <summary> 
            /// 当前占用的空间大小, 单位 KB
            /// </summary>
                public double currentSize;
            /// <summary> 
            /// 当前 storage 中所有的 key
            /// </summary>
                public string[] keys;
            /// <summary> 
            /// 限制的空间大小，单位 KB
            /// </summary>
                public double limitSize;
    }
    [Preserve]
    public class GetSystemInfoOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<SystemInfo> success;
    }
    [Preserve]
    public class GetSystemInfoAsyncOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<SystemInfo> success;
    }
    [Preserve]
    public class GetUserCloudStorageOption {
            /// <summary> 
            /// 要获取的 key 列表
            /// </summary>
                public string[] keyList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetUserCloudStorageSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetUserCloudStorageSuccessCallbackResult {
            /// <summary> 
            /// 用户托管的 KV 数据列表
            /// </summary>
                public KVData[] KVDataList;

                public string errMsg;
    }
    [Preserve]
    public class GetUserCloudStorageKeysOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetUserCloudStorageKeysSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetUserCloudStorageKeysSuccessCallbackResult {
            /// <summary> 
            /// 用户托管数据当中所有的 key 数组
            /// </summary>
                public string[] keys;

                public string errMsg;
    }
    [Preserve]
    public class GetUserInfoOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 显示用户信息的语言
            /// 可选值：
            /// - 'en': 英文;
            /// - 'zh_CN': 简体中文;
            /// - 'zh_TW': 繁体中文;
            /// </summary>
                public string lang;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetUserInfoSuccessCallbackResult> success;
            /// <summary> 
            /// 是否带上登录态信息。当 withCredentials 为 true 时，要求此前有调用过 wx.login 且登录态尚未过期，此时返回的数据会包含 encryptedData, iv 等敏感信息；当 withCredentials 为 false 时，不要求有登录态，返回的数据不包含 encryptedData, iv 等敏感信息。
            /// </summary>
                public bool withCredentials;
    }
    [Preserve]
    public class GetUserInfoSuccessCallbackResult {
            /// <summary> 
            /// 需要基础库： `2.7.0`
            /// 敏感数据对应的云 ID，开通[云开发](https://developers.weixin.qq.com/minigame/dev/wxcloud/basis/getting-started.html)的小程序才会返回，可通过云调用直接获取开放数据，详细见[云调用直接获取开放数据](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#method-cloud)
            /// </summary>
                public string cloudID;
            /// <summary> 
            /// 包括敏感数据在内的完整用户信息的加密数据，详见 [用户数据的签名验证和加解密](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#加密数据解密算法)
            /// </summary>
                public string encryptedData;
            /// <summary> 
            /// 加密算法的初始向量，详见 [用户数据的签名验证和加解密](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#加密数据解密算法)
            /// </summary>
                public string iv;
            /// <summary> 
            /// 不包括敏感信息的原始数据字符串，用于计算签名
            /// </summary>
                public string rawData;
            /// <summary> 
            /// 使用 sha1( rawData + sessionkey ) 得到字符串，用于校验用户信息，详见 [用户数据的签名验证和加解密](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html)
            /// </summary>
                public string signature;
            /// <summary> 
            /// [UserInfo](https://developers.weixin.qq.com/minigame/dev/api/open-api/user-info/UserInfo.html)
            /// 用户信息对象，不包含 openid 等敏感信息
            /// </summary>
                public UserInfo userInfo;

                public string errMsg;
    }
    [Preserve]
    public class UserInfo {
            /// <summary> 
            /// 用户头像图片的 URL。URL 最后一个数值代表正方形头像大小（有 0、46、64、96、132 数值可选，0 代表 640x640 的正方形头像，46 表示 46x46 的正方形头像，剩余数值以此类推。默认132），用户没有头像时该项为空。若用户更换头像，原有头像 URL 将失效。
            /// </summary>
                public string avatarUrl;
            /// <summary> 
            /// 用户所在城市。不再返回，参考 [相关公告](https://developers.weixin.qq.com/community/develop/doc/00028edbe3c58081e7cc834705b801)
            /// </summary>
                public string city;
            /// <summary> 
            /// 用户所在国家。不再返回，参考 [相关公告](https://developers.weixin.qq.com/community/develop/doc/00028edbe3c58081e7cc834705b801)
            /// </summary>
                public string country;
            /// <summary> 
            /// 用户性别。不再返回，参考 [相关公告](https://developers.weixin.qq.com/community/develop/doc/00028edbe3c58081e7cc834705b801)
            /// 可选值：
            /// - 0: 未知;
            /// - 1: 男性;
            /// - 2: 女性;
            /// </summary>
                public double gender;
            /// <summary> 
            /// 显示 country，province，city 所用的语言。强制返回 “zh_CN”，参考 [相关公告](https://developers.weixin.qq.com/community/develop/doc/00028edbe3c58081e7cc834705b801)
            /// 可选值：
            /// - 'en': 英文;
            /// - 'zh_CN': 简体中文;
            /// - 'zh_TW': 繁体中文;
            /// </summary>
                public string language;
            /// <summary> 
            /// 用户昵称
            /// </summary>
                public string nickName;
            /// <summary> 
            /// 用户所在省份。不再返回，参考 [相关公告](https://developers.weixin.qq.com/community/develop/doc/00028edbe3c58081e7cc834705b801)
            /// </summary>
                public string province;
    }
    [Preserve]
    public class GetUserInteractiveStorageOption {
            /// <summary> 
            /// 要获取的 key 列表
            /// </summary>
                public string[] keyList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GetUserInteractiveStorageFailCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetUserInteractiveStorageSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetUserInteractiveStorageFailCallbackResult {
            /// <summary> 
            /// 错误码
            /// 可选值：
            /// - -17008: 非法的 key;
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
    }
    [Preserve]
    public class GetUserInteractiveStorageSuccessCallbackResult {
            /// <summary> 
            /// 敏感数据对应的云 ID，开通[云开发](https://developers.weixin.qq.com/minigame/dev/wxcloud/basis/getting-started.html)的小程序才会返回，可通过云调用直接获取开放数据，详细见[云调用直接获取开放数据](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#method-cloud)
            /// </summary>
                public string cloudID;
            /// <summary> 
            /// 加密数据，包含互动型托管数据的值。解密后的结果为一个 `KVDataList`，每一项为一个 `KVData`。 [用户数据的签名验证和加解密](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#加密数据解密算法)
            /// </summary>
                public string encryptedData;

                public string errMsg;
            /// <summary> 
            /// 加密算法的初始向量，详见 [用户数据的签名验证和加解密](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#加密数据解密算法)
            /// </summary>
                public string iv;
    }
    [Preserve]
    public class GetWeRunDataOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetWeRunDataSuccessCallbackResult> success;
    }
    [Preserve]
    public class GetWeRunDataSuccessCallbackResult {
            /// <summary> 
            /// 需要基础库： `2.7.0`
            /// 敏感数据对应的云 ID，开通云开发的小程序才会返回，可通过云调用直接获取开放数据，详细见[云调用直接获取开放数据](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#method-cloud)
            /// </summary>
                public string cloudID;
            /// <summary> 
            /// 包括敏感数据在内的完整用户信息的加密数据，详细见[加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html)。解密后得到的数据结构见后文
            /// </summary>
                public string encryptedData;
            /// <summary> 
            /// 加密算法的初始向量，详细见[加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html)
            /// </summary>
                public string iv;

                public string errMsg;
    }
    [Preserve]
    public class HideKeyboardOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class HideLoadingOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class HideShareMenuOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.11.3`
            /// 本接口为 Beta 版本，暂只在 Android 平台支持。需要隐藏的转发按钮名称列表，默认['shareAppMessage', 'shareTimeline']。按钮名称合法值包含 "shareAppMessage"、"shareTimeline" 两种
            /// </summary>
                public string[] menus;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class HideToastOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class InitFaceDetectOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class IsBluetoothDevicePairedOption {
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class JoinVoIPChatOption {
            /// <summary> 
            /// 小游戏内此房间/群聊的 ID。同一时刻传入相同 groupId 的用户会进入到同个实时语音房间。
            /// </summary>
                public string groupId;
            /// <summary> 
            /// 验证所需的随机字符串
            /// </summary>
                public string nonceStr;
            /// <summary> 
            /// 签名，用于验证小游戏的身份
            /// </summary>
                public string signature;
            /// <summary> 
            /// 验证所需的时间戳
            /// </summary>
                public long timeStamp;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<JoinVoIPChatError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<JoinVoIPChatError> fail;
            /// <summary> 
            /// 静音设置
            /// </summary>
                public MuteConfig muteConfig;
            /// <summary> 
            /// 房间类型
            /// 可选值：
            /// - 'voice': 音频房间，用于语音通话;
            /// - 'video': 视频房间，结合 [voip-room](#) 组件可显示成员画面;
            /// </summary>
                public string roomType;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<JoinVoIPChatSuccessCallbackResult> success;
    }
    [Preserve]
    public class JoinVoIPChatError {
            /// <summary> 
            /// 错误信息
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | -1 | 当前已在房间内 |  |
            /// | -2 | 录音设备被占用，可能是当前正在使用微信内语音通话或系统通话 |  |
            /// | -3 | 加入会话期间退出（可能是用户主动退出，或者退后台、来电等原因），因此加入失败 |  |
            /// | -1000 | 系统错误 |  |
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 错误码
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | -1 | 当前已在房间内 |  |
            /// | -2 | 录音设备被占用，可能是当前正在使用微信内语音通话或系统通话 |  |
            /// | -3 | 加入会话期间退出（可能是用户主动退出，或者退后台、来电等原因），因此加入失败 |  |
            /// | -1000 | 系统错误 |  |
            /// </summary>
                public double errCode;
    }
    [Preserve]
    public class MuteConfig {
            /// <summary> 
            /// 是否静音耳机
            /// </summary>
                public bool muteEarphone;
            /// <summary> 
            /// 是否静音麦克风
            /// </summary>
                public bool muteMicrophone;
    }
    [Preserve]
    public class JoinVoIPChatSuccessCallbackResult {
            /// <summary> 
            /// 错误码
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 调用结果
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 在此通话中的成员 openId 名单
            /// </summary>
                public string[] openIdList;
    }
    [Preserve]
    public class LoginOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<LoginSuccessCallbackResult> success;
            /// <summary> 
            /// 需要基础库： `1.9.90`
            /// 超时时间，单位ms
            /// </summary>
                public double timeout;
    }
    [Preserve]
    public class LoginSuccessCallbackResult {
            /// <summary> 
            /// 用户登录凭证（有效期五分钟）。开发者需要在开发者服务器后台调用 [auth.code2Session](https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/login/auth.code2Session.html)，使用 code 换取 openid、unionid、session_key 等信息
            /// </summary>
                public string code;

                public string errMsg;
    }
    [Preserve]
    public class MakeBluetoothPairOption {
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// pin 码，Base64 格式。
            /// </summary>
                public string pin;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
            /// <summary> 
            /// 超时时间，单位 ms
            /// </summary>
                public double timeout;
    }
    [Preserve]
    public class ModifyFriendInteractiveStorageOption {
            /// <summary> 
            /// 需要修改的数据的 key，目前可以为 '1' - '50'
            /// </summary>
                public string key;
            /// <summary> 
            /// 需要修改的数值，目前只能为 1
            /// </summary>
                public double opNum;
            /// <summary> 
            /// 修改类型
            /// 可选值：
            /// - 'add': 加;
            /// </summary>
                public string operation;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<ModifyFriendInteractiveStorageFailCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.9.0`
            /// 分享图片地址，详见 wx.shareMessageToFriend 同名参数（需要配置模板规则）
            /// </summary>
                public string imageUrl;
            /// <summary> 
            /// 需要基础库： `2.9.0`
            /// 分享图片 ID，详见 wx.shareMessageToFriend 同名参数（需要配置模板规则）
            /// </summary>
                public string imageUrlId;
            /// <summary> 
            /// 需要基础库： `2.9.0`
            /// 是否静默修改（不弹框）。当进入场景是好友 [定向分享](https://developers.weixin.qq.com/minigame/dev/api/open-api/data/wx.shareMessageToFriend.html) 的卡片时有效，代表分享反馈操作，此时 `toUser` 默认为原分享者的 openId
            /// </summary>
                public bool quiet;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
            /// <summary> 
            /// 需要基础库： `2.9.0`
            /// 分享标题，如果设置了这个值，则在交互成功后自动询问用户是否分享给好友（需要配置模板规则）
            /// </summary>
                public string title;
            /// <summary> 
            /// 目标好友的 openId
            /// </summary>
                public string toUser;
    }
    [Preserve]
    public class ModifyFriendInteractiveStorageFailCallbackResult {
            /// <summary> 
            /// 错误码
            /// 可选值：
            /// - -17006: 非好友关系;
            /// - -17007: 非法的 toUser openId;
            /// - -17008: 非法的 key;
            /// - -17009: 非法的 operation;
            /// - -17010: 非法的操作数;
            /// - -17011: JSServer 校验写操作失败;
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
    }
    [Preserve]
    public class NavigateToMiniProgramOption {
            /// <summary> 
            /// 要打开的小程序 appId
            /// </summary>
                public string appId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 要打开的小程序版本。仅在当前小程序为开发版或体验版时此参数有效。如果当前小程序是正式版，则打开的小程序必定是正式版。
            /// 可选值：
            /// - 'develop': 开发版;
            /// - 'trial': 体验版;
            /// - 'release': 正式版;
            /// </summary>
                public string envVersion;
            /// <summary> 
            /// 需要传递给目标小程序的数据，目标小程序可在 `App.onLaunch`，`App.onShow` 中获取到这份数据。如果跳转的是小游戏，可以在 [wx.onShow](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html)、[wx.getLaunchOptionsSync](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.getLaunchOptionsSync.html) 中可以获取到这份数据数据。
            /// </summary>
                public Dictionary<string,string> extraData;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 打开的页面路径，如果为空则打开首页。path 中 ? 后面的部分会成为 query，在小程序的 `App.onLaunch`、`App.onShow` 和 `Page.onLoad` 的回调函数或小游戏的 [wx.onShow](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html) 回调函数、[wx.getLaunchOptionsSync](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.getLaunchOptionsSync.html) 中可以获取到 query 数据。对于小游戏，可以只传入 query 部分，来实现传参效果，如：传入 "?foo=bar"。
            /// </summary>
                public string path;
            /// <summary> 
            /// 需要基础库： `2.18.1`
            /// 小程序链接，当传递该参数后，可以不传 appId 和 path。链接可以通过【小程序菜单】->【复制链接】获取。
            /// </summary>
                public string shortLink;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class NotifyBLECharacteristicValueChangeOption {
            /// <summary> 
            /// 蓝牙特征的 UUID
            /// </summary>
                public string characteristicId;
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 蓝牙特征对应服务的 UUID
            /// </summary>
                public string serviceId;
            /// <summary> 
            /// 是否启用 notify
            /// </summary>
                public bool state;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
            /// <summary> 
            /// 需要基础库： `2.4.0`
            /// 设置特征订阅类型，有效值有 `notification` 和 `indication`
            /// </summary>
                public string type;
    }
    [Preserve]
    public class OnAccelerometerChangeCallbackResult {
            /// <summary> 
            /// X 轴
            /// </summary>
                public double x;
            /// <summary> 
            /// Y 轴
            /// </summary>
                public double y;
            /// <summary> 
            /// Z 轴
            /// </summary>
                public double z;
    }
    [Preserve]
    public class OnAddToFavoritesCallbackResult {
            /// <summary> 
            /// 禁止收藏后长按转发，默认 false
            /// </summary>
                public bool disableForward;
            /// <summary> 
            /// 转发显示图片的链接，可以是网络图片路径或本地图片文件路径或相对代码包根目录的图片文件路径。显示图片长宽比是 5:4
            /// </summary>
                public string imageUrl;
            /// <summary> 
            /// 查询字符串，必须是 key1=val1&key2=val2 的格式。从收藏进入后，可通过 wx.getLaunchOptionsSync() 或 wx.onShow() 获取启动参数中的 query。
            /// </summary>
                public string query;
            /// <summary> 
            /// 收藏标题，不传则默认使用当前小游戏的昵称。
            /// </summary>
                public string title;
    }
    [Preserve]
    public class OnBLECharacteristicValueChangeCallbackResult {
            /// <summary> 
            /// 蓝牙特征的 UUID
            /// </summary>
                public string characteristicId;
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 蓝牙特征对应服务的 UUID
            /// </summary>
                public string serviceId;
            /// <summary> 
            /// 特征最新的值
            /// </summary>
                public byte[] value;
    }
    [Preserve]
    public class OnBLEConnectionStateChangeCallbackResult {
            /// <summary> 
            /// 是否处于已连接状态
            /// </summary>
                public bool connected;
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
    }
    [Preserve]
    public class OnBLEMTUChangeCallbackResult {
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 最大传输单元
            /// </summary>
                public double mtu;
    }
    [Preserve]
    public class OnBLEPeripheralConnectionStateChangedCallbackResult {
            /// <summary> 
            /// 连接目前状态
            /// </summary>
                public bool connected;
            /// <summary> 
            /// 连接状态变化的设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// server 的 UUID
            /// </summary>
                public string serverId;
    }
    [Preserve]
    public class OnBeaconServiceChangeCallbackResult {
            /// <summary> 
            /// 服务目前是否可用
            /// </summary>
                public bool available;
            /// <summary> 
            /// 目前是否处于搜索状态
            /// </summary>
                public bool discovering;
    }
    [Preserve]
    public class OnBeaconUpdateCallbackResult {
            /// <summary> 
            /// 当前搜寻到的所有 Beacon 设备列表
            /// </summary>
                public BeaconInfo[] beacons;
    }
    [Preserve]
    public class OnBluetoothAdapterStateChangeCallbackResult {
            /// <summary> 
            /// 蓝牙适配器是否可用
            /// </summary>
                public bool available;
            /// <summary> 
            /// 蓝牙适配器是否处于搜索状态
            /// </summary>
                public bool discovering;
    }
    [Preserve]
    public class OnBluetoothDeviceFoundCallbackResult {
            /// <summary> 
            /// 新搜索到的设备列表
            /// </summary>
                public BlueToothDevice[] devices;
    }
    [Preserve]
    public class OnCompassChangeCallbackResult {
            /// <summary> 
            /// 需要基础库： `2.4.0`
            /// 精度
            /// </summary>
                public double accuracy;
            /// <summary> 
            /// 面对的方向度数
            /// </summary>
                public double direction;
    }
    [Preserve]
    public class OnCopyUrlCallbackResult {
            /// <summary> 
            /// 用短链打开小程序时当前页面携带的查询字符串。小程序中使用时，应在进入页面时调用 `wx.onCopyUrl` 自定义 `query`，退出页面时调用 `wx.offCopyUrl`，防止影响其它页面。
            /// </summary>
                public string query;
    }
    [Preserve]
    public class OnDeviceMotionChangeCallbackResult {
            /// <summary> 
            /// 当 手机坐标 X/Y 和 地球 X/Y 重合时，绕着 Z 轴转动的夹角为 alpha，范围值为 [0, 2*PI)。逆时针转动为正。
            /// </summary>
                public double alpha;
            /// <summary> 
            /// 当手机坐标 Y/Z 和地球 Y/Z 重合时，绕着 X 轴转动的夹角为 beta。范围值为 [-1*PI, PI) 。顶部朝着地球表面转动为正。也有可能朝着用户为正。
            /// </summary>
                public double beta;
            /// <summary> 
            /// 当手机 X/Z 和地球 X/Z 重合时，绕着 Y 轴转动的夹角为 gamma。范围值为 [-1*PI/2, PI/2)。右边朝着地球表面转动为正。
            /// </summary>
                public double gamma;
    }
    [Preserve]
    public class OnDeviceOrientationChangeCallbackResult {
            /// <summary> 
            /// 表示切换后的屏幕是横屏还是竖屏
            /// 可选值：
            /// - 'portrait': 竖屏;
            /// - 'landscape': 横屏正方向，以 HOME 键在屏幕右侧为正方向;
            /// - 'landscapeReverse': 横屏反方向，以 HOME 键在屏幕左侧为反方向;
            /// </summary>
                public string value;
    }
    [Preserve]
    public class WxOnErrorCallbackResult {
            /// <summary> 
            /// 错误
            /// </summary>
                public string message;
            /// <summary> 
            /// 错误调用堆栈
            /// </summary>
                public string stack;
    }
    [Preserve]
    public class OnGyroscopeChangeCallbackResult {
            /// <summary> 
            /// x 轴的角速度
            /// </summary>
                public double x;
            /// <summary> 
            /// y 轴的角速度
            /// </summary>
                public double y;
            /// <summary> 
            /// z 轴的角速度
            /// </summary>
                public double z;
    }
    [Preserve]
    public class OnHandoffCallbackResult {
            /// <summary> 
            /// 需要传递给接力客户端的 query
            /// </summary>
                public string query;
    }
    [Preserve]
    public class OnKeyDownCallbackResult {
            /// <summary> 
            /// 同 Web 规范 KeyEvent code 属性
            /// </summary>
                public string code;
            /// <summary> 
            /// 同 Web 规范 KeyEvent key 属性
            /// </summary>
                public string key;
            /// <summary> 
            /// 事件触发时的时间戳
            /// </summary>
                public long timeStamp;
    }
    [Preserve]
    public class OnKeyboardInputCallbackResult {
            /// <summary> 
            /// 键盘输入的当前值
            /// </summary>
                public string value;
    }
    [Preserve]
    public class OnKeyboardHeightChangeCallbackResult {
            /// <summary> 
            /// 键盘高度
            /// </summary>
                public double height;
    }
    [Preserve]
    public class OnMemoryWarningCallbackResult {
            /// <summary> 
            /// 内存告警等级，只有 Android 才有，对应系统宏定义
            /// 可选值：
            /// - 5: TRIM_MEMORY_RUNNING_MODERATE;
            /// - 10: TRIM_MEMORY_RUNNING_LOW;
            /// - 15: TRIM_MEMORY_RUNNING_CRITICAL;
            /// </summary>
                public double level;
    }
    [Preserve]
    public class OnNetworkStatusChangeCallbackResult {
            /// <summary> 
            /// 当前是否有网络连接
            /// </summary>
                public bool isConnected;
            /// <summary> 
            /// 网络类型
            /// 可选值：
            /// - 'wifi': wifi 网络;
            /// - '2g': 2g 网络;
            /// - '3g': 3g 网络;
            /// - '4g': 4g 网络;
            /// - 'unknown': Android 下不常见的网络类型;
            /// - 'none': 无网络;
            /// </summary>
                public string networkType;
    }
    [Preserve]
    public class OnNetworkWeakChangeCallbackResult {
            /// <summary> 
            /// 当前网络类型
            /// </summary>
                public string networkType;
            /// <summary> 
            /// 当前是否处于弱网状态
            /// </summary>
                public bool weakNet;
    }
    [Preserve]
    public class OnShareMessageToFriendCallbackResult {
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 是否成功
            /// </summary>
                public bool success;
    }
    [Preserve]
    public class OnShareTimelineCallbackResult {
            /// <summary> 
            /// 转发显示图片的链接，可以是网络图片路径或本地图片文件路径或相对代码包根目录的图片文件路径。（该图片用于分享到朋友圈的卡片以及从朋友圈转发到会话消息的卡片展示）
            /// </summary>
                public string imageUrl;
            /// <summary> 
            /// 需要基础库： `2.14.3`
            /// 朋友圈预览图链接，不传则默认使用当前游戏画面截图
            /// </summary>
                public string imagePreviewUrl;
            /// <summary> 
            /// 需要基础库： `2.14.3`
            /// 审核通过的朋友圈预览图图片 ID，详见 [使用审核通过的转发图片](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/share.html#使用审核通过的转发图片)
            /// </summary>
                public string imagePreviewUrlId;
            /// <summary> 
            /// 审核通过的图片 ID，详见 [使用审核通过的转发图片](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/share.html#使用审核通过的转发图片)
            /// </summary>
                public string imageUrlId;
            /// <summary> 
            /// 需要基础库： `2.12.2`
            /// 独立分包路径。详见 [小游戏独立分包指南](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/independent-sub-packages.html)
            /// </summary>
                public string path;
            /// <summary> 
            /// 查询字符串，必须是 key1=val1&key2=val2 的格式。从这条转发消息进入后，可通过 wx.getLaunchOptionsSync() 或 wx.onShow() 获取启动参数中的 query。不传则默认使用当前页面query。
            /// </summary>
                public string query;
            /// <summary> 
            /// 转发标题，不传则默认使用当前小游戏的昵称。
            /// </summary>
                public string title;
    }
    [Preserve]
    public class OnShowCallbackResult {
            /// <summary> 
            /// 查询参数
            /// </summary>
                public Dictionary<string,string> query;
            /// <summary> 
            /// 当场景为由从另一个小程序或公众号或App打开时，返回此字段
            /// </summary>
                public ResultReferrerInfo referrerInfo;
            /// <summary> 
            /// 场景值
            /// </summary>
                public double scene;
            /// <summary> 
            /// shareTicket
            /// </summary>
                public string shareTicket;
    }
    [Preserve]
    public class ResultReferrerInfo {
            /// <summary> 
            /// 来源小程序或公众号或App的 appId
            /// </summary>
                public string appId;
            /// <summary> 
            /// 来源小程序传过来的数据，scene=1037或1038时支持
            /// </summary>
                public Dictionary<string,string> extraData;
    }
    [Preserve]
    public class SocketTaskOnCloseCallbackResult {
            /// <summary> 
            /// 一个数字值表示关闭连接的状态号，表示连接被关闭的原因。
            /// </summary>
                public double code;
            /// <summary> 
            /// 一个可读的字符串，表示连接被关闭的原因。
            /// </summary>
                public string reason;
    }
    [Preserve]
    public class SocketTaskOnMessageCallbackResult {
            /// <summary> 
            /// 服务器返回的消息
            /// </summary>
                public string data;
    }
    [Preserve]
    public class OnSocketOpenCallbackResult {
            /// <summary> 
            /// 需要基础库： `2.0.0`
            /// 连接成功的 HTTP 响应 Header
            /// </summary>
                public Dictionary<string,string> header;
    }
    [Preserve]
    public class OnTouchStartCallbackResult {
            /// <summary> 
            /// 触发此次事件的触摸点列表
            /// </summary>
                public Touch[] changedTouches;
            /// <summary> 
            /// 事件触发时的时间戳
            /// </summary>
                public long timeStamp;
            /// <summary> 
            /// 当前所有触摸点的列表
            /// </summary>
                public Touch[] touches;
    }
    [Preserve]
    public class Touch {
            /// <summary> 
            /// 触点相对于可见视区左边沿的 X 坐标。
            /// </summary>
                public float clientX;
            /// <summary> 
            /// 触点相对于可见视区上边沿的 Y 坐标。
            /// </summary>
                public float clientY;
            /// <summary> 
            /// 手指挤压触摸平面的压力大小, 从0.0(没有压力)到1.0(最大压力)的浮点数（仅在支持 force touch 的设备返回）
            /// </summary>
                public double force;
            /// <summary> 
            /// Touch 对象的唯一标识符，只读属性。一次触摸动作(我们值的是手指的触摸)在平面上移动的整个过程中, 该标识符不变。可以根据它来判断跟踪的是否是同一次触摸过程。
            /// </summary>
                public int identifier;
            /// <summary> 
            /// 触点相对于页面左边沿的 X 坐标。
            /// </summary>
                public float pageX;
            /// <summary> 
            /// 触点相对于页面上边沿的 Y 坐标。
            /// </summary>
                public float pageY;
    }
    [Preserve]
    public class OnUnhandledRejectionCallbackResult {
            /// <summary> 
            /// 拒绝原因，一般是一个 Error 对象
            /// </summary>
                public string reason;
    }
    [Preserve]
    public class OnVoIPChatInterruptedCallbackResult {
            /// <summary> 
            /// 错误码
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 调用结果（错误原因）
            /// </summary>
                public string errMsg;
    }
    [Preserve]
    public class OnVoIPChatMembersChangedCallbackResult {
            /// <summary> 
            /// 错误码
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 调用结果
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 还在实时语音通话中的成员 openId 名单
            /// </summary>
                public string[] openIdList;
    }
    [Preserve]
    public class OnVoIPChatSpeakersChangedCallbackResult {
            /// <summary> 
            /// 错误码
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 调用结果（错误原因）
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 还在实时语音通话中的成员 openId 名单
            /// </summary>
                public string[] openIdList;
    }
    [Preserve]
    public class OnVoIPChatStateChangedCallbackResult {
            /// <summary> 
            /// 事件码
            /// </summary>
                public double code;
            /// <summary> 
            /// 附加信息
            /// </summary>
                public Dictionary<string,string> data;
            /// <summary> 
            /// 错误码
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 调用结果
            /// </summary>
                public string errMsg;
    }
    [Preserve]
    public class OpenBluetoothAdapterOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 需要基础库： `2.10.0`
            /// 蓝牙模式，可作为主/从设备，仅 iOS 需要。
            /// 可选值：
            /// - 'central': 主机模式;
            /// - 'peripheral': 从机（外围设备）模式;
            /// </summary>
                public string mode;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
    }
    [Preserve]
    public class OpenCardOption {
            /// <summary> 
            /// 需要打开的卡券列表
            /// </summary>
                public OpenCardRequestInfo[] cardList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class OpenCardRequestInfo {
            /// <summary> 
            /// 卡券 ID
            /// </summary>
                public string cardId;
            /// <summary> 
            /// 由 [wx.addCard](https://developers.weixin.qq.com/minigame/dev/api/open-api/card/wx.addCard.html) 的返回对象中的加密 code 通过解密后得到，解密请参照：[code 解码接口](https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1499332673_Unm7V)
            /// </summary>
                public string code;
    }
    [Preserve]
    public class OpenChannelsActivityOption {
            /// <summary> 
            /// 视频 feedId
            /// </summary>
                public string feedId;
            /// <summary> 
            /// 视频号 id，以“sph”开头的id，可在视频号助手获取
            /// </summary>
                public string finderUserName;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class OpenChannelsEventOption {
            /// <summary> 
            /// 活动 id
            /// </summary>
                public string eventId;
            /// <summary> 
            /// 视频号 id，以“sph”开头的id，可在视频号助手获取
            /// </summary>
                public string finderUserName;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class OpenChannelsLiveOption {
            /// <summary> 
            /// 视频号 id，以“sph”开头的id，可在视频号助手获取
            /// </summary>
                public string finderUserName;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 直播 feedId，通过 getChannelsLiveInfo 接口获取（基础库 v2.19.2 之前的版本需要填写）
            /// </summary>
                public string feedId;
            /// <summary> 
            /// 直播 nonceId，通过 getChannelsLiveInfo 接口获取（基础库 v2.19.2 之前的版本需要填写）
            /// </summary>
                public string nonceId;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class OpenChannelsUserProfileOption {
            /// <summary> 
            /// 视频号 id
            /// </summary>
                public string finderUserName;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class OpenCustomerServiceConversationOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 会话内消息卡片图片路径
            /// </summary>
                public string sendMessageImg;
            /// <summary> 
            /// 会话内消息卡片路径
            /// </summary>
                public string sendMessagePath;
            /// <summary> 
            /// 会话内消息卡片标题
            /// </summary>
                public string sendMessageTitle;
            /// <summary> 
            /// 会话来源
            /// </summary>
                public string sessionFrom;
            /// <summary> 
            /// 是否显示会话内消息卡片，设置此参数为 true，用户进入客服会话会在右下角显示"可能要发送的小程序"提示，用户点击后可以快速发送小程序消息
            /// </summary>
                public bool showMessageCard;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class OpenSettingOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<OpenSettingSuccessCallbackResult> success;
            /// <summary> 
            /// 需要基础库： `2.10.3`
            /// 是否同时获取用户订阅消息的订阅状态，默认不获取。注意：withSubscriptions 只返回用户勾选过订阅面板中的“总是保持以上选择，不再询问”的订阅消息。
            /// </summary>
                public bool withSubscriptions;
    }
    [Preserve]
    public class OpenSettingSuccessCallbackResult {
            /// <summary> 
            /// [AuthSetting](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/AuthSetting.html)
            /// 用户授权结果
            /// </summary>
                public AuthSetting authSetting;
            /// <summary> 
            /// [SubscriptionsSetting](https://developers.weixin.qq.com/minigame/dev/api/open-api/setting/SubscriptionsSetting.html)
            /// 需要基础库： `2.10.3`
            /// 用户订阅消息设置，接口参数`withSubscriptions`值为`true`时才会返回。
            /// </summary>
                public SubscriptionsSetting subscriptionsSetting;

                public string errMsg;
    }
    [Preserve]
    public class PreviewImageOption {
            /// <summary> 
            /// 需要预览的图片链接列表。[2.2.3](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html) 起支持云文件ID。
            /// </summary>
                public string[] urls;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 当前显示图片的链接
            /// </summary>
                public string current;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.13.0`
            /// `origin`: 发送完整的referrer; `no-referrer`: 不发送。格式固定为 `https://servicewechat.com/{appid}/{version}/page-frame.html`，其中 {appid} 为小程序的 appid，{version} 为小程序的版本号，版本号为 0 表示为开发版、体验版以及审核版本，版本号为 devtools 表示为开发者工具，其余为正式版本；
            /// </summary>
                public string referrerPolicy;
            /// <summary> 
            /// 需要基础库： `2.13.0`
            /// 是否显示长按菜单。
            /// 支持识别的码：小程序码
            /// 仅小程序支持识别的码：微信个人码、微信群码、企业微信个人码、 企业微信群码与企业微信互通群码；
            /// </summary>
                public bool showmenu;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class PreviewMediaOption {
            /// <summary> 
            /// 需要预览的资源列表
            /// </summary>
                public MediaSource[] sources;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 当前显示的资源序号
            /// </summary>
                public double current;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.13.0`
            /// `origin`: 发送完整的referrer; `no-referrer`: 不发送。格式固定为 `https://servicewechat.com/{appid}/{version}/page-frame.html`，其中 {appid} 为小程序的 appid，{version} 为小程序的版本号，版本号为 0 表示为开发版、体验版以及审核版本，版本号为 devtools 表示为开发者工具，其余为正式版本；
            /// </summary>
                public string referrerPolicy;
            /// <summary> 
            /// 需要基础库： `2.13.0`
            /// 是否显示长按菜单。
            /// 支持识别的码：小程序码
            /// 仅小程序支持识别的码：微信个人码、微信群码、企业微信个人码、 企业微信群码与企业微信互通群码；
            /// </summary>
                public bool showmenu;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class MediaSource {
            /// <summary> 
            /// 图片或视频的地址
            /// </summary>
                public string url;
            /// <summary> 
            /// 视频的封面图片
            /// </summary>
                public string poster;
            /// <summary> 
            /// 资源的类型，默认为图片
            /// 可选值：
            /// - 'image': 图片;
            /// - 'video': 视频;
            /// </summary>
                public string type;
    }
    [Preserve]
    public class ReadBLECharacteristicValueOption {
            /// <summary> 
            /// 蓝牙特征的 UUID
            /// </summary>
                public string characteristicId;
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 蓝牙特征对应服务的 UUID
            /// </summary>
                public string serviceId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
    }
    [Preserve]
    public class RemoveStorageOption {
            /// <summary> 
            /// 本地缓存中指定的 key
            /// </summary>
                public string key;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class RemoveUserCloudStorageOption {
            /// <summary> 
            /// 要删除掉 key 列表
            /// </summary>
                public string[] keyList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ReportUserBehaviorBranchAnalyticsOption {
            /// <summary> 
            /// 分支ID，在「小程序管理后台」获取
            /// </summary>
                public string branchId;
            /// <summary> 
            /// 事件类型，1：曝光； 2：点击
            /// </summary>
                public double eventType;
            /// <summary> 
            /// 自定义维度，基础库 v2.14.0 开始支持可选
            /// </summary>
                public string branchDim;
    }
    [Preserve]
    public class RequestMidasFriendPaymentOption {
            /// <summary> 
            /// 购买数量。mode=game 时必填。购买数量。详见 [buyQuantity 限制说明](#buyQuantity限制说明)。
            /// </summary>
                public double buyQuantity;
            /// <summary> 
            /// 币种
            /// 可选值：
            /// - 'CNY': 人民币;
            /// </summary>
                public string currencyType;
            /// <summary> 
            /// 环境配置
            /// 可选值：
            /// - 0: 米大师正式环境;
            /// - 1: 米大师沙箱环境;
            /// </summary>
                public double env;
            /// <summary> 
            /// 支付的类型，不同的支付类型有各自额外要传的附加参数
            /// 可选值：
            /// - 'game': 购买游戏币;
            /// </summary>
                public string mode;
            /// <summary> 
            /// 随机字符串，长度应小于 128
            /// </summary>
                public string nonceStr;
            /// <summary> 
            /// 在米大师侧申请的应用 id
            /// </summary>
                public string offerId;
            /// <summary> 
            /// 开发者业务订单号，每个订单号只能使用一次，重复使用会失败。要求32个字符内，只能是数字、大小写字母、符号 `_-|*@`
            /// </summary>
                public string outTradeNo;
            /// <summary> 
            /// 申请接入时的平台，platform 与应用id有关。
            /// 可选值：
            /// - 'android': Android平台;
            /// </summary>
                public string platform;
            /// <summary> 
            /// 签名
            /// </summary>
                public string signature;
            /// <summary> 
            /// 生成这个随机字符串的 UNIX 时间戳（精确到秒）
            /// </summary>
                public long timeStamp;
            /// <summary> 
            /// 分区 ID
            /// </summary>
                public string zoneId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<MidasFriendPaymentError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<MidasFriendPaymentError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<RequestMidasFriendPaymentSuccessCallbackResult> success;
    }
    [Preserve]
    public class MidasFriendPaymentError {
            /// <summary> 
            /// 错误信息
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | 1000 |  | mode错误 |
            /// | -15005 |  | 索要权限被封禁（索要功能不可用） |
            /// | -10073011 |  | 参数错误（具体错误见errMsg） |
            /// | -10073003 |  | outTradeNo业务单号重复 |
            /// | -10073012 |  | 索要单已支付 |
            /// | -10073013 |  | 索要单已超时 |
            /// | -10073014 |  | 签名错误 |
            /// | -10073015 |  | 索要功能不可用 |
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 错误码
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | 1000 |  | mode错误 |
            /// | -15005 |  | 索要权限被封禁（索要功能不可用） |
            /// | -10073011 |  | 参数错误（具体错误见errMsg） |
            /// | -10073003 |  | outTradeNo业务单号重复 |
            /// | -10073012 |  | 索要单已支付 |
            /// | -10073013 |  | 索要单已超时 |
            /// | -10073014 |  | 签名错误 |
            /// | -10073015 |  | 索要功能不可用 |
            /// </summary>
                public double errCode;
    }
    [Preserve]
    public class RequestMidasFriendPaymentSuccessCallbackResult {
            /// <summary> 
            /// 敏感数据对应的云 ID，开通[云开发](https://developers.weixin.qq.com/minigame/dev/wxcloud/basis/getting-started.html)的小程序才会返回，可通过云调用直接获取开放数据，详细见[云调用直接获取开放数据](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html#method-cloud)
            /// </summary>
                public string cloudID;
            /// <summary> 
            /// 包括敏感数据在内的完整转发信息的加密数据，详细见[加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html)
            /// </summary>
                public string encryptedData;
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 加密算法的初始向量，详细见[加密数据解密算法](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/signature.html)
            /// </summary>
                public string iv;
    }
    [Preserve]
    public class RequestMidasPaymentOption {
            /// <summary> 
            /// 币种
            /// 可选值：
            /// - 'CNY': 人民币;
            /// </summary>
                public string currencyType;
            /// <summary> 
            /// 支付的类型，不同的支付类型有各自额外要传的附加参数。
            /// 可选值：
            /// - 'game': 购买游戏币;
            /// </summary>
                public string mode;
            /// <summary> 
            /// 在米大师侧申请的应用 id
            /// </summary>
                public string offerId;
            /// <summary> 
            /// 购买数量。mode=game 时必填。购买数量。详见 [buyQuantity 限制说明](#buyquantity-限制说明)。
            /// </summary>
                public double buyQuantity;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<MidasPaymentError> complete;
            /// <summary> 
            /// 环境配置
            /// 可选值：
            /// - 0: 米大师正式环境;
            /// - 1: 米大师沙箱环境;
            /// </summary>
                public double env;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<MidasPaymentError> fail;
            /// <summary> 
            /// 申请接入时的平台，platform 与应用id有关。
            /// 可选值：
            /// - 'android': android;
            /// </summary>
                public string platform;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
            /// <summary> 
            /// 分区 ID
            /// </summary>
                public string zoneId;
    }
    [Preserve]
    public class MidasPaymentError {
            /// <summary> 
            /// 错误信息
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | -1 |  | 系统失败 |
            /// | -2 |  | 支付取消 |
            /// | -15001 |  | 虚拟支付接口错误码，缺少参数 |
            /// | -15002 |  | 虚拟支付接口错误码，参数不合法 |
            /// | -15003 |  | 虚拟支付接口错误码，订单重复 |
            /// | -15004 |  | 虚拟支付接口错误码，后台错误 |
            /// | -15005 |  | 虚拟支付接口错误码，appId权限被封禁 |
            /// | -15006 |  | 虚拟支付接口错误码，货币类型不支持 |
            /// | -15007 |  | 虚拟支付接口错误码，订单已支付 |
            /// | -15009 |  | 虚拟支付接口错误码，由于健康系统限制，本次支付已超过限额（这种错误情况会有默认弹窗提示） |
            /// | 1 |  | 虚拟支付接口错误码，用户取消支付 |
            /// | 2 |  | 虚拟支付接口错误码，客户端错误,判断到小程序在用户处于支付中时,又发起了一笔支付请求 |
            /// | 3 |  | 虚拟支付接口错误码，Android独有错误：用户使用GooglePlay支付，而手机未安装GooglePlay |
            /// | 4 |  | 虚拟支付接口错误码，用户操作系统支付状态异常 |
            /// | 5 |  | 虚拟支付接口错误码，操作系统错误 |
            /// | 6 |  | 虚拟支付接口错误码，其他错误 |
            /// | 1000 |  | 参数错误 |
            /// | 1003 |  | 米大师Portal错误 |
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 错误码
            /// | 错误码 | 错误信息 | 说明 |
            /// | - | - | - |
            /// | -1 |  | 系统失败 |
            /// | -2 |  | 支付取消 |
            /// | -15001 |  | 虚拟支付接口错误码，缺少参数 |
            /// | -15002 |  | 虚拟支付接口错误码，参数不合法 |
            /// | -15003 |  | 虚拟支付接口错误码，订单重复 |
            /// | -15004 |  | 虚拟支付接口错误码，后台错误 |
            /// | -15005 |  | 虚拟支付接口错误码，appId权限被封禁 |
            /// | -15006 |  | 虚拟支付接口错误码，货币类型不支持 |
            /// | -15007 |  | 虚拟支付接口错误码，订单已支付 |
            /// | -15009 |  | 虚拟支付接口错误码，由于健康系统限制，本次支付已超过限额（这种错误情况会有默认弹窗提示） |
            /// | 1 |  | 虚拟支付接口错误码，用户取消支付 |
            /// | 2 |  | 虚拟支付接口错误码，客户端错误,判断到小程序在用户处于支付中时,又发起了一笔支付请求 |
            /// | 3 |  | 虚拟支付接口错误码，Android独有错误：用户使用GooglePlay支付，而手机未安装GooglePlay |
            /// | 4 |  | 虚拟支付接口错误码，用户操作系统支付状态异常 |
            /// | 5 |  | 虚拟支付接口错误码，操作系统错误 |
            /// | 6 |  | 虚拟支付接口错误码，其他错误 |
            /// | 1000 |  | 参数错误 |
            /// | 1003 |  | 米大师Portal错误 |
            /// </summary>
                public double errCode;
    }
    [Preserve]
    public class RequestSubscribeMessageOption {
            /// <summary> 
            /// 需要订阅的消息模板的id的集合，一次调用最多可订阅3条消息（注意：iOS客户端7.0.6版本、Android客户端7.0.7版本之后的一次性订阅/长期订阅才支持多个模板消息，iOS客户端7.0.5版本、Android客户端7.0.6版本之前的一次订阅只支持一个模板消息）消息模板id在[微信公众平台(mp.weixin.qq.com)-功能-订阅消息]中配置。每个tmplId对应的模板标题需要不相同，否则会被过滤。
            /// </summary>
                public string[] tmplIds;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<RequestSubscribeMessageFailCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<RequestSubscribeMessageSuccessCallbackResult> success;
    }
    [Preserve]
    public class RequestSubscribeMessageFailCallbackResult {
            /// <summary> 
            /// 接口调用失败错误码
            /// </summary>
                public double errCode;
            /// <summary> 
            /// 接口调用失败错误信息
            /// </summary>
                public string errMsg;
    }
    [Preserve]
    public class RequestSubscribeMessageSuccessCallbackResult: Dictionary<string, string>{
            /// <summary> 
            /// [TEMPLATE_ID]是动态的键，即模板id，值包括'accept'、'reject'、'ban'、'filter'。'accept'表示用户同意订阅该条id对应的模板消息，'reject'表示用户拒绝订阅该条id对应的模板消息，'ban'表示已被后台封禁，'filter'表示该模板因为模板标题同名被后台过滤。例如 { errMsg: "requestSubscribeMessage:ok", zun-LzcQyW-edafCVvzPkK4de2Rllr1fFpw2A_x0oXE: "accept"} 表示用户同意订阅zun-LzcQyW-edafCVvzPkK4de2Rllr1fFpw2A_x0oXE这条消息
            /// </summary>
            /// <summary> 
            /// 接口调用成功时errMsg值为'requestSubscribeMessage:ok'
            /// </summary>
            public string  errMsg;
    }
    [Preserve]
    public class RequestSubscribeSystemMessageOption {
            /// <summary> 
            /// 系统订阅消息类型列表，一次调用最多可订阅3种类型的消息，目前支持两种类型，"SYS_MSG_TYPE_INTERACTIVE"（好友互动提醒）、"SYS_MSG_TYPE_RANK"（排行榜超越提醒）
            /// </summary>
                public string[] msgTypeList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<RequestSubscribeMessageFailCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<RequestSubscribeSystemMessageSuccessCallbackResult> success;
    }
    [Preserve]
    public class RequestSubscribeSystemMessageSuccessCallbackResult: Dictionary<string, string>{
            /// <summary> 
            /// [MSG_TYPE]是动态的键，即系统订阅消息类型，值为'accept'、'reject'、'ban'，'accept'表示用户同意订阅该类型对应的模板消息，'reject'表示用户拒绝订阅该类型对应的模板消息，'ban'表示已被后台封禁。例如 { errMsg: "requestSubscribeSystemMessage:ok", SYS_MSG_TYPE_INTERACTIVE: "accept" } 表示用户同意订阅'SYS_MSG_TYPE_INTERACTIVE'这条消息
            /// </summary>
            /// <summary> 
            /// 接口调用成功时errMsg值为'requestSubscribeSystemMessage:ok'
            /// </summary>
            public string  errMsg;
    }
    [Preserve]
    public class ReserveChannelsLiveOption {
            /// <summary> 
            /// 预告 id，通过 getChannelsLiveNoticeInfo 接口获取
            /// </summary>
                public string noticeId;
    }
    [Preserve]
    public class SaveFileToDiskOption {
            /// <summary> 
            /// 待保存文件路径
            /// </summary>
                public string filePath;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SaveImageToPhotosAlbumOption {
            /// <summary> 
            /// 图片文件路径，可以是临时文件路径或永久文件路径 (本地路径) ，不支持网络路径
            /// </summary>
                public string filePath;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ScanCodeOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `1.2.0`
            /// 是否只能从相机扫码，不允许从相册选择图片
            /// </summary>
                public bool onlyFromCamera;
            /// <summary> 
            /// 需要基础库： `1.7.0`
            /// 扫码类型
            /// 可选值：
            /// - 'barCode': 一维码;
            /// - 'qrCode': 二维码;
            /// - 'datamatrix': Data Matrix 码;
            /// - 'pdf417': PDF417 条码;
            /// </summary>
                public Array scanType;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<ScanCodeSuccessCallbackResult> success;
    }
    [Preserve]
    public class ScanCodeSuccessCallbackResult {
            /// <summary> 
            /// 所扫码的字符集
            /// </summary>
                public string charSet;
            /// <summary> 
            /// 当所扫的码为当前小程序二维码时，会返回此字段，内容为二维码携带的 path
            /// </summary>
                public string path;
            /// <summary> 
            /// 原始数据，base64编码
            /// </summary>
                public string rawData;
            /// <summary> 
            /// 所扫码的内容
            /// </summary>
                public string result;
            /// <summary> 
            /// 所扫码的类型
            /// 可选值：
            /// - 'QR_CODE': 二维码;
            /// - 'AZTEC': 一维码;
            /// - 'CODABAR': 一维码;
            /// - 'CODE_39': 一维码;
            /// - 'CODE_93': 一维码;
            /// - 'CODE_128': 一维码;
            /// - 'DATA_MATRIX': 二维码;
            /// - 'EAN_8': 一维码;
            /// - 'EAN_13': 一维码;
            /// - 'ITF': 一维码;
            /// - 'MAXICODE': 一维码;
            /// - 'PDF_417': 二维码;
            /// - 'RSS_14': 一维码;
            /// - 'RSS_EXPANDED': 一维码;
            /// - 'UPC_A': 一维码;
            /// - 'UPC_E': 一维码;
            /// - 'UPC_EAN_EXTENSION': 一维码;
            /// - 'WX_CODE': 二维码;
            /// - 'CODE_25': 一维码;
            /// </summary>
                public string scanType;

                public string errMsg;
    }
    [Preserve]
    public class SendSocketMessageOption {
            /// <summary> 
            /// 需要发送的内容
            /// </summary>
                public string data;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SetBLEMTUOption {
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 最大传输单元。设置范围为 (22,512) 区间内，单位 bytes
            /// </summary>
                public double mtu;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<SetBLEMTUFailCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<SetBLEMTUSuccessCallbackResult> success;
    }
    [Preserve]
    public class SetBLEMTUFailCallbackResult {
            /// <summary> 
            /// 最终协商的 MTU 值。如果协商失败则无此参数。安卓客户端 8.0.9 开始支持。
            /// </summary>
                public double mtu;
    }
    [Preserve]
    public class SetBLEMTUSuccessCallbackResult {
            /// <summary> 
            /// 最终协商的 MTU 值，与传入参数一致。安卓客户端 8.0.9 开始支持。
            /// </summary>
                public double mtu;

                public string errMsg;
    }
    [Preserve]
    public class SetClipboardDataOption {
            /// <summary> 
            /// 剪贴板的内容
            /// </summary>
                public string data;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SetEnableDebugOption {
            /// <summary> 
            /// 是否打开调试
            /// </summary>
                public bool enableDebug;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SetInnerAudioOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 是否与其他音频混播，设置为 true 之后，不会终止其他应用或微信内的音乐
            /// </summary>
                public bool mixWithOther;
            /// <summary> 
            /// （仅在 iOS 生效）是否遵循静音开关，设置为 false 之后，即使是在静音模式下，也能播放声音
            /// </summary>
                public bool obeyMuteSwitch;
            /// <summary> 
            /// true 代表用扬声器播放，false 代表听筒播放，默认值为 true。
            /// </summary>
                public bool speakerOn;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SetKeepScreenOnOption {
            /// <summary> 
            /// 是否保持屏幕常亮
            /// </summary>
                public bool keepScreenOn;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SetMenuStyleOption {
            /// <summary> 
            /// 样式风格
            /// 可选值：
            /// - 'light': 浅色;
            /// - 'dark': 深色;
            /// </summary>
                public string style;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SetScreenBrightnessOption {
            /// <summary> 
            /// 屏幕亮度值，范围 0 ~ 1。0 最暗，1 最亮
            /// </summary>
                public double value;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SetStatusBarStyleOption {
            /// <summary> 
            /// 样式风格
            /// 可选值：
            /// - 'white': 白色;
            /// - 'black': 浅色;
            /// </summary>
                public string style;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class SetUserCloudStorageOption {
            /// <summary> 
            /// 要修改的 KV 数据列表
            /// </summary>
                public KVData[] KVDataList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ShareAppMessageOption {
            /// <summary> 
            /// 转发显示图片的链接，可以是网络图片路径或本地图片文件路径或相对代码包根目录的图片文件路径。显示图片长宽比是 5:4
            /// </summary>
                public string imageUrl;
            /// <summary> 
            /// 需要基础库： `2.4.3`
            /// 审核通过的图片 ID，详见 [使用审核通过的转发图片](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/share.html#使用审核通过的转发图片)
            /// </summary>
                public string imageUrlId;
            /// <summary> 
            /// 需要基础库： `2.12.2`
            /// 独立分包路径。详见 [小游戏独立分包指南](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/independent-sub-packages.html)
            /// </summary>
                public string path;
            /// <summary> 
            /// 查询字符串，从这条转发消息进入后，可通过 wx.getLaunchOptionsSync() 或 wx.onShow() 获取启动参数中的 query。必须是 key1=val1&key2=val2 的格式。
            /// </summary>
                public string query;
            /// <summary> 
            /// 转发标题，不传则默认使用当前小游戏的昵称。
            /// </summary>
                public string title;
            /// <summary> 
            /// 需要基础库： `2.12.2`
            /// 是否转发到当前群。该参数只对从群工具栏打开的场景下生效，默认转发到当前群，填入false时可转发到其他会话。
            /// </summary>
                public bool toCurrentGroup;
    }
    [Preserve]
    public class ShareMessageToFriendOption {
            /// <summary> 
            /// 发送对象的 openId
            /// </summary>
                public string openId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 转发显示图片的链接，可以是网络图片路径或本地图片文件路径或相对代码包根目录的图片文件路径。显示图片长宽比是 5:4
            /// </summary>
                public string imageUrl;
            /// <summary> 
            /// 审核通过的图片 ID，详见 [使用审核通过的转发图片](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/share.html#使用审核通过的转发图片)
            /// </summary>
                public string imageUrlId;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
            /// <summary> 
            /// 转发标题，不传则默认使用当前小游戏的昵称。
            /// </summary>
                public string title;
    }
    [Preserve]
    public class ShowActionSheetOption {
            /// <summary> 
            /// 按钮的文字数组，数组长度最大为 6
            /// </summary>
                public string[] itemList;
            /// <summary> 
            /// 需要基础库： `2.14.0`
            /// 警示文案
            /// </summary>
                public string alertText;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 按钮的文字颜色
            /// </summary>
                public string itemColor;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<ShowActionSheetSuccessCallbackResult> success;
    }
    [Preserve]
    public class ShowActionSheetSuccessCallbackResult {
            /// <summary> 
            /// 用户点击的按钮序号，从上到下的顺序，从0开始
            /// </summary>
                public double tapIndex;

                public string errMsg;
    }
    [Preserve]
    public class ShowKeyboardOption {
            /// <summary> 
            /// 当点击完成时键盘是否收起
            /// </summary>
                public bool confirmHold;
            /// <summary> 
            /// 键盘右下角 confirm 按钮的类型，只影响按钮的文本内容
            /// 可选值：
            /// - 'done': 完成;
            /// - 'next': 下一个;
            /// - 'search': 搜索;
            /// - 'go': 前往;
            /// - 'send': 发送;
            /// </summary>
                public string confirmType;
            /// <summary> 
            /// 键盘输入框显示的默认值
            /// </summary>
                public string defaultValue;
            /// <summary> 
            /// 键盘中文本的最大长度
            /// </summary>
                public double maxLength;
            /// <summary> 
            /// 是否为多行输入
            /// </summary>
                public bool multiple;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ShowLoadingOption {
            /// <summary> 
            /// 提示的内容
            /// </summary>
                public string title;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 是否显示透明蒙层，防止触摸穿透
            /// </summary>
                public bool mask;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ShowModalOption {
            /// <summary> 
            /// 取消按钮的文字颜色，必须是 16 进制格式的颜色字符串
            /// </summary>
                public string cancelColor;
            /// <summary> 
            /// 取消按钮的文字，最多 4 个字符
            /// </summary>
                public string cancelText;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 确认按钮的文字颜色，必须是 16 进制格式的颜色字符串
            /// </summary>
                public string confirmColor;
            /// <summary> 
            /// 确认按钮的文字，最多 4 个字符
            /// </summary>
                public string confirmText;
            /// <summary> 
            /// 提示的内容
            /// </summary>
                public string content;
            /// <summary> 
            /// 需要基础库： `2.17.1`
            /// 是否显示输入框
            /// </summary>
                public bool editable;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.17.1`
            /// 显示输入框时的提示文本
            /// </summary>
                public string placeholderText;
            /// <summary> 
            /// 是否显示取消按钮
            /// </summary>
                public bool showCancel;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<ShowModalSuccessCallbackResult> success;
            /// <summary> 
            /// 提示的标题
            /// </summary>
                public string title;
    }
    [Preserve]
    public class ShowModalSuccessCallbackResult {
            /// <summary> 
            /// 需要基础库： `1.1.0`
            /// 为 true 时，表示用户点击了取消（用于 Android 系统区分点击蒙层关闭还是点击取消按钮关闭）
            /// </summary>
                public bool cancel;
            /// <summary> 
            /// 为 true 时，表示用户点击了确定按钮
            /// </summary>
                public bool confirm;
            /// <summary> 
            /// editable 为 true 时，用户输入的文本
            /// </summary>
                public string content;

                public string errMsg;
    }
    [Preserve]
    public class ShowShareImageMenuOption {
            /// <summary> 
            /// 要分享的图片地址，必须为本地路径或临时路径
            /// </summary>
                public string path;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class ShowShareMenuOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.11.3`
            /// 本接口为 Beta 版本，暂只在 Android 平台支持。需要显示的转发按钮名称列表，默认['shareAppMessage']。按钮名称合法值包含 "shareAppMessage"、"shareTimeline" 两种
            /// </summary>
                public string[] menus;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
            /// <summary> 
            /// 是否使用带 shareTicket 的转发[详情](#)
            /// </summary>
                public bool withShareTicket;
    }
    [Preserve]
    public class ShowToastOption {
            /// <summary> 
            /// 提示的内容
            /// </summary>
                public string title;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 提示的延迟时间
            /// </summary>
                public double duration;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 图标
            /// 可选值：
            /// - 'success': 显示成功图标，此时 title 文本最多显示 7 个汉字长度;
            /// - 'error': 显示失败图标，此时 title 文本最多显示 7 个汉字长度;
            /// - 'loading': 显示加载图标，此时 title 文本最多显示 7 个汉字长度;
            /// - 'none': 不显示图标，此时 title 文本最多可显示两行，[1.9.0](https://developers.weixin.qq.com/miniprogram/dev/framework/compatibility.html)及以上版本支持;
            /// </summary>
                public string icon;
            /// <summary> 
            /// 需要基础库： `1.1.0`
            /// 自定义图标的本地路径，image 的优先级高于 icon
            /// </summary>
                public string image;
            /// <summary> 
            /// 是否显示透明蒙层，防止触摸穿透
            /// </summary>
                public bool mask;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StartAccelerometerOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.1.0`
            /// 监听加速度数据回调函数的执行频率
            /// 可选值：
            /// - 'game': 适用于更新游戏的回调频率，在 20ms/次 左右;
            /// - 'ui': 适用于更新 UI 的回调频率，在 60ms/次 左右;
            /// - 'normal': 普通的回调频率，在 200ms/次 左右;
            /// </summary>
                public string interval;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StartBeaconDiscoveryOption {
            /// <summary> 
            /// Beacon 设备广播的 UUID 列表
            /// </summary>
                public string[] uuids;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BeaconError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BeaconError> fail;
            /// <summary> 
            /// 是否校验蓝牙开关，仅在 iOS 下有效。iOS 11 起，控制面板里关掉蓝牙，还是能继续使用 Beacon 服务。
            /// </summary>
                public bool ignoreBluetoothAvailable;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BeaconError> success;
    }
    [Preserve]
    public class StartBluetoothDevicesDiscoveryOption {
            /// <summary> 
            /// 是否允许重复上报同一设备。如果允许重复上报，则 [wx.onBlueToothDeviceFound](#) 方法会多次上报同一设备，但是 RSSI 值会有不同。
            /// </summary>
                public bool allowDuplicatesKey;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 上报设备的间隔，单位 ms。0 表示找到新设备立即上报，其他数值根据传入的间隔上报。
            /// </summary>
                public double interval;
            /// <summary> 
            /// 扫描模式，越高扫描越快，也越耗电。仅安卓微信客户端 7.0.12 及以上支持。
            /// 可选值：
            /// - 'low': 低;
            /// - 'medium': 中;
            /// - 'high': 高;
            /// </summary>
                public string powerLevel;
            /// <summary> 
            /// 要搜索的蓝牙设备主服务的 UUID 列表（支持 16/32/128 位 UUID）。某些蓝牙设备会广播自己的主 service 的 UUID。如果设置此参数，则只搜索广播包有对应 UUID 的主服务的蓝牙设备。建议通过该参数过滤掉周边不需要处理的其他蓝牙设备。
            /// </summary>
                public string[] services;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
    }
    [Preserve]
    public class StartCompassOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StartDeviceMotionListeningOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 监听设备方向的变化回调函数的执行频率
            /// 可选值：
            /// - 'game': 适用于更新游戏的回调频率，在 20ms/次 左右;
            /// - 'ui': 适用于更新 UI 的回调频率，在 60ms/次 左右;
            /// - 'normal': 普通的回调频率，在 200ms/次 左右;
            /// </summary>
                public string interval;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StartGyroscopeOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 监听陀螺仪数据回调函数的执行频率
            /// 可选值：
            /// - 'game': 适用于更新游戏的回调频率，在 20ms/次 左右;
            /// - 'ui': 适用于更新 UI 的回调频率，在 60ms/次 左右;
            /// - 'normal': 普通的回调频率，在 200ms/次 左右;
            /// </summary>
                public string interval;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StopAccelerometerOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StopBeaconDiscoveryOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BeaconError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BeaconError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BeaconError> success;
    }
    [Preserve]
    public class StopBluetoothDevicesDiscoveryOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
    }
    [Preserve]
    public class StopCompassOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StopDeviceMotionListeningOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StopFaceDetectOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class StopGyroscopeOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class UpdateKeyboardOption {
            /// <summary> 
            /// 键盘输入框的当前值
            /// </summary>
                public string value;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class UpdateShareMenuOption {
            /// <summary> 
            /// 需要基础库： `2.4.0`
            /// 动态消息的 activityId。通过 [updatableMessage.createActivityId](https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/updatable-message/updatableMessage.createActivityId.html) 接口获取
            /// </summary>
                public string activityId;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 需要基础库： `2.13.0`
            /// 是否是私密消息。详见 [小程序私密消息](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/private-message.html)
            /// </summary>
                public bool isPrivateMessage;
            /// <summary> 
            /// 需要基础库： `2.4.0`
            /// 是否是动态消息，详见[动态消息](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/updatable-message.html)
            /// </summary>
                public bool isUpdatableMessage;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
            /// <summary> 
            /// 需要基础库： `2.4.0`
            /// 动态消息的模板信息
            /// </summary>
                public UpdatableMessageFrontEndTemplateInfo templateInfo;
            /// <summary> 
            /// 需要基础库： `2.11.0`
            /// 群待办消息的id，通过toDoActivityId可以把多个群待办消息聚合为同一个。通过 [updatableMessage.createActivityId](https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/updatable-message/updatableMessage.createActivityId.html) 接口获取。详见[群待办消息](#)
            /// </summary>
                public string toDoActivityId;
            /// <summary> 
            /// 是否使用带 shareTicket 的转发[详情](#)
            /// </summary>
                public bool withShareTicket;
    }
    [Preserve]
    public class UpdatableMessageFrontEndTemplateInfo {
            /// <summary> 
            /// 参数列表
            /// </summary>
                public UpdatableMessageFrontEndParameter[] parameterList;
    }
    [Preserve]
    public class UpdatableMessageFrontEndParameter {
            /// <summary> 
            /// 参数名
            /// </summary>
                public string name;
            /// <summary> 
            /// 参数值
            /// </summary>
                public string value;
    }
    [Preserve]
    public class UpdateVoIPChatMuteConfigOption {
            /// <summary> 
            /// 静音设置
            /// </summary>
                public MuteConfig muteConfig;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class UpdateWeChatAppOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class VibrateLongOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class VibrateShortOption {
            /// <summary> 
            /// 需要基础库： `2.13.0`
            /// 震动强度类型，有效值为：heavy、medium、light
            /// </summary>
                public string type;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class WriteBLECharacteristicValueOption {
            /// <summary> 
            /// 蓝牙特征的 UUID
            /// </summary>
                public string characteristicId;
            /// <summary> 
            /// 蓝牙设备 id
            /// </summary>
                public string deviceId;
            /// <summary> 
            /// 蓝牙特征对应服务的 UUID
            /// </summary>
                public string serviceId;
            /// <summary> 
            /// 蓝牙设备特征对应的二进制值
            /// </summary>
                public byte[] value;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<BluetoothError> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<BluetoothError> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<BluetoothError> success;
    }
    [Preserve]
    public class StartGameLiveOption {
            /// <summary> 
            /// 自定义query
            /// </summary>
                public string query;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }
    [Preserve]
    public class CheckGameLiveEnabledOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<CheckGameLiveEnabledSuccessCallbackOption> success;
    }
    [Preserve]
    public class CheckGameLiveEnabledSuccessCallbackOption {
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
            /// <summary> 
            /// 用户是否有直播权限
            /// </summary>
                public bool isEnabled;
    }
    [Preserve]
    public class OnGameLiveStateChangeCallbackResult {
            /// <summary> 
            /// 当前直播状态
            /// state 合法值：
            /// menuClick 用户点击右上角直播按钮
            /// start 开始直播
            /// end 直播结束
            /// </summary>
                public string state;
            /// <summary> 
            /// 当前直播id，只在 state 是 start 时会返回 (基础库v2.19.2开始支持)
            /// </summary>
                public string feedId;
    }
    [Preserve]
    public class OnGameLiveStateChangeCallbackResponse {
            /// <summary> 
            /// 开发者可通过 wx.onGameLiveStateChange 设置观众从直播间打开小游戏的 query 比如：'a=1&b=2'
            /// </summary>
                public string query;
    }
    [Preserve]
    public class GameLiveState {
            /// <summary> 
            /// 是否正在直播
            /// </summary>
                public bool isLive;
    }
    [Preserve]
    public class GetUserCurrentGameliveInfoOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetUserCurrentGameliveInfoSuccessCallbackOption> success;
    }
    [Preserve]
    public class GetUserCurrentGameliveInfoSuccessCallbackOption {
            /// <summary> 
            /// 最近几场直播的 feedId 列表
            /// </summary>
                public string[] feedIdList;
    }
    [Preserve]
    public class GetUserRecentGameLiveInfoOption {
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetUserGameLiveDetailsSuccessCallbackOption> success;
    }
    [Preserve]
    public class GetUserGameLiveDetailsSuccessCallbackOption {
            /// <summary> 
            /// 包括敏感数据在内的完整转发信息的加密数据，详细见加密数据解密算法 https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/signature.html
            /// </summary>
                public string encryptedData;
            /// <summary> 
            /// 加密算法的初始向量，详细见加密数据解密算法
            /// </summary>
                public string iv;
            /// <summary> 
            /// 敏感数据对应的云 ID，开通云开发的小程序才会返回，可通过云调用直接获取开放数据，详细见云调用直接获取开放数据
            /// </summary>
                public string cloudID;
            /// <summary> 
            /// 最近几场直播的 feedId 列表
            /// </summary>
                public string[] feedIdList;
            /// <summary> 
            /// 错误信息
            /// </summary>
                public string errMsg;
    }
    [Preserve]
    public class GetUserGameLiveDetailsOption {
            /// <summary> 
            /// 要查询的直播的id
            /// </summary>
                public string[] feedIdList;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GetUserGameLiveDetailsSuccessCallbackOption> success;
    }
    [Preserve]
    public class OpenChannelsLiveCollectionOption {
            /// <summary> 
            /// 支持填写最多4个openid，该用户的直播间将在直播专区置顶显示；可不填
            /// </summary>
                public string[] openIds;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> success;
    }

    [Preserve]
    public class UpdateManager{
        private string instanceId;
        public UpdateManager(string id)
        {
            instanceId = id;
        }
        /// <summary>
        /// [UpdateManager.applyUpdate()](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.applyUpdate.html)
        /// 强制小程序重启并使用新版本。在小程序新版本下载完成后（即收到 `onUpdateReady` 回调）调用。
        /// **示例代码**
        /// [示例代码](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.html#示例代码)
        /// </summary>
        public void ApplyUpdate(){ 
            WXSDKManagerHandler.Instance.ApplyUpdate(instanceId);
        }
        /// <summary>
        /// [UpdateManager.onCheckForUpdate(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.onCheckForUpdate.html)
        /// 监听向微信后台请求检查更新结果事件。微信在小程序冷启动时自动检查更新，不需由开发者主动触发。
        /// **示例代码**
        /// [示例代码](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.html#示例代码)
        /// </summary>
        public void OnCheckForUpdate(Action<OnCheckForUpdateCallbackResult> callback){
            WXSDKManagerHandler.Instance.OnCheckForUpdate(instanceId, callback);
        }
        /// <summary>
        /// [UpdateManager.onUpdateFailed(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.onUpdateFailed.html)
        /// 监听小程序更新失败事件。小程序有新版本，客户端主动触发下载（无需开发者触发），下载失败（可能是网络原因等）后回调
        /// **示例代码**
        /// [示例代码](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.html#示例代码)
        /// </summary>
        public void OnUpdateFailed(Action<GeneralCallbackResult> callback){
            WXSDKManagerHandler.Instance.OnUpdateFailed(instanceId, callback);
        }
        /// <summary>
        /// [UpdateManager.onUpdateReady(function callback)](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.onUpdateReady.html)
        /// 监听小程序有版本更新事件。客户端主动触发下载（无需开发者触发），下载成功后回调
        /// **示例代码**
        /// [示例代码](https://developers.weixin.qq.com/minigame/dev/api/base/update/UpdateManager.html#示例代码)
        /// </summary>
        public void OnUpdateReady(Action<GeneralCallbackResult> callback){
            WXSDKManagerHandler.Instance.OnUpdateReady(instanceId, callback);
        }
    }


}
