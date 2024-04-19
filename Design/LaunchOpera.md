# 启动剧情（Beta）

  Unity微信小游戏首次启动会花费较长的加载时间，这段等待期间游戏与玩家之间没有更多的交互，这是新用户的留存率影响的重要因素，微信小游戏希望能够提供一些更早的交互行为来提升这段等待空窗期的用户访问体验，为游戏的主逻辑争取更多的下载、加载时间。由此推出「启动剧情」能力，对于希望进一步提升游戏启动留存的开发者可以基于该能力精心设计用于“迎新”的剧情内容，进而提升玩家的代入感与游戏的顺畅体验。

## 剧情效果

### 演示视频及演示工程源码

  <video width="320" height="auto" controls>
    <source src="../image/launch-opera/demo-video.mp4" type="video/mp4">
      Your browser does not support the video tag.
  </video>

  [演示工程源码](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo/LaunchOpera)

### 优秀作品

首次访问将直接进入剧情模式（不会显示Unity游戏通用Loading界面），二次访问通常删除本地微信小游戏包再次访问游戏可体验剧情内容（部分游戏使用异步模式，若已经注册游戏角色可能会改变剧情内容，需使用新微信账号访问体验）。

魔魔打勇士 | 飞翔之光 | 镜花异闻录
-|-|-
<img src='../image/launch-opera/app-mmdys.jpeg' width="170"/>|<img src='../image/launch-opera/app-fxzg.jpeg' width="170"/>|<img src='../image/launch-opera/app-jhywl.jpeg' width="170"/>

欢迎更多游戏接入成为优秀案例。

## 能力特性

- 比WASM(C#)更早的运行时机
- 独立线程
- 支持区分新老用户不同的播放内容
- 以视频、插图等形式展现

## 推荐内容

- 前置新人、赛季CG动画短片
- 游戏世界观、故事背景的介绍
- 游戏厂家启动Logo、防沉迷等信息披露

## 接入方式

由于启动剧情为Unity启动加载耗时过久而推出的能力，因此主要配置由 JavaScript 脚本实现（早于WASM初始化）。

### 步骤一：设计剧情

剧本设计请阅读 [启动剧情剧本自助设计工具及文档](LaunchOperaDocument.md) 完成设计与调试；

由工具构建(npm run build)生成剧本产物：资源目录 `launchOperaPlay`。

### 步骤二：配置启动剧情

1. 使用代码编辑工具打开Unity工程中 `Assets/WX-WASM-SDK-V2/Runtime/wechat-default` 目录；
2. 将 **步骤一** 中 `launchOperaPlay` 资源放到 `wechat-default` 目录中；
3. 打开 `wechat-default/game.js` 文件，该文件是 JavaScript 运行的入口文件，在文件底部增加启动剧情初始化配置。

```js
// game.js

...   // 原有的代码

// 底部增加启动剧情配置
// launchOperaInit 是用于初始化剧情的回调事件
// 配置工作需要在该回调中使用「同步」方式完成，请勿使用异步函数
GameGlobal.events.on("launchOperaInit", (operaHandler) => {

  // 如需读取本地缓存请使用 getStorageSync 读取，请勿使用异步方式
  // 如需异步请查阅「基于异步干预剧情发展」
  let play = true;
  try {
    var value = wx.getStorageSync('launchOperaLocalDataXXX'); // 自行管理的本地缓存 Key-Value
    if (value) {    // 本地有特定缓存标识意味已经不是首次访问可以不播放
      play = false;
    }
  } catch (e) { }

  // 合理位置标记为非新用户，也可以在 C# 侧完成标记
  wx.setStorageSync('launchOperaLocalDataXXX', { anydata: 0 });

  // 开始配置启动剧情
  operaHandler.config = { // 配置本地剧本路径，若 playPath 文件不存在或读取失败则自动放弃启动剧情
    playPath: play ? '/launchOperaPlay/operaPlay.obj' : null,
  }

  // 注册一些其他的启动剧情事件回调
  operaHandler.onEnd((logger) => {
    console.log('剧情播放结束');
  })

  operaHandler.onErr((err) => {
    console.log('发生异常');
    operaHandler.end();       // 发生异常时强制结束，避免用户无法退出剧情插件模式
  })

  // 弱网处理
  operaHandler.onWeakNetwork((info) => {
    // code...
  })

});

```
4. 导出面板进行导出微信小游戏即可。

### 基于异步干预剧情发展

初始化期间可以同步读取本地资源简单判断是否需要播放剧情，但对于有网络存档的游戏而言，显然不是可靠的判断新用户的方案（用户新设备或本地缓存丢失时也将判定为新用户），这将涉及到异步方式来干预启动剧情插件的工作。异步由于存在不确定的结果返回时间，游戏的启动自然不能始终等待这段空隙，因此在异步结果返回前，我们应让启动剧情插件**正常启动**，并在后续合理的时机完成故事线的切换。下图给出一种推荐的做法：

![](/image/launch-opera/image-0.png)

我们可以看到，默认的剧情将固定播放一段大约3～5秒钟的启动动画（可以是游戏厂家Logo、防沉迷提醒等），在3～5秒期间 JavaScript 脚本尝试用一些途径来确定后续的剧情发展（可以通过网络交互、本地读取等），当确认后，启动剧情插件允许配置相关变量进而干预剧情发展。
值得注意的是，异步的获取时间明显是不可控的，因此是有可能在5秒的启动动画结束后，仍未得到期望的结果，因此推荐的设计是默认情况下仅播放5秒的启动动画，后续剧情不播放，当5秒内明确了后续播与不播放的选择时，按结果配置，若仍未得到结果，可以按照老用户立即结束剧情即可。具体如何抉择，开发者可以自行设计。

异步干预剧情需要使用到 **全局变量** 能力，Beta期间请联系研发助手设计剧情期间咨询异步干预能力。

### 自定义上报分析

启动剧情是一个持续较长时间的业务内容，这段时间中任何时刻均会有用户离开，因此上报剧情期间用户不同阶段的行为对于分析剧情内容与留存率是非常重要的。启动剧情的“剧本”由开发者定义，因此开发者更清楚一个剧情的不同阶段的时间点，所以需要开发者自行对不同阶段剧情进行上报打点。开发者配置上报后，MP管理后台提供了漏斗图的数据可视化看板，将方便开发者进行数据分析。
有关自定义上报详细内容请参考 [启动场景上报分析](https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-action-start-reportScene.html) 。


### 外显进度条接入

启动剧情能力工作期间，仍然提供了加载进度外显能力，这有助于在剧情播放期间通过截图方式反馈一些加载进度信息，默认情况下位于小游戏底部区域，如图所示：

<img src='/image/launch-opera/image-1.png' width="50%"/>

启动剧情外显进度条默认为用户开启，并且进度条前70%固定为Unity小游戏封面启动进度，开发者可以自行补充后30%进度的显示，若开发者未定义后30%显示进度则启动剧情插件将在首资源包与WASM初始化完成后以平滑动画完成100%进度显示。

#### 关闭/样式调整

如需关闭/样式调整外显进度条，如下配置：

```js
GameGlobal.event.on("launchOperaInit", (operaHandler) => {

  // other codes...

  // 配置外显进度条
  operaHandler.config = {
    progressStyle: {   // 外显进度条配置，所有配置项均可缺省，以下为默认值
      position: 1,                  // 0 顶部 1 底部
      hidden: false,                // 是否隐藏
      color: '#FFFFFF',             // 进度条颜色
      backgroundColor: '#000000',   // 进度条背景颜色
      height: 3,                    // 进度条高度
    },
    useCustomProgress: true,       // 声明控制后30%显示，默认不控制将以动画自动补间
  }

});
```

如开启 `useCustomProgress` 则可在游戏侧完成控制

```c#
launchOpera.percentage = 0.6;     // 开发者输入 .0～1.0 浮点数，对应控制剩余 30%
```

### 弱网处理

启动剧情通常以视频内容呈现为主，网络流畅度对用户体验是存在直接关系，除了开发者需要确保使用可靠的CDN服务托管视频资源确保足够的输出带宽，用户的实际网络也是影响的重要因素。微信小游戏启动剧情对可能影响用户体验的弱网情况做了相应的回调事件，也对网络情况做了三个级别的分级，请开发者对弱网的反馈同样做出合理的处理提升用户体验。

弱网级别：
- 0级：视频、音频数据流畅（不会产生onWeakNetwork回调）
- 1级：存在稍微卡顿但可及时恢复播放。可适当给出Loading动画提醒网络加载，或使用全局变量控制剧情显示退出/跳过按钮由用户主动放弃剧情。
- 2级：严重卡顿，长时间等待视频数据缓冲。可主动提前结束启动剧情，进入原本的Unity loading模式。

请参阅 [.onWeakNetwork](#onweaknetworkcallback-function) API描述。

## API执行环境说明

启动剧情的运行环境主要以 JavaScript 为主，当然我们也提供了部分 C# 侧需要用到的访问接口。JavaScript 侧指的是导出目录中 `minigame` 文件夹中的脚本，这是微信开发者工具打开的脚本目录，`minigame/game.js` 是整个游戏客户端启动的入口，我们通常也是从该入口进行能力迭代。不过值得注意的是，`minigame` 目录是导出产物，在重新导出游戏时将会被覆盖，所以正确的修改目录应该位于 `Assets/WX-WASM-SDK-V2/Runtime/wechat-default` 目录中，这里是导出 `minigame` 的模板文件，并且能够跟随项目Git等代码版本托管迭代。

C# 侧指的是游戏在 Unity 环境中的函数调用，区别于 JavaScript 他的时机将更晚，因为 C# 侧需要等待 WASM 准备充分（首场景加载完成）后才能够进行一系列的函数调用，因此配置性的操作是不能此完成（请在 JavaScript 完成），当剧情启动并给到充分的 WASM 启动后，C# 将得到一些信息反馈，如：何时结束剧情、外显进度条的进度设置等。

## API（JavaScript侧）

在 JavaScript 中除了 `launchOperaInit` 回调函数参数中可获得句柄外， 全局变量 `GameGlobal.launchOpera` 可以让开发者在任意位置访问到控制句柄；

### .running

只读属性，获得当前剧情插件运行状态，`true` 代表正在播放剧情，`false` 为未运行或已播放结束资源已完成析构。

```js
console.log(GameGlobal.launchOpera.running);    // true or false
```

### .config

在初始化期间对启动剧情组件进行相关配置。

```js
GameGlobal.launchOpera.config = {
  playPath: '',   // 可选，剧本文件路径，填写该项则意味开启启动剧情
  progressStyle: {   // 外显进度条配置，所有配置项均可缺省，以下为默认值
    position: 1,                  // 0 顶部 1 底部
    hidden: false,                // 是否隐藏
    color: '#FFFFFF',             // 进度条颜色
    backgroundColor: '#000000',   // 进度条背景颜色
    height: 3,                    // 进度条高度
  },
  useCustomProgress: false,       // 是否接入自定义外显进度条
}
```

### .end()

提前结束启动剧情。

### .onEnd(callback: Function)

注册当剧情结束时的回调事件。

当产生该回调时意味着启动剧情组件资源已经完全析构，同时自动释放注册的事件（如 .onErr 、.onEnd），无需开发手动释放。

### .offEnd(callback: Function)

注销当剧情结束时配置的回调事件。

### .onErr(callback: Function)

注册当发生异常时的回调事件。

引发异常的可能是：剧本文件读取失败、剧本与启动剧情插件版本不兼容、插件环境异常、CDN视频资源播放失败等。

为避免发生异常时用户无法退出启动剧情插件，推荐开发者在 onErr 强制结束启动剧情。

```js
launchOpera.onErr((err) => {
  launchOpera.end();    // 强制结束
});
```

### .offErr(callback: Function)

注销当发生异常时的回调事件。

### .onWeakNetwork(callback: Function)

当发生1-2级弱网情况时发生的回调事件。

一种推荐的配置：

```js
launchOpera.onWeakNetwork((info) => {
  /**
   * info 结构：
   *  interface info {
   *    level: number;  // 弱网级别
   *    url: string;  // 产生本次回调的远程资源url
   *  }
  */
  if (info.level == 1) {
    wx.showToast({
      title: '网络较弱正在缓冲...',
      icon: 'none',
    });
    // 使用 GlobalVar 显示跳过/退出按钮
    // code...
  } else { // 不是 level 1 则为 level 2
    wx.showToast({
      title: '网络较差，已为您跳过剧情',
      icon: 'none',
    });
    launchOpera.end();    // 强制结束
  }
});
```

### .offWeakNetwork(callback: Function)

注销当发生弱网情况时的回调事件。

### .setGlobalVar(globalName: string, value: string)

设置启动剧情全局变量值。

### .getGlobalVar(globalName: string): string | null

读取启动剧情全局变量值。

### .onGlobalVarChange(globalName: string, callback: Function)

当启动剧情全局变量变化时回调。

### .offGlobalVarChange(globalName: string, callback: Function)

注销启动剧情全局变量变化时回调。

## API（C#侧）

### 获得交互句柄

```c#
var launchOperaHandler = WX.GetLaunchOperaHandler();
```

### void SetPercentage(double value)

当开启自定义外显进度条时（useCustomProgress）可控制进度条进度，value 接受 .0 ~ 1.0 区间浮点数，对应外显进度条的 70% ~ 100% 进度。

### bool GetRunning()

获得当前剧情插件运行状态，`true` 代表正在播放剧情，`false` 为未运行或已播放结束资源析构。

### void End()

提前结束启动剧情。

### void onEnd(Action\<bool> callback)

注册当剧情结束时的回调事件。

由于 C# 代码启动较晚，如果在开发者注册时剧情已经结束，则在注册该方法时会立即产生回调，注册的回调只会产生1次。

```c#
// On LaunchOpera End
WX.GetLaunchOperaHandler().onEnd((status) =>
{
    WX.ShowToast(new ShowToastOption()
    {
        title = "C#(WASM) received the ending callback event!",
        icon = "none",
    });
});
```

### void offEnd(Action\<bool> callback)

注销当剧情结束时配置的回调事件。

### void SetGlobalVar(string key, string value)

设置启动剧情全局变量值。

### string GetGlobalVar(string key)

读取启动剧情全局变量值。
