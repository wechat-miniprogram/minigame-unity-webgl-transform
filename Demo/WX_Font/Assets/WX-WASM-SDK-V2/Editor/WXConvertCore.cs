using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using LitJson;

namespace WeChatWASM
{
    public class WXConvertCore
    {

        static WXConvertCore()
        {
            Init();
        }

        public static void Init()
        {
            config = UnityUtil.GetEditorConf();
            SDKFilePath = Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "index.js");

            PlayerSettings.WebGL.threadsSupport = false;
            PlayerSettings.runInBackground = false;

            PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
#if UNITY_2022_3_OR_NEWER
        PlayerSettings.WebGL.template = "PROJECT:WXTemplate2022";
#elif UNITY_2020_1_OR_NEWER
            PlayerSettings.WebGL.template = "PROJECT:WXTemplate2020";
#else
            PlayerSettings.WebGL.template = "PROJECT:WXTemplate";
#endif

            PlayerSettings.WebGL.linkerTarget = WebGLLinkerTarget.Wasm;

            PlayerSettings.WebGL.dataCaching = false;

#if UNITY_2021_2_OR_NEWER
            PlayerSettings.WebGL.debugSymbolMode = WebGLDebugSymbolMode.External;
#else
            PlayerSettings.WebGL.debugSymbols = true;
#endif

            EditorSettings.spritePackerMode = SpritePackerMode.AlwaysOnAtlas;
        }

        public enum WXExportError
        {
            SUCCEED = 0,
            NODE_NOT_FOUND = 1,
            BUILD_WEBGL_FAILED = 2,
        }

        public static WXEditorScriptObject config;
        public static string webglDir = "webgl"; // 导出的webgl目录
        public static string miniGameDir = "minigame"; // 生成小游戏的目录
        public static string audioDir = "Assets"; // 音频资源目录
        public static string dataFileSize = string.Empty;
        public static string codeMd5 = string.Empty;
        public static string dataMd5 = string.Empty;
        private static string SDKFilePath = string.Empty;
        public static string defaultImgSrc = "Assets/WX-WASM-SDK-V2/Runtime/wechat-default/images/background.jpg";

        // 可以调用这个来集成
        public static WXExportError DoExport(bool buildWebGL = true)
        {
            if (!CheckSDK())
            {
                Debug.LogError("若游戏曾使用旧版本微信SDK，需删除 Assets/WX-WASM-SDK 文件夹后再导入最新工具包。");
                return WXExportError.BUILD_WEBGL_FAILED;
            }
            Init();
            // JSLib
            SettingWXTextureMinJSLib();
            UpdateGraphicAPI();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();

            if (config.ProjectConf.DST == string.Empty)
            {
                Debug.LogError("请先配置游戏导出路径");
                return WXExportError.BUILD_WEBGL_FAILED;
            }
            else
            {
                // 仅删除StreamingAssets目录
                if (config.CompileOptions.DeleteStreamingAssets)
                {
                    UnityUtil.DelectDir(Path.Combine(config.ProjectConf.DST, webglDir + "/StreamingAssets"));
                }

                if (buildWebGL && Build() != 0)
                {
                    return WXExportError.BUILD_WEBGL_FAILED;
                }

                if (WXExtEnvDef.GETDEF("UNITY_2021_2_OR_NEWER") && !config.CompileOptions.DevelopBuild)
                {
                    // 如果是2021版本，官方symbols产生有BUG，这里需要用工具将函数名提取出来
                    WeChatWASM.UnityUtil.preprocessSymbols(GetWebGLSymbolPath());
                }

                ConvertCode();
                string dataFilePath = GetWebGLDataPath();
                if (config.CompileOptions.fbslim && !IsInstantGameAutoStreaming())
                {
                    WXAssetsTextTools.FirstBundleSlim(dataFilePath, (result, info) =>
                    {
                        if (!result)
                        {
                            Debug.LogError("【首包资源优化异常】：" + info);
                        }

                        finishExport();
                    });
                }
                else
                {
                    finishExport();
                }
            }
            return WXExportError.SUCCEED;
        }

        public static void UpdateGraphicAPI()
        {
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.WebGL, false);
            GraphicsDeviceType[] targets = new GraphicsDeviceType[] { };
            if (config.CompileOptions.Webgl2)
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, new GraphicsDeviceType[] { GraphicsDeviceType.OpenGLES3 });
            }
            else
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, new GraphicsDeviceType[] { GraphicsDeviceType.OpenGLES2 });
            }
        }

        private static void ConvertCode()
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to adapt framewor. Dst: " + config.ProjectConf.DST);

            UnityUtil.DelectDir(Path.Combine(config.ProjectConf.DST, miniGameDir));
            string text = String.Empty;
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                text = File.ReadAllText(Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.framework.js"), Encoding.UTF8);
            }
            else
            {
                text = File.ReadAllText(Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.wasm.framework.unityweb"), Encoding.UTF8);
            }
            int i;
            for (i = 0; i < ReplaceRules.rules.Length; i++)
            {
                var rule = ReplaceRules.rules[i];
                text = Regex.Replace(text, rule.old, rule.newStr);
            }

            if (PlayerSettings.WebGL.exceptionSupport == WebGLExceptionSupport.None)
            {
                Rule[] rules =
                {
                    new Rule()
                    {
                        old = "console.log\\(\"Exception at",
                        newStr = "if(Module.IsWxGame);console.log(\"Exception at",
                    },                    new Rule()
                    {
                        old = "throw ptr",
                        newStr = "if(Module.IsWxGame)window.WXWASMSDK.WXUncaughtException(true);else throw ptr",
                    },
                };
                foreach (var rule in rules)
                {
                    text = Regex.Replace(text, rule.old, rule.newStr);
                }
            }

            if (text.Contains("UnityModule"))
            {
                text += ";GameGlobal.unityNamespace.UnityModule = UnityModule;";
            }
            else if (text.Contains("unityFramework"))
            {
                text += ";GameGlobal.unityNamespace.UnityModule = unityFramework;";
            }
            else
            {
                if (text.StartsWith("(") && text.EndsWith(")"))
                {
                    text = text.Substring(1, text.Length - 2);
                }

                text = "GameGlobal.unityNamespace.UnityModule = " + text;
            }

            if (!Directory.Exists(Path.Combine(config.ProjectConf.DST, miniGameDir)))
            {
                Directory.CreateDirectory(Path.Combine(config.ProjectConf.DST, miniGameDir));
            }

            var header = "function createWebAudio(){window.AudioContext=window.AudioContext||window.webkitAudioContext;if(window.AudioContext){return new AudioContext();}return wx.createWebAudioContext();}\n";
            text = header + text;

            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, "webgl.wasm.framework.unityweb.js"), text, new UTF8Encoding(false));

            UnityEngine.Debug.LogFormat("[Converter]  adapt framework done! ");
        }

        private static int Build()
        {
            PlayerSettings.WebGL.emscriptenArgs = string.Empty;
            if (WXExtEnvDef.GETDEF("UNITY_2021_2_OR_NEWER"))
            {
                PlayerSettings.WebGL.emscriptenArgs += " -s EXPORTED_FUNCTIONS=_sbrk,_emscripten_stack_get_base,_emscripten_stack_get_end";
            }
            PlayerSettings.runInBackground = false;
            if (config.ProjectConf.MemorySize != 0)
            {
                if (config.ProjectConf.MemorySize >= 1024)
                {
                    UnityEngine.Debug.LogErrorFormat($"UnityHeap必须小于1024，请查看GIT文档<a href=\"https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/OptimizationMemory.md\">优化Unity WebGL的内存</a>");
                    return -1;
                }
                else if (config.ProjectConf.MemorySize >= 500)
                {
                    UnityEngine.Debug.LogWarningFormat($"UnityHeap大于500M时，32位Android与iOS普通模式较大概率启动失败，中轻度游戏建议小于该值。请查看GIT文档<a href=\"https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/OptimizationMemory.md\">优化Unity WebGL的内存</a>");
                }

                PlayerSettings.WebGL.emscriptenArgs += $" -s TOTAL_MEMORY={config.ProjectConf.MemorySize}MB";
            }

            if (config.CompileOptions.ProfilingMemory)
            {
                PlayerSettings.WebGL.emscriptenArgs += " --memoryprofiler ";
            }

            if (config.CompileOptions.profilingFuncs)
            {
                PlayerSettings.WebGL.emscriptenArgs += " --profiling-funcs ";
            }

            WXExtEnvDef.GOTO("WXEditorWindow.Build");

            UnityEngine.Debug.Log("[Builder] Starting to build WebGL project ... ");
            UnityEngine.Debug.Log("PlayerSettings.WebGL.emscriptenArgs : " + PlayerSettings.WebGL.emscriptenArgs);

            // PlayerSettings.WebGL.memorySize = memorySize;
            BuildOptions option = BuildOptions.None;

            if (config.CompileOptions.DevelopBuild)
            {
                option |= BuildOptions.Development;
            }

            if (config.CompileOptions.AutoProfile)
            {
                option |= BuildOptions.ConnectWithProfiler;
            }

            if (config.CompileOptions.ScriptOnly)
            {
                option |= BuildOptions.BuildScriptsOnly;
            }
#if UNITY_2021_2_OR_NEWER
            if (config.CompileOptions.CleanBuild)
            {
                option |= BuildOptions.CleanBuildCache;
            }
#endif

            if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.WebGL)
            {
                UnityEngine.Debug.LogFormat("[Builder] Current target is: {0}, switching to: {1}", EditorUserBuildSettings.activeBuildTarget, BuildTarget.WebGL);
                if (!EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL))
                {
                    UnityEngine.Debug.LogFormat("[Builder] Switching to {0}/{1} failed!", BuildTargetGroup.WebGL, BuildTarget.WebGL);
                    return -1;
                }
            }

            var projDir = Path.Combine(config.ProjectConf.DST, webglDir);

            var result = BuildPipeline.BuildPlayer(GetScenePaths(), projDir, BuildTarget.WebGL, option);
            if (result.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                UnityEngine.Debug.LogFormat($"[Builder] BuildPlayer failed. emscriptenArgs:{0}", PlayerSettings.WebGL.emscriptenArgs);
                return -1;
            }

            UnityEngine.Debug.LogFormat("[Builder] Done: " + projDir);
            return 0;
        }

        private static string GetWebGLDataPath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.data");
            }
            else
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.data.unityweb");
            }
        }

        private static void finishExport()
        {
            int code = GenerateBinFile();
            if (code == 0)
            {
                checkNeedCopyDataPackage(false);
                UnityEngine.Debug.LogFormat("[Converter] All done!");
                //ShowNotification(new GUIContent("转换完成"));
            }
            else
            {
                checkNeedCopyDataPackage(true);
            }
        }
        /// <summary>
        /// 等brotli之后，统计下资源包加brotli压缩后代码包是否超过了20M（小游戏代码分包总大小限制）
        /// </summary>
        private static void checkNeedCopyDataPackage(bool brotliError)
        {
            // 如果brotli失败，使用CDN加载
            if (brotliError)
            {
                // brotli失败后，因为无法知道wasmcode大小，则得不到最终小游戏总包体大小。不能使用小游戏分包加载资源，还原成cdn的方式。
                if (config.ProjectConf.assetLoadType == 1)
                {
                    UnityEngine.Debug.LogWarning("brotli失败，无法检测文件大小，请上传资源文件到CDN");
                    config.ProjectConf.assetLoadType = 0;
                }

                // ShowNotification(new GUIContent("Brotli压缩失败，请到转出目录手动压缩！！！"));
                Debug.LogError("Brotli压缩失败，请到转出目录手动压缩！");
            }

            if (config.ProjectConf.assetLoadType == 1)
            {
                var dataPath = GetWebGLDataPath();
                var brcodePath = Path.Combine(config.ProjectConf.DST, miniGameDir, "wasmcode", codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");
                var brcodeInfo = new FileInfo(brcodePath);
                var brcodeSize = brcodeInfo.Length;
                if (brcodeSize + int.Parse(dataFileSize) > 20971520)
                {
                    //ShowNotification(new GUIContent("资源文件过大，不适宜用放小游戏包内加载"));
                    Debug.LogError("资源文件过大，不适宜用放小游戏包内加载");
                    throw new Exception("资源文件过大，不适宜用小游戏包内加载");
                }
                else
                {
                    File.Copy(dataPath, Path.Combine(config.ProjectConf.DST, miniGameDir, "data-package", dataMd5 + ".webgl.data.unityweb.bin.txt"), true);
                }
            }

            var loadDataFromCdn = config.ProjectConf.assetLoadType == 0;
            Rule[] rules =
            {
                new Rule()
                {
                    old = "$DEPLOY_URL",
                    newStr = config.ProjectConf.CDN,
                },
                new Rule()
                {
                    old = "$LOAD_DATA_FROM_SUBPACKAGE",
                    newStr = loadDataFromCdn ? "false" : "true",
                },
            };
            string[] files = { "game.js", "game.json", "project.config.json" };
            ReplaceFileContent(files, rules);
        }

        /// <summary>
        /// 对文件做内容替换
        /// </summary>
        /// <param name="files"></param>
        /// <param name="replaceList"></param>
        public static void ReplaceFileContent(string[] files, Rule[] replaceList)
        {
            if (files.Length != 0 && replaceList.Length != 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    var filePath = Path.Combine(config.ProjectConf.DST, miniGameDir, files[i]);
                    string text = File.ReadAllText(filePath, Encoding.UTF8);
                    for (int j = 0; j < replaceList.Length; j++)
                    {
                        var rule = replaceList[j];
                        text = text.Replace(rule.old, rule.newStr);
                    }

                    File.WriteAllText(filePath, text, new UTF8Encoding(false));
                }
            }
        }

        private static string GetWebGLCodePath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.wasm");
            }
            else
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.wasm.code.unityweb");
            }
        }

        private static bool CopyDirectory(string SourcePath, string DestinationPath, bool overwriteexisting)
        {
            bool ret = false;
            var separator = Path.DirectorySeparatorChar;
            var ignoreFiles = new List<string>() { "unityNamespace.js" };

            // eventEmitter - 改名为event-emitter
            // loading和libs 是可交互视频用到的文件，先下掉可交互方案
            var ignoreDirs = new List<string>() { "eventEmitter", "loading", "libs" };
            try
            {
                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                    {
                        Directory.CreateDirectory(DestinationPath);
                    }
                    else
                    {
                        // 已经存在，删掉目录下无用的文件
                        foreach (string filename in ignoreFiles)
                        {
                            var filepath = Path.Combine(DestinationPath, filename);
                            if (File.Exists(filepath))
                            {
                                File.Delete(filepath);
                            }
                        }

                        foreach (string dir in ignoreDirs)
                        {
                            var dirpath = Path.Combine(DestinationPath, dir);
                            if (Directory.Exists(dirpath))
                            {
                                Directory.Delete(dirpath);
                            }
                        }
                    }

                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        if (flinfo.Extension == ".meta" || ignoreFiles.Contains(flinfo.Name))
                        {
                            continue;
                        }
                        flinfo.CopyTo(Path.Combine(DestinationPath, flinfo.Name), overwriteexisting);
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (ignoreDirs.Contains(drinfo.Name))
                        {
                            continue;
                        }
                        if (CopyDirectory(drs, Path.Combine(DestinationPath, drinfo.Name), overwriteexisting) == false)
                        {
                            ret = false;
                        }
                    }
                }

                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                UnityEngine.Debug.LogError(ex);
            }

            return ret;
        }

        public static string FirstBundlePath = "";
        public static int GenerateBinFile(bool isFromConvert = false)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to genarate md5 and copy files");

            var codePath = GetWebGLCodePath();
            codeMd5 = UnityUtil.BuildFileMd5(codePath);
            var dataPath = GetWebGLDataPath();
            dataMd5 = UnityUtil.BuildFileMd5(dataPath);
            var symbolPath = GetWebGLSymbolPath();

            RemoveOldAssetPackage(Path.Combine(config.ProjectConf.DST, webglDir));
            RemoveOldAssetPackage(Path.Combine(config.ProjectConf.DST, webglDir + "-min"));
            FirstBundlePath = Path.Combine(config.ProjectConf.DST, webglDir, dataMd5 + ".webgl.data.unityweb.bin.txt");
            File.Copy(dataPath, FirstBundlePath, true);
            CopyDirectory(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default"), Path.Combine(config.ProjectConf.DST, miniGameDir), true);
            // FIX: 2021.2版本生成symbol有bug，导出时生成symbol报错，有symbol才copy
            // 代码分包需要symbol文件以进行增量更新
            if (File.Exists(symbolPath))
            {
                File.Copy(symbolPath, Path.Combine(config.ProjectConf.DST, miniGameDir, "webgl.wasm.symbols.unityweb"), true);
            }

            var info = new FileInfo(dataPath);
            dataFileSize = info.Length.ToString();
            UnityEngine.Debug.LogFormat("[Converter] that to genarate md5 and copy files ended");
            ModifyWeChatConfigs(isFromConvert);
            ModifySDKFile();
            ClearFriendRelationCode();

            // 如果没有StreamingAssets目录，默认生成
            if (!Directory.Exists(Path.Combine(config.ProjectConf.DST, webglDir, "StreamingAssets")))
            {
                Directory.CreateDirectory(Path.Combine(config.ProjectConf.DST, webglDir, "StreamingAssets"));
            }
            return Brotlib(codePath);
        }

        private static int Brotlib(string filePath)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to generate Brotlib file");
            var dstPath = Path.Combine(config.ProjectConf.DST, miniGameDir, "wasmcode", codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");
            var codeInWebGL = Path.Combine(config.ProjectConf.DST, webglDir, codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");

            // 如果code没有发生过变化，则不再进行br压缩
            if (File.Exists(codeInWebGL))
            {
                File.Copy(codeInWebGL, dstPath);
                return 0;
            }

            // 删除旧的br压缩文件
            if (Directory.Exists(Path.Combine(config.ProjectConf.DST, webglDir)))
            {
                foreach (string path in Directory.GetFiles(Path.Combine(config.ProjectConf.DST, webglDir)))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    if (fileInfo.Name.Contains(".webgl.wasm.code.unityweb.wasm.br"))
                    {
                        File.Delete(fileInfo.FullName);
                    }
                }
            }

            var exePath = string.Empty;
            if (WXExtEnvDef.GETDEF("UNITY_EDITOR_OSX"))
            {
                exePath = Path.Combine(Application.dataPath, "WX-WASM-SDK-V2/Editor/Brotli/macos/brotli");
                if (WXExtEnvDef.GETDEF("UNITY_2021_2_OR_NEWER"))
                {
                    exePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "PlaybackEngines/WebGLSupport/BuildTools/Brotli/macos/brotli");
                }
            }
            else
            {
                exePath = Path.Combine(Application.dataPath, "WX-WASM-SDK-V2/Editor/Brotli/win_x86_64/brotli.exe");
            }
            WeChatWASM.UnityUtil.RunCmd(exePath, string.Format($" --force --quality 11" +
                   $" --input \"{filePath}\"" +
                   $" --output \"{dstPath}\""), string.Empty);
            File.Copy(dstPath, codeInWebGL);
            return 0;
        }


        /// <summary>
        /// 如果没有使用好友关系链的话，自动删掉无用代码
        /// </summary>
        private static void ClearFriendRelationCode()
        {
            var filePath = Path.Combine(config.ProjectConf.DST, miniGameDir, "game.json");

            string content = File.ReadAllText(filePath, Encoding.UTF8);
            JsonData gameJson = JsonMapper.ToObject(content);

            if (!config.SDKOptions.UseFriendRelation || !config.SDKOptions.UseMiniGameChat)
            {
                JsonWriter writer = new JsonWriter();
                writer.IndentValue = 2;
                writer.PrettyPrint = true;

                // 将 game.json 里面关系链相关的配置删除
                if (!config.SDKOptions.UseFriendRelation)
                {
                    gameJson.Remove("openDataContext");
                    gameJson["plugins"].Remove("Layout");

                    // 删除 open-data 相应的文件夹
                    string openDataDir = Path.Combine(config.ProjectConf.DST, miniGameDir, "open-data");
                    UnityUtil.DelectDir(openDataDir);
                    Directory.Delete(openDataDir, true);
                }

                if (!config.SDKOptions.UseMiniGameChat)
                {
                    gameJson["plugins"].Remove("MiniGameChat");
                    UnityEngine.Debug.Log(gameJson["plugins"]);
                }

                // 将配置写回到文件夹
                gameJson.ToJson(writer);
                File.WriteAllText(filePath, writer.TextWriter.ToString());
            }
        }


        private static void ModifySDKFile()
        {
            var config = UnityUtil.GetEditorConf();
            string content = File.ReadAllText(SDKFilePath, Encoding.UTF8);
            content = content.Replace("$unityVersion$", Application.unityVersion);
            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, "unity-sdk", "index.js"), content, Encoding.UTF8);
            content = File.ReadAllText(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "storage.js"), Encoding.UTF8);
            var PreLoadKeys = config.PlayerPrefsKeys.Count > 0 ? JsonMapper.ToJson(config.PlayerPrefsKeys) : "[]";
            content = content.Replace("\"$PreLoadKeys\"", PreLoadKeys);
            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, "unity-sdk", "storage.js"), content, Encoding.UTF8);
            // 修改纹理dxt
            content = File.ReadAllText(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "texture.js"), Encoding.UTF8);
            content = content.Replace("\"$UseDXT5$\"", config.CompressTexture.useDXT5 ? "true" : "false");
            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, "unity-sdk", "texture.js"), content, Encoding.UTF8);
        }

        public static string HandleLoadingImage()
        {
            var info = AssetDatabase.LoadAssetAtPath<Texture>(config.ProjectConf.bgImageSrc);
            var oldFilename = Path.GetFileName(defaultImgSrc);
            var newFilename = Path.GetFileName(config.ProjectConf.bgImageSrc);
            if (config.ProjectConf.bgImageSrc != defaultImgSrc)
            {
                // 图片宽高不能超过2048
                if (info.width > 2048 || info.height > 2048)
                {
                    throw new Exception("封面图宽高不可超过2048");
                }

                File.Delete(Path.Combine(config.ProjectConf.DST, miniGameDir, "images", oldFilename));
                File.Copy(config.ProjectConf.bgImageSrc, Path.Combine(config.ProjectConf.DST, miniGameDir, "images", newFilename), true);
                return "images/" + Path.GetFileName(config.ProjectConf.bgImageSrc);
            }
            else
            {
                return "images/" + Path.GetFileName(defaultImgSrc);
            }
        }
        /// <summary>
        /// 按;分隔字符串，将分隔后每一项作为字符串用,连接
        /// eg: input "i1;i2;i3" => output: `"i1", "i2", "i3"`
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        public static string GetArrayString(string inp)
        {
            var result = string.Empty;
            var iterms = new List<string>(inp.Split(new char[] { ';' }));
            iterms.ForEach((iterm) =>
            {
                if (!string.IsNullOrEmpty(iterm.Trim()))
                {
                    result += "\"" + iterm.Trim() + "\", ";
                }
            });
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Substring(0, result.Length - 2);
            }

            return result;
        }
        private class PreloadFile
        {
            public PreloadFile(string fn, string rp)
            {
                fileName = fn;
                relativePath = rp;
            }

            public string fileName;
            public string relativePath;
        }

        /// <summary>
        /// 从webgl目录模糊搜索preloadfiles中的文件，作为预下载的列表
        /// </summary>
        private static string GetPreloadList(string strPreloadfiles)
        {
            if (strPreloadfiles == string.Empty)
            {
                return string.Empty;
            }

            string preloadList = string.Empty;
            var streamingAssetsPath = Path.Combine(config.ProjectConf.DST, webglDir + "/StreamingAssets");
            var fileNames = strPreloadfiles.Split(new char[] { ';' });
            List<PreloadFile> preloadFiles = new List<PreloadFile>();
            foreach (var fileName in fileNames)
            {
                if (fileName.Trim() == string.Empty)
                {
                    continue;
                }

                preloadFiles.Add(new PreloadFile(fileName, string.Empty));
            }

            if (Directory.Exists(streamingAssetsPath))
            {
                foreach (string path in Directory.GetFiles(streamingAssetsPath, "*", SearchOption.AllDirectories))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    foreach (var preloadFile in preloadFiles)
                    {
                        if (fileInfo.Name.Contains(preloadFile.fileName))
                        {
                            // 相对于StreamingAssets的路径
                            var relativePath = path.Substring(streamingAssetsPath.Length + 1).Replace('\\', '/');
                            preloadFile.relativePath = relativePath;
                            break;
                        }
                    }
                }
            }
            else
            {
                UnityEngine.Debug.LogError("没有找到StreamingAssets目录， 无法生成预下载列表");
            }

            foreach (var preloadFile in preloadFiles)
            {
                if (preloadFile.relativePath == string.Empty)
                {
                    UnityEngine.Debug.LogError($"并非所有预下载的文件都被找到，剩余：{preloadFile.fileName}");
                    continue;
                }

                preloadList += "\"" + preloadFile.relativePath + "\", \r";
            }

            return preloadList;
        }


        public static void ModifyWeChatConfigs(bool isFromConvert = false)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to modify configs");

            var config = UnityUtil.GetEditorConf();

            var PRELOAD_LIST = GetPreloadList(config.ProjectConf.preloadFiles);
            var imgSrc = HandleLoadingImage();

            var bundlePathIdentifierStr = GetArrayString(config.ProjectConf.bundlePathIdentifier);
            var excludeFileExtensionsStr = GetArrayString(config.ProjectConf.bundleExcludeExtensions);

            var screenOrientation = new List<string>() { "portrait", "landscape", "landscapeLeft", "landscapeRight" }[(int)config.ProjectConf.Orientation];

            Rule[] replaceArrayList = ReplaceRules.GenRules(new string[] {
                config.ProjectConf.projectName == string.Empty ? "webgl" : config.ProjectConf.projectName,
                config.ProjectConf.Appid,
                screenOrientation,
                config.ProjectConf.VideoUrl,
                codeMd5,
                dataMd5,
                config.ProjectConf.StreamCDN,
                config.ProjectConf.CDN + "/Assets",
                PRELOAD_LIST,
                imgSrc,
                config.ProjectConf.HideAfterCallMain ? "true" : "false",
                config.ProjectConf.bundleHashLength.ToString(),
                bundlePathIdentifierStr,
                excludeFileExtensionsStr,
                config.CompileOptions.Webgl2 ? "2" : "1",
                Application.unityVersion,
                WXExtEnvDef.pluginVersion,
                config.ProjectConf.dataFileSubPrefix,
                config.ProjectConf.maxStorage.ToString(),
                config.ProjectConf.defaultReleaseSize.ToString(),
                config.ProjectConf.texturesHashLength.ToString(),
                config.ProjectConf.texturesPath,
                config.ProjectConf.needCacheTextures ? "true" : "false",
                config.ProjectConf.loadingBarWidth.ToString(),
                config.ProjectConf.needCheckUpdate ? "true" : "false",
                GetColorSpace(),
                config.ProjectConf.disableHighPerformanceFallback ? "true" : "false",
                config.SDKOptions.PreloadWXFont ? "true" : "false",
                config.CompileOptions.showMonitorSuggestModal ? "true" : "false",
                config.CompileOptions.enableProfileStats ? "true" : "false",
            });

            List<Rule> replaceList = new List<Rule>(replaceArrayList);
            List<string> files = new List<string> { "game.js", "game.json", "project.config.json", "unity-namespace.js", "check-version.js" };

            ReplaceFileContent(files.ToArray(), replaceList.ToArray());

            UnityEngine.Debug.LogFormat("[Converter] that to modify configs ended");
        }

        /// <summary>
        /// 获取当前工程颜色空间
        /// </summary>
        /// <returns></returns>
        private static string GetColorSpace()
        {
            switch (PlayerSettings.colorSpace)
            {
                case ColorSpace.Gamma:
                    return "Gamma";
                case ColorSpace.Linear:
                    return "Linear";
                case ColorSpace.Uninitialized:
                    return "Uninitialized";
                default:
                    return "Unknow";
            }
        }

        /// <summary>
        /// 删掉导出目录webgl目录下旧资源包
        /// </summary>
        private static void RemoveOldAssetPackage(string dstDir)
        {
            try
            {
                if (Directory.Exists(dstDir))
                {
                    foreach (string path in Directory.GetFiles(dstDir))
                    {
                        FileInfo fileInfo = new FileInfo(path);
                        if (fileInfo.Name.Contains("webgl.data.unityweb.bin.txt"))
                        {
                            File.Delete(fileInfo.FullName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex);
            }
        }

        private static string GetWebGLSymbolPath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.symbols.json");
            }
            else
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.wasm.symbols.unityweb");
            }
        }

        private static string[] GetScenePaths()
        {
            List<string> scenes = new List<string>();
            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                var scene = EditorBuildSettings.scenes[i];
                UnityEngine.Debug.LogFormat("[Builder] Scenes [{0}]: {1}, [{2}]", i, scene.path, scene.enabled ? "x" : " ");

                if (scene.enabled)
                {
                    scenes.Add(scene.path);
                }
            }

            return scenes.ToArray();
        }

        /// <summary>
        /// 兼容 WebGL1 WebGL2 Linear Gamma 配置 Assets/WX-WASM-SDK/Plugins
        /// </summary>
        private static void SettingWXTextureMinJSLib()
        {
            string DS = WXAssetsTextTools.DS;
            string jsLibRootDir = $"Assets{DS}WX-WASM-SDK-V2{DS}Runtime{DS}Plugins{DS}";

            // 下方顺序不可变动
            string[] jsLibs = new string[]
            {
                $"{jsLibRootDir}SDK-WX-TextureMin-JS-WEBGL1.jslib",
                $"{jsLibRootDir}SDK-WX-TextureMin-JS-WEBGL2.jslib",
                $"{jsLibRootDir}SDK-WX-TextureMin-JS-WEBGL2-Linear.jslib",
            };
            int index = 0;

            if (config.CompileOptions.Webgl2)
            {
                if (PlayerSettings.colorSpace == ColorSpace.Linear)
                {
                    index = 2;
                }
                else
                {
                    index = 1;
                }
            }

            for (int i = 0; i < jsLibs.Length; i++)
            {
                var importer = AssetImporter.GetAtPath(jsLibs[i]) as PluginImporter;
                bool value = i == index;
                importer.SetCompatibleWithPlatform(BuildTarget.WebGL, value);
                importer.SaveAndReimport();
            }
        }

        public static bool IsInstantGameAutoStreaming()
        {
            if (string.IsNullOrEmpty(GetInstantGameAutoStreamingCDN()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckSDK()
        {
            string dir = Path.Combine(Application.dataPath, "WX-WASM-SDK");
            if (Directory.Exists(dir))
            {
                return false;
            }
            return true;
        }

        public static string GetInstantGameAutoStreamingCDN()
        {
#if UNITY_INSTANTGAME
            string cdn = Unity.InstantGame.IGBuildPipeline.GetInstantGameCDNRoot();
            return cdn;
#else
            return "";
#endif
        }
    }

}