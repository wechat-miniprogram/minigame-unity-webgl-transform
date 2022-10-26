# 启动留存数据上报统计

## 一、概述
在小游戏环境下，玩家对启动时长与体验非常敏感（尤其从“广告”等买量场景进入的玩家）。开发者往往需要分析玩家从点击到进入游戏核心玩法的整个过程流失率。
[Unity Loader](UsingLoader.md)的数据统计功能如下：
1. Unity Loader插件自动统计了代码包、首包资源、代码编译、引擎与首场景初始化，无需手动上报
2. 通过C# SDK接口让开发者上报自定义启动阶段，分析每个环节可能存在的流失

## 二、上报广告信息
为了帮助开发者分析广告渠道的留存数据，达到最好的买量效果，Loader提供了上报广告参数的能力，用于区分**不同广告位/广告类型/素材类型**的数据。

#### 如何上报？
广告买量时，带上广告相关自定义参数，Loader自动上报
eg: `adSpaceType=1&adType=1&materialType=1`

- adSpaceType: 广告位类型；一个广告位可以投放不同类型的广告
- adType: 广告类型；一个广告类型可以投放不同素材
- materialType: 素材类型

取值范围：1-200; 默认为0

## 三、上报自定义阶段
为了详细统计玩家的流失情况以便开发者进行优化，我们拆分了三个部分。
<img src='../image/reportstartupstat3.png'/>
其中**自动上报**为Unity Loader自动完成开发者无需关注，但**自定义阶段**与**启动加载完成**需开发者主动调用接口进行上报。详细接口可参考C# SDK中的WX.cs，此处列出关键接口：

**1. 定义阶段**

设置游戏当前阶段，通过此接口，插件能感知到游戏业务所处阶段。
``` C#
    WX.SetGameStage(int stageType)
```
stageType取值范围：[200,10000]

**2. 上报阶段耗时**
上报当前自定义阶段耗时
``` C#
      WX.ReportGameStageCostTime(int costTime, string extJsonStr)
```
costTime为阶段耗时，如不关心可填0
extJsonStr为阶段额外信息，可填""

**3. 游戏完成所有加载时上报**

当游戏完成所有加载阶段，进入核心玩法时(如进入新手引导或大厅)调用
``` C#
      WX.ReportGameStart()
```
**4. 上报当前自定义阶段错误信息**
``` C#
      WX.ReportGameStageError(int errorType, string errStr, string extJsonStr)
```
errorType取值：[0,10000]

示例：
``` C#
      // 假设Loading场景中A资源完成为200, 需要知道完成的留存率
      WX.SetGameStage(200);
      WX.ReportGameStageCostTime(0, "");
      
      // 所有加载完成，玩家可以交互(如休闲游戏已进入核心玩法、MMO游戏进入创角时), 需要知道留存率
      WX.ReportGameStart();
```

## 四、获取Loader启动阶段
从启动时序可以知道Loader启动阶段分为以下五个阶段
- wasm代码包下载
- wasm编译
- 首包资源下载
- 首包资源读取
- 引擎初始化(callmain)

当业务侧需要使用Loader启动数据时，可以使用Loader暴露的进度事件上报到自己的系统
> tips: 目前只支持js调用
```js
gameManager.onLaunchProgress = (e) => {
      // e: LaunchEvent
      // interface LaunchEvent {
      //   type: LaunchEventType;
      //   data: {
      //     costTimeMs: number; // 阶段耗时
      //     runTimeMs: number; // 总耗时
      //     loadDataPackageFromSubpackage: boolean; // 首包资源是否通过小游戏分包加载
      //     isVisible: boolean; // 当前是否处于前台，onShow/onHide
      //     useCodeSplit: boolean; // 是否使用代码分包
      //     isHighPerformance: boolean; // 是否iOS高性能模式
      //   };
      // }
      if (e.type === launchEventType.launchPlugin) {

      }
      if (e.type === launchEventType.loadWasm) {

      }
      if (e.type === launchEventType.compileWasm) {

      }
      if (e.type === launchEventType.loadAssets) {

      }
      if (e.type === launchEventType.readAssets) {

      }
      if (e.type === launchEventType.prepareGame) {

      }
}
```

## 五、获取数据统计
数据报表包含Unity Loader自动上报与开发者自定义阶段。关注总体流失漏斗以确定需要优化的方向，同时分阶段的耗时分布有利于帮助我们分析该阶段的对应耗时的用户占比。
<img src='../image/reportstartupstat1.png'/>

<img src='../image/reportstartupstat2.png'/>

注：
目前该数据统计报表需要建联[小游戏研发助手](IssueAndContact.md)获取，未来会开放到《小游戏数据助手》。
