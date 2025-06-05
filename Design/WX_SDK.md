# SDK 调用微信 API

## 初始化

调用`Unity SDK`前，需要在主入口进行SDK初始化，回调后再执行主逻辑。

```csharp
WX.InitSDK((int code)=> {
// 你的主逻辑
});
```

## 支持范围

本`Unity SDK`对`WXSDK`的支持大体与[官网 API 文档](https://developers.weixin.qq.com/minigame/dev/api/)相同。

具体支持的 API 可以查看`WX.cs`文件，其中有详细注释说明。

### 更新机制

新版`Unity SDK`会在[lib.wx.api.d.ts](https://github.com/wechat-miniprogram/minigame-api-typings/blob/master/types/wx/lib.wx.api.d.ts)更新后及时更新。
若基础库更新后[lib.wx.api.d.ts](https://github.com/wechat-miniprogram/minigame-api-typings/blob/master/types/wx/lib.wx.api.d.ts)暂未更新，开发者可参考[自定义SDK调用](./CustomSDK.md)临时调用WXSDK。
以`wx.shareAppMessageToGroup`为例：

```csharp
using WeChatWASM;

public class ShareAppMessageToGroupOption
{
    public string title;
    public string path;
    public string imageUrl;
}

// 合适位置调用
WX.CallJSFunction("wx", "shareAppMessageToGroup", new ShareAppMessageToGroupOption
{
    title = "群任务",
});
```

### Unity SDK 特供API

此处列出[lib.wx.api.d.ts](https://github.com/wechat-miniprogram/minigame-api-typings/blob/master/types/wx/lib.wx.api.d.ts)中未列出，仅在`Unity SDK`中可用的API列表。

| 类别 | 函数名 | 备注 |
|------|--------|------|
| **基础功能** | InitSDK | 初始化SDK |
|| CanIUse | 判断API在当前环境是否可用 |
|| SetDevicePixelRatio | 设置设备像素比 |
|| CallJSFunction | 调用JS函数 |
|| CallJSFunctionWithReturn | 调用JS函数并获取返回值 |
| **字体** | GetWXFont | 获取微信字体 |
| **广告** | CreateFixedBottomMiddleBannerAd | 创建固定底部中间的bannerAd |
| **社交组件** | CreateMiniGameChat | 创建社交组件 |
| **开放数据域** | ShowOpenData | 显示开放数据域Canvas |
|| HideOpenData | 显示开放数据域Canvas |
| **音频** | PreDownloadAudios | 预下载音频资源 |
| **云测试** | IsCloudTest | 是否小游戏云测试环境 |
| **隐私协议弹窗** | PrivacyAuthorizeResolve | 由于C#侧无法直接返回JS绑定函数，所以新增一个API专门用于在WX.OnNeedPrivacyAuthorization的回调内调用 |
| **本地缓存** | StorageSetIntSync | 同wx.setStorageSync |
|| StorageGetIntSync | 同wx.getStorageSync |
|| StorageSetStringSync | 同wx.setStorageSync |
|| StorageSetFloatSync | 同wx.setStorageSync |
|| StorageGetFloatSync | 同wx.getStorageSync |
|| StorageDeleteAllSync | 同wx.clearStorageSync |
|| StorageDeleteKeySync | 同wx.removeStorageSync |
|| StorageHasKeySync | 判断本地缓存中是否包含该key |
| **文件缓存清理** | CleanAllFileCache | 清理所有文件缓存 |
|| CleanFileCache | 清理文件缓存 |
|| RemoveFile | 删除文件 |
|| GetCachePath | 获取缓存路径 |
| **性能** | GetTotalMemorySize | 获取当前UnityHeap总内存(峰值) |
|| GetTotalStackSize | 获取当前UnityHeap Stack大小 |
|| GetStaticMemorySize | 获取当前UnityHeap静态内存 |
|| GetDynamicMemorySize | 获取当前UnityHeap动态内存 |
|| GetUsedMemorySize | 获取已使用UnityHeap内存大小 |
|| GetUnAllocatedMemorySize | 获取未分配UnityHeap内存大小 |
|| LogUnityHeapMem | 打印UnityHeap内存 |
|| GetBundleNumberInMemory | 获取当前AssetBundle在JS内存中的数量 |
|| GetBundleNumberOnDisk | 获取当前AssetBundle在磁盘中不可清理的数量 |
|| GetBundleSizeInMemory | 获取当前AssetBundle在JS内存中的体积 |
|| GetBundleSizeOnDisk | 获取当前AssetBundle在磁盘中不可清理的体积 |
|| OpenProfileStats | 打开性能面板 |
|| ProfilingMemoryDump | ProfilingMemory内存Dump |
| **LogManager** | WriteLog | 同LogManager.log |
|| WriteWarn | 同LogManager.warn |
|| LogManagerDebug | 同LogManager.debug |
|| LogManagerInfo | 同LogManager.info |
|| LogManagerLog | 同LogManager.log |
|| LogManagerWarn | 同LogManager.warn |
| **上报** | ReportUserBehaviorBranchAnalytics | 分支相关的UI组件相关事件的上报 |
|| UncaughtException | 异常上报 |
|| ReportGameSceneError | 上报游戏自定义场景的错误信息 |
| **插件配置** | SetDataCDN | 设置数据CDN |
|| SetPreloadList | 设置预加载列表 |
| **启动剧情** | GetLaunchOperaHandler | 获取启动剧情交互句柄 |
| **其他** | ReportGameStart | 游戏开始运行时上报 |
|| HideLoadingPage | 隐藏加载页 |
|| PreloadConcurrent | 控制预载并发数 |
|| OnLaunchProgress | 获取启动loader的启动数据 |

### 暂未支持的WXAPI

`暂未支持的WXAPI`中有一部分接口**需要在开放数据域调用**，故暂无法支持。

| 主类别 | 副类别 | 函数名 | 描述 |
|------|------|------|------|
| **基础** | **分包加载** | wx.loadSubpackage | 触发分包加载 |
| **转发** || wx.checkHandoffEnabled | 检查是否可以进行接力 |
||| wx.startHandoff | 开始进行接力 |
| **界面** | **窗口** | wx.setWindowSize | 设置窗口大小 |
| **网络** | **WebSocket** | wx.sendSocketMessage | 通过 WebSocket 连接发送数据 |
||| wx.onSocketOpen | 监听 WebSocket 连接打开事件 |
||| wx.onSocketMessage | 监听 WebSocket 接收到服务器的消息事件 |
||| wx.onSocketError | 监听 WebSocket 错误事件 |
||| wx.onSocketClose | 监听 WebSocket 连接关闭事件 |
||| wx.closeSocket | 关闭 WebSocket 连接 |
| **数据缓存** || wx.getStorage | 异步获取本地缓存 |
||| wx.setStorage | 异步存储本地缓存 |
||| wx.setStorageSync | 同步存储本地缓存 |
||| wx.getStorageSync | 同步获取本地缓存 |
||| wx.clearStorage | 异步清理本地缓存 |
||| wx.clearStorageSync | 同步清理本地缓存 |
||| wx.createBufferURL | 创建Buffer URL |
| **渲染** | **图片** | wx.createImage | 创建图片对象 |
| **开放接口** | **开放数据** | wx.getFriendCloudStorage | 获取同玩好友托管数据 |
||| wx.getGroupCloudStorage | 获取群同玩成员游戏数据 |
||| wx.getGroupInfo | 获取群信息 |
||| wx.getPotentialFriendList | 获取可能对游戏感兴趣的未注册的好友名单 |
||| wx.getUserCloudStorage | 获取当前用户托管数据 |
||| wx.getUserCloudStorageKeys | 获取当前用户托管数据键值 |
||| wx.modifyFriendInteractiveStorage | 修改好友的互动型托管数据 |
||| wx.shareMessageToFriend | 给指定的好友分享游戏信息 |
| **工具** || wx.encode | 将字符串编码成ArrayBuffer |
||| wx.decode | 将ArrayBuffer解码成字符串 |

## 调用方法

Unity 版本的 API 大体与[官网 API 文档](https://developers.weixin.qq.com/minigame/dev/api/)的 JS 版本 API 类似，使用时可以参考。

如 JS 版的 banner 广告的调用如下：

```js
var bannerAd = wx.createBannerAd({
    adUnitId: "xxxx",
    adIntervals: 30,
    style: {
        left: 0,
        top: 0,
        width: 600,
        height: 200,
    },
});
bannerAd.onLoad(() => {
    bannerAd.show();
});
bannerAd.onError((res) => {
    console.log(res);
});
```

而对于 Unity 版的调用如下：

```csharp
var bannerAd = WX.CreateBannerAd(new WXCreateBannerAdParam()
{
    adUnitId = "xxxx",
    adIntervals = 30,
    style = new Style()
    {
        left = 0,
        top = 0,
        width = 600,
        height = 200
    }
});
bannerAd.OnLoad(()=> {
    bannerAd.Show();
});
bannerAd.OnError((WXADErrorResponse res)=>
{
    Debug.Log(res.errCode);
});
```

大体是将 JS 版中的`wx`替换为 Unity 版的`WX`,然后对应方法名首字母由小写改为大写，如`createBannerAd`就变为`CreateBannerAd`

## 基础库

-   [基础库介绍](https://developers.weixin.qq.com/miniprogram/dev/framework/client-lib/)
-   [基础库版本分布](https://developers.weixin.qq.com/miniprogram/dev/framework/client-lib/version.html)

### 在 Unity 中兼容低版本基础库

使用`WX.CanIUse`可以判断当前版本是否支持该 API（仅支持 wx），例如想要判断当前环境`WX.ReportScene`是否可用，可以用`WX.CanIUse("ReportScene")`来判断

## 开发建议

### API 示例

使用示例我们会逐渐补充到[Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo), 其中 API 项目为常见使用范例，请优先查阅用法。

### 联调效率

如果开发者有简单的 JS 代码经验，建议先以 JS 方式直接修改 minigame 的 JS 代码进行调试，完成之后再使用 C# SDK 修改 Unity 工程：

1. 只保留 game.js 前面 import 部分，其余删除，即不运行游戏逻辑。
2. 增加以下代码：

```js
const gl = GameGlobal.canvas.getContext("webgl");
gl.clear(gl.COLOR_BUFFER_BIT);
```

3. 使用 JS 编写需要调试的 API

## 注意事项

1. 广告接口是否需要上线后才能调试

-   是的，需要上线并累计 UV>1000 才可以开通广告主
