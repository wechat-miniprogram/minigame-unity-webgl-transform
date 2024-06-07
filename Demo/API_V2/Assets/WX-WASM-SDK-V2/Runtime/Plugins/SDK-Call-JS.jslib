mergeInto(LibraryManager.library, {
WX_OneWayFunction:function(functionName, successType, failType, completeType, conf, callbackId) {
    window.WXWASMSDK.WX_OneWayFunction(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(successType), _WXPointer_stringify_adaptor(failType), _WXPointer_stringify_adaptor(completeType), _WXPointer_stringify_adaptor(conf), _WXPointer_stringify_adaptor(callbackId));
},
WX_OneWayNoFunction_v: function (functionName) {
    window.WXWASMSDK.WX_OneWayNoFunction_v(_WXPointer_stringify_adaptor(functionName));
},
WX_OneWayNoFunction_vs: function (functionName, param1) {
    window.WXWASMSDK.WX_OneWayNoFunction_vs(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1));
},
WX_OneWayNoFunction_vt: function (functionName, param1) {
    window.WXWASMSDK.WX_OneWayNoFunction_vt(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1));
},
WX_OneWayNoFunction_vst: function (functionName, param1, param2) {
    window.WXWASMSDK.WX_OneWayNoFunction_vst(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1), _WXPointer_stringify_adaptor(param2));
},
WX_OneWayNoFunction_vsn: function (functionName, param1, param2) {
    window.WXWASMSDK.WX_OneWayNoFunction_vsn(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1), param2);
},
WX_OneWayNoFunction_vnns: function (functionName, param1, param2, param3) {
    window.WXWASMSDK.WX_OneWayNoFunction_vnns(_WXPointer_stringify_adaptor(functionName), param1, param2, _WXPointer_stringify_adaptor(param3));
},
WX_OnEventRegister:function(functionName, resType) {
    window.WXWASMSDK.WX_OnEventRegister(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(resType));
},

WX_OffEventRegister:function(functionName) {
    window.WXWASMSDK.WX_OffEventRegister(_WXPointer_stringify_adaptor(functionName));
},
WX_OnAddToFavorites:function() {
    window.WXWASMSDK.WX_OnAddToFavorites();
},
WX_OffAddToFavorites:function() {
    window.WXWASMSDK.WX_OffAddToFavorites();
},
WX_OnAddToFavorites_Resolve:function(conf){
    window.WXWASMSDK.WX_OnAddToFavorites_Resolve(_WXPointer_stringify_adaptor(conf));
},
WX_OnCopyUrl:function() {
    window.WXWASMSDK.WX_OnCopyUrl();
},
WX_OffCopyUrl:function() {
    window.WXWASMSDK.WX_OffCopyUrl();
},
WX_OnCopyUrl_Resolve:function(conf){
    window.WXWASMSDK.WX_OnCopyUrl_Resolve(_WXPointer_stringify_adaptor(conf));
},
WX_OnHandoff:function() {
    window.WXWASMSDK.WX_OnHandoff();
},
WX_OffHandoff:function() {
    window.WXWASMSDK.WX_OffHandoff();
},
WX_OnHandoff_Resolve:function(conf){
    window.WXWASMSDK.WX_OnHandoff_Resolve(_WXPointer_stringify_adaptor(conf));
},
WX_OnShareTimeline:function() {
    window.WXWASMSDK.WX_OnShareTimeline();
},
WX_OffShareTimeline:function() {
    window.WXWASMSDK.WX_OffShareTimeline();
},
WX_OnShareTimeline_Resolve:function(conf){
    window.WXWASMSDK.WX_OnShareTimeline_Resolve(_WXPointer_stringify_adaptor(conf));
},
WX_OnGameLiveStateChange:function() {
    window.WXWASMSDK.WX_OnGameLiveStateChange();
},
WX_OffGameLiveStateChange:function() {
    window.WXWASMSDK.WX_OffGameLiveStateChange();
},
WX_OnGameLiveStateChange_Resolve:function(conf){
    window.WXWASMSDK.WX_OnGameLiveStateChange_Resolve(_WXPointer_stringify_adaptor(conf));
},

WX_SyncFunction_bs: function(functionName, param1){
    return window.WXWASMSDK.WX_SyncFunction_bs(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1));
},
WX_SyncFunction_t: function(functionName, returnType){
    var res = window.WXWASMSDK.WX_SyncFunction_t(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(returnType));
    var bufferSize = lengthBytesUTF8(res || '') + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8((res || ''), buffer, bufferSize);
    return buffer; 
},
WX_SyncFunction_tt: function(functionName, returnType, param1){
    var res = window.WXWASMSDK.WX_SyncFunction_tt(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(returnType), _WXPointer_stringify_adaptor(param1));
    var bufferSize = lengthBytesUTF8(res || '') + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8((res || ''), buffer, bufferSize);
    return buffer;
},
WX_SyncFunction_b: function(functionName){
    return window.WXWASMSDK.WX_SyncFunction_b(_WXPointer_stringify_adaptor(functionName));
},
WX_SyncFunction_bsnn: function(functionName, param1, param2, param3){
    return window.WXWASMSDK.WX_SyncFunction_bsnn(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1), param2, param3);
},
WX_SyncFunction_bt: function(functionName, param1){
    return window.WXWASMSDK.WX_SyncFunction_bt(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1));
},
WX_SyncFunction_nt: function(functionName, param1){
    return window.WXWASMSDK.WX_SyncFunction_nt(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1));
},
WX_SyncFunction_ss: function(functionName, param1){
    var res = window.WXWASMSDK.WX_SyncFunction_ss(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(param1));
    var bufferSize = lengthBytesUTF8(res || '') + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8((res || ''), buffer, bufferSize);
    return buffer;
},
WX_ClassOneWayFunction:function(functionName, returnType, successType, failType, completeType, conf) {
    var res = window.WXWASMSDK.WX_ClassOneWayFunction(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(returnType), _WXPointer_stringify_adaptor(successType), _WXPointer_stringify_adaptor(failType), _WXPointer_stringify_adaptor(completeType), _WXPointer_stringify_adaptor(conf));
    var bufferSize = lengthBytesUTF8(res || '') + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8((res || ''), buffer, bufferSize);
    return buffer;
},
WX_ClassFunction: function(functionName, returnType, option) {
    var res = window.WXWASMSDK.WX_ClassFunction(_WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(returnType), _WXPointer_stringify_adaptor(option));
    var bufferSize = lengthBytesUTF8(res || '') + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8((res || ''), buffer, bufferSize);
    return buffer;
},
WX_ClassSetProperty: function(className, id, key, value) {
  window.WXWASMSDK.WX_ClassSetProperty(_WXPointer_stringify_adaptor(className), _WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key), _WXPointer_stringify_adaptor(value));
},
WX_ClassOnEventFunction: function(className, functionName, returnType, id, eventName) {
    window.WXWASMSDK.WX_ClassOnEventFunction(_WXPointer_stringify_adaptor(className), _WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(returnType), _WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(eventName));
},WX_ClassOffEventFunction: function(className, functionName, id, eventType) {
    window.WXWASMSDK.WX_ClassOffEventFunction(_WXPointer_stringify_adaptor(className), _WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(eventType));
},WX_ClassOneWayNoFunction_v: function(className, functionName, id) {
    window.WXWASMSDK.WX_ClassOneWayNoFunction_v(_WXPointer_stringify_adaptor(className), _WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(id));
},
WX_ClassOneWayNoFunction_vs: function(className, functionName, id, param1) {
    window.WXWASMSDK.WX_ClassOneWayNoFunction_vs(_WXPointer_stringify_adaptor(className), _WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(param1));
},
WX_ClassOneWayNoFunction_t: function(className, functionName, returnType, id) {
    var res = window.WXWASMSDK.WX_ClassOneWayNoFunction_t(_WXPointer_stringify_adaptor(className), _WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(returnType), _WXPointer_stringify_adaptor(id));
    var bufferSize = lengthBytesUTF8(res || '') + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8((res || ''), buffer, bufferSize);
    return buffer;
},
WX_ClassOneWayNoFunction_vt: function(className, functionName, id, param1) {
    window.WXWASMSDK.WX_ClassOneWayNoFunction_vt(_WXPointer_stringify_adaptor(className), _WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(param1));
},
WX_ClassOneWayNoFunction_vn: function(className, functionName, id, param1) {
    window.WXWASMSDK.WX_ClassOneWayNoFunction_vs(_WXPointer_stringify_adaptor(className), _WXPointer_stringify_adaptor(functionName), _WXPointer_stringify_adaptor(id), param1);
},
})