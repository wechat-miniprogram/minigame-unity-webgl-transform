var WXAssetBundleLibrary = {
  $WXFS: {},

  WXFSInit: function (ttl, capacity) {
    function _instanceof(left, right) { if (right != null && typeof Symbol !== "undefined" && right[Symbol.hasInstance]) { return !!right[Symbol.hasInstance](left); } else { return left instanceof right; } }
    function _typeof(obj) { "@babel/helpers - typeof"; return _typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (obj) { return typeof obj; } : function (obj) { return obj && "function" == typeof Symbol && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; }, _typeof(obj); }
    function _classCallCheck(instance, Constructor) { if (!_instanceof(instance, Constructor)) { throw new TypeError("Cannot call a class as a function"); } }
    function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, _toPropertyKey(descriptor.key), descriptor); } }
    function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); Object.defineProperty(Constructor, "prototype", { writable: false }); return Constructor; }
    function _toPropertyKey(arg) { var key = _toPrimitive(arg, "string"); return _typeof(key) === "symbol" ? key : String(key); }
    function _toPrimitive(input, hint) { if (_typeof(input) !== "object" || input === null) return input; var prim = input[Symbol.toPrimitive]; if (prim !== undefined) { var res = prim.call(input, hint || "default"); if (_typeof(res) !== "object") return res; throw new TypeError("@@toPrimitive must return a primitive value."); } return (hint === "string" ? String : Number)(input); }
    var WXMap = /*#__PURE__*/function () {
      function WXMap(hash, rename) {
        _classCallCheck(this, WXMap);
        this.hash = hash;
        this.rename = rename;
        this.size = 0;
      }
      _createClass(WXMap, [{
        key: "get",
        value: function get(key) {
          return this.hash.get(this.rename(key));
        }
      }, {
        key: "set",
        value: function set(key, value) {
          this.delete(key);
          this.size += value;
          return this.hash.set(this.rename(key), value);
        }
      }, {
        key: "has",
        value: function has(key) {
          return this.hash.has(this.rename(key));
        }
      }, {
        key: "delete",
        value: function _delete(key) {
          this.size -= this.hash.get(this.rename(key))|0;
          return this.hash.delete(this.rename(key));
        }
      }]);
      return WXMap;
    }();
    WXFS.disk = new WXMap(unityNamespace.WXAssetBundles,unityNamespace.PathInFileOS);
    WXFS.msg = "";
    WXFS.fd2wxStream = new Map;
    WXFS.path2fd = new Map;
    WXFS.fs = wx.getFileSystemManager();
    WXFS.nowfd = FS.MAX_OPEN_FDS + 1;
    WXFS.isWXAssetBundle = function(url){
      if(url.includes(GameGlobal.unityNamespace.DATA_CDN)){
        return unityNamespace.isWXAssetBundle(WXFS.url2path(url));
      }
      return unityNamespace.isWXAssetBundle(url);
    }
    WXFS.newfd = function(){
      return WXFS.nowfd++;
    }
    WXFS.doWXAccess = function(path, amode){
      if (amode & ~7) {
        return -28;
      }
      try{
        WXFS.fs.accessSync(path);
      } catch(e){
        return -44;
      }
      return 0
    }
    
    var WXFileCache = /*#__PURE__*/function () {
      function WXFileCache(ttl, capacity) {
        _classCallCheck(this, WXFileCache);
        this.ttl = ttl;
        if (capacity > 0) this.capacity = capacity;
        this.hash = new Map();
        this.size = 0;
        this.maxSize = 0;
        this.obsolete = "";
      }
      // record obsolete file path when file not found
      _createClass(WXFileCache, [{
        key: "record",
        value: function record(path) {
          if (!this.obsolete.includes(path)) {
            if (this.obsolete != "") this.obsolete += ";";
            this.obsolete += path;
          }
        }
      }, {
        key: "get",
        value: function get(key) {
          var temp = this.hash.get(key);
          if (temp !== undefined) {
            this.hash.delete(key);
            temp.time = Date.now();
            this.hash.set(key, temp);
            return temp.ab;
          }
          return -1;
        }
      }, {
        key: "put",
        value: function put(key, ab, cleanable) {
          cleanable = cleanable != undefined ? cleanable : true;
          var value = {
            ab: ab,
            time: Date.now(),
            cleanable: cleanable
          };
          var temp = this.hash.get(key);
          if (temp !== undefined) {
            this.size -= temp.ab.byteLength;
            this.hash.delete(key);
            this.hash.set(key, value);
          } else {
            if (this.capacity !== undefined && this.size >= this.capacity) {
              var idx = this.hash.keys().next().value;
              this.size -= idx.ab.byteLength;
              this.hash.delete(idx);
              this.hash.set(key, value);
            } else {
              this.hash.set(key, value);
            }
          }
          this.size += value.ab.byteLength;
          this.maxSize = Math.max(this.size, this.maxSize);
        }
      }, {
        key: "cleanable",
        value: function cleanable(key, _cleanable) {
          _cleanable = _cleanable != undefined ? _cleanable : true;
          var temp = this.hash.get(key);
          if (temp !== undefined) {
            // this.hash.delete(key);
            // temp.time = Date.now();
            temp.cleanable = _cleanable;
            this.hash.set(key, temp);
            return 0;
          } else {
            return -1;
          }
        }
      }, {
        key: "cleanbytime",
        value: function cleanbytime(deadline) {
          var iter = this.hash.keys(),
            key,
            value;
          while ((key = iter.next().value) != undefined && (value = this.hash.get(key)).time < deadline) {
            if (value.cleanable) {
              this.size -= value.ab.byteLength;
              this.hash.delete(key);
            }
          }
        }
      }, {
        key: "RegularCleaning",
        value: function RegularCleaning(kIntervalSecond) {
          var _this = this;
          setInterval(function () {
            _this.cleanbytime(Date.now() - _this.ttl * 1000);
          }, kIntervalSecond * 1000);
        }
      }, {
        key: "delete",
        value: function _delete(key) {
            this.size -= this.hash.get(key).ab.byteLength;
            return this.hash.delete(key)
        }
      }, {
        key: "has",
        value: function _has(key) {
            return this.hash.has(key)
        }
      }
      ]);
      return WXFileCache;
    }();
    
    WXFS.cache = new WXFileCache(ttl, capacity);
    WXFS.cache.RegularCleaning(1);

    WXFS.wxstat = function(path){
      try {
        var fd = WXFS.path2fd.get(path)
        if (fd !== undefined){
          var stat = {
            mode: 33206,
            size: WXFS.cache.get(fd).byteLength,
            dev: 1,
            ino: 1,
            nlink: 1,
            uid: 0,
            gid: 0,
            rdev: 0,
            atime: new Date(),
            mtime: new Date(0),
            ctime: new Date(),
            blksize: 4096
          }
          stat.blocks = Math.ceil(stat.size / stat.blksize);
          return stat;
        }
        var stat = WXFS.fs.statSync(path);
        // something not in wx.FileSystemManager, just fill in 0/1
        stat.dev = 1;
        stat.ino = 1;
        stat.nlink = 1;
        stat.uid = 0;
        stat.gid = 0;
        stat.rdev = 0;
        stat.atime = new Date(stat.lastAccessedTime * 1000);
        stat.mtime = new Date(0); // if update modified time, wasm will log error "Archive file was modified when opened"
        stat.ctime = new Date(stat.lastModifiedTime * 1000); // time of permission modification, just use mtime to instand
        delete stat.lastAccessedTime;
        delete stat.lastModifiedTime;
        stat.blksize = 4096;
        stat.blocks = Math.ceil(stat.size / stat.blksize);
        return stat;
      } catch (e){
        console.error(e)
        throw e;
      }
    }
    WXFS._url2path = new Map();
    WXFS.url2path = function(url) {
      if(WXFS._url2path.has(url)){
        return WXFS._url2path.get(url);
      }
      var path = url.replace(GameGlobal.unityNamespace.DATA_CDN, wx.env.USER_DATA_PATH+'/__GAME_FILE_CACHE/');
      if(path.indexOf('?') > -1){
        path = path.substring(0,path.indexOf("?"));
      }
      WXFS._url2path.set(url, path);
      return path;
    };
    WXFS.read = function(stream, buffer, offset, length, position){
      var contents = WXFS.cache.get(stream.fd);
      if (contents === -1) {
        var res = WXFS.fs.readFileSync(stream.path);
        WXFS.cache.put(stream.fd, res);
        contents = res;
      }
      if (position >= stream.node.usedBytes) return 0;
      var size = Math.min(stream.node.usedBytes - position, length);
      assert(size >= 0);
      buffer.set(new Uint8Array(contents.slice(position, position + size)), offset);
      return size;
    };
  },

  GetObsoleteFilePath: function () {
    var bufferSize = lengthBytesUTF8(WXFS.cache.obsolete) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(WXFS.cache.obsolete, buffer, bufferSize);
    WXFS.cache.obsolete = "";
    return buffer;
  },

  UnCleanbyPath: function (ptr) {
    var url = UTF8ToString(ptr);
    var path = WXFS.url2path(url);
    if(!WXFS.disk.has(path)){
      WXFS.disk.set(path, 0);
    }
  },

  UnloadbyPath: function (ptr) {
    var path = WXFS.url2path(UTF8ToString(ptr));
    var fd = WXFS.path2fd.get(path);
    if(WXFS.cache.has(fd)){
      WXFS.cache.delete(fd);
    }
    if(WXFS.disk.has(path)){
      WXFS.disk.delete(path);
    }
  },

  WXGetBundleFromXML: function(url, id, callback, needRetry){
    needRetry = needRetry?needRetry:true;
    var _url = UTF8ToString(url);
    var _id = UTF8ToString(id);
    var len = lengthBytesUTF8(_id) + 1;
    var idPtr = _malloc(len);
    stringToUTF8(_id, idPtr, len);
    var xhr = new GameGlobal.unityNamespace.UnityLoader.UnityCache.XMLHttpRequest;
    xhr.open('GET', _url, true);
    xhr.responseType = "arraybuffer";
    xhr.onload = function (e) {
      if (xhr.status >= 400 && needRetry) {
        setTimeout(function () {
          _WXGetBundleFromXML(url, false);
        }, 1000);
        xhr=null;
        return false;
      }
      if (callback) {
        var kWebRequestOK = 0;
        var kNoResponseBuffer = 1111;
        var xhrByteArray = new Uint8Array(xhr.response);
        if (xhrByteArray.length != 0) {
          var arrayBuffer = xhr.response;
          var path = WXFS.url2path(_url);
          var numberfd = WXFS.path2fd.get(path);
          if (numberfd == undefined) {
            numberfd = WXFS.newfd();
            WXFS.path2fd.set(path, numberfd);
          }
          var wxStream = WXFS.fd2wxStream.get(numberfd);
          if (wxStream == undefined) {
            wxStream = {
              fd: numberfd,
              path: path,
              seekable: true,
              position: 0,
              stream_ops: MEMFS.stream_ops,
              ungotten: [],
              node:{mode:32768,usedBytes:xhrByteArray.length},
              error: false
            };
            wxStream.stream_ops.read = WXFS.read;
            WXFS.fd2wxStream.set(numberfd, wxStream);
          }
          WXFS.cache.put(numberfd, arrayBuffer, xhr.isReadFromCache);
          WXFS.disk.set(path, xhrByteArray.length);
          dynCall("viii", callback, [idPtr, kWebRequestOK, 0]);
          if(xhr.isReadFromCache){
            _free(idPtr);
          }
        } else {
          dynCall('viii', callback, [idPtr, kNoResponseBuffer, 0]);
          _free(idPtr);
        }
      }
    };
    xhr.onsave = function xhr_onsave(e){
      WXFS.cache.cleanable(WXFS.path2fd.get(e));
      _free(idPtr);
    }
    function XHRHandleError(err, code) {
      if (needRetry) {
        return setTimeout(function () {
          _WXGetBundleFromXML(url, false);
        }, 1e3);
      }
      if (callback) {
        var len = lengthBytesUTF8(err) + 1;
        var buffer = _malloc(len);
        stringToUTF8(err, buffer, len);
        dynCall("viii", callback, [idPtr, code, buffer]);
        _free(buffer);
        _free(idPtr);
      }
    }
    xhr.onerror = function xhr_onerror(e) {
      var kWebErrorUnknown = 2;
      XHRHandleError("Unknown error.", kWebErrorUnknown);
    };
    xhr.ontimeout = function xhr_onerror(e) {
      var kWebErrorTimeout = 14;
      XHRHandleError("Connection timed out.", kWebErrorTimeout);
    };
    xhr.onabort = function xhr_onerror(e) {
      var kWebErrorAborted = 17;
      XHRHandleError("Aborted.", kWebErrorAborted);
    }
    xhr.send();
  },

  WXGetBundleNumberInMemory: function () { 
    return WXFS&&WXFS.cache&&WXFS.cache.hash&&WXFS.cache.hash.size; 
  },
  WXGetBundleNumberOnDisk: function () { 
    return WXFS&&WXFS.disk&&WXFS.disk.hash&&WXFS.disk.hash.size; 
  },
  WXGetBundleSizeInMemory: function () { 
    return WXFS&&WXFS.cache&&WXFS.cache.size; 
  },
  WXGetBundleSizeOnDisk: function () { 
    return WXFS&&WXFS.disk&&WXFS.disk.size; 
  }
};

autoAddDeps(WXAssetBundleLibrary, '$WXFS');
mergeInto(LibraryManager.library, WXAssetBundleLibrary);