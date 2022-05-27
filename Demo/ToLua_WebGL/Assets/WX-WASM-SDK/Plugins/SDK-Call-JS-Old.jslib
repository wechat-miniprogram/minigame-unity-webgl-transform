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
                case "dds":
                    format = GLctx.getExtension("WEBGL_compressed_texture_s3tc").COMPRESSED_RGBA_S3TC_DXT5_EXT;
                    dataOffset = 128;
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
            if(!GL.textures[lastTid]){
                return;
            }
            var PotList = [1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096];
            var cid = imageType + "_" + id;
            var _data = GameGlobal.DownloadedTextures[cid].data;
            var info = {
                "Texture":GameGlobal.TextureConfig,
                "SpriteAtlas":GameGlobal.SpriteAtlasConfig
            }[imageType][id];
            var tid = lastTid;
              if(!GL.textures[tid]){
                return;
              }
            GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[tid]);
            if (!GameGlobal.TextureCompressedFormat || (GameGlobal.TextureCompressedFormat == "pvr" && (info.w !== info.h || PotList.indexOf(info.h)==-1)) || (GameGlobal.TextureCompressedFormat == 'dds' && (info.h%4!==0 || info.w%4!==0))) {
                texImage2D(_data)
            }else{
                compressedImage2D(_data, info.w, info.h);
            }
            GLctx.bindTexture(GLctx.TEXTURE_2D, window._lastBoundTexture ? GL.textures[window._lastBoundTexture] : null);

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
            if ((d[2] | d[3]) === 0 && !(width === 4 && height === 4)) {
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
           if (width === 4 && height === 4) {
             imageType = "Texture"
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
    glCompressedTexSubImage2D:function(target, level, xoffset, yoffset, width, height, format, imageSize, data) {
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
                case "dds":
                    format = GLctx.getExtension("WEBGL_compressed_texture_s3tc").COMPRESSED_RGBA_S3TC_DXT5_EXT;
                    dataOffset = 128;
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
            GLctx["compressedTexSubImage2D"](target, level, xoffset, yoffset, w || width, h || height, format, new Uint8Array(rawData, dataOffset))
        }

        function texImage2D(image,width,height) {
            GLctx.texSubImage2D(target, level, xoffset, yoffset, width, height, GLctx.RGBA, GLctx.UNSIGNED_BYTE, image)
        }

        function renderTexture(id, imageType) {
            if(!GL.textures[lastTid]){
                return;
            }
            var cid = imageType + "_" + id;
            var _data = GameGlobal.DownloadedTextures[cid].data;
            var info = {
                "Texture":GameGlobal.TextureConfig,
                "SpriteAtlas":GameGlobal.SpriteAtlasConfig
            }[imageType][id];
            var tid = lastTid;
            if(!GL.textures[tid]){
                return;
            }
            GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[tid]);
            if (!GameGlobal.TextureCompressedFormat || (GameGlobal.TextureCompressedFormat == "pvr" && info.w !== info.h) || (GameGlobal.TextureCompressedFormat == 'dds' && (info.h%4!==0 || info.w%4!==0))) {
                texImage2D(_data, info.w, info.h)
            }else{
                compressedImage2D(_data, info.w, info.h);
            }
            GLctx.bindTexture(GLctx.TEXTURE_2D, window._lastBoundTexture ? GL.textures[window._lastBoundTexture] : null);

        }

        function getMatchId() {
            if (width * height / 2 !== imageSize || !data || imageSize < 8) {
                return -1
            }
            var id = -1;
            var d = HEAPU8.subarray(data, data + 8);
            if ((d[2] | d[3]) === 0 && !(width === 4 && height === 4)) {
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
        var p = window._lastTexStorage2DParams;
        if (matchId != -1) {
            var imageType = "SpriteAtlas";
            if (width === 4 && height === 4) {
                imageType = "Texture"
            }
            var info = {
                "Texture":GameGlobal.TextureConfig,
                "SpriteAtlas":GameGlobal.SpriteAtlasConfig
            }[imageType][matchId];
            var f = GLctx.RGBA8;
            switch (GameGlobal.TextureCompressedFormat) {
                case "astc":
                    f = GLctx.getExtension("WEBGL_compressed_texture_astc").COMPRESSED_RGBA_ASTC_8x8_KHR;
                    break;
                case "etc2":
                    f = GLctx.getExtension("WEBGL_compressed_texture_etc").COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2;
                case "dds":
                    f = GLctx.getExtension("WEBGL_compressed_texture_s3tc").COMPRESSED_RGBA_S3TC_DXT5_EXT;
                    break;
                case "pvr":
                    f = GLctx.getExtension("WEBGL_compressed_texture_pvrtc").COMPRESSED_RGBA_PVRTC_4BPPV1_IMG;
                    break;
            }
            GLctx["texStorage2D"](p[0], p[1], f, info.w, info.h);
            if (GameGlobal.DownloadedTextures[matchId] && GameGlobal.DownloadedTextures[matchId].data) {
                renderTexture(matchId, imageType)
            } else {
                window.WXWASMSDK.WXDownloadTexture(matchId, imageType, (function () {
                    renderTexture(matchId, imageType)
                }))
            }
            return
        }else if(GameGlobal.TextureConfig || GameGlobal.SpriteAtlasConfig){
            GLctx["texStorage2D"](p[0], p[1], p[2], p[3], p[4])
        }
    if (GL.currentContext.supportsWebGL2EntryPoints) {
        GLctx["compressedTexSubImage2D"](target, level, xoffset, yoffset, width, height, format, HEAPU8, data, imageSize);
        return
    }
    GLctx["compressedTexSubImage2D"](target, level, xoffset, yoffset, width, height, format, data ? HEAPU8.subarray(data, data + imageSize) : null)
    },

    WXInitializeSDK: function (version) {
        window.WXWASMSDK.WXInitializeSDK(_WXPointer_stringify_adaptor(version));
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
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
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
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
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
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateRewardedVideoAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateRewardedVideoAd(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateInterstitialAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateInterstitialAd(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateGridAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateGridAd(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateCustomAd: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateCustomAd(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
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
    WXHideAd: function (id, s, f) {
        window.WXWASMSDK.WXHideAd(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f));
    },
    WXADGetStyleValue: function (id, key) {
        window.WXWASMSDK.WXADGetStyleValue(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXADDestroy: function (id) {
        window.WXWASMSDK.WXADDestroy(_WXPointer_stringify_adaptor(id));
    },
    WXADLoad: function (id, succ, fail) {
        window.WXWASMSDK.WXADLoad(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(succ), _WXPointer_stringify_adaptor(fail));
    },

    WXToTempFilePathSync: function (conf) {
        var returnStr = window.WXWASMSDK.WXToTempFilePathSync(_WXPointer_stringify_adaptor(conf));
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
        var returnStr = window.WXWASMSDK.WXWriteFileSync(_WXPointer_stringify_adaptor(filePath), _WXPointer_stringify_adaptor(data), _WXPointer_stringify_adaptor(encoding));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateFixedBottomMiddleBannerAd: function (adUnitId, adIntervals, height) {
        var returnStr = window.WXWASMSDK.WXCreateFixedBottomMiddleBannerAd(_WXPointer_stringify_adaptor(adUnitId), adIntervals, height);
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
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
    WXSetGameStage: function(stageType) {
        window.WXWASMSDK.WXSetGameStage(stageType);
    },
    WXReportGameStageCostTime: function(totalMs, extJsonStr) {
        window.WXWASMSDK.WXReportGameStageCostTime(totalMs, _WXPointer_stringify_adaptor(extJsonStr));
    },
    WXReportGameStageError: function(errorType, errStr, extJsonStr) {
        window.WXWASMSDK.WXReportGameStageError(errorType, _WXPointer_stringify_adaptor(errStr), _WXPointer_stringify_adaptor(extJsonStr));
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
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXAccessFile: function (path, s, f, c) {
        return window.WXWASMSDK.WXAccessFile(_WXPointer_stringify_adaptor(path), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXCopyFileSync: function (srcPath, destPath) {
        var returnStr = window.WXWASMSDK.WXCopyFileSync(_WXPointer_stringify_adaptor(srcPath), _WXPointer_stringify_adaptor(destPath));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCopyFile: function (srcPath, destPath, s, f, c) {
        return window.WXWASMSDK.WXCopyFile(_WXPointer_stringify_adaptor(srcPath), _WXPointer_stringify_adaptor(destPath), _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXUnlinkSync: function (filePath) {
        var returnStr = window.WXWASMSDK.WXUnlinkSync(_WXPointer_stringify_adaptor(filePath));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
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
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXCreateInnerAudioContext: function (src, loop, startTime, autoplay, volume, playbackRate, needDownload) {
        var returnStr = window.WXWASMSDK.WXCreateInnerAudioContext(_WXPointer_stringify_adaptor(src), loop, startTime, autoplay, volume, playbackRate, needDownload);
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
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
    WXCreateGameClubButton: function (conf) {
        var returnStr = window.WXWASMSDK.WXCreateGameClubButton(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
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
    WXCreateVideo: function(conf){
        var returnStr = window.WXWASMSDK.WXCreateVideo(_WXPointer_stringify_adaptor(conf));
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXVideoPlay: function(id){
        window.WXWASMSDK.WXVideoPlay(_WXPointer_stringify_adaptor(id));
    },
    WXVideoAddListener: function(id,key){
        window.WXWASMSDK.WXVideoAddListener(_WXPointer_stringify_adaptor(id), _WXPointer_stringify_adaptor(key));
    },
    WXVideoDestroy: function(id){
        window.WXWASMSDK.WXVideoDestroy(_WXPointer_stringify_adaptor(id));
    },
    WXVideoExitFullScreen: function(id){
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
    WXWriteFile:function(filePath, data, dataLength, encoding, s, f, c){
        window.WXWASMSDK.WXWriteFile(
            _WXPointer_stringify_adaptor(filePath),
            HEAPU8.slice(data,dataLength+data),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(s),
            _WXPointer_stringify_adaptor(f),
            _WXPointer_stringify_adaptor(c)
        )
    },
    WXWriteStringFile:function (filePath,data,encoding, s, f, c){
        window.WXWASMSDK.WXWriteStringFile(
            _WXPointer_stringify_adaptor(filePath),
            _WXPointer_stringify_adaptor(data),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(s),
            _WXPointer_stringify_adaptor(f),
            _WXPointer_stringify_adaptor(c)
        )
    },
    WXAppendFile:function(filePath, data, dataLength, encoding, s, f, c){
        window.WXWASMSDK.WXAppendFile(
            _WXPointer_stringify_adaptor(filePath),
            HEAPU8.slice(data,dataLength+data),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(s),
            _WXPointer_stringify_adaptor(f),
            _WXPointer_stringify_adaptor(c)
        )
    },
    WXAppendStringFile:function (filePath,data,encoding, s, f, c){
        window.WXWASMSDK.WXAppendStringFile(
            _WXPointer_stringify_adaptor(filePath),
            _WXPointer_stringify_adaptor(data),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(s),
            _WXPointer_stringify_adaptor(f),
            _WXPointer_stringify_adaptor(c)
        )
    },
    WXWriteBinFileSync:function(filePath, data, dataLength, encoding){
        return window.WXWASMSDK.WXWriteBinFileSync(
            _WXPointer_stringify_adaptor(filePath),
            HEAPU8.slice(data,dataLength+data),
            _WXPointer_stringify_adaptor(encoding)
        )
    },
    WXReadFile:function(filePath, encoding,callbackId){
        window.WXWASMSDK.WXReadFile(
            _WXPointer_stringify_adaptor(filePath),
            _WXPointer_stringify_adaptor(encoding),
            _WXPointer_stringify_adaptor(callbackId)
        );
    },
    WXReadBinFileSync:function(filePath){
        return window.WXWASMSDK.WXReadFileSync(
            _WXPointer_stringify_adaptor(filePath)
        );
    },
    WXReadFileSync:function(filePath, encoding){
        var returnStr = window.WXWASMSDK.WXReadFileSync( _WXPointer_stringify_adaptor(filePath), _WXPointer_stringify_adaptor(encoding) );
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    WXShareFileBuffer:function(offset,callbackId){
        window.WXWASMSDK.WXShareFileBuffer(
            HEAPU8,
            offset,
            _WXPointer_stringify_adaptor(callbackId)
        )
    },
    WXGetTotalMemorySize: function() {
        if (typeof TOTAL_MEMORY !== "undefined") {
            return TOTAL_MEMORY
        }
        return buffer.byteLength;
    },
    WXGetTotalStackSize: function() {
        return TOTAL_STACK;
    },
    WXGetStaticMemorySize: function() {
        return STATICTOP - STATIC_BASE;
    },
    WXGetDynamicMemorySize: function() {
        if (typeof DYNAMIC_BASE !== "undefined") {
          return HEAP32[DYNAMICTOP_PTR >> 2] - DYNAMIC_BASE;
        } else {
          return 0
        }
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
        return window.WXWASMSDK.WXCleanAllFileCache();
    },
    WXUncaughtException: function() {
       window.WXWASMSDK.WXUncaughtException(false);
    },
    WXPreLoadShortAudio:function(s){
        window.WXWASMSDK.WXPreLoadShortAudio(_WXPointer_stringify_adaptor(s));
    },
    WXStopOthersAndPlay:function(audio,loop,volume){
        window.WXWASMSDK.WXStopOthersAndPlay(_WXPointer_stringify_adaptor(audio),loop,volume);
    },
    WXShortAudioPlayerStop:function(audio){
        window.WXWASMSDK.WXShortAudioPlayerStop(_WXPointer_stringify_adaptor(audio));
    },
    WXShortAudioPlayerDestroy:function(audio){
        window.WXWASMSDK.WXShortAudioPlayerDestroy(_WXPointer_stringify_adaptor(audio));
    },
    WXMkdir:function(dirPath, recursive, s,  f,  c){
        window.WXWASMSDK.WXMkdir(_WXPointer_stringify_adaptor(dirPath), recursive, _WXPointer_stringify_adaptor(s), _WXPointer_stringify_adaptor(f), _WXPointer_stringify_adaptor(c));
    },
    WXMkdirSync: function (dirPath, recursive) {
        var returnStr = window.WXWASMSDK.WXMkdirSync(_WXPointer_stringify_adaptor(dirPath),recursive);
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
});
