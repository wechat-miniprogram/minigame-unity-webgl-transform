const unityNamespace = {
  canvas: GameGlobal.canvas,
  navigator: GameGlobal.navigator,
  XMLHttpRequest: GameGlobal.XMLHttpRequest,
  hideTimeLogModal: false, // 是否显示耗时的弹框，默认开发版时显示弹出耗时弹框
  enableDebugLog: false, // 是否打印详细日志
  bundleHashLength: $BUNDLE_HASH_LENGTH, // 自定义bundle中的hash长度
  bundlePathIdentifier: [$BUNDLE_PATH_IDENTIFIER], // 判定为下载bundle的路径标识符，此路径下的下载，会自动缓存
  excludeFileExtensions: [$EXCLUDE_FILE_EXTENSIONS], // 命中路径标识符的情况下，并不是所有文件都有必要缓存，过滤下不需要缓存的文件拓展名
  releaseMemorySize: 31457280, // 单位Bytes, 1MB = 1024 KB = 1024*1024Bytes
  unityVersion: "$UNITY_VERSION",
  convertPluginVersion: "$PLUGIN_VERSION",
}

GameGlobal.WebAssembly = GameGlobal.WXWebAssembly
GameGlobal.unityNamespace = GameGlobal.unityNamespace || unityNamespace
GameGlobal.realtimeLogManager = wx.getRealtimeLogManager()
GameGlobal.logmanager = wx.getLogManager()
GameGlobal.onCrash = function(error){
  let button = wx.createFeedbackButton({
    type: 'text',
    text: '程序遇到错误，请您提交反馈信息',
    style: {
      left: 10,
      top: 300,
      width: 300,
      height: 40,
      lineHeight: 40,
      backgroundColor: '#ff0000',
      color: '#ffffff',
      textAlign: 'center',
      fontSize: 16,
      borderRadius: 4
    }
  })  
}
export default GameGlobal.unityNamespace
