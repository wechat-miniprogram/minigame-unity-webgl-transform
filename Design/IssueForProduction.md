# 现网错误日志上报与排查

当游戏发布到现网时，开发者需要收集玩家遇到的错误、异常等问题并进行排查原因，本文阐述在微信小游戏环境的最佳实践。
开发者可通过三种途径收集到游戏异常数据：
- 用户反馈日志
- 小游戏实时日志
- JS Error错误日志
=

## 用户反馈日志
数据入口：MP平台-用户反馈
当玩家游戏中出现问题时，进行功能反馈将会提交“用户反馈日志“，开发者可以在后台下载到对应数据：
<image src='../image/issueforproduction1.png' width="800"/>
<image src='../image/issueforproduction2.png' width="800"/>

该功能需要两个必要条件：
1. 玩家提交反馈
   - 默认情况下，玩家可通过游戏右上方"..."-反馈与投诉-功能异常打开反馈入口。
   - 除此外，开发者也可通过使用[wx.createFeedbackButton](https://developers.weixin.qq.com/minigame/dev/api/open-api/feedback/wx.createFeedbackButton.html)主动创建反馈入口。

2. 开发者埋点打印日志
   - 默认情况下，适配插件将自动埋点游戏启动与特殊异常日志
   - 除此外，开发者看通过C# SDK的LogManagerxxx系列函数进行埋点上报
建议：
   开发者埋点上报购买物品、打开广告、进入关卡等关键信息
   开发者埋点上报异常捕捉的信息

## 小游戏实时日志
数据入口：MP平台-开发管理-实时日志

[实时日志](https://developers.weixin.qq.com/miniprogram/dev/framework/realtimelog/)为帮助小程序开发者快捷地排查小程序漏洞、定位问题.

<image src='../image/issueforproduction3.png' width="800"/>
相对于用户反馈日志，小游戏实时日志**不需要用户反馈行为**。

但需要开发者上报游戏关键节点信息与异常日志。


## JS Error错误日志
数据入口：MP平台-开发管理-错误日志

微信小游戏框架会在顶层监控到任何**未捕捉的JS异常**。
<image src='../image/issueforproduction4.png' width="800"/>


使用Unity WebGL转换方案的游戏通常会有这几种错误会产生：
- 导出选项中禁用异常，当触发异常时将走到js abort相关逻辑，此处将产生异常。
- 适配插件自身脚本错误
- 其他JS层未捕获异常

 





