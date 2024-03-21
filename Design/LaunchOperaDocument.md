# 启动剧情剧本自助设计工具及文档

## 1.文档说明

启动剧情能力上线初期微信小游戏团队希望更多开发者能够一定程度上自助接入该能力设计剧本，来减少人工协助带来的额外时间消耗，为此提供本指南及工具，游戏开发者通常可通过阅读指南与使用本工具自行完成剧本的设计并上线能力。

## 2.准备工作

- [微信开发者工具](https://developers.weixin.qq.com/miniprogram/dev/devtools/download.html)
- [Node.js (版本 >= 18.0.0)](https://nodejs.org/en/download/current)
- 需要了解一些 JavaScript 的基本语法
- 一个专业的JavaScript代码编辑器（推荐 [VScode](https://code.visualstudio.com/download)、Sublime 等）

## 3.快速入门

如果你还没接触 Cli 开发模式，请跟随本教程直至你能在 **微信开发者工具** 中随意的预览你创作的剧情设计。

#### Step1 安装启动剧情Cli工具

确保安装Node.js与npm包管理器时，只需在你的PC命令行中输入：

```sh
npm install launch-opera-cli -g
```

有时可能需要以管理员身份运行。

#### Step2 创建剧情工程

在合适的目录下创建你的剧情编辑工程，PC命令行中输入：

```sh
lacop create
```

按照提示创建，如名为 `lac-opera-test` 的剧情工程，等待片刻创建成功后请进入该目录。

#### Step3 启动开发模式

创建成功后进入 `lac-opera-test` （本案例名）目录中执行：

```sh
lacop watch
```

等待片刻提示 `Starting compilation in watch mode...` 代表启动成功，此时将自动生成 `/minigame` 文件夹。
**注意在调试期间请勿关闭该命令行，应使其始终保持活跃，直到结束剧本设计**。

#### Step4 预览默认剧情

使用 `微信开发者工具` 打开 `/minigame` 目录，AppID 请切换成当前登陆用户有开发权限的小游戏AppID，如果AppID是首次打开后会要求添加用于调试的小游戏插件，按照提示申请权限，若一切正常，你将在工具完全载入资源后看到默认的启动剧情内容。

#### Step5 对剧本修改

可能与平时开发小程序/小游戏直接在 `微信开发者工具` 修改剧本不同的是，你无需修改 `/minigame` 目录中的任何资源，因为这是一个动态构建的产物，他会随着 `/src` 目录中的资源变化被不断覆盖。所以你真正需要修改的是 `/src` 中的代码资源。

接下来请你使用 JavaScript 代码编辑器打开本仓库目录（如 VSCode 打开），找到 `/src/launchOperaPlay/index.ts` 脚本。

请修改脚本中大约第 72 行的 URL 文本地址为：

```js
//url: 'https://testcos.merge.qq.com/mini-mm-release/1.0.5/StreamingAssets/Movies/CG_Trim.mp4',   // 修改前
url: 'https://testcos.merge.qq.com/mini-mm-release/1.0.5/StreamingAssets/Movies/CG_Trim.mp4',   // 修改后
```

此时保存这个文件，如果你的 Step3 中启动的开发模式还在工作，那么 `/minigame` 目录资源也将被实时更新，此时 `微信开发者工具` 通常也将重新加载游戏内容，你会看到被你刚刚修改的新的剧情内容。

#### Step6 导出剧本

当你对剧情设计完成，需要导出剧本给正式的游戏工程使用时，请回到 Step3 中你开启的命令行窗口，Windows系统下使用 `Ctrl + C` MacOS 系统下使用 `control + C` 结束开发模式。

再次执行：

```sh
lacop build
```

等待程序执行结束后，你将在本仓库根目录看到 `/release` 目录，此时你可以将 release 目录内资源放到你的正式游戏工程导出的 minigame 目录下使用。

有关图片资源路径问题请阅读 [常见Q&A](#常见qa) 中说明。

至此你已经完成了一次很小变动的剧本导出工作。

#### Step7 尝试更多的模板

启动剧情能够设计很复杂的交互剧情内容，但是这对于初学者还需要阅读本文更多的内容，后续请查阅 [进阶指南](#4进阶指南)。如果你想快速应用场景，类似 Step5 中这样仅修改属性值就可以替换成自己的游戏素材还是十分便捷。我们提供了多种模板可供选择，只需要在命令行中输入 `lacop template` 可以快速切换提供的多种模板效果拿来使用。

**实际上你可以直接执行 `lacop` 而无需带后面的参数进行能力的自主选择**