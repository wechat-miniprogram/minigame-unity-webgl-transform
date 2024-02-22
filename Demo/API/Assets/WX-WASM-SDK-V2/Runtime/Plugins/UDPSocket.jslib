var WXUDPSocketLibrary = 
{
    WX_CreateUDPSocket:function() {
        var res = window.WXWASMSDK.WX_CreateUDPSocket();
        var bufferSize = lengthBytesUTF8(res || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_UDPSocketClose:function(id) {
        window.WXWASMSDK.WX_UDPSocketClose(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketConnect:function(id, option) {
        window.WXWASMSDK.WX_UDPSocketConnect(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(option));
    },
    WX_UDPSocketOffClose:function(id) {
        window.WXWASMSDK.WX_UDPSocketOffClose(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketOffError:function(id) {
        window.WXWASMSDK.WX_UDPSocketOffError(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketOffListening:function(id) {
        window.WXWASMSDK.WX_UDPSocketOffListening(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketOffMessage:function(id) {
        window.WXWASMSDK.WX_UDPSocketOffMessage(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketOnClose:function(id) {
        window.WXWASMSDK.WX_UDPSocketOnClose(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketOnError:function(id) {
        window.WXWASMSDK.WX_UDPSocketOnError(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketOnListening:function(id) {
        window.WXWASMSDK.WX_UDPSocketOnListening(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketOnMessage:function(id, needInfo) {
        window.WXWASMSDK.WX_UDPSocketOnMessage(_WXPointer_stringify_adaptor(id), needInfo);
    },
    WX_UDPSocketSendString:function(id, data, param) {
        window.WXWASMSDK.WX_UDPSocketSendString(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(data), _WXPointer_stringify_adaptor(param));
    },
    WX_UDPSocketSendBuffer:function(id, dataPtr, dataLength, param) {
        window.WXWASMSDK.WX_UDPSocketSendBuffer(_WXPointer_stringify_adaptor(id), dataPtr, dataLength, _WXPointer_stringify_adaptor(param));
    },
    WX_UDPSocketSetTTL:function(id, ttl) {
        window.WXWASMSDK.WX_UDPSocketSetTTL(_WXPointer_stringify_adaptor(id), ttl);
    },
    WX_UDPSocketWrite:function(id) {
        window.WXWASMSDK.WX_UDPSocketWrite(_WXPointer_stringify_adaptor(id));
    },
    WX_UDPSocketBind:function(id, port) {
        var res = window.WXWASMSDK.WX_UDPSocketBind(_WXPointer_stringify_adaptor(id), port);
        return res;
    },
    WX_RegisterUDPSocketOnMessageCallback:function(callback) {
        window.WXWASMSDK.WX_RegisterUDPSocketOnMessageCallback(callback);
    }
};

mergeInto(LibraryManager.library, WXUDPSocketLibrary);