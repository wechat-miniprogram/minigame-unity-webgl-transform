mergeInto(LibraryManager.library, {
    WXPointer_stringify_adaptor:function(str){
        if (typeof UTF8ToString !== "undefined") {
            return UTF8ToString(str)
        }
        return Pointer_stringify(str)
    },
    glGenTextures: function (n, textures) {
        for (var i = 0; i < n; i++) {
            var texture = GLctx.createTexture();
            if (!texture) {
                GL.recordError(1282);
                while (i < n) HEAP32[textures + i++ * 4 >> 2] = 0;
                return
            }
            var id = GL.getNewId(GL.textures);
            texture.name = id;
            GL.textures[id] = texture;
            window._lastTextureId = id;
            HEAP32[textures + i * 4 >> 2] = id
        }
    },
    glBindTexture:function(target, texture) {
        window._lastBoundTexture = texture;
        GLctx.bindTexture(target, texture ? GL.textures[texture] : null)
    },
    WXInitializeSDK: function (version) {
        window.WXWASMSDK.WXInitializeSDK(_WXPointer_stringify_adaptor(version));
        if (typeof emscriptenMemoryProfiler !== "undefined")  {
            GameGlobal.memprofiler = emscriptenMemoryProfiler
            GameGlobal.memprofiler.onDump = function () {
            var fs = wx.getFileSystemManager();
            var allocation_used=GameGlobal.memprofiler.allocationsAtLoc; 
            if (typeof allocation_used === "undefined") allocation_used=GameGlobal.memprofiler.allocationSiteStatistics;
            var calls = [];
            for (var i in allocation_used) {
                    calls.push(i);
            }
            calls.sort((function (a, b) {
                return allocation_used[b][1] - allocation_used[a][1];
            }));

            console.log('WXDumpUnityHeap begin', Object.keys(allocation_used).length, calls.length);
            wx.getFileSystemManager().open({
                filePath: wx.env.USER_DATA_PATH + '/alloc_used.csv',
                flag: 'w',
                success: function(res) {
                    var wxfile = res.fd;
                    fs.write({
                        fd: wxfile,
                        data:'callback;count;size;malloc;free\r\n',
                        fail: function(res) {
                            console.error(res);
                        }
                    })
                    var errorCount = 0;
                    for (var i = 0; i < 100000 && i < calls.length; ++i) {
                        var callstack = calls[i];
                        var item = allocation_used[callstack];
                        if (typeof item === "undefined") {
                            // console.error('callstack not fond', callstack);
                            ++errorCount;
                            continue
                        }
                        var posOfThisFunc = callstack.indexOf('emscripten_trace_record_') + "emscripten_trace_record_".length;
                        if (posOfThisFunc != -1) callstack = callstack.substr(posOfThisFunc);
                        var posOfRaf = callstack.lastIndexOf("InitWebGLPlayeriPPc ");
                        if (posOfRaf != -1) callstack = callstack.substr(0, posOfRaf);
                        posOfRaf = callstack.lastIndexOf("InitPlayerLoopCallbacks");
                        if (posOfRaf != -1) callstack = callstack.substr(0, posOfRaf);

                        callstack = callstack.replace(/\(.*?\)/g, '')
                        callstack = callstack.replace(/[A-Z0-9]{40}/g, '')
                        callstack = callstack.replace(/\n/g, "<-")
                        callstack = callstack.replace(/_malloc <-.*?MemLabelId15AllocateOptions/g, '')
                        callstack = callstack.replace(/<-    at dynCall.*?at invoke_/g, '')
                        fs.write({
                            fd: wxfile,
                            data: callstack + ';' + item[0] + ';' + item[1] + ';' + item[2] + ';' + item[3] + '\r\n',
                            fail: function(res) {
                                console.error(res)
                            }
                        })
                    }
                    console.log("WXDumpUnityHeap end", errorCount)
                }
            })
        }
        }
    },
    WXStorageSetIntSync: function (key, value) {
        window.WXWASMSDK.WXStorageSetIntSync(_WXPointer_stringify_adaptor(key), value);
    },
    WXStorageGetIntSync: function (key, defaultValue) {
        return window.WXWASMSDK.WXStorageGetIntSync(_WXPointer_stringify_adaptor(key), defaultValue);
    },
    WXStorageSetFloatSync: function (key, value) {
        window.WXWASMSDK.WXStorageSetFloatSync(_WXPointer_stringify_adaptor(key), value);
    },
    WXStorageGetFloatSync: function (key, defaultValue) {
        return window.WXWASMSDK.WXStorageGetFloatSync(_WXPointer_stringify_adaptor(key), defaultValue);
    },
    WXStorageSetStringSync: function (key, value) {
        window.WXWASMSDK.WXStorageSetStringSync(_WXPointer_stringify_adaptor(key), _WXPointer_stringify_adaptor(value));
    },
    WXStorageGetStringSync: function (key, defaultValue) {
        var returnStr = window.WXWASMSDK.WXStorageGetStringSync(_WXPointer_stringify_adaptor(key), _WXPointer_stringify_adaptor(defaultValue));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXStorageDeleteAllSync: function () {
        window.WXWASMSDK.WXStorageDeleteAllSync();
    },
    WXStorageDeleteKeySync: function (key) {
        window.WXWASMSDK.WXStorageDeleteKeySync(_WXPointer_stringify_adaptor(key));
    },
    WXStorageHasKeySync: function (key) {
        return window.WXWASMSDK.WXStorageHasKeySync(_WXPointer_stringify_adaptor(key));
    },
    WXCheckSession: function (s, f, c) {
        window.WXWASMSDK.WXCheckSession(_WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXAuthorize: function (scope, s, f, c) {
        window.WXWASMSDK.WXAuthorize(_WXPointer_stringify_adaptor(scope), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXCreateUserInfoButton: function (x, y, width, height, lang, withCredentials) {
        var returnStr = window.WXWASMSDK.WXCreateUserInfoButton(x, y, width, height, _WXPointer_stringify_adaptor(lang), withCredentials);
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXUserInfoButtonShow: function (id) {
        window.WXWASMSDK.WXUserInfoButtonShow(_WXPointer_stringify_adaptor(id));
    },
    WXUserInfoButtonDestroy: function (id) {
        window.WXWASMSDK.WXUserInfoButtonDestroy(_WXPointer_stringify_adaptor(id));
    },
    WXUserInfoButtonHide: function (id) {
        window.WXWASMSDK.WXUserInfoButtonHide(_WXPointer_stringify_adaptor(id));
    },
    WXUserInfoButtonOffTap: function (id) {
        window.WXWASMSDK.WXUserInfoButtonOffTap(_WXPointer_stringify_adaptor(id));
    },
    WXUserInfoButtonOnTap: function (id) {
        window.WXWASMSDK.WXUserInfoButtonOnTap(_WXPointer_stringify_adaptor(id));
    },
    WXOnShareAppMessage: function (conf, isPromise) {
        return window.WXWASMSDK.WXOnShareAppMessage(_WXPointer_stringify_adaptor(conf), isPromise);
    },
    WXOnShareAppMessageResolve: function (conf) {
        return window.WXWASMSDK.WXOnShareAppMessageResolve(_WXPointer_stringify_adaptor(conf));
    },
    WXOffShareAppMessage: function () {
        return window.WXWASMSDK.WXOffShareAppMessage();
    },
    WXCreateBannerAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateBannerAd(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateRewardedVideoAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateRewardedVideoAd(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXGetFontRawData: function (conf, callbackId) {
        window.WXWASMSDK.WXGetFontRawData(_WXPointer_stringify_adaptor(conf), _WXPointer_stringify_adaptor(callbackId))
    },
    WXShareFontBuffer:function(offset,callbackId){
        window.WXWASMSDK.WXShareFontBuffer(
            HEAPU8,
            offset,
            _WXPointer_stringify_adaptor(callbackId)
        )
    },
    WXRewardedVideoAdReportShareBehavior: function (id, conf) {
        var returnStr = window.WXWASMSDK.WXReportShareBehavior(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateInterstitialAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateInterstitialAd(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateCustomAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateCustomAd(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXADStyleChange: function (id, key, value) {
        window.WXWASMSDK.WXADStyleChange(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key), value);
    },
    WXShowAd: function (id, s, f) {
        window.WXWASMSDK.WXShowAd(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f));
    },
    WXShowAd2: function (id,branchId,branchDim, s, f) {
        window.WXWASMSDK.WXShowAd2(_WXPointer_stringify_adaptor(id),_WXPointer_stringify_adaptor(branchId),_WXPointer_stringify_adaptor(branchDim), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f));
    },
    WXHideAd: function (id, s, f) {
        window.WXWASMSDK.WXHideAd(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f));
    },
    WXADGetStyleValue: function (id, key) {
        return window.WXWASMSDK.WXADGetStyleValue(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXADDestroy: function (id) {
        window.WXWASMSDK.WXADDestroy(_WXPointer_stringify_adaptor(id));
    },
    WXADLoad: function (id, succ, fail) {
        window.WXWASMSDK.WXADLoad(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(succ), _WXPointer_stringify_adaptor(fail));
    },
    WXToTempFilePath: function (conf, s, f, c) {
        window.WXWASMSDK.WXToTempFilePath(_WXPointer_stringify_adaptor(conf), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c))
    },
    WXToTempFilePathSync: function (conf) {
        var returnStr = window.WXWASMSDK.WXToTempFilePathSync(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXGetUserDataPath: function () {
        var returnStr = window.WXWASMSDK.WXGetUserDataPath();
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXWriteFileSync: function (filePath, data, encoding) {
        var returnStr = window.WXWASMSDK.WXWriteFileSync(_WXPointer_stringify_adaptor(filePath), _WXPointer_stringify_adaptor(data), _WXPointer_stringify_adaptor(encoding));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateFixedBottomMiddleBannerAd: function (adUnitId, adIntervals, height) {
        var returnStr = window.WXWASMSDK.WXCreateFixedBottomMiddleBannerAd(_WXPointer_stringify_adaptor(adUnitId), adIntervals, height);
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXDataContextPostMessage: function (msg) {
        window.WXWASMSDK.WXDataContextPostMessage(_WXPointer_stringify_adaptor(msg));
    },
    WXShowOpenData: function (id, x, y, width, height) {
        window.WXWASMSDK.WXShowOpenData(id, x, y, width, height);
    },
    WXHideOpenData: function () {
        window.WXWASMSDK.WXHideOpenData();
    },
    WXReportGameStart: function () {
        window.WXWASMSDK.WXReportGameStart();
    },
    WXReportGameSceneError: function(sceneId, errorType, errStr, extJsonStr) {
        window.WXWASMSDK.WXReportGameSceneError(sceneId, errorType, _WXPointer_stringify_adaptor(errStr), _WXPointer_stringify_adaptor(extJsonStr));
    },
    WXWriteLog: function (str) {
        window.WXWASMSDK.WXWriteLog(_WXPointer_stringify_adaptor(str))
    },
    WXWriteWarn: function (str) {
        window.WXWASMSDK.WXWriteWarn(_WXPointer_stringify_adaptor(str))
    },
    WXPreloadConcurrent: function (count) {
        window.WXWASMSDK.WXPreloadConcurrent(count);
    },
    WXAccessFileSync: function (path) {
        var returnStr = window.WXWASMSDK.WXAccessFileSync(_WXPointer_stringify_adaptor(path));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXAccessFile: function (path, s, f, c) {
        return window.WXWASMSDK.WXAccessFile(_WXPointer_stringify_adaptor(path), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXCopyFileSync: function (srcPath, destPath) {
        var returnStr = window.WXWASMSDK.WXCopyFileSync(_WXPointer_stringify_adaptor(srcPath), _WXPointer_stringify_adaptor(destPath));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCopyFile: function (srcPath, destPath, s, f, c) {
        return window.WXWASMSDK.WXCopyFile(_WXPointer_stringify_adaptor(srcPath), _WXPointer_stringify_adaptor(destPath), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXUnlinkSync: function (filePath) {
        var returnStr = window.WXWASMSDK.WXUnlinkSync(_WXPointer_stringify_adaptor(filePath));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXUnlink: function (filePath, s, f, c) {
        return window.WXWASMSDK.WXUnlink(_WXPointer_stringify_adaptor(filePath), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXReportUserBehaviorBranchAnalytics: function (branchId, branchDim, eventType) {
        window.WXWASMSDK.WXReportUserBehaviorBranchAnalytics(_WXPointer_stringify_adaptor(branchId), _WXPointer_stringify_adaptor(branchDim), eventType);
    },
    WXCallFunction: function (name, data, conf, s, f, c) {
        window.WXWASMSDK.WXCallFunction(_WXPointer_stringify_adaptor(name), _WXPointer_stringify_adaptor(data), _WXPointer_stringify_adaptor(conf), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXCallFunctionInit: function (conf) {
        window.WXWASMSDK.WXCallFunctionInit(_WXPointer_stringify_adaptor(conf));
    },
    WXCloudID: function (cloudID) {
        var returnStr = window.WXWASMSDK.WXCloudID(_WXPointer_stringify_adaptor(cloudID));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateInnerAudioContext: function (src, loop, startTime, autoplay, volume, playbackRate, needDownload) {
        var returnStr = window.WXWASMSDK.WXCreateInnerAudioContext(_WXPointer_stringify_adaptor(src), loop, startTime, autoplay, volume, playbackRate, needDownload);
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXInnerAudioContextSetBool: function (id, k, v) {
        window.WXWASMSDK.WXInnerAudioContextSetBool(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(k), v);
    },
    WXInnerAudioContextSetString: function (id, k, v) {
        window.WXWASMSDK.WXInnerAudioContextSetString(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(k), _WXPointer_stringify_adaptor(v));
    },
    WXInnerAudioContextSetFloat: function (id, k, v) {
        window.WXWASMSDK.WXInnerAudioContextSetFloat(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(k), v);
    },
    WXInnerAudioContextGetFloat: function (id, k) {
        return window.WXWASMSDK.WXInnerAudioContextGetFloat(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(k));
    },
    WXInnerAudioContextGetBool: function (id, k) {
        return window.WXWASMSDK.WXInnerAudioContextGetBool(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(k));
    },
    WXInnerAudioContextPlay: function (id) {
        window.WXWASMSDK.WXInnerAudioContextPlay(_WXPointer_stringify_adaptor(id));
    },
    WXInnerAudioContextStop: function (id) {
        window.WXWASMSDK.WXInnerAudioContextStop(_WXPointer_stringify_adaptor(id));
    },
    WXInnerAudioContextPause: function (id) {
        window.WXWASMSDK.WXInnerAudioContextPause(_WXPointer_stringify_adaptor(id));
    },
    WXInnerAudioContextDestroy: function (id) {
        window.WXWASMSDK.WXInnerAudioContextDestroy(_WXPointer_stringify_adaptor(id));
    },
    WXInnerAudioContextSeek: function (id, position) {
        window.WXWASMSDK.WXInnerAudioContextSeek(_WXPointer_stringify_adaptor(id), position);
    },
    WXInnerAudioContextAddListener: function (id, key) {
        window.WXWASMSDK.WXInnerAudioContextAddListener(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXInnerAudioContextRemoveListener: function (id, key) {
        window.WXWASMSDK.WXInnerAudioContextRemoveListener(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXPreDownloadAudios: function (paths, id) {
        window.WXWASMSDK.WXPreDownloadAudios(_WXPointer_stringify_adaptor(paths), id);
    },
    WXSetDataCDN: function(path) {
        window.WXWASMSDK.WXSetDataCDN(_WXPointer_stringify_adaptor(path));
    },
    WXSetPreloadList: function(paths) {
        window.WXWASMSDK.WXSetPreloadList(_WXPointer_stringify_adaptor(paths));
    },
    WXCreateGameClubButton: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateGameClubButton(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXGameClubButtonDestroy: function(id) {
        window.WXWASMSDK.WXGameClubButtonDestroy(_WXPointer_stringify_adaptor(id));
    },
    WXGameClubButtonHide: function(id) {
        window.WXWASMSDK.WXGameClubButtonHide(_WXPointer_stringify_adaptor(id));
    },
    WXGameClubButtonShow: function(id) {
        window.WXWASMSDK.WXGameClubButtonShow(_WXPointer_stringify_adaptor(id));
    },
    WXGameClubButtonAddListener: function(id, key) {
        window.WXWASMSDK.WXGameClubButtonAddListener(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXGameClubButtonRemoveListener: function(id, key) {
        window.WXWASMSDK.WXGameClubButtonRemoveListener(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXGameClubButtonSetProperty: function(id, key, value) {
        window.WXWASMSDK.WXGameClubButtonSetProperty(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key), _WXPointer_stringify_adaptor(value));
    },
    WXGameClubStyleChangeInt: function(id, key, value) {
        window.WXWASMSDK.WXGameClubStyleChangeInt(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key), value);
    },
    WXGameClubStyleChangeStr: function(id, key, value) {
        window.WXWASMSDK.WXGameClubStyleChangeStr(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key), _WXPointer_stringify_adaptor(value));
    },
    WXCreateVideo: function(conf) {
        var returnStr = window.WXWASMSDK.WXCreateVideo(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXVideoPlay: function(id) {
        window.WXWASMSDK.WXVideoPlay(_WXPointer_stringify_adaptor(id));
    },
    WXVideoAddListener: function(id,key) {
        window.WXWASMSDK.WXVideoAddListener(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXVideoDestroy: function(id) {
        window.WXWASMSDK.WXVideoDestroy(_WXPointer_stringify_adaptor(id));
    },
    WXVideoExitFullScreen: function(id) {
        window.WXWASMSDK.WXVideoExitFullScreen(_WXPointer_stringify_adaptor(id));
    },
    WXVideoPause: function(id){
        window.WXWASMSDK.WXVideoPause(_WXPointer_stringify_adaptor(id));
    },
    WXVideoRequestFullScreen:function(id,direction){
        window.WXWASMSDK.WXVideoRequestFullScreen(_WXPointer_stringify_adaptor(id),direction);
    },
    WXVideoSeek:function(id,time){
        window.WXWASMSDK.WXVideoSeek(_WXPointer_stringify_adaptor(id),time);
    },
    WXVideoStop:function(id){
       window.WXWASMSDK.WXVideoStop(_WXPointer_stringify_adaptor(id));
    },
    WXVideoRemoveListener:function(id,key){
        window.WXWASMSDK.WXVideoRemoveListener(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXHideLoadingPage: function() {
        window.WXWASMSDK && window.WXWASMSDK.WXHideLoadingPage()
    },
    WXWriteFile:function(filePath, data, dataLength, encoding, s, f, c) {
        window.WXWASMSDK.WXWriteFile(
            _WXPointer_stringify_adaptor(filePath),
            HEAPU8.slice(data, dataLength + data),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(s),
            _WXPointer_stringify_adaptor(f),
            _WXPointer_stringify_adaptor(c)
        )
    },
    WXWriteStringFile:function (filePath,data,encoding, s, f, c) {
        window.WXWASMSDK.WXWriteStringFile(
            _WXPointer_stringify_adaptor(filePath),
            _WXPointer_stringify_adaptor(data),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(s),
            _WXPointer_stringify_adaptor(f),
            _WXPointer_stringify_adaptor(c)
        )
    },
    WXAppendFile:function(filePath, data, dataLength, encoding, s, f, c) {
        window.WXWASMSDK.WXAppendFile(
            _WXPointer_stringify_adaptor(filePath),
            HEAPU8.slice(data, dataLength + data),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(s),
            _WXPointer_stringify_adaptor(f),
            _WXPointer_stringify_adaptor(c)
        )
    },
    WXAppendStringFile:function (filePath, data, encoding, s, f, c) {
        window.WXWASMSDK.WXAppendStringFile(
            _WXPointer_stringify_adaptor(filePath),
            _WXPointer_stringify_adaptor(data),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(s),
            _WXPointer_stringify_adaptor(f),
            _WXPointer_stringify_adaptor(c)
        )
    },
    WXWriteBinFileSync:function(filePath, data, dataLength, encoding) {
        var returnStr = window.WXWASMSDK.WXWriteBinFileSync(
            _WXPointer_stringify_adaptor(filePath),
            HEAPU8.slice(data, dataLength + data),
            _WXPointer_stringify_adaptor(encoding)
        );
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXReadFile:function(option, callbackId) {
        window.WXWASMSDK.WXReadFile(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WXReadFileSync:function(option) {
        var returnStr = window.WXWASMSDK.WXReadFileSync(_WXPointer_stringify_adaptor(option));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXGetTotalMemorySize: function() {
        if (typeof TOTAL_MEMORY !== "undefined") {
            return TOTAL_MEMORY
        }
        if (wasmMemory && wasmMemory.buffer) {
            return wasmMemory.buffer.byteLength;
        }
        console.error('Fail to find wasmMemory.buffer, TotalMemorySize is not correct.');
        return 0;
    },
    WXGetTotalStackSize: function() {
        return TOTAL_STACK;
    },
    WXGetStaticMemorySize: function() {
        return STATICTOP - STATIC_BASE;
    },
    WXGetDynamicMemorySize: function() {
        if (typeof DYNAMIC_BASE !== "undefined") {
          return HEAP32[DYNAMICTOP_PTR >> 2] - DYNAMIC_BASE
        } 
        var heap_base = 7936880;
        if (typeof Module["___heap_base"] !== "undefined") {
            heap_base = Module["___heap_base"];
        }
        var heap_end = _sbrk();
        return heap_end - heap_base;
    },
    WXGetUsedMemorySize: function() {
         if (typeof emscriptenMemoryProfiler !== "undefined")  {
            return  emscriptenMemoryProfiler.totalMemoryAllocated;
        }
    },
    WXGetUnAllocatedMemorySize: function() {
        var heap_end = _sbrk()
        return HEAP8.length - heap_end
        return 0
    },
    WXGetEXFrameTime : function() {
        if(typeof GameGlobal.calcFrameTimeFunc == "undefined") 
        {
            GameGlobal.calcFrameTimeFunc = function () 
            {
                var frameCount = 0;
                var exTotalTime = 0;
                return function update(frameStart, frameEnd) {
                  frameCount++;
                  exTotalTime += (frameEnd - frameStart);
                  if (frameCount >= 60) {
                    GameGlobal.avgExFrameTime = exTotalTime / 60;
                    frameCount = 0;
                    exTotalTime = 0;
                  }
                };
            }();
        } 
        return GameGlobal.avgExFrameTime
    },
    WXProfilingMemoryDump: function() {
        if (typeof emscriptenMemoryProfiler !== "undefined")  {
            GameGlobal.memprofiler.onDump();
            wx.showModal({
                title: 'ProfilingMemory',
                content: 'OnDump Complete!'
            });
            return;
        }
        console.error('Please call WX.InitSDK & Select ProfilingMemory Option')  
    },
    WXLogManagerDebug:function(str){
        window.WXWASMSDK.WXLogManagerDebug(
            _WXPointer_stringify_adaptor(str)
        );
    },
    WXLogManagerInfo:function(str){
        window.WXWASMSDK.WXLogManagerInfo(
            _WXPointer_stringify_adaptor(str)
        );
    },
    WXLogManagerLog:function(str){
        window.WXWASMSDK.WXLogManagerLog(
            _WXPointer_stringify_adaptor(str)
        );
    },
    WXLogManagerWarn:function(str){
        window.WXWASMSDK.WXLogManagerWarn(
            _WXPointer_stringify_adaptor(str)
        );
    },
    WXIsCloudTest:function(){
        return window.WXWASMSDK.WXIsCloudTest();
    },
    WXCleanAllFileCache:function() {
        var returnStr = window.WXWASMSDK.WXCleanAllFileCache();
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCleanFileCache: function(fileSize) {
        var returnStr = window.WXWASMSDK.WXCleanFileCache(fileSize);
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXRemoveFile: function(path) {
        var returnStr = window.WXWASMSDK.WXRemoveFile(_WXPointer_stringify_adaptor(path));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXGetCachePath: function(url) {
        var returnStr = window.WXWASMSDK.WXGetCachePath(_WXPointer_stringify_adaptor(url));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXGetPluginCachePath: function() {
        var returnStr = window.WXWASMSDK.WXGetPluginCachePath();
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXOnLaunchProgress: function() {
        var returnStr = window.WXWASMSDK.WXOnLaunchProgress();
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXUncaughtException: function() {
       window.WXWASMSDK.WXUncaughtException(false);
    },
    WXMkdir:function(dirPath, recursive, s,  f,  c){
        window.WXWASMSDK.WXMkdir(_WXPointer_stringify_adaptor(dirPath), recursive, _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXMkdirSync: function (dirPath, recursive) {
        var returnStr = window.WXWASMSDK.WXMkdirSync(_WXPointer_stringify_adaptor(dirPath),recursive);
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXRmdir: function(dirPath, recursive, s, f, c) {
        window.WXWASMSDK.WXRmdir(_WXPointer_stringify_adaptor(dirPath), recursive, _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXRmdirSync: function(dirPath, recursive) {
        var returnStr = window.WXWASMSDK.WXRmdirSync(_WXPointer_stringify_adaptor(dirPath),recursive);
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },

    WXCameraCreateCamera: function (option, callbackId) {
        window.WXWASMSDK.WXCameraCreateCamera(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },

    WXCameraCloseFrameChange: function (id) {
        window.WXWASMSDK.WXCameraCloseFrameChange(_WXPointer_stringify_adaptor(id));
    },

    WXCameraDestroy: function (id) {
        window.WXWASMSDK.WXCameraDestroy(_WXPointer_stringify_adaptor(id));
    },

    WXCameraListenFrameChange: function (id) {
        window.WXWASMSDK.WXCameraListenFrameChange(_WXPointer_stringify_adaptor(id));
    },

    WXCameraOnAuthCancel: function (id) {
        window.WXWASMSDK.WXCameraOnAuthCancel(_WXPointer_stringify_adaptor(id));
    },

    WXCameraOnCameraFrame: function (id) {
        window.WXWASMSDK.WXCameraOnCameraFrame(_WXPointer_stringify_adaptor(id));
    },

    WXCameraOnStop:function (id) {
        window.WXWASMSDK.WXCameraOnStop(_WXPointer_stringify_adaptor(id));
    },

    WX_GetRecorderManager:function(
    ){
            var res = window.WXWASMSDK.WX_GetRecorderManager();
            var bufferSize = lengthBytesUTF8(res || '') + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(res, buffer, bufferSize);
            return buffer;
    },

    WX_OnRecorderError:function(id){
        window.WXWASMSDK.WX_OnRecorderError(_WXPointer_stringify_adaptor(id));
    },
    WX_OnRecorderFrameRecorded:function(id){
        window.WXWASMSDK.WX_OnRecorderFrameRecorded(_WXPointer_stringify_adaptor(id));
    },
    WX_OnRecorderInterruptionBegin:function(id){
        window.WXWASMSDK.WX_OnRecorderInterruptionBegin(_WXPointer_stringify_adaptor(id));
    },
    WX_OnRecorderInterruptionEnd:function(id){
        window.WXWASMSDK.WX_OnRecorderInterruptionEnd(_WXPointer_stringify_adaptor(id));
    },
    WX_OnRecorderPause:function(id){
        window.WXWASMSDK.WX_OnRecorderPause(_WXPointer_stringify_adaptor(id));
    },
    WX_OnRecorderResume:function(id){
        window.WXWASMSDK.WX_OnRecorderResume(_WXPointer_stringify_adaptor(id));
    },
    WX_OnRecorderStart:function(id){
        window.WXWASMSDK.WX_OnRecorderStart(_WXPointer_stringify_adaptor(id));
    },
    WX_OnRecorderStop:function(id){
        window.WXWASMSDK.WX_OnRecorderStop(_WXPointer_stringify_adaptor(id));
    },
    WX_RecorderPause:function(id){
        window.WXWASMSDK.WX_RecorderPause(_WXPointer_stringify_adaptor(id));
    },
    WX_RecorderResume:function(id){
        window.WXWASMSDK.WX_RecorderResume(_WXPointer_stringify_adaptor(id));
    },
    WX_RecorderStart:function(id,option){
        window.WXWASMSDK.WX_RecorderStart(_WXPointer_stringify_adaptor(id),_WXPointer_stringify_adaptor(option));
    },
    WX_RecorderStop:function(id){
        window.WXWASMSDK.WX_RecorderStop(_WXPointer_stringify_adaptor(id));
    },
    WX_UploadFile:function(conf, callbackId){
        window.WXWASMSDK.WX_UploadFile(_WXPointer_stringify_adaptor(conf), _WXPointer_stringify_adaptor(callbackId));
    },
    WXUploadTaskAbort:function(id){
        window.WXWASMSDK.WXUploadTaskAbort(_WXPointer_stringify_adaptor(id));
    },
    WXUploadTaskOffHeadersReceived:function(id){
        window.WXWASMSDK.WXUploadTaskOffHeadersReceived(_WXPointer_stringify_adaptor(id));
    },
    WXUploadTaskOffProgressUpdate:function(id){
        window.WXWASMSDK.WXUploadTaskOffProgressUpdate(_WXPointer_stringify_adaptor(id));
    },
    WXUploadTaskOnHeadersReceived:function(id){
        window.WXWASMSDK.WXUploadTaskOnHeadersReceived(_WXPointer_stringify_adaptor(id));
    },
    WXUploadTaskOnProgressUpdate:function(id){
        window.WXWASMSDK.WXUploadTaskOnProgressUpdate(_WXPointer_stringify_adaptor(id));
    },
    WXStat: function (conf, callbackId) {
        window.WXWASMSDK.WXStat(_WXPointer_stringify_adaptor(conf), _WXPointer_stringify_adaptor(callbackId))
    },
    WX_GetGameRecorder:function() {
        var res = window.WXWASMSDK.WX_GetGameRecorder();
        var bufferSize = lengthBytesUTF8(res || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_GameRecorderOff:function(id, eventType){
        window.WXWASMSDK.WX_GameRecorderOff(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(eventType));
    },
    WX_GameRecorderOn:function(id, eventType){
        window.WXWASMSDK.WX_GameRecorderOn(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(eventType));
    },
    WX_GameRecorderStart:function(id,option){
        window.WXWASMSDK.WX_GameRecorderStart(_WXPointer_stringify_adaptor(id),_WXPointer_stringify_adaptor(option));
    },
    WX_GameRecorderAbort:function(id){
        window.WXWASMSDK.WX_GameRecorderAbort(_WXPointer_stringify_adaptor(id));
    },
    WX_GameRecorderPause:function(id){
        window.WXWASMSDK.WX_GameRecorderPause(_WXPointer_stringify_adaptor(id));
    },
    WX_GameRecorderResume:function(id){
        window.WXWASMSDK.WX_GameRecorderResume(_WXPointer_stringify_adaptor(id));
    },
    WX_GameRecorderStop:function(id){
        window.WXWASMSDK.WX_GameRecorderStop(_WXPointer_stringify_adaptor(id));
    },  
    WX_OperateGameRecorderVideo:function(option){
        window.WXWASMSDK.WX_OperateGameRecorderVideo(_WXPointer_stringify_adaptor(option));
    },
    WXChatCreate: function (option) {
        var returnStr = window.WXWASMSDK.WXChatCreate(_WXPointer_stringify_adaptor(option));
        var bufferSize = lengthBytesUTF8(returnStr || '') + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXChatHide: function () {
        window.WXWASMSDK.WXChatHide();
    },
    WXChatShow: function (option) {
        window.WXWASMSDK.WXChatShow(_WXPointer_stringify_adaptor(option));
    },
    WXChatClose: function () {
        window.WXWASMSDK.WXChatClose();
    },
    WXChatOpen: function (pageKey) {
        window.WXWASMSDK.WXChatOpen(_WXPointer_stringify_adaptor(pageKey));
    },
    WXChatSetTabs: function (pageKeys) {
        window.WXWASMSDK.WXChatSetTabs(_WXPointer_stringify_adaptor(pageKeys));
    },
    WXChatOn: function (eventType) {
        window.WXWASMSDK.WXChatOn(_WXPointer_stringify_adaptor(eventType));
    },
    WXChatOff: function (eventType) {
        window.WXWASMSDK.WXChatOff(_WXPointer_stringify_adaptor(eventType));
    },
    WXChatSetSignature: function (signature) {
        window.WXWASMSDK.WXChatSetSignature(_WXPointer_stringify_adaptor(signature));
    },
    WXSetArrayBuffer: function (offset,callbackId){
        window.WXWASMSDK.WXSetArrayBuffer(
            HEAPU8,
            offset,
            _WXPointer_stringify_adaptor(callbackId)
        )
    },
    WX_FileSystemManagerAppendFileSync:function(filePath, data, dataLength, encoding) {
        window.WXWASMSDK.WX_FileSystemManagerAppendFileSync(
            _WXPointer_stringify_adaptor(filePath),
            HEAPU8.slice(data, dataLength + data),
            _WXPointer_stringify_adaptor(encoding)
        );
    },
    WX_FileSystemManagerAppendFileStringSync:function(filePath, data, encoding) {
        window.WXWASMSDK.WX_FileSystemManagerAppendFileStringSync(_WXPointer_stringify_adaptor(filePath), _WXPointer_stringify_adaptor(data), _WXPointer_stringify_adaptor(encoding));
    },
    WX_FileSystemManagerReaddirSync:function(dirPath) {
        var res = window.WXWASMSDK.WX_FileSystemManagerReaddirSync(_WXPointer_stringify_adaptor(dirPath));
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerReadCompressedFileSync:function(option, callbackId) {
        var res = window.WXWASMSDK.WX_FileSystemManagerReadCompressedFileSync(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerClose:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerClose(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerFstat:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerFstat(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerFtruncate:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerFtruncate(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerGetFileInfo:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerGetFileInfo(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerGetSavedFileList:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerGetSavedFileList(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerOpen:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerOpen(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerRead:function(option, data, dataLength, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerRead(_WXPointer_stringify_adaptor(option), HEAPU8.slice(data, dataLength + data), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerReadCompressedFile:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerReadCompressedFile(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerReadZipEntry:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerReadZipEntry(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerReadZipEntryString:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerReadZipEntryString(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerReaddir:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerReaddir(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerRemoveSavedFile:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerRemoveSavedFile(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerRename:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerRename(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerSaveFile:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerSaveFile(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerTruncate:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerTruncate(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerUnzip:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerUnzip(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerWrite:function(option, data, dataLength, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerWrite(_WXPointer_stringify_adaptor(option), HEAPU8.slice(data, dataLength + data), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerWriteString:function(option, callbackId) {
        window.WXWASMSDK.WX_FileSystemManagerWriteString(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
    },
    WX_FileSystemManagerRenameSync:function(oldPath, newPath) {
        window.WXWASMSDK.WX_FileSystemManagerRenameSync(_WXPointer_stringify_adaptor(oldPath), _WXPointer_stringify_adaptor(newPath));
    },
    WX_FileSystemManagerReadSync:function(option, callbackId) {
        var res = window.WXWASMSDK.WX_FileSystemManagerReadSync(_WXPointer_stringify_adaptor(option), _WXPointer_stringify_adaptor(callbackId));
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerFstatSync:function(option) {
        var res = window.WXWASMSDK.WX_FileSystemManagerFstatSync(_WXPointer_stringify_adaptor(option));
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerStatSync:function(path, recursive) {
        var res = window.WXWASMSDK.WX_FileSystemManagerStatSync(_WXPointer_stringify_adaptor(path), recursive);
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerWriteSync:function(option, data, dataLength) {
        var res = window.WXWASMSDK.WX_FileSystemManagerWriteSync(_WXPointer_stringify_adaptor(option), HEAPU8.slice(data, dataLength + data));
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerWriteStringSync:function(option) {
        var res = window.WXWASMSDK.WX_FileSystemManagerWriteStringSync(_WXPointer_stringify_adaptor(option));
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerOpenSync:function(option) {
        var res = window.WXWASMSDK.WX_FileSystemManagerOpenSync(_WXPointer_stringify_adaptor(option));
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerSaveFileSync:function(tempFilePath, filePath) {
        var res = window.WXWASMSDK.WX_FileSystemManagerSaveFileSync(_WXPointer_stringify_adaptor(tempFilePath), _WXPointer_stringify_adaptor(filePath));
        var bufferSize = lengthBytesUTF8(res) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(res, buffer, bufferSize);
        return buffer;
    },
    WX_FileSystemManagerCloseSync:function(option) {
        window.WXWASMSDK.WX_FileSystemManagerCloseSync(_WXPointer_stringify_adaptor(option));
    },
    WX_FileSystemManagerFtruncateSync:function(option) {
        window.WXWASMSDK.WX_FileSystemManagerFtruncateSync(_WXPointer_stringify_adaptor(option));
    },
    WX_FileSystemManagerTruncateSync:function(option) {
        window.WXWASMSDK.WX_FileSystemManagerTruncateSync(_WXPointer_stringify_adaptor(option));
    },
    WXVideoSetProperty: function(id, key, value) {
        window.WXWASMSDK.WXVideoSetProperty(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key), _WXPointer_stringify_adaptor(value));
    },
    WX_OnNeedPrivacyAuthorization:function() {
        window.WXWASMSDK.WX_OnNeedPrivacyAuthorization();
    },
    WX_PrivacyAuthorizeResolve: function(option) {
        window.WXWASMSDK.WX_PrivacyAuthorizeResolve(_WXPointer_stringify_adaptor(option));
    },
    WXLaunchOperaBridge: function(req) {
        var res = window.WXWASMSDK.WXLaunchOperaBridge(_WXPointer_stringify_adaptor(req));
        if (res) {
            var bufferSize = lengthBytesUTF8(res) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(res, buffer, bufferSize);
            return buffer;
        }
    },
    WXCanIUse: function(key) {
        if (!key || !_WXPointer_stringify_adaptor(key)) {
            return false;
        }
        const keyString = _WXPointer_stringify_adaptor(key);
        return typeof wx[keyString[0].toLowerCase() + keyString.slice(1)] !== 'undefined';
    },
    WX_OnBLECharacteristicValueChange: function() {
        window.WXWASMSDK.WX_OnBLECharacteristicValueChange();
    },
    WX_OffBLECharacteristicValueChange: function() {
        window.WXWASMSDK.WX_OffBLECharacteristicValueChange();
    },
    WX_RegisterOnBLECharacteristicValueChangeCallback: function(callback) {
        window.WXWASMSDK.WX_RegisterOnBLECharacteristicValueChangeCallback(callback);
    },
    WX_SetDevicePixelRatio: function(ratio) {
        window.devicePixelRatio = ratio;
    }
});
