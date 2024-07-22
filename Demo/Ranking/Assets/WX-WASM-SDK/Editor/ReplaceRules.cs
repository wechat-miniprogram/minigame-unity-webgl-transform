﻿using UnityEngine;
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
            newStr="function doRun() {GameGlobal.manager.TimeLogger.timeStart(\"callMain耗时\");"
       },
       new Rule()
       {
           old=@"calledMain *= *true",
           newStr="if(ABORT===true)return;calledMain = true;if(Module.calledMainCb){Module.calledMainCb()};if (GameGlobal.unityNamespace.enableProfileStats) {setTimeout(() => {SendMessage('WXSDKManagerHandler', 'OpenProfileStats');}, 30000);}"
       },
       new Rule()
       {
           old="self\\[\"performance\"\\]\\[\"now\"\\]",
           newStr="performance.now"
       }
       ,new Rule()
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
            old="new *\\(window.AudioContext*\\|*\\|window.webkitAudioContext\\)",
            newStr="createWebAudio()"
       },
       new Rule()
       {
            old="context.createScriptProcessor*\\(*\\$1,0",
            newStr="context.createScriptProcessor($1,1"
       },
       new Rule()
       {
            old="eval*\\(UTF8ToString*\\(ptr*\\)*\\)",
            newStr="/*eval(UTF8ToString(ptr))*/"
       },
       new Rule()
       {
            old="window.addEventListener*\\(\"touchend\",OutputWebAudio_resumeAudio,false*\\);window.addEventListener*\\(\"click\",OutputWebAudio_resumeAudio,false*\\)",
            newStr="/*window.addEventListener(\"touchend\",OutputWebAudio_resumeAudio,false);window.addEventListener(\"click\",OutputWebAudio_resumeAudio,false)*/",
       },
       new Rule()
       {
            old="window.removeEventListener*\\(\"click\",OutputWebAudio_resumeAudio,false*\\);window.removeEventListener*\\(\"touchend\",OutputWebAudio_resumeAudio,false*\\)",
            newStr="/*window.removeEventListener(\"click\",OutputWebAudio_resumeAudio,false);window.removeEventListener(\"touchend\",OutputWebAudio_resumeAudio,false)*/",
       },
       new Rule()
       {
            old="window.removeEventListener*\\(\"click\",OutputAudioWorklet_resumeAudio,false*\\);window.removeEventListener*\\(\"touchend\",OutputAudioWorklet_resumeAudio,false*\\)",
            newStr="/*window.removeEventListener(\"click\",OutputAudioWorklet_resumeAudio,false);window.removeEventListener(\"touchend\",OutputAudioWorklet_resumeAudio,false)*/",
       },
       new Rule()
       {
            old="window.addEventListener*\\(\"touchend\",OutputAudioWorklet_resumeAudio,false*\\);window.addEventListener*\\(\"click\",OutputAudioWorklet_resumeAudio,false*\\)",
            newStr="/*window.addEventListener(\"touchend\",OutputAudioWorklet_resumeAudio,false);window.addEventListener(\"click\",OutputAudioWorklet_resumeAudio,false)*/",
       },
       new Rule()
       {
            old="scriptDirectory=self.location.href",
            newStr="scriptDirectory=this.location.href",
       },
       new Rule()
       {
            old="self.AudioWorkletNode",
            newStr="this.AudioWorkletNode",
       },
       new Rule()
       {
            old="self.SharedArrayBuffer",
            newStr="this.SharedArrayBuffer",
       },
       new Rule()
       {
            old="self.crossOriginIsolated",
            newStr="this.crossOriginIsolated",
       },
       // ----MemoryProfiler Begin-----//
       new Rule()
       {
           old="(new Error).stack.toString()",
           newStr="\"\""
       },
       new Rule()
       {
           old="if *\\(location.search.toLowerCase",
           newStr="return; if(location.search.toLowerCase"
       },
       new Rule()
       {
           old="if *\\(this.hookStackAlloc",
           newStr="return;if(this.hookStackAlloc"
       },
       new Rule()
       {
           old="allocateStatistics: *false",
           newStr="allocateStatistics: true"
       },
       new Rule()
       {
           old="this.allocationSiteStatistics\\[str\\] *= *\\[0, *0\\]",
           newStr="this.allocationSiteStatistics[str] = [0, 0, 0, 0];this.allocationSiteStatistics[str][2] += 1;"
       },
       new Rule()
       {
           old="this.allocationSiteStatistics\\[str\\]\\[1\\] *-= *sz",
           newStr="this.allocationSiteStatistics[str][1] -= sz;this.allocationSiteStatistics[str][3] += 1;"
       },
       // ----MemoryProfiler End-----//
#if !UNITY_2021
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
       },
#endif
       new Rule()
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
           old="addRunDependency\\(\"wasm-instantiate\"\\)",
           newStr="addRunDependency(\"wasm-instantiate\");addRunDependency(\"wasm-preloadAssets\");GameGlobal.manager.TimeLogger.timeStart(\"wasm编译耗时\");"
       },new Rule()
       {
           old="removeRunDependency\\(\"wasm-instantiate\"\\)",
           newStr="if(Module.wasmInstantiated){Module.wasmInstantiated();removeRunDependency(\"wasm-instantiate\")}"
       },
       new Rule()
       {
           old="var runDependencies",
           newStr="var runDependencies = GameGlobal.unityNamespace.runDependencies"
       },
       new Rule()
       {
           old=@"function *addRunDependency *\(id\) *{",
           newStr="function addRunDependency(id) {console.log(\"addRunDependency: \", id);"
       },
       new Rule()
       {
           old=@"function *removeRunDependency *\(id\) *{",
           newStr="function removeRunDependency(id) {console.log(\"removeRunDependency: \", id);"
       },
       new Rule()
       {
           old=": *_JS_Sound_Create_Channel",
          newStr=":window.WXWASMSDK._JS_Sound_Create_Channel"
       },
       new Rule()
       {
           old=": *_JS_Sound_GetLength",
           newStr=":window.WXWASMSDK._JS_Sound_GetLength"
       },new Rule()
       {
           old=": *_JS_Sound_GetLoadState",
           newStr=":window.WXWASMSDK._JS_Sound_GetLoadState"
       },new Rule()
       {
           old=": *_JS_Sound_Init",
           newStr=":window.WXWASMSDK._JS_Sound_Init"
       },new Rule()
       {
           old=": *_JS_Sound_Load",
           newStr=":window.WXWASMSDK._JS_Sound_Load"
       },new Rule()
       {
          old=": *_JS_Sound_Load_PCM",
          newStr=":window.WXWASMSDK._JS_Sound_Load_PCM"
       },new Rule()
       {
           old=": *_JS_Sound_Play",
          newStr=":window.WXWASMSDK._JS_Sound_Play"
       },new Rule()
       {
           old=": *_JS_Sound_ReleaseInstance",
          newStr=":window.WXWASMSDK._JS_Sound_ReleaseInstance"
       },       new Rule()
       {
          old=": *_JS_Sound_ResumeIfNeeded",
          newStr=":window.WXWASMSDK._JS_Sound_ResumeIfNeeded"
       },new Rule()
       {
          old=": *_JS_Sound_Set3D",
           newStr=":window.WXWASMSDK._JS_Sound_Set3D"
       },new Rule()
       {
           old=": *_JS_Sound_SetListenerOrientation",
           newStr=":window.WXWASMSDK._JS_Sound_SetListenerOrientation"
       },new Rule()
       {
           old=": *_JS_Sound_SetListenerPosition",
          newStr=":window.WXWASMSDK._JS_Sound_SetListenerPosition"
       },
       new Rule()
       {
           old=": *_JS_Sound_SetLoop",
           newStr=":window.WXWASMSDK._JS_Sound_SetLoop"
       },new Rule()
       {
           old=": *_JS_Sound_SetLoopPoints",
           newStr=":window.WXWASMSDK._JS_Sound_SetLoopPoints"
       },new Rule()
       {
           old=": *_JS_Sound_SetPaused",
           newStr=":window.WXWASMSDK._JS_Sound_SetPaused"
       },new Rule()
       {
           old=": *_JS_Sound_SetPitch",
           newStr=":window.WXWASMSDK._JS_Sound_SetPitch"
       },new Rule()
       {
           old=": *_JS_Sound_SetPosition",
           newStr=":window.WXWASMSDK._JS_Sound_SetPosition"
       },new Rule()
       {
           old=": *_JS_Sound_SetVolume",
           newStr=":window.WXWASMSDK._JS_Sound_SetVolume"
       },new Rule(){
           old=": *_JS_Sound_Stop",
           newStr=":window.WXWASMSDK._JS_Sound_Stop"
       },new Rule()
       {
           old="assert\\(typeof Module\\[\"pthreadMainPrefixURL\"\\]",
           newStr="// assert(typeof Module[\"pthreadMainPrefixURL\"]"
       },new Rule()
        {
            old=@"var *Browser *=",

            newStr="var Browser = GameGlobal.unityNamespace.Browser ="
        },new Rule()
        {
            old="safeSetInterval: *\\( *function *\\(func, *timeout\\) *{[\\s\\S]*?Module\\[\"noExitRuntime\"\\] *= *true;",
            newStr="safeSetInterval: (function(func, timeout) {Module[\"noExitRuntime\"] = true;if (!GameGlobal.unityNamespace.isLoopRunnerEnable) return;"
        },new Rule()
       {
           old=@"_emscripten_set_main_loop_timing\(1, *1\)",
           newStr="_emscripten_set_main_loop_timing(1, 1);if (!GameGlobal.unityNamespace.isLoopRunnerEnable) return;"
       },new Rule(){
           old="\"parent\": *Module\\b",
           newStr="\"parent\": Module,wx:{ignore_opt_glue_apis:[\"_glGenTextures\",\"_glBindTexture\",\"_glDeleteTextures\",\"_glFramebufferTexture2D\",\"_glIsTexture\",\"_glCompressedTexImage2D\",\"_glGetString\"]}"
       },new Rule(){
           old="info={\"a\":asmLibraryArg}",
           newStr="info={\"a\":asmLibraryArg,\"wx\":{ignore_opt_glue_apis:[\"glGenTextures\",\"glBindTexture\",\"glDeleteTextures\",\"glFramebufferTexture2D\",\"glIsTexture\",\"glCompressedTexImage2D\",\"glGetString\"]}}"
       },new Rule(){
          old = "GL.createContext\\(([^)]+)\\);",
          newStr="GL.createContext($1);WXWASMSDK.canvasContext && WXWASMSDK.canvasContext._triggerCallback();"
      },new Rule(){
          old = "throw\"abort",
          newStr = "if(Module.IsWxGame)window.WXWASMSDK.WXUncaughtException(true);else throw\"abort"
      },
      new Rule(){
          old = "err\\(\"Looks like",
          newStr = "console.warn(\"Looks like"
      },
      new Rule(){
          old = "case 4:console.error",
          newStr = "case 4:if(str.startsWith('An abnormal situation')){if(GameGlobal.logAbNormalOnce!=undefined)return;GameGlobal.logAbNormalOnce=1;}if(str.indexOf('is corrupted! Remove it and launch unity again!')>-1){return;}console.error"
      },
      new Rule(){
          old = @"console.error\(",
          newStr = "err("
      },
      new Rule(){
          old = "Module\\[\"ccall\"\\] *=",
          newStr = " Module['GL'] = GL; Module['ccall'] ="
      },
      new Rule(){
          old = "var exts *= *GLctx\\.getSupportedExtensions\\(\\)( *\\|\\| *\\[\\])?;",
          newStr = "var exts = GLctx.getSupportedExtensions() || [];GameGlobal.USED_TEXTURE_COMPRESSION && exts.push('WEBGL_compressed_texture_etc1');"
      },
      new Rule(){
          old = "Browser.mainLoop.runIter",
          newStr = "if(GameGlobal.manager.isVisible) Browser.mainLoop.runIter"
      },
      new Rule(){
          old = "function _glTexStorage2D\\(x0, *x1, *x2, *x3, *x4\\) *{",
          newStr = "function _glTexStorage2D(x0, x1, x2, x3, x4) {window._lastTexStorage2DParams = [x0, x1, x2, x3, x4];if(x2 == 36196){return;}"
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
            newStr="GetStreamingAssetsURL(buffer,bufferSize){if(Module.IsWxGame) Module.streamingAssetsUrl=Module.resolveBuildUrl(\"StreamingAssets\");"
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
           old=@"function *_emscripten_get_num_gamepads *\( *\) *{",
           newStr="function _emscripten_get_num_gamepads(){ if(Module.IsWxGame)return 0;"
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
            newStr="GetStreamingAssetsURL(buffer,bufferSize){if(Module.IsWxGame) Module.streamingAssetsUrl=Module.resolveBuildUrl(\"StreamingAssets\");"
       },
       new Rule()
       {

           old="abort\\(\"randomDevice\"\\)",
           newStr="if(Module.IsWxGame)return Math.random()*256|0;abort(\"randomDevice\")"
       },
       new Rule()
       {
           old=@"function *getRandomDevice *\( *\) *{",
           newStr="function getRandomDevice(){ if(Module.IsWxGame)return function () {return Math.random() * 256 | 0};"
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
       },
       new Rule()
       {
           old="var message=\"abort",
          newStr="if(Module.IsWxGame)window.WXWASMSDK.WXUncaughtException(true);var message=\"abort"
       },
       new Rule()
       {
          old="what=\"abort",
          newStr="if(Module.IsWxGame)window.WXWASMSDK.WXUncaughtException(true);what=\"abort"
       },
       new Rule()
       {
          old="self.allocationsAtLoc\\[loc\\] *= *\\[ *0, *0, *self.filterCallstackForMalloc\\(loc\\)\\]",
          newStr="self.allocationsAtLoc[loc] = [0, 0, 0, 0];"
       },
       new Rule()
       {
          old="self.allocationSitePtrs\\[ptr\\] *=",
          newStr="self.allocationsAtLoc[loc][2] += 1;self.allocationSitePtrs[ptr]="
       },
       new Rule()
       {
          old="allocsAtThisLoc\\[1\\] *-= *sz",
          newStr="allocsAtThisLoc[1] -= sz; allocsAtThisLoc[3] += 1;" 
       },
#endif
#if UNITY_2021_3_OR_NEWER
        new Rule()
        {
            old="new AbortController(\\(\\)|\\b);?",
            newStr="new GameGlobal.unityNamespace.UnityLoader.UnityCache.XMLHttpRequest();if(GameGlobal.TEXTURE_PARALLEL_BUNDLE){GameGlobal.ParalleLDownloadTexture(_url)}"
        },
        new Rule()
        {
            old="enableStreamingDownload: *true",
            newStr="enableStreamingDownload: false"
        },
        new Rule()
        {
            old="fetchImpl\\(",
            newStr="fetchImpl = abortController.openAndSend;fetchImpl("
        },
        new Rule()
        {
            old="requestOptions.init.body *= *new Blob\\(\\[ *postData *\\]\\)",
            newStr="requestOptions.init.body = postData"
        },
        new Rule(){
            old = "function HandleError\\(err, *code\\) *{",
            newStr = "function HandleError(err, code){ abortController.retryCount = abortController.retryCount || 0; if (typeof abortController !='undefined' && abortController.paramsCache.method === 'GET' && /\\b(settings|catalog)\\.json\\b/.test(abortController.paramsCache.url) && abortController.retryCount<2) {return setTimeout(function () {_reTryRequest(requestId, arg, onresponse)}, 1000);}"
        },
        new Rule()
        {
            old="function _JS_WebRequest_Send",
            newStr="function _reTryRequest(requestId,arg,onresponse,needRetry){var abortController = wr.abortControllers[requestId];abortController.retryCount = abortController.retryCount || 0;abortController.retryCount++;var xml=new GameGlobal.unityNamespace.UnityLoader.UnityCache.XMLHttpRequest();xml.open('GET',abortController.paramsCache.url,true);xml.responseType=abortController.responseType;xml.onload=function(){if(abortController.status>=400&&needRetry){setTimeout(function(){_reTryRequest(requestId,arg,onresponse)},1000);return false;}else{if(onresponse){var kWebRequestOK=0;var byteArray=new Uint8Array(xml.response);if(byteArray.length!=0){var buffer=_malloc(byteArray.length);HEAPU8.set(byteArray,buffer);dynCall('viiiiii',onresponse,[arg,xml.status,buffer,byteArray.length,0,kWebRequestOK])}else{dynCall('viiiiii',onresponse,[arg,xml.status,0,0,0,kWebRequestOK])}}}};xml.send(abortController.postData);xml.onerror=abortController.onerror;xml.ontimeout=abortController.ontimeout;xml.onabort=abortController.onabort;console.error('load url error:' + abortController.paramsCache.url);GameGlobal.logmanager.warn('load url error:'+abortController.paramsCache.url);GameGlobal.realtimeLogManager.error('load url error:'+abortController.paramsCache.url);} function _JS_WebRequest_Send"
        }
#else
        new Rule()
        {
            old = "function _JS_WebRequest_SetResponseHandler",
            newStr = "function _reTryRequest(request,arg,onresponse,needRetry){var http=wr.requestInstances[request];http.retryCount = http.retryCount || 0;http.retryCount++;var xml=new XMLHttpRequest();xml.open('GET',http.paramsCache.url,true);xml.responseType=http.responseType;xml.onload=function(){if(http.status>=400&&needRetry){setTimeout(function(){_reTryRequest(request,arg,onresponse)},1000);return false;}else{if(onresponse){var kWebRequestOK=0;var byteArray=new Uint8Array(xml.response);if(byteArray.length!=0){var buffer=_malloc(byteArray.length);HEAPU8.set(byteArray,buffer);dynCall('viiiiii',onresponse,[arg,xml.status,buffer,byteArray.length,0,kWebRequestOK])}else{dynCall('viiiiii',onresponse,[arg,xml.status,0,0,0,kWebRequestOK])}}}};xml.send(http.postData);xml.onerror=http.onerror;xml.ontimeout=http.ontimeout;xml.onabort=http.onabort;console.error('load url error:' + http.paramsCache.url);GameGlobal.logmanager.warn('load url error:'+http.paramsCache.url);GameGlobal.realtimeLogManager.error('load url error:'+http.paramsCache.url);} function _JS_WebRequest_SetResponseHandler"
        },
        new Rule(){
            old = "function HandleError\\(err, *code\\) *{",
            newStr = "function HandleError(err, code){ http.retryCount = http.retryCount || 0; if (typeof http !='undefined' && http.paramsCache.method === 'GET' && /\\b(settings|catalog)\\.json\\b/.test(http.paramsCache.url) && http.retryCount<2) {return setTimeout(function () {_reTryRequest(request, arg, onresponse)}, 1000);}"
        },
        new Rule(){
            old = "function http_onload\\(e\\) *{",
            newStr = "function http_onload(e){if(http.status>=400&&http.paramsCache.method==='GET'&&/\\b(settings|catalog)\\.json\\b/.test(http.paramsCache.url)){return _reTryRequest(request,arg,onresponse,true)}"
        },
        new Rule()
        {
            old="http\\.open\\( *_method *, *_url *, *true *\\);",
            newStr="if(GameGlobal.TEXTURE_PARALLEL_BUNDLE){GameGlobal.ParalleLDownloadTexture(_url)}var http = new GameGlobal.unityNamespace.UnityLoader.UnityCache.XMLHttpRequest();http.open(_method, _url, true);"
        }
#endif
    };
    }

}


