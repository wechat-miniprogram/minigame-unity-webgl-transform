// @ts-nocheck
/* eslint-disable no-prototype-builtins */
/* eslint-disable no-unused-vars */
/* eslint-disable no-undef */
import './weapp-adapter';
import './events';
import 'texture-config.js';
import unityNamespace from './unity-namespace';
import '.$DOTNET_RUNTIME_FOLD/$GAME_NAME.wasm.framework.unityweb';
import './unity-sdk/index.js';
import checkVersion from './check-version';
import { launchEventType, scaleMode } from './plugin-config';
import { preloadWxCommonFont } from './unity-sdk/font/index';
function checkUpdate() {
    const updateManager = wx.getUpdateManager();
    updateManager.onCheckForUpdate(() => {
        // 请求完新版本信息的回调
        // console.log(res.hasUpdate)
    });
    updateManager.onUpdateReady(() => {
        wx.showModal({
            title: '更新提示',
            content: '新版本已经准备好，是否重启应用？',
            success(res) {
                if (res.confirm) {
                    // 新的版本已经下载好，调用 applyUpdate 应用新版本并重启
                    updateManager.applyUpdate();
                }
            },
        });
    });
    updateManager.onUpdateFailed(() => {
        // 新版本下载失败
    });
}
if ($NEED_CHECK_UPDATE) {
    checkUpdate();
}
const managerConfig = {
    DATA_FILE_MD5: '$DATA_MD5',
    CODE_FILE_MD5: '$CODE_MD5',
    GAME_NAME: '$GAME_NAME',
    APPID: '$APP_ID',
    DATA_FILE_SIZE: '$DATA_FILE_SIZE',
    OPT_DATA_FILE_SIZE: '$OPT_DATA_FILE_SIZE',
    DATA_CDN: '$DEPLOY_URL',
    // 资源包是否作为小游戏分包加载
    loadDataPackageFromSubpackage: $LOAD_DATA_FROM_SUBPACKAGE,
    // 资源包放小游戏分包加载时，是否br压缩
    compressDataPackage: $COMPRESS_DATA_PACKAGE,
    // 需要在网络空闲时预加载的资源，支持如下形式的路径
    preloadDataList: [
        // 'DATA_CDN/StreamingAssets/WebGL/textures_8d265a9dfd6cb7669cdb8b726f0afb1e',
        // '/WebGL/sounds_97cd953f8494c3375312e75a29c34fc2'
        '$PRELOAD_LIST',
    ],
    contextConfig: {
        contextType: $WEBGL_VERSION, // 1=>webgl1  2=>webgl2 3=>auto
    },
};
GameGlobal.managerConfig = managerConfig;
// 版本检查
checkVersion().then((enable) => {
    if (enable) {
        // eslint-disable-next-line @typescript-eslint/naming-convention
        let UnityManager;
        try {
            // @ts-ignore
            UnityManager = requirePlugin('UnityPlugin', {
                enableRequireHostModule: true,
                customEnv: {
                    wx,
                    unityNamespace,
                    document,
                    canvas,
                    events: GameGlobal.events,
                    WXWASMSDK: GameGlobal.WXWASMSDK,
                },
            }).default;
        }
        catch (error) {
            GameGlobal.realtimeLogManager.error(error);
            // logManager不支持自动处理错误对象
            GameGlobal.logmanager.warn(error.stack);
            console.error('requirePlugin:', error);
            if (error.message.indexOf('not defined') !== -1) {
                console.error('！！！插件需要申请才可使用\n请勿使用测试AppID，并登录 https://mp.weixin.qq.com/ 并前往：能力地图-开发提效包-快适配 开通\n阅读文档获取详情:https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/Transform.md');
            }
        }
        // JS堆栈能显示更完整
        Error.stackTraceLimit = Infinity;
        Object.assign(managerConfig, {
            // callmain结束后立即隐藏封面视频
            hideAfterCallmain: $HIDE_AFTER_CALLMAIN,
            loadingPageConfig: {
                // 以下是默认值
                totalLaunchTime: 7000,
                animationDuration: 100,
                /**
                 * !!注意：修改设计宽高和缩放模式后，需要修改文字和进度条样式。默认设计尺寸为667*375
                 */
                designWidth: 0,
                designHeight: 0,
                scaleMode: scaleMode.default,
                // 以下配置的样式，尺寸相对设计宽高
                textConfig: {
                    firstStartText: '首次加载请耐心等待',
                    downloadingText: ['正在加载资源'],
                    compilingText: '编译中',
                    initText: '初始化中',
                    completeText: '开始游戏',
                    textDuration: 1500,
                    // 文字样式
                    style: {
                        bottom: 64,
                        height: 24,
                        width: 240,
                        lineHeight: 24,
                        color: '#ffffff',
                        fontSize: 12,
                    },
                },
                // 进度条样式
                barConfig: {
                    style: {
                        width: 240,
                        height: 24,
                        padding: 2,
                        bottom: 64,
                        backgroundColor: '#07C160',
                    },
                },
                // 一般不修改，控制icon样式
                iconConfig: {
                    visible: true,
                    style: {
                        width: 64,
                        height: 23,
                        bottom: 20,
                    },
                },
                // 加载页的素材配置
                materialConfig: {
                    // 背景图或背景视频，两者都填时，先展示背景图，视频可播放后，播放视频
                    backgroundImage: '$BACKGROUND_IMAGE',
                    backgroundVideo: '$LOADING_VIDEO_URL',
                    iconImage: 'images/unity_logo.png', // icon图片，一般不更换
                },
            },
        });
        GameGlobal.managerConfig = managerConfig;
        // 显示启动封面
        const gameManager = new UnityManager(managerConfig);
        gameManager.onLaunchProgress((e) => {
            // interface LaunchEvent {
            //   type: LaunchEventType;
            //   data: {
            //     costTimeMs: number; // 阶段耗时
            //     runTimeMs: number; // 总耗时
            //     loadDataPackageFromSubpackage: boolean; // 首包资源是否通过小游戏分包加载
            //     isVisible: boolean; // 当前是否处于前台，onShow/onHide
            //     useCodeSplit: boolean; // 是否使用代码分包
            //     isHighPerformance: boolean; // 是否iOS高性能模式
            //     needDownloadDataPackage: boolean; // 本次启动是否需要下载资源包
            //   };
            // }
            if (e.type === launchEventType.launchPlugin) {
            }
            if (e.type === launchEventType.loadWasm) {
            }
            if (e.type === launchEventType.compileWasm) {
            }
            if (e.type === launchEventType.loadAssets) {
            }
            if (e.type === launchEventType.readAssets) {
            }
            if (e.type === launchEventType.prepareGame) {
            }
        });
        gameManager.onModulePrepared(() => {
            // eslint-disable-next-line no-restricted-syntax
            for (const key in unityNamespace) {
                // 动态修改DATA_CDN后，同步修改全局对象
                if (!GameGlobal.hasOwnProperty(key) || key === 'DATA_CDN') {
                    GameGlobal[key] = unityNamespace[key];
                }
                else {
                }
            }
            managerConfig.DATA_CDN = GameGlobal.DATA_CDN;
            gameManager.assetPath = `${(managerConfig.DATA_CDN || '').replace(/\/$/, '')}/Assets`;
            preloadWxCommonFont();
        });
        // 插件捕获到引擎错误后，会通过此事件抛给游戏
        gameManager.onLogError = function (err) {
            GameGlobal.realtimeLogManager.error(err);
            const isErrorObj = err && err.stack;
            GameGlobal.logmanager.warn(isErrorObj ? err.stack : err);
        };
        // iOS高性能模式定期GC
        if (GameGlobal.canUseiOSAutoGC && unityNamespace.iOSAutoGCInterval !== 0) {
            setInterval(() => {
                wx.triggerGC();
            }, unityNamespace.iOSAutoGCInterval);
        }
        // 开始执行游戏启动流程
        gameManager.startGame();
        GameGlobal.manager = gameManager;
        GameGlobal.events.on('launchOperaPushMsgToWasm', (callback, args) => GameGlobal.WXWASMSDK.WXLaunchOperaBridgeToC(callback, args));
        // eslint-disable-next-line @typescript-eslint/no-unused-vars
        GameGlobal.events.on('createWorker', (worker) => {
            // worker created
        });
    }
});
