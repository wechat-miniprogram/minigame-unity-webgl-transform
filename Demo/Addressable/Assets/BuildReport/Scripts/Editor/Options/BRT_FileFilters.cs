using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BuildReportTool
{
	[System.Serializable]
	public class FileFilters
	{
		public FileFilters(string label, string[] filters)
		{
			_label = label;

			for (int n = 0, len = filters.Length; n < len; ++n)
			{
				_filtersDict.Add(filters[n], false);
				var shouldBeAllLowerCase = true;

				if ((filters[n].StartsWith("/") || filters[n].StartsWith("Assets/", StringComparison.OrdinalIgnoreCase)) &&
				    filters[n].EndsWith("/"))
				{
					_usesFolderFilter = true;
				}
				else if (filters[n].StartsWith(BUILT_IN_ASSET_KEYWORD, StringComparison.OrdinalIgnoreCase))
				{
					_usesFolderFilter = true;

					// note: filters for built-in types are case-sensitive
					shouldBeAllLowerCase = false;

					//Debug.Log("uses built-in: " + label + ", " + filters[n]);
				}
				else if (filters[n].StartsWith("\"") && filters[n].EndsWith("\""))
				{
					_usesExactFileMatching = true;
				}

				if (shouldBeAllLowerCase)
				{
					filters[n] = filters[n].ToLower();
				}
			}

			_filtersList = filters;
		}

		public FileFilters()
		{
			_label = "";
		}

		const string BUILT_IN_ASSET_KEYWORD = "Built-in";


		[SerializeField]
		string _label;

		readonly Dictionary<string, bool> _filtersDict = new Dictionary<string, bool>();

		[SerializeField]
		string[] _filtersList;

		[SerializeField]
		bool _usesFolderFilter;

		[SerializeField]
		bool _usesExactFileMatching;

		public string Label
		{
			get { return _label; }
			set { _label = value; }
		}

		public string[] FiltersList
		{
			get { return _filtersList; }
			set
			{
				_filtersList = value;

				for (int n = 0, len = _filtersList.Length; n < len; ++n)
				{
					_filtersDict.Add(_filtersList[n], false);
					var shouldBeAllLowerCase = true;

					if ((_filtersList[n].StartsWith("/") ||
					     _filtersList[n].StartsWith("Assets/", StringComparison.OrdinalIgnoreCase)) &&
					    _filtersList[n].EndsWith("/"))
					{
						_usesFolderFilter = true;
					}
					else if (_filtersList[n].StartsWith(BUILT_IN_ASSET_KEYWORD, StringComparison.OrdinalIgnoreCase))
					{
						_usesFolderFilter = true;
						shouldBeAllLowerCase = false;
						//Debug.Log("uses built-in: " + _label + ", " + _filtersList[n]);
					}
					else if (_filtersList[n].StartsWith("\"") && _filtersList[n].EndsWith("\""))
					{
						_usesExactFileMatching = true;
					}

					if (shouldBeAllLowerCase)
					{
						_filtersList[n] = _filtersList[n].ToLower();
					}
				}
			}
		}


		public string GetFileExt(string file)
		{
			int lastDotIdx = file.LastIndexOf(".", StringComparison.OrdinalIgnoreCase);
			if (lastDotIdx == -1) return "";
			return file.Substring(lastDotIdx, file.Length - lastDotIdx);
		}

		public bool IsFileInFilter(string file)
		{
			// -------------------------------------------------
			// try using folder filter method:

			if (_usesFolderFilter)
			{
				//Debug.Log(_label + " uses folder filter");
				for (int n = 0, len = _filtersList.Length; n < len; ++n)
				{
					// built-in asset compare is case-sensitive
					if (_filtersList[n].StartsWith(BUILT_IN_ASSET_KEYWORD, StringComparison.OrdinalIgnoreCase) &&
					    file.StartsWith(BUILT_IN_ASSET_KEYWORD, StringComparison.OrdinalIgnoreCase) &&
					    file.IndexOf(_filtersList[n], StringComparison.OrdinalIgnoreCase) != -1)
					{
						return true;
					}

					//Debug.Log(file + " ---- " + _filtersList[n]);
					if (file.IndexOf(_filtersList[n], StringComparison.OrdinalIgnoreCase) != -1)
					{
						return true;
					}
				}
			}

			// -------------------------------------------------
			// if not found using folder filter method, try exact file matching next:

			if (_usesExactFileMatching)
			{
				//Debug.Log("_usesExactFileMatching");

				for (int n = 0, len = _filtersList.Length; n < len; ++n)
				{
					//Debug.Log("in quotes: " + _filtersList[n] + " " + (_filtersList[n].StartsWith("\"") && _filtersList[n].EndsWith("\"")));


					if (_filtersList[n].StartsWith("\"") && _filtersList[n].EndsWith("\""))
					{
						string fileWithQuotes = "\"" + System.IO.Path.GetFileName(file) + "\"";

						//Debug.Log("match? " + _filtersList[n] + " == " + fileWithQuotes);

						if (_filtersList[n].Equals(fileWithQuotes))
						{
							return true;
						}
					}
				}
			}

			// -------------------------------------------------
			// if not found using exact file matching, try checking in dictionary next:

			var fileExtension = GetFileExt(file);

			if (_filtersDict.ContainsKey(fileExtension))
			{
				return true;
			}

			for (int n = 0, len = _filtersList.Length; n < len; ++n)
			{
				//Debug.Log("in quotes: " + _filtersList[n] + " " + (_filtersList[n].StartsWith("\"") && _filtersList[n].EndsWith("\"")));

				if (fileExtension.Equals(_filtersList[n], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			return false;
		}
	}


	[System.Serializable, XmlRoot("FileFilterGroup")]
	public class FileFilterGroup
	{
		[SerializeField]
		FileFilters[] _fileFilters;

		public FileFilters[] FileFilters
		{
			get { return _fileFilters; }
			set
			{
				_fileFilters = value;
				InitNames();
			}
		}

		[SerializeField]
		string[] _names;

		public FileFilterGroup()
		{
			_fileFilters = null;
			_names = null;
		}

		public FileFilterGroup(FileFilters[] filters)
		{
			_fileFilters = filters;
			InitNames();
		}

		void InitNames()
		{
			_names = new string[_fileFilters.Length + 2];

			_names[0] = "All";

			for (int n = 0, len = _fileFilters.Length; n < len; ++n)
			{
				_names[n + 1] = _fileFilters[n].Label;
			}

			_names[_names.Length - 1] = "Unknown";
		}

		int _selectedFilterIdx;

		/// <summary>
		/// -1 means "All" list.
		/// </summary>
		public int SelectedFilterIdx
		{
			get { return _selectedFilterIdx - 1; }
		}

		public int GetSelectedFilterIdx()
		{
			return _selectedFilterIdx;
		}

		public void ForceSetSelectedFilterIdx(int idx)
		{
			if ((idx < _fileFilters.Length + 2) && idx >= 0)
			{
				_selectedFilterIdx = idx;
			}
		}

		const string UNPRESSED_STYLE_NAME = "ButtonNoContents";
		const string ALREADY_PRESSED_STYLE_NAME = "ButtonAlreadyPressed";

		const string HAS_CONTENTS_UNPRESSED_STYLE_NAME = "ButtonHasContents";
		const string HAS_CONTENTS_ALREADY_PRESSED_STYLE_NAME = "ButtonAlreadyPressed";

		string GetStyleToUse(int assetNum, int selectedIdx, int idxOfThisGroup)
		{
			string styleToUse;

			if (assetNum > 0)
			{
				styleToUse = HAS_CONTENTS_UNPRESSED_STYLE_NAME;
				if (selectedIdx == idxOfThisGroup)
				{
					styleToUse = HAS_CONTENTS_ALREADY_PRESSED_STYLE_NAME;
				}
			}
			else
			{
				styleToUse = UNPRESSED_STYLE_NAME;
				if (selectedIdx == idxOfThisGroup)
				{
					styleToUse = ALREADY_PRESSED_STYLE_NAME;
				}
			}

			return styleToUse;
		}

		public bool Draw(AssetList assetList, float width)
		{
			BuildReportTool.Options.FileFilterDisplay displayType = BuildReportTool.Options.GetOptionFileFilterDisplay();
			switch (displayType)
			{
				case BuildReportTool.Options.FileFilterDisplay.DropDown:
					return DrawFiltersAsDropDown(assetList, width);
				case BuildReportTool.Options.FileFilterDisplay.Buttons:
					return DrawFiltersAsButtons(assetList, width);
			}

			return false;
		}

		bool DrawFiltersAsDropDown(AssetList assetList, float width)
		{
			var changed = false;
			GUILayout.BeginHorizontal();
			GUILayout.Space(3);
			GUILayout.Label("Filter: ", BuildReportTool.Window.Settings.TOP_BAR_LABEL_STYLE_NAME);
			if (assetList != null && assetList.Labels != null && assetList.Labels.Length > 0)
			{
				var newSelectedFilterIdx = EditorGUILayout.Popup(_selectedFilterIdx, assetList.Labels,
					BuildReportTool.Window.Settings.FILE_FILTER_POPUP_STYLE_NAME);

				if (newSelectedFilterIdx != _selectedFilterIdx)
				{
					_selectedFilterIdx = newSelectedFilterIdx;
					assetList.SortIfNeeded(this);
					changed = true;
				}
			}

			GUILayout.EndHorizontal();

			return changed;
		}

		bool DrawFiltersAsButtons(AssetList assetList, float width)
		{
			var changed = false;
			GUILayout.BeginHorizontal();

			float overallWidth = 0;


			var styleToUse = GetStyleToUse(assetList.All.Length, _selectedFilterIdx, 0);
			var label = "All (" + assetList.All.Length.ToString() + ")";

			var widthToAdd = GUI.skin.GetStyle(styleToUse).CalcSize(new GUIContent(label)).x;

			overallWidth += widthToAdd;

			if (GUILayout.Button(label, styleToUse))
			{
				_selectedFilterIdx = 0;
				assetList.SortIfNeeded(this);
				changed = true;
			}

			if (overallWidth >= width)
			{
				overallWidth = 0;
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
			}

			if (assetList.PerCategory != null && assetList.PerCategory.Length >= _fileFilters.Length)
			{
				for (int n = 0, len = _fileFilters.Length; n < len; ++n)
				{
					styleToUse = GetStyleToUse(assetList.PerCategory[n].Length, _selectedFilterIdx, n + 1);
					label = _fileFilters[n].Label + " (" + assetList.PerCategory[n].Length.ToString() + ")";

					widthToAdd = GUI.skin.GetStyle(styleToUse).CalcSize(new GUIContent(label)).x;

					if (overallWidth + widthToAdd >= width)
					{
						overallWidth = 0;
						GUILayout.EndHorizontal();
						GUILayout.BeginHorizontal();
					}

					overallWidth += widthToAdd;

					if (GUILayout.Button(label, styleToUse))
					{
						_selectedFilterIdx = n + 1;
						assetList.SortIfNeeded(this);
						changed = true;
					}
				}

				styleToUse = GetStyleToUse(assetList.PerCategory[assetList.PerCategory.Length - 1].Length,
					_selectedFilterIdx, assetList.PerCategory.Length);

				label = string.Format("Unknown ({0})",
					assetList.PerCategory[assetList.PerCategory.Length - 1].Length.ToString());
				widthToAdd = GUI.skin.GetStyle(styleToUse).CalcSize(new GUIContent(label)).x;
				if (overallWidth + widthToAdd >= width)
				{
					//overallWidth = 0;
					GUILayout.EndHorizontal();
					GUILayout.BeginHorizontal();
				}

				if (GUILayout.Button(label, styleToUse))
				{
					_selectedFilterIdx = assetList.PerCategory.Length;
					assetList.SortIfNeeded(this);
					changed = true;
				}
			}

			GUILayout.EndHorizontal();
			return changed;
		}

		public FileFilters this[int idx]
		{
			get { return _fileFilters[idx]; }
		}

		public int Count
		{
			get { return _fileFilters.Length; }
		}

		public override string ToString()
		{
			string ret = "(" + _names.Length.ToString() + ") ";

			for (int n = 0, len = _names.Length; n < len; ++n)
			{
				ret += _names[n] + ", ";
			}

			return ret;
		}
	}
} // namespace BuildReportTool