using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WeChatWASM.EditorTable
{
	public interface ITableData
	{
		int nRowCount { get; }
		int nColumnCount { get; }

		string GetData(int nRow, int nColumn);
		void SetData(int nRow, int nColumn, dynamic data);
		void SaveData();
		void RemakeData();
	}
}

