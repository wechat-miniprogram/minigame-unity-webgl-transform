## 音频

目前 UnityAudio 已自动适配微信小游戏，优先建议使用 UnityAudio 来播放音频，也支持FMOD插件

## 兼容原理

UnityAudio原理：
- 长音频播放使用的是[InnerAudio](https://developers.weixin.qq.com/minigame/dev/api/media/audio/InnerAudioContext.html) 
- 短音频播放使用的是[WebAudio](https://developers.weixin.qq.com/minigame/dev/api/media/audio/WebAudioContext.html)
- 插件代码根据音频文件大小自动适配使用不同的播放方式

FMOD原理：
- 全部使用[WebAudio](https://developers.weixin.qq.com/minigame/dev/api/media/audio/WebAudioContext.html)，因此不推荐背景音乐等大文件使用FMOD播放，会占用很大内存

### QA

1. 在IOS 17.5以上的版本，小游戏退后台后返回音效无法继续播放了
- 可以尝试更新最新的插件版本，可以避免一些出现的情况，我们正在尝试兼容IOS的更新

2. IOS偶现音频报错operateAudio:fail jsapi has no permission
- 音频播放时小游戏退后台就有可能出现，没有实际影响，可以忽略

3. 音频播放时游戏卡顿
- 如果同时播放的音频数量过多，是有可能造成游戏延迟卡顿的，建议限制同时播放的音频数量

4. 部分音频文件在安卓无法循环播放
- 已知问题，8.0.51客户端版本修复

5. 音频在PC端无法循环播放完整音频
- 已知问题，更新最新的Unity导出插件

6. 推荐使用什么音频格式
- 推荐mp3或者aac格式，在双端有较好的兼容

## 视频

目前 VideoPlayer 已自动适配微信小游戏

### 支持版本
不同客户端的支持情况不同，以下为最低支持版本：

| 参数        | 版本                        |
| ----------- | --------------------------- |
| IOS 高性能+ | 8.0.51(未发布)              |
| IOS 高性能  | 8.0.41                      |
| 安卓        | 8.0.40                      |
| PC          | 基础库 3.2.1                |
| 开发者工具  | 基础库 3.2.1 + 1.06.2310312 |

### QA

1. 我的视频在IOS无法播放，在其他平台都可以播放
- 可以尝试把视频播放链接替换我们这个视频链接试试看是否正常，一般这种情况都是服务端设置问题，会报错Origin weapp://wechat-game-runtime is not allowed by Access-Control-Allow-Origin，但是没有打印到客户端，只需要配置服务端允许微信跨域访问即可（视频链接：https://wxsnsdy.tc.qq.com/105/20210/snsdyvideodownload?filekey=30280201010421301f0201690402534804102ca905ce620b1241b726bc41dcff44e00204012882540400&bizid=1023&hy=SH&fileparam=302c020101042530230204136ffd93020457e3c4ff02024ef202031e8d7f02030f42400204045a320a0201000400 ）

2. 我的视频在IOS播放有声音没画面
- 开启了高性能+，先临时关闭高性能+

3. 为什么IOS高性能模式只能同时播放一个视频
- IOS的播放策略，只能从逻辑上兼容

4. 是否应该使用VideoPlayer？
- 如果只是单纯使用全屏的视频播放，更推荐使用小游戏API视频播放能力。请参考[小游戏开发者文档](https://developers.weixin.qq.com/minigame/dev/api/media/video/wx.createVideo.html)以及示例[Video Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo/WX_Video)