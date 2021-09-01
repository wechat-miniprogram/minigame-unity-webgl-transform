using UnityEngine;
using UnityEditor;

namespace WeChatWASM
{
    public class WXTextureQualityWindow : EditorWindow
    {

        public WXEditorScriptObject config;
        public int quality = 65;
        public string tempPath = "";

        [MenuItem("微信小游戏 / 包体瘦身--压缩纹理 / 设置压缩质量")]
        public static void Open()
        {

            var win = GetWindow(typeof(WXTextureQualityWindow), false, "设置压缩纹理压缩质量", true);//创建窗口
            win.minSize = new Vector2(500, 300);
            //win.maxSize = new Vector2(400, 200);
            win.Show();

        }

        public void LoadData()
        {

            config = AssetDatabase.LoadAssetAtPath("Assets/WX-WASM-SDK/Editor/MiniGameConfig.asset", typeof(WXEditorScriptObject)) as WXEditorScriptObject;

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

            GUILayout.Label("设置压缩质量匹配规则", labelStyle);

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


            quality = EditorGUILayout.IntField("压缩质量", quality, inputStyle, GUILayout.Height(30));

            if (string.IsNullOrEmpty(tempPath))
            {

                var clickChoosePath = GUILayout.Button("选择匹配目录路径", pathButtonStyle, GUILayout.Height(30), GUILayout.Width(200));
                if (clickChoosePath)
                {
                    // 弹出选目录窗口
                    var dstPath = EditorUtility.SaveFolderPanel("选择匹配目录路径", "", "");

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
                if (quality > 100 || quality <= 0)
                {
                    Debug.LogError("图片质量为1至100");
                    return;
                }
                if (string.IsNullOrEmpty(tempPath))
                {
                    Debug.LogError("目录不能为空！");
                    return;
                }

                config.CompressTexture.QualityList.Add(new QualityOptions()
                {
                    Path = tempPath,
                    Quality = quality
                });
                OnLostFocus();
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUILayout.Label("已配置匹配规则:", labelStyle);

            if (config.CompressTexture.QualityList != null && config.CompressTexture.QualityList.Count > 0)
            {
                for (int i = 0; i < config.CompressTexture.QualityList.Count; i++)
                {
                    QualityOptions options = config.CompressTexture.QualityList[i];

                    GUILayout.BeginHorizontal();
                    // 路径框
                    GUILayout.Label(options.Path, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 190));

                    GUILayout.Label("压缩率：" + options.Quality.ToString() + "%", pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.Width(80));
                    var isDelete = GUILayout.Button("删除", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                    if (isDelete)
                    {
                        config.CompressTexture.QualityList.Remove(options);
                        OnLostFocus();
                    }
                    GUILayout.EndHorizontal();
                }

            }




        }



    }
}
