# 使用高精度时间进行性能检测

## 背景

在浏览器默认环境中，开发者通常使用`performance.now()`或`Date.now()`获取时间戳，但这些API存在精度限制：

- `Date.now()`返回自1970年1月1日UTC至今的整型毫秒时间戳，精度固定为1ms
- `performance.now()`理论上可返回浮点型微秒级数值（如1780.7999999988824），但实际精度受浏览器限制：
  - Chrome：0.1ms（100μs）
  - Safari：1ms

![开发者工具的Performance.now()](../image/high-precise-time/HighPreciseTime_Image_0.png)

相较之下，端游/手游APP普遍支持微秒级精度。浏览器环境的时间精度限制对微信小游戏的性能优化工作形成了显著制约。

## 高精度时间与性能深度分析工具

自基础库3.5.4版本起，微信小游戏为Android平台及iOS普通模式提供了底层高精度时间支持。该功能默认关闭，需同时满足以下条件方可启用：

1. 勾选`Development Build`
2. 启用`Enable Perf Analysis`导出选项

![性能深度分析工具](../image/high-precise-time/image.png)

详细使用指南请参考：[性能深度分析工具文档](https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/Design/DeepProfileTool.html)

## 手动开启高精度时间功能

通过修改JS代码可强制启用高精度时间：

1. 打开`weapp-adapter.js`
2. 定位`const clientPerfAdapter = Object.assign`代码段：
```javascript
const clientPerfAdapter = Object.assign({}, {
    now: function now() {
        if (GameGlobal.unityNamespace.isDevelopmentBuild
            && GameGlobal.unityNamespace.isProfilingBuild
            && !GameGlobal.unityNamespace.isDevtools
            && !GameGlobal.isIOSHighPerformanceMode) {
            // 由于wx.getPerformance()获取到的是微秒级，因此这里需要/1000.0，进行单位的统一
            return (ori_performance.now() - ori_initTime) * 0.001;
        }
        return (Date.now() - initTime);
    },
});
```
3. 删除`GameGlobal.unityNamespace.isDevelopmentBuild`和`GameGlobal.unityNamespace.isProfilingBuild`条件判断。


## 注意事项

1. 平台支持
   - 当前仅支持Android和iOS普通模式
   - 其他模式仍保持毫秒级精度

2. 性能影响
   - `performance.now()`较`Date.now()`存在性能开销
   - 不建议在正式版本中开启

3. 版本依赖
   - 需基础库版本≥3.5.4
   - 若手动配置未生效，请检查基础库版本