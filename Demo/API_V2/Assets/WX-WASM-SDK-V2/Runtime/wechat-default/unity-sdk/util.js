import moduleHelper from './module-helper';
import { launchEventType } from '../plugin-config';
import { setArrayBuffer, uid } from './utils';
import '../events';
export default {
    WXReportGameStart() {
        GameGlobal.manager.reportCustomLaunchInfo();
    },
    WXReportGameSceneError(sceneId, errorType, errStr, extInfo) {
        if (GameGlobal.manager && GameGlobal.manager.reportGameSceneError) {
            GameGlobal.manager.reportGameSceneError(sceneId, errorType, errStr, extInfo);
        }
    },
    WXWriteLog(str) {
        if (GameGlobal.manager && GameGlobal.manager.writeLog) {
            GameGlobal.manager.writeLog(str);
        }
    },
    WXWriteWarn(str) {
        if (GameGlobal.manager && GameGlobal.manager.writeWarn) {
            GameGlobal.manager.writeWarn(str);
        }
    },
    WXHideLoadingPage() {
        if (GameGlobal.manager && GameGlobal.manager.hideLoadingPage) {
            GameGlobal.manager.hideLoadingPage();
        }
    },
    WXReportUserBehaviorBranchAnalytics(branchId, branchDim, eventType) {
        wx.reportUserBehaviorBranchAnalytics({ branchId, branchDim, eventType });
    },
    WXPreloadConcurrent(count) {
        if (GameGlobal.manager && GameGlobal.manager.setConcurrent) {
            GameGlobal.manager.setConcurrent(count);
        }
    },
    WXIsCloudTest() {
        if (typeof GameGlobal.isTest !== 'undefined' && GameGlobal.isTest) {
            return true;
        }
        return false;
    },
    WXUncaughtException(needAbort) {
        function currentStackTrace() {
            const err = new Error('WXUncaughtException');
            return err;
        }
        const err = currentStackTrace();
        let fullTrace = err.stack?.toString();
        if (fullTrace) {
            const posOfThisFunc = fullTrace.indexOf('WXUncaughtException');
            if (posOfThisFunc !== -1) {
                fullTrace = fullTrace.substr(posOfThisFunc);
            }
            const posOfRaf = fullTrace.lastIndexOf('browserIterationFunc');
            if (posOfRaf !== -1) {
                fullTrace = fullTrace.substr(0, posOfRaf);
            }
        }
        const realTimelog = wx.getRealtimeLogManager();
        realTimelog.error(fullTrace);
        const logmanager = wx.getLogManager({ level: 0 });
        logmanager.warn(fullTrace);
        if (needAbort === true) {
            GameGlobal.onCrash(err);
            throw err;
        }
        else {
            setTimeout(() => {
                throw err;
            }, 0);
        }
    },
    WXCleanAllFileCache() {
        if (GameGlobal.manager && GameGlobal.manager.cleanCache) {
            const key = uid();
            GameGlobal.manager.cleanAllCache().then((res) => {
                moduleHelper.send('CleanAllFileCacheCallback', JSON.stringify({
                    callbackId: key,
                    result: res,
                }));
            });
            return key;
        }
        return '';
    },
    WXCleanFileCache(fileSize) {
        if (GameGlobal.manager && GameGlobal.manager.cleanCache) {
            const key = uid();
            GameGlobal.manager.cleanCache(fileSize).then((res) => {
                moduleHelper.send('CleanFileCacheCallback', JSON.stringify({
                    callbackId: key,
                    result: res,
                }));
            });
            return key;
        }
        return '';
    },
    WXRemoveFile(path) {
        if (GameGlobal.manager && GameGlobal.manager.removeFile && path) {
            const key = uid();
            GameGlobal.manager.removeFile(path).then((res) => {
                moduleHelper.send('RemoveFileCallback', JSON.stringify({
                    callbackId: key,
                    result: res,
                }));
            });
            return key;
        }
        return '';
    },
    WXGetCachePath(url) {
        if (GameGlobal.manager && GameGlobal.manager.getCachePath) {
            return GameGlobal.manager.getCachePath(url);
        }
    },
    WXGetPluginCachePath() {
        if (GameGlobal.manager && GameGlobal.manager.PLUGIN_CACHE_PATH) {
            return GameGlobal.manager.PLUGIN_CACHE_PATH;
        }
    },
    WXOnLaunchProgress() {
        if (GameGlobal.manager && GameGlobal.manager.onLaunchProgress) {
            const key = uid();
            // 异步执行，保证C#已经记录这个回调ID
            setTimeout(() => {
                GameGlobal.manager.onLaunchProgress((e) => {
                    moduleHelper.send('OnLaunchProgressCallback', JSON.stringify({
                        callbackId: key,
                        res: JSON.stringify(Object.assign({}, e.data, {
                            type: e.type,
                        })),
                    }));
                    
                    if (e.type === launchEventType.prepareGame) {
                        moduleHelper.send('RemoveLaunchProgressCallback', JSON.stringify({
                            callbackId: key,
                        }));
                    }
                });
            }, 0);
            return key;
        }
        return '';
    },
    WXSetDataCDN(path) {
        if (GameGlobal.manager && GameGlobal.manager.setDataCDN) {
            GameGlobal.manager.setDataCDN(path);
        }
    },
    WXSetPreloadList(paths) {
        if (GameGlobal.manager && GameGlobal.manager.setPreloadList) {
            const list = (paths || '').split(',').filter(str => !!str && !!str.trim());
            GameGlobal.manager.setPreloadList(list);
        }
    },
    WXSetArrayBuffer(buffer, offset, callbackId) {
        setArrayBuffer(buffer, offset, callbackId);
    },
    WXLaunchOperaBridge(args) {
        const res = GameGlobal.events.emit('launchOperaMsgBridgeFromWasm', args);
        if (Array.isArray(res) && res.length > 0) {
            return res[0];
        }
        return null;
    },
    WXLaunchOperaBridgeToC(callback, args) {
        moduleHelper.send('WXLaunchOperaBridgeToC', JSON.stringify({
            callback,
            args,
        }));
    },
};
