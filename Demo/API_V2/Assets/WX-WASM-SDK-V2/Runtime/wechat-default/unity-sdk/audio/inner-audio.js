import moduleHelper from '../module-helper';
import { isSupportPlayBackRate } from '../../check-version';
import { audios, localAudioMap, downloadingAudioMap, innerAudioVolume, WEBAudio } from './store';
import { createInnerAudio, destroyInnerAudio, printErrMsg } from './utils';
import { IGNORE_ERROR_MSG, INNER_AUDIO_UNDEFINED_MSG } from './const';
const funs = {
    
    getFullUrl(v) {
        if (!/^https?:\/\//.test(v) && !/^wxfile:\/\//.test(v)) {
            const cdnPath = GameGlobal.manager.assetPath;
            v = `${cdnPath.replace(/\/$/, '')}/${v.replace(/^\//, '').replace(/^Assets\//, '')}`;
        }
        return v;
    },
    
    downloadAudios(paths) {
        const list = paths.split(',');
        return Promise.all(list.map((v) => {
            const src = funs.getFullUrl(v);
            return new Promise((resolve, reject) => {
                
                if (!downloadingAudioMap[src]) {
                    downloadingAudioMap[src] = [
                        {
                            resolve,
                            reject,
                        },
                    ];
                    if (funs.checkLocalFile(src)) {
                        funs.handleDownloadEnd(src, true);
                    }
                    else if (!GameGlobal.unityNamespace.isCacheableFile(src)) {
                        
                        wx.downloadFile({
                            url: src,
                            success(res) {
                                if (res.statusCode === 200 && res.tempFilePath) {
                                    localAudioMap[src] = res.tempFilePath;
                                    funs.handleDownloadEnd(src, true);
                                }
                                else {
                                    funs.handleDownloadEnd(src, false);
                                }
                            },
                            fail(e) {
                                funs.handleDownloadEnd(src, false);
                                printErrMsg(e);
                            },
                        });
                    }
                    else {
                        const xmlhttp = new GameGlobal.unityNamespace.UnityLoader.UnityCache.XMLHttpRequest();
                        xmlhttp.open('GET', src, true);
                        xmlhttp.responseType = 'arraybuffer';
                        xmlhttp.onsave = () => {
                            localAudioMap[src] = GameGlobal.manager.getCachePath(src);
                            funs.handleDownloadEnd(src, true);
                        };
                        xmlhttp.onsavefail = () => {
                            funs.handleDownloadEnd(src, false);
                        };
                        xmlhttp.onerror = () => {
                            funs.handleDownloadEnd(src, false);
                        };
                        xmlhttp.send();
                    }
                }
                else {
                    downloadingAudioMap[src].push({
                        resolve,
                        reject,
                    });
                }
            });
        }));
    },
    
    handleDownloadEnd(src, succeeded) {
        if (!downloadingAudioMap[src]) {
            return;
        }
        while (downloadingAudioMap[src] && downloadingAudioMap[src].length > 0) {
            const item = downloadingAudioMap[src].shift();
            if (!succeeded) {
                item?.reject();
            }
            else {
                item?.resolve('');
            }
        }
        delete downloadingAudioMap[src];
    },
    // 是否存在本地文件
    checkLocalFile(src) {
        if (localAudioMap[src]) {
            return true;
        }
        const path = GameGlobal.manager.getCachePath(src);
        if (path) {
            localAudioMap[src] = path;
            return true;
        }
        return false;
    },
    // 设置路径
    setAudioSrc(audio, getSrc) {
        return new Promise((resolve, reject) => {
            const src = funs.getFullUrl(getSrc);
            // 设置原始路径，后面用此路径作为key值
            audio.isLoading = src;
            if (funs.checkLocalFile(src)) {
                audio.src = localAudioMap[src];
                delete audio.isLoading;
                funs.handleDownloadEnd(src, true);
                resolve(localAudioMap[src]);
            }
            else if (audio.needDownload) {
                funs
                    .downloadAudios(src)
                    .then(() => {
                    if (audio) {
                        audio.src = localAudioMap[src];
                        delete audio.isLoading;
                        resolve(localAudioMap[src]);
                    }
                    else {
                        console.warn('资源已被删除:', src);
                        reject({
                            errCode: -1,
                            errMsg: '资源已被删除',
                        });
                    }
                })
                    .catch(() => {
                    console.warn('资源下载失败:', src);
                    if (audio) {
                        audio.src = src;
                        delete audio.isLoading;
                    }
                    reject({
                        errCode: -1,
                        errMsg: '资源下载失败',
                    });
                });
            }
            else {
                // 不推荐这样处理，建议优先下载再使用，除非是需要立即播放的长音频文件或一次性播放音频
                // console.warn('建议优先下载再使用:', src);
                audio.src = src;
                delete audio.isLoading;
                resolve(src);
            }
        });
    },
};
function checkHasAudio(id) {
    if (audios[id]) {
        return true;
    }
    console.error(INNER_AUDIO_UNDEFINED_MSG, id);
    return false;
}
export default {
    // 创建audio对象
    WXCreateInnerAudioContext(src, loop, startTime, autoplay, volume, playbackRate, needDownload) {
        const { audio: getAudio, id } = createInnerAudio();
        getAudio.needDownload = needDownload;
        if (src) {
            // 设置原始src
            funs.setAudioSrc(getAudio, src).catch((e) => {
                moduleHelper.send('OnAudioCallback', JSON.stringify({
                    callbackId: id,
                    errMsg: 'onError',
                    result: JSON.stringify(e),
                }));
            });
        }
        if (loop) {
            getAudio.loop = true;
        }
        if (autoplay) {
            getAudio.autoplay = true;
        }
        if (typeof startTime === 'undefined') {
            startTime = 0;
        }
        if (startTime > 0) {
            getAudio.startTime = +startTime.toFixed(2);
        }
        
        let volumeValue;
        if (typeof volume === 'undefined') {
            volumeValue = 1;
        }
        else {
            volumeValue = +volume.toFixed(2);
        }
        innerAudioVolume.set(getAudio, volumeValue);
        if (WEBAudio.isMute) {
            volumeValue = 0;
        }
        if (volumeValue !== 1) {
            getAudio.volume = volumeValue;
        }
        
        if (!isSupportPlayBackRate) {
            playbackRate = 1;
        }
        if (typeof playbackRate !== 'undefined' && playbackRate !== 1) {
            getAudio.playbackRate = +playbackRate.toFixed(2);
        }
        return id;
    },
    
    WXInnerAudioContextSetBool(id, k, v) {
        if (!checkHasAudio(id)) {
            return;
        }
        audios[id][k] = Boolean(+v);
    },
    
    WXInnerAudioContextSetString(id, k, v) {
        if (!checkHasAudio(id)) {
            return;
        }
        
        if (k === 'src') {
            funs.setAudioSrc(audios[id], v);
        }
        else if (k === 'needDownload') {
            audios[id].needDownload = !!v;
        }
        else {
            audios[id][k] = v;
        }
    },
    
    WXInnerAudioContextSetFloat(id, k, v) {
        if (!checkHasAudio(id)) {
            return;
        }
        let value = +v.toFixed(2);
        if (k === 'volume') {
            innerAudioVolume.set(audios[id], value);
            if (WEBAudio.isMute) {
                value = 0;
            }
        }
        audios[id][k] = value;
    },
    
    WXInnerAudioContextGetFloat(id, k) {
        if (!checkHasAudio(id)) {
            return 0;
        }
        return audios[id][k];
    },
    
    WXInnerAudioContextGetBool(id, k) {
        if (!checkHasAudio(id)) {
            return false;
        }
        return audios[id][k];
    },
    WXInnerAudioContextPlay(id) {
        if (!checkHasAudio(id)) {
            return;
        }
        
        const url = audios[id].isLoading;
        if (url) {
            if (downloadingAudioMap[url]) {
                downloadingAudioMap[url].push({
                    resolve: () => {
                        if (typeof audios[id] !== 'undefined') {
                            audios[id].play();
                        }
                    },
                    reject: () => { },
                });
            }
            else {
                audios[id].src = url;
                audios[id].play();
            }
        }
        else {
            audios[id].play();
        }
    },
    WXInnerAudioContextPause(id) {
        if (!checkHasAudio(id)) {
            return;
        }
        audios[id].pause();
    },
    WXInnerAudioContextStop(id) {
        if (!checkHasAudio(id)) {
            return;
        }
        audios[id].stop();
    },
    WXInnerAudioContextDestroy(id) {
        if (!checkHasAudio(id)) {
            return;
        }
        destroyInnerAudio(id, false);
    },
    WXInnerAudioContextSeek(id, position) {
        if (!checkHasAudio(id)) {
            return;
        }
        audios[id].seek(+position.toFixed(3));
    },
    
    WXInnerAudioContextAddListener(id, key) {
        if (!checkHasAudio(id)) {
            return;
        }
        if (key === 'onCanplay') {
            audios[id][key](() => {
                
                
                
                const { duration, buffered, referrerPolicy, volume } = audios[id];
                setTimeout(() => {
                    moduleHelper.send('OnAudioCallback', JSON.stringify({
                        callbackId: id,
                        errMsg: key,
                    }));
                }, 0);
            });
        }
        else if (key === 'onError') {
            audios[id][key]((e) => {
                if (key === 'onError') {
                    console.error(e);
                    
                    if (e.errMsg && e.errMsg.indexOf(IGNORE_ERROR_MSG) > -1) {
                        return;
                    }
                }
                moduleHelper.send('OnAudioCallback', JSON.stringify({
                    callbackId: id,
                    errMsg: key,
                    result: JSON.stringify(e),
                }));
            });
        }
        else {
            audios[id][key](() => {
                moduleHelper.send('OnAudioCallback', JSON.stringify({
                    callbackId: id,
                    errMsg: key,
                }));
            });
        }
    },
    WXInnerAudioContextRemoveListener(id, key) {
        if (!checkHasAudio(id)) {
            return;
        }
        audios[id][key]();
    },
    WXPreDownloadAudios(paths, id) {
        funs
            .downloadAudios(paths)
            .then(() => {
            moduleHelper.send('WXPreDownloadAudiosCallback', JSON.stringify({
                callbackId: id.toString(),
                errMsg: '0',
            }));
        })
            .catch(() => {
            moduleHelper.send('WXPreDownloadAudiosCallback', JSON.stringify({
                callbackId: id.toString(),
                errMsg: '1',
            }));
        });
    },
};
