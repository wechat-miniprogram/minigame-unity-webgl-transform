<!-- 
Feature － 新增功能/接口
Changed - 功能/接口变更
Deprecated - 不建议使用的功能/接口
Removed - 删除功能/接口
Fixed - 修复问题
Others - 其他 
-->
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
