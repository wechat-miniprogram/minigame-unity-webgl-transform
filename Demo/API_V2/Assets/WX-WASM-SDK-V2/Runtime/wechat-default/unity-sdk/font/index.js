
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
const fontOptions = {
    CJK_Unified_Ideographs: {
        include: $CJK_Unified_Ideographs,
        unicodeRange: [0x4E00, 0x9FFF],
    },
    C0_Controls_and_Basic_Latin: {
        include: $C0_Controls_and_Basic_Latin,
        unicodeRange: [0x0000, 0x007F],
    },
    CJK_Symbols_and_Punctuation: {
        include: $CJK_Symbols_and_Punctuation,
        unicodeRange: [0x3000, 0x303F],
    },
    General_Punctuation: {
        include: $General_Punctuation,
        unicodeRange: [0x2000, 0x206F],
    },
    Enclosed_CJK_Letters_and_Months: {
        include: $Enclosed_CJK_Letters_and_Months,
        unicodeRange: [0x3200, 0x32FF],
    },
    Vertical_Forms: {
        include: $Vertical_Forms,
        unicodeRange: [0xFE10, 0xFE1F],
    },
    CJK_Compatibility_Forms: {
        include: $CJK_Compatibility_Forms,
        unicodeRange: [0xFE30, 0xFE4F],
    },
    Miscellaneous_Symbols: {
        include: $Miscellaneous_Symbols,
        unicodeRange: [0x2600, 0x26FF],
    },
    CJK_Compatibility: {
        include: $CJK_Compatibility,
        unicodeRange: [0x3300, 0x33FF],
    },
    Halfwidth_and_Fullwidth_Forms: {
        include: $Halfwidth_and_Fullwidth_Forms,
        unicodeRange: [0xFF00, 0xFFEF],
    },
    Dingbats: {
        include: $Dingbats,
        unicodeRange: [0x2700, 0x27BF],
    },
    Letterlike_Symbols: {
        include: $Letterlike_Symbols,
        unicodeRange: [0x2100, 0x214F],
    },
    Enclosed_Alphanumerics: {
        include: $Enclosed_Alphanumerics,
        unicodeRange: [0x2460, 0x24FF],
    },
    Number_Forms: {
        include: $Number_Forms,
        unicodeRange: [0x2150, 0x218F],
    },
    Currency_Symbols: {
        include: $Currency_Symbols,
        unicodeRange: [0x20A0, 0x20CF],
    },
    Arrows: {
        include: $Arrows,
        unicodeRange: [0x2190, 0x21FF],
    },
    Geometric_Shapes: {
        include: $Geometric_Shapes,
        unicodeRange: [0x25A0, 0x25FF],
    },
    Mathematical_Operators: {
        include: $Mathematical_Operators,
        unicodeRange: [0x2200, 0x22FF],
    },
    CustomUnicodeRange: $CustomUnicodeRange,
};

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
            let unicodeRange = [];
            
            Object.keys(fontOptions).forEach((key) => {
                if (fontOptions[key].include) {
                    unicodeRange.push(fontOptions[key].unicodeRange);
                }
            });
            
            unicodeRange = unicodeRange.concat(fontOptions.CustomUnicodeRange);
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
            }, unicodeRange);
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
