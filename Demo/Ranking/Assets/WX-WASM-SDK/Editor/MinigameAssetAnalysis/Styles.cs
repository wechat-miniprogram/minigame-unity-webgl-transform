using UnityEngine;

namespace WeChatWASM.Analysis
{
    internal static class Styles
    {
        public static readonly GUIStyle entryEven = "OL EntryBackEven";

        public static readonly GUIStyle entryOdd = "OL EntryBackOdd";

        public static readonly string focusHelper = "SerializedPropertyTreeViewFocusHelper";

        public static readonly string serializeFilterSelection = "_FilterSelection";

        public static readonly string serializeFilterDisable = "_FilterDisable";

        public static readonly string serializeFilterInvert = "_FilterInvert";

        public static readonly string serializeTreeViewState = "_TreeViewState";

        public static readonly string serializeColumnHeaderState = "_ColumnHeaderState";

        public static readonly string serializeFilter = "_Filter_";

        public static readonly GUIContent filterSelection =
            new GUIContent("Lock Selection|Limits the table contents to the active selection.");
        //EditorGUIUtility.TextContent("Lock Selection|Limits the table contents to the active selection.");

        public static readonly GUIContent filterDisable = new GUIContent("Disable All|Disables all filters.");
        //EditorGUIUtility.TextContent("Disable All|Disables all filters.");

        public static readonly GUIContent filterInvert =
            new GUIContent("Invert Result|Inverts the filtered results.");

        public static readonly GUIStyle searchField = "SearchTextField";

        public static readonly GUIStyle searchFieldCancelButton = "SearchCancelButton";

        public static readonly GUIStyle searchFieldCancelButtonEmpty = "SearchCancelButtonEmpty";
        //EditorGUIUtility.TextContent("Invert Result|Inverts the filtered results.");
    }
}