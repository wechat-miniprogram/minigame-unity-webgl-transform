import moduleHelper from './module-helper';
import { formatJsonStr } from './utils';
const tempCacheObj = {};
export default {
  WXGetFontRawData(conf, callbackId) {
    const config = formatJsonStr(conf);
    if (!GameGlobal.manager?.font?.getCommonFont) {
      const xhr = new GameGlobal.unityNamespace.UnityLoader.UnityCache.XMLHttpRequest();
      xhr.open('GET', config.fallbackUrl, true);
      xhr.responseType = 'arraybuffer';
      xhr.onload = () => {
        if ((xhr.status === 200 || xhr.status === 0) && xhr.response) {
          const notoFontData = xhr.response;
          tempCacheObj[callbackId] = notoFontData;
          moduleHelper.send('GetFontRawDataCallback', JSON.stringify({ callbackId, type: 'success', res: JSON.stringify({ byteLength: notoFontData.byteLength }) }));
          console.info('[font] load font from network, url=', config.fallbackUrl);
        }
      };
      xhr.onerror = (e) => {
        moduleHelper.send('GetFontRawDataCallback', JSON.stringify({ callbackId, type: 'fail', res: JSON.stringify(e) }));
      };
      xhr.send();
      return;
    }
    GameGlobal.manager.font.getCommonFont({
      success(fontData) {
        tempCacheObj[callbackId] = fontData;
        moduleHelper.send('GetFontRawDataCallback', JSON.stringify({ callbackId, type: 'success', res: JSON.stringify({ byteLength: fontData.byteLength }) }));
      },
      fail(err) {
        console.error('[font] load font error: ', err);
        moduleHelper.send('GetFontRawDataCallback', JSON.stringify({ callbackId, type: 'fail', res: JSON.stringify(err) }));
      },
    });
  },
  WXShareFontBuffer(buffer, offset, callbackId) {
    if (typeof tempCacheObj[callbackId] === 'string') {
      console.error('内存写入异常');
    }
    buffer.set(new Uint8Array(tempCacheObj[callbackId]), offset);
    delete tempCacheObj[callbackId];
  },
};
