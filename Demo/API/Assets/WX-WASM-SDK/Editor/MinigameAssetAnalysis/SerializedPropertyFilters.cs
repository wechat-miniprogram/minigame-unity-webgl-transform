using System;
using UnityEditor;
using UnityEngine;

namespace WeChatWASM.Analysis
{
    internal class SerializedPropertyFilters
    {
        internal interface IFilter
        {
            bool Active();

            bool Filter(SerializedProperty prop);

            void OnGUI(Rect r);

            string SerializeState();

            void DeserializeState(string state);
        }

        internal abstract class SerializableFilter : SerializedPropertyFilters.IFilter
        {
            public abstract bool Active();

            public abstract bool Filter(SerializedProperty prop);

            public abstract void OnGUI(Rect r);

            public string SerializeState()
            {
                return JsonUtility.ToJson(this);
            }

            public void DeserializeState(string state)
            {
                JsonUtility.FromJsonOverwrite(state, this);
            }
        }

        internal class String : SerializedPropertyFilters.SerializableFilter
        {
            private static class Styles
            {
                public static readonly GUIStyle searchField = "SearchTextField";

                public static readonly GUIStyle searchFieldCancelButton = "SearchCancelButton";

                public static readonly GUIStyle searchFieldCancelButtonEmpty = "SearchCancelButtonEmpty";
            }

            [SerializeField]
            protected string m_Text = "";

            public override bool Active()
            {
                return !string.IsNullOrEmpty(this.m_Text);
            }

            public override bool Filter(SerializedProperty prop)
            {
                return prop.stringValue.IndexOf(this.m_Text, 0, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            public override void OnGUI(Rect r)
            {
                r.width -= 15f;
                this.m_Text = EditorGUI.TextField(r, GUIContent.none, this.m_Text, SerializedPropertyFilters.String.Styles.searchField);
                r.x += r.width;
                r.width = 15f;
                bool flag = this.m_Text != "";
                if (GUI.Button(r, GUIContent.none, (!flag) ? SerializedPropertyFilters.String.Styles.searchFieldCancelButtonEmpty : SerializedPropertyFilters.String.Styles.searchFieldCancelButton) && flag)
                {
                    this.m_Text = "";
                    GUIUtility.keyboardControl = 0;
                }
            }
        }

        internal sealed class Name : SerializedPropertyFilters.String
        {
            public bool Filter(string str)
            {
                return str.IndexOf(this.m_Text, 0, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        internal sealed class None : SerializedPropertyFilters.IFilter
        {
            public bool Active()
            {
                return false;
            }

            public bool Filter(SerializedProperty prop)
            {
                return true;
            }

            public void OnGUI(Rect r)
            {
            }

            public string SerializeState()
            {
                return null;
            }

            public void DeserializeState(string state)
            {
            }
        }

        internal static readonly SerializedPropertyFilters.None s_FilterNone = new SerializedPropertyFilters.None();
    }
}