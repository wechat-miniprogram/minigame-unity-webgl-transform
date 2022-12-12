using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace BuildReportTool
{
	/// <summary>
	/// Class for holding which asset uses which.
	/// This is the class that is serialized when saving an Asset Dependency Report to a file.
	/// </summary>
	[System.Serializable, System.Xml.Serialization.XmlRoot("AssetDependencies")]
	public class AssetDependencies
	{
		/// <summary>
		/// Name of project folder.
		/// </summary>
		public string ProjectName;

		/// <summary>
		/// Type of build that the project was configured to, at the time that asset dependencies were calculated.
		/// </summary>
		public string BuildType;

		/// <summary>
		/// When asset dependencies were calculated.
		/// </summary>
		public System.DateTime TimeGot;

		public string GetDefaultFilename()
		{
			return BuildReportTool.Util.GetAssetDependenciesDefaultFilename(ProjectName, BuildType, TimeGot);
		}

		public string GetAccompanyingBuildReportFilename()
		{
			return BuildReportTool.Util.GetBuildInfoDefaultFilename(ProjectName, BuildType, TimeGot);
		}

		// ==================================================================================

		/// <summary>
		/// Full path where this Build Report is saved in the local storage.
		/// </summary>
		string _savedPath;

		/// <inheritdoc cref="_savedPath"/>
		public string SavedPath
		{
			get { return _savedPath; }
		}

		public void SetSavedPath(string val)
		{
			_savedPath = val;
		}


		public bool HasContents
		{
			get { return _assetDependencies.Count > 0; }
		}

		// ==================================================================================

		Dictionary<string, DependencyEntry> _assetDependencies = new Dictionary<string, DependencyEntry>();

		public List<string> Assets;
		public List<DependencyEntry> Dependencies;

		public Dictionary<string, DependencyEntry> GetAssetDependencies()
		{
			return _assetDependencies;
		}

		// ==================================================================================

		public void OnBeforeSave()
		{
			if (Assets != null)
			{
				Assets.Clear();
			}
			else
			{
				Assets = new List<string>();
			}

			Assets.AddRange(_assetDependencies.Keys);

			if (Dependencies != null)
			{
				Dependencies.Clear();
			}
			else
			{
				Dependencies = new List<DependencyEntry>();
			}

			Dependencies.AddRange(_assetDependencies.Values);
		}

		public void OnAfterLoad()
		{
			_assetDependencies.Clear();

			var len = Mathf.Min(Assets.Count, Dependencies.Count);
			for (int n = 0; n < len; ++n)
			{
				_assetDependencies.Add(Assets[n], Dependencies[n]);
			}
		}

		// ----------------------------------------------------------

		public static void PopulateAssetEndUsers(string rootAsset, AssetDependencies assetDependencies)
		{
			if (assetDependencies == null)
			{
				return;
			}

			var dependencies = assetDependencies.GetAssetDependencies();

			if (!dependencies.ContainsKey(rootAsset))
			{
				return;
			}

			var selectedAssetDependencies = dependencies[rootAsset];

			if (selectedAssetDependencies.Users.Count <= 0)
			{
				// asset isn't used by any other asset
				return;
			}

			var destination = selectedAssetDependencies.GetEndUserLabels();

			if (destination.Count > 0)
			{
				// already assigned
				return;
			}

			PopulateAssetEndUsers(rootAsset, destination, assetDependencies);
		}

		public static void PopulateAssetEndUsers(string rootAsset, List<GUIContent> destination,
			AssetDependencies assetDependencies)
		{
			if (assetDependencies == null)
			{
				return;
			}

			var dependencies = assetDependencies.GetAssetDependencies();

			if (!dependencies.ContainsKey(rootAsset))
			{
				return;
			}

			var selectedAssetDependencies = dependencies[rootAsset];

			if (destination.Count > 0)
			{
				// already assigned
				return;
			}

			var usersFlattened = selectedAssetDependencies.UsersFlattened;

			if (usersFlattened.Count <= 0)
			{
				// asset has no flattened users list
				destination.Clear();
				return;
			}

			// count: 2
			// availableExistingIdx: 0
			//
			// 1st primary user found:
			//  count <= availableExistingIdx
			//  2 <= 0 ? false: 1st primary user put to idx 0
			//  availableExistingIdx: 1
			//
			// 2nd primary user found:
			//  2 <= 1 ? false: 2nd primary user put to idx 1
			//  availableExistingIdx: 2
			//
			// 3rd primary user found:
			//  2 <= 2 ? true: 3rd primary user added as new entry to list (at idx 2)
			//  count: 3
			//  availableExistingIdx: 3
			//
			// while (count > availableExistingIdx)
			//  3 > 3 ? false: stop while loop

			// count : 0
			// availableExistingIdx: 0
			//
			// 1st primary user found:
			//  count <= availableExistingIdx
			//  0 <= 0 ? true: 1st primary user added as new entry to list (at idx 0)
			//  count: 1
			//  availableExistingIdx: 1
			//
			// while (count > availableExistingIdx)
			//  1 > 1 ? false: stop while loop

			// count: 2
			// availableExistingIdx: 0
			//
			// 1st primary user found:
			//  count <= availableExistingIdx
			//  2 <= 0 ? false: 1st primary user put to idx 0
			//  availableExistingIdx: 1
			//
			// while (count > availableExistingIdx)
			//  2 > 1 ? true: removed idx 1 of list
			//  1 > 1 ? false: stop while loop

			// count: 2
			// availableExistingIdx: 0
			//
			// while (count > availableExistingIdx)
			//  2 > 0 ? true: removed idx 1 of list
			//  1 > 0 ? true: removed idx 0 of list
			//  0 > 0 ? false: stop while loop

			int availableExistingIdx = 0;

			for (int n = 0, len = usersFlattened.Count; n < len; ++n)
			{
				if (usersFlattened[n].AssetPath.IsSceneFile() ||
				    usersFlattened[n].AssetPath.IsInResourcesFolder())
				{
					var assetFilename = System.IO.Path.GetFileName(usersFlattened[n].AssetPath);

					var alreadyInList = false;
					for (int alreadyN = 0, alreadyLen = availableExistingIdx; alreadyN < alreadyLen; ++alreadyN)
					{
						if (destination[alreadyN].text.Equals(assetFilename, StringComparison.OrdinalIgnoreCase))
						{
							alreadyInList = true;
							break;
						}
					}

					if (alreadyInList)
					{
						continue;
					}

					if (destination.Count <= availableExistingIdx)
					{
						destination.Add(new GUIContent(
							assetFilename,
							AssetDatabase.GetCachedIcon(usersFlattened[n].AssetPath),
							usersFlattened[n].AssetPath));
					}
					else
					{
						destination[availableExistingIdx].text = assetFilename;
						destination[availableExistingIdx].image = AssetDatabase.GetCachedIcon(usersFlattened[n].AssetPath);
						destination[availableExistingIdx].tooltip = usersFlattened[n].AssetPath;
					}

					++availableExistingIdx;
				}
			}

			while (destination.Count > availableExistingIdx)
			{
				destination.RemoveAt(destination.Count - 1);
			}
		}
	}

	// ==================================================================================

	public class DependencyEntry
	{
		/// <summary>
		/// Assets that this one uses.
		/// </summary>
		public List<string> Uses = new List<string>();

		/// <summary>
		/// Assets that use this one.
		/// </summary>
		public List<string> Users = new List<string>();

		/// <summary>
		/// Assets that use this one, and the assets that use those, et al.
		/// </summary>
		public List<AssetUserFlattened> UsersFlattened = new List<AssetUserFlattened>();

		List<GUIContent> _endUserLabels;

		public List<GUIContent> GetEndUserLabels()
		{
			if (_endUserLabels == null)
			{
				_endUserLabels = new List<GUIContent>();
			}

			return _endUserLabels;
		}
	}

	public struct AssetUserFlattened
	{
		public string AssetPath;

		/// <summary>
		/// Always starts at 1.
		/// </summary>
		public int IndentLevel;

		public bool CyclicDependency;

#if BRT_ASSET_DEPENDENCY_DEBUG
		public string DebugInfo;
#endif

		public AssetUserFlattened(string assetPath, int indentLevel)
		{
			AssetPath = assetPath;
			IndentLevel = indentLevel;
			CyclicDependency = false;

#if BRT_ASSET_DEPENDENCY_DEBUG
			DebugInfo = null;
#endif
		}

#if BRT_ASSET_DEPENDENCY_DEBUG
		public AssetUserFlattened(string assetPath, int indentLevel, string debugInfo)
		{
			AssetPath = assetPath;
			IndentLevel = indentLevel;
			CyclicDependency = false;

			DebugInfo = debugInfo;
		}
#endif
	}

	// ==================================================================================
}