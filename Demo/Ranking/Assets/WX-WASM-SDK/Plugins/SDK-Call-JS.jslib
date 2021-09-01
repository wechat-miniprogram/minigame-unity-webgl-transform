mergeInto(LibraryManager.library, {
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
    glGetString:function(name_) {
        if (GL.stringCache[name_]) return GL.stringCache[name_];
        var ret;
        switch (name_) {
            case 7936:
            case 7937:
            case 37445:
            case 37446:
                ret = allocate(intArrayFromString(GLctx.getParameter(name_)), "i8", ALLOC_NORMAL);
                break;
            case 7938:
                var glVersion = GLctx.getParameter(GLctx.VERSION);
                if (GLctx.canvas.GLctxObject.version >= 2) glVersion = "OpenGL ES 3.0 (" + glVersion + ")"; else {
                    glVersion = "OpenGL ES 2.0 (" + glVersion + ")"
                }
                ret = allocate(intArrayFromString(glVersion), "i8", ALLOC_NORMAL);
                break;
            case 7939:
                var exts = GLctx.getSupportedExtensions();
                if(GameGlobal.TextureConfig || GameGlobal.SpriteAtlasConfig){
                    exts.push("WEBGL_compressed_texture_s3tc");
                }
                var gl_exts = [];
                for (var i = 0; i < exts.length; ++i) {
                    gl_exts.push(exts[i]);
                    gl_exts.push("GL_" + exts[i])
                }
                ret = allocate(intArrayFromString(gl_exts.join(" ")), "i8", ALLOC_NORMAL);
                break;
            case 35724:
                var glslVersion = GLctx.getParameter(GLctx.SHADING_LANGUAGE_VERSION);
                var ver_re = /^WebGL GLSL ES ([0-9]\.[0-9][0-9]?)(?:$| .*)/;
                var ver_num = glslVersion.match(ver_re);
                if (ver_num !== null) {
                    if (ver_num[1].length == 3) ver_num[1] = ver_num[1] + "0";
                    glslVersion = "OpenGL ES GLSL ES " + ver_num[1] + " (" + glslVersion + ")"
                }
                ret = allocate(intArrayFromString(glslVersion), "i8", ALLOC_NORMAL);
                break;
            default:
                GL.recordError(1280);
                return 0
        }
        GL.stringCache[name_] = ret;
        return ret
    },
    glCompressedTexImage2D: function (target, level, internalFormat, width, height, border, imageSize, data) {
        var lastTid = window._lastTextureId;

        function compressedImage2D(rawData, w, h) {
            var format = 0;
            var dataOffset = 16;
            var compressFormat = GameGlobal.TextureCompressedFormat;
            switch (compressFormat) {
                case "astc":
                    format = GLctx.getExtension("WEBGL_compressed_texture_astc").COMPRESSED_RGBA_ASTC_8x8_KHR;
                    break;
                case "etc2":
                    format = GLctx.getExtension("WEBGL_compressed_texture_etc").COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2;
                    break;
                case "pvr":
                    format = GLctx.getExtension("WEBGL_compressed_texture_pvrtc").COMPRESSED_RGBA_PVRTC_4BPPV1_IMG;
                    var PVR_HEADER_METADATA = 12;
                    var PVR_HEADER_LENGTH = 13; // The header length in 32 bit ints.
                    var header = new Int32Array(rawData, 0, PVR_HEADER_LENGTH);
                    dataOffset = header[PVR_HEADER_METADATA] + 52;
                    break;
                case "etc1":
                    format = GLctx.getExtension("WEBGL_compressed_texture_etc1").COMPRESSED_RGB_ETC1_WEBGL;
                    break
            }
            GLctx["compressedTexImage2D"](target, level, format, w || width, h || height, border, new Uint8Array(rawData, dataOffset))
        }

        function texImage2D(image) {
            GLctx.texImage2D(GLctx.TEXTURE_2D, 0, GLctx.RGBA, GLctx.RGBA, GLctx.UNSIGNED_BYTE, image)
        }

        function renderTexture(id, imageType) {
            var cid = imageType + "_" + id;
            var _data = GameGlobal.DownloadedTextures[cid].data;
            var info = {
                "Texture":GameGlobal.TextureConfig,
                "SpriteAtlas":GameGlobal.SpriteAtlasConfig,
                "NoTPOTTexture":GameGlobal.NotPotTextureConfig
            }[imageType][id];
            GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[lastTid]);
            if(!GameGlobal.TextureCompressedFormat || (GameGlobal.TextureCompressedFormat == 'pvr' && info.w !== info.h ) || imageType ==="NoTPOTTexture"){
                texImage2D(_data);
            }else{
                compressedImage2D(_data, info.w, info.h);
            }
            GLctx.bindTexture(GLctx.TEXTURE_2D, null);

        }

        function renderTransparent() {
            GLctx.texImage2D(GLctx.TEXTURE_2D, 0, GLctx.RGBA, 1, 1, 0, GLctx.RGBA, GLctx.UNSIGNED_SHORT_4_4_4_4, new Uint16Array([0, 0]))
        }

        function getMatchId() {
            if (width * height / 2 !== imageSize || !data || imageSize < 8) {
                return -1
            }
            var id = -1;
            var d = HEAPU8.subarray(data, data + 8);
            if(width ===8 && height === 8){
                if ((d[2] | d[3]) === 0) {
                    id = d[1] * 255 + d[0]
                } else if ((d[0] | d[1]) === 0) {
                    id = d[3] * 255 + d[2]
                }
                if (GameGlobal.NotPotTextureConfig[id]) {
                    return id
                }
            }
            else if ((d[2] | d[3]) === 0 && !(width === 4 && height === 4)) {
                var bitText = d[1].toString(2).padStart(8, "0") + d[0].toString(2).padStart(8, "0");
                var r = parseInt(bitText.substr(0, 5), 2);
                var g = parseInt(bitText.substr(5, 6), 2);
                var b = parseInt(bitText.substr(11, 5), 2);
                id = Math.round(r / 31 * 15) * 16 * 16 + Math.round(g / 63 * 15) * 16 + Math.round(b / 31 * 15);
                if (GameGlobal.SpriteAtlasConfig[id]) {
                    return id
                }
            } else if (width === 4 && height === 4) {
                if ((d[2] | d[3]) === 0) {
                    id = d[1] * 255 + d[0]
                } else if ((d[0] | d[1]) === 0) {
                    id = d[3] * 255 + d[2]
                }
                if (GameGlobal.TextureConfig[id]) {
                    return id
                }
            }
            return -1
        }

        var matchId = getMatchId();
        if (matchId != -1) {
            var imageType = "SpriteAtlas";
            if(width === 4 && height === 4){
                imageType = "Texture";
            }else if(width === 8 && height === 8){
                imageType = "NoTPOTTexture";
            }
            if (GameGlobal.DownloadedTextures[matchId] && GameGlobal.DownloadedTextures[matchId].data) {
                renderTexture(matchId, imageType)
            } else {
                renderTransparent();
                window.WXWASMSDK.WXDownloadTexture(matchId, imageType, (function () {
                    renderTexture(matchId, imageType)
                }))
            }
            return
        }
        if (GL.currentContext.supportsWebGL2EntryPoints) {
            GLctx["compressedTexImage2D"](target, level, internalFormat, width, height, border, HEAPU8, data, imageSize);
            return
        }
        GLctx["compressedTexImage2D"](target, level, internalFormat, width, height, border, data ? HEAPU8.subarray(data, data + imageSize) : null)
    },
    WXInitializeSDK: function (version) {
        window.WXWASMSDK.WXInitializeSDK(Pointer_stringify(version));
    },
    WXVibrateShort: function (s, f, c) {
        window.WXWASMSDK.VibrateShort(Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXVibrateLong: function (s, f, c) {
        window.WXWASMSDK.VibrateLong(Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXStorageSetIntSync: function (key, value) {
        window.WXWASMSDK.WXStorageSetIntSync(Pointer_stringify(key), value);
    },
    WXStorageGetIntSync: function (key, defaultValue) {
        return window.WXWASMSDK.WXStorageGetIntSync(Pointer_stringify(key), defaultValue);
    },
    WXStorageSetFloatSync: function (key, value) {
        window.WXWASMSDK.WXStorageSetFloatSync(Pointer_stringify(key), value);
    },
    WXStorageGetFloatSync: function (key, defaultValue) {
        return window.WXWASMSDK.WXStorageGetFloatSync(Pointer_stringify(key), defaultValue);
    },
    WXStorageSetStringSync: function (key, value) {
        window.WXWASMSDK.WXStorageSetStringSync(Pointer_stringify(key), Pointer_stringify(value));
    },
    WXStorageGetStringSync: function (key, defaultValue) {
        var returnStr = window.WXWASMSDK.WXStorageGetStringSync(Pointer_stringify(key), Pointer_stringify(defaultValue));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXStorageDeleteAllSync: function () {
        window.WXWASMSDK.WXStorageDeleteAllSync();
    },
    WXStorageDeleteKeySync: function (key) {
        window.WXWASMSDK.WXStorageDeleteKeySync(Pointer_stringify(key));
    },
    WXStorageHasKeySync: function (key) {
        return window.WXWASMSDK.WXStorageHasKeySync(Pointer_stringify(key));
    },
    WXLogin: function (s, f, c) {
        window.WXWASMSDK.WXLogin(Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXCheckSession: function (s, f, c) {
        window.WXWASMSDK.WXCheckSession(Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXAuthorize: function (scope, s, f, c) {
        window.WXWASMSDK.WXAuthorize(Pointer_stringify(scope), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXGetUserInfo: function (withCredentials, lang, s, f, c) {
        window.WXWASMSDK.WXGetUserInfo(withCredentials, Pointer_stringify(lang), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXGetSystemLanguage: function () {
        var returnStr = window.WXWASMSDK.WXGetSystemLanguage();
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXGetSystemInfo: function (s, f, c) {
        window.WXWASMSDK.WXGetSystemInfo(Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXGetSystemInfoSync: function () {
        var returnStr = window.WXWASMSDK.WXGetSystemInfoSync();
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateUserInfoButton: function (x, y, width, height, lang, withCredentials) {
        var returnStr = window.WXWASMSDK.WXCreateUserInfoButton(x, y, width, height, Pointer_stringify(lang), withCredentials);
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXUserInfoButtonShow: function (id) {
        window.WXWASMSDK.WXUserInfoButtonShow(Pointer_stringify(id));
    },
    WXUserInfoButtonDestroy: function (id) {
        window.WXWASMSDK.WXUserInfoButtonDestroy(Pointer_stringify(id));
    },
    WXUserInfoButtonHide: function (id) {
        window.WXWASMSDK.WXUserInfoButtonHide(Pointer_stringify(id));
    },
    WXUserInfoButtonOffTap: function (id) {
        window.WXWASMSDK.WXUserInfoButtonOffTap(Pointer_stringify(id));
    },
    WXUserInfoButtonOnTap: function (id) {
        window.WXWASMSDK.WXUserInfoButtonOnTap(Pointer_stringify(id));
    },
    WXUpdateShareMenu: function (conf, s, f, c) {
        window.WXWASMSDK.WXUpdateShareMenu(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXShowShareMenu: function (conf, s, f, c) {
        window.WXWASMSDK.WXShowShareMenu(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXHideShareMenu: function (conf, s, f, c) {
        window.WXWASMSDK.WXHideShareMenu(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXShareAppMessage: function (conf) {
        window.WXWASMSDK.WXShareAppMessage(Pointer_stringify(conf));
    },
    WXSetMessageToFriendQuery: function (num) {
        return window.WXWASMSDK.WXSetMessageToFriendQuery(num);
    },
    WXOnShareAppMessage: function (conf, isPromise) {
        return window.WXWASMSDK.WXOnShareAppMessage(Pointer_stringify(conf), isPromise);
    },
    WXOnShareAppMessageResolve: function (conf) {
        return window.WXWASMSDK.WXOnShareAppMessageResolve(Pointer_stringify(conf));
    },
    WXOnShareTimeline: function (conf, needCallback) {
        return window.WXWASMSDK.WXOnShareTimeline(Pointer_stringify(conf), needCallback);
    },
    WXOnAddToFavorites: function (conf, needCallback) {
        return window.WXWASMSDK.WXOnAddToFavorites(Pointer_stringify(conf), needCallback);
    },
    WXOffShareTimeline: function () {
        return window.WXWASMSDK.WXOffShareTimeline();
    },
    WXOffShareAppMessage: function () {
        return window.WXWASMSDK.WXOffShareAppMessage();
    },
    WXOffAddToFavorites: function () {
        return window.WXWASMSDK.WXOffAddToFavorites();
    },
    WXGetShareInfo: function (conf, s, f, c) {
        window.WXWASMSDK.WXGetShareInfo(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXAuthPrivateMessage: function (conf, s, f, c) {
        window.WXWASMSDK.WXAuthPrivateMessage(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXCreateBannerAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateBannerAd(Pointer_stringify(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateRewardedVideoAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateRewardedVideoAd(Pointer_stringify(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateInterstitialAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateInterstitialAd(Pointer_stringify(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateGridAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateGridAd(Pointer_stringify(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateCustomAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateCustomAd(Pointer_stringify(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXADStyleChange: function (id, key, value) {
        window.WXWASMSDK.WXADStyleChange(Pointer_stringify(id), Pointer_stringify(key), value);
    },
    WXShowAd: function (id, s, f) {
        window.WXWASMSDK.WXShowAd(Pointer_stringify(id), Pointer_stringify(s), Pointer_stringify(f));
    },
    WXHideAd: function (id, s, f) {
        window.WXWASMSDK.WXHideAd(Pointer_stringify(id), Pointer_stringify(s), Pointer_stringify(f));
    },
    WXADGetStyleValue: function (id, key) {
        window.WXWASMSDK.WXADGetStyleValue(Pointer_stringify(id), Pointer_stringify(key));
    },
    WXADDestroy: function (id) {
        window.WXWASMSDK.WXADDestroy(Pointer_stringify(id));
    },
    WXADLoad: function (id, succ, fail) {
        window.WXWASMSDK.WXADLoad(Pointer_stringify(id), Pointer_stringify(succ), Pointer_stringify(fail));
    },
    WXGetLaunchOptionsSync: function () {
        var returnStr = window.WXWASMSDK.WXGetLaunchOptionsSync();
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXToTempFilePathSync: function (conf) {
        var returnStr = window.WXWASMSDK.WXToTempFilePathSync(Pointer_stringify(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXGetUserDataPath: function () {
        var returnStr = window.WXWASMSDK.WXGetUserDataPath();
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXWriteFileSync: function (filePath, data, encoding) {
        var returnStr = window.WXWASMSDK.WXWriteFileSync(Pointer_stringify(filePath), Pointer_stringify(data), Pointer_stringify(encoding));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateFixedBottomMiddleBannerAd: function (adUnitId, adIntervals, height) {
        var returnStr = window.WXWASMSDK.WXCreateFixedBottomMiddleBannerAd(Pointer_stringify(adUnitId), adIntervals, height);
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXDataContextPostMessage: function (msg) {
        window.WXWASMSDK.WXDataContextPostMessage(Pointer_stringify(msg));
    },
    WXShowOpenData: function (id, x, y, width, height) {
        window.WXWASMSDK.WXShowOpenData(id, x, y, width, height);
    },
    WXHideOpenData: function () {
        window.WXWASMSDK.WXHideOpenData();
    },
    WXUpdateKeyboard: function (value, s, f, c) {
        window.WXWASMSDK.WXUpdateKeyboard(Pointer_stringify(value), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXShowKeyboard: function (conf, s, f, c) {
        window.WXWASMSDK.WXShowKeyboard(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXHideKeyboard: function (s, f, c) {
        window.WXWASMSDK.WXHideKeyboard(Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXSetUserCloudStorage: function (list, s, f, c) {
        window.WXWASMSDK.WXSetUserCloudStorage(
            Pointer_stringify(list),
            Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXRemoveUserCloudStorage: function (list, s, f, c) {
        window.WXWASMSDK.WXRemoveUserCloudStorage(
            Pointer_stringify(list),
            Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXReportGameStart: function () {
        window.WXWASMSDK.WXReportGameStart();
    },
    WXSetGameStage: function(stageType) {
        window.WXWASMSDK.WXSetGameStage(stageType);
    },
    WXReportGameStageCostTime: function(totalMs, extJsonStr) {
        window.WXWASMSDK.WXReportGameStageCostTime(totalMs, Pointer_stringify(extJsonStr));
    },
    WXReportGameStageError: function(errorType, errStr, extJsonStr) {
        window.WXWASMSDK.WXReportGameStageError(errorType, Pointer_stringify(errStr), Pointer_stringify(extJsonStr));
    },
    WXWriteLog: function (str) {
        window.WXWASMSDK.WXWriteLog(Pointer_stringify(str))
    },
    WXWriteWarn: function (str) {
        window.WXWASMSDK.WXWriteWarn(Pointer_stringify(str))
    },
    WXPreloadConcurrent: function (count) {
        window.WXWASMSDK.WXPreloadConcurrent(count);
    },
    WXAccessFileSync: function (path) {
        var returnStr = window.WXWASMSDK.WXAccessFileSync(Pointer_stringify(path));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXAccessFile: function (path, s, f, c) {
        return window.WXWASMSDK.WXAccessFile(Pointer_stringify(path), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXCopyFileSync: function (srcPath, destPath) {
        var returnStr = window.WXWASMSDK.WXCopyFileSync(Pointer_stringify(srcPath), Pointer_stringify(destPath));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCopyFile: function (srcPath, destPath, s, f, c) {
        return window.WXWASMSDK.WXCopyFile(Pointer_stringify(srcPath), Pointer_stringify(destPath), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXUnlinkSync: function (filePath) {
        var returnStr = window.WXWASMSDK.WXUnlinkSync(Pointer_stringify(filePath));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXUnlink: function (filePath, s, f, c) {
        return window.WXWASMSDK.WXUnlink(Pointer_stringify(filePath), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXReportUserBehaviorBranchAnalytics: function (branchId, branchDim, eventType) {
        window.WXWASMSDK.WXReportUserBehaviorBranchAnalytics(Pointer_stringify(branchId), Pointer_stringify(branchDim), eventType);
    },
    WXCallFunction: function (name, data, conf, s, f, c) {
        window.WXWASMSDK.WXCallFunction(Pointer_stringify(name), Pointer_stringify(data), Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXCallFunctionInit: function (conf) {
        window.WXWASMSDK.WXCallFunctionInit(Pointer_stringify(conf));
    },
    WXCreateInnerAudioContext: function (src, loop, startTime, autoplay, volume, playbackRate, needDownload) {
        var returnStr = window.WXWASMSDK.WXCreateInnerAudioContext(Pointer_stringify(src), loop, startTime, autoplay, volume, playbackRate, needDownload);
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXInnerAudioContextSetBool: function (id, k, v) {
        window.WXWASMSDK.WXInnerAudioContextSetBool(Pointer_stringify(id), Pointer_stringify(k), v);
    },
    WXInnerAudioContextSetString: function (id, k, v) {
        window.WXWASMSDK.WXInnerAudioContextSetString(Pointer_stringify(id), Pointer_stringify(k), Pointer_stringify(v));
    },
    WXInnerAudioContextSetFloat: function (id, k, v) {
        window.WXWASMSDK.WXInnerAudioContextSetFloat(Pointer_stringify(id), Pointer_stringify(k), v);
    },
    WXInnerAudioContextGetFloat: function (id, k) {
        return window.WXWASMSDK.WXInnerAudioContextGetFloat(Pointer_stringify(id), Pointer_stringify(k));
    },
    WXInnerAudioContextGetBool: function (id, k) {
        return window.WXWASMSDK.WXInnerAudioContextGetBool(Pointer_stringify(id), Pointer_stringify(k));
    },
    WXInnerAudioContextPlay: function (id) {
        window.WXWASMSDK.WXInnerAudioContextPlay(Pointer_stringify(id));
    },
    WXInnerAudioContextStop: function (id) {
        window.WXWASMSDK.WXInnerAudioContextStop(Pointer_stringify(id));
    },
    WXInnerAudioContextPause: function (id) {
        window.WXWASMSDK.WXInnerAudioContextPause(Pointer_stringify(id));
    },
    WXInnerAudioContextDestroy: function (id) {
        window.WXWASMSDK.WXInnerAudioContextDestroy(Pointer_stringify(id));
    },
    WXInnerAudioContextSeek: function (id, position) {
        window.WXWASMSDK.WXInnerAudioContextSeek(Pointer_stringify(id), position);
    },
    WXInnerAudioContextAddListener: function (id, key) {
        window.WXWASMSDK.WXInnerAudioContextAddListener(Pointer_stringify(id), Pointer_stringify(key));
    },
    WXInnerAudioContextRemoveListener: function (id, key) {
        window.WXWASMSDK.WXInnerAudioContextRemoveListener(Pointer_stringify(id), Pointer_stringify(key));
    },
    WXPreDownloadAudios: function (paths, id) {
        window.WXWASMSDK.WXPreDownloadAudios(Pointer_stringify(paths), id);
    },
    WXCreateVideo: function(conf){
        var returnStr = window.WXWASMSDK.WXCreateVideo(Pointer_stringify(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXVideoPlay: function(id){
        window.WXWASMSDK.WXVideoPlay(Pointer_stringify(id));
    },
    WXVideoAddListener: function(id,key){
        window.WXWASMSDK.WXVideoAddListener(Pointer_stringify(id), Pointer_stringify(key));
    },
    WXVideoDestroy: function(id){
        window.WXWASMSDK.WXVideoDestroy(Pointer_stringify(id));
    },
    WXVideoExitFullScreen: function(id){
        window.WXWASMSDK.WXVideoExitFullScreen(Pointer_stringify(id));
    },
    WXVideoPause: function(id){
        window.WXWASMSDK.WXVideoPause(Pointer_stringify(id));
    },
    WXVideoRequestFullScreen:function(id,direction){
        window.WXWASMSDK.WXVideoRequestFullScreen(Pointer_stringify(id),direction);
    },
    WXVideoSeek:function(id,time){
        window.WXWASMSDK.WXVideoSeek(Pointer_stringify(id),time);
    },
    WXVideoStop:function(id){
       window.WXWASMSDK.WXVideoStop(Pointer_stringify(id));
    },
    WXVideoRemoveListener:function(id,key){
        window.WXWASMSDK.WXVideoRemoveListener(Pointer_stringify(id), Pointer_stringify(key));
    },
    WXRequestMidasPayment:function(conf, s, f, c){
        window.WXWASMSDK.WXRequestMidasPayment(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXRequestMidasFriendPayment:function(conf, s, f, c){
        window.WXWASMSDK.WXRequestMidasFriendPayment(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXHideLoadingPage: function() {
        window.WXWASMSDK.WXHideLoadingPage()
    },
    WXGetNetworkType:function(s, f, c){
        window.WXWASMSDK.WXGetNetworkType(Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXSetKeepScreenOn:function(b,s, f, c){
        window.WXWASMSDK.WXSetKeepScreenOn(b,Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXExitMiniProgram:function(s, f, c){
         window.WXWASMSDK.WXExitMiniProgram(Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    },
    WXWriteFile:function(filePath, data, dataLength, encoding, s, f, c){
        window.WXWASMSDK.WXWriteFile(
            Pointer_stringify(filePath),
            HEAPU8.slice(data,dataLength+data),
            Pointer_stringify(encoding),
            Pointer_stringify(s),
            Pointer_stringify(f),
            Pointer_stringify(c)
        )
    },
    WXWriteBinFileSync:function(filePath, data, dataLength, encoding){
        return window.WXWASMSDK.WXWriteBinFileSync(
            Pointer_stringify(filePath),
            HEAPU8.slice(data,dataLength+data),
            Pointer_stringify(encoding)
        )
    },
    WXReadFile:function(filePath, encoding,callbackId){
        window.WXWASMSDK.WXReadFile(
            Pointer_stringify(filePath),
            Pointer_stringify(encoding),
            Pointer_stringify(callbackId)
        );
    },
    WXReadBinFileSync:function(filePath){
        return window.WXWASMSDK.WXReadFileSync(
            Pointer_stringify(filePath)
        );
    },
    WXReadFileSync:function(filePath, encoding){
        return window.WXWASMSDK.WXReadFileSync(
            Pointer_stringify(filePath),
            Pointer_stringify(encoding)
        );
    },
    WXShareFileBuffer:function(offset,callbackId){
        window.WXWASMSDK.WXShareFileBuffer(
            HEAPU8,
            offset,
            Pointer_stringify(callbackId)
        )
    },
    WXGetTotalMemorySize: function() {
        return TOTAL_MEMORY; // WebGLMemorySize in bytes
    },
    WXGetTotalStackSize: function() {
        return TOTAL_STACK;
    },
    WXGetStaticMemorySize: function() {
        return STATICTOP - STATIC_BASE;
    },
    WXGetDynamicMemorySize: function() {
        if (typeof DYNAMICTOP !== "undefined") {
            return DYNAMICTOP - DYNAMIC_BASE;
        } else {
            // Unity 5.6+
            return HEAP32[DYNAMICTOP_PTR >> 2] - DYNAMIC_BASE;
        }
    },
    WXOpenCustomerServiceConversation:function(conf, s, f, c){
        window.WXWASMSDK.WXOpenCustomerServiceConversation(Pointer_stringify(conf), Pointer_stringify(s), Pointer_stringify(f), Pointer_stringify(c));
    }

});
