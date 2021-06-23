# Unity WebGL 小游戏适配方案(内测)

欢迎使用 Unity WebGL 小游戏适配(转换)方案，本方案设计目的是**降低 Unity 游戏转换到微信小游戏的开发成本**。开发者无需更换 Unity 引擎工作流与重写核心代码的情况下，将原有游戏项目适配到微信小游戏。

# 文档总览

概述

- [方案概述](Design/Summary.md)
- [支持平台](Design/SupportedPlatform.md)
- [转换案例](Design/ShowCase.md)

工具指引

- [方案兼容性评估](Design/Evaluation.md)
- [快速开始：转换工具导出微信小游戏](Design/Transform.md)

性能优化

- [性能优化总览](Design/PerfOptimization.md)
- [性能评估标准](Design/PerfMeasure.md)
- 启动性能

  - [提升 Unity WebGL 游戏启动速度](Design/StartupOptimization.md)
  - [启动流程与时序](Design/Startup.md)
  - [使用 Loader 进行游游戏加载](Design/UsingLoader.md)
  - [使用 Addressable 进行资源按需加载](Design/UsingAddressable.md)
  - [首场景启动优化](Design/FirstSceneOptimization.md)
  - [启动留存数据上报统计](Design/ReportStartupStat.md)
  - [代码分包](Design/WasmSplit.md)
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

