#if UNITY_4 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
	#define UNITY_5_2_AND_LESSER
#endif

using UnityEditor;
using System.Linq;

namespace BuildReportTool
{
	public partial class BuildInfo
	{
		public struct SceneInBuild
		{
			public bool Enabled;
			public string Path;
		}

		// Queries
		// ==================================================================================

		public bool HasContents
		{
			get
			{
				// build sizes can't be empty (they are always there when you build)
				return !string.IsNullOrEmpty(ProjectName) && (BuildSizes != null && BuildSizes.Length > 0);
			}
		}

		public bool IsUnityVersionAtLeast(int majorAtLeast, int minorAtLeast, int patchAtLeast)
		{
			return DldUtil.UnityVersion.IsUnityVersionAtLeast(UnityVersion, majorAtLeast, minorAtLeast, patchAtLeast);
		}

		public bool IsUnityVersionAtMost(int majorAtMost, int minorAtMost, int patchAtMost)
		{
			return DldUtil.UnityVersion.IsUnityVersionAtMost(UnityVersion, majorAtMost, minorAtMost, patchAtMost);
		}

		public string SuitableTitle
		{
			get
			{
				if (UnityBuildSettings != null && UnityBuildSettings.HasValues &&
				    !string.IsNullOrEmpty(UnityBuildSettings.ProductName))
				{
					return UnityBuildSettings.ProductName;
				}

				return ProjectName;
			}
		}

		public string GetTimeReadable()
		{
			if (!string.IsNullOrEmpty(TimeGotReadable))
			{
				return TimeGotReadable;
			}

			return TimeGot.ToString(BuildReportTool.ReportGenerator.TIME_OF_BUILD_FORMAT);
		}

		public string UnityVersionDisplayed
		{
			get
			{
				if (UnityBuildSettings != null && UnityBuildSettings.HasValues)
				{
					return UnityVersion + (UnityBuildSettings.UsingAdvancedLicense ? " Pro" : "");
				}

				return UnityVersion;
			}
		}

		public string GetDefaultFilename()
		{
			return BuildReportTool.Util.GetBuildInfoDefaultFilename(ProjectName, BuildType, TimeGot);
		}

		public string GetAccompanyingAssetDependenciesFilename()
		{
			return BuildReportTool.Util.GetAssetDependenciesDefaultFilename(ProjectName, BuildType, TimeGot);
		}

		// old size values were only TotalBuildSize and CompressedBuildSize
		public bool HasOldSizeValues
		{
			get
			{
				return
					string.IsNullOrEmpty(UnusedTotalSize) &&
					string.IsNullOrEmpty(UsedTotalSize) &&
					string.IsNullOrEmpty(StreamingAssetsSize) &&
					string.IsNullOrEmpty(WebFileBuildSize) &&
					string.IsNullOrEmpty(AndroidApkFileBuildSize) &&
					string.IsNullOrEmpty(AndroidObbFileBuildSize);
			}
		}

		public bool HasUsedAssets
		{
			get { return UsedAssets != null; }
		}

		public bool HasUnusedAssets
		{
			get { return UnusedAssets != null; }
		}

		public bool HasStreamingAssets
		{
			get { return StreamingAssetsSize != "0 B"; }
		}

		// Commands
		// ==================================================================================

		/// <inheritdoc cref="_reportGenerationTime"/>
		[System.Xml.Serialization.XmlIgnore]
		public System.TimeSpan ReportGenerationTime
		{
			get { return _reportGenerationTime; }
			set { _reportGenerationTime = value; }
		}

		public void UnescapeAssetNames()
		{
			if (UsedAssets != null)
			{
				UsedAssets.UnescapeAssetNames();
			}

			if (UnusedAssets != null)
			{
				UnusedAssets.UnescapeAssetNames();
			}
		}

		public void RecategorizeAssetLists()
		{
			FileFilterGroup fileFiltersToUse = FileFilters;

			if (BuildReportTool.Options.ShouldUseConfiguredFileFilters())
			{
				fileFiltersToUse = BuildReportTool.FiltersUsed.GetProperFileFilterGroupToUse();
				//Debug.Log("going to use configured file filters instead... loaded: " + (fileFiltersToUse != null));
			}

			if (UsedAssets != null)
			{
				UsedAssets.AssignPerCategoryList(
					BuildReportTool.ReportGenerator.SegregateAssetSizesPerCategory(UsedAssets.All, fileFiltersToUse));

				UsedAssets.RefreshFilterLabels(fileFiltersToUse);

				UsedAssets.ResortDefault(BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow);
			}

			if (UnusedAssets != null)
			{
				UnusedAssets.AssignPerCategoryList(
					BuildReportTool.ReportGenerator.SegregateAssetSizesPerCategory(UnusedAssets.All, fileFiltersToUse));

				UnusedAssets.RefreshFilterLabels(fileFiltersToUse);

				UnusedAssets.ResortDefault(BuildReportTool.Options.NumberOfTopLargestUnusedAssetsToShow);
			}
		}

		public void RecategorizeUsedAssets()
		{
			if (UsedAssets == null)
			{
				return;
			}

			FileFilterGroup fileFiltersToUse = FileFilters;

			if (BuildReportTool.Options.ShouldUseConfiguredFileFilters())
			{
				fileFiltersToUse = BuildReportTool.FiltersUsed.GetProperFileFilterGroupToUse();
				//Debug.Log("going to use configured file filters instead... loaded: " + (fileFiltersToUse != null));
			}

			UsedAssets.AssignPerCategoryList(
				BuildReportTool.ReportGenerator.SegregateAssetSizesPerCategory(UsedAssets.All, fileFiltersToUse));

			UsedAssets.RefreshFilterLabels(fileFiltersToUse);

			UsedAssets.ResortDefault(BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow);
		}

		public void RecategorizeUnusedAssets()
		{
			if (UnusedAssets == null)
			{
				return;
			}

			FileFilterGroup fileFiltersToUse = FileFilters;

			if (BuildReportTool.Options.ShouldUseConfiguredFileFilters())
			{
				fileFiltersToUse = BuildReportTool.FiltersUsed.GetProperFileFilterGroupToUse();
				//Debug.Log("going to use configured file filters instead... loaded: " + (fileFiltersToUse != null));
			}

			UnusedAssets.AssignPerCategoryList(
				BuildReportTool.ReportGenerator.SegregateAssetSizesPerCategory(UnusedAssets.All, fileFiltersToUse));

			UnusedAssets.RefreshFilterLabels(fileFiltersToUse);

			UnusedAssets.ResortDefault(BuildReportTool.Options.NumberOfTopLargestUnusedAssetsToShow);
		}

		void CalculateUsedAssetsDerivedSizes()
		{
			if (UsedAssets != null)
			{
				for (int n = 0, len = UsedAssets.All.Length; n < len; ++n)
				{
					UsedAssets.All[n].DerivedSize = BuildReportTool.Util.GetApproxSizeFromString(UsedAssets.All[n].Size);
				}
			}
		}

		public void SortSizes()
		{
			System.Array.Sort(BuildSizes, delegate(BuildReportTool.SizePart b1, BuildReportTool.SizePart b2)
			{
				if (b1.Percentage > b2.Percentage) return -1;
				else if (b1.Percentage < b2.Percentage) return 1;
				// if percentages are equal, check actual file size (approximate values)
				else if (b1.DerivedSize > b2.DerivedSize) return -1;
				else if (b1.DerivedSize < b2.DerivedSize) return 1;
				return 0;
			});
		}


		/// <summary>
		/// This is called right after generating a build report.
		/// </summary>
		public void FixReport()
		{
#if UNITY_5_2_AND_LESSER
			// this bug has already been fixed since Unity 5.2.1
			// so we only execute this for Unity 5.2.0 and below

			if (!DldUtil.UnityVersion.IsUnityVersionAtLeast(5, 2, 1))
			{
				// --------------------------------------------------------------------------------
				// fix imported sizes of Resources files

				for (int n = 0; n < UsedAssets.All.Length; ++n)
				{
					if (BuildReportTool.Util.IsFileInAPath(UsedAssets.All[n].Name, "/Resources/"))
					{
						UsedAssets.All[n].ImportedSizeBytes = BRT_LibCacheUtil.GetImportedFileSize(UsedAssets.All[n].Name);
						UsedAssets.All[n].ImportedSize =
							BuildReportTool.Util.GetBytesReadable(UsedAssets.All[n].ImportedSizeBytes);

						UsedAssets.All[n].RawSizeBytes = UsedAssets.All[n].ImportedSizeBytes;
						UsedAssets.All[n].RawSize = UsedAssets.All[n].ImportedSize;

						UsedAssets.All[n].DerivedSize = 0;
						UsedAssets.All[n].Percentage = -1;
					}
				}

				UsedAssets.ResortDefault(BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow);

				// --------------------------------------------------------------------------------
				// recalculate percentages

				var totalSizePart = BuildSizes.FirstOrDefault(part => part.IsTotal);
				if (totalSizePart != null && System.Math.Abs(totalSizePart.DerivedSize) < 0.01)
				{
					var totalSize = GetTotalSize();
					ChangeTotalSize(totalSize);
				}

				// add textures, meshes, sounds, and animations that are in resources folder to the build size
				// since they are not included anymore in Unity 5

				var resourcesTextureSizeSum =
					GetSizeSumForUsedAssets("/Resources/", BuildReportTool.Util.IsTextureFile);
				AddToSize("Textures", resourcesTextureSizeSum);

				var resourcesMeshSizeSum = GetSizeSumForUsedAssets("/Resources/", BuildReportTool.Util.IsMeshFile);
				AddToSize("Meshes", resourcesMeshSizeSum);

				var resourcesSoundsSizeSum = GetSizeSumForUsedAssets("/Resources/", BuildReportTool.Util.IsSoundFile);
				AddToSize("Sounds", resourcesSoundsSizeSum);

				var resourcesAnimationsSizeSum =
					GetSizeSumForUsedAssets("/Resources/", BuildReportTool.Util.IsAnimationFile);
				AddToSize("Animations", resourcesAnimationsSizeSum);

				AddToTotalSize(resourcesTextureSizeSum);
				AddToTotalSize(resourcesMeshSizeSum);
				AddToTotalSize(resourcesSoundsSizeSum);
				AddToTotalSize(resourcesAnimationsSizeSum);

				RecalculatePercentages();

				// sort sizes again since we modified them
				SortSizes();
			}
#else
			// newer versions of Unity (2017 and up)
			// has a bug where the total size reported is actually the final build's size,
			// instead of the total of the sizes indicated in the build log.
			// so we recalculate the percentages.
			// this is most noticeable when the percentages
			// indicated don't really total up to 100, not even close to 90
			RecalculatePercentages();

			// sort sizes again since we modified them
			SortSizes();
#endif
		}

		// Events
		// ==================================================================================

		public void OnDeserialize()
		{
			if (HasContents)
			{
				CalculateUsedAssetsDerivedSizes();
				UnescapeAssetNames();
				RecategorizeAssetLists();
			}
		}

		// Helper methods
		// ==================================================================================

		double GetTotalSize()
		{
			if (BuildSizes == null)
			{
				return 0;
			}

			double totalSize = 0;
			for (int n = 0, len = BuildSizes.Length; n < len; ++n)
			{
				if (!BuildSizes[n].IsTotal)
				{
					totalSize += BuildSizes[n].DerivedSize;
				}
			}


			return totalSize;
		}

		void RecalculatePercentages()
		{
			//Debug.Log("RecalculatePercentages() called");


			double totalSize = GetTotalSize();

			//Debug.LogFormat("BuildSizes total: {0}", totalSize);

			for (int n = 0, len = BuildSizes.Length; n < len; ++n)
			{
				BuildSizes[n].Percentage = System.Math.Round((BuildSizes[n].UsableSize / totalSize) * 100, 2,
					System.MidpointRounding.AwayFromZero);
			}


			// note: only Used Assets are shown the percentages so we
			// don't bother recalculating percentage for Unused Assets
			if (UsedAssets != null)
			{
				UsedAssets.RecalculatePercentages(totalSize);
			}

			ChangeTotalSize(totalSize);
		}

		long GetSizeSumForUsedAssets(string assetFolderName, System.Func<string, bool> fileTypePredicate)
		{
			if (UsedAssets == null || UsedAssets.All == null)
			{
				return 0;
			}

			return UsedAssets.All.Where(part =>
				                 BuildReportTool.Util.IsFileInAPath(part.Name, assetFolderName) &&
				                 fileTypePredicate(part.Name))
			                 .Sum(part => BRT_LibCacheUtil.GetImportedFileSize(part.Name));
		}

		static void AddToSize(BuildReportTool.SizePart buildSize, long sizeToAdd)
		{
			if (buildSize != null)
			{
				buildSize.DerivedSize += sizeToAdd;
				buildSize.Size = BuildReportTool.Util.GetBytesReadable(buildSize.DerivedSize);
			}
		}

		void AddToSize(string buildSizeName, long sizeToAdd)
		{
			if (sizeToAdd == 0)
			{
				return;
			}

			BuildReportTool.SizePart buildSize = BuildSizes.FirstOrDefault(part => part.Name == buildSizeName);

			if (buildSize != null)
			{
				//Debug.LogFormat("{0} size before: {1}", buildSizeName, buildSize.DerivedSize);

				AddToSize(buildSize, sizeToAdd);

				//Debug.LogFormat("{0} size after: {1}", buildSizeName, buildSize.DerivedSize);
			}
		}

		void AddToTotalSize(long sizeToAdd)
		{
			if (sizeToAdd == 0)
			{
				return;
			}

			BuildReportTool.SizePart buildSize = BuildSizes.FirstOrDefault(part => part.IsTotal);

			if (buildSize != null)
			{
				//Debug.LogFormat("total size before: {0}", buildSize.DerivedSize);

				AddToSize(buildSize, sizeToAdd);

				UsedTotalSize = buildSize.Size;

				//Debug.LogFormat("total size after: {0}", buildSize.DerivedSize);
			}
		}

		void ChangeTotalSize(double newSize)
		{
			if (System.Math.Abs(newSize) < 0.01)
			{
				// disallow zero total size
				return;
			}

			BuildReportTool.SizePart totalSize = BuildSizes.FirstOrDefault(part => part.IsTotal);

			if (totalSize != null)
			{
				//Debug.LogFormat("total size before: {0}", totalSize.DerivedSize);

				totalSize.DerivedSize = newSize;
				totalSize.Size = BuildReportTool.Util.GetBytesReadable(totalSize.DerivedSize);

				UsedTotalSize = totalSize.Size;

				//Debug.LogFormat("total size after: {0}", totalSize.DerivedSize);
			}
		}


		// temp variables that are not serialized into the XML file
		// ==================================================================================

		// only used while generating the build report or opening one

		/// <summary>
		/// How long it took to create this Build Report.
		/// </summary>
		System.TimeSpan _reportGenerationTime;

		/// <summary>
		/// Needed for ParseDLLs
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public ApiCompatibilityLevel MonoLevel;

		/// <summary>
		/// Needed for ParseDLLs
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public StrippingLevel CodeStrippingLevel;


		public void SetScenes(EditorBuildSettingsScene[] newScenes)
		{
			var len = newScenes.Length;
			ScenesInBuild = new SceneInBuild[len];
			for (int n = 0; n < len; ++n)
			{
				ScenesInBuild[n].Enabled = newScenes[n].enabled;
				ScenesInBuild[n].Path = newScenes[n].path;
			}
		}

		public void SetScenes(string[] newScenes)
		{
			var len = newScenes.Length;
			ScenesInBuild = new SceneInBuild[len];
			for (int n = 0; n < len; ++n)
			{
				ScenesInBuild[n].Enabled = true;
				ScenesInBuild[n].Path = newScenes[n];
			}
		}


		int _unusedAssetsBatchNum;

		public int UnusedAssetsBatchNum
		{
			get { return _unusedAssetsBatchNum; }
		}

		public void MoveUnusedAssetsBatchNumToNext()
		{
			++_unusedAssetsBatchNum;
		}

		public void MoveUnusedAssetsBatchNumToPrev()
		{
			if (_unusedAssetsBatchNum == 0)
			{
				return;
			}

			--_unusedAssetsBatchNum;
		}

		// ---------------------------------------

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

		// ---------------------------------------

		BuildTarget _buildTarget;

		public BuildTarget BuildTargetUsed
		{
			get { return _buildTarget; }
		}

		public void SetBuildTargetUsed(BuildTarget val)
		{
			_buildTarget = val;
		}

		// ---------------------------------------

		bool _refreshRequest;

		public void FlagOkToRefresh()
		{
			_refreshRequest = true;
		}

		public void FlagFinishedRefreshing()
		{
			_refreshRequest = false;
		}

		public bool RequestedToRefresh
		{
			get { return _refreshRequest; }
		}
	}
}