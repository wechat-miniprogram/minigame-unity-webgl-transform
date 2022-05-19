using UnityEngine;
using System.Collections;

namespace WeChatWASM
{
    public class Rule
    {
        public string old;
        public string newStr;
    }

    public class ReplaceRules
    {
        public static Rule[] rules = {
       new Rule()
       {
           old=@"function *doRun\(\) *{",
           newStr="function doRun() {GameGlobal.unityNamespace.DO_RUN_START = Date.now();"
       },
       new Rule()
       {
           old=@"calledMain *= *true",
           newStr="calledMain = true;if(Module.calledMainCb){Module.calledMainCb()}"
       },
       new Rule()
       {
           old="self\\[\"performance\"\\]\\[\"now\"\\]",
           newStr="wx.getPerformance().now"
       },new Rule()
       {
           old="self\\[\"performance\"\\]",
           newStr="wx.getPerformance && wx.getPerformance()"
       },new Rule()
       {
           old="var IDBFS",
           newStr="var IDBFS = GameGlobal.unityNamespace.IDBFS"
       },
       new Rule()
       {
           old=@"return WebAssembly\.instantiate *\(binary *, *info\)",
           newStr="if(Module[\"wasmBin\"]){return WebAssembly.instantiate(Module[\"wasmBin\"], info);}return WebAssembly.instantiate(Module[\"wasmPath\"], info)"
       },
       new Rule()
       {
           old="var FS *=",
           newStr="var FS = GameGlobal.unityNamespace.FS="
       },
       new Rule()
       {
           old=@"t\.clientX *- *canvasRect\.left",
           newStr="(t.clientX - canvasRect.left) * window._ScaleRate * (canvas.width / window.innerWidth / devicePixelRatio)"
       },new Rule()
       {
           old=@"t\.clientY *- *canvasRect\.top", 
           newStr="(t.clientY - canvasRect.top) * window._ScaleRate * (canvas.height / window.innerHeight / devicePixelRatio)"
       },new Rule()
       {
           old=@"t\.clientX *- *targetRect\.left",
           newStr="(t.clientX - targetRect.left) * window._ScaleRate * (canvas.width / window.innerWidth / devicePixelRatio)"
       },new Rule()
       {
           old=@"t\.clientY *- *targetRect\.top",
           newStr="(t.clientY - targetRect.top) * window._ScaleRate * (canvas.height / window.innerHeight / devicePixelRatio)"
       },new Rule()
       {
           old=@"document\.URL",
           newStr="GameGlobal.unityNamespace.DATA_CDN || \"https://game.weixin.qq.com\""
       },new Rule()
       {
           old=@"canvas\.style\.setProperty *\(",
           newStr="if(canvas.style.setProperty)canvas.style.setProperty("
       },new Rule()
       {
           old=@"canvas\.style\.removeProperty *\(",
           newStr="if(canvas.style.removeProperty)canvas.style.removeProperty("
       },new Rule()
       {
           old="if *\\(!\\(Module\\[\"wasmMemory\"\\]",
           newStr="if(!Module.IsWxGame && !(Module[\"wasmMemory\"]"
       },
       new Rule()
       {
           old=@"function *getBinary *\( *\) *{",
           newStr="function getBinary() {return;"
       },new Rule()
       {
           old="\"_JS_Sound_Init\":_JS_Sound_Init",
           newStr="\"_JS_Sound_Init\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_Init"
       },new Rule()
       {
           old="\"_JS_Sound_Load\":_JS_Sound_Load",
           newStr="\"_JS_Sound_Load\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_Load"
       },new Rule()
       {
           old="addRunDependency\\(\"wasm-instantiate\"\\)",
           newStr="addRunDependency(\"wasm-instantiate\");addRunDependency(\"wasm-preloadAssets\");GameGlobal.unityNamespace.WASM_BEGIN_TIME = Date.now();"
       },new Rule()
       {
           old="removeRunDependency\\(\"wasm-instantiate\"\\)",
           newStr="if(Module.wasmInstantiated){Module.wasmInstantiated();removeRunDependency(\"wasm-instantiate\")}"
       },new Rule()
       {
           old="\"_JS_Sound_Create_Channel\":_JS_Sound_Create_Channel",
           newStr="\"_JS_Sound_Create_Channel\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_Create_Channel"
       },new Rule()
       {
           old="\"_JS_Sound_Play\":_JS_Sound_Play",
           newStr="\"_JS_Sound_Play\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_Play"
       },new Rule()
       {
           old="\"_JS_Sound_SetLoop\":_JS_Sound_SetLoop",
           newStr="\"_JS_Sound_SetLoop\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_SetLoop"
       },new Rule()
       {
           old="\"_JS_Sound_Set3D\":_JS_Sound_Set3D",
           newStr="\"_JS_Sound_Set3D\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_Set3D"
       },new Rule()
       {
           old="\"_JS_Sound_Stop\":_JS_Sound_Stop",
           newStr="\"_JS_Sound_Stop\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_Stop"
       },new Rule()
       {
           old="\"_JS_Sound_SetVolume\":_JS_Sound_SetVolume",
           newStr="\"_JS_Sound_SetVolume\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_SetVolume"
       },new Rule()
       {
           old="\"_JS_Sound_SetPitch\":_JS_Sound_SetPitch",
           newStr="\"_JS_Sound_SetPitch\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_SetPitch"
       },new Rule()
       {
           old="\"_JS_Sound_GetLoadState\":_JS_Sound_GetLoadState",
           newStr="\"_JS_Sound_GetLoadState\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_GetLoadState"
       },new Rule()
       {
           old="\"_JS_Sound_ResumeIfNeeded\":_JS_Sound_ResumeIfNeeded",
           newStr="\"_JS_Sound_ResumeIfNeeded\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_ResumeIfNeeded"
       },new Rule()
       {
           old="\"_JS_Sound_GetLength\":_JS_Sound_GetLength",
           newStr="\"_JS_Sound_GetLength\":GameGlobal.unityNamespace.UnityAdapter._JS_Sound_GetLength"
       },new Rule()
       {
           old="assert\\(typeof Module\\[\"pthreadMainPrefixURL\"\\]",
           newStr="// assert(typeof Module[\"pthreadMainPrefixURL\"]"
       },new Rule()
       {
           old="http\\.open\\( *_method *, *_url *, *true *\\);",
           newStr="var http = new GameGlobal.unityNamespace.UnityLoader.UnityCache.XMLHttpRequest();http.open(_method, _url, true);"
       },
       new Rule()
        {
            old=@"var *Browser *=",
            newStr="var Browser = GameGlobal.unityNamespace.Browser ="
        },
        new Rule()
        {
            old="safeSetInterval: *\\( *function *\\(func, *timeout\\) *{[\\s\\S]*?Module\\[\"noExitRuntime\"\\] *= *true;",
            newStr="safeSetInterval: (function(func, timeout) {Module[\"noExitRuntime\"] = true;if (!GameGlobal.unityNamespace.isLoopRunnerEnable) return;"
        },
       new Rule()
       {
           old=@"_emscripten_set_main_loop_timing\(1, *1\)",
           newStr="_emscripten_set_main_loop_timing(1, 1);if (!GameGlobal.unityNamespace.isLoopRunnerEnable) return;"
       },
       new Rule(){
           old="\"parent\": *Module\\b",
           newStr="\"parent\": Module,wx:{ignore_opt_glue_apis:[\"_glGenTextures\",\"_glBindTexture\",\"_glDeleteTextures\",\"_glFramebufferTexture2D\",\"_glIsTexture\",\"_glCompressedTexImage2D\",\"_glGetString\"]}"
       },
      new Rule(){
          old = @"_emscripten_webgl_create_context\(\) *{",
          newStr="_emscripten_webgl_create_context(){setTimeout(function(){WXWASMSDK.canvasContext && WXWASMSDK.canvasContext._triggerCallback();},0);"
      },
      new Rule(){
          old = "throw\"abort",
          newStr = "if(Module.IsWxGame)window.WXWASMSDK.WXUncaughtException(true);else throw\"abort"
      },
      new Rule(){
          old = @"console.error\(",
          newStr = "err("
      },
#if UNITY_2020
       new Rule()
       {
           old="FileSystem_Initialize\\(\\) *{",
           newStr="FileSystem_Initialize(){if (!Module.indexedDB) return;"
       },
       new Rule()
       {
           old="_JS_FileSystem_Sync\\(\\) *{",
           newStr="_JS_FileSystem_Sync(){if (!Module.indexedDB) return;"
       },
       new Rule()
       {
           old="Module.SystemInfo",
           newStr="UnityLoader.SystemInfo"
       },
       new Rule()
       {
            old=@"GetStreamingAssetsURL\(buffer, *bufferSize\) *{",
            newStr="GetStreamingAssetsURL(buffer,bufferSize){if(Module.IsWxGame) Module.streamingAssetsUrl=GameGlobal.unityNamespace.DATA_CDN + \"StreamingAssets\";"
       },

#endif
#if UNITY_2021
       new Rule()
       {
           old="if *\\(buffer.buffer *=== *HEAP8.buffer",
           newStr="if (!Module.IsWxGame && buffer.buffer === HEAP8.buffer"
       },
       new Rule()
       {
           old="return ext.getSupportedProfiles\\(",
           newStr="return Module.IsWxGame ? false:ext.getSupportedProfiles("
       },
       new Rule()
       {
           old="function UTF8ToString",
           newStr="function Pointer_stringify(ptr){return UTF8ToString(ptr)}function UTF8ToString"
       },
       new Rule()
       {
           old=@"var result *= *WebAssembly\.instantiate *\(binary *, *info\)",
           newStr="if(Module[\"wasmBin\"]){return WebAssembly.instantiate(Module[\"wasmBin\"], info);}return WebAssembly.instantiate(Module[\"wasmPath\"], info)"
       },

       new Rule()
       {
           old="if *\\(readAsync",
           newStr="if (readAsync && !Module.IsWxGame"
       },
         new Rule()
       {
           old="return ver",
           newStr="if(Module.IsWxGame)return gl;return ver"
       },
       new Rule()
       {
           old="Module.SystemInfo",
           newStr="UnityLoader.SystemInfo"
       },
       new Rule()
       {
           old="FileSystem_Initialize\\(\\) *{",
           newStr="FileSystem_Initialize(){if (!Module.indexedDB) return;"
       },
        new Rule()
       {
           old="return JSEvents.lastGamepadState",
           newStr="return Module.IsWxGame ? 0 : JSEvents.lastGamepadState"
       },
       new Rule()
       {
           old="fs.sync\\(false\\)",
           newStr="if(Module.IsWxGame)return;fs.sync(false)"
       },
       new Rule()
       {
           old=@"function *getBinary *\(file *\) *{",
           newStr="function getBinary(file) {return;"
       },
       new Rule()
       {
            old=@"GetStreamingAssetsURL\(buffer, *bufferSize\) *{",
            newStr="GetStreamingAssetsURL(buffer,bufferSize){if(Module.IsWxGame) Module.streamingAssetsUrl=GameGlobal.unityNamespace.DATA_CDN + \"StreamingAssets\";"
       },
       new Rule()
       {

           old="abort\\(\"randomDevice\"\\)",           
           newStr="if(Module.IsWxGame)return Math.random()*256|0;abort(\"randomDevice\")"
       },
       new Rule()
       {
           old="!Module\\[\"canvas\"\\].id",
           newStr="!Module.IsWxGame && !Module[\"canvas\"].id"
       },
       new Rule()
       {
           old="typeof allocator === \"number\"",
           newStr="true"
       },
       new Rule()
       {
           old="typeof slab !== \"number\"",
           newStr="true"
       }
#endif
    };
    }

}


