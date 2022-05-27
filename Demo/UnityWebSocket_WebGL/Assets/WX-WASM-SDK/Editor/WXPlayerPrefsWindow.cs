using UnityEngine;
using UnityEditor;

namespace WeChatWASM
{
    public class WXPlayerPrefsWindow : EditorWindow
    {

        public WXEditorScriptObject config;
        public string tempKey = "";


        
        [MenuItem("微信小游戏 / PlayerPrefs优化 / 配置KeyName")]
        public static void Open()
        {

            var win = GetWindow(typeof(WXPlayerPrefsWindow), false, "配置PlayerPrefs用到的KeyName", true);//创建窗口
            win.minSize = new Vector2(700, 300);
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

            GUILayout.Label("设置PlayerPrefs用到的KeyName，能加快第一次的查询速度", labelStyle);

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


            tempKey = EditorGUILayout.TextField("KeyName", tempKey, inputStyle);


            EditorGUILayout.Space();
            EditorGUILayout.Space();

            var clickAdd = GUILayout.Button("添加", pathButtonStyle, GUILayout.Height(30), GUILayout.Width(200));

            if (clickAdd)
            {

                if (string.IsNullOrEmpty(tempKey))
                {
                    Debug.LogError("Key不能为空！");
                    return;
                }
                if (config.PlayerPrefsKeys.Contains(tempKey)) {
                    Debug.LogError("目录已经添加！");
                    return;
                }

                config.PlayerPrefsKeys.Add(tempKey);
                OnLostFocus();
                tempKey = "";
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            GUILayout.Label("已添加Key:", labelStyle);

            if (config.PlayerPrefsKeys != null && config.PlayerPrefsKeys.Count > 0)
            {
                for (int i = 0; i < config.PlayerPrefsKeys.Count; i++)
                {
                    string options = config.PlayerPrefsKeys[i];

                    GUILayout.BeginHorizontal();
                    // 路径框
                    GUILayout.Label(options, pathLabelStyle, GUILayout.Height(pathButtonHeight - 6), GUILayout.ExpandWidth(true), GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth - 190));

                    var isDelete = GUILayout.Button("删除", GUILayout.Height(pathButtonHeight), GUILayout.Width(40));
                    if (isDelete)
                    {
                        config.PlayerPrefsKeys.Remove(options);
                        OnLostFocus();
                    }
                    GUILayout.EndHorizontal();
                }

            }




        }



    }
}
