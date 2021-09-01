mergeInto(LibraryManager.library, {
  DumpUICallback: function (str) {
    GameGlobal.monkeyCallback(Pointer_stringify(str));
  },
  GetScreenSizeCallback: function(width, height){
    GameGlobal.monkeyCallback([width, height]);
  },
  GetUnityVersionCallback: function(version){
    GameGlobal.monkeyCallback(Pointer_stringify(version));
  },
  GetUnityFrameRateCallback: function(rate){
    GameGlobal.monkeyCallback(rate)
  },
  GetUnityCacheDetailCallback: function(str) {
    GameGlobal.monkeyCallback(Pointer_stringify(str));
  },
  SetUnityUIType: function(str){
    GameGlobal.UnityUIType = Pointer_stringify(str);
  },
});