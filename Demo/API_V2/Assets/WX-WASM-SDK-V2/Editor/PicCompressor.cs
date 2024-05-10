using System.IO;
using System.Threading;

using UnityEngine;

namespace WeChatWASM
{
    public class PicTask
    {
        /// <summary>
        /// 0: png, 1:astc, 2:etc2，3：pvrtc
        /// </summary>
        public int type;

        /// <summary>
        /// 图片路径
        /// </summary>
        public string src;
        public string dst;
        public int width;
        public int height;
    }

    /// <summary>
    /// 基于ImageMagick的图片处理
    /// </summary>
    ///
    public static class PicCompressor
    {
        private static string ASTCPath;
        private static string PVRTCPath;
        private static string PNGPath;
        private static string DXT5Path;
        private static Semaphore sempore = new Semaphore(8, 8); // 最多设置8个进程

        public static string GetASTCPath()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                return Path.Combine(UnityUtil.GetWxSDKRootPath(), "Editor/TextureEditor/Node/astcenc-sse4.1.exe");
            }

            if (UnityEngine.SystemInfo.processorType.ToLower().Contains("apple"))
            {
                return Path.Combine(UnityUtil.GetWxSDKRootPath(), "Editor/TextureEditor/Node/astcenc-neon");
            }

            return Path.Combine(UnityUtil.GetWxSDKRootPath(), "Editor/TextureEditor/Node/astcenc-avx2");
        }

        public static string GetPVRTCPath()
        {
            return Path.Combine(UnityUtil.GetWxSDKRootPath(), "Editor/TextureEditor/Node/PVRTexToolCLI" + (Application.platform == RuntimePlatform.WindowsEditor ? ".exe" : string.Empty));
        }

        public static string GetDXT5Path()
        {
            return Path.Combine(UnityUtil.GetWxSDKRootPath(), "Editor/TextureEditor/Node/PVRTexToolCLI" + (Application.platform == RuntimePlatform.WindowsEditor ? ".exe" : string.Empty));
        }

        public static string GetPNGPath()
        {
            return Path.Combine(UnityUtil.GetWxSDKRootPath(), "Editor/TextureEditor/Node/pngquant" + (Application.platform == RuntimePlatform.WindowsEditor ? ".exe" : string.Empty));
        }

        public static void TestASTC()
        {
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = GetASTCPath();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = " -help";

            p.Start();

            string strOuput = p.StandardOutput.ReadToEnd();
            Debug.Log(strOuput);
            p.WaitForExit();
            p.Close();
        }

        public static void TestMinPNG()
        {
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = GetPNGPath();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = " -help";

            p.Start();

            /*
            string strOuput = p.StandardOutput.ReadToEnd();
            Debug.Log(strOuput);
            p.WaitForExit();
            p.Close();
            */
        }

        public static void TestPVRTC()
        {
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = GetPVRTCPath();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = " -help";

            p.Start();
        }
    }
}
