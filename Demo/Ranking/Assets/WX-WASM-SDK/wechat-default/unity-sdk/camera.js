import moduleHelper from './module-helper';
import { formatJsonStr } from './sdk';

const tempCacheObj = {};

export default {
  WXCameraCreateCamera(option) {
    const obj = wx.createCamera(formatJsonStr(option));
    this.CameraList = this.CameraList || {};
    const list = this.CameraList;
    const count = Object.keys(list);
    const key = `${count}${new Date().getTime()}`;
    list[key] = obj;
    return key;
  },
  WXCameraCloseFrameChange(id) {
    const obj = this.CameraList[id];
    if (obj) {
      obj.closeFrameChange();
    }
  },
  WXCameraDestroy(id) {
    const obj = this.CameraList[id];
    if (obj) {
      obj.destroy();
    }
  },
  WXCameraListenFrameChange(id) {
    const obj = this.CameraList[id];
    if (obj) {
      obj.listenFrameChange();
    }
  },
  WXCameraOnAuthCancel(id) {
    const obj = this.CameraList[id];
    obj.OnAuthCancelList = obj.OnAuthCancelList || [];
    const callback = (res) => {
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('CameraOnAuthCancelCallback', resStr);
    };
    obj.OnAuthCancelList.push(callback);
    obj.onAuthCancel(callback);
  },
  WXCameraOnCameraFrame(id) {
    const obj = this.CameraList[id];
    obj.OnCameraFrameList = obj.OnCameraFrameList || [];
    const callback = (result) => {
      tempCacheObj[id] = result.data;
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify({
          width: result.width,
          height: result.height,
        }),
      });
      moduleHelper.send('CameraOnCameraFrameCallback', resStr);
    };
    obj.OnCameraFrameList.push(callback);
    obj.onCameraFrame(callback);
  },
  WXCameraOnStop(id) {
    const obj = this.CameraList[id];
    obj.OnStopList = obj.OnStopList || [];
    const callback = (res) => {
      const resStr = JSON.stringify({
        callbackId: id,
        res: JSON.stringify(res),
      });
      moduleHelper.send('CameraOnStopCallback', resStr);
    };
    obj.OnStopList.push(callback);
    obj.onStop(callback);
  },
  WXCameraArrayBuffer(buffer, offset, callbackId) {
    buffer.set(new Uint8Array(tempCacheObj[callbackId]), offset);
    delete tempCacheObj[callbackId];
  },
};
