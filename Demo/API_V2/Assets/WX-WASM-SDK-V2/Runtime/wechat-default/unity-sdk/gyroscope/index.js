import { formatJsonStr, formatResponse, convertDataToPointer } from '../utils';
let wxStartGyroscopeCallback;
let wxStopGyroscopeCallback;
let wxOnGyroscopeChangeCallback;
const OnGyroscopeChange = (res) => {
    formatResponse('OnGyroscopeChangeListenerResult', res);
    const xPtr = convertDataToPointer(res.x);
    const yPtr = convertDataToPointer(res.y);
    const zPtr = convertDataToPointer(res.z);
    GameGlobal.Module.dynCall_viii(wxOnGyroscopeChangeCallback, xPtr, yPtr, zPtr);
    GameGlobal.Module._free(xPtr);
    GameGlobal.Module._free(yPtr);
    GameGlobal.Module._free(zPtr);
};
function handleCallback(callback, id, callbackType, res) {
    formatResponse('GeneralCallbackResult', res);
    const idPtr = convertDataToPointer(id);
    const msgPtr = convertDataToPointer(res.errMsg);
    GameGlobal.Module.dynCall_viii(callback, idPtr, callbackType, msgPtr);
    GameGlobal.Module._free(idPtr);
    GameGlobal.Module._free(msgPtr);
}
function WX_StartGyroscope(id, conf) {
    const config = formatJsonStr(conf);
    wx.startGyroscope({
        ...config,
        success(res) {
            handleCallback(wxStartGyroscopeCallback, id, 2, res);
        },
        fail(res) {
            handleCallback(wxStartGyroscopeCallback, id, 1, res);
        },
        complete(res) {
            handleCallback(wxStartGyroscopeCallback, id, 0, res);
        },
    });
}
function WX_StopGyroscope(id, conf) {
    const config = formatJsonStr(conf);
    wx.stopGyroscope({
        ...config,
        success(res) {
            handleCallback(wxStopGyroscopeCallback, id, 2, res);
        },
        fail(res) {
            handleCallback(wxStopGyroscopeCallback, id, 1, res);
        },
        complete(res) {
            handleCallback(wxStopGyroscopeCallback, id, 0, res);
        },
    });
}
function WX_OnGyroscopeChange() {
    wx.onGyroscopeChange(OnGyroscopeChange);
}
function WX_OffGyroscopeChange() {
    wx.offGyroscopeChange();
}
function WX_RegisterStartGyroscopeCallback(callback) {
    wxStartGyroscopeCallback = callback;
}
function WX_RegisterStopGyroscopeCallback(callback) {
    wxStopGyroscopeCallback = callback;
}
function WX_RegisterOnGyroscopeChangeCallback(callback) {
    wxOnGyroscopeChangeCallback = callback;
}
export default {
    WX_StartGyroscope,
    WX_StopGyroscope,
    WX_OnGyroscopeChange,
    WX_OffGyroscopeChange,
    WX_RegisterStartGyroscopeCallback,
    WX_RegisterStopGyroscopeCallback,
    WX_RegisterOnGyroscopeChangeCallback,
};
