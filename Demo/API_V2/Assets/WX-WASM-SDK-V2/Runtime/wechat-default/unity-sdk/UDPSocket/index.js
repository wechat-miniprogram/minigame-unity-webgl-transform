import { formatJsonStr, uid, onEventCallback, offEventCallback, getListObject, convertDataToPointer, convertInfoToPointer, formatResponse } from '../utils';
const UDPSocketList = {};
const wxUDPSocketCloseList = {};
const wxUDPSocketErrorList = {};
const wxUDPSocketListeningList = {};
const wxUDPSocketMessageList = {};
const getUDPSocketObject = getListObject(UDPSocketList, 'UDPSocket');
let wxUDPSocketOnMessageCallback;
function WX_CreateUDPSocket() {
    const obj = wx.createUDPSocket();
    const key = uid();
    UDPSocketList[key] = obj;
    return key;
}
function WX_UDPSocketClose(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.close();
    delete UDPSocketList[id];
}
function WX_UDPSocketConnect(id, option) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.connect(formatJsonStr(option));
}
function WX_UDPSocketOffClose(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxUDPSocketCloseList, (v) => {
        obj.offClose(v);
    }, id);
}
function WX_UDPSocketOffError(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxUDPSocketErrorList, (v) => {
        obj.offError(v);
    }, id);
}
function WX_UDPSocketOffListening(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxUDPSocketListeningList, (v) => {
        obj.offListening(v);
    }, id);
}
function WX_UDPSocketOffMessage(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    offEventCallback(wxUDPSocketMessageList, (v) => {
        obj.offMessage(v);
    }, id);
}
function WX_UDPSocketOnClose(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    const callback = onEventCallback(wxUDPSocketCloseList, '_UDPSocketOnCloseCallback', id, id);
    obj.onClose(callback);
}
function WX_UDPSocketOnError(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    const callback = onEventCallback(wxUDPSocketErrorList, '_UDPSocketOnErrorCallback', id, id);
    obj.onError(callback);
}
function WX_UDPSocketOnListening(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    const callback = onEventCallback(wxUDPSocketListeningList, '_UDPSocketOnListeningCallback', id, id);
    obj.onListening(callback);
}
function WX_UDPSocketOnMessage(id, needInfo) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    if (!wxUDPSocketMessageList[id]) {
        wxUDPSocketMessageList[id] = [];
    }
    const callback = (res) => {
        formatResponse('UDPSocketOnMessageListenerResult', res);
        const idPtr = convertDataToPointer(id);
        const messagePtr = convertDataToPointer(res.message);
        if (needInfo) {
            const localInfoPtr = convertInfoToPointer(res.localInfo);
            const remoteInfoPtr = convertInfoToPointer(res.remoteInfo);
            GameGlobal.Module.dynCall_viiiii(wxUDPSocketOnMessageCallback, idPtr, messagePtr, res.message.length || res.message.byteLength, localInfoPtr, remoteInfoPtr);
            GameGlobal.Module._free(localInfoPtr);
            GameGlobal.Module._free(remoteInfoPtr);
        }
        else {
            GameGlobal.Module.dynCall_viiiii(wxUDPSocketOnMessageCallback, idPtr, messagePtr, res.message.length || res.message.byteLength, 0, 0);
        }
        GameGlobal.Module._free(idPtr);
        GameGlobal.Module._free(messagePtr);
    };
    wxUDPSocketMessageList[id].push(callback);
    obj.onMessage(callback);
}
function WX_UDPSocketSendString(id, data, param) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    const config = formatJsonStr(param);
    obj.send({
        address: config.address,
        message: data,
        port: config.port,
        setBroadcast: config.setBroadcast,
    });
}
function WX_UDPSocketSendBuffer(id, dataPtr, dataLength, param) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    const config = formatJsonStr(param);
    obj.send({
        address: config.address,
        message: GameGlobal.Module.HEAPU8.buffer.slice(dataPtr, dataPtr + dataLength),
        port: config.port,
        length: config.length,
        offset: config.offset,
        setBroadcast: config.setBroadcast,
    });
}
function WX_UDPSocketSetTTL(id, ttl) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.setTTL(ttl);
}
function WX_UDPSocketWrite(id) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return;
    }
    obj.write();
}
function WX_UDPSocketBind(id, param) {
    const obj = getUDPSocketObject(id);
    if (!obj) {
        return 0;
    }
    const config = formatJsonStr(param);
    return obj.bind(config.port);
}
function WX_RegisterUDPSocketOnMessageCallback(callback) {
    wxUDPSocketOnMessageCallback = callback;
}
export default {
    WX_CreateUDPSocket,
    WX_UDPSocketBind,
    WX_UDPSocketClose,
    WX_UDPSocketConnect,
    WX_UDPSocketOffClose,
    WX_UDPSocketOffError,
    WX_UDPSocketOffListening,
    WX_UDPSocketOffMessage,
    WX_UDPSocketOnClose,
    WX_UDPSocketOnError,
    WX_UDPSocketOnListening,
    WX_UDPSocketOnMessage,
    WX_UDPSocketSendString,
    WX_UDPSocketSendBuffer,
    WX_UDPSocketSetTTL,
    WX_UDPSocketWrite,
    WX_RegisterUDPSocketOnMessageCallback,
};
