using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using Brotli;
using System.Text.RegularExpressions;
using UnityEngine.Rendering;

namespace WeChatWASM
{
    /// <summary>
    /// 脚本调用的话可修改 Assets/WX-WASM-SDK/Editor/MiniGameConfig.asset配置，然后调用WXEditorWindow 的 DoExport方法导出小游戏
    /// </summary>
    public class WXEditorWindow : EditorWindow
    {
        string projectName = "";
        string appid = "";
        string cdn = "";
        string videoUrl = "";
        public static string dst = "";
        string streamCDN = "";
        string preloadFiles = ""; // 预下载文件名, 以,分隔文件
        string audioPrefix = "";
        bool useAudioApi = false;
        bool useFriendRelation = false;
        bool developBuild = false;
        bool autoProfile = false;
        bool scriptOnly = false;
        bool useCompressedTexture = false;
        int assetLoadType = 0; // 首包资源加载方式
        static bool needPython = false; // big sur bortil压缩 在unity低版本下会出现问题，需要先用python来先过渡一下

        int orientation = 0;
        // int memorySize = 256;

        static string SDKFilePath = "";


        public static string webglDir = "webgl"; //导出的webgl目录
        string miniGameDir = "minigame"; // 生成小游戏的目录
        public static string audioDir = "Assets"; //音频资源目录
        public string codeMd5 = "";
        public string dataMd5 = "";
        public string dataFileSize = "";



        [MenuItem("微信小游戏 / 转换小游戏", false, 1)]
        public static void Open()
        {
#if !(UNITY_2019 || UNITY_2018)
            Debug.LogError("目前仅支持 Unity2018 和 Unity 2019！");
#endif
            var win = GetWindow(typeof(WXEditorWindow), false, "转换微信小游戏", true);//创建窗口
            win.minSize = new Vector2(650, 700);
            win.maxSize = new Vector2(1600, 700);
            win.Show();
            // 打开面板时自动检查更新
            UpdateManager.CheckUpdte();
            Init();

        }


        [MenuItem("微信小游戏 / 包体瘦身--压缩纹理 / 替换纹理")]
        public static void TextureReplace() {

            Debug.Log("start replace");
            //先恢复缓存的
            WXTextureManager.Recover();
            WXTextureManager.Start();
            Debug.Log("end replace");
        }



        [MenuItem("微信小游戏 / 包体瘦身--压缩纹理 / 恢复纹理")]
        public static void TextureRecover()
        {
            //先恢复缓存的
            WXTextureManager.Recover();
        }



        [MenuItem("微信小游戏 / 包体瘦身--压缩纹理 / 根据ASTC生成ETC2纹理")]
        public static void TextureContinueConver()
        {

            var miniGameConf = UnityUtil.GetEditorConf();

            if (string.IsNullOrEmpty(miniGameConf.ProjectConf.DST))
            {
                Debug.LogError("请选择导出目录！");
                return;
            }



            Debug.Log("开始生成");

            WXTextureManager.TextureContinueConver(Path.Combine(miniGameConf.ProjectConf.DST, webglDir, "Assets"));

            Debug.Log("结束生成");
        }


        [MenuItem("微信小游戏 / 包体瘦身--压缩纹理 / 重新替换失败的纹理")]
        public static void ReTryTextureReplace()
        {
            PicCompressor.ReTryFailedTask();
        }




#if UNITY_EDITOR_OSX
        [MenuItem("微信小游戏 / MacOS脚本授权", false, 2)]
        public static void MacSetAuth()
        {

            PicCompressor.TestASTC();
            PicCompressor.TestMinPNG();
            PicCompressor.TestPVRTC();
            if (!needPython)
            {
                TestBrotlib();
            }
            else {
                Debug.LogError("因为您使用的事Big Sur版本Mac系统,建议您将Unity版本升级至2019.4.14之后的版本。");
            }

        }
#endif


        public static WXTextureRecoverObject LoadTextureRecoverConf() {
            var config = AssetDatabase.LoadAssetAtPath(WXTextureManager.RecoverAssetsPath, typeof(WXTextureRecoverObject)) as WXTextureRecoverObject;
            if (config == null)
            {
                AssetDatabase.CreateAsset(CreateInstance<WXTextureRecoverObject>(), WXTextureManager.RecoverAssetsPath);
                config = AssetDatabase.LoadAssetAtPath(WXTextureManager.RecoverAssetsPath, typeof(WXTextureRecoverObject)) as WXTextureRecoverObject;
            }
            return config;
        }

        public static void Init() {

            PlayerSettings.WebGL.threadsSupport = false;

            if (Application.platform == RuntimePlatform.OSXEditor)
            {

                var mc = Regex.Match(SystemInfo.operatingSystem, @"Mac OS X (\d{1,4})\.(\d{1,4})\.\d{1,4}$");

                if (mc.Success)
                {
                    int.TryParse(mc.Groups[1].Value, out int mainVersion);
                    int.TryParse(mc.Groups[2].Value, out int subVersion);
                    if ((mainVersion == 10 && subVersion >= 16) || mainVersion > 10)
                    {
                        var mUnity = Regex.Match(Application.unityVersion, @"(\d{4})\.(\d{1,4})\.(\d{1,4})");

                        if (mUnity.Success)
                        {
                            int.TryParse(mUnity.Groups[1].Value, out int mainUnityVersion);
                            int.TryParse(mUnity.Groups[2].Value, out int subUnityVersion);
                            int.TryParse(mUnity.Groups[3].Value, out int thirdUnityVersion);

                            if (mainUnityVersion < 2019)
                            {
                                needPython = true;
                            }
                            else if (mainUnityVersion == 2019)
                            {
                                if (subUnityVersion < 4)
                                {
                                    needPython = true;
                                }
                                else if (thirdUnityVersion < 14)
                                {
                                    needPython = true;
                                }
                            }
                        }

                    }
                }

            }


            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.WebGL, false);
            GraphicsDeviceType[] targets = { GraphicsDeviceType.OpenGLES2 };
            PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, targets);

            PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;

            PlayerSettings.WebGL.template = "PROJECT:WXTemplate";

            PlayerSettings.WebGL.debugSymbols = true;

            EditorSettings.spritePackerMode = SpritePackerMode.AlwaysOnAtlas;



        }

        public void OnEnable()
        {
            Init();
            LoadData();
        }


        public void LoadData() {

            SDKFilePath = Path.Combine(Application.dataPath, "WX-WASM-SDK", "wechat-default", "unity-sdk", "index.js");
            var config = UnityUtil.GetEditorConf();
            projectName = config.ProjectConf.projectName;
            appid = config.ProjectConf.Appid;
            cdn = config.ProjectConf.CDN;
            assetLoadType = config.ProjectConf.assetLoadType;
            videoUrl = config.ProjectConf.VideoUrl;
            orientation = (int)config.ProjectConf.Orientation;
            dst = config.ProjectConf.DST;
            streamCDN = config.ProjectConf.StreamCDN;
            preloadFiles = config.ProjectConf.preloadFiles;
            developBuild = config.CompileOptions.DevelopBuild;
            autoProfile = config.CompileOptions.AutoProfile;
            scriptOnly = config.CompileOptions.ScriptOnly;
            useAudioApi = config.SDKOptions.UseAudioApi;
            audioPrefix = config.ProjectConf.AssetsUrl;
            useFriendRelation = config.SDKOptions.UseFriendRelation;
            useCompressedTexture = config.SDKOptions.UseCompressedTexture;
            // memorySize = config.ProjectConf.MemorySize;

        }

        private void OnFocus()
        {
            LoadData();
        }

        private void OnLostFocus() {

            var config = UnityUtil.GetEditorConf();
            config.ProjectConf.projectName = projectName;
            config.ProjectConf.Appid = appid;
            config.ProjectConf.CDN = cdn;
            config.ProjectConf.assetLoadType = assetLoadType;
            config.ProjectConf.VideoUrl = videoUrl;
            config.ProjectConf.Orientation = (WXScreenOritation)orientation;
            config.ProjectConf.DST = dst;
            config.ProjectConf.StreamCDN = streamCDN;
            config.ProjectConf.preloadFiles = preloadFiles;
            config.CompileOptions.DevelopBuild = developBuild;
            config.CompileOptions.AutoProfile = autoProfile;
            config.CompileOptions.ScriptOnly = scriptOnly;
            config.SDKOptions.UseAudioApi = useAudioApi;
            config.ProjectConf.AssetsUrl = audioPrefix;
            config.SDKOptions.UseFriendRelation = useFriendRelation;
            config.SDKOptions.UseCompressedTexture = useCompressedTexture;
            // config.ProjectConf.MemorySize = memorySize;
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }


        static string[] GetScenePaths()
        {
            List<string> scenes = new List<string>();
            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                var scene = EditorBuildSettings.scenes[i];
                Debug.LogFormat("[Builder] Scenes [{0}]: {1}, [{2}]", i, scene.path, scene.enabled ? "x" : " ");

                if (scene.enabled)
                {
                    scenes.Add(scene.path);
                }
            }

            return scenes.ToArray();
        }

        private void Build()
        {
            if (useFriendRelation)
            {
                PlayerSettings.WebGL.emscriptenArgs = "-s EXTRA_EXPORTED_RUNTIME_METHODS=['GL','ccall'] -s FORCE_FILESYSTEM=1 -03";
            }
            else
            {
                PlayerSettings.WebGL.emscriptenArgs = "";
            }


            Debug.Log("[Builder] Starting to build WebGL project ... ");

            Debug.Log("PlayerSettings.WebGL.emscriptenArgs : "+ PlayerSettings.WebGL.emscriptenArgs);

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


            if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.WebGL)
            {
                Debug.LogFormat("[Builder] Current target is: {0}, switching to: {1}", EditorUserBuildSettings.activeBuildTarget, BuildTarget.WebGL);
                if (!EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL))
                {
                    Debug.LogFormat("[Builder] Switching to {0}/{1} failed!", BuildTargetGroup.WebGL, BuildTarget.WebGL);
                    return;
                }
            }

            var projDir = Path.Combine(dst, webglDir);

            BuildPipeline.BuildPlayer(GetScenePaths(), projDir, BuildTarget.WebGL, option);

            Debug.LogFormat("[Builder] Done: " + projDir);

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
                    } else
                    {
                        // 已经存在，删掉目录下无用的文件
                        foreach(string filename in ignoreFiles)
                        {
                            var filepath = Path.Combine(DestinationPath, filename);
                            if (File.Exists(filepath))
                            {
                                File.Delete(filepath);
                            }
                        }
                        foreach(string dir in ignoreDirs)
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
                            ret = false;
                    }
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                Debug.LogError(ex);
            }
            return ret;
        }

        private static bool CopyMusicDirectory(string SourcePath, string DestinationPath, bool overwriteexisting)
        {
            bool ret = false;
            try
            {

                if (Directory.Exists(SourcePath))
                {


                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {

                        FileInfo flinfo = new FileInfo(fls);
                        string[] suffix = { ".wav",".mp3", "m4a", "aac", "mp4" };
                        if (Array.IndexOf(suffix, flinfo.Extension.ToLower())>-1) {
                            UnityUtil.CreateDir(DestinationPath);
                            flinfo.CopyTo(Path.Combine(DestinationPath, flinfo.Name), overwriteexisting);
                        }

                    }
                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (CopyMusicDirectory(drs, Path.Combine(DestinationPath, drinfo.Name), overwriteexisting) == false)
                            ret = false;
                    }
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                Debug.LogError(ex);
            }
            return ret;

        }

        private void ConvertCode()
        {

            Debug.LogFormat("[Converter] Starting to adapt framewor. Dst: " + dst);

            UnityUtil.DelectDir(Path.Combine(dst, miniGameDir));

            string text = File.ReadAllText(Path.Combine(dst, webglDir, "Build", "webgl.wasm.framework.unityweb"), Encoding.UTF8);

            int i;
            for (i = 0; i < ReplaceRules.rules.Length; i++)
            {
                var rule = ReplaceRules.rules[i];
                text = Regex.Replace(text, rule.old, rule.newStr);
            }

            if (text.Contains("UnityModule"))
            {
                text += ";GameGlobal.unityNamespace.UnityModule = UnityModule;";
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

            File.WriteAllText(Path.Combine(dst, miniGameDir, "webgl.wasm.framework.unityweb.js"), text, new UTF8Encoding(false));



            Debug.LogFormat("[Converter]  adapt framework done! ");


        }
        /// <summary>
        /// 删掉导出目录webgl目录下旧资源包
        /// </summary>
        private void removeOldAssetPackage()
        {
            try
            {
                var sourceDataPath = Path.Combine(dst, webglDir);
                if (Directory.Exists(sourceDataPath))
                {
                    foreach (string path in Directory.GetFiles(sourceDataPath))
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
                Debug.LogError(ex);
            }
        }
        /// <summary>
        /// 等brotli之后，统计下资源包加brotli压缩后代码包是否超过了20M（小游戏代码分包总大小限制）
        /// </summary>
        private void checkNeedCopyDataPackage(bool brotliError)
        {
            // 如果brotli失败，使用CDN加载
            if (brotliError) {
                Debug.LogWarning("brotli失败，无法检测文件大小，请上传资源文件到CDN");
                ShowNotification(new GUIContent("Brotli压缩失败，不可使用代码分包加载资源"));
                assetLoadType = 0;
            }
            if ((assetLoadType == 1))
            {
                var dataPath = Path.Combine(dst, webglDir, "Build", "webgl.data.unityweb");
                var brcodePath = Path.Combine(dst, miniGameDir, "wasmcode", codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");
                var brcodeInfo = new FileInfo(brcodePath);
                var brcodeSize = brcodeInfo.Length;
                if (brcodeSize + int.Parse(dataFileSize) > 20971520)
                {
                    ShowNotification(new GUIContent("资源文件过大，不适宜用代码分包加载"));
                    assetLoadType = 0;
                } else
                {
                    File.Copy(dataPath, Path.Combine(dst, miniGameDir, "data-package", dataMd5 + ".webgl.data.unityweb.bin.txt"));
                }
            }
            var loadDataFromCdn = assetLoadType == 0;
            Rule[] rules =
            {
                new Rule()
                {
                    old="$DEPLOY_URL",
                    newStr= loadDataFromCdn ? cdn : ""
                },
                new Rule()
                {
                    old="$LOAD_DATA_FROM_SUBPACKAGE",
                    newStr = loadDataFromCdn ? "false" : "true"
                }
            };
            string[] files = { "game.js", "game.json", "project.config.json", "texture-config.js" };
            ReplaceFileContent(files, rules);
        }

        public int GenerateBinFile(bool isFromConvert = false)
        {
            Debug.LogFormat("[Converter] Starting to genarate md5 and copy files");

            var codePath = Path.Combine(dst, webglDir, "Build", "webgl.wasm.code.unityweb");
            codeMd5 = UnityUtil.BuildFileMd5(codePath);

            var dataPath = Path.Combine(dst, webglDir, "Build", "webgl.data.unityweb");
            dataMd5 = UnityUtil.BuildFileMd5(dataPath);

            removeOldAssetPackage();

            File.Copy(dataPath, Path.Combine(dst, webglDir, dataMd5 + ".webgl.data.unityweb.bin.txt"));

            CopyDirectory(Path.Combine(Application.dataPath, "WX-WASM-SDK", "wechat-default"), Path.Combine(dst, miniGameDir), true);

            var info = new FileInfo(dataPath);
            dataFileSize = info.Length.ToString();

            Debug.LogFormat("[Converter] that to genarate md5 and copy files ended");

            ModifyWeChatConfigs(isFromConvert);

            ModifySDKFile();

            ClearFriendRelationCode();
            if (useAudioApi && audioPrefix != null)
            {
                CopyMusicDirectory(Application.dataPath, Path.Combine(dst, webglDir ,audioDir), true);
            }
            return Brotlib(codePath);

        }

        private void ModifySDKFile()
        {
            string content = File.ReadAllText(SDKFilePath, Encoding.UTF8);
            content = content.Replace("$unityVersion$", Application.unityVersion);

            File.WriteAllText(Path.Combine(dst, miniGameDir, "unity-sdk", "index.js"), content, Encoding.UTF8);
        }

        /// <summary>
        /// 从webgl目录模糊搜索preloadfiles中的文件，作为预下载的列表
        /// </summary>
        private string GetPreloadList(string preloadfiles)
        {

            if (preloadFiles == "")
            {
                return "";
            }
            string preloadList = "";
            var streamingAssetsPath = Path.Combine(dst, webglDir + "/StreamingAssets");
            var fileNames = preloadFiles.Split(new char[] { ';' });
            List<System.String> fileList = new List<System.String>(fileNames);
            if (Directory.Exists(streamingAssetsPath))
            {
                foreach (string path in Directory.GetFiles(streamingAssetsPath, "*", SearchOption.AllDirectories))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    foreach (var fileName in fileList)
                    {
                        if (fileInfo.Name.Contains(fileName))
                        {
                            // 相对于StreamingAssets的路径
                            var relativePath = path.Substring(streamingAssetsPath.Length + 1).Replace('\\', '/') + ",";
                            preloadList += ("\"" + relativePath + "\", \r");
                            fileList.Remove(fileName);
                            break;
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("没有找到StreamingAssets目录， 无法生成预下载列表");
            }
            if (fileList.Count != 0)
            {
                Debug.LogError($"并非所有预下载的文件都被找到，剩余{fileList.Count}。");
            }
            return preloadList;
        }

        public void ModifyWeChatConfigs(bool isFromConvert = false)
        {
            Debug.LogFormat("[Converter] Starting to modify configs");

            var config = UnityUtil.GetEditorConf();


            var DATA_Texture_Infos = string.IsNullOrWhiteSpace(config.CompressTexture.TextureRes) ? "\"\"" : config.CompressTexture.TextureRes;
            var DATA_SpriteAtlas_Infos = string.IsNullOrWhiteSpace(config.CompressTexture.SpriteRes) ? "\"\"" : config.CompressTexture.SpriteRes;
            var DATA_Not_POT_Texture_Infos = string.IsNullOrWhiteSpace(config.CompressTexture.NotPotTextureRes) ? "\"\"" : config.CompressTexture.NotPotTextureRes;
            var PRELOAD_LIST = GetPreloadList(preloadFiles);

            Rule[] replaceArrayList =
            {
                new Rule()
                {
                    old="$GAME_NAME",
                    newStr="webgl"
                },
                new Rule()
                {
                    old="$PROJECT_NAME",
                    newStr=projectName == "" ? "webgl" : projectName,
                },
                new Rule()
                {
                    old="$APP_ID",
                    newStr=appid
                },
                new Rule()
                {
                    old="$ORIENTATION",
                    newStr=orientation == 0 ? "portrait" : "landscape"
                },
                new Rule()
                {
                    old="$LOADING_VIDEO_URL",
                    newStr=videoUrl
                },
                new Rule()
                {
                    old="$CODE_MD5",
                    newStr=codeMd5
                },
                new Rule()
                {
                    old="$DATA_MD5",
                    newStr=dataMd5
                },
                new Rule()
                {
                    old="$DATA_FILE_SIZE",
                    newStr=dataFileSize
                },
                new Rule()
                {
                    old="$STREAM_CDN",
                    newStr=streamCDN
                },
                new Rule()
                {
                    old="$AUDIO_PREFIX",
                    newStr=audioPrefix
                },
                new Rule()
                {
                    old="\"$DATA_Texture_Infos\"",
                    newStr=DATA_Texture_Infos
                },
                new Rule()
                {
                    old="\"$DATA_SpriteAtlas_Infos\"",
                    newStr=DATA_SpriteAtlas_Infos
                },
                new Rule()
                {
                    old="\"$DATA_NOT_POT_Texture_Infos\"",
                    newStr=DATA_Not_POT_Texture_Infos
                },
                new Rule()
                {
                    old="\"$PRELOAD_LIST\"",
                    newStr=PRELOAD_LIST
                }
            };

            List<Rule> replaceList = new List<Rule>(replaceArrayList);
            if (isFromConvert) {
                replaceList.RemoveAt(replaceArrayList.Length -1);
                var dstFile = Path.Combine(dst, miniGameDir, "texture-config.js");
                if (File.Exists(dstFile)) {
                    File.Delete(dstFile);
                }
                File.Copy(Path.Combine(dst, webglDir, "texture-config.js"), dstFile);
            }
            else{
                File.WriteAllText(Path.Combine(dst, webglDir, "texture-config.js"), "const TextureConfig = " + DATA_Texture_Infos + ";const SpriteAtlasConfig = " + DATA_SpriteAtlas_Infos + "; GameGlobal.TextureConfig = TextureConfig;GameGlobal.SpriteAtlasConfig = SpriteAtlasConfig; GameGlobal.NotPotTextureConfig = "+DATA_Not_POT_Texture_Infos+";", new UTF8Encoding(false));
            }


            string[] files = { "game.js", "game.json", "project.config.json", "texture-config.js" };


            ReplaceFileContent(files, replaceList.ToArray());



            Debug.LogFormat("[Converter] that to modify configs ended");



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

        public static void TestBrotlib() {
            if (!needPython)
            {
                try
                {
                    var ms = new MemoryStream();
                    var bs = new BrotliStream(ms, System.IO.Compression.CompressionMode.Compress);
                }
                catch (Exception e) {
                    Debug.LogError(e);
                    Debug.LogError("如授权还还是出错，请重启Unity后再授权一次。");
                }

            }

        }


        private int Brotlib(string filePath)
        {
            Debug.LogFormat("[Converter] Starting to generate Brotlib file");

            var dstPath = Path.Combine(dst, miniGameDir, "wasmcode", codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");

            if (needPython)
            {


                string text = File.ReadAllText(Path.Combine(Application.dataPath, "WX-WASM-SDK", "Editor", "Brotli.py"), Encoding.UTF8);

                text = text.Replace("sys.argv[1]", "\"" + filePath + "\"").Replace("sys.argv[2]", "\"" + dstPath + "\"");

                File.WriteAllText(Path.Combine(dst, "Brotli.py"), text, Encoding.UTF8);

                Debug.LogWarning("---因为当前big sur系统的兼容问题，还需您在转出目录 " + dst + " 命令行执行 python3 ./Brotli.py 命令，才能完成！--");

                return 1;

            }
            else
            {
                var fs = File.OpenRead(filePath);
                var ms = new MemoryStream();
                var bs = new BrotliStream(ms, System.IO.Compression.CompressionMode.Compress);
                bs.SetQuality(11);
                fs.CopyTo(bs);
                bs.Dispose();
                byte[] compressed = ms.ToArray();

                FileStream fs2 = new FileStream(dstPath, FileMode.Create, FileAccess.Write, FileShare.None);

                fs2.Write(compressed, 0, compressed.Length);
                fs2.Flush();
                fs2.Close();

                Debug.LogFormat("[Converter] that to generate Brotlib ended");

                return 0;
            }



        }

        /// <summary>
        /// 如果没有使用好友关系链的话，自动删掉无用代码
        /// </summary>
        private void ClearFriendRelationCode()
        {
            if (!useFriendRelation)
            {
                var filePath = Path.Combine(dst, miniGameDir, "game.json");

                string content = File.ReadAllText(filePath, Encoding.UTF8);
                content = content.Replace("\"openDataContext\": \"open-data\",", "");
                File.WriteAllText(filePath, content);

                string openDataDir = Path.Combine(dst, miniGameDir, "open-data");

                UnityUtil.DelectDir(openDataDir);

                Directory.Delete(openDataDir, true);
            }

        }




        private void OnGUI()
        {


            var labelStyle = new GUIStyle(EditorStyles.boldLabel);
            labelStyle.fontSize = 14;

            labelStyle.margin.left = 20;
            labelStyle.margin.top = 10;
            labelStyle.margin.bottom = 10;

            GUILayout.Label("转换参数设置", labelStyle);


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
            projectName = EditorGUILayout.TextField("小游戏项目名", projectName, inputStyle);

            var optionsList = new List<GUIContent>();
            optionsList.Add(new GUIContent("CDN"));
            optionsList.Add(new GUIContent("小游戏分包"));
            GUIContent assetLoadTypeLabel = new GUIContent("首包资源加载方式", "选择'CDN'通过传统CDN加载资源。选择'小游戏分包'通过小游戏代码分包加载资源。小游戏分包有总大小20M限制，若资源加代码总大小超过20M，会自动切换为传统CDN加载");

            assetLoadType = EditorGUILayout.IntPopup(assetLoadTypeLabel, assetLoadType, optionsList.ToArray(), new[] { 0, 1 }, intPopupStyle);

            if (assetLoadType == 0)
            {
                cdn = EditorGUILayout.TextField("游戏资源CDN", cdn, inputStyle);
            }


            streamCDN = EditorGUILayout.TextField("AB包CDN地址", streamCDN, inputStyle);

            videoUrl = EditorGUILayout.TextField("加载阶段视频url", videoUrl, inputStyle);

            audioPrefix = EditorGUILayout.TextField("Assets目录对应CDN地址", audioPrefix, inputStyle);

            // memorySize = EditorGUILayout.IntField("游戏内存大小（MB）", memorySize, inputStyle);


            orientation = EditorGUILayout.IntPopup("游戏方向", orientation, new[] { "竖屏", "横屏" }, new[] { 0, 1 }, intPopupStyle);



            EditorGUILayout.Space();

            GUILayout.Label("导出路径", labelStyle);



            var choosePathButtonClicked = false;
            var openTargetButtonClicked = false;
            var resetButtonClicked = false;

            if (dst == "")
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

            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.margin.left = 20;
            toggleStyle.margin.right = 20;

            GUILayout.Label("SDK功能选项", labelStyle);
            GUILayout.BeginHorizontal();
            useFriendRelation = GUILayout.Toggle(useFriendRelation, "使用好友关系链", toggleStyle);
            useAudioApi = GUILayout.Toggle(useAudioApi, "使用微信音频API", toggleStyle);
            useCompressedTexture = GUILayout.Toggle(useCompressedTexture, "压缩纹理替换(beta)", toggleStyle);
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();


            EditorGUILayout.Space();
            GUILayout.Label("预下载选项", labelStyle);
            GUILayout.BeginHorizontal(); 
            preloadFiles = EditorGUILayout.TextField("文件列表(;间隔，模糊匹配)", preloadFiles, inputStyle);

            GUILayout.EndHorizontal();

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUILayout.Label("调试编译选项", labelStyle);
            GUILayout.BeginHorizontal();

            developBuild = GUILayout.Toggle(developBuild, "Development Build",toggleStyle);
            autoProfile = GUILayout.Toggle(autoProfile, "Autoconnect Profiler", toggleStyle);


            scriptOnly = GUILayout.Toggle(scriptOnly, "Scripts Only Build", toggleStyle);
            GUILayout.EndHorizontal();

            EditorGUILayout.Space();

            GUIStyle exportButtonStyle = new GUIStyle(GUI.skin.button);
            exportButtonStyle.fontSize = 14;
            exportButtonStyle.margin.left = 20;
            exportButtonStyle.margin.top = 40;

            EditorGUILayout.BeginHorizontal();


            var isExportBtnPressed = GUILayout.Button("导出WEBGL并转换为小游戏(常用)", exportButtonStyle, GUILayout.Height(40), GUILayout.Width(EditorGUIUtility.currentViewWidth - 270));

            var isConvertBtnPressed = GUILayout.Button("将WEBGL转为小游戏(不常用)", exportButtonStyle, GUILayout.Height(40), GUILayout.Width(210));

            EditorGUILayout.EndHorizontal();


            if (isExportBtnPressed)
            {

                DoExport();

            }

            if (isConvertBtnPressed)
            {
                DoConvert();
            }

            if (choosePathButtonClicked)
            {
                // 弹出选目录窗口
                var dstPath = EditorUtility.SaveFolderPanel("选择你的游戏导出目录", "", "");

                if (dstPath != "")
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
                dst = "";
            }


            EditorGUILayout.Space();

        }

        // 可以调用这个来集成
        public void DoExport() {

            if (dst == "")
            {
                ShowNotification(new GUIContent("请先选择游戏导出路径"));
            }
            else
            {

                if (useCompressedTexture)
                {
                    WXTextureManager.Recover();
                    //编译之前先把纹理替换
                    WXTextureManager.Start();
                }
               
                //UnityUtil.DelectDir(Path.Combine(dst, webglDir));  //不要执行删除目录，会把压缩纹理也都删掉了。。

                Build();
                ConvertCode();
                int res = GenerateBinFile();
                if (res == 0)
                {
                    checkNeedCopyDataPackage(false);
                    Debug.LogFormat("[Converter] All done!");
                    ShowNotification(new GUIContent("转换完成"));
                }
                else
                {
                    checkNeedCopyDataPackage(true);
                }
            }
        }

        public void DoConvert() {
            if (dst == "")
            {
                ShowNotification(new GUIContent("请先选择游戏导出路径"));
            }
            else if (!Directory.Exists(Path.Combine(dst, webglDir)))
            {

                ShowNotification(new GUIContent("请先点击左侧”导出WEBGL并转换为小游戏“按钮来导出"));
            }
            else
            {
                if (useAudioApi && audioPrefix != null)
                {
                    CopyMusicDirectory(Application.dataPath, Path.Combine(dst,webglDir, audioDir), true);
                }
                ConvertCode();
                int res = GenerateBinFile(true);
                if (res == 0)
                {
                    checkNeedCopyDataPackage(false);
                    Debug.LogFormat("[Converter] All done!");
                    ShowNotification(new GUIContent("转换完成"));
                }
                else
                {
                    checkNeedCopyDataPackage(true);
                }
            }
        }
    }
}
