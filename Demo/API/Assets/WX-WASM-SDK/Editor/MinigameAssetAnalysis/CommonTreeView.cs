using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace WeChatWASM.Analysis
{
    public class CommonTreeView<T> : TreeView where T : class
    {
        private List<CommonTreeViewItem<T>> m_items;
        private Boolean isAllCheck;
        private Action<Boolean> m_toggleSelectAll;

        private readonly List<T> m_datas;
        public CommonTreeView(
            TreeViewState state,
            MultiColumnHeader multiColumnHeader,
            List<T> datas,
            FilterMethod<T> filter,
            SelectMethod<T> select = null,
            Action<Boolean> toggleSelectAll = null)
            : base(state, multiColumnHeader)
        {
            m_datas = datas;

            m_filter = filter;
            m_select = select;
            m_toggleSelectAll = toggleSelectAll;

            multiColumnHeader.sortingChanged += OnSortingChanged;
            multiColumnHeader.visibleColumnsChanged += OnVisibleColumnChanged;
            
            showAlternatingRowBackgrounds = true;
            showBorder = true;
            rowHeight = EditorGUIUtility.singleLineHeight;
        }

        private void OnVisibleColumnChanged(MultiColumnHeader multicolumnheader)
        {
            Reload();
        }

        private void OnSortingChanged(MultiColumnHeader multicolumnheader)
        {
            var rows = GetRows();
            Sort(rows, multiColumnHeader.sortedColumnIndex);
        }

        protected override TreeViewItem BuildRoot()
        {
            return new CommonTreeViewItem<T>(-1, -1, null);
        }

        protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
        {
            if (m_items == null)
            {
                m_items = new List<CommonTreeViewItem<T>>();
                for (var i = 0; i < m_datas.Count; i++)
                {
                    var data = m_datas[i];
                    m_items.Add(new CommonTreeViewItem<T>(i, 0, data));
                }
            }
            var items = m_items;
            if (!string.IsNullOrEmpty(m_text))
                items = Filter(items);

            var list = new List<TreeViewItem>();
            foreach (var item in items)
            {
                list.Add(item);
            }
            if (multiColumnHeader.sortedColumnIndex >= 0)
                Sort(list, multiColumnHeader.sortedColumnIndex);
            return items.Cast<TreeViewItem>().ToList();
        }

        private readonly FilterMethod<T> m_filter;

        [CanBeNull]
        private readonly SelectMethod<T> m_select;

        private List<CommonTreeViewItem<T>> Filter(IEnumerable<CommonTreeViewItem<T>> rows)
        {
            var enumerable = rows;
            var i = 0;
            if (IsColumnVisible(i) && m_filter != null)
            {
                enumerable = from item in enumerable
                             where m_filter(item.Data, m_text)
                             select item;
            }
            return enumerable.ToList();
        }
        private CommonTableColumn<T> Col(int idx)
        {
            return (CommonTableColumn<T>)multiColumnHeader.state.columns[idx];
        }

        private void Sort(IList<TreeViewItem> rows, int sortIdx)
        {
            var flag = multiColumnHeader.IsSortedAscending(sortIdx);
            var comp = Col(sortIdx).Compare;
            var list = (List<TreeViewItem>)rows;
            if (comp != null)
            {
                Comparison<TreeViewItem> comparison = (lhs, rhs) =>
                {
                    var x1 = (CommonTreeViewItem<T>)lhs;
                    var x2 = (CommonTreeViewItem<T>)rhs;
                    return comp(x1.Data, x2.Data);
                };
                Comparison<TreeViewItem> comparison2 = (lhs, rhs) =>
                {
                    var x1 = (CommonTreeViewItem<T>)lhs;
                    var x2 = (CommonTreeViewItem<T>)rhs;
                    return -comp(x1.Data, x2.Data);
                };
                list.Sort(!flag ? comparison2 : comparison);
            }
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var item = (CommonTreeViewItem<T>)args.item;
            for (var i = 0; i < args.GetNumVisibleColumns(); i++)
            {
                CellGUI(args.GetCellRect(i), item.Data, args.GetColumn(i));
            }
        }

        private void CellGUI(Rect cellRect, T item, int columnIndex)
        {
            CenterRectUsingSingleLineHeight(ref cellRect);
            var column = (CommonTableColumn<T>)multiColumnHeader.GetColumn(columnIndex);
            if (column.DrawCell != null)
                column.DrawCell(cellRect, item);
        }

        public void OnCheckAllGUI()
        {
            var selectedList = this.GetSelection();
            if (selectedList.Count != m_datas.Count)
            {
                isAllCheck = false;
            }
            var newState = GUI.Toggle(new Rect(5, 20, 50, 20), isAllCheck, "全选");
            if (newState != isAllCheck)
            {
                isAllCheck = newState;
                if (isAllCheck)
                {
                    if (m_datas.Count != 0)
                    {
                        this.SelectAllRows();
                    }
                } else
                {
                    this.SetSelection(new List<int>());
                }
                if (m_toggleSelectAll != null)
                {
                    m_toggleSelectAll(isAllCheck);
                }
            }
        }

        public void OnFilterGUI(Rect r)
        {
            EditorGUI.BeginChangeCheck();
            var width = r.width;
            var num = 16f;
            r.width = num;
            r.x += num;
            r.width = GUI.skin.label.CalcSize(Styles.filterSelection).x;

            //EditorGUI.LabelField(r, Styles.filterSelection);
            r.width = Mathf.Min(width - (r.x + r.width), 300f);
            r.x = width - r.width + 25;
            FilterGUI(r);
            if (EditorGUI.EndChangeCheck())
            {
                Reload();
            }
        }

        private string m_text;
        private void FilterGUI(Rect r)
        {
            r.width -= 15f;
            //GUI.SetNextControlName("InputText");
            m_text = EditorGUI.DelayedTextField(r, GUIContent.none, m_text, Styles.searchField);
            //EditorGUI.FocusTextInControl("InputText");
            r.x += r.width;
            r.width = 15f;
            bool flag = m_text != "";
            if (GUI.Button(r, GUIContent.none, (!flag) ? Styles.searchFieldCancelButtonEmpty : Styles.searchFieldCancelButton) && flag)
            {
                m_text = "";
                GUIUtility.keyboardControl = 0;
            }
        }

        private bool IsColumnVisible(int idx)
        {
            return multiColumnHeader.state.visibleColumns.Any(t => t == idx);
        }

        protected override void KeyEvent()
        {
            if (Event.current.type == EventType.KeyDown)
            {
                if (Event.current.character == '\t')
                {
                    GUI.FocusControl(Styles.focusHelper);
                    Event.current.Use();
                }
            }
        }

        protected override void SelectionChanged(IList<int> selectedIds)
        {
            var datas = new List<T>();
            foreach (var id in selectedIds)
            {
                if (id < 0 || id > m_datas.Count)
                {
                    Debug.Log(id + "out of range");
                    continue;
                }
                var data = m_datas[id];
                datas.Add(data);
            }
            if (m_select != null)
                m_select(datas);
        }
    }

    public class CommonTableColumn<T> : MultiColumnHeaderState.Column
    {
        public DrawCellMethod<T> DrawCell;

        //public IFilter Filter;
        public CompareMethod<T> Compare { get; set; }
    }

    //public interface IFilter
    //{
    //    void OnGUI(Rect r);
    //}

    //public interface IFilter<T> : IFilter
    //{
    //    bool Filter(T prop);
    //}

    //public class StringFilter
    //{
    //    [SerializeField]
    //    protected string m_Text = "";
    //    public void OnGUI(Rect r)
    //    {

    //    }

    //    public bool Filter(string prop)
    //    {
    //        return prop.IndexOf(m_Text, 0, StringComparison.OrdinalIgnoreCase) >= 0;
    //    }
    //}
}