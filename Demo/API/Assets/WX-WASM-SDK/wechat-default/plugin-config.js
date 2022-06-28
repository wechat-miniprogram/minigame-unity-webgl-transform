export const launchEventType = {
  launchPlugin: 0, // 插件启动
  loadWasm: 1, // 加载wasm代码包
  compileWasm: 2, // 编译wasm代码
  loadAssets: 3, // 加载首包资源
  readAssets: 5, // 读取首包资源
  prepareGame: 6, // 初始化引擎
}