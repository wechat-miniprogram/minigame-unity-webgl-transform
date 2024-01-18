var WXTCPSocketLibrary = 
{
    WX_CreateTCPSocket:function() {
        var res = window.WXWASMSDK.WX_CreateTCPSocket();
        var bufferSize = lengthBytesUTF8(res || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_TCPSocketBindWifi:function(id, option) {
        window.WXWASMSDK.WX_TCPSocketBindWifi(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(option));
    },
    WX_TCPSocketClose:function(id) {
        window.WXWASMSDK.WX_TCPSocketClose(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketConnect:function(id, option) {
        window.WXWASMSDK.WX_TCPSocketConnect(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(option));
    },
    WX_TCPSocketWriteString:function(id, data) {
        window.WXWASMSDK.WX_TCPSocketWriteString(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(data));
    },
    WX_TCPSocketWriteBuffer:function(id, dataPtr, dataLength) {
        window.WXWASMSDK.WX_TCPSocketWriteBuffer(_WXPointer_stringify_adaptor(id), dataPtr, dataLength);
    },
    WX_TCPSocketOffBindWifi:function(id) {
        window.WXWASMSDK.WX_TCPSocketOffBindWifi(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOffClose:function(id) {
        window.WXWASMSDK.WX_TCPSocketOffClose(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOffConnect:function(id) {
        window.WXWASMSDK.WX_TCPSocketOffConnect(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOffError:function(id) {
        window.WXWASMSDK.WX_TCPSocketOffError(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOffMessage:function(id) {
        window.WXWASMSDK.WX_TCPSocketOffMessage(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOnBindWifi:function(id) {
        window.WXWASMSDK.WX_TCPSocketOnBindWifi(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOnClose:function(id) {
        window.WXWASMSDK.WX_TCPSocketOnClose(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOnConnect:function(id) {
        window.WXWASMSDK.WX_TCPSocketOnConnect(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOnError:function(id) {
        window.WXWASMSDK.WX_TCPSocketOnError(_WXPointer_stringify_adaptor(id));
    },
    WX_TCPSocketOnMessage:function(id, needInfo) {
        window.WXWASMSDK.WX_TCPSocketOnMessage(_WXPointer_stringify_adaptor(id), needInfo);
    },
    WX_RegisterTCPSocketOnMessageCallback:function(callback) {
        window.WXWASMSDK.WX_RegisterTCPSocketOnMessageCallback(callback);
    },
};

mergeInto(LibraryManager.library, WXTCPSocketLibrary);