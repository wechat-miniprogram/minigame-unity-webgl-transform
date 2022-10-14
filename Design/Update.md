# 版本更新
请阅读文档，了解小游戏的[更新机制](https://developers.weixin.qq.com/minigame/dev/guide/runtime/update-mechanism.html)

总结起来，新版本发布后，无法立刻覆盖现网用户，因此需要考虑到发新版本后，现网用户可能依旧运行旧版本小游戏的情况。

有两种方式来保证及时更新：
1. 使用[更新管理器](https://developers.weixin.qq.com/minigame/dev/api/base/update/wx.getUpdateManager.html)
作用是游戏运行期间检查是否有新版本，可主动更新。
转换插件有提供配置来自动使用这项能力，通过勾选`MiniGameConfig.asset`中的`needCheckUpdate`。

2. mp后台-设置-基本设置-小程序最低可用版本，修改为最新版本
可禁止旧版本用户打开，并更新到最新版本
