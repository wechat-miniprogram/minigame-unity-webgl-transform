# SDK 调用微信API
   将 WX-WASM-SDK 这个目录拷贝至unity工程 Assets目录下,在主入口初始化，回调后再执行你的主逻辑
```
WX.InitSDK((int code)=> {
// 你的主逻辑
}); 
```   

API可以直接看`WX.cs`这个文件，里面有`详细注释说明`。

本Unity的SDK的API大体与[官网](https://developers.weixin.qq.com/minigame/dev/guide/)的JS版本API类似，使用时可以参考之。
如JS版的banner广告的调用如下：
```js
    var bannerAd = wx.createBannerAd({
        adUnitId: "xxxx",
        adIntervals: 30,
        style: {
            left: 0,
            top: 0,
            width: 600,
            height:200
        }
    });
    bannerAd.onLoad(() => {
        bannerAd.show();
    });
    bannerAd.onError((res)=>{
        console.log(res);
    });
```
而对于Unity版的调用如下：
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
大体是将JS版中的`wx`替换为Unity版的`WX`,然后对应方法名首字母由小写改为大写，如`createBannerAd`就变为`CreateBannerAd`

## 开发建议
### Demo API示例
使用示例我们会逐渐补充到[Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo), 其中API项目为常见到使用范例，请优先查阅用法。

### 联调效率
如果开发者有简单的JS代码经验，建议先以JS方式直接修改minigame的JS代码进行调试，完成之后再使用C# SDK修改Unity工程：
1. 只保留game.js前面import部分，其余删除，即不运行游戏逻辑。
2. 增加以下代码：

```js
    const gl = GameGlobal.canvas.getContext('webgl') 
    gl.clear(gl.COLOR_BUFFER_BIT);
```
3. 使用JS编写需要调试的API

## 注意事项
1. 广告接口是否需要上线后才能调试
- 是的，需要上线并累计UV>1000才可以开通广告主
