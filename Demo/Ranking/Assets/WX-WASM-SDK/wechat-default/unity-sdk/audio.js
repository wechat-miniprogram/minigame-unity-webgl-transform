const audios = {};
import moduleHelper from "./module-helper";
const msg = 'InnerAudioContext does not exist!';
const localAudioMap = {};
const funs = {
    getFullUrl(v){
        if(!/^https?:\/\//.test(v)){
            const cdnPath = GameGlobal.manager.managerConfig.AUDIO_PREFIX;
            v = cdnPath.replace(/\/$/,'') +'/' +v.replace(/^\//,'').replace(/^Assets\//,'');
        }
        return encodeURI(v);
    }
};
export default {
    WXCreateInnerAudioContext(src, loop, startTime, autoplay, volume, playbackRate, needDownload){
        const id = new Date().getTime().toString(32)+Math.random().toString(32);
        audios[id] = wx.createInnerAudioContext();
        if(src){
            src = funs.getFullUrl(src);
            if(localAudioMap[src]){
                audios[id].src = localAudioMap[src];
            }
            else if(needDownload){
                wx.downloadFile({
                    url:src,
                    success (res) {
                        // 只要服务器有响应数据，就会把响应内容写入文件并进入 success 回调，业务需要自行判断是否下载到了想要的内容
                        if (res.statusCode === 200 && res.tempFilePath) {
                            localAudioMap[src] = res.tempFilePath;
                            audios[id].src = localAudioMap[src];
                        }else{
                            moduleHelper.send('OnAudioCallback',JSON.stringify({
                                callbackId:id,
                                errMsg:"onError"
                            }));
                        }
                    },
                    error(e){
                        moduleHelper.send('OnAudioCallback',JSON.stringify({
                            callbackId:id,
                            errMsg:"onError"
                        }));
                        console.error(e);
                    }
                });
            }else{
                audios[id].src = src;
            }
        }
        if(loop){
            audios[id].loop = true;
        }
        if(autoplay){
            audios[id].autoplay = true;
        }
        if(startTime > 0){
            audios[id].startTime = +startTime.toFixed(2);
        }
        if(volume !== 1){
            audios[id].volume = +volume.toFixed(2);
        }
        if(playbackRate !==1){
            audios[id].playbackRate = +playbackRate.toFixed(2);
        }
        return id;
    },
    WXInnerAudioContextSetBool(id,k,v){
        if(audios[id]){
            audios[id][k] = Boolean(+v);
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextSetString(id,k,v){
        if(audios[id]){
            if(k === 'src'){
                v = funs.getFullUrl(v);
                if(localAudioMap[v]){
                    v = localAudioMap[v];
                }
            }
            audios[id][k] = v;
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextSetFloat(id,k,v){
        if(audios[id]){
            audios[id][k] = +v.toFixed(2);
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextGetFloat(id,k){
        if(audios[id]){
            return audios[id][k];
        }else{
            console.error(msg,id);
            return 0;
        }
    },
    WXInnerAudioContextGetBool(id,k){
        if(audios[id]){
            return audios[id][k];
        }else{
            console.error(msg,id);
            return false;
        }
    },
    WXInnerAudioContextPlay(id){
        if(audios[id]){
            audios[id].play();
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextPause(id){
        if(audios[id]){
            audios[id].pause();
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextStop(id){
        if(audios[id]){
            audios[id].stop();
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextDestroy(id){
        if(audios[id]){
            audios[id].destroy();
            delete audios[id];
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextSeek(id,position){
        if(audios[id]){
            audios[id].seek(+position.toFixed(3));
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextAddListener(id,key){
        if(audios[id]){
            audios[id][key](function(e){
                moduleHelper.send('OnAudioCallback',JSON.stringify({
                    callbackId:id,
                    errMsg:key
                }));
                if(key === 'onError'){
                    console.error(e);
                }
            });
        }else{
            console.error(msg,id);
        }
    },
    WXInnerAudioContextRemoveListener(id,key){
        if(audios[id]){
            audios[id][key]();
        }else{
            console.error(msg,id);
        }
    },
    WXPreDownloadAudios(paths,id){
        var list = paths.split(',');
        Promise.all(list.map(v=>{
            var src = funs.getFullUrl(v);
            return new Promise((resolve,reject)=>{
                if(localAudioMap[src]){
                    resolve();
                }
                wx.downloadFile({
                    url:funs.getFullUrl(src),
                    success (res) {
                        if (res.statusCode === 200 && res.tempFilePath) {
                            localAudioMap[src] = res.tempFilePath;
                            resolve();
                        }else{
                            reject();
                        }
                    },
                    error(e){
                        reject(e);
                        console.error(e);
                    }
                });
            })
        })).then(()=>{
            moduleHelper.send('WXPreDownloadAudiosCallback',JSON.stringify({
                callbackId:id.toString(),
                errMsg:"0"
            }));
        }).catch(e=>{
            moduleHelper.send('WXPreDownloadAudiosCallback',JSON.stringify({
                callbackId:id.toString(),
                errMsg:"1"
            }));
        })

    }
}

//声音被打断后自动帮用户恢复
const HandleInterruption = {
    init(){
        var InterruptList = {};
        wx.onHide(function(){
            for(var key in audios){
                if(!audios[key].paused){
                    InterruptList[key] = true;
                }
            }
        });
        wx.onShow(function(){
            for(var key in audios){
                if(audios[key].paused && InterruptList[key]){
                    audios[key].play();
                }
            }
            InterruptList = {};
        });
        wx.onAudioInterruptionBegin(function(){
            for(var key in audios){
                if(!audios[key].paused){
                    InterruptList[key] = true;
                }
            }
        });
        wx.onAudioInterruptionEnd(function(){
            for(var key in audios){
                if(audios[key].paused && InterruptList[key]){
                    audios[key].play();
                }
            }
            InterruptList = {};
        });
    }
};

HandleInterruption.init();
