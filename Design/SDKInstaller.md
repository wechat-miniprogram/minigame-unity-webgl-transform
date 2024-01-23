# 微信SDK安装

为兼容历史团结/Unity版本的使用，微信小游戏团队将SDK分为如下两种模式安装使用。

## 团结引擎微信SDK安装

团结引擎是针对中国区开发者定制提供实时3D引擎，有关团结引擎请前往[团结引擎官网]()。

团结引擎自 `2022.3.3` 版本后我们与中国区引擎团队紧密合作，推出 SDKPackage 导入方式，更方便开发者管理与更新SDK插件。

### PackageManager 导入

`打开游戏工程` -> `菜单栏` -> `Package Manager` -> `右上方 “+”` -> `Add package from git URL`
URL地址为：
```
https://github.com/wechat-miniprogram/minigame-tuanjie-transform-sdk.git
```
即可完成SDK导入。

### 下载导入

如果当前版本暂不支持 PackageManager 导入，请 [下载团结SDK]() 后导入包。

## Unity引擎微信SDK安装

Unity引擎开发者，请 [下载UnitySDK](https://game.weixin.qq.com/cgi-bin/gamewxagwasmsplitwap/getunityplugininfo?download=1) 后导入包。

## 目录结构说明

我们希望SDK与工程代码节藕，如此一来也更方便开发者的代码版本维护。因此 PackageManager 模式下，微信SDK内容将不再存放在游戏工程的Assets目录中，外部目录独立存储。为兼容需要，仍然会自动在 Assets 目录下创建 `WX-WASM-SDK-V2` 数据目录，如需保持相关的应用配置应始终保留该目录内容。