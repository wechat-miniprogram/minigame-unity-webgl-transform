import { convertDataToPointer } from '../utils';
let wxOnBLECharacteristicValueChangeCallback;
const OnBLECharacteristicValueChange = (res) => {
    const deviceIdPtr = convertDataToPointer(res.deviceId);
    const serviceIdPtr = convertDataToPointer(res.serviceId);
    const characteristicIdPtr = convertDataToPointer(res.characteristicId);
    const valuePtr = convertDataToPointer(res.value);
    GameGlobal.Module.dynCall_viiiii(wxOnBLECharacteristicValueChangeCallback, deviceIdPtr, serviceIdPtr, characteristicIdPtr, valuePtr, res.value.byteLength);
    GameGlobal.Module._free(deviceIdPtr);
    GameGlobal.Module._free(serviceIdPtr);
    GameGlobal.Module._free(characteristicIdPtr);
    GameGlobal.Module._free(valuePtr);
};
function WX_OnBLECharacteristicValueChange() {
    wx.onBLECharacteristicValueChange(OnBLECharacteristicValueChange);
}
function WX_OffBLECharacteristicValueChange() {
    wx.offBLECharacteristicValueChange();
}
function WX_RegisterOnBLECharacteristicValueChangeCallback(callback) {
    wxOnBLECharacteristicValueChangeCallback = callback;
}
export default {
    WX_OnBLECharacteristicValueChange,
    WX_OffBLECharacteristicValueChange,
    WX_RegisterOnBLECharacteristicValueChangeCallback,
};
