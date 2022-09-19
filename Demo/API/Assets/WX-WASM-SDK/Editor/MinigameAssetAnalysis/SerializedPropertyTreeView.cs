using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Profiling;
using Object = UnityEngine.Object;

namespace WeChatWASM.Analysis
{
    internal class SerializedPropertyTreeView : TreeView
    {
        private bool m_bFilterSelection;

        private int m_ChangedId;

        private readonly ColumnInternal[] m_ColumnsInternal;

        private readonly SerializedPropertyDataStore m_DataStore;

        private List<TreeViewItem> m_Items;

        private int[] m_SelectionFilter;

        public SerializedPropertyTreeView(TreeViewState state, MultiColumnHeader multicolumnHeader,
            SerializedPropertyDataStore dataStore)
            : base(state, multicolumnHeader)
        {
            m_DataStore = dataStore;
            var num = multiColumnHeader.state.columns.Length;
            m_ColumnsInternal = new ColumnInternal[num];
            for (var i = 0; i < num; i++)
            {
                var column = Col(i);
                if (column.propertyName != null)
                    m_ColumnsInternal[i].dependencyProps = new SerializedProperty[column.propertyName.Length];
            }
            multiColumnHeader.sortingChanged += OnSortingChanged;
            multiColumnHeader.visibleColumnsChanged += OnVisibleColumnChanged;
            showAlternatingRowBackgrounds = true;
            showBorder = true;
            rowHeight = EditorGUIUtility.singleLineHeight;
        }

        public void SerializeState(string uid)
        {
            SessionState.SetBool(uid + Styles.serializeFilterSelection,
                m_bFilterSelection);
            for (var i = 0; i < multiColumnHeader.state.columns.Length; i++)
            {
                var filter = Col(i).filter;
                if (filter != null)
                {
                    var value = filter.SerializeState();
                    if (!string.IsNullOrEmpty(value))
                        SessionState.SetString(uid + Styles.serializeFilter + i, value);
                }
            }
            SessionState.SetString(uid + Styles.serializeTreeViewState,
                JsonUtility.ToJson(state));
            SessionState.SetString(uid + Styles.serializeColumnHeaderState,
                JsonUtility.ToJson(multiColumnHeader.state));
        }

        public void DeserializeState(string uid)
        {
            m_bFilterSelection =
                SessionState.GetBool(uid + Styles.serializeFilterSelection, false);
            for (var i = 0; i < multiColumnHeader.state.columns.Length; i++)
            {
                var filter = Col(i).filter;
                if (filter != null)
                {
                    var @string = SessionState.GetString(uid + Styles.serializeFilter + i,
                        null);
                    if (!string.IsNullOrEmpty(@string))
                        filter.DeserializeState(@string);
                }
            }
            var string2 = SessionState.GetString(uid + Styles.serializeTreeViewState, "");
            var string3 = SessionState.GetString(uid + Styles.serializeColumnHeaderState,
                "");
            if (!string.IsNullOrEmpty(string2))
                JsonUtility.FromJsonOverwrite(string2, state);
            if (!string.IsNullOrEmpty(string3))
                JsonUtility.FromJsonOverwrite(string3, multiColumnHeader.state);
        }

        public bool IsFilteredDirty()
        {
            return m_ChangedId != 0 && (m_ChangedId != GUIUtility.keyboardControl ||
                                        !EditorGUIUtility.editingTextField);
        }

        public bool Update()
        {
            var rows = GetRows();
            int num;
            int num2;
            GetFirstAndLastVisibleRows(out num, out num2);
            var flag = false;
            if (num2 != -1)
                for (var i = num; i <= num2; i++)
                    flag = flag || ((SerializedPropertyItem)rows[i]).GetData().Update();
            return flag;
        }

        public void FullReload()
        {
            m_Items = null;
            Reload();
        }

        protected override TreeViewItem BuildRoot()
        {
            return new SerializedPropertyItem(-1, -1, null);
        }

        protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
        {
            if (m_Items == null)
            {
                var elements = m_DataStore.GetElements();
                m_Items = new List<TreeViewItem>(elements.Length);
                for (var i = 0; i < elements.Length; i++)
                {
                    var item2 = new SerializedPropertyItem(elements[i].ObjectId, 0, elements[i]);
                    m_Items.Add(item2);
                }
            }
            IEnumerable<TreeViewItem> enumerable = m_Items;
            if (m_bFilterSelection)
            {
                if (m_SelectionFilter == null)
                    m_SelectionFilter = Selection.instanceIDs;
                enumerable = from item in m_Items
                             where m_SelectionFilter.Contains(item.id)
                             select item;
            }
            else
            {
                m_SelectionFilter = null;
            }
            enumerable = Filter(enumerable);
            var list = enumerable.ToList();
            if (multiColumnHeader.sortedColumnIndex >= 0)
                Sort(list, multiColumnHeader.sortedColumnIndex);
            m_ChangedId = 0;
            //TreeViewUtility.SetParentAndChildrenForItems(list, root);
            return list;
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var item =
                (SerializedPropertyItem)args.item;
            for (var i = 0; i < args.GetNumVisibleColumns(); i++)
                CellGUI(args.GetCellRect(i), item, args.GetColumn(i), ref args);
        }

        private void CellGUI(Rect cellRect, SerializedPropertyItem item, int columnIndex,
            ref RowGUIArgs args)
        {
            Profiler.BeginSample("SerializedPropertyTreeView.CellGUI");
            CenterRectUsingSingleLineHeight(ref cellRect);
            var data = item.GetData();
            var column = (Column)multiColumnHeader.GetColumn(columnIndex);
            if (column.drawDelegate == DefaultDelegates.s_DrawName)
            {
                Profiler.BeginSample("SerializedPropertyTreeView.OnItemGUI.LabelField");
                DefaultGUI.Label(cellRect, data.Name, IsSelected(args.item.id), false);
                Profiler.EndSample();
            }
            else if (column.drawDelegate != null)
            {
                var properties = data.Properties;
                var num = column.dependencyIndices == null ? 0 : column.dependencyIndices.Length;
                for (var i = 0; i < num; i++)
                    m_ColumnsInternal[columnIndex].dependencyProps[i] = properties[column.dependencyIndices[i]];
                if (args.item.id == state.lastClickedID && HasFocus() && columnIndex == multiColumnHeader.state.visibleColumns[multiColumnHeader.state.visibleColumns[0] != 0 ? 0 : 1])
                    GUI.SetNextControlName(Styles.focusHelper);
                var serializedProperty = data.Properties[columnIndex];
                EditorGUI.BeginChangeCheck();
                Profiler.BeginSample("SerializedPropertyTreeView.OnItemGUI.drawDelegate");
                column.drawDelegate(cellRect, serializedProperty, m_ColumnsInternal[columnIndex].dependencyProps);
                Profiler.EndSample();
                if (EditorGUI.EndChangeCheck())
                {
                    m_ChangedId = column.filter == null || !column.filter.Active()
                        ? m_ChangedId
                        : GUIUtility.keyboardControl;
                    data.Store();
                    var selection = GetSelection();
                    if (selection.Contains(data.ObjectId))
                    {
                        var list = FindRows(selection);
                        Undo.RecordObjects((from r in list
                                            select ((SerializedPropertyItem)r).GetData()
                                            .SerializedObject.targetObject).ToArray(),
                            "Modify Multiple Properties");
                        foreach (var current in list)
                            if (current.id != args.item.id)
                            {
                                var data2 =
                                    ((SerializedPropertyItem)current).GetData();
                                if (IsEditable(data2.SerializedObject.targetObject))
                                {
                                    if (column.copyDelegate != null)
                                        column.copyDelegate(data2.Properties[columnIndex], serializedProperty);
                                    else
                                        DefaultDelegates.s_CopyDefault(data2.Properties[columnIndex],
                                            serializedProperty);
                                    data2.Store();
                                }
                            }
                    }
                }
                Profiler.EndSample();
            }
        }

        private static bool IsEditable(Object target)
        {
            return (target.hideFlags & HideFlags.NotEditable) == HideFlags.None;
        }

        protected override void BeforeRowsGUI()
        {
            var rows = GetRows();
            int num;
            int num2;
            GetFirstAndLastVisibleRows(out num, out num2);
            if (num2 != -1)
                for (var i = num; i <= num2; i++)
                    ((SerializedPropertyItem)rows[i]).GetData().Update();
            var list = FindRows(GetSelection());
            using (var enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var serializedPropertyItem =
                        (SerializedPropertyItem)enumerator.Current;
                    serializedPropertyItem.GetData().Update();
                }
            }
            base.BeforeRowsGUI();
        }

        public void OnFilterGUI(Rect r)
        {
            EditorGUI.BeginChangeCheck();
            var width = r.width;
            var num = 16f;
            r.width = num;
            m_bFilterSelection = EditorGUI.Toggle(r, m_bFilterSelection);
            r.x += num;
            r.width = GUI.skin.label.CalcSize(Styles.filterSelection).x;
            EditorGUI.LabelField(r, Styles.filterSelection);
            r.width = Mathf.Min(width - (r.x + r.width), 300f);
            r.x = width - r.width + 25;
            for (var i = 0; i < multiColumnHeader.state.columns.Length; i++)
            {
                if (IsColumnVisible(i))
                {
                    var column = Col(i);
                    if (column.filter != null && column.filter.GetType().Equals(typeof(SerializedPropertyFilters.Name)))
                        column.filter.OnGUI(r);
                }
            }
            if (EditorGUI.EndChangeCheck())
                Reload();
        }

        protected override void SelectionChanged(IList<int> selectedIds)
        {
            Selection.instanceIDs = selectedIds.ToArray();
        }

        protected override void KeyEvent()
        {
            if (Event.current.type == EventType.KeyDown)
                if (Event.current.character == '\t')
                {
                    GUI.FocusControl(Styles.focusHelper);
                    Event.current.Use();
                }
        }

        private void OnVisibleColumnChanged(MultiColumnHeader header)
        {
            Reload();
        }

        private void OnSortingChanged(MultiColumnHeader multiColumnHeader)
        {
            var rows = GetRows();
            Sort(rows, multiColumnHeader.sortedColumnIndex);
        }

        private void Sort(IList<TreeViewItem> rows, int sortIdx)
        {
            var flag = multiColumnHeader.IsSortedAscending(sortIdx);
            var comp = Col(sortIdx).compareDelegate;
            var list = rows as List<TreeViewItem>;
            if (comp != null)
            {
                Comparison<TreeViewItem> comparison;
                Comparison<TreeViewItem> comparison2;
                if (comp == DefaultDelegates.s_CompareName)
                {
                    comparison = (lhs, rhs) => EditorUtility.NaturalCompare(
                        ((SerializedPropertyItem)lhs).GetData().Name,
                        ((SerializedPropertyItem)rhs).GetData().Name);
                    comparison2 = (lhs, rhs) => -EditorUtility.NaturalCompare(
                        ((SerializedPropertyItem)lhs).GetData().Name,
                        ((SerializedPropertyItem)rhs).GetData().Name);
                }
                else
                {
                    comparison = (lhs, rhs) => comp(
                        ((SerializedPropertyItem)lhs).GetData().Properties[sortIdx],
                        ((SerializedPropertyItem)rhs).GetData().Properties[sortIdx]);
                    comparison2 = (lhs, rhs) => -comp(
                        ((SerializedPropertyItem)lhs).GetData().Properties[sortIdx],
                        ((SerializedPropertyItem)rhs).GetData().Properties[sortIdx]);
                }
                list.Sort(!flag ? comparison2 : comparison);
            }
        }

        private IEnumerable<TreeViewItem> Filter(IEnumerable<TreeViewItem> rows)
        {
            var enumerable = rows;
            var num = m_ColumnsInternal.Length;
            for (var i = 0; i < num; i++)
                if (IsColumnVisible(i))
                {
                    var c = Col(i);
                    var idx = i;
                    if (c.filter != null)
                        if (c.filter.Active())
                            if (c.filter.GetType().Equals(typeof(SerializedPropertyFilters.Name)))
                            {
                                var f = (SerializedPropertyFilters.Name)c.filter;
                                enumerable = from item in enumerable
                                             where f.Filter(((SerializedPropertyItem)item).GetData().Name)
                                             select item;
                            }
                            else
                            {
                                enumerable = from item in enumerable
                                             where c.filter.Filter(((SerializedPropertyItem)item)
                                                 .GetData()
                                                 .Properties[idx])
                                             select item;
                            }
                }
            return enumerable;
        }

        private bool IsColumnVisible(int idx)
        {
            bool result;
            for (var i = 0; i < multiColumnHeader.state.visibleColumns.Length; i++)
                if (multiColumnHeader.state.visibleColumns[i] == idx)
                {
                    result = true;
                    return result;
                }
            result = false;
            return result;
        }

        private Column Col(int idx)
        {
            return (Column)multiColumnHeader.state.columns[idx];
        }


        internal class SerializedPropertyItem : TreeViewItem
        {
            private readonly SerializedPropertyDataStore.Data m_Data;

            public SerializedPropertyItem(int id, int depth, SerializedPropertyDataStore.Data ltd)
                : base(id, depth, ltd == null ? "root" : ltd.Name)
            {
                m_Data = ltd;
            }

            public SerializedPropertyDataStore.Data GetData()
            {
                return m_Data;
            }
        }

        internal class Column : MultiColumnHeaderState.Column
        {
            public delegate int CompareEntry(SerializedProperty lhs, SerializedProperty rhs);

            public delegate void CopyDelegate(SerializedProperty target, SerializedProperty source);

            public delegate void DrawEntry(Rect r, SerializedProperty prop, SerializedProperty[] dependencies);

            public CompareEntry compareDelegate = null;

            public CopyDelegate copyDelegate = null;

            public int[] dependencyIndices = null;

            public DrawEntry drawDelegate = null;

            public SerializedPropertyFilters.IFilter filter = null;

            public string propertyName = null;
        }

        private struct ColumnInternal
        {
            public SerializedProperty[] dependencyProps;
        }

        internal class DefaultDelegates
        {
            public static readonly Column.DrawEntry s_DrawDefault = delegate(Rect r, SerializedProperty prop, SerializedProperty[] dependencies)
            {
                Profiler.BeginSample("PropDrawDefault");
                EditorGUI.PropertyField(r, prop, GUIContent.none);
                Profiler.EndSample();
            };

            public static readonly Column.DrawEntry s_DrawCheckbox = delegate(Rect r, SerializedProperty prop, SerializedProperty[] dependencies)
            {
                Profiler.BeginSample("PropDrawCheckbox");
                var num = r.width / 2f - 8f;
                r.x += num < 0f ? 0f : num;
                EditorGUI.PropertyField(r, prop, GUIContent.none);
                Profiler.EndSample();
            };

            public static readonly Column.DrawEntry s_DrawName = delegate { };

            public static readonly Column.CompareEntry s_CompareFloat =
                (SerializedProperty lhs, SerializedProperty rhs) => lhs.floatValue.CompareTo(rhs.floatValue);

            public static readonly Column.CompareEntry s_CompareCheckbox =
                (SerializedProperty lhs, SerializedProperty rhs) => lhs.boolValue.CompareTo(rhs.boolValue);

            public static readonly Column.CompareEntry s_CompareEnum =
                (SerializedProperty lhs, SerializedProperty rhs) => lhs.enumValueIndex.CompareTo(rhs.enumValueIndex);

            public static readonly Column.CompareEntry s_CompareInt =
                (SerializedProperty lhs, SerializedProperty rhs) => lhs.intValue.CompareTo(rhs.intValue);

            public static readonly Column.CompareEntry s_CompareColor =
                delegate(SerializedProperty lhs, SerializedProperty rhs)
                {
                    float num;
                    float num2;
                    float num3;
                    Color.RGBToHSV(lhs.colorValue, out num, out num2, out num3);
                    float value;
                    float num4;
                    float num5;
                    Color.RGBToHSV(rhs.colorValue, out value, out num4, out num5);
                    return num.CompareTo(value);
                };

            public static readonly Column.CompareEntry s_CompareName =
                (SerializedProperty lhs, SerializedProperty rhs) => 0;

            public static readonly Column.CopyDelegate s_CopyDefault =
                delegate(SerializedProperty target, SerializedProperty source)
                {
                    target.serializedObject.CopyFromSerializedProperty(source);
                };
        }
    }
}