//#define BUILD_REPORT_TOOL_EXPERIMENTS

using UnityEngine;
using UnityEditor;
#if UNITY_5_3_OR_NEWER
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
#endif
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using DldUtil;

/*

Editor
Editor log can be brought up through the Open Editor Log button in Unity's Console window.

Mac OS X	~/Library/Logs/Unity/Editor.log (or /Users/username/Library/Logs/Unity/Editor.log)
Windows XP *	C:\Documents and Settings\username\Local Settings\Application Data\Unity\Editor\Editor.log
Windows Vista/7 *	C:\Users\username\AppData\Local\Unity\Editor\Editor.log

(*) On Windows the Editor log file is stored in the local application data folder: %LOCALAPPDATA%\Unity\Editor\Editor.log, where LOCALAPPDATA is defined by CSIDL_LOCAL_APPDATA.





need to parse contents of editor log.
this part is what we're interested in:

[quote]
Textures      196.4 kb	 3.4%
Meshes        0.0 kb	 0.0%
Animations    0.0 kb	 0.0%
Sounds        0.0 kb	 0.0%
Shaders       0.0 kb	 0.0%
Other Assets  37.4 kb	 0.6%
Levels        8.5 kb	 0.1%
Scripts       228.4 kb	 3.9%
Included DLLs 5.2 mb	 91.7%
File headers  12.5 kb	 0.2%
Complete size 5.7 mb	 100.0%

Used Assets, sorted by uncompressed size:
 39.1 kb	 0.7% Assets/BTX/GUI/Skin/Window.png
 21.0 kb	 0.4% Assets/BTX/GUI/BehaviourTree/Resources/BehaviourTreeGuiSkin.guiskin
 20.3 kb	 0.3% Assets/BTX/Fonts/DejaVuSans-SmallSize.ttf
 20.2 kb	 0.3% Assets/BTX/Fonts/DejaVuSans-Bold.ttf
 20.1 kb	 0.3% Assets/BTX/Fonts/DejaVuSansCondensed 1.ttf
 12.0 kb	 0.2% Assets/BTX/Fonts/DejaVuSansCondensed.ttf
 10.8 kb	 0.2% Assets/BTX/GUI/BehaviourTree/Nodes2/White.png
 8.1 kb	 0.1% Assets/BTX/GUI/BehaviourTree/Nodes/RoundedBox.png
 8.1 kb	 0.1% Assets/BTX/GUI/BehaviourTree/Nodes/Decorator.png
 4.9 kb	 0.1% Assets/BTX/GUI/Skin/Box.png
 4.6 kb	 0.1% Assets/BTX/GUI/BehaviourTree/GlovedHand.png
 4.5 kb	 0.1% Assets/BTX/GUI/Skin/TextField_Normal.png
 4.5 kb	 0.1% Assets/BTX/GUI/Skin/Button_Toggled.png
 4.5 kb	 0.1% Assets/BTX/GUI/Skin/Button_Normal.png
 4.5 kb	 0.1% Assets/BTX/GUI/Skin/Button_Active.png
 4.1 kb	 0.1% Assets/BTX/GUI/BehaviourTree/RunState/Visiting.png
 4.1 kb	 0.1% Assets/BTX/GUI/BehaviourTree/RunState/Success.png
 4.1 kb	 0.1% Assets/BTX/GUI/BehaviourTree/RunState/Running.png
 (etc. goes on and on until all files used are listed)
[/quote]


This part can also be helpful:

[quote]
Mono dependencies included in the build
Boo.Lang.dll
Mono.Security.dll
System.Core.dll
System.Xml.dll
System.dll
UnityScript.Lang.dll
mscorlib.dll
Assembly-CSharp.dll
Assembly-UnityScript.dll

[/quote]


so we're gonna flex our string parsing skills here.

just get this string since it seems to be constant enough:
"Used Assets, sorted by uncompressed size:"

then starting from that line going upwards, get the line that begins with "Textures"

we're relying on the assumption that this format won't get changed

in short, this is all complete hackery that won't be futureproof

hopefully UT would provide proper script access to this

*/

namespace BuildReportTool
{
	[System.Serializable]
	public partial class ReportGenerator
	{
		static BuildInfo _lastKnownBuildInfo;
		static AssetDependencies _lastKnownAssetDependencies;

		static bool _shouldCalculateBuildSize = true;

		static string _lastEditorLogPath = "";

		// given values only upon building
		static readonly Dictionary<string, bool> PrefabsUsedInScenes = new Dictionary<string, bool>();

		static readonly List<string> PrefabsUsedInScenesList = new List<string>();


		static string _lastSavePath = "";


		static BuildInfo CreateNewBuildInfo()
		{
			return new BuildInfo();
			//return ScriptableObject.CreateInstance<BuildInfo>();
		}


		/// <summary>
		/// Called to get project's values from the Unity Editor API after the project is built.
		/// Has to be called from the main thread.
		/// </summary>
		static void Init()
		{
			Init(ref _lastKnownBuildInfo, null, DateTime.Now);
		}

		public const string TIME_OF_BUILD_FORMAT = "yyyy MMM dd ddd h:mm:ss tt UTCz";

		static bool _gotCommandLineArguments;
		static bool _unityHasNoLogArgument;


		/// <summary>
		/// Get and store data that are only allowed to be accessed
		/// from the main thread here so it won't generate errors
		/// when we access them from threads.
		///
		/// Which means this function has to be called from the main
		/// thread.</summary>
		/// <param name="buildInfo">The BuildInfo to save the values to.</param>
		/// <param name="scenes">You can specify a custom list of scenes,
		/// if project was built with a custom build script.
		/// Otherwise, leave null so that it will just use
		/// UnityEditor.EditorBuildSettings.scenes instead.</param>
		/// <param name="timeOfGeneration">Record the time that build report generation was made.</param>
		static void Init(ref BuildInfo buildInfo, string[] scenes, DateTime timeOfGeneration)
		{
			if (buildInfo == null)
			{
				buildInfo = CreateNewBuildInfo();
			}

			// --------------------

			//Debug.LogFormat("BuildReportTool.ReportGenerator.Init() called");

			buildInfo.SetBuildTargetUsed(BuildReportTool.Util.BuildTargetOfLastBuild);

			// --------------------

			if (scenes != null)
			{
				buildInfo.SetScenes(scenes);
			}
			else
			{
				buildInfo.SetScenes(BuildReportTool.Util.GetAllScenesInBuild());
			}

			//for (int n = 0, len = buildInfo.ScenesIncludedInProject.Length; n < len; ++n)
			//{
			//	Debug.Log("scene " + n + ": " + buildInfo.ScenesIncludedInProject[n]);
			//}

			// --------------------

			if (!string.IsNullOrEmpty(_lastPathToBuiltProject))
			{
				buildInfo.BuildFilePath = _lastPathToBuiltProject;
			}
			else
			{
				buildInfo.BuildFilePath =
					EditorUserBuildSettings.GetBuildLocation(BuildReportTool.Util.BuildTargetOfLastBuild);
			}
			//Debug.Log("BuildTargetOfLastBuild: " + BuildReportTool.Util.BuildTargetOfLastBuild);

			// --------------------

			buildInfo.TimeGot = timeOfGeneration;
			buildInfo.TimeGotReadable = buildInfo.TimeGot.ToString(TIME_OF_BUILD_FORMAT);

			buildInfo.EditorAppContentsPath = EditorApplication.applicationContentsPath;
			buildInfo.ProjectAssetsPath = Application.dataPath;

			// --------------------

			buildInfo.UnityVersion = string.Format("Unity {0}", Application.unityVersion);

			buildInfo.IncludedSvnInUnused = BuildReportTool.Options.IncludeSvnInUnused;
			buildInfo.IncludedGitInUnused = BuildReportTool.Options.IncludeGitInUnused;

			buildInfo.UnusedAssetsEntriesPerBatch = BuildReportTool.Options.UnusedAssetsEntriesPerBatch;

			// --------------------

#if UNITY_5_6_OR_NEWER
			buildInfo.MonoLevel =
				PlayerSettings.GetApiCompatibilityLevel(EditorUserBuildSettings.selectedBuildTargetGroup);
#else
		buildInfo.MonoLevel = PlayerSettings.apiCompatibilityLevel;
#endif

#if !UNITY_2018_3_OR_NEWER
		buildInfo.CodeStrippingLevel = PlayerSettings.strippingLevel;
#endif

			// --------------------

			if (BuildReportTool.Options.GetProjectSettings)
			{
				buildInfo.HasUnityBuildSettings = true;
				buildInfo.UnityBuildSettings = new UnityBuildSettings();
				UnityBuildSettingsUtility.Populate(buildInfo.UnityBuildSettings);
			}
			else
			{
				buildInfo.HasUnityBuildSettings = false;
				buildInfo.UnityBuildSettings = null;
			}

			// --------------------

			//#if (UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6)
			buildInfo.AndroidUseAPKExpansionFiles = PlayerSettings.Android.useAPKExpansionFiles;
			//#endif

			buildInfo.AndroidCreateProject = buildInfo.BuildTargetUsed == BuildTarget.Android &&
			                                 !Util.IsFileOfType(buildInfo.BuildFilePath, ".apk");

			//Debug.Log("buildInfo.AndroidCreateProject: " + buildInfo.AndroidCreateProject);
			//Debug.Log("PlayerSettings.Android.useAPKExpansionFiles: " + PlayerSettings.Android.useAPKExpansionFiles);
			//Debug.Log("BuildOptions.AcceptExternalModificationsToPlayer: " + BuildOptions.AcceptExternalModificationsToPlayer);

			// --------------------

			buildInfo.UsedAssetsIncludedInCreation = BuildReportTool.Options.IncludeUsedAssetsInReportCreation;
			buildInfo.UnusedAssetsIncludedInCreation = BuildReportTool.Options.IncludeUnusedAssetsInReportCreation;
			buildInfo.UnusedPrefabsIncludedInCreation = BuildReportTool.Options.IncludeUnusedPrefabsInReportCreation;

			// --------------------

			_shouldCalculateBuildSize = BuildReportTool.Options.IncludeBuildSizeInReportCreation;

			// --------------------

			// clear old values if any
			buildInfo.ProjectName = null;
			buildInfo.UsedAssets = null;
			buildInfo.UnusedAssets = null;

			// --------------------

			//Debug.Log("getting _lastEditorLogPath");
			_lastEditorLogPath = BuildReportTool.Util.UsedEditorLogPath;
			_lastSavePath = BuildReportTool.Options.BuildReportSavePath;
		}

		static string _lastPathToBuiltProject = string.Empty;

		[UnityEditor.Callbacks.PostProcessBuild]
		static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
		{
			// OnPostprocessBuild also gets called when changing scene while game is running
			// so need to check if we really are in editor
			if (Application.isEditor && !Application.isPlaying)
			{
				//Debug.Log("post process build called in editor. pathToBuiltProject: " + pathToBuiltProject);

				if (!string.IsNullOrEmpty(pathToBuiltProject))
				{
					_lastPathToBuiltProject = pathToBuiltProject;
				}

				BuildReportTool.Util.BuildTargetOfLastBuild = EditorUserBuildSettings.activeBuildTarget;
				//Debug.Log("OnPostprocessBuild: got new BuildTargetOfLastBuild: " + BuildReportTool.Util.BuildTargetOfLastBuild);

				if (!BuildReportTool.Options.CollectBuildInfo)
				{
					return;
				}

				Init();
				CommitAdditionalInfoToCache();

				// later on, in BRT_BuildReportWindow.Update(),
				// the code will finally create a build report when it can
				BuildReportTool.Util.ShouldGetBuildReportNow = true;

				// later on, in BRT_BuildReportWindow.Update(),
				// when `BuildReportTool.ReportGenerator.IsFinishedGettingValuesFromThread` is true,
				// the code will finally save the created build report
				BuildReportTool.Util.ShouldSaveGottenBuildReportNow = true;

				if (BRT_BuildReportWindow.IsOpen || BuildReportTool.Options.ShouldShowWindowAfterBuild)
				{
					ShowBuildReportWithLastValues();
				}
			}

			//Debug.Log("post process build finished");
		}

		[UnityEditor.Callbacks.PostProcessScene]
		static void OnPostprocessScene()
		{
			if (Application.isPlaying)
			{
				return;
			}

			// get used prefabs on each scene
			//

			//Debug.Log("post process scene called");
			//Debug.Log(" at " + EditorApplication.currentScene);
			if (BuildReportTool.Options.IncludeUnusedPrefabsInReportCreation)
			{
				AddAllPrefabsUsedInCurrentSceneToList();
			}

			//Debug.Log("post process scene finished");
		}

		static void AddAllPrefabsUsedInScene(string sceneFilename)
		{
#if UNITY_5_3_OR_NEWER
			string[] assetsUsedInCurrentScene = AssetDatabase.GetDependencies(sceneFilename);
#else
		string[] assetsUsedInCurrentScene = AssetDatabase.GetDependencies(new []{sceneFilename});
#endif

			//Debug.Log(" in " + sceneFilename + ": " + assetsUsedInCurrentScene.Length);

			for (int n = 0, len = assetsUsedInCurrentScene.Length; n < len; ++n)
			{
				//Debug.Log(n + ": " + assetsUsedInCurrentScene[n]);
				if (assetsUsedInCurrentScene[n].EndsWith(".prefab", StringComparison.OrdinalIgnoreCase))
				{
					if (!PrefabsUsedInScenes.ContainsKey(assetsUsedInCurrentScene[n]))
					{
						//Debug.Log("added prefab used: " + assetsUsedInCurrentScene[n] + " from scene " + sceneFilename);
						PrefabsUsedInScenes.Add(assetsUsedInCurrentScene[n], false);
					}
				}
			}
		}

		static void AddAllPrefabsUsedInCurrentSceneToList()
		{
#if UNITY_5_3_OR_NEWER
			AddAllPrefabsUsedInScene(SceneManager.GetActiveScene().path);
#else
		AddAllPrefabsUsedInScene(EditorApplication.currentScene);
#endif
		}

		static void ClearListOfAllPrefabsUsedInAllScenes()
		{
			PrefabsUsedInScenes.Clear();
		}

		static void RefreshListOfAllPrefabsUsedInAllScenesIncludedInBuild()
		{
			ClearListOfAllPrefabsUsedInAllScenes();

			foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
			{
				//Debug.Log(S.path);
				if (scene.enabled) // is checkbox for this scene in build settings checked?
				{
					AddAllPrefabsUsedInScene(scene.path);
				}
			}
		}

		static void CommitAdditionalInfoToCache()
		{
			if (PrefabsUsedInScenes != null)
			{
				//Debug.Log("addInfo: " + (addInfo != null));

				//buildInfo.PrefabsUsedInScenes = new string[_prefabsUsedInScenes.Keys.Count];
				//_prefabsUsedInScenes.Keys.CopyTo(buildInfo.PrefabsUsedInScenes, 0);

				PrefabsUsedInScenesList.Clear();
				PrefabsUsedInScenesList.AddRange(PrefabsUsedInScenes.Keys);

				//Debug.Log("assigned to addInfo.PrefabsUsedInScenes: " + addInfo.PrefabsUsedInScenes.Length);
			}
		}

		// -------------------------------------------------------------------------------------------------


		static string GetBuildTypeFromEditorLog(string editorLogPath)
		{
			const string BUILD_TYPE_KEY = "*** Completed 'Build.";
			const string CANCELED_BUILD_TYPE_KEY = "*** Canceled 'Build.";

			string returnValue = GetBuildTypeFromEditorLog(editorLogPath, BUILD_TYPE_KEY);
			if (string.IsNullOrEmpty(returnValue))
			{
				returnValue = GetBuildTypeFromEditorLog(editorLogPath, CANCELED_BUILD_TYPE_KEY);
			}

			return returnValue;
		}

		static string GetBuildTypeFromEditorLog(string editorLogPath, string buildTypeKey)
		{
			//Debug.Log("GetBuildTypeFromEditorLog path: " + editorLogPath);
			var gotLines = DldUtil.BigFileReader.SeekAllText(editorLogPath, buildTypeKey);

			if (gotLines.Count == 0)
			{
				//Debug.LogFormat("no buildType got");
				return string.Empty;
			}

			var lastLine = gotLines[gotLines.Count - 1].Text;

			if (!string.IsNullOrEmpty(lastLine))
			{
				//Debug.LogFormat("GetBuildTypeFromEditorLog line: {0} for key: {1}", line, buildTypeKey);

				int buildTypeIdx = lastLine.LastIndexOf(buildTypeKey, StringComparison.Ordinal);
				//Debug.Log("buildTypeIdx: " + buildTypeIdx);

				if (buildTypeIdx == -1)
				{
					return string.Empty;
				}

				int buildTypeEndIdx = lastLine.IndexOf("' in ", buildTypeIdx, StringComparison.Ordinal);
				//Debug.Log("buildTypeEndIdx: " + buildTypeEndIdx);

				string buildType = lastLine.Substring(buildTypeIdx + buildTypeKey.Length,
					buildTypeEndIdx - buildTypeIdx - buildTypeKey.Length);

				int anotherDotIdx = buildType.IndexOf(".", StringComparison.Ordinal);
				if (anotherDotIdx > -1)
				{
					buildType = buildType.Substring(anotherDotIdx + 1, buildType.Length - anotherDotIdx - 1);
				}

				//Debug.LogFormat("buildType got: {0}", buildType);
				return buildType;
			}
			//else
			//{
			//	Debug.LogFormat("no buildType got");
			//}

			return string.Empty;
		}

		static bool HasInvalidPercentValue(string line)
		{
			return line.IndexOf("inf%", StringComparison.Ordinal) >= 0 ||
			       line.IndexOf("nan%", StringComparison.Ordinal) >= 0 || line.IndexOf("-1.$%",
				       StringComparison.Ordinal) >= 0 || line.IndexOf("1.$%", StringComparison.Ordinal) >= 0;
		}

		static BuildReportTool.SizePart[] ParseSizePartsFromString(string editorLogPath)
		{
			// now parse the build parts to an array of `BuildReportTool.SizePart`
			List<BuildReportTool.SizePart> buildSizes = new List<BuildReportTool.SizePart>();


			const string SIZE_PARTS_KEY = "Textures      ";

			foreach (string line in DldUtil.BigFileReader.ReadFile(editorLogPath, false, SIZE_PARTS_KEY))
			{
				// blank line signifies end of list
				if (string.IsNullOrEmpty(line) || line == "\n" || line == "\r\n")
				{
					break;
				}
				//Debug.LogFormat("ParseSizePartsFromString: line:\n{0}", line);

				string b = line;

				string gotName = "???";
				string gotSize = "?";
				string gotPercent;

				Match match = Regex.Match(b, @"^[a-z \t]+[^0-9]", RegexOptions.IgnoreCase);
				if (match.Success)
				{
					gotName = match.Groups[0].Value;
					gotName = gotName.Trim();

					if (gotName == "Included DLLs")
					{
						gotName = "System DLLs";
					}

					if (gotName == "Total User Assets")
					{
						// No need for this, we calculate our own total size.
						// The "Total User Assets" entry also signifies the
						// last part has been parsed already, so no need
						// to process further.
						break;
					}

					//Debug.LogFormat("    got name: {0}", gotName);
				}

				match = Regex.Match(b, @"[0-9.]+ (kb|mb|b|gb)", RegexOptions.IgnoreCase);
				if (match.Success)
				{
					gotSize = match.Groups[0].Value.ToUpper();
					//Debug.LogFormat("    got size: {0}", gotSize);
				}

				if (HasInvalidPercentValue(b))
				{
					gotPercent = "0";
					//Debug.LogFormat("    got percent (inf): {0}", gotPercent);
				}
				else
				{
					match = Regex.Match(b, @"[0-9.]+%", RegexOptions.IgnoreCase);
					if (match.Success)
					{
						gotPercent = match.Groups[0].Value;
						gotPercent = gotPercent.Substring(0, gotPercent.Length - 1);
						//Debug.LogFormat("    got percent: {0}", gotPercent);
					}
					else
					{
						gotPercent = "0";
					}
				}

				BuildReportTool.SizePart inPart = new BuildReportTool.SizePart();
				inPart.Name = gotName;
				inPart.Size = gotSize;
				inPart.Percentage = Double.Parse(gotPercent, CultureInfo.InvariantCulture);
				inPart.DerivedSize = BuildReportTool.Util.GetApproxSizeFromString(gotSize);

				//Debug.LogFormat("SizePart: {0} size: {1} percent: {2}", inPart.Name, inPart.Size, inPart.Percentage);

				buildSizes.Add(inPart);

				if (line.IndexOf("100.0%", StringComparison.Ordinal) != -1 ||
				    line.IndexOf("nan%", StringComparison.Ordinal) != -1 ||
				    gotName.IndexOf("Complete size", StringComparison.Ordinal) != -1)
				{
					// that was the final part of the list
					break;
				}
			}

			BuildReportTool.SizePart streamingAssetsSize = new BuildReportTool.SizePart();
			streamingAssetsSize.SetNameToStreamingAssets();
			streamingAssetsSize.Size = "0";
			streamingAssetsSize.SizeBytes = 0;
			streamingAssetsSize.Percentage = 0;

			buildSizes.Add(streamingAssetsSize);

			return buildSizes.ToArray();
		}

		const string ASSET_SIZES_KEY = "Used Assets, sorted by uncompressed size:";
		const string ASSET_SIZES_KEY_2 = "Used Assets and files from the Resources folder, sorted by uncompressed size:";

		static List<BuildReportTool.SizePart> ParseAssetSizesFromEditorLog(string editorLogPath,
			List<string> prefabsUsedInScenes)
		{
			List<BuildReportTool.SizePart> assetSizes = new List<BuildReportTool.SizePart>();
			Dictionary<string, bool> prefabsInBuildDict = new Dictionary<string, bool>();


			// note: list gotten from editor log is already sorted by raw size, descending

			foreach (string line in DldUtil.BigFileReader.ReadFile(editorLogPath, ASSET_SIZES_KEY, ASSET_SIZES_KEY_2))
			{
				if (string.IsNullOrEmpty(line) || line == "\n" || line == "\r\n")
				{
					break;
				}

				//Debug.LogFormat("from line: {0}", line);

				Match match = Regex.Match(line, @"^ [0-9].*[a-z0-9) ]$", RegexOptions.IgnoreCase);
				if (match.Success)
				{
					// it's an asset entry. parse it
					//string b = match.Groups[0].Value;

					string gotName = "???";
					string gotSize = "?";
					string gotPercent = "?";

					match = Regex.Match(line, @"Assets/.+", RegexOptions.IgnoreCase);
					if (match.Success)
					{
						gotName = match.Groups[0].Value;
						gotName = gotName.Trim();
						//Debug.Log("    name? " + gotName);
					}
					else
					{
						match = Regex.Match(line, @"Built-in.+:.+", RegexOptions.IgnoreCase);
						if (match.Success)
						{
							gotName = match.Groups[0].Value;
							gotName = gotName.Trim();
							//Debug.Log("    built-in?: " + gotName);
						}
						else
						{
							match = Regex.Match(line, @"Resources/.+", RegexOptions.IgnoreCase);
							if (match.Success)
							{
								gotName = match.Groups[0].Value;
								gotName = gotName.Trim();
								//Debug.Log("    built-in?: " + gotName);
							}
							else
							{
								match = Regex.Match(line, @"UnityExtensions/.+", RegexOptions.IgnoreCase);
								if (match.Success)
								{
									gotName = match.Groups[0].Value;
									gotName = gotName.Trim();
									//Debug.Log("    extension?: " + gotName);
								}
								else
								{
									match = Regex.Match(line, @"Packages/.+", RegexOptions.IgnoreCase);
									if (match.Success)
									{
										gotName = match.Groups[0].Value;
										gotName = gotName.Trim();
										//Debug.Log("    extension?: " + gotName);
									}
								}
							}
						}
					}

					match = Regex.Match(line, @"[0-9.]+ (kb|mb|b|gb)", RegexOptions.IgnoreCase);
					if (match.Success)
					{
						gotSize = match.Groups[0].Value.ToUpper();
						//Debug.Log("    size? " + gotSize);
					}
					else
					{
						Debug.Log("didn't find size for :" + line);
					}

					if (HasInvalidPercentValue(line))
					{
						gotPercent = "0";
					}
					else
					{
						match = Regex.Match(line, @"[0-9.]+%", RegexOptions.IgnoreCase);
						if (match.Success)
						{
							gotPercent = match.Groups[0].Value;
							gotPercent = gotPercent.Substring(0, gotPercent.Length - 1);
							//Debug.Log("    percent? " + gotPercent);
						}
						else
						{
							Debug.Log("didn't find percent for :" + line);
						}
					}
					//Debug.LogFormat("got: {0} size: {1} percent: {2}", gotName, gotSize, gotPercent);

					// UnityEngine dll files show up in the used assets list so don't add them in
					var filename = Path.GetFileName(gotName);
					if (BuildReportTool.Util.IsFileOfType(filename, ".dll") &&
					    BuildReportTool.Util.IsAUnityEngineDLL(filename))
					{
						//Debug.Log("Found UnityEngine dll in Used Assets: " + filename);
					}
					else
					{
						BuildReportTool.SizePart inPart = new BuildReportTool.SizePart();
						inPart.Name = System.Security.SecurityElement.Escape(gotName);
						inPart.Size = gotSize;
						inPart.SizeBytes = -1;
						inPart.DerivedSize = BuildReportTool.Util.GetApproxSizeFromString(gotSize);
						inPart.Percentage = Double.Parse(gotPercent, CultureInfo.InvariantCulture);


						// since this is a used asset, the size we got from the editor log *is* already the imported size
						// so don't bother computing imported size.
						long importedSizeBytes = -1;
						inPart.ImportedSizeBytes = importedSizeBytes;
						inPart.ImportedSize = BuildReportTool.Util.GetBytesReadable(importedSizeBytes);

						assetSizes.Add(inPart);

						//if (inPart.Name.IndexOf("Rocks_lighup.tif") > -1)
						//{
						//	Debug.LogFormat("Rocks_lighup.tif: got Size: {0} Imported Size: {1}", inPart.Size, inPart.ImportedSize);
						//}

						if (gotName.EndsWith(".prefab", StringComparison.OrdinalIgnoreCase))
						{
							prefabsInBuildDict.Add(gotName, false);
						}
					}
				}
				else
				{
					break;
				}
			}

			// Additional Step:
			// include prefabs that are instantiated in scenes (they are not by default)
			//Debug.Log("addInfo.PrefabsUsedInScenes: " + addInfo.PrefabsUsedInScenes.Length);
			foreach (string p in prefabsUsedInScenes)
			{
				if (p.IndexOf("/Resources/", StringComparison.Ordinal) != -1)
					continue; // prefabs in resources folder are already included in the editor log build info
				if (prefabsInBuildDict.ContainsKey(p)) continue; // if already in assetSizes, continue

				BuildReportTool.SizePart inPart = new BuildReportTool.SizePart();
				inPart.Name = p;
				inPart.Size = "N/A";
				inPart.Percentage = -1;

				//Debug.Log("   prefab added in used assets: " + p);

				assetSizes.Add(inPart);
			}

			return assetSizes;
		}


		public static BuildReportTool.SizePart[][] SegregateAssetSizesPerCategory(
			BuildReportTool.SizePart[] assetSizesAll, FileFilterGroup filters)
		{
			if (assetSizesAll == null || assetSizesAll.Length == 0) return null;

			// we do filters.Count+1 for Unrecognized category
			List<List<BuildReportTool.SizePart>> ret = new List<List<BuildReportTool.SizePart>>(filters.Count + 1);
			for (int n = 0, len = filters.Count + 1; n < len; ++n)
			{
				ret.Add(new List<BuildReportTool.SizePart>());
			}

			for (int idxAll = 0, lenAll = assetSizesAll.Length; idxAll < lenAll; ++idxAll)
			{
				BRT_BuildReportWindow.GetValueMessage =
					"Segregating assets " + (idxAll + 1) + " of " + assetSizesAll.Length + "...";

				var foundAtLeastOneMatch = false;
				for (int n = 0, len = filters.Count; n < len; ++n)
				{
					if (filters[n].IsFileInFilter(assetSizesAll[idxAll].Name))
					{
						foundAtLeastOneMatch = true;
						ret[n].Add(assetSizesAll[idxAll]);
					}
				}

				if (!foundAtLeastOneMatch)
				{
					ret[ret.Count - 1].Add(assetSizesAll[idxAll]);
				}
			}

			BRT_BuildReportWindow.GetValueMessage = "";

			BuildReportTool.SizePart[][] retArr = new BuildReportTool.SizePart[filters.Count + 1][];
			for (int n = 0, len = filters.Count + 1; n < len; ++n)
			{
				retArr[n] = ret[n].ToArray();
			}

			return retArr;
		}


		public static void MoveUnusedAssetsBatchToNext(BuildInfo buildInfo, FileFilterGroup filtersToUse)
		{
			buildInfo.MoveUnusedAssetsBatchNumToNext();
			RefreshUnusedAssetsBatch(buildInfo, filtersToUse);
		}

		public static void MoveUnusedAssetsBatchToPrev(BuildInfo buildInfo, FileFilterGroup filtersToUse)
		{
			if (buildInfo.UnusedAssetsBatchNum == 0)
			{
				return;
			}

			buildInfo.MoveUnusedAssetsBatchNumToPrev();
			RefreshUnusedAssetsBatch(buildInfo, filtersToUse);
		}

		static void RefreshUnusedAssetsBatch(BuildInfo buildInfo, FileFilterGroup filtersToUse)
		{
			if (buildInfo.UnusedAssetsIncludedInCreation)
			{
				BRT_BuildReportWindow.GetValueMessage = "Getting list of unused assets...";

				List<BuildReportTool.SizePart> allUsed = buildInfo.UsedAssets.GetAllAsList();

				BuildReportTool.SizePart[] allUnused;
				BuildReportTool.SizePart[][] perCategoryUnused;

				BuildPlatform buildPlatform = GetBuildPlatformFromString(buildInfo.BuildType, buildInfo.BuildTargetUsed);


				allUnused = GetAllUnusedAssets(buildInfo.ScriptDLLs, buildInfo.ProjectAssetsPath,
					buildInfo.IncludedSvnInUnused, buildInfo.IncludedGitInUnused, buildPlatform,
					buildInfo.UnusedPrefabsIncludedInCreation, buildInfo.UnusedAssetsBatchNum,
					buildInfo.UnusedAssetsEntriesPerBatch, allUsed);

				if (allUnused != null && allUnused.Length > 0)
				{
					perCategoryUnused = SegregateAssetSizesPerCategory(allUnused, filtersToUse);

					AssetList.SortType previousUnusedSortType = buildInfo.UnusedAssets.LastSortType;
					AssetList.SortOrder previousUnusedSortOrder = buildInfo.UnusedAssets.LastSortOrder;

					buildInfo.UnusedAssets = new AssetList();
					buildInfo.UnusedAssets.Init(allUnused, perCategoryUnused,
						BuildReportTool.Options.NumberOfTopLargestUnusedAssetsToShow, filtersToUse,
						previousUnusedSortType, previousUnusedSortOrder);
					buildInfo.UnusedAssets.PopulateImportedSizes();

					if (allUsed.Count != buildInfo.UsedAssets.AllCount)
					{
						// it means GetAllUnusedAssets() found new used assets
						// (something from the StreamingAssets or Resources folder, a dll, etc.)
						// re-assign it to the all used list in the build report, and re-sort
						BuildReportTool.SizePart[] newAllUsedArray = allUsed.ToArray();

						BuildReportTool.SizePart[][] newPerCategoryUsed =
							SegregateAssetSizesPerCategory(newAllUsedArray, filtersToUse);


						AssetList.SortType previousUsedSortType = buildInfo.UsedAssets.LastSortType;
						AssetList.SortOrder previousUsedSortOrder = buildInfo.UsedAssets.LastSortOrder;

						buildInfo.UsedAssets = new AssetList();
						buildInfo.UsedAssets.Init(newAllUsedArray, newPerCategoryUsed,
							BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow, filtersToUse,
							previousUsedSortType, previousUsedSortOrder);
						buildInfo.UsedAssets.PopulateImportedSizes();
					}
				}
				else
				{
					// no assets found. this only happens when we tried to move to next batch but it turns out to be the last
					// so we move back
					buildInfo.MoveUnusedAssetsBatchNumToPrev();
				}


				BRT_BuildReportWindow.GetValueMessage = "";

				buildInfo.FlagOkToRefresh();
			}
		}

		static BuildReportTool.SizePart[] GetAllUnusedAssets(
			BuildReportTool.SizePart[] scriptDLLs,
			string projectAssetsPath,
			bool includeSvn, bool includeGit,
			BuildPlatform buildPlatform,
			bool includeUnusedPrefabs,
			int fileCountBatchSkip, int fileCountLimit,
			//Dictionary<string, bool> usedAssetsDict,
			List<BuildReportTool.SizePart> inOutAllUsedAssets)
		{
			List<BuildReportTool.SizePart> unusedAssets = new List<BuildReportTool.SizePart>();


			// now loop through all assets in the whole project,
			// check if that file exists in the usedAssetsDict,
			// if not, include it in the unusedAssets list,
			// then sort by size

			int projectStringLen = projectAssetsPath.Length - "Assets".Length;

			bool has32BitPluginsFolder = Directory.Exists(projectAssetsPath + "/Plugins/x86");
			bool has64BitPluginsFolder = Directory.Exists(projectAssetsPath + "/Plugins/x86_64");

			string currentAsset;

			int assetIdx = 0;

			int fileCountOffset = fileCountBatchSkip * fileCountLimit;

			foreach (string fullAssetPath in DldUtil.TraverseDirectory.Do(projectAssetsPath))
			{
				++assetIdx;

				if (assetIdx < fileCountOffset)
				{
					continue;
				}

				BRT_BuildReportWindow.GetValueMessage =
					string.Format("Getting list of used assets {0} ...", assetIdx.ToString());

				//Debug.Log(fullAssetPath);

				//string fullAssetPath = allAssets[assetIdx];

				// get the path but starting from the "Assets/" folder
				currentAsset = fullAssetPath;
				currentAsset = currentAsset.Substring(projectStringLen, currentAsset.Length - projectStringLen);

				// --------------------------
				// Unity .meta files are not considered part of the assets
				// Unity .mask (Avatar masks): whether a .mask file is used or not currently cannot be reliably found out, so they are skipped
				if (Util.IsFileOfType(currentAsset, ".meta") ||
				    Util.IsFileOfType(currentAsset, ".mask"))
				{
					continue;
				}

				// --------------------------
				// anything in a /Resources/ folder will always be in the build, as long as it's not in an Editor folder
				if (Util.IsFileInAPath(currentAsset, "/Resources/") && !Util.IsFileInAnEditorFolder(currentAsset))
				{
					// ensure this Resources asset is in the used assets list
					if (!inOutAllUsedAssets.Exists(part =>
						    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
					{
						inOutAllUsedAssets.Add(BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
					}

					continue;
				}

				// --------------------------
				// Include version control files only if requested to do so
				if (!includeSvn && Util.IsFileInAPath(currentAsset, "/.svn/"))
				{
					continue;
				}

				if (!includeGit && Util.IsFileInAPath(currentAsset, "/.git/"))
				{
					continue;
				}

				// --------------------------
				// NOTE: if a .dll is present in the Script DLLs list, that means
				// it is a managed DLL, and thus, is always used in the build

				if (Util.IsFileOfType(currentAsset, ".dll"))
				{
					string assetFilenameOnly = System.IO.Path.GetFileName(currentAsset);
					//Debug.Log(assetFilenameOnly);

					bool foundMatch = false;

					// is current asset found in the script/managed DLLs list?
					for (int mdllIdx = 0; mdllIdx < scriptDLLs.Length; ++mdllIdx)
					{
						if (scriptDLLs[mdllIdx].Name == assetFilenameOnly)
						{
							// it's a managed DLL. Managed DLLs are always included in the build.
							foundMatch = true;
							var sizePartForThisScriptDLL =
								BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath);

							if (!inOutAllUsedAssets.Exists(part =>
								    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
							{
								inOutAllUsedAssets.Add(sizePartForThisScriptDLL);
							}

							// update the file size in the build report with the values that we found
							scriptDLLs[mdllIdx].Percentage = sizePartForThisScriptDLL.Percentage;
							scriptDLLs[mdllIdx].RawSize = sizePartForThisScriptDLL.RawSize;
							scriptDLLs[mdllIdx].RawSizeBytes = sizePartForThisScriptDLL.RawSizeBytes;
							scriptDLLs[mdllIdx].DerivedSize = sizePartForThisScriptDLL.DerivedSize;
							scriptDLLs[mdllIdx].ImportedSize = sizePartForThisScriptDLL.ImportedSize;
							scriptDLLs[mdllIdx].ImportedSizeBytes = sizePartForThisScriptDLL.ImportedSizeBytes;

							break;
						}
					}

					if (foundMatch)
					{
						// this DLL file has been taken into account since it was detected to be a managed DLL
						// so move on to the next file
						continue;
					}
				}


				// per platform special cases
				// involving native plugins

				// in windows and linux, the issue gets dicey as we have to check if its a 32 bit, 64 bit, or universal build

				// so for windows/linux 32 bit, if Assets/Plugins/x86 exists, it will include all dll/so in those. if that folder does not exist, all dll/so in Assets/Plugins are included instead.
				//
				// what if there's a 64 bit dll/so in Assets/Plugins? surely it would not get included in a 32 bit build?

				// for windows/linux 64 bit, if Assets/Plugins/x86_64 exists, it will include all dll/so in those. if that folder does not exist, all dll/so in Assets/Plugins are included instead.

				// right now there is no such thing as a windows universal build

				// For linux universal build, any .so in Assets/Plugins/x86 and Assets/Plugins/x86_64 are included. No .so in Assets/Plugins will be included (as it wouldn't be able to determine if such an .so in that folder is 32 or 64 bit) i.e. it relies on the .so being in the x86 or x86_64 subfolder to determine which is the 32 bit and which is the 64 bit version


				// NOTE: in Unity 3.x there is no Linux build target, but there is Windows 32/64 bit

/*
			from http://docs.unity3d.com/Documentation/Manual/PluginsForDesktop.html

			On Windows and Linux, plugins can be managed manually (e.g, before building a 64-bit player, you copy the 64-bit library into the Assets/Plugins folder, and before building a 32-bit player, you copy the 32-bit library into the Assets/Plugins folder)

				OR you can place the 32-bit version of the plugin in Assets/Plugins/x86 and the 64-bit version of the plugin in Assets/Plugins/x86_64.

			By default the editor will look in the architecture-specific sub-directory first, and if that directory does not exist, it will use plugins from the root Assets/Plugins folder instead.

			Note that for the Universal Linux build, you are required to use the architecture-specific sub-directories (when building a Universal Linux build, the Editor will not copy any plugins from the root Assets/Plugins folder).

			For Mac OS X, you should build your plugin as a universal binary that contains both 32-bit and 64-bit architectures.
*/

				switch (buildPlatform)
				{
					case BuildPlatform.Android:
						// .jar files inside /Assets/Plugins/Android/ are always included in the build if built for Android
						if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/Android/") &&
						    (Util.IsFileOfType(currentAsset, ".jar") ||
						     Util.IsFileOfType(currentAsset, ".so")))
						{
							//Debug.Log(".jar file in android " + currentAsset);
							if (!inOutAllUsedAssets.Exists(part =>
								    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
							{
								inOutAllUsedAssets.Add(
									BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
							}

							continue;
						}

						break;

					case BuildPlatform.iOS:
						if (Util.IsFileOfType(currentAsset, ".a") ||
						    Util.IsFileOfType(currentAsset, ".m") ||
						    Util.IsFileOfType(currentAsset, ".mm") ||
						    Util.IsFileOfType(currentAsset, ".c") ||
						    Util.IsFileOfType(currentAsset, ".cpp"))
						{
							// any .a, .m, .mm, .c, or .cpp files inside Assets/Plugins/iOS are automatically symlinked/used
							if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/iOS/"))
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}
							}

							// if there are any .a, .m, .mm, .c, or .cpp files outside of Assets/Plugins/iOS
							// we can't determine if they are really used or not because the user may manually copy them to the Xcode project, or a post-process .sh script may copy them to the Xcode project.
							// so we don't put them in the unused assets list
							continue;
						}

						break;


					case BuildPlatform.MacOSX32:
						// when in mac build, .bundle files that are in Assets/Plugins are always included
						// supposedly, Unity expects all .bundle files as universal builds (even if this is only a 32-bit build?)
						if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/") &&
						    Util.IsFileOfType(currentAsset, ".bundle"))
						{
							if (!inOutAllUsedAssets.Exists(part =>
								    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
							{
								inOutAllUsedAssets.Add(
									BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
							}

							continue;
						}

						break;
					case BuildPlatform.MacOSX64:
						// when in mac build, .bundle files that are in Assets/Plugins are always included
						// supposedly, Unity expects all .bundle files as universal builds (even if this is only a 64-bit build?)
						if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/") &&
						    Util.IsFileOfType(currentAsset, ".bundle"))
						{
							if (!inOutAllUsedAssets.Exists(part =>
								    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
							{
								inOutAllUsedAssets.Add(
									BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
							}

							continue;
						}

						break;
					case BuildPlatform.MacOSXUniversal:
						// when in mac build, .bundle files that are in Assets/Plugins are always included
						// supposedly, Unity expects all .bundle files as universal builds
						if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/") &&
						    Util.IsFileOfType(currentAsset, ".bundle"))
						{
							if (!inOutAllUsedAssets.Exists(part =>
								    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
							{
								inOutAllUsedAssets.Add(
									BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
							}

							continue;
						}

						break;


					case BuildPlatform.Windows32:
						if (Util.IsFileOfType(currentAsset, ".dll"))
						{
							if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/x86/") &&
							    !Util.IsFileInAnEditorFolder(currentAsset))
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
							// Unity only makes use of Assets/Plugins/ if Assets/Plugins/x86/ does not exist
							else if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/") &&
							         !Util.IsFileInAnEditorFolder(currentAsset) && !has32BitPluginsFolder)
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
						}

						break;

					case BuildPlatform.Windows64:
						if (Util.IsFileOfType(currentAsset, ".dll"))
						{
							if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/x86_64/") &&
							    !Util.IsFileInAnEditorFolder(currentAsset))
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
							// Unity only makes use of Assets/Plugins/ if Assets/Plugins/x86_64/ does not exist
							else if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/") &&
							         !Util.IsFileInAnEditorFolder(currentAsset) && !has64BitPluginsFolder)
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
						}

						break;


					case BuildPlatform.Linux32:
						if (Util.IsFileOfType(currentAsset, ".so"))
						{
							if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/x86/"))
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
							// Unity only makes use of Assets/Plugins/ if Assets/Plugins/x86/ does not exist
							else if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/") && !has32BitPluginsFolder)
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
						}

						break;

					case BuildPlatform.Linux64:
						if (Util.IsFileOfType(currentAsset, ".so"))
						{
							if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/x86_64/"))
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
							// Unity only makes use of Assets/Plugins/ if Assets/Plugins/x86_64/ does not exist
							else if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/") && !has64BitPluginsFolder)
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
						}

						break;

					case BuildPlatform.LinuxUniversal:
						if (Util.IsFileOfType(currentAsset, ".so"))
						{
							if (Util.DoesFileStartIn(currentAsset, "Assets/Plugins/x86/") ||
							    Util.DoesFileStartIn(currentAsset, "Assets/Plugins/x86_64/"))
							{
								if (!inOutAllUsedAssets.Exists(part =>
									    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
								{
									inOutAllUsedAssets.Add(
										BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
								}

								continue;
							}
						}

						break;
				}

				// check prefabs only when requested to do so
				if (Util.IsFileOfType(currentAsset, ".prefab"))
				{
					//Debug.Log("GetAllUnusedAssets: found prefab: " + System.IO.Path.GetFileName(currentAsset));
					if (!includeUnusedPrefabs)
					{
						continue;
					}
				}

				// assets in StreamingAssets folder are always included
				if (Util.DoesFileStartIn(currentAsset, "Assets/StreamingAssets/"))
				{
					if (!inOutAllUsedAssets.Exists(part =>
						    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
					{
						inOutAllUsedAssets.Add(BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
					}

					continue;
				}

				// add asset to unused list, but only if it's not in the used list
				//if (!usedAssetsDict.ContainsKey(currentAsset))
				if (!inOutAllUsedAssets.Exists(part =>
					    string.Equals(part.Name, currentAsset, StringComparison.InvariantCultureIgnoreCase)))
				{
					// when all other checks pass through, then that simply means this asset is unused
					unusedAssets.Add(BuildReportTool.Util.CreateSizePartFromFile(currentAsset, fullAssetPath));
				}

				if (unusedAssets.Count >= fileCountLimit)
				{
					break;
				}
			}

			return unusedAssets.ToArray();
		}


		static void ParseDLLs(string editorLogPath, bool wasWebBuild, bool wasWebGLBuild, string buildFilePath,
			string projectAssetsPath, string editorAppContentsPath, ApiCompatibilityLevel monoLevel,
			StrippingLevel codeStrippingLevel, out BuildReportTool.SizePart[] systemDLLs,
			out BuildReportTool.SizePart[] unityEngineDLLs, out BuildReportTool.SizePart[] scriptDLLs)
		{
			List<BuildReportTool.SizePart> systemDLLsList = new List<BuildReportTool.SizePart>();
			List<BuildReportTool.SizePart> unityEngineDLLsList = new List<BuildReportTool.SizePart>();
			List<BuildReportTool.SizePart> scriptDLLsList = new List<BuildReportTool.SizePart>();

			string buildManagedDLLsFolder = BuildReportTool.Util.GetBuildManagedFolder(buildFilePath);
			string buildScriptDLLsFolder = buildManagedDLLsFolder;
			string buildManagedDLLsFolderHigherPriority;

			bool wasAndroidApkBuild = buildFilePath.EndsWith(".apk", StringComparison.OrdinalIgnoreCase);

			if (wasWebBuild || wasWebGLBuild)
			{
				string tryPath;
				bool success = BuildReportTool.Util.AttemptGetWebTempStagingArea(projectAssetsPath, out tryPath);
				if (success)
				{
					buildManagedDLLsFolder = tryPath;
					buildScriptDLLsFolder = tryPath;
				}
			}
			else if (wasAndroidApkBuild)
			{
				string tryPath;
				bool success = BuildReportTool.Util.AttemptGetAndroidTempStagingArea(projectAssetsPath, out tryPath);
				if (success)
				{
					buildManagedDLLsFolder = tryPath;
					buildScriptDLLsFolder = tryPath;
				}
			}

			BuildReportTool.SizePart inPart;

			if (!string.IsNullOrEmpty(buildManagedDLLsFolder) && Directory.Exists(buildManagedDLLsFolder))
			{
				foreach (string filepath in DldUtil.TraverseDirectory.Do(buildManagedDLLsFolder))
				{
					var filename = Path.GetFileName(filepath);

					if (BuildReportTool.Util.IsFileOfType(filename, ".dll"))
					{
						inPart = BuildReportTool.Util.CreateSizePartFromFile(filename, filepath);

						if (BuildReportTool.Util.IsAUnityEngineDLL(filename))
						{
							unityEngineDLLsList.Add(inPart);
						}
						else if (BuildReportTool.Util.IsAScriptDLL(filename))
						{
							scriptDLLsList.Add(inPart);
						}
						else if (BuildReportTool.Util.IsAKnownSystemDLL(filename))
						{
							systemDLLsList.Add(inPart);
						}
						else
						{
							scriptDLLsList.Add(inPart);
						}
					}
				}
			}
			else
			{
				// folder inside the Unity installation where mono system dlls are
				string unityFolderManagedDLLs;

				bool unityfoldersSuccess = BuildReportTool.Util.AttemptGetUnityFolderMonoDLLs(wasWebBuild,
					wasAndroidApkBuild, editorAppContentsPath, monoLevel,
					codeStrippingLevel, out unityFolderManagedDLLs,
					out buildManagedDLLsFolderHigherPriority);


				//Debug.Log("buildManagedDLLsFolder: " + buildManagedDLLsFolder);
				//Debug.Log("Application.dataPath: " + Application.dataPath);

				if (unityfoldersSuccess &&
				    (string.IsNullOrEmpty(buildManagedDLLsFolder) || !Directory.Exists(buildManagedDLLsFolder)))
				{
#if BRT_SHOW_MINOR_WARNINGS
				Debug.LogWarning("Could not find build folder. Using Unity install folder instead for getting mono DLL file sizes.");
#endif
					buildManagedDLLsFolder = unityFolderManagedDLLs;
				}

#if BRT_SHOW_MINOR_WARNINGS
			if (!Directory.Exists(buildManagedDLLsFolder))
			{
				Debug.LogWarning("Could not find folder for getting DLL file sizes. Got: \"" + buildManagedDLLsFolder + "\"");
			}
#endif


				const string PREFIX_REMOVE = "Dependency assembly - ";


				const string MONO_DLL_KEY = "Mono dependencies included in the build";


				foreach (string line in DldUtil.BigFileReader.ReadFile(editorLogPath, MONO_DLL_KEY))
				{
					// blank line signifies end of dll list
					if (string.IsNullOrEmpty(line) || line == "\n" || line == "\r\n")
					{
						break;
					}

					if (line.IndexOf(MONO_DLL_KEY, StringComparison.Ordinal) != -1)
					{
						continue;
					}

					string filename = line;

					filename = BuildReportTool.Util.RemovePrefix(PREFIX_REMOVE, filename);


					string filepath;
					if (BuildReportTool.Util.IsAScriptDLL(filename))
					{
						filepath = buildScriptDLLsFolder + filename;
						//Debug.LogWarning("Script \"" + filepath + "\".");
					}
					else
					{
						filepath = buildManagedDLLsFolder + filename;

						if (!File.Exists(filepath) && unityfoldersSuccess &&
						    (buildManagedDLLsFolder != unityFolderManagedDLLs))
						{
#if BRT_SHOW_MINOR_WARNINGS
						Debug.LogWarning("Failed to find file \"" + filepath + "\". Attempting to get from Unity folders.");
#endif
							filepath = unityFolderManagedDLLs + filename;

							if (!string.IsNullOrEmpty(buildManagedDLLsFolderHigherPriority) &&
							    File.Exists(buildManagedDLLsFolderHigherPriority + filename))
							{
								filepath = buildManagedDLLsFolderHigherPriority + filename;
							}
						}
					}

					if ((buildManagedDLLsFolder == unityFolderManagedDLLs) &&
					    !string.IsNullOrEmpty(buildManagedDLLsFolderHigherPriority) &&
					    File.Exists(buildManagedDLLsFolderHigherPriority + filename))
					{
						filepath = buildManagedDLLsFolderHigherPriority + filename;
					}

					//Debug.Log(filename + " " + filepath);

					inPart = BuildReportTool.Util.CreateSizePartFromFile(filename, filepath);

					//gotTotalSizeBytes += inPart.SizeBytes;

					if (BuildReportTool.Util.IsAUnityEngineDLL(filename))
					{
						unityEngineDLLsList.Add(inPart);
					}
					else if (BuildReportTool.Util.IsAScriptDLL(filename) || !File.Exists(unityFolderManagedDLLs + filename))
					{
						scriptDLLsList.Add(inPart);
					}
					else
					{
						systemDLLsList.Add(inPart);
					}
				}

				// somehow, the editor logfile
				// doesn't include UnityEngine.dll
				// even though it gets included in the final build (for desktop builds)
				//
				// for web builds though, it makes sense not to put UnityEngine.dll in the build. and it isn't.
				// Instead, it's likely residing in the browser plugin to save bandwidth.
				//
				// begs the question though, why not have the whole Mono Web Subset DLLs be
				// installed alongside the Unity web browser plugin?
				// no need to bundle Mono DLLs in the web build itself.
				// would have shaved 1 whole MB when a game uses System.Xml.dll for example
				//
				//if (!wasWebBuild)
				{
					string filename = "UnityEngine.dll";
					string filepath = buildManagedDLLsFolder + filename;

					if (File.Exists(filepath))
					{
						inPart = BuildReportTool.Util.CreateSizePartFromFile(filename, filepath);
						//gotTotalSizeBytes += inPart.SizeBytes;
						unityEngineDLLsList.Add(inPart);
					}
				}


				//Debug.Log("total size: " + EditorUtility.FormatBytes(gotTotalSizeBytes) + " (" + gotTotalSizeBytes + " bytes)");
				//Debug.Log("total assembly size: " + EditorUtility.FormatBytes(gotScriptTotalSizeBytes) + " (" + gotScriptTotalSizeBytes + " bytes)");
				//Debug.Log("total size without assembly: " + EditorUtility.FormatBytes(gotTotalSizeBytes - gotScriptTotalSizeBytes) + " (" + (gotTotalSizeBytes-gotScriptTotalSizeBytes) + " bytes)");
			}

			systemDLLs = systemDLLsList.ToArray();
			unityEngineDLLs = unityEngineDLLsList.ToArray();
			scriptDLLs = scriptDLLsList.ToArray();
		}


		const string NO_BUILD_INFO_WARNING =
			"Build Report Tool: No build info found. Build the project first. If you have more than one instance of the Unity Editor open, close all of them and open only one.";

		const string NO_BUILD_INFO_NO_LOG_WARNING =
			"Build Report Tool: No build info found. Unity was launched with the -nolog argument. Build Report Tool can't obtain build info if there are no logs. Please relaunch Unity without the -nolog argument.";

		const string NO_BUILD_INFO_OVERRIDDEN_LOG_WARNING =
			"Build Report Tool: No build info found.\n\nWarning: Build Report Tool is configured to use a custom log file to obtain build data from ({0}). Perhaps this was not intended?\n\nClear the override log in Build Report Tool's Options, or set the EditorLogOverridePath tag to empty in {1}.\n\n";

		public static bool DoesEditorLogHaveBuildInfo(string editorLogPath)
		{
			return DldUtil.BigFileReader.FileHasText(editorLogPath, ASSET_SIZES_KEY, ASSET_SIZES_KEY_2);
		}

		public static BuildSettingCategory GetBuildSettingCategoryFromBuildValues(BuildInfo buildReport)
		{
			if (!BuildReportTool.Util.BuildInfoHasContents(buildReport))
			{
				return BuildSettingCategory.None;
			}

			return GetBuildSettingCategoryFromBuildValues(buildReport.BuildType, buildReport.BuildTargetUsed);
		}

		public static BuildSettingCategory GetBuildSettingCategoryFromBuildValues(string gotBuildType,
			BuildTarget buildTarget)
		{
			BuildPlatform b = GetBuildPlatformFromString(gotBuildType, buildTarget);

			switch (b)
			{
				case BuildPlatform.Windows32:
					return BuildSettingCategory.WindowsDesktopStandalone;
				case BuildPlatform.Windows64:
					return BuildSettingCategory.WindowsDesktopStandalone;


				case BuildPlatform.MacOSX64:
					return BuildSettingCategory.MacStandalone;
				case BuildPlatform.MacOSXUniversal:
					return BuildSettingCategory.MacStandalone;


				case BuildPlatform.Linux32:
					return BuildSettingCategory.LinuxStandalone;
				case BuildPlatform.Linux64:
					return BuildSettingCategory.LinuxStandalone;
				case BuildPlatform.LinuxUniversal:
					return BuildSettingCategory.LinuxStandalone;


				case BuildPlatform.Web:
					return BuildSettingCategory.WebPlayer;
				case BuildPlatform.Flash:
					return BuildSettingCategory.FlashPlayer;
				case BuildPlatform.WebGL:
					return BuildSettingCategory.WebGL;


				case BuildPlatform.iOS:
					return BuildSettingCategory.iOS;
				case BuildPlatform.Android:
					return BuildSettingCategory.Android;
				case BuildPlatform.Blackberry:
					return BuildSettingCategory.Blackberry;


				case BuildPlatform.XBOX360:
					return BuildSettingCategory.Xbox360;
				case BuildPlatform.PS3:
					return BuildSettingCategory.PS3;
			}

			return BuildSettingCategory.None;
		}

		public static BuildPlatform GetBuildPlatformFromString(string gotBuildType, BuildTarget buildTarget)
		{
			BuildPlatform buildPlatform = BuildPlatform.None;


			if (string.IsNullOrEmpty(gotBuildType))
			{
				// log has no build type
				// have to resort to looking at current build settings
				// which may be inaccurate (if generating report from custom log file)
				buildPlatform = BuildReportTool.Util.GetBuildPlatformBasedOnUnityBuildTarget(buildTarget);
			}

			// mobile

			else if (gotBuildType.IndexOf("Android", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.Android;
			}
			else if (gotBuildType.IndexOf("iPhone", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.iOS;
			}
			else if (gotBuildType.IndexOf("iOS", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.iOS;
			}

			// browser

			else if (gotBuildType.IndexOf("WebPlayer", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.Web;
			}
			else if (gotBuildType.IndexOf("Flash", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.Flash;
			}
			else if (gotBuildType.IndexOf("WebGL", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.WebGL;
			}

			// Windows

			else if (gotBuildType.IndexOf("Windows64", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.Windows64;
			}
			else if (gotBuildType.IndexOf("Windows", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.Windows32;
			}

			// Linux

			else if (gotBuildType.IndexOf("Linux64", StringComparison.Ordinal) != -1)
			{
				buildPlatform = BuildPlatform.Linux64;
			}
			else if (gotBuildType.IndexOf("Linux", StringComparison.Ordinal) != -1)
			{
				// unfortunately we don't know if this is a 32-bit or universal build
				// we'll have to rely on current build settings which may be inaccurate
				buildPlatform = BuildReportTool.Util.GetBuildPlatformBasedOnUnityBuildTarget(buildTarget);
			}

			// Mac OS X

			else if (gotBuildType.IndexOf("Mac", StringComparison.Ordinal) != -1)
			{
				// unfortunately we don't know if this is a 32-bit, 64-bit, or universal build
				// we'll have to rely on current build settings which may be inaccurate
				buildPlatform = BuildReportTool.Util.GetBuildPlatformBasedOnUnityBuildTarget(buildTarget);
			}

			// ???

			else
			{
				//Debug.LogFormat("Could not determine build type from: {0}", gotBuildType);
				// could not determine from log
				// have to resort to looking at current build settings
				// which may be inaccurate
				buildPlatform = BuildReportTool.Util.GetBuildPlatformBasedOnUnityBuildTarget(buildTarget);
			}

			return buildPlatform;
		}


		/// <summary>
		/// Note: This doesn't work anymore in Unity 5.3.2
		/// </summary>
		/// <returns></returns>
		public static string GetCompressedSizeReadingFromLog()
		{
			const string COMPRESSED_BUILD_SIZE_STA_KEY = "Total compressed size ";
			const string COMPRESSED_BUILD_SIZE_END_KEY = ". Total uncompressed size ";

			string result = string.Empty;

			string line = DldUtil.BigFileReader.SeekText(_lastEditorLogPath, COMPRESSED_BUILD_SIZE_STA_KEY);

			if (!string.IsNullOrEmpty(line))
			{
				int compressedBuildSizeIdx = line.LastIndexOf(COMPRESSED_BUILD_SIZE_STA_KEY, StringComparison.Ordinal);
				if (compressedBuildSizeIdx != -1)
				{
					// this data in the editor log only shows in web builds so far
					// meaning we do not get a compressed result in other builds (except android, where we can check the file size of the .apk itself)
					//
					int compressedBuildSizeEndIdx = line.IndexOf(COMPRESSED_BUILD_SIZE_END_KEY, compressedBuildSizeIdx,
						StringComparison.Ordinal);

					result = line.Substring(compressedBuildSizeIdx + COMPRESSED_BUILD_SIZE_STA_KEY.Length,
						compressedBuildSizeEndIdx - compressedBuildSizeIdx - COMPRESSED_BUILD_SIZE_STA_KEY.Length);
				}
			}

			//Debug.Log("compressed size from log: " + result);

			return result;
		}


		/// <summary>
		/// Used for Windows and Linux builds to get build size.
		/// </summary>
		/// <param name="buildFilePath">Path to build as given by <see cref="EditorUserBuildSettings.GetBuildLocation"/></param>
		/// <param name="unityVersion"></param>
		/// <returns>Size of build in bytes</returns>
		static double GetStandaloneBuildSize(string buildFilePath, string unityVersion)
		{
			if (string.IsNullOrEmpty(buildFilePath))
			{
				return 0;
			}

			if (Directory.Exists(buildFilePath))
			{
				//Debug.LogFormat("{0} is a folder", buildFilePath);

				// build location is a folder. normally it would be a file instead (the executable file for the build)
				// in the latest versions of Unity, it's a folder

				// for windows, attempt to find the .exe file within this folder and use that
				// what if there are multiple unity builds in this folder???
				string[] potentialBuildExeFiles =
					Directory.GetFiles(buildFilePath, "*.exe", SearchOption.TopDirectoryOnly);

				if (potentialBuildExeFiles.Length > 0)
				{
					for (int n = 0, len = potentialBuildExeFiles.Length; n < len; ++n)
					{
						if (IsUnityExecutableFile(potentialBuildExeFiles[n]))
						{
							//Debug.LogFormat("found unity .exe file: {0}", potentialBuildExeFiles[n]);
							return GetStandaloneBuildWithDataFolderSize(potentialBuildExeFiles[n], unityVersion);
						}
					}
				}

				// --------------------------

				string[] potentialBuildLinux32BitFiles =
					Directory.GetFiles(buildFilePath, "*.x86", SearchOption.TopDirectoryOnly);

				if (potentialBuildLinux32BitFiles.Length > 0)
				{
					for (int n = 0, len = potentialBuildLinux32BitFiles.Length; n < len; ++n)
					{
						if (IsUnityExecutableFile(potentialBuildLinux32BitFiles[n]))
						{
							//Debug.Log("found unity .x86 file: " + potentialBuildLinux32BitFiles[n]);
							return GetStandaloneBuildWithDataFolderSize(potentialBuildLinux32BitFiles[n], unityVersion);
						}
					}
				}

				// --------------------------

				string[] potentialBuildLinux64BitFiles =
					Directory.GetFiles(buildFilePath, "*.x86_64", SearchOption.TopDirectoryOnly);

				if (potentialBuildLinux64BitFiles.Length > 0)
				{
					for (int n = 0, len = potentialBuildLinux64BitFiles.Length; n < len; ++n)
					{
						if (IsUnityExecutableFile(potentialBuildLinux64BitFiles[n]))
						{
							//Debug.Log("found unity .x86_64 file: " + potentialBuildLinux64BitFiles[n]);
							return GetStandaloneBuildWithDataFolderSize(potentialBuildLinux64BitFiles[n], unityVersion);
						}
					}
				}

				// just return size of whole folder.
				//Debug.LogFormat("Getting size of whole folder: {0}", buildFilePath);
				return BuildReportTool.Util.GetPathSizeInBytes(buildFilePath);
			}

			//Debug.LogFormat("{0} is a file", buildFilePath);

			// build location is a file
			return GetStandaloneBuildWithDataFolderSize(buildFilePath, unityVersion);
		}

		/// <summary>
		/// Used for Windows and Linux builds to get build size.
		/// </summary>
		/// <param name="buildFilePath">Path to build as given by <see cref="EditorUserBuildSettings.GetBuildLocation"/></param>
		/// <param name="unityVersion"></param>
		/// <returns>Size of build in bytes</returns>
		static double GetStandaloneBuildWithDataFolderSize(string buildFilePath, string unityVersion)
		{
			if (string.IsNullOrEmpty(buildFilePath))
			{
				return 0;
			}

			var folderOfBuildFile = Directory.Exists(buildFilePath) ? buildFilePath : Path.GetDirectoryName(buildFilePath);

			if (IsSingleStandaloneBuildInPath(folderOfBuildFile))
			{
				// then just get the total size of the parent folder

				//Debug.LogFormat("GetStandaloneBuildWithDataFolderSize: Getting size of whole folder {0}", folderOfBuildFile);

				double parentFolderByteSize = BuildReportTool.Util.GetPathSizeInBytes(folderOfBuildFile);

				return parentFolderByteSize;
			}
			// else: there's multiple unity builds in the path,
			// so we should only get the size of the build we're interested in

			if (IsUnityExecutableFile(buildFilePath))
			{
				//Debug.LogFormat("GetStandaloneBuildWithDataFolderSize: Getting size of executable and its _Data folder {0}", buildFilePath);

				double exeFileByteSize = BuildReportTool.Util.GetPathSizeInBytes(buildFilePath);

				// get the exe file but remove the file type and add _Data. that's the folder name
				string dataFolderPath = BuildReportTool.Util.ReplaceFileType(buildFilePath, "_Data");
				//Debug.Log("dataFolderPath: " + dataFolderPath);

				double dataFolderByteSize = BuildReportTool.Util.GetPathSizeInBytes(dataFolderPath);

				if (buildFilePath.EndsWith(".x86", StringComparison.OrdinalIgnoreCase))
				{
					// check if accompanying 64-bit executable is also there (i.e. if it's a universal build)
					// and include that in file size too

					// get the .x86 file file but change the file type to ".x86_64"
					string exe64Path = BuildReportTool.Util.ReplaceFileType(buildFilePath, ".x86_64");

					if (File.Exists(exe64Path))
					{
						// gets the size of 64-bit executable
						double exe64SizeBytes = BuildReportTool.Util.GetPathSizeInBytes(exe64Path);

						return (exeFileByteSize + exe64SizeBytes + dataFolderByteSize);
					}
				}

				return (exeFileByteSize + dataFolderByteSize);
			}

			// buildFilePath doesn't have a path we can use to determine the build size
			return 0;
		}

		/// <summary>
		/// Does the path contain only one Unity standalone build?
		/// </summary>
		/// <returns></returns>
		static bool IsSingleStandaloneBuildInPath(string buildFilePath)
		{
			// check if there are multiple .exe or .x86 or .x86_64 files in the folder
			if (!Directory.Exists(buildFilePath))
			{
				// not a folder
				return false;
			}

			string parentFolderPath = Path.GetDirectoryName(buildFilePath);
			if (string.IsNullOrEmpty(parentFolderPath))
			{
				return false;
			}

			//Debug.LogFormat("IsSingleStandaloneBuildInPath: Checking {0}", parentFolderPath);

			if (Directory.Exists(parentFolderPath))
			{
				var exeFilesInFolder = Directory.GetFiles(parentFolderPath, "*.exe", SearchOption.TopDirectoryOnly);
				var manyExeFiles = exeFilesInFolder.Length >= 2;
				if (manyExeFiles)
				{
					var foundUnityBuildExeFiles = 0;
					for (int n = 0, len = exeFilesInFolder.Length; n < len; ++n)
					{
						// new in Unity 2017 and above
						// even though these are .exe files, they're not a build's executable
						if (exeFilesInFolder[n].Contains("UnityCrashHandler64.exe") ||
						    exeFilesInFolder[n].Contains("UnityCrashHandler32.exe"))
						{
							continue;
						}

						if (IsUnityExecutableFile(exeFilesInFolder[n]))
						{
							++foundUnityBuildExeFiles;
						}
					}

					//Debug.LogFormat("IsSingleStandaloneBuildInPath: .exe files found in {0}: {1}",
					//	parentFolderPath, foundUnityBuildExeFiles.ToString());

					if (foundUnityBuildExeFiles > 1)
					{
						return false;
					}

					// note: Even if there's only 1 unity build exe file in this folder,
					// one of the subfolders in here may have an .exe file and build folder too
					// But it's tricky to check for this.
					// Newer versions of Unity add new files into the build like UnityCrashHandler64.exe,
					// and WinPixEventRuntime.dll (these are beside the game's exe file),
					// so an explicit approach (get size only of particular files and folders)
					// can potentially miss out on newly added files/folders of builds from newer versions of Unity.
					//
					// So the current approach of just getting the entire folder's size is preferable.
					// It's just that the user has to be mindful to always set the build location to a
					// folder where that build is the only thing in that folder.
				}

				// -------------------

				var linuxExeFilesInFolder = Directory.GetFiles(parentFolderPath, "*.x86", SearchOption.TopDirectoryOnly);
				var manyLinuxExeFiles = linuxExeFilesInFolder.Length >= 2;
				if (manyLinuxExeFiles)
				{
					//Debug.LogFormat("IsSingleStandaloneBuildInPath: Many .x86 files found in {0}", parentFolderPath);

					var foundUnityBuildExeFiles = 0;
					for (int n = 0, len = linuxExeFilesInFolder.Length; n < len; ++n)
					{
						if (IsUnityExecutableFile(linuxExeFilesInFolder[n]))
						{
							++foundUnityBuildExeFiles;
						}
					}

					if (foundUnityBuildExeFiles > 1)
					{
						return false;
					}
				}

				// -------------------

				var linuxExe64FilesInFolder =
					Directory.GetFiles(parentFolderPath, "*.x86_64", SearchOption.TopDirectoryOnly);
				var manyLinuxExe64Files = linuxExe64FilesInFolder.Length >= 2;
				if (manyLinuxExe64Files)
				{
					//Debug.LogFormat("IsSingleStandaloneBuildInPath: Many .x86_64 files found in {0}", parentFolderPath);

					var foundUnityBuildExeFiles = 0;
					for (int n = 0, len = linuxExe64FilesInFolder.Length; n < len; ++n)
					{
						if (IsUnityExecutableFile(linuxExe64FilesInFolder[n]))
						{
							++foundUnityBuildExeFiles;
						}
					}

					if (foundUnityBuildExeFiles > 1)
					{
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Does the specified executable file also have an accompanying "_Data" folder in the same path?
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns></returns>
		static bool IsUnityExecutableFile(string filepath)
		{
			if (File.Exists(filepath))
			{
				string dataFolderPath;

				if (BuildReportTool.Util.IsFileOfType(filepath, ".exe") ||
				    BuildReportTool.Util.IsFileOfType(filepath, ".x86") ||
				    BuildReportTool.Util.IsFileOfType(filepath, ".x86_64"))
				{
					dataFolderPath = BuildReportTool.Util.ReplaceFileType(filepath, "_Data");
				}
				else
				{
					// file doesn't have .exe or .x86 or .x86_64.
					// this happens in linux build where executable has no file type extension
					// just append "_Data" to it then
					dataFolderPath = filepath + "_Data";
				}

				if (Directory.Exists(dataFolderPath))
				{
					return true;
				}
			}

			return false;
		}

		public static bool CheckIfUnityHasNoLogArgument()
		{
			if (!_gotCommandLineArguments)
			{
				string[] args = System.Environment.GetCommandLineArgs();

				_unityHasNoLogArgument = false;
				for (int i = 0; i < args.Length; i++)
				{
					//Debug.Log(args[i]);
					if (args[i] == "-nolog")
					{
						_unityHasNoLogArgument = true;
						break;
					}
				}

				_gotCommandLineArguments = true;
			}

			return _unityHasNoLogArgument;
		}

		// ==================================================================================================================================================================================================================
		// main function for generating a report

		public static void GetValues(BuildInfo buildInfo, string buildFilePath, string projectAssetsPath,
			string editorAppContentsPath, bool calculateBuildSize)
		{
			BRT_BuildReportWindow.GetValueMessage = "Getting values...";

			if (!DoesEditorLogHaveBuildInfo(_lastEditorLogPath))
			{
				if (BuildReportTool.Util.IsDefaultEditorLogPathOverridden)
				{
					Debug.LogWarning(string.Format(NO_BUILD_INFO_OVERRIDDEN_LOG_WARNING, _lastEditorLogPath,
						BuildReportTool.Options.FoundPathForSavedOptions));
				}
				else if (CheckIfUnityHasNoLogArgument())
				{
					Debug.LogWarning(NO_BUILD_INFO_NO_LOG_WARNING);
				}
				else
				{
					Debug.LogWarning(NO_BUILD_INFO_WARNING);
				}

				return;
			}


			// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// determining build platform based on editor log
			// much more reliable especially when using an override log
			// if no build platform found from editor log, it will just use `buildInfo.BuildTargetUsed`

			string gotBuildType = GetBuildTypeFromEditorLog(_lastEditorLogPath);
			BuildPlatform buildPlatform = GetBuildPlatformFromString(gotBuildType, buildInfo.BuildTargetUsed);

			//Debug.LogFormat("Build Type found in Editor Log: \"{0}\"\nDetermined build platform: {1}",
			//	gotBuildType, buildPlatform);

			if (string.IsNullOrEmpty(gotBuildType))
			{
				buildInfo.BuildType = buildPlatform.ToString();
			}
			else
			{
				buildInfo.BuildType = gotBuildType;
			}


			buildInfo.ProjectName = BuildReportTool.Util.GetProjectName(projectAssetsPath);


			// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// DLLs

			BRT_BuildReportWindow.GetValueMessage = "Getting list of DLLs...";

			bool wasWebBuild = buildInfo.BuildType == "WebPlayer";
			bool wasWebGLBuild = buildInfo.BuildType == "WebGLSupport" || buildInfo.BuildType == "WebGL";

			//Debug.Log("going to call parseDLLs");
			ParseDLLs(_lastEditorLogPath, wasWebBuild, wasWebGLBuild, buildFilePath, projectAssetsPath,
				editorAppContentsPath, buildInfo.MonoLevel, buildInfo.CodeStrippingLevel,
				out buildInfo.MonoDLLs, out buildInfo.UnityEngineDLLs, out buildInfo.ScriptDLLs);


			//Debug.Log("ParseDLLs done");


			// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// build sizes per category

			BRT_BuildReportWindow.GetValueMessage = "Getting build sizes...";

			//Debug.Log("ParseSizePartsFromString sta");

			buildInfo.BuildSizes = ParseSizePartsFromString(_lastEditorLogPath);

			//Debug.Log("ParseSizePartsFromString end");


			// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// getting total asset size (uncompressed)

			buildInfo.UsedTotalSize = "";

			foreach (BuildReportTool.SizePart b in buildInfo.BuildSizes)
			{
				if (b.IsTotal)
				{
					buildInfo.UsedTotalSize = b.Size;
					break;
				}
			}


			// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// getting streaming assets size (uncompressed)

			BRT_BuildReportWindow.GetValueMessage = "Getting Streaming Assets size...";

			var streamingAssetsPath = projectAssetsPath + "/StreamingAssets";

			if (calculateBuildSize) // BuildReportTool.Options.IncludeBuildSizeInReportCreation
			{
				buildInfo.StreamingAssetsSize = BuildReportTool.Util.GetFolderSizeReadable(streamingAssetsPath);
			}

			foreach (BuildReportTool.SizePart b in buildInfo.BuildSizes)
			{
				if (b.IsStreamingAssets)
				{
					b.DerivedSize = BuildReportTool.Util.GetFolderSizeInBytes(streamingAssetsPath);
					b.Size = BuildReportTool.Util.GetBytesReadable(b.DerivedSize);
					break;
				}
			}


			// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// getting compressed total build size

			buildInfo.TotalBuildSize = "";

			if (calculateBuildSize)
			{
				BRT_BuildReportWindow.GetValueMessage = "Getting final build size...";
				//Debug.LogFormat("trying to get size for {0} of {1} ({2})",
				//	buildPlatform, buildFilePath, buildInfo.UnityVersion);

				// note: buildFilePath is the path to the build, as given by EditorUserBuildSettings.GetBuildLocation()

				if (buildPlatform == BuildPlatform.Flash)
				{
					// in Flash builds, `buildFilePath` is the .swf file

					buildInfo.TotalBuildSize = BuildReportTool.Util.GetPathSizeReadable(buildFilePath);
				}
				else if (buildPlatform == BuildPlatform.Android)
				{
					//Debug.Log("trying to get size of: " + buildFilePath);

					// in Unity 4, Android can generate an Eclipse project if set so in the build settings
					// or an .apk with an accompanying .obb file, which we should take into account

					// check if an .obb file was generated and get its file size


					if (!buildInfo.AndroidCreateProject && !buildInfo.AndroidUseAPKExpansionFiles)
					{
						// .apk without an .obb

						buildInfo.TotalBuildSize = BuildReportTool.Util.GetPathSizeReadable(buildFilePath);
					}
					else if (!buildInfo.AndroidCreateProject && buildInfo.AndroidUseAPKExpansionFiles)
					{
						// .apk with .obb

						// get the .apk file but remove the file type
						string obbPath = BuildReportTool.Util.ReplaceFileType(buildFilePath, ".main.obb");

						double obbSize = BuildReportTool.Util.GetPathSizeInBytes(obbPath);
						double apkSize = BuildReportTool.Util.GetPathSizeInBytes(buildFilePath);

						buildInfo.TotalBuildSize = BuildReportTool.Util.GetBytesReadable(apkSize + obbSize);
						buildInfo.AndroidApkFileBuildSize = BuildReportTool.Util.GetBytesReadable(apkSize);
						buildInfo.AndroidObbFileBuildSize = BuildReportTool.Util.GetBytesReadable(obbSize);
					}
					else if (buildInfo.AndroidCreateProject)
					{
						// total build size is size of the eclipse project folder
						buildInfo.TotalBuildSize = BuildReportTool.Util.GetPathSizeReadable(buildFilePath);

						// if there is .obb, find it
						if (buildInfo.AndroidUseAPKExpansionFiles)
						{
							// the .obb is inside this folder
							buildInfo.AndroidObbFileBuildSize =
								BuildReportTool.Util.GetObbSizeInEclipseProjectReadable(buildFilePath);
						}
					}
					else
					{
						// ???
						buildInfo.TotalBuildSize = BuildReportTool.Util.GetPathSizeReadable(buildFilePath);
					}
				}
				else if (buildPlatform == BuildPlatform.Web)
				{
					// in web builds, `buildFilePath` is the folder
					buildInfo.TotalBuildSize = BuildReportTool.Util.GetPathSizeReadable(buildFilePath);

					if (Directory.Exists(buildFilePath))
					{
						// find a .unity3d file inside the build folder and get its file size
						foreach (
							var file in TraverseDirectory
							            .Do(buildFilePath).Where(file => BuildReportTool.Util.IsFileOfType(file, ".unity3d"))
						)
						{
							buildInfo.WebFileBuildSize = BuildReportTool.Util.GetPathSizeReadable(file);
							break;
						}
					}
				}
				else if (
					buildPlatform == BuildPlatform.Windows32 ||
					buildPlatform == BuildPlatform.Windows64 ||
					buildPlatform == BuildPlatform.Linux32 ||
					buildPlatform == BuildPlatform.Linux64 ||
					buildPlatform == BuildPlatform.LinuxUniversal ||
					(buildPlatform == BuildPlatform.None &&
					 (buildFilePath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ||
					  buildFilePath.EndsWith(".x86", StringComparison.OrdinalIgnoreCase) ||
					  buildFilePath.EndsWith(".x86_64", StringComparison.OrdinalIgnoreCase))))
				{
					//Debug.LogFormat(
					//	"BuildReportTool.ReportGenerator: Getting Total Build Size: Detected Windows/Linux buildFilePath: {0}",
					//	buildFilePath);

					// in Windows/Linux builds, `buildFilePath` is only the executable file (.exe, .x86, or .x86_64 file).
					// we still need to get the size of the Data folder

					buildInfo.TotalBuildSize =
						BuildReportTool.Util.GetBytesReadable(GetStandaloneBuildSize(buildFilePath, buildInfo.UnityVersion));
				}
				else if (
					buildPlatform == BuildPlatform.MacOSX32 ||
					buildPlatform == BuildPlatform.MacOSX64 ||
					buildPlatform == BuildPlatform.MacOSXUniversal)
				{
					//Debug.LogFormat(
					//	"BuildReportTool.ReportGenerator: Getting Total Build Size: Detected Mac OS X buildFilePath: {0}",
					//	buildFilePath);

					// in Mac builds, `buildFilePath` is the .app file (which is really just a folder)
					buildInfo.TotalBuildSize = BuildReportTool.Util.GetPathSizeReadable(buildFilePath);
				}
				else if (buildPlatform == BuildPlatform.iOS)
				{
					// in iOS builds, `buildFilePath` is the Xcode project folder
					buildInfo.TotalBuildSize = BuildReportTool.Util.GetPathSizeReadable(buildFilePath);
				}
				else
				{
					//Debug.LogFormat(
					//	"BuildReportTool.ReportGenerator: Getting Total Build Size: Unknown build platform: {0}",
					//	buildFilePath);

					// in console builds, `buildFilePath` is ???
					// last resort for unknown build platforms
					buildInfo.TotalBuildSize = BuildReportTool.Util.GetPathSizeReadable(buildFilePath);
				}
			}


			// for debug
			//GetCompressedSizeReadingFromLog();

			// ensure this is not used anymore on new reports
			// (it's still there for old build report XML files)
			//buildInfo.CompressedBuildSize = "";


			buildInfo.UnusedTotalSize = "";


			// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// assets list

			if (buildInfo.UsedAssetsIncludedInCreation)
			{
				BRT_BuildReportWindow.GetValueMessage = "Getting list of used assets...";

				// asset list

				buildInfo.FileFilters = BuildReportTool.FiltersUsed.GetProperFileFilterGroupToUse(_lastSavePath);


				var allUsed = ParseAssetSizesFromEditorLog(_lastEditorLogPath, PrefabsUsedInScenesList);

				var scenes = buildInfo.ScenesInBuild;
				if (scenes != null)
				{
					// add Unity scene files into the Used Assets list even though technically they do not show up there

					string projectPath = BuildReportTool.Util.GetProjectPath(buildInfo.ProjectAssetsPath);

					string buildDataFolderPath = BuildReportTool.Util.GetBuildDataFolder(buildFilePath);

					int enabledSceneIdx = 0;
					for (int n = 0, len = scenes.Length; n < len; ++n)
					{
						if (!scenes[n].Enabled)
						{
							// disabled scene means it was not included in the build
							continue;
						}

						//Debug.Log("Scene " + n + ": " + projectPath + scenes[n].path + " enabled: " + scenes[n].enabled + " level" + enabledSceneIdx);

						var sceneSizePart =
							BuildReportTool.Util.CreateSizePartFromFile(scenes[n].Path, projectPath + scenes[n].Path, false);

						if (!string.IsNullOrEmpty(buildDataFolderPath))
						{
							// in standalone builds, a unity scene file is found in the _Data folder as files with filename level0 ... leveln
							// the number index there being the scene's index in the build

							var fileInBuild = string.Format("{0}/level{1}", buildDataFolderPath, enabledSceneIdx);

							if (File.Exists(fileInBuild))
							{
								long fileSizeBytes = BuildReportTool.Util.GetFileSizeInBytes(fileInBuild);
								sceneSizePart.RawSizeBytes = fileSizeBytes;
								sceneSizePart.RawSize = BuildReportTool.Util.GetBytesReadable(fileSizeBytes);
							}
						}

						allUsed.Add(sceneSizePart);
						++enabledSceneIdx;
					}
				}

				//Debug.Log("buildInfo.UsedAssets.All: " + buildInfo.UsedAssets.All.Length);

				if (buildInfo.UnusedAssetsIncludedInCreation)
				{
					BRT_BuildReportWindow.GetValueMessage = "Getting list of unused assets...";

					BuildReportTool.SizePart[] allUnused;
					BuildReportTool.SizePart[][] perCategoryUnused;


					allUnused = GetAllUnusedAssets(buildInfo.ScriptDLLs, projectAssetsPath, buildInfo.IncludedSvnInUnused,
						buildInfo.IncludedGitInUnused, buildPlatform, buildInfo.UnusedPrefabsIncludedInCreation, 0,
						buildInfo.UnusedAssetsEntriesPerBatch, allUsed);

					perCategoryUnused = SegregateAssetSizesPerCategory(allUnused, buildInfo.FileFilters);

					buildInfo.UnusedAssets = new AssetList();
					buildInfo.UnusedAssets.Init(allUnused, perCategoryUnused,
						BuildReportTool.Options.NumberOfTopLargestUnusedAssetsToShow, buildInfo.FileFilters);

					buildInfo.UnusedTotalSize =
						BuildReportTool.Util.GetBytesReadable(buildInfo.UnusedAssets.GetTotalSizeInBytes());
				}

				BuildReportTool.SizePart[] allUsedArray = allUsed.ToArray();

				BuildReportTool.SizePart[][] perCategoryUsed =
					SegregateAssetSizesPerCategory(allUsedArray, buildInfo.FileFilters);
				buildInfo.UsedAssets = new AssetList();
				buildInfo.UsedAssets.Init(allUsedArray, perCategoryUsed,
					BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow, buildInfo.FileFilters);
			}


			buildInfo.SortSizes();

			Array.Sort(buildInfo.MonoDLLs, delegate(BuildReportTool.SizePart b1, BuildReportTool.SizePart b2)
			{
				if (b1.SizeBytes > b2.SizeBytes) return -1;
				if (b1.SizeBytes < b2.SizeBytes) return 1;
				return 0;
			});
			Array.Sort(buildInfo.UnityEngineDLLs, delegate(BuildReportTool.SizePart b1, BuildReportTool.SizePart b2)
			{
				if (b1.SizeBytes > b2.SizeBytes) return -1;
				if (b1.SizeBytes < b2.SizeBytes) return 1;
				return 0;
			});
			Array.Sort(buildInfo.ScriptDLLs, delegate(BuildReportTool.SizePart b1, BuildReportTool.SizePart b2)
			{
				if (b1.SizeBytes > b2.SizeBytes) return -1;
				if (b1.SizeBytes < b2.SizeBytes) return 1;
				return 0;
			});

			//foreach (string d in EditorUserBuildSettings.activeScriptCompilationDefines)
			//{
			//	Debug.Log("define: " + d);
			//}

			// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// duration of build generation

			System.TimeSpan timeNow = new System.TimeSpan(System.DateTime.Now.Ticks);
			buildInfo.ReportGenerationTime = timeNow - _timeReportGenerationStarted;

			BRT_BuildReportWindow.GetValueMessage = "";

			buildInfo.FlagOkToRefresh();
		}

		//public static void ChangeSavePathToUserPersonalFolder()
		//{
		//BuildReportTool.Options.BuildReportSavePath = BuildReportTool.Util.GetUserHomeFolder();
		//}

		public static string GetSavePathToProjectFolder()
		{
			string projectParent;
			if (_lastKnownBuildInfo != null)
			{
				projectParent = _lastKnownBuildInfo.ProjectAssetsPath;
			}
			else
			{
				projectParent = Application.dataPath;
			}

			const string SUFFIX_STRING_TO_REMOVE = "/Assets";
			projectParent = BuildReportTool.Util.RemoveSuffix(SUFFIX_STRING_TO_REMOVE, projectParent);

			int lastSlashIdx = projectParent.LastIndexOf("/", StringComparison.Ordinal);
			projectParent = projectParent.Substring(0, lastSlashIdx);
			return projectParent;
			//BuildReportTool.Options.BuildReportSavePath = projectParent;
			//Debug.Log("projectParent: " + projectParent);
		}


		/// <summary>
		/// Called by <see cref="BRT_BuildReportWindow.Refresh"/> to start creating a build report.
		/// </summary>
		///
		/// Called when the "Get Log" button is pressed by the user in the BRT_BuildReportWindow.
		///
		/// Can also be called due to BRT_BuildReportWindow's <see cref="BRT_BuildReportWindow.OnInspectorUpdate"/>,
		/// when it has detected that a build has completed, and a Build Report creation was scheduled
		/// (<see cref="BuildReportTool.Util.ShouldGetBuildReportNow"/>). This was scheduled for us
		/// when <see cref="OnPostprocessBuild"/> was called, which gets called automatically by Unity
		/// when a build has finished.
		///
		/// <param name="buildInfo"></param>
		/// <param name="assetDependencies"></param>
		/// <returns></returns>
		public static bool RefreshData(ref BuildReportTool.BuildInfo buildInfo,
			ref BuildReportTool.AssetDependencies assetDependencies)
		{
			// this would have been set to true in BuildReportTool.ReportGenerator.OnPostprocessBuild
			// which allowed BRT_BuildReportWindow.OnInspectorUpdate() to get here
			if (BuildReportTool.Util.ShouldGetBuildReportNow)
			{
				BuildReportTool.Util.ShouldGetBuildReportNow = false;
			}

			if (!DoesEditorLogHaveBuildInfo(BuildReportTool.Util.UsedEditorLogPath))
			{
				if (BuildReportTool.Util.IsDefaultEditorLogPathOverridden)
				{
					Debug.LogWarning(string.Format(NO_BUILD_INFO_OVERRIDDEN_LOG_WARNING,
						BuildReportTool.Util.UsedEditorLogPath, BuildReportTool.Options.FoundPathForSavedOptions));
				}
				else if (CheckIfUnityHasNoLogArgument())
				{
					Debug.LogWarning(NO_BUILD_INFO_NO_LOG_WARNING);
				}
				else
				{
					Debug.LogWarning(NO_BUILD_INFO_WARNING);
				}

				return false;
			}

			// --------------------

			var timeNow = System.DateTime.Now;
			_timeReportGenerationStarted = new System.TimeSpan(timeNow.Ticks);

			// --------------------

			// get important values from the Unity API
			// (which can only be retrieved in the main thread)
			Init(ref buildInfo, null, timeNow);

			if (BuildReportTool.Options.CalculateAssetDependencies)
			{
				if (assetDependencies == null)
				{
					assetDependencies = new BuildReportTool.AssetDependencies();
				}

				assetDependencies.TimeGot = timeNow;
			}

			// --------------------

			// getting prefabs has to be done in the main thread
			// since it uses the Unity API (AssetDatabase.GetDependencies)
			if (BuildReportTool.Options.IncludeUnusedPrefabsInReportCreation)
			{
				RefreshListOfAllPrefabsUsedInAllScenesIncludedInBuild();
			}
			else
			{
				ClearListOfAllPrefabsUsedInAllScenes();
			}

			CommitAdditionalInfoToCache();

			// --------------------

			CreateBuildReportInBackgroundIfNeeded(buildInfo, assetDependencies);

			return true;
		}

		/// <summary>
		/// Called by <see cref="RefreshData"/> to create the Build Report.
		/// </summary>
		///
		/// <para>It will be done either on the main thread or on a new one, depending
		/// on the value of <see cref="BuildReportTool.Options.UseThreadedReportGeneration"/>.</para>
		///
		/// <para>Once it's done, <see cref="_gettingValuesCurrentState"/> will be set to
		/// <see cref="GettingValues.Finished"/>, to signal the rest of the code to continue.
		/// Specifically, <see cref="BRT_BuildReportWindow.OnInspectorUpdate"/> keeps checking
		/// that state and when it does, it calls
		/// <see cref="BRT_BuildReportWindow.OnFinishGeneratingBuildReport"/> as the next step.</para>
		///
		static void CreateBuildReportInBackgroundIfNeeded(BuildReportTool.BuildInfo buildInfo,
			BuildReportTool.AssetDependencies assetDependencies)
		{
			//Debug.Log("starting thread");
			_shouldCalculateBuildSize = BuildReportTool.Options.IncludeBuildSizeInReportCreation;

			_gettingValuesCurrentState = GettingValues.Yes;

			if (BuildReportTool.Options.UseThreadedReportGeneration)
			{
				// the only things we do is get values from the Editor.log txt file
				// so it's safe to do it in a separate thread, nothing in the Unity API
				// is used.

				Thread thread = new Thread(() => CreateBuildReport(buildInfo));
				thread.Start();
			}
			else
			{
				CreateBuildReport(buildInfo);
			}
		}

		/// <summary>
		/// Finally go and create the contents of the Build Report, based on
		/// the values given in the Editor.log text file, and other info prepared
		/// beforehand.
		/// </summary>
		///
		/// Once it's done, <see cref="_gettingValuesCurrentState"/> will be set to
		/// <see cref="GettingValues.Finished"/>, to signal the rest of the code to continue.
		/// Specifically, <see cref="BRT_BuildReportWindow.OnInspectorUpdate"/> keeps checking
		/// that state and when it does, it calls
		/// <see cref="BRT_BuildReportWindow.OnFinishGeneratingBuildReport"/> as the next step.
		///
		/// <param name="buildInfo">The BuildInfo to populate.</param>
		static void CreateBuildReport(BuildReportTool.BuildInfo buildInfo)
		{
			//Debug.Log("in thread");

			GetValues(buildInfo, buildInfo.BuildFilePath, buildInfo.ProjectAssetsPath, buildInfo.EditorAppContentsPath,
				_shouldCalculateBuildSize);

			//Debug.Log("done thread");
			_gettingValuesCurrentState = GettingValues.Finished;

			// the next part of the code that gets executed is BRT_BuildReportWindow.OnFinishGeneratingBuildReport()
		}

		public static string OnFinishedGetValues(BuildInfo buildInfo, AssetDependencies assetDependencies)
		{
			string resultingFilePath = null;

			if (buildInfo.HasUsedAssets)
			{
				if (BuildReportTool.Options.ShowImportedSizeForUsedAssets)
				{
					buildInfo.UsedAssets.PopulateImportedSizes();
				}

				if (BuildReportTool.Options.GetSizeBeforeBuildForUsedAssets)
				{
					buildInfo.UsedAssets.PopulateSizeInAssetsFolder();
				}
			}

			if (buildInfo.HasUnusedAssets && BuildReportTool.Options.GetImportedSizesForUnusedAssets)
			{
				buildInfo.UnusedAssets.PopulateImportedSizes();
			}

			buildInfo.FixReport();

			// ------------------------------

			// Asset dependency calculation has to be done *after* build report has been created,
			// but it also has to be done in the main thread, since it makes use of the Unity Editor API
			// (UnityEditor.AssetDatabase.GetDependencies()).
			if (BuildReportTool.Options.CalculateAssetDependencies)
			{
				assetDependencies.ProjectName = buildInfo.ProjectName;
				assetDependencies.BuildType = buildInfo.BuildType;

				if (BuildReportTool.Options.CalculateAssetDependenciesOnUnusedToo)
				{
					BuildReportTool.AssetDependencyGenerator.CreateForAllAssets(assetDependencies, buildInfo,
#if BRT_ASSET_DEPENDENCY_DEBUG
					false //true
#else
						false
#endif
					);
				}
				else
				{
					BuildReportTool.AssetDependencyGenerator.CreateForUsedAssetsOnly(assetDependencies, buildInfo,
#if BRT_ASSET_DEPENDENCY_DEBUG
					false //true
#else
						false
#endif
					);
				}
			}

			// ------------------------------

			// BuildReportTool.Util.ShouldSaveGottenBuildReportNow was set to true on
			// BuildReportTool.ReportGenerator.OnPostprocessBuild,
			// which is called automatically after a build
			// so by this time, it should be true
			if (BuildReportTool.Util.ShouldSaveGottenBuildReportNow)
			{
				BuildReportTool.Util.ShouldSaveGottenBuildReportNow = false;

				resultingFilePath = BuildReportTool.Util.SerializeBuildInfoAtFolder(buildInfo, _lastSavePath);

				if (BuildReportTool.Options.CalculateAssetDependencies)
				{
					BuildReportTool.Util.SerializeAssetDependenciesAtFolder(assetDependencies, _lastSavePath);
				}
			}

			_gettingValuesCurrentState = GettingValues.No;

			FixZeroSizeUsedAssetEntries(buildInfo);

			return resultingFilePath;
		}

		static void FixZeroSizeUsedAssetEntries(BuildInfo buildInfo)
		{
			if (!buildInfo.UsedAssetsIncludedInCreation)
			{
				return;
			}

			AssetList usedAssetsList = buildInfo.UsedAssets;

			SizePart[] usedAssets = usedAssetsList.All;

			bool sizeWasChangedAtLeastOnce = false;

			string projectPath = BuildReportTool.Util.GetProjectPath(buildInfo.ProjectAssetsPath);

			for (int n = 0, len = usedAssets.Length; n < len; ++n)
			{
				// files in StreamingAssets folder do not get imported in the 1st place
				// so skip them
				if (Util.IsFileStreamingAsset(usedAssets[n].Name))
				{
					continue;
				}

				if (usedAssets[n].Size == "N/A")
				{
					continue;
				}

				if (usedAssets[n].DerivedSize <= 0.0 && usedAssets[n].SizeBytes <= 0)
				{
					// got size from log was 0?
					// likely the asset was so small, Unity rounded off the value to 0
					// then we forcibly get the imported size

					long realSize = BuildReportTool.Util.GetFileSizeInBytes(projectPath + usedAssets[n].Name);

					// but check first if real file size really is 0, then we need to indicate to the user that "hey, this file actually is empty"
					if (realSize <= 0)
					{
						continue;
					}

					sizeWasChangedAtLeastOnce = true;

					// here's the weird thing:
					// when the asset is text, Unity reports the file size based on the .txt file's real size on disk
					// when it's a texture image, Unity reports the file size based on the imported size
					// when it's a material, seems Unity does some extra compressing because it ends up smaller than either raw size or imported size
					//
					// seems it's really different per asset type
					//
					// so we'll make our own rules:
					// just use whichever value is smaller: raw or imported size.

					long importedSize = BRT_LibCacheUtil.GetImportedFileSize(usedAssets[n].Name);

					long sizeToUse = Math.Min(realSize, importedSize);

					usedAssets[n].SizeBytes = sizeToUse;
					usedAssets[n].Size = BuildReportTool.Util.GetBytesReadable(usedAssets[n].SizeBytes);

					//Debug.Log("asset \"" + usedAssets[n].Name + "\" size from log is " + usedAssets[n].DerivedSize + " so we calculated imported size and got: " + usedAssets[n].SizeBytes + " real size is " + BuildReportTool.Util.GetBytesReadable(realSize));
				}
			}

			if (sizeWasChangedAtLeastOnce)
			{
				// resort asset list since sizes were changed
				usedAssetsList.ResortDefault(BuildReportTool.Options.NumberOfTopLargestUsedAssetsToShow);
			}
		}


		enum GettingValues
		{
			/// <summary>
			/// Initial state, not doing anything.
			/// </summary>
			No,

			/// <summary>
			/// Currently in the middle of creating a report.
			/// </summary>
			Yes,

			/// <summary>
			/// Just finished generating a build report and is ready to be saved.
			/// </summary>
			Finished
		}

		static GettingValues _gettingValuesCurrentState = GettingValues.No;

		public static bool IsStillGettingValues
		{
			get { return _gettingValuesCurrentState == GettingValues.Yes; }
		}

		public static bool IsFinishedGettingValues
		{
			get { return _gettingValuesCurrentState == GettingValues.Finished; }
		}


		public static void RecategorizeAssetList(BuildInfo buildInfo)
		{
			buildInfo.RecategorizeAssetLists();
			buildInfo.FlagOkToRefresh();
		}

		const string EDITOR_WINDOW_TITLE = "Build Report";

		[MenuItem("Window/Show Build Report")]
		public static void ShowBuildReport()
		{
			//RefreshData(ref _lastKnownBuildInfo);

			// close any existing window first, in case it's stuck in an error
			BRT_BuildReportWindow brtWindow =
				(BRT_BuildReportWindow) EditorWindow.GetWindow(typeof(BRT_BuildReportWindow), false, EDITOR_WINDOW_TITLE,
					true);
			brtWindow.Close();

			ShowBuildReportWithLastValues();
		}

		static System.TimeSpan _timeReportGenerationStarted;

		/*static void PopulateLastBuildValues()
		{
			if (string.IsNullOrEmpty(_lastKnownBuildInfo.BuildFilePath))
			{
				Debug.LogError("Can't populate last build values, BuildFilePath not initialized");
			}
	
			_timeReportGenerationStarted = new System.TimeSpan(System.DateTime.Now.Ticks);
			GetValues(_lastKnownBuildInfo, _lastKnownBuildInfo.ScenesIncludedInProject, _lastKnownBuildInfo.BuildFilePath, _lastKnownBuildInfo.ProjectAssetsPath, _lastKnownBuildInfo.EditorAppContentsPath, _shouldCalculateBuildSize);
		}*/

		// has to be called in main thread
		static void ShowBuildReportWithLastValues()
		{
			//BRT_BuildReportWindow window = ScriptableObject.CreateInstance<BRT_BuildReportWindow>();
			//window.ShowUtility();

			//Debug.Log("showing build report window...");

			//BRT_BuildReportWindow brtWindow = EditorWindow.GetWindow<BRT_BuildReportWindow>("Build Report", true, typeof(SceneView));
			BRT_BuildReportWindow brtWindow =
				(BRT_BuildReportWindow) EditorWindow.GetWindow(typeof(BRT_BuildReportWindow), false, EDITOR_WINDOW_TITLE,
					true);
			//BRT_BuildReportWindow brtWindow = EditorWindow.GetWindow(typeof(BRT_BuildReportWindow), false, "Build Report", true) as BRT_BuildReportWindow;
			brtWindow.Init(_lastKnownBuildInfo);
		}
	}
} // namespace BuildReportTool