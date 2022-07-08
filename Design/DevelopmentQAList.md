# 技术常见问题QA
## 工具使用
1. 微信开发者工具打开时提示“app.json未找到”
- 请注册小程序appid，并申请为小游戏服务类目
- 请参考[小游戏开发者文档-注册一个小游戏帐号](https://developers.weixin.qq.com/minigame/dev/guide)
2. 微信开发者工具打开时提示“找不到game.json或读取错误”
- 打开导出目录/minigame文件夹而不是导出的根目录
3. Unity PlayerSettings导出选项中使用"brotli"或"gzip", 使用微信开发者工具无法启动游戏
- 请勿修改PlayerSettings的压缩选项，保持为不压缩
- 转换工具对代码包自动进行br压缩
- 资源包请使用CDN gzip/br, 传输大小与zip压缩后体积相当
4. 使用代码分包的情况下，启动游戏出现“首次拉取代码分包”提示
- 原因是收集函数不够完备，查看分包工具是否有新收集函数，重新生成一轮即可
- 该提示仅在开发版本提示，代表在“引擎+业务首场景”初始化时遇到了缺失函数

  
## Unity WebGL
1. 能否使用System.Net命名空间下的接口
- 不行，WebGL导出时网络需要进行改造适配，请参考文档[网络通信适配](UsingNetworking.md)
2. 小游戏启动出现"Unable to load DLL ...."  
-  WebGL模式不允许加载非源码编译的插件，需游戏自行排查
-  典型地，如System.Net、lua外部模块、某些依赖平台的第三方插件
1. 能否使用System.File相关接口做文件存储
 - 如果是资源(比如AssetBundle)需要进行缓存, 适配插件已自动完成，注意bundle命名规则和缓存策略即可，请参考文档[资源部署与缓存](DataCDN.md)
 - 如果是玩家存档，可使用C# SDK中的小游戏存储接口。此外，更建议使用服务器或云开发进行定期存储，因为微信用户更容易删除小程序，文件存储将随之被删除。
3. 如何接入第三方的js sdk, 能写js脚本和C#进行交互吗？
- 可以，请参考我们提供的C# SDK写法，原理也是利用到了JS与C#互通的特性。具体方式请参考Unity官方文档[Interaction with browser scripting](https://docs.unity3d.com/cn/2021.3/Manual/webgl-interactingwithbrowserscripting.html)
4. 小游戏的中文字体不显示，但Editor没问题
- WebGL环境下的中文字体需要打包（首资源包或Bundle），无法使用操作系统字体
5. 游戏逻辑是否能使用lua
- 可以，但具体性能需自己实际评测，请参照[Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo)示例。
- lua可使用AssetBundle方式整体打包，require时使用bundle.LoadAsset同步接口获取脚本
6. Touch事件丢失或错误，导致多点触控不正确
- 请将WXTouchInputOverride.cs附加到EventSystem对象上，已测试EasyTouch、UGUI、FairGUI可正常工作
7. 显示黑屏，运行提示大量shader编译错误
- 默认导出未webgl1, 请确认游戏是否依赖webgl2(opengles3.0)
- 导出选项勾选webgl2实验能力
  
## 平台适配
1. 文本输入框点击无法输入，没有弹出输入法
- 请参考小游戏输入法API进行适配
2. 高性能模式下iOS无法加载，但Android和微信开发者工具没问题
- 请参考文档[iOS高性能模式](iOSOptimization.md)QA部分
3. Android运行达到满帧较为流畅，iOS性能差
- 请参考文档[iOS高性能模式](iOSOptimization.md)概述部分
4. 小游戏中能插入超链接跳转网页吗？
- 不行，不提供内嵌webview或跳转的能力
5. 小游戏是否支持Unity Video
- 不行，小游戏支持视频播放能力，但暂无法与Unity元素进行融合。请参考[小游戏开发者文档](https://developers.weixin.qq.com/minigame/dev/api/media/video/wx.createVideo.html)



