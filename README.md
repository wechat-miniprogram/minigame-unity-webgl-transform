# 微信小游戏团结/Unity适配方案

欢迎使用 Unity WebGL 小游戏适配方案(又称团结Unity快适配)，本方案设计目的是**降低 Unity 游戏转换到微信小游戏的开发成本**。基于WebAssembly技术，无需更换Unity引擎与重写核心代码的情况下将原有游戏项目适配到微信小游戏。

**官方文档：[https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/](https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/)**


### 方案特点
* 保持原引擎工具链与技术栈
* 无需重写游戏核心逻辑，支持大部分第三方插件
* 由转换工具与微信小游戏运行环境保证适配兼容，保持较高还原度
* 微信小游戏平台能力以C# SDK方式提供给开发者，快速对接平台开放能力

### 转换案例
| 我叫MT2(回合战斗) | 旅行串串(休闲) | 谜题大陆(SLG) | 热血神剑(MMO) | 
| --- | --- | --- | --- |
| <img src='./image/showcase34.png' width="240"/> | <img src='./image/showcase32.png' width="220"/> |  <img src='./image/showcase25.png' width="230"/>| <img src='./image/showcase33.png' width="230"/> |

[查阅更多转换案例](Design/ShowCase.md)

## 安装与使用

下载 [Unity插件](https://game.weixin.qq.com/cgi-bin/gamewxagwasmsplitwap/getunityplugininfo?download=1)并导入至游戏项目中，版本更新请查看[更新日志](https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/CHANGELOG.html)，团结版 or Package安装请查阅[SDK安装指引](https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/Design/SDKInstaller.html)

- 请查阅[推荐引擎版本](https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/Design/UnityVersion.html)，安装时选择WebGL组件
- 前往[微信开发者工具下载](https://developers.weixin.qq.com/miniprogram/dev/devtools/stable.html)安装Stable版开发者工具【注意：为保证稳定性，请勿使用小游戏版 Minigame Build】
- 查阅[小游戏开发者文档-快速上手](https://developers.weixin.qq.com/minigame/dev/guide/)创建小游戏类目应用
- 登录[MP微信公众平台](https://mp.weixin.qq.com)，能力地图-生产提效包-快适配，开通使用
- 查阅[快速开始：转换工具导出微信小游戏](https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/Design/Transform.html)进行小游戏导出转换
