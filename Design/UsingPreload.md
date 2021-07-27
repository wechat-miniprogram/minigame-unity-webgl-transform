# 使用预下载功能
## 概述
通过 [启动流程与时序](Design/Startup.md)我们知道，在UnityLoader加载过程中存在网络空闲的情况。特别是“引擎初始化和首场景准备”，影响该步骤包括：引擎自身模块与数据初始化，游戏首个场景加载以及Awake流程。这个过程是CPU处理密集，但网络空闲的期间，根据机型性能不同，通常平均耗时会在3~6s左右，我们可以在此阶段提前下载资源。


## 导出预下载列表
<image src='../image/usingpreload1.png' width="500"/>

在Unity转换导出插件填写文件列表，生成时工具会自动从webgl/StreamAssets目录找资源并填充到game.js。
运行时UnityLoader将根据列表内容在网络空闲期下载。

## 手动配置
除了在Unity转换导出插件填写文件列表外，也可以在生成的game.js手动配置：
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

## 注意事项
1. 预下载所有文件总体积应控制在合理范围内，通常可以3~5MB左右的内容。
2. 文件数量应控制在10个以内，在此阶段最多只能允许10个并发，超过将会排队。
3. UnityLoader插件已经考虑到业务会重复请求预下载的文件，游戏逻辑依然按未使用预下载的异步记载逻辑去些，如果预下载完成插件会立即返回内容，业务无感知。