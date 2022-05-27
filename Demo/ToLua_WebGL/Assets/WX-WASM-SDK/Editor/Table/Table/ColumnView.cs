using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace WeChatWASM.EditorTable
{
	public enum ColumnType : byte
	{
		emLabel,
		emInt,
		emFloat,
		emString,
		emCheck,
		emToggle,
		emButton,
		emDropdown,
	}

	public class ColumnState
	{
		public delegate object GetData();
		public delegate bool CheckInput(string strInput);

		public ColumnType		type					= ColumnType.emLabel;

		public GUIContent		headerContent			= new GUIContent();
		public string			strContextMenuText		= null;

		public TextAlignment	headerTextAlignment		= TextAlignment.Center;
		public TextAlignment	sortingArrowAlignment	= TextAlignment.Center;

		public float			fMinWidth				= 20f;
		public float			fMaxWidth				= 1000000f;
		public float			fWidth					= 80f;
		public bool				bAutoResize				= true;

		
		public bool				bAllowToggleVisibility	= true;

		public bool				bCanSort				= true;
		public bool				bSortedAscending		= false;//sort flag

		public object			exData					= null;

		public ColumnState(string strHeader, string tips, ColumnType type, float fWidth = -1, object exFn = null)
		{
			this.headerContent = EditorGUIUtility.TrTextContent(strHeader,tips);
			this.type = type;
			
			this.exData = exFn;
			this.fWidth = fWidth == -1 ? this.fWidth : fWidth;
		}
	}

	public class MultiColumnHeader : BaseView
	{
		public class MultiColumnState
		{
			public ColumnState[]	columns					= null;
			public int[]			visibleColumns			= null;
			public int				nSortedColumnIndex		= -1;

			public MultiColumnState(ColumnState[] columns)
			{
				this.columns	= columns;
				visibleColumns	= Enumerable.Range(0, columns.Length).ToArray();
			}

			public float widthOfAllVisibleColumns
			{
				get { return visibleColumns.Sum(t => columns[t].fWidth); }
			}
		}

		public MultiColumnState		state				= null;

		public float				fHeaderHeight		= 25.0f;
		public bool					isDraw				= true;
		public bool					bResizeToFit		= false;

		protected float				m_fDividerWidth		= 6;
		protected Rect				m_previousRect		= Rect.zero;
		protected Rect[]			m_columnRects		= null;
		protected bool				m_bCanSort			= false;

		public int					columnCount			=> state.columns.Length;
		public int					visibleColumnCount	=> state.visibleColumns.Length;

		public delegate void HeaderCallback(MultiColumnHeader multiColumnHeader);
		public event HeaderCallback sortingChanged;
		public event HeaderCallback visibleColumnsChanged;

		public MultiColumnHeader(ColumnState[] columns)
		{
			Debug.Assert(columns != null);
			this.state = new MultiColumnState(columns);
		}

		public void OnGUI(Rect rect, float fXScroll)
		{
			Event evt = Event.current;

			DetectSizeChanges(rect);

			if (bResizeToFit && evt.type == EventType.Repaint && rect.width > 0)
			{
				bResizeToFit = false;
				ResizeColumnsWidthsProportionally(rect.width - GUI.skin.verticalScrollbar.fixedWidth - state.widthOfAllVisibleColumns);
			}

			if (!isDraw)
				return;

			GUI.BeginClip(rect, new Vector2(-fXScroll, 0f), Vector2.zero, false);
			{
				Rect localRect = new Rect(0, 0, rect.width, rect.height);

				float fWidthOfAllColumns = state.widthOfAllVisibleColumns;
				float fBackgroundWidth = (localRect.width > fWidthOfAllColumns ? localRect.width : fWidthOfAllColumns) + GUI.skin.verticalScrollbar.fixedWidth;
				Rect backgroundRect = new Rect(0, 0, fBackgroundWidth, localRect.height);
				GUI.Label(backgroundRect, GUIContent.none, DefaultStyles.background);
				
				if (evt.type == EventType.ContextClick && backgroundRect.Contains(evt.mousePosition))
				{
					evt.Use();
					DoContextMenu();
				}

				UpdateColumnHeaderRects(localRect);

				for (int i = 0; i < state.visibleColumns.Length; i++)
				{
					int columnIndex = state.visibleColumns[i];
					ColumnState column = state.columns[columnIndex];
					Rect headerRect = m_columnRects[i];

					const float cfLimitHeightOfDivider = 4f;// dividers height between columns
					Rect dividerRect = new Rect(headerRect.xMax - 1, headerRect.y + cfLimitHeightOfDivider, 1f, headerRect.height - 2 * cfLimitHeightOfDivider);

					Rect dragRect = new Rect(dividerRect.x - m_fDividerWidth * 0.5f, localRect.y, m_fDividerWidth, localRect.height);
					
					column.fWidth = ToolGUIUtility.WidthResizer(dragRect, column.fWidth, column.fMinWidth, column.fMaxWidth, out bool bHasControl);
					if (bHasControl && evt.type == EventType.Repaint)
					{
						DrawColumnResizing(headerRect, column);
					}

					DrawDivider(dividerRect, column);
					ColumnHeaderGUI(column, headerRect, columnIndex);
				}
			}
			GUI.EndClip();
		}

		private void DrawColumnResizing(Rect headerRect, ColumnState column)
		{
			const float cfMargin = 1;
			headerRect.y += cfMargin;
			headerRect.width -= cfMargin;
			headerRect.height -= 2 * cfMargin;
			EditorGUI.DrawRect(headerRect, new Color(0.5f, 0.5f, 0.5f, 0.1f));
		}

		private void DrawDivider(Rect dividerRect, ColumnState column)
		{
			EditorGUI.DrawRect(dividerRect, new Color(0.5f, 0.5f, 0.5f, 0.5f));
		}

		private void ColumnHeaderGUI(ColumnState column, Rect headerRect, int columnIndex)
		{
			if (m_bCanSort && column.bCanSort)
			{
				SortingButton(column, headerRect, columnIndex);
			}

			GUIStyle style = GetColumnHeaderLabelStyle(column.headerTextAlignment);

			float labelHeight = DefaultGUI.columnHeaderLabelHeight;
			Rect labelRect = new Rect(headerRect.x, headerRect.yMax - labelHeight, headerRect.width, labelHeight);
			GUI.Label(labelRect, column.headerContent, style);
		}

		private GUIStyle GetColumnHeaderLabelStyle(TextAlignment alignment)
		{
			switch (alignment)
			{
				case TextAlignment.Left: return DefaultStyles.columnHeader;
				case TextAlignment.Center: return DefaultStyles.columnHeaderCenterAligned;
				case TextAlignment.Right: return DefaultStyles.columnHeaderRightAligned;
				default: return DefaultStyles.columnHeader;
			}
		}

		private void SortingButton(ColumnState column, Rect headerRect, int columnIndex)
		{
			// Button logic
			if (ToolGUIUtility.OnlyLeftButton(headerRect, GUIContent.none, GUIStyle.none))
			{
				ColumnHeaderClicked(column, columnIndex);
			}

			// Draw sorting arrow
			if (columnIndex == state.nSortedColumnIndex && Event.current.type == EventType.Repaint)
			{
				var arrowRect = GetArrowRect(column, headerRect);

				Matrix4x4 normalMatrix = GUI.matrix;
				if (column.bSortedAscending)
					GUIUtility.RotateAroundPivot(180, arrowRect.center - new Vector2(0, 1));

				GUI.Label(arrowRect, "\u25BE", DefaultStyles.arrowStyle);

				if (column.bSortedAscending)
					GUI.matrix = normalMatrix;
			}
		}

		private Rect GetArrowRect(ColumnState column, Rect headerRect)
		{
			float fSortingArrowWidth = DefaultStyles.arrowStyle.fixedWidth;
			float fArrowYPos = headerRect.y;
			float fArrowXPos = 0f;

			switch (column.sortingArrowAlignment)
			{
				case TextAlignment.Left:
					fArrowXPos = headerRect.x + DefaultStyles.columnHeader.padding.left;
					break;
				case TextAlignment.Center:
					fArrowXPos = headerRect.x + headerRect.width * 0.5f - fSortingArrowWidth * 0.5f;
					break;
				case TextAlignment.Right:
					fArrowXPos = headerRect.xMax - DefaultStyles.columnHeader.padding.right - fSortingArrowWidth;
					break;
				default:
					Debug.LogError("Unhandled enum");
					break;
			}

			Rect arrowRect = new Rect(Mathf.Round(fArrowXPos), fArrowYPos, fSortingArrowWidth, 16f);
			return arrowRect;
		}

		private void ColumnHeaderClicked(ColumnState column, int columnIndex)
		{
			if (state.nSortedColumnIndex == columnIndex)
				column.bSortedAscending = !column.bSortedAscending;
			else
				state.nSortedColumnIndex = columnIndex;

			OnSortingChanged();
		}

		private void OnSortingChanged()
		{
			if (sortingChanged != null)
				sortingChanged(this);
		}

		void UpdateColumnHeaderRects(Rect totalHeaderRect)
		{
			if (m_columnRects == null || m_columnRects.Length != state.visibleColumns.Length)
				m_columnRects = new Rect[state.visibleColumns.Length];

			Rect curRect = totalHeaderRect;
			for (int i = 0; i < state.visibleColumns.Length; ++i)
			{
				int columnIndex = state.visibleColumns[i];
				ColumnState column = state.columns[columnIndex];

				if (i > 0)
					curRect.x += curRect.width;
				curRect.width = column.fWidth;

				m_columnRects[i] = curRect;
			}
		}

		void DoContextMenu()
		{
			var menu = new GenericMenu();
			AddColumnHeaderContextMenuItems(menu);
			menu.ShowAsContext();
		}

		protected virtual void AddColumnHeaderContextMenuItems(GenericMenu menu)
		{
			menu.AddItem(EditorGUIUtility.TrTextContent("Resize to Fit"), false, ResizeToFit);

			menu.AddSeparator("");

			for (int i = 0; i < state.columns.Length; ++i)
			{
				var column = state.columns[i];
				var menuText = !string.IsNullOrEmpty(column.strContextMenuText) ? column.strContextMenuText : column.headerContent.text;
				if (column.bAllowToggleVisibility)
					menu.AddItem(new GUIContent(menuText), state.visibleColumns.Contains(i), ToggleVisibility, i);
				else
					menu.AddDisabledItem(new GUIContent(menuText));
			}
		}

		void ToggleVisibility(object userData)
		{
			ToggleVisibility((int)userData);
		}

		protected virtual void ToggleVisibility(int columnIndex)
		{
			var newVisibleColumns = new List<int>(state.visibleColumns);
			if (newVisibleColumns.Contains(columnIndex))
			{
				newVisibleColumns.Remove(columnIndex);
			}
			else
			{
				newVisibleColumns.Add(columnIndex);
				newVisibleColumns.Sort();
			}
			state.visibleColumns = newVisibleColumns.ToArray();
			Repaint();

			OnVisibleColumnsChanged();
		}

		protected virtual void OnVisibleColumnsChanged()
		{
			if (visibleColumnsChanged != null)
				visibleColumnsChanged(this);
		}

		public void ResizeToFit()
		{
			bResizeToFit = true;
			Repaint();
		}

		void DetectSizeChanges(Rect rect)
		{
			if (Event.current.type == EventType.Repaint)
			{
				if (m_previousRect.width > 0f)
				{
					float fDeltaWidth = Mathf.Round(rect.width - m_previousRect.width);
					if (fDeltaWidth != 0f)
					{
						float fTep = GUI.skin.verticalScrollbar.fixedWidth;
						bool bIsColumnsVisible = rect.width - fTep > state.widthOfAllVisibleColumns;
						if (bIsColumnsVisible || fDeltaWidth < 0f)
							ResizeColumnsWidthsProportionally(fDeltaWidth);
					}
				}
				m_previousRect = rect;
			}
		}

		void ResizeColumnsWidthsProportionally(float deltaWidth)
		{
			List<ColumnState> autoResizeColumns = null;
			foreach (int i in state.visibleColumns)
			{
				ColumnState column = state.columns[i];
				if (column.bAutoResize)
				{
					if (deltaWidth > 0f && column.fWidth >= column.fMaxWidth)
						continue;
					if (deltaWidth < 0f && column.fWidth <= column.fMinWidth)
						continue;

					if (autoResizeColumns == null)
						autoResizeColumns = new List<ColumnState>();

					autoResizeColumns.Add(column);
				}
			}

			if (autoResizeColumns == null)
				return;

			float fTotalAutoResizeWidth = autoResizeColumns.Sum(x => x.fWidth);

			foreach (var column in autoResizeColumns)
			{
				column.fWidth += deltaWidth * (column.fWidth / fTotalAutoResizeWidth);
				column.fWidth = Mathf.Clamp(column.fWidth, column.fMinWidth, column.fMaxWidth);
			}
		}
	}
}

