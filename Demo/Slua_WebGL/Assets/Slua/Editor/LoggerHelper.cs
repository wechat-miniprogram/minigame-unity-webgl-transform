using System;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;

namespace SLua
{
    public static class LoggerHelper
    {
        static Regex rgx = new Regex(@"(\s|/)(?<File>\w+):(?<Line>\d+):", RegexOptions.IgnoreCase);
        static char[] LineEndings = new char[2] { '\n', '\r' };

        [UnityEditor.Callbacks.OnOpenAsset(0)]
        static bool OnOpenAsset(int instanceID, int line)
        {
            var instance = EditorUtility.InstanceIDToObject(instanceID) as MonoScript;
            if (instance == null || instance.GetClass() != typeof(SLua.Logger))
                return false;

            var stacktrace = GetStackTrace();
            if (string.IsNullOrEmpty(stacktrace))
                return false;

            string[] lines = stacktrace.Split(LineEndings, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 3; i < lines.Length; i++)
            {
                var match = rgx.Match(lines[i]);
                if (!match.Success)
                    continue;
                var filename = match.Groups["File"].Value;
                int linenumber = 0;
                int.TryParse(match.Groups["Line"].Value, out linenumber);

                string[] guids = AssetDatabase.FindAssets(filename);
                filename = filename + ".txt";
                for (int j = 0; j < guids.Length; j++)
                {
                    string path = AssetDatabase.GUIDToAssetPath(guids[j]);
                    if (System.IO.Path.GetFileName(path).Equals(filename))
                    {
                        UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(path, linenumber);
                        return true;
                    }
                }
            }
            return false;
        }

        static Type ConsoleWindowType = typeof(EditorWindow).Assembly.GetType("UnityEditor.ConsoleWindow");
        // static Type ListViewStateType = typeof(EditorWindow).Assembly.GetType("UnityEditor.ListViewState");
        static FieldInfo ConsoleWindowField = ConsoleWindowType.GetField("ms_ConsoleWindow", BindingFlags.Static | BindingFlags.NonPublic);
        // static FieldInfo ListViewField = ConsoleWindowType.GetField("m_ListView", BindingFlags.Instance | BindingFlags.NonPublic);
        // static FieldInfo RowField = ListViewStateType.GetField("row", BindingFlags.Instance | BindingFlags.Public);
        static FieldInfo ActiveTextField = ConsoleWindowType.GetField("m_ActiveText", BindingFlags.Instance | BindingFlags.NonPublic);
        static string GetStackTrace()
        {
            var instance = ConsoleWindowField.GetValue(null);
            if (instance == null)
                return null;

            // var listView = ListViewField.GetValue(instance);
            // int row = (int)RowField.GetValue(listView);
            return (string)ActiveTextField.GetValue(instance);
        }
    }
}