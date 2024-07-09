# Unity WebGL小游戏适配方案性能标准

## 为什么需要性能评测标准？

Unity性能评测标准用于开发者优化游戏性能数据，提升用户体验。评测标准根据小游戏整体的性能数据表现，结合操作系统、机型分档等多种维度建立。

## 评测标准细则

### 性能基线

> 1. 性能基线机型并非特定，但建议综合CPU、内存、GPU等选取性能相当的机型
> 2. 更新时间：2023-05-17

| 档位 |Android参考机型  | iOS参考机型  |
| --- | --- |--- |
| 高档 | ⼩⽶10(⾼通骁⻰865) | iPhone13 |
| 中档 | VIVO S7(⾼通骁⻰765G)、红米k30 | iPhone11 |
| 低档 | OPPO r9s(通骁⻰625) | iPhone7/8/X |

### 指标与测量方法

Unity小游戏的启动可参考[启动流程与时序](Startup.md)

|   | 定义 | 测量方法 |
| --- | --- |--- |
| 首资源包 | 游戏首个data资源文件 | 位于导出目录/webgl/md5.webgl.data.unityweb.bin.txt, CDN使用gzip压缩 |
| WASM代码 | 游戏代码压缩包 | 位于导出目录/minigame/wasmcode/md5.webgl.wasm.code.unityweb.wasm.br, CDN使用gzip压缩 |
| 核心资源 | 除首资源包外进入游戏核心玩法所需的资源量 | 业务自定下载，通常为AssetBundle |
| CALLMAIN | 引擎和首场景(Loading)初始化 | 通过timelog,或日志查看“CALLMAIN耗时” |
| 游戏初始化完成 | 引擎和首场景完成，出现首个业务场景 | 通过timelog, 或日志查看“游戏启动耗时” |
| 游戏可交互完成 | 游戏核心场景完成 | 通常定义为用户可交互的时机，可通过[启动留存上报能力](ReportStartupStat.md)上报统计。</br>注：这个时间一般指的是**无缓存启动**情况下的时间</br>eg：休闲游戏为**核心玩法**，RPG游戏为**创角** |
| 内存峰值 | 内存峰值 | 进程内存峰值，测量方法请参考[优化Unity WebGL的内存](OptimizationMemory.md) |
| 内存Crash运行时长| 由于内存不足而使小游戏发生Crash时，当前游戏的运行时长，表示游戏的稳定运行时长 | 通过[小游戏数据助手](https://developers.weixin.qq.com/minigame/analysis/assistant.html)查看（仅包含线上用户数据）</br> 数据路径：`数据 - 性能分析 - 运行性能 - 内存异常退出分析` |
| 帧率 | 核心玩法的平均帧率 | 测量5分钟以上游戏核心玩法帧率，取平均值 |
| 卡顿率 | 核心玩法的平均卡顿率 | 测量5分钟以上游戏核心玩法卡顿率，取平均值 |

### 代码与资源体积

| 能力 | 下载量 |
| --- | --- |
| 首资源包(gzip压缩后) | <5MB |
| WASM代码(br压缩后) | <5MB |
| 核心玩法资源 | <30MB |

### 评测工具

#### 启动性能

使用网络模拟工具1MB/s条件，使用Unity适配提供TimeLog窗口、运行日志或[小游戏云测试](https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-tools-cloudtest.html)获取性能数据。

#### 运行性能

使用[PerfDog](https://perfdog.qq.com/)测试，PerfDog记录性能数据并上传，取平均值，每种机型测试3组数据再取平均，内存峰值取最大值。

### 评测标准

> 评测标准更新时间：2023-05-17（历史现网标准请查阅[文档](PerfMeasure_old.md)）

评测标准依赖于 **现网真实玩家上报的性能数据** 和 **人工批量测试数据** 统计得出。

#### 开发者需要关注哪些性能指标

| 阶段 | 重点关注指标 |
| :---: | --- |
| 启动 | 1. 游戏初始化完成耗时</br> 2. 游戏可交互耗时(新用户无缓存启动时) |
| 运行 | 1. 内存峰值</br> 2. FPS均值</br> 3. 卡顿率</br> 4. 内存Crash率(iOS)</br> 5. 内存Crash运行时长 |
| 兼容性问题 | 1. 逻辑异常</br> 2. 黑/白屏</br> 3. JS Error |

#### 游戏类型说明

| 分类 | 定义  |
| :---: | --- |
| 重度 | 玩法较复杂，通常包含较多游戏场景或支持多人在线游戏（eg: MMO、SLG品类等） |
| 中度 | 包含一定养成玩法、内置内购商城等（eg: 模拟经营、卡牌等） |
| 轻度 | 仅包含简单操作、无养成体系、无内购，以休闲娱乐为主（eg: 棋牌等） |

#### iOS性能评测标准

***启动性能***

<img src='../image/performance-standard/ios_start_performance.png' />

***运行性能***

重点关注：`内存峰值`、`GC后内存峰值`、`内存Crash率`、`内存Crash运行时长`

> 注：如果使用PerfDog采集数据，其CPU占用数据是**除以**了核心数的。跟该表格对比时，请将数据**乘以**核心数之后再作对比。

<img src='../image/performance-standard/ios_running_performance.png'/>

#### Android性能评测标准

***启动性能***

<img src='../image/performance-standard/android_start_performance.png' />

***运行性能***

<img src='../image/performance-standard/android_running_performance.png'/>
