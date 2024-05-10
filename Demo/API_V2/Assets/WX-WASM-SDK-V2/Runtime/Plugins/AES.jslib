var WebAesLibrary = {
  $aesManager: {
    instance: null,
    mode: 0,
    padding: null,
    encCallback: null,
    decCallback: null,
  },

  WebAesInitialize: function (
    mode,
    keyBuffer,
    keySize,
    ivBuffer,
    ivSize,
    encCallback,
    decCallback,
    counter,
    segmentSize
  ) {
    if (typeof window === "undefined" || !window.aesjs) {
      throw new Error("Fail to initialize WebAES. window.aesjs not found.");
    }
    var aesjs = window.aesjs;
    var key = new Uint8Array(Module.HEAPU8.buffer, keyBuffer, keySize);
    var iv = new Uint8Array(Module.HEAPU8.buffer, ivBuffer, ivSize);
    switch (mode) {
      case 1: // CBC
        aesManager.instance = new aesjs.ModeOfOperation.cbc(key, iv);
        break;
      case 2: // ECB
        aesManager.instance = new aesjs.ModeOfOperation.ecb(key);
        break;
      case 3: // OFB
        aesManager.instance = new aesjs.ModeOfOperation.ofb(key, iv);
        break;
      case 4: // CFB
        aesManager.instance = new aesjs.ModeOfOperation.cfb(
          key,
          iv,
          segmentSize
        );
        break;
      case 5:
        break; // Reserved for CTS
      case 6: // CTR, Not used by interop yet
        aesManager.instance = new aesjs.ModeOfOperation.ctr(key, counter);
        break;
      default:
        // Default to ECB
        aesManager.instance = new aesjs.ModeOfOperation.ecb(key);
    }
    aesManager.encCallback = encCallback;
    aesManager.decCallback = decCallback;
  },
  WebAesFinalize: function () {
    aesManager = {
      instance: null,
      mode: 0,
      padding: null,
      encCallback: null,
      decCallback: null,
    };
  },
  WebAesEncrypt: function (plainPtr, size, needPad) {
    if (aesManager.instance === null) {
      throw new Error("Must call initialize before encrypt");
    }
    var key = new Uint8Array(Module.HEAPU8.buffer, plainPtr, size);
    if (needPad) {
      key = aesjs.padding.pkcs7.pad(key);
    }
    // result is Uint8Array
    var result = aesManager.instance.encrypt(key);
    var buffer = _malloc(result.length);
    HEAPU8.set(result, buffer);
    try {
      if (aesManager.encCallback) {
        Module.dynCall_viii(aesManager.encCallback, 1, buffer, result.length);
      }
    } finally {
      _free(buffer);
    }
  },
  WebAesDecrypt: function (cipherPtr, size, needStrip) {
    if (aesManager.instance === null) {
      throw new Error("Must call initialize before decrypt");
    }
    var key = new Uint8Array(Module.HEAPU8.buffer, cipherPtr, size);
    // result is Uint8Array
    var result = aesManager.instance.decrypt(key, needStrip);
    if (needStrip) {
      result = aesjs.padding.pkcs7.strip(result);
    }
    var buffer = _malloc(result.length);
    HEAPU8.set(result, buffer);
    try {
      if (aesManager.decCallback) {
        Module.dynCall_viii(aesManager.decCallback, 0, buffer, result.length);
      }
    } finally {
      _free(buffer);
    }
  },
};

autoAddDeps(WebAesLibrary, "$aesManager");
mergeInto(LibraryManager.library, WebAesLibrary);
