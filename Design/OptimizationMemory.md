# 优化Unity WebGL的内存
## 一、内存与OOM
Unity WebGL游戏通常比普通H5(JS)游戏占用更大的内存，在操作系统的控制策略下超出阈值时非常容易被OOM。

为了提高游戏在中低端机型的稳定性，内存优化极为重要。那么，多大的内存是合理的呢？
我们建议内存峰值控制在以下范围([性能评估标准](PerfMeasure.md))：
1. Android: 低档机 < 1.2G,  中高档机 < 1.5G
2. iOS: 低档机 < 1G, 中高档机 < 1.4G

相对而言，Android机型的内存更为宽松。

iOS低档机为iPhone 6sp/7/8等RAM 2G机型为主，中高档机为iPhone 7P/8P/iPhoneX/iPhone11等RAM 3G或以上机型。



## 二、Unity WebGL适配小游戏的内存结构
Unity WebGL内存结构可先参考：

[Unity博客：了解 Unity WebGL 中的内存 (Understanding Memory in Unity WebGL)](https://blogs.unity3d.com/2016/09/20/understanding-memory-in-unity-webgl/?_ga=2.221731928.1756133398.1638172136-1917727044.1634213664)

[Unity博客：Unity WebGL 内存：Unity 堆 (Unity WebGL Memory: The Unity Heap)](https://blog.unity.com/technology/unity-webgl-memory-the-unity-heap)

<img src='../image/optimizationMemory1.png' width="1080"/>
Unity WebGL是以WebAssembly+WebGL技术为基础的应用，运行在浏览器环境，因此游戏内存的分配也是完全托管在这个环境中。

适配在小游戏后，小游戏进程也就成为了“容器”，虽然不再是标准的浏览器，但内存组成结构与上图基本一致，典型游戏的内存占用如下图所示：

<img src='../image/optimizationMemory10.png' width="800"/>


- 基础库+Canvas：在小游戏环境中并不存在DOM，但依然会存在一些基本消耗，比如小游戏公共库，Canvas画布等。典型地，***小游戏公共库约占用内存100~150MB，Canvas 画布与设备物理分辨率相关***，比如iPhone 11 Promax占用约80MB。

- Unity Heap: 托管堆、本机堆与原生插件底层内存。举例，游戏逻辑分配的C#对象等托管内存、Unity管理的AssetBundle和场景结构等本机内存、第三方原生插件(如lua)调用的malloc分配。

- WASM编译: 代码编译与运行时指令优化产生的内存，在Android v8、iOS JavascriptCore中还需要大量内存进行JIT优化

- GPU内存：纹理或模型Upload GPU之后的显存占用, 由于Unity2021之前不支持压缩纹理，纹理内存会造成明显膨胀。

- 音频：Unity将音频传递给容器（浏览器或小游戏）后，播放音频时将占用的内存。目前自带音频系统存在较大内存和性能问题，Unity2021之前不支持内存压缩音频，因此音频加载后将被完整解压，***非压缩音频会导致极大内存占用***。

- 其他： 
   - Emscripten使用[文件系统](https://emscripten.org/docs/api_reference/Filesystem-API.html)模拟Linux/POSIX接口，***代价是占用与文件同等大小的内存***。 请勿使用首资源包、Addressable Cache机制、WWW.LoadFromCacheOrDownload等Cache API***
   - 网络请求造成的浏览器端JS临时内存、垃圾回收
   - 
        





## 三、内存查看工具
开发者可由系统进程、UnityHeap、JavaScript Heap等方面去分析和查看游戏内存。

### 3.1 进程总内存
查看总内存时，我们需要先确定监控的小游戏进程名称：
- Android：WeChat AppBrand1/2
- iOS:普通模式WeChat、高性能模式(WebContent)
#### Instruments in Xcode(iOS)
<img src='../image/optimizationMemory2.png' width="800"/>

使用“Activity Monitor”，选择对应的设备-all processes-捕捉，即可看到所有进程的CPU与内存情况.
<img src='../image/optimizationMemory3.png' width="800"/>

#### Perfdog（Android or iOS）
使用[Perfdog](https://perfdog.qq.com)选择对应的设置-进程名，即可看到相关性能数据，iOS设备应以紫色的XcodeMemory为准。
<img src='../image/optimizationMemory4.png' width="800"/>

### 3.2 UnityHeap
UnityHeap非常关键，典型由以下几部分组成：
- 托管堆， C#对象托管对象、游戏状态
- 本机堆， Unity Native产生，引擎内部对象
- 原生内存，第三方插件（如lua）直接调用malloc产生

分析手段：
1. 勾选转换面板"ProfilingMemory"
2. 代码中增加WeChatWASM.WX.OpenProfileStats显示性能面板(注意：提审版本请勿显示).
游戏左上角显示Performence Stats性能面板
<img src='../image/optimizationMemory6.jpg' width="600"/>

每项指标有三个数值：当前帧、最小值、最大值。

**通常而言：MonoHeap + NativeReserverd + 原生插件内存 = DynamicMemory， 因此开发者需要关注这几部分内存。**

Unity引擎视角：
- MonoHeapReserved: 托管堆的内存预留内存
- MonoHeap：托管堆(如C#业务逻辑)当前的内存使用量 
- NativeReserverd：本机堆(Native)内存分配峰值
- NativeUnused：本机堆(Native)空闲内存值
- NativeAllocated：本机堆(Native)当前的内存使用量
  
  注意：第三方原生插件(如lua)分配内存并未呈现，需开发者自行分析。

底层分配器视角：

- TotalHeapMemory: UnityHeap总预分配内存大小
- DynamicMemory：UnityHeap使用上限
- UsedHeapMemory：UnityHeap真实使用量
- UnAllocatedMemory：UnityHeap预留量

<img src='../image/optimizationMemory11.png' width="600"/>

底层分配器：
- 绿色为空闲内存或碎片，底层分配器会尽量复用
- 白色为预留部分，可被使用 
- 其他颜色，已被业务使用

### 3.3 JavaScript Heap
由于Unity WebGL是托管在浏览器环境中，因此JavaScript Heap包含了大部分（并非全部）我们关注的内存， 通常我们可以使用浏览器自带的内存工具。 
#### FireFox Memory(PC)
#### iOS Safari Timeline(PC or iOS)
<img src='../image/optimizationMemory5.png' width="1080"/>

### 四、内存优化方案
计算公式：
小游戏基础库 + Cavnas + 编译内存 + UnityHeap + Gfx显存 + 音频 + JavaScript内存。
UnityHeap = max(托管/Mono内存) + max(Native/Reserved内存 + C原生代码内存)

以iOS高性能模式为例，一款代码(导出目录/webgl/Build/xxx.code.unityweb或code.wasm)大小为30MB的游戏占用内存为：
小游戏基础库(130MB) + Cavnas(70MB) + 编译内存(300MB) + UnityHeap + Gfx显存 + 音频 + JavaScript(通常<100MB)。

假如游戏需要支持低档机型，将内存控制到1G以内，业务侧(UnityHeap, Gfx显存，音频，JavaScript)需控制在500MB左右。我们此处给出转换游戏中最容易遇到的内存问题与解决方案，如果开发者遇到内存问题时请逐个排查优化。


### 4.1 WASM代码编译内存
- 问题原因：Unity WebGL将所有代码(引擎、业务代码、第三方插件)编译为跨平台的WebAssembly二进制代码，运行时需进行编译执行。编译所占用内存占用非常大（如在iOS系统，30MB未压缩代码需300MB运行时编译内存）。
- 解决办法：
  - 1. [使用代码分包工具](WasmSplit.md)能降低原编译代码内存50%以上。 
  - 2. 手动删除多余插件，减少不必要的Unity模块引入(如物理、Unity数据统计等)

### 4.2 GPU纹理内存
- 问题原因：Unity 2021才开始支持移动平台的压缩纹理，使用RGBA、DXT等纹理格式将导致巨大的内存开销与运行时解压消耗。
- 解决办法：
  - 1. [压缩纹理优化](CompressedTexture.md)能最大程度地减少内存与解压开销。
  - 2. 升级引擎至2021使用ASTC压缩纹理

### 4.3 UnityHeap
- 问题原因：Unity Heap是用于存储所有状态、托管的对象和本机对象，往往由于场景过大或由于业务原因造成瞬间内存峰值。***由于Unity WebGL在单首帧内无法GC***，单帧内瞬间的内存使用非常容易造成crash。同时，***Heap是只增不减且存在内存碎片的。***
- 解决办法: 
  - 1. 转换设置设置合理的“最大内存”
  - 2. 避免场景过大导致瞬间峰值
  - 3. 避免过大的AssetBundle导致瞬间峰值
  - 4. 避免单帧内分配过多的对象, ***切忌产生跳跃峰值***
- 如何设置“最大内存”？该值仅表示UnityHeap的峰值进行预留，避免内存不足时导致扩容产生的尖刺；
  - 1. 转换面板的“最大内存”设置为0，并使用WeChatWASM.WX.OpenProfileStats打开性能面板
  - 2. 将游戏运行一段时间，观察TotalHeapMemory项
  - 3. 转换面板的“最大内存”设置为为略大于步骤2的数值。建议值：休闲游戏256，中度(模拟经营、养成等)512，重度游戏(SLG,MMO)768。
       最大内存可略微大些，真实内存占用以游戏实际使用为准。
  - 4. UnityHeap不宜过大，当UnityHeap>=1024MB时，大部分设备将启动失败；UnityHeap>=500MB时，32位微信(约5%用户)与iOS普通模式大概率启动失败，建议中轻度游戏不超过该值。


### 4.4 首资源包与AssetBundle内存
- 问题原因：首资源包永远占用内存且无法释放；首资源包和AssetBundle自带的cache机制都会使用Emscripten使用[文件系统](https://emscripten.org/docs/api_reference/Filesystem-API.html)，应避免使用。
- 解决办法：
  - 1. 减少首资源包大小，此部分始终占用内存无法释放, 使用AssetBundle；
  - 2. AssetBundle按需加载，及时释放以节省内存；
  - 3. AssetBundle使用时被解压占用Unity Native内存，应减少AssetBundle大小；
  - 4. 避免使用Unity自带的文件缓存机制， ***首资源包和AssetBundle都不应使用文件Cache***；

### 4.5 音频内存
- 问题原因：Unity2021之前不支持内存压缩音频，因此音频加载后将被完整解压，***非压缩音频会导致极大内存占用***。
- 解决办法：
   - 1. 使用小游戏SDK[音频适配优化](AudioOptimization.md)。
   - 2. 避免长音频使用Unity自带Audio系统 

### 4.6 其他常见优化手段
- [Unity加载和内存管理](https://zentia.github.io/2018/04/11/AssetBundle/)
- [性能优化，进无止境-内存篇（上）](https://blog.uwa4d.com/archives/optimzation_memory_1.html)
- [性能优化，进无止境-内存篇（下）](https://blog.uwa4d.com/archives/optimzation_memory_2.html)
- [全面理解Unity加载和内存管理](https://gameinstitute.qq.com/community/detail/100741)


## 五、QA
1. Q: 在Unity Profiler看到内存才200MB+，是否代表游戏内存无问题

   A: 不是。游戏占用内存必须以真机环境为准，使用Perfdog（Android or iOS）或 Instruments in Xcode(iOS)测试对应进程的内存占用。Unity Profiler仅能看到Unity Heap相关内存，并不包含小游戏公共库、Cavas、WebAssembly编译以及容器其他内存。

2. Q: 转换面板设置内存值多少合适？
   
   A: 可使用WeChatWASM.WX.OpenProfileStats查看Dynamic项，需要预留略大于游戏Dynamic峰值，避免游戏进行过程中产生内存扩容。建议值：休闲游戏256，中度(模拟经营、养成等)512，重度游戏(SLG,MMO)768，必须<1024。
   
