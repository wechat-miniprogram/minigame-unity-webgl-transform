using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WeChatWASM.EditorTable
{
	public static class DefaultGUI
	{
		public static void Label(Rect rect, string label, bool selected, bool focused)
		{
			if (Event.current.type == EventType.Repaint)
				DefaultStyles.label.Draw(rect, new GUIContent(label), false, false, selected, focused);
		}

		public static float columnContentMargin => 4f;
		public static float columnHeaderLabelHeight => 21f;
		public static float windowToolbarHeight => 21f;

		public static float baseIndent => 2f;

		public static float indentWidth => 14f;
		public static float lineHeight => 18f;

		public static float topRowMargin => 0f;
	}

	public static class DefaultStyles
	{
		public static GUIStyle columnHeader = "MultiColumnHeader";
		public static GUIStyle columnHeaderRightAligned = "MultiColumnHeaderRight";
		public static GUIStyle columnHeaderCenterAligned = "MultiColumnHeaderCenter";
		public static GUIStyle background = "MultiColumnTopBar";
		public static GUIStyle arrowStyle = "MultiColumnArrow";

		public static GUIStyle foldout = "IN Foldout";
		public static GUIStyle insertion = "TV Insertion";
		public static GUIStyle toolbarButton = "ToolbarButton";
		public static GUIStyle lineStyle = "TV Line";
		public static GUIStyle lineBoldStyle = "TV LineBold";
		public static GUIStyle selectionStyle = "TV Selection";

		public static GUIStyle backgroundEven = "OL EntryBackEven";
		public static GUIStyle backgroundOdd = "OL EntryBackOdd";

		public static GUIStyle foldoutLabel;
		public static GUIStyle label;
		public static GUIStyle labelRightAligned;

		public static GUIStyle boldLabel;
		public static GUIStyle boldLabelRightAligned;

		static DefaultStyles()
		{
			foldoutLabel = new GUIStyle(lineStyle);
			foldoutLabel.padding.left = 0;

			label = new GUIStyle(foldoutLabel);
			label.padding.left = 2;
			label.padding.right = 2;

			labelRightAligned = new GUIStyle(label);
			labelRightAligned.alignment = TextAnchor.UpperRight;

			boldLabel = new GUIStyle(label);
			boldLabel.font = EditorStyles.boldLabel.font;
			boldLabel.fontStyle = EditorStyles.boldLabel.fontStyle;

			boldLabelRightAligned = new GUIStyle(boldLabel);
			boldLabelRightAligned.alignment = TextAnchor.UpperRight;
		}
	}
}
	
