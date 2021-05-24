# 代码分包

目前我们采用了一种 Profile Guided Optimization 的方式，通过离线运行时收集信息，将小游戏的 wasm 代码包进行拆分，使得小游戏可以先加载较小的首包进入主场景，再异步加载剩下的分包

我们提供了一个开发者工具插件来辅助分包过程，依赖的[开发者工具](https://developers.weixin.qq.com/miniprogram/dev/devtools/download.html)版本为 1.05.2104251 RC 及以上，稳定版 1.05.2105100 已支持

分包工作流如图所示
<image src="../image/wasmsplit/workflow.png">

## 打开分包

通过开发者工具的设置-拓展设置-编辑器自定义拓展，打开 minigame.codeSplit 这个插件的开关
<image src="../image/wasmsplit/extension-panel.png">
<image src="../image/wasmsplit/enable-plugin.png">

## 使用流程

1. 打开插件开关后，在目录树上的工具栏中，可以看到插件的按钮，如图所示，点击后即可进入插件页：
   <image src="../image/wasmsplit/code-split-index.png">

2. 点击启用代码分包，新导出的小游戏（注：同一游戏从 unity 的不同次导出也认为是新的）会提示输入版本描述，简单输入方便识别版本的描述即可，然后插件会自动进行首次分包

3. 第一次分包完成后，就可以开始迭代式收集，每一轮迭代流程如下：

- 点击开始收集
- 点击开发者工具的预览，在真机上跑，有条件的话可以尽量覆盖各种机型(主流品牌)以及平台(Android/iOS)
- 当插件页显示的收集到增量函数个数相对稳定时，可以点击结束收集
- 点击生成 profile 包

<image src="../image/wasmsplit/code-split-index-2.png">
<image src="../image/wasmsplit/profiling.png">

随着迭代轮数增多，新增函数会越来越少，

这里没有完成收集的标准，建议开发者能回归覆盖游戏的各种启动场景即可（不同进度，二次启动等等），目的是为了延迟依赖剩下的分包的时间

4. 当收集评估 ok 时，可以点击生成 release 版分包，生成最终的发布版本（如果生成了 release 包，下次收集前需要先生成 profile 包）

## 关闭分包

如果想发布不分包的版本，点击插件页的关闭代码分包按钮即可
