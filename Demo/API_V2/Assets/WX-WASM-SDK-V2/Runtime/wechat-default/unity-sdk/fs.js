import response from './response';
import moduleHelper from './module-helper';
import { cacheArrayBuffer, formatJsonStr, formatResponse } from './utils';
import { fileInfoHandler, fileInfoType, responseWrapper } from './file-info';
function runMethod(method, option, callbackId, isString = false) {
    try {
        const fs = wx.getFileSystemManager();
        let config;
        if (typeof option === 'string') {
            config = formatJsonStr(option);
        }
        else {
            config = option;
        }
        if (method === 'readZipEntry' && !config.encoding) {
            config.encoding = 'utf-8';
            console.error('fs.readZipEntry不支持读取ArrayBuffer，已改为utf-8');
        }
        
        fs[method]({
            ...config,
            success(res) {
                let returnRes = '';
                if (method === 'read') {
                    cacheArrayBuffer(callbackId, res.arrayBuffer);
                    returnRes = JSON.stringify({
                        bytesRead: res.bytesRead,
                        arrayBufferLength: res.arrayBuffer?.byteLength ?? 0,
                    });
                }
                else if (method === 'readCompressedFile') {
                    cacheArrayBuffer(callbackId, res.data);
                    returnRes = JSON.stringify({
                        arrayBufferLength: res.data?.byteLength ?? 0,
                    });
                }
                else if (method === 'readFile') {
                    if (config.encoding) {
                        returnRes = JSON.stringify({
                            stringData: res.data || '',
                        });
                    }
                    else {
                        cacheArrayBuffer(callbackId, res.data);
                        returnRes = JSON.stringify({
                            arrayBufferLength: res.data?.byteLength ?? 0,
                        });
                    }
                }
                else {
                    returnRes = JSON.stringify(res);
                }
                // console.log(`fs.${method} success:`, res);
                moduleHelper.send('FileSystemManagerCallback', JSON.stringify({
                    callbackId, type: 'success', res: returnRes, method: isString ? `${method}_string` : method,
                }));
            },
            fail(res) {
                
                moduleHelper.send('FileSystemManagerCallback', JSON.stringify({
                    callbackId, type: 'fail', res: JSON.stringify(res), method: isString ? `${method}_string` : method,
                }));
            },
            complete(res) {
                moduleHelper.send('FileSystemManagerCallback', JSON.stringify({
                    callbackId, type: 'complete', res: JSON.stringify(res), method: isString ? `${method}_string` : method,
                }));
            },
        });
    }
    catch (e) {
        moduleHelper.send('FileSystemManagerCallback', JSON.stringify({
            callbackId, type: 'complete', res: 'fail', method: isString ? `${method}_string` : method,
        }));
    }
}
export default {
        WXGetUserDataPath() {
        return wx.env.USER_DATA_PATH;
    },
    WXWriteFileSync(filePath, data, encoding) {
        try {
            const fs = wx.getFileSystemManager();
            
            fs.writeFileSync(filePath, data, encoding);
            fileInfoHandler.addFileInfo(filePath, data);
        }
        catch (e) {
            console.error(e);
            if (e.message) {
                return e.message;
            }
            return 'fail';
        }
        return 'ok';
    },
    WXAccessFileSync(filePath) {
        try {
            const fs = wx.getFileSystemManager();
            fs.accessSync(filePath);
            return 'access:ok';
        }
        catch (e) {
            
            if (e.message) {
                return e.message;
            }
            return 'fail';
        }
    },
    WXAccessFile(path, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.access({
            path,
            ...response.handleText(s, f, c),
        });
    },
    WXCopyFileSync(src, dst) {
        try {
            const fs = wx.getFileSystemManager();
            fs.copyFileSync(src, dst);
            return 'copyFile:ok';
        }
        catch (e) {
            console.error(e);
            if (e.message) {
                return e.message;
            }
            return 'fail';
        }
    },
    WXCopyFile(srcPath, destPath, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.copyFile({
            srcPath,
            destPath,
            ...response.handleText(s, f, c),
        });
    },
    WXUnlinkSync(filePath) {
        try {
            const fs = wx.getFileSystemManager();
            fs.unlinkSync(filePath);
            fileInfoHandler.removeFileInfo(filePath);
            return 'unlink:ok';
        }
        catch (e) {
            console.error(e);
            if (e.message) {
                return e.message;
            }
            return 'fail';
        }
    },
    WXUnlink(filePath, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.unlink({
            filePath,
            ...responseWrapper(response.handleText(s, f, c), { filePath, type: fileInfoType.remove }),
        });
    },
    WXWriteFile(filePath, data, encoding, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.writeFile({
            filePath,
            data: data.buffer,
            encoding,
            ...responseWrapper(response.handleTextLongBack(s, f, c), { filePath, data: data.buffer, type: fileInfoType.add }),
        });
    },
    WXWriteStringFile(filePath, data, encoding, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.writeFile({
            filePath,
            data,
            encoding,
            ...responseWrapper(response.handleTextLongBack(s, f, c), { filePath, data, type: fileInfoType.add }),
        });
    },
    WXAppendFile(filePath, data, encoding, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.appendFile({
            filePath,
            data: data.buffer,
            encoding,
            ...response.handleTextLongBack(s, f, c),
        });
    },
    WXAppendStringFile(filePath, data, encoding, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.appendFile({
            filePath,
            data,
            encoding,
            ...response.handleTextLongBack(s, f, c),
        });
    },
    WXWriteBinFileSync(filePath, data, encoding) {
        const fs = wx.getFileSystemManager();
        try {
            fs.writeFileSync(filePath, data.buffer, encoding);
            fileInfoHandler.addFileInfo(filePath, data.buffer);
        }
        catch (e) {
            console.error(e);
            if (e.message) {
                return e.message;
            }
            return 'fail';
        }
        return 'ok';
    },
    WXReadFile(option, callbackId) {
        runMethod('readFile', option, callbackId);
    },
    WXReadFileSync(option) {
        const fs = wx.getFileSystemManager();
        const config = formatJsonStr(option);
        try {
            const { filePath } = config;
            const res = fs.readFileSync(config.filePath, config.encoding, config.position, config.length);
            if (!config.encoding && typeof res !== 'string') {
                cacheArrayBuffer(filePath, res);
                return `${res.byteLength}`;
            }
            return res;
        }
        catch (e) {
            console.error(e);
            if (e.message) {
                return e.message;
            }
            return 'fail';
        }
    },
    WXMkdir(dirPath, recursive, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.mkdir({
            dirPath,
            recursive: Boolean(recursive),
            ...response.handleText(s, f, c),
        });
    },
    WXMkdirSync(dirPath, recursive) {
        try {
            const fs = wx.getFileSystemManager();
            fs.mkdirSync(dirPath, Boolean(recursive));
            return 'mkdir:ok';
        }
        catch (e) {
            console.error(e);
            if (e.message) {
                return e.message;
            }
            return 'fail';
        }
    },
    WXRmdir(dirPath, recursive, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.rmdir({
            dirPath,
            recursive: Boolean(recursive),
            ...response.handleText(s, f, c),
        });
    },
    WXRmdirSync(dirPath, recursive) {
        try {
            const fs = wx.getFileSystemManager();
            fs.rmdirSync(dirPath, Boolean(recursive));
            return 'rmdirSync:ok';
        }
        catch (e) {
            console.error(e);
            if (e.message) {
                return e.message;
            }
            return 'fail';
        }
    },
    WXStat(conf, callbackId) {
        const config = formatJsonStr(conf);
        wx.getFileSystemManager().stat({
            ...config,
            success(res) {
                if (!Array.isArray(res.stats)) {
                    
                    res.one_stat = res.stats;
                    
                    res.stats = null;
                }
                moduleHelper.send('StatCallback', JSON.stringify({
                    callbackId,
                    type: 'success',
                    res: JSON.stringify(res),
                }));
            },
            fail(res) {
                moduleHelper.send('StatCallback', JSON.stringify({
                    callbackId,
                    type: 'fail',
                    res: JSON.stringify(res),
                }));
            },
            complete(res) {
                
                if (!Array.isArray(res.stats)) {
                    
                    res.one_stat = res.stats;
                    
                    res.stats = null;
                }
                moduleHelper.send('StatCallback', JSON.stringify({
                    callbackId,
                    type: 'complete',
                    res: JSON.stringify(res),
                }));
            },
        });
    },
    WX_FileSystemManagerClose(option, callbackId) {
        runMethod('close', option, callbackId);
    },
    WX_FileSystemManagerFstat(option, callbackId) {
        runMethod('fstat', option, callbackId);
    },
    WX_FileSystemManagerFtruncate(option, callbackId) {
        runMethod('ftruncate', option, callbackId);
    },
    WX_FileSystemManagerGetFileInfo(option, callbackId) {
        runMethod('getFileInfo', option, callbackId);
    },
    WX_FileSystemManagerGetSavedFileList(option, callbackId) {
        runMethod('getSavedFileList', option, callbackId);
    },
    WX_FileSystemManagerOpen(option, callbackId) {
        runMethod('open', option, callbackId);
    },
    WX_FileSystemManagerRead(option, data, callbackId) {
        const config = formatJsonStr(option);
        config.arrayBuffer = data.buffer;
        runMethod('read', config, callbackId);
    },
    WX_FileSystemManagerReadCompressedFile(option, callbackId) {
        runMethod('readCompressedFile', option, callbackId);
    },
    WX_FileSystemManagerReadZipEntry(option, callbackId) {
        runMethod('readZipEntry', option, callbackId);
    },
    WX_FileSystemManagerReadZipEntryString(option, callbackId) {
        runMethod('readZipEntry', option, callbackId, true);
    },
    WX_FileSystemManagerReaddir(option, callbackId) {
        runMethod('readdir', option, callbackId);
    },
    WX_FileSystemManagerRemoveSavedFile(option, callbackId) {
        runMethod('removeSavedFile', option, callbackId);
    },
    WX_FileSystemManagerRename(option, callbackId) {
        runMethod('rename', option, callbackId);
    },
    WX_FileSystemManagerSaveFile(option, callbackId) {
        runMethod('saveFile', option, callbackId);
    },
    WX_FileSystemManagerTruncate(option, callbackId) {
        runMethod('truncate', option, callbackId);
    },
    WX_FileSystemManagerUnzip(option, callbackId) {
        runMethod('unzip', option, callbackId);
    },
    WX_FileSystemManagerWrite(option, data, callbackId) {
        const config = formatJsonStr(option);
        config.data = data.buffer;
        runMethod('write', config, callbackId);
    },
    WX_FileSystemManagerWriteString(option, callbackId) {
        runMethod('write', option, callbackId, true);
    },
    WX_FileSystemManagerReaddirSync(dirPath) {
        const fs = wx.getFileSystemManager();
        try {
            
            return JSON.stringify(fs.readdirSync(dirPath) || []);
        }
        catch (e) {
            console.error(e);
            return '[]';
        }
    },
    WX_FileSystemManagerReadCompressedFileSync(option, callbackId) {
        const fs = wx.getFileSystemManager();
        const res = fs.readCompressedFileSync(formatJsonStr(option));
        cacheArrayBuffer(callbackId, res);
        return res.byteLength;
    },
    WX_FileSystemManagerAppendFileStringSync(filePath, data, encoding) {
        const fs = wx.getFileSystemManager();
        fs.appendFileSync(filePath, data, encoding);
    },
    WX_FileSystemManagerAppendFileSync(filePath, data, encoding) {
        const fs = wx.getFileSystemManager();
        fs.appendFileSync(filePath, data.buffer, encoding);
    },
    WX_FileSystemManagerRenameSync(oldPath, newPath) {
        const fs = wx.getFileSystemManager();
        fs.renameSync(oldPath, newPath);
        return 'ok';
    },
    WX_FileSystemManagerReadSync(option, callbackId) {
        const fs = wx.getFileSystemManager();
        const res = fs.readSync(formatJsonStr(option));
        cacheArrayBuffer(callbackId, res.arrayBuffer);
        return JSON.stringify({
            bytesRead: res.bytesRead,
            arrayBufferLength: res.arrayBuffer?.byteLength ?? 0,
        });
    },
    WX_FileSystemManagerFstatSync(option) {
        const fs = wx.getFileSystemManager();
        const res = fs.fstatSync(formatJsonStr(option));
        formatResponse('Stats', res);
        return JSON.stringify(res);
    },
    WX_FileSystemManagerStatSync(path, recursive) {
        const fs = wx.getFileSystemManager();
        const res = fs.statSync(path, recursive);
        let resArray;
        if (Array.isArray(res)) {
            resArray = res;
        }
        else {
            resArray = [res];
        }
        return JSON.stringify(resArray);
    },
    WX_FileSystemManagerWriteSync(option, data) {
        const fs = wx.getFileSystemManager();
        const optionConfig = formatJsonStr(option);
        optionConfig.data = data.buffer;
        const res = fs.writeSync(optionConfig);
        return JSON.stringify({
            mode: res.bytesWritten,
        });
    },
    WX_FileSystemManagerWriteStringSync(option) {
        const fs = wx.getFileSystemManager();
        const res = fs.writeSync(formatJsonStr(option));
        return JSON.stringify({
            mode: res.bytesWritten,
        });
    },
    WX_FileSystemManagerOpenSync(option) {
        const fs = wx.getFileSystemManager();
        return fs.openSync(formatJsonStr(option));
    },
    WX_FileSystemManagerSaveFileSync(tempFilePath, filePath) {
        const fs = wx.getFileSystemManager();
        return fs.saveFileSync(tempFilePath, filePath);
    },
    WX_FileSystemManagerCloseSync(option) {
        const fs = wx.getFileSystemManager();
        fs.closeSync(formatJsonStr(option));
        return 'ok';
    },
    WX_FileSystemManagerFtruncateSync(option) {
        const fs = wx.getFileSystemManager();
        fs.ftruncateSync(formatJsonStr(option));
        return 'ok';
    },
    WX_FileSystemManagerTruncateSync(option) {
        const fs = wx.getFileSystemManager();
        fs.truncateSync(formatJsonStr(option));
        return 'ok';
    },
};
