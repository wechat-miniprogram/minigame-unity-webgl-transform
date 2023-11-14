mergeInto(LibraryManager.library, {
  _WXPointer_stringify_adaptor:function(str){
    if (typeof UTF8ToString !== "undefined") {
        return UTF8ToString(str)
    }
    return Pointer_stringify(str)
  },
  DumpUICallback: function (str) {
    if(typeof GameGlobal!='undefined'){
      GameGlobal.monkeyCallback(_WXPointer_stringify_adaptor(str));
    }
  },
  GetScreenSizeCallback: function(width, height){
    if(typeof GameGlobal!='undefined'){
      GameGlobal.monkeyCallback([width, height]);
    }
  },
  GetUnityVersionCallback: function(version){
    if(typeof GameGlobal!='undefined'){
      GameGlobal.monkeyCallback(_WXPointer_stringify_adaptor(version));
    }
  },
  GetUnityFrameRateCallback: function(rate){
    if(typeof GameGlobal!='undefined'){
      GameGlobal.monkeyCallback(rate)
    }
  },
  GetUnityCacheDetailCallback: function(str) {
    if(typeof GameGlobal!='undefined'){
      GameGlobal.monkeyCallback(_WXPointer_stringify_adaptor(str));
    }
  },
  SetUnityUIType: function(str){
    if(typeof GameGlobal!='undefined'){
      GameGlobal.UnityUIType = _WXPointer_stringify_adaptor(str);
    }
  },
  DumpProfileStatsCallback: function(str){
     if(typeof GameGlobal!='undefined') {
       GameGlobal.monkeyCallback(_WXPointer_stringify_adaptor(str));
     }
  }
});
