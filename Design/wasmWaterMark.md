# wasm水印插件

> 如果同时使用代码分包插件，需要在使用分包插件后，再使用水印插件对分包后的wasm代码打水印

### 说明:
  在平台原有相似度检测基础上，为进一步保障wasm小游戏的代码安全，引入wasm水印机制
  已添加水印的wasm游戏，若遭遇恶意人员扒包抄袭，平台可通过水印准确检测出游戏的原作者，并处罚恶意抄袭人员
  
### 使用方式:
插件依赖[微信开发者工具](https://developers.weixin.qq.com/miniprogram/dev/devtools/download.html)1.05.2104251 RC 及以上，稳定版 1.05.2105100 及以上

#### 添加插件

> 部分示意图可能有出入，请升级微信开发者工具版本

打开拓展设置，找到水印工具，添加插件

<image src="../image/wasmsplit/extension-panel.png" width="600" />

<image src="../image/watermark/panel.png" width="600" />

<image src="../image/watermark/add.png" width="600" />

#### 使用插件
  在目录树上方工具栏找到水印工具icon，点击显示水印插件面板

  <image src="../image/watermark/icon.png" width="400" />

  项目首次使用插件默认会启用打水印功能。

  插件检测并展示项目中的wasm文件，开发者自行决定是否需要上传并打水印。

  <image src="https://res.wx.qq.com/wechatgame/product/webpack/userupload/20210623/163231/single-file.png" width="400" />

  点击上传按钮后，插件会自动执行逻辑

  正在打水印

  <image src="https://res.wx.qq.com/wechatgame/product/webpack/userupload/20210623/164104/doing.png" width="400">

  下载中

  <image src="https://res.wx.qq.com/wechatgame/product/webpack/userupload/20210623/164114/downloading.png" width="400">

  已完成

  <image src="https://res.wx.qq.com/wechatgame/product/webpack/userupload/20210623/164504/reset.png" width="400">

  完成后，即可测试小游戏是否正常运行，若有异常，可点击还原wasm文件到初始状态，重新打水印。

  当有两个wasm文件时，操作同理

  <image src="https://res.wx.qq.com/wechatgame/product/webpack/userupload/20210623/163222/multi-file.png" width="400" />

  若不想使用水印功能，点击关闭水印，wasm代码回到初始状态

  <image src="https://res.wx.qq.com/wechatgame/product/webpack/userupload/20210623/163419/disabled.png" width="400"/>

### 注意
  打水印和下载过程可能会有一定耗时，请耐心等待。

  若AppID为测试号，或者是小程序AppID，会出现如下界面，更换正确的AppID后重新检测即可
  
  <image src="https://res.wx.qq.com/wechatgame/product/webpack/userupload/20210623/163318/invalid-appid.png" width="400"/>

