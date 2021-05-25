# 使用Loader进行游游戏加载

## 一、什么是Unity Loader？
Unity Loader是在微信小游戏环境加载Unity WebGL游戏的加载与适配器，使用微信小游戏插件技术开发，功能包括：
- WebAssembly代码分包加载与编译
- 资源加载与编译
- 启动进度显示
- 缓存策略
- 数据上报

## 二、如何使用Unity Loader插件
生成微信小游戏项目时，转换工具会在`game.json`中声明：
```json
"plugins": {
    "UnityPlugin": {
        "version": "major.minor.patch", // 可切换版本号
        "provider": "wxe5a48f1ed5f544b7",
        "contexts": [
            {
                "type": "isolatedContext"
            }
        ]
    }
}
```
这部分配置表示使用Unity Loader插件进行游戏加载，开发者无需手动修改

首次使用时，会提示添加插件，按提示添加即可
<image src="../image/addPlugin.png">

## 三、配置Unity Loader功能
### 3.1 封面视频
由于Unity WebGL启动加载需要一定时间，因此需要使用视频或图片等内容作为过渡以留住玩家。Unity Loader默认使用视频+进度信息呈现，开发者可以自定义封面视频，可参考[启动Loader视频规范](video.md)进行配置。


### 3.2 预加载资源
为了充分利用网络带宽，在网络空闲时，比如下载完小游戏分包和首包资源后，可以预加载游戏需要用到的AB包。
``` js
let managerConfig = {
  /* 省略其他配置 */

  /** 
   * 假设: AB包打包到 path1/StreamingAssets/WebGL这个目录下; STREAMING_CDN是以path1为根路径上传到服务器的CDN地址
   */
  // 需要在网络空闲时预加载的资源，支持如下形式的路径。
  preloadDataList: [
    // '$STREAM_CDN/StreamingAssets/WebGL/textures_8d265a9dfd6cb7669cdb8b726f0afb1e',
    // '/WebGL/sounds_97cd953f8494c3375312e75a29c34fc2'
  ],
}
```

## 3.3 缓存策略
由于缓存目录最大不可超过200M，在下载资源包、下载AB包时，若剩余空间不足以缓存，会进行缓存淘汰。目前规则比较简单，如下：
1. 如果所需空间过大，超过最大限制：下载完成后不缓存文件，也不执行清理逻辑，直接返回下载内容。
2. 清理部分文件可以缓存新文件：按最近使用时间从前往后排序清理，直到清理出所需空间。

> 因为文件解压只能解压到用户目录，所以，若压缩文件过大，无法解压到用户目录时，会返回失败。
 

### 3.4 可交互视频
***这个配置目前不是对所有游戏适用***
可交互视频相比默认版本的启动页，交互性更强，用户可以通过操作（目前是点击）来切换画面。
可交互视频实际是多段视频，通过点击来切换视频。
视频是流式加载，但也需要平衡好视频质量和视频大小，避免抢占带宽，影响游戏主要启动流程。
``` js
// 是否开启可交互视频
const NEED_INTERACTION = false

// 需要使用可交互视频方案时，需要引入这两个文件
import PageManager from './loading/pageManager'
import VideoManager from './loading/videoManager'

if (NEED_INTERACTION) {
  const videoManager = new VideoManager({
    // 填写一个或多个视频视频地址，可选择传入视频封面
    videoList: [
      // {
      //   src: '',
      //   poster: ''
      // },
      // {
      //   src: '',
      //   poster: ''
      // }
    ]
  })
  const pageManager = new PageManager({
    // jumpBtnImg: 'images/jump-btn.png', // 跳过按钮图片地址，可本地，可远程
    // continueBtnImg: 'images/PageTip.png', // 点击继续按钮图片地址，可本地，可远程
  })
  managerConfig = {
    ...managerConfig,
    // 可交互视频相关配置
    finalPageVideoUrl: '', // 点击跳过后，循环播放的视频地址，不传默认使用LOADING_VIDEO_URL
    videoManager,
    pageManager,
    probability: 0.3, // 可交互视频出现概率
  }

  // 点击跳过按钮
  pageManager.eventEmitter.once('jumpClick', () => {
    const gameManager = GameGlobal.manager
    if (gameManager) {
      gameManager.reportJump()
      gameManager.showFinalPage()
    }
  })
  // 点击继续按钮
  pageManager.eventEmitter.on('continueClick', () => {
    videoManager.continue()
  })
  // 可交互视频播放完毕
  videoManager.once('allvideoEnd', () => {
    const gameManager = GameGlobal.manager
    pageManager.hideContinueBtn()
    gameManager && gameManager.showFinalPage()
  })
  // 每段视频开始前，隐藏点击继续按钮
  videoManager.on('oneVideoStart', () => {
    pageManager.hideContinueBtn()
  })
  // 每段视频播放完毕，显示点击继续按钮
  videoManager.on('oneVideoEnd', () => {
    pageManager.showContinueBtn()
  })
}
```
### 3.5 手动可配置参看
在`game.js`中修改插件配置
### 基本配置
```js
let managerConfig = {
  DATA_FILE_MD5: "$DATA_MD5", // 转换脚本自动填写，无需关注
  CODE_FILE_MD5: "$CODE_MD5", // 转换脚本自动填写，无需关注
  GAME_NAME: "$GAME_NAME", // 转换脚本自动填写，无需关注
  DATA_FILE_SIZE: "$DATA_FILE_SIZE", // 资源文件大小，自动填写无需关注

  APPID: "$APP_ID", // 转换脚本自动填写，无需关注
  LOADING_VIDEO_URL: "$LOADING_VIDEO_URL", // 默认加载视频地址
  DATA_CDN: "$DEPLOY_URL", // 下载资源文件的CDN
  STREAMING_CDN: "$STREAM_CDN", // AB包存放地址，有用到AB包时需要填写
}
```