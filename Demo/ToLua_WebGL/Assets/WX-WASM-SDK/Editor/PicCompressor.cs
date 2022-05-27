using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using LitJson;
using UnityEditor;
using System.Linq;
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

        public static void CompressPNG(string src, string dstPath, int width, int height,Action action = null)
        {
            sempore.WaitOne();
            UnityUtil.CreateDir(new DirectoryInfo(dstPath).Parent.ToString());

            var config = UnityUtil.GetEditorConf();

            int quality = 65;
            if (config.CompressTexture.QualityList != null && config.CompressTexture.QualityList.Count > 0)
            {
                var txDir = WXTextureManager.textureDstDir.Replace("\\", "/");
                var AssetPath = Application.dataPath;
                foreach (QualityOptions options in config.CompressTexture.QualityList)
                {

                    var p1 = options.Path.Replace("\\", "/").Replace(AssetPath,"");
                    var p2 = src.Replace("\\", "/").Replace(txDir,"");

                    if (p2.IndexOf(p1) > -1)
                    {
                        quality = options.Quality;
                    }
                }
            }

            ASTCPath = GetASTCPath();
            PVRTCPath = GetPVRTCPath();
            PNGPath = GetPNGPath();

            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "magick";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;





            var isTGA = Regex.IsMatch(src.ToLower(), @"\.tga$");
            if (isTGA)
            {
                // tga就是直接翻转的
                p.StartInfo.Arguments = "convert \"" +
    src + "[0]"
    + "\" -quality " + quality + " -resize " + width + "x" + height + "! \"" +
    dstPath + "\"";
            }
            else
            {
                p.StartInfo.Arguments = "convert \"" +
    src +  "[0]"
    + "\" -quality " + quality + " -flip -resize " + width + "x" + height + "! \"" +
    dstPath + "\"";
            }


            if (action !=null) {
                p.EnableRaisingEvents = true;
                p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler((object sender, System.Diagnostics.DataReceivedEventArgs e) => {
                    if (e.Data != null)
                    {
                        Debug.LogError(e.Data);
                    }
                });

                p.Exited += new EventHandler((object sender, EventArgs e) => {

                    sempore.Release();

                    if (!File.Exists(dstPath))
                    {
                        Debug.LogError("图片：" + src + " 生图片纹理失败！");
                    }
                    else
                    {
                        if (action != null)
                            action?.Invoke();
                    }


                });
            }
            // 注册进程结束事件

            try
            {
                p.Start();   //默认为75的压缩率
            }catch(Exception e)
            {
                Debug.LogError(e);
                sempore.Release();
            }

            p.BeginErrorReadLine();
            p.BeginOutputReadLine();
            if (action == null)
            {
                p.WaitForExit();
                p.Close();
            }

        }


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




        public static void CompressASTC(string src, string dstPath, Action action = null)
        {

            //UnityUtil.CreateDir(new DirectoryInfo(dstPath).Parent.ToString());
            sempore.WaitOne();
            if (string.IsNullOrEmpty(ASTCPath))
            {
                ASTCPath = GetASTCPath();
            }
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = ASTCPath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "-cs \"" +
                src
                + "\" \"" +
                dstPath + "\" 8x8 -medium";

            p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler((object sender, System.Diagnostics.DataReceivedEventArgs e) => {
                if (e.Data != null)
                {
                 //   Debug.LogError(e.Data);
                }
            });


            p.EnableRaisingEvents = true;

            p.Exited += new EventHandler((object sender, EventArgs e) => {

                if (File.Exists(dstPath + ".txt"))
                {
                    File.Delete(dstPath + ".txt");
                }

                try
                {
                    File.Move(dstPath, dstPath + ".txt"); //改成txt后缀方便cdn gzip压缩}
                }
                catch (System.Exception)
                {
                    Debug.LogError("图片：" + src + " 生成astc压缩纹理失败！");
                }

                sempore.Release();


                if (action!=null)
                action.Invoke();


            });

            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                sempore.Release();
            }

            p.BeginErrorReadLine();
            p.BeginOutputReadLine();


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

        public static void CompressETC2(string src, string dstPath, Action action = null)
        {  // etc1的也直接用etc2的图片展示


            sempore.WaitOne();

            if (string.IsNullOrEmpty(PVRTCPath)) {
                PVRTCPath = GetPVRTCPath();
            }

            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = PVRTCPath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "-i \"" +
                src
                + "\" -o \"" +
                dstPath + "\" -f ETC2_RGB_A1,UBN,sRGB";

            p.EnableRaisingEvents = true;


            p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler((object sender, System.Diagnostics.DataReceivedEventArgs e) => {
                if (e.Data != null)
                {
                 //   Debug.LogError(e.Data);
                }
            });

            p.Exited += new EventHandler((object sender, EventArgs e) => {


                var finalDst = dstPath + ".txt";
                if (File.Exists(finalDst))
                {
                    File.Delete(finalDst);
                }

                try
                {
                    File.Move(dstPath + ".pvr", finalDst);
                    var bytes = File.ReadAllBytes(finalDst);
                    var index = BitConverter.ToInt32(bytes, 48);
                    File.WriteAllBytes(finalDst, bytes.Skip(index + 52 - 16).Take(bytes.Length).ToArray()); //为了兼容旧版本的解析保留头部16个字节
                }
                catch (System.Exception)
                {
                    Debug.LogError("图片：" + src + " 生成etc2压缩纹理失败！");

                }

                sempore.Release();


                if (action != null)
                    action.Invoke();


            });


            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                sempore.Release();
            }

            p.BeginErrorReadLine();
            p.BeginOutputReadLine();



        }


        public static void CompressPVRTC(string src, string dstPath,  Action action = null)
        {
            sempore.WaitOne();

            if (string.IsNullOrEmpty(PVRTCPath))
            {
                PVRTCPath = GetPVRTCPath();
            }

            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = PVRTCPath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "-i \"" +
                src
                + "\" -o \"" +
                dstPath + "\" -f PVRTC1_4,UBN,sRGB";

            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler((object sender, EventArgs e) => {
                if (File.Exists(dstPath + ".txt"))
                {
                    File.Delete(dstPath + ".txt");
                }

                try
                {
                    File.Move(dstPath, dstPath + ".txt"); //改成txt后缀方便cdn gzip压缩}
                }
                catch (System.Exception)
                {
                    Debug.LogError("图片：" + src + " 生成pvrtc压缩纹理失败！");
                }

                sempore.Release();

                if (action != null)
                    action.Invoke();


            });

            p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler((object sender, System.Diagnostics.DataReceivedEventArgs e) => {

                if (e.Data != null)
                {
                //    Debug.LogError(e.Data);
                }

            });

            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                sempore.Release();
            }

            p.BeginErrorReadLine();
            p.BeginOutputReadLine();


        }

        public static void CompressDXT5(string src, string dstPath, Action action = null)
        {  // pc端的压缩纹理


            sempore.WaitOne();

            if (string.IsNullOrEmpty(DXT5Path))
            {
                DXT5Path = GetDXT5Path();
            }

            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = DXT5Path;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "-i \"" +
                src
                + "\" -o \"" +
                dstPath + "\" -f BC3,UBN,sRGB";

            p.EnableRaisingEvents = true;


            p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler((object sender, System.Diagnostics.DataReceivedEventArgs e) => {
                if (e.Data != null)
                {
                    //   Debug.LogError(e.Data);
                }
            });

            p.Exited += new EventHandler((object sender, EventArgs e) => {


                var finalDst = dstPath + ".txt";
                if (File.Exists(finalDst))
                {
                    File.Delete(finalDst);
                }

                try
                {
                    File.Move(dstPath , finalDst);
                }
                catch (System.Exception)
                {
                    Debug.LogError("图片：" + src + " 生成dxt5压缩纹理失败！");

                }

                sempore.Release();


                if (action != null)
                    action.Invoke();


            });


            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                sempore.Release();
            }

            p.BeginErrorReadLine();
            p.BeginOutputReadLine();



        }


        public static void CompressMinPNG(string src, Action action = null)
        {

            sempore.WaitOne();


            if (string.IsNullOrEmpty(PNGPath))
            {
                PNGPath = GetPNGPath();
            }

            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName =PNGPath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = "\"" +
                src
                + "\" -o \"" +
                src + "\" -f";

            p.EnableRaisingEvents = true;


            p.Exited += new EventHandler((object sender, EventArgs e) => {

                sempore.Release();

                if (action != null)
                    action.Invoke();


            });

            p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler((object sender, System.Diagnostics.DataReceivedEventArgs e) => {

                if (e.Data != null)
                {
                    Debug.LogError(e.Data);
                }

            });

            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                sempore.Release();
            }

            p.BeginErrorReadLine();
            p.BeginOutputReadLine();
        }


    }
}
