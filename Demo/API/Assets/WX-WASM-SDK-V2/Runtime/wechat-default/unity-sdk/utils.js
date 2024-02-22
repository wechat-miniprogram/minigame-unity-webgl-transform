import moduleHelper from './module-helper';
import { ResType } from './resType';
import { ResTypeOther } from './resTypeOther';
Object.assign(ResType, ResTypeOther);
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
    number: 0,
    bool: false,
    object: {},
};
const interfaceTypeMap = {
    array: 'object',
    arrayBuffer: 'object',
    string: 'string',
    number: 'number',
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
        clientX: v.clientX * window.devicePixelRatio,
        clientY: (window.innerHeight - v.clientY) * window.devicePixelRatio,
        force: v.force,
        identifier: formatIdentifier(v.identifier),
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
        else if (conf[key] === 'long') {
            data[key] = parseInt(data[key], 10);
        }
        else if (conf[key] === 'number' && typeof data[key] === 'string') {
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
export function formatResponseNew(type, data) {
    if (!data) {
        data = {};
    }
    if (type === 'ArrayBuffer') {
        return Array.from(new Uint8Array(data));
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
        else if (conf[key] === 'long') {
            data[key] = parseInt(data[key], 10);
        }
        else if (conf[key] === 'number' && typeof data[key] === 'string') {
            data[key] = Number(data[key]);
        }
        else if (conf[key] === 'string' && typeof data[key] === 'number') {
            data[key] = `${data[key]}`;
        }
        else if (conf[key] === 'bool' && (typeof data[key] === 'number' || typeof data[key] === 'string')) {
            data[key] = !!data[key];
        }
        else if (data[key] instanceof ArrayBuffer) {
            data[key] = Array.from(new Uint8Array(data[key]));
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
export function formatJsonStr(str, type) {
    if (!str) {
        return {};
    }
    if (type === 'string|arrayBuffer') {
        return convertBase64ToData(str);
    }
    try {
        const data = JSON.parse(str);
        Object.keys(data).forEach((v) => {
            if (data[v] === null) {
                delete data[v];
            }
        });
        if (type) {
            const conf = ResType[type];
            if (!conf) {
                return data;
            }
            Object.keys(conf).forEach((key) => {
                if (data[key]) {
                    if (conf[key] === 'arrayBuffer') { 
                        data[key] = new Uint8Array(data[key]).buffer;
                    }
                    else if (conf[key] === 'string|arrayBuffer') { 
                        data[key] = convertBase64ToData(data[key]);
                    }
                }
            });
        }
        return data;
    }
    catch (e) {
        return str;
    }
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
function isBase64(str) {
    const base64Pattern = /^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$/;
    return base64Pattern.test(str);
}
function base64ToArrayBuffer(base64) {
    const binaryString = atob(base64);
    const len = binaryString.length;
    const bytes = new Uint8Array(len);
    for (let i = 0; i < len; i++) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    return bytes.buffer;
}
function convertBase64ToData(input) {
    if (isBase64(input)) {
        return base64ToArrayBuffer(input);
    }
    return input;
}
export function stringToUint8ArrayWithLength(str) {
    const strBytesLength = GameGlobal.Module.lengthBytesUTF8(str) + 1; 
    const strPtr = GameGlobal.Module._malloc(strBytesLength); 
    GameGlobal.Module.stringToUTF8(str, strPtr, strBytesLength); 
    const strBytes = new Uint8Array(GameGlobal.Module.HEAPU8.buffer, strPtr, strBytesLength - 1); 
    const lengthBytes = new Uint8Array(4); 
    new DataView(lengthBytes.buffer).setUint32(0, strBytes.length, true); 
    const result = new Uint8Array(4 + strBytes.length);
    result.set(lengthBytes);
    result.set(strBytes, 4);
    GameGlobal.Module._free(strPtr); 
    return result;
}
export function numberToUint8Array(num, ArrayType = Float64Array) {
    return new Uint8Array(new ArrayType([num]).buffer);
}
export function serializeLocalInfo(localInfo) {
    const addressByteArray = stringToUint8ArrayWithLength(localInfo.address);
    const familyByteArray = stringToUint8ArrayWithLength(localInfo.family);
    const portByteArray = numberToUint8Array(localInfo.port, Uint32Array);
    const byteArray = new Uint8Array(addressByteArray.length + familyByteArray.length + portByteArray.length);
    let offset = 0;
    byteArray.set(addressByteArray, offset);
    offset += addressByteArray.length;
    byteArray.set(familyByteArray, offset);
    offset += familyByteArray.length;
    byteArray.set(portByteArray, offset);
    return byteArray;
}
export function serializeRemoteInfo(remoteInfo) {
    const addressByteArray = stringToUint8ArrayWithLength(remoteInfo.address);
    const familyByteArray = stringToUint8ArrayWithLength(remoteInfo.family);
    const portByteArray = numberToUint8Array(remoteInfo.port, Uint32Array);
    const byteArray = new Uint8Array(addressByteArray.length + familyByteArray.length + portByteArray.length);
    let offset = 0;
    byteArray.set(addressByteArray, offset);
    offset += addressByteArray.length;
    byteArray.set(familyByteArray, offset);
    offset += familyByteArray.length;
    byteArray.set(portByteArray, offset);
    return byteArray;
}
