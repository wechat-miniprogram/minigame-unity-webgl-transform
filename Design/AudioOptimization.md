# 为何需要音频优化

1. Unity2021 版本之前的音频不支持压缩音频，在引擎 CPU 侧解压会消耗大量内存
2. iOS 高性能模式下，Unity WebGL 默认使用 WebAudio 会消耗游戏进程大量内存(特别是时长较大的音频)
3. 减少音频重复下载，音频保存本地可以反复使用

我们建议将 Unity Audio 替换成 SDK 中的音频 API 控制播放。如果工作量太大，也建议替换长音频(如 BGM)。

## API 使用

### 接口使用

参考[微信开发者文档](https://developers.weixin.qq.com/minigame/dev/api/media/audio/InnerAudioContext.html)
其中src为音频地址，可填本地路径如 xx.wav，运行时会自动和配置的音频地址前缀(默认为DATA_CDN/Assets)做拼接得到最终线上地址。

* 使用方法一:


```c#
// 使用方法一：创建音频对象可以在初始化是加上needDownload = true，音频会先下载到本地，然后再播放
// 保存本地后，同样的路径不会重复下载，再次使用时无需下载
var audio1 = WX.CreateInnerAudioContext(new InnerAudioContextParam()
{
    src = "Audio/0.wav",
    needDownload = true
});
// 在可以播放时播放
audio1.OnCanplay(() =>
{
    audio1.Play();
});


// 使用方法二：创建音频对象，不设置下载，音频在准备完成后会立即开始播放，并且边下边播
// 这样下载的缓存并不会保存到本地，再次使用时依然会重复下载，推荐频率少或者一次性使用的音频这样处理
var audio2 = WX.CreateInnerAudioContext(new InnerAudioContextParam()
{
    src = "Audio/1.wav",
});
// 在可以播放时播放
audio2.OnCanplay(() =>
{
    audio2.Play();
});


// 使用方法三：先提前创建音频对象，批量下载音频文件，在下载完成后可以直接修改音频对象的src并播放
string[] a = { "Audio/0.wav", "Audio/1.wav", "Audio/2.wav" }; 
var audio3 = WX.CreateInnerAudioContext(new InnerAudioContextParam(){ needDownload = true });
WX.PreDownloadAudios(a, (int res) =>
{
    // 下载完成后回调
    if (res == 0)
    {
        audio3.src = "Audio/2.wav"
        audio3.OnCanplay(() =>
        {
            audio3.Play();
        });
    }
});
```

## 参考示例
音频一般最多只能同时存在10个，所以必须要开发者自己控制音频对象池重复使用，可以参考以下示例：
[音频示例](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Demo/API/Assets/Scripts/AudioManager.cs)

## 示例补充说明
- 示例只是作为参考，可以不按照示例，以开发者文档为准
- WX.CreateInnerAudioContext 返回的音频对象是可以复用的，可以多次调用 Play 方法播放，但是如果需要多个音频同时播放就要创建多个音频对象。
- 其中音频 src 为音频地址，可填本地路径如 Audios/xx.wav，运行时会自动和配置的音频地址前缀(默认为 DATA_CDN/Assets)做拼接得到最终线上地址。
- 音频需要等待`onCanplay`事件之后再调用`Play`播放。onCanplay 事件是表示，当前音频已经可以播了，

## 保存文件到本地

在使用 WX.CreateInnerAudioContext 时设置了 needDownload 属性或者使用 WX.PreDownloadAudios 下载音频时，会自动把符合[自动缓存规则](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/FileCache.md#%E4%BA%8C%E5%93%AA%E4%BA%9B%E8%B5%84%E6%BA%90%E4%BC%9A%E8%87%AA%E5%8A%A8%E7%BC%93%E5%AD%98)的文件保存到本地，下次启动游戏时可以无需下载

## 导出设置

勾选使用微信音频 API，并填上"游戏资源 CDN"，比如填写的地址为https://wx.qq.com/data/ ，而 API 的 src 地址为 Audio/Chill_1.wav，则最终请求路径会自动拼接前缀 DATA_CDN/Assets(其中 Assets 路径可通过 MiniGameConfig.asset 更改), 即https://wx.qq.com/data/Assets/Audio/Chill_1.wav。

## 将音频文件上传 CDN

游戏内的音频会被导出到导出目录的 Assets 文件夹下，需要将其上传至您的 CDN，保证用户能访问到

![avatar](../image/assets2.png)

## 注意事项

- 使用微信音频 API 后音频无需再监听 onAudioInterruptionBegin，onAudioInterruptionEnd 事件，插件会自动处理。
- 音频未使用 needDownload=true 或 PreDownloadAudios 的情况下，音频文件是不还被缓存的，多次创建并播放同样音频会造成多次下载。需要游戏逻辑自己负责缓存音频对象（就是 WX.CreateInnerAudioContext 的对象需要自己缓存）。
