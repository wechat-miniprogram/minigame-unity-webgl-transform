import { uid } from '../utils';
import { isSupportCacheAudio } from '../../check-version';
import { WEBAudio, audios } from './store';
import { TEMP_DIR_PATH } from './const';
export const resumeWebAudio = () => {
    
    
    
    
    
    
    WEBAudio.audioContext?.resume();
};
export const createInnerAudio = () => {
    const id = uid();
    const audio = (isSupportCacheAudio && WEBAudio.audioCache.length ? WEBAudio.audioCache.shift() : wx.createInnerAudioContext());
    if (audio) {
        audios[id] = audio;
    }
    return {
        id,
        audio,
    };
};
export const destroyInnerAudio = (id, useCache) => {
    if (!id) {
        return;
    }
    if (!useCache || !isSupportCacheAudio || WEBAudio.audioCache.length > 32) {
        audios[id].destroy();
    }
    else {
        
        ['Play', 'Pause', 'Stop', 'Canplay', 'Error', 'Ended', 'Waiting', 'Seeking', 'Seeked', 'TimeUpdate'].forEach((eventName) => {
            audios[id][`off${eventName}`]();
        });
        const state = {
            startTime: 0,
            obeyMuteSwitch: true,
            volume: 1,
            autoplay: false,
            loop: false,
            referrerPolicy: '',
        };
        Object.keys(state).forEach((key) => {
            try {
                
                
                audios[id][key] = state[key];
            }
            catch (e) { }
        });
        audios[id].stop();
        const cacheAudio = audios[id];
        
        setTimeout(() => {
            
            WEBAudio.audioCache.push(cacheAudio);
        }, 1000);
    }
    delete audios[id];
};
export const printErrMsg = (msg) => {
    GameGlobal.manager.printErr(msg);
};
export function mkCacheDir() {
    const fs = wx.getFileSystemManager();
    fs.rmdir({
        dirPath: TEMP_DIR_PATH,
        recursive: true,
        complete: () => {
            fs.mkdir({
                dirPath: TEMP_DIR_PATH,
            });
        },
    });
}
