import moduleHelper from './module-helper';
import { ResType } from './resType';
function realUid(length = 20, char = true) {
    const soup = `${char ? '' : '!#%()*+,-./:;=?@[]^_`{|}~'}ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789`;
    const soupLength = soup.length;
    const id = [];
    for (let i = 0; i < length; i++) {
        id[i] = soup.charAt(Math.random() * soupLength);
    }
    return id.join('');
}
const identifierCache = [];
const tempCacheObj = {};
const typeMap = {
    array: [],
    arrayBuffer: [],
    string: '',
    int: 0,
    bool: false,
    object: {},
};
const interfaceTypeMap = {
    array: 'object',
    arrayBuffer: 'object',
    string: 'string',
    int: 'number',
    bool: 'boolean',
    object: 'object',
};
export const uid = () => realUid(20, true);
export function formatIdentifier(identifier) {
    if (identifier >= 0 && Math.abs(identifier) < 2147483648) {
        return Math.round(identifier);
    }
    
    for (const key in identifierCache) {
        if (identifierCache[key] && identifierCache[key].key === identifier) {
            return identifierCache[key].value;
        }
    }
    let value = parseInt(`${Math.random() * 2147483648}`, 10);
    
    while (identifierCache.some(v => v.value === value)) {
        value += 1;
    }
    identifierCache.push({
        key: identifier,
        value,
    });
    if (identifierCache.length > 30) {
        identifierCache.shift();
    }
    return value;
}
export function formatTouchEvent(v) {
    return {
        identifier: formatIdentifier(v.identifier),
        clientX: v.clientX * window.devicePixelRatio,
        clientY: (window.innerHeight - v.clientY) * window.devicePixelRatio,
        pageX: v.pageX * window.devicePixelRatio,
        pageY: (window.innerHeight - v.pageY) * window.devicePixelRatio,
    };
}
export function formatResponse(type, data, id) {
    if (!data) {
        data = {};
    }
    if (typeof data !== 'object') {
        return {};
    }
    const conf = ResType[type];
    if (!conf) {
        return data;
    }
    
    Object.keys(conf).forEach((key) => {
        if (data[key] === null || typeof data[key] === 'undefined') {
            if (typeof typeMap[conf[key]] === 'undefined') {
                data[key] = {};
                if (ResType[conf[key]]) {
                    formatResponse(conf[key], data[key]);
                }
            }
            else {
                data[key] = typeMap[conf[key]];
            }
        }
        else if (conf[key] === 'int' && typeof data[key] === 'string') {
            data[key] = Number(data[key]);
        }
        else if (conf[key] === 'string' && typeof data[key] === 'number') {
            data[key] = `${data[key]}`;
        }
        else if (conf[key] === 'bool' && (typeof data[key] === 'number' || typeof data[key] === 'string')) {
            data[key] = !!data[key];
        }
        else if (conf[key] === 'arrayBuffer' && id) {
            
            cacheArrayBuffer(id, data[key]);
            data.arrayBufferLength = data[key].byteLength;
            data[key] = [];
        }
        else if (typeof data[key] === 'object' && conf[key] === 'object') {
            Object.keys(data[key]).forEach((v) => {
                if (typeof data[key][v] === 'object') {
                    data[key][v] = JSON.stringify(data[key][v]);
                }
                else {
                    data[key][v] += '';
                }
            });
        }
        else if (typeof data[key] === 'object' && conf[key]) {
            
            const array = conf[key].match(/(.+)\[\]/);
            if (array) {
                for (const itemKey of Object.keys(data[key])) {
                    if (array[1] === 'string') {
                        data[key][itemKey] = `${data[key][itemKey]}`;
                    }
                    else if (array[1] === 'number') {
                        data[key][itemKey] = Number(data[key][itemKey]);
                    }
                    else {
                        formatResponse(array[1], data[key][itemKey]);
                    }
                }
            }
            else {
                formatResponse(conf[key], data[key]);
            }
        }
    });
    
    if (conf.anyKeyWord) {
        return data;
    }
    
    Object.keys(data).forEach((key) => {
        if (typeof conf[key] === 'undefined') {
            delete data[key];
        }
        else {
            const getType = interfaceTypeMap[conf[key]];
            if (getType && getType !== typeof data[key]) {
                data[key] = typeMap[conf[key]];
            }
        }
    });
    return data;
}
export function formatJsonStr(str) {
    if (!str) {
        return {};
    }
    const conf = JSON.parse(str);
    const keys = Object.keys(conf);
    keys.forEach((v) => {
        if (conf[v] === null) {
            delete conf[v];
        }
    });
    return conf;
}
export function cacheArrayBuffer(callbackId, data) {
    tempCacheObj[callbackId] = data;
}
export function setArrayBuffer(buffer, offset, callbackId) {
    buffer.set(new Uint8Array(tempCacheObj[callbackId]), offset);
    delete tempCacheObj[callbackId];
}
export function getListObject(list, name) {
    return (id) => {
        if (!list) {
            list = {};
        }
        const obj = list[id];
        if (!obj) {
            console.error(`${name} 不存在:`, id);
        }
        return obj;
    };
}
export function onEventCallback(list, eventName, id, callbackId) {
    if (!list[id]) {
        list[id] = [];
    }
    const callback = (res) => {
        const resStr = JSON.stringify({
            callbackId: callbackId || id,
            res: JSON.stringify(res),
        });
        moduleHelper.send(eventName, resStr);
    };
    list[id].push(callback);
    return callback;
}
export function offEventCallback(list, callback, id) {
    if (!list || !list[id]) {
        return;
    }
    list[id].forEach(callback);
    delete list[id];
}
