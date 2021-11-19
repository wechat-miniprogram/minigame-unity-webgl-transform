mergeInto(LibraryManager.library, {
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
});
