using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WeChatWASM.EditorTable
{
	public abstract class RowViewItem
	{
		protected int					m_nId			= 0;
		protected int					m_nDepth		= -1;
		protected List<RowViewItem>		m_children		= null;
		protected RowViewItem			m_parent		= null;

		public virtual bool				hasChildren		=> m_children != null && m_children.Count > 0;
		public abstract string keyValue { get; }
		public abstract int columnCount { get; }
		public virtual int id { get { return m_nId; } set { m_nId = value; } }
		public virtual int depth { get { return m_nDepth; } set { m_nDepth = value; } }
		public virtual List<RowViewItem> children { get { return m_children; } set { m_children = value; } }
		public virtual RowViewItem parent { get { return m_parent; } set { m_parent = value; } }

		public RowViewItem(int nId)
		{
			m_nId = nId;
		}

		public void AddChild(RowViewItem child, int nIdx = -1)
		{
			if (m_children == null)
				m_children = new List<RowViewItem>();

			m_children.Insert(nIdx == -1 ? m_children.Count : nIdx, child);

			if (child != null)
				child.m_parent = this;
		}

		public void RemoveChild(RowViewItem child)
		{
			if (child != null)
				child.m_parent = null;

			if (m_children != null)
				m_children.Remove(child);
		}

		abstract public dynamic GetData(int nColumn);
		abstract public void SetData(int row, int nColumn, dynamic data);
	}

	public class RootRowViewItem : RowViewItem
	{
		public override int depth => -1;
		public override int columnCount => 1;
		public override string keyValue => "";

		public RootRowViewItem(int nId) : base(nId)
		{
			
		}

		override public dynamic GetData(int nColumn)
		{
			throw new NotImplementedException();
		}

		override public void SetData(int row, int nColumn, dynamic data)
		{
			throw new NotImplementedException();
		}
	}

	class RowViewItemAlphaNumericSort : IComparer<RowViewItem>
	{
		public int Compare(RowViewItem lhs, RowViewItem rhs)
		{
			if (lhs == rhs) return 0;
			if (lhs == null) return -1;
			if (rhs == null) return 1;

			return string.Compare(lhs.keyValue, rhs.keyValue);
		}
	}
}

