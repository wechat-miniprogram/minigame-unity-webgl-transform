import './weapp-adapter'
import unityNamespace from './unity-namespace'
import './webgl.wasm.framework.unityweb'
import "./unity-sdk/index.js"
import checkVersion, {canUseCoverview} from './check-version'

import TextureConfig from './texture-config';

// 版本检查
checkVersion().then(enable => {
  if (enable) {
    const UnityManager = requirePlugin('UnityPlugin', {
      enableRequireHostModule: true,
      customEnv: {
        wx,
        unityNamespace,
        document,
        canvas
      }
    }).default
    
    let managerConfig = {
      DATA_FILE_MD5: "188cdbd54f8b7ae5",
      CODE_FILE_MD5: "619b20a9e252371c",
      GAME_NAME: "webgl",
      APPID: "wxe5a48f1ed5f544b7",
      DATA_FILE_SIZE: "6314109",
      LOADING_VIDEO_URL: "",
      DATA_CDN: "",
      AUDIO_PREFIX: "",
      STREAMING_CDN: "",
      // 资源包是否作为小游戏分包加载
      loadDataPackageFromSubpackage: true,
    
      // 需要在网络空闲时预加载的资源，支持如下形式的路径
      preloadDataList: [
        // 'STREAMING_CDN/StreamingAssets/WebGL/textures_8d265a9dfd6cb7669cdb8b726f0afb1e',
        // '/WebGL/sounds_97cd953f8494c3375312e75a29c34fc2'
        
      ],
    };
    
    // JS堆栈能显示更完整
    Error.stackTraceLimit = Infinity;
    // 是否使用coverview作为启动页
    let USE_COVER_VIEW
    if (canUseCoverview()) {
      USE_COVER_VIEW = true
    } else {
      USE_COVER_VIEW = false
    }
    if (USE_COVER_VIEW) {
      managerConfig = {
        ...managerConfig,
        useCoverView: true,
	      // callmain结束后立即隐藏封面视频
	      hideAfterCallmain: true, 
        loadingPageConfig: {
          // 背景图或背景视频，两者都填时，先展示背景图，视频可播放后，播放视频
          backgroundImage: 'images/background.jpg', // 不使用默认背景图可将此图片删除
          backgroundVideo: '',
          // 以下是默认值
          totalLaunchTime: 15000, // 默认总启动耗时，即加载动画默认播放时间，可根据游戏实际情况进行调整
          textDuration: 1500, // 当downloadingText有多个文案时，每个文案展示时间
          firstStartText: '首次加载请耐心等待', // 首次启动时提示文案
          downloadingText: ['正在加载资源'], // 加载阶段循环展示的文案
          compilingText: '编译中', // 编译阶段文案
          initText: '初始化中', // 初始化阶段文案
          completeText: '开始游戏', // 初始化完成
        }
      }
    }
    
    const gameManager = new UnityManager(managerConfig);
    
    gameManager.managerConfig = managerConfig;
    
    gameManager.onModulePrepared(() => {
      for(let key in unityNamespace) {
        if (!GameGlobal.hasOwnProperty(key)) {
          GameGlobal[key] = unityNamespace[key]
        } else {
        }
      }
    })
    gameManager.startGame();
    
    GameGlobal.manager = gameManager;
  }
})