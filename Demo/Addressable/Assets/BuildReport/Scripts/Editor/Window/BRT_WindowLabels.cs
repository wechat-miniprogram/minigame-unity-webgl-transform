#if UNITY_EDITOR

namespace BuildReportTool.Window
{
	public static class Labels
	{
		// GUI messages, labels

		public const string WAITING_FOR_BUILD_TO_COMPLETE_MSG =
			"Waiting for build to complete... Click this window if not in focus to refresh.";

		public const string NO_BUILD_INFO_FOUND_MSG =
			"No Build Info.\n\nClick \"Get Log\" to retrieve the last build info from the Editor log.\n\nClick Open to manually open a previously saved build report file.";

		public const string FOUND_NO_LOG_ARGUMENT_MSG =
			"Warning: Unity was launched with the -nolog argument. Build Report Tool can't obtain build info if there are no logs. To generate build reports, relaunch Unity without the -nolog argument.";


		public const string MONO_DLLS_LABEL = "System DLLs:";
		public const string UNITY_ENGINE_DLLS_LABEL = "UnityEngine DLLs:";
		public const string SCRIPT_DLLS_LABEL = "Script DLLs:";


		public const string TIME_OF_BUILD_LABEL = "Time of Build:";


		public const string UNUSED_TOTAL_SIZE_LABEL = "Total Unused\nAssets Size:";
		public const string USED_TOTAL_SIZE_LABEL = "Total Used\nAssets Size:";
		public const string STREAMING_ASSETS_TOTAL_SIZE_LABEL = "Streaming\nAssets Size:";
		public const string BUILD_TOTAL_SIZE_LABEL = "Total Build Size:";
		public const string BUILD_XCODE_SIZE_LABEL = "Size of Xcode Project Folder";

		public const string WEB_UNITY3D_FILE_SIZE_LABEL = "Size of .unity3d File:";

		public const string ANDROID_APK_FILE_SIZE_LABEL = "Size of .apk File:";
		public const string ANDROID_OBB_FILE_SIZE_LABEL = "Size of .obb File:";


		public const string UNUSED_TOTAL_SIZE_DESC = "Total size of project assets not included in the build.";

		public const string USED_TOTAL_SIZE_DESC =
			"Total size of the used assets before being packed.\nAlso includes size of compiled Mono scripts.\nDoes not include size of files in StreamingAssets.";

		public const string STREAMING_ASSETS_SIZE_DESC = "Total size of all files in the StreamingAssets folder.";


		public const string BUILD_SIZE_STANDALONE_DESC =
			"File size of the executable file and the accompanying Data folder.";

		public const string BUILD_SIZE_WINDOWS_DESC = "File size of the .exe file and the accompanying Data folder.";
		public const string BUILD_SIZE_MACOSX_DESC = "File size of the .app file.";

		public const string BUILD_SIZE_LINUX_UNIVERSAL_DESC =
			"File size of both 32-bit and 64-bit executables, plus the accompanying Data folder.";

		public const string BUILD_SIZE_WEB_DESC = "File size of the whole web build folder.";

		public const string BUILD_SIZE_IOS_DESC = "File size of the Xcode project folder.";

		public const string BUILD_SIZE_ANDROID_DESC = "File size of resulting .apk file.";
		public const string BUILD_SIZE_ANDROID_WITH_OBB_DESC = "File size of resulting .apk and .obb files.";
		public const string BUILD_SIZE_ANDROID_WITH_PROJECT_DESC = "File size of generated Eclipse project folder.";


		public const string OPEN_SERIALIZED_BUILD_INFO_TITLE = "Open Build Report XML File";

		public const string TOTAL_SIZE_BREAKDOWN_LABEL = "Used Assets Size Breakdown:";

		public const string ASSET_SIZE_BREAKDOWN_LABEL = "Asset Breakdown:";


		public const string ASSET_SIZE_BREAKDOWN_MSG_PRE_BOLD = "Sorted by";
		public const string ASSET_SIZE_BREAKDOWN_MSG_BOLD = "uncompressed";

		public const string ASSET_SIZE_BREAKDOWN_MSG_POST_BOLD =
			"size. Click on an asset's name to include it in size calculations or batch deletions. Shift-click to select many. Ctrl-click to toggle selection.";

		public const string TOTAL_SIZE_BREAKDOWN_MSG_PRE_BOLD = "Based on";
		public const string TOTAL_SIZE_BREAKDOWN_MSG_BOLD = "uncompressed";
		public const string TOTAL_SIZE_BREAKDOWN_MSG_POST_BOLD = "build size";


		public const string NO_FILES_FOR_THIS_CATEGORY_LABEL = "None";

		public const string NON_APPLICABLE_PERCENTAGE_LABEL = "N/A";

		public const string OVERVIEW_CATEGORY_LABEL = "Overview";
		public const string BUILD_SETTINGS_CATEGORY_LABEL = "Project Settings";
		public const string SIZE_STATS_CATEGORY_LABEL = "Total Size";
		public const string USED_ASSETS_CATEGORY_LABEL = "Used Assets";
		public const string UNUSED_ASSETS_CATEGORY_LABEL = "Unused Assets";
		public const string OPTIONS_CATEGORY_LABEL = "Options";
		public const string HELP_CATEGORY_LABEL = "Help & Info";


		public const string REFRESH_LABEL = "Get Log";
		public const string OPEN_LABEL = "Open";
		public const string SAVE_LABEL = "Save";

		public const string SAVE_MSG = "Save Build Report to XML";

		public const string RECALC_RAW_SIZES = "Recalculate Raw Sizes";
		public const string RECALC_IMPORTED_SIZES = "Recalculate Imported Sizes";
		public const string RECALC_SIZE_BEFORE_BUILD = "Recalculate Size Before Build";

		public const string SELECT_ALL_LABEL = "Select All";
		public const string SELECT_NONE_LABEL = "Select None";
		public const string SELECTED_QTY_LABEL = "Selected: ";
		public const string SELECTED_SIZE_LABEL = "Total size: ";
		public const string SELECTED_PERCENT_LABEL = "Total percentage: ";

		public const string BUILD_TYPE_PREFIX_MSG = "For ";
		public const string BUILD_TYPE_SUFFIX_MSG = "";
		public const string UNITY_VERSION_PREFIX_MSG = ", built in ";

		public const string COLLECT_BUILD_INFO_LABEL =
			"Automatically collect and save build info after building (does not include batchmode builds)";

		public const string SHOW_AFTER_BUILD_LABEL = "Show Build Report Window automatically after building";
		public const string INCLUDE_SVN_LABEL = "Include SVN metadata when creating Unused Assets list";
		public const string INCLUDE_GIT_LABEL = "Include Git metadata when creating Unused Assets list";
		public const string FILE_FILTER_DISPLAY_TYPE_LABEL = "Draw file filters as:";

		public const string FILE_FILTER_DISPLAY_TYPE_DROP_DOWN_LABEL = "Dropdown box";
		public const string FILE_FILTER_DISPLAY_TYPE_BUTTONS_LABEL = "Buttons";

		public const string SAVE_PATH_LABEL = "Current Build Report save path: ";
		public const string SAVE_FOLDER_NAME_LABEL = "Folder name for Build Reports:";
		public const string SAVE_PATH_TYPE_LABEL = "Save build reports:";

		public const string SAVE_PATH_TYPE_PERSONAL_DEFAULT_LABEL = "In user's personal folder";
		public const string SAVE_PATH_TYPE_PERSONAL_WIN_LABEL = "In \"My Documents\" folder";
		public const string SAVE_PATH_TYPE_PERSONAL_MAC_LABEL = "In Home folder";
		public const string SAVE_PATH_TYPE_PROJECT_LABEL = "Beside project folder";

		public const string EDITOR_LOG_LABEL = "Unity Editor.log path ";
		public const string DEFAULT_EDITOR_LOG_NOT_FOUND_MSG = "Warning: Unity Editor Log file not found.";

		public const string OVERRIDE_LOG_NOT_FOUND_MSG =
			"Specified log file not found. Please change the path by clicking \"Set Override Log\"";

		public const string SET_OVERRIDE_LOG_LABEL = "Set Override Log";
		public const string CLEAR_OVERRIDE_LOG_LABEL = "Clear Override Log";

		public const string FILTER_GROUP_TO_USE_LABEL = "File Filter Group To Use:";
		public const string FILTER_GROUP_FILE_PATH_LABEL = "Configured File Filter Group: ";

		public const string FILTER_GROUP_TO_USE_CONFIGURED_LABEL = "Always use configured file filter group";

		public const string FILTER_GROUP_TO_USE_EMBEDDED_LABEL =
			"Use file filter group embedded in file if available\n(when opening build report files)";

		public const string OPEN_IN_FILE_BROWSER_DEFAULT_LABEL = "Open in file browser";
		public const string OPEN_IN_FILE_BROWSER_WIN_LABEL = "Show in Explorer";
		public const string OPEN_IN_FILE_BROWSER_MAC_LABEL = "Reveal in Finder";


		public const string CALCULATION_LEVEL_FULL_NAME = "4 - Full Report (complete calculations)";

		public const string CALCULATION_LEVEL_FULL_DESC =
			"Calculate everything. Will show size breakdown, \"Used Assets\", and \"Unused Assets\" list.\n\nThis can be slow if you have a large project with thousands of files or objects in scenes. If you get out of memory errors, try the lower calculation levels.";

		public const string CALCULATION_LEVEL_NO_PREFAB_NAME = "3 - Do not calculate unused prefabs";

		public const string CALCULATION_LEVEL_NO_PREFAB_DESC =
			"Will calculate everything, except that it will not determine whether a prefab is unused. It will still show which other assets are unused.\n\nIf you have scenes that use hundreds to thousands of prefabs and you get an out of memory error when generating a build report, try this setting.";

		public const string CALCULATION_LEVEL_NO_UNUSED_NAME = "2 - Do not calculate unused assets";

		public const string CALCULATION_LEVEL_NO_UNUSED_DESC =
			"Will display overview data and \"Used Assets\" list only. It will not determine which assets are unused.\n\nIt will not show Streaming Assets files in your Used Assets list, but their total size will still be shown in the Overview.";

		public const string CALCULATION_LEVEL_MINIMAL_NAME = "1 - Overview only (minimum calculations)";

		public const string CALCULATION_LEVEL_MINIMAL_DESC =
			"Will display overview data only. This is the fastest but also shows the least information.";
	}
}

#endif