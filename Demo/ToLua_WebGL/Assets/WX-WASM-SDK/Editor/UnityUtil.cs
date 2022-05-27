using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace WeChatWASM
{
    /**
     * 工具函数
     */
    public class UnityUtil
    {
        private static bool IsInMacOS
        {
            get
            {
                return UnityEngine.SystemInfo.operatingSystem.IndexOf("Mac OS") != -1;
            }
        }

        private static bool IsInWinOS
        {
            get
            {
                return UnityEngine.SystemInfo.operatingSystem.IndexOf("Windows") != -1;
            }
        }

        private static void OpenInMac(string path)
        {
            bool openInsidesOfFolder = false;

            // try mac
            string macPath = path.Replace("\\", "/"); // mac finder doesn't like backward slashes

            if (Directory.Exists(macPath)) // if path requested is a folder, automatically open insides of that folder
            {
                openInsidesOfFolder = true;
            }

            if (!macPath.StartsWith("\""))
            {
                macPath = "\"" + macPath;
            }

            if (!macPath.EndsWith("\""))
            {
                macPath = macPath + "\"";
            }

            string arguments = (openInsidesOfFolder ? "" : "-R ") + macPath;

            try
            {
                System.Diagnostics.Process.Start("open", arguments);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                // tried to open mac finder in windows
                // just silently skip error
                // we currently have no platform define for the current OS we are in, so we resort to this
                e.HelpLink = ""; // do anything with this variable to silence warning about not using it
            }
        }

        private static void OpenInWin(string path)
        {
            bool openInsidesOfFolder = false;

            // try windows
            string winPath = path.Replace("/", "\\"); // windows explorer doesn't like forward slashes

            if (Directory.Exists(winPath)) // if path requested is a folder, automatically open insides of that folder
            {
                openInsidesOfFolder = true;
            }

            try
            {
                System.Diagnostics.Process.Start("explorer.exe", (openInsidesOfFolder ? "/root," : "/select,") + winPath);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                // tried to open win explorer in mac
                // just silently skip error
                // we currently have no platform define for the current OS we are in, so we resort to this
                e.HelpLink = ""; // do anything with this variable to silence warning about not using it
            }
        }

        public static void ShowInExplorer(string path)
        {
            if (IsInWinOS)
            {
                OpenInWin(path);
            }
            else if (IsInMacOS)
            {
                OpenInMac(path);
            }
            else // couldn't determine OS
            {
                OpenInWin(path);
                OpenInMac(path);
            }
        }

        public static string GetMd5Str(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");

            t2 = t2.ToLower();

            return t2;
        }

        public static string GetMd5Str(byte[] bytes)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(bytes), 4, 8);
            t2 = t2.Replace("-", "");

            t2 = t2.ToLower();

            return t2;
        }

        public static string BuildFileMd5(string filename, int length = 16)
        {
            string filemd5 = null;
            try
            {
                var fileStream = File.OpenRead(filename);
                var md5 = MD5.Create();
                var fileMD5Bytes = md5.ComputeHash(fileStream);//计算指定Stream 对象的哈希值
                filemd5 = BitConverter.ToString(fileMD5Bytes).Replace("-", "").ToLower();
                fileStream.Close();

            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
            return filemd5.Substring(8, length);
        }

        public static void DelectDir(string srcPath)
        {
            if (!Directory.Exists(srcPath))
            {
                return;
            }
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {           //如果 使用了 streamreader 在删除前 必须先关闭流 ，否则无法删除 sr.close();
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void CreateDir(string srcPath)
        {

            if (!Directory.Exists(srcPath))
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                CreateDir(dir.Parent.ToString());
                Directory.CreateDirectory(srcPath);
            }
            return;
        }

        public static void CopyDir(string srcPath, string destPath) {
            if (!Directory.Exists(srcPath))
            {
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)     //判断是否文件夹
                {
                    if (!Directory.Exists(destPath + "/" + i.Name))
                    {
                        Directory.CreateDirectory(destPath + "/" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                    }
                    CopyDir(i.FullName, destPath + "/" + i.Name);    //递归调用复制子文件夹
                }
                else
                {
                    File.Copy(i.FullName, destPath + "/" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                    File.Delete(i.FullName);
                }
            }
        }

        public static WXEditorScriptObject GetEditorConf() {
            var path = "Assets/WX-WASM-SDK/Editor/MiniGameConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath(path, typeof(WXEditorScriptObject)) as WXEditorScriptObject;
            if (config == null)
            {
                AssetDatabase.CreateAsset(EditorWindow.CreateInstance<WXEditorScriptObject>(), path);
                config = AssetDatabase.LoadAssetAtPath(path, typeof(WXEditorScriptObject)) as WXEditorScriptObject;
            }
            return config;
        }

        public static WXTextureCacheObject GetTextureCacheConf()
        {
            var path = "Assets/WX-WASM-SDK/Editor/TextureCacheConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath(path, typeof(WXTextureCacheObject)) as WXTextureCacheObject;
            if (config == null)
            {
                AssetDatabase.CreateAsset(EditorWindow.CreateInstance<WXTextureCacheObject>(), path);
                config = AssetDatabase.LoadAssetAtPath(path, typeof(WXTextureCacheObject)) as WXTextureCacheObject;
            }
            return config;
        }

    }

}