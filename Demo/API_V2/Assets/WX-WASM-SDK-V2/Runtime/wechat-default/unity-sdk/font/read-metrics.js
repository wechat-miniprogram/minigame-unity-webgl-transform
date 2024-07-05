import { toBytesInt32 } from './util';
export default function readMetrics(arrayBuffer) {
    const font = new DataView(arrayBuffer);
    const tableCount = font.getUint16(4);
    const ppem = 1; 
    let ascent = 0;
    let descent = 0;
    let lineGap = 0;
    let unitsPerEm;
    for (let i = 0; i < tableCount; i++) {
        const tag = font.getUint32(12 + i * 16);
        const tagStr = toBytesInt32(tag);
        
        if (tagStr === 'hhea') {
            const offset = font.getUint32(12 + i * 16 + 8);
            const length = font.getUint32(12 + i * 16 + 12);
            
            const hhea = new DataView(arrayBuffer, offset, length);
            ascent = hhea.getInt16(4);
            descent = hhea.getInt16(6);
            lineGap = hhea.getInt16(8);
        }
        else if (tagStr === 'head') {
            const offset = font.getUint32(12 + i * 16 + 8);
            const length = font.getUint32(12 + i * 16 + 12);
            
            const head = new DataView(arrayBuffer, offset, length);
            unitsPerEm = head.getUint16(18);
        }
    }
    if (!ascent || !descent || !unitsPerEm) {
        
        return undefined;
    }
    return {
        ascent: ascent * ppem / unitsPerEm,
        descent: descent * ppem / unitsPerEm,
        lineGap: lineGap * ppem / unitsPerEm,
        unitsPerEm,
    };
}
