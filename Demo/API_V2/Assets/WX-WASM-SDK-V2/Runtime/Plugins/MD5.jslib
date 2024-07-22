mergeInto(LibraryManager.library, {
  _WebMD5: function(rawData, dataLength, result) {
    var data = new Uint8Array(Module.HEAPU8.buffer, rawData, dataLength);
    var md5Result = window.md5WASM(data, true); // Assuming this always returns a Uint8Array of 16 bytes

    Module.HEAPU8.set(md5Result, result);
  }
});
