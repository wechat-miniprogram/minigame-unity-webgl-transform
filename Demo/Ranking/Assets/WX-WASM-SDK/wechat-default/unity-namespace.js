const unityNamespace = {
  canvas: GameGlobal.canvas,
  navigator: GameGlobal.navigator,
  XMLHttpRequest: GameGlobal.XMLHttpRequest,
  hideTimeLogModal: false, // 是否显示耗时的弹框，默认开发版时显示弹出耗时弹框
  enableDebugLog: false, // 是否打印详细日志
}

GameGlobal.WebAssembly = GameGlobal.WXWebAssembly
GameGlobal.unityNamespace = GameGlobal.unityNamespace || unityNamespace

export default GameGlobal.unityNamespace