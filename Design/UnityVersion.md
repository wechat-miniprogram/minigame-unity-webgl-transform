# 推荐引擎版本

## 版本兼容性
 Unity WebGL微信小游戏适配方案是以WebAssembly为基础，具有非常宽泛的兼容性，转换插件理论上支持的Unity版本涵盖：2018、2019、2020、2021。
 
 但并非每个小版本我们都有足够的验证，我们会根据验证情况以及大量转换游戏反馈的情况给出引擎版本建议。

## 推荐版本

| 引擎版本 | 压缩纹理/音频 | 编译体积 | 已验证小版本 | 其他 |
| --- | --- | --- | --- | --- |
| 2018 | 不支持 | DXT | 2018.4.25~2018.4.34 | 不支持设置dpr分辨率 |
| 2019 | 不支持 | DXT | 2019.4.28~2019.4.35 | --- |
| 2019 InstantGame| DXT/ETC2/ASTC | 100% | 2019.4.28~2019.4.35 | --- |
| 2020 | DXT/ETC2 | 100% | 2020.3.1~2020.2.36 | --- |
| 2021 | DXT/ETC2/ASTC | 80% | 2021.2.5~2021.2.18 | --- |
| 2021 InstantGame | DXT/ETC2/ASTC | 80% | 2021.2.5~2021.2.18 | 增强的UnityProfiler |
 
备注:
- Unity引擎在早期版本如5.x已提供WebGL平台导出模式，但我们并不推荐使用早期版本，因为存在较多BUG。
- Unity2018~2020在WebGL上没有明显的性能差异，但2018缺少部分功能(如不支持设置WebGL分辨率)，老项目请尽量选择2019以上版本
- Unity2021开始支持更多特性，如压缩纹理、压缩音频、更快的编译速度与更小的体积，强烈建议
- Unity InstantGame版本目前是以2019.4.29/2021.2.5基础上，由Unity中国区特殊优化，提供更强的Profier分析、AutoStreaming等功能，如有条件尽可能使用
- 当引擎不支持移动端压缩纹理(ETC2/ASTC)时，请务必使用[压缩纹理优化](Design/CompressedTexture.md)进行优化；该工具暂无法支持高版本引擎，如2021.3.x，请使用2021.2.18以下版本



## Unity InstantGame版本获取

### 基于2021.2.5
Windows平台：

- Unity Editor：[Editor_2021.2.5f1c301_a9](https://unity-1258948065.cos.ap-shanghai.myqcloud.com/test/AutoStreamerTest1/Release/Alpha/c301_a9/UnitySetup64.exe)
- WebGL Build Support: [UnitySetup-WebGL-Support-for-Editor-2021.2.5f1c301.exe](https://unity-1258948065.cos.ap-shanghai.myqcloud.com/test/AutoStreamerTest1/Release/Alpha/c301_a9/UnitySetup-WebGL-Support-for-Editor-2021.2.5f1c301.exe)

MacOS平台：

- Unity Editor：[Editor_2021.2.5f1c301_a9](https://unity-1258948065.cos.ap-shanghai.myqcloud.com/test/AutoStreamerTest1/Release/Alpha/c301_a9/Unity.pkg)
- WebGL Build Support: [UnitySetup-WebGL-Support-for-Editor-2021.2.5f1c301.pkg](https://unity-1258948065.cos.ap-shanghai.myqcloud.com/test/AutoStreamerTest1/Release/Alpha/c301_a9/UnitySetup-WebGL-Support-for-Editor-2021.2.5f1c301.pkg)

InstantGame Package：
[com.unity.instantgame.zip](https://unity-1258948065.cos.ap-shanghai.myqcloud.com/test/AutoStreamerTest1/Release/Alpha/c301_a9/com.unity.instantgame.zip)

### 基于2019.4.29
在原有引擎版本基础提供压缩纹理、压缩音频支持，需要的开发者联系小游戏研发助手(minigamedevop08)获取


## QA
1. 我们项目使用2017版本，应该使用哪个引擎版本转换？
转换工具最低需要引擎版本为2018, 需要升级项目，建议升级到2021以支持压缩纹理、更小的编译体积

