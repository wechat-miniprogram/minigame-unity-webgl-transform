using UnityEngine;
using UnityEditor;

namespace WeChatWASM
{
    public class WXTextureOptionWindow : EditorWindow
    {

        public WXEditorScriptObject config;


        [MenuItem("微信小游戏 / 包体瘦身--压缩纹理 / 更多设置")]
        public static void Open()
        {

            var win = GetWindow(typeof(WXTextureOptionWindow), false, "更多设置", true);//创建窗口
            win.minSize = new Vector2(750, 300);
            win.Show();

        }

        public void LoadData()
        {

            config = UnityUtil.GetEditorConf();

        }

        public void OnEnable()
        {
            LoadData();
        }

        private void OnFocus()
        {
            LoadData();
        }


        private void OnLostFocus()
        {

            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();

        }


        private void OnGUI()
        {
            var labelStyle = new GUIStyle(EditorStyles.boldLabel);
            labelStyle.fontSize = 16;

            labelStyle.margin.left = 20;
            labelStyle.margin.top = 10;
            labelStyle.margin.bottom = 10;

            EditorGUILayout.Space();

            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.margin.left = 20;
            toggleStyle.margin.right = 20;
            toggleStyle.fontSize = 14;

            GUILayout.Label("更多设置", labelStyle);
            EditorGUILayout.Space();

            var choosePathButtonClicked = false;
            var openTargetButtonClicked = false;
            var resetButtonClicked = false;

            GUILayout.Label("自定义纹理导出路径", labelStyle);
            if (config.CompressTexture.DstDir == "")
            {
                GUIStyle pathButtonStyle = new GUIStyle(GUI.skin.button);
                pathButtonStyle.fontSize = 12;
                pathButtonStyle.margin.left = 20;

                choosePathButtonClicked = GUILayout.Button("选择纹理导出路径", pathButtonStyle, GUILayout.Height(30), GUILayout.Width(200));
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
                GUILayout.Label(config.CompressTexture.DstDir, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 126));
                openTargetButtonClicked = GUILayout.Button("打开", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                resetButtonClicked = GUILayout.Button("重选", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                GUILayout.EndHorizontal();
            }
            EditorGUILayout.Space();

            config.CompressTexture.LazyLoadNotPot = GUILayout.Toggle(config.CompressTexture.LazyLoadNotPot, "懒加载非POT图片", toggleStyle);
            EditorGUILayout.Space();

            config.CompressTexture.OnlyAstc = GUILayout.Toggle(config.CompressTexture.OnlyAstc, "只生成ASTC纹理  （该设置只是方便快速生成纹理验证，还需手动点击”根据ASTC生成ETC2纹理”，切记）", toggleStyle);
            EditorGUILayout.Space();


            config.CompressTexture.TooManyFiles = GUILayout.Toggle(config.CompressTexture.TooManyFiles, "单独用NodeJS生成纹理 (Mac上Unity工程太大时使用压缩纹理，容易遇到 Too Many Files错误，可勾选本选项\r\n替换后再进入，WX-WASM-SDK/Editor/Node 目录用命令行，执行 ’node compress_all.js‘, \r\n或者 ’node compress_astc_only.js‘ 来命令生成纹理，其中compress_astc_only.js 为只生成astc方便开发阶段验证，\r\ncompress_all.js 为全部纹理，适合正式上线前使用)", toggleStyle);
            EditorGUILayout.Space();


            if (choosePathButtonClicked)
            {
                // 弹出选目录窗口
                var dstPath = EditorUtility.SaveFolderPanel("选择你的纹理导出目录", "", "");

                if (dstPath != "")
                {
                    config.CompressTexture.DstDir = dstPath;
                    OnLostFocus();
                }


            }

            if (openTargetButtonClicked)
            {
                UnityUtil.ShowInExplorer(config.CompressTexture.DstDir);
            }
            if (resetButtonClicked)
            {
                config.CompressTexture.DstDir = "";
            }

        }



    }
}
