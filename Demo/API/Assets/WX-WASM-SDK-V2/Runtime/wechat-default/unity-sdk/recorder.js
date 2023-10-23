import moduleHelper from './module-helper';
import { formatJsonStr, cacheArrayBuffer, getListObject, uid } from './utils';
const recorderManagerList = {};
const getObject = getListObject(recorderManagerList, 'video');
export default {
    WX_GetRecorderManager() {
        const id = uid();
        recorderManagerList[id] = wx.getRecorderManager();
        return id;
    },
    WX_OnRecorderError(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_OnRecorderErrorCallback', resStr);
        };
        obj.onError(callback);
    },
    WX_OnRecorderFrameRecorded(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            cacheArrayBuffer(id, res.frameBuffer);
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify({
                    frameBufferLength: res.frameBuffer.byteLength,
                    isLastFrame: res.isLastFrame,
                }),
            });
            moduleHelper.send('_OnRecorderFrameRecordedCallback', resStr);
        };
        obj.onFrameRecorded(callback);
    },
    WX_OnRecorderInterruptionBegin(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_OnRecorderInterruptionBeginCallback', resStr);
        };
        obj.onInterruptionBegin(callback);
    },
    WX_OnRecorderInterruptionEnd(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_OnRecorderInterruptionEndCallback', resStr);
        };
        obj.onInterruptionEnd(callback);
    },
    WX_OnRecorderPause(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_OnRecorderPauseCallback', resStr);
        };
        obj.onPause(callback);
    },
    WX_OnRecorderResume(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_OnRecorderResumeCallback', resStr);
        };
        obj.onResume(callback);
    },
    WX_OnRecorderStart(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_OnRecorderStartCallback', resStr);
        };
        obj.onStart(callback);
    },
    WX_OnRecorderStop(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = (res) => {
            const resStr = JSON.stringify({
                callbackId: id,
                res: JSON.stringify(res),
            });
            moduleHelper.send('_OnRecorderStopCallback', resStr);
        };
        obj.onStop(callback);
    },
    WX_RecorderPause(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.pause();
    },
    WX_RecorderResume(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.resume();
    },
    WX_RecorderStart(id, option) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const conf = formatJsonStr(option);
        obj.start(conf);
    },
    WX_RecorderStop(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.stop();
    },
};
