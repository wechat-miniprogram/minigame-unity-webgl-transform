# 调试错误与异常处理


本文描述Unity WebGL游戏运行过程中，如果遇到异常(业务代码、引擎)时开发者应该如何进行调试。

## 开启代码异常
<image src='../image/howtodebug1.png' width="600"/>

> 默认情况下，使用“转换插件”这两个选项都已设置完成。

需要说明的是：
* Enable Exception如果设置为"Full Without StackTrace"时将会步骤更多引擎运行时产生的异常。
* Enable Exception如果设置为"Full With StackTrace"时将会看到更多信息，但程序运行性能将受极大影响。
* Debug Symbols不会对程序性能造成影响，该选项建议一直开启，用于后面做异常源码映射。



## 异常产生时如何排查
由于Unity WebGL运行时是基于WebAssembly，该格式并非“人类可读”，直接对WebAssembly进行调试会非常困难。
因此我们建议开发者使用日志与异常堆栈进行问题排查。对于未知问题，开发者往往需要异常产生时的堆栈找到蛛丝马迹，下文将引导开发者如何去根据WebAssembly找到对应的游戏工程源码所在位置。

### 微信开发者工具


### 真机环境



1. 已验证Unity版本：2018.3/2018.4LTS、2019.2/2019.4LTS
安装时选择WebGL组件
2. 如果你用的是Big Sur版本的Mac系统，并且Unity 版本小于 2019.4.14, 则需另外安装 [python3](https://www.python.org/downloads/)，并安装brotli 命令如下
```
python3 -m pip install brotli  
```

## 二、Unity导出WebGL

1. 下载 [Unity插件](http://res.wx.qq.com/wechatgame/product/webpack/userupload/wasm_plugin/minigame.unitypackage), 并导入至游戏项目中

2. 添加需要导出的scene
   
<image src='../image/scene.png' width="600"/>

建议仅勾选Loading场景，后续场景使用AssetsBundle/Addressable进行按需加载。


## 三、适配小游戏
1. Mac上授权  
因为Mac上的隐私安全问题，使用mac的用户需要先授权，使用window的用户跳过这步。点击"微信小游戏"->"MacOS脚本授权",进行授权，直到不报错为止。若授权后还是报错，重启unity后再点授权试试。
2. 选择 点击 微信小游戏 -> 转换小游戏， 填写相应参数，点击`导出WEBGL并转换为小游戏`按钮 ，等待转换完成。

<image src='../image/export.png' width="600"/>

其中：
* 必须：appid 为 小游戏的Appid
* 必须：游戏资源CDN为首包资源所在的HTTP或CDN目录
* 可选：视频url 用来作为初始加载阶段的封面视频，视频格式请参考[视频规范](Design/video.md)
* 可选：AB包CDN地址为StreamingAssets目录的上一级注意末尾加`/`,若没有用到AB包则不需要填
生成目录下 webgl目录为游戏对应的webgl版本，minigame目录为转化后的小游戏代码。

注意：
* 将生成目录下的`webgl/ProjectName.data.unityweb.bin.txt`上传至“游戏资源CDN”。您的CDN最好支持gzip压缩txt文件，这样能减少网络传输数据和时间。
* 项目使用了小游戏Unity适配插件，若小游戏是第一次使用本插件，在开发者工具会报错提示插件未授权，具体可参考[使用Loader进行游游戏加载](UsingLoader.md)
* 使用AssetsBundle时，请将资源上传到“AB包CDN地址”

至此，可以在[微信开发者工具](https://developers.weixin.qq.com/miniprogram/dev/devtools/download.html)打开转化后的小游戏进行预览。
 
## 四、使用脚本集成到自己的构建系统
如果你希望将导出插件集成到自己的发布流程，想脚本调用的话，可修改 Assets/WX-WASM-SDK/Editor/MiniGameConfig.asset配置，然后调用WXEditorWindow 的 DoExport方法导出小游戏   
 ```
 var win = new WXEditorWindow();
 win.DoExport();
 ```

## 五、常见问题
1. 微信版本与运行时基础要求是什么？

* Android版本必须>=7.0.19
* iOS版本必须>=7.0.18
* 基础库版本必须>=2.14.0
具体支持情况参考[支持平台](Design/SupportedPlatform.md)

2. 为什么运行时出现奇怪的“Maximun call stack size exceeded.RangeError”或“Not Impletemented: Class::FromIL2CPPType”？
 Unity WebGL 首包资源data文件含有metadata，如果data资源包和wasm对不上会有各种问题，尤其在**浏览器**运行时需清理IndexedDB中的缓存。

3. 为什么资源或网络请求在打开"vConsole"正常，关闭时下载失败？
网络请求必须**配置安全域名**：https://developers.weixin.qq.com/minigame/dev/guide/base-ability/network.html
打开"vConsole"时，小游戏默认不检查因此能请求通过。

4. 中文字体适配
字体必须打包到项目中，才能正常展示。

5. 音频被切到后台会停止
小游戏被切到后台会停止播放音频需代码中监听 [WX.OnShow](https://developers.weixin.qq.com/minigame/dev/api/base/app/life-cycle/wx.onShow.html)事件和 [WX.OnAudioInterruptionEnd](https://developers.weixin.qq.com/minigame/dev/api/base/app/app-event/wx.onAudioInterruptionEnd.html)事件，在该事件之后重新播放音频
