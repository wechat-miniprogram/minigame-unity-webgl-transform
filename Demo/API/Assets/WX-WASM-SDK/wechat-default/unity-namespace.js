const unityNamespace = {
  canvas: GameGlobal.canvas,
  navigator: GameGlobal.navigator,
  XMLHttpRequest: GameGlobal.XMLHttpRequest,
  hideTimeLogModal: true, // 是否显示耗时的弹框，默认开发版时显示弹出耗时弹框
  enableDebugLog: false, // 是否打印详细日志
  bundleHashLength: $BUNDLE_HASH_LENGTH, // 自定义bundle中的hash长度
  releaseMemorySize: $DEFAULT_RELEASE_SIZE, // 单位Bytes, 1MB = 1024 KB = 1024*1024Bytes
  unityVersion: "$UNITY_VERSION",
  convertPluginVersion: "$PLUGIN_VERSION",
  streamingUrlPrefixPath: '', // 拼在StreamingAssets前面的path，DATA_CDN + streamingUrlPrefixPath + StreamingAssets
  dataFileSubPrefix: '$DATA_FILE_SUB_PREFIX', // DATA_CDN + dataFileSubPrefix + datafilename
  maxStorage: $MAX_STORAGE_SIZE, // 当前appid扩容后，通过本字段告知插件本地存储最大容量，单位MB
  texturesHashLength: $TEXTURE_HASH_LENGTH, // 纹理中的hash长度
  texturesPath: '$TEXTURES_PATH', // 纹理存放路径
  needCacheTextures: $NEED_CACHE_TEXTURES, // 是否需要缓存纹理
}

// 判断是否需要自动缓存的文件，返回true自动缓存；false不自动缓存
unityNamespace.isCacheableFile = function(path) {
  const cacheableFileIdentifier = [$BUNDLE_PATH_IDENTIFIER]; // 判定为下载bundle的路径标识符，此路径下的下载，会自动缓存
  const excludeFileIdentifier = [$EXCLUDE_FILE_EXTENSIONS]; // 命中路径标识符的情况下，并不是所有文件都有必要缓存，过滤下不需要缓存的文件
  if (cacheableFileIdentifier.some(identifier => path.includes(identifier) && excludeFileIdentifier.every(excludeIdentifier => !path.includes(excludeIdentifier)))) {
    return true;
  }
  return false;
}

// 清理缓存时是否可被自动清理；返回true可自动清理；返回false不可自动清理
unityNamespace.isErasableFile = function(info) {
  const inErasableIdentifier = []; // 达到缓存上限时，不会被自动清理的文件
  if (inErasableIdentifier.some(identifier => info.path.includes(identifier))) {
    return false;
  }
  return true;
}

GameGlobal.WebAssembly = GameGlobal.WXWebAssembly
GameGlobal.unityNamespace = GameGlobal.unityNamespace || unityNamespace
GameGlobal.realtimeLogManager = wx.getRealtimeLogManager()
GameGlobal.logmanager = wx.getLogManager()
GameGlobal.onCrash = function(error){
  GameGlobal.manager.showAbort();
  const sysInfo = wx.getSystemInfoSync()
  let button = wx.createFeedbackButton({
    type: 'text',
    text: '提交反馈',
    style: {
      left: (sysInfo.screenWidth - 184) / 2,
      top: sysInfo.screenHeight / 3 + 140,
      width: 184,
      height: 40,
      lineHeight: 40,
      backgroundColor: '#07C160',
      color: '#ffffff',
      textAlign: 'center',
      fontSize: 16,
      borderRadius: 4
    }
  })
}
export default GameGlobal.unityNamespace
