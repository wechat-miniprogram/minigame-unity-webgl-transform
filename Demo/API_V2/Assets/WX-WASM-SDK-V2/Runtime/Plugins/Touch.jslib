var WXTouchLibrary = 
{
  WX_OnTouchCancel: function() {
      window.WXWASMSDK.WX_OnTouchCancel();
  },
  WX_OffTouchCancel: function() {
      window.WXWASMSDK.WX_OffTouchCancel();
  },
  WX_OnTouchEnd: function() {
      window.WXWASMSDK.WX_OnTouchEnd();
  },
  WX_OffTouchEnd: function() {
      window.WXWASMSDK.WX_OffTouchEnd();
  },
  WX_OnTouchMove: function() {
      window.WXWASMSDK.WX_OnTouchMove();
  },
  WX_OffTouchMove: function() {
      window.WXWASMSDK.WX_OffTouchMove();
  },
  WX_OnTouchStart: function() {
      window.WXWASMSDK.WX_OnTouchStart();
  },
  WX_OffTouchStart: function() {
      window.WXWASMSDK.WX_OffTouchStart();
  },
  WX_RegisterOnTouchCancelCallback: function(callback) {
    window.WXWASMSDK.WX_RegisterOnTouchCancelCallback(callback);
  },
  WX_RegisterOnTouchEndCallback: function(callback) {
    window.WXWASMSDK.WX_RegisterOnTouchEndCallback(callback);
  },
  WX_RegisterOnTouchMoveCallback: function(callback) {
    window.WXWASMSDK.WX_RegisterOnTouchMoveCallback(callback);
  },
  WX_RegisterOnTouchStartCallback: function(callback) {
    window.WXWASMSDK.WX_RegisterOnTouchStartCallback(callback);
  },
};

mergeInto(LibraryManager.library, WXTouchLibrary);