using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace DldUtil
{
	public static class GetRspDefines
	{
		static string SmcsFilePath
		{
			get { return Application.dataPath + "/smcs.rsp"; }
		}

		static string McsFilePath
		{
			get { return Application.dataPath + "/mcs.rsp"; }
		}

		static string UsFilePath
		{
			get { return Application.dataPath + "/us.rsp"; }
		}

		static string BooFilePath
		{
			get { return Application.dataPath + "/boo.rsp"; }
		}

		public struct Entry
		{
			public int TimesDefinedInSmcs;
			public int TimesDefinedInMcs;
			public int TimesDefinedInUs;
			public int TimesDefinedInBoo;
			public int TimesDefinedInBuiltIn;
		}

		// Unity-made defines are in EditorUserBuildSettings.activeScriptCompilationDefines
		static bool IsDefineAlreadyInUnity(string defineName)
		{
			string[] builtInDefines = EditorUserBuildSettings.activeScriptCompilationDefines;

			for (int n = 0, len = builtInDefines.Length; n < len; n++)
			{
				if (builtInDefines[n] == defineName)
				{
					return true;
				}
			}

			return false;
		}

		// ========================================================================================

		static void IncrementTimesDefinedInBuiltIn(Dictionary<string, Entry> table, string define)
		{
			if (!table.ContainsKey(define))
			{
				table[define] = new Entry();
			}

			Entry currentDef = table[define];
			currentDef.TimesDefinedInBuiltIn++;

			// assign it back to store it
			table[define] = currentDef;
		}

		static void IncrementTimesDefinedInSmcs(Dictionary<string, Entry> table, string define)
		{
			if (!table.ContainsKey(define))
			{
				table[define] = new Entry();
			}

			Entry currentDef = table[define];
			currentDef.TimesDefinedInSmcs++;

			// assign it back to store it
			table[define] = currentDef;
		}

		static void IncrementTimesDefinedInMcs(Dictionary<string, Entry> table, string define)
		{
			if (!table.ContainsKey(define))
			{
				table[define] = new Entry();
			}

			Entry currentDef = table[define];
			currentDef.TimesDefinedInMcs++;

			// assign it back to store it
			table[define] = currentDef;
		}

		static void IncrementTimesDefinedInUs(Dictionary<string, Entry> table, string define)
		{
			if (!table.ContainsKey(define))
			{
				table[define] = new Entry();
			}

			Entry currentDef = table[define];
			currentDef.TimesDefinedInUs++;

			// assign it back to store it
			table[define] = currentDef;
		}

		static void IncrementTimesDefinedInBoo(Dictionary<string, Entry> table, string define)
		{
			if (!table.ContainsKey(define))
			{
				table[define] = new Entry();
			}

			Entry currentDef = table[define];
			currentDef.TimesDefinedInBoo++;

			// assign it back to store it
			table[define] = currentDef;
		}

		// ========================================================================================

		public static Dictionary<string, Entry> GetDefines()
		{
			Dictionary<string, Entry> result = new Dictionary<string, Entry>();

			// ---------------------------------------------------------

			string[] definesInSmcs = GetDefinesInsideFile(SmcsFilePath);

			if (definesInSmcs != null && definesInSmcs.Length > 0)
			{
				for (int n = 0, len = definesInSmcs.Length; n < len; n++)
				{
					IncrementTimesDefinedInSmcs(result, definesInSmcs[n]);
					if (IsDefineAlreadyInUnity(definesInSmcs[n]))
					{
						IncrementTimesDefinedInBuiltIn(result, definesInSmcs[n]);
					}
				}
			}

			// ---------------------------------------------------------

			string[] definesInMcs = GetDefinesInsideFile(McsFilePath);

			if (definesInMcs != null && definesInMcs.Length > 0)
			{
				for (int n = 0, len = definesInMcs.Length; n < len; n++)
				{
					IncrementTimesDefinedInMcs(result, definesInMcs[n]);
					if (IsDefineAlreadyInUnity(definesInMcs[n]))
					{
						IncrementTimesDefinedInBuiltIn(result, definesInMcs[n]);
					}
				}
			}

			// ---------------------------------------------------------

			string[] definesInUs = GetDefinesInsideFile(UsFilePath);

			if (definesInUs != null && definesInUs.Length > 0)
			{
				for (int n = 0, len = definesInUs.Length; n < len; n++)
				{
					IncrementTimesDefinedInUs(result, definesInUs[n]);
					if (IsDefineAlreadyInUnity(definesInUs[n]))
					{
						IncrementTimesDefinedInBuiltIn(result, definesInUs[n]);
					}
				}
			}

			// ---------------------------------------------------------

			string[] definesInBoo = GetDefinesInsideFile(BooFilePath);

			if (definesInBoo != null && definesInBoo.Length > 0)
			{
				for (int n = 0, len = definesInBoo.Length; n < len; n++)
				{
					IncrementTimesDefinedInBoo(result, definesInBoo[n]);
					if (IsDefineAlreadyInUnity(definesInBoo[n]))
					{
						IncrementTimesDefinedInBuiltIn(result, definesInBoo[n]);
					}
				}
			}

			// ---------------------------------------------------------

			return result;
		}

		static string[] GetDefinesInsideFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				return null;
			}

			string rawContents = File.ReadAllText(filePath);
			if (!rawContents.StartsWith("-define:"))
			{
				// malformed .rsp file
				return null;
			}

			// remove "-define:"
			string allDefines = rawContents.Substring(8);
			//Debug.Log(allDefines);

			return allDefines.Split(';');
		}
	}
}