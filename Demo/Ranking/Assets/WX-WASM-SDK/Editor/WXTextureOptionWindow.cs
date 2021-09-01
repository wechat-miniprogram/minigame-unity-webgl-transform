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
            config.CompressTexture.LazyLoadNotPot = GUILayout.Toggle(config.CompressTexture.LazyLoadNotPot, "懒加载非POT图片", toggleStyle);
            EditorGUILayout.Space();

            config.CompressTexture.OnlyAstc = GUILayout.Toggle(config.CompressTexture.OnlyAstc, "只生成ASTC纹理  （该设置只是方便快速生成纹理验证，还需手动点击”根据ASTC生成ETC2纹理”，切记）", toggleStyle);
            EditorGUILayout.Space();

#if UNITY_EDITOR_OSX
            config.CompressTexture.TooManyFiles = GUILayout.Toggle(config.CompressTexture.TooManyFiles, "单独用NodeJS生成纹理 (Mac上Unity工程太大时使用压缩纹理，容易遇到 Too Many Files错误，可勾选本选项\r\n替换后再进入，WX-WASM-SDK/Editor/Node 目录用命令行，执行 ’node compressor.js‘ 来命令生成纹理)", toggleStyle);
            EditorGUILayout.Space();
#endif


        }



    }
}
