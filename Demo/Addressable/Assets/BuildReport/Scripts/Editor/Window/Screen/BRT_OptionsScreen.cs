using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;


namespace BuildReportTool.Window.Screen
{
	public class Options : BaseScreen
	{
		public override string Name
		{
			get { return Labels.OPTIONS_CATEGORY_LABEL; }
		}

		string[] _saveTypeLabels;

		/// <summary>
		/// 0: always use configured file filters <br/>
		/// 1: use file filters embedded in opened build report, if available
		/// </summary>
		static readonly string[] FileFilterToUseType =
			{Labels.FILTER_GROUP_TO_USE_CONFIGURED_LABEL, Labels.FILTER_GROUP_TO_USE_EMBEDDED_LABEL};

		/// <summary>
		/// 0: mouse is hovering over icon <br/>
		/// 1: mouse is hovering over icon or label
		/// </summary>
		static readonly string[] ShowThumbnailOnHoverTypeLabels =
			{"Mouse is hovering over asset's icon", "Mouse is hovering over asset's icon or label"};

		/// <summary>
		/// 0: dedicated ping button before each asset <br/>
		/// 1: double-click on asset label will ping
		/// </summary>
		static readonly string[] AssetPingTypeLabels =
			{"Dedicated ping button before each asset", "Double-clicking on asset will ping"};

		/// <summary>
		/// 0: verbose <br/>
		/// 1: standard <br/>
		/// 2: minimal
		/// </summary>
		static readonly string[] AssetUsageLabelTypeLabels =
		{
			"Verbose\n(use words only)",
			"Standard\n(use arrows when possible, show any extra info with words)",
			"Minimal\n(use arrows only, don't show any extra info even if available)"
		};

		string OPEN_IN_FILE_BROWSER_OS_SPECIFIC_LABEL
		{
			get
			{
				if (BuildReportTool.Util.IsInWinOS)
					return Labels.OPEN_IN_FILE_BROWSER_WIN_LABEL;
				if (BuildReportTool.Util.IsInMacOS)
					return Labels.OPEN_IN_FILE_BROWSER_MAC_LABEL;

				return Labels.OPEN_IN_FILE_BROWSER_DEFAULT_LABEL;
			}
		}

		string SAVE_PATH_TYPE_PERSONAL_OS_SPECIFIC_LABEL
		{
			get
			{
				if (BuildReportTool.Util.IsInWinOS)
					return Labels.SAVE_PATH_TYPE_PERSONAL_WIN_LABEL;
				if (BuildReportTool.Util.IsInMacOS)
					return Labels.SAVE_PATH_TYPE_PERSONAL_MAC_LABEL;

				return Labels.SAVE_PATH_TYPE_PERSONAL_DEFAULT_LABEL;
			}
		}


		static readonly string[] CalculationTypeLabels =
		{
			Labels.CALCULATION_LEVEL_FULL_NAME,
			Labels.CALCULATION_LEVEL_NO_PREFAB_NAME,
			Labels.CALCULATION_LEVEL_NO_UNUSED_NAME,
			Labels.CALCULATION_LEVEL_MINIMAL_NAME
		};

		int _selectedCalculationLevelIdx;

		string CalculationLevelDescription
		{
			get
			{
				switch (_selectedCalculationLevelIdx)
				{
					case 0:
						return Labels.CALCULATION_LEVEL_FULL_DESC;
					case 1:
						return Labels.CALCULATION_LEVEL_NO_PREFAB_DESC;
					case 2:
						return Labels.CALCULATION_LEVEL_NO_UNUSED_DESC;
					case 3:
						return Labels.CALCULATION_LEVEL_MINIMAL_DESC;
				}

				return "";
			}
		}

		int GetCalculationLevelGuiIdxFromOptions()
		{
			if (BuildReportTool.Options.IsCurrentCalculationLevelAtFull)
			{
				return 0;
			}

			if (BuildReportTool.Options.IsCurrentCalculationLevelAtNoUnusedPrefabs)
			{
				return 1;
			}

			if (BuildReportTool.Options.IsCurrentCalculationLevelAtNoUnusedAssets)
			{
				return 2;
			}

			if (BuildReportTool.Options.IsCurrentCalculationLevelAtOverviewOnly)
			{
				return 3;
			}

			return 0;
		}

		void SetCalculationLevelFromGuiIdx(int selectedIdx)
		{
			switch (selectedIdx)
			{
				case 0:
					BuildReportTool.Options.SetCalculationLevelToFull();
					break;
				case 1:
					BuildReportTool.Options.SetCalculationLevelToNoUnusedPrefabs();
					break;
				case 2:
					BuildReportTool.Options.SetCalculationLevelToNoUnusedAssets();
					break;
				case 3:
					BuildReportTool.Options.SetCalculationLevelToOverviewOnly();
					break;
			}
		}


		Vector2 _assetListScrollPos;


		public override void RefreshData(BuildInfo buildReport)
		{
			if (_saveTypeLabels == null)
			{
				_saveTypeLabels = new[] {SAVE_PATH_TYPE_PERSONAL_OS_SPECIFIC_LABEL, Labels.SAVE_PATH_TYPE_PROJECT_LABEL};
			}

			_selectedCalculationLevelIdx = GetCalculationLevelGuiIdxFromOptions();
		}

		GUIStyle _linkStyle;
		GUIStyle _textBesideLinkStyle;

		public override void DrawGUI(Rect position, BuildInfo buildReportToDisplay, AssetDependencies assetDependencies,
			out bool requestRepaint)
		{
			requestRepaint = false;
			var prevEnabled = GUI.enabled;

			GUILayout.Space(10); // extra top padding


			_assetListScrollPos = GUILayout.BeginScrollView(_assetListScrollPos);

			GUILayout.BeginHorizontal();
			GUILayout.Space(20); // extra left padding
			GUILayout.BeginVertical();

			if (!string.IsNullOrEmpty(BuildReportTool.Options.FoundPathForSavedOptions))
			{
				GUILayout.BeginHorizontal(BuildReportTool.Window.Settings.BOXED_LABEL_STYLE_NAME);
				GUILayout.Label(string.Format("Using options file in: {0}",
					BuildReportTool.Options.FoundPathForSavedOptions));
				GUILayout.FlexibleSpace();
				if (GUILayout.Button("Reload"))
				{
					BuildReportTool.Options.RefreshOptions();
				}

				GUILayout.EndHorizontal();

				GUILayout.Space(10);
			}

			// === Main Options ===

			GUILayout.Label("Main Options", BuildReportTool.Window.Settings.INFO_TITLE_STYLE_NAME);


			BuildReportTool.Options.CollectBuildInfo = GUILayout.Toggle(BuildReportTool.Options.CollectBuildInfo,
				"Automatically generate and save a Build Report file after building (does not include batchmode builds)");
			GUILayout.BeginHorizontal();
			GUILayout.Space(20);
			GUILayout.Label(
				"Note: For batchmode builds, to create build reports, call BuildReportTool.ReportGenerator.CreateReport() after BuildPipeline.BuildPlayer() in your build scripts. The Build Report is automatically saved as an XML file.",
				BuildReportTool.Window.Settings.BOXED_LABEL_STYLE_NAME, GUILayout.MaxWidth(525));
			GUILayout.EndHorizontal();
			GUILayout.Space(10);

			BuildReportTool.Options.AutoShowWindowAfterNormalBuild = GUILayout.Toggle(
				BuildReportTool.Options.AutoShowWindowAfterNormalBuild,
				"Automatically show Build Report Window after building (if it is not open yet)");

			BuildReportTool.Options.AutoResortAssetsWhenUnityEditorRegainsFocus = GUILayout.Toggle(
				BuildReportTool.Options.AutoResortAssetsWhenUnityEditorRegainsFocus,
				"Re-sort assets automatically whenever the Unity Editor regains focus");

			BuildReportTool.Options.AllowDeletingOfUsedAssets = GUILayout.Toggle(
				BuildReportTool.Options.AllowDeletingOfUsedAssets,
				"Allow deleting of Used Assets (practice caution!)");

			GUILayout.Space(20);

			BuildReportTool.Options.UseThreadedReportGeneration = GUILayout.Toggle(
				BuildReportTool.Options.UseThreadedReportGeneration,
				"When generating Build Reports, use a separate thread");
			GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
			GUILayout.Space(20);
			GUILayout.Label(
				"Note: For batchmode builds, report generation with BuildReportTool.ReportGenerator.CreateReport() is always non-threaded.",
				BuildReportTool.Window.Settings.BOXED_LABEL_STYLE_NAME, GUILayout.MaxWidth(525));
			GUILayout.EndHorizontal();
			GUILayout.Space(10);

			BuildReportTool.Options.UseThreadedFileLoading = GUILayout.Toggle(
				BuildReportTool.Options.UseThreadedFileLoading,
				"When loading Build Report files, use a separate thread");

			//GUILayout.Space(20);

			GUILayout.Space(BuildReportTool.Window.Settings.CATEGORY_VERTICAL_SPACING);

			// === Data to include in the Build Report ===

			GUILayout.Label("Data to include in the Build Report", BuildReportTool.Window.Settings.INFO_TITLE_STYLE_NAME);

			BuildReportTool.Options.IncludeBuildSizeInReportCreation = GUILayout.Toggle(
				BuildReportTool.Options.IncludeBuildSizeInReportCreation,
				"Get build's file size upon creation of a build report");

			GUILayout.Space(10);

			//BuildReportTool.Options.GetImportedSizesForUsedAssets = GUILayout.Toggle(BuildReportTool.Options.GetImportedSizesForUsedAssets,
			//	"Get imported sizes of Used Assets upon creation of a build report");

			BuildReportTool.Options.GetImportedSizesForUnusedAssets = GUILayout.Toggle(
				BuildReportTool.Options.GetImportedSizesForUnusedAssets,
				"Get imported sizes of Unused Assets upon creation of a build report");

			BuildReportTool.Options.GetSizeBeforeBuildForUsedAssets = GUILayout.Toggle(
				BuildReportTool.Options.GetSizeBeforeBuildForUsedAssets,
				"Get size-before-build of Used Assets upon creation of a build report");


			BuildReportTool.Options.IncludeSvnInUnused =
				GUILayout.Toggle(BuildReportTool.Options.IncludeSvnInUnused, Labels.INCLUDE_SVN_LABEL);
			BuildReportTool.Options.IncludeGitInUnused =
				GUILayout.Toggle(BuildReportTool.Options.IncludeGitInUnused, Labels.INCLUDE_GIT_LABEL);

			GUILayout.Space(10);

			BuildReportTool.Options.GetProjectSettings = GUILayout.Toggle(BuildReportTool.Options.GetProjectSettings,
				"Get Unity project settings upon creation of a build report");

			GUILayout.Space(10);

			BuildReportTool.Options.CalculateAssetDependencies = GUILayout.Toggle(
				BuildReportTool.Options.CalculateAssetDependencies,
				"Calculate asset dependencies upon creation of a build report");

			BuildReportTool.Options.CalculateAssetDependenciesOnUnusedToo = GUILayout.Toggle(
				BuildReportTool.Options.CalculateAssetDependenciesOnUnusedToo,
				"Include Unused Assets in asset dependency calculations");

			GUILayout.Space(10);

			BuildReportTool.Options.ShowImportedSizeForUsedAssets = GUILayout.Toggle(
				BuildReportTool.Options.ShowImportedSizeForUsedAssets,
				"Show calculated sizes of Used Assets instead of reported sizes");

			if (_linkStyle == null)
			{
				_linkStyle = new GUIStyle(GUI.skin.label);
				_linkStyle.normal.textColor = new Color(0.266f, 0.533f, 1);
				_linkStyle.hover.textColor = new Color(0.118f, 0.396f, 1);
				_linkStyle.stretchWidth = false;
				_linkStyle.margin.bottom = 0;
				_linkStyle.padding.bottom = 0;
			}

			if (_textBesideLinkStyle == null)
			{
				_textBesideLinkStyle = new GUIStyle(GUI.skin.label);
				_textBesideLinkStyle.stretchWidth = false;
				_textBesideLinkStyle.margin.right = 0;
				_textBesideLinkStyle.padding.right = 0;
				_textBesideLinkStyle.margin.bottom = 0;
				_textBesideLinkStyle.padding.bottom = 0;
			}

			GUILayout.BeginHorizontal();
			GUILayout.Label("Note: This option is a workaround for the ", _textBesideLinkStyle);
			if (GUILayout.Button("Unity bug with Issue ID 885258", _linkStyle))
			{
				Application.OpenURL(
					"https://issuetracker.unity3d.com/issues/unity-reports-incorrect-textures-size-in-the-editor-dot-log-after-building-on-standalone");
			}

			GUILayout.EndHorizontal();
			GUILayout.Label(
				"This bug has already been fixed in Unity 2017.1, 5.5.3p1 and 5.6.0p1. Only enable this if you are affected by the bug.");

			GUILayout.Space(15);

			GUILayout.BeginHorizontal();
			GUILayout.Label("Calculation Level: ");

			GUILayout.BeginVertical();
			int newSelectedCalculationLevelIdx = EditorGUILayout.Popup(_selectedCalculationLevelIdx, CalculationTypeLabels,
				"Popup", GUILayout.Width(300));
			GUILayout.BeginHorizontal();
			GUILayout.Space(20);
			GUILayout.Label(CalculationLevelDescription, GUILayout.MaxWidth(500), GUILayout.MinHeight(75));
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(BuildReportTool.Window.Settings.CATEGORY_VERTICAL_SPACING);

			if (newSelectedCalculationLevelIdx != _selectedCalculationLevelIdx)
			{
				_selectedCalculationLevelIdx = newSelectedCalculationLevelIdx;
				SetCalculationLevelFromGuiIdx(newSelectedCalculationLevelIdx);
			}


			// === Editor Log File ===

			GUILayout.Label("Editor Log File", BuildReportTool.Window.Settings.INFO_TITLE_STYLE_NAME);

			// which Editor.log is used
			GUILayout.BeginHorizontal();
			GUILayout.Label(Labels.EDITOR_LOG_LABEL + BuildReportTool.Util.EditorLogPathOverrideMessage + ": " +
			                BuildReportTool.Util.UsedEditorLogPath);
			if (GUILayout.Button(OPEN_IN_FILE_BROWSER_OS_SPECIFIC_LABEL) && BuildReportTool.Util.UsedEditorLogExists)
			{
				BuildReportTool.Util.OpenInFileBrowser(BuildReportTool.Util.UsedEditorLogPath);
			}

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			if (!BuildReportTool.Util.UsedEditorLogExists)
			{
				if (BuildReportTool.Util.IsDefaultEditorLogPathOverridden)
				{
					GUILayout.Label(Labels.OVERRIDE_LOG_NOT_FOUND_MSG);
				}
				else
				{
					GUILayout.Label(Labels.DEFAULT_EDITOR_LOG_NOT_FOUND_MSG);
				}
			}

			// override which log is opened
			GUILayout.BeginHorizontal();
			if (GUILayout.Button(Labels.SET_OVERRIDE_LOG_LABEL))
			{
				string filepath = EditorUtility.OpenFilePanel(
					"", // title
					"", // default path
					""); // file type (only one type allowed?)

				if (!string.IsNullOrEmpty(filepath))
				{
					BuildReportTool.Options.EditorLogOverridePath = filepath;
				}
			}

			if (GUILayout.Button(Labels.CLEAR_OVERRIDE_LOG_LABEL))
			{
				BuildReportTool.Options.EditorLogOverridePath = "";
			}

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(BuildReportTool.Window.Settings.CATEGORY_VERTICAL_SPACING);


			// === Asset Lists ===

			GUILayout.Label("Asset Lists", BuildReportTool.Window.Settings.INFO_TITLE_STYLE_NAME);


			// top largest used
			GUILayout.BeginHorizontal();
			GUILayout.Label("Number of Top Largest Used Assets to display in Overview Tab:");
			string numberOfTopUsedInput =
				GUILayout.TextField(BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow.ToString(),
					GUILayout.MinWidth(100));
			numberOfTopUsedInput =
				Regex.Replace(numberOfTopUsedInput, @"[^0-9]", ""); // positive numbers only, no fractions
			if (string.IsNullOrEmpty(numberOfTopUsedInput))
			{
				numberOfTopUsedInput = "0";
			}

			BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow = int.Parse(numberOfTopUsedInput);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();


			// top largest unused
			GUILayout.BeginHorizontal();
			GUILayout.Label("Number of Top Largest Unused Assets to display in Overview Tab:");
			string numberOfTopUnusedInput =
				GUILayout.TextField(BuildReportTool.Options.NumberOfTopLargestUnusedAssetsToShow.ToString(),
					GUILayout.MinWidth(100));
			numberOfTopUnusedInput =
				Regex.Replace(numberOfTopUnusedInput, @"[^0-9]", ""); // positive numbers only, no fractions
			if (string.IsNullOrEmpty(numberOfTopUnusedInput))
			{
				numberOfTopUnusedInput = "0";
			}

			BuildReportTool.Options.NumberOfTopLargestUnusedAssetsToShow = int.Parse(numberOfTopUnusedInput);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();


			GUILayout.BeginHorizontal();
			GUILayout.Space(20);
			GUILayout.Label(
				"Note: To disable the display of Top Largest Assets, use a value of 0.",
				BuildReportTool.Window.Settings.BOXED_LABEL_STYLE_NAME, GUILayout.MaxWidth(525));
			GUILayout.EndHorizontal();

			GUILayout.Space(10);

			// pagination length
			GUILayout.BeginHorizontal();
			GUILayout.Label("View assets per groups of:");
			string pageInput = GUILayout.TextField(BuildReportTool.Options.AssetListPaginationLength.ToString(),
				GUILayout.MinWidth(100));
			pageInput = Regex.Replace(pageInput, @"[^0-9]", ""); // positive numbers only, no fractions
			if (string.IsNullOrEmpty(pageInput))
			{
				pageInput = "0";
			}

			BuildReportTool.Options.AssetListPaginationLength = int.Parse(pageInput);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(10);

			// unused assets entries per batch
			GUILayout.BeginHorizontal();
			GUILayout.Label("Process unused assets per batches of:");
			string entriesPerBatchInput =
				GUILayout.TextField(BuildReportTool.Options.UnusedAssetsEntriesPerBatch.ToString(),
					GUILayout.MinWidth(100));
			entriesPerBatchInput =
				Regex.Replace(entriesPerBatchInput, @"[^0-9]", ""); // positive numbers only, no fractions
			if (string.IsNullOrEmpty(entriesPerBatchInput))
			{
				entriesPerBatchInput = "0";
			}

			BuildReportTool.Options.UnusedAssetsEntriesPerBatch = int.Parse(entriesPerBatchInput);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();


			GUILayout.Space(10);

			// choose which file filter group to use
			GUILayout.BeginHorizontal();
			GUILayout.Label(Labels.FILTER_GROUP_TO_USE_LABEL);
			BuildReportTool.Options.FilterToUseInt = GUILayout.SelectionGrid(BuildReportTool.Options.FilterToUseInt,
				FileFilterToUseType, FileFilterToUseType.Length);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			// display which file filter group is used
			GUILayout.BeginHorizontal();
			GUILayout.Label(Labels.FILTER_GROUP_FILE_PATH_LABEL +
			                BuildReportTool
				                .FiltersUsed.GetProperFileFilterGroupToUseFilePath()); // display path to used file filter
			if (GUILayout.Button(OPEN_IN_FILE_BROWSER_OS_SPECIFIC_LABEL))
			{
				BuildReportTool.Util.OpenInFileBrowser(BuildReportTool.FiltersUsed.GetProperFileFilterGroupToUseFilePath());
			}

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(10);


			GUILayout.BeginHorizontal();
			GUILayout.Label("Asset Ping method:");
			BuildReportTool.Options.DoubleClickOnAssetWillPing = GUILayout.SelectionGrid(
				                                                     BuildReportTool.Options.DoubleClickOnAssetWillPing
					                                                     ? 1
					                                                     : 0,
				                                                     AssetPingTypeLabels, 2, GUILayout.Height(26)) == 1;
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Space(20);

			GUILayout.Label(
				BuildReportTool.Options.DoubleClickOnAssetWillPing
					? "Note: To ping multiple assets, select the assets, and hold Alt while double-clicking one of them."
					: "Note: To ping multiple assets, select the assets, and hold Alt while pressing one of their Ping buttons.",
				BuildReportTool.Window.Settings.BOXED_LABEL_STYLE_NAME, GUILayout.MaxWidth(593));

			GUILayout.EndHorizontal();

			GUILayout.Space(10);

			//AssetUsageLabelTypeLabels

			GUILayout.BeginHorizontal();
			GUILayout.Label("Asset usage labels:");
			BuildReportTool.Options.AssetUsageLabelType = GUILayout.SelectionGrid(
				BuildReportTool.Options.AssetUsageLabelType, AssetUsageLabelTypeLabels, 1);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(10);

			BuildReportTool.Options.ShowAssetPrimaryUsersInTooltipIfAvailable = GUILayout.Toggle(
				BuildReportTool.Options.ShowAssetPrimaryUsersInTooltipIfAvailable,
				"Show end users in asset tooltip (if available)");

			GUILayout.BeginHorizontal();
			GUILayout.Space(20);
			GUILayout.Label(
				"Note: \"End users\" are the scenes (or Resources assets) that use a given asset (directly or indirectly), they are the main reason why that asset got included in the build.",
				BuildReportTool.Window.Settings.BOXED_LABEL_STYLE_NAME, GUILayout.MaxWidth(525));
			GUILayout.EndHorizontal();

			GUILayout.Space(10);

			BuildReportTool.Options.ShowTooltipThumbnail = GUILayout.Toggle(
				BuildReportTool.Options.ShowTooltipThumbnail,
				"Show thumbnail in asset tooltip");

			GUI.enabled = prevEnabled && BuildReportTool.Options.ShowTooltipThumbnail;

			GUILayout.BeginHorizontal();
			GUILayout.Label("Show thumbnail when:");
			BuildReportTool.Options.ShowThumbnailOnHoverType = GUILayout.SelectionGrid(
				BuildReportTool.Options.ShowThumbnailOnHoverType, ShowThumbnailOnHoverTypeLabels,
				ShowThumbnailOnHoverTypeLabels.Length, GUILayout.Height(26));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();

			GUILayout.Label("Thumbnail Tooltip Width:");
			string tooltipThumbnailWidthInput =
				GUILayout.TextField(BuildReportTool.Options.TooltipThumbnailWidth.ToString(),
					GUILayout.MinWidth(100));
			tooltipThumbnailWidthInput =
				Regex.Replace(tooltipThumbnailWidthInput, @"[^0-9]", ""); // positive numbers only, no fractions
			if (string.IsNullOrEmpty(tooltipThumbnailWidthInput))
			{
				tooltipThumbnailWidthInput = "0";
			}

			BuildReportTool.Options.TooltipThumbnailWidth = int.Parse(tooltipThumbnailWidthInput);

			GUILayout.Space(3);

			GUILayout.Label("Height:");
			string tooltipThumbnailHeightInput =
				GUILayout.TextField(BuildReportTool.Options.TooltipThumbnailHeight.ToString(),
					GUILayout.MinWidth(100));
			tooltipThumbnailHeightInput =
				Regex.Replace(tooltipThumbnailHeightInput, @"[^0-9]", ""); // positive numbers only, no fractions
			if (string.IsNullOrEmpty(tooltipThumbnailHeightInput))
			{
				tooltipThumbnailHeightInput = "0";
			}

			BuildReportTool.Options.TooltipThumbnailHeight = int.Parse(tooltipThumbnailHeightInput);

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();


			GUILayout.BeginHorizontal();

			GUILayout.Label("Thumbnail Tooltip Zoomed-in Width:");
			string tooltipThumbnailZoomedInWidthInput =
				GUILayout.TextField(BuildReportTool.Options.TooltipThumbnailZoomedInWidth.ToString(),
					GUILayout.MinWidth(100));
			tooltipThumbnailZoomedInWidthInput =
				Regex.Replace(tooltipThumbnailZoomedInWidthInput, @"[^0-9]", ""); // positive numbers only, no fractions
			if (string.IsNullOrEmpty(tooltipThumbnailZoomedInWidthInput))
			{
				tooltipThumbnailZoomedInWidthInput = "0";
			}

			BuildReportTool.Options.TooltipThumbnailZoomedInWidth = int.Parse(tooltipThumbnailZoomedInWidthInput);

			GUILayout.Space(3);

			GUILayout.Label("Height:");
			string tooltipThumbnailZoomedInHeightInput =
				GUILayout.TextField(BuildReportTool.Options.TooltipThumbnailZoomedInHeight.ToString(),
					GUILayout.MinWidth(100));
			tooltipThumbnailZoomedInHeightInput =
				Regex.Replace(tooltipThumbnailZoomedInHeightInput, @"[^0-9]", ""); // positive numbers only, no fractions
			if (string.IsNullOrEmpty(tooltipThumbnailZoomedInHeightInput))
			{
				tooltipThumbnailZoomedInHeightInput = "0";
			}

			BuildReportTool.Options.TooltipThumbnailZoomedInHeight = int.Parse(tooltipThumbnailZoomedInHeightInput);

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUI.enabled = prevEnabled;

			GUILayout.BeginHorizontal();
			GUILayout.Space(20);
			GUILayout.Label(
				"Note: Hold Ctrl while a thumbnail tooltip is shown to zoom-in.",
				BuildReportTool.Window.Settings.BOXED_LABEL_STYLE_NAME, GUILayout.MaxWidth(525));
			GUILayout.EndHorizontal();


			GUILayout.Space(BuildReportTool.Window.Settings.CATEGORY_VERTICAL_SPACING);


			// === Build Report Files ===

			GUILayout.Label("Build Report Files", BuildReportTool.Window.Settings.INFO_TITLE_STYLE_NAME);

			// build report files save path
			GUILayout.BeginHorizontal();
			GUILayout.Label(Labels.SAVE_PATH_LABEL + BuildReportTool.Options.BuildReportSavePath);
			if (GUILayout.Button(OPEN_IN_FILE_BROWSER_OS_SPECIFIC_LABEL))
			{
				BuildReportTool.Util.OpenInFileBrowser(BuildReportTool.Options.BuildReportSavePath);
			}

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			// change name of build reports folder
			GUILayout.BeginHorizontal();
			GUILayout.Label(Labels.SAVE_FOLDER_NAME_LABEL);
			BuildReportTool.Options.BuildReportFolderName =
				GUILayout.TextField(BuildReportTool.Options.BuildReportFolderName, GUILayout.MinWidth(250));
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			// where to save build reports (my docs/home, or beside project)
			GUILayout.BeginHorizontal();
			GUILayout.Label(Labels.SAVE_PATH_TYPE_LABEL);

			if (_saveTypeLabels == null)
			{
				_saveTypeLabels = new[]
					{SAVE_PATH_TYPE_PERSONAL_OS_SPECIFIC_LABEL, Labels.SAVE_PATH_TYPE_PROJECT_LABEL};
			}

			BuildReportTool.Options.SaveType = GUILayout.SelectionGrid(BuildReportTool.Options.SaveType, _saveTypeLabels,
				_saveTypeLabels.Length);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(BuildReportTool.Window.Settings.CATEGORY_VERTICAL_SPACING);


			GUILayout.EndVertical();
			GUILayout.Space(20); // extra right padding
			GUILayout.EndHorizontal();

			GUILayout.EndScrollView();

			//if (BuildReportTool.Options.SaveType == BuildReportTool.Options.SAVE_TYPE_PERSONAL)
			//{
			// changed to user's personal folder
			//BuildReportTool.ReportGenerator.ChangeSavePathToUserPersonalFolder();
			//}
			//else if (BuildReportTool.Options.SaveType == BuildReportTool.Options.SAVE_TYPE_PROJECT)
			//{
			// changed to project folder
			//BuildReportTool.ReportGenerator.ChangeSavePathToProjectFolder();
			//}
		}
	}
}