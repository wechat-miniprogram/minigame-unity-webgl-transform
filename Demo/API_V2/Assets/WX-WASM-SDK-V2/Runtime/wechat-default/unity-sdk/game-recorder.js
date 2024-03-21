import moduleHelper from './module-helper';
import { formatJsonStr, getListObject, uid } from './utils';
const gameRecorderList = {};
let wxGameRecorderList;
const getObject = getListObject(gameRecorderList, 'gameRecorder');
export default {
    WX_GetGameRecorder() {
        const id = uid();
        gameRecorderList[id] = wx.getGameRecorder();
        return id;
    },
    WX_GameRecorderOff(id, eventType) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        if (!obj || typeof wxGameRecorderList === 'undefined' || typeof wxGameRecorderList[eventType] === 'undefined') {
            return;
        }
        
        for (const key in Object.keys(wxGameRecorderList[eventType])) {
            const callback = wxGameRecorderList[eventType][key];
            if (callback) {
                obj.off(eventType, callback);
            }
        }
        wxGameRecorderList[eventType] = {};
    },
    WX_GameRecorderOn(id, eventType) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        if (!wxGameRecorderList) {
            wxGameRecorderList = {
                start: {},
                stop: {},
                pause: {},
                resume: {},
                abort: {},
                timeUpdate: {},
                error: {},
            };
        }
        const callbackId = uid();
        const callback = (res) => {
            let result = '';
            if (res) {
                result = JSON.stringify(res);
            }
            const resStr = JSON.stringify({
                id,
                res: JSON.stringify({
                    eventType,
                    result,
                }),
            });
            moduleHelper.send('_OnGameRecorderCallback', resStr);
        };
        if (wxGameRecorderList[eventType]) {
            wxGameRecorderList[eventType][callbackId] = callback;
            obj.on(eventType, callback);
            return callbackId;
        }
        return '';
    },
    WX_GameRecorderStart(id, option) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const data = formatJsonStr(option);
        obj.start(data);
    },
    WX_GameRecorderAbort(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.abort();
    },
    WX_GameRecorderPause(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.pause();
    },
    WX_GameRecorderResume(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.resume();
    },
    WX_GameRecorderStop(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.stop();
    },
    WX_OperateGameRecorderVideo(option) {
        if (typeof wx.operateGameRecorderVideo !== 'undefined') {
            const data = formatJsonStr(option);
            data.fail = (res) => {
                console.error(res);
            };
            wx.operateGameRecorderVideo(data);
        }
    },
};
