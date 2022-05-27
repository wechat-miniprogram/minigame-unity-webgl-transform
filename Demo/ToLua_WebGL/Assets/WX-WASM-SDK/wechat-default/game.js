import './weapp-adapter'
import unityNamespace from './unity-namespace'
import './$GAME_NAME.wasm.framework.unityweb'
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
      DATA_FILE_MD5: "$DATA_MD5",
      CODE_FILE_MD5: "$CODE_MD5",
      GAME_NAME: "$GAME_NAME",
      APPID: "$APP_ID",
      DATA_FILE_SIZE: "$DATA_FILE_SIZE",
      LOADING_VIDEO_URL: "$LOADING_VIDEO_URL",
      DATA_CDN: "$DEPLOY_URL",
      // 资源包是否作为小游戏分包加载
      loadDataPackageFromSubpackage: $LOAD_DATA_FROM_SUBPACKAGE,

      // 需要在网络空闲时预加载的资源，支持如下形式的路径
      preloadDataList: [
        // 'DATA_CDN/StreamingAssets/WebGL/textures_8d265a9dfd6cb7669cdb8b726f0afb1e',
        // '/WebGL/sounds_97cd953f8494c3375312e75a29c34fc2'
        "$PRELOAD_LIST"
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
	      hideAfterCallmain: $HIDE_AFTER_CALLMAIN,
        loadingPageConfig: {
          // 背景图或背景视频，两者都填时，先展示背景图，视频可播放后，播放视频
          backgroundImage: '$BACKGROUND_IMAGE', // 不使用默认背景图可将此图片删除
          backgroundVideo: '$LOADING_VIDEO_URL',
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

    managerConfig.contextConfig = {
     contextType: $WEBGL_VERSION  // 1=>webgl1  2=>webgl2 3=>auto
    }

    const gameManager = new UnityManager(managerConfig);

    gameManager.assetPath = (managerConfig.DATA_CDN|| '').replace(/\/$/,'') + '/Assets';
    gameManager.managerConfig = managerConfig;

    gameManager.onModulePrepared(() => {
      for(let key in unityNamespace) {
        if (!GameGlobal.hasOwnProperty(key)) {
          GameGlobal[key] = unityNamespace[key]
        } else {
        }
      }
    })


    // 上报初始化信息
    const systeminfo = wx.getSystemInfoSync();
    let bootinfo = {
      'brand': systeminfo.brand,
      'model':systeminfo.model,
      'platform':systeminfo.platform,
      'system':systeminfo.system,
      'version':systeminfo.version,
      'SDKVersion':systeminfo.SDKVersion,
      'benchmarkLevel':systeminfo.benchmarkLevel,
      'renderer':systeminfo.renderer || ''
    };
    wx.getRealtimeLogManager().info('game starting', managerConfig.DATA_FILE_SIZE, bootinfo);
    wx.getLogManager().info('game starting', managerConfig.DATA_FILE_SIZE, bootinfo);
    console.info('game starting', managerConfig.DATA_FILE_SIZE, bootinfo);

     // 默认上报小游戏实时日志与用户反馈日志(所有error日志+小程序框架异常)
    wx.onError((result) => {gameManager.printErr(result.message)});
    gameManager.onLogError = function(err){
      GameGlobal.realtimeLogManager.error(err)
      GameGlobal.logmanager.warn(err)
    }
    gameManager.startGame();

    GameGlobal.manager = gameManager;
  }
})
