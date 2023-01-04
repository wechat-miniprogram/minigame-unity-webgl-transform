import moduleHelper from './module-helper';

const tempCacheObj = {};

export default {
  WX_GetRecorderManager() {
    const obj = wx.getRecorderManager();
    this.RecorderManagerList = this.RecorderManagerList || {};
    const list = this.RecorderManagerList;
    const count = Object.keys(list);
    const key = `${count}${new Date().getTime()}`;
    list[key] = obj;
    return key;
  },
  WX_OnRecorderError(id) {
    const obj = this.RecorderManagerList[id];
    obj.OnRecorderErrorList = obj.OnRecorderErrorList || [];
    const callback = (res) => {
      //   formatResponse('GeneralCallbackResult', res);
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('_OnRecorderErrorCallback', resStr);
    };
    obj.OnRecorderErrorList.push(callback);
    obj.onError(callback);
  },
  WX_OnRecorderFrameRecorded(id) {
    const obj = this.RecorderManagerList[id];
    obj.OnRecorderFrameRecordedList = obj.OnRecorderFrameRecordedList || [];
    const callback = (res) => {
      tempCacheObj[id] = res.data;
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify({
          frameBufferLength: res.frameBuffer.byteLength,
          isLastFrame: res.isLastFrame,
        }),
      });
      moduleHelper.send('_OnRecorderFrameRecordedCallback', resStr);
    };
    obj.OnRecorderFrameRecordedList.push(callback);
    obj.onFrameRecorded(callback);
  },
  WX_OnRecorderInterruptionBegin(id) {
    const obj = this.RecorderManagerList[id];
    obj.OnRecorderInterruptionBeginList = obj.OnRecorderInterruptionBeginList || [];
    const callback = (res) => {
      //   formatResponse('GeneralCallbackResult', res);
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('_OnRecorderInterruptionBeginCallback', resStr);
    };
    obj.OnRecorderInterruptionBeginList.push(callback);
    obj.onInterruptionBegin(callback);
  },
  WX_OnRecorderInterruptionEnd(id) {
    const obj = this.RecorderManagerList[id];
    obj.OnRecorderInterruptionEndList = obj.OnRecorderInterruptionEndList || [];
    const callback = (res) => {
      //   formatResponse('GeneralCallbackResult', res);
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('_OnRecorderInterruptionEndCallback', resStr);
    };
    obj.OnRecorderInterruptionEndList.push(callback);
    obj.onInterruptionEnd(callback);
  },
  WX_OnRecorderPause(id) {
    const obj = this.RecorderManagerList[id];
    obj.OnRecorderPauseList = obj.OnRecorderPauseList || [];
    const callback = (res) => {
      //   formatResponse('GeneralCallbackResult', res);
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('_OnRecorderPauseCallback', resStr);
    };
    obj.OnRecorderPauseList.push(callback);
    obj.onPause(callback);
  },
  WX_OnRecorderResume(id) {
    const obj = this.RecorderManagerList[id];
    obj.OnRecorderResumeList = obj.OnRecorderResumeList || [];
    const callback = (res) => {
      //   formatResponse('GeneralCallbackResult', res);
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('_OnRecorderResumeCallback', resStr);
    };
    obj.OnRecorderResumeList.push(callback);
    obj.onResume(callback);
  },
  WX_OnRecorderStart(id) {
    const obj = this.RecorderManagerList[id];
    obj.OnRecorderStartList = obj.OnRecorderStartList || [];
    const callback = (res) => {
      //   formatResponse('GeneralCallbackResult', res);
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('_OnRecorderStartCallback', resStr);
    };
    obj.OnRecorderStartList.push(callback);
    obj.onStart(callback);
  },
  WX_OnRecorderStop(id) {
    const obj = this.RecorderManagerList[id];
    obj.OnRecorderStopList = obj.OnRecorderStopList || [];
    const callback = (res) => {
      //   formatResponse('OnStopCallbackResult', res);
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('_OnRecorderStopCallback', resStr);
    };
    obj.OnRecorderStopList.push(callback);
    obj.onStop(callback);
  },
  WX_RecorderPause(id) {
    const obj = this.RecorderManagerList[id];
    if (obj) {
      obj.pause();
    }
  },
  WX_RecorderResume(id) {
    const obj = this.RecorderManagerList[id];
    if (obj) {
      obj.resume();
    }
  },
  WX_RecorderStart(id, option) {
    const obj = this.RecorderManagerList[id];
    if (obj) {
      obj.start(JSON.parse(option));
    }
  },
  WX_RecorderStop(id) {
    const obj = this.RecorderManagerList[id];
    if (obj) {
      obj.stop();
    }
  },
  WXRecorderArrayBuffer(buffer, offset, callbackId) {
    buffer.set(new Uint8Array(tempCacheObj[callbackId]), offset);
    delete tempCacheObj[callbackId];
  },
};
