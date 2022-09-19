using UnityEngine;
using UnityEditor;
using System;

namespace WeChatWASM.Analysis
{
    public class AnalysisWindow : EditorWindow
    {
        public int AssetsTypeSelected;
        public string[] AssetsTypeOptions = new string[] { "Texture", "Font", "Audio", "Prefab" };

        public TextureWindow TextureWindow;
        public FontWindow FontWindow;
        public AudioWindow AudioWindow;
        public PrefabWindow PrefabWindow;

        static private EditorWindow win;

        [MenuItem("微信小游戏 / 资源优化工具")]
        static void ShowTextureWindow()
        {
            //EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
            win = AnalysisWindow.GetCurrentWindow();
            win.minSize = new Vector2(1600, 800);
            win.Show();
        }

        public static EditorWindow GetCurrentWindow()
        {
            return GetWindow(typeof(AnalysisWindow), false, "Optimize", true);
        }

        private void OnEnable()
        {
            this.TextureWindow = TextureWindow.GetInstance();
            this.FontWindow = FontWindow.GetInstance();
            this.AudioWindow = AudioWindow.GetInstance();
            this.PrefabWindow = PrefabWindow.GetInstance();
        }

        private void OnDisable()
        {
            this.TextureWindow = null;
            this.FontWindow = null;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
            GUILayout.FlexibleSpace();
            GUILayoutOption[] options = new GUILayoutOption[] { GUILayout.Height(25f) };
            this.AssetsTypeSelected = GUILayout.Toolbar(this.AssetsTypeSelected, this.AssetsTypeOptions, "LargeButton", GUI.ToolbarButtonSize.FitToContents, options);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            switch (this.AssetsTypeSelected)
            {
                case 0:
                    this.TextureWindow.Show();
                    break;
                case 1:
                    this.FontWindow.Show();
                    break;
                case 2:
                    this.AudioWindow.Show();
                    break;
                case 3:
                    this.PrefabWindow.Show();
                    break;
                default:
                    break;
            }
        }
    }
}