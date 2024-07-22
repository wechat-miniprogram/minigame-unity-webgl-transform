import moduleHelper from '../module-helper';
import { formatJsonStr } from '../utils';
import fixCmapTable from './fix-cmap';
import { launchEventType } from '../../plugin-config';

const { platform } = wx.getSystemInfoSync();

const tempCacheObj = {};
let fontDataCache;
let getFontPromise;
const isIOS = platform === 'ios';

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
    handleGetFontData(config).then(() => {
        if (fontDataCache) {
            tempCacheObj[callbackId] = fontDataCache;
            moduleHelper.send('GetFontRawDataCallback', JSON.stringify({ callbackId, type: 'success', res: JSON.stringify({ byteLength: fontDataCache.byteLength }) }));
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
function preloadWxCommonFont() {
    
    if (!!GameGlobal.unityNamespace.preloadWXFont && !!GameGlobal.manager?.font?.getCommonFont) {
        handleGetFontData();
    }
}
setTimeout(() => {
    GameGlobal.manager.onLaunchProgress((e) => {
        if (e.type === launchEventType.launchPlugin) {
            preloadWxCommonFont();
        }
    });
}, 50);
export default {
    WXGetFontRawData,
    WXShareFontBuffer,
};
