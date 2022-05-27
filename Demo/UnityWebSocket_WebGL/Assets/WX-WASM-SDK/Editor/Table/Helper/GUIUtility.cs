using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WeChatWASM.EditorTable
{
	public static class ToolGUIUtility
	{
		static int ms_mouseDeltaReaderHash = "SceneToolMouseDeltaReader".GetHashCode();

		public static SkinnedColor splitLineSkinnedColor = new SkinnedColor(new Color(0.6f, 0.6f, 0.6f, 1.333f), new Color(0.12f, 0.12f, 0.12f, 1.333f));
		public class SkinnedColor
		{
			Color normalColor;
			Color proColor;

			public SkinnedColor(Color color, Color proColor)
			{
				normalColor = color;
				this.proColor = proColor;
			}

			public SkinnedColor(Color color)
			{
				normalColor = color;
				proColor = color;
			}

			public Color color
			{
				get { return EditorGUIUtility.isProSkin ? proColor : normalColor; }

				set
				{
					if (EditorGUIUtility.isProSkin)
						proColor = value;
					else
						normalColor = value;
				}
			}

			public static implicit operator Color(SkinnedColor colorSkin)
			{
				return colorSkin.color;
			}
		}

		public static float WidthResizer(Rect position, float width, float minWidth, float maxWidth, out bool hasControl)
		{
			return Resizer.Resize(position, width, minWidth, maxWidth, true, out hasControl);
		}

		internal static class Resizer
		{
			static float ms_startSize;
			static Vector2 ms_mouseDeltaReaderStartPos;

			internal static float Resize(Rect position, float size, float minSize, float maxSize, bool horizontal, out bool hasControl)
			{
				int id = EditorGUIUtility.GetControlID(ms_mouseDeltaReaderHash, FocusType.Passive, position);
				Event evt = Event.current;
				switch (evt.GetTypeForControl(id))
				{
					case EventType.MouseDown:
						if (GUIUtility.hotControl == 0 && position.Contains(evt.mousePosition) && evt.button == 0)
						{
							GUIUtility.hotControl = id;
							GUIUtility.keyboardControl = 0;
							ms_mouseDeltaReaderStartPos = evt.mousePosition;
							ms_startSize = size;
							evt.Use();
						}
						break;
					case EventType.MouseDrag:
						if (GUIUtility.hotControl == id)
						{
							evt.Use();
							Vector2 screenPos = evt.mousePosition;
							float delta = horizontal ? (screenPos - ms_mouseDeltaReaderStartPos).x : (screenPos - ms_mouseDeltaReaderStartPos).y;
							float newSize = ms_startSize + delta;
							if (newSize >= minSize && newSize <= maxSize)
								size = newSize;
							else
								size = Mathf.Clamp(newSize, minSize, maxSize);
						}
						break;
					case EventType.MouseUp:
						if (GUIUtility.hotControl == id && evt.button == 0)
						{
							GUIUtility.hotControl = 0;
							evt.Use();
						}
						break;
					case EventType.Repaint:
						var cursor = horizontal ? MouseCursor.SplitResizeLeftRight : MouseCursor.SplitResizeUpDown;
						EditorGUIUtility.AddCursorRect(position, cursor, id);
						break;
				}

				hasControl = GUIUtility.hotControl == id;
				return size;
			}
		}

		public static bool OnlyLeftButton(Rect position, GUIContent content)
		{
			return OnlyLeftButton(position, content, EditorStyles.miniButton);
		}

		public static bool OnlyLeftButton(Rect position, GUIContent content, GUIStyle style)
		{
			Event evt = Event.current;
			switch (evt.type)
			{
				case EventType.MouseDown:
				case EventType.MouseUp:
					if (evt.button != 0)
						return false;
					break;
			}

			return GUI.Button(position, content, style);
		}

		public static Rect DrawBorder(Rect rect)
		{
			return Border.Draw(rect);
		}

		internal static class Border
		{
			internal const float borderWidth = 1f;
			static public Rect Draw(Rect rect)
			{
				DrawOutline(rect, borderWidth, ToolGUIUtility.splitLineSkinnedColor);
				return new Rect(rect.x + borderWidth, rect.y + borderWidth, rect.width - 2 * borderWidth, rect.height - 2 * borderWidth);
			}

			static void DrawOutline(Rect rect, float size, Color color)
			{
				if (Event.current.type != EventType.Repaint)
					return;

				Color orgColor = GUI.color;
				GUI.color = GUI.color * color;
				GUI.DrawTexture(new Rect(rect.x, rect.y, rect.width, size), EditorGUIUtility.whiteTexture);
				GUI.DrawTexture(new Rect(rect.x, rect.yMax - size, rect.width, size), EditorGUIUtility.whiteTexture);
				GUI.DrawTexture(new Rect(rect.x, rect.y + 1, size, rect.height - 2 * size), EditorGUIUtility.whiteTexture);
				GUI.DrawTexture(new Rect(rect.xMax - size, rect.y + 1, size, rect.height - 2 * size), EditorGUIUtility.whiteTexture);

				GUI.color = orgColor;
			}
		}
	}
}
	
