
import './weapp-adapter';
import 'texture-config.js';
import unityNamespace from './unity-namespace';
import './$GAME_NAME.wasm.framework.unityweb';
import './unity-sdk/index.js';
import checkVersion from './check-version';
import { launchEventType, scaleMode } from './plugin-config';
import { preloadWxCommonFont } from './unity-sdk/font/index';
function checkUpdate() {
    const updateManager = wx.getUpdateManager();
    updateManager.onCheckForUpdate(() => {
        
        
    });
    updateManager.onUpdateReady(() => {
        wx.showModal({
            title: '更新提示',
            content: '新版本已经准备好，是否重启应用？',
            success(res) {
                if (res.confirm) {
                    
                    updateManager.applyUpdate();
                }
            },
        });
    });
    updateManager.onUpdateFailed(() => {
        
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
    DATA_FILE_SIZE: "$DATA_FILE_SIZE",
    OPT_DATA_FILE_SIZE: "$OPT_DATA_FILE_SIZE",
    DATA_CDN: '$DEPLOY_URL',
    
    loadDataPackageFromSubpackage: $LOAD_DATA_FROM_SUBPACKAGE,
    
    compressDataPackage: $COMPRESS_DATA_PACKAGE,
    
    preloadDataList: [
        
        
        '$PRELOAD_LIST',
    ],
    contextConfig: {
        contextType: $WEBGL_VERSION, 
    },
};
GameGlobal.managerConfig = managerConfig;

checkVersion().then((enable) => {
    if (enable) {
        
        let UnityManager;
        try {
            
            UnityManager = requirePlugin('UnityPlugin', {
                enableRequireHostModule: true,
                customEnv: {
                    wx,
                    unityNamespace,
                    document,
                    canvas,
                },
            }).default;
        }
        catch (error) {
            if (error.message.indexOf('not defined') !== -1) {
                console.error('！！！插件需要申请才可使用\n请勿使用测试AppID，并登录 https://mp.weixin.qq.com/ 并前往：能力地图-开发提效包-快适配 开通\n阅读文档获取详情:https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/Transform.md');
            }
        }
        
        Error.stackTraceLimit = Infinity;
        Object.assign(managerConfig, {
            
            hideAfterCallmain: $HIDE_AFTER_CALLMAIN,
            loadingPageConfig: {
                
                totalLaunchTime: 15000,
                                designWidth: 0,
                designHeight: 0,
                scaleMode: scaleMode.default,
                
                textConfig: {
                    firstStartText: '首次加载请耐心等待',
                    downloadingText: ['正在加载资源'],
                    compilingText: '编译中',
                    initText: '初始化中',
                    completeText: '开始游戏',
                    textDuration: 1500,
                    
                    style: {
                        bottom: 64,
                        height: 24,
                        width: 240,
                        lineHeight: 24,
                        color: '#ffffff',
                        fontSize: 12,
                    },
                },
                
                barConfig: {
                    style: {
                        width: 240,
                        height: 24,
                        padding: 2,
                        bottom: 64,
                        backgroundColor: '#07C160',
                    },
                },
                
                iconConfig: {
                    visible: true,
                    style: {
                        width: 64,
                        height: 23,
                        bottom: 20,
                    },
                },
                
                materialConfig: {
                    
                    backgroundImage: '$BACKGROUND_IMAGE',
                    backgroundVideo: '$LOADING_VIDEO_URL',
                    iconImage: 'images/unity_logo.png', 
                },
            },
        });
        GameGlobal.managerConfig = managerConfig;
        const gameManager = new UnityManager(managerConfig);
        gameManager.onLaunchProgress((e) => {
            
            
            
            
            
            
            
            
            
            
            
            
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
            
            for (const key in unityNamespace) {
                
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
        
        const systeminfo = wx.getSystemInfoSync();
        const bootinfo = {
            renderer: systeminfo.renderer || '',
            abi: systeminfo.abi || '',
            brand: systeminfo.brand,
            model: systeminfo.model,
            platform: systeminfo.platform,
            system: systeminfo.system,
            version: systeminfo.version,
            SDKVersion: systeminfo.SDKVersion,
            benchmarkLevel: systeminfo.benchmarkLevel,
        };
        wx.getRealtimeLogManager().info('game starting', bootinfo);
        wx.getLogManager({ level: 0 }).info('game starting', bootinfo);
        console.info('game starting', bootinfo);
        
        wx.onError((result) => {
            gameManager.printErr(result.message);
        });
        gameManager.onLogError = function (err) {
            GameGlobal.realtimeLogManager.error(err);
            GameGlobal.logmanager.warn(err);
        };
        
        if (GameGlobal.canUseiOSAutoGC && unityNamespace.iOSAutoGCInterval !== 0) {
            setInterval(function () { wx.triggerGC(); }, unityNamespace.iOSAutoGCInterval);
        }
        gameManager.startGame();
        GameGlobal.manager = gameManager;
    }
});
