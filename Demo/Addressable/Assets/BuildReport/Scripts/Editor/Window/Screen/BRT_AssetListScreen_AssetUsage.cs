//#define BRT_ASSET_LIST_SCREEN_DEBUG

using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Globalization;


namespace BuildReportTool.Window.Screen
{
	public partial class AssetList
	{
		// ----------------------------------------------------------------

		/// <summary>
		/// "is used by"
		/// </summary>
		static readonly GUIContent AssetUsageIsUsedByLabel = new GUIContent("is used by");

		/// <summary>
		/// "which is used by"
		/// </summary>
		static readonly GUIContent AssetUsageWhichIsUsedByLabel = new GUIContent("which is used by");

		// ---------------------------------------

		/// <summary>
		/// "is used as default material by"
		/// </summary>
		static readonly GUIContent AssetUsageIsUsedAsDefaultMaterialByLabel =
			new GUIContent("is used as default material by");

		/// <summary>
		/// "which is used as default material by"
		/// </summary>
		static readonly GUIContent AssetUsageWhichIsUsedAsDefaultMaterialByLabel =
			new GUIContent("which is used as default material by");

		// ---------------------------------------

		/// <summary>
		/// "is used as default value by"
		/// </summary>
		static readonly GUIContent AssetUsageIsUsedAsDefaultValueByLabel =
			new GUIContent("is used as default value by");

		/// <summary>
		/// "which is used as default value by"
		/// </summary>
		static readonly GUIContent AssetUsageWhichIsUsedAsDefaultValueByLabel =
			new GUIContent("which is used as default value by");

		// ---------------------------------------

		/// <summary>
		/// "is a Resources asset, so it's always in the build. But it's also used by"
		/// </summary>
		static readonly GUIContent AssetUsageIsAResourcesAssetButAlsoUsedByLabel =
			new GUIContent("is a Resources asset, so it's always in the build. But it's also used by");

		/// <summary>
		/// "which is a Resources asset, so it's always in the build. But it's also used by"
		/// </summary>
		static readonly GUIContent AssetUsageWhichIsAResourcesAssetButAlsoUsedByLabel =
			new GUIContent("which is a Resources asset, so it's always in the build. But it's also used by");

		// --------------------------------------------------

		/// <summary>
		/// "which is in the build"
		/// </summary>
		static readonly GUIContent AssetUsageWhichIsInTheBuildLabel = new GUIContent("which is in the build");

		/// <summary>
		/// "is a Resources asset, so it's always in the build"
		/// </summary>
		static readonly GUIContent AssetUsageIsAResourcesAssetLabel =
			new GUIContent("is a Resources asset, so it's always in the build");

		/// <summary>
		/// "which is a Resources asset, so it's always in the build"
		/// </summary>
		static readonly GUIContent AssetUsageWhichIsAResourcesAssetLabel =
			new GUIContent("which is a Resources asset, so it's always in the build");

		/// <summary>
		/// "(cyclic dependency)"
		/// </summary>
		static readonly GUIContent AssetUsageWhichIsACyclicDependencyLabel = new GUIContent("(cyclic dependency)");

		static readonly GUIContent AssetUsageAncestryDefaultMaterialInFbxOfScene = new GUIContent(
			"* even though the scene is certainly using the material, Build Report Tool is not certain that the instantiated fbx in the scene is really the one using the material");

		// ----------------------------------------------------------------

		struct PrettyAssetLabel
		{
			public string AssetPath;
			public string AssetPathSelected;
			public string AssetName;
		}

		struct PrettyAssetLabelWithNumber
		{
			public string AssetPath;
			public string AssetPathSelected;
			public string AssetName;
			public int Number;
		}

		readonly Dictionary<string, PrettyAssetLabel> _prettyAssetLabels = new Dictionary<string, PrettyAssetLabel>();

		readonly Dictionary<string, PrettyAssetLabelWithNumber> _prettyAssetLabelsWithNumber =
			new Dictionary<string, PrettyAssetLabelWithNumber>();

		string GetPrettyAssetPath(string assetPath, bool showAssetPath, bool selected)
		{
			PrettyAssetLabel entry;

			if (_prettyAssetLabels.ContainsKey(assetPath))
			{
				entry = _prettyAssetLabels[assetPath];
			}
			else
			{
				var path = BuildReportTool.Util.GetAssetPath(assetPath);
				var separator = BuildReportTool.Util.GetAssetPathToNameSeparator(assetPath);
				var filename = BuildReportTool.Util.GetAssetFilename(assetPath);

				entry.AssetPathSelected = string.Format("<color=#{0}>{1}{2}</color><color=white><b>{3}</b></color>",
					BuildReportTool.Window.Screen.AssetList.GetPathColor(true),
					path, separator, filename);

				entry.AssetPath = string.Format("<color=#{0}>{1}{2}</color><b>{3}</b>",
					BuildReportTool.Window.Screen.AssetList.GetPathColor(false),
					path, separator, filename);

				entry.AssetName = string.Format("<b>{0}</b>", filename);

				_prettyAssetLabels.Add(assetPath, entry);
			}

			if (showAssetPath)
			{
				if (selected)
				{
					return entry.AssetPathSelected;
				}
				else
				{
					return entry.AssetPath;
				}
			}
			else
			{
				return entry.AssetName;
			}
		}

		string GetPrettyAssetPath(string assetPath, int number, bool showAssetPath, bool selected)
		{
			PrettyAssetLabelWithNumber entry;

			if (_prettyAssetLabelsWithNumber.ContainsKey(assetPath))
			{
				entry = _prettyAssetLabelsWithNumber[assetPath];
			}
			else
			{
				entry.AssetPath = null;
				entry.AssetPathSelected = null;
				entry.AssetName = null;
				entry.Number = -1;
				_prettyAssetLabelsWithNumber.Add(assetPath, entry);
			}

			if (showAssetPath)
			{
				if (selected)
				{
					if (string.IsNullOrEmpty(entry.AssetPathSelected) || entry.Number != number)
					{
						entry.AssetPathSelected = string.Format(" {0}. <color=#{1}>{2}{3}</color><b>{4}</b>",
							(number + 1).ToString(),
							BuildReportTool.Window.Screen.AssetList.GetPathColor(true),
							BuildReportTool.Util.GetAssetPath(assetPath),
							BuildReportTool.Util.GetAssetPathToNameSeparator(assetPath),
							BuildReportTool.Util.GetAssetFilename(assetPath));
						entry.Number = number;
						_prettyAssetLabelsWithNumber[assetPath] = entry;
					}

					return entry.AssetPathSelected;
				}
				else
				{
					if (string.IsNullOrEmpty(entry.AssetPath) || entry.Number != number)
					{
						entry.AssetPath = string.Format(" {0}. <color=#{1}>{2}{3}</color><b>{4}</b>",
							(number + 1).ToString(),
							BuildReportTool.Window.Screen.AssetList.GetPathColor(false),
							BuildReportTool.Util.GetAssetPath(assetPath),
							BuildReportTool.Util.GetAssetPathToNameSeparator(assetPath),
							BuildReportTool.Util.GetAssetFilename(assetPath));
						entry.Number = number;
						_prettyAssetLabelsWithNumber[assetPath] = entry;
					}

					return entry.AssetPath;
				}
			}
			else
			{
				if (string.IsNullOrEmpty(entry.AssetName) || entry.Number != number)
				{
					entry.AssetName = string.Format(" {0}. <b>{1}</b>",
						(number + 1).ToString(), BuildReportTool.Util.GetAssetFilename(assetPath));
					entry.Number = number;
					_prettyAssetLabelsWithNumber[assetPath] = entry;
				}

				return entry.AssetName;
			}
		}

		/// <summary>
		/// The size of the Asset Usage Panel that shows up below the Asset Screen.
		/// </summary>
		Rect _assetUsageRect;

		/// <summary>
		/// Upper portion of the Asset Usage Panel that shows toolbar plus contextual info.
		/// </summary>
		Rect _assetInfoPanelRect;

		/// <summary>
		/// Scrollbar pos for the asset user list.
		/// </summary>
		Vector2 _assetUsagePanelScrollbarPos;

		/// <summary>
		/// Re-used GUIContent for drawing the asset user list.
		/// </summary>
		readonly GUIContent _assetUsageEntryLabel = new GUIContent();

		/// <summary>
		/// Which asset is selected/highlighted in the Asset User List.
		/// </summary>
		int _selectedAssetUserIdx = -1;

		/// <summary>
		/// Used when the Asset User List is showing "All" (flattened),
		/// meaning show both direct and indirect users in one giant list.
		///
		/// This is the chain of "which is used by", "which is used by", etc.
		/// chain for the currently selected asset user.
		///
		/// The very first element in the list is the asset being looked at,
		/// and the very last element is, most often, the scene where it's used,
		/// telling the user why the asset got included in the build.
		/// </summary>
		readonly List<AssetUsageAncestry> _assetUsageAncestry = new List<AssetUsageAncestry>();

		/// <summary>
		/// Used when the Asset User List is showing "Direct",
		/// meaning showing only direct users.
		///
		/// This is the breadcrumb history of inspected direct users.
		/// </summary>
		readonly List<AssetUserCrumb> _assetUserCrumbs = new List<AssetUserCrumb>();

		struct AssetUserCrumb
		{
			public string AssetPath;
			public float ScrollbarPosY;
		}

		int _assetUserCrumbActiveIdx;

		float _preferredDirectAssetUserListViewHeight;

		/// <summary>
		/// True when the asset selected is from a Resources folder, meaning it has no
		/// asset dependencies. It is automatically included in the build because of being
		/// in a Resources folder.
		/// </summary>
		bool _selectedIsAResourcesAsset;

		/// <summary>
		/// When the selected asset in the main asset list is a Resources asset, this stores
		/// the filename and icon.
		/// </summary>
		readonly GUIContent _selectedResourcesAsset = new GUIContent();

		/// <summary>
		/// Path to the selected Resources asset, starting from "Assets/"
		/// </summary>
		string _selectedResourcesAssetPath;

		/// <summary>
		/// Special case when a scene is using an fbx directly (did not save it as a prefab first).
		/// In this case, it's impossible to tell whether the fbx in that scene is using its
		/// default material, or if it's overriden to use no material. So, without opening the scene
		/// and checking directly, we cannot be sure of the Asset Usage Ancestry in this situation.
		/// </summary>
		bool _assetUsageAncestryHasFbxUsingDefaultMaterialUsedInScene;

		/// <summary>
		/// Toggled by user to show a list of all users of selected asset, "users" being other assets.
		/// </summary>
		bool _showAssetUsagesList;

		struct AssetUsageAncestry
		{
			public GUIContent Label;
			public string AssetPath;
			public bool CyclicDependency;
		}

		Texture _indentLine;

		static readonly string[] AssetUsageDisplayLabel = new[]
		{
			"All", "Direct", "End"
		};

		const int ASSET_USAGE_DISPLAY_ALL = 0;
		const int ASSET_USAGE_DISPLAY_DIRECT = 1;
		const int ASSET_USAGE_DISPLAY_END = 2;

		int _selectedAssetUsageDisplayIdx = ASSET_USAGE_DISPLAY_ALL;

		const int ASSET_USAGE_HISTORY_ROW_SPACING = 2;
		const int ASSET_USAGE_HISTORY_LAST_ROW_PADDING = 2;

		const int ASSET_INFO_ROW_HEIGHT = 20;

		// ----------------------------------------------------------------

		static bool IsFileNextToFile(List<AssetUsageAncestry> list, int idx, string fileTypeInIdx, string fileTypeInNext)
		{
			return !string.IsNullOrEmpty(list[idx].AssetPath) && list[idx].AssetPath.IsFileOfType(fileTypeInIdx) &&
			       (idx < list.Count - 1) &&
			       !string.IsNullOrEmpty(list[idx + 1].AssetPath) && list[idx + 1].AssetPath.IsFileOfType(fileTypeInNext);
		}

		public void DrawAssetUsage(Rect position, BuildReportTool.AssetList listToDisplay,
			BuildInfo buildReportToDisplay, AssetDependencies assetDependencies)
		{
			if (buildReportToDisplay == null)
			{
				_assetUsageRect.height = 0;
				return;
			}

			if (listToDisplay == null)
			{
				_assetUsageRect.height = 0;
				return;
			}

			if (assetDependencies == null)
			{
				_assetUsageRect.height = 0;
				return;
			}

			var assetStyle = GUI.skin.GetStyle("Asset");

#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("listToDisplay.GetSelectedCount(): {0}\n",
				listToDisplay.GetSelectedCount().ToString());
#endif

			if (listToDisplay.GetSelectedCount() != 1)
			{
				// no asset selected, or too many selected
				_assetUsageRect.height = 0;
				return;
			}

			var selectedAsset = listToDisplay.GetLastSelected();

#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("selectedAsset: {0}\n",
				selectedAsset != null ? selectedAsset.Name : "<i>null</i>");
#endif

			if (selectedAsset == null)
			{
				// selected is null?
				_assetUsageRect.height = 0;
				return;
			}

			var dependencies = assetDependencies.GetAssetDependencies();

			if (dependencies == null)
			{
				_assetUsageRect.height = 0;
				return;
			}

#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("AssetDependencies has \"{0}\" ? {1}\n",
				selectedAsset.Name,
				dependencies.ContainsKey(selectedAsset.Name).ToString());
#endif

			var selectedHasNoAssetDependencies = false;
			DependencyEntry selectedAssetDependencies;

			if (dependencies.TryGetValue(selectedAsset.Name, out selectedAssetDependencies))
			{
				// There may be record of selected Asset but check first if
				// selected Asset has no recorded users

				var selectedAssetUsers = selectedAssetDependencies != null ? selectedAssetDependencies.Users : null;

#if BRT_ASSET_LIST_SCREEN_DEBUG
				_debugText.AppendFormat("selectedAssetDependencies.Users.Count: {0}\n",
					selectedAssetUsers != null ? selectedAssetUsers.Count.ToString() : "-1");
#endif
				if (selectedAssetUsers == null || selectedAssetUsers.Count <= 0)
				{
					// No asset is using the selected asset
					selectedHasNoAssetDependencies = true;
				}
			}
			else
			{
				// selected asset is not in the calculated
				// Asset Dependencies of the project
				selectedAssetDependencies = null;
				selectedHasNoAssetDependencies = true;
			}

#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("selectedHasNoAssetDependencies: {0}\n_selectedIsAResourcesAsset: {1}\n",
				selectedHasNoAssetDependencies.ToString(), _selectedIsAResourcesAsset.ToString());
#endif

			var assetInfoPanelNoListStyle = GUI.skin.GetStyle("AssetInfoPanelNoList");
			var assetInfoPanelStyle = GUI.skin.GetStyle("AssetInfoPanel");
			if (_showAssetUsagesList)
			{
				if (_selectedAssetUsageDisplayIdx == ASSET_USAGE_DISPLAY_ALL)
				{
					assetInfoPanelStyle = GUI.skin.GetStyle("AssetInfoPanelToolbarTopAllList");
				}
				else
				{
					assetInfoPanelStyle = GUI.skin.GetStyle("AssetInfoPanelToolbarTop");
				}
			}

			if (selectedHasNoAssetDependencies)
			{
				// Selected asset is not used by another asset and/or is not using any asset, so we will abort.

				// But if it's a Resources asset, we will at least indicate so.
				// It's most likely this Resources asset is only referenced in code,
				// (or also could be not at all!)
				if (_selectedIsAResourcesAsset)
				{
					var height = ASSET_INFO_ROW_HEIGHT + assetInfoPanelNoListStyle.padding.vertical;
					_assetUsageRect =
						new Rect(0, position.height - height, position.width, height);

					_assetUsageRect.y = Mathf.RoundToInt(_assetUsageRect.y);

					GUILayout.Space(height);
					GUILayout.BeginArea(_assetUsageRect);


					GUILayout.BeginVertical(string.Empty, assetInfoPanelNoListStyle, BRT_BuildReportWindow.LayoutNone);
					GUILayout.BeginHorizontal(BRT_BuildReportWindow.LayoutNone);

					if (GUILayout.Button(_selectedResourcesAsset, assetStyle, BRT_BuildReportWindow.LayoutNone))
					{
						Utility.PingAssetInProject(_selectedResourcesAssetPath);
					}

					if (Event.current.type == EventType.Repaint &&
					    (Event.current.mousePosition.x < position.width ||
					     Event.current.mousePosition.y < position.height))
					{
						var assetUsageAncestryEntryRect = GUILayoutUtility.GetLastRect();

						if (assetUsageAncestryEntryRect.Contains(Event.current.mousePosition))
						{
							// there really isn't an asset usage ancestry list in this case,
							// but we do this to flag the code that a tooltip should be drawn
							_assetUsageAncestryHoveredIdx = 0;

							// ----------------
							// update what is considered the hovered asset, for use later on
							// when the tooltip will be drawn
							BRT_BuildReportWindow.UpdateHoveredAsset(_selectedResourcesAssetPath,
								assetUsageAncestryEntryRect, IsShowingUsedAssets,
								buildReportToDisplay, assetDependencies);

							// ----------------
							// if mouse is hovering over the correct area, we signify that
							// the tooltip thumbnail should be drawn
							if (BuildReportTool.Options.ShowTooltipThumbnail &&
							    BRT_BuildReportWindow.GetAssetPreview(_selectedResourcesAssetPath) != null)
							{
								_shouldShowThumbnailOnHoveredAsset = true;
							}
							else
							{
								_shouldShowThumbnailOnHoveredAsset = false;
							}
						}
						else
						{
							// there's only 1 asset being displayed in the asset usage ancestry panel
							// which is the resources asset that's selected
							// so if the mouse isn't on it, then we're sure it's not on any
							// other asset usage ancestry entry
							_assetUsageAncestryHoveredIdx = -1;
						}
					}

					GUILayout.Label(AssetUsageIsAResourcesAssetLabel, "LabelSingleLine", BRT_BuildReportWindow.LayoutNone);

					GUILayout.EndHorizontal();
					GUILayout.EndVertical();

					GUILayout.EndArea();
				}
				else
				{
					_assetUsageRect.height = 0;
				}

				return;
			}

			// at this point, we are sure selectedAssetDependencies isn't null

			var usersFlattened = selectedAssetDependencies.UsersFlattened;

			if (usersFlattened == null || usersFlattened.Count == 0)
			{
				// no users?
				_assetUsageRect.height = 0;
				return;
			}

			var expandButtonStyle = GUI.skin.GetStyle("ExpandButton");

			var availableWidth = position.width - 10;

#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("availableWidth: {0}\nexpandButtonStyle.lineHeight: {1}\n",
				availableWidth.ToString(CultureInfo.InvariantCulture),
				expandButtonStyle.lineHeight.ToString(CultureInfo.InvariantCulture));

#endif

#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("_selectedAssetUserIdx: {0}\n_showAllAssetUsagesList: {1}\n",
				_selectedAssetUserIdx.ToString(),
				_showAssetUsagesList.ToString());
#endif

			// expand button height is the height of the small toolbar
			float assetInfoPanelHeight = expandButtonStyle.lineHeight;

			switch (_selectedAssetUsageDisplayIdx)
			{
				case ASSET_USAGE_DISPLAY_ALL:
				{
					var numberOfRowsInAssetUsageAncestry = 0;
					if (_selectedAssetUserIdx != -1)
					{
						numberOfRowsInAssetUsageAncestry =
							GetNumberOfAssetUsageAncestryRows(_assetUsageAncestry, availableWidth);

#if BRT_ASSET_LIST_SCREEN_DEBUG
						_debugText.AppendFormat("numberOfRowsInAssetUsageTraceHistory: {0}\n",
							numberOfRowsInAssetUsageAncestry.ToString());
#endif
					}

					assetInfoPanelHeight +=
						(ASSET_INFO_ROW_HEIGHT * numberOfRowsInAssetUsageAncestry) + assetInfoPanelStyle.padding.vertical;

					if (numberOfRowsInAssetUsageAncestry > 1)
					{
						// asset usage ancestry is using up more than 1 row
						// include the spacing in-between rows
						assetInfoPanelHeight += ASSET_USAGE_HISTORY_ROW_SPACING * (numberOfRowsInAssetUsageAncestry - 1);
						assetInfoPanelHeight += ASSET_USAGE_HISTORY_LAST_ROW_PADDING;
					}

					if (_assetUsageAncestryHasFbxUsingDefaultMaterialUsedInScene)
					{
						assetInfoPanelHeight +=
							GUI.skin.label.CalcHeight(AssetUsageAncestryDefaultMaterialInFbxOfScene, position.width) +
							GUI.skin.label.margin.vertical;
					}

					break;
				}

				case ASSET_USAGE_DISPLAY_DIRECT:
					//assetUsageToolbarHeight += breadcrumbLeftStyle.lineHeight + assetInfoPanelStyle.padding.vertical;

					// height of the breadcrumbs chain + padding
					// there's only one row of breadcrumbs so it's a constant value
					assetInfoPanelHeight += 20;
					break;
			}

#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("_selectedAssetUsageDisplayIdx: {0}\nassetInfoToolbarHeight: {1}\n",
				_selectedAssetUsageDisplayIdx.ToString(),
				assetInfoPanelHeight.ToString(CultureInfo.InvariantCulture));
#endif
			// ----------------------------------------------------

			int assetUsageScrollViewHeight;
			int heightToUse;

			var assetUsageListScrollViewHeightIsClamped = false;

			// ----------------------------------------------------
			// getting the height of the asset users list

			float assetUsageListHeight = 0;
			float assetUsageListRealHeight = 0;
			if (_showAssetUsagesList)
			{
				switch (_selectedAssetUsageDisplayIdx)
				{
					case ASSET_USAGE_DISPLAY_ALL:
						// currently showing asset usage flattened list
						assetUsageListHeight =
							(BRT_BuildReportWindow.LIST_HEIGHT * usersFlattened.Count) + 10; // 10 for some padding
						assetUsageListRealHeight = assetUsageListHeight;
						break;

					case ASSET_USAGE_DISPLAY_DIRECT:
						// currently showing asset direct users list
						var countToUse = selectedAssetDependencies.Users.Count;

						if (_assetUserCrumbs.Count > 0 && _assetUserCrumbActiveIdx >= 0 &&
						    _assetUserCrumbActiveIdx < _assetUserCrumbs.Count)
						{
							var activeAssetUserCrumb = _assetUserCrumbs[_assetUserCrumbActiveIdx].AssetPath;

							{
								DependencyEntry activeAssetUserCrumbDependencyEntry;
								if (dependencies.TryGetValue(activeAssetUserCrumb, out activeAssetUserCrumbDependencyEntry))
								{
									countToUse = activeAssetUserCrumbDependencyEntry.Users.Count;
								}
							}
						}

						var initialListViewHeight =
							(BRT_BuildReportWindow.LIST_HEIGHT * selectedAssetDependencies.Users.Count) +
							10; // 10 for some padding;

						assetUsageListRealHeight =
							(BRT_BuildReportWindow.LIST_HEIGHT * countToUse) + 10; // 10 for some padding


						if (initialListViewHeight > _preferredDirectAssetUserListViewHeight)
						{
							_preferredDirectAssetUserListViewHeight = initialListViewHeight;
						}

						if (assetUsageListRealHeight > _preferredDirectAssetUserListViewHeight)
						{
							_preferredDirectAssetUserListViewHeight = assetUsageListRealHeight;
						}

						assetUsageListHeight = _preferredDirectAssetUserListViewHeight;

						break;

					case ASSET_USAGE_DISPLAY_END:
					{
						// currently showing asset end users list
						var endUsersList = selectedAssetDependencies.GetEndUserLabels();
						if (endUsersList.Count == 0)
						{
							BuildReportTool.AssetDependencies.PopulateAssetEndUsers(selectedAsset.Name, assetDependencies);
						}

						assetUsageListHeight =
							(BRT_BuildReportWindow.LIST_HEIGHT * endUsersList.Count) + 10; // 10 for some padding
						assetUsageListRealHeight = assetUsageListHeight;
						break;
					}
				}


				var properHeight = assetInfoPanelHeight + assetUsageListHeight;

				if (properHeight > position.height / 2)
				{
					// asset usage panel height is too much. clamp it
					// scrollview also has to be limited
					heightToUse = Mathf.RoundToInt(position.height / 2);
					assetUsageScrollViewHeight = Mathf.RoundToInt(heightToUse - assetInfoPanelHeight);
					assetUsageListScrollViewHeightIsClamped = true;
				}
				else
				{
					heightToUse = Mathf.RoundToInt(properHeight);
					assetUsageScrollViewHeight = Mathf.RoundToInt(assetUsageListHeight);
				}
			}
			else
			{
				// not showing asset usage flattened list

				heightToUse = Mathf.RoundToInt(assetInfoPanelHeight);
				assetUsageScrollViewHeight = 0;
			}

			// ----------------------------------------------------

			heightToUse += 6; // compensate for the bottom edge of the window border


			// ----------------------------------------------------
			// Reserve the space used for the entire Asset Info Panel

			GUILayout.Space(heightToUse);

			// ----------------------------------------------------
			// We draw the Asset Usage Panel from a GUILayout.Area
			// that will occupy that space we reserved just now

			_assetUsageRect =
				new Rect(0, position.height - heightToUse, position.width, heightToUse);

			_assetUsageRect.y = Mathf.RoundToInt(_assetUsageRect.y);
			if (_showAssetUsagesList)
			{
				_assetUsageRect.y -= 3;
				_assetUsageRect.height += 2;
			}

			// ----------------------------------------------------

			GUILayout.BeginArea(_assetUsageRect);

			// ----------------------------------------------------
			// Asset Info Panel

			GUILayout.BeginVertical(string.Empty, assetInfoPanelStyle, BRT_BuildReportWindow.LayoutNone);

			if (_showAssetUsagesList)
			{
				// toolbar at top
				// reserve space for the toolbar
				GUILayout.Space(ASSET_INFO_TOOLBAR_HEIGHT);
			}

			DrawAssetInfoPanel(position, availableWidth, buildReportToDisplay, assetDependencies);

			GUILayout.EndVertical(); // end of Asset Info Panel
			if (Event.current.type == EventType.Repaint)
			{
				_assetInfoPanelRect = GUILayoutUtility.GetLastRect();
				//_assetInfoPanelRect.height += ASSET_INFO_TOOLBAR_HEIGHT;
			}


			// ----------------------------------------------------
			// Asset Users List

			var newEntryHoveredIdx = -1;
			string newEntryHoveredAssetPath = null;
			Rect newEntryHoveredRect = new Rect();

			if (_showAssetUsagesList)
			{
				// the rect inside the scrollview. it has the real height of the asset user list
				var scrollViewRect = new Rect(0, 0, position.width - 15, assetUsageListRealHeight);

				_assetUsagePanelScrollbarPos = GUI.BeginScrollView(
					new Rect(0, _assetInfoPanelRect.height, position.width, assetUsageScrollViewHeight),
					_assetUsagePanelScrollbarPos, scrollViewRect);

				switch (_selectedAssetUsageDisplayIdx)
				{
					case ASSET_USAGE_DISPLAY_ALL:
						DrawAllAssetUsers(scrollViewRect.width, assetUsageScrollViewHeight,
							assetUsageListScrollViewHeightIsClamped,
							selectedAsset.Name, usersFlattened,
							out newEntryHoveredIdx, out newEntryHoveredAssetPath, out newEntryHoveredRect);
						break;

					case ASSET_USAGE_DISPLAY_DIRECT:
						var assetToShowDirectUsersOf = selectedAsset.Name;

						if (_assetUserCrumbs.Count > 0 && _assetUserCrumbActiveIdx >= 0 &&
						    _assetUserCrumbActiveIdx < _assetUserCrumbs.Count)
						{
							assetToShowDirectUsersOf = _assetUserCrumbs[_assetUserCrumbActiveIdx].AssetPath;
						}

						List<string> users = null;
					{
						DependencyEntry entry;
						if (dependencies.TryGetValue(assetToShowDirectUsersOf, out entry))
						{
							users = entry.Users;
						}
					}

						DrawDirectAssetUsers(scrollViewRect.width, assetUsageScrollViewHeight,
							assetUsageListScrollViewHeightIsClamped,
							users, assetDependencies,
							out newEntryHoveredIdx, out newEntryHoveredAssetPath, out newEntryHoveredRect);
						break;

					case ASSET_USAGE_DISPLAY_END:
					{
						var endUsersList = selectedAssetDependencies.GetEndUserLabels();
						if (endUsersList.Count == 0)
						{
							BuildReportTool.AssetDependencies.PopulateAssetEndUsers(selectedAsset.Name,
								endUsersList, assetDependencies);
						}

#if BRT_ASSET_LIST_SCREEN_DEBUG
						_debugText.AppendFormat(
							"endUsersList.Count: {0}\n",
							endUsersList.Count.ToString());
#endif

						DrawEndAssetUsers(scrollViewRect.width, assetUsageScrollViewHeight,
							assetUsageListScrollViewHeightIsClamped, endUsersList,
							out newEntryHoveredIdx, out newEntryHoveredAssetPath, out newEntryHoveredRect);
					}
						break;
				}

				GUI.EndScrollView(true);

				if (Event.current.type == EventType.Repaint)
				{
					_assetUserEntryHoveredIdx = newEntryHoveredIdx;
				}
			}

			GUILayout.EndArea(); // end of Asset Usage Panel

			// ----------------------------------------------------
			// toolbar

			DrawAssetInfoToolbar(position, selectedAsset.Name, assetDependencies);

			// ---------------------------------------------------------

			if (Event.current.type == EventType.Repaint)
			{
#if BRT_ASSET_LIST_SCREEN_DEBUG
				_debugText.AppendFormat(
					"Event.current.mousePosition.y: {0}\n_assetInfoPanelRect: {1}\n_assetUsageRect: {2}\n",
					Event.current.mousePosition.y.ToString(CultureInfo.InvariantCulture),
					_assetInfoPanelRect.ToString(),
					_assetUsageRect.ToString());
#endif
				if (Event.current.mousePosition.y < _assetUsageRect.y + _assetInfoPanelRect.height)
				{
					// mouse is in the asset info panel
					_assetUserEntryHoveredIdx = -1;
				}

				if (!_assetUsageRect.Contains(Event.current.mousePosition))
				{
					// mouse is outside
					_assetUserEntryHoveredIdx = -1;
				}

				if (_assetUserEntryHoveredIdx != -1)
				{
					// ----------------
					// update what is considered the hovered asset, for use later on
					// when the tooltip will be drawn
					BRT_BuildReportWindow.UpdateHoveredAsset(newEntryHoveredAssetPath, newEntryHoveredRect,
						IsShowingUsedAssets, buildReportToDisplay, assetDependencies);
				}
			}
		}


		void ChangeAssetUserCrumbRootIfNeeded(string assetPath)
		{
			if (_assetUserCrumbs.Count == 0 ||
			    !_assetUserCrumbs[0].AssetPath.Equals(assetPath, StringComparison.OrdinalIgnoreCase))
			{
				_assetUserCrumbs.Clear();

				AssetUserCrumb newEntry;
				newEntry.AssetPath = assetPath;
				newEntry.ScrollbarPosY = 0;
				_assetUserCrumbs.Add(newEntry);

				_assetUserCrumbActiveIdx = 0;
				_preferredDirectAssetUserListViewHeight = 0;

				_assetUsagePanelScrollbarPos.y = 0;
			}
		}

		void SelectNextAssetUserCrumb(Dictionary<string, DependencyEntry> dependencies)
		{
			if (_assetUserCrumbActiveIdx < 0)
			{
				// do not allow if current active crumb is negative
				return;
			}

			if (_assetUserCrumbActiveIdx >= _assetUserCrumbs.Count - 1)
			{
				// do not allow if current active crumb is last in the breadcrumb list
				// just clear selection
				// if there is only 1 crumb, this also applies
				_selectedAssetUserIdx = -1;
				return;
			}

			var thisAsset = _assetUserCrumbs[_assetUserCrumbActiveIdx].AssetPath;
			var nextAsset = _assetUserCrumbs[_assetUserCrumbActiveIdx + 1].AssetPath;

			if (dependencies.ContainsKey(thisAsset))
			{
				var thisAssetUsers = dependencies[thisAsset].Users;
				var idxOfNextAsset = thisAssetUsers.IndexOf(nextAsset);
				if (idxOfNextAsset != -1)
				{
					_selectedAssetUserIdx = idxOfNextAsset;
				}
			}
		}

		void DrawDirectAssetUsers(float assetUsageScrollViewWidth, int assetUsageScrollViewHeight,
			bool assetUsageListScrollViewHeightIsClamped, List<string> directUsers, AssetDependencies assetDependencies,
			out int newEntryHoveredIdx, out string newEntryHoveredAssetPath, out Rect newEntryHoveredRect)
		{
			newEntryHoveredIdx = -1;
			newEntryHoveredAssetPath = null;
			newEntryHoveredRect = new Rect();

			float currentY = 0;

			// draw only what's visible in the scrollview

			int directUserN = 0;
			int directUserLen = directUsers.Count;

			if (assetUsageListScrollViewHeightIsClamped && directUsers.Count > 0)
			{
				// figure out which entry to start in

				// for every BRT_BuildReportWindow.LIST_HEIGHT in _assetUsagePanelScrollbarPos.y
				// an entry has been hidden and doesn't need to be drawn
				// and we only need to draw up until the number of entries that can fit in assetUsageScrollViewHeight

				// minus 1 since the first label at the top is not from the list
				var toSkip =
					Mathf.FloorToInt(_assetUsagePanelScrollbarPos.y / BRT_BuildReportWindow.LIST_HEIGHT);

				var amountToDraw = (assetUsageScrollViewHeight / BRT_BuildReportWindow.LIST_HEIGHT) + 2;

				if (toSkip >= 0)
				{
					directUserN = toSkip;
					currentY += toSkip * BRT_BuildReportWindow.LIST_HEIGHT;

					directUserLen = toSkip + amountToDraw;
					if (directUserLen >= directUsers.Count)
					{
						directUserLen = directUsers.Count;
					}

					if (directUserN >= directUsers.Count)
					{
						directUserN = directUsers.Count - 1;
						directUserLen = 1;
					}
				}
			}

			const int PING_BUTTON_WIDTH = 37;
			const int PING_BUTTON_HEIGHT = 18;

			const int INSPECT_BUTTON_WIDTH = 50;
			const int INSPECT_BUTTON_HEIGHT = 18;

			var listEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_STYLE_NAME);
			var listAltEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_ALT_STYLE_NAME);
			var listSelectedEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_SELECTED_NAME);

			EditorGUIUtility.SetIconSize(BRT_BuildReportWindow.IconSize);

			var dependencies = assetDependencies.GetAssetDependencies();

			for (; directUserN < directUserLen; ++directUserN)
			{
				var useAlt = (directUserN % 2) == 0;

				var styleToUse = useAlt
					                 ? listAltEntryStyle
					                 : listEntryStyle;
				if (_selectedAssetUserIdx == directUserN)
				{
					styleToUse = listSelectedEntryStyle;
				}

				// -----------------------------------------------

				bool labelPressed = false;

				var assetPath = directUsers[directUserN];

				// -----------------------------------------------
				// Background color

				GUI.Box(new Rect(0, currentY, assetUsageScrollViewWidth, BRT_BuildReportWindow.LIST_HEIGHT), string.Empty,
					styleToUse);

				float currentX = 0;

				var labelRect = new Rect(
					0, currentY,
					0, BRT_BuildReportWindow.LIST_HEIGHT);

				// -------------------------
				// Ping button

				if (!BuildReportTool.Options.DoubleClickOnAssetWillPing)
				{
					if (GUI.Button(new Rect(0, currentY + 1, PING_BUTTON_WIDTH, PING_BUTTON_HEIGHT), "Ping", "ListButton"))
					{
						// only asset entries inside the top-level assets folder can be pinged
						if (assetPath.IsInAssetsFolder())
						{
							Utility.PingAssetInProject(assetPath);
						}
					}

					currentX += PING_BUTTON_WIDTH + 2; // 2 for some spacing
				}

				// -----------------------------------------------
				// Inspect button

				var shouldDrawInspectButton =
					dependencies.ContainsKey(assetPath) && dependencies[assetPath].Users.Count > 0;

				if (shouldDrawInspectButton)
				{
					var inspectButtonRect =
						new Rect(currentX, currentY + 1, INSPECT_BUTTON_WIDTH, INSPECT_BUTTON_HEIGHT);
					if (GUI.Button(inspectButtonRect, "Inspect", "ListButton"))
					{
						// store the scrollbar pos so that we can return to it
						if (_assetUserCrumbs.Count > 0 && _assetUserCrumbActiveIdx >= 0 &&
						    _assetUserCrumbActiveIdx < _assetUserCrumbs.Count)
						{
							var entryToModify = _assetUserCrumbs[_assetUserCrumbActiveIdx];
							entryToModify.ScrollbarPosY = _assetUsagePanelScrollbarPos.y;
							_assetUserCrumbs[_assetUserCrumbActiveIdx] = entryToModify;
						}

						// add the current asset user to the breadcrumbs
						// if the current asset is already in the breadcrumbs, just switch to it

						var alreadyInBreadcrumbHistory = false;
						for (int n = 0, len = _assetUserCrumbs.Count; n < len; ++n)
						{
							if (_assetUserCrumbs[n].AssetPath.Equals(assetPath, StringComparison.OrdinalIgnoreCase))
							{
								// asset is already in breadcrumb history. this is most likely a cyclic dependency
								// switch to the existing one
								_assetUserCrumbActiveIdx = n;
								_assetUsagePanelScrollbarPos.y = _assetUserCrumbs[n].ScrollbarPosY;
								SelectNextAssetUserCrumb(dependencies);
								alreadyInBreadcrumbHistory = true;
								break;
							}
						}

						if (!alreadyInBreadcrumbHistory)
						{
							if (_assetUserCrumbActiveIdx != _assetUserCrumbs.Count - 1)
							{
								// everything after _assetUserCrumbActiveIdx is removed
								var removalStartIdx = _assetUserCrumbActiveIdx + 1;
								_assetUserCrumbs.RemoveRange(removalStartIdx, _assetUserCrumbs.Count - removalStartIdx);
							}

							AssetUserCrumb newEntry;
							newEntry.AssetPath = assetPath;
							newEntry.ScrollbarPosY = 0;
							_assetUserCrumbs.Add(newEntry);

							_assetUserCrumbActiveIdx = _assetUserCrumbs.Count - 1;

							// since this is a newly viewed direct user list,
							// reset the scrollbar and currently selected
							_assetUsagePanelScrollbarPos.y = 0;
							_selectedAssetUserIdx = -1;
						}
					}
				}

				// even if we don't draw the inspect button, we still
				// need to add space so that it lines up with the other
				// entries that do have that button
				currentX += INSPECT_BUTTON_WIDTH;

				// -----------------------------------------------
				// Asset Path/Name

				_assetUsageEntryLabel.text =
					GetPrettyAssetPath(assetPath, _showAssetPath, _selectedAssetUserIdx == directUserN);
				_assetUsageEntryLabel.image = AssetDatabase.GetCachedIcon(assetPath);

				if (_assetUsageEntryLabel.image == null)
				{
					// no icon, leave some space before the label to represent where the icon would be
					currentX += BRT_BuildReportWindow.ICON_WIDTH_WITH_PADDING;
				}

				labelRect.x = currentX;
				// allow asset label width to take up remaining width
				labelRect.width = assetUsageScrollViewWidth - labelRect.x;

				labelPressed |= GUI.Button(labelRect, _assetUsageEntryLabel, styleToUse);

				// -----------------------------------------------
				// Respond to Click

				if (labelPressed)
				{
					// Respond to Double-click Ping if needed
					if (BuildReportTool.Options.DoubleClickOnAssetWillPing &&
					    _selectedAssetUserIdx == directUserN &&
					    (EditorApplication.timeSinceStartup - _assetListEntryLastClickedTime) < DOUBLE_CLICK_THRESHOLD &&
					    assetPath.IsInAssetsFolder())
					{
						Utility.PingAssetInProject(assetPath);
					}

					_selectedAssetUserIdx = directUserN;
					_assetListEntryLastClickedTime = EditorApplication.timeSinceStartup;
				}

				// -----------------------------------------------
				// Hover Check

				if (Event.current.type == EventType.Repaint)
				{
					const int ICON_WIDTH = 20;

					var mousePos = Event.current.mousePosition;

					if (labelRect.Contains(mousePos))
					{
						newEntryHoveredIdx = directUserN;
						newEntryHoveredAssetPath = assetPath;
						newEntryHoveredRect = labelRect;

						// ----------------
						// put a border on the icon to signify that it's the one being hovered
						// note: _assetUsageEntryLabel.image currently has the icon of the asset we hovered
						Rect iconHoveredRect = labelRect;
						iconHoveredRect.x += 1;
						iconHoveredRect.y += 2;
						iconHoveredRect.width = 17;
						iconHoveredRect.height = 16;
						GUI.Box(iconHoveredRect, _assetUsageEntryLabel.image, "IconHovered");

						// ----------------
						// if mouse is hovering over the correct area, we signify that
						// the tooltip thumbnail should be drawn
						if (BuildReportTool.Options.ShowTooltipThumbnail &&
						    (BuildReportTool.Options.ShowThumbnailOnHoverLabelToo ||
						     Mathf.Abs(mousePos.x - labelRect.x) < ICON_WIDTH) &&
						    BRT_BuildReportWindow.GetAssetPreview(assetPath) != null)
						{
							_shouldShowThumbnailOnHoveredAsset = true;
						}
						else
						{
							_shouldShowThumbnailOnHoveredAsset = false;
						}
					}
				}

				// -----------------------------------------------

				currentY += BRT_BuildReportWindow.LIST_HEIGHT;
			}
		}

		void DrawEndAssetUsers(float assetUsageScrollViewWidth, int assetUsageScrollViewHeight,
			bool assetUsageListScrollViewHeightIsClamped, List<GUIContent> endUsers,
			out int newEntryHoveredIdx, out string newEntryHoveredAssetPath, out Rect newEntryHoveredRect)
		{
			newEntryHoveredIdx = -1;
			newEntryHoveredAssetPath = null;
			newEntryHoveredRect = new Rect();

			float currentY = 0;

			// draw only what's visible in the scrollview

			int endUserN = 0;
			int endUserLen = endUsers.Count;

			if (assetUsageListScrollViewHeightIsClamped && endUsers.Count > 0)
			{
				// figure out which entry to start in

				// for every BRT_BuildReportWindow.LIST_HEIGHT in _assetUsagePanelScrollbarPos.y
				// an entry has been hidden and doesn't need to be drawn
				// and we only need to draw up until the number of entries that can fit in assetUsageScrollViewHeight

				// minus 1 since the first label at the top is not from the list
				var toSkip =
					Mathf.FloorToInt(_assetUsagePanelScrollbarPos.y / BRT_BuildReportWindow.LIST_HEIGHT);

				var amountToDraw = (assetUsageScrollViewHeight / BRT_BuildReportWindow.LIST_HEIGHT) + 2;

				if (toSkip >= 0)
				{
					endUserN = toSkip;
					currentY += toSkip * BRT_BuildReportWindow.LIST_HEIGHT;

					endUserLen = toSkip + amountToDraw;
					if (endUserLen >= endUsers.Count)
					{
						endUserLen = endUsers.Count;
					}

					if (endUserN >= endUsers.Count)
					{
						endUserN = endUsers.Count - 1;
						endUserLen = 1;
					}
				}
			}

			const int PING_BUTTON_WIDTH = 37;
			const int PING_BUTTON_HEIGHT = 18;

			var listEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_STYLE_NAME);
			var listAltEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_ALT_STYLE_NAME);
			var listSelectedEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_SELECTED_NAME);

			EditorGUIUtility.SetIconSize(BRT_BuildReportWindow.IconSize);


			for (; endUserN < endUserLen; ++endUserN)
			{
				var useAlt = (endUserN % 2) == 0;

				var styleToUse = useAlt
					                 ? listAltEntryStyle
					                 : listEntryStyle;
				if (_selectedAssetUserIdx == endUserN)
				{
					styleToUse = listSelectedEntryStyle;
				}

				// -----------------------------------------------

				bool labelPressed = false;

				var assetPath = endUsers[endUserN].tooltip;

				// -----------------------------------------------
				// Background color

				GUI.Box(new Rect(0, currentY, assetUsageScrollViewWidth, BRT_BuildReportWindow.LIST_HEIGHT), string.Empty,
					styleToUse);

				var labelRect = new Rect(
					0, currentY,
					0, BRT_BuildReportWindow.LIST_HEIGHT);

				// -------------------------
				// Ping button

				if (!BuildReportTool.Options.DoubleClickOnAssetWillPing)
				{
					labelRect.x += PING_BUTTON_WIDTH;
					if (GUI.Button(new Rect(0, currentY + 1, PING_BUTTON_WIDTH, PING_BUTTON_HEIGHT), "Ping", "ListButton"))
					{
						// only asset entries inside the top-level assets folder can be pinged
						if (assetPath.IsInAssetsFolder())
						{
							Utility.PingAssetInProject(assetPath);
						}
					}
				}

				// -----------------------------------------------
				// Asset Path/Name

				_assetUsageEntryLabel.text =
					GetPrettyAssetPath(assetPath, _showAssetPath, _selectedAssetUserIdx == endUserN);
				_assetUsageEntryLabel.image = endUsers[endUserN].image;

				if (_assetUsageEntryLabel.image == null)
				{
					// no icon, leave some space before the label to represent where the icon would be
					labelRect.x += BRT_BuildReportWindow.ICON_WIDTH_WITH_PADDING;
				}

				// allow asset label width to take up remaining width
				labelRect.width = assetUsageScrollViewWidth - labelRect.x;

				labelPressed |= GUI.Button(labelRect, _assetUsageEntryLabel, styleToUse);

				// -----------------------------------------------
				// Respond to click

				if (labelPressed)
				{
					// Double-click Ping
					if (BuildReportTool.Options.DoubleClickOnAssetWillPing &&
					    _selectedAssetUserIdx == endUserN &&
					    (EditorApplication.timeSinceStartup - _assetListEntryLastClickedTime) < DOUBLE_CLICK_THRESHOLD &&
					    assetPath.IsInAssetsFolder())
					{
						Utility.PingAssetInProject(assetPath);
					}

					_selectedAssetUserIdx = endUserN;
					_assetListEntryLastClickedTime = EditorApplication.timeSinceStartup;
				}

				// -----------------------------------------------
				// Hover Check

				if (Event.current.type == EventType.Repaint)
				{
					const int ICON_WIDTH = 20;

					var mousePos = Event.current.mousePosition;

					if (labelRect.Contains(mousePos))
					{
						newEntryHoveredIdx = endUserN;
						newEntryHoveredAssetPath = assetPath;
						newEntryHoveredRect = labelRect;

						// ----------------
						// put a border on the icon to signify that it's the one being hovered
						// note: _assetUsageEntryLabel.image currently has the icon of the asset we hovered
						Rect iconHoveredRect = labelRect;
						iconHoveredRect.x += 1;
						iconHoveredRect.y += 2;
						iconHoveredRect.width = 17;
						iconHoveredRect.height = 16;
						GUI.Box(iconHoveredRect, _assetUsageEntryLabel.image, "IconHovered");

						// ----------------
						// if mouse is hovering over the correct area, we signify that
						// the tooltip thumbnail should be drawn
						if (BuildReportTool.Options.ShowTooltipThumbnail &&
						    (BuildReportTool.Options.ShowThumbnailOnHoverLabelToo ||
						     Mathf.Abs(mousePos.x - labelRect.x) < ICON_WIDTH) &&
						    BRT_BuildReportWindow.GetAssetPreview(assetPath) != null)
						{
							_shouldShowThumbnailOnHoveredAsset = true;
						}
						else
						{
							_shouldShowThumbnailOnHoveredAsset = false;
						}
					}
				}

				// -----------------------------------------------

				currentY += BRT_BuildReportWindow.LIST_HEIGHT;
			}
		}

		void DrawAllAssetUsers(float assetUsageScrollViewWidth, int assetUsageScrollViewHeight,
			bool assetUsageListScrollViewHeightIsClamped,
			string pathOfSelectedAsset, List<AssetUserFlattened> usersFlattened,
			out int newEntryHoveredIdx, out string newEntryHoveredAssetPath, out Rect newEntryHoveredRect)
		{
			newEntryHoveredIdx = -1;
			newEntryHoveredAssetPath = null;
			newEntryHoveredRect = new Rect();

			/*
			_assetUsageEntryLabel.image = null;
			if (IsShowingUsedAssets)
			{
				if (_selectedIsAResourcesAsset)
				{
					_assetUsageEntryLabel.text = "This Resources asset is used by:";
				}
				else
				{
					_assetUsageEntryLabel.text = "Included in the build because it's used by:";
				}
			}
			else
			{
				_assetUsageEntryLabel.text = "Used by:";
			}

			var listLabelSize = GUI.skin.label.CalcSize(_assetUsageEntryLabel);
			GUI.Label(new Rect(0, 0, scrollViewRect.width, listLabelSize.y), _assetUsageEntryLabel);*/

			float currentY = 0;

			// draw only what's visible in the scrollview

			int userFlattenedN = 0;
			int userFlattenedLen = usersFlattened.Count;

			if (assetUsageListScrollViewHeightIsClamped && usersFlattened.Count > 0)
			{
				// figure out which entry to start in

				// for every BRT_BuildReportWindow.LIST_HEIGHT in _assetUsagePanelScrollbarPos.y
				// an entry has been hidden and doesn't need to be drawn
				// and we only need to draw up until the number of entries that can fit in assetUsageScrollViewHeight

				// minus 1 since the first label at the top is not from the list
				var toSkip =
					Mathf.FloorToInt(_assetUsagePanelScrollbarPos.y / BRT_BuildReportWindow.LIST_HEIGHT);

				var amountToDraw = (assetUsageScrollViewHeight / BRT_BuildReportWindow.LIST_HEIGHT) + 2;

				if (toSkip >= 0)
				{
					userFlattenedN = toSkip;
					currentY += toSkip * BRT_BuildReportWindow.LIST_HEIGHT;

					userFlattenedLen = toSkip + amountToDraw;
					if (userFlattenedLen >= usersFlattened.Count)
					{
						userFlattenedLen = usersFlattened.Count;
					}

					if (userFlattenedN >= usersFlattened.Count)
					{
						userFlattenedN = usersFlattened.Count - 1;
						userFlattenedLen = 1;
					}
				}

#if BRT_ASSET_LIST_SCREEN_DEBUG
				_debugText.AppendFormat(
					"_assetUsagePanelScrollbarPos.y: {0}\nassetUsageScrollViewHeight: {1}\ntoSkip: {2}\namountToDraw: {3}\ntotal Count: {4}\n",
					_assetUsagePanelScrollbarPos.y.ToString(CultureInfo.InvariantCulture),
					assetUsageScrollViewHeight.ToString(CultureInfo.InvariantCulture),
					toSkip.ToString(CultureInfo.InvariantCulture),
					amountToDraw.ToString(CultureInfo.InvariantCulture),
					usersFlattened.Count.ToString(CultureInfo.InvariantCulture));
#endif
			}

			const int INDENT_SPACE = 20;
			const int PING_BUTTON_WIDTH = 37;
			const int PING_BUTTON_HEIGHT = 18;

			var listEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_STYLE_NAME);
			var listAltEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_ALT_STYLE_NAME);
			var listSelectedEntryStyle = GUI.skin.GetStyle(BuildReportTool.Window.Settings.LIST_SMALL_SELECTED_NAME);

			EditorGUIUtility.SetIconSize(BRT_BuildReportWindow.IconSize);

			for (; userFlattenedN < userFlattenedLen; ++userFlattenedN)
			{
				var useAlt = ((usersFlattened[userFlattenedN].IndentLevel % 2) == 0);

				var styleToUse = useAlt
					                 ? listAltEntryStyle
					                 : listEntryStyle;
				if (_selectedAssetUserIdx == userFlattenedN)
				{
					styleToUse = listSelectedEntryStyle;
				}

				// -----------------------------------------------

				bool labelPressed = false;

				var assetPath = usersFlattened[userFlattenedN].AssetPath;

				// -----------------------------------------------
				// Background color

				GUI.Box(new Rect(0, currentY, assetUsageScrollViewWidth, BRT_BuildReportWindow.LIST_HEIGHT), string.Empty,
					styleToUse);

				var labelRect = new Rect(
					(INDENT_SPACE * (usersFlattened[userFlattenedN].IndentLevel - 1)), currentY,
					0, BRT_BuildReportWindow.LIST_HEIGHT);

				// -------------------------
				// Ping button

				var pingButtonUsedWidth = 0;
				if (!BuildReportTool.Options.DoubleClickOnAssetWillPing)
				{
					labelRect.x += PING_BUTTON_WIDTH;
					pingButtonUsedWidth = PING_BUTTON_WIDTH;
					if (GUI.Button(new Rect(0, currentY + 1, PING_BUTTON_WIDTH, PING_BUTTON_HEIGHT), "Ping", "ListButton"))
					{
						// only asset entries inside the top-level assets folder can be pinged
						if (assetPath.IsInAssetsFolder())
						{
							Utility.PingAssetInProject(assetPath);
						}
					}
				}

				// -----------------------------------------------
				// Prefix Label

				if (usersFlattened[userFlattenedN].IndentLevel > 1)
				{
					var prefixLabelRect = new Rect(
						pingButtonUsedWidth + (INDENT_SPACE * (usersFlattened[userFlattenedN].IndentLevel - 1)), currentY,
						0, BRT_BuildReportWindow.LIST_HEIGHT);

					int idxOfPrevious;
					if (BuildReportTool.AssetDependencyGenerator.IsFileTypeBeforeAnother(usersFlattened, userFlattenedN,
						".mat", ".fbx", out idxOfPrevious))
					{
						prefixLabelRect.width = styleToUse.CalcSize(AssetUsageWhichIsUsedAsDefaultMaterialByLabel).x;
						labelPressed |= GUI.Button(prefixLabelRect, AssetUsageWhichIsUsedAsDefaultMaterialByLabel,
							styleToUse);
					}
					else if (assetPath.IsFileOfType(".cs"))
					{
						prefixLabelRect.width = styleToUse.CalcSize(AssetUsageWhichIsUsedAsDefaultValueByLabel).x;
						labelPressed |= GUI.Button(prefixLabelRect, AssetUsageWhichIsUsedAsDefaultValueByLabel, styleToUse);
					}
					else
					{
						prefixLabelRect.width = styleToUse.CalcSize(AssetUsageWhichIsUsedByLabel).x;
						labelPressed |= GUI.Button(prefixLabelRect, AssetUsageWhichIsUsedByLabel, styleToUse);
					}

					labelRect.x += prefixLabelRect.width;
				}

				// -----------------------------------------------
				// Asset Path/Name

				_assetUsageEntryLabel.text = GetPrettyAssetPath(usersFlattened[userFlattenedN].AssetPath, _showAssetPath,
					_selectedAssetUserIdx == userFlattenedN);
				_assetUsageEntryLabel.image = AssetDatabase.GetCachedIcon(assetPath);

				if (_assetUsageEntryLabel.image == null)
				{
					// no icon, leave some space before the label to represent where the icon would be
					labelRect.x += BRT_BuildReportWindow.ICON_WIDTH_WITH_PADDING;
				}

				if (usersFlattened[userFlattenedN].CyclicDependency)
				{
					// asset has a suffix label, width of the asset label itself should not take up entire remaining width
					labelRect.width = listEntryStyle.CalcSize(_assetUsageEntryLabel).x;
				}
				else
				{
					// allow asset label width to take up remaining width
					labelRect.width = assetUsageScrollViewWidth - labelRect.x;
				}

				labelPressed |= GUI.Button(labelRect, _assetUsageEntryLabel, styleToUse);

				// -----------------------------------------------
				// Suffix Label

				if (usersFlattened[userFlattenedN].CyclicDependency)
				{
					// cyclic dependency means there's a label after the asset name,
					// so we can't expand the width for the asset name, or the next label
					// would show up away from it

					var suffixLabelRect = new Rect(
						labelRect.xMax, currentY,
						assetUsageScrollViewWidth - labelRect.xMax, BRT_BuildReportWindow.LIST_HEIGHT);

					labelPressed |= GUI.Button(suffixLabelRect, AssetUsageWhichIsACyclicDependencyLabel, styleToUse);
				}

				// -----------------------------------------------
				// Indent Lines

				if (_indentLine == null)
				{
					_indentLine = GUI.skin.GetStyle("IndentStyle1").normal.background;
				}

				var prevColor = GUI.color;
				GUI.color = new Color(0, 0, 0, 0.5f);
				for (int indentN = 1, indentLen = usersFlattened[userFlattenedN].IndentLevel;
				     indentN < indentLen;
				     ++indentN)
				{
					var indentRect = new Rect(pingButtonUsedWidth + ((indentN - 1) * 20), currentY, 20, 20);
					GUI.DrawTexture(indentRect, _indentLine, ScaleMode.StretchToFill);
				}

				GUI.color = prevColor;

				// -----------------------------------------------
				// Respond to Click

				if (labelPressed)
				{
					// ---------------------------
					// Respond to Double-click Ping if needed
					if (BuildReportTool.Options.DoubleClickOnAssetWillPing &&
					    _selectedAssetUserIdx == userFlattenedN &&
					    (EditorApplication.timeSinceStartup - _assetListEntryLastClickedTime) < DOUBLE_CLICK_THRESHOLD &&
					    assetPath.IsInAssetsFolder())
					{
						Utility.PingAssetInProject(assetPath);
					}

					// ---------------------------

					SetAssetUsageAncestry(_assetUsageAncestry, usersFlattened, userFlattenedN,
						pathOfSelectedAsset);
					_assetUsageAncestryHasFbxUsingDefaultMaterialUsedInScene =
						DoesAssetUsageAncestryHaveFbxUsingDefaultMaterialUsedInScene(_assetUsageAncestry);

					_selectedAssetUserIdx = userFlattenedN;
					_assetListEntryLastClickedTime = EditorApplication.timeSinceStartup;
				}

				// -----------------------------------------------
				// Hover Check

				if (Event.current.type == EventType.Repaint)
				{
					const int ICON_WIDTH = 20;

					var mousePos = Event.current.mousePosition;

					if (labelRect.Contains(mousePos))
					{
						newEntryHoveredIdx = userFlattenedN;
						newEntryHoveredAssetPath = assetPath;
						newEntryHoveredRect = labelRect;

						// ----------------
						// put a border on the icon to signify that it's the one being hovered
						// note: _assetUsageEntryLabel.image currently has the icon of the asset we hovered
						Rect iconHoveredRect = labelRect;
						iconHoveredRect.x += 1;
						iconHoveredRect.y += 2;
						iconHoveredRect.width = 17;
						iconHoveredRect.height = 16;
						GUI.Box(iconHoveredRect, _assetUsageEntryLabel.image, "IconHovered");

						// ----------------
						// if mouse is hovering over the correct area, we signify that
						// the tooltip thumbnail should be drawn
						if (BuildReportTool.Options.ShowTooltipThumbnail &&
						    (BuildReportTool.Options.ShowThumbnailOnHoverLabelToo ||
						     Mathf.Abs(mousePos.x - labelRect.x) < ICON_WIDTH) &&
						    BRT_BuildReportWindow.GetAssetPreview(assetPath) != null)
						{
							_shouldShowThumbnailOnHoveredAsset = true;
						}
						else
						{
							_shouldShowThumbnailOnHoveredAsset = false;
						}
					}
				}

				// -----------------------------------------------

				currentY += BRT_BuildReportWindow.LIST_HEIGHT;
			}
		}


		void DrawAssetInfoPanel(Rect position, float availableWidth, BuildInfo buildReportToDisplay,
			AssetDependencies assetDependencies)
		{
			if (_selectedAssetUsageDisplayIdx == ASSET_USAGE_DISPLAY_ALL)
			{
				DrawAssetUsageAncestry(position, availableWidth, buildReportToDisplay, assetDependencies);
			}
			else if (_selectedAssetUsageDisplayIdx == ASSET_USAGE_DISPLAY_DIRECT)
			{
				GUILayout.BeginHorizontal(BRT_BuildReportWindow.LayoutNone);

				_assetUsageEntryLabel.text = BuildReportTool.Util.GetAssetFilename(_assetUserCrumbs[0].AssetPath);
				_assetUsageEntryLabel.image = AssetDatabase.GetCachedIcon(_assetUserCrumbs[0].AssetPath);
				if (GUILayout.Toggle(_assetUserCrumbActiveIdx == 0, _assetUsageEntryLabel, "GUIEditor.BreadcrumbLeft") &&
				    _assetUserCrumbActiveIdx != 0)
				{
					// before switching, store the scrollbar pos so that we can return to it
					if (_assetUserCrumbs.Count > 0 && _assetUserCrumbActiveIdx >= 0 &&
					    _assetUserCrumbActiveIdx < _assetUserCrumbs.Count)
					{
						var entryToModify = _assetUserCrumbs[_assetUserCrumbActiveIdx];
						entryToModify.ScrollbarPosY = _assetUsagePanelScrollbarPos.y;
						_assetUserCrumbs[_assetUserCrumbActiveIdx] = entryToModify;
					}

					_assetUserCrumbActiveIdx = 0;
					_assetUsagePanelScrollbarPos.y = _assetUserCrumbs[0].ScrollbarPosY;
					SelectNextAssetUserCrumb(assetDependencies.GetAssetDependencies());
				}

				for (int crumbN = 1, crumbLen = _assetUserCrumbs.Count; crumbN < crumbLen; ++crumbN)
				{
					_assetUsageEntryLabel.text = BuildReportTool.Util.GetAssetFilename(_assetUserCrumbs[crumbN].AssetPath);
					_assetUsageEntryLabel.image = AssetDatabase.GetCachedIcon(_assetUserCrumbs[crumbN].AssetPath);

					if (GUILayout.Toggle(_assetUserCrumbActiveIdx == crumbN, _assetUsageEntryLabel,
						    "GUIEditor.BreadcrumbMid") && _assetUserCrumbActiveIdx != crumbN)
					{
						// before switching, store the scrollbar pos so that we can return to it
						if (_assetUserCrumbs.Count > 0 && _assetUserCrumbActiveIdx >= 0 &&
						    _assetUserCrumbActiveIdx < _assetUserCrumbs.Count)
						{
							var entryToModify = _assetUserCrumbs[_assetUserCrumbActiveIdx];
							entryToModify.ScrollbarPosY = _assetUsagePanelScrollbarPos.y;
							_assetUserCrumbs[_assetUserCrumbActiveIdx] = entryToModify;
						}

						_assetUserCrumbActiveIdx = crumbN;
						_assetUsagePanelScrollbarPos.y = _assetUserCrumbs[crumbN].ScrollbarPosY;
						SelectNextAssetUserCrumb(assetDependencies.GetAssetDependencies());
					}
				}

				GUILayout.EndHorizontal();
			}
		}

		const int ASSET_INFO_TOOLBAR_HEIGHT = 15;

		void DrawAssetInfoToolbar(Rect position, string selectedAssetPath, AssetDependencies assetDependencies)
		{
			var bgRect = new Rect(0, 0,
				position.width, ASSET_INFO_TOOLBAR_HEIGHT);

			if (_showAssetUsagesList)
			{
				bgRect.y = _assetUsageRect.y + 2;
			}
			else
			{
				bgRect.y = position.height - ASSET_INFO_TOOLBAR_HEIGHT;
				bgRect.height += 3;
			}

			GUI.Box(bgRect, "", "ListButton");

			const int EXPAND_BUTTON_WIDTH = 150;
			var expandButtonRect = new Rect(bgRect.x + ((bgRect.width - EXPAND_BUTTON_WIDTH) / 2), bgRect.y,
				EXPAND_BUTTON_WIDTH, ASSET_INFO_TOOLBAR_HEIGHT);

			var showAllUsagesLabel = _showAssetUsagesList
				                         ? "Hide"
				                         : "Show More Usages";

			var newShowAssetUsersList =
				GUI.Toggle(expandButtonRect, _showAssetUsagesList, showAllUsagesLabel, "ExpandButton");

			if (newShowAssetUsersList != _showAssetUsagesList)
			{
				_showAssetUsagesList = newShowAssetUsersList;
				if (!newShowAssetUsersList)
				{
					if (_selectedAssetUsageDisplayIdx != ASSET_USAGE_DISPLAY_ALL)
					{
						_selectedAssetUsageDisplayIdx = ASSET_USAGE_DISPLAY_ALL;
						SetAssetUsageHistoryToFirstEndUser(selectedAssetPath, assetDependencies);
					}
				}
			}

			if (_showAssetUsagesList)
			{
				// ---------------------------------------------
				// if asset users list is shown,
				// show the toggles to change what kind
				// of users list is shown

				const int ASSET_USAGE_LABEL_WIDTH = 40;
				var assetUsageLabelRect =
					new Rect(bgRect.x + 5, bgRect.y,
						ASSET_USAGE_LABEL_WIDTH, ASSET_INFO_TOOLBAR_HEIGHT);
				GUI.Label(assetUsageLabelRect, "Show:");

				var newAssetUsageDisplayIdx = GUI.SelectionGrid(
					new Rect(assetUsageLabelRect.xMax, bgRect.y,
						150, ASSET_INFO_TOOLBAR_HEIGHT),
					_selectedAssetUsageDisplayIdx, AssetUsageDisplayLabel, 3, "ListButtonRadio");

				if (newAssetUsageDisplayIdx != _selectedAssetUsageDisplayIdx)
				{
					// previously showing direct users and is leaving it
					// store the scrollbar pos so that we can return to it
					if (_selectedAssetUsageDisplayIdx == ASSET_USAGE_DISPLAY_DIRECT)
					{
						if (_assetUserCrumbs.Count > 0 && _assetUserCrumbActiveIdx >= 0 &&
						    _assetUserCrumbActiveIdx < _assetUserCrumbs.Count)
						{
							var entryToModify = _assetUserCrumbs[_assetUserCrumbActiveIdx];
							entryToModify.ScrollbarPosY = _assetUsagePanelScrollbarPos.y;
							_assetUserCrumbs[_assetUserCrumbActiveIdx] = entryToModify;
						}
					}

					_selectedAssetUsageDisplayIdx = newAssetUsageDisplayIdx;

					// what asset user list is shown has been changed
					// so we need to change what asset user is selected
					if (_selectedAssetUsageDisplayIdx == ASSET_USAGE_DISPLAY_ALL)
					{
						SetAssetUsageHistoryToFirstEndUser(selectedAssetPath, assetDependencies);
					}
					else
					{
						_selectedAssetUserIdx = -1;
					}

					// switched to showing direct users
					// ensure crumbs is showing proper values
					if (_selectedAssetUsageDisplayIdx == ASSET_USAGE_DISPLAY_DIRECT)
					{
						ChangeAssetUserCrumbRootIfNeeded(selectedAssetPath);

						if (_assetUserCrumbs.Count > 0 && _assetUserCrumbActiveIdx >= 0 &&
						    _assetUserCrumbActiveIdx < _assetUserCrumbs.Count)
						{
							_assetUsagePanelScrollbarPos.y = _assetUserCrumbs[_assetUserCrumbActiveIdx].ScrollbarPosY;

							SelectNextAssetUserCrumb(assetDependencies.GetAssetDependencies());
						}
					}
				}
			}
		}


		void DrawAssetUsageAncestry(Rect position, float availableWidth, BuildInfo buildReportToDisplay,
			AssetDependencies assetDependencies)
		{
			var assetStyle = GUI.skin.GetStyle("Asset");
			var assetHoveredStyle = GUI.skin.GetStyle("AssetHovered");
			var assetLabelInBetweenStyle = GUI.skin.GetStyle("LabelSingleLine");
			var assetUsageArrowStyle = GUI.skin.GetStyle("AssetUsageArrow");
			var assetUsageArrow = assetUsageArrowStyle.normal.background;

			// draw usage ancestry
			// for selected user

			float currentRowWidth = 0;
			bool moreThan1Row = false;

			GUILayout.BeginHorizontal(BRT_BuildReportWindow.LayoutNone);

			var newAssetUsageAncestryEntryHoveredIdx = -1;

			for (int n = 0, len = _assetUsageAncestry.Count; n < len; ++n)
			{
				// --------------------------
				// width of the asset name itself
				var widthToAdd = assetStyle.CalcSize(_assetUsageAncestry[n].Label).x;

#if BRT_ASSET_LIST_SCREEN_DEBUG
				//_debugText.AppendFormat("Actual Item {0} name width: {1}\n",
				//	n,
				//	widthToAdd.ToString(CultureInfo.InvariantCulture));
#endif

				if (currentRowWidth + widthToAdd >= availableWidth)
				{
					moreThan1Row = true;
#if BRT_ASSET_LIST_SCREEN_DEBUG
					_debugText.AppendFormat("Actual Row width: {0}\n",
						currentRowWidth.ToString(CultureInfo.InvariantCulture));
#endif

					currentRowWidth = 0;
					GUILayout.EndHorizontal();
					GUILayout.Space(ASSET_USAGE_HISTORY_ROW_SPACING);
					GUILayout.BeginHorizontal(BRT_BuildReportWindow.LayoutNone);
				}

				currentRowWidth += widthToAdd;

				// --------------------------
				// asset name

				var assetPressed = GUILayout.Button(_assetUsageAncestry[n].Label,
					n == _assetUsageAncestryHoveredIdx ? assetHoveredStyle : assetStyle,
					BRT_BuildReportWindow.LayoutHeight21);

				if (Event.current.type == EventType.Repaint &&
				    (Event.current.mousePosition.x < position.width ||
				     Event.current.mousePosition.y < position.height))
				{
					var assetUsageAncestryEntryRect = GUILayoutUtility.GetLastRect();

					if (assetUsageAncestryEntryRect.Contains(Event.current.mousePosition))
					{
						newAssetUsageAncestryEntryHoveredIdx = n;

						// ----------------
						// update what is considered the hovered asset, for use later on
						// when the tooltip will be drawn
						BRT_BuildReportWindow.UpdateHoveredAsset(_assetUsageAncestry[n].AssetPath,
							assetUsageAncestryEntryRect, IsShowingUsedAssets,
							buildReportToDisplay, assetDependencies);

						// ----------------
						// if mouse is hovering over the correct area, we signify that
						// the tooltip thumbnail should be drawn
						if (BuildReportTool.Options.ShowTooltipThumbnail &&
						    BRT_BuildReportWindow.GetAssetPreview(_assetUsageAncestry[n].AssetPath) != null)
						{
							_shouldShowThumbnailOnHoveredAsset = true;
						}
						else
						{
							_shouldShowThumbnailOnHoveredAsset = false;
						}
					}
				}

				if (assetPressed)
				{
					Utility.PingAssetInProject(_assetUsageAncestry[n].AssetPath);
				}

				// --------------------------
				// width of the label following the asset
				widthToAdd = 0;

				var isMaterialUsedByMesh = IsFileNextToFile(_assetUsageAncestry, n, ".mat", ".fbx");
				var isAResourcesAsset = _assetUsageAncestry[n].AssetPath.IsInResourcesFolder();
				var isAssetUsedByScript = (n < len - 1) && _assetUsageAncestry[n + 1].AssetPath.IsFileOfType(".cs");

				if (BuildReportTool.Options.IsAssetUsageLabelTypeOnVerbose)
				{
					if (n == 0)
					{
						if (isMaterialUsedByMesh)
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageIsUsedAsDefaultMaterialByLabel).x;
						}
						else if (isAResourcesAsset)
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageIsAResourcesAssetButAlsoUsedByLabel).x;
						}
						else if (isAssetUsedByScript)
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageIsUsedAsDefaultValueByLabel).x;
						}
						else
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageIsUsedByLabel).x;
						}

						widthToAdd += assetLabelInBetweenStyle.margin.horizontal;
					}
					else if (n < len - 1)
					{
						if (isMaterialUsedByMesh)
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsUsedAsDefaultMaterialByLabel).x;
						}
						else if (isAResourcesAsset)
						{
							widthToAdd = assetLabelInBetweenStyle
							             .CalcSize(AssetUsageWhichIsAResourcesAssetButAlsoUsedByLabel).x;
						}
						else if (isAssetUsedByScript)
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsUsedAsDefaultValueByLabel).x;
						}
						else
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsUsedByLabel).x;
						}

						widthToAdd += assetLabelInBetweenStyle.margin.horizontal;
					}
					else if (n == len - 1)
					{
						if (_assetUsageAncestry[n].AssetPath.IsSceneFile())
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsInTheBuildLabel).x +
							             assetLabelInBetweenStyle.margin.horizontal;
						}
						else if (_assetUsageAncestry[n].AssetPath.IsInResourcesFolder())
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsAResourcesAssetLabel).x +
							             assetLabelInBetweenStyle.margin.horizontal;
						}
						else if (_assetUsageAncestry[n].CyclicDependency)
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsACyclicDependencyLabel).x +
							             assetLabelInBetweenStyle.margin.horizontal;
						}
					}
				}
				else if (BuildReportTool.Options.IsAssetUsageLabelTypeOnStandard)
				{
					if (n < len - 1)
					{
						// todo determine if _assetUsageAncestry[n] has extra info and add that to width
						widthToAdd = assetUsageArrow.width + assetUsageArrowStyle.padding.horizontal;
					}
				}
				else if (BuildReportTool.Options.IsAssetUsageLabelTypeOnMinimal)
				{
					if (n < len - 1)
					{
						widthToAdd = assetUsageArrow.width + assetUsageArrowStyle.padding.horizontal;
					}
				}

#if BRT_ASSET_LIST_SCREEN_DEBUG
				_debugText.AppendFormat("Actual Item {0} in-between width: {1}\n",
					n.ToString(),
					widthToAdd.ToString(CultureInfo.InvariantCulture));
#endif

				if (currentRowWidth + widthToAdd >= availableWidth)
				{
					moreThan1Row = true;
#if BRT_ASSET_LIST_SCREEN_DEBUG
					_debugText.AppendFormat("Actual Row width: {0}\n",
						currentRowWidth.ToString(CultureInfo.InvariantCulture));
#endif

					currentRowWidth = 0;
					GUILayout.EndHorizontal();
					GUILayout.Space(ASSET_USAGE_HISTORY_ROW_SPACING);
					GUILayout.BeginHorizontal(BRT_BuildReportWindow.LayoutNone);
				}

				currentRowWidth += widthToAdd;

				// --------------------------
				// label following the asset

				if (BuildReportTool.Options.IsAssetUsageLabelTypeOnVerbose)
				{
					if (n == 0)
					{
						if (isMaterialUsedByMesh)
						{
							GUILayout.Label(AssetUsageIsUsedAsDefaultMaterialByLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
						else if (isAResourcesAsset)
						{
							GUILayout.Label(AssetUsageIsAResourcesAssetButAlsoUsedByLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
						else if (isAssetUsedByScript)
						{
							GUILayout.Label(AssetUsageIsUsedAsDefaultValueByLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
						else
						{
							GUILayout.Label(AssetUsageIsUsedByLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
					}
					else if (n < len - 1)
					{
						if (isMaterialUsedByMesh)
						{
							GUILayout.Label(AssetUsageWhichIsUsedAsDefaultMaterialByLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
						else if (isAResourcesAsset)
						{
							GUILayout.Label(AssetUsageWhichIsAResourcesAssetButAlsoUsedByLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
						else if (isAssetUsedByScript)
						{
							GUILayout.Label(AssetUsageWhichIsUsedAsDefaultValueByLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
						else
						{
							GUILayout.Label(AssetUsageWhichIsUsedByLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
					}
					else if (n == len - 1)
					{
						if (_assetUsageAncestry[n].AssetPath.IsSceneFile())
						{
							GUILayout.Label(AssetUsageWhichIsInTheBuildLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
						else if (_assetUsageAncestry[n].AssetPath.IsInResourcesFolder())
						{
							GUILayout.Label(AssetUsageWhichIsAResourcesAssetLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
						else if (_assetUsageAncestry[n].CyclicDependency)
						{
							GUILayout.Label(AssetUsageWhichIsACyclicDependencyLabel,
								assetLabelInBetweenStyle, BRT_BuildReportWindow.LayoutNone);
						}
					}
				}
				else if (BuildReportTool.Options.IsAssetUsageLabelTypeOnStandard)
				{
					// don't draw arrow after last asset
					if (n < len - 1)
					{
						// todo determine if _assetUsageAncestry[n] has extra info and draw that and different kind of arrow

						var needWidth = assetUsageArrow.width + assetUsageArrowStyle.padding.horizontal;

						// Note: I set the width to 9 for the GetRect(), and it gives me a width of 422 (???)
						// I have to force set expand width to false. It seems expand width is set to true,
						// even with no style specified.
						Rect arrowRect = GUILayoutUtility.GetRect(needWidth, assetUsageArrow.height,
							GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));

						//Debug.LogFormat("Event.current.type: {0}\nrequested width x height: {1}x{2}\ngot rect: {3}",
						//	Event.current.type, needWidth, needHeight, arrowRect);

						if (Event.current.type == EventType.Repaint)
						{
							arrowRect.y += ((ASSET_INFO_ROW_HEIGHT - assetUsageArrow.height) / 2.0f);
							arrowRect.height = assetUsageArrow.height;
							GUI.DrawTexture(arrowRect, assetUsageArrow);
						}
					}
				}
				else if (BuildReportTool.Options.IsAssetUsageLabelTypeOnMinimal)
				{
					// don't draw arrow after last asset
					if (n < len - 1)
					{
						var needWidth = assetUsageArrow.width + assetUsageArrowStyle.padding.horizontal;

						// Note: I set the width to 9 for the GetRect(), and it gives me a width of 422 (???)
						// I have to force set expand width to false. It seems expand width is set to true,
						// even with no style specified.
						Rect arrowRect = GUILayoutUtility.GetRect(needWidth, assetUsageArrow.height,
							GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));

						//Debug.LogFormat("Event.current.type: {0}\nrequested width x height: {1}x{2}\ngot rect: {3}",
						//	Event.current.type, needWidth, needHeight, arrowRect);

						if (Event.current.type == EventType.Repaint)
						{
							arrowRect.y += ((ASSET_INFO_ROW_HEIGHT - assetUsageArrow.height) / 2.0f);
							arrowRect.height = assetUsageArrow.height;
							GUI.DrawTexture(arrowRect, assetUsageArrow);
						}
					}
				}

				// --------------------------
			} // end of for-loop on asset usage ancestry

			if (Event.current.type == EventType.Repaint)
			{
				_assetUsageAncestryHoveredIdx = newAssetUsageAncestryEntryHoveredIdx;
			}

			GUILayout.EndHorizontal();
			if (moreThan1Row)
			{
				GUILayout.Space(ASSET_USAGE_HISTORY_LAST_ROW_PADDING);
			}

			if (_assetUsageAncestryHasFbxUsingDefaultMaterialUsedInScene)
			{
				GUILayout.Label(AssetUsageAncestryDefaultMaterialInFbxOfScene, BRT_BuildReportWindow.LayoutNone);
			}
		}


		int GetNumberOfAssetUsageAncestryRows(List<AssetUsageAncestry> list, float availableWidth)
		{
			var assetStyle = GUI.skin.GetStyle("Asset");
			var assetLabelInBetweenStyle = GUI.skin.GetStyle("LabelSingleLine");
			var assetUsageArrowStyle = GUI.skin.GetStyle("AssetUsageArrow");
			var assetUsageArrow = assetUsageArrowStyle.normal.background;

			var numberOfRowsInAssetUsageAncestry = 1;

			float currentRowWidth = 0;

			for (int n = 0, len = list.Count; n < len; ++n)
			{
				// --------------------------
				// width of the asset name

				var widthToAdd = assetStyle.CalcSize(list[n].Label).x;

#if BRT_ASSET_LIST_SCREEN_DEBUG
				_debugText.AppendFormat("Item {0} name width: {1}\n",
					n.ToString(),
					widthToAdd.ToString(CultureInfo.InvariantCulture));
#endif

				if (currentRowWidth + widthToAdd >= availableWidth)
				{
#if BRT_ASSET_LIST_SCREEN_DEBUG
					_debugText.AppendFormat("Row {0} width: {1}\n",
						numberOfRowsInAssetUsageAncestry.ToString(),
						currentRowWidth.ToString(CultureInfo.InvariantCulture));
#endif

					currentRowWidth = 0;

					++numberOfRowsInAssetUsageAncestry;
				}

				currentRowWidth += widthToAdd;

				// --------------------------
				// width of the label following the asset

				widthToAdd = 0;

				if (BuildReportTool.Options.IsAssetUsageLabelTypeOnVerbose)
				{
					if (n == 0)
					{
						if (IsFileNextToFile(list, n, ".mat", ".fbx"))
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageIsUsedAsDefaultMaterialByLabel).x;
						}
						else if (list[n].AssetPath.IsInResourcesFolder())
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageIsAResourcesAssetButAlsoUsedByLabel).x;
						}
						else if ((n < len - 1) && list[n + 1].AssetPath.IsFileOfType(".cs"))
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageIsUsedAsDefaultValueByLabel).x;
						}
						else
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageIsUsedByLabel).x;
						}

						widthToAdd += assetLabelInBetweenStyle.margin.horizontal;
					}
					else if (n < len - 1)
					{
						if (IsFileNextToFile(list, n, ".mat", ".fbx"))
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsUsedAsDefaultMaterialByLabel).x;
						}
						else if (list[n].AssetPath.IsInResourcesFolder())
						{
							widthToAdd = assetLabelInBetweenStyle
							             .CalcSize(AssetUsageWhichIsAResourcesAssetButAlsoUsedByLabel).x;
						}
						else if ((n < len - 1) && list[n + 1].AssetPath.IsFileOfType(".cs"))
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsUsedAsDefaultValueByLabel).x;
						}
						else
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsUsedByLabel).x;
						}

						widthToAdd += assetLabelInBetweenStyle.margin.horizontal;
					}
					else if (n == len - 1)
					{
						if (list[n].AssetPath.IsSceneFile())
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsInTheBuildLabel).x +
							             assetLabelInBetweenStyle.margin.horizontal;
						}
						else if (list[n].AssetPath.IsInResourcesFolder())
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsAResourcesAssetLabel).x +
							             assetLabelInBetweenStyle.margin.horizontal;
						}
						else if (list[n].CyclicDependency)
						{
							widthToAdd = assetLabelInBetweenStyle.CalcSize(AssetUsageWhichIsACyclicDependencyLabel).x +
							             assetLabelInBetweenStyle.margin.horizontal;
						}
					}
				}
				else if (BuildReportTool.Options.IsAssetUsageLabelTypeOnStandard)
				{
					if (n < len - 1)
					{
						// todo determine if list[n] has extra info and add that to width
						widthToAdd = assetUsageArrow.width + assetUsageArrowStyle.padding.horizontal;
					}
				}
				else if (BuildReportTool.Options.IsAssetUsageLabelTypeOnMinimal)
				{
					if (n < len - 1)
					{
						widthToAdd = assetUsageArrow.width + assetUsageArrowStyle.padding.horizontal;
					}
				}

#if BRT_ASSET_LIST_SCREEN_DEBUG
				_debugText.AppendFormat("Item {0} in-between label width: {1}\n",
					n,
					widthToAdd.ToString(CultureInfo.InvariantCulture));
#endif

				if (currentRowWidth + widthToAdd >= availableWidth)
				{
#if BRT_ASSET_LIST_SCREEN_DEBUG
					_debugText.AppendFormat("Row {0} width: {1}\n",
						numberOfRowsInAssetUsageAncestry.ToString(),
						currentRowWidth.ToString(CultureInfo.InvariantCulture));
#endif

					currentRowWidth = 0;

					++numberOfRowsInAssetUsageAncestry;
				}

				currentRowWidth += widthToAdd;
			}

#if BRT_ASSET_LIST_SCREEN_DEBUG
			_debugText.AppendFormat("numberOfRowsInAssetUsageTraceHistory: {0}\n",
				numberOfRowsInAssetUsageAncestry.ToString());
#endif


			return numberOfRowsInAssetUsageAncestry;
		}


		/// <summary>
		/// Trace the ancestry
		/// "end user" is either a scene that's included in the build, or a Resources asset.
		/// </summary>
		/// <param name="rootAsset">the asset whose usage we are inspecting</param>
		/// <param name="assetDependencies"></param>
		void SetAssetUsageHistoryToFirstEndUser(string rootAsset, AssetDependencies assetDependencies)
		{
			var dependencies = assetDependencies.GetAssetDependencies();

			if (!dependencies.ContainsKey(rootAsset))
			{
				return;
			}

			var selectedAssetDependencies = dependencies[rootAsset];
			var selectedAssetUsers = selectedAssetDependencies.Users;

			if (selectedAssetUsers.Count <= 0)
			{
				// asset isn't used by any other asset
				return;
			}

			var usersFlattened = selectedAssetDependencies.UsersFlattened;

			if (usersFlattened.Count <= 0)
			{
				// asset has no flattened users list
				return;
			}


			// ----------------
			// find first scene

			for (int n = 0, len = usersFlattened.Count; n < len; ++n)
			{
				if (usersFlattened[n].AssetPath.IsSceneFile())
				{
					_selectedAssetUserIdx = n;
					SetAssetUsageAncestry(_assetUsageAncestry, usersFlattened, n, rootAsset);
					_assetUsageAncestryHasFbxUsingDefaultMaterialUsedInScene =
						DoesAssetUsageAncestryHaveFbxUsingDefaultMaterialUsedInScene(_assetUsageAncestry);
					return;
				}
			}

			// ----------------
			// no scene found, now check if a Resources asset uses it

			for (int n = 0, len = usersFlattened.Count; n < len; ++n)
			{
				if (usersFlattened[n].AssetPath.IsInResourcesFolder())
				{
					_selectedAssetUserIdx = n;
					SetAssetUsageAncestry(_assetUsageAncestry, usersFlattened, n, rootAsset);
					_assetUsageAncestryHasFbxUsingDefaultMaterialUsedInScene = false;
					return;
				}
			}

			// ----------------
			// no end user found, just select the first user

			_selectedAssetUserIdx = 0;
			SetAssetUsageAncestry(_assetUsageAncestry, usersFlattened, 0, rootAsset);
			_assetUsageAncestryHasFbxUsingDefaultMaterialUsedInScene = false;
		}


		/// <summary>
		/// Check special case when a scene is using an fbx directly (did not save it as a prefab first).
		/// In this case, it's impossible to tell whether the fbx in that scene is using its
		/// default material, or if it's overriden to use no material. So, without opening the scene
		/// and checking directly, we cannot be sure of the Asset Usage Ancestry in this situation.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		static bool DoesAssetUsageAncestryHaveFbxUsingDefaultMaterialUsedInScene(List<AssetUsageAncestry> list)
		{
			if (list.Count >= 3 &&
			    list[list.Count - 1].AssetPath.IsSceneFile() &&
			    list[list.Count - 2].AssetPath.IsMeshFile() &&
			    list[list.Count - 3].AssetPath.IsMaterialFile())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Trace the ancestry of asset usage gor a given asset, and assign it to the destination List.
		/// </summary>
		/// <param name="destination"></param>
		/// <param name="source">Entire asset usage chain</param>
		/// <param name="idxChosenFromSource"></param>
		/// <param name="rootAsset">the asset whose usage we are inspecting</param>
		static void SetAssetUsageAncestry(List<AssetUsageAncestry> destination, List<AssetUserFlattened> source,
			int idxChosenFromSource, string rootAsset)
		{
			destination.Clear();

			// --------------------------------------

			AssetUsageAncestry lastEntry;
			lastEntry.AssetPath = source[idxChosenFromSource].AssetPath;
			lastEntry.CyclicDependency = source[idxChosenFromSource].CyclicDependency;
			lastEntry.Label =
				new GUIContent(
					System.IO.Path.GetFileName(lastEntry.AssetPath),
					AssetDatabase.GetCachedIcon(lastEntry.AssetPath));

			destination.Add(lastEntry);

			// --------------------------------------

			var currentIndentLevel = source[idxChosenFromSource].IndentLevel;

			// go backwards and insert each one in front of the destination list
			for (int traceN = idxChosenFromSource - 1; traceN >= 0; --traceN)
			{
				// we need only the entries that move to upper indent levels each time
				if (source[traceN].IndentLevel >= currentIndentLevel)
				{
					continue;
				}

				currentIndentLevel = source[traceN].IndentLevel;

				AssetUsageAncestry newEntry;
				newEntry.AssetPath = source[traceN].AssetPath;
				newEntry.CyclicDependency = source[traceN].CyclicDependency;
				newEntry.Label =
					new GUIContent(
						System.IO.Path.GetFileName(newEntry.AssetPath),
						AssetDatabase.GetCachedIcon(newEntry.AssetPath));

				destination.Insert(0, newEntry);
			}

			// --------------------------------------

			AssetUsageAncestry firstEntry;
			firstEntry.AssetPath = rootAsset;
			firstEntry.CyclicDependency = false;
			firstEntry.Label =
				new GUIContent(
					System.IO.Path.GetFileName(firstEntry.AssetPath),
					AssetDatabase.GetCachedIcon(firstEntry.AssetPath));
			destination.Insert(0, firstEntry);
		}
	}
}