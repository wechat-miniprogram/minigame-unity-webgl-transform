var WXTouchLibrary = 
{
  $WXTouchManager: 
  {
    onTouchMove: null,
  }, 

  WXSetOnTouchMove: function (callback) {
    WXTouchManager.onTouchMove = callback;
  },
};

autoAddDeps(WXTouchLibrary, '$WXTouchManager');
mergeInto(LibraryManager.library, WXTouchLibrary);