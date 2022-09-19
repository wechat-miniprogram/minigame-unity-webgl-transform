const cacheAudios = {};
const funs = {
    getFullUrl(v){
        if(!/^https?:\/\//.test(v)){
            const cdnPath = GameGlobal.manager.assetPath;
            v = cdnPath.replace(/\/$/,'') +'/' +v.replace(/^\//,'').replace(/^Assets\//,'');
        }
        return encodeURI(v);
    }
};
export default {
    WXPreLoadShortAudio(str) {
        str.split(',').forEach(v=>{
            if(!cacheAudios[v]){
                const innerAudioContext = wx.createInnerAudioContext();
                innerAudioContext.src= funs.getFullUrl(v);
                cacheAudios[v] = {
                    context:innerAudioContext
                }
            }
        })
    },
    WXStopOthersAndPlay(str,loop,volume){
        if(!cacheAudios[str]){
            const innerAudioContext = wx.createInnerAudioContext();
            innerAudioContext.src= funs.getFullUrl(str);
            innerAudioContext.loop = Boolean(loop);
            cacheAudios[str] = {
                context:innerAudioContext,
                loop,
                volume,
                isPlaying:false
            }
            innerAudioContext.onEnded = function(){
                cacheAudios[str].isPlaying = false;
            }
        }

        Object.keys(cacheAudios).forEach(v=>{
            if(cacheAudios[v].isPlaying && v!==str){
                cacheAudios[v].isPlaying = false;
                cacheAudios[v].context.stop();
            }
        })

        const audio = cacheAudios[str];
        if(audio.loop !=Boolean(loop)){
            audio.loop = Boolean(loop);
            audio.context.loop = Boolean(loop);
        }
        if(audio.volume !=volume){
            audio.volume = volume;
            audio.context.volume = volume;
        }
        if(!audio.isPlaying){
            audio.context.play();
            audio.context.isPlaying = true;
        }
    },
    WXShortAudioPlayerStop(str){
        let audio = cacheAudios[str];
        if(audio){
            if(audio.isPlaying){
                audio.isPlaying =false;
                audio.context.stop();
            }
        }
    },
    WXShortAudioPlayerDestroy(str){
        let audio = cacheAudios[str];
        if(audio){
            audio.context.destroy();
            delete cacheAudios[str];
        }
    }

}

const mod = {
    recover(){
        Object.keys(cacheAudios).forEach(key=>{
            const audio = cacheAudios[key];
            if(audio.context.paused && audio.isPlaying){
                if(audio.loop){
                    audio.play();
                }else{
                    audio.isPlaying = false;
                }
            }
        })
    },
    init(){
        wx.onShow(mod.recover);
        wx.onAudioInterruptionEnd(mod.recover);
    }
};

mod.init();

