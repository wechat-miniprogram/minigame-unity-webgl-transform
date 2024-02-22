mergeInto(LibraryManager.library, {

    glCompressedTexImage2D: function(target, level, internalFormat, width, height, border, imageSize, data) {

        var lastTid = window._lastTextureId;
        var isMiniProgram = typeof wx !== 'undefined';

        function getMatchId() {
            var webgl2c = internalFormat == 37493;
            if (isMiniProgram && GameGlobal.USED_TEXTURE_COMPRESSION && webgl2c) {
                var length = HEAPU8.subarray(data, data + 1)[0];
                var d = HEAPU8.subarray(data + 1, data + 1 + length);
                var res = [];
                d.forEach(function(v) {
                    res.push(String.fromCharCode(v));
                });
                var matchId = res.join('');
                var start0 = res.length - 8;
                var start1 = res.length - 5;
                if (res[start0] == '_') {
                    start0++;
                    var header = ['a', 's', 't', 'c'];
                    for (var i = 0; i < header.length; i++) {
                        if (res[start0 + i] != header[i]) {
                            return [matchId, '8x8', false];
                        }
                    }
                    start0--;
                    var astcBlockSize = matchId.substring(start0 + 5);
                    return [matchId.substr(0, start0), astcBlockSize, false];
                } else if (res[start1] == '_') {
                    start1++;
                    var size = res[start1++];
                    if (size != '4' && size != '5' && size != '6' && size != '8') {
                        return [matchId, '8x8', false];
                    }
                    var astcBlockSize = size + 'x' + size;
                    var limit = res[start1];
                    var limitType = false;
                    if (limit != '#') {
                        limitType = true;
                    }
                    start1 -= 2;
                    return [matchId.substr(0, start1), astcBlockSize, limitType];
                } else {
                    return [matchId, '8x8', false];
                }
            }
            return [-1, '8x8', false];
        }

        var matchIdInfo = getMatchId();
        var matchId = matchIdInfo[0];
        var astcBlockSize = matchIdInfo[1];
        var limitType = matchIdInfo[2];

        function compressedImage2D(rawData) {
            var format = 0;
            var dataOffset = 16;
            var compressFormat = limitType ? GameGlobal.NoneLimitSupportedTexture : GameGlobal.TextureCompressedFormat;
            switch (compressFormat) {
                case "astc":
                    var astcList = GLctx.getExtension("WEBGL_compressed_texture_astc");
                    if (astcBlockSize == '4x4') {
                        format = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_4x4_KHR;
                        break;
                    }
                    if (astcBlockSize == '5x5') {
                        format = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_5x5_KHR;
                        break;
                    }
                    if (astcBlockSize == '6x6') {
                        format = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_6x6_KHR;
                        break;
                    }
                    format = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_8x8_KHR;
                    break;
                case "etc2":
                    format = GLctx.getExtension("WEBGL_compressed_texture_etc").COMPRESSED_RGBA8_ETC2_EAC;
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
            GLctx["compressedTexImage2D"](target, level, format, width, height, border, new Uint8Array(rawData, dataOffset))
        }

        function texImage2D(image) {
            GLctx.texImage2D(GLctx.TEXTURE_2D, 0, GLctx.RGBA, GLctx.RGBA, GLctx.UNSIGNED_BYTE, image)
        }

        function renderTexture(id) {
            if (!GL.textures[lastTid]) {
                return;
            }
            var PotList = [1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096];
            var _data = GameGlobal.DownloadedTextures[id].data;
            var tid = lastTid;
            if (!GL.textures[tid]) {
                return;
            }
            GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[tid]);

            if (limitType && !GameGlobal.NoneLimitSupportedTexture) {
                texImage2D(_data);
            } else if (!GameGlobal.TextureCompressedFormat) {
                texImage2D(_data);
            } else if (GameGlobal.TextureCompressedFormat == "pvr" && (width !== height || PotList.indexOf(height) == -1)) {
                texImage2D(_data);
            } else if (GameGlobal.TextureCompressedFormat == 'dds' && (height % 4 !== 0 || width % 4 !== 0)) {
                texImage2D(_data);
            } else {
                compressedImage2D(_data);
            }
            GLctx.bindTexture(GLctx.TEXTURE_2D, window._lastBoundTexture ? GL.textures[window._lastBoundTexture] : null);

        }

        function renderTransparent() {
            GLctx.texImage2D(GLctx.TEXTURE_2D, 0, GLctx.RGBA, 1, 1, 0, GLctx.RGBA, GLctx.UNSIGNED_SHORT_4_4_4_4, new Uint16Array([0, 0]))
        }

        if (matchId != -1) {
            if (GameGlobal.DownloadedTextures[matchId] && GameGlobal.DownloadedTextures[matchId].data) {
                renderTexture(matchId)
            } else {
                renderTransparent();
                window.WXWASMSDK.WXDownloadTexture(matchId, width, height, (function() {
                    renderTexture(matchId)
                }), limitType)
            }
            return
        }
        if (GL.currentContext.supportsWebGL2EntryPoints) {
            GLctx["compressedTexImage2D"](target, level, internalFormat, width, height, border, HEAPU8, data, imageSize);
            return
        }
        GLctx["compressedTexImage2D"](target, level, internalFormat, width, height, border, data ? HEAPU8.subarray(data, data + imageSize) : null)
    },
    glCompressedTexSubImage2D: function(target, level, xoffset, yoffset, width, height, format, imageSize, data) {
        var lastTid = window._lastTextureId;
        var isMiniProgram = typeof wx !== 'undefined';

        function getMatchId() {
            var webgl2c = format == 37493;
            if (isMiniProgram && GameGlobal.USED_TEXTURE_COMPRESSION && webgl2c) {
                var length = HEAPU8.subarray(data, data + 1)[0];
                var d = HEAPU8.subarray(data + 1, data + 1 + length);
                var res = [];
                d.forEach(function(v) {
                    res.push(String.fromCharCode(v));
                });
                var matchId = res.join('');
                var start0 = res.length - 8;
                var start1 = res.length - 5;
                if (res[start0] == '_') {
                    start0++;
                    var header = ['a', 's', 't', 'c'];
                    for (var i = 0; i < header.length; i++) {
                        if (res[start0 + i] != header[i]) {
                            return [matchId, '8x8', false];
                        }
                    }
                    start0--;
                    var astcBlockSize = matchId.substring(start0 + 5);
                    return [matchId.substr(0, start0), astcBlockSize, false];
                } else if (res[start1] == '_') {
                    start1++;
                    var size = res[start1++];
                    if (size != '4' && size != '5' && size != '6' && size != '8') {
                        return [matchId, '8x8', false];
                    }
                    var astcBlockSize = size + 'x' + size;
                    var limit = res[start1];
                    var limitType = false;
                    if (limit != '#') {
                        limitType = true;
                    }
                    start1 -= 2;
                    return [matchId.substr(0, start1), astcBlockSize, limitType];
                } else {
                    return [matchId, '8x8', false];
                }
            }
            return [-1, '8x8', false];
        }

        var matchIdInfo = getMatchId();
        var matchId = matchIdInfo[0];
        var astcBlockSize = matchIdInfo[1];
        var limitType = matchIdInfo[2];

        function compressedImage2D(rawData) {
            var format = 0;
            var dataOffset = 16;
            var compressFormat = limitType ? GameGlobal.NoneLimitSupportedTexture : GameGlobal.TextureCompressedFormat;
            switch (compressFormat) {
                case "astc":
                    var astcList = GLctx.getExtension("WEBGL_compressed_texture_astc");
                    if (astcBlockSize == '4x4') {
                        format = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_4x4_KHR;
                        break;
                    }
                    if (astcBlockSize == '5x5') {
                        format = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_5x5_KHR;
                        break;
                    }
                    if (astcBlockSize == '6x6') {
                        format = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_6x6_KHR;
                        break;
                    }
                    format = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_8x8_KHR;
                    break;
                case "etc2":
                    format = GLctx.getExtension("WEBGL_compressed_texture_etc").COMPRESSED_RGBA8_ETC2_EAC;
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
            GLctx["compressedTexSubImage2D"](target, level, xoffset, yoffset, width, height, format, new Uint8Array(rawData, dataOffset))
        }

        function texImage2D(image) {
            GLctx.texSubImage2D(target, level, xoffset, yoffset, width, height, GLctx.RGBA, GLctx.UNSIGNED_BYTE, image)
        }

        function renderTexture(id) {
            if (!GL.textures[lastTid]) {
                return;
            }
            var _data = GameGlobal.DownloadedTextures[id].data;
            var tid = lastTid;
            if (!GL.textures[tid]) {
                return;
            }
            GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[tid]);

            if (limitType && !GameGlobal.NoneLimitSupportedTexture) {
                texImage2D(_data);
            } else if (!GameGlobal.TextureCompressedFormat) {
                texImage2D(_data);
            } else if (GameGlobal.TextureCompressedFormat == "pvr" && (width !== height || PotList.indexOf(height) == -1)) {
                texImage2D(_data);
            } else if (GameGlobal.TextureCompressedFormat == 'dds' && (height % 4 !== 0 || width % 4 !== 0)) {
                texImage2D(_data);
            } else {
                compressedImage2D(_data);
            }


            GLctx.bindTexture(GLctx.TEXTURE_2D, window._lastBoundTexture ? GL.textures[window._lastBoundTexture] : null);

        }

        var p = window._lastTexStorage2DParams;
        if (matchId != -1) {
            var f = GLctx.RGBA8;
            switch (GameGlobal.TextureCompressedFormat) {
                case "astc":
                    var astcList = GLctx.getExtension("WEBGL_compressed_texture_astc");
                    if (astcBlockSize == '4x4') {
                        f = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_4x4_KHR;
                        break;
                    }
                    if (astcBlockSize == '5x5') {
                        f = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_5x5_KHR;
                        break;
                    }
                    if (astcBlockSize == '6x6') {
                        f = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_6x6_KHR;
                        break;
                    }
                    f = astcList.COMPRESSED_SRGB8_ALPHA8_ASTC_8x8_KHR;
                    break;
                case "etc2":
                    f = GLctx.getExtension("WEBGL_compressed_texture_etc").COMPRESSED_RGBA8_ETC2_EAC;
                    break;
                case "dds":
                    f = GLctx.getExtension("WEBGL_compressed_texture_s3tc").COMPRESSED_RGBA_S3TC_DXT5_EXT;
                    break;
                case "pvr":
                    f = GLctx.getExtension("WEBGL_compressed_texture_pvrtc").COMPRESSED_RGBA_PVRTC_4BPPV1_IMG;
                    break;
            }
            GLctx["texStorage2D"](p[0], p[1], f, width, height);
            if (GameGlobal.DownloadedTextures[matchId] && GameGlobal.DownloadedTextures[matchId].data) {
                renderTexture(matchId)
            } else {
                window.WXWASMSDK.WXDownloadTexture(matchId, width, height, (function() {
                    renderTexture(matchId)
                }), limitType)
            }
            return
        }
        if (GL.currentContext.supportsWebGL2EntryPoints) {
            GLctx["compressedTexSubImage2D"](target, level, xoffset, yoffset, width, height, format, HEAPU8, data, imageSize);
            return
        }
        GLctx["compressedTexSubImage2D"](target, level, xoffset, yoffset, width, height, format, data ? HEAPU8.subarray(data, data + imageSize) : null)
    },
});