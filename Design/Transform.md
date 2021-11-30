# 转换工具导出微信小游戏

## 一、Unity导出WebGL

添加需要导出的scene
   
<image src='../image/scene.png' width="600"/>

建议仅勾选Loading场景，后续场景使用AssetsBundle/Addressable进行按需加载。


## 二、适配小游戏
1. Mac上授权  
因为Mac上的隐私安全问题，使用mac的用户需要先授权，使用window的用户跳过这步。点击"微信小游戏"->"MacOS脚本授权",进行授权，直到不报错为止。若授权后还是报错，重启unity后再点授权试试。
2. 选择 点击 微信小游戏 -> 转换小游戏， 填写相应参数，点击`导出WEBGL并转换为小游戏`按钮 ，等待转换完成。

<image src='../image/export.png' width="600"/>

其中：
1. 必须
- 游戏appid：小游戏的appid
- 游戏资源CDN：游戏资源所在HTTP或CDN地址
- 导出路径：转换后文件目录
2. 可选
- 小游戏项目名：开发者工具中展示的小游戏项目名
- 首包资源加载方式：CDN-使用CDN下载首包资源；小游戏分包-使用小游戏代码分包下载资源
- 加载阶段视频URL：启动需要一定耗时，在启动加载时会循环播放这段视频，视频格式请参考[视频规范](video.md)
- 启动背景/视频封面图：启动阶段背景图片；如果配置了加载阶段视频URL，则作为视频封面。
- 游戏方向：游戏是横屏还是竖屏，可选值参考[deviceOrientation](https://developers.weixin.qq.com/minigame/dev/reference/configuration/app.html)
- 不自动缓存文件类型：游戏资源CDN下不自动缓存的文件类型，具体参见[AssetBundle缓存]](UsingLoader.md)
- Bundle名中Hash长度：自定义AssetBundle名中Hash长度用于缓存控制，具体参见[AssetBundle缓存](UsingLoader.md)
- 预下载列表：网络空闲时预下载的资源，[使用预下载](UsingPreload.md)
- SDK功能选项：[好友关系链](OpenData.md) [音频优化](AudioOptimization.md)
- 调试编译选项

转换完成后，参照[资源部署与缓存](DataCDN.md)章节进行资源部署，并了解启动Loader在加载资源时的缓存逻辑。

注意：
* 项目使用了小游戏Unity适配插件，若小游戏是第一次使用本插件，在开发者工具会报错提示插件未授权，具体可参考[使用Loader进行游游戏加载](UsingLoader.md)

至此，可以在[微信开发者工具](https://developers.weixin.qq.com/miniprogram/dev/devtools/download.html)打开转化后的小游戏进行预览。
 
## 三、使用脚本集成到自己的构建系统
如果你希望将导出插件集成到自己的发布流程，想脚本调用的话，可修改 Assets/WX-WASM-SDK/Editor/MiniGameConfig.asset配置，然后调用WXEditorWindow 的 DoExport方法导出小游戏   
 ```
 var win = new WXEditorWindow();
 win.DoExport();
 ```

## 四、常见问题
1. 为什么资源或网络请求在打开"vConsole"正常，关闭时下载失败？
网络请求必须**配置安全域名**：https://developers.weixin.qq.com/minigame/dev/guide/base-ability/network.html
打开"vConsole"时，小游戏默认不检查因此能请求通过。

2. 中文字体适配
字体必须打包到项目中，才能正常展示。

3. 音频被切到后台会停止
小游戏被切到后台会停止播放音频需代码中监听 [WX.OnShow](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html)事件和 [WX.OnAudioInterruptionEnd](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onAudioInterruptionEnd.html)事件，在该事件之后重新播放音频
