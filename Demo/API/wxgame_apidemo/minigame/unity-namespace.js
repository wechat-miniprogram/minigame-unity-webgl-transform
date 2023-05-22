/* eslint-disable no-unused-vars */
/* eslint-disable no-undef */
const unityNamespace = {
  canvas: GameGlobal.canvas,
  navigator: GameGlobal.navigator,
  XMLHttpRequest: GameGlobal.XMLHttpRequest,
  hideTimeLogModal: true,
  enableDebugLog: false,
  bundleHashLength: 32,
  releaseMemorySize: 31457280,
  unityVersion: '2021.2.18f1c1',
  uintyColorSpace: 'Gamma',
  convertPluginVersion: '202305222027',
  streamingUrlPrefixPath: '',
  dataFileSubPrefix: '',
  maxStorage: 200,
  texturesHashLength: 8,
  texturesPath: 'Assets/Textures',
  needCacheTextures: true,
  ttlAssetBundle: 5,
  enableProfileStats: false,
  preloadwXFont: true, // 是否预载微信系统字体
};
// 判断是否需要自动缓存的文件，返回true自动缓存；false不自动缓存
unityNamespace.isCacheableFile = function (path) {
  const cacheableFileIdentifier = ["StreamingAssets"]; // 判定为下载bundle的路径标识符，此路径下的下载，会自动缓存
  const excludeFileIdentifier = ["json"]; // 命中路径标识符的情况下，并不是所有文件都有必要缓存，过滤下不需要缓存的文件
  if (cacheableFileIdentifier.some(identifier => path.includes(identifier)
        && excludeFileIdentifier.every(excludeIdentifier => !path.includes(excludeIdentifier)))) {
    return true;
  }
  return false;
};
// 判断是否是AssetBundle
unityNamespace.isWXAssetBundle = function (path) {
  return unityNamespace.WXAssetBundles.has(unityNamespace.PathInFileOS(path));
};
unityNamespace.PathInFileOS = function (path) {
  return path.replace(`${wx.env.USER_DATA_PATH}/__GAME_FILE_CACHE`, '');
};
unityNamespace.WXAssetBundles = new Map();
// 清理缓存时是否可被自动清理；返回true可自动清理；返回false不可自动清理
unityNamespace.isErasableFile = function (info) {
  // 用于特定AssetBundle的缓存保持
  if (unityNamespace.WXAssetBundles.has(info.path)) {
    return false;
  }
  const inErasableIdentifier = []; // 达到缓存上限时，不会被自动清理的文件
  if (inErasableIdentifier.some(identifier => info.path.includes(identifier))) {
    return false;
  }
  return true;
};
const { version, SDKVersion, platform, renderer, system } = wx.getSystemInfoSync();
unityNamespace.version = version;
unityNamespace.SDKVersion = SDKVersion;
unityNamespace.platform = platform;
unityNamespace.renderer = renderer;
unityNamespace.system = system;
unityNamespace.isPc = platform === 'windows' || platform === 'mac';
unityNamespace.isDevtools = platform === 'devtools';
unityNamespace.isMobile = !unityNamespace.isPc && !unityNamespace.isDevtools;
unityNamespace.isH5Renderer = unityNamespace.isMobile && unityNamespace.renderer === 'h5';
unityNamespace.isIOS = platform === 'ios';
unityNamespace.isAndroid = platform === 'android';
GameGlobal.WebAssembly = GameGlobal.WXWebAssembly;
GameGlobal.unityNamespace = GameGlobal.unityNamespace || unityNamespace;
GameGlobal.realtimeLogManager = wx.getRealtimeLogManager();
GameGlobal.logmanager = wx.getLogManager({ level: 0 });
GameGlobal.onCrash = function () {
  GameGlobal.manager.showAbort();
  const sysInfo = wx.getSystemInfoSync();
  wx.createFeedbackButton({
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
      borderRadius: 4,
    },
  });
};
export default GameGlobal.unityNamespace;
