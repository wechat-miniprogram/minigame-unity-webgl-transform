using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WeChatWASM.EditorTable
{
	public abstract class BaseView
	{
		protected BaseView m_parentView = null;

		public virtual void Repaint()
		{
			m_parentView?.Repaint();
		}

		public void InitView(BaseView view)
		{
			m_parentView = view;
		}
	}

	public class WindowView : BaseView
	{
		private EditorWindow editorWindow = null;

		public WindowView(EditorWindow editorWindow)
		{
			this.editorWindow = editorWindow;
		}

		public override void Repaint()
		{
			this.editorWindow.Repaint();
		}
	}
}
	
