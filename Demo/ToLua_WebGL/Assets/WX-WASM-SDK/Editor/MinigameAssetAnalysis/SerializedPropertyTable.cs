using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Profiling;

namespace WeChatWASM.Analysis
{
    internal class SerializedPropertyTable
    {
        private readonly float m_DragHeight = 20f;

        private readonly float m_DragWidth = 32f;

        private readonly float m_FilterHeight = 20f;

        private float m_ColumnHeaderHeight;

        private SerializedPropertyDataStore m_DataStore;

        private readonly SerializedPropertyDataStore.GatherDelegate m_GatherDelegate;

        private readonly HeaderDelegate m_HeaderDelegate;

        private bool m_Initialized;

        private MultiColumnHeaderState m_MultiColumnHeaderState;

        private readonly string m_SerializationUID;

        //private float m_TableHeight = 200f;

        private SerializedPropertyTreeView m_TreeView;

        private TreeViewState m_TreeViewState;

        public SerializedPropertyTable(string serializationUID, SerializedPropertyDataStore.GatherDelegate gatherDelegate, HeaderDelegate headerDelegate)
        {
            //dragHandleEnabled = true;
            m_SerializationUID = serializationUID;
            m_GatherDelegate = gatherDelegate;
            m_HeaderDelegate = headerDelegate;
            //OnEnable();
        }

        //public bool dragHandleEnabled { get; set; }

        private void InitIfNeeded()
        {
            if (!m_Initialized)
            {
                if (m_TreeViewState == null)
                    m_TreeViewState = new TreeViewState();
                if (m_MultiColumnHeaderState == null)
                {
                    string[] propNames;
                    m_MultiColumnHeaderState = new MultiColumnHeaderState(m_HeaderDelegate(out propNames));
                    m_DataStore = new SerializedPropertyDataStore(propNames, m_GatherDelegate);
                }
                var multiColumnHeader = new MultiColumnHeader(m_MultiColumnHeaderState);
                m_ColumnHeaderHeight = multiColumnHeader.height;
                m_TreeView = new SerializedPropertyTreeView(m_TreeViewState, multiColumnHeader, m_DataStore);
                m_TreeView.DeserializeState(m_SerializationUID);
                m_TreeView.Reload();
                m_Initialized = true;
            }
        }

        private float GetMinHeight()
        {
            var singleLineHeight = EditorGUIUtility.singleLineHeight;
            var num = m_FilterHeight + m_ColumnHeaderHeight + singleLineHeight + m_DragHeight;
            return num + singleLineHeight * 3f;
        }

        public void OnInspectorUpdate()
        {
            if (m_DataStore != null && m_DataStore.Repopulate() && m_TreeView != null)
                m_TreeView.FullReload();
            else if (m_TreeView != null && m_TreeView.Update())
                m_TreeView.Repaint();
        }

        public void OnHierarchyChange()
        {
            if (m_DataStore != null && m_DataStore.Repopulate() && m_TreeView != null)
                m_TreeView.FullReload();
        }

        public void OnSelectionChange()
        {
            OnSelectionChange(Selection.instanceIDs);
        }

        public void OnSelectionChange(int[] instanceIDs)
        {
            if (m_TreeView != null)
                m_TreeView.SetSelection(instanceIDs);
        }

        public void OnGUI()
        {
            Profiler.BeginSample("SerializedPropertyTable.OnGUI");
            InitIfNeeded();
            var rect = GUILayoutUtility.GetRect(0f, Screen.width, 0f, Screen.height);
            if (Event.current.type != EventType.Layout)
            {
                rect.x += m_DragWidth;
                rect.width -= m_DragWidth * 2;

                rect.y += m_DragHeight;

                var r = rect;
                rect.y += m_FilterHeight;
                rect.height = rect.height - m_FilterHeight - m_DragHeight * 2;

                var rect2 = rect;
                Profiler.BeginSample("TreeView.OnGUI");
                m_TreeView.OnGUI(rect2);
                Profiler.EndSample();

                m_TreeView.OnFilterGUI(r);
                if (m_TreeView.IsFilteredDirty())
                    m_TreeView.Reload();
                Profiler.EndSample();
            }
        }

        public void OnDisable()
        {
            if (m_TreeView != null)
                m_TreeView.SerializeState(m_SerializationUID);
        }

        private static class Styles
        {
            public static readonly GUIStyle DragHandle = "RL DragHandle";
        }

        internal delegate SerializedPropertyTreeView.Column[] HeaderDelegate(out string[] propNames);
    }
}