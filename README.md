# Unity WebGL 小游戏适配方案(公测)

欢迎使用 Unity WebGL 小游戏适配(转换)方案，本方案设计目的是**降低 Unity 游戏转换到微信小游戏的开发成本**。基于WebAssembly技术，开发者无需更换 Unity 引擎工作流与重写核心代码的情况下，将原有游戏项目适配到微信小游戏。
 
## 方案特点
* 保持原引擎工具链与技术栈
* 无需重写游戏核心逻辑，支持大部分第三方插件
* 由转换工具与微信小游戏运行环境保证适配兼容，保持较高还原度
* 微信小游戏平台能力以C# SDK方式提供给开发者，快速对接平台开放能力
<br>
<br>

## 转换案例
<image src='image/showcase11.png' width="200"/>

- [更多转换案例](Design/ShowCase.md)
<br>
<br>

## 安装与使用

下载 [Unity插件](https://res.wx.qq.com/wechatgame/product/webpack/userupload/wasm_plugin/minigame.unitypackage), 并导入至游戏项目中。

> 已验证Unity版本：2018.3/2018.4LTS、2019.2/2019.4LTS. 安装时选择WebGL组件。
> 如果你用的是Big Sur版本的Mac系统，并且Unity 版本小于 2019.4.14, 则需另外安装 python3，并安装brotli 命令如下: python3 -m pip install brotli

[快速开始：转换工具导出微信小游戏](Design/Transform.md)
<br>
<br>

 
## 文档总览
方案概述与兼容性
- [技术原理与流程](Design/Summary.md)
- [兼容性评估](Design/Evaluation.md)
- [更多转换案例](Design/ShowCase.md)

性能优化
- [性能优化总览](Design/PerfOptimization.md)
- [性能评估标准](Design/PerfMeasure.md)
- 启动性能

  - [提升 Unity WebGL 游戏启动速度](Design/StartupOptimization.md)
  - [启动流程与时序](Design/Startup.md)
  - [使用 Loader 进行游游戏加载](Design/UsingLoader.md)
  - [使用 Addressable 进行资源按需加载](Design/UsingAddressable.md)
  - [使用 AssetBundle 进行资源按需加载](Design/UsingAssetBundle.md)
  - [使用预下载功能](Design/UsingPreload.md)
  - [首场景启动优化](Design/FirstSceneOptimization.md)
  - [使用代码分包工具](Design/WasmSplit.md)
  - [启动留存数据上报统计](Design/ReportStartupStat.md)
  - [使用水印保护代码包安全](Design/wasmWaterMark.md)

- 运行性能
  - [使用 Android CPU Profiler 性能调优](Design/AndroidProfile.md)
  - [使用 Unity Profiler 性能调优](Design/UnityProfiler.md)
  - [音频适配优化](Design/AudioOptimization.md)
  - [压缩纹理优化](Design/CompressedTexture.md)
  - [资源优化工具与建议](Design/AssetOptimization.md)

能力适配

- [WX SDK 平台能力适配](Design/WX_SDK.md)
- [屏幕适配](Design/fixScreen.md)
- [输入法适配](Design/InputAdaptation.md)
- [排行榜与微信关系数据](Design/OpenData.md)
- [后端服务指引](Design/BackendServiceStartup.md)

问题反馈

- [问题反馈与联系我们](Design/IssueAndContact.md)

