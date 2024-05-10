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
                if (conf[key].indexOf('[]') > -1) {
                    data[key] = [];
                }
                else {
                    data[key] = {};
                    if (ResType[conf[key]]) {
                        formatResponse(conf[key], data[key]);
                    }
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
        else if (conf[key] === 'arrayBuffer') {
            if (id) {
                
                cacheArrayBuffer(id, data[key]);
                data.arrayBufferLength = data[key].byteLength;
                data[key] = [];
            }
            else if (data[key] instanceof ArrayBuffer) {
                data[key] = new Uint8Array(data[key]);
                data[key] = Array.from(data[key]);
            }
            else {
                data[key] = [];
            }
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
export function cacheArrayBuffer(callbackId, data) {
    if (!callbackId || !data) {
        return;
    }
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
function allocateAndSet(byteArray) {
    const ptr = GameGlobal.Module._malloc(byteArray.length);
    GameGlobal.Module.HEAPU8.set(byteArray, ptr);
    return ptr;
}

function convertNumberToPointer(num, ArrayType = Float64Array) {
    const byteArray = numberToUint8Array(num, ArrayType);
    return allocateAndSet(byteArray);
}
function convertArrayBufferToPointer(arrayBuffer) {
    const byteArray = new Uint8Array(arrayBuffer);
    return allocateAndSet(byteArray);
}
function convertStringToPointer(str) {
    const byteArray = GameGlobal.Module.lengthBytesUTF8(str) + 1;
    const ptr = GameGlobal.Module._malloc(byteArray);
    GameGlobal.Module.stringToUTF8(str, ptr, byteArray);
    return ptr;
}
export function convertDataToPointer(data) {
    if (typeof data === 'number') {
        return convertNumberToPointer(data);
    }
    if (typeof data === 'string') {
        return convertStringToPointer(data);
    }
    if (data instanceof ArrayBuffer || typeof data === 'object') {
        return convertArrayBufferToPointer(data);
    }
    return 0;
}

function numberToUint8Array(num, ArrayType = Float64Array) {
    return new Uint8Array(new ArrayType([num]).buffer);
}
function stringToUint8ArrayWithLength(str) {
    const strPtr = convertStringToPointer(str);
    const strBytesLength = GameGlobal.Module.lengthBytesUTF8(str);
    const strBytes = new Uint8Array(GameGlobal.Module.HEAPU8.buffer, strPtr, strBytesLength);
    const lengthBytes = new Uint8Array(4); 
    new DataView(lengthBytes.buffer).setUint32(0, strBytes.length, true); 
    const result = new Uint8Array(4 + strBytes.length);
    result.set(lengthBytes);
    result.set(strBytes, 4);
    GameGlobal.Module._free(strPtr); 
    return result;
}
function createUint8ArrayFromByteArrays(byteArrays) {
    const totalLength = byteArrays.reduce((sum, byteArray) => sum + byteArray.length, 0);
    const result = new Uint8Array(totalLength);
    let offset = 0;
    byteArrays.forEach((byteArray) => {
        result.set(byteArray, offset);
        offset += byteArray.length;
    });
    return result;
}

function touchToUint8Array(touch) {
    return createUint8ArrayFromByteArrays([
        numberToUint8Array(touch.clientX, Float32Array),
        numberToUint8Array(touch.clientY, Float32Array),
        numberToUint8Array(touch.force),
        numberToUint8Array(touch.identifier, Uint32Array),
        numberToUint8Array(touch.pageX, Float32Array),
        numberToUint8Array(touch.pageY, Float32Array),
    ]);
}
function touchesToUint8Array(touches) {
    return createUint8ArrayFromByteArrays(touches.map(touchToUint8Array));
}
function onTouchStartListenerResultToUint8Array(result) {
    return createUint8ArrayFromByteArrays([
        touchesToUint8Array(result.touches),
        touchesToUint8Array(result.changedTouches),
        numberToUint8Array(result.timeStamp, Uint32Array),
    ]);
}
export function convertOnTouchStartListenerResultToPointer(result) {
    return allocateAndSet(onTouchStartListenerResultToUint8Array(result));
}

function infoToUint8Array(info) {
    return createUint8ArrayFromByteArrays([
        stringToUint8ArrayWithLength(info.address),
        stringToUint8ArrayWithLength(info.family),
        numberToUint8Array(info.port, Uint32Array)
    ]);
}
export function convertInfoToPointer(info) {
    return allocateAndSet(infoToUint8Array(info));
}
export function stringifyRes(obj) {
    if (!obj) {
        return '{}';
    }
    return JSON.stringify(obj);
}
