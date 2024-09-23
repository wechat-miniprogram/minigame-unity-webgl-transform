# SDK 调用微信 API

将 WX-WASM-SDK 这个目录拷贝至 unity 工程 Assets 目录下,在主入口初始化，回调后再执行你的主逻辑

```
WX.InitSDK((int code)=> {
// 你的主逻辑
});
```

API 可以直接看`WX.cs`这个文件，里面有`详细注释说明`。

本 Unity 的 SDK 的 API 大体与[官网 API 文档](https://developers.weixin.qq.com/minigame/dev/api/)的 JS 版本 API 类似，使用时可以参考之。
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

### Demo API 示例

使用示例我们会逐渐补充到[Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo), 其中 API 项目为常见到使用范例，请优先查阅用法。

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

