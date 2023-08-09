import { WEBAudio, audios } from './store';
import { resumeWebAudio, mkCacheDir } from './utils';

mkCacheDir();
export default {
        WXGetAudioCount() {
        return {
            innerAudio: Object.keys(audios).length,
            webAudio: WEBAudio.bufferSourceNodeLength,
            buffer: WEBAudio.audioBufferLength,
        };
    },
};

const HandleInterruption = {
    init() {
        let INTERRUPT_LIST = {};
        wx.onHide(() => {
            Object.keys(audios).forEach((key) => {
                if (!audios[key].paused !== false) {
                    INTERRUPT_LIST[key] = true;
                }
            });
        });
        wx.onShow(() => {
            Object.keys(audios).forEach((key) => {
                if (audios[key].paused !== false && INTERRUPT_LIST[key]) {
                    audios[key].play();
                }
            });
            INTERRUPT_LIST = {};
        });
        wx.onAudioInterruptionBegin(() => {
            Object.keys(audios).forEach((key) => {
                if (!audios[key].paused !== false) {
                    INTERRUPT_LIST[key] = true;
                }
            });
        });
        wx.onAudioInterruptionEnd(() => {
            Object.keys(audios).forEach((key) => {
                if (audios[key].paused !== false && INTERRUPT_LIST[key]) {
                    audios[key].play();
                }
            });
            INTERRUPT_LIST = {};
            resumeWebAudio();
        });
    },
};
HandleInterruption.init();
