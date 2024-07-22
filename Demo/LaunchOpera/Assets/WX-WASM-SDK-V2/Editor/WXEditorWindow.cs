using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using static WeChatWASM.WXConvertCore;
using System;

namespace WeChatWASM
{

    public class WXEditorWin : EditorWindow
    {
        private static WXEditorScriptObject config;
        private bool fbSlimSupport = true;
        [MenuItem("微信小游戏 / 转换小游戏", false, 1)]
        public static void Open()
        {
            var win = GetWindow(typeof(WXEditorWin), false, "微信小游戏转换工具面板");
            win.minSize = new Vector2(350, 400);
            win.position = new Rect(100, 100, 600, 700);
            win.Show();
            // 打开面板时自动检查更新
            PluginUpdateManager.CheckUpdte();
        }

        // 向前兼容，请使用 WXConvertCore.cs
        public static WXExportError DoExport(bool buildWebGL = true)
        {
            return WXConvertCore.DoExport(buildWebGL);
        }

        // Start is called before the first frame update
        void Start()
        {
            foldInstantGame = WXConvertCore.IsInstantGameAutoStreaming();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnFocus()
        {
            loadData();
        }

        public void OnLostFocus()
        {
            saveData();
        }

        public void OnDisable()
        {
            EditorUtility.SetDirty(config);
        }

        public Texture tex;
        public void OnGUI()
        {
            scrollRoot = EditorGUILayout.BeginScrollView(scrollRoot);

            GUIStyle linkStyle = new GUIStyle(GUI.skin.label);
            linkStyle.normal.textColor = Color.yellow;
            linkStyle.hover.textColor = Color.yellow;
            linkStyle.stretchWidth = false;
            linkStyle.alignment = TextAnchor.UpperLeft;
            linkStyle.wordWrap = true;

            foldBaseInfo = EditorGUILayout.Foldout(foldBaseInfo, "基本信息");
            if (foldBaseInfo)
            {
                EditorGUILayout.BeginVertical("frameBox");

                this.formInput("appid", "游戏AppID");
                this.formInput("cdn", "游戏资源CDN");
                this.formInput("projectName", "小游戏项目名");
                this.formIntPopup("orientation", "游戏方向", new[] { "Portrait", "Landscape", "LandscapeLeft", "LandscapeRight" }, new[] { 0, 1, 2, 3 });
                this.formInput("memorySize", "UnityHeap预留内存(?)", "单位MB，预分配内存值，超休闲游戏256/中轻度496/重度游戏768，需预估游戏最大UnityHeap值以防止内存自动扩容带来的峰值尖刺。预估方法请查看GIT文档《优化Unity WebGL的内存》");

                GUILayout.BeginHorizontal();
                string targetDst = "dst";
                if (!formInputData.ContainsKey(targetDst))
                {
                    formInputData[targetDst] = "";
                }
                EditorGUILayout.LabelField(string.Empty, GUILayout.Width(10));
                GUILayout.Label("导出路径", GUILayout.Width(140));
                formInputData[targetDst] = GUILayout.TextField(formInputData[targetDst], GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 270));
                if (GUILayout.Button(new GUIContent("打开"), GUILayout.Width(40)))
                {
                    if (!formInputData[targetDst].Trim().Equals(string.Empty))
                    {
                        EditorUtility.RevealInFinder(formInputData[targetDst]);
                    }
                    GUIUtility.ExitGUI();
                }
                if (GUILayout.Button(new GUIContent("选择"), GUILayout.Width(40)))
                {
                    var dstPath = EditorUtility.SaveFolderPanel("选择你的游戏导出目录", string.Empty, string.Empty);
                    if (dstPath != string.Empty)
                    {
                        formInputData[targetDst] = dstPath;
                        this.saveData();
                    }
                    GUIUtility.ExitGUI();
                }
                GUILayout.EndHorizontal();


                EditorGUILayout.EndVertical();
            }

            foldLoadingConfig = EditorGUILayout.Foldout(foldLoadingConfig, "启动Loading配置");
            if (foldLoadingConfig)
            {
                EditorGUILayout.BeginVertical("frameBox");

                GUILayout.BeginHorizontal();
                string targetBg = "bgImageSrc";
                EditorGUILayout.LabelField(string.Empty, GUILayout.Width(10));
                tex = (Texture)EditorGUILayout.ObjectField("启动背景图/视频封面", tex, typeof(Texture2D), false);
                var currentBgSrc = AssetDatabase.GetAssetPath(tex);
                if (!string.IsNullOrEmpty(currentBgSrc) && currentBgSrc != this.formInputData[targetBg])
                {
                    this.formInputData[targetBg] = currentBgSrc;
                    this.saveData();
                }
                GUILayout.EndHorizontal();

                this.formInput("videoUrl", "加载阶段视频URL");
                this.formIntPopup("assetLoadType", "首包资源加载方式", new[] { "CDN", "小游戏包内" }, new[] { 0, 1 });
                this.formCheckbox("compressDataPackage", "压缩首包资源(?)", "将首包资源Brotli压缩, 降低资源大小. 注意: 首次启动耗时可能会增加200ms, 仅推荐使用小游戏分包加载时节省包体大小使用");
                this.formInput("bundleExcludeExtensions", "不自动缓存文件类型(?)", "(使用;分割)当请求url包含资源'cdn+StreamingAssets'时会自动缓存，但StreamingAssets目录下不是所有文件都需缓存，此选项配置不需要自动缓存的文件拓展名。默认值json");
                this.formInput("bundleHashLength", "Bundle名称Hash长度(?)", "自定义Bundle文件名中hash部分长度，默认值32，用于缓存控制。");
                this.formInput("preloadFiles", "预下载文件列表(?)", "使用;间隔，支持模糊匹配");

                EditorGUILayout.EndVertical();
            }

            foldSDKOptions = EditorGUILayout.Foldout(foldSDKOptions, "SDK功能选项");
            if (foldSDKOptions)
            {
                EditorGUILayout.BeginVertical("frameBox");

                this.formCheckbox("useFriendRelation", "使用好友关系链");
                this.formCheckbox("useMiniGameChat", "使用社交组件");
                this.formCheckbox("preloadWXFont", "预加载微信字体(?)", "在game.js执行开始时预载微信系统字体，运行期间可使用WX.GetWXFont获取微信字体");

                EditorGUILayout.EndVertical();
            }

            foldDebugOptions = EditorGUILayout.Foldout(foldDebugOptions, "调试编译选项");
            if (foldDebugOptions)
            {
                EditorGUILayout.BeginVertical("frameBox");


                this.formCheckbox("developBuild", "Development Build");
                this.formCheckbox("autoProfile", "Auto connect Profiler");
                this.formCheckbox("scriptOnly", "Scripts Only Build");
                this.formCheckbox("il2CppOptimizeSize", "Il2Cpp Optimize Size(?)", "对应于Il2CppCodeGeneration选项，勾选时使用OptimizeSize(默认推荐)，生成代码小15%左右，取消勾选则使用OptimizeSpeed。游戏中大量泛型集合的高频访问建议OptimizeSpeed，在使用HybridCLR等第三方组件时只能用OptimizeSpeed。");
                this.formCheckbox("profilingFuncs", "Profiling Funcs");
                this.formCheckbox("profilingMemory", "Profiling Memory");
                this.formCheckbox("webgl2", "WebGL2.0(beta)");
                this.formCheckbox("deleteStreamingAssets", "Clear Streaming Assets");
                this.formCheckbox("cleanBuild", "Clean WebGL Build");
                // this.formCheckbox("cleanCloudDev", "Clean Cloud Dev");
                this.formCheckbox("fbslim", "首包资源优化(?)", "导出时自动清理UnityEditor默认打包但游戏项目从未使用的资源，瘦身首包资源体积，建议所有游戏启用。" + (this.fbSlimSupport ? "" : "(当前Unity Editor暂不支持该能力)"), !this.fbSlimSupport, (res) =>
                {
                    var fbWin = GetWindow(typeof(WXFbSettingWindow), false, "首包资源优化配置面板", true);
                    fbWin.minSize = new Vector2(680, 350);
                    fbWin.Show();
                });
                this.formCheckbox("showMonitorSuggestModal", "显示优化建议弹窗");
                this.formCheckbox("enableProfileStats", "显示性能面板");
                this.formCheckbox("enableRenderAnalysis", "显示渲染日志(dev only)");
                EditorGUILayout.EndVertical();
            }

#if UNITY_INSTANTGAME
            foldInstantGame = EditorGUILayout.Foldout(foldInstantGame, "Instant Game - AutoStreaming");
            if (foldInstantGame)
            {
                EditorGUILayout.BeginVertical("frameBox");
                this.formInput("bundlePathIdentifier", "Bundle Path Identifier");
                this.formInput("dataFileSubPrefix", "Data File Sub Prefix");

                EditorGUI.BeginDisabledGroup(true);
                this.formCheckbox("autoUploadFirstBundle", "构建后自动上传首包(?)", "仅在开启AutoStreaming生效", true);
                EditorGUI.EndDisabledGroup();

                GUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(string.Empty, GUILayout.Width(10));
                GUILayout.Label(new GUIContent("清理AS配置(?)", "如需关闭AutoStreaming选用默认发布方案则需要清理AS配置项目。"), GUILayout.Width(140));
                EditorGUI.BeginDisabledGroup(WXConvertCore.IsInstantGameAutoStreaming());
                if(GUILayout.Button(new GUIContent("恢复"),GUILayout.Width(60))){
                    string identifier = config.ProjectConf.bundlePathIdentifier;
                    string[] identifiers = identifier.Split(";");
                    string idStr = "";
                    foreach (string id in identifiers)
                    {
                        if (id != "AS" && id != "CUS/CustomAB")
                        {
                            idStr += id + ";";
                        }
                    }
                    config.ProjectConf.bundlePathIdentifier = idStr.Trim(';');
                    if (config.ProjectConf.dataFileSubPrefix == "CUS")
                    {
                        config.ProjectConf.dataFileSubPrefix = "";
                    }
                    this.loadData();
                }
                EditorGUI.EndDisabledGroup();
                GUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(string.Empty);
                if (GUILayout.Button(new GUIContent("了解Instant Game AutoStreaming", ""), linkStyle))
                {
                    Application.OpenURL("https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/InstantGameGuide.md");
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }
#endif
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(new GUIContent("更多配置项"), GUILayout.Width(100), GUILayout.Height(25)))
            {
                var config = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("Assets/WX-WASM-SDK-V2/Editor/MiniGameConfig.asset");
                Selection.activeObject = config;
                GUIUtility.ExitGUI();
            }
            if (GUILayout.Button(new GUIContent("WebGL转小游戏(不常用)"), GUILayout.Width(150), GUILayout.Height(25)))
            {
                this.saveData();
                if (WXConvertCore.DoExport(false) == WXConvertCore.WXExportError.SUCCEED)
                {
                    ShowNotification(new GUIContent("转换完成"));
                }

                GUIUtility.ExitGUI();
            }
            EditorGUILayout.LabelField(string.Empty, GUILayout.MinWidth(10));
            if (GUILayout.Button(new GUIContent("生成并转换"), GUILayout.Width(100), GUILayout.Height(25)))
            {
                this.saveData();
                if (WXConvertCore.DoExport() == WXConvertCore.WXExportError.SUCCEED)
                {
                    if (!WXConvertCore.IsInstantGameAutoStreaming())
                        ShowNotification(new GUIContent("转换完成"));
                    else
                    {
#if UNITY_WEBGL && UNITY_INSTANTGAME
                        // 上传首包资源
                        if (!string.IsNullOrEmpty(WXConvertCore.FirstBundlePath) && File.Exists(WXConvertCore.FirstBundlePath))
                        {
                            if (Unity.InstantGame.IGBuildPipeline.UploadWeChatDataFile(WXConvertCore.FirstBundlePath))
                            {
                                Debug.Log("转换完成并成功上传首包资源");
                                ShowNotification(new GUIContent("转换完成并成功上传"));
                            }
                            else
                            {
                                Debug.LogError("首包资源上传失败，请检查网络以及Auto Streaming配置是否正确。");
                                ShowNotification(new GUIContent("上传失败"));
                            }
                        }
                        else
                        {
                            Debug.LogError("转换失败");
                            ShowNotification(new GUIContent("转换失败"));
                        }
#else
                        ShowNotification(new GUIContent("转换完成"));
#endif
                    }
                }
                GUIUtility.ExitGUI();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Empty);
            if (GUILayout.Button(new GUIContent("了解如何实现自定义构建", ""), linkStyle))
            {
                Application.OpenURL("https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/DevelopmentQAList.md#13%E5%A6%82%E4%BD%95%E8%87%AA%E5%AE%9A%E4%B9%89%E6%8E%A5%E5%85%A5%E6%9E%84%E5%BB%BA%E6%B5%81%E7%A8%8B");
                GUIUtility.ExitGUI();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndScrollView();
        }



        private Vector2 scrollRoot;
        private bool foldBaseInfo = true;
        private bool foldLoadingConfig = true;
        private bool foldSDKOptions = true;
        private bool foldDebugOptions = true;
        private bool foldInstantGame = false;
        private Dictionary<string, string> formInputData = new Dictionary<string, string>();
        private Dictionary<string, int> formIntPopupData = new Dictionary<string, int>();
        private Dictionary<string, bool> formCheckboxData = new Dictionary<string, bool>();

        private string SDKFilePath;


        private void addBundlePathIdentifier(string value)
        {
            string identifier = config.ProjectConf.bundlePathIdentifier;
            if (identifier[identifier.Length - 1] != ';')
            {
                identifier += ";";
            }
            identifier += value;
            config.ProjectConf.bundlePathIdentifier = identifier;
        }
        private void loadData()
        {
            SDKFilePath = Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "index.js");
            config = UnityUtil.GetEditorConf();

            // Instant Game
            if (WXConvertCore.IsInstantGameAutoStreaming())
            {
                config.ProjectConf.CDN = WXConvertCore.GetInstantGameAutoStreamingCDN();
                string identifier = config.ProjectConf.bundlePathIdentifier;
                string[] identifiers = identifier.Split(';');
                bool AS = false;
                bool CUS = false;
                foreach (string id in identifiers)
                {
                    if (id == "AS")
                    {
                        AS = true;
                    }
                    if (id == "CUS/CustomAB")
                    {
                        CUS = true;
                    }
                }
                if (!AS)
                {
                    this.addBundlePathIdentifier("AS");
                }
                if (!CUS)
                {
                    this.addBundlePathIdentifier("CUS/CustomAB");
                }
                if (config.ProjectConf.dataFileSubPrefix != "CUS")
                {
                    config.ProjectConf.dataFileSubPrefix = "CUS";
                }
            }

            this.setData("projectName", config.ProjectConf.projectName);
            this.setData("appid", config.ProjectConf.Appid);
            this.setData("cdn", config.ProjectConf.CDN);
            this.setData("assetLoadType", config.ProjectConf.assetLoadType);
            this.setData("compressDataPackage", config.ProjectConf.compressDataPackage);
            this.setData("videoUrl", config.ProjectConf.VideoUrl);
            this.setData("orientation", (int)config.ProjectConf.Orientation);
            this.setData("dst", config.ProjectConf.DST);
            this.setData("bundleHashLength", config.ProjectConf.bundleHashLength.ToString());
            this.setData("bundlePathIdentifier", config.ProjectConf.bundlePathIdentifier);
            this.setData("bundleExcludeExtensions", config.ProjectConf.bundleExcludeExtensions);
            this.setData("preloadFiles", config.ProjectConf.preloadFiles);
            this.setData("developBuild", config.CompileOptions.DevelopBuild);
            this.setData("autoProfile", config.CompileOptions.AutoProfile);
            this.setData("scriptOnly", config.CompileOptions.ScriptOnly);
            this.setData("il2CppOptimizeSize", config.CompileOptions.Il2CppOptimizeSize);
            this.setData("profilingFuncs", config.CompileOptions.profilingFuncs);
            this.setData("profilingMemory", config.CompileOptions.ProfilingMemory);
            this.setData("deleteStreamingAssets", config.CompileOptions.DeleteStreamingAssets);
            this.setData("cleanBuild", config.CompileOptions.CleanBuild);
            this.setData("customNodePath", config.CompileOptions.CustomNodePath);
            this.setData("webgl2", config.CompileOptions.Webgl2);
            this.setData("fbslim", config.CompileOptions.fbslim);
            this.setData("useFriendRelation", config.SDKOptions.UseFriendRelation);
            this.setData("useMiniGameChat", config.SDKOptions.UseMiniGameChat);
            this.setData("preloadWXFont", config.SDKOptions.PreloadWXFont);
            this.setData("bgImageSrc", config.ProjectConf.bgImageSrc);
            tex = AssetDatabase.LoadAssetAtPath<Texture>(config.ProjectConf.bgImageSrc);
            this.setData("memorySize", config.ProjectConf.MemorySize.ToString());
            this.setData("hideAfterCallMain", config.ProjectConf.HideAfterCallMain);

            this.setData("dataFileSubPrefix", config.ProjectConf.dataFileSubPrefix);
            this.setData("maxStorage", config.ProjectConf.maxStorage.ToString());
            this.setData("defaultReleaseSize", config.ProjectConf.defaultReleaseSize.ToString());
            this.setData("texturesHashLength", config.ProjectConf.texturesHashLength.ToString());
            this.setData("texturesPath", config.ProjectConf.texturesPath);
            this.setData("needCacheTextures", config.ProjectConf.needCacheTextures);
            this.setData("loadingBarWidth", config.ProjectConf.loadingBarWidth.ToString());
            this.setData("needCheckUpdate", config.ProjectConf.needCheckUpdate);
            this.setData("disableHighPerformanceFallback", config.ProjectConf.disableHighPerformanceFallback);
            this.setData("showMonitorSuggestModal", config.CompileOptions.showMonitorSuggestModal);
            this.setData("enableProfileStats", config.CompileOptions.enableProfileStats);
            this.setData("enableRenderAnalysis", config.CompileOptions.enableRenderAnalysis);
            this.setData("autoUploadFirstBundle", true);
        }

        private void saveData()
        {
            config.ProjectConf.projectName = this.getDataInput("projectName");
            config.ProjectConf.Appid = this.getDataInput("appid");
            config.ProjectConf.CDN = this.getDataInput("cdn");
            config.ProjectConf.assetLoadType = this.getDataPop("assetLoadType");
            config.ProjectConf.compressDataPackage = this.getDataCheckbox("compressDataPackage");
            config.ProjectConf.VideoUrl = this.getDataInput("videoUrl");
            config.ProjectConf.Orientation = (WXScreenOritation)this.getDataPop("orientation");
            config.ProjectConf.DST = this.getDataInput("dst");
            config.ProjectConf.bundleHashLength = int.Parse(this.getDataInput("bundleHashLength"));
            config.ProjectConf.bundlePathIdentifier = this.getDataInput("bundlePathIdentifier");
            config.ProjectConf.bundleExcludeExtensions = this.getDataInput("bundleExcludeExtensions");
            config.ProjectConf.preloadFiles = this.getDataInput("preloadFiles");
            config.CompileOptions.DevelopBuild = this.getDataCheckbox("developBuild");
            config.CompileOptions.AutoProfile = this.getDataCheckbox("autoProfile");
            config.CompileOptions.ScriptOnly = this.getDataCheckbox("scriptOnly");
            config.CompileOptions.Il2CppOptimizeSize = this.getDataCheckbox("il2CppOptimizeSize");
            config.CompileOptions.profilingFuncs = this.getDataCheckbox("profilingFuncs");
            config.CompileOptions.ProfilingMemory = this.getDataCheckbox("profilingMemory");
            config.CompileOptions.DeleteStreamingAssets = this.getDataCheckbox("deleteStreamingAssets");
            config.CompileOptions.CleanBuild = this.getDataCheckbox("cleanBuild");
            config.CompileOptions.CustomNodePath = this.getDataInput("customNodePath");
            config.CompileOptions.Webgl2 = this.getDataCheckbox("webgl2");
            config.CompileOptions.fbslim = this.getDataCheckbox("fbslim");
            config.SDKOptions.UseFriendRelation = this.getDataCheckbox("useFriendRelation");
            config.SDKOptions.UseMiniGameChat = this.getDataCheckbox("useMiniGameChat");
            config.SDKOptions.PreloadWXFont = this.getDataCheckbox("preloadWXFont");
            config.ProjectConf.bgImageSrc = this.getDataInput("bgImageSrc");
            config.ProjectConf.MemorySize = int.Parse(this.getDataInput("memorySize"));
            config.ProjectConf.HideAfterCallMain = this.getDataCheckbox("hideAfterCallMain");
            config.ProjectConf.dataFileSubPrefix = this.getDataInput("dataFileSubPrefix");
            config.ProjectConf.maxStorage = int.Parse(this.getDataInput("maxStorage"));
            config.ProjectConf.defaultReleaseSize = int.Parse(this.getDataInput("defaultReleaseSize"));
            config.ProjectConf.texturesHashLength = int.Parse(this.getDataInput("texturesHashLength"));
            config.ProjectConf.texturesPath = this.getDataInput("texturesPath");
            config.ProjectConf.needCacheTextures = this.getDataCheckbox("needCacheTextures");
            config.ProjectConf.loadingBarWidth = int.Parse(this.getDataInput("loadingBarWidth"));
            config.ProjectConf.needCheckUpdate = this.getDataCheckbox("needCheckUpdate");
            config.ProjectConf.disableHighPerformanceFallback = this.getDataCheckbox("disableHighPerformanceFallback");
            config.CompileOptions.showMonitorSuggestModal = this.getDataCheckbox("showMonitorSuggestModal");
            config.CompileOptions.enableProfileStats = this.getDataCheckbox("enableProfileStats");
            config.CompileOptions.enableRenderAnalysis = this.getDataCheckbox("enableRenderAnalysis");
        }

        private string getDataInput(string target)
        {
            if (this.formInputData.ContainsKey(target))
                return this.formInputData[target];
            return "";
        }
        private int getDataPop(string target)
        {
            if (this.formIntPopupData.ContainsKey(target))
                return this.formIntPopupData[target];
            return 0;
        }
        private bool getDataCheckbox(string target)
        {
            if (this.formCheckboxData.ContainsKey(target))
                return this.formCheckboxData[target];
            return false;
        }

        private void setData(string target, string value)
        {
            if (formInputData.ContainsKey(target))
            {
                formInputData[target] = value;
            }
            else
            {
                formInputData.Add(target, value);
            }
        }
        private void setData(string target, bool value)
        {
            if (formCheckboxData.ContainsKey(target))
            {
                formCheckboxData[target] = value;
            }
            else
            {
                formCheckboxData.Add(target, value);
            }
        }
        private void setData(string target, int value)
        {
            if (formIntPopupData.ContainsKey(target))
            {
                formIntPopupData[target] = value;
            }
            else
            {
                formIntPopupData.Add(target, value);
            }
        }
        private void formInput(string target, string label, string help = null)
        {
            if (!formInputData.ContainsKey(target))
            {
                formInputData[target] = "";
            }
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Empty, GUILayout.Width(10));
            if (help == null)
            {
                GUILayout.Label(label, GUILayout.Width(140));
            }
            else
            {
                GUILayout.Label(new GUIContent(label, help), GUILayout.Width(140));
            }
            formInputData[target] = GUILayout.TextField(formInputData[target], GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 195));
            GUILayout.EndHorizontal();
        }

        private void formIntPopup(string target, string label, string[] options, int[] values)
        {
            if (!formIntPopupData.ContainsKey(target))
            {
                formIntPopupData[target] = 0;
            }
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Empty, GUILayout.Width(10));
            GUILayout.Label(label, GUILayout.Width(140));
            formIntPopupData[target] = EditorGUILayout.IntPopup(formIntPopupData[target], options, values, GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 195));
            GUILayout.EndHorizontal();
        }

        private void formCheckbox(string target, string label, string help = null, bool disable = false, Action<bool> setting = null)
        {
            if (!formCheckboxData.ContainsKey(target))
            {
                formCheckboxData[target] = false;
            }
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Empty, GUILayout.Width(10));
            if (help == null)
            {
                GUILayout.Label(label, GUILayout.Width(140));
            }
            else
            {
                GUILayout.Label(new GUIContent(label, help), GUILayout.Width(140));
            }
            EditorGUI.BeginDisabledGroup(disable);
            formCheckboxData[target] = EditorGUILayout.Toggle(formCheckboxData[target]);

            if (setting != null)
            {
                EditorGUILayout.LabelField("", GUILayout.Width(10));
                // 配置按钮
                if (GUILayout.Button(new GUIContent("设置"), GUILayout.Width(40), GUILayout.Height(18)))
                {
                    setting?.Invoke(true);
                }
                EditorGUILayout.LabelField("", GUILayout.MinWidth(10));
            }

            EditorGUI.EndDisabledGroup();

            EditorGUILayout.LabelField(string.Empty);
            GUILayout.EndHorizontal();
        }

    }
}