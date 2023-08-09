import moduleHelper from './module-helper';
import { formatJsonStr, getListObject, uid } from './utils';
const videoList = {};
const getObject = getListObject(videoList, 'video');
export default {
    WXCreateVideo(conf) {
        const id = uid();
        const params = formatJsonStr(conf);
        
        if (params.underGameView) {
            GameGlobal.enableTransparentCanvas = true;
        }
        videoList[id] = wx.createVideo(params);
        return id;
    },
    WXVideoSetProperty(id, key, value) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        if (key === 'x' || key === 'y' || key === 'width' || key === 'height') {
            obj[key] = +value;
        }
        else if (key === 'src' || key === 'poster') {
            obj[key] = value;
        }
    },
    WXVideoPlay(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.play();
    },
    WXVideoAddListener(id, key) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj[key]((e) => {
            moduleHelper.send('OnVideoCallback', JSON.stringify({
                callbackId: id,
                errMsg: key,
                position: e && e.position,
                buffered: e && e.buffered,
                duration: e && e.duration,
            }));
            if (key === 'onError') {
                GameGlobal.enableTransparentCanvas = false;
                console.error(e);
            }
        });
    },
    WXVideoDestroy(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.destroy();
        GameGlobal.enableTransparentCanvas = false;
    },
    WXVideoExitFullScreen(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.exitFullScreen();
    },
    WXVideoPause(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.pause();
    },
    WXVideoRequestFullScreen(id, direction) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.requestFullScreen(direction);
    },
    WXVideoSeek(id, time) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.seek(time);
    },
    WXVideoStop(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.stop();
    },
    WXVideoRemoveListener(id, key) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj[key]();
    },
};
