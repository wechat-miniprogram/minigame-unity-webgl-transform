# iOS 高性能与高性能+模式

- [什么是高性能模式](#什么是高性能模式)
- [什么是高性能+模式](#什么是高性能+模式)
- [性能提升](#性能提升)
  - [CPU 消耗](#cpu-消耗)
  - [压力测试](#压力测试)
- [如何开通](#如何开通)
- [高性能模式限制](#高性能模式限制)
  - [内存限制](#内存限制)
  - [代码体积限制](#代码体积限制)
- [QA](#qa)
  - [1. 如何判别游戏否已经开启了高性能模式？](#1-如何判别游戏否已经开启了高性能模式)
  - [2. 使用高性能模式下，游戏本身是否需要做修改？](#2-使用高性能模式下游戏本身是否需要做修改)
  - [3. iOS 报错提示未开启 gzip/br 压缩](#3-gzip-off-warning)
  - [4. 资源下载提示 isTrusted](#4-isTrusted-warning)
  - [5. 卡在启动封面无法启动](#5-卡在启动封面无法启动)
  - [6. 个别游戏 UI 会出现闪烁问题](#6-ui-flicker)
  - [7. 为什么开启了高性能模式，游戏启动很烫？](#7-为什么开启了高性能模式游戏启动很烫)
  - [8. 使用高性能模式下，不优化内存、WASM 代码包体积就发布上线可以吗？](#8-release-with-no-memory-and-code-size-optimize)
  - [9. iOS 高性能模式与安卓性能对比如何？](#9-iOS-high-performance-vs-android)

## 什么是高性能模式

在 iOS 环境下，标准的微信小游戏 WASM 运行模式是无 JIT, 对于计算性能要求较高的游戏会受到比较大的限制。常见情况是：

1. 中低端机帧率较低，流畅度难以达到上线标准
2. 对 CPU 计算资源消耗过高，运行一段时间后设备温度持续上升

小游戏环境框架提供了高性能运行模式，该运行模式下 CPU 算力得到明显提升。但该模式也存在更严格的内存与代码包体限制，需要开发者采取合适的手段以达到最优。

## 什么是高性能+模式
高性能+模式开创新地在保留游戏独立进程的基础上将渲染重新挪回了微信进程，这使得渲染效果和渲染内存消耗都得到了改善。详细文档请查阅[高性能+模式](https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-high-performance-plus.html)。
特别地，建议使用WebGL2、内存压力大的游戏开启此选项。开启后请验证进程内存、渲染兼容性、帧耗时数据是否正常。

## 性能提升

### CPU 消耗

通过多款游戏项目，我们得到实际游戏项目的 CPU 占用如下图所示：

<img src='../image/iosoptimization3.png' width="500"/>

我们得到以下结论：

- 高性能模式在长期执行过程中 CPU 明显低于普通模式，后者长期处于高 CPU 占用因此长期运行容易越来越烫
- 游戏启动初始阶段，高性能模式存在 CPU 高峰用于 WebAssembly 编译优化
- 采用[代码分包](WasmSplit.md)后，高性能模式能较快回落 CPU 占用并维持正常水平

### 压力测试

使用 Unity 所提供的 Benchmark Demo 的部分案例进行评测：

- Instntiate & Destroy
- Animation & Skinning
- Physics Cubes
- AI Agents

测试过程为不断增加运算复杂度，直到帧率下降到特定数值。

分数越高，代表的运行能力越强。

<img src='../image/iosoptimization1.png' width="250"/>
<img src='../image/iosoptimization2.png' width="250"/>

上图分别是 iOS 端普通模式与高性能模式的得分，可以看到在几个压测示例中高性能模式均明显优于普通模式。

经实际游戏测试，游戏帧率都会得到明显改善，虽无法达到 Benchmark 几乎一个数量级的差异。

## 如何开通

iOS 端小游戏高性能模式适用于遇到 iOS 环境运行性能不足，运行发烫的小游戏。

- 需要该能力的开发者登录[微信公众平台](https://mp.weixin.qq.com) -> 首页能力地图模块 -> 点击进入"生产提效包" -> 点击开通高性能模式。
  <img src="../image/mp_addplugin.png">
- 开通成功后，过配置 game.json 的 iOSHighPerformance 为 true 则可进入高性能模式，通过去掉此开关可以正常回退到普通模式，以便两种模式对比。

## 高性能模式限制

### 内存限制

高性能模式下，iOS 低端机(6s/7/8 等)2G RAM 机型的内存限制为 1G，中高端机(7P/8P/iPhoneX/XSAMX/11/12 等)3G 以上内存机型的内存限制为 1.5G（安全内存建议1.2G~1.3G），因此开发者务必保证内存峰值不超过该数值。

建议开发者根据指引[优化 Unity WebGL 的内存](OptimizationMemory.md)。

### 代码体积限制

高性能模式下，WASM 代码将被编译并优化，需要占用更多的编译消耗与内存。如果未进行优化前，可以明显感受到启动开始阶段（如启动前 1 分钟内）设备发烫。

**_上线发布时，特别建议使用[WASM 代码分包](WasmSplit.md)+[压缩纹理](CompressedTexture.md)+[UnityHeap](OptimizationMemory.md)预留这几种优化手段。_**

## QA

### 1. 如何判别游戏否已经开启了高性能模式？

- 删除本地小游戏(包括开发版、体验版和正式版)，
- 重新进入小游戏并打开调试，查看 vconsole 日志, 关注"game start"日志中的"render"字段为"h5"则为高性能模式
- 系统和基础库要求是: iOS>=14.0, 基础库>=2.23.1, 用户占比约为 90%。 对于不满足此要求时回退为普通执行方式。

### 2. 使用高性能模式下，游戏本身是否需要做修改？

- 业务代码无需做任何调整，普通模式与高性能模式可以无缝切换。
- 高性能模式下，请不要服务端设置 Cookie，游戏端内因为跨域问题会读取不到 Cookie
- Android 下载资源无问题，高性能模式提示资源下载失败等网络问题，请参考文档[网络通信适配](UsingNetworking.md#注意事项)关于跨域的问题

### <p id="3-gzip-off-warning">3. iOS 报错提示未开启 gzip/br 压缩

<img src='../image/contentencoding_error.png' width="500">

可通过微信开发者工具查看 Content-Encoding 是否为 gzip 或 br

如果有正确压缩，可忽略这个错误。

问题原因：由于跨域获取不到 Content-Encoding 头

解决办法：增加跨域头部`"Access-Control-Expose-Headers": "Content-Length, Content-Encoding",`

<img src="../image/devtools_network.png" width="500">

### <p id="4-isTrusted-warning">4. 资源下载提示`isTrusted`

<img src='../image/cors_istrusted.png' width='500'>

多半由于跨域问题导致，可通过开发者工具查看对应资源的 Response Header 是否有跨域头，
请参考文档[网络通信适配](UsingNetworking.md#注意事项)关于跨域的问题

### 5. 卡在启动封面无法启动

- 右上角打开调试，重启小游戏，点三次下方的 Unity logo 打开 vconsole
- 如果出现资源访问失败，但 Android 和开发者工具却可以下载则参考 QA3 关于跨域问题
- 15.4 系统出现"Not implemented"与内存问题，此为 Unity & iOS 15.4 的 BUG，微信提供的 wasm 代码分包(推荐)或 Unity WebGL 官方论坛的[临时修复方案](https://forum.unity.com/threads/ios-15-webgl-2-issue.1176116/page-2)
- 16.7/17.0系统出现"glGetString (GL_EXTENSIONS) - failure", 苹果官方17.1已fix。对于未更新系统的玩家，也可使用[高性能+模式](https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-high-performance-plus.html)处理。详情请查阅: [Unity社区讨论](https://forum.unity.com/threads/webgl-context-lost-ios-17-safari.1501193/)，[iOS浏览器Webkit BUG](https://bugs.webkit.org/show_bug.cgi?id=261313),
  

### <p id="6-ui-flicker">6. 个别游戏 UI 会出现闪烁问题
- 目前已发现iOS 15.4出现若干渲染BUG，如stencil特性支持，请查阅文档[优化Unity WebGL的渲染性能](RenderOptimization.md)
- 如按上述文档去除依然无法解决，请提供可复现 Unity 工程联系 minigamedevop08

### 7. 为什么开启了高性能模式，游戏启动很烫？

- 请参考本文前面部分，如果未使用代码分包的情况下 JIT 编译优化将耗费大量性能

### <p id="8-release-with-no-memory-and-code-size-optimize">8. 使用高性能模式下，不优化内存、WASM 代码包体积就发布上线可以吗？

- 不建议。iOS 高性能模式虽然能提运行算力，但对内存、WASM 包体积有更苛刻的要求，需要更多的精力做优化。如果不做任何优化的情况下，很有可能会遇到超出内存限制而崩溃，启动时发烫现象严重等问题。**_上线发布时，特别建议使用[WASM 代码分包](WasmSplit.md)+[压缩纹理](CompressedTexture.md)+[UnityHeap](OptimizationMemory.md)预留这几种优化手段。_**

### <p id="9-iOS-high-performance-vs-android">9. iOS 高性能模式与安卓性能对比如何？

- 两种系统环境下，WASM 执行都是 JIT 代码。但由于底层虚拟机差异过大以及自身不断迭代，难以横向对比。
