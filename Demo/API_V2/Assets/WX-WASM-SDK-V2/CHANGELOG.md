<!-- 
Feature － 新增功能/接口
Changed - 功能/接口变更
Deprecated - 不建议使用的功能/接口
Removed - 删除功能/接口
Fixed - 修复问题
Others - 其他 
-->
## 2024-5-15 【普通更新】
### Feature
* 普通：支持JS构建模板，请查阅[模板文档](https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/Design/BuildTemplate.html)
* 普通：调整启动封面表现，默认进度动画加速
* 普通：writeFile/unlink操作文件时同步更新启动插件维护的缓存信息
* 普通：支持自定义微信系统字体字符集
* 普通：网络接口如UnityWebRequest支持通过添加特殊请求头`request.SetRequestHeader("wechatminigame-preload", "1")`做预下载，缓存到用户目录但不增加unity内存。当需要使用时不增加请求头重新请求即可从用户目录读取缓存使用。
* 普通：网络接口如UnityWebRequest支持通过添加特殊请求头`request.SetRequestHeader("wechatminigame-skipclean", "1")`不做旧缓存淘汰。
* 普通：适配插件版本升级到1.2.50

## 2024-5-15 【普通更新】
### Fixed
* 普通：修复团结版dotnet wasm加载报错
* 普通：修复音频的长度为负数时的异常stop
* 普通：修复配置文件重置bug

## 2024-4-17 【普通更新】
### Feature
* 普通：编译参数增加ERROR_ON_UNDEFINED_SYMBOLS
* 适配插件版本升级到1.2.45
### Fixed
* 普通：修复团结版dotnet wasm加载报错
* 普通：修复音频的长度为负数时的异常stop
* 普通：修复配置文件重置bug

## 2024-4-3 【重要更新】
包含重要bugfix、特性支持
### Fixed
* 重要：修复UDP接口处理buffer
* 重要：修复unity-namespace.js部分环境变量丢失问题

## 2024-3-28 【普通更新】
### Feature
* 普通：优化对团结版的导出支持
### Fixed
* 普通：兼容PlayDelayed播放
* 普通：兼容FMOD2.02版本
* 普通：修复FState偶现报错

## 2024-3-5 【普通更新】
### Feature
* 普通：WXAssetBundle支持切换CDN
* 普通：优化VideoPlayer组件
* 普通：更新小游戏模板捕获全局错误
* 普通：高性能+模式不再限制需要iOS>15.0
### Fixed
* 普通：修复wx.onBluetoothDeviceFound
* 普通：修复wx.onUserCaptureScreen
* 普通：修复wx.getAppAuthorizeSetting
* 普通：修复fs.stat
* 普通：修复截屏回调
* 普通：unity21.3网络超时时间设置

## 2024-1-18 【普通更新】
* 普通：更新适配插件版本到1.2.38
### Fixed
* 普通：不支持WebGL2的旧Android微信版本提供升级指引

## 2024-1-15 【普通更新】
### Feature
* 重要：增加iOS高性能+(iOSPerformancePlus)选项，请查阅[高性能+模式](https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-high-performance-plus.html)，有助于提升渲染兼容性、降低WebContent进程内存
* 普通：陀螺仪去json性能优化
### Fixed
* 普通：修复蓝牙数据传输问题
* 普通：修复广告低版本微信ReportshareBehavior上报问题
* 普通：修复2021.3.33 ContextMenu适配
* 普通：修复开放域排行榜触控 

## 2024-1-2 【重要更新】
包含重要bugfix、特性支持
### Feature
* 普通：启动剧情新增Hash 、版本号兼容验证逻辑
* 普通：转换配置新增iOS dpr选项
* 普通：C# SDK支持文档注释
### Fixed
* 重要：修复Android系统代码分包Patch功能不生效的问题(需同时升级分包工具插件至1.1.12)
* 普通：修复压缩纹理工具在一些特殊字符转义失败的bug

## 2023-12-18 重要更新】
包含重要bugfix、特性支持
### Feature
* 普通：TouchStart/TouchEnd去json性能优化
### Fixed
* 重要：修复TCP接口处理buffer

## 2023-12-12
【重要更新】包含重要bugfix、特性支持
### Feature
* 重要：优化TCP接口能力，使用请查阅[网络通信适配](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/UsingNetworking.md)
* 重要：优化UDP接口能力
* 普通：优化启动剧情能力(Beta)
* 普通：增加接口WX.CanIUse

## 2023-12-08
【重要更新】包含重要bugfix、特性支持
### Feature
* 重要：新增启动剧情能力(Beta)
* 重要：新增TCP接口能力
* 普通：更新适配插件版本到1.2.34
### Fixed
* 严重：修复TouchMove在<iOS 15.0系统BigUnit64Array兼容性问题
* 严重：修复适配插件处理代码分包时序导致的一定概率启动失败

## 2023-11-29
【普通更新】
### Fixed
* 普通：修复TouchMove优化在2020之前版本产生的导出错误

## 2023-11-28
【重要更新】包含重要bugfix、特性支持
### Feature
* 普通：FileSystem Stat支持isDirectory和isFile
* 普通：优化胶水层代码，删减多余代码
* 重要：TouchMove触摸性能优化
* 重要：优化微信字体所占用的MonoHeap临时内存
### Fixed
* 普通：修复IOS音频被打断无法重新播放
* 普通：修复2022导出Video的BUG

## 2023-11-10
【普通更新】
### Feature
* 普通：支持2022 Input Field组件适配微信输入法
* 普通：PC端和开发者工具支持Unity VideoPlayer组件

## 2023-11-02
【普通更新】
### Fixed
* 修复部分首资源包压缩异常问题

## 2023-10-20
【普通更新】
### Feature
* 重要：Unity2022 development build的导出支持
* 普通：更新小游戏云测试profile获取的性能数据
### Fixed
* 普通：修复微信压缩纹理工具对音频ab包的处理bug问题
* 普通：修复微信压缩纹理工具在 MacOS M1系列芯片执行异常问题

## 2023-10-11【普通更新】
### Feature
* 适配Video Player, 安卓3.0.0基础库/IOS 3.1.1基础库且只支持播放一个视频

## 2023-9-26
【重要更新】包含重要bugfix、特性支持
### Feature
* 适配Application.targetFramerate，无需再调用小游戏的帧率设置API
### Fixed
* 重要：修复wasm分包patch未生效的问题
* 重要：修复WXAssetBundle在异常时上报错误
* 更新适配插件版本到1.2.31

## 2023-09-20
### Feature
* API协议更新至3.0.1版本，增加模糊地理位置获取接口
* 更新适配插件版本到1.2.29

## 2023-09-01
### Feature
* 微信压缩纹理工具Unity全版本支持
### Fixed 
* 修复WXAssetBundle WXUnload后再次Load同个AssetBundle可能出现的异常
* 优化WXAssetBundle当UnityWebRequest异常时DownloadHandlerWXAssetBundle.assetBundle返回null，不再直接崩溃
* 更新适配插件版本到1.2.26

## 2023-08-24
### Feature
* 适配AudioClip.GetData
* 更新适配插件版本到1.2.25
### Fixed 
* 修复旧版本安卓使用系统字体报错'SC Font not found in TTC File'
* 资源优化工具支持ASTC6*6格式

## 2023-08-18
### Feature
* 增加downloadfile（优化构建，支持创建类时传入success等会回调）
* 重构fs.readFile和fs.readFileSync，支持position和length参数
* 增加onMouseDown等PC点击事件
* 支持通过 `minigame/unity-namespace.js` 中函数 `isReportableHttpError` 忽略非重要网络异常上报，如心跳、数据分析接口
### Fixed 
* 修复使用 `WXAssetBundle` 且请求了不同版本的资源时报错'readFileSync:fail no such file or directory'
* pc下载资源出现'still downloading xxx'弹框时用户可尝试重启小游戏
* 修复最佳实践检测工具首资源包是否压缩判断

## 2023-08-10
### Feature
* 增加隐私信息授权API（requirePrivacyAuthorize等）
* 增加API-requestSubscribeLiveActivity
* WXAssetBundle兼容WebGL浏览器环境(回退至UnityWebRequestAssetBundle模式运行)
 
## 2023-08-3
### Feature
更新内容：
* 首资源包压缩后在pc上运行的基础库版本限制调整，CDN加载(>=2.32.3)，小游戏分包加载(2.29.2)
* 完善FileSystemManager
* Video支持修改属性
* development模式下，增加渲染性能检测日志
* 启动卡住时补充上报dependency
* 更新适配插件为1.2.23
### Fixed 
* 修复微信系统字体加载时报错'SC Font not found in TTC File'
* 忽略unity分析的网络失败上报
* 修正网络个数和HTTP2.0检测
* 修复wx.onCompassChange

## 2023-07-27
### Feature
* 转换插件添加启动并行下载配置
* 详细缓存日志不写入日志管理器
* pc增加是否支持brotli压缩条件判断
### Fixed
* 修复系统字体未正常预下载
* PC微信因loadSubPackage无回调的容错处理
* 修复最佳实践检测工具首资源包brotli压缩后仍提示未gzip/br压缩
* 修复AudioSource修改pitch失效
* 修复PC端OnKeyDown回调报错

## 2023-07-20
### Feature
* 补充启动阶段关键日志
* 新增米大师接口RequestMidasPaymentGameItem
* 更新适配插件1.2.19
### Fixed
* 首资源包校验兼容微信纹理压缩工具
* 移除不用的纹理下载API

## 2023-07-12
### Feature
* 增加选项Il2CppCodeGeneration，默认为Il2CppCodeGeneration.OptimizeSize
* 启动期间校验首资源包大小
* 更新适配插件1.2.18

## 2023-07-05
### Feature
* iOS高性能模式自动GC策略(默认10s GC)，可通过MiniGameConfig.asset-CompileOption-iOSAutoGCInterval调整间隔
* 支持对首资源包进行brotli压缩
### Fixed
* 性能面板数值显示优化

## 2023-06-29
### Feature
* 最佳实践预下载及网络下载检测项调整
* 增加OpenCustomerServiceChat
* 优化WXTouchInputOverride，在touchend时触发点击事件

### Fixed
* 修复微信系统字体在iOS上部分字符缺失
* 修复微信系统字体在安卓上字形异常
* 修复导出webgl的兼容逻辑

## 2023-06-16
### Fixed
* 修复Unity压缩选项导致出包错误
* 调整默认打开窗口宽度
* 修复打包后分包插件提示: '当前项目模板过旧，请使用新版unity导出插件重新导出项目

## 2023-06-14
### Feature
* 移除对Node.js依赖；
* 优化面板，提供Instant Game AutoStreaming自动配置与上传。
* 增加API getlogmanager/getrealtimelogmanager
### Fixed
* iOS高性能最低支持版本调整
* 微信系统字体预载bug修复
* 音频FMOD导出适配

## 2023-06-12
### Fixed
* plugins目录增加link.xml, 避免动态创建的类型被裁剪(如litjson解析)

## 2023-06-7
### Feature
* UnityWebRequest支持timeout属性
* 二次启动最佳实践检测逻辑调整
### Fixed
* 修复Unity 2022引擎版本导出Web版本的模板
* dev版本不处理symbols数据
* 修复微信系统字体多行重写的问题
* 修复微信系统字体在iOS系统部分缺失符号

## 2023-06-1
### Feature
* 支持Unity 2022引擎版本导出微信小游戏
* 优化framework胶水层获取Canvas与宽高属性的性能损耗
* ProfileStats性能面板增加FrameTime
* 支持WASM生成external symbols优化，无需Node支持
* 增加API CreateFeedbackButton
* 广告API customAd增加onHide
* 更新适配插件1.2.11
### Fixed
* 修复Android首次退出小游戏后会继续播放的问题
* DoExport增加返回值方便第三方工具集成
* innerAudio onError增加回调信息
 
## 2023-05-24
### Feature
* 更新适配插件1.2.5
* 优化开发版、体验版小游戏支持最佳实践检测工具
### Fixed
* TextureEditor插件目录不参与编译 

## 2023-05-22
### Feature
* 支持使用微信字体，使用WX.GetWXFont获取使用系统字体
* 支持WXAssetBundle，替换Unity AssetBundle以减少内存使用，请参阅文档[使用AssetBundle](Design/UsingAssetBundle.md)其中WXAssetBundle部分
* 开发版、体验版小游戏支持最佳实践检测，请参阅[最佳实践检测工具](Design/PerformanceMonitor.md)
* WX-WASM-SDK-V2** 版本使用新的目录结构为WX-WASM-SDK-V2，更新需手动删除`Assets/WX-WASM-SDK` (如有二次修改请备份)。若新版本出现异常，可使用旧版本备份包 [SDKv1 Unity插件](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/tools/minigame.202305172131.unitypackage) 版本包进行回退
* 适配插件版本号更新为1.2.3

### Fixed
* 对齐最新[小游戏基础库2.30.4协议](https://github.com/wechat-miniprogram/minigame-api-typings/blob/master/types/wx/lib.wx.api.d.ts)
部分类、接口名变更，原 Callback 命名更替为 Listener 如：
```
  OnKeyboardInputCallbackResult -> OnKeyboardInputListenerResult
```
* 修正调用参数类名的大小写，例如：
```
  getGameClubDataOption -> GetGameClubDataOption
  openPageOption -> OpenPageOption
```

## 2023-04-26
### Changed
* 更新启动插件1.1.19
## 2023-03-31
### Feature
* 优化启动插件内存占用
## 2023-02-22
### Feature
* 支持开通高性能模式的游戏禁止回退成普通模式运行，通过`disableHighPerformanceFallback`修改

## 2023-02-15
### Fixed
* 微信压缩纹理工具修复自定义路径导出
* 微信压缩纹理工具优化增量逻辑
* fmod转换适配develop build

## 2023-02-9
### Feature
* 微信压缩纹理新增API可供开发者调用接入自定义自动转化能力
* 微信压缩纹理工具内核优化
* 微信压缩纹理工具对WebGL2.0 Gamma Linear模式兼容（Beta）
### Fixed
* WebGL2.0模式下，修复Android的内存异常上涨

## 2023-01-17
### Fixed
* iOS高性能模式下，touch identifier始终返回正整数

## 2023-01-17
### Feature
* 适配Unity 2020版本导出的_JS_Sound_IsStopped
* 适配插件版本升级到1.1.12

### Fixed
* WebGL2.0模式下，修复iOS普通模式的渲染异常
* WebGL2.0模式下，修复iOS高性能模式进程内存过大的问题
* 修复fmod相关的适配问题
* 修复微信压缩纹理DXT占位符当初修复eslint引发的无法替换问题


## 2023-01-04
### Feature
* 增加`WX.ReportScene`接口，用于游戏自定义场景上报，可参见github文档，或mp文档 https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-action-start-reportScene.html
* 增加`Rmdir`及`RmdirSync`接口
* 增加`GetCachePath`接口
* 提供插件缓存路径`PluginCachePath`
* 性能面板增加ProfilingMemory Dump功能，使用请查阅：https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/UsingMemoryProfiler.md

### Fixed
* 修复偶现读取空文件的bug

## 2022-12-28
### Feature
* 增加ProfilingMemory功能，使用请阅读相关文档
* C# SDK支持API chooseMedia
* Snapshot支持，Unity 2021编译参数增加_emscripten_stack_get_base,_emscripten_stack_get_end
* iOS高性能模式2.29.1支持BufferURL
### Fixed
* InnerAudio播放音频中文文件名修复
* 兼容iOS 8.0.31普通模式UnityAudio短音频适配问题

## 2022-12-22
### Fixed
* 修复UnityPlugin v1.1.5导致特性开关和分包patch逻辑失效

## 2022-12-21
### Feature
* 排行榜能力优化
* 视频透明时全局清理标记
* 移除markdown插件
* 微信压缩纹理增加支持ASTC6*6格式
* 适配插件版本升级到1.1.5

## 2022-12-7
### Feature
* 支持指定Node路径，MiniGameConfig.asset-CompileOption-CustomNodePath指定自定义node安装目录
* 编译选项增加CleanBuild(仅支持2021以上版本)
* 适配插件版本升级到1.1.3
### Fixed
* 修复UnityAudio适配InnerAudio时，静音状态对长音频在切换场景后无效的问题

## 2022-11-30
### Feature
* 微信压缩纹理支持WebGL2.0
* 微信压缩纹理对.svn .git目录忽略 

## 2022-11-23
### Feature
*  导出增加sbrk函数，2021无需profiling-memory查看DynamicMemory

### Fixed
*  UDPClient使用connect+write, 修复send接口性能问题

## 2022-11-17
### Feature
*  微信压缩纹理优化，支持ASTC使用非4倍数尺寸
*  新增录屏接口功能

## 2022-11-9
### Feature
*  Unity Audio压缩纹理，支持小游戏InnerAudio
*  适配插件版本升级到1.1.2
### Fixed
*  修复png资源Windows系统下缓存异常

## 2022-10-27
### Feature
压缩纹理回退使用png时也支持缓存逻辑
### Fixed
使用node命令时同时查找默认安装路径
修复Win7下使用Unity2021生成symbols时导致的卡死问题

## 2022-10-20
### Feature
* 高性能模式HTTP网络切换为小游戏接口
* 适配插件版本升级到1.0.97

## 2022-10-12
### Feature
* 微信压缩纹理工具支持ASTC文件读取，并支持不同的块大小(需Unity2021版本)
* 适配插件版本升级到1.0.95
### Fixed
* 文件缓存清理逻辑优化

## 2022-9-28
### Feature
* InnerAudio支持持久化文件存储（当音频路径加入到缓存目录时）
* 适配插件版本升级到1.0.94
### Fixed
* 修复Unity2021下使用微信压缩纹理工具，在iOS普通模式无法正常渲染的问题
* 修复WebGL2导出时的胶水层异常

## 2022-9-21
### Feature
* 增加游戏圈接口openPageOption, getGameClubData
* FileSystemManager增加stat接口
### Fixed
* FileSystemManager异步读取文件，填写encoding时没有返回数据
  
## 2022-9-13
### Feature
* 微信压缩纹理工具支持bundle级别修改压缩纹理等级
* Unity2021 IL2CPP默认选项更改为SIZE减少代码包体

## 2022-9-8
### Fixed
* 启动封面拉伸
* pc小游戏下载路径处理

### Feature
* 增加动态修改DATA_CDN的C#接口`SetDataCDN`，以及js接口`GameGlobal.manager.setDataCDN`
* 增加动态修改预下载列表的C#接口`SetPreloadList`，以及js接口`GameGlobal.manager.setPreloadList`

## 2022-9-7
### Fixed
* 修复PlayerPref在Unity Editor中的兼容
* 修复WXWriteBinFileSync返回值的处理

## 2022-8-31
### Fixed
* 调整WXTouchOverride更新逻辑为LateUpdate, 补充TouchCancel事件
* 修复资源量较大时，压缩纹理工具替换过程的卡死问题
 
## 2022-8-26
### Feature
* HTTP下载时，文件缓存与规则判定效率优化
* 压缩纹理对于不支持的引擎版本增加提示
* 插件特性动态开关

## 2022-8-17
### Feature
* WASM代码未发生变化时不在进行压缩，加快转换速度
* 压缩纹理支持剔除功能, 增加详细日志输出
* 微信开发者工具支持提示插件审核指引

## 2022-8-11
### Fixed
* 启动视频样式错误

## 2022-8-10
### Feature
* 支持自定义启动封面样式
* pc微信支持启动封面

### Fixed
* 安卓8.0.25启动异常
* 写缓存时未删除同名旧缓存
* 使用Date.now替换performence.now以提升性能
* 压缩纹理工具支持特殊字符资源

## 2022-7-28
### Feature
* 增加UDP接口能力
## 2022-7-20
### Feature
* 增加重启小游戏的API支持
### Fixed
* 纹理压缩并行下载完成未正常显示
### Feature
* 设置启动时是否自动检查小游戏版本更新
## 2022-7-14
### Fixed
* 转换面板的最大内存提示与指引优化
* WebGL导出失败时不进行小游戏转换
* 非playing状态调用WX接口的告警提示
## 2022-7-1
### Fixed
* 开发阶段没显示耗时弹框
* 21.3unity服务器错误且无跨域头导致报错
## 2022-6-30
### Fixed
* 压缩纹理工具逻辑异常，增加进度条
* 完善限帧率接口SetPreferredFramesPerSecond

## 2022-6-28
### Feature
* 导出插件的brotli压缩不依赖python环境
### Fixed
* 压缩纹理工具独立命名，避免有NuGet产生dll冲突

## 2022-6-18
### Fixed
* 小游戏模板错误
## 2022-6-16
### Feature
* 支持自定义可缓存文件及可清理文件
* 优化缓存目录统计

### Fixed
* 21.3unity在iOS上网络报错
## 2022-6-13
### Fixed
* `RemoveFile`参数转字符串
* 8.0.16安卓worker写文件报错
## 2022-6-8
### Feature
* 提供Loader启动数据

### Fixed
* 修复是否需要下载代码包上报
* 21.3版本Unity webrequest设置请求头；注册进度事件
## 2022-6-7
### Feature
* 增加MemoryProfiler，开发阶段分析内存
 
## 2022-6-1
### Feature
* 使用worker做文件写入临时绕过安卓文件写入多时造成卡顿
## 2022-5-31
### Feature
* 暴露插件进度事件
## 2022-5-30
### Fixed
* pc小游戏首包资源通过分包加载时读取失败
## 2022-5-26
### Changed
* 默认关闭纹理缓存，影响安卓帧率
  
### Fixed
* 修复21.3替换规则
## 2022-5-24
### Feature
* 增加对21.3版本unity支持
* MiniGameConfig.asset增加不常用配置入口
## 2022-4-29
### Fixed
* 通过分包加载资源时读取bug

## 2022-4-26
### Fixed
* 带`dataFileSubPrefix`时iOS首包资源下载bug

### Feature
* 游戏异常时增加重启游戏按钮
* 检查是否32位微信导致无法进入游戏
* 修正URL中非法路径
## 2022-4-24
### Fixed
更新独立域插件版本`1.0.60`
* 达缓存上限时未正常清理旧缓存
* 1.0.58版本插件iOS报错
## 2022-4-22

### Fixed
更新独立域插件版本`1.0.58`
* 预下载问题路径bug
* 不支持webgl2时提示
### Feature
* 增加清理指定文件接口`RemoveFile`
* 是否缓存纹理开关

## 2022-4-18
### Feature
* 修改文件删除接口使用方法`CleanFileCache`,`CleanAllFileCache`
## 2022-4-14
### Feature
* 增加清除文件缓存接口`CleanFileCache`

## 2022-4-11
### Changed
* 2021版本调整为需要手动分离symbols，由于Unity自身产生的symbols存在缺失问题
* 增加CleaStreamingAssets选项，控制是否清理webgl/StreamingAssets

## 2022-3-29
### Changed
* 更新插件版本为1.0.53
* `streamingUrlSubPath`支持传自定义拼接到streamingcdn后面的路径
* iOS不支持webgl2时提示

## 2022-3-22
### Changed
* 更新压缩纹理工具使用方式

## 2022-3-7
### Changed
* 更新独立域插件版本为1.0.51
* 预载列表按照填写顺序生成
* Unity2021不再提示分离symbols，2021.2.11以后版本已支持
* Pointer_stringify导致的浏览器告警

## 2022-3-7
### Changed
* 更新独立域插件版本为1.0.50

## 2022-2-17
### Changed
* 更新独立域插件版本
* 增加日志输出
* 限帧时禁用后台执行Loop

## 2022-2-15
### Fixed
* UnityAudio循环播放修复
* 2021版本修改为默认使用External Symbols(需升级Unity到2021.2.11以上)
* PlayerSettings默认去除"Run In Background"

## 2022-2-14
### Feature
* 支持PC端DXT5压缩纹理

## 2022-2-11
### Feature
* 调整部分API
* 支持webgl2.0的压缩纹理

## 2022-1-26
### Feature
* 新增API
* 修复API中不确定类型的数据可能导致类型转换失败的问题

## 2022-1-25
### Fixed
* 修复Login方法，默认不传timeout，默认超时为1000ms，容易失败的问题

## 2022-1-24
### Feature
* 兼容浏览器环境，修复部分API问题

## 2022-1-21
### Feature
* 新增WXCleanAllFileCache接口，用于清理所有文件缓存

### Changed
* 独立域插件版本更新到1.0.46，包含以下修改
1. 自动清理存量旧文件
2. 达到缓存上限时清理更多空间，具体值可通过minigame/unity-namespace.js中releaseMemorySize修改
3. 上报unity版本和转换插件版本
4. 支持以文件名全匹配的方式忽略缓存
5. 插件错误报实时日志
6. pc小游戏兼容

## 2022-1-20

### Feature
* 新增API，旧API批量重命名，用法保持不变

## 2022-1-17
### Fixed
* 同名文件缓存未清理

### Changed
* 版本限制条件更新

## 2022-1-13
### Fixed

* Unity Audio能力适配, 不支持设备兼容处理; 退后台暂停播放音频; 性能提升

## 2022-1-7
### Fixed

* Unity Audio能力适配
* Unity Input Touch能力适配

## 2021-12-31
### Fixed

* 调整为默认不打开性能面板，单独提供WX.OpenProfileStats

## 2021-12-30

### Fixed
* 修复引擎初始化失败后依然回调calledMainCb导致统计问题
* 修复2021版本abort时执行WXUncaughtException
* 补充小程序框架异常时上报实时日志

## 2021-12-20

### Fixed
* 2021 dev 运行报错(randomDevices替换)
* 跳转小游戏接口错误
* 缓存大小为0，AssetBundle重试失败问题

## 2021-12-16

### Feature
* 开发、体验版本增加性能面板

## 2021-12-10

### Fixed
* 修复独立域插件未编译子包bug

## 2021-12-06

### Feature
* WebGL2.0 增加适配，该特性处于测试阶段
* 2021增加embedded symbols分离
* 增加error日志回调

### Fixed
* 2021 dev 运行报错

## 2021-12-02

### Fixed
* dev build报错
* 设备方向无法选中"LandscapeLeft", "LandscapeRight"

## 2021-11-30

### Changed
* 导出配置调整：统一资源CDN路径配置；配置顺序调整。

### Fixed
* 低版本C#导致markdownviewer报错'interpolated strings' cannot be used.

## 2021-11-19

### Fixed
* 更新小游戏模板

## 2021-11-18
### Feature
增加bundle相关导出配置

* 自定义bundle名中hash长度：用于缓存控制，默认32
* 自定义需缓存的路径标识符：下载路径命中标识符时会自动缓存本次下载文件。
* 忽略路径下指定类型文件：路径命中标识符时，过滤不需缓存的文件类型。

### Fixed
* markdownviewer可能出现guiskin引用丢失

### Changed
* 更新小游戏模板

## 2021-10-26
### Feature
* 增加部分文件操作API
* 压缩纹理替换优化，提升转换速度

## 2021-10-09
### Feature
* 增加Unity2020、2021版本支持


## 2021-09-23
### Fixed
* 程序crash时触发用户反馈入口


## 2021-09-22

### Feature
* 支持短音频的播放API（WX.ShortAudioPlayer），更接近Unity的API调用方式

### Feature
* 当禁用异常时，程序即将crash之前弹出用户反馈入口，并自动提交用户反馈日志、JS Error与实时日志

### Feature
* 编译选项增加"Profiling Funcs", 仅调试问题时勾选此选项时，编译代码将含有函数名，代码体积变大

## 2021-09-14

### Feature
* 支持PlayerPrefs优化，支持配置key
### Fixed
* 修复排行榜内存增长问题

## 2021-09-06

### Feature
* 支持导出时配置封面图

## 2021-8-20

### Feature
* 支持创建视频

## 2021-8-12

### Feature
* 修复IOS下音频被系统打断后的恢复问题
* 支持客服消息

## 2021-8-10

### Changed
* 小游戏项目模板更新
* 独立域插件更新为1.0.27。优化文件删除；修复资源预载bug

## 2021-08-05

### Feature
* 音频支持获取播放状态
* 非POT图也支持延迟加载

## 2021-08-04

### Fixed
* 独立域插件版本更新为1.0.24，修复若干问题

## 2021-08-02

### Fixed
* 独立域插件更新1.0.20，修复首包资源下载异常
* 更新小游戏项目模板

## 2021-08-01

### Changed
* 小游戏项目模板更新

## 2021-07-31

### Feature
* 增加预下载并发数控制接口WX.SetConcurrent

### Changed
* 小游戏项目模板变更

## 2021-07-26
### Feature
* 增加预下载猎豹配置，自动从导出目录webgl/StreamingAssets查找资源并填充到game.js的Preload列表

## 2021-07-26
### Feature
* 支持文件二进制读写（同步和异步）
* 压缩纹理替换速度优化

## 2021-07-20
### Fixed
* 独立域插件版本升级为1.0.16，修复初始上报时机

## 2021-07-19

### Changed
* 优化插件更新提示

## 2021-07-13

### Fixed
* 独立域插件版本升级为1.0.14，修复了一些bug

### Changed
* 导出插件只提示更新，不自动下载

## 2021-07-09

### Fixed
* 独立域插件版本升级为1.0.13，修复了一些bug

## 2021-07-02

### Fixed
* 微信版本或基础库版本过低时`WXWebAssembly`未定义，未弹框提示更新客户端

## 2021-06-30

### Fixed

* 压缩纹理兼容flare

### Feature

* 支持游戏恢复到前台后自动播放，默认开启分享

## 2021-06-29

### Fixed

* 云测试设置UI框架导致editor运行错误

### Feature

* 引入[UnityMarkdownViewer](https://github.com/gwaredd/UnityMarkdownViewer)在inspector面板预览changelog

### Removed

* 移除转换小游戏面板中`游戏内存大小`字段: 从Unity 2019开始已不支持设置`PlayerSettings.WebGL.memorySize`

### Changed

* 资源优化工具代码添加namespace, 避免与游戏代码冲突

### Others

独立域插件更新为(1.0.11)

* `.untiy3d`拓展名文件视为bundle文件，可做缓存。
* 根据是否调试模式控制日志输出，规则为: 若为开发版, enableDebugLog=false且为调试模式时输出详细日志；其他版本, 开启调试模式则输出详细日志

## 2021-06-10

### Fixed

* 独立域插件更新(1.0.10): 修复安卓分片读取包内资源内存越界
