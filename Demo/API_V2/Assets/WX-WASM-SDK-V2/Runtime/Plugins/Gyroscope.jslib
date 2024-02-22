var WXGyroscopeLibrary = 
{
    WX_StartGyroscope: function(callbackId, option) {
        window.WXWASMSDK.WX_StartGyroscope(_WXPointer_stringify_adaptor(callbackId), _WXPointer_stringify_adaptor(option));
    },
    WX_StopGyroscope: function(callbackId) {
        window.WXWASMSDK.WX_StopGyroscope(_WXPointer_stringify_adaptor(callbackId));
    },
    WX_OnGyroscopeChange: function() {
        window.WXWASMSDK.WX_OnGyroscopeChange();
    },
    WX_OffGyroscopeChange: function() {
        window.WXWASMSDK.WX_OffGyroscopeChange();
    },
    WX_RegisterStartGyroscopeCallback: function(callback) {
        window.WXWASMSDK.WX_RegisterStartGyroscopeCallback(callback);
    },
    WX_RegisterStopGyroscopeCallback: function(callback) {
        window.WXWASMSDK.WX_RegisterStopGyroscopeCallback(callback);
    },
    WX_RegisterOnGyroscopeChangeCallback: function(callback) {
        window.WXWASMSDK.WX_RegisterOnGyroscopeChangeCallback(callback);
    },
};

mergeInto(LibraryManager.library, WXGyroscopeLibrary);