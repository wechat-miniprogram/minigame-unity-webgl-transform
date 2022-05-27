<!-- 
Added － 新增功能/接口
Changed - 功能/接口变更
Deprecated - 不建议使用的功能/接口
Removed - 删除功能/接口
Fixed - 修复问题
Others - 其他 
-->
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
### Added
* 支持PC端DXT5压缩纹理

## 2022-2-11
### Added
* 调整部分API
* 支持webgl2.0的压缩纹理

## 2022-1-26
### Added
* 新增API
* 修复API中不确定类型的数据可能导致类型转换失败的问题

## 2022-1-25
### Fixed
* 修复Login方法，默认不传timeout，默认超时为1000ms，容易失败的问题

## 2022-1-24
### Added
* 兼容浏览器环境，修复部分API问题

## 2022-1-21
### Added
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

### Added
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

### Added
* 开发、体验版本增加性能面板

## 2021-12-10

### Fixed
* 修复独立域插件未编译子包bug

## 2021-12-06

### Added
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
### Added
增加bundle相关导出配置

* 自定义bundle名中hash长度：用于缓存控制，默认32
* 自定义需缓存的路径标识符：下载路径命中标识符时会自动缓存本次下载文件。
* 忽略路径下指定类型文件：路径命中标识符时，过滤不需缓存的文件类型。

### Fixed
* markdownviewer可能出现guiskin引用丢失

### Changed
* 更新小游戏模板

## 2021-10-26
### Added
* 增加部分文件操作API
* 压缩纹理替换优化，提升转换速度

## 2021-10-09
### Added
* 增加Unity2020、2021版本支持


## 2021-09-23
### Fixed
* 程序crash时触发用户反馈入口


## 2021-09-22

### Added
* 支持短音频的播放API（WX.ShortAudioPlayer），更接近Unity的API调用方式

### Added
* 当禁用异常时，程序即将crash之前弹出用户反馈入口，并自动提交用户反馈日志、JS Error与实时日志

### Added
* 编译选项增加"Profiling Funcs", 仅调试问题时勾选此选项时，编译代码将含有函数名，代码体积变大

## 2021-09-14

### Added
* 支持PlayerPrefs优化，支持配置key
### Fixed
* 修复排行榜内存增长问题

## 2021-09-06

### Added
* 支持导出时配置封面图

## 2021-8-20

### Added
* 支持创建视频

## 2021-8-12

### Added
* 修复IOS下音频被系统打断后的恢复问题
* 支持客服消息

## 2021-8-10

### Changed
* 小游戏项目模板更新
* 独立域插件更新为1.0.27。优化文件删除；修复资源预载bug

## 2021-08-05

### Added
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

### Added
* 增加预下载并发数控制接口WX.SetConcurrent

### Changed
* 小游戏项目模板变更

## 2021-07-26
### Added
* 增加预下载猎豹配置，自动从导出目录webgl/StreamingAssets查找资源并填充到game.js的Preload列表

## 2021-07-26
### Added
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

### Added

* 支持游戏恢复到前台后自动播放，默认开启分享

## 2021-06-29

### Fixed

* 云测试设置UI框架导致editor运行错误

### Added

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
