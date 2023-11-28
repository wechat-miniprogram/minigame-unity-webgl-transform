import moduleHelper from '../module-helper';
import { formatJsonStr } from '../utils';
import fixCmapTable from './fix-cmap';
import readMetrics from './read-metrics';
import splitTTCToBufferOnlySC from './split-sc';

const { platform } = wx.getSystemInfoSync();

const tempCacheObj = {};
let fontDataCache;
let getFontPromise;
let isReadFromCache = false;
const isIOS = platform === 'ios';
const isAndroid = platform === 'android';

function handleGetFontData(config, forceLoad = false) {
    const canGetWxCommonFont = !!GameGlobal.manager?.font?.getCommonFont;
    if (!config && !canGetWxCommonFont) {
        return Promise.reject('invalid usage');
    }
    
    if (!getFontPromise || forceLoad) {
        getFontPromise = new Promise((resolve, reject) => {
            if (!canGetWxCommonFont && !!config) {
                const xhr = new GameGlobal.unityNamespace.UnityLoader.UnityCache.XMLHttpRequest();
                xhr.open('GET', config.fallbackUrl, true);
                xhr.responseType = 'arraybuffer';
                xhr.onload = () => {
                    if ((xhr.status === 200 || xhr.status === 0) && xhr.response) {
                        const notoFontData = xhr.response;
                        fontDataCache = notoFontData;
                        isReadFromCache = xhr.isReadFromCache;
                        resolve();
                    }
                };
                xhr.onerror = reject;
                xhr.send();
                return;
            }
            GameGlobal.manager.font.getCommonFont({
                success(fontData) {
                    
                    if (isIOS) {
                        fixCmapTable(fontData);
                    }
                    if (isAndroid) {
                        const tempData = splitTTCToBufferOnlySC(fontData);
                        if (tempData) {
                            fontData = tempData;
                        }
                    }
                    fontDataCache = fontData;
                    resolve();
                },
                fail: reject,
            });
        });
    }
    return getFontPromise;
}
function WXGetFontRawData(conf, callbackId) {
    const config = formatJsonStr(conf);
    const loadFromRemote = !GameGlobal.manager?.font?.getCommonFont;
    GameGlobal.manager.TimeLogger.timeStart('WXGetFontRawData');
    handleGetFontData(config).then(() => {
        if (fontDataCache) {
            GameGlobal.manager.font.reportGetFontCost(GameGlobal.manager.TimeLogger.timeEnd('WXGetFontRawData'), { loadFromRemote, isReadFromCache, preloadWXFont: GameGlobal.unityNamespace.preloadWXFont });
            const { ascent, descent, lineGap, unitsPerEm } = readMetrics(fontDataCache) || {};
            tempCacheObj[callbackId] = fontDataCache;
            moduleHelper.send('GetFontRawDataCallback', JSON.stringify({ callbackId, type: 'success', res: JSON.stringify({ byteLength: fontDataCache.byteLength, ascent, descent, lineGap, unitsPerEm }) }));
            GameGlobal.manager.Logger.pluginLog(`[font] load font from ${loadFromRemote ? `network, url=${config.fallbackUrl}` : 'local'}`);
            
            fontDataCache = null;
        }
        else {
            GameGlobal.manager.Logger.pluginError('[font] load font error: empty content');
        }
    })
        .catch((err) => {
        GameGlobal.manager.Logger.pluginError('[font] load font error: ', err);
    });
}
function WXShareFontBuffer(buffer, offset, callbackId) {
    if (typeof tempCacheObj[callbackId] === 'string') {
        GameGlobal.manager.Logger.pluginError('[font]内存写入异常');
    }
    buffer.set(new Uint8Array(tempCacheObj[callbackId]), offset);
    delete tempCacheObj[callbackId];
}
export function preloadWxCommonFont() {
    
    if (!!GameGlobal.unityNamespace.preloadWXFont && !!GameGlobal.manager?.font?.getCommonFont) {
        handleGetFontData();
    }
}
export default {
    WXGetFontRawData,
    WXShareFontBuffer,
};
