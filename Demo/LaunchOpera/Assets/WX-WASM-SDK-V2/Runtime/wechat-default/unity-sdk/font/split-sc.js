import { ceil4, toBytesInt32, decodeUnicode } from './util';
function extractTTF(ttcView, tableHeaderOffset) {
    
    
    
    
    const subFontTableCount = ttcView.getUint16(tableHeaderOffset + 0x04);
    
    const subFontHeaderLength = 0x0C + subFontTableCount * 0x10;
    
    let tableLength = 0;
    for (let j = 0; j < subFontTableCount; j++) {
        
        const length = ttcView.getUint32(tableHeaderOffset + 0x0C + 0x0C + j * 0x10);
        tableLength += ceil4(length);
    }
    
    const totalLength = subFontHeaderLength + tableLength;
    
    
    const newBuf = new ArrayBuffer(totalLength);
    const newBufUint = new Uint8Array(newBuf);
    const newBufData = new DataView(newBuf);
    
    
    newBufUint.set(new Uint8Array(ttcView.buffer, tableHeaderOffset, subFontHeaderLength), 0);
    
    let currentOffset = subFontHeaderLength;
    for (let j = 0; j < subFontTableCount; j++) {
        
        const offset = ttcView.getUint32(tableHeaderOffset + 0x0C + 0x08 + j * 0x10);
        const length = ttcView.getUint32(tableHeaderOffset + 0x0C + 0x0C + j * 0x10);
        
        
        newBufData.setUint32(0x0C + 0x08 + j * 0x10, currentOffset);
        newBufUint.set(new Uint8Array(ttcView.buffer, offset, length), currentOffset);
        currentOffset += ceil4(length);
    }
    return newBufData;
}


function parseTableToDataView(fontDataView, tableName, startOffset = 0) {
    const font = fontDataView;
    const tableCount = font.getUint16(startOffset + 4);
    for (let i = 0; i < tableCount; i++) {
        const tag = font.getUint32(startOffset + 12 + i * 16);
        const tagStr = toBytesInt32(tag);
        
        if (tagStr === tableName) {
            const offset = font.getUint32(startOffset + 12 + i * 16 + 8);
            const length = font.getUint32(startOffset + 12 + i * 16 + 12);
            return new DataView(fontDataView.buffer, offset, length);
        }
    }
    GameGlobal.manager.Logger.pluginError(`\tTable#${tableName} not found in DataView`);
    return undefined;
}


function parseNameTable(fontDataView, startOffset = 0) {
    const nameTable = parseTableToDataView(fontDataView, 'name', startOffset);
    if (!nameTable) {
        return undefined;
    }
    const result = {};
    result.data = nameTable;
    result.format = nameTable.getUint16(0);
    result.count = nameTable.getUint16(2);
    result.stringOffset = nameTable.getUint16(4);
    const nameRecords = [];
    for (let i = 0; i < result.count; i++) {
        const offset = 6 + i * 12;
        nameRecords.push({
            platformID: nameTable.getUint16(offset),
            platformSpecificID: nameTable.getUint16(offset + 2),
            languageID: nameTable.getUint16(offset + 4),
            nameID: nameTable.getUint16(offset + 6),
            length: nameTable.getUint16(offset + 8),
            offset: nameTable.getUint16(offset + 10),
        });
    }
    result.nameRecords = nameRecords;
    return result;
}

function parseFamilyName(fontDataView, startOffset = 0) {
    const nameTable = parseNameTable(fontDataView, startOffset);
    if (!nameTable) {
        return undefined;
    }
    if (nameTable.nameRecords) {
        for (const record of nameTable.nameRecords) {
            const { nameID } = record;
            if (nameID === 1)  {
                const { offset } = record;
                const byteLength = record.length;
                
                return decodeUnicode(fontDataView.buffer, (nameTable.data?.byteOffset || 0) + (nameTable.stringOffset || 0) + offset, byteLength);
            }
        }
    }
    return undefined;
}

export default function splitTTCToBufferOnlySC(arrayBuffer) {
    const ttc = new DataView(arrayBuffer);
    const tag = ttc.getUint32(0);
    
    if (toBytesInt32(tag) !== 'ttcf') {
        GameGlobal.manager.Logger.pluginError('input not a valid ttc file');
        return undefined;
    }
    
    
    
    const ttfCount = ttc.getInt32(8);
    
    
    let fontSCHeaderOffset = undefined;
    const reg = /S\0?C/;
    for (let i = 0; i < ttfCount; i++) {
        
        const tableHeaderOffset = ttc.getUint32(0x0C + i * 4);
        
        
        const familyName = parseFamilyName(ttc, tableHeaderOffset);
        
        if (typeof familyName === 'string' && reg.test(familyName)) { 
            fontSCHeaderOffset = tableHeaderOffset;
            break;
        }
    }
    if (!fontSCHeaderOffset) {
        GameGlobal.manager.Logger.pluginError('SC Font not found in TTC File.');
        return undefined;
    }
    
    return extractTTF(ttc, fontSCHeaderOffset).buffer;
}
