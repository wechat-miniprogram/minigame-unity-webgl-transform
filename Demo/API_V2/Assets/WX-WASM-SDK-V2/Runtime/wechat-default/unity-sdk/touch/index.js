import { formatTouchEvent, convertOnTouchStartListenerResultToPointer } from '../utils';
let wxOnTouchCancelCallback;
let wxOnTouchEndCallback;
let wxOnTouchMoveCallback;
let wxOnTouchStartCallback;
function handleTouchEvent(res, callback) {
    const dataPtr = convertOnTouchStartListenerResultToPointer({
        touches: res.touches.map(v => formatTouchEvent(v)),
        changedTouches: res.changedTouches.map(v => formatTouchEvent(v)),
        timeStamp: parseInt(res.timeStamp.toString(), 10),
    });
    GameGlobal.Module.dynCall_viii(callback, dataPtr, res.touches.length, res.changedTouches.length);
    GameGlobal.Module._free(dataPtr);
}
const OnTouchCancel = (res) => {
    handleTouchEvent(res, wxOnTouchCancelCallback);
};
const OnTouchEnd = (res) => {
    handleTouchEvent(res, wxOnTouchEndCallback);
};
const OnTouchMove = (res) => {
    handleTouchEvent(res, wxOnTouchMoveCallback);
};
const OnTouchStart = (res) => {
    handleTouchEvent(res, wxOnTouchStartCallback);
};
function WX_OnTouchCancel() {
    wx.onTouchCancel(OnTouchCancel);
}
function WX_OffTouchCancel() {
    wx.offTouchCancel(OnTouchCancel);
}
function WX_OnTouchEnd() {
    wx.onTouchEnd(OnTouchEnd);
}
function WX_OffTouchEnd() {
    wx.offTouchEnd(OnTouchEnd);
}
function WX_OnTouchMove() {
    wx.onTouchMove(OnTouchMove);
}
function WX_OffTouchMove() {
    wx.offTouchMove(OnTouchMove);
}
function WX_OnTouchStart() {
    wx.onTouchStart(OnTouchStart);
}
function WX_OffTouchStart() {
    wx.offTouchStart(OnTouchStart);
}
function WX_RegisterOnTouchCancelCallback(callback) {
    wxOnTouchCancelCallback = callback;
}
function WX_RegisterOnTouchEndCallback(callback) {
    wxOnTouchEndCallback = callback;
}
function WX_RegisterOnTouchMoveCallback(callback) {
    wxOnTouchMoveCallback = callback;
}
function WX_RegisterOnTouchStartCallback(callback) {
    wxOnTouchStartCallback = callback;
}
export default {
    WX_OnTouchCancel,
    WX_OffTouchCancel,
    WX_OnTouchEnd,
    WX_OffTouchEnd,
    WX_OnTouchMove,
    WX_OffTouchMove,
    WX_OnTouchStart,
    WX_OffTouchStart,
    WX_RegisterOnTouchCancelCallback,
    WX_RegisterOnTouchEndCallback,
    WX_RegisterOnTouchMoveCallback,
    WX_RegisterOnTouchStartCallback,
};
