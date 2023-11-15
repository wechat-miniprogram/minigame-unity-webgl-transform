# 启动剧情（Alpha内测）

  Unity微信小游戏首次启动会花费较长的加载时间，这段等待期间游戏与玩家之间没有更多的交互，这是新用户的留存率影响的重要因素，微信小游戏希望能够提供一些更早的交互行为来提升这段等待空窗期的用户访问体验，为游戏的主逻辑争取更多的下载、加载时间。由此推出「启动剧情」能力，对于希望进一步提升游戏启动留存的开发者可以基于该能力精心设计用于“迎新”的剧情内容，进而提升玩家的代入感与游戏的顺畅体验。

## 演示效果

  [演示视频](https://drive.weixin.qq.com/s?k=AJEAIQdfAAoX1N1P1D)

  <等待更多优秀游戏作品入驻>

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

[演示工程源码]()
由于启动剧情为Unity启动加载耗时过久而推出的能力，因此主要配置由 JavaScript 脚本实现（早于WASM初始化）。

### 步骤一：设计剧情

剧情设计由开发者自行准备游戏主题相关视频、图片资源素材并上传至CDN。剧情编辑工具目前有一定的使用学习成本，内测阶段为了降低开发者的接入难度，具体的剧情设计需联系研发助手协助设计。

剧本产物：资源目录 `launchOperaPlay`。

### 步骤二：配置启动剧情

1. 使用微信开发者工具打开微信SDK导出产物中 `minigame` 目录，在模拟器中运行导出的Unity小游戏；
2. 将 **步骤一** 中 `launchOperaPlay` 资源放到 `minigame` 目录中；
3. 打开 `mingame/game.js` 文件，该文件是 JavaScript 运行的入口文件，在文件底部增加启动剧情初始化配置。

```js
// game.js

...   // 原有的代码

// 底部增加启动剧情配置
// launchOperaInit 是用于初始化剧情的回调事件
// 配置工作需要在该回调中使用「同步」方式完成，请勿使用异步函数
GameGlobal.event.on("launchOperaInit", (operaHandler) => {

  // 如需读取本地缓存请使用 getStorageSync 读取，请勿使用异步方式
  // 如需异步请查阅「基于异步干预剧情发展」
  let play = true;
  try {
    var value = wx.getStorageSync('launchOperaLocalDataXXX'); // 自行管理的本地缓存 Key-Value
    if (value) {    // 本地有特定缓存标识意味已经不是首次访问可以不播放
      play = false;
    }
  } catch (e) { }

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

});

```

### 基于异步干预剧情发展

初始化期间可以同步读取本地资源简单判断是否需要播放剧情，但对于有网络存档的游戏而言，显然不是可靠的判断新用户的方案（用户新设备或本地缓存丢失时也将判定为新用户），这将涉及到异步方式来干预启动剧情插件的工作。异步由于存在不确定的结果返回时间，游戏的启动自然不能始终等待这段空隙，因此在异步结果返回前，我们应让启动剧情插件**正常启动**，并在后续合理的时机完成故事线的切换。下图给出一种推荐的做法：

![](/image/launch-opera/image-0.png)

我们可以看到，默认的剧情将固定播放一段大约3～5秒钟的启动动画（可以是游戏厂家Logo、防沉迷提醒等），在3～5秒期间 JavaScript 脚本尝试用一些途径来确定后续的剧情发展（可以通过网络交互、本地读取等），当确认后，启动剧情插件允许配置相关变量进而干预剧情发展。
值得注意的是，异步的获取时间明显是不可控的，因此是有可能在5秒的启动动画结束后，仍未得到期望的结果，因此推荐的设计是默认情况下仅播放5秒的启动动画，后续剧情不播放，当5秒内明确了后续播与不播放的选择时，按结果配置，若仍未得到结果，可以按照老用户立即结束剧情即可。具体如何抉择，开发者可以自行设计。


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

## API

JavaScript 与 C# 环境中均能获得 launchOpera 控制句柄，
JavaScript 中除了 `launchOperaInit` 回调函数参数中可获得句柄外， 全局变量 `GameGlobal.launchOpera` 同样可访问；
C# 环境中引入微信SDK同样可以获得交互句柄。

### .running
只读属性，获得当前剧情插件运行状态，`true` 代表正在播放剧情，`false` 为未运行或已播放结束资源析构。

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

### .onEnd( callback )
注册当剧情结束时的回调事件。
当产生该回调时意味着启动剧情组件资源已经完全析构，同时自动释放注册的事件（如 .onErr 、.onEnd），无需开发手动释放。

### .offEnd( callback )
注销当剧情结束时配置的回调事件。

### .onErr( callback )
注册当发生异常时的回调事件。
引发异常的可能是：剧本文件读取失败、剧本与启动剧情插件版本不兼容、插件环境异常、CDN视频资源播放失败等。
为避免发生异常时用户无法退出启动剧情插件，推荐开发者在 onErr 强制结束启动剧情。

```js
launchOpera.onErr((err) => {
  launchOpera.end();    // 强制结束
});
```

### .offErr( callback )
注销当发生异常时的回调事件。