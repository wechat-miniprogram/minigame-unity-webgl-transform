# 启动封面
由于Unity WebGL启动加载需要一定时间，因此需要使用视频或图片等内容作为过渡以留住玩家。Unity Loader默认使用图片+进度信息，铺满全屏呈现。

开发者可自定义以下内容
- 替换加载图片/视频
- 加载文案及样式
- 进度条样式
- 封面自动隐藏时机

## 完整配置

### 转换插件配置
```
bgImageSrc: 启动封面图；-- $BACKGROUND_IMAGE
VideoUrl: 启动视频；-- $LOADING_VIDEO_URL
HideAfterCallMain: 是否callmain完成后立即隐藏封面；-- $HIDE_AFTER_CALLMAIN
```

### game.js配置
样式配置**未提供对应的转换插件配置入口**，需要修改unity工程中，小游戏模板`wechat-default/game.js`

```js
hideAfterCallmain: $HIDE_AFTER_CALLMAIN,// 是否需要callmain结束后立即隐藏封面视频
// 加载页配置项
loadingPageConfig: {
  totalLaunchTime: 15000, // 默认总启动耗时，即加载动画默认播放时间，可根据游戏实际情况进行调整
  /**
   * !!注意：修改设计宽高和缩放模式后，需要修改文字和进度条样式。默认设计尺寸为667*375
   */
  designWidth: 0, // 设计宽度，单位px
  designHeight: 0, // 设计高度，单位px
  scaleMode: '', // 缩放模式, 取值和效果参考，https://github.com/egret-labs/egret-docs/blob/master/Engine2D/screenAdaptation/zoomMode/README.md
  // 以下配置的样式，尺寸相对设计宽高
  textConfig: {
    firstStartText: '首次加载请耐心等待', // 首次启动时提示文案
    downloadingText: ['正在加载资源'], // 加载阶段循环展示的文案
    compilingText: '编译中', // 编译阶段文案
    initText: '初始化中', // 初始化阶段文案
    completeText: '开始游戏', // 初始化完成
    textDuration: 1500, // 当downloadingText有多个文案时，每个文案展示时间
    // 文字样式
    style: {
      bottom: 64,
      height: 24,
      width: 240,
      lineHeight: 24,
      color: '#ffffff',
      fontSize: 12,
    }
  },
  // 进度条样式
  barConfig: {
    style: {
      width: 240,
      height: 24,
      padding: 2,
      bottom: 64,
      backgroundColor: '#07C160',
    }
  },
  // 一般不修改，控制icon样式
  iconConfig: {
    visible: true, // 是否显示icon
    style: {
      width: 64,
      height: 23,
      bottom: 20,
    }
  },
  // 加载页的素材配置
  materialConfig: {
    // 背景图或背景视频，两者都填时，先展示背景图，视频可播放后，播放视频
    backgroundImage: '$BACKGROUND_IMAGE', // 背景图片，推荐使用小游戏包内图片；当有视频时，可作为视频加载时的封面
    backgroundVideo: '$LOADING_VIDEO_URL', // 加载视频，网络url
    iconImage: 'images/unity_logo.png', // icon图片，一般不更换
  }
},
```

下面根据配置介绍两种加载效果的实现


## 默认效果
<img src='../image/loading_default.png' width="600"/>

实现默认效果很简单，开发者只需在导出时配置启动素材即可

所需配置项

```js
bgImageSrc: 启动封面图；-- $BACKGROUND_IMAGE
VideoUrl: 启动视频；-- $LOADING_VIDEO_URL
HideAfterCallMain: 是否callmain完成后立即隐藏封面；-- $HIDE_AFTER_CALLMAIN
loadingBarWidth: 加载进度条宽度；-- $LOADING_BAR_WIDTH
```

## 定制效果
启动loader提供的默认加载界面为了契合不同游戏，做得相对通用，但游戏可能会存在定制启动loading的需求，以达到和游戏更贴近的体验。

- 小游戏表现
<img src='../image/loading_demo.jpg' width="600"/>

- 设计稿
设计尺寸：1600*720

<img src='../image/loading_design.jpg' width='600'/>

- 小游戏配置
```js
loadingPageConfig: {
  totalLaunchTime: 15000, // 默认总启动耗时，即加载动画默认播放时间，可根据游戏实际情况进行调整
  designWidth: 1600,
  designHeight: 720,
  scaleMode: scaleMode.fixedHeight,
  textConfig: {
    firstStartText: '', // 首次启动时提示文案
    downloadingText: ['红中在手，天下我有'], // 加载阶段循环展示的文案
    compilingText: '牌从门前过，不如摸一个', // 编译阶段文案
    initText: '牌从门前过，不如摸一个', // 初始化阶段文案
    completeText: '牌从门前过，不如摸一个', // 初始化完成
    textDuration: 1500, // 当downloadingText有多个文案时，每个文案展示时间
    style: {
      bottom: 115,
      height: 45,
      width: 1045,
      lineHeight: 45,
      color: '#ffffff',
      fontSize: 28,
    }
  },
  barConfig: {
    style: {
      width: 1045,
      height: 15,
      padding: 2,
      bottom: 78,
      backgroundColor: '#66b71f'
    }
  },
  materialConfig: {
    // 背景图或背景视频，两者都填时，先展示背景图，视频可播放后，播放视频
    backgroundImage: 'images/background.jpg',
    iconImage:'images/unity_logo.png'
  }
}
```

- `scaleMode`取值
```js
// https://github.com/egret-labs/egret-docs/blob/master/Engine2D/screenAdaptation/zoomMode/README.md
export const scaleMode = {
  noBorder: 'NO_BORDER', // 常用之一，不留黑边
  exactFit: 'EXACT_FIT',
  fixedHeight: 'FIXED_HEIGHT', // 常用之一，高度适配
  fixedWidth: 'FIXED_WIDTH', // 常用之一，宽度适配
  showAll: 'SHOW_ALL',
  fixedNarrow: 'FIXED_NARROW',
  fixedWide: 'FIXED_WIDE',
}
```

