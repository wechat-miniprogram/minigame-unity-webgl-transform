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

确保正确安装Node.js与npm包管理器时，只需在你的PC命令行中输入：

```sh
npm install launch-opera-cli -g
```

有时可能需要以管理员身份运行该命令。

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

接下来请你使用 JavaScript 代码编辑器打开当前工程目录（如 VSCode 打开），找到 `/src/launchOperaPlay/index.ts` 脚本。

请修改脚本中大约第 51 行的 skipButton 的 setParams 参数为：

```js
skipButton.setParams({
  // right: 30,   // 修改前
  left: 30,   // 修改后
  bottom: 60,
  width: 173 / 1.5,
  height: 64 / 1.5,
  url: 'launchOperaPlay/skip.png',
  visible: true,
});
```

此时保存这个文件，如果你的 Step3 中启动的开发模式还在工作，那么 `/minigame` 目录资源也将被实时更新，此时 `微信开发者工具` 通常也将重新加载游戏内容，你会看到被你刚刚修改的按钮贴图位置从右下角变成左下角。

以此类推，你可以快速修改你看到的很多属性内容，比如位置信息、URL地址从而改变剧情的内容。

#### Step6 导出剧本

当你对剧情设计完成，需要导出剧本给正式的游戏工程使用时，请回到 Step3 中你开启的命令行窗口，Windows系统下使用 `Ctrl + C` MacOS 系统下使用 `control + C` 结束开发模式。

再次执行：

```sh
lacop build
```

等待程序执行结束后，你将在根目录看到 `/release` 目录，此时你可以将 release 目录内资源放到你的正式游戏工程导出的 minigame 目录下使用。

有关图片资源路径问题请阅读 [常见Q&A](#常见qa) 中说明。

至此你已经完成了一次很小变动的剧本导出工作。

#### Step7 尝试更多的模板

启动剧情能够设计很复杂的交互剧情内容，但是这对于初次使用的开发者还需要阅读本文更多的内容，后续请查阅 [进阶指南](#4进阶指南)。如果你想快速应用场景，类似 Step5 中这样仅修改属性值就可以替换成自己的游戏素材还是十分便捷。我们提供了多种模板可供选择，只需要在命令行中输入 `lacop template` 可以快速切换提供的多种模板效果拿来使用。

**实际上你可以直接执行 `lacop` 而无需带后面的参数进行能力的自主选择**

## 4.进阶指南

如果模板还不能满足你的需要，请仔细阅读本节，你将学会设计复杂的剧情内容。

### 4.1 了解构建工具

本构建工具已经为开发者配置好了相关类型声明，如果你使用例如 `VScode` 等具备 JavaScript/TypeScript 解析的 IDE 工具将可以享受到函数名联想及参数注释能力。

在使用前请了解本工具的一些行为约束：

- `src` 目录中资源将根据层级结构覆盖构建至 `minigame` 目录中，因此你可以将图片资源放置在本目录中以供引用，其中 `.ts` 结尾的脚本不会覆盖；
- `src/launchOperaPlay` 是固定的启动剧情资源目录，请勿修改名称；
- `src/launchOperaPlay/index.ts` 是固定的剧情撰写文件，请勿修改名称；
- 视频、音频资源均需要存放至 CDN 中，贴图资源只能放置 `src` 目录中；
- `operaData` 是整个剧情的编辑句柄，剧情的设计将由操作它开始。


### 4.2 基本概念

在启动剧情中由两个剧本元素组成，分别是 **关键动作帧(Frame)** 、**故事线(StoryLine)**，关键动作帧更像是一个“函数”，核心思想在于执行到该帧时会引发某种动作，而故事线则是将多个独立的关键动作帧串联有序执行。

#### 4.2.1 关键动作帧

有关关键动作帧的种类，请查阅 [API速查](#5api速查) 。每个关键动作帧均有两个必要的组成部分：属性、事件。

##### 4.2.1.1 属性

属性是从关键动作帧激活的那一刻起被赋予其特定的值，属性决定了该帧的真实视图表现。例如：

```js
// 创建了一个 Image，并赋予了他一些初始化的属性
const skipButton = operaData.createFrame(FrameType.createImage, {
  url: `launchOpera/skip_button.png`,
  right: 25,
  bottom: 25,
  width: 100,
  height: 100,
});

// 也可以创建后再修改其属性，与上面的写法实际效果完全一样
const skipButton = operaData.createFrame(FrameType.createImage);

skipButton.setParams({
  url: `launchOpera/skip_button.png`,
  right: 25,
  bottom: 25,
  width: 100,
  height: 100,
});

// 注意设置属性是一个最终态的表现，也就意味着如下设置只有最后一个是生效的
skipButton.setParams({
  height: 100,  // 会因下面设置会覆盖，因此该设置无效
});
skipButton.setParams({
  height: 101,  // 会因下面设置会覆盖，因此该设置无效
});
skipButton.setParams({
  height: 102, // 因最后赋值则有效，skipButton 的 height 初始值则为 102
});
```

##### 4.2.1.2 事件

事件是对于不同关键动作帧存在不同的事件从而可以引发新的故事线的能力。比如 图片 可以存在被点击(onClick)的事件，视频组件存在开始播放(onPlay)、播放到第n秒时(onPlayTimeAt)、播放结束时(onEnded)等事件，当发生某种事件自然也就可以触发新的故事线内容。

其中，播放到第n秒时(onPlayTimeAt)，n 是一个可变系数，因此事件也是支持配置参数的。

例子：

```js
const video1 = operaData.createFrame(FrameType.createVideo, { ... });
// 设置多个不同的事件
// ①
video1.setEvents({
  event: 'onPlayTimeAt',
  params: {
    sec: 9,
  },
  bind: nextStoryLine,
});
// ②
video1.setEvents({
  event: 'onPlayTimeAt',
  params: {
    sec: 2,
  },
  keep: true,
  bind: [ skipButton ],
});
// ③
skipButton.setEvents({
  event: 'onClick',
  bind: [ operaData.EndFrame ]
});
```

上面的例子展示了实际应用的多种可能，首先是不同于 [属性](#4211-属性) 的后设置的值将覆盖前设置特点，同名事件是支持创建多个并同时生效（对照① ②中均是 pnPlayTimeAt 事件，但都是独立生效）。② 中使用了一个 keep 字段告诉剧情引擎该事件是反复有效，意味着实际运行时多次达到该事件条件都会引发该事件，而 ① ③ 没有设置 keep 发生一次事件后再达成条件也不会再次引发该事件。

再次观察 ① ② 的 bind，可以发现发生事件后执行的新的故事线其实可以存在多种表达方式，① 中是上下文中开发者自行创建的名为 `nextStoryLine` 故事线，有关故事线创建请阅读 [故事线](#422-故事线) 小节，而 ② 中是放了一个由 关键动作帧 组成的数组，这其实是一种匿名故事线。

最后 ③ 中的 `operaData.EndFrame` 实际上最特殊的关键动作帧，当执行到该帧后，启动剧情将立即结束。

#### 4.2.2 故事线

故事线是将一个或多个关键动作帧有序打包的容器，比较特殊的是，启动剧情需要存在一个主故事线作为启动入口。

##### 4.2.2.1 创建及添加关键动作帧

创建故事线以及添加关键动作帧很简单，使用 operaData 句柄执行：

```js
// 创建
const storyLine = operaData.createStoryLine();

// 创建一系列的动作帧...

// 如需添加动作帧
storyLine.add(var_GC_GUIDE_STEP, startImg, video1, ... );
```

##### 4.2.2.2 主故事线

主故事线是启动剧情启动后最先执行的内容，当你第一次创建故事线时，那条线也就是主故事线了。

主故事线有一些很常见的用途，比如挂载一些全局变量放到主故事线上就很合理，这样你可以在任何时候对全局变量进行使用，对于全局变量的详细介绍请阅读 [全局变量]() 小节。


## 5.API速查

了解基本概念后，你也就知道驱动整个剧情发展无非3点。
- 合适的时机执行需要的关键动作帧；
- 用故事线串联一系列动作帧让他们有序执行；
- 关键动作帧可以达成某种事件从而产生新的一条故事线。

故事线的理解比较简单，重点是了解微信小游戏为开发者们提供了哪些关键动作帧，你可以略读 FrameType速查表 大概知道有哪些能力，并可以具体查看每一个 FrameType 的使用说明，来完成剧情的自主设计。

### FrameType速查表

点击名称可快速查阅说明

FrameType | 释义
-|-
[createVideo](#frametypecreatevideo)| 创建视频组件
[pauseVide](#frametypepausevideo)| 将某个视频组件进行暂停
[playVideo](#frametypeplayvideo)| 将某个视频组件进行继续播放
[createAudio](#frametypecreateaudio)| 创建音频组件
[pauseAudio](#frametypepauseaudio)| 将某个音频组件进行暂停
[playAudio](#frametypeplayaudio)| 将某个音频组件进行继续播放
[createImage](#frametypecreateimage)| 创建贴图
[createRect](#frametypecreaterect)| 创建矩形区域（可透明、填充纯色、用于区域点击识别）
[setParam](#frametypesetparam)| 设置某个关键动作帧的属性
[setParamSizeAndPosition](#frametypesetparamsizeandposition)| 同时设置组件的Size、Position属性
[setTimeout](#frametypesettimeout)| 创建延迟执行
[createAnimationFunction](#frametypecreateanimationfunction)| 创建动画函数

[var]()| 创建全局变量
[if]()| 条件判断
[report]()| 创建上报节点
[checkPoint]()| 剧情检查点
[reportCheckPointCount]()| 上报剧情检查点个数

### 类型约定

类型主要包括以下几种：

类型名 | 说明
-|-
String | 字符串
Boolean | 布尔值
Number | 数值
None | 可缺省值
Percent | 百分比字符串，如 30%
Frame | 关键动作帧句柄，如 Frame.var 只接受 FrameType 为 var 的句柄

### 空间描述约定

在描述组件的空间位置时，提供了几种简单的描述几乎可以满足大部分的使用需要。

空间描述主要涉及：left、right、top、bottom、width、height 5个属性，这5个属性均支持缺省（None），实际上描述一个组件在屏幕中的位置有时不需要将5个属性完全设置，比如当你规定了 left=0、right=0 时，也就意味着 width=屏幕宽度（width=100%），同理当你 left=0、width=100%，自然right也就=0。

在处理相对位置的时候有时 Number 与 Percent 可能都不能满足你的需要，比如：left=50% 代表屏幕中间，但是你希望屏幕中间再靠左10像素，就无法直接使用 Percent 实现，因为不同用户的设备宽度是不相同的，此时用到 calc 表达式方式，比如刚刚的案例中你可以这样描述： left=calc(50%-10) 就可以了。

### 视频相关

#### FrameType.createVideo

创建视频组件。

##### 属性

属性名 | 类型 | 介绍
-|-|-
top | Number/Percent | 顶端。可参阅[空间描述约定](#空间描述约定)
bottom | Number/Percent | 底端
left | Number/Percent | 左端
right | Number/Percent | 右端
visible | Boolean | 可视
width | Number/Percent | 宽度
height | Number/Percent | 高度
url | String/Frame.var | 视频资源CDN地址
autoPlay | Boolean | 是否自动播放
playing | Boolean | 是否播放中
objectFit | String/Frame.var | 视频的缩放模式，可选值：fill(填充拉伸)、contain(包含，可能有黑边)、cover(覆盖，可能有部分内容溢出屏幕)
seek | Number/String/Frame.var | 视频跳转到特定秒数，如果 < 0 则不跳转
loop | Boolean | 是否循环播放

##### 事件

事件名 | 参数 | 介绍
-|-|-
onPlayTimeAt | sec:Number | 当播放到第sec秒数时（sec单位：秒）
onEnded | - | 视频播放结束时
onPlay | - | 视频开始播放时

##### 案例

```js
const video = operaData.createFrame(FrameType.createVideo);

video.setParams({
  // 全屏视频
  left: 0,
  right: 0,
  top: 0,
  bottom: 0,
  // 视频完整呈现，可能存在黑边
  objectFit: 'contain',
  // 视频CDN
  url: 'http://abc.com/xx.mp4',
  autoPlay: true,
});

// 播放 1.5s 时触发新的关键动作帧
video.setEvent({
  event: 'onPlayTimeAt',
  param: {
    sec: 1.5,
  },
  bind: [ xxxx ] // 新的关键动作帧/故事线
});

// 可以创建多个事件，互相独立
video.setEvent({
  event: 'onPlayTimeAt',
  ...
});
```

###### seek 的使用案例

seek 需要配合 Frame.SetParam 使用，意味其他事件触发 Frame.SetParam 后为 video 关键动作帧赋值 seek 则产生视频跳转，如需了解 SetParam 请移步特定章节阅读，此处给出 seek 案例：

```js
const video = ... // 创建video

// 创建一个 setParam ，对 video 的 seek 属性设置为 10
// 意味着当触发 seek0 时，video 组件视频将从10秒的位置开始播放
const seek0 = operaData.createFrame(FrameType.setParam, {
  frame: video,
  param: 'seek',
  value: '10'
});

... // 在特定条件下触发 seek0
```

#### FrameType.pauseVideo

暂停视频。

##### 属性

属性名 | 类型 | 介绍
-|-|-
video | Frame.createVideo | 需要暂停的视频的关键动作帧句柄

##### 案例

```js
const video = ... // 创建video

const playVideo0 = operaData.createFrame(FrameType.playVideo, {
  video: video,
});

... // 在特定条件下触发 playVideo0
```

#### FrameType.playVideo

（继续）播放视频。

##### 属性

属性名 | 类型 | 介绍
-|-|-
video | Frame.createVideo | 需要（继续）播放的视频的关键动作帧句柄

##### 案例

同 [FrameType.pauseVideo](#frametypepausevideo) 使用。

### 音频相关

#### FrameType.createAudio

创建音频组件。

##### 属性

属性名 | 类型 | 介绍
-|-|-
url | String/Frame.var | 音频资源CDN地址
autoPlay | Boolean | 是否自动播放
playing | Boolean | 是否播放中
seek | Number/String/Frame.var | 视频跳转到特定秒数，如果 < 0 则不跳转
loop | Boolean | 是否循环播放
volume | Number | 音量，0～1之间的数值，默认为1

##### 事件

事件名 | 参数 | 介绍
-|-|-
onPlayTimeAt | sec:Number | 当播放到第sec秒数时（sec单位：秒）
onEnded | - | 音频播放结束时
onPlay | - | 音频开始播放时

##### 案例

```js
const audio = operaData.createFrame(FrameType.createAudio);

audio.setParams({
  // 视频CDN
  url: 'http://abc.com/xx.mp3',
  autoPlay: true,
});

// 播放 1.5s 时触发新的关键动作帧
audio.setEvent({
  event: 'onPlayTimeAt',
  param: {
    sec: 1.5,
  },
  bind: [ xxxx ] // 新的关键动作帧/故事线
});

// 可以创建多个事件，互相独立
audio.setEvent({
  event: 'onPlayTimeAt',
  ...
})
```

#### FrameType.pauseAudio

暂停音频。

##### 属性

属性名 | 类型 | 介绍
-|-|-
audio | Frame.createAudio | 需要暂停的音频的关键动作帧句柄

##### 案例

同 [FrameType.pauseVideo](#frametypepausevideo) 使用。

#### FrameType.playAudio

（继续）播放音频。

##### 属性

属性名 | 类型 | 介绍
-|-|-
audio | Frame.createAudio | 需要（继续）播放的音频的关键动作帧句柄

##### 案例

同 [FrameType.pauseVideo](#frametypepausevideo) 使用。


### 贴图相关

#### FrameType.createImage

创建贴图组件。

贴图只能加载小游戏包内图片资源，并且需要主动设置高宽（不会自动读取贴图资源尺寸）。

##### 属性

属性名 | 类型 | 介绍
-|-|-
top | Number/Percent | 顶端。可参阅[空间描述约定](#空间描述约定)
bottom | Number/Percent | 底端
left | Number/Percent | 左端
right | Number/Percent | 右端
visible | Boolean | 可视
width | Number/Percent | 宽度
height | Number/Percent | 高度
opacity | Number | 透明度 0～1
url | String/Frame.var | 图片资源本地路径
scaleWidth | Number | 宽度放缩系数
scaleHeight | Number | 高度放缩系数

##### 事件

事件名 | 参数 | 介绍
-|-|-
onClick | - | 当贴图被点击

##### 案例

```js
const image = operaData.createFrame(FrameType.createImage);

// 右下角跳过贴图
image.setParams({
  bottom: 10,
  right: 10,
  width: 100,
  height: 30,
  url: 'launchOperaPlay/skip.png',
});

// 点击事件
image.setEvent({
  event: 'onClick',
  bind: [ ... ],
  keep: true,   // 事件始终有效
});
```

#### FrameType.createRect

创建透明、纯色矩形区域，通常用于透明点击区域、背景色。

##### 属性

属性名 | 类型 | 介绍
-|-|-
top | Number/Percent | 顶端。可参阅[空间描述约定](#空间描述约定)
bottom | Number/Percent | 底端
left | Number/Percent | 左端
right | Number/Percent | 右端
visible | Boolean | 可视
width | Number/Percent | 宽度
height | Number/Percent | 高度
color | String | 十六进制颜色描述字符串（如：#FFFFFF00）

##### 事件

事件名 | 参数 | 介绍
-|-|-
onClick | - | 当贴图被点击

##### 案例

```js
const rect = operaData.createFrame(FrameType.createRect);

// 一个全屏的透明区域，可以用于点击事件透明遮罩
rect.setParams({
  top: 0,
  left: 0,
  bottom: 0,
  right: 0,
  color: '#FFFFFF00'
});

// 点击事件
rect.setEvent({
  event: 'onClick',
  bind: [ ... ],
})
```

### 属性修改

#### FrameType.setParam

设置单个属性。

##### 属性

属性名 | 类型 | 介绍
-|-|-
frame | Frame | 需要修改的 frame 句柄
param | String | 属性名
value | String/Frame.var/Number/Boolean | 新的值

##### 案例

参阅 [seek的使用案例](#seek-的使用案例) 案例

#### FrameType.setParamSizeAndPosition

同时设置 Size 或 Position 相关属性。相比较于 [FrameType.setParam](#frametypesetparam) 每次只能设置1个属性，对于常见的位置属性可以使用 `FrameType.setParamSizeAndPosition` 一次性设置。

##### 属性

类型中 None 代表可缺省，即不设置该属性。

属性名 | 类型 | 介绍
-|-|-
frame | Frame | 需要修改的 frame 句柄
top | Number/Percent/None | 顶端
bottom | Number/Percent/None | 底端
left | Number/Percent/None | 左端
right | Number/Percent/None | 右端
visible | Boolean/None | 可视
width | Number/Percent/None | 宽度
height | Number/Percent/None | 高度
opacity | Number/None | 透明度 0～1
scaleWidth | Number/None | 宽度放缩系数
scaleHeight | Number/None | 高度放缩系数

##### 案例

```js
const image = ... // 创建image

// 调整Image位置
const setPositon = operaData.createFrame(FrameType.setParamSizeAndPosition, {
  frame: image,
  top: 0,
  right: '10%',
  opacity: 0.5
});

... // 在特定条件下触发 setPositon
```

### 延迟执行

#### FrameType.setTimeout

类似 JavaScript `setTimeout` 的延迟执行。

##### 属性

属性名 | 类型 | 介绍
-|-|-
timeout | String/Number/Frame.var | 延迟时长，单位 ms
cancel | Boolean | 取消状态，运行时赋值false可提前终止延迟执行

##### 事件

事件名 | 参数 | 介绍
-|-|-
onEnded | - | 当延迟结束后
onCancel | - | 当主动取消时

##### 案例

```js
const delay1000 = operaData.createFrame(FrameType.setTimeout, {
  timeout: 1000,  // 1000ms
});

delay1000.setEvent({
  event: 'onEnded',
  bind: [ ... ] // 1000ms 后执行的关键动作帧/故事线
});
```

### 动画相关

#### FrameType.createAnimationFunction

创建动画函数，使得视图组件的某(几)个属性能够按照持续时间完成渐变。无需考虑卸载动画函数，当动画函数被作用的关键动作帧句柄不可视状态时，动画函数将自动结束。

动画在微信开发者工具（模拟器）中表现异常，以真机表现为准。

##### 属性

属性名 | 类型 | 介绍
-|-|-
frame | Frame | 动画被作用的关键动作帧句柄
duration | String/Frame.var | 持续时长
easing | String/Frame.var | 曲率函数，如 ease-out
top | Number/Percent/None | 顶端
bottom | Number/Percent/None | 底端
left | Number/Percent/None | 左端
right | Number/Percent/None | 右端
visible | Boolean/None | 可视
width | Number/Percent/None | 宽度
height | Number/Percent/None | 高度
opacity | Number/None | 透明度 0～1
scaleWidth | Number/None | 宽度放缩系数
scaleHeight | Number/None | 高度放缩系数

##### 事件

事件名 | 参数 | 介绍
-|-|-
onEnded | - | 当动画结束后。

##### 演示

使用动画实现贴图按钮“点击继续”的「呼吸态」是最常见的实用应用，本演示将提供呼吸态按钮的实现：

```js
// 一个位于底部的 点击继续按钮
const button = operaData.createFrame(FrameType.createImage, {
  bottom: 20,
  left: '50%',
  width: 100,
  height: 25,
  url: 'launchOperaPlay/click_go_on.png'
});

// 创建一个淡出的动画（透明度从 1->0.2）
const goonButtonAnimationFadeOut = operaData.createFrame(
  FrameType.createAnimationFunction,
  {
    opacity: 0.2,
    duration: 1000,
    easing: 'ease-out',
    frame: button,
  },
);
// 再创建一个淡入的动画（透明度从 0.2->1）
const goonButtonAnimationFadeIn = operaData.createFrame(
  FrameType.createAnimationFunction,
  {
    opacity: 1,
    duration: 1000,
    easing: 'ease-out',
    frame: button,
  },
);

// 需要两个 Animation 结束后互相调用，即 淡入->结束->淡出->结束->... 循环之
goonButtonAnimationFadeOut.setEvent({
  event: 'onEnded',
  bind: goonButtonAnimationFadeIn,
  keep: true,    // keep = true 很关键，因为该事件将被反复执行
});
goonButtonAnimationFadeIn.setEvent({
  event: 'onEnded',
  bind: goonButtonAnimationFadeOut,
  keep: true,
});

// 挂载一个适合的故事线中触发后则实现「呼吸态」
storyLineX.add(button, goonButtonAnimationFadeOut);
```

### 全局变量

### 条件判断

条件判断

### 上报

## 6.常见Q&A

#### 6.1 图片资源可以使用网络图片吗？
目前图片资源只能存放于小游戏 minigame 目录中，不可使用网络图片。

#### 6.2 为什么要放首帧图片（firstFramePic）
图片资源是跟随微信小游戏包上传至微信服务器，所以在小游戏主逻辑运行时，图片资源也处于就绪状态可以同步加载，因此玩家打开游戏时首帧将看到具体的游戏画面。而视频是存放在CDN的远程资源，不可避免的存在加载延迟问题，所以配置好首帧图片后，在视频可播放后再隐藏图片资源。
