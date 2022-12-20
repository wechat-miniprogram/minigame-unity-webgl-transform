using UnityEngine;
using UnityEditor;


namespace BuildReportTool.Window.Screen
{
	public class Help : BaseScreen
	{
		public override string Name
		{
			get { return Labels.HELP_CATEGORY_LABEL; }
		}

		const int LABEL_LENGTH = 16000;

		public override void RefreshData(BuildInfo buildReport)
		{
			const string README_FILENAME = "README.txt";
			_readmeContents = BuildReportTool.Util.GetPackageFileContents(README_FILENAME);

			const string CHANGELOG_FILENAME = "VERSION.txt";
			_changelogContents = BuildReportTool.Util.GetPackageFileContents(CHANGELOG_FILENAME);


			if (_readmeContents.Length > LABEL_LENGTH)
			{
				_readmeContents = _readmeContents.Substring(0, LABEL_LENGTH);
			}

			if (_changelogContents.Length > LABEL_LENGTH)
			{
				_changelogContents = _changelogContents.Substring(0, LABEL_LENGTH);
			}

			if (_readmeGuiContent == null)
			{
				_readmeGuiContent = new GUIContent(_readmeContents);
			}

			if (_changelogGuiContent == null)
			{
				_changelogGuiContent = new GUIContent(_changelogContents);
			}
		}

		public override void DrawGUI(Rect position, BuildInfo buildReportToDisplay, AssetDependencies assetDependencies,
			out bool requestRepaint)
		{
			requestRepaint = false;

			GUI.SetNextControlName("BRT_HelpUnfocuser");
			GUI.TextField(new Rect(-100, -100, 10, 10), "");

			GUILayout.Space(10); // extra top padding

			GUILayout.BeginHorizontal();
			int newSelectedHelpIdx = GUILayout.SelectionGrid(_selectedHelpContentsIdx, _helpTypeLabels, 1);

			if (newSelectedHelpIdx != _selectedHelpContentsIdx)
			{
				GUI.FocusControl("BRT_HelpUnfocuser");
			}

			_selectedHelpContentsIdx = newSelectedHelpIdx;

			//GUILayout.Space((position.width - HELP_CONTENT_WIDTH) * 0.5f);

			if (_selectedHelpContentsIdx == HELP_TYPE_README_IDX)
			{
				_readmeScrollPos = GUILayout.BeginScrollView(
					_readmeScrollPos);

				float readmeHeight = GUI.skin.GetStyle(HELP_CONTENT_GUI_STYLE)
				                        .CalcHeight(_readmeGuiContent, HELP_CONTENT_WIDTH);

				EditorGUILayout.SelectableLabel(_readmeContents, HELP_CONTENT_GUI_STYLE,
					GUILayout.Width(HELP_CONTENT_WIDTH), GUILayout.Height(readmeHeight));

				GUILayout.EndScrollView();
			}
			else if (_selectedHelpContentsIdx == HELP_TYPE_CHANGELOG_IDX)
			{
				_changelogScrollPos = GUILayout.BeginScrollView(
					_changelogScrollPos);

				float changelogHeight = GUI.skin.GetStyle(HELP_CONTENT_GUI_STYLE)
				                           .CalcHeight(_changelogGuiContent, HELP_CONTENT_WIDTH);

				EditorGUILayout.SelectableLabel(_changelogContents, HELP_CONTENT_GUI_STYLE,
					GUILayout.Width(HELP_CONTENT_WIDTH), GUILayout.Height(changelogHeight));

				GUILayout.EndScrollView();
			}

			GUILayout.EndHorizontal();
		}


		int _selectedHelpContentsIdx = 0;
		const int HELP_TYPE_README_IDX = 0;
		const int HELP_TYPE_CHANGELOG_IDX = 1;


		const string HELP_CONTENT_GUI_STYLE = "label";
		const int HELP_CONTENT_WIDTH = 500;

		string[] _helpTypeLabels = new string[] {"Help (README)", "Version Changelog"};

		Vector2 _readmeScrollPos;
		string _readmeContents;
		float _readmeHeight;

		Vector2 _changelogScrollPos;
		string _changelogContents;
		float _changelogHeight;

		GUIContent _readmeGuiContent;
		GUIContent _changelogGuiContent;
	}
}