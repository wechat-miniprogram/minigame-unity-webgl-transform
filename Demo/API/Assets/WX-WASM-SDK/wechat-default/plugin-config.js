export const launchEventType = {
  launchPlugin: 0, // 插件启动
  loadWasm: 1, // 加载wasm代码包
  compileWasm: 2, // 编译wasm代码
  loadAssets: 3, // 加载首包资源
  readAssets: 5, // 读取首包资源
  prepareGame: 6, // 初始化引擎
}

// https://docs.egret.com/engine/docs/screenAdaptation/zoomMode
export const scaleMode = {
  noBorder: 'NO_BORDER', // 常用之一，不留黑边
  exactFit: 'EXACT_FIT',
  fixedHeight: 'FIXED_HEIGHT', // 常用之一，高度适配
  fixedWidth: 'FIXED_WIDTH', // 常用之一，宽度适配
  showAll: 'SHOW_ALL',
  fixedNarrow: 'FIXED_NARROW',
  fixedWide: 'FIXED_WIDE',
}