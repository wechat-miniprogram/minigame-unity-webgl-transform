using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildReportTool
{
	/// <summary>
	/// A collection of file entries in a build report.
	/// Used to display the "Used Assets" and the "Unused Assets".
	/// </summary>
	[System.Serializable]
	public class AssetList
	{
		// ==================================================================================

		[SerializeField]
		BuildReportTool.SizePart[] _all;

		int[] _viewOffsets;

		[SerializeField]
		BuildReportTool.SizePart[][] _perCategory;


		[SerializeField]
		string[] _labels;


		public BuildReportTool.SizePart[] All
		{
			get { return _all; }
			set { _all = value; }
		}

		public BuildReportTool.SizePart[][] PerCategory
		{
			get { return _perCategory; }
		}

		public string[] Labels
		{
			get { return _labels; }
			set { _labels = value; }
		}

		// ==================================================================================

		BuildReportTool.SizePart[] _topLargest;

		public BuildReportTool.SizePart[] TopLargest
		{
			get { return _topLargest; }
		}

		public int NumberOfTopLargest
		{
			get
			{
				if (_topLargest == null)
				{
					return 0;
				}

				return _topLargest.Length;
			}
		}

		void PostSetListAll(int numberOfTop)
		{
			List<BuildReportTool.SizePart> topLargestList = new List<BuildReportTool.SizePart>();

			// temporarily sort "All" list by raw size so we can get the top largest
			SortAssetList(_all, SortType.RawSize, SortOrder.Descending);

			// in case entries in "all" list is lesser than the numberOfTop value
			int len = Mathf.Min(numberOfTop, _all.Length);

			for (int n = 0; n < len; ++n)
			{
				topLargestList.Add(_all[n]);
			}

			_topLargest = topLargestList.ToArray();

			// revert "All" list to original sort type
			Resort(_all);
		}

		public void ResortDefault(int numberOfTop)
		{
			PostSetListAll(numberOfTop);
		}

		// ==================================================================================
		// Sort Type

		public enum SortType
		{
			None,
			AssetFullPath,
			AssetFilename,
			RawSize,
			ImportedSize,

			/// <summary>
			/// Try imported size. If imported size is unavailable (N/A) use raw size.
			/// </summary>
			ImportedSizeOrRawSize,

			SizeBeforeBuild,
			PercentSize
		}

		public enum SortOrder
		{
			None,
			Ascending,
			Descending
		}

		SortType _lastSortType = SortType.None;
		SortOrder _lastSortOrder = SortOrder.None;

		public SortType LastSortType
		{
			get { return _lastSortType; }
		}

		public SortOrder LastSortOrder
		{
			get { return _lastSortOrder; }
		}

		readonly HashSet<int> _hasListBeenSorted = new HashSet<int>();

		public void Resort(BuildReportTool.SizePart[] assetList)
		{
			if (_lastSortType != SortType.None && _lastSortOrder != SortOrder.None)
			{
				SortAssetList(assetList, _lastSortType, _lastSortOrder);
			}
		}

		public void Sort(SortType sortType, SortOrder sortOrder, BuildReportTool.FileFilterGroup fileFilters)
		{
			_lastSortType = sortType;
			_lastSortOrder = sortOrder;

			_hasListBeenSorted.Clear();

			_hasListBeenSorted.Add(fileFilters.SelectedFilterIdx);

			// sort only currently displayed list
			if (fileFilters.SelectedFilterIdx == -1)
			{
				SortAssetList(_all, sortType, sortOrder);
			}
			else
			{
				SortAssetList(_perCategory[fileFilters.SelectedFilterIdx], sortType, sortOrder);
			}

			//SortAssetList(_all, sortType, sortOrder);
			//for (int n = 0, len = _perCategory.Length; n < len; ++n)
			//{
			//	SortAssetList(_perCategory[n], sortType, sortOrder);
			//}
		}

		public void SortIfNeeded(BuildReportTool.FileFilterGroup fileFilters)
		{
			if (_lastSortType != SortType.None && _lastSortOrder != SortOrder.None &&
			    !_hasListBeenSorted.Contains(fileFilters.SelectedFilterIdx))
			{
				if (fileFilters.SelectedFilterIdx == -1)
				{
					SortAssetList(_all, _lastSortType, _lastSortOrder);
				}
				else
				{
					SortAssetList(_perCategory[fileFilters.SelectedFilterIdx], _lastSortType, _lastSortOrder);
				}

				_hasListBeenSorted.Add(fileFilters.SelectedFilterIdx);
			}
		}

		public static void SortAssetList(BuildReportTool.SizePart[] assetList, SortType sortType, SortOrder sortOrder)
		{
			switch (sortType)
			{
				case SortType.RawSize:
					SortRawSize(assetList, sortOrder);
					break;
				case SortType.ImportedSize:
					SortImportedSize(assetList, sortOrder);
					break;
				case SortType.ImportedSizeOrRawSize:
					SortImportedSizeOrRawSize(assetList, sortOrder);
					break;
				case SortType.SizeBeforeBuild:
					SortSizeBeforeBuild(assetList, sortOrder);
					break;
				case SortType.PercentSize:
					SortPercentSize(assetList, sortOrder);
					break;
				case SortType.AssetFullPath:
					SortAssetFullPath(assetList, sortOrder);
					break;
				case SortType.AssetFilename:
					SortAssetName(assetList, sortOrder);
					break;
			}
		}

		static void SortRawSize(BuildReportTool.SizePart[] assetList, SortOrder sortOrder)
		{
			if (sortOrder == SortOrder.Descending)
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.UsableSize > entry2.UsableSize) return -1;
					if (entry1.UsableSize < entry2.UsableSize) return 1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetNameDescending(entry1, entry2);
				});
			}
			else
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.UsableSize > entry2.UsableSize) return 1;
					if (entry1.UsableSize < entry2.UsableSize) return -1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetNameAscending(entry1, entry2);
				});
			}
		}

		static void SortImportedSizeOrRawSize(BuildReportTool.SizePart[] assetList, SortOrder sortOrder)
		{
			if (sortOrder == SortOrder.Descending)
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.ImportedSizeOrRawSize > entry2.ImportedSizeOrRawSize) return -1;
					if (entry1.ImportedSizeOrRawSize < entry2.ImportedSizeOrRawSize) return 1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetNameDescending(entry1, entry2);
				});
			}
			else
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.ImportedSizeOrRawSize > entry2.ImportedSizeOrRawSize) return 1;
					if (entry1.ImportedSizeOrRawSize < entry2.ImportedSizeOrRawSize) return -1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetNameAscending(entry1, entry2);
				});
			}
		}

		static void SortImportedSize(BuildReportTool.SizePart[] assetList, SortOrder sortOrder)
		{
			if (sortOrder == SortOrder.Descending)
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.ImportedSizeBytes > entry2.ImportedSizeBytes) return -1;
					if (entry1.ImportedSizeBytes < entry2.ImportedSizeBytes) return 1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetNameDescending(entry1, entry2);
				});
			}
			else
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.ImportedSizeBytes > entry2.ImportedSizeBytes) return 1;
					if (entry1.ImportedSizeBytes < entry2.ImportedSizeBytes) return -1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetNameAscending(entry1, entry2);
				});
			}
		}

		static void SortSizeBeforeBuild(BuildReportTool.SizePart[] assetList, SortOrder sortOrder)
		{
			if (sortOrder == SortOrder.Descending)
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.SizeInAssetsFolderBytes > entry2.SizeInAssetsFolderBytes) return -1;
					if (entry1.SizeInAssetsFolderBytes < entry2.SizeInAssetsFolderBytes) return 1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetNameDescending(entry1, entry2);
				});
			}
			else
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.SizeInAssetsFolderBytes > entry2.SizeInAssetsFolderBytes) return 1;
					if (entry1.SizeInAssetsFolderBytes < entry2.SizeInAssetsFolderBytes) return -1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetNameAscending(entry1, entry2);
				});
			}
		}

		static void SortPercentSize(BuildReportTool.SizePart[] assetList, SortOrder sortOrder)
		{
			if (sortOrder == SortOrder.Descending)
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.Percentage > entry2.Percentage) return -1;
					if (entry1.Percentage < entry2.Percentage) return 1;

					// same percent
					// sort by asset name for assets with same percent
					return SortByAssetFullPathDescending(entry1, entry2);
				});
			}
			else
			{
				Array.Sort(assetList, delegate(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
				{
					if (entry1.Percentage > entry2.Percentage) return 1;
					if (entry1.Percentage < entry2.Percentage) return -1;

					// same size
					// sort by asset name for assets with same sizes
					return SortByAssetFullPathAscending(entry1, entry2);
				});
			}
		}

		static void SortAssetFullPath(BuildReportTool.SizePart[] assetList, SortOrder sortOrder)
		{
			if (sortOrder == SortOrder.Descending)
			{
				Array.Sort(assetList, SortByAssetFullPathDescending);
			}
			else
			{
				Array.Sort(assetList, SortByAssetFullPathAscending);
			}
		}

		static int SortByAssetFullPathDescending(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
		{
			int result = string.Compare(entry1.Name, entry2.Name, StringComparison.OrdinalIgnoreCase);

			return result;
		}

		static int SortByAssetFullPathAscending(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
		{
			int result = string.Compare(entry1.Name, entry2.Name, StringComparison.OrdinalIgnoreCase);

			// invert the result
			if (result == 1) return -1;
			if (result == -1) return 1;
			return 0;
		}

		static void SortAssetName(BuildReportTool.SizePart[] assetList, SortOrder sortOrder)
		{
			if (sortOrder == SortOrder.Descending)
			{
				Array.Sort(assetList, SortByAssetNameDescending);
			}
			else
			{
				Array.Sort(assetList, SortByAssetNameAscending);
			}
		}

		static int SortByAssetNameDescending(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
		{
			int result = string.Compare(System.IO.Path.GetFileName(entry1.Name), System.IO.Path.GetFileName(entry2.Name),
				StringComparison.OrdinalIgnoreCase);

			return result;
		}

		static int SortByAssetNameAscending(BuildReportTool.SizePart entry1, BuildReportTool.SizePart entry2)
		{
			int result = string.Compare(System.IO.Path.GetFileName(entry1.Name), System.IO.Path.GetFileName(entry2.Name),
				StringComparison.OrdinalIgnoreCase);

			// invert the result
			if (result == 1) return -1;
			if (result == -1) return 1;

			return 0;
		}

		// Queries
		// ==================================================================================

		public List<BuildReportTool.SizePart> GetAllAsList()
		{
			return _all.ToList();
		}

		public int AllCount
		{
			get { return _all.Length; }
		}

		public double GetTotalSizeInBytes()
		{
			double total = 0;

			for (int n = 0, len = _all.Length; n < len; ++n)
			{
				if (_all[n].UsableSize > 0)
				{
					total += _all[n].UsableSize;
				}
			}

			return total;
		}

		public int GetViewOffsetForDisplayedList(FileFilterGroup fileFilters)
		{
			if (_viewOffsets == null || _viewOffsets.Length == 0)
			{
				return 0;
			}

			if (fileFilters.SelectedFilterIdx == -1)
			{
				return _viewOffsets[0]; // _viewOffsets[0] is the "All" list
			}
			else if (PerCategory != null && PerCategory.Length >= fileFilters.SelectedFilterIdx + 1)
			{
				return _viewOffsets[fileFilters.SelectedFilterIdx + 1];
			}

			return 0;
		}

		public BuildReportTool.SizePart[] GetListToDisplay(FileFilterGroup fileFilters)
		{
			BuildReportTool.SizePart[] ret = null;
			if (fileFilters.SelectedFilterIdx == -1)
			{
				ret = All;
			}
			else if (PerCategory != null && PerCategory.Length >= fileFilters.SelectedFilterIdx + 1)
			{
				ret = PerCategory[fileFilters.SelectedFilterIdx];
			}

			return ret;
		}


		// Commands
		// ==================================================================================

		public void UnescapeAssetNames()
		{
			for (int n = 0, len = _all.Length; n < len; ++n)
			{
				_all[n].Name = BuildReportTool.Util.MyHtmlDecode(_all[n].Name);
			}


			if (_perCategory != null)
			{
				for (int catIdx = 0, catLen = _perCategory.Length; catIdx < catLen; ++catIdx)
				{
					for (int n = 0, len = _perCategory[catIdx].Length; n < len; ++n)
					{
						_perCategory[catIdx][n].Name = BuildReportTool.Util.MyHtmlDecode(_perCategory[catIdx][n].Name);
					}
				}
			}
		}

		public void SetViewOffsetForDisplayedList(FileFilterGroup fileFilters, int newVal)
		{
			if (fileFilters.SelectedFilterIdx == -1)
			{
				_viewOffsets[0] = newVal; // _viewOffsets[0] is the "All" list
			}
			else if (PerCategory != null && PerCategory.Length >= fileFilters.SelectedFilterIdx + 1)
			{
				_viewOffsets[fileFilters.SelectedFilterIdx + 1] = newVal;
			}
		}


		public void PopulateRawSizes()
		{
			/*long importedSize = -1;
			for (int n = 0, len = _all.Length; n < len; ++n)
			{
				importedSize = BRT_LibCacheUtil.GetImportedFileSize(_all[n].Name);

				_all[n].SizeBytes = importedSize;
				_all[n].Size = BuildReportTool.Util.GetBytesReadable(importedSize);
			}*/
		}


		public void PopulateImportedSizes()
		{
			for (int n = 0, len = _all.Length; n < len; ++n)
			{
				/*if (BuildReportTool.Util.IsFileAUnityAsset(_all[n].Name))
				{
					// Scene files/terrain files/scriptable object files/etc. always seem to be only 4kb in the library,
					// no matter how large the actual file in the assets folder really is.
					// The 4kb is probably just metadata/reference to the actual file itself.
					// Makes sense since these file types are "native" to unity, so no importing is necessary.
					//
					// In this case, the raw size (size of the file in the assets folder) counts as the imported size
					// so just use the raw size.

					_all[n].ImportedSizeBytes = _all[n].RawSizeBytes;
					_all[n].ImportedSize = _all[n].RawSize;
				}
				else*/
				{
					var importedSize = BRT_LibCacheUtil.GetImportedFileSize(_all[n].Name);

					_all[n].ImportedSizeBytes = importedSize;
					_all[n].ImportedSize = BuildReportTool.Util.GetBytesReadable(importedSize);
				}
			}
		}

		public void PopulateSizeInAssetsFolder()
		{
			var projectPath = BuildReportTool.Util.GetProjectPath(Application.dataPath);
			for (int n = 0, len = _all.Length; n < len; ++n)
			{
				string assetImportedPath = projectPath + BuildReportTool.Util.MyHtmlDecode(_all[n].Name);

				var size = BuildReportTool.Util.GetFileSizeInBytes(assetImportedPath);
				_all[n].SizeInAssetsFolderBytes = size;
				_all[n].SizeInAssetsFolder = BuildReportTool.Util.GetBytesReadable(size);
			}
		}

		public void RecalculatePercentages(double totalSize)
		{
			//Debug.Log("Recalculate Percentage Start");

			if (_all != null)
			{
				// if the all list is available,
				// prefer using that to get the total size

				totalSize = 0;

				for (int n = 0, len = _all.Length; n < len; ++n)
				{
					totalSize += _all[n].UsableSize;
				}
			}

			if (_all != null)
			{
				for (int n = 0, len = _all.Length; n < len; ++n)
				{
					_all[n].Percentage =
						Math.Round((_all[n].UsableSize / totalSize) * 100, 2, MidpointRounding.AwayFromZero);
					//Debug.Log("Percentage for: " + n + " " + _all[n].Name + " = " + _all[n].Percentage + " = " + _all[n].UsableSize + " / " + totalSize);
				}
			}

			if (_perCategory != null)
			{
				for (int catIdx = 0, catLen = _perCategory.Length; catIdx < catLen; ++catIdx)
				{
					for (int n = 0, len = _perCategory[catIdx].Length; n < len; ++n)
					{
						_perCategory[catIdx][n].Percentage =
							Math.Round((_perCategory[catIdx][n].UsableSize / totalSize) * 100, 2,
								MidpointRounding.AwayFromZero);
					}
				}
			}

			//Debug.Log("Recalculate Percentage End");
		}


		// Commands: Initialization
		// ==================================================================================

		public void Init(BuildReportTool.SizePart[] all, BuildReportTool.SizePart[][] perCategory, int numberOfTop,
			FileFilterGroup fileFilters)
		{
			All = all;
			PostSetListAll(numberOfTop);
			_perCategory = perCategory;

			_viewOffsets = new int[1 + PerCategory.Length]; // +1 since we need to include the "All" list

			if (_lastSortType == SortType.None)
			{
				// sort by raw size, descending, by default
				Sort(SortType.RawSize, SortOrder.Descending, fileFilters);
			}
			else
			{
				Sort(_lastSortType, _lastSortOrder, fileFilters);
			}

			RefreshFilterLabels(fileFilters);
		}

		public void Init(BuildReportTool.SizePart[] all, BuildReportTool.SizePart[][] perCategory, int numberOfTop,
			FileFilterGroup fileFilters, SortType newSortType, SortOrder newSortOrder)
		{
			_lastSortType = newSortType;
			_lastSortOrder = newSortOrder;

			Init(all, perCategory, numberOfTop, fileFilters);
		}

		public void Reinit(BuildReportTool.SizePart[] all, BuildReportTool.SizePart[][] perCategory, int numberOfTop)
		{
			All = all;
			PostSetListAll(numberOfTop);
			_perCategory = perCategory;
		}

		public void AssignPerCategoryList(BuildReportTool.SizePart[][] perCategory)
		{
			_perCategory = perCategory;
			_viewOffsets = new int[1 + _perCategory.Length]; // +1 since we need to include the "All" list
		}

		public void RefreshFilterLabels(FileFilterGroup fileFiltersToUse)
		{
			_labels = new string[1 + PerCategory.Length];
			_labels[0] = string.Format("All ({0})", All.Length.ToString());
			for (int n = 0, len = fileFiltersToUse.Count; n < len; ++n)
			{
				_labels[n + 1] = string.Format("{0} ({1})", fileFiltersToUse[n].Label, PerCategory[n].Length.ToString());
			}

			_labels[_labels.Length - 1] = string.Format("Unknown ({0})", PerCategory[PerCategory.Length - 1].Length.ToString());
		}


		// Sum Selection
		// ==================================================================================

		[SerializeField]
		Dictionary<string, BuildReportTool.SizePart> _selectedForSum = new Dictionary<string, BuildReportTool.SizePart>();

		BuildReportTool.SizePart _lastSelected;


		// Sum Selection: Queries
		// --------------------------------------------------------------------

		public bool InSumSelection(BuildReportTool.SizePart b)
		{
			return _selectedForSum.ContainsKey(b.Name);
		}

		double GetSizeOfSumSelection()
		{
			double total = 0;
			foreach (var pair in _selectedForSum)
			{
				if (pair.Value.UsableSize > 0)
				{
					total += pair.Value.UsableSize;
				}
			}

			return total;
		}

		public double GetPercentageOfSumSelection()
		{
			double total = 0;
			foreach (var pair in _selectedForSum)
			{
				if (pair.Value.Percentage > 0)
				{
					if (pair.Value.Percentage > 0)
					{
						total += pair.Value.Percentage;
					}
				}
			}

			return total;
		}

		public string GetReadableSizeOfSumSelection()
		{
			return BuildReportTool.Util.GetBytesReadable(GetSizeOfSumSelection());
		}

		public bool AtLeastOneSelectedForSum
		{
			get { return _selectedForSum.Count > 0; }
		}

		public bool IsNothingSelected
		{
			get { return _selectedForSum.Count <= 0; }
		}

		public Dictionary<string, SizePart>.Enumerator GetSelectedEnumerator()
		{
			return _selectedForSum.GetEnumerator();
		}

		public int GetSelectedCount()
		{
			return _selectedForSum.Count;
		}

		public SizePart GetLastSelected()
		{
			return _lastSelected;
		}


		// Sum Selection: Commands
		// --------------------------------------------------------------------

		public void ToggleSumSelection(BuildReportTool.SizePart b)
		{
			if (InSumSelection(b))
			{
				RemoveFromSumSelection(b);
			}
			else
			{
				AddToSumSelection(b);
			}
		}

		public void RemoveFromSumSelection(BuildReportTool.SizePart b)
		{
			_selectedForSum.Remove(b.Name);
		}

		public void AddToSumSelection(BuildReportTool.SizePart b)
		{
			if (_selectedForSum.ContainsKey(b.Name))
			{
				// already added
				return;
			}

			_selectedForSum.Add(b.Name, b);

			_lastSelected = b;
		}

		public void AddDisplayedRangeToSumSelection(FileFilterGroup fileFilters, int offset, int range)
		{
			BuildReportTool.SizePart[] listForSelection = GetListToDisplay(fileFilters);

			for (int n = offset; n < offset + range; ++n)
			{
				if (!InSumSelection(listForSelection[n]))
				{
					AddToSumSelection(listForSelection[n]);
				}
			}
		}

		public void AddAllDisplayedToSumSelection(FileFilterGroup fileFilters)
		{
			BuildReportTool.SizePart[] listForSelection = GetListToDisplay(fileFilters);

			for (int n = 0; n < listForSelection.Length; ++n)
			{
				if (!InSumSelection(listForSelection[n]))
				{
					AddToSumSelection(listForSelection[n]);
				}
			}
		}

		public void ClearSelection()
		{
			_selectedForSum.Clear();
		}
	}
} // namespace BuildReportTool