using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace WeChatWASM.Analysis
{
    public abstract class CommonTable
    {
        public abstract void OnGUI();
    }

    public class CommonTable<T> : CommonTable where T : class
    {
        private const float DragHeight = 20f;

        private const float DragWidth = 5f;

        private readonly float m_FilterHeight = 20f;

        private bool m_initialized;

        private CommonTreeView<T> m_treeView;

        private TreeViewState m_treeViewState;

        private readonly List<T> m_datas;
        private readonly FilterMethod<T> m_filter;
        private readonly SelectMethod<T> m_select;
        private readonly Action<Boolean> m_toggleSelectAll;

        protected MultiColumnHeaderState MultiColumnHeaderState { get; private set; }

        public CommonTable(List<T> datas, CommonTableColumn<T>[] cs, FilterMethod<T> onfilter, SelectMethod<T> onselect = null, Action<Boolean> toggleSelectAll = null)
        {
            var state = new MultiColumnHeaderState(cs);
            MultiColumnHeaderState = state;
            m_filter = onfilter;
            m_datas = datas;
            m_select = onselect;
            m_toggleSelectAll = toggleSelectAll;
        }

        private void InitIfNeeded()
        {
            if (!m_initialized)
            {
                if (m_treeViewState == null)
                    m_treeViewState = new TreeViewState();
                var multiColumnHeader = new MultiColumnHeader(MultiColumnHeaderState);
                m_treeView = new CommonTreeView<T>(m_treeViewState, multiColumnHeader, m_datas, m_filter, m_select, m_toggleSelectAll);
                m_treeView.Reload();
                m_initialized = true;
            }
        }

        public void SelectAll()
        {
            if (m_treeView != null)
            {
                m_treeView.SelectAllRows();
            }
        }

        public override void OnGUI()
        {

            InitIfNeeded();

            var rect = GUILayoutUtility.GetRect(0f, Screen.width, 0f, Screen.height);
            if (Event.current.type == EventType.Layout)
                return;
            rect.x += DragWidth;
            rect.width -= DragWidth;

            rect.y += DragHeight;

            var r = rect;
            rect.y += m_FilterHeight;
            rect.height = rect.height - m_FilterHeight - DragHeight * 2;

            var rect2 = rect;
            m_treeView.OnCheckAllGUI();
            m_treeView.OnGUI(rect2);
            //DrawExportButton(r);
            m_treeView.OnFilterGUI(r);
            //if (m_treeView.IsFilteredDirty())
            //    m_treeView.Reload();
        }

        //private void DrawExportButton(Rect rect)
        //{
        //    var br = rect;
        //    br.height = 20;
        //    br.width = 50;
        //    if (GUI.Button(br, "Export"))
        //    {
        //        var path = EditorUtility.SaveFilePanel("file", Application.dataPath, "data", "xml");
        //        if (!string.IsNullOrEmpty(path))
        //            Serializer.SaveAsXml(m_datas, path);
        //    }
        //}
    }

    public delegate void DrawCellMethod<in T>(Rect cellRect, T item);

    public delegate bool FilterMethod<in T>(T data, string std);

    public delegate int CompareMethod<in T>(T data1, T data2);

    public delegate void SelectMethod<T>(List<T> datas);

    public class StringFilter
    {
        public static bool Contains(string req, string std)
        {
            if (req == null || std == null)
                return false;
            return req.IndexOf(std, 0, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}