import { formatJsonStr, uid, onEventCallback, offEventCallback, getListObject, serializeLocalInfo, serializeRemoteInfo, formatResponse } from '../utils';
const TCPSocketList = {};
const wxTCPSocketBindWifiList = {};
const wxTCPSocketCloseList = {};
const wxTCPSocketConnectList = {};
const wxTCPSocketErrorList = {};
const wxTCPSocketMessageList = {};
const getTCPSocketObject = getListObject(TCPSocketList, 'TCPSocket');
let wxTCPSocketOnMessageCallback;
function WX_CreateTCPSocket() {
    const obj = wx.createTCPSocket();
    const key = uid();
    TCPSocketList[key] = obj;
    return key;
}
function WX_TCPSocketBindWifi(id, option) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.bindWifi(formatJsonStr(option));
}
function WX_TCPSocketClose(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.close();
    delete TCPSocketList[id];
}
function WX_TCPSocketConnect(id, option) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.connect(formatJsonStr(option));
}
function WX_TCPSocketWriteString(id, data) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.write(data);
}
function WX_TCPSocketWriteBuffer(id, dataPtr, dataLength) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.write(GameGlobal.Module.HEAPU8.buffer.slice(dataPtr, dataPtr + dataLength));
}
function WX_TCPSocketOffBindWifi(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxTCPSocketBindWifiList, (v) => {
        obj.offBindWifi(v);
    }, id);
}
function WX_TCPSocketOffClose(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxTCPSocketCloseList, (v) => {
        obj.offClose(v);
    }, id);
}
function WX_TCPSocketOffConnect(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxTCPSocketConnectList, (v) => {
        obj.offConnect(v);
    }, id);
}
function WX_TCPSocketOffError(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxTCPSocketErrorList, (v) => {
        obj.offError(v);
    }, id);
}
function WX_TCPSocketOffMessage(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxTCPSocketMessageList, (v) => {
        obj.offMessage(v);
    }, id);
}
function WX_TCPSocketOnBindWifi(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    const callback = onEventCallback(wxTCPSocketBindWifiList, '_TCPSocketOnBindWifiCallback', id, id);
    obj.onBindWifi(callback);
}
function WX_TCPSocketOnClose(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    const callback = onEventCallback(wxTCPSocketCloseList, '_TCPSocketOnCloseCallback', id, id);
    obj.onClose(callback);
}
function WX_TCPSocketOnConnect(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    const callback = onEventCallback(wxTCPSocketConnectList, '_TCPSocketOnConnectCallback', id, id);
    obj.onConnect(callback);
}
function WX_TCPSocketOnError(id) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    const callback = onEventCallback(wxTCPSocketErrorList, '_TCPSocketOnErrorCallback', id, id);
    obj.onError(callback);
}
function WX_TCPSocketOnMessage(id, needInfo) {
    const obj = getTCPSocketObject(id);
    if (!obj) {
        return;
    }
    if (!wxTCPSocketMessageList[id]) {
        wxTCPSocketMessageList[id] = [];
    }
    const callback = (res) => {
        if (needInfo) {
            formatResponse('TCPSocketOnMessageListenerResult', res);
            const idBytes = GameGlobal.Module.lengthBytesUTF8(id) + 1; 
            const idPtr = GameGlobal.Module._malloc(idBytes); 
            GameGlobal.Module.stringToUTF8(id, idPtr, idBytes);
            const messageByteArray = new Uint8Array(res.message);
            const localInfoByteArray = serializeLocalInfo(res.localInfo);
            const remoteInfoByteArray = serializeRemoteInfo(res.remoteInfo);
            const messageBuffer = GameGlobal.Module._malloc(messageByteArray.length);
            const localInfoBuffer = GameGlobal.Module._malloc(localInfoByteArray.length);
            const remoteInfoBuffer = GameGlobal.Module._malloc(remoteInfoByteArray.length);
            GameGlobal.Module.HEAPU8.set(messageByteArray, messageBuffer);
            GameGlobal.Module.HEAPU8.set(localInfoByteArray, localInfoBuffer);
            GameGlobal.Module.HEAPU8.set(remoteInfoByteArray, remoteInfoBuffer);
            GameGlobal.Module.dynCall_viiiii(wxTCPSocketOnMessageCallback, idPtr, messageBuffer, messageByteArray.length, localInfoBuffer, remoteInfoBuffer);
            GameGlobal.Module._free(idPtr);
            GameGlobal.Module._free(messageBuffer);
            GameGlobal.Module._free(localInfoBuffer);
            GameGlobal.Module._free(remoteInfoBuffer);
        }
        else {
            formatResponse('TCPSocketOnMessageListenerResult', res);
            const idBytes = GameGlobal.Module.lengthBytesUTF8(id) + 1; 
            const idPtr = GameGlobal.Module._malloc(idBytes); 
            GameGlobal.Module.stringToUTF8(id, idPtr, idBytes);
            const messageByteArray = new Uint8Array(res.message);
            const messageBuffer = GameGlobal.Module._malloc(messageByteArray.length);
            GameGlobal.Module.HEAPU8.set(messageByteArray, messageBuffer);
            GameGlobal.Module.dynCall_viiiii(wxTCPSocketOnMessageCallback, idPtr, messageBuffer, messageByteArray.length, 0, 0);
            GameGlobal.Module._free(idPtr);
            GameGlobal.Module._free(messageBuffer);
        }
    };
    wxTCPSocketMessageList[id].push(callback);
    obj.onMessage(callback);
}
function WX_RegisterTCPSocketOnMessageCallback(callback) {
    wxTCPSocketOnMessageCallback = callback;
}
export default {
    WX_CreateTCPSocket,
    WX_TCPSocketBindWifi,
    WX_TCPSocketClose,
    WX_TCPSocketConnect,
    WX_TCPSocketWriteString,
    WX_TCPSocketWriteBuffer,
    WX_TCPSocketOffBindWifi,
    WX_TCPSocketOffClose,
    WX_TCPSocketOffConnect,
    WX_TCPSocketOffError,
    WX_TCPSocketOffMessage,
    WX_TCPSocketOnBindWifi,
    WX_TCPSocketOnClose,
    WX_TCPSocketOnConnect,
    WX_TCPSocketOnError,
    WX_TCPSocketOnMessage,
    WX_RegisterTCPSocketOnMessageCallback,
};
