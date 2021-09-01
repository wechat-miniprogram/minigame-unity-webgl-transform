using UnityEngine;
using UnityEditor;

namespace WeChatWASM
{
    public class WXTextureDirWindow : EditorWindow
    {

        public WXEditorScriptObject config;
        public string tempPath = "";

        [MenuItem("微信小游戏 / 包体瘦身--压缩纹理 / 设置替换纹理目录")]
        public static void Open()
        {

            var win = GetWindow(typeof(WXTextureDirWindow), false, "设置替换纹理目录", true);//创建窗口
            win.minSize = new Vector2(750, 300);
            //win.maxSize = new Vector2(400, 200);
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
            labelStyle.fontSize = 14;

            labelStyle.margin.left = 20;
            labelStyle.margin.top = 10;
            labelStyle.margin.bottom = 10;

            GUILayout.Label("设置压缩纹理目录能减少不必要的纹理压缩，注意不在压缩纹理目录下的纹理不能设置为DXT1或DXT5，切记。", labelStyle);

            GUIStyle pathButtonStyle = new GUIStyle(GUI.skin.button);
            pathButtonStyle.fontSize = 12;
            pathButtonStyle.margin.left = 20;

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


            int pathButtonHeight = 28;
            GUIStyle pathLabelStyle = new GUIStyle(GUI.skin.textField);

            pathLabelStyle.fontSize = 12;
            pathLabelStyle.alignment = TextAnchor.MiddleLeft;
            pathLabelStyle.margin.top = 6;
            pathLabelStyle.margin.bottom = 6;
            pathLabelStyle.margin.left = 20;

            if (string.IsNullOrEmpty(tempPath))
            {

                var clickChoosePath = GUILayout.Button("选择匹配目录路径", pathButtonStyle, GUILayout.Height(30), GUILayout.Width(200));
                if (clickChoosePath)
                {
                    // 弹出选目录窗口
                    var dstPath = EditorUtility.SaveFolderPanel("选择匹配目录路径", "", "");
                    if (dstPath.IndexOf(Application.dataPath)!=0)
                    {
                        Debug.LogError("需选择Assets目录里的文件夹");
                        return;
                    }
                    dstPath = "Assets/"+dstPath.Substring(Application.dataPath.Length+1).Replace("\\", "/");

                    if (!string.IsNullOrEmpty(dstPath))
                    {
                        tempPath = dstPath;
                        OnLostFocus();
                    }
                }
            }
            else
            {



                GUILayout.BeginHorizontal();
                // 路径框
                GUILayout.Label(tempPath, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 126));
                var resetButtonClicked = GUILayout.Button("重选", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                GUILayout.EndHorizontal();
                if (resetButtonClicked)
                {
                    tempPath = "";
                }

            }


            EditorGUILayout.Space();
            EditorGUILayout.Space();

            var clickAdd = GUILayout.Button("添加", pathButtonStyle, GUILayout.Height(30), GUILayout.Width(200));

            if (clickAdd)
            {

                if (string.IsNullOrEmpty(tempPath))
                {
                    Debug.LogError("目录不能为空！");
                    return;
                }
                if (config.CompressTexture.SourceDirs.Contains(tempPath)) {
                    Debug.LogError("目录已经添加！");
                    return;
                }

                config.CompressTexture.SourceDirs.Add(tempPath);
                OnLostFocus();
                tempPath = "";
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUILayout.Label("已配置匹配规则:", labelStyle);

            if (config.CompressTexture.SourceDirs != null && config.CompressTexture.SourceDirs.Count > 0)
            {
                for (int i = 0; i < config.CompressTexture.SourceDirs.Count; i++)
                {
                    string options = config.CompressTexture.SourceDirs[i];

                    GUILayout.BeginHorizontal();
                    // 路径框
                    GUILayout.Label(options, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 190));

                    var isDelete = GUILayout.Button("删除", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                    if (isDelete)
                    {
                        config.CompressTexture.SourceDirs.Remove(options);
                        OnLostFocus();
                    }
                    GUILayout.EndHorizontal();
                }

            }




        }



    }
}
