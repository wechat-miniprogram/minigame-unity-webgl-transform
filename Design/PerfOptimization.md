
# 性能优化总览

## 一、为何需要进行性能优化？

Unity WebGL导出形式相对于原生APP应用，需要开发者更关注性能与体验调优。有以下几点原因：
1. 小游戏天生为"即开即用"，在小游戏生态下玩家对启动耗时更敏感。
2. Unity WebGL底层基于WebAssembly，算力不及原生APP。
3. Unity并未对WebGL平台做特别裁剪，启动较慢。

因此，相对于原生APP，无论从启动还是运行上我们都需要做进一步性能优化。

## 二、优化目标
根据平台在不同游戏类型/机型下的评测，我们给出Unity WebGL小游戏可以参照的的[性能评估标准](PerfMeasure.md)，开发者依此对游戏的启动与运行性能进行调优。

## 三、最佳实践
### 3.1 加快游戏启动速度
* 编译选项中仅勾选首场景
* CDN必须开启Brotli或gzip压缩
* 精简首场景物件，尽快渲染让玩家看到游戏首画面
* 减少初始化与首帧逻辑，首场景Awake/Start/首次Update不要包含过重逻辑
* 减少代码包体, 剔除不必要的插件
* 使用代码分包工具缩减WebAssembly首次下载包体


更多信息请参考：
  * [提升Unity WebGL游戏启动速度](StartupOptimization.md)
  * [首场景启动优化](FirstSceneOptimization.md)
  * [使用代码分包工具](WasmSplit.md)
 
### 3.2 资源按需加载
* 尽量避免在各级Resource包含资源，该目录将被直接打包在首资源包
* 使用AssetsBundle/Addressable进行资源加载
* 单个包体最好不超过2MB
* 资源请求并发数不超过20个

更多信息请阅读:
*  [使用Addressable进行资源按需加载](UsingAddressable.md)
*  [使用 AssetBundle 进行资源按需加载](UsingAssetBundle.md)
*  [使用预下载功能](UsingPreload.md)

### 3.3 资源处理建议
* 贴图maxsize尽量不超过1024，小游戏环境适当降低画质
* 贴图尽量不生成Mipmap
* 贴图尽量不使用可写属性
* 字体文件压缩前最大不超过4MB
  
更多信息请阅读:
*  [资源优化工具与建议](AssetOptimization.md)

 
### 3.4 降低小游戏内存使用
* 不要初始化所有未使用的资源
* 释放不使用的资源
* 发布前使用压缩纹理工具进行优化
* 使用微信音频接口对Unity音频进行改造优化
  
更多信息请阅读: 
*  [优化Unity WebGL的内存](OptimizationMemory.md)
*  [压缩纹理优化](CompressedTexture.md)
*  [Unity WebGL内存原理详解](https://gameinstitute.qq.com/community/detail/112321)
*  [音频适配优化](AudioOptimization.md)

### 3.5 降低CPU消耗
* iOS使用高性能模式
* 尽量使用Android CPU Profiler在小游戏真机环境Profie计算瓶颈
* 提前在Unity环境使用Unity Profiler发现问题
* 物理计算较重的游戏使用Fixed Timestep控制计算频率
* 在中低端机型限制帧率已减轻设备发烫

更多信息请阅读:
* [iOS高性能模式](iOSOptimization.md)
* [使用Android CPU Profiler性能调优](AndroidProfile.md)
* [使用Unity Profiler性能调优](UnityProfiler.md)
