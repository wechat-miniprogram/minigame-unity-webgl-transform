using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using LitJson;
using System.Text;
using System.Linq;
using System;

namespace WeChatWASM
{


    public class WXReplaceTextureData
    {
        public string path;
        public int width;
        public int height;
        public string astc;
        public string limittype;
    }

    public class WXBundlePicDepsData
    {
        public string bundlePath;
        public List<WXReplaceTextureData> pics;
        public bool isCached;
    }

    public class WXFileCachedData
    {
        public string filePath;
        public string md5;
    }


    public class JSTextureTaskConf
    {
        public string dst;
        public string dataPath;
        public bool useDXT5;
        public List<WXReplaceTextureData> textureList;
    }

    public class JSTextureData
    {
        public string p;
        public int w;
        public int h;
    }

    public class WXTextureFileCacheScriptObject
    {
        public int Version;
        public DateTime UpdateTime;
        public int CostTimeInSeconds;
        public List<WXFileCachedData> cachedDatas = new List<WXFileCachedData>();
    }

    public class WXTextureReplacerScriptObject
    {
        public int Version;
        public DateTime UpdateTime;
        public List<WXBundlePicDepsData> bundlePicDeps = new List<WXBundlePicDepsData>();
    }

    public class WXTextureEditorWindow : EditorWindow
    {
        public static WXEditorScriptObject miniGameConf;

        [MenuItem("微信小游戏 / 包体瘦身--压缩纹理")]
        public static void Open()
        {
            miniGameConf = UnityUtil.GetEditorConf();
            var win = GetWindow(typeof(WXTextureEditorWindow), false, "包体瘦身--压缩纹理", true);//创建窗口
            win.minSize = new Vector2(600, 450);
            win.maxSize = new Vector2(600, 450);
            win.Show();
        }

        public static void Log(string type, string msg)
        {

            if (type == "Error")
            {
                UnityEngine.Debug.LogError(msg);
            }
            else if (type == "Log")
            {
                UnityEngine.Debug.Log(msg);
            }
            else if (type == "Warn")
            {
                UnityEngine.Debug.LogWarning(msg);
            }

        }

        private static WXTextureReplacerScriptObject GetTextureEditorCacheConf()
        {
            var BundlePicsFilePath = Path.Combine(GetDestDir(), "BundlePicsFile.json");
            string BundlePicsFileJson = "";
            if (File.Exists(BundlePicsFilePath))
            {
                using (FileStream fileStream = new FileStream(BundlePicsFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        BundlePicsFileJson = reader.ReadToEnd();
                    }
                }
            }
            WXTextureReplacerScriptObject wXTextureReplacerScriptObject = JsonMapper.ToObject<WXTextureReplacerScriptObject>(BundlePicsFileJson);
            Dictionary<string, List<WXReplaceTextureData>> cacheMap = new Dictionary<string, List<WXReplaceTextureData>>();
            if (wXTextureReplacerScriptObject == null) wXTextureReplacerScriptObject = new WXTextureReplacerScriptObject();
            if (wXTextureReplacerScriptObject.bundlePicDeps == null) wXTextureReplacerScriptObject.bundlePicDeps = new List<WXBundlePicDepsData>();
            return wXTextureReplacerScriptObject;
        }

        public static void CreateJSTask()
        {

            WXTextureReplacerScriptObject wXTextureReplacerScriptObject = GetTextureEditorCacheConf();
            List<WXReplaceTextureData> list = new List<WXReplaceTextureData>();
            Dictionary<string, List<WXReplaceTextureData>> cacheMap = new Dictionary<string, List<WXReplaceTextureData>>();
            foreach (var item in wXTextureReplacerScriptObject.bundlePicDeps)
            {
                if (item.pics == null)
                {
                    continue;
                }
                list = list.Union(item.pics).ToList();
                cacheMap.Add(item.bundlePath, item.pics);
            }
            var conf = new JSTextureTaskConf()
            {
                dst = GetDestDir(),
                dataPath = Application.dataPath,
                useDXT5 = miniGameConf.CompressTexture.useDXT5,
                textureList = list,
            };

            File.WriteAllText(Application.dataPath + "/WX-WASM-SDK/Editor/Node/conf.js", "module.exports = " + JsonMapper.ToJson(conf));

            UnityEngine.Debug.LogError($"最后一步请安装 Nodejs 然后进入{Application.dataPath}/WX-WASM-SDK/Editor/Node 目录用命令行，执行 ’node compress_astc_only.js‘ (开发阶段使用) 或 ’node compress_all.js‘（上线时候使用） 命令来生成纹理。");

            ModifiyJsFile(cacheMap);
        }

        private void showToast(string content, bool err = false)
        {
            if (err)
            {
                UnityEngine.Debug.LogError(content);
            }
            else
            {
                UnityEngine.Debug.LogFormat(content);
            }
            ShowNotification(new GUIContent(content));
        }

        public static void ModifiyJsFile(Dictionary<string, List<WXReplaceTextureData>> picDeps)
        {


            //修改使用纹理dxt
            string content = File.ReadAllText(Path.Combine(Application.dataPath, "WX-WASM-SDK", "wechat-default", "unity-sdk", "texture.js"), Encoding.UTF8);

            content = content.Replace("\"$UseDXT5$\"", miniGameConf.CompressTexture.useDXT5 ? "true" : "false");

            File.WriteAllText(Path.Combine(miniGameConf.ProjectConf.DST, "minigame", "unity-sdk", "texture.js"), content, Encoding.UTF8);

            Dictionary<string, List<JSTextureData>> picDepsShort = new Dictionary<string, List<JSTextureData>>();
            foreach (var item in picDeps)
            {
                if (item.Key != "unity_default_resources")
                {
                    var list = new List<JSTextureData>();
                    if (item.Value == null)
                    {
                        continue;
                    }
                    foreach (var data in item.Value)
                    {
                        list.Add(new JSTextureData()
                        {
                            h = data.height,
                            w = data.width,
                            p = data.path
                        });
                    }
                    picDepsShort.Add(item.Key, list);
                }
            }

            var textureConfigPath = Path.Combine(miniGameConf.ProjectConf.DST, "minigame", "texture-config.js");

            if (miniGameConf.CompressTexture.parallelWithBundle)
            {

                File.WriteAllText(textureConfigPath, "GameGlobal.USED_TEXTURE_COMPRESSION=true;GameGlobal.TEXTURE_PARALLEL_BUNDLE=true;GameGlobal.TEXTURE_BUNDLES = " + JsonMapper.ToJson(picDepsShort), Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(textureConfigPath, "GameGlobal.USED_TEXTURE_COMPRESSION=true;GameGlobal.TEXTURE_PARALLEL_BUNDLE=false;GameGlobal.TEXTURE_BUNDLES = ''", Encoding.UTF8);
            }


        }

        public static string GetDestDir()
        {
            var dstDir = miniGameConf.ProjectConf.DST + "/webgl-min";
            if (!string.IsNullOrEmpty(miniGameConf.CompressTexture.dstMinDir))
            {
                dstDir = miniGameConf.CompressTexture.dstMinDir;
            }
            return dstDir;
        }

        public static void ReplaceBundle()
        {

            if (string.IsNullOrEmpty(miniGameConf.CompressTexture.bundleSuffix))
            {
                UnityEngine.Debug.LogError("bundle后缀不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(miniGameConf.ProjectConf.DST))
            {
                UnityEngine.Debug.LogError("请先转换为小游戏！");
                return;
            }
            if (!File.Exists(miniGameConf.ProjectConf.DST + "/webgl/index.html"))
            {
                UnityEngine.Debug.LogError("请先转换为小游戏！并确保导出目录下存在webgl目录！");
                return;
            }
            UnityEngine.Debug.Log("Start! 【" + System.DateTime.Now.ToString("T") + "】");

            var dstDir = GetDestDir();
            var dstTexturePath = dstDir + "/Assets/Textures";
            var sourceDir = miniGameConf.ProjectConf.DST + "/webgl";

            var path = "";
            var exePath = Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/TextureEditor/Release/WXTextureMin.exe");
            var classDataPath = Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/TextureEditor/classdata.tpk");
            var bundlePathArg = string.IsNullOrEmpty(miniGameConf.CompressTexture.bundleDir) ? "" : $" -bd {miniGameConf.CompressTexture.bundleDir}";
#if UNITY_EDITOR_OSX
            var monoPath = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Unity.app/Contents/MonoBleedingEdge/bin/mono");
            Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/TextureEditor/Release/WXTextureMin.exe");
            WeChatWASM.UnityUtil.RunCmd(monoPath, string.Format($" {exePath} -b {miniGameConf.CompressTexture.bundleSuffix} " +
                    $" -d {dstDir}" +
                    $" -dt {dstTexturePath}" +
                    $" -s {sourceDir}" +
                    $" -c {classDataPath}" +
                    $" {bundlePathArg}"), path,
                    (current, total, extInfo) => {
                        EditorUtility.DisplayProgressBar($"TextureMin Bundle处理中，当前:{current}，总共:{total}", $"Handling:{extInfo}", current * 1.0f / total);
                    });
            EditorUtility.ClearProgressBar();
#else
            exePath = Path.Combine(Application.dataPath, "WX-WASM-SDK/Editor/TextureEditor/Release/WXTextureMin.exe");
            WeChatWASM.UnityUtil.RunCmd(exePath, string.Format($" -b {miniGameConf.CompressTexture.bundleSuffix} " +
                    $" -d {dstDir}" +
                    $" -dt {dstTexturePath}" +
                    $" -s {sourceDir}" +
                    $" -c {classDataPath}"  + 
                    $" {bundlePathArg}"), path, 
                    (current, total, extInfo) => {
                        EditorUtility.DisplayProgressBar($"TextureMin Bundle处理中，当前:{current}，总共:{total}", $"Handling:{extInfo}", current * 1.0f / total);
                    });
            EditorUtility.ClearProgressBar();
#endif





            OnReplaceEnd();
        }

        private static void OnReplaceEnd()
        {

            CreateJSTask();


            if (miniGameConf.ProjectConf.assetLoadType == 1)
            {

                DirectoryInfo TheFolder = new DirectoryInfo(miniGameConf.ProjectConf.DST + "/minigame/data-package/");
                var dstDataFiles = TheFolder.GetFiles("*.txt");
                if (dstDataFiles.Length != 1)
                {
                    Debug.LogError("目录minigame/data-package/无法找到data首资源文件, 无法进行首资源包替换");
                    return;
                }
                var dstDataFile = dstDataFiles[0].FullName;
                var sourceDataFile = Path.Combine(GetDestDir(), Path.GetFileName(dstDataFile));
                if (!File.Exists(sourceDataFile))
                {
                    Debug.LogError($"sourceDataFile not exist {sourceDataFile}");
                    return;
                }
                File.Delete(dstDataFile);
                File.Copy(sourceDataFile, dstDataFile);

            }
            // 替换资源文件后更新文件大小
            // var info = new FileInfo(sourceDataFile);
            // var oldSize = WXEditorWindow.GetWindow<WXEditorWindow>().dataFileSize;
            // var newSize = info.Length.ToString();
            // string[] files = {"game.js"};
            // Rule[] rules = {
            //     new Rule() {
            //         old="DATA_FILE_SIZE: \"" + oldSize + "\"",
            //         newStr="DATA_FILE_SIZE: \"" + newSize + "\""
            //     }
            // };
            // WXEditorWindow.GetWindow<WXEditorWindow>().ReplaceFileContent(files, rules);

            UnityEngine.Debug.Log("Done! 【" + System.DateTime.Now.ToString("T") + "】");
        }

        private void OnDisable()
        {
            EditorUtility.SetDirty(miniGameConf);
        }

        private void OnEnable()
        {
            miniGameConf = UnityUtil.GetEditorConf();
        }

        private void OnGUI()
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

            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.margin.left = 20;
            toggleStyle.margin.right = 20;

            miniGameConf.CompressTexture.bundleSuffix = EditorGUILayout.TextField(new GUIContent("bunlde文件后缀(?)", "多个不同后缀可用;分割开来"), miniGameConf.CompressTexture.bundleSuffix, inputStyle);


            GUILayout.Label(new GUIContent("bundle资源配置(?)", "可启用忽略、对ASCT格式进行bundle粒度的配置。注：忽略的bundle(被压缩过)将被强制还原为原始bundle"), labelStyle);

            GUIStyle pathButtonStyle0 = new GUIStyle(GUI.skin.button);
            pathButtonStyle0.fontSize = 12;
            pathButtonStyle0.margin.left = 20;

            //if (useBundleIgnore) {
            GUILayout.BeginHorizontal();
            GUIStyle pathButtonStyle1 = new GUIStyle(GUI.skin.button);
            pathButtonStyle1.fontSize = 12;
            pathButtonStyle1.margin.left = 20;
            //GUIStyle pathButtonStyle2 = new GUIStyle(GUI.skin.button);
            //pathButtonStyle2.fontSize = 12;
            //pathButtonStyle2.margin.left = 10;
            //if (GUILayout.Button(new GUIContent("编辑忽略列表"), pathButtonStyle1, GUILayout.Height(30), GUILayout.Width(100)))
            //{
            //    var win2 = GetWindow(typeof(WXBundleSelectorWindow), false, "选择被忽略的Bundle资源", true);//创建窗口
            //    win2.minSize = new Vector2(570, 300);
            //    win2.Show();
            //}
            if (GUILayout.Button(new GUIContent("打开bundle配置面板"), pathButtonStyle1, GUILayout.Height(30), GUILayout.Width(150)))
            {
                var win2 = GetWindow(typeof(WXBundleSettingWindow), false, "Bundle配置面板", true);//创建窗口
                win2.minSize = new Vector2(680, 350);
                win2.Show();
            }
            //if (GUILayout.Button(new GUIContent("关闭忽略"), pathButtonStyle2, GUILayout.Height(30), GUILayout.Width(60)))
            //{
            //    this.cancelBundleIgnore();
            //}
            GUILayout.EndHorizontal();
            //}
            //else
            //{
            //    if (GUILayout.Button(new GUIContent("忽略部分bundle资源，默认不用选"), pathButtonStyle0, GUILayout.Height(30), GUILayout.Width(300)))
            //    {
            //        this.useBundleIgnore = true;
            //        var win2 = GetWindow(typeof(WXBundleSelectorWindow), false, "选择被忽略的Bundle资源", true);//创建窗口
            //        win2.minSize = new Vector2(570, 300);
            //        win2.Show();
            //    }
            //}

            GUILayout.Label(new GUIContent("功能选项(?)", "每次变更了下列选项都需要重新发布小游戏包"), labelStyle);
            GUILayout.BeginHorizontal();

            var labelStyle2 = new GUIStyle(EditorStyles.label);

            labelStyle2.margin.left = 20;
            GUILayout.Label(new GUIContent("支持PC端压缩纹理(?)", "使PC微信也支持压缩纹理，不过会在开发阶段增加纹理生成耗时。"), labelStyle2, GUILayout.Height(22), GUILayout.Width(150));

            miniGameConf.CompressTexture.useDXT5 = GUILayout.Toggle(miniGameConf.CompressTexture.useDXT5, "", GUILayout.Height(22), GUILayout.Width(50));

            //GUILayout.Label(new GUIContent("纹理与bundle并行加载(?)", "默认纹理是解析bundle后才加载，勾选后加载bundle时bundle对应纹理就会同时加载。"), labelStyle2, GUILayout.Height(22), GUILayout.Width(150));

            miniGameConf.CompressTexture.parallelWithBundle = false; //GUILayout.Toggle(miniGameConf.CompressTexture.parallelWithBundle, "", GUILayout.Height(22), GUILayout.Width(50));

            GUILayout.EndHorizontal();

            GUILayout.Label(new GUIContent("自定义目录(?)", "默认不用选择"), labelStyle);

            var labelStyle3 = new GUIStyle(EditorStyles.boldLabel);
            labelStyle3.fontSize = 12;

            labelStyle3.margin.left = 20;
            labelStyle3.margin.top = 10;
            labelStyle3.margin.bottom = 10;

            GUILayout.Label("bundle路径", labelStyle3);

            var chooseBundlePathButtonClicked = false;
            var openBundleButtonClicked = false;
            var resetBundleButtonClicked = false;

            int pathButtonHeight = 28;
            GUIStyle pathLabelStyle = new GUIStyle(GUI.skin.textField);
            pathLabelStyle.fontSize = 12;
            pathLabelStyle.alignment = TextAnchor.MiddleLeft;
            pathLabelStyle.margin.top = 6;
            pathLabelStyle.margin.bottom = 6;
            pathLabelStyle.margin.left = 20;

            if (string.IsNullOrEmpty(miniGameConf.CompressTexture.bundleDir))
            {
                GUIStyle pathButtonStyle2 = new GUIStyle(GUI.skin.button);
                pathButtonStyle2.fontSize = 12;
                pathButtonStyle2.margin.left = 20;

                chooseBundlePathButtonClicked = GUILayout.Button("选择自定义bundle路径，默认不用选", pathButtonStyle2, GUILayout.Height(30), GUILayout.Width(300));
            }
            else
            {
                GUILayout.BeginHorizontal();
                // 路径框
                GUILayout.Label(miniGameConf.CompressTexture.bundleDir, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 126));
                openBundleButtonClicked = GUILayout.Button("打开", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                resetBundleButtonClicked = GUILayout.Button("重选", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                GUILayout.EndHorizontal();
            }
            EditorGUILayout.Space();


            if (chooseBundlePathButtonClicked)
            {
                // 弹出选目录窗口
                var dstPath = EditorUtility.SaveFolderPanel("选择你的bundle目录", "", "");

                if (dstPath != "")
                {
                    miniGameConf.CompressTexture.bundleDir = dstPath;
                }

            }

            if (openBundleButtonClicked)
            {
                UnityUtil.ShowInExplorer(miniGameConf.CompressTexture.bundleDir);
            }
            if (resetBundleButtonClicked)
            {
                miniGameConf.CompressTexture.bundleDir = "";
            }



            GUILayout.Label("自定义资源处理后存放路径", labelStyle3);

            var chooseDstPathButtonClicked = false;
            var openDstButtonClicked = false;
            var resetDstButtonClicked = false;


            if (string.IsNullOrEmpty(miniGameConf.CompressTexture.dstMinDir))
            {
                GUIStyle pathButtonStyle2 = new GUIStyle(GUI.skin.button);
                pathButtonStyle2.fontSize = 12;
                pathButtonStyle2.margin.left = 20;

                chooseDstPathButtonClicked = GUILayout.Button("选择自定义资源处理后存放路径，默认不用选", pathButtonStyle2, GUILayout.Height(30), GUILayout.Width(300));
            }
            else
            {
                GUILayout.BeginHorizontal();
                // 路径框
                GUILayout.Label(miniGameConf.CompressTexture.dstMinDir, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 126));
                openDstButtonClicked = GUILayout.Button("打开", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                resetDstButtonClicked = GUILayout.Button("重选", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                GUILayout.EndHorizontal();
            }
            EditorGUILayout.Space();


            if (chooseDstPathButtonClicked)
            {
                // 弹出选目录窗口
                var dstPath = EditorUtility.SaveFolderPanel("选择你的自定义资源处理后存放路径", "", "");

                if (dstPath != "")
                {
                    miniGameConf.CompressTexture.dstMinDir = dstPath;
                }

            }

            if (openDstButtonClicked)
            {
                UnityUtil.ShowInExplorer(miniGameConf.CompressTexture.dstMinDir);
            }
            if (resetDstButtonClicked)
            {
                miniGameConf.CompressTexture.dstMinDir = "";
            }




            GUILayout.Label("操作", labelStyle);

            GUIStyle pathButtonStyle = new GUIStyle(GUI.skin.button);
            pathButtonStyle.fontSize = 12;
            pathButtonStyle.margin.left = 20;
            pathButtonStyle.margin.right = 20;

            EditorGUILayout.BeginHorizontal();


            var replaceTexture = GUILayout.Button(new GUIContent("处理资源(?)", "处理完成后会在导出目录生成webgl-min目录，bundle文件要换成使用webgl-min目录下的bundle文件，xx.webgl.data.unityweb.bin.txt文件也要换成使用webgl-min目录下对应的文件，注意要将导出目录里面Assets目录下的都上传至CDN对应路径，小游戏里才会显示成正常的压缩纹理。注意bundle文件不能开启crc校验，否则会展示异常。"), pathButtonStyle, GUILayout.Height(40), GUILayout.Width(140));


            var goReadMe = GUILayout.Button(new GUIContent("README"), pathButtonStyle, GUILayout.Height(40), GUILayout.Width(80));

            EditorGUILayout.EndHorizontal();

            if (replaceTexture)
            {
                if (!this.checkUnityVersion())
                    return;

                ReplaceBundle();
            }

            if (goReadMe)
            {
                Application.OpenURL("https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/CompressedTexture.md");
            }


        }


        private static string[] supportUnityVersion = new string[] { "2018.", "2019.", "2020.", "2021.2" };
        /**
            Unity 2021.3.x 及以后 2022 等版本均不支持纹理压缩
            支持版本： 2018、2019、2020、2021 其中2021.3.x 不支持 https://github.com/wechat-miniprogram/minigame-unity-webgl-transform#%E5%AE%89%E8%A3%85%E4%B8%8E%E4%BD%BF%E7%94%A8
        */
        private bool checkUnityVersion()
        {
            string unityVersion = Application.unityVersion;
            bool success = false;
            for (int i = 0; i < supportUnityVersion.Length; i++)
            {
                if (unityVersion.IndexOf(supportUnityVersion[i]) != -1)
                {
                    success = true;
                    break;
                }
            }
            if (!success)
            {
                if (unityVersion.IndexOf("2021.3") != -1)
                {
                    this.showToast("纹理压缩工具暂不支持Unity 2021.3.x 版本，请使用 2021.2.18(含)之前版本", true);
                    return false;
                }

                this.showToast("当前Unity版本可能不支持纹理压缩，建议使用 2021.2.18(含)之前版本");
            }
            return true;

        }

    }

}