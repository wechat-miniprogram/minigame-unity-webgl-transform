#  提升Unity WebGL游戏启动速度

## 一、 为什么要做启动优化
### 1.1  小游戏与手游APP的启动差异
微信小游戏具有“即开即用“的特性，手游APP则往往需要较长时间的下载。小游戏玩家对于启动时长更为敏感，因此过长的启动时间将导致用户显著流失。

### 1.2 优化的目标与标准
目前普通小游戏普遍启动时间为7~10s，而如果不经优化的Unity WebGL游戏启动会是该时间的2-3倍以上。我们建议开发者将启动优化作为上线前最为重要的事项。


## 二、分析小游戏启动速度

### 2.1. 查看启动耗时

通过timelog开发者可以看到小游戏目前的启动首屏时长：

<image src='../image/startupop1.png' width="400"/>

要知道各个阶段的含义，我们必要理解[启动流程](Startup.md)
  
小游戏启动主要由三部分影响：
> 1. 首包资源下载 
> 2. WASM代码下载和编译 
> 3. 引擎初始化与开发者首帧逻辑

**建议首屏启动时间控制在10~15s甚至更短**。

### 2.2 分阶段耗时
### 2.2.1 资源下载阶段与首包体积
此阶段主要是小游戏资源下载的消耗时间，新用户或者版本资源更新时玩家需要重新下载。开发者需要了解小游戏玩家网速情况：
> 1. 网络条件绝大部分为wifi或4G(另，微信广告可指定网络条件)
> 2. 玩家平均下载速度约1MB/s
> 3. 微信用户存在不少<300KB/s的低网速玩家

我们建议首包资源**不超过5MB**以减少此阶段的耗时。

### 2.2.2 WASM代码下载和编译
WASM分包的大小会直接影响代码下载时长以及程序初始化编译的时间，关于WASM代码对启动速度的影响，开发者需要注意：
>1. 转换工具会将Unity WebGL包进行br压缩(压缩至原code包的20%)
>2. WASM代码下载与首包资源并行下载，因此占用下载带宽
>3. WASM编译对于低端机来说时间依然可观
>4. WASM编译在中高端机器很快，但对于低端机来说时间依然可观

我们建议原始代码包**不超过30MB**, 建议开发者**勾选"Strip Engine Code"并设置"Managed Stripping Level"为High**。同时，强烈建议开发者可以使用[代码分包](WasmSplit.md)工具将代码包减少到原始尺寸的到1/3。

### 2.2.3 引擎初始化与开发者首帧逻辑
在timelog中呈现的首场景耗时即为引擎初始化与开发者首帧逻辑，关于该阶段耗时，开发者需要注意的是：
>1. MonoBehaviour脚本的首帧Start/Awake应足够少逻辑，优先将画面呈现
>2. 初始场景不宜过大，通常呈现Splah场景即可
>3. 初始场景中需要后续主场景或配置加载时可采取分帧策略，切勿在Start/Awake阻塞。

我们建议开发者[使用预下载功能](UsingPreload.md)，该功能可以利用此阶段的网络空闲期进行资源下载。

### 2.2.4 游戏内资源按需加载
前面我们提到开发者需要将资源从首包分离以较少首屏加载时间，同理，而对于其余的资源开发者最好使用按需加载的方式进行加载，减少玩家进行核心玩法的等待时间。
优化可参考 [使用Addressable Assets System进行资源按需加载](UsingAddressable.md)。

### 2.3 优化总览
我们总结下启动时序以及开发者、平台提升启动性能的优化事项：
<image src='../image/startupop2.png'/>


## 三、常用启动优化技巧
当分析出小游戏需要进行启动优化时，请继续阅读：
* [使用Addressable Assets System进行资源按需加载](UsingAddressable.md)
* [首场景启动优化](FirstSceneOptimization.md)  

## 四、常用启动优化工具
### 4.1. AssetStudio(推荐)
https://github.com/Perfare/AssetStudio

一款开源的资源查看工具，可以检查data首包以及AssetsBundle(或新Addressable)的资源内容，对于分析打包的资源正确性和冗余具有很好的帮助。

### 4.2 BuildReportTool(推荐)
https://assetstore.unity.com/packages/tools/utilities/build-report-tool-8162?locale=zh-CN

很好的前端用于查看Unity编译信息，BRT显示了编译时包括的每个资源占用的存储空间以及未使用资源情况。

### 4.3 Asset Hunter
https://assetstore.unity.com/packages/tools/utilities/asset-hunter-pro-135296

资源清理插件，可将项目中无用资源清理

### 4.4 Unity Addressable Assets System   
https://docs.unity3d.com/Packages/com.unity.addressables@1.16/manual/index.html
Unity全新资源管理流程

