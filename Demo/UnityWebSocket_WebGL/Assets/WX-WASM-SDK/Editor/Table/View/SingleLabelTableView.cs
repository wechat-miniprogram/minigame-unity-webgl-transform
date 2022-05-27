using System;

namespace WeChatWASM.EditorTable
{
	public class SingleLabelTableView : TableView
	{
		public class SingleLabelTableViewItem : RowViewItem
		{
			public string strLabel = null;

			public override int depth => -1;
			public override int columnCount => 1;
			public override string keyValue => strLabel;

			public SingleLabelTableViewItem(int nId, string strLabel) : base(nId)
			{
				this.strLabel = strLabel;
			}

			override public dynamic GetData(int nColumn)
			{
				return strLabel;
			}

			override public void SetData(int nRow,int nColumn, dynamic data)
			{
				throw new NotImplementedException();
			}
		}

		public class SingleLabelTableViewData : TableViewData
		{
			private string[] strTypeLabel = null;
			public SingleLabelTableViewData(string[] strLabel) : base(null)
			{
				strTypeLabel = strLabel;
			}

			protected override RowViewItem GetViewDataRoot()
			{
				RootRowViewItem root = new RootRowViewItem(GetNewRowItemId());

				for (int nRow = 0; nRow < strTypeLabel.Length; ++nRow)
				{
					SingleLabelTableViewItem singleLabelTableViewItem = new SingleLabelTableViewItem(GetNewRowItemId(), strTypeLabel[nRow]);
					root.AddChild(singleLabelTableViewItem);
				}
				return root;
			}

			public override bool CanBeMultiSelected(RowViewItem item)
			{
				return false;
			}
		}

		public SingleLabelTableView(string[] strLabel) : base(new MultiColumnHeader(new ColumnState[] { new ColumnState("", "", ColumnType.emLabel, 200) }),
			new TableState(), new SingleLabelTableViewData(strLabel))
		{
			m_multiColumnHeader.isDraw = false;
			m_multiColumnHeader.bResizeToFit = true;
		}

		protected override void BeforeRowsGUI()
		{
			InitSelectionIfNeed();
			base.BeforeRowsGUI();
		}

		protected void InitSelectionIfNeed()
		{
			if (state.selectedIDs.Count == 0)
				SelectionClick(m_viewData.GetItem(0));
		}
	}
}
