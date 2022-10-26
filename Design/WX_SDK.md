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
```
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
```

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

``` 
    const gl = GameGlobal.canvas.getContext('webgl') 
    gl.clear(gl.COLOR_BUFFER_BIT);
```
3. 使用JS编写需要调试的API

## 注意事项
1. 广告接口是否需要上线后才能调试
- 是的，需要上线并累计UV>1000才可以开通广告主

## 目前已完成API列表：
<table>
    <tr>
        <th>分类</th>
        <th>类名</th>
        <th>方法名</th>
    </tr>
    <tr>
        <td>初始化SDK</td>
        <td rowspan="64">WX</td>
        <td>InitSDK</td>
    </tr>
    <tr>
        <td rowspan="2">振动</td>
        <td>VibrateShort</td>
    </tr>
    <tr>
        <td>VibrateLong</td>
    </tr>
    <tr>
        <td rowspan="9">本地存储</td>
        <td>StorageSetIntSync</td>
    </tr>
    <tr>
        <td>StorageGetIntSync</td>
    </tr>
    <tr>
        <td>StorageSetStringSync</td>
    </tr>
    <tr>
        <td>StorageGetStringSync</td>
    </tr>
    <tr>
        <td>StorageSetFloatSync</td>
    </tr>
    <tr>
        <td>StorageGetFloatSync</td>
    </tr>
    <tr>
        <td>StorageDeleteAllSync</td>
    </tr>
    <tr>
        <td>StorageDeleteKeySync</td>
    </tr>
    <tr>
        <td>StorageHasKeySync</td>
    </tr>
    <tr>
        <td rowspan="3">登录 <a href="https://developers.weixin.qq.com/minigame/dev/guide/open-ability/login.html">参考地址</a></td>
        <td>Login </td>
    </tr>
    <tr>
        <td>CheckSession</td>
    </tr>
    <tr>
        <td>Authorize</td>
    </tr>
    <tr>
        <td rowspan="2">用户信息 <a href="https://developers.weixin.qq.com/minigame/dev/guide/open-ability/user-info.html">参考地址</a></td>
        <td>GetUserInfo</td>
    </tr>
    <tr>
        <td>CreateUserInfoButton</td>
    </tr>
    <tr>
        <td rowspan="3">客户端信息</td>
        <td>GetSystemInfo</td>
    </tr>
    <tr>
        <td>GetSystemInfoSync</td>
    </tr>
    <tr>
        <td>GetSystemLanguage</td>
    </tr>
    <tr>
        <td rowspan="14">分享转发 <a href="https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/share.html">参考地址</a></td>
        <td>UpdateShareMenu</td>
    </tr>
    <tr>
        <td>ShowShareMenu</td>
    </tr>
    <tr>
        <td>HideShareMenu</td>
    </tr>
    <tr>
        <td>SetMessageToFriendQuery</td>
    </tr>
    <tr>
        <td>ShareAppMessage</td>
    </tr>
    <tr>
        <td>ShowShareMenu</td>
    </tr>
    <tr>
        <td>OnShareAppMessage</td>
    </tr>
    <tr>
        <td>OffShareAppMessage</td>
    </tr>
    <tr>
        <td>OnShareTimeline</td>
    </tr>
    <tr>
        <td>OffShareTimeline</td>
    </tr>
    <tr>
        <td>OnAddToFavorites</td>
    </tr>
    <tr>
        <td>OffAddToFavorites</td>
    </tr>
    <tr>
        <td>GetShareInfo</td>
    </tr>
    <tr>
        <td>AuthPrivateMessage</td>
    </tr>
    <tr>
        <td rowspan="6">广告 <a href="https://developers.weixin.qq.com/minigame/dev/guide/open-ability/ad/ad.html">参考地址</a></td>
        <td>CreateRewardedVideoAd</td>
    </tr>
    <tr>
        <td>CreateFixedBottomMiddleBannerAd</td>
    </tr>
    <tr>
        <td>CreateInterstitialAd</td>
    </tr>
    <tr>
        <td>CreateGridAd</td>
    </tr>
    <tr>
        <td>CreateBannerAd</td>
    </tr>
    <tr>
        <td>CreateCustomAd</td>
    </tr>
    <tr>
    <td rowspan="9">生命周期</td>
        <td>OnShow</td>
    </tr>
    <tr>
        <td>OffShow</td>
    </tr>
    <tr>
        <td>OnHide</td>
    </tr>
    <tr>
        <td>OffHide</td>
    </tr>
    <tr>
        <td>GetLaunchOptionsSync</td>
    </tr>
    <tr>
        <td>OnAudioInterruptionBegin</td>
    </tr>
    <tr>
        <td>OnAudioInterruptionEnd</td>
    </tr>
    <tr>
        <td>OffAudioInterruptionEnd</td>
    </tr>
    <tr>
        <td>OffAudioInterruptionBegin</td>
    </tr>
    <tr>
        <td >文件</td>
        <td>GetFileSystemManager</td>
    </tr>
    <tr>
        <td rowspan="5">开放数据</td>
        <td>GetOpenDataContext</td>
    </tr>
    <tr>
        <td>ShowOpenData</td>
    </tr>
    <tr>
        <td>HideOpenData</td>
    </tr>
    <tr>
        <td>SetUserCloudStorage</td>
    </tr>
    <tr>
        <td>RemoveUserCloudStorage</td>
    </tr>
    <tr>
        <td rowspan="9">输入法</td>
        <td>UpdateKeyboard</td>
    </tr>
    <tr>
        <td>ShowKeyboard</td>
    </tr>
    <tr>
        <td>HideKeyboard</td>
    </tr>
    <tr>
        <td>OnKeyboardInput</td>
    </tr>
    <tr>
        <td>OnKeyboardConfirm</td>
    </tr>
    <tr>
        <td>OnKeyboardComplete</td>
    </tr>
    <tr>
        <td>OffKeyboardInput</td>
    </tr>
    <tr>
        <td>OffKeyboardConfirm</td>
    </tr>
    <tr>
        <td>OffKeyboardComplete</td>
    </tr>
    <tr>
        <td>渲染</td>
        <td>WXCanvas</td>
        <td>ToTempFilePathSync</td>
    </tr>
</table>


