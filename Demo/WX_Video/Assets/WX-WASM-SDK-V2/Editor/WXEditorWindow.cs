using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using LitJson;

using UnityEditor;

using UnityEngine;
using UnityEngine.Rendering;

namespace WeChatWASM
{
    /// <summary>
    /// 脚本调用的话可修改 Assets/WX-WASM-SDK/Editor/MiniGameConfig.asset配置，然后调用WXEditorWindow 的 DoExport方法导出小游戏
    /// </summary>
    public class WXEditorWindow : EditorWindow
    {
        private string projectName = string.Empty;
        private string appid = string.Empty;
        private string cdn = string.Empty;
        private string videoUrl = string.Empty;
        public static string dst = string.Empty;
        private string streamCDN = string.Empty;
        private int bundleHashLength = 32;
        private string bundlePathIdentifier = "StreamingAssets;";
        private string bundleExcludeExtensions = "json;";
        private string preloadFiles = string.Empty; // 预下载文件名, 以,分隔文件

        // string audioPrefix = "";
        private bool useFriendRelation = false;
        private bool useMiniGameChat = false;
        private bool preloadWXFont = false;
        private bool developBuild = false;
        private bool autoProfile = false;
        private bool scriptOnly = false;
        private bool profilingFuncs = false;
        private bool profilingMemory = false;
        private bool deleteStreamingAssets = true;
        private bool cleanBuild = false;
        private bool cleanCloudDev = false;
        private string customNodePath = string.Empty;
        private int assetLoadType = 0; // 首包资源加载方式
        private bool webgl2 = false;
        private bool fbslim = false;

        private int orientation = 0;

        private static string SDKFilePath = string.Empty;

        public static WXEditorScriptObject config;

        public static string webglDir = "webgl"; // 导出的webgl目录
        public static string miniGameDir = "minigame"; // 生成小游戏的目录
        public static string audioDir = "Assets"; // 音频资源目录
        public string codeMd5 = string.Empty;
        public string dataMd5 = string.Empty;
        public string dataFileSize = string.Empty;
        public Texture tex;
        public string defaultImgSrc = "Assets/WX-WASM-SDK-V2/Runtime/wechat-default/images/background.jpg";
        public string bgImageSrc = string.Empty;
        public int memorySize = 0;
        public bool hideAfterCallMain = true;

        public string dataFileSubPrefix = string.Empty;
        public int maxStorage = 200;
        public int defaultReleaseSize = 31457280;
        public int texturesHashLength = 8;
        public string texturesPath = "Assets/Textures";
        public bool needCacheTextures = false;
        public int loadingBarWidth = 240;
        public bool needCheckUpdate = false;
        public bool disableHighPerformanceFallback = false;
        public bool showMonitorSuggestModal = true;
        public bool enableProfileStats = false;

        [MenuItem("微信小游戏 / 转换小游戏", false, 1)]
        public static void Open()
        {
            if (!WXExtEnvDef.GETDEF("UNITY_2018_1_OR_NEWER"))
            {
                UnityEngine.Debug.LogError("目前仅支持 Unity2018及以上的版本！");
            }
            var win = GetWindow(typeof(WXEditorWindow), false, "转换微信小游戏", true); // 创建窗口
            win.minSize = new Vector2(650, 800);
            win.maxSize = new Vector2(1600, 950);
            win.Show();

            // 打开面板时自动检查更新
            PluginUpdateManager.CheckUpdte();
            Init();
        }

        public static void Init()
        {
            PlayerSettings.WebGL.threadsSupport = false;
            PlayerSettings.runInBackground = false;

            PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                PlayerSettings.WebGL.template = "PROJECT:WXTemplate2020";
            }
            else
            {
                PlayerSettings.WebGL.template = "PROJECT:WXTemplate";
            }
            PlayerSettings.WebGL.linkerTarget = WebGLLinkerTarget.Wasm;
            PlayerSettings.WebGL.dataCaching = false;

            WXExtEnvDef.GOTO("WXEditorWindow.Init");

            EditorSettings.spritePackerMode = SpritePackerMode.AlwaysOnAtlas;
        }

        public void OnEnable()
        {
            Init();
            LoadData();
            UpdateGraphicAPI();
        }

        public void LoadData()
        {
            SDKFilePath = Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "index.js");
            config = UnityUtil.GetEditorConf();
            projectName = config.ProjectConf.projectName;
            appid = config.ProjectConf.Appid;
            cdn = config.ProjectConf.CDN;
            assetLoadType = config.ProjectConf.assetLoadType;
            videoUrl = config.ProjectConf.VideoUrl;
            orientation = (int)config.ProjectConf.Orientation;
            dst = config.ProjectConf.DST;

            // streamCDN = config.ProjectConf.StreamCDN;
            bundleHashLength = config.ProjectConf.bundleHashLength;
            bundlePathIdentifier = config.ProjectConf.bundlePathIdentifier;
            bundleExcludeExtensions = config.ProjectConf.bundleExcludeExtensions;
            preloadFiles = config.ProjectConf.preloadFiles;
            developBuild = config.CompileOptions.DevelopBuild;
            autoProfile = config.CompileOptions.AutoProfile;
            scriptOnly = config.CompileOptions.ScriptOnly;
            profilingFuncs = config.CompileOptions.profilingFuncs;
            profilingMemory = config.CompileOptions.ProfilingMemory;
            deleteStreamingAssets = config.CompileOptions.DeleteStreamingAssets;
            cleanBuild = config.CompileOptions.CleanBuild;
            customNodePath = config.CompileOptions.CustomNodePath;
            webgl2 = config.CompileOptions.Webgl2;
            fbslim = config.CompileOptions.fbslim;

            // audioPrefix = config.ProjectConf.AssetsUrl;
            useFriendRelation = config.SDKOptions.UseFriendRelation;
            useMiniGameChat = config.SDKOptions.UseMiniGameChat;
            preloadWXFont = config.SDKOptions.PreloadWXFont;
            bgImageSrc = config.ProjectConf.bgImageSrc;
            tex = AssetDatabase.LoadAssetAtPath<Texture>(bgImageSrc);
            memorySize = config.ProjectConf.MemorySize;
            hideAfterCallMain = config.ProjectConf.HideAfterCallMain;

            // 不常用配置，先只通过MiniGameConfig.assets修改
            dataFileSubPrefix = config.ProjectConf.dataFileSubPrefix;
            maxStorage = config.ProjectConf.maxStorage;
            defaultReleaseSize = config.ProjectConf.defaultReleaseSize;
            texturesHashLength = config.ProjectConf.texturesHashLength;
            texturesPath = config.ProjectConf.texturesPath;
            needCacheTextures = config.ProjectConf.needCacheTextures;
            loadingBarWidth = config.ProjectConf.loadingBarWidth;
            needCheckUpdate = config.ProjectConf.needCheckUpdate;
            disableHighPerformanceFallback = config.ProjectConf.disableHighPerformanceFallback;
            showMonitorSuggestModal = config.CompileOptions.showMonitorSuggestModal;
            enableProfileStats = config.CompileOptions.enableProfileStats;
        }

        public void OnFocus()
        {
            LoadData();
        }

        public void OnDisable()
        {
            EditorUtility.SetDirty(config);
        }

        public void OnLostFocus()
        {
            config.ProjectConf.projectName = projectName;
            config.ProjectConf.Appid = appid;
            config.ProjectConf.CDN = cdn;
            config.ProjectConf.assetLoadType = assetLoadType;
            config.ProjectConf.VideoUrl = videoUrl;
            config.ProjectConf.Orientation = (WXScreenOritation)orientation;
            config.ProjectConf.DST = dst;

            // config.ProjectConf.StreamCDN = streamCDN;
            config.ProjectConf.bundleHashLength = bundleHashLength;
            config.ProjectConf.bundlePathIdentifier = bundlePathIdentifier;
            config.ProjectConf.bundleExcludeExtensions = bundleExcludeExtensions;
            config.ProjectConf.preloadFiles = preloadFiles;
            config.CompileOptions.DevelopBuild = developBuild;
            config.CompileOptions.AutoProfile = autoProfile;
            config.CompileOptions.ScriptOnly = scriptOnly;
            config.CompileOptions.profilingFuncs = profilingFuncs;
            config.CompileOptions.ProfilingMemory = profilingMemory;
            config.CompileOptions.DeleteStreamingAssets = deleteStreamingAssets;
            config.CompileOptions.CleanBuild = cleanBuild;
            config.CompileOptions.CustomNodePath = customNodePath;
            config.CompileOptions.Webgl2 = webgl2;
            config.CompileOptions.fbslim = fbslim;

            // config.ProjectConf.AssetsUrl = audioPrefix;
            config.SDKOptions.UseFriendRelation = useFriendRelation;
            config.SDKOptions.UseMiniGameChat = useMiniGameChat;
            config.SDKOptions.PreloadWXFont = preloadWXFont;
            config.ProjectConf.bgImageSrc = bgImageSrc;
            config.ProjectConf.MemorySize = memorySize;
            config.ProjectConf.HideAfterCallMain = hideAfterCallMain;

            config.ProjectConf.dataFileSubPrefix = dataFileSubPrefix;
            config.ProjectConf.maxStorage = maxStorage;
            config.ProjectConf.defaultReleaseSize = defaultReleaseSize;
            config.ProjectConf.texturesHashLength = texturesHashLength;
            config.ProjectConf.texturesPath = texturesPath;
            config.ProjectConf.needCacheTextures = needCacheTextures;
            config.ProjectConf.loadingBarWidth = loadingBarWidth;
            config.ProjectConf.needCheckUpdate = needCheckUpdate;
            config.ProjectConf.disableHighPerformanceFallback = disableHighPerformanceFallback;
            config.CompileOptions.showMonitorSuggestModal = showMonitorSuggestModal;
            config.CompileOptions.enableProfileStats = enableProfileStats;
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

        private string GetWebGLCodePath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                return Path.Combine(dst, webglDir, "Build", "webgl.wasm");
            }
            else
            {
                return Path.Combine(dst, webglDir, "Build", "webgl.wasm.code.unityweb");
            }
        }

        private string GetWebGLDataPath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                return Path.Combine(dst, webglDir, "Build", "webgl.data");
            }
            else
            {
                return Path.Combine(dst, webglDir, "Build", "webgl.data.unityweb");
            }
        }

        private string GetWebGLSymbolPath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                return Path.Combine(dst, webglDir, "Build", "webgl.symbols.json");
            }
            else
            {
                return Path.Combine(dst, webglDir, "Build", "webgl.wasm.symbols.unityweb");
            }
        }

        private bool IsCodeChanged()
        {
            var codePath = GetWebGLCodePath();
            if (!File.Exists(codePath))
            {
                return true;
            }

            var oldCodeMd5 = UnityUtil.BuildFileMd5(codePath);
            var dstPath = Path.Combine(dst, miniGameDir, "wasmcode", oldCodeMd5 + ".webgl.wasm.code.unityweb.wasm.br");
            return !File.Exists(dstPath);
        }

        private int Build()
        {
            PlayerSettings.WebGL.emscriptenArgs = string.Empty;
            if (WXExtEnvDef.GETDEF("UNITY_2021_2_OR_NEWER"))
            {
                PlayerSettings.WebGL.emscriptenArgs += " -s EXPORTED_FUNCTIONS=_sbrk,_emscripten_stack_get_base,_emscripten_stack_get_end";
            }
            PlayerSettings.runInBackground = false;
            if (memorySize != 0)
            {
                if (memorySize >= 1024)
                {
                    UnityEngine.Debug.LogErrorFormat($"UnityHeap必须小于1024，请查看GIT文档<a href=\"https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/OptimizationMemory.md\">优化Unity WebGL的内存</a>");
                    return -1;
                }
                else if (memorySize >= 500)
                {
                    UnityEngine.Debug.LogWarningFormat($"UnityHeap大于500M时，32位Android与iOS普通模式较大概率启动失败，中轻度游戏建议小于该值。请查看GIT文档<a href=\"https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/OptimizationMemory.md\">优化Unity WebGL的内存</a>");
                }

                PlayerSettings.WebGL.emscriptenArgs += $" -s TOTAL_MEMORY={memorySize}MB";
            }

            if (profilingMemory)
            {
                PlayerSettings.WebGL.emscriptenArgs += " --memoryprofiler ";
            }

            if (profilingFuncs)
            {
                PlayerSettings.WebGL.emscriptenArgs += " --profiling-funcs ";
            }

            WXExtEnvDef.GOTO("WXEditorWindow.Build");

            UnityEngine.Debug.Log("[Builder] Starting to build WebGL project ... ");
            UnityEngine.Debug.Log("PlayerSettings.WebGL.emscriptenArgs : " + PlayerSettings.WebGL.emscriptenArgs);

            // PlayerSettings.WebGL.memorySize = memorySize;
            BuildOptions option = BuildOptions.None;

            if (developBuild)
            {
                option |= BuildOptions.Development;
            }

            if (autoProfile)
            {
                option |= BuildOptions.ConnectWithProfiler;
            }

            if (scriptOnly)
            {
                option |= BuildOptions.BuildScriptsOnly;
            }
#if UNITY_2021_2_OR_NEWER
                if (cleanBuild)
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

            var projDir = Path.Combine(dst, webglDir);

            var result = BuildPipeline.BuildPlayer(GetScenePaths(), projDir, BuildTarget.WebGL, option);
            if (result.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                UnityEngine.Debug.LogFormat($"[Builder] BuildPlayer failed. emscriptenArgs:{0}", PlayerSettings.WebGL.emscriptenArgs);
                return -1;
            }

            UnityEngine.Debug.LogFormat("[Builder] Done: " + projDir);
            return 0;
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

        private void ConvertCode()
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to adapt framewor. Dst: " + dst);

            UnityUtil.DelectDir(Path.Combine(dst, miniGameDir));
            string text = String.Empty;
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                text = File.ReadAllText(Path.Combine(dst, webglDir, "Build", "webgl.framework.js"), Encoding.UTF8);
            }
            else
            {
                text = File.ReadAllText(Path.Combine(dst, webglDir, "Build", "webgl.wasm.framework.unityweb"), Encoding.UTF8);
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

            if (!Directory.Exists(Path.Combine(dst, miniGameDir)))
            {
                Directory.CreateDirectory(Path.Combine(dst, miniGameDir));
            }

            var header = "function createWebAudio(){window.AudioContext=window.AudioContext||window.webkitAudioContext;if(window.AudioContext){return new AudioContext();}return wx.createWebAudioContext();}\n";
            text = header + text;

            File.WriteAllText(Path.Combine(dst, miniGameDir, "webgl.wasm.framework.unityweb.js"), text, new UTF8Encoding(false));

            UnityEngine.Debug.LogFormat("[Converter]  adapt framework done! ");
        }

        /// <summary>
        /// 删掉导出目录webgl目录下旧资源包
        /// </summary>
        private void RemoveOldAssetPackage(string dstDir)
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

        /// <summary>
        /// 等brotli之后，统计下资源包加brotli压缩后代码包是否超过了20M（小游戏代码分包总大小限制）
        /// </summary>
        private void checkNeedCopyDataPackage(bool brotliError)
        {
            // 如果brotli失败，使用CDN加载
            if (brotliError)
            {
                // brotli失败后，因为无法知道wasmcode大小，则得不到最终小游戏总包体大小。不能使用小游戏分包加载资源，还原成cdn的方式。
                if (assetLoadType == 1)
                {
                    UnityEngine.Debug.LogWarning("brotli失败，无法检测文件大小，请上传资源文件到CDN");
                    assetLoadType = 0;
                }

                ShowNotification(new GUIContent("Brotli压缩失败，请到转出目录手动压缩！！！"));
            }

            if (assetLoadType == 1)
            {
                var dataPath = GetWebGLDataPath();
                var brcodePath = Path.Combine(dst, miniGameDir, "wasmcode", codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");
                var brcodeInfo = new FileInfo(brcodePath);
                var brcodeSize = brcodeInfo.Length;
                if (brcodeSize + int.Parse(dataFileSize) > 20971520)
                {
                    ShowNotification(new GUIContent("资源文件过大，不适宜用放小游戏包内加载"));
                    throw new Exception("资源文件过大，不适宜用小游戏包内加载");
                }
                else
                {
                    File.Copy(dataPath, Path.Combine(dst, miniGameDir, "data-package", dataMd5 + ".webgl.data.unityweb.bin.txt"), true);
                }
            }

            var loadDataFromCdn = assetLoadType == 0;
            Rule[] rules =
            {
                new Rule()
                {
                    old = "$DEPLOY_URL",
                    newStr = cdn,
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

        public int GenerateBinFile(bool isFromConvert = false)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to genarate md5 and copy files");

            var codePath = GetWebGLCodePath();
            codeMd5 = UnityUtil.BuildFileMd5(codePath);
            var dataPath = GetWebGLDataPath();
            dataMd5 = UnityUtil.BuildFileMd5(dataPath);
            var symbolPath = GetWebGLSymbolPath();

            RemoveOldAssetPackage(Path.Combine(dst, webglDir));
            RemoveOldAssetPackage(Path.Combine(dst, webglDir + "-min"));

            File.Copy(dataPath, Path.Combine(dst, webglDir, dataMd5 + ".webgl.data.unityweb.bin.txt"), true);

            CopyDirectory(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default"), Path.Combine(dst, miniGameDir), true);

            // FIX: 2021.2版本生成symbol有bug，导出时生成symbol报错，有symbol才copy
            // 代码分包需要symbol文件以进行增量更新
            if (File.Exists(symbolPath))
            {
                File.Copy(symbolPath, Path.Combine(dst, miniGameDir, "webgl.wasm.symbols.unityweb"), true);
            }

            var info = new FileInfo(dataPath);
            dataFileSize = info.Length.ToString();

            UnityEngine.Debug.LogFormat("[Converter] that to genarate md5 and copy files ended");

            ModifyWeChatConfigs(isFromConvert);

            ModifySDKFile();

            ClearFriendRelationCode();

            // 如果没有StreamingAssets目录，默认生成
            if (!Directory.Exists(Path.Combine(dst, webglDir, "StreamingAssets")))
            {
                Directory.CreateDirectory(Path.Combine(dst, webglDir, "StreamingAssets"));
            }

            return Brotlib(codePath);
        }

        private void ModifySDKFile()
        {
            var config = UnityUtil.GetEditorConf();
            string content = File.ReadAllText(SDKFilePath, Encoding.UTF8);
            content = content.Replace("$unityVersion$", Application.unityVersion);

            File.WriteAllText(Path.Combine(dst, miniGameDir, "unity-sdk", "index.js"), content, Encoding.UTF8);

            content = File.ReadAllText(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "storage.js"), Encoding.UTF8);

            var PreLoadKeys = config.PlayerPrefsKeys.Count > 0 ? JsonMapper.ToJson(config.PlayerPrefsKeys) : "[]";

            content = content.Replace("\"$PreLoadKeys\"", PreLoadKeys);

            File.WriteAllText(Path.Combine(dst, miniGameDir, "unity-sdk", "storage.js"), content, Encoding.UTF8);

            // 修改纹理dxt
            content = File.ReadAllText(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "texture.js"), Encoding.UTF8);

            content = content.Replace("\"$UseDXT5$\"", config.CompressTexture.useDXT5 ? "true" : "false");

            File.WriteAllText(Path.Combine(dst, miniGameDir, "unity-sdk", "texture.js"), content, Encoding.UTF8);
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
        private string GetPreloadList(string strPreloadfiles)
        {
            if (strPreloadfiles == string.Empty)
            {
                return string.Empty;
            }

            string preloadList = string.Empty;
            var streamingAssetsPath = Path.Combine(dst, webglDir + "/StreamingAssets");
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

        public string HandleLoadingImage()
        {
            var info = AssetDatabase.LoadAssetAtPath<Texture>(bgImageSrc);
            var oldFilename = Path.GetFileName(defaultImgSrc);
            var newFilename = Path.GetFileName(bgImageSrc);
            if (bgImageSrc != defaultImgSrc)
            {
                // 图片宽高不能超过2048
                if (info.width > 2048 || info.height > 2048)
                {
                    throw new Exception("封面图宽高不可超过2048");
                }

                File.Delete(Path.Combine(dst, miniGameDir, "images", oldFilename));
                File.Copy(bgImageSrc, Path.Combine(dst, miniGameDir, "images", newFilename), true);
                return "images/" + Path.GetFileName(bgImageSrc);
            }
            else
            {
                return "images/" + Path.GetFileName(defaultImgSrc);
            }
        }

        public void ModifyWeChatConfigs(bool isFromConvert = false)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to modify configs");

            var config = UnityUtil.GetEditorConf();

            var PRELOAD_LIST = GetPreloadList(preloadFiles);
            var imgSrc = HandleLoadingImage();

            var bundlePathIdentifierStr = GetArrayString(bundlePathIdentifier);
            var excludeFileExtensionsStr = GetArrayString(bundleExcludeExtensions);

            var screenOrientation = new List<string>() { "portrait", "landscape", "landscapeLeft", "landscapeRight" }[orientation];

            Rule[] replaceArrayList = ReplaceRules.GenRules(new string[] {
                projectName == string.Empty ? "webgl" : projectName,
                appid,
                screenOrientation,
                videoUrl,
                codeMd5,
                dataMd5,
                streamCDN,
                cdn + "/Assets",
                PRELOAD_LIST,
                imgSrc,
                hideAfterCallMain ? "true" : "false",
                bundleHashLength.ToString(),
                bundlePathIdentifierStr,
                excludeFileExtensionsStr,
                webgl2 ? "2" : "1",
                Application.unityVersion,
                WXExtEnvDef.pluginVersion,
                dataFileSubPrefix,
                maxStorage.ToString(),
                defaultReleaseSize.ToString(),
                texturesHashLength.ToString(),
                texturesPath,
                needCacheTextures ? "true" : "false",
                loadingBarWidth.ToString(),
                needCheckUpdate ? "true" : "false",
                GetColorSpace(),
                disableHighPerformanceFallback ? "true" : "false",
                preloadWXFont ? "true" : "false",
                showMonitorSuggestModal ? "true" : "false",
                enableProfileStats ? "true" : "false",
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
        public static string GetColorSpace()
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
        /// 对文件做内容替换
        /// </summary>
        /// <param name="files"></param>
        /// <param name="replaceList"></param>
        public void ReplaceFileContent(string[] files, Rule[] replaceList)
        {
            if (files.Length != 0 && replaceList.Length != 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    var filePath = Path.Combine(dst, miniGameDir, files[i]);
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

        /// <summary>
        /// 按;分隔字符串，将分隔后每一项作为字符串用,连接
        /// eg: input "i1;i2;i3" => output: `"i1", "i2", "i3"`
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        public string GetArrayString(string inp)
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

        private int Brotlib(string filePath)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to generate Brotlib file");
            var dstPath = Path.Combine(dst, miniGameDir, "wasmcode", codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");
            var codeInWebGL = Path.Combine(dst, webglDir, codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");

            // 如果code没有发生过变化，则不再进行br压缩
            if (File.Exists(codeInWebGL))
            {
                File.Copy(codeInWebGL, dstPath);
                return 0;
            }

            // 删除旧的br压缩文件
            if (Directory.Exists(Path.Combine(dst, webglDir)))
            {
                foreach (string path in Directory.GetFiles(Path.Combine(dst, webglDir)))
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
        private void ClearFriendRelationCode()
        {
            var filePath = Path.Combine(dst, miniGameDir, "game.json");

            string content = File.ReadAllText(filePath, Encoding.UTF8);
            JsonData gameJson = JsonMapper.ToObject(content);

            if (!useFriendRelation || !useMiniGameChat)
            {
                JsonWriter writer = new JsonWriter();
                writer.IndentValue = 2;
                writer.PrettyPrint = true;

                // 将 game.json 里面关系链相关的配置删除
                if (!useFriendRelation)
                {
                    gameJson.Remove("openDataContext");
                    gameJson["plugins"].Remove("Layout");

                    // 删除 open-data 相应的文件夹
                    string openDataDir = Path.Combine(dst, miniGameDir, "open-data");
                    UnityUtil.DelectDir(openDataDir);
                    Directory.Delete(openDataDir, true);
                }

                if (!useMiniGameChat)
                {
                    gameJson["plugins"].Remove("MiniGameChat");
                    UnityEngine.Debug.Log(gameJson["plugins"]);
                }

                // 将配置写回到文件夹
                gameJson.ToJson(writer);
                File.WriteAllText(filePath, writer.TextWriter.ToString());
            }
        }

        public static void DrawProObjectField<T>(
             GUIContent label,
             SerializedProperty value,
             Type objType,
             GUIStyle style,
             bool allowSceneObjects,
             Texture objIcon = null)
            where T : UnityEngine.Object
        {
            T tObj = value.objectReferenceValue as T;

            if (objIcon == null)
            {
                objIcon = EditorGUIUtility.FindTexture("PrefabNormal Icon");
            }

            style.imagePosition = ImagePosition.ImageLeft;

            int pickerID = 455454425;

            if (tObj != null)
            {
                EditorGUILayout.LabelField(
                    label,
                    new GUIContent(tObj.name, objIcon), style);
            }

            if (GUILayout.Button("Select"))
            {
                EditorGUIUtility.ShowObjectPicker<T>(
                    tObj, allowSceneObjects, string.Empty, pickerID);
            }

            if (Event.current.commandName == "ObjectSelectorUpdated")
            {
                if (EditorGUIUtility.GetObjectPickerControlID() == pickerID)
                {
                    tObj = EditorGUIUtility.GetObjectPickerObject() as T;
                    value.objectReferenceValue = tObj;
                }
            }
        }

        public void OnGUI()
        {
            var labelStyle = new GUIStyle(EditorStyles.boldLabel);
            labelStyle.fontSize = 14;

            labelStyle.margin.left = 20;
            labelStyle.margin.top = 10;
            labelStyle.margin.bottom = 10;

            GUILayout.Label("基本设置", labelStyle);

            var inputStyle = new GUIStyle(EditorStyles.textField);
            inputStyle.fontSize = 14;
            inputStyle.margin.left = 20;
            inputStyle.margin.bottom = 10;
            inputStyle.margin.right = 20;

            var intPopupStyle = new GUIStyle(EditorStyles.popup);
            intPopupStyle.fontSize = 14;
            intPopupStyle.margin.left = 20;
            intPopupStyle.margin.bottom = 15;
            intPopupStyle.margin.right = 20;

            appid = EditorGUILayout.TextField("游戏appid", appid, inputStyle);
            cdn = EditorGUILayout.TextField("游戏资源CDN", cdn, inputStyle);
            projectName = EditorGUILayout.TextField("小游戏项目名", projectName, inputStyle);
            orientation = EditorGUILayout.IntPopup("游戏方向", orientation, new[] { "Portrait", "Landscape", "LandscapeLeft", "LandscapeRight" }, new[] { 0, 1, 2, 3 }, intPopupStyle);
            var totalMemoryFieldDesc = new GUIContent("UnityHeap预留内存(MB)", "预分配内存值，超休闲游戏256/中轻度496/重度游戏768，需预估游戏最大UnityHeap值以防止内存自动扩容带来的峰值尖刺。预估方法请查看GIT文档《优化Unity WebGL的内存》");
            memorySize = EditorGUILayout.IntField(totalMemoryFieldDesc, memorySize, inputStyle);

            GUILayout.Label("导出路径", labelStyle);

            var choosePathButtonClicked = false;
            var openTargetButtonClicked = false;
            var resetButtonClicked = false;

            if (dst == string.Empty)
            {
                GUIStyle pathButtonStyle = new GUIStyle(GUI.skin.button);
                pathButtonStyle.fontSize = 12;
                pathButtonStyle.margin.left = 20;

                choosePathButtonClicked = GUILayout.Button("选择导出路径", pathButtonStyle, GUILayout.Height(30), GUILayout.Width(200));
            }
            else
            {
                int pathButtonHeight = 28;
                GUIStyle pathLabelStyle = new GUIStyle(GUI.skin.textField);
                pathLabelStyle.fontSize = 12;
                pathLabelStyle.alignment = TextAnchor.MiddleLeft;
                pathLabelStyle.margin.top = 6;
                pathLabelStyle.margin.bottom = 6;
                pathLabelStyle.margin.left = 20;

                GUILayout.BeginHorizontal();

                // 路径框
                GUILayout.Label(dst, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 126));
                openTargetButtonClicked = GUILayout.Button("打开", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                resetButtonClicked = GUILayout.Button("重选", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                GUILayout.EndHorizontal();
            }

            EditorGUILayout.Space();

            GUILayout.Label("启动Loader设置", labelStyle);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20);
            tex = (Texture)EditorGUILayout.ObjectField("启动背景图/视频封面", tex, typeof(Texture2D), false);
            var currentBgSrc = AssetDatabase.GetAssetPath(tex);
            TextureImporter texInfo = (TextureImporter)AssetImporter.GetAtPath(currentBgSrc);
            if (!string.IsNullOrEmpty(currentBgSrc) && currentBgSrc != bgImageSrc)
            {
                bgImageSrc = currentBgSrc;
                var config = UnityUtil.GetEditorConf();
                config.ProjectConf.bgImageSrc = bgImageSrc;
                EditorUtility.SetDirty(config);
                AssetDatabase.SaveAssets();
            }

            GUILayout.Space(20);
            EditorGUILayout.EndHorizontal();

            videoUrl = EditorGUILayout.TextField("加载阶段视频url", videoUrl, inputStyle);

            var optionsList = new List<GUIContent>();
            optionsList.Add(new GUIContent("CDN"));
            optionsList.Add(new GUIContent("小游戏包内"));
            GUIContent assetLoadTypeLabel = new GUIContent("首包资源加载方式", "选择'CDN'通过传统CDN加载资源。选择'小游戏包内'通过小游戏包内加载资源。小游戏包有总大小20M限制，若资源加代码总大小超过20M，会自动切换为传统CDN加载");

            assetLoadType = EditorGUILayout.IntPopup(assetLoadTypeLabel, assetLoadType, optionsList.ToArray(), new[] { 0, 1 }, intPopupStyle);

            // audioPrefix = EditorGUILayout.TextField("Assets目录对应CDN地址", audioPrefix, inputStyle);

            // memorySize = EditorGUILayout.IntField("游戏内存大小（MB）", memorySize, inputStyle);

            // EditorGUILayout.Space();

            // GUILayout.Label("AssetBundle缓存配置", labelStyle);

            // streamCDN = EditorGUILayout.TextField("Bundle包CDN地址", streamCDN, inputStyle);
            // var bundlePathFieldDesc = new GUIContent("路径标识符(;分隔)", "下载路径中包含标识符可判定为下载Bundle，可自动缓存。默认值StreamingAssets");
            // bundlePathIdentifier = EditorGUILayout.TextField(bundlePathFieldDesc, bundlePathIdentifier, inputStyle);
            var bundleExcludeExtensionsFieldDesc = new GUIContent("不自动缓存文件类型(;分隔)", "当请求url包含资源'cdn+StreamingAssets'时会自动缓存，但StreamingAssets目录下不是所有文件都需缓存，此选项配置不需要自动缓存的文件拓展名。默认值json");
            bundleExcludeExtensions = EditorGUILayout.TextField(bundleExcludeExtensionsFieldDesc, bundleExcludeExtensions, inputStyle);

            var bundleHashLengthFieldDesc = new GUIContent("Bundle名中Hash长度", "自定义Bundle文件名中hash部分长度，默认值32，用于缓存控制。");
            bundleHashLength = EditorGUILayout.IntField(bundleHashLengthFieldDesc, bundleHashLength, inputStyle);

            EditorGUILayout.Space();

            GUILayout.Label("预下载选项", labelStyle);
            GUILayout.BeginHorizontal();
            preloadFiles = EditorGUILayout.TextField("文件列表(;间隔，模糊匹配)", preloadFiles, inputStyle);

            GUILayout.EndHorizontal();

            EditorGUILayout.Space();

            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.margin.left = 20;
            toggleStyle.margin.right = 20;

            GUILayout.Label("SDK功能选项", labelStyle);
            GUILayout.BeginHorizontal();
            useFriendRelation = GUILayout.Toggle(useFriendRelation, "使用好友关系链", toggleStyle);
            useMiniGameChat = GUILayout.Toggle(useMiniGameChat, "使用社交组件", toggleStyle);
            preloadWXFont = GUILayout.Toggle(preloadWXFont, new GUIContent("预载微信字体(?)", "在game.js执行开始时预载微信系统字体，运行期间可使用WX.GetWXFont获取微信字体"), toggleStyle);
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUILayout.Label("调试编译选项", labelStyle);
            GUILayout.BeginHorizontal();

            developBuild = GUILayout.Toggle(developBuild, "Development Build ", toggleStyle);
            autoProfile = GUILayout.Toggle(autoProfile, "Autoconnect Profiler ", toggleStyle);
            scriptOnly = GUILayout.Toggle(scriptOnly, "Scripts Only Build", toggleStyle);

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();

            profilingFuncs = GUILayout.Toggle(profilingFuncs, "Profiling Funcs       ", toggleStyle);
            profilingMemory = GUILayout.Toggle(profilingMemory, "Profiling Memory     ", toggleStyle);

            var oldwebgl2 = webgl2;
            webgl2 = GUILayout.Toggle(webgl2, "WebGL2.0(beta)", toggleStyle);
            if (oldwebgl2 != webgl2)
            {
                UpdateGraphicAPI();
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            deleteStreamingAssets = GUILayout.Toggle(deleteStreamingAssets, "ClearStreamingAssets", toggleStyle);
            cleanBuild = GUILayout.Toggle(cleanBuild, "CleanWebGLBuild          ", toggleStyle);
            cleanCloudDev = GUILayout.Toggle(cleanCloudDev, "CleanCloudDev       ", toggleStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            fbslim = GUILayout.Toggle(fbslim, new GUIContent("首包资源优化(?)", "导出时自动清理UnityEditor默认打包但游戏项目从未使用的资源，瘦身首包资源体积，建议所有游戏启用。"), toggleStyle);
            showMonitorSuggestModal = GUILayout.Toggle(showMonitorSuggestModal, new GUIContent("显示优化建议弹框"), toggleStyle);
            enableProfileStats = GUILayout.Toggle(enableProfileStats, new GUIContent("显示性能面板"), toggleStyle);
            GUILayout.EndHorizontal();

            GUIStyle exportButtonStyle = new GUIStyle(GUI.skin.button);
            exportButtonStyle.fontSize = 14;
            exportButtonStyle.margin.left = 20;
            exportButtonStyle.margin.top = 15;

            var isMoreConfigPressed = GUILayout.Button("更多配置选项(MiniGameConfig.asset)", exportButtonStyle, GUILayout.Height(30), GUILayout.Width(EditorGUIUtility.currentViewWidth - 40));

            EditorGUILayout.BeginHorizontal();

            var isExportBtnPressed = GUILayout.Button("导出WEBGL并转换为小游戏(常用)", exportButtonStyle, GUILayout.Height(40), GUILayout.Width(EditorGUIUtility.currentViewWidth - 270));

            var isConvertBtnPressed = GUILayout.Button("将WEBGL转为小游戏(不常用)", exportButtonStyle, GUILayout.Height(40), GUILayout.Width(210));

            EditorGUILayout.EndHorizontal();

            if (isExportBtnPressed)
            {
                DoExport(true);
            }

            if (isConvertBtnPressed)
            {
                DoExport(false);
            }

            if (isMoreConfigPressed)
            {
                var config = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("Assets/WX-WASM-SDK-V2/Editor/MiniGameConfig.asset");
                Selection.activeObject = config;
            }

            if (choosePathButtonClicked)
            {
                // 弹出选目录窗口
                var dstPath = EditorUtility.SaveFolderPanel("选择你的游戏导出目录", string.Empty, string.Empty);

                if (dstPath != string.Empty)
                {
                    dst = dstPath;
                    OnLostFocus();
                }
            }

            if (openTargetButtonClicked)
            {
                UnityUtil.ShowInExplorer(dst);
            }

            if (resetButtonClicked)
            {
                dst = string.Empty;
            }

            EditorGUILayout.Space();
        }

        public void UpdateGraphicAPI()
        {
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.WebGL, false);
            GraphicsDeviceType[] targets = new GraphicsDeviceType[] { };
            if (webgl2)
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, new GraphicsDeviceType[] { GraphicsDeviceType.OpenGLES3 });
            }
            else
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, new GraphicsDeviceType[] { GraphicsDeviceType.OpenGLES2 });
            }
        }

        public enum WXExportError
        {
            SUCCEED = 0,
            NODE_NOT_FOUND = 1,
            BUILD_WEBGL_FAILED = 2,
        }

        // 可以调用这个来集成
        public WXExportError DoExport(bool buildWebGL)
        {
            // JSLib
            SettingWXTextureMinJSLib();

            OnLostFocus();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();

            if (dst == string.Empty)
            {
                ShowNotification(new GUIContent("请先选择游戏导出路径"));
            }
            else
            {
                // 仅删除StreamingAssets目录
                if (deleteStreamingAssets)
                {
                    UnityUtil.DelectDir(Path.Combine(dst, webglDir + "/StreamingAssets"));
                }

                if (buildWebGL && Build() != 0)
                {
                    return WXExportError.BUILD_WEBGL_FAILED;
                }

                if (WXExtEnvDef.GETDEF("UNITY_2021_2_OR_NEWER"))
                {
                    // 如果是2021版本，官方symbols产生有BUG，这里需要用工具将embedded的函数名提取出来
                    WeChatWASM.UnityUtil.preprocessSymbols(GetWebGLSymbolPath());
                }

                ConvertCode();
                string dataFilePath = GetWebGLDataPath();
                if (fbslim)
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

        private void finishExport()
        {
            int code = GenerateBinFile();
            if (code == 0)
            {
                checkNeedCopyDataPackage(false);
                UnityEngine.Debug.LogFormat("[Converter] All done!");
                ShowNotification(new GUIContent("转换完成"));
            }
            else
            {
                checkNeedCopyDataPackage(true);
            }
        }

        /// <summary>
        /// 兼容 WebGL1 WebGL2 Linear Gamma 配置 Assets/WX-WASM-SDK/Plugins
        /// </summary>
        private void SettingWXTextureMinJSLib()
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

            if (webgl2)
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
    }
}
