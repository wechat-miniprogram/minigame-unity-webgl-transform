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
以下配置都在导出的minigame/game.js中
### 3.1 启动界面
由于Unity WebGL启动加载需要一定时间，因此需要使用视频或图片等内容作为过渡以留住玩家。Unity Loader默认使用视频+进度信息呈现，开发者可以自定义封面视频，可参考[启动Loader视频规范](video.md)进行配置。
界面有以下两种
1. 使用coverview渲染进度（默认方式）
   <image src="/image/coverview_loading.png" height="500">
   这种方式的优势在于可以覆盖因首帧逻辑过重，导致启动过程中可能出现的黑屏，等游戏画面真正出现时再隐藏启动界面
   支持参数
   ```js
   loadingPageConfig: {
      // 背景图或背景视频，两者都填时，先展示背景图，视频可播放后，播放视频
      backgroundImage: 'images/background.jpg', // 默认的背景图，可自行替换，支持本地图片和网络图片
      backgroundVideo: '', // 视频url，需要开发者提供，只支持网络url
      // 以下是默认值
      totalLaunchTime: 15000, // 默认总启动耗时，即加载动画默认播放时间，可根据游戏实际情况进行调整
      textDuration: 1500, // 当downloadingText有多个文案时，每个文案展示时间
      firstStartText: '首次加载请耐心等待', // 首次启动时提示文案
      downloadingText: ['正在加载资源'], // 加载阶段循环展示的文案
      compilingText: '编译中', // 编译阶段文案
      initText: '初始化中', // 初始化阶段文案
      completeText: '开始游戏', // 初始化完成
    }
   ```
   > backgroundImage需要注意图片宽高不可超过2048，否则无法显示
   > 使用coverview需要基础库版本>=2.16.1，插件已做兼容，若不支持，降级为使用离屏canvas渲染进度的方式
2. 使用离屏canvas渲染进度
   <image src="/image/default_loading.jpg" height="500" />
    支持参数
    ```js
    let managerConfig = {
      // ...省略其他配置
      LOADING_VIDEO_URL: "", // 视频url
    }
    ```
当基础库>=2.16.1时，默认使用coverview，否则使用离屏canvas
### 3.2 首包资源加载方式
**加载方式在转换工具导出时就确定好了，开发者一般不需要修改**
当游戏资源量比较少时，可选择将首包资源作为小游戏分包加载，了解[小游戏分包](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/sub-packages.html)
wasm代码已是通过代码分包加载，当wasm代码+首包资源>20M时，资源包不可再使用小游戏分包加载。
当首包资源通过小游戏代码分包下载时，会将首包资源存放在minigame/data-package这个分包下
相关配置
```js
let managerConfig = {
  /* 省略其他配置 */
  loadDataPackageFromSubpackage: $LOAD_DATA_FROM_SUBPACKAGE, // 转换工具自动替换
}
```
- 若手动将`loadDataPackageFromSubpackage`改为false，需要将webgl目录下的资源包上传到CDN，并将CDN地址填写到game.js`DATA_CDN`字段
- 同样的，若手动将`loadDataPackageFromSubpackage`改为true，需要将webgl目录下的资源包copy到minigame/data-package下
### 3.3 预加载资源
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

### 3.4 资源缓存与淘汰策略
#### 资源缓存
首包资源和wasm代码会自动缓存。
使用bundle时，插件也会做缓存处理，但插件需根据下载文件名进行处理，因此需要注意:

1. bundle文件名不可重名，否则同名文件无法使用缓存
2. bundle名需要带上md5 [BuildAssetBundleOptions.AppendHashToAssetBundleName](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.AppendHashToAssetBundleName.html)，以便清理掉该文件的旧缓存
3. bundle存放路径需要包含StreamingAssets这个path（一般addressable默认打包会放在StreamingAssets/aa/WebGL/WebGL/这个目录下），或者文件名包含.bundle，才能启用缓存

#### 资源淘汰
由于缓存目录最大不可超过200M，在下载资源包、下载AB包时，若剩余空间不足以缓存，会进行缓存淘汰。目前规则比较简单，如下：
1. 如果所需空间过大，超过最大限制：下载完成后不缓存文件，也不执行清理逻辑，直接返回下载内容。
2. 清理部分文件可以缓存新文件：按最近使用时间从前往后排序清理，直到清理出所需空间。

> 因为文件解压只能解压到用户目录，所以，若压缩文件过大，无法解压到用户目录时，会返回失败。
 

### 3.5 其他可配置参看
在`game.js`中修改插件配置
### 基本配置
```js
let managerConfig = {
  DATA_FILE_MD5: "$DATA_MD5", // 转换脚本自动填写，无需关注
  CODE_FILE_MD5: "$CODE_MD5", // 转换脚本自动填写，无需关注
  GAME_NAME: "$GAME_NAME", // 转换脚本自动填写，无需关注
  APPID: "$APP_ID", // 转换脚本自动填写，无需关注
  DATA_FILE_SIZE: "$DATA_FILE_SIZE", // 资源文件大小，自动填写无需关注

  LOADING_VIDEO_URL: "$LOADING_VIDEO_URL", // 默认加载视频地址
  DATA_CDN: "$DEPLOY_URL", // 下载资源文件的CDN
  AUDIO_PREFIX: "$AUDIO_PREFIX", // 音频资源cdn
  STREAMING_CDN: "$STREAM_CDN", // AB包存放地址，有用到AB包时需要填写
  
  loadDataPackageFromSubpackage: $LOAD_DATA_FROM_SUBPACKAGE, // 资源包是否作为小游戏分包加载
};
```