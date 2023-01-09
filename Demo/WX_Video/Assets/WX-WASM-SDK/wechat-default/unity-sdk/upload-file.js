import moduleHelper from './module-helper';
import { formatJsonStr } from './sdk';

export default {
  WX_UploadFile(option, callbackId) {
    const conf = formatJsonStr(option);
    const obj = wx.uploadFile({
      ...conf,
      success: (res) => {
        moduleHelper.send('UploadFileCallback', JSON.stringify({
          callbackId, type: 'success', res: JSON.stringify(res),
        }));
      },
      fail: (res) => {
        moduleHelper.send('UploadFileCallback', JSON.stringify({
          callbackId, type: 'fail', res: JSON.stringify(res),
        }));
      },
      complete: (res) => {
        moduleHelper.send('UploadFileCallback', JSON.stringify({
          callbackId, type: 'complete', res: JSON.stringify(res),
        }));
        setTimeout(() => {
          delete this.UploadTaskList[callbackId];
        }, 0);
      },
    });
    this.UploadTaskList = this.UploadTaskList || {};
    const list = this.UploadTaskList;
    list[callbackId] = obj;
  },
  WXUploadTaskAbort(id) {
    const obj = this.UploadTaskList[id];
    if (obj) {
      obj.abort();
    }
  },
  WXUploadTaskOffHeadersReceived(id) {
    const obj = this.UploadTaskList[id];
    if (obj) {
      obj.OffHeadersReceivedList = obj.OffHeadersReceivedList || [];
      obj.OffHeadersReceivedList.forEach((v) => {
        obj.offHeadersReceived(v);
      });
      obj.OffHeadersReceivedList = [];
    }
  },
  WXUploadTaskOffProgressUpdate(id) {
    const obj = this.UploadTaskList[id];
    if (obj) {
      obj.OffProgressUpdateList = obj.OffProgressUpdateList || [];
      obj.OffProgressUpdateList.forEach((v) => {
        obj.offProgressUpdate(v);
      });
      obj.OffProgressUpdateList = [];
    }
  },
  WXUploadTaskOnHeadersReceived(id) {
    const obj = this.UploadTaskList[id];
    if (obj) {
      obj.OnHeadersReceivedList = obj.OnHeadersReceivedList || [];
      const callback = (res) => {
        const resStr = JSON.stringify({
          callbackId: id,
          res: JSON.stringify(res),
        });
        moduleHelper.send('_OnHeadersReceivedCallback', resStr);
      };
      obj.OnHeadersReceivedList.push(callback);
      obj.onHeadersReceived(callback);
    }
  },
  WXUploadTaskOnProgressUpdate(id) {
    const obj = this.UploadTaskList[id];
    if (obj) {
      obj.OnProgressUpdateList = obj.OnProgressUpdateList || [];
      const callback = (res) => {
        const resStr = JSON.stringify({
          callbackId: id,
          res: JSON.stringify(res),
        });
        moduleHelper.send('_OnProgressUpdateCallback', resStr);
      };
      obj.OnProgressUpdateList.push(callback);
      obj.onProgressUpdate(callback);
    }
  },
};
