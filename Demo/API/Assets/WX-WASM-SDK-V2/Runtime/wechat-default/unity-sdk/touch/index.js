import { formatTouchEvent, numberToUint8Array } from '../utils';
function serializeTouch(touch) {
    const clientXByteArray = numberToUint8Array(touch.clientX, Float32Array);
    const clientYByteArray = numberToUint8Array(touch.clientY, Float32Array);
    const forceByteArray = numberToUint8Array(touch.force);
    const identifierByteArray = numberToUint8Array(touch.identifier, Uint32Array);
    const pageXByteArray = numberToUint8Array(touch.pageX, Float32Array);
    const pageYByteArray = numberToUint8Array(touch.pageY, Float32Array);
    const byteArray = new Uint8Array(clientXByteArray.length + clientYByteArray.length + forceByteArray.length + identifierByteArray.length + pageXByteArray.length + pageYByteArray.length);
    let offset = 0;
    byteArray.set(clientXByteArray, offset);
    offset += clientXByteArray.length;
    byteArray.set(clientYByteArray, offset);
    offset += clientYByteArray.length;
    byteArray.set(forceByteArray, offset);
    offset += forceByteArray.length;
    byteArray.set(identifierByteArray, offset);
    offset += identifierByteArray.length;
    byteArray.set(pageXByteArray, offset);
    offset += pageXByteArray.length;
    byteArray.set(pageYByteArray, offset);
    return byteArray;
}
function serializeTouches(touches) {
    const serializedTouches = touches.map(serializeTouch);
    const totalLength = serializedTouches.reduce((sum, touchByteArray) => sum + touchByteArray.length, 0);
    const byteArray = new Uint8Array(totalLength);
    let offset = 0;
    serializedTouches.forEach((touchByteArray) => {
        byteArray.set(touchByteArray, offset);
        offset += touchByteArray.length;
    });
    return byteArray;
}
function serializeOnTouchStartListenerResult(result) {
    const touchesByteArray = serializeTouches(result.touches);
    const changedTouchesByteArray = serializeTouches(result.changedTouches);
    const timeStampByteArray = numberToUint8Array(result.timeStamp, Uint32Array);
    const byteArray = new Uint8Array(touchesByteArray.length + changedTouchesByteArray.length + timeStampByteArray.length);
    let offset = 0;
    byteArray.set(touchesByteArray, offset);
    offset += touchesByteArray.length;
    byteArray.set(changedTouchesByteArray, offset);
    offset += changedTouchesByteArray.length;
    byteArray.set(timeStampByteArray, offset);
    return byteArray;
}
let wxOnTouchCancelCallback;
let wxOnTouchEndCallback;
let wxOnTouchMoveCallback;
let wxOnTouchStartCallback;
function handleTouchEvent(res, callback) {
    res.touches = res.touches.map(v => formatTouchEvent(v));
    res.changedTouches = res.changedTouches.map(v => formatTouchEvent(v));
    res.timeStamp = parseInt(res.timeStamp.toString(), 10);
    const serializedData = serializeOnTouchStartListenerResult(res);
    const buffer = GameGlobal.Module._malloc(serializedData.length);
    GameGlobal.Module.HEAPU8.set(serializedData, buffer);
    GameGlobal.Module.dynCall_viiii(callback, buffer, serializedData.length, res.touches.length, res.changedTouches.length);
    GameGlobal.Module._free(buffer);
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
