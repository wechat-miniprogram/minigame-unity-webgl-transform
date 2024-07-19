import moduleHelper from './module-helper';
import { formatJsonStr, getListObject, offEventCallback, onEventCallback } from './utils';
const uploadTaskList = {};
const wxUpdateTaskOnProgressList = {};
const wxUpdateTaskOnHeadersList = {};
const getObject = getListObject(uploadTaskList, 'uploadTask');
export default {
    WX_UploadFile(option, callbackId) {
        const conf = formatJsonStr(option);
        const obj = wx.uploadFile({
            ...conf,
            success: (res) => {
                moduleHelper.send('UploadFileCallback', JSON.stringify({
                    callbackId,
                    type: 'success',
                    res: JSON.stringify(res),
                }));
            },
            fail: (res) => {
                moduleHelper.send('UploadFileCallback', JSON.stringify({
                    callbackId,
                    type: 'fail',
                    res: JSON.stringify(res),
                }));
            },
            complete: (res) => {
                moduleHelper.send('UploadFileCallback', JSON.stringify({
                    callbackId,
                    type: 'complete',
                    res: JSON.stringify(res),
                }));
                setTimeout(() => {
                    if (uploadTaskList) {
                        delete uploadTaskList[callbackId];
                    }
                }, 0);
            },
        });
        uploadTaskList[callbackId] = obj;
    },
    WXUploadTaskAbort(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        obj.abort();
    },
    WXUploadTaskOffHeadersReceived(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        offEventCallback(wxUpdateTaskOnHeadersList, (v) => {
            obj.offHeadersReceived(v);
        }, id);
    },
    WXUploadTaskOffProgressUpdate(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        offEventCallback(wxUpdateTaskOnProgressList, (v) => {
            obj.offProgressUpdate(v);
        }, id);
    },
    WXUploadTaskOnHeadersReceived(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = onEventCallback(wxUpdateTaskOnHeadersList, '_OnHeadersReceivedCallback', id);
        obj.onHeadersReceived(callback);
    },
    WXUploadTaskOnProgressUpdate(id) {
        const obj = getObject(id);
        if (!obj) {
            return;
        }
        const callback = onEventCallback(wxUpdateTaskOnProgressList, '_OnProgressUpdateCallback', id);
        obj.onProgressUpdate(callback);
    },
};
