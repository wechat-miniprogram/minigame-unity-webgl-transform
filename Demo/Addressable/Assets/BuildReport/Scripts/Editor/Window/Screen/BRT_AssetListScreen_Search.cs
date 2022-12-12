using System;
using UnityEditor;
using System.Collections.Generic;
using FuzzyString;


namespace BuildReportTool.Window.Screen
{
	public partial class AssetList
	{
		BuildReportTool.SizePart[] _searchResults;

		const double SEARCH_DELAY = 0.75f;
		double _lastSearchTime;
		string _lastSearchText = string.Empty;

		string _searchTextInput = string.Empty;

		int _searchViewOffset;

		// Search algorithms that will weigh in for the comparison
		readonly FuzzyStringComparisonOptions[] _searchOptions =
		{
			FuzzyStringComparisonOptions.UseOverlapCoefficient,
			FuzzyStringComparisonOptions.UseLongestCommonSubsequence,
			FuzzyStringComparisonOptions.UseLongestCommonSubstring
		};

		void ClearSearch()
		{
			_searchTextInput = "";
			_lastSearchText = null;
			_searchResults = null;
		}

		void UpdateSearch(double timeNow, BuildInfo buildReportToDisplay)
		{
			if (string.IsNullOrEmpty(_searchTextInput) && !string.IsNullOrEmpty(_lastSearchText))
			{
				// cancel search
				ClearSearch();
				if (buildReportToDisplay != null)
				{
					buildReportToDisplay.FlagOkToRefresh();
				}

				_searchViewOffset = 0;
			}
			else if ((timeNow - _lastSearchTime >= SEARCH_DELAY) &&
			         !_searchTextInput.Equals(_lastSearchText, StringComparison.Ordinal))
			{
				// update search
				_lastSearchText = _searchTextInput;
				_lastSearchTime = EditorApplication.timeSinceStartup;

				if (buildReportToDisplay != null)
				{
					Search(_lastSearchText, buildReportToDisplay);
					buildReportToDisplay.FlagOkToRefresh();
				}

				_searchViewOffset = 0;
				_currentSortType = BuildReportTool.AssetList.SortType.None;
				_lastSearchTime = timeNow;
			}
		}

		void Search(string searchText, BuildInfo buildReportToDisplay)
		{
			if (string.IsNullOrEmpty(searchText))
			{
				_searchResults = null;
				return;
			}

			BuildReportTool.AssetList list = GetAssetListToDisplay(buildReportToDisplay);


			BuildReportTool.FileFilterGroup filter = buildReportToDisplay.FileFilters;

			if (BuildReportTool.Options.ShouldUseConfiguredFileFilters())
			{
				filter = _configuredFileFilterGroup;
			}

			List<BuildReportTool.SizePart> searchResults = new List<BuildReportTool.SizePart>();


			BuildReportTool.SizePart[] assetListToSearchFrom = list.GetListToDisplay(filter);

			for (int n = 0; n < assetListToSearchFrom.Length; ++n)
			{
				if (IsANearStringMatch(assetListToSearchFrom[n].Name, searchText))
				{
					searchResults.Add(assetListToSearchFrom[n]);
				}
			}

			if (searchResults.Count > 0)
			{
				searchResults.Sort((a, b) =>
					GetFuzzyEqualityScore(searchText, a.Name).CompareTo(GetFuzzyEqualityScore(searchText, b.Name)));
			}

			_searchResults = searchResults.ToArray();
		}

		void SortBySearchRank(BuildReportTool.SizePart[] assetList, string searchText)
		{
			if (assetList.Length <= 0)
			{
				return;
			}

			System.Array.Sort(assetList, (entry1, entry2) =>
				GetFuzzyEqualityScore(searchText, entry1.Name)
					.CompareTo(GetFuzzyEqualityScore(searchText, entry2.Name)));
		}

		bool IsANearStringMatch(string source, string target)
		{
			if (string.IsNullOrEmpty(target))
			{
				return false;
			}

			// Choose the relative strength of the comparison - is it almost exactly equal? or is it just close?
			const FuzzyStringComparisonTolerance TOLERANCE = FuzzyStringComparisonTolerance.Strong;

			// Get a boolean determination of approximate equality
			return source.ApproximatelyEquals(target, TOLERANCE, _searchOptions);
		}

		double GetFuzzyEqualityScore(string source, string target)
		{
			if (string.IsNullOrEmpty(target))
			{
				return 0;
			}

			return source.GetFuzzyEqualityScore(target, _searchOptions);
		}
	}
}