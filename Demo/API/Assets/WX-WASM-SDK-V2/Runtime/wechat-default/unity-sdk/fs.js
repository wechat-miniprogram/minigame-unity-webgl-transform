import response from './response';
import moduleHelper from './module-helper';
import { formatJsonStr } from './utils';

const tempCacheObj = {};
export default {
        WXGetUserDataPath() {
        return wx.env.USER_DATA_PATH;
    },
    WXWriteFileSync(filePath, data, encoding) {
        try {
            const fs = wx.getFileSystemManager();
            
            fs.writeFileSync(filePath, data, encoding);
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
            ...response.handleText(s, f, c),
        });
    },
    WXWriteFile(filePath, data, encoding, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.writeFile({
            filePath,
            data: data.buffer,
            encoding,
            ...response.handleTextLongBack(s, f, c),
        });
    },
    WXWriteStringFile(filePath, data, encoding, s, f, c) {
        const fs = wx.getFileSystemManager();
        fs.writeFile({
            filePath,
            data,
            encoding,
            ...response.handleTextLongBack(s, f, c),
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
    WXReadFile(filePath, encoding, callbackId) {
        const fs = wx.getFileSystemManager();
        fs.readFile({
            filePath,
            encoding,
            success(res) {
                if (!encoding) {
                    tempCacheObj[callbackId] = res.data;
                    moduleHelper.send('ReadFileCallback', JSON.stringify({
                        callbackId,
                        errMsg: res.errMsg,
                        errCode: 0,
                        byteLength: res.data.byteLength || 0,
                        data: encoding ? res.data : '',
                    }));
                }
                else {
                    moduleHelper.send('ReadFileCallback', JSON.stringify({
                        callbackId,
                        errMsg: res.errMsg,
                        errCode: 0,
                        byteLength: 0,
                        data: encoding ? res.data : '',
                    }));
                }
            },
            fail(res) {
                moduleHelper.send('ReadFileCallback', JSON.stringify({
                    callbackId,
                    errMsg: res.errMsg,
                    errCode: 1,
                }));
            },
        });
    },
    WXReadFileSync(filePath, encoding) {
        const fs = wx.getFileSystemManager();
        try {
            const res = fs.readFileSync(filePath, encoding);
            if (!encoding) {
                tempCacheObj[filePath] = res;
                if (typeof res !== 'string') {
                    return res.byteLength;
                }
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
    WXShareFileBuffer(buffer, offset, callbackId) {
        if (typeof tempCacheObj[callbackId] === 'string') {
            console.error('内存写入异常');
        }
        buffer.set(new Uint8Array(tempCacheObj[callbackId]), offset);
        delete tempCacheObj[callbackId];
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
};
