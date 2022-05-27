using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace WeChatWASM
{
    public class WXFileSystemManager
    {
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXWriteFileSync(string filePath, string data, string encoding);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXWriteBinFileSync(string filePath, byte[] data, int dataLength, string encoding);


        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXWriteFile(string filePath, byte[] data, int dataLength, string encoding, string s, string f, string c);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXWriteStringFile(string filePath, string data, string encoding, string s, string f, string c);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXAppendFile(string filePath, byte[] data, int dataLength, string encoding, string s, string f, string c);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXAppendStringFile(string filePath, string data, string encoding, string s, string f, string c);

#if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXReadFile(string filePath, string encoding, string callbackId);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern int WXReadBinFileSync(string filePath);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXReadFileSync(string filePath,string encoding);


        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXShareFileBuffer(byte[] data,string callbackId);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXAccessFileSync(string filePath);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXAccessFile(string filePath,string s,string f,string c);


        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXCopyFileSync(string srcPath, string destPath);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXCopyFile(string srcPath, string destPath, string s, string f, string c);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXUnlinkSync(string filePath);


        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUnlink(string filePath,  string s, string f, string c);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXMkdir(string dirPath, bool recursive, string s, string f, string c);
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXMkdirSync(string dirPath, bool recursive);
        


        /// <summary>
        /// 请不要调用这个,这个是内部使用的回调方法
        /// </summary>
        public static void HanldReadFileCallback(string msg)
        {
            var res = JsonUtility.FromJson<WXReadFileCallback>(msg);
            var conf = ReadFileDict[res.callbackId];
            if (conf == null)
            {
                return;
            }
            if (res.errCode == 1)
            {
                var obj = new WXReadFileResponse()
                {
                    errMsg = res.errMsg
                };
                conf.fail?.Invoke(obj);
                conf.complete?.Invoke(obj);
            }
            else if (string.IsNullOrEmpty(conf.encoding))
            {
                var sharedBuffer = new byte[res.byteLength];
                WXShareFileBuffer(sharedBuffer, res.callbackId);
                var obj = new WXReadFileResponse()
                {
                    errMsg = res.errMsg,
                    binData = sharedBuffer,
                };
                conf.success?.Invoke(obj);
                conf.complete?.Invoke(obj);
            }
            else {
                var obj = new WXReadFileResponse()
                {
                    errMsg = res.errMsg,
                    stringData = res.data
                };
                conf.fail?.Invoke(obj);
                conf.complete?.Invoke(obj);
            }
            ReadFileDict.Remove(res.callbackId);

        }

        static Dictionary<string, ReadFileParam > ReadFileDict = new Dictionary<string, ReadFileParam>();


        /// <summary>
        /// 同步写文件，详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.writeFileSync.html
        /// </summary>
        /// <param name="filePath">要写入的文件路径 (本地路径)</param>
        /// <param name="data">要写入的文本</param>
        /// <param name="encoding">指定写入文件的字符编码</param>
        /// <returns>错误信息，如果成功的话返回ok</returns>
        public string WriteFileSync(string filePath, string data, string encoding = "utf8")
        {
            return WXWriteFileSync(filePath, data, encoding);
        }


        /// <summary>
        /// 同步写文件，详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.writeFileSync.html
        /// </summary>
        /// <param name="filePath">要写入的文件路径 (本地路径)</param>
        /// <param name="data">要写入的二进制数据</param>
        /// <param name="encoding">指定写入文件的字符编码</param>
        /// <returns>错误信息，如果成功的话返回ok</returns>
        public string WriteFileSync(string filePath, byte[] data, string encoding = "utf8") {
            return WXWriteBinFileSync(filePath, data, data.Length, encoding);
        }


        /// <summary>
        /// 将二进制写入文件, 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.writeFile.html
        /// </summary>
        /// <param name="param"></param>
        public void WriteFile(WriteFileParam param)
        {
            WXWriteFile(
                param.filePath,
                param.data,
                param.data.Length,
                param.encoding,
                WXLongCallBackHandler.Add(param.success),
                WXLongCallBackHandler.Add(param.fail),
                WXLongCallBackHandler.Add(param.complete)
            );
        }

        /// <summary>
        /// 将字符串写入文件, 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.appendFile.html
        /// </summary>
        /// <param name="param"></param>
        public void WriteFile(WriteFileStringParam param)
        {
            WXWriteStringFile(
                param.filePath,
                param.data,
                param.encoding,
                WXLongCallBackHandler.Add(param.success),
                WXLongCallBackHandler.Add(param.fail),
                WXLongCallBackHandler.Add(param.complete)
            );
        }

        /// <summary>
        /// 在文件结尾追加二进制内容, 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.appendFile.html
        /// </summary>
        /// <param name="param"></param>
        public void AppendFile(WriteFileParam param)
        {
            WXAppendFile(
                param.filePath,
                param.data,
                param.data.Length,
                param.encoding,
                WXLongCallBackHandler.Add(param.success),
                WXLongCallBackHandler.Add(param.fail),
                WXLongCallBackHandler.Add(param.complete)
            );
        }

        /// <summary>
        /// 在文件结尾追加文本内容, 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.appendFile.html
        /// </summary>
        /// <param name="param"></param>
        public void AppendFile(WriteFileStringParam param)
        {
            WXAppendStringFile(
                param.filePath,
                param.data,
                param.encoding,
                WXLongCallBackHandler.Add(param.success),
                WXLongCallBackHandler.Add(param.fail),
                WXLongCallBackHandler.Add(param.complete)
            );
        }

        /// <summary>
        /// 读取本地文件内容, 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.readFile.html
        /// </summary>
        /// <param name="param"></param>
        public void ReadFile(ReadFileParam param) {
            var Rid = UnityEngine.Random.Range(0f, 10000000f).ToString();
            var id = param.filePath + Rid;
            ReadFileDict.Add(param.filePath + Rid, param);
            WXReadFile(param.filePath, param.encoding, id);
        }


        /// <summary>
        /// 同步读取本地文件，详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.readFileSync.html
        /// </summary>
        /// <param name="filePath">要读取的文件的路径 (本地路径)</param>
        /// <param name="bytes">返回结果，失败为null</param>
        public byte[] ReadFileSync(string filePath) {
            var length = WXReadBinFileSync(filePath);
            if (length == 0) {
                return null;
            }
            var sharedBuffer = new byte[length];
            WXShareFileBuffer(sharedBuffer, filePath);
            return sharedBuffer;
        }

        /// <summary>
        /// 同步读取本地文件，详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.readFileSync.html
        /// </summary>
        /// <param name="filePath">要读取的文件的路径 (本地路径)</param>
        /// <param name="encodeing">指定读取文件的字符编码,不能为空</param>
        /// <returns></returns>
        public string ReadFileSync(string filePath,string encodeing)
        {
            return WXReadFileSync(filePath, encodeing);
        }


        /// <summary>
        /// 同步判断文件/目录是否存在 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.accessSync.html
        /// </summary>
        /// <param name="path">要判断是否存在的文件/目录路径 (本地路径)</param>
        /// <returns>成功返回 "access:ok" 其他为失败，不可访问</returns>
        public string AccessSync(string path)
        {
            return WXAccessFileSync(path);
        }

        /// <summary>
        /// 判断文件/目录是否存在 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.access.html
        /// </summary>
        /// <param name="param"></param>
        public void Access(AccessParam param)
        {
            WXAccessFile(param.path, WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        /// <summary>
        /// 同步复制文件 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.copyFileSync.html
        /// </summary>
        /// <param name="srcPath">源文件路径，支持本地路径</param>
        /// <param name="destPath">目标文件路径，支持本地路径</param>
        /// <returns>成功返回 "copyFile:ok" 其他为失败</returns>
        public string CopyFileSync(string srcPath, string destPath)
        {
            return WXCopyFileSync(srcPath, destPath);
        }

        /// <summary>
        /// 复制文件 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.copyFile.html
        /// </summary>
        /// <param name="param"></param>
        public void CopyFile(CopyFileParam param)
        {
            WXCopyFile(param.srcPath, param.destPath, WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        /// <summary>
        /// 同步删除文件 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.unlinkSync.html
        /// </summary>
        /// <param name="filePath">源文件路径，支持本地路径</param>
        /// <returns>成功返回 "unlink:ok" 其他为失败</returns>
        public string UnlinkSync(string filePath)
        {
            return WXUnlinkSync(filePath);
        }

        /// <summary>
        /// 删除文件 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.unlink.html 
        /// </summary>
        /// <param name="param"></param>
        public void Unlink(UnlinkParam param)
        {
            WXUnlink(param.filePath, WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }


        /// <summary>
        /// 创建目录, 详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.mkdir.html
        /// </summary>
        /// <param name="param"></param>
        public void Mkdir(MkdirParam param) {
            WXMkdir(param.dirPath, param.recursive,WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }

        /// <summary>
        /// 同步创建目录,详见 https://developers.weixin.qq.com/minigame/dev/api/file/FileSystemManager.mkdirSync.html
        /// </summary>
        /// <param name="dirPath">创建的目录路径 (本地路径)</param>
        /// <param name="recursive">是否在递归创建该目录的上级目录后再创建该目录。如果对应的上级目录已经存在，则不创建该上级目录。如 dirPath 为 a/b/c/d 且 recursive 为 true，将创建 a 目录，再在 a 目录下创建 b 目录，以此类推直至创建 a/b/c 目录下的 d 目录。</param>
        /// <returns></returns>
        public string MkdirSync(string dirPath,bool recursive) {
            return WXMkdirSync(dirPath, recursive);
        }

    }
}
