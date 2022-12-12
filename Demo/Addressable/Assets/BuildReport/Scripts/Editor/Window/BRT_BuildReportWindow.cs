//#define BRT_SHOW_MINOR_WARNINGS

#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading;
using BuildReportTool;
using BuildReportTool.Window;


namespace BuildReportTool
{
	public static class GUISkinUtility
	{
		public static bool HasStyle(this GUISkin me, string styleName)
		{
			return Array.Find(me.customStyles,
				       style => style.name.Equals(styleName, StringComparison.OrdinalIgnoreCase)) != null;
		}
	}
}

// can't put this in a namespace since older versions of Unity doesn't allow that
public class BRT_BuildReportWindow : EditorWindow
{
	const int ICON_WIDTH = 16;
	public const int ICON_WIDTH_WITH_PADDING = 20;
	public const int LIST_HEIGHT = 20;

	public static Vector2 IconSize = new Vector2(15, 15);

	public static readonly GUILayoutOption[] LayoutNone = new GUILayoutOption[] { };

	public static readonly GUILayoutOption[] LayoutListHeight =
		new[] {GUILayout.Height(LIST_HEIGHT)};

	public static readonly GUILayoutOption[] LayoutListHeightContractWidth =
		new[] {GUILayout.ExpandWidth(false), GUILayout.Height(LIST_HEIGHT)};

	public static readonly GUILayoutOption[] LayoutListHeightMinWidth90 =
		new[] {GUILayout.MinWidth(90), GUILayout.Height(LIST_HEIGHT)};

	public static readonly GUILayoutOption[] LayoutHeight21 = new[] {GUILayout.Height(21)};
	public static readonly GUILayoutOption[] LayoutMinWidth200 = new[] {GUILayout.MinWidth(200)};
	public static readonly GUILayoutOption[] LayoutPingButton = new[] {GUILayout.Width(37)};
	public static readonly GUILayoutOption[] LayoutIconWidth = new[] {GUILayout.Width(ICON_WIDTH)};

	public static readonly GUILayoutOption[] LayoutExpandButton = new GUILayoutOption[] {GUILayout.Width(150)};

	void OnDisable()
	{
		ForceStopFileLoadThread();
		IsOpen = false;
	}

	void OnFocus()
	{
		if (BuildReportTool.Options.AutoResortAssetsWhenUnityEditorRegainsFocus)
		{
			_usedAssetsScreen.RefreshData(_buildInfo);
			_unusedAssetsScreen.RefreshData(_buildInfo);

			// check if configured file filters changed and only then do we need to recategorize

			if (BuildReportTool.Options.ShouldUseConfiguredFileFilters())
			{
				RecategorizeDisplayedBuildInfo();
			}
		}
	}

	void OnEnable()
	{
		//Debug.Log("BuildReportWindow.OnEnable() " + System.DateTime.Now);

#if UNITY_5_6_OR_NEWER
		wantsMouseEnterLeaveWindow = true;
#endif
		wantsMouseMove = true;

		IsOpen = true;

		InitGUISkin();


		if (BuildReportTool.Util.BuildInfoHasContents(_buildInfo))
		{
			//Debug.Log("recompiled " + _buildInfo.SavedPath);
			if (!string.IsNullOrEmpty(_buildInfo.SavedPath))
			{
				BuildReportTool.BuildInfo loadedBuild = BuildReportTool.Util.OpenSerializedBuildInfo(_buildInfo.SavedPath);
				if (BuildReportTool.Util.BuildInfoHasContents(loadedBuild))
				{
					_buildInfo = loadedBuild;
				}
			}
			else
			{
				if (_buildInfo.HasUsedAssets)
				{
					_buildInfo.UsedAssets.AssignPerCategoryList(
						BuildReportTool.ReportGenerator.SegregateAssetSizesPerCategory(_buildInfo.UsedAssets.All,
							_buildInfo.FileFilters));
				}

				if (_buildInfo.HasUnusedAssets)
				{
					_buildInfo.UnusedAssets.AssignPerCategoryList(
						BuildReportTool.ReportGenerator.SegregateAssetSizesPerCategory(_buildInfo.UnusedAssets.All,
							_buildInfo.FileFilters));
				}
			}
		}

		// lol wtf have I done
		_usedAssetsScreen.SetListToDisplay(BuildReportTool.Window.Screen.AssetList.ListToDisplay.UsedAssets);
		_unusedAssetsScreen.SetListToDisplay(BuildReportTool.Window.Screen.AssetList.ListToDisplay.UnusedAssets);

		_overviewScreen.RefreshData(_buildInfo);
		_buildSettingsScreen.RefreshData(_buildInfo);
		_sizeStatsScreen.RefreshData(_buildInfo);
		_usedAssetsScreen.RefreshData(_buildInfo);
		_unusedAssetsScreen.RefreshData(_buildInfo);

		_optionsScreen.RefreshData(_buildInfo);
		_helpScreen.RefreshData(_buildInfo);
	}

	double _lastTime;

	void OnInspectorUpdate()
	{
		var deltaTime = EditorApplication.timeSinceStartup - _lastTime;
		_lastTime = EditorApplication.timeSinceStartup;

		if (IsInUsedAssetsCategory)
		{
			_usedAssetsScreen.Update(EditorApplication.timeSinceStartup, deltaTime, _buildInfo, _assetDependencies);
		}
		else if (IsInUnusedAssetsCategory)
		{
			_unusedAssetsScreen.Update(EditorApplication.timeSinceStartup, deltaTime, _buildInfo, _assetDependencies);
		}

		if (_buildInfo != null && BuildReportTool.ReportGenerator.IsFinishedGettingValues)
		{
			OnFinishGeneratingBuildReport();
		}

		// if Unity Editor has finished making a build and we are scheduled to create a Build Report...
		if (BuildReportTool.Util.ShouldGetBuildReportNow &&
		    !BuildReportTool.ReportGenerator.IsStillGettingValues &&
		    !EditorApplication.isCompiling)
		{
			//Debug.Log("BuildReportWindow getting build info right after the build... " + System.DateTime.Now);
			Refresh();
		}

		if (_finishedOpeningFromThread)
		{
			OnFinishOpeningBuildReportFile();
		}
	}

	void Update()
	{
		if (_buildInfo != null)
		{
			if (_buildInfo.RequestedToRefresh)
			{
				Repaint();
				_buildInfo.FlagFinishedRefreshing();
			}
		}
	}

	// ==========================================================================================
	// sub-screens

	readonly BuildReportTool.Window.Screen.Overview _overviewScreen = new BuildReportTool.Window.Screen.Overview();

	readonly BuildReportTool.Window.Screen.BuildSettings _buildSettingsScreen =
		new BuildReportTool.Window.Screen.BuildSettings();

	readonly BuildReportTool.Window.Screen.SizeStats _sizeStatsScreen = new BuildReportTool.Window.Screen.SizeStats();
	readonly BuildReportTool.Window.Screen.AssetList _usedAssetsScreen = new BuildReportTool.Window.Screen.AssetList();
	readonly BuildReportTool.Window.Screen.AssetList _unusedAssetsScreen = new BuildReportTool.Window.Screen.AssetList();

	readonly BuildReportTool.Window.Screen.Options _optionsScreen = new BuildReportTool.Window.Screen.Options();
	readonly BuildReportTool.Window.Screen.Help _helpScreen = new BuildReportTool.Window.Screen.Help();


	// ==========================================================================================


	public static string GetValueMessage { set; get; }

	static bool _loadingValuesFromThread;

	public static bool LoadingValuesFromThread
	{
		get { return _loadingValuesFromThread; }
	}

	static bool _noGuiSkinFound;

	/// <summary>
	/// The Build Report we're displaying.
	/// </summary>
	static BuildReportTool.BuildInfo _buildInfo;

	/// <summary>
	/// The Asset Dependencies data being used
	/// for whichever Build Report is displayed.
	/// </summary>
	static BuildReportTool.AssetDependencies _assetDependencies;

	public const bool FORCE_USE_DARK_SKIN = false;

	GUISkin _usedSkin = null;

	public static bool IsOpen { get; set; }

	public static bool ZoomedInThumbnails { get; set; }
	public static bool ShowThumbnailsWithAlphaBlend { get; set; }

	static Vector2 _lastMousePos;
	static bool _lastMouseMoved;

	public enum AssetInfoType
	{
		None,
		InStreamingAssetsFolder,
		InAPackage,
		InAResourcesFolder,
		ASceneInBuild,
	}

	/// <summary>
	/// Rect of whatever asset is hovered on
	/// </summary>
	public static Rect HoveredAssetEntryRect;

	/// <summary>
	/// Asset path of whatever asset is hovered
	/// </summary>
	public static string HoveredAssetEntryPath;

	public static readonly List<GUIContent> HoveredAssetEndUsers = new List<GUIContent>();

	public static void UpdateHoveredAsset(string hoveredAssetPath, Rect hoveredAssetRect, bool showingUsedAssets,
		BuildInfo buildReportToDisplay, AssetDependencies assetDependencies)
	{
		var alreadyUsingSameAssetPath =
			hoveredAssetPath.Equals(HoveredAssetEntryPath, StringComparison.OrdinalIgnoreCase);

		if (!alreadyUsingSameAssetPath)
		{
			HoveredAssetEntryPath = hoveredAssetPath;
		}

		// even if the new hovered asset to assign is the same as the current one,
		// its rect might have moved, so we always assign it
		HoveredAssetEntryRect = hoveredAssetRect;

		if (BuildReportTool.Options.ShowAssetPrimaryUsersInTooltipIfAvailable && !alreadyUsingSameAssetPath)
		{
			UpdateHoveredAssetType(hoveredAssetPath, showingUsedAssets);

			if (HoveredAssetIsASceneInBuild)
			{
				UpdateSceneInBuildLabel(SceneIsInBuildLabel,
					buildReportToDisplay.ScenesInBuild, HoveredAssetEntryPath);
			}

			AssignHoveredAssetEndUsers(assetDependencies);
		}
	}

	public static void UpdateSceneInBuildLabel(GUIContent destination, BuildInfo.SceneInBuild[] scenesInBuild,
		string scenePath)
	{
		var foundSceneInBuild = false;
		for (int sceneN = 0, sceneLen = scenesInBuild.Length; sceneN < sceneLen; ++sceneN)
		{
			if (scenesInBuild[sceneN].Path.Equals(scenePath, StringComparison.OrdinalIgnoreCase))
			{
				destination.text = string.Format(SCENE_IN_BUILD_LABEL_WITH_INDEX_FORMAT, sceneN.ToString());
				foundSceneInBuild = true;
				break;
			}
		}

		if (!foundSceneInBuild)
		{
			// This doesn't make sense though. If we're showing used assets,
			// the scene *should* be in the ScenesInBuild array.
			//
			// One possibility is that the user might have had a custom build script
			// that was manipulating the values in UnityEditor.EditorBuildSettings.scenes
			// after Build Report generation recorded it into the ScenesInBuild array.
			//
			destination.text = SCENE_IN_BUILD_LABEL;
		}
	}

	static List<GUIContent> GetEndUserLabelsFor(AssetDependencies assetDependencies, string assetPath)
	{
		if (string.IsNullOrEmpty(assetPath))
		{
			return null;
		}

		List<GUIContent> endUsersListToUse = null;

		var dependencies = assetDependencies.GetAssetDependencies();
		if (dependencies.ContainsKey(assetPath))
		{
			var entry = dependencies[assetPath];
			if (entry != null)
			{
				endUsersListToUse = entry.GetEndUserLabels();
			}
		}

		return endUsersListToUse;
	}

	static void AssignHoveredAssetEndUsers(AssetDependencies assetDependencies)
	{
		BuildReportTool.AssetDependencies.PopulateAssetEndUsers(HoveredAssetEntryPath, assetDependencies);
	}

	static AssetInfoType _hoveredAssetType = AssetInfoType.None;

	static void UpdateHoveredAssetType(string hoveredAssetPath, bool showingUsedAssets)
	{
		if (hoveredAssetPath.IsInStreamingAssetsFolder())
		{
			_hoveredAssetType = AssetInfoType.InStreamingAssetsFolder;
		}
		else if (hoveredAssetPath.IsInPackagesFolder())
		{
			_hoveredAssetType = AssetInfoType.InAPackage;
		}
		else if (hoveredAssetPath.IsInResourcesFolder())
		{
			_hoveredAssetType = AssetInfoType.InAResourcesFolder;
		}
		else if (hoveredAssetPath.IsSceneFile() && showingUsedAssets)
		{
			_hoveredAssetType = AssetInfoType.ASceneInBuild;
		}
		else
		{
			_hoveredAssetType = AssetInfoType.None;
		}
	}

	public static bool HoveredAssetIsASceneInBuild
	{
		get { return _hoveredAssetType == AssetInfoType.ASceneInBuild; }
	}

	public static bool ShouldHoveredAssetShowEndUserTooltip(AssetDependencies assetDependencies)
	{
		if (_hoveredAssetType != AssetInfoType.None)
		{
			return true;
		}

		List<GUIContent> endUsersListToUse = GetEndUserLabelsFor(assetDependencies, HoveredAssetEntryPath);

		return endUsersListToUse != null && endUsersListToUse.Count > 0;
	}

	public static GUIContent GetAppropriateEndUserLabelForHovered()
	{
		switch (_hoveredAssetType)
		{
			case AssetInfoType.InAPackage:
				return InPackagesLabel;

			case AssetInfoType.InStreamingAssetsFolder:
				return InStreamingAssetsLabel;

			case AssetInfoType.InAResourcesFolder:
			{
				if (HoveredAssetEndUsers.Count > 0)
				{
					return AResourcesAssetButAlsoUsedByLabel;
				}
				else
				{
					return AResourcesAssetLabel;
				}
			}

			case AssetInfoType.ASceneInBuild:
				return SceneIsInBuildLabel;

			default:
				return UsedByLabel;
		}
	}

	/// <summary>
	/// "Used by:"
	/// </summary>
	static readonly GUIContent UsedByLabel = new GUIContent("Used by:");

	/// <summary>
	/// "Asset is in a Resources folder"
	/// </summary>
	static readonly GUIContent AResourcesAssetLabel = new GUIContent("Asset is in a Resources folder");

	/// <summary>
	/// "Asset is in the StreamingAssets folder"
	/// </summary>
	static readonly GUIContent InStreamingAssetsLabel = new GUIContent("File is in the StreamingAssets folder");

	/// <summary>
	/// "A Resources asset, but also used by:"
	/// </summary>
	static readonly GUIContent AResourcesAssetButAlsoUsedByLabel =
		new GUIContent("A Resources asset, but also used by:");

	/// <summary>
	/// "Scene is in build"
	/// </summary>
	public static readonly GUIContent SceneIsInBuildLabel = new GUIContent("Scene is in build");

	const string SCENE_IN_BUILD_LABEL_WITH_INDEX_FORMAT = "Scene is in build at index <b>{0}</b>";
	const string SCENE_IN_BUILD_LABEL = "Scene is in build";

	static readonly GUIContent InPackagesLabel = new GUIContent("Asset is from the Packages folder");


	Texture2D _toolbarIconLog;
	Texture2D _toolbarIconOpen;
	Texture2D _toolbarIconSave;
	Texture2D _toolbarIconOptions;
	Texture2D _toolbarIconHelp;


	GUIContent _toolbarLabelLog;
	GUIContent _toolbarLabelOpen;
	GUIContent _toolbarLabelSave;
	GUIContent _toolbarLabelOptions;
	GUIContent _toolbarLabelHelp;


	void RecategorizeDisplayedBuildInfo()
	{
		if (BuildReportTool.Util.BuildInfoHasContents(_buildInfo))
		{
			BuildReportTool.ReportGenerator.RecategorizeAssetList(_buildInfo);
		}
	}


	void InitGUISkin()
	{
		string guiSkinToUse;
		if (EditorGUIUtility.isProSkin || FORCE_USE_DARK_SKIN)
		{
			guiSkinToUse = BuildReportTool.Window.Settings.DARK_GUI_SKIN_FILENAME;
		}
		else
		{
			guiSkinToUse = BuildReportTool.Window.Settings.DEFAULT_GUI_SKIN_FILENAME;
		}

		// try default path
		_usedSkin = AssetDatabase.LoadAssetAtPath(
			            string.Format("{0}/GUI/{1}", BuildReportTool.Options.BUILD_REPORT_TOOL_DEFAULT_PATH, guiSkinToUse),
			            typeof(GUISkin)) as GUISkin;

		if (_usedSkin == null)
		{
#if BRT_SHOW_MINOR_WARNINGS
			Debug.LogWarning(BuildReportTool.Options.BUILD_REPORT_PACKAGE_MOVED_MSG);
#endif

			string folderPath = BuildReportTool.Util.FindAssetFolder(Application.dataPath,
				BuildReportTool.Options.BUILD_REPORT_TOOL_DEFAULT_FOLDER_NAME);
			if (!string.IsNullOrEmpty(folderPath))
			{
				folderPath = folderPath.Replace('\\', '/');
				int assetsIdx = folderPath.IndexOf("/Assets/", StringComparison.OrdinalIgnoreCase);
				if (assetsIdx != -1)
				{
					folderPath = folderPath.Substring(assetsIdx + 8, folderPath.Length - assetsIdx - 8);
				}
				//Debug.Log(folderPath);

				_usedSkin = AssetDatabase.LoadAssetAtPath(string.Format("Assets/{0}/GUI/{1}", folderPath, guiSkinToUse),
					            typeof(GUISkin)) as GUISkin;
			}
			else
			{
				Debug.LogError(BuildReportTool.Options.BUILD_REPORT_PACKAGE_MISSING_MSG);
			}

			//Debug.Log("_usedSkin " + (_usedSkin != null));
		}

		if (_usedSkin != null)
		{
			// weirdo enum labels used to get either light or dark skin
			// (https://forum.unity.com/threads/editorguiutility-getbuiltinskin-not-working-correctly-in-unity-4-3.211504/#post-1430038)
			GUISkin nativeSkin =
				EditorGUIUtility.GetBuiltinSkin(EditorGUIUtility.isProSkin ? EditorSkin.Scene : EditorSkin.Inspector);

			if (!(EditorGUIUtility.isProSkin || FORCE_USE_DARK_SKIN))
			{
				_usedSkin.verticalScrollbar = nativeSkin.verticalScrollbar;
				_usedSkin.verticalScrollbarThumb = nativeSkin.verticalScrollbarThumb;
				_usedSkin.verticalScrollbarUpButton = nativeSkin.verticalScrollbarUpButton;
				_usedSkin.verticalScrollbarDownButton = nativeSkin.verticalScrollbarDownButton;

				_usedSkin.horizontalScrollbar = nativeSkin.horizontalScrollbar;
				_usedSkin.horizontalScrollbarThumb = nativeSkin.horizontalScrollbarThumb;
				_usedSkin.horizontalScrollbarLeftButton = nativeSkin.horizontalScrollbarLeftButton;
				_usedSkin.horizontalScrollbarRightButton = nativeSkin.horizontalScrollbarRightButton;

				// change the toggle skin to use the Unity builtin look, but keep our settings
				GUIStyle toggleSaved = new GUIStyle(_usedSkin.toggle);

				// make our own copy of the native skin toggle so that editing it won't affect the rest of the editor GUI
				GUIStyle nativeToggleCopy = new GUIStyle(nativeSkin.toggle);

				_usedSkin.toggle = nativeToggleCopy;
				_usedSkin.toggle.border = toggleSaved.border;
				_usedSkin.toggle.margin = toggleSaved.margin;
				_usedSkin.toggle.padding = toggleSaved.padding;
				_usedSkin.toggle.overflow = toggleSaved.overflow;
				_usedSkin.toggle.contentOffset = toggleSaved.contentOffset;

				_usedSkin.box = nativeSkin.box;
				_usedSkin.label = nativeSkin.label;
				_usedSkin.textField = nativeSkin.textField;
				_usedSkin.button = nativeSkin.button;

				_usedSkin.label.wordWrap = true;
			}

			// ----------------------------------------------------
			// Add styles we need

			var hasBreadcrumbLeftStyle = _usedSkin.HasStyle("GUIEditor.BreadcrumbLeft");
			var hasBreadcrumbMidStyle = _usedSkin.HasStyle("GUIEditor.BreadcrumbMid");

			if (!hasBreadcrumbLeftStyle || !hasBreadcrumbMidStyle)
			{
				var newStyles = new List<GUIStyle>(_usedSkin.customStyles);

				if (!hasBreadcrumbLeftStyle)
				{
					newStyles.Add(nativeSkin.GetStyle("GUIEditor.BreadcrumbLeft"));
				}

				if (!hasBreadcrumbMidStyle)
				{
					newStyles.Add(nativeSkin.GetStyle("GUIEditor.BreadcrumbMid"));
				}

				_usedSkin.customStyles = newStyles.ToArray();
			}

			// ----------------------------------------------------

			_toolbarIconLog = _usedSkin.GetStyle("Icon-Toolbar-Log").normal.background;
			_toolbarIconOpen = _usedSkin.GetStyle("Icon-Toolbar-Open").normal.background;
			_toolbarIconSave = _usedSkin.GetStyle("Icon-Toolbar-Save").normal.background;
			_toolbarIconOptions = _usedSkin.GetStyle("Icon-Toolbar-Options").normal.background;
			_toolbarIconHelp = _usedSkin.GetStyle("Icon-Toolbar-Help").normal.background;

			_toolbarLabelLog = new GUIContent(Labels.REFRESH_LABEL, _toolbarIconLog);
			_toolbarLabelOpen = new GUIContent(Labels.OPEN_LABEL, _toolbarIconOpen);
			_toolbarLabelSave = new GUIContent(Labels.SAVE_LABEL, _toolbarIconSave);
			_toolbarLabelOptions = new GUIContent(Labels.OPTIONS_CATEGORY_LABEL, _toolbarIconOptions);
			_toolbarLabelHelp = new GUIContent(Labels.HELP_CATEGORY_LABEL, _toolbarIconHelp);
		}
	}


	public void Init(BuildReportTool.BuildInfo buildInfo)
	{
		_buildInfo = buildInfo;

		minSize = new Vector2(903, 378);
	}

	/// <summary>
	/// Creates a Build Report and shows it on-screen.
	/// </summary>
	/// Called either when the "Get Log" button is pressed in this EditorWindow
	/// (called in <see cref="DrawTopRowButtons"/>, which is called in <see cref="OnGUI"/>),
	/// or in <see cref="Update"/>, when it has detected that a build has completed and
	/// a Build Report creation was scheduled.
	void Refresh()
	{
		GoToOverviewScreen();
		BuildReportTool.ReportGenerator.RefreshData(ref _buildInfo, ref _assetDependencies);
	}

	bool IsWaitingForBuildCompletionToGenerateBuildReport
	{
		get { return BuildReportTool.Util.ShouldGetBuildReportNow && EditorApplication.isCompiling; }
	}

	void OnFinishOpeningBuildReportFile()
	{
		_finishedOpeningFromThread = false;

		if (BuildReportTool.Util.BuildInfoHasContents(_buildInfo))
		{
			_buildSettingsScreen.RefreshData(_buildInfo);
			_usedAssetsScreen.RefreshData(_buildInfo);
			_unusedAssetsScreen.RefreshData(_buildInfo);
			_sizeStatsScreen.RefreshData(_buildInfo);


			_buildInfo.OnDeserialize();
			_buildInfo.SetSavedPath(_lastOpenedBuildInfoFilePath);
		}

		Repaint();
		GoToOverviewScreen();
	}

	void OnFinishGeneratingBuildReport()
	{
		BuildReportTool.ReportGenerator.OnFinishedGetValues(_buildInfo, _assetDependencies);
		_buildInfo.UnescapeAssetNames();

		GoToOverviewScreen();

		_buildSettingsScreen.RefreshData(_buildInfo);
	}


	void GoToOverviewScreen()
	{
		_selectedCategoryIdx = OVERVIEW_IDX;
	}


	// ==========================================================================

	// ==========================================================================


	int _fileFilterGroupToUseOnOpeningOptionsWindow = 0;
	int _fileFilterGroupToUseOnClosingOptionsWindow = 0;


	int _selectedCategoryIdx = 0;

	bool IsInOverviewCategory
	{
		get { return _selectedCategoryIdx == OVERVIEW_IDX; }
	}

	bool IsInBuildSettingsCategory
	{
		get { return _selectedCategoryIdx == BUILD_SETTINGS_IDX; }
	}

	bool IsInSizeStatsCategory
	{
		get { return _selectedCategoryIdx == SIZE_STATS_IDX; }
	}

	bool IsInUsedAssetsCategory
	{
		get { return _selectedCategoryIdx == USED_ASSETS_IDX; }
	}

	bool IsInUnusedAssetsCategory
	{
		get { return _selectedCategoryIdx == UNUSED_ASSETS_IDX; }
	}

	bool IsInOptionsCategory
	{
		get { return _selectedCategoryIdx == OPTIONS_IDX; }
	}

	bool IsInHelpCategory
	{
		get { return _selectedCategoryIdx == HELP_IDX; }
	}


	const int OVERVIEW_IDX = 0;
	const int BUILD_SETTINGS_IDX = 1;
	const int SIZE_STATS_IDX = 2;
	const int USED_ASSETS_IDX = 3;
	const int UNUSED_ASSETS_IDX = 4;

	const int OPTIONS_IDX = 5;
	const int HELP_IDX = 6;


	bool _finishedOpeningFromThread = false;
	string _lastOpenedBuildInfoFilePath = "";

	void _OpenBuildInfo(string filepath)
	{
		if (string.IsNullOrEmpty(filepath))
		{
			return;
		}

		_finishedOpeningFromThread = false;
		GetValueMessage = "Opening...";
		BuildReportTool.BuildInfo loadedBuild = BuildReportTool.Util.OpenSerializedBuildInfo(filepath, false);

		if (BuildReportTool.Util.BuildInfoHasContents(loadedBuild))
		{
			_buildInfo = loadedBuild;
			_lastOpenedBuildInfoFilePath = filepath;
		}
		else
		{
			Debug.LogError("Build Report Tool: Invalid data in build info file: " + filepath);
		}


		var assetDependenciesFilePath = BuildReportTool.Util.GetAssetDependenciesFilenameFromBuildInfo(filepath);
		if (System.IO.File.Exists(assetDependenciesFilePath))
		{
			var loadedAssetDependencies = BuildReportTool.Util.OpenSerializedAssetDependencies(assetDependenciesFilePath);
			if (loadedAssetDependencies != null)
			{
				_assetDependencies = loadedAssetDependencies;
			}
		}

		_finishedOpeningFromThread = true;

		GetValueMessage = "";
	}


	Thread _currentBuildReportFileLoadThread = null;

	bool IsCurrentlyOpeningAFile
	{
		get
		{
			return _currentBuildReportFileLoadThread != null &&
			       _currentBuildReportFileLoadThread.ThreadState == ThreadState.Running;
		}
	}

	void ForceStopFileLoadThread()
	{
		if (IsCurrentlyOpeningAFile)
		{
			try
			{
				//Debug.LogFormat(this, "Build Report Tool: Stopping file load background thread...");
				_currentBuildReportFileLoadThread.Abort();
				Debug.LogFormat(this, "Build Report Tool: File load background thread stopped.");
			}
			catch (ThreadStateException)
			{
			}
		}
	}

	void OpenBuildInfoInBackgroundIfNeeded(string filepath)
	{
		if (string.IsNullOrEmpty(filepath))
		{
			return;
		}

		// user selected the asset dependencies file for the build report
		// derive the build report file from it
		if (filepath.DoesFileBeginWith("DEP-"))
		{
			var path = System.IO.Path.GetDirectoryName(filepath);
			var filename = System.IO.Path.GetFileName(filepath);
			filepath = string.Format("{0}/{1}", path, filename.Substring(4)); // filename without the "DEP-" at the start
		}

		if (!BuildReportTool.Options.UseThreadedFileLoading)
		{
			_OpenBuildInfo(filepath);
		}
		else
		{
			if (_currentBuildReportFileLoadThread != null &&
			    _currentBuildReportFileLoadThread.ThreadState == ThreadState.Running)
			{
				ForceStopFileLoadThread();
			}

			_currentBuildReportFileLoadThread = new Thread(() => LoadThread(filepath));
			_currentBuildReportFileLoadThread.Start();
			Debug.LogFormat(this, "Build Report Tool: Started new load background thread...");
		}
	}

	void LoadThread(string filepath)
	{
		_OpenBuildInfo(filepath);
		Debug.LogFormat(this, "Build Report Tool: Load background thread finished.");
	}


	void DrawCentralMessage(string msg)
	{
		float w = 300;
		float h = 100;
		float x = (position.width - w) * 0.5f;
		float y = (position.height - h) * 0.25f;

		GUI.Label(new Rect(x, y, w, h), msg);
	}


	void DrawWarningMessage(string msg)
	{
		float w = 400;
		float h = 100;
		float x = (position.width - w) * 0.5f;
		float y = ((position.height - h) * 0.25f) + 100 + 40;

		var msgRect = new Rect(x, y, w, h);
		GUI.Label(msgRect, msg);

		var warning = GUI.skin.GetStyle("Icon-Warning");
		if (warning != null)
		{
			var warningIcon = warning.normal.background;

			var iconWidth = warning.fixedWidth;
			var iconHeight = warning.fixedHeight;

			GUI.DrawTexture(new Rect(msgRect.x - iconWidth, msgRect.y, iconWidth, iconHeight), warningIcon);
		}
	}


	void DrawTopRowButtons()
	{
		int toolbarX = 10;

		if (GUI.Button(new Rect(toolbarX, 5, 50, 40), _toolbarLabelLog,
			    BuildReportTool.Window.Settings.TOOLBAR_LEFT_STYLE_NAME) && !LoadingValuesFromThread)
		{
			Refresh();
		}

		toolbarX += 50;
		if (GUI.Button(new Rect(toolbarX, 5, 40, 40), _toolbarLabelOpen,
			    BuildReportTool.Window.Settings.TOOLBAR_MIDDLE_STYLE_NAME) && !LoadingValuesFromThread)
		{
			string filepath = EditorUtility.OpenFilePanel(
				Labels.OPEN_SERIALIZED_BUILD_INFO_TITLE,
				BuildReportTool.Options.BuildReportSavePath,
				"xml");

			OpenBuildInfoInBackgroundIfNeeded(filepath);
		}

		toolbarX += 40;

		if (GUI.Button(new Rect(toolbarX, 5, 40, 40), _toolbarLabelSave,
			    BuildReportTool.Window.Settings.TOOLBAR_RIGHT_STYLE_NAME) &&
		    BuildReportTool.Util.BuildInfoHasContents(_buildInfo))
		{
			string filepath = EditorUtility.SaveFilePanel(
				Labels.SAVE_MSG,
				BuildReportTool.Options.BuildReportSavePath,
				_buildInfo.GetDefaultFilename(),
				"xml");

			if (!string.IsNullOrEmpty(filepath))
			{
				BuildReportTool.Util.SerializeBuildInfo(_buildInfo, filepath);

				if (_assetDependencies != null && _assetDependencies.HasContents)
				{
					var assetDependenciesFilePath = BuildReportTool.Util.GetAssetDependenciesFilenameFromBuildInfo(filepath);
					BuildReportTool.Util.SerializeAssetDependencies(_assetDependencies, assetDependenciesFilePath);
				}
			}
		}

		toolbarX += 40;


		toolbarX += 20;

		//if (!BuildReportTool.Util.BuildInfoHasContents(_buildInfo))
		{
			if (GUI.Button(new Rect(toolbarX, 5, 55, 40), _toolbarLabelOptions,
				BuildReportTool.Window.Settings.TOOLBAR_LEFT_STYLE_NAME))
			{
				_selectedCategoryIdx = OPTIONS_IDX;
			}

			toolbarX += 55;
			if (GUI.Button(new Rect(toolbarX, 5, 70, 40), _toolbarLabelHelp,
				BuildReportTool.Window.Settings.TOOLBAR_RIGHT_STYLE_NAME))
			{
				_selectedCategoryIdx = HELP_IDX;
			}
		}
	}

	bool _buildInfoHasNoContentsToDisplay = false;

	void OnGUI()
	{
		if (Event.current.type == EventType.Layout)
		{
			_noGuiSkinFound = _usedSkin == null;
			_loadingValuesFromThread = !string.IsNullOrEmpty(GetValueMessage);
			_buildInfoHasNoContentsToDisplay = !BuildReportTool.Util.BuildInfoHasContents(_buildInfo);
		}

		//GUI.Label(new Rect(5, 100, 800, 20), "BuildReportTool.Util.ShouldReload: " + BuildReportTool.Util.ShouldReload + " EditorApplication.isCompiling: " + EditorApplication.isCompiling);
		if (_noGuiSkinFound)
		{
			GUI.Label(new Rect(20, 20, 500, 100), BuildReportTool.Options.BUILD_REPORT_PACKAGE_MISSING_MSG);
			return;
		}

		GUI.skin = _usedSkin;

		DrawTopRowButtons();


		GUI.Label(new Rect(0, 0, position.width, 20), BuildReportTool.Info.ReadableVersion,
			BuildReportTool.Window.Settings.VERSION_STYLE_NAME);


		// loading message
		if (LoadingValuesFromThread)
		{
			DrawCentralMessage(GetValueMessage);
			return;
		}

		bool requestRepaint = false;

		// content to show when there is no build report on display
		if (_buildInfoHasNoContentsToDisplay)
		{
			if (IsInOptionsCategory)
			{
				GUILayout.Space(40);
				_optionsScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaint);
			}
			else if (IsInHelpCategory)
			{
				GUILayout.Space(40);
				_helpScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaint);
			}
			else if (IsWaitingForBuildCompletionToGenerateBuildReport)
			{
				DrawCentralMessage(Labels.WAITING_FOR_BUILD_TO_COMPLETE_MSG);
			}
			else
			{
				DrawCentralMessage(Labels.NO_BUILD_INFO_FOUND_MSG);

				if (ReportGenerator.CheckIfUnityHasNoLogArgument())
				{
					DrawWarningMessage(Labels.FOUND_NO_LOG_ARGUMENT_MSG);
				}
			}

			if (requestRepaint)
			{
				Repaint();
			}

			return;
		}


		GUILayout.Space(50); // top padding (top row buttons are 40 pixels)


		var mouseHasMoved = Mathf.Abs(Event.current.mousePosition.x - _lastMousePos.x) > 0 ||
		                    Mathf.Abs(Event.current.mousePosition.y - _lastMousePos.y) > 0;


		// category buttons

		int oldSelectedCategoryIdx = _selectedCategoryIdx;

		GUILayout.BeginHorizontal();
		if (GUILayout.Toggle(IsInOverviewCategory, "Overview", BuildReportTool.Window.Settings.TAB_LEFT_STYLE_NAME,
			GUILayout.ExpandWidth(true)))
		{
			_selectedCategoryIdx = OVERVIEW_IDX;
		}

		if (GUILayout.Toggle(IsInBuildSettingsCategory, "Project Settings",
			BuildReportTool.Window.Settings.TAB_MIDDLE_STYLE_NAME, GUILayout.ExpandWidth(true)))
		{
			_selectedCategoryIdx = BUILD_SETTINGS_IDX;
		}

		if (GUILayout.Toggle(IsInSizeStatsCategory, "Size Stats", BuildReportTool.Window.Settings.TAB_MIDDLE_STYLE_NAME,
			GUILayout.ExpandWidth(true)))
		{
			_selectedCategoryIdx = SIZE_STATS_IDX;
		}

		if (GUILayout.Toggle(IsInUsedAssetsCategory, "Used Assets", BuildReportTool.Window.Settings.TAB_MIDDLE_STYLE_NAME,
			GUILayout.ExpandWidth(true)))
		{
			_selectedCategoryIdx = USED_ASSETS_IDX;
		}

		if (GUILayout.Toggle(IsInUnusedAssetsCategory, "Unused Assets",
			BuildReportTool.Window.Settings.TAB_RIGHT_STYLE_NAME, GUILayout.ExpandWidth(true)))
		{
			_selectedCategoryIdx = UNUSED_ASSETS_IDX;
		}

		/*GUILayout.Space(20);

		if (GUILayout.Toggle(IsInOptionsCategory, _toolbarLabelOptions, BuildReportTool.Window.Settings.TAB_LEFT_STYLE_NAME, GUILayout.ExpandWidth(true)))
		{
			_selectedCategoryIdx = OPTIONS_IDX;
		}
		if (GUILayout.Toggle(IsInHelpCategory, _toolbarLabelHelp, BuildReportTool.Window.Settings.TAB_RIGHT_STYLE_NAME, GUILayout.ExpandWidth(true)))
		{
			_selectedCategoryIdx = HELP_IDX;
		}*/
		GUILayout.EndHorizontal();


		if (oldSelectedCategoryIdx != OPTIONS_IDX && _selectedCategoryIdx == OPTIONS_IDX)
		{
			// moving into the options screen
			_fileFilterGroupToUseOnOpeningOptionsWindow = BuildReportTool.Options.FilterToUseInt;
		}
		else if (oldSelectedCategoryIdx == OPTIONS_IDX && _selectedCategoryIdx != OPTIONS_IDX)
		{
			// moving away from the options screen
			_fileFilterGroupToUseOnClosingOptionsWindow = BuildReportTool.Options.FilterToUseInt;

			if (_fileFilterGroupToUseOnOpeningOptionsWindow != _fileFilterGroupToUseOnClosingOptionsWindow)
			{
				RecategorizeDisplayedBuildInfo();
			}
		}

		bool requestRepaintOnTabs = false;

		// main content
		GUILayout.BeginHorizontal();
		//GUILayout.Space(3); // left padding
		GUILayout.BeginVertical();

		if (IsInOverviewCategory)
		{
			_overviewScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaintOnTabs);
		}
		else if (IsInBuildSettingsCategory)
		{
			_buildSettingsScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaintOnTabs);
		}
		else if (IsInSizeStatsCategory)
		{
			_sizeStatsScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaintOnTabs);
		}
		else if (IsInUsedAssetsCategory)
		{
			_usedAssetsScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaintOnTabs);
		}
		else if (IsInUnusedAssetsCategory)
		{
			_unusedAssetsScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaintOnTabs);
		}
		else if (IsInOptionsCategory)
		{
			_optionsScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaintOnTabs);
		}
		else if (IsInHelpCategory)
		{
			_helpScreen.DrawGUI(position, _buildInfo, _assetDependencies, out requestRepaintOnTabs);
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		//GUILayout.Space(5); // right padding
		GUILayout.EndHorizontal();

		//GUILayout.Space(10); // bottom padding

		if (requestRepaintOnTabs)
		{
			_buildInfo.FlagOkToRefresh();
		}

		_lastMousePos = Event.current.mousePosition;
		_lastMouseMoved = mouseHasMoved;
	}

	public static bool LastMouseMoved
	{
		get { return _lastMouseMoved; }
	}

	public static bool MouseMovedNow
	{
		get
		{
			return Mathf.Abs(Event.current.mousePosition.x - _lastMousePos.x) > 0 ||
			       Mathf.Abs(Event.current.mousePosition.y - _lastMousePos.y) > 0;
		}
	}

	// =====================================================================================

	public static Texture GetAssetPreview(SizePart sizePart)
	{
		if (sizePart == null)
		{
			return null;
		}

		return GetAssetPreview(sizePart.Name);
	}

	public static Texture GetAssetPreview(string assetName)
	{
		if (string.IsNullOrEmpty(assetName))
		{
			return null;
		}

		Texture thumbnailImage = null;
		if (assetName.IsTextureFile())
		{
			thumbnailImage = AssetDatabase.LoadAssetAtPath<Texture>(assetName);
		}
		else //if (_assetListEntryHovered.Name.EndsWith(".prefab") || BuildReportTool.Util.IsFileAUnityMesh(_assetListEntryHovered.Name))
		{
			var loadedObj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetName);

			if (loadedObj != null)
			{
				thumbnailImage = AssetPreview.GetAssetPreview(loadedObj);
				//thumbnailImage = AssetPreview.GetMiniThumbnail(loadedObj);
			}
		}

		return thumbnailImage;
	}

	public static Vector2 GetThumbnailSize()
	{
		Vector2 thumbnailSize;
		thumbnailSize.x = ZoomedInThumbnails
			                  ? BuildReportTool.Options.TooltipThumbnailZoomedInWidth
			                  : BuildReportTool.Options.TooltipThumbnailWidth;

		thumbnailSize.y = ZoomedInThumbnails
			                  ? BuildReportTool.Options.TooltipThumbnailZoomedInHeight
			                  : BuildReportTool.Options.TooltipThumbnailHeight;
		return thumbnailSize;
	}

	public static Rect DrawTooltip(Rect position, Rect initialRect, float desiredWidth, float desiredHeight)
	{
		var tooltipStyle = GUI.skin.GetStyle("Tooltip");
		var tooltipRect = initialRect;

		var tooltipPos = Event.current.mousePosition;
		tooltipPos.x += 18;
		tooltipPos.y += 15;

		// initially tooltip is to the right and below the mouse

		tooltipRect.width = desiredWidth;
		tooltipRect.height = desiredHeight;


		tooltipRect.width += tooltipStyle.border.horizontal;
		tooltipRect.height += tooltipStyle.border.vertical;

		tooltipRect.x = tooltipPos.x - tooltipStyle.border.left;
		tooltipRect.y = tooltipPos.y - tooltipStyle.border.top;

		if (tooltipRect.xMax > position.width)
		{
			// move tooltip to the left
			tooltipPos.x = Event.current.mousePosition.x - 5 - tooltipRect.width;
			tooltipRect.x = tooltipPos.x - tooltipStyle.border.left;

			if (tooltipRect.x < 0)
			{
				tooltipPos.x = position.width - tooltipRect.width;
				tooltipRect.x = tooltipPos.x - tooltipStyle.border.left;
			}
		}

		if (tooltipRect.yMax > position.height)
		{
			// move tooltip above mouse
			tooltipPos.y = Event.current.mousePosition.y + 3 - tooltipRect.height;
			tooltipRect.y = tooltipPos.y - tooltipStyle.border.top;

			if (tooltipRect.y < 0)
			{
				tooltipPos.y = position.height - tooltipRect.height;
				tooltipRect.y = tooltipPos.y - tooltipStyle.border.top;
			}
		}

		//GUI.Box(thumbnailRect, string.Format("hovered idx: {0}", _assetListEntryHoveredIdx.ToString()));
		GUI.Box(tooltipRect, string.Empty, tooltipStyle);

		return new Rect(tooltipPos.x, tooltipPos.y, desiredWidth, desiredHeight);
	}

	public static void ProcessThumbnailControls()
	{
		if (Event.current.type == EventType.KeyDown && (Event.current.keyCode == KeyCode.LeftAlt ||
		                                                Event.current.keyCode == KeyCode.RightAlt))
		{
			ShowThumbnailsWithAlphaBlend = !ShowThumbnailsWithAlphaBlend;
		}

		if ((Event.current.keyCode == KeyCode.LeftControl ||
		     Event.current.keyCode == KeyCode.RightControl))
		{
			if (Event.current.type == EventType.KeyDown)
			{
				ZoomedInThumbnails = true;
			}
			else if (Event.current.type == EventType.KeyUp)
			{
				ZoomedInThumbnails = false;
			}
		}
	}

	public static void ResetThumbnailControls()
	{
		// ensure that thumbnails are not zoomed in
		ZoomedInThumbnails = false;
	}

	public static void DrawThumbnail(float posX, float posY, Vector2 thumbnailSize, Texture thumbnailImage)
	{
		var thumbnailRect = new Rect(posX, posY, thumbnailSize.x, thumbnailSize.y);
		GUI.DrawTexture(thumbnailRect, thumbnailImage, ScaleMode.ScaleToFit, ShowThumbnailsWithAlphaBlend);
	}

	public static Vector2 GetEndUsersListSize(GUIContent label, List<GUIContent> endUsers)
	{
		var assetStyle = GUI.skin.GetStyle("Asset");
		var labelStyle = GUI.skin.GetStyle("TooltipText");

		Vector2 endUsersSize = Vector2.zero;

		var labelSize = labelStyle.CalcSize(label);
		endUsersSize.x = Mathf.Max(endUsersSize.x, labelSize.x);
		endUsersSize.y += labelSize.y;

		if (endUsers != null)
		{
			EditorGUIUtility.SetIconSize(IconSize);

			for (int n = 0, len = endUsers.Count; n < len; ++n)
			{
				var endUserSize = assetStyle.CalcSize(endUsers[n]);

				endUsersSize.x = Mathf.Max(endUsersSize.x, endUserSize.x);
				endUsersSize.y += endUserSize.y;
			}
		}

		return endUsersSize;
	}

	public static void DrawEndUsersList(Vector2 pos, GUIContent label, List<GUIContent> endUsers)
	{
		var assetStyle = GUI.skin.GetStyle("Asset");
		var labelStyle = GUI.skin.GetStyle("TooltipText");

		Rect endUserRect = new Rect(pos.x, pos.y, 0, 0);

		endUserRect.size = labelStyle.CalcSize(label);
		GUI.Label(endUserRect, label, labelStyle);

		if (endUsers != null && endUsers.Count > 0)
		{
			endUserRect.y += endUserRect.height;

			EditorGUIUtility.SetIconSize(IconSize);

			for (int n = 0, len = endUsers.Count; n < len; ++n)
			{
				endUserRect.size = assetStyle.CalcSize(endUsers[n]);

				GUI.Label(endUserRect, endUsers[n], assetStyle);

				endUserRect.y += endUserRect.height;
			}
		}
	}

	// -----------------------------------------------

	public static void DrawThumbnailTooltip(Rect position)
	{
		DrawThumbnailTooltip(position, HoveredAssetEntryPath, HoveredAssetEntryRect);
	}

	public static void DrawThumbnailTooltip(Rect position, string assetPath, Rect assetRect)
	{
		var thumbnailImage = BRT_BuildReportWindow.GetAssetPreview(assetPath);

		if (thumbnailImage != null)
		{
			var thumbnailSize = BRT_BuildReportWindow.GetThumbnailSize();

			var tooltipRect = BRT_BuildReportWindow.DrawTooltip(position, assetRect,
				thumbnailSize.x, thumbnailSize.y);

			DrawThumbnail(tooltipRect.x, tooltipRect.y, thumbnailSize, thumbnailImage);
		}
	}

	public static void DrawEndUsersTooltip(Rect position, AssetDependencies assetDependencies)
	{
		List<GUIContent> endUsersListToUse = GetEndUserLabelsFor(assetDependencies, HoveredAssetEntryPath);
		DrawEndUsersTooltip(position, GetAppropriateEndUserLabelForHovered(), endUsersListToUse,
			HoveredAssetEntryRect);
	}

	public static void DrawEndUsersTooltip(Rect position, GUIContent label, List<GUIContent> endUsers, Rect assetRect)
	{
		var endUsersSize = BRT_BuildReportWindow.GetEndUsersListSize(label, endUsers);

		var tooltipRect = BRT_BuildReportWindow.DrawTooltip(position, assetRect,
			endUsersSize.x, endUsersSize.y);

		BRT_BuildReportWindow.DrawEndUsersList(tooltipRect.position, label, endUsers);
	}

	public static void DrawThumbnailEndUsersTooltip(Rect position, AssetDependencies assetDependencies)
	{
		List<GUIContent> endUsersListToUse = GetEndUserLabelsFor(assetDependencies, HoveredAssetEntryPath);
		DrawThumbnailEndUsersTooltip(position, HoveredAssetEntryPath, GetAppropriateEndUserLabelForHovered(),
			endUsersListToUse, HoveredAssetEntryRect);
	}

	public static void DrawThumbnailEndUsersTooltip(Rect position, string assetPath, GUIContent label,
		List<GUIContent> endUsers, Rect assetRect)
	{
		var thumbnailImage = BRT_BuildReportWindow.GetAssetPreview(assetPath);

		if (thumbnailImage != null)
		{
			var usedBySpacing = 5;

			var thumbnailSize = BRT_BuildReportWindow.GetThumbnailSize();

			// compute end users height and width
			// then create a tooltip size that encompasses both thumbnail and end users list

			Vector2 endUsersSize = BRT_BuildReportWindow.GetEndUsersListSize(label, endUsers);
			endUsersSize.y += usedBySpacing;

			Vector2 tooltipSize = new Vector2(Mathf.Max(thumbnailSize.x, endUsersSize.x),
				thumbnailSize.y + endUsersSize.y);

			var tooltipRect = BRT_BuildReportWindow.DrawTooltip(position, assetRect,
				tooltipSize.x, tooltipSize.y);

			// --------
			// now draw the contents

			BRT_BuildReportWindow.DrawThumbnail(tooltipRect.x, tooltipRect.y, thumbnailSize, thumbnailImage);

			var endUsersPos = tooltipRect.position;
			endUsersPos.y += thumbnailSize.y + usedBySpacing;
			BRT_BuildReportWindow.DrawEndUsersList(endUsersPos, label, endUsers);
		}
	}

	// =====================================================================================
}

#endif