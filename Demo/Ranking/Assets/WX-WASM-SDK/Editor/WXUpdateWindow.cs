using UnityEngine;
using UnityEditor;
using System.Net;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WeChatWASM
{
    public class UpdateManager {
        public static string checkUrl = "https://res.wx.qq.com/wechatgame/product/webpack/userupload/wasm_plugin/pluginversion.json";

        public static string downloadUrl = "";
        public static bool CheckUpdte()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(checkUrl + "?time=" + DateTime.Now.ToString("MMddHHmmss"));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 20000;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();
            httpWebResponse.Close();
            streamReader.Close();

            var pluginConf = JsonUtility.FromJson<WXPluginConf>(responseContent);


            long.TryParse(pluginConf.version, out long onlineVersion);
            long.TryParse(WXPluginVersion.pluginVersion, out long nowVersion);

            if (onlineVersion > nowVersion)
            {
                downloadUrl = pluginConf.filePath;
                OpenDownloadUrl();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void OpenDownloadUrl()
        {
            Selection.activeObject = AssetDatabase.LoadAssetAtPath("Assets/WX-WASM-SDK/CHANGELOG.md", typeof(UnityEngine.Object));
            if (EditorUtility.DisplayDialog("微信小游戏插件更新提示", "插件有更新\n是否立即更新", "是", "否"))
            {
                Application.OpenURL(downloadUrl);
            } else
            {
                Debug.Log("有更新版本插件，请及时更新：<a href=\"" + downloadUrl + "\">" + downloadUrl + "</a>");
            }
        }
    }
    public class WXUpdateWindow : EditorWindow
    {
        [MenuItem("微信小游戏 / 插件管理")]
        public static void Open()
        {

            var win = GetWindow(typeof(WXUpdateWindow), false, "微信小游戏转换插件管理", true);//创建窗口
            win.minSize = new Vector2(400, 250);
            win.maxSize = new Vector2(400, 250);
            win.Show();

        }

        private void OnGUI()
        {

            var labelStyle = new GUIStyle(EditorStyles.boldLabel);
            labelStyle.fontSize = 16;

            labelStyle.margin.left = (int)(EditorGUIUtility.currentViewWidth / 2 - 100);
            labelStyle.margin.top = 50;
            labelStyle.margin.bottom = 10;

            GUILayout.Label("当前版本：" + WXPluginVersion.pluginVersion, labelStyle);


            GUIStyle exportButtonStyle = new GUIStyle(GUI.skin.button);
            exportButtonStyle.fontSize = 14;
            exportButtonStyle.margin.left = 20;
            exportButtonStyle.margin.top = 40;
            var isCheckBtnPressed = GUILayout.Button("检查更新", exportButtonStyle, GUILayout.Height(40), GUILayout.Width(EditorGUIUtility.currentViewWidth - 40));

            if (isCheckBtnPressed)
            {
                if (UpdateManager.CheckUpdte())
                {
                    ShowNotification(new GUIContent("有新版可以下载，请尽快更新！"));
                }
                else
                {
                    ShowNotification(new GUIContent("当前已是最新！"));
                }
            }

            var openChangeLog = GUILayout.Button("更新日志", exportButtonStyle, GUILayout.Height(40), GUILayout.Width(EditorGUIUtility.currentViewWidth - 40));
            if (openChangeLog)
            {
                Selection.activeObject = AssetDatabase.LoadAssetAtPath("Assets/WX-WASM-SDK/CHANGELOG.md", typeof(UnityEngine.Object));
            }
        }
    }
}
