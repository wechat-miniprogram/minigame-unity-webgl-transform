export default function fixCmapTable(arrayBuffer) {
    
    const font = new DataView(arrayBuffer);
    const tableCount = font.getUint16(4);
    
    let cmapOffset = 0;
    let cmapLength = 0;
    let cmapCheckSumOffset = 0;
    let cmapCheckSum = 0;
    
    for (let i = 0; i < tableCount; i++) {
        const tag = font.getUint32(12 + i * 16);
        
        if (tag === 0x636D6170) { 
            cmapCheckSumOffset = 12 + i * 16 + 4;
            cmapCheckSum = font.getUint32(cmapCheckSumOffset);
            cmapOffset = font.getUint32(12 + i * 16 + 8);
            cmapLength = font.getUint32(12 + i * 16 + 12);
            GameGlobal.manager.Logger.pluginLog(`[font]cmapCheckSubOffset [${cmapCheckSumOffset}], cmapCheckSum [${cmapCheckSum}], cmapOffset [${cmapOffset}], cmapLength [${cmapLength}]`);
        }
    }
    if (cmapOffset === 0) {
        GameGlobal.manager.Logger.pluginError('[font]not found cmap');
        return false;
    }
    
    const cmap = new DataView(arrayBuffer, cmapOffset, cmapLength);
    const numTables = cmap.getUint16(2);
    let subtableOffset = 4;
    let targetSubtableOffset = 0;
    
    for (let i = 0; i < numTables; i++) {
        const platformId = cmap.getUint16(subtableOffset);
        const encodingId = cmap.getUint16(subtableOffset + 2);
        
        
        if (platformId === 0 && encodingId === 5) {
            if (i === (numTables - 1)) { 
                targetSubtableOffset = subtableOffset;
                GameGlobal.manager.Logger.pluginLog(`[font]targetSubtableOffset ${targetSubtableOffset}`);
            }
            break;
        }
        subtableOffset += 8;
    }
    
    if (targetSubtableOffset > 0) {
        
        
        
        const newCmapView = new DataView(arrayBuffer, cmapOffset, cmapLength - 8);
        
        newCmapView.setUint16(2, numTables - 1);
        let sum = 0;
        const lengthInUint32 = (newCmapView.byteLength + 3) / 4;
        for (let i = 0; i < lengthInUint32; i++) {
            sum += newCmapView.getUint32(i);
        }
        
        font.setUint32(cmapCheckSumOffset, sum);
        return true;
    }
    GameGlobal.manager.Logger.pluginLog('[font]not found cmap subtable');
    
    return false;
}
