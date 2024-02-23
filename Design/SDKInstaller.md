# 微信SDK安装

为兼容历史团结/Unity版本的使用，微信小游戏团队将SDK分为如下两种模式安装使用。

## 方法一：Package 方式安装

目前[团结引擎](https://unity.cn/tuanjie/tuanjieyinqing)、Unity 2019及以后版本推荐使用 Package 方式安装WXSDK。

### 安装指南

`打开游戏工程` -> `团结/Unity Editor 菜单栏` -> `Package Manager` -> `右上方 “+”` -> `Add package from git URL`
URL地址为：
```
https://github.com/wechat-miniprogram/minigame-tuanjie-transform-sdk.git
```
即可完成SDK导入。

## 方法二：资源包方式安装

对于 Unity 2018 版本引擎使用资源包方式可安装 WXSDK

### 安装指南

如果当前版本暂不支持 PackageManager 导入，请 [下载UnitySDK](https://game.weixin.qq.com/cgi-bin/gamewxagwasmsplitwap/getunityplugininfo?download=1) 后导入游戏工程中。

## 目录结构说明

我们希望SDK与工程代码节藕，如此一来也更方便开发者的代码版本维护。因此 PackageManager 模式下，微信SDK内容将不再存放在游戏工程的Assets目录中。为兼容需要，仍然会自动在 Assets 目录下创建 `WX-WASM-SDK-V2` 数据目录，如需保持相关的应用配置应始终保留该目录内容。

## 常见问题

#### 1.游戏工程可以导出但在微信开发者工具运行提示报错：
常见的情况是发生在如空项目或游戏代码中从未使用WXSDK的任何Runtime能力时，引擎导出项目将微信Runtime包裁剪，解决办法是在游戏合理位置增加对WXSDK的使用即可。
如：
```c#
// 无直接的API能力调用可使用读取系统信息等API
WX.GetSystemInfo(new GetSystemInfoOption());  // 读取SystemInfo
```