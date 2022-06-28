using UnityEngine;
using System.IO;
using System.Threading;

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

        static string ASTCPath;
        static string PVRTCPath;
        static string PNGPath;
        static string DXT5Path;
        static Semaphore sempore = new Semaphore(8, 8); //最多设置8个进程



        public static string GetASTCPath()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                return Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/astcenc-sse4.1.exe");
            }
            if (UnityEngine.SystemInfo.processorType.ToLower().Contains("apple")) {
                return Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/astcenc-neon");
            }
            return Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/astcenc-avx2");
        }

        public static string GetPVRTCPath()
        {
            return Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/PVRTexToolCLI" + (Application.platform == RuntimePlatform.WindowsEditor ? ".exe" : ""));
        }


        public static string GetDXT5Path()
        {
            return Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/PVRTexToolCLI" + (Application.platform == RuntimePlatform.WindowsEditor ? ".exe" : ""));
        }

        public static string GetPNGPath()
        {
            return Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/pngquant" + (Application.platform == RuntimePlatform.WindowsEditor ? ".exe" : ""));
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
