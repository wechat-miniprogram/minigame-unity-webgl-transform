using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Profiling;
using System.Linq;

namespace WeChatWASM.EditorTable
{
	public class TableState
	{
		public float		fRowHeight			= 16.0f;

		public string		strSearch			= null;
		public int			nLastClickedID		= 0;
		public Vector3		scrollPos			= Vector3.zero;
		public List<int>	selectedIDs			= new List<int>();
		public List<int>	expandedIDs			= new List<int>();
	}

	public class TableView : BaseView
	{
		protected TableViewData			m_viewData				= null;
		protected TableState			m_tableState			= null;
		protected MultiColumnHeader		m_multiColumnHeader		= null;

		public bool						isSearching				=> !string.IsNullOrEmpty(state.strSearch);
		public MultiColumnHeader		multiColumnHeader		=> m_multiColumnHeader;
		public TableState				state					=> m_tableState;

		virtual protected float			filterHeight			=> 0.0f;

		public string searchString
		{
			get { return state.strSearch; }
			set
			{
				if (string.ReferenceEquals(state.strSearch, value))
					return;

				if (state.strSearch == value)
					return;
				
				state.strSearch = value;
				m_viewData.OnSearchChanged();
			}
		}

		public TableView(MultiColumnHeader multiColumnHeader, TableState tableState, TableViewData viewData)
		{
			Debug.Assert(multiColumnHeader != null);
			Debug.Assert(viewData != null);

			m_viewData = viewData;
			m_tableState = tableState;
			m_multiColumnHeader = multiColumnHeader;

			m_viewData.InitView(this);
			m_multiColumnHeader.InitView(this);
		}

		void TableViewWithMultiColumnHeader(Rect rect)
		{
			Rect columnHeaderRect = new Rect(rect.x, rect.y, rect.width, m_multiColumnHeader.fHeaderHeight);
			Rect tableRect = new Rect(rect.x, columnHeaderRect.yMax, rect.width, rect.height - columnHeaderRect.height);

			float scrollX = Mathf.Max(m_tableState.scrollPos.x, 0f);

			m_multiColumnHeader.OnGUI(columnHeaderRect, scrollX);
			TableViewOnGUI(tableRect);
		}

		void TableViewWithoutMultiColumnHeader(Rect rect)
		{
			float scrollX = Mathf.Max(m_tableState.scrollPos.x, 0f);
			m_multiColumnHeader.OnGUI(rect, scrollX);
			TableViewOnGUI(rect);
		}

		private Rect m_totalRect				= Rect.zero;
		private Rect m_contentRect				= Rect.zero;
		public bool showingVerticalScrollBar	=> m_totalRect.height > 0 && m_contentRect.height > m_totalRect.height;
		public bool showingHorizontalScrollBar	=> m_totalRect.width > 0 && m_contentRect.width > m_totalRect.width;
		private void TableViewOnGUI(Rect rect)
		{
			Event evt = Event.current;
			if (evt.type == EventType.Repaint)
				m_totalRect = rect;

			m_viewData.InitIfNeeded();

			Vector2 contentSize = GetTotalSize();

			m_contentRect = new Rect(0, 0, contentSize.x, contentSize.y);
			state.scrollPos = GUI.BeginScrollView(m_totalRect, state.scrollPos, m_contentRect, false, false, GUI.skin.horizontalScrollbar, GUI.skin.verticalScrollbar);

			BeforeRowsGUI();

			int firstRow, lastRow;
			GetFirstAndLastRowVisible(out firstRow, out lastRow);

			if (lastRow >= 0)
			{
				int numVisibleRows = lastRow - firstRow + 1;
				float rowWidth = m_contentRect.width;

				IterateVisibleItems(firstRow, numVisibleRows, rowWidth);
			}

			EndRowGUI();
			GUI.EndScrollView(showingVerticalScrollBar);

			if (Event.current.type == EventType.MouseLeaveWindow)
				hoveredItem = null;
		}

		virtual protected void EndRowGUI()
		{
			DoRowCountChange();
		}

		protected Action rowCountChange = null;
		virtual protected void DoRowCountChange()
		{
			rowCountChange?.Invoke();
			rowCountChange = null;
		}

		protected void AddRowCountChange(Action action)
		{
			rowCountChange += action;
		}

		public bool bEnableItemHovering { get; set; }
		private RowViewItem hoveredItem { get; set; }
		private Rect hoveredItemRect { get; set; }
		protected virtual void IterateVisibleItems(int firstRow, int numVisibleRows, float rowWidth)
		{
			RowViewItem currentHoveredItem = null;
			for (int i = 0; i < numVisibleRows && i< m_viewData.rowCount; ++i)
			{
				int row = firstRow + i;

				float screenSpaceRowY = GetRowRect(row, rowWidth).y - state.scrollPos.y;
				if (screenSpaceRowY > m_totalRect.height)
				{
					continue;
				}

				if (bEnableItemHovering)
				{
					Rect rowRect = GetRowRect(row, rowWidth);
					if (rowRect.Contains(Event.current.mousePosition))
					{
						currentHoveredItem = m_viewData.GetItem(row);
						hoveredItemRect = GUIUtility.ScreenToGUIRect(rowRect);
					}
				}

				DoItemGUI(m_viewData.GetItem(row), row, rowWidth);
			}

			hoveredItem = currentHoveredItem;
		}

		protected bool IsItemSelectedById(int id)
		{
			return state.selectedIDs.Contains(id);
		}

		public void DoItemGUI(RowViewItem item, int row, float rowWidth)
		{
			if (row < 0 || row >= m_viewData.rowCount)
			{
				Debug.LogError("Invalid. Org row: " + (row) + " Num rows " + m_viewData.rowCount);
				return;
			}

			bool selected = IsItemSelectedById(item.id);
			Rect rowRect = GetRowRect(row, rowWidth);

			OnRowGUI(rowRect, item, row, selected);
			HandleUnusedMouseEventsForItem(rowRect, item, row);
		}

		public void OnRowGUI(Rect rowRect, RowViewItem item, int row, bool selected)
		{
			bool bShowFoldout = m_viewData.IsExpandable(item);

			if (Event.current.type == EventType.Repaint)
			{
				if (selected)
					DefaultStyles.selectionStyle.Draw(rowRect, false, false, true, true);
			}

			OnContentGUI(rowRect, row, item, selected);

			if (bShowFoldout)
			{
				DoFoldout(rowRect, item, row);
			}
		}

		protected float foldoutStyleWidth => DefaultStyles.foldout.fixedWidth;

		protected Rect DoFoldout(Rect rect, RowViewItem item, int row)
		{
			float indent = GetFoldoutIndent(item);
			Rect foldoutRect = new Rect(rect.x + indent, GetFoldoutYPosition(rect.y), foldoutStyleWidth, 16);
			FoldoutButton(foldoutRect, item, row, DefaultStyles.foldout);
			return foldoutRect;
		}

		protected virtual void FoldoutButton(Rect foldoutRect, RowViewItem item, int row, GUIStyle foldoutStyle)
		{
			bool expandedState = m_viewData.IsExpanded(item);
			bool newExpandedValue = GUI.Toggle(foldoutRect, expandedState, GUIContent.none, foldoutStyle);
			if (newExpandedValue != expandedState)
			m_viewData.SetExpanded(item, newExpandedValue);
		}

		virtual protected float GetFoldoutYPosition(float rectY)
		{
			const float customFoldoutYOffset = 0;
			// 默认状态箭头紧贴标签
			return rectY + customFoldoutYOffset;
		}

		private Rect[] m_cellRects = null;
		protected void OnContentGUI(Rect rect, int row, RowViewItem item, bool selected)
		{
			float fIndent = GetContentIndent(item);
			rect.x += fIndent;
			rect.width -= fIndent;

			var visibleColumns = m_multiColumnHeader.state.visibleColumns;
			if (m_cellRects == null || m_cellRects.Length != visibleColumns.Length)
				m_cellRects = new Rect[visibleColumns.Length];

			var columns = m_multiColumnHeader.state.columns;
			var columnRect = rect;
			for (int i = 0; i < visibleColumns.Length; ++i)
			{
				var columnState = columns[visibleColumns[i]];
				columnRect.width = columnState.fWidth;

				m_cellRects[i] = columnRect;

				columnRect.x += columnState.fWidth;
			}

			for (int i = 0; i < m_multiColumnHeader.state.visibleColumns.Length; ++i)
			{
				CellGUI(m_cellRects[i], item, row, m_multiColumnHeader.state.visibleColumns[i]);
			}
		}

		protected void CenterRectUsingSingleLineHeight(ref Rect rect)
		{
			float singleLineHeight = EditorGUIUtility.singleLineHeight;
			if (rect.height > singleLineHeight)
			{
				rect.y += (rect.height - singleLineHeight) * 0.5f;
				rect.height = singleLineHeight;
			}
		}

		protected void CellGUI(Rect cellRect, RowViewItem item, int nRow, int nColumn)
		{
			CenterRectUsingSingleLineHeight(ref cellRect);
			cellRect.width -= DefaultGUI.columnContentMargin;

			ColumnState column = m_multiColumnHeader.state.columns[nColumn];

			switch(column.type)
			{
				case ColumnType.emLabel:
					using (new EditorGUI.DisabledScope())
					{
						string strLabel = item.GetData(nColumn).ToString();
						DefaultGUI.Label(cellRect, strLabel, IsItemSelectedById(item.id), false);
					}
					break;
				case ColumnType.emString:
					string strPrev = item.GetData(nColumn);
					string strText = GUI.TextField(cellRect, strPrev);
					if (strPrev != strText)
						item.SetData(nRow,nColumn, strText);
					break;
				case ColumnType.emInt:
					int nPrev = item.GetData(nColumn);
					int nNow = EditorGUI.IntField(cellRect, nPrev);
					if (nNow != nPrev)
						item.SetData(nRow, nColumn, nNow);
					break;
				case ColumnType.emFloat:
					float fPrev = item.GetData(nColumn);
					float fNow = EditorGUI.FloatField(cellRect, fPrev);

					if (!Mathf.Approximately(fPrev, fNow))
						item.SetData(nRow, nColumn, fNow);

					break;
				case ColumnType.emDropdown:
					ColumnState.GetData getData = (ColumnState.GetData)column.exData;
					string[] dropdowns = (string[])getData();
					int nSel = item.GetData(nColumn);
					int nNew = EditorGUI.Popup(cellRect, nSel, dropdowns);
					if (nNew != nSel)
						item.SetData(nRow, nColumn, nNew);

					break;
				case ColumnType.emCheck:
					string strPrevCheck = item.GetData(nColumn);
					string strData = GUI.TextField(cellRect, strPrevCheck);
					if (!strData.Equals(strPrevCheck))
					{
						ColumnState.CheckInput checkInput = (ColumnState.CheckInput)column.exData;
						if (checkInput(strData))
							item.SetData(nRow, nColumn, strData);
					}
					break;
				case ColumnType.emButton:
					GUIContent gUIContent = item.GetData(nColumn);
					bool bCheck = ToolGUIUtility.OnlyLeftButton(cellRect, gUIContent);
					if (bCheck)
						CellItemClick(nRow, nColumn);
					break;
				case ColumnType.emToggle:
					bool bPrevToggle = item.GetData(nColumn);
					bool bToggle = GUI.Toggle(cellRect, bPrevToggle,"");
					if (bToggle != bPrevToggle)
					{
						item.SetData(nRow, nColumn, bToggle);
						CellItemClick(nRow, nColumn);
					}
					break;
				default:
					throw new Exception("error ColumnType");
			}
		}

		virtual protected void CellItemClick(int nRow, int nColumn)
		{

		}

		virtual protected void BeforeRowsGUI()
		{
			DrawAlternatingRowBackgrounds();
		}

		const float mc_fBackgroundWidth = 100000f;
		public void DrawAlternatingRowBackgrounds()
		{
			if (Event.current.rawType != EventType.Repaint)
				return;

			float contentYMax = m_totalRect.height + state.scrollPos.y;
			DefaultStyles.backgroundOdd.Draw(new Rect(0, 0, mc_fBackgroundWidth, contentYMax), false, false, false, false);

			int first = 0;
			var numRows = m_viewData.GetRows().Count;
			if (numRows > 0)
			{
				int last;
				GetFirstAndLastRowVisible(out first, out last);
				if (first < 0 || first >= numRows)
					return;
			}

			Rect rowRect = new Rect(0, 0, 0, DefaultGUI.lineHeight);
			for (int row = first; rowRect.yMax < contentYMax; row++)
			{
				if (row % 2 == 1)
					continue;

				if (row < numRows)
					rowRect = GetRowRect(row);
				else if (row > 0)
					rowRect.y += rowRect.height * 2;

				rowRect.width = mc_fBackgroundWidth;
				DefaultStyles.backgroundEven.Draw(rowRect, false, false, false, false);
			}
		}

		protected Rect GetRowRect(int row)
		{
			return GetRowRect(row, m_totalRect.width);
		}

		virtual protected void HandleUnusedMouseEventsForItem(Rect rect, RowViewItem item, int row)
		{
			Event evt = Event.current;
			switch (evt.type)
			{
				case EventType.MouseDown:
					if (rect.Contains(Event.current.mousePosition))
					{
						if (Event.current.button == 0)
						{
							// Let client handle double click
							if (Event.current.clickCount == 2)
							{
								// TODO double click
							}
							else
							{
								SelectionClick(item);
							}
							evt.Use();
						}
						else if (Event.current.button == 1)
						{
							SelectionClick(item);
							evt.Use();
						}
					}
					break;
			}
		}

		virtual protected void SelectionClick(RowViewItem itemClicked)
		{
			var newSelection = m_viewData.GetNewSelection(itemClicked, state.selectedIDs, state.nLastClickedID);
			RowItemSelectionChange(newSelection, itemClicked != null ? itemClicked.id : 0);
		}

		public System.Action<int[], int[]> selectionChangedCallback { get; set; }
		protected void RowItemSelectionChange(List<int> newSelection, int itemID)
		{
			state.nLastClickedID = itemID;

			bool selectionChanged = !state.selectedIDs.SequenceEqual(newSelection);
			if (selectionChanged)
			{
				var prevSelection = state.selectedIDs;
				state.selectedIDs = newSelection;

				int[] prevSelectionRows = prevSelection.ToArray();
				int[] newSelectionRows = newSelection.ToArray();
				for (int i = 0; i < prevSelectionRows.Length; ++i)
					prevSelectionRows[i] = m_viewData.GetRow(prevSelectionRows[i]);

				for (int i = 0; i < newSelectionRows.Length; ++i)
					newSelectionRows[i] = m_viewData.GetRow(newSelectionRows[i]);

				selectionChangedCallback?.Invoke(prevSelectionRows, newSelectionRows);
				Repaint();
			}
		}

		public Rect GetRowRect(int row, float rowWidth)
		{
			if (row < 0 || row >= m_rowRects.Count)
			{
				throw new ArgumentOutOfRangeException("row", string.Format("Input row index: {0} is invalid. Number of rows rects: {1}. (Number of rows: {2})", row, m_rowRects.Count, m_viewData.rowCount));
			}

			Rect rowRect = m_rowRects[row];
			rowRect.width = rowWidth;
			return rowRect;
		}

		public void GetFirstAndLastRowVisible(out int nFirstRowVisible, out int nLastRowVisible)
		{
			if (m_viewData.rowCount == 0)
			{
				nFirstRowVisible = nLastRowVisible = -1;
				return;
			}

			var rowCount = m_viewData.rowCount;
			if (rowCount != m_rowRects.Count)
			{
				var errorMessage = string.Format(
					"Number of rows does not match number of row rects. Did you remember to update the row rects when BuildRootAndRows was called? Number of rows: {0}, number of custom row rects: {1}. Falling back to fixed row height.",
					rowCount, m_rowRects.Count);
				m_rowRects = null;
				throw new InvalidOperationException(errorMessage);
			}

			float fTopPixel = m_tableState.scrollPos.y;
			float fHeightInPixels = m_totalRect.height;

			int nFirstVisible = -1;
			int nLastVisible = -1;
			for (int i = 0; i < m_rowRects.Count; ++i)
			{
				bool visible = ((m_rowRects[i].y > fTopPixel && (m_rowRects[i].y < fTopPixel + fHeightInPixels))) ||
					((m_rowRects[i].yMax > fTopPixel && (m_rowRects[i].yMax < fTopPixel + fHeightInPixels)));

				if (visible)
				{
					if (nFirstVisible == -1)
						nFirstVisible = i;
					nLastVisible = i;
				}
			}

			if (nFirstVisible != -1 && nLastVisible != -1)
			{
				nFirstRowVisible = nFirstVisible;
				nLastRowVisible = nLastVisible;
			}
			else
			{
				nFirstRowVisible = 0;
				nLastRowVisible = rowCount - 1;
			}
		}

		private List<Rect> m_rowRects = null;
		private float m_fRowMargin = 0;
		private float customRowsTotalHeight => (m_rowRects.Count > 0 ? m_rowRects[m_rowRects.Count - 1].yMax : 0f) + m_fRowMargin;

		public void RefreshRowRects(IList<RowViewItem> rows)
		{
			if (m_rowRects == null)
				m_rowRects = new List<Rect>(rows.Count);

			if (m_rowRects.Capacity < rows.Count)
				m_rowRects.Capacity = rows.Count;
			
			m_rowRects.Clear();
			float curY = DefaultGUI.topRowMargin;
			for (int row = 0; row < rows.Count; ++row)
			{
				float height = DefaultGUI.lineHeight;
				m_rowRects.Add(new Rect(0f, curY, 1f, height)); // row width is updatd to the actual visibleRect of the TreeView's scrollview on the fly
				curY += height;
			}
		}

		virtual protected Vector2 GetTotalSize()
		{
			return new Vector2(Mathf.Floor(m_multiColumnHeader.state.widthOfAllVisibleColumns), customRowsTotalHeight);
		}

		virtual public float GetContentIndent(RowViewItem item)
		{
			return GetFoldoutIndent(item) + DefaultStyles.foldout.fixedWidth + DefaultStyles.lineStyle.margin.left;
		}

		virtual public float GetFoldoutIndent(RowViewItem item)
		{
			if (isSearching)
				return DefaultGUI.baseIndent;

			return DefaultGUI.baseIndent + item.depth * DefaultGUI.indentWidth;
		}

		public void OnGUI()
		{
			Profiler.BeginSample("TableView.OnGUI");

			Rect rect = GUILayoutUtility.GetRect(0, float.MaxValue, 0, float.MaxValue);

			if (Event.current.type == EventType.Layout)
			{
				Profiler.EndSample();
				return;
			}

			float tableHeight = rect.height - filterHeight;
			rect.height = filterHeight;
			Rect filterRect = rect;

			rect.height = tableHeight;
			rect.y += filterHeight;

			Profiler.BeginSample("DrawBorder");
			Rect tableRect = ToolGUIUtility.DrawBorder(rect);
			if (m_multiColumnHeader.isDraw)
				TableViewWithMultiColumnHeader(tableRect);
			else
				TableViewWithoutMultiColumnHeader(tableRect);

			Profiler.EndSample();

			OnFilterGUI(filterRect);
			Profiler.EndSample();
		}

		virtual protected bool isFilteredDirty { set; get; } = false;

		virtual protected void OnFilterGUI(Rect filterRect)
		{
			if (isFilteredDirty)
				Repaint();
		}
	}
}

