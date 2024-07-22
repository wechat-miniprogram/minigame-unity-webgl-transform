import moduleHelper from './module-helper';
import { uid } from './utils';

const GameRecorderList = {};

export default {
  WX_GetGameRecorder() {
    const obj = wx.getGameRecorder();
    const id = uid();
    GameRecorderList[id] = obj;
    return id;
  },
  WX_GameRecorderOff(id, eventType) {
    const obj = GameRecorderList[id];
    if (!obj || typeof obj.onList === 'undefined' || typeof obj.onList[eventType] === 'undefined') {
      return;
    }
    for (const key in Object.keys(obj.onList[eventType])) {
      const callback = obj.onList[eventType][key];
      if (callback) {
        obj.off(eventType, callback);
      }
    }
    obj.onList[eventType] = {};
  },
  WX_GameRecorderOn(id, eventType) {
    const obj = GameRecorderList[id];
    if (!obj) return '';
    if (!obj.onList) {
      obj.onList = {
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
    if (obj.onList[eventType]) {
      obj.onList[eventType][callbackId] = callback;
      obj.on(eventType, callback);
      return callbackId;
    }
    return '';
  },
  WX_GameRecorderStart(id, option) {
    const obj = GameRecorderList[id];
    if (obj) {
      obj.start(JSON.parse(option));
    }
  },
  WX_GameRecorderAbort(id) {
    const obj = GameRecorderList[id];
    if (obj) {
      obj.abort();
    }
  },
  WX_GameRecorderPause(id) {
    const obj = GameRecorderList[id];
    if (obj) {
      obj.pause();
    }
  },
  WX_GameRecorderResume(id) {
    const obj = GameRecorderList[id];
    if (obj) {
      obj.resume();
    }
  },
  WX_GameRecorderStop(id) {
    const obj = GameRecorderList[id];
    if (obj) {
      obj.stop();
    }
  },
  WX_OperateGameRecorderVideo(option) {
    if (typeof wx.operateGameRecorderVideo !== 'undefined') {
      const data = JSON.parse(option);
      data.fail = (res) => {
        console.error(res);
      };
      wx.operateGameRecorderVideo(data);
    }
  },
};
