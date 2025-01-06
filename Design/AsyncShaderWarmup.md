# Shader 异步 Warmup 

当游戏的 Shader 变体较多时，可以使用 ShaderVariantCollection（后面简称 SVC） 进行 Shader 预热，避免游戏运行过程 Shader 编译卡顿。

但当 SVC 里的 Shader 变体数量较多时，SVC 同步 Warmup 可能会导致长时间的卡顿。因此，Unity 团结引擎推出了 Shader 异步 Warmup 的功能，微信小游戏平台已经支持了该项能力。

## 平台支持情况说明
- iOS 普通模式不支持
- PC 和 iOS 高性能模式支持（系统自带的能力，不需要额外配置）
- Android 和 iOS 高性能+ 模式 使用平台的能力，需要开发者进行配置才能使用。

## 异步 Shader Warmup 使用条件
- 1、安装 8.0.54 或以上的微信客户端
- 2、需要 3.7.4 或以上的基础库 （打开小游戏调试面板，查看第一条日志）
- 3、请联系客服助手申请开通 Shader 异步 Warmup 功能
    - <img src='../image/issueandcontact2.png' width="200"/>
- 4、同时需要在小游戏的 `game.json` 文件配置`"enableParallelShaderCompile": true`
    - <img src="../image/shader_warmup_01.png" width="300" />

## Shader Warmup 参考
- [Unity ShaderVariantCollection](https://docs.unity3d.com/2021.3/Documentation/ScriptReference/ShaderVariantCollection.html)
- [Unity 团结引擎Shader 异步Warmup](https://docs.unity.cn/cn/tuanjiemanual/Manual/WeixinAsyncShaderWarmup.html)