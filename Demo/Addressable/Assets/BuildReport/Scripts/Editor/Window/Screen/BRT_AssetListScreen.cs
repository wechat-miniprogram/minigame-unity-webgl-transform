//#define BRT_ASSET_LIST_SCREEN_DEBUG

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEditor;


namespace BuildReportTool.Window.Screen
{
	public partial class AssetList : BaseScreen
	{
#if BRT_ASSET_LIST_SCREEN_DEBUG
	bool _showDebugText;
	readonly GUIContent _debugLabel = new GUIContent();
	StringBuilder _debugText;
#endif

		const int SCROLLBAR_BOTTOM_PADDING = 5;
		const int BOTTOM_STATUS_BAR_HEIGHT = 20;
		const int DOUBLE_CLICK_THRESHOLD = 2;

		BuildReportTool.FileFilterGroup _configuredFileFilterGroup;

		/// <summary>
		/// True means the asset list shows the complete path of each asset entry, starting in "Assets/".
		/// False means the asset list only shows the filename of each asset entry.
		/// </summary>
		bool _showAssetPath = true;

		/// <summary>
		/// Which field of the asset we are sorting the list in.
		/// </summary>
		BuildReportTool.AssetList.SortType _currentSortType = BuildReportTool.AssetList.SortType.RawSize;

		/// <summary>
		/// Whether we are sorting ascending or descending.
		/// </summary>
		BuildReportTool.AssetList.SortOrder _currentSortOrder = BuildReportTool.AssetList.SortOrder.Descending;

		/// <summary>
		/// Last clicked entry in the main asset list.
		/// This is used to check if user is clicking on the same asset that's already selected, or a new one.
		/// </summary>
		int _assetListEntryLastClickedIdx = -1;

		/// <summary>
		/// -1 is already used to signify the "All" list (i.e. no filter)
		/// so we need something else to signify no value.
		/// </summary>
		const int NO_FILTER_VALUE = -2;

		int _filterIdxOfLastClickedAssetListEntry = NO_FILTER_VALUE;

		/// <summary>
		/// Hovered entry in the main asset list
		/// </summary>
		int _assetListEntryHoveredIdx = -1;

		/// <summary>
		/// Hovered entry in the asset usage ancestry list
		/// </summary>
		int _assetUsageAncestryHoveredIdx = -1;

		/// <summary>
		/// Hovered entry in the flattened asset users list 
		/// </summary>
		int _assetUserEntryHoveredIdx = -1;

		bool _shouldShowThumbnailOnHoveredAsset;


		/// <summary>
		/// We record the time an asset has been clicked
		/// to check for a double-click.
		/// We use this instead of Event.current.clickCount
		/// because this way is easier.
		/// </summary>
		double _assetListEntryLastClickedTime;

		Vector2 _assetListScrollPos;
		Rect _assetPathColumnHeaderRect;
		readonly GUIContent _assetPathCheckboxLabel = new GUIContent("", "Display Asset's Path or just the filename.");

		/// <summary>
		/// Re-used entry in the main asset list.
		/// </summary>
		readonly GUIContent _assetListEntry = new GUIContent();


		public enum ListToDisplay
		{
			Invalid,
			UsedAssets,
			UnusedAssets,
		}

		ListToDisplay _currentListDisplayed = ListToDisplay.Invalid;


		// =================================================================================

		public override string Name
		{
			get { return ""; }
		}

		public override void RefreshData(BuildInfo buildReport)
		{
			RefreshConfiguredFileFilters();

			if (BuildReportTool.Options.ShouldUseConfiguredFileFilters())
			{
				BuildReportTool.AssetList listToDisplay = GetAssetListToDisplay(buildReport);
				if (listToDisplay != null)
				{
					listToDisplay.SortIfNeeded(_configuredFileFilterGroup);
				}
			}

			_currentSortType = BuildReportTool.AssetList.SortType.RawSize;
			_currentSortOrder = BuildReportTool.AssetList.SortOrder.Descending;
		}

		public override void Update(double timeNow, double deltaTime, BuildInfo buildReportToDisplay,
			AssetDependencies assetDependencies)
		{
			UpdateSearch(timeNow, buildReportToDisplay);
		}

		public void SetListToDisplay(ListToDisplay t)
		{
			_currentListDisplayed = t;
		}

		bool IsShowingUnusedAssets
		{
			get { return _currentListDisplayed == ListToDisplay.UnusedAssets; }
		}

		bool IsShowingUsedAssets
		{
			get { return _currentListDisplayed == ListToDisplay.UsedAssets; }
		}

		BuildReportTool.AssetList GetAssetListToDisplay(BuildInfo buildReportToDisplay)
		{
			if (buildReportToDisplay == null)
			{
				return null;
			}

			if (_currentListDisplayed == ListToDisplay.UsedAssets)
			{
				return buildReportToDisplay.UsedAssets;
			}
			else if (_currentListDisplayed == ListToDisplay.UnusedAssets)
			{
				return buildReportToDisplay.UnusedAssets;
			}

			Debug.LogError("Invalid list to display type");
			return null;
		}

		public override void DrawGUI(Rect position, BuildInfo buildReportToDisplay, AssetDependencies assetDependencies,
			out bool requestRepaint)
		{
			if (!buildReportToDisplay.HasUsedAssets)
			{
				requestRepaint = false;
				return;
			}

#if BRT_ASSET_LIST_SCREEN_DEBUG
		if (_debugText == null)
		{
			_debugText = new StringBuilder();
		}
		else
		{
			_debugText.Length = 0;
		}
#endif


			// init variables to use
			// --------------------------------------------------------------------------

			BuildReportTool.FileFilterGroup fileFilterGroupToUse = buildReportToDisplay.FileFilters;

			if (BuildReportTool.Options.ShouldUseConfiguredFileFilters())
			{
				fileFilterGroupToUse = _configuredFileFilterGroup;
			}

			BuildReportTool.AssetList listToDisplay = GetAssetListToDisplay(buildReportToDisplay);

			if (listToDisplay == null)
			{
				if (IsShowingUsedAssets)
				{
					Utility.DrawCentralMessage(position, "No \"Used Assets\" included in this build report.");
				}
				else if (IsShowingUnusedAssets)
				{
					Utility.DrawCentralMessage(position, "No \"Unused Assets\" included in this build report.");
				}

				requestRepaint = false;
				return;
			}


			// continually request repaint, since we need to check the rects
			// generated by the GUILayout (using GUILayoutUtility.GetLastRect())
			// to make the hover checks work. GetLastRect() only works during
			// repaint event.
			//
			// later checks below can set requestRepaint to false if there's no
			// need to repaint, to help lessen cpu usage
			requestRepaint = true;

			// GUI
			// --------------------------------------------------------------------------

			GUILayout.Space(1);

			// Toolbar at top
			// ------------------------------------------------

			DrawTopBar(position, buildReportToDisplay, fileFilterGroupToUse);


			// Actual Asset List
			// ------------------------------------------------

			if (buildReportToDisplay.HasUsedAssets)
			{
				DrawAssetList(position, buildReportToDisplay, assetDependencies, listToDisplay, fileFilterGroupToUse,
					BuildReportTool.Options.AssetListPaginationLength);
				GUILayout.FlexibleSpace();
			}


			// Asset Usage Panel for selected
			// ------------------------------------------------

			DrawAssetUsage(position, listToDisplay, buildReportToDisplay, assetDependencies);

			var selectedName = listToDisplay.GetSelectedCount() == 1 ? listToDisplay.GetLastSelected().Name : null;

			// .unity files (scenes) are users themselves, but no asset uses them, because they are the ones directly
			// included in builds
			bool selectedAssetHasUsers = listToDisplay.GetSelectedCount() == 1 && !string.IsNullOrEmpty(selectedName) &&
			                             !selectedName.EndsWith(".unity", StringComparison.OrdinalIgnoreCase) &&
			                             assetDependencies.GetAssetDependencies().ContainsKey(selectedName);

			bool isAssetUsagePanelShown = selectedAssetHasUsers || _selectedIsAResourcesAsset;


			// Status bar at bottom
			// ------------------------------------------------

			// reserve space for the bottom bar
			// later we draw the bottom bar using GUILayout.BeginArea/EndArea
			GUILayout.Space(BOTTOM_STATUS_BAR_HEIGHT);

			var bottomBarRect = new Rect(0, 0, position.width, BOTTOM_STATUS_BAR_HEIGHT);

			if (isAssetUsagePanelShown)
			{
				// bottom bar is anchored to the bottom of the window
				// but move it up a bit, since the bottom-most portion is now occupied by the Asset Usage Panel
				bottomBarRect.y = position.height - BOTTOM_STATUS_BAR_HEIGHT - _assetUsageRect.height;
			}
			else
			{
				// bottom bar is anchored to the bottom of the window
				bottomBarRect.y = position.height - BOTTOM_STATUS_BAR_HEIGHT;
			}


			// --------------------------

			if (Event.current.mousePosition.y >= position.height ||
			    Event.current.mousePosition.y <= _assetPathColumnHeaderRect.yMax ||
			    Event.current.mousePosition.x <= 0 ||
			    Event.current.mousePosition.x >= position.width)
			{
				// mouse is outside the window, no need to repaint, can't show tooltip anyway
				// set requestRepaint to false to help lessen cpu usage
				requestRepaint = false;
			}

			// if mouse is too far below, above, or to the right for showing tooltip
			// in main asset list, then prevent tooltip from showing in that situation
			// note: this doesn't prevent tooltips in the asset usage panel
			if (Event.current.type == EventType.Repaint && (Event.current.mousePosition.y >= bottomBarRect.y ||
			                                                Event.current.mousePosition.y <=
			                                                _assetPathColumnHeaderRect.yMax ||
			                                                Event.current.mousePosition.x >= position.width))
			{
				_assetListEntryHoveredIdx = -1;
			}

			var shouldShowThumbnailTooltipNow = BuildReportTool.Options.ShowTooltipThumbnail &&
			                                    _shouldShowThumbnailOnHoveredAsset &&
			                                    (_assetListEntryHoveredIdx != -1 ||
			                                     _assetUsageAncestryHoveredIdx != -1 ||
			                                     _assetUserEntryHoveredIdx != -1);

			var zoomInChanged = false;
			if (shouldShowThumbnailTooltipNow)
			{
				var prevZoomedIn = BRT_BuildReportWindow.ZoomedInThumbnails;

				// if thumbnail is currently showing, we process the inputs
				// (ctrl zooms in on thumbnail, alt toggles alpha blend)
				BRT_BuildReportWindow.ProcessThumbnailControls();

				if (prevZoomedIn != BRT_BuildReportWindow.ZoomedInThumbnails)
				{
					zoomInChanged = true;
				}
			}
			else
			{
				// no thumbnail currently shown. ensure the controls that
				// need to be reset to initial state are reset
				BRT_BuildReportWindow.ResetThumbnailControls();
			}

			if (!zoomInChanged && !Event.current.alt &&
			    !BRT_BuildReportWindow.MouseMovedNow && !BRT_BuildReportWindow.LastMouseMoved)
			{
				// mouse hasn't moved, and no request to zoom-in thumbnail or toggle thumbnail alpha
				// no need to repaint because nothing has changed
				// set requestRepaint to false to help lessen cpu usage
				requestRepaint = false;
			}

			// --------------------------
			// actual contents of Bottom Bar

			string selectedInfoLabel = string.Format(
				"{0}{1}. {2}{3} ({4}%)",
				Labels.SELECTED_QTY_LABEL,
				listToDisplay.GetSelectedCount().ToString("N0"),
				Labels.SELECTED_SIZE_LABEL, listToDisplay.GetReadableSizeOfSumSelection(),
				listToDisplay.GetPercentageOfSumSelection().ToString("N"));

			GUILayout.BeginArea(bottomBarRect);

			GUILayout.BeginHorizontal(BuildReportTool.Window.Settings.STATUS_BAR_BG_STYLE_NAME,
				BRT_BuildReportWindow.LayoutNone);
			GUILayout.Label(selectedInfoLabel, BuildReportTool.Window.Settings.STATUS_BAR_LABEL_STYLE_NAME,
				BRT_BuildReportWindow.LayoutNone);
			GUILayout.FlexibleSpace();

			if (shouldShowThumbnailTooltipNow)
			{
				GUILayout.Label(
					"Hold Ctrl to zoom-in on the thumbnail. Press Alt to show/hide alpha transparency.",
					BuildReportTool.Window.Settings.STATUS_BAR_LABEL_STYLE_NAME,
					BRT_BuildReportWindow.LayoutNone);
			}
			else
			{
				GUILayout.Label(
					"Click on an asset's name to include it in size calculations or batch deletions. Shift-click to select many. Ctrl-click to toggle selection.",
					BuildReportTool.Window.Settings.STATUS_BAR_LABEL_STYLE_NAME,
					BRT_BuildReportWindow.LayoutNone);
			}

			GUILayout.EndHorizontal();

			GUILayout.EndArea();

			// --------------------------

#if BRT_ASSET_LIST_SCREEN_DEBUG
		_debugText.AppendFormat("Event.current.mousePosition.x: {0}\nposition.width: {1}\nshouldShowThumbnailTooltipNow: {2}\n",
			Event.current.mousePosition.x.ToString(CultureInfo.InvariantCulture),
			position.width.ToString(CultureInfo.InvariantCulture),
			shouldShowThumbnailTooltipNow);
#endif

			// ------------------------------------------------
			// Tooltip

			var shouldShowAssetEndUsersTooltipNow = BuildReportTool.Options.ShowAssetPrimaryUsersInTooltipIfAvailable &&
			                                        BRT_BuildReportWindow.ShouldHoveredAssetShowEndUserTooltip(
				                                        assetDependencies) &&
			                                        (_assetListEntryHoveredIdx != -1 ||
			                                         _assetUsageAncestryHoveredIdx != -1 ||
			                                         _assetUserEntryHoveredIdx != -1);


			if (Event.current.type == EventType.Repaint)
			{
				if (shouldShowThumbnailTooltipNow && shouldShowAssetEndUsersTooltipNow)
				{
					// draw thumbnail and end users below it
					BRT_BuildReportWindow.DrawThumbnailEndUsersTooltip(position, assetDependencies);
				}
				else if (shouldShowAssetEndUsersTooltipNow)
				{
					// draw only end users in tooltip
					BRT_BuildReportWindow.DrawEndUsersTooltip(position, assetDependencies);
				}
				else if (shouldShowThumbnailTooltipNow)
				{
					// draw only thumbnail in tooltip
					BRT_BuildReportWindow.DrawThumbnailTooltip(position);
				}
			}

#if BRT_ASSET_LIST_SCREEN_DEBUG
		// Debug text
		// ------------------------------------------------

		_showDebugText = GUI.Toggle(new Rect(position.width - 90, 20, 90, 20),
			_showDebugText, "Show Debug", "Button");
		
		if (_showDebugText)
		{
			_debugLabel.text = _debugText.ToString();
			var debugStyle = GUI.skin.GetStyle("DebugOverlay");
			var debugLabelSize = debugStyle.CalcSize(_debugLabel);

			GUI.Label(new Rect(position.width - debugLabelSize.x, 0, debugLabelSize.x, debugLabelSize.y), _debugLabel, debugStyle);
		}
#endif
		}


		public void ToggleSort(BuildReportTool.AssetList assetList, BuildReportTool.AssetList.SortType newSortType,
			BuildReportTool.FileFilterGroup fileFilters)
		{
			if (_currentSortType != newSortType)
			{
				_currentSortType = newSortType;
				_currentSortOrder = BuildReportTool.AssetList.SortOrder.Descending; // descending by default
			}
			else
			{
				// already in this sort type
				// now toggle the sort order
				if (_currentSortOrder == BuildReportTool.AssetList.SortOrder.Descending)
				{
					_currentSortOrder = BuildReportTool.AssetList.SortOrder.Ascending;
				}
				else if (_currentSortOrder == BuildReportTool.AssetList.SortOrder.Ascending)
				{
					if (_searchResults != null)
					{
						// clicked again while sort order is in ascending
						// now disable it
						_currentSortType = BuildReportTool.AssetList.SortType.None;
						_currentSortOrder = BuildReportTool.AssetList.SortOrder.None;
					}
					else
					{
						_currentSortOrder = BuildReportTool.AssetList.SortOrder.Descending;
					}
				}
			}

			if (_searchResults != null)
			{
				if (_currentSortType == BuildReportTool.AssetList.SortType.None)
				{
					// no column used as sort
					// revert to sorting by search rank
					SortBySearchRank(_searchResults, _lastSearchText);
				}
				else
				{
					BuildReportTool.AssetList.SortAssetList(_searchResults, _currentSortType, _currentSortOrder);
				}
			}
			else
			{
				assetList.Sort(_currentSortType, _currentSortOrder, fileFilters);
			}
		}

		void RefreshConfiguredFileFilters()
		{
			// reload used FileFilterGroup but save current used filter idx
			// to be re-set afterwards

			int tempIdx = 0;

			if (_configuredFileFilterGroup != null)
			{
				tempIdx = _configuredFileFilterGroup.GetSelectedFilterIdx();
			}

			_configuredFileFilterGroup = BuildReportTool.FiltersUsed.GetProperFileFilterGroupToUse();

			_configuredFileFilterGroup.ForceSetSelectedFilterIdx(tempIdx);
		}


		void DrawTopBar(Rect position, BuildInfo buildReportToDisplay,
			BuildReportTool.FileFilterGroup fileFilterGroupToUse)
		{
			BuildReportTool.AssetList assetListUsed = GetAssetListToDisplay(buildReportToDisplay);

			if (assetListUsed == null)
			{
				return;
			}


			Texture2D prevArrow = GUI.skin.GetStyle(BuildReportTool.Window.Settings.BIG_LEFT_ARROW_ICON_STYLE_NAME).normal
			                         .background;
			Texture2D nextArrow = GUI.skin.GetStyle(BuildReportTool.Window.Settings.BIG_RIGHT_ARROW_ICON_STYLE_NAME).normal
			                         .background;


			GUILayout.BeginHorizontal(GUILayout.Height(11));

			GUILayout.Label(" ", BuildReportTool.Window.Settings.TOP_BAR_BG_STYLE_NAME, BRT_BuildReportWindow.LayoutNone);

			// ------------------------------------------------------------------------------------------------------
			// File Filters

			var selectedFilterChanged = fileFilterGroupToUse.Draw(assetListUsed, position.width - 100);

			if (selectedFilterChanged)
			{
				_assetListEntryLastClickedIdx = -1;
				_filterIdxOfLastClickedAssetListEntry = NO_FILTER_VALUE;
			}

			// ------------------------------------------------------------------------------------------------------

			GUILayout.Space(20);

			// ------------------------------------------------------------------------------------------------------
			// Unused Assets Batch

			if (IsShowingUnusedAssets)
			{
				int batchNumber = buildReportToDisplay.UnusedAssetsBatchNum + 1;

				if (GUILayout.Button(prevArrow, BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME,
					    BRT_BuildReportWindow.LayoutNone) && (batchNumber - 1 >= 1))
				{
					// move to previous batch
					BuildReportTool.ReportGenerator.MoveUnusedAssetsBatchToPrev(buildReportToDisplay, fileFilterGroupToUse);
				}

				string batchLabel = string.Format("Batch {0}", batchNumber.ToString());
				GUILayout.Label(batchLabel, BuildReportTool.Window.Settings.TOP_BAR_LABEL_STYLE_NAME,
					BRT_BuildReportWindow.LayoutNone);

				if (GUILayout.Button(nextArrow, BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME,
					BRT_BuildReportWindow.LayoutNone))
				{
					// move to next batch
					// (possible to have no new batch anymore. if so, it will just fail silently)
					BuildReportTool.ReportGenerator.MoveUnusedAssetsBatchToNext(buildReportToDisplay, fileFilterGroupToUse);
				}
			}

			// ------------------------------------------------------------------------------------------------------

			// ------------------------------------------------------------------------------------------------------
			// Paginate Buttons

			BuildReportTool.SizePart[] assetListToUse = assetListUsed.GetListToDisplay(fileFilterGroupToUse);

			// how many assets overall in this entire list
			int assetListLength = 0;
			if (_searchResults != null && _searchResults.Length > 0)
			{
				assetListLength = _searchResults.Length;
			}
			else if (assetListToUse != null)
			{
				assetListLength = assetListToUse.Length;
			}

			// index of first asset to show, for current page.
			// This is an offset from the entire asset list.
			int viewOffset = _searchResults != null
				                 ? _searchViewOffset
				                 : assetListUsed.GetViewOffsetForDisplayedList(fileFilterGroupToUse);

			if (GUILayout.Button(prevArrow, BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME,
				    BRT_BuildReportWindow.LayoutNone) &&
			    (viewOffset - BuildReportTool.Options.AssetListPaginationLength >= 0))
			{
				if (_searchResults != null)
				{
					_searchViewOffset -= BuildReportTool.Options.AssetListPaginationLength;
				}
				else
				{
					assetListUsed.SetViewOffsetForDisplayedList(fileFilterGroupToUse,
						viewOffset - BuildReportTool.Options.AssetListPaginationLength);
				}

				_assetListScrollPos.y = 0;
			}

			// number of assets in current page
			int pageLength = Mathf.Min(viewOffset + BuildReportTool.Options.AssetListPaginationLength, assetListLength);

			// the max number of digits for the displayed offset counters
			string assetCountDigitNumFormat = string.Format("D{0}", assetListLength.ToString().Length.ToString());

			int offsetNonZeroBased = viewOffset + (pageLength > 0 ? 1 : 0);

			string paginateLabel = string.Format("Page {0} - {1} of {2}",
				offsetNonZeroBased.ToString(assetCountDigitNumFormat),
				pageLength.ToString(assetCountDigitNumFormat),
				assetListLength.ToString(assetCountDigitNumFormat));

			GUILayout.Label(paginateLabel, BuildReportTool.Window.Settings.TOP_BAR_LABEL_STYLE_NAME,
				BRT_BuildReportWindow.LayoutNone);

			if (GUILayout.Button(nextArrow, BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME,
				    BRT_BuildReportWindow.LayoutNone) &&
			    (viewOffset + BuildReportTool.Options.AssetListPaginationLength < assetListLength))
			{
				if (_searchResults != null)
				{
					_searchViewOffset += BuildReportTool.Options.AssetListPaginationLength;
				}
				else
				{
					assetListUsed.SetViewOffsetForDisplayedList(fileFilterGroupToUse,
						viewOffset + BuildReportTool.Options.AssetListPaginationLength);
				}

				_assetListScrollPos.y = 0;
			}

			// ------------------------------------------------------------------------------------------------------


			GUILayout.FlexibleSpace();

			_searchTextInput = GUILayout.TextField(_searchTextInput, "TextField-Search",
				BRT_BuildReportWindow.LayoutMinWidth200);
			if (GUILayout.Button(string.Empty, "TextField-Search-ClearButton", BRT_BuildReportWindow.LayoutNone))
			{
				ClearSearch();
			}

			// ------------------------------------------------------------------------------------------------------
			// Recalculate Imported sizes
			// (makes sense only for unused assets)

			if ((_currentListDisplayed != ListToDisplay.UsedAssets) &&
			    GUILayout.Button(Labels.RECALC_IMPORTED_SIZES,
				    BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME, BRT_BuildReportWindow.LayoutNone))
			{
				assetListUsed.PopulateImportedSizes();
			}

			if (!BuildReportTool.Options.AutoResortAssetsWhenUnityEditorRegainsFocus &&
			    BuildReportTool.Options.GetSizeBeforeBuildForUsedAssets &&
			    (_currentListDisplayed == ListToDisplay.UsedAssets) &&
			    GUILayout.Button(Labels.RECALC_SIZE_BEFORE_BUILD,
				    BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME, BRT_BuildReportWindow.LayoutNone))
			{
				assetListUsed.PopulateSizeInAssetsFolder();
			}

			// ------------------------------------------------------------------------------------------------------


			// ------------------------------------------------------------------------------------------------------
			// Selection buttons

			if (GUILayout.Button(Labels.SELECT_ALL_LABEL,
				BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME, BRT_BuildReportWindow.LayoutNone))
			{
				assetListUsed.AddAllDisplayedToSumSelection(fileFilterGroupToUse);
			}

			if (GUILayout.Button(Labels.SELECT_NONE_LABEL,
				BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME, BRT_BuildReportWindow.LayoutNone))
			{
				assetListUsed.ClearSelection();
				_assetListEntryLastClickedIdx = -1;
				_filterIdxOfLastClickedAssetListEntry = NO_FILTER_VALUE;
			}

			// ------------------------------------------------------------------------------------------------------


			// ------------------------------------------------------------------------------------------------------
			// Delete buttons

			if (ShouldShowDeleteButtons(buildReportToDisplay))
			{
				GUI.backgroundColor = Color.red;
				const string DEL_SELECTED_LABEL = "Delete selected";
				if (GUILayout.Button(DEL_SELECTED_LABEL,
					BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME, BRT_BuildReportWindow.LayoutNone))
				{
					InitiateDeleteSelectedUsed(buildReportToDisplay);
				}

				const string DELETE_ALL_LABEL = "Delete all";
				if (GUILayout.Button(DELETE_ALL_LABEL,
					BuildReportTool.Window.Settings.TOP_BAR_BTN_STYLE_NAME, BRT_BuildReportWindow.LayoutNone))
				{
					InitiateDeleteAllUnused(buildReportToDisplay);
				}

				GUI.backgroundColor = Color.white;
			}

			// ------------------------------------------------------------------------------------------------------

			GUILayout.EndHorizontal();


			GUILayout.Space(5);
		}


		string GetColumnHeaderStyle(BuildReportTool.AssetList.SortType sortTypeNeeded)
		{
			string styleResult = BuildReportTool.Window.Settings.LIST_COLUMN_HEADER_STYLE_NAME;

			if (_currentSortType == sortTypeNeeded)
			{
				if (_currentSortOrder == BuildReportTool.AssetList.SortOrder.Descending)
				{
					styleResult = BuildReportTool.Window.Settings.LIST_COLUMN_HEADER_DESC_STYLE_NAME;
				}
				else
				{
					styleResult = BuildReportTool.Window.Settings.LIST_COLUMN_HEADER_ASC_STYLE_NAME;
				}
			}

			return styleResult;
		}

		void DrawAssetList(Rect position, BuildInfo buildReportToDisplay, AssetDependencies assetDependencies,
			BuildReportTool.AssetList list, BuildReportTool.FileFilterGroup filter, int length)
		{
			if (list == null)
			{
				return;
			}

			if (_searchResults != null && _searchResults.Length == 0)
			{
				DrawCentralMessage(position, "No search results");
				return;
			}

			BuildReportTool.SizePart[] assetListToUse;

			var hasSearchResults = _searchResults != null;

			if (hasSearchResults && _searchResults.Length > 0)
			{
				assetListToUse = _searchResults;
			}
			else
			{
				assetListToUse = list.GetListToDisplay(filter);
			}

			if (assetListToUse == null)
			{
				return;
			}

			if (assetListToUse.Length == 0)
			{
				GUILayout.BeginHorizontal(BRT_BuildReportWindow.LayoutNone);
				GUILayout.Space(10);
				GUILayout.Label(Labels.NO_FILES_FOR_THIS_CATEGORY_LABEL,
					BuildReportTool.Window.Settings.INFO_TITLE_STYLE_NAME, BRT_BuildReportWindow.LayoutNone);
				GUILayout.EndHorizontal();

				return;
			}

			EditorGUIUtility.SetIconSize(BRT_BuildReportWindow.IconSize);

			int viewOffset = hasSearchResults ? _searchViewOffset : list.GetViewOffsetForDisplayedList(filter);

			// if somehow view offset was out of bounds of the SizePart[] array
			// reset it to zero
			if (viewOffset >= assetListToUse.Length)
			{
				list.SetViewOffsetForDisplayedList(filter, 0);
				viewOffset = 0;
			}

			int len = Mathf.Min(viewOffset + length, assetListToUse.Length);


			GUILayout.BeginHorizontal(BRT_BuildReportWindow.LayoutNone);


			// --------------------------------------------------------------------------------------------------------
			// column: asset path and name
			GUILayout.BeginVertical(BRT_BuildReportWindow.LayoutNone);
			var useAlt = false;

			GUILayout.BeginHorizontal(BRT_BuildReportWindow.LayoutNone);


			Rect assetPathCheckboxRect = _assetPathColumnHeaderRect;
			assetPathCheckboxRect.x += 5;
			assetPathCheckboxRect.y += 1;
			assetPathCheckboxRect.width = 20;
			assetPathCheckboxRect.height -= 1;

			_showAssetPath = GUI.Toggle(assetPathCheckboxRect, _showAssetPath, _assetPathCheckboxLabel);

			string sortTypeAssetFullPathStyleName = GetColumnHeaderStyle(BuildReportTool.AssetList.SortType.AssetFullPath);
			if (GUILayout.Button("     Asset Path", sortTypeAssetFullPathStyleName,
				BRT_BuildReportWindow.LayoutListHeight))
			{
				ToggleSort(list, BuildReportTool.AssetList.SortType.AssetFullPath, filter);
			}

			if (Event.current.type == EventType.Repaint)
			{
				_assetPathColumnHeaderRect = GUILayoutUtility.GetLastRect();
#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("_assetPathColumnHeaderRect: {0}\nyMax: {1}\n", _assetPathColumnHeaderRect.ToString(),
				_assetPathColumnHeaderRect.yMax.ToString(CultureInfo.InvariantCulture));
#endif
			}

			GUI.Toggle(assetPathCheckboxRect, _showAssetPath, _assetPathCheckboxLabel);

			// -----------------------------------------------------------------

			string sortTypeAssetFilenameStyleName = GetColumnHeaderStyle(BuildReportTool.AssetList.SortType.AssetFilename);
			if (GUILayout.Button("Asset Filename", sortTypeAssetFilenameStyleName, BRT_BuildReportWindow.LayoutListHeight))
			{
				ToggleSort(list, BuildReportTool.AssetList.SortType.AssetFilename, filter);
			}

			GUILayout.EndHorizontal();


			// --------------------------------------------------------------------------------------------------------

			var newEntryHoveredIdx = -1;

			_assetListScrollPos = GUILayout.BeginScrollView(_assetListScrollPos,
				BuildReportTool.Window.Settings.HIDDEN_SCROLLBAR_STYLE_NAME,
				BuildReportTool.Window.Settings.HIDDEN_SCROLLBAR_STYLE_NAME, BRT_BuildReportWindow.LayoutNone);

			var mousePos = Event.current.mousePosition;

			for (int n = viewOffset; n < len; ++n)
			{
				BuildReportTool.SizePart b = assetListToUse[n];

				string styleToUse = useAlt
					                    ? BuildReportTool.Window.Settings.LIST_SMALL_ALT_STYLE_NAME
					                    : BuildReportTool.Window.Settings.LIST_SMALL_STYLE_NAME;
				bool inSumSelect = list.InSumSelection(b);
				if (inSumSelect)
				{
					styleToUse = BuildReportTool.Window.Settings.LIST_SMALL_SELECTED_NAME;
				}

				GUILayout.BeginHorizontal(styleToUse, BRT_BuildReportWindow.LayoutNone);


				if (!BuildReportTool.Options.DoubleClickOnAssetWillPing)
				{
					// only asset entries inside the top-level assets folder can be pinged
					if (b.Name.IsInAssetsFolder())
					{
						if (GUILayout.Button("Ping", "ListButton", BRT_BuildReportWindow.LayoutPingButton))
						{
							if (list.GetSelectedCount() > 1 && list.InSumSelection(b) && Event.current.alt)
							{
								// ping multiple
								Utility.PingSelectedAssets(list);
							}
							else
							{
								Utility.PingAssetInProject(b.Name);
							}
						}
					}
					else
					{
						// add spacing where the ping button would be,
						// so that this entry aligns with the rest
						GUILayout.Space(38);
					}
				}


				_assetListEntry.image = AssetDatabase.GetCachedIcon(b.Name);
				var hasIcon = _assetListEntry.image != null;

				var mouseIsOnEmptySpaceForIcon = false;

				if (!hasIcon)
				{
					// entry has no icon, just add space so it aligns with the other entries
					GUILayout.Label(string.Empty, "DrawTexture", BRT_BuildReportWindow.LayoutIconWidth);

					if (Event.current.type == EventType.Repaint)
					{
						var emptySpaceForIconRect = GUILayoutUtility.GetLastRect();
						if (emptySpaceForIconRect.Contains(mousePos))
						{
							mouseIsOnEmptySpaceForIcon = true;
						}
					}
				}

				_assetListEntry.text = GetPrettyAssetPath(b.Name, n, _showAssetPath, inSumSelect);

				GUIStyle styleObjToUse = GUI.skin.GetStyle(styleToUse);
				Color temp = styleObjToUse.normal.textColor;
				int origLeft = styleObjToUse.padding.left;
				int origRight = styleObjToUse.padding.right;

				styleObjToUse.normal.textColor = styleObjToUse.onNormal.textColor;
				styleObjToUse.padding.right = 0;

				styleObjToUse.normal.textColor = temp;
				styleObjToUse.padding.left = 2;

				// the asset icon and name

				if (GUILayout.Button(_assetListEntry, styleObjToUse, BRT_BuildReportWindow.LayoutListHeight))
				{
					if (Event.current.control)
					{
						if (!inSumSelect)
						{
							list.AddToSumSelection(b);
							_assetListEntryLastClickedIdx = n;
						}
						else
						{
							list.ToggleSumSelection(b);
							_assetListEntryLastClickedIdx = -1;
						}
					}
					else if (Event.current.shift)
					{
						if (_assetListEntryLastClickedIdx != -1)
						{
							// select all from last clicked to here
							if (_assetListEntryLastClickedIdx < n)
							{
								for (int addToSelectIdx = _assetListEntryLastClickedIdx; addToSelectIdx <= n; ++addToSelectIdx)
								{
									list.AddToSumSelection(assetListToUse[addToSelectIdx]);
								}
							}
							else if (_assetListEntryLastClickedIdx > n)
							{
								for (int addToSelectIdx = n; addToSelectIdx <= _assetListEntryLastClickedIdx; ++addToSelectIdx)
								{
									list.AddToSumSelection(assetListToUse[addToSelectIdx]);
								}
							}
						}
						else
						{
							list.AddToSumSelection(b);
						}

						_assetListEntryLastClickedIdx = n;
					}
					else
					{
						// single select
						// -----------------------------

						// double-click detection for pinging
						if (BuildReportTool.Options.DoubleClickOnAssetWillPing &&
						    (EditorApplication.timeSinceStartup - _assetListEntryLastClickedTime) < DOUBLE_CLICK_THRESHOLD &&
						    b.Name.IsInAssetsFolder())
						{
							if (list.GetSelectedCount() > 1 && list.InSumSelection(b) && Event.current.alt)
							{
								// double-clicking on one of the selected assets while holding alt
								// ping multiple
								Utility.PingSelectedAssets(list);
							}
							else if (_assetListEntryLastClickedIdx == n)
							{
								// 2nd click on the same asset (i.e. double-click)
								Utility.PingAssetInProject(b.Name);
							}
						}


						// --------------------
						// selecting a different asset
						// click with no ctrl, alt, or shift
						if ((_assetListEntryLastClickedIdx != n ||
						     _filterIdxOfLastClickedAssetListEntry != filter.SelectedFilterIdx) &&
						    !Event.current.alt)
						{
							list.ClearSelection();
							list.AddToSumSelection(b);

							_assetListEntryLastClickedIdx = n;
							_filterIdxOfLastClickedAssetListEntry = filter.SelectedFilterIdx;

							// --------------------
							// update what's shown in the Asset Usage Panel

							if (b.Name.IsInResourcesFolder())
							{
								// this is a Resources asset
								_selectedIsAResourcesAsset = true;
								_selectedResourcesAssetPath = b.Name;
								_selectedResourcesAsset.text = System.IO.Path.GetFileName(_selectedResourcesAssetPath);
								_selectedResourcesAsset.image = AssetDatabase.GetCachedIcon(_selectedResourcesAssetPath);
							}
							else
							{
								_selectedIsAResourcesAsset = false;
								_selectedResourcesAssetPath = null;
							}

							if (_selectedAssetUsageDisplayIdx == ASSET_USAGE_DISPLAY_ALL)
							{
								_selectedAssetUserIdx = -1;
								_assetUsageAncestry.Clear();
								SetAssetUsageHistoryToFirstEndUser(b.Name, assetDependencies);
							}
							else if (_selectedAssetUsageDisplayIdx == ASSET_USAGE_DISPLAY_DIRECT)
							{
								ChangeAssetUserCrumbRootIfNeeded(b.Name);
							}
						}

						_assetListEntryLastClickedTime = EditorApplication.timeSinceStartup;
					}
				}

				styleObjToUse.padding.right = origRight;
				styleObjToUse.padding.left = origLeft;


#if BRT_ASSET_LIST_SCREEN_DEBUG
			//_debugText.AppendFormat("mousePos: {0}\n", mousePos.ToString());
#endif

				if (Event.current.type == EventType.Repaint)
				{
					// Have to do this during Repaint event because
					// GUILayoutUtility.GetLastRect() only works during that time.
					//
					// The problem is that our hover check should really only be done during
					// MouseMove event instead. The way it is right now, doing the hover check
					// every Repaint event, means it's doing this check over and over
					// even if the mouse is sitting still at the same position.
					//
					// However, we do mitigate this by not calling EditorWindow.Repaint() if
					// it's not needed.
					//
					// Also, getting GetLastRect() during Repaint event and then using
					// that value during MouseMove event means having to store the rect value
					// in a variable. Since we're checking for each entry in the asset list,
					// we'd have to store all the rects in a List
					// (we have one rect for each entry in the asset list).
					//
					// I don't know if that is too much processing,
					// so I'm leaving the code the way it is right now.

					var assetListEntryRect = GUILayoutUtility.GetLastRect();

					// note: Rects of the asset list entries do not overlap.
					// So actually, throughout all the iterations of this for-loop,
					// this if can only be successful once.
					if (assetListEntryRect.Contains(mousePos) || mouseIsOnEmptySpaceForIcon)
					{
						newEntryHoveredIdx = n;

						// ----------------
						// update what is considered the hovered asset, for use later on
						// when the tooltip will be drawn
						BRT_BuildReportWindow.UpdateHoveredAsset(b.Name, assetListEntryRect, IsShowingUsedAssets,
							buildReportToDisplay, assetDependencies);

						// ----------------
						// put a border on the icon to signify that it's the one being hovered
						// note: _assetListEntry.image currently has the icon of the asset we hovered
						Rect iconHoveredRect = assetListEntryRect;
						if (_assetListEntry.image != null)
						{
							iconHoveredRect.x += 1;
						}
						else
						{
							iconHoveredRect.x -= 15;
						}

						iconHoveredRect.y += 2;
						iconHoveredRect.width = 17;
						iconHoveredRect.height = 16;
						GUI.Box(iconHoveredRect, _assetListEntry.image, "IconHovered");

						// ----------------
						// if mouse is hovering over the correct area, we signify that
						// the tooltip thumbnail should be drawn
						if (BuildReportTool.Options.ShowTooltipThumbnail &&
						    (BuildReportTool.Options.ShowThumbnailOnHoverLabelToo ||
						     Mathf.Abs(mousePos.x - assetListEntryRect.x) < BRT_BuildReportWindow.ICON_WIDTH_WITH_PADDING) &&
						    BRT_BuildReportWindow.GetAssetPreview(b.Name) != null)
						{
							_shouldShowThumbnailOnHoveredAsset = true;
						}
						else
						{
							_shouldShowThumbnailOnHoveredAsset = false;
						}
					}
				}


				GUILayout.EndHorizontal();

				useAlt = !useAlt;
			} // end of for-loop for drawing all asset names

			if (Event.current.type == EventType.Repaint)
			{
				_assetListEntryHoveredIdx = newEntryHoveredIdx;
			}


#if BRT_ASSET_LIST_SCREEN_DEBUG
		_debugText.AppendFormat("_assetListEntryLastClickedTime: {0}\n",
			_assetListEntryLastClickedTime.ToString(CultureInfo.InvariantCulture));
		_debugText.AppendFormat("_assetListEntryHovered: {0}\n", _assetListEntryHoveredIdx.ToString());
#endif


			GUILayout.Space(SCROLLBAR_BOTTOM_PADDING);

			GUILayout.EndScrollView();

			GUILayout.EndVertical(); // end of column: asset path and name


			bool pressedRawSizeSortBtn = false;
			bool pressedImpSizeSortBtn = false;

			bool pressedSizeBeforeBuildSortBtn = false;

			// --------------------------------------------------------------------------------------------------------
			// column: raw file size


			if (IsShowingUsedAssets && (assetListToUse[0].SizeInAssetsFolderBytes != -1))
			{
				pressedSizeBeforeBuildSortBtn = DrawColumn(viewOffset, len,
					BuildReportTool.AssetList.SortType.SizeBeforeBuild, "Size Before Build   ", true, false,
					list, assetListToUse, (b) => b.SizeInAssetsFolder, ref _assetListScrollPos);
			}

			if (IsShowingUsedAssets && BuildReportTool.Options.ShowImportedSizeForUsedAssets)
			{
				pressedRawSizeSortBtn = DrawColumn(viewOffset, len,
					BuildReportTool.AssetList.SortType.ImportedSizeOrRawSize, "Size In Build", true, false,
					list, assetListToUse, (b) =>
					{
						// assets in the "StreamingAssets" folder do not have an imported size
						// in those cases, the raw size is the same as the imported size
						// so just use the raw size
						if (b.ImportedSize == "N/A")
						{
							return b.RawSize;
						}

						return b.ImportedSize;
					}, ref _assetListScrollPos);
			}

			if (IsShowingUnusedAssets || (IsShowingUsedAssets && !BuildReportTool.Options.ShowImportedSizeForUsedAssets))
			{
				pressedRawSizeSortBtn = DrawColumn(viewOffset, len, BuildReportTool.AssetList.SortType.RawSize,
					(IsShowingUnusedAssets ? "Raw Size" : "Size In Build"), true, false,
					list, assetListToUse, (b) => b.RawSize, ref _assetListScrollPos);
			}


			bool showScrollbarForImportedSize = IsShowingUnusedAssets;


			// --------------------------------------------------------------------------------------------------------
			// column: imported file size


			if (IsShowingUnusedAssets)
			{
				pressedImpSizeSortBtn = DrawColumn(viewOffset, len, BuildReportTool.AssetList.SortType.ImportedSize,
					"Imported Size   ", true, showScrollbarForImportedSize,
					list, assetListToUse, (b) => b.ImportedSize, ref _assetListScrollPos);
			}


			// --------------------------------------------------------------------------------------------------------
			// column: percentage to total size

			bool pressedPercentSortBtn = false;

			if (IsShowingUsedAssets)
			{
				pressedPercentSortBtn = DrawColumn(viewOffset, len, BuildReportTool.AssetList.SortType.PercentSize,
					"Percent   ", true, true,
					list, assetListToUse, (b) =>
					{
						string text = string.Format("{0}%", b.Percentage.ToString(CultureInfo.InvariantCulture));
						if (b.Percentage < 0)
						{
							text = Labels.NON_APPLICABLE_PERCENTAGE_LABEL;
						}

						return text;
					}, ref _assetListScrollPos);
			}

			// --------------------------------------------------------------------------------------------------------

			if (pressedRawSizeSortBtn)
			{
				var sortType = BuildReportTool.AssetList.SortType.RawSize;
				if (IsShowingUsedAssets && BuildReportTool.Options.ShowImportedSizeForUsedAssets)
				{
					sortType = BuildReportTool.AssetList.SortType.ImportedSizeOrRawSize;
				}

				ToggleSort(list, sortType, filter);
			}
			else if (pressedSizeBeforeBuildSortBtn)
			{
				ToggleSort(list, BuildReportTool.AssetList.SortType.SizeBeforeBuild, filter);
			}
			else if (pressedImpSizeSortBtn)
			{
				ToggleSort(list, BuildReportTool.AssetList.SortType.ImportedSize, filter);
			}
			else if (pressedPercentSortBtn)
			{
				ToggleSort(list, BuildReportTool.AssetList.SortType.PercentSize, filter);
			}

			GUILayout.EndHorizontal();
		}

		public static string GetPathColor(bool inSumSelect)
		{
			const string PATH_COLOR_UNSELECTED_WHITE_SKIN = "4f4f4fff";
			const string PATH_COLOR_SELECTED_WHITE_SKIN = "cececeff";

			const string PATH_COLOR_UNSELECTED_DARK_SKIN = "767676ff";
			const string PATH_COLOR_SELECTED_DARK_SKIN = "c2c2c2ff";

			string colorUsedForPath = PATH_COLOR_UNSELECTED_WHITE_SKIN;
			if (EditorGUIUtility.isProSkin || BRT_BuildReportWindow.FORCE_USE_DARK_SKIN)
			{
				colorUsedForPath = PATH_COLOR_UNSELECTED_DARK_SKIN;
			}

			if (inSumSelect)
			{
				if (EditorGUIUtility.isProSkin || BRT_BuildReportWindow.FORCE_USE_DARK_SKIN)
				{
					colorUsedForPath = PATH_COLOR_SELECTED_DARK_SKIN;
				}
				else
				{
					colorUsedForPath = PATH_COLOR_SELECTED_WHITE_SKIN;
				}
			}

			return colorUsedForPath;
		}


		delegate string ColumnDisplayDelegate(BuildReportTool.SizePart b);

		bool DrawColumn(int sta, int end, BuildReportTool.AssetList.SortType columnType, string columnName,
			bool allowSort,
			bool showScrollbar, BuildReportTool.AssetList assetListCollection, BuildReportTool.SizePart[] assetList,
			ColumnDisplayDelegate dataToDisplay, ref Vector2 scrollbarPos)
		{
			bool buttonPressed = false;
			GUILayout.BeginVertical(BRT_BuildReportWindow.LayoutNone);


			// ----------------------------------------------------------
			// column header
			string sortTypeStyleName = BuildReportTool.Window.Settings.LIST_COLUMN_HEADER_STYLE_NAME;
			if (allowSort && _currentSortType == columnType)
			{
				if (_currentSortOrder == BuildReportTool.AssetList.SortOrder.Descending)
				{
					sortTypeStyleName = BuildReportTool.Window.Settings.LIST_COLUMN_HEADER_DESC_STYLE_NAME;
				}
				else
				{
					sortTypeStyleName = BuildReportTool.Window.Settings.LIST_COLUMN_HEADER_ASC_STYLE_NAME;
				}
			}

			if (GUILayout.Button(columnName, sortTypeStyleName, BRT_BuildReportWindow.LayoutListHeight) && allowSort)
			{
				buttonPressed = true;
			}


			// ----------------------------------------------------------
			// scrollbar
			if (showScrollbar)
			{
				scrollbarPos = GUILayout.BeginScrollView(scrollbarPos,
					BuildReportTool.Window.Settings.HIDDEN_SCROLLBAR_STYLE_NAME,
					"verticalscrollbar", BRT_BuildReportWindow.LayoutNone);
			}
			else
			{
				scrollbarPos = GUILayout.BeginScrollView(scrollbarPos,
					BuildReportTool.Window.Settings.HIDDEN_SCROLLBAR_STYLE_NAME,
					BuildReportTool.Window.Settings.HIDDEN_SCROLLBAR_STYLE_NAME, BRT_BuildReportWindow.LayoutNone);
			}


			// ----------------------------------------------------------
			// actual contents
			bool useAlt = false;

			BuildReportTool.SizePart b;
			for (int n = sta; n < end; ++n)
			{
				b = assetList[n];

				string styleToUse = useAlt
					                    ? BuildReportTool.Window.Settings.LIST_SMALL_ALT_STYLE_NAME
					                    : BuildReportTool.Window.Settings.LIST_SMALL_STYLE_NAME;
				if (assetListCollection.InSumSelection(b))
				{
					styleToUse = BuildReportTool.Window.Settings.LIST_SMALL_SELECTED_NAME;
				}

				GUILayout.Label(dataToDisplay(b), styleToUse, BRT_BuildReportWindow.LayoutListHeightMinWidth90);

				useAlt = !useAlt;
			}

			GUILayout.Space(SCROLLBAR_BOTTOM_PADDING);

			GUILayout.EndScrollView();

			GUILayout.EndVertical();

			return buttonPressed;
		}
	}
}