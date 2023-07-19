# 使用 AutoStreaming 进行资源按需加载

​		除常规使用 AA/AB 分包方案外，Unity 官方也提供了 AutoStreaming 转换工具可以实现 Unity 游戏转化至微信小游戏平台的能力。开发者可阅读本文自行选择转换方案。

## 方案选择建议

​		Instant Game 能够快速有效的将原生 APP 游戏工程在较少的代码修改的情况下完成微信小游戏平台的运行，这得益于 Unity 引擎基于底层实现对游戏资源的异步加载能力，并将这些资源托管至 CCD 服务中。对于开发者而言，若游戏为休闲关卡类等小型游戏，使用 Instant Game 能够减少游戏的转化工时。适用于 Instant Game 转化的游戏一般具备：

- 需要快速转化上线
- 原生 APP 游戏工程没有使用 AA/AB 实现资源的管理
- 中小型游戏，对设备性能如计算、内存等要求并不是特别吃紧的游戏

​		Instant Game 对于极小的休闲类游戏将具备更快更小修改代价将游戏迁移至微信小游戏环境内运行，若追求较好的游戏品质，无论哪一种方案都需要开发者专项的适配。在部署方面 Instant Game 需要使用平台提供的 CDN 服务，不支持开发者自建。



## 实践指南

​		请前往 [Unity微信小游戏专区](https://unity.cn/instantgame/docs/WechatMinigame/Demo) (https://unity.cn/instantgame/docs/WechatMinigame/Demo) 阅读转换指引。

## Q&A

#### 1.游戏在微信开发者工具中运行缺失资源？

​		经过 AutoStreaming 转换后开发者应在微信开发者工具检查控制台中Network面板资源是否加载正常，若存在404时，需要查看资源是否正确上传、读取路径是否正确等。
