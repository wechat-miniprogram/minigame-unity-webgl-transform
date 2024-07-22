using UnityEngine;
using UnityEditor;
using static WeChatWASM.WXConvertCore;

namespace WeChatWASM
{

    public class WXEditorWin : EditorWindow
    {
        [MenuItem("微信小游戏 / 转换小游戏", false, 1)]
        public static void Open()
        {
            var win = GetWindow(typeof(WXEditorWin), false, "微信小游戏转换工具面板");
            win.minSize = new Vector2(350, 400);
            win.position = new Rect(100, 100, 600, 700);
            win.Show();
        }

        // 向前兼容，请使用 WXConvertCore.cs
        public static WXExportError DoExport(bool buildWebGL = true)
        {
            return WXConvertCore.DoExport(buildWebGL);
        }

        public void OnFocus()
        {
            WXSettingsHelperInterface.helper.OnFocus();
        }

        public void OnLostFocus()
        {
            WXSettingsHelperInterface.helper.OnLostFocus();
        }

        public void OnDisable()
        {
            WXSettingsHelperInterface.helper.OnDisable();
        }

        public void OnGUI()
        {
            WXSettingsHelperInterface.helper.OnSettingsGUI(this);
            WXSettingsHelperInterface.helper.OnBuildButtonGUI(this);
        }
    }
}