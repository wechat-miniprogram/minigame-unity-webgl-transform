export function toBytesInt32(num) {
    let ascii = '';
    for (let i = 3; i >= 0; i--) {
        ascii += String.fromCharCode((num >> (8 * i)) & 255);
    }
    return ascii;
}
;
export function ceil4(n) {
    
    return (n + 3) & ~3;
}
export function decodeUnicode(buffer, byteOffset, byteLength) {
    const dataview = new Uint8Array(buffer, byteOffset, byteLength);
    const ret = String.fromCharCode.apply(null, Array.from(dataview));
    return ret;
}
