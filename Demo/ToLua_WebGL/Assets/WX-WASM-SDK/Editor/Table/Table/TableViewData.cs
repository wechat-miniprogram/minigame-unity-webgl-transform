using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WeChatWASM.EditorTable
{
	public abstract class TableViewData
	{
		protected TableView				m_view					= null;
		public ITableData			m_tableData				= null;

		protected bool					m_bNeedRefreshRows		= false;
		protected RowViewItem			m_rootItem				= null;
		protected IList<RowViewItem>	m_rows					= null;

		public System.Action			onVisibleRowsReloaded	= null;

		protected MultiColumnHeader		multiColumnHeader		=> m_view.multiColumnHeader;
		public RowViewItem				root					=> m_rootItem;

		public bool showRootItem { get; set; }					= false;
		public bool rootIsCollapsable { get; set; }				= false;


		protected List<int> expandedIDs
		{
			get { return m_view.state.expandedIDs; }
			set { m_view.state.expandedIDs = value; }
		}

		public TableViewData(ITableData tableData)
		{
			m_tableData = tableData;
		}

		public void InitView(TableView tableView)
		{
			m_view = tableView;
		}

		public virtual RowViewItem FindItem(int id)
		{
			return FindItemRecursive(id, m_rootItem);
		}

		static RowViewItem FindItemRecursive(int id, RowViewItem item)
		{
			if (item == null)
				return null;

			if (item.id == id)
				return item;

			if (!item.hasChildren)
				return null;

			foreach (RowViewItem child in item.children)
			{
				RowViewItem result = FindItemRecursive(id, child);
				if (result != null)
					return result;
			}
			return null;
		}

		virtual public bool IsRevealed(int id)
		{
			IList<RowViewItem> rows = GetRows();
			return GetIndexOfID(rows, id) >= 0;
		}

		static int GetIndexOfID(IList<RowViewItem> items, int id)
		{
			for (int i = 0; i < items.Count; ++i)
				if (items[i].id == id)
					return i;
			return -1;
		}

		virtual public void RevealItem(int id)
		{
			if (IsRevealed(id))
				return;

			RowViewItem item = FindItem(id);
			if (item != null)
			{
				RowViewItem parent = item.parent;
				while (parent != null)
				{
					SetExpanded(parent, true);
					parent = parent.parent;
				}
			}
		}

		virtual public void OnSearchChanged()
		{
			m_bNeedRefreshRows = true;
		}

		virtual protected void GetVisibleItemsRecursive(RowViewItem item, IList<RowViewItem> items)
		{
			if (item != root || showRootItem)
				items.Add(item);

			if (item.hasChildren && IsExpanded(item))
				foreach (RowViewItem child in item.children)
					GetVisibleItemsRecursive(child, items);
		}

		virtual protected List<RowViewItem> GetAllExpandedRows(RowViewItem root)
		{
			var result = new List<RowViewItem>();
			GetVisibleItemsRecursive(root, result);
			return result;
		}

		virtual protected List<RowViewItem> Search(RowViewItem root, string search)
		{
			var result = new List<RowViewItem>();

			if (showRootItem)
			{
				SearchRecursive(root, search, result);
				result.Sort(new RowViewItemAlphaNumericSort());
			}
			else
			{
				if (root.hasChildren)
				{
					for (int i = 0; i < root.children.Count; ++i)
					{
						SearchRecursive(root.children[i], search, result);
					}
					result.Sort(new RowViewItemAlphaNumericSort());
				}
			}

			return result;
		}

		virtual protected void SearchRecursive(RowViewItem item, string search, IList<RowViewItem> searchResult)
		{
			if (item.keyValue.ToLower().Contains(search))
				searchResult.Add(item);

			if (item.children != null)
				foreach (RowViewItem child in item.children)
					SearchRecursive(child, search, searchResult);
		}

		virtual public int rowCount => GetRows().Count;

		virtual public IList<RowViewItem> GetRows()
		{
			InitIfNeeded();
			return m_rows;
		}

		virtual public RowViewItem GetItem(int row)
		{
			return GetRows()[row];
		}

		virtual public int GetRow(int id)
		{
			var rows = GetRows();
			for (int row = 0; row < rows.Count; ++row)
			{
				if (rows[row].id == id)
					return row;
			}
			return -1;
		}

		virtual public void InitIfNeeded()
		{
			if (m_rows == null || m_bNeedRefreshRows)
			{
				if (root == null)
				{
					m_rootItem = GetViewDataRoot();
					SetExpanded(m_rootItem, true);
				}

				if (root != null)
				{
					if (m_view.isSearching)
						m_rows = Search(root, m_view.searchString.ToLower());
					else
						m_rows = GetAllExpandedRows(root);
				}
				else
				{
					Debug.LogError("root item is null. Ensure that your sets up at least a root item.");
					m_rows = new List<RowViewItem>();
				}

				m_bNeedRefreshRows = false;

				if (onVisibleRowsReloaded != null)
					onVisibleRowsReloaded();

				m_view.RefreshRowRects(m_rows);
				m_view.Repaint();
			}
		}

		virtual public void SetExpandedIDs(int[] ids)
		{
			expandedIDs = new List<int>(ids);
			expandedIDs.Sort();
			m_bNeedRefreshRows = true;
		}

		virtual public bool IsExpanded(int id)
		{
			return expandedIDs.BinarySearch(id) >= 0;
		}

		virtual public bool SetExpanded(int id, bool expand)
		{
			bool expanded = IsExpanded(id);
			if (expand != expanded)
			{
				if (expand)
				{
					Debug.Assert(!expandedIDs.Contains(id));
					expandedIDs.Add(id);
					expandedIDs.Sort();
				}
				else
				{
					expandedIDs.Remove(id);
				}

				m_bNeedRefreshRows = true;
				return true;
			}
			return false;
		}

		virtual public void SetExpandedWithChildren(int id, bool expand)
		{
			SetExpandedWithChildren(FindItem(id), expand);
		}

		virtual public void SetExpandedWithChildren(RowViewItem fromItem, bool expand)
		{
			if (fromItem == null)
			{
				Debug.LogError("item is null");
				return;
			}

			HashSet<int> parents = new HashSet<int>();
			GetParentsBelowItem(fromItem, parents);

			HashSet<int> oldExpandedSet = new HashSet<int>(expandedIDs);

			if (expand)
				oldExpandedSet.UnionWith(parents);
			else
				oldExpandedSet.ExceptWith(parents);

			SetExpandedIDs(oldExpandedSet.ToArray());
		}

		static void GetParentsBelowItem(RowViewItem fromItem, HashSet<int> parentsBelow)
		{
			if (fromItem == null)
				throw new ArgumentNullException("fromItem");

			Stack<RowViewItem> stack = new Stack<RowViewItem>();
			stack.Push(fromItem);

			while (stack.Count > 0)
			{
				RowViewItem current = stack.Pop();
				if (current.hasChildren)
				{
					parentsBelow.Add(current.id);

					foreach (var foo in current.children)
					{
						stack.Push(foo);
					}
				}
			}
		}

		virtual public void SetExpanded(RowViewItem item, bool expand)
		{
			SetExpanded(item.id, expand);
		}

		virtual public bool IsExpanded(RowViewItem item)
		{
			return IsExpanded(item.id);
		}

		virtual public bool IsExpandable(RowViewItem item)
		{
			if (m_view.isSearching)
				return false;
			return item.hasChildren;
		}

		virtual public bool CanBeMultiSelected(RowViewItem item)
		{
			return true;
		}

		virtual public List<int> GetNewSelection(RowViewItem clickedItem, List<int> selectedIDs, int nLastClickedID)
		{
			bool bAllowMultiselection = CanBeMultiSelected(clickedItem);
			if (!bAllowMultiselection)
				return new List<int>() { clickedItem.id };

			if (!Event.current.control && !Event.current.shift)
				return new List<int>() { clickedItem.id };

			if (Event.current.control)
			{
				List<int> newSelects = new List<int>(selectedIDs);
				if (newSelects.Contains(clickedItem.id))
					newSelects.Remove(clickedItem.id);
				else
					newSelects.Add(clickedItem.id);

				return newSelects;
			}

			if (Event.current.shift)
			{
				var visibleRows = GetRows();
				int nMaxIdx = -1, nMinIdx = -1;
				List<int> allIDs = new List<int>(visibleRows.Count);

				for (int i = 0; i < visibleRows.Count; ++i)
				{
					int nId = visibleRows[i].id;
					allIDs.Add(nId);

					if (selectedIDs.Contains(nId))
					{
						if (nMinIdx == -1)
							nMinIdx = i;

						nMaxIdx = i;
					}
				}

				int nCurIdx = allIDs.IndexOf(clickedItem.id);
				if (nCurIdx > nMinIdx)
					return allIDs.GetRange(nMinIdx, nCurIdx - nMinIdx + 1);
				else
					return allIDs.GetRange(nCurIdx, nMaxIdx - nCurIdx + 1);
			}

			return new List<int>() { clickedItem.id };
		}

		virtual protected int nextRowItemId { get; set; } = 0;
		virtual protected int GetNewRowItemId()
		{
			nextRowItemId = nextRowItemId + 1;
			return nextRowItemId;
		}

		virtual public void AddNewRow(RowViewItem child, int nRow = -1)
		{
			m_rootItem.AddChild(child, nRow);
			m_rows = null;
		}

		virtual protected void Remove(int nId)
		{
			RowViewItem child = FindItem(nId);
			if (child != null)
			{
				m_rootItem.RemoveChild(child);
				m_rows = null;
			}
		}

		virtual public void RemoveAtIndex(int nIdx)
		{
			RowViewItem rowViewItem = GetItem(nIdx);
			Remove(rowViewItem.id);
		}

		public delegate bool TraverseFn(RowViewItem rowViewItem);
		public void TraverseAllRow(TraverseFn action, bool bContainRoot)
		{
			InitIfNeeded();

			if (bContainRoot)
				action(m_rootItem);

			if (m_rootItem.hasChildren)
			{
				foreach (RowViewItem child in m_rootItem.children)
				{
					if (!TraverseRowItemchildren(action, child))
						return;
				}
			}
		}

		protected bool TraverseRowItemchildren(TraverseFn action, RowViewItem item)
		{
			if (!action(item))
				return false;

			if (item.hasChildren)
			{
				foreach (RowViewItem child in item.children)
				{
					if (!TraverseRowItemchildren(action, child))
						return false;
				}
			}
			return true;
		}

		virtual public void SaveData()
		{
			throw new Exception("it is not has save data");
		}

		virtual public void AddNewRow(int nRow = -1)
		{
			throw new Exception("it is not AddNewRow");
		}

		abstract protected RowViewItem GetViewDataRoot();
	}
}

