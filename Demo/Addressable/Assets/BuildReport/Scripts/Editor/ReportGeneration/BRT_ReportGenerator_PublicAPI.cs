using UnityEngine;
using UnityEditor;

namespace BuildReportTool
{
	public partial class ReportGenerator
	{
		/// <summary>
		/// Create and save a Build Report. This is meant to be used for users who have a
		/// custom build script, or is automating a project build command from the command line.
		///
		/// The Editor log needs to have build data for this to work,
		/// so only call this after <see cref="UnityEditor.BuildPipeline.BuildPlayer"/>.
		/// </summary>
		///
		/// <remarks>
		/// <para>This overload will make use of the project's current build settings.</para>
		///
		/// <para>Specifically, that means it will retrieve the list of scenes from
		/// UnityEditor.EditorBuildSettings.scenes, the build location using
		/// UnityEditor.EditorUserBuildSettings.GetBuildLocation(), and the build target
		/// using UnityEditor.EditorUserBuildSettings.activeBuildTarget.</para>
		///
		/// <para>If your build scripts are overriding the project's current build settings,
		/// you should use <see cref="CreateReport(string[], string, BuildTarget, string)"/>
		/// instead.</para>
		/// </remarks>
		///
		/// <param name="customEditorLogPath">If your Unity Editor log file is not in
		/// the default path, specify it here. Otherwise, leave this null so that
		/// BuildReportTool will just use the default location of the Editor.log file.</param>
		///
		/// <returns>The full path and filename of the created Build Report XML file,
		/// or null if no Build Report was created.</returns>
		public static string CreateReport(string customEditorLogPath = null)
		{
			return CreateReport(null, null, EditorUserBuildSettings.activeBuildTarget, customEditorLogPath);
		}

#if UNITY_5_5_OR_NEWER
		/// <summary>
		/// Create and save a Build Report. This is meant to be used for users who have a
		/// custom build script, or is automating a project build command from the command line.
		///
		/// The Editor log needs to have build data for this to work,
		/// so only call this after <see cref="UnityEditor.BuildPipeline.BuildPlayer"/>.
		/// </summary>
		///
		/// <remarks>
		/// This overload will retrieve the list of scenes, the build location, and the
		/// build target from the <see cref="UnityEditor.BuildPlayerOptions"/> that you pass.
		/// If your custom build script makes a BuildPlayerOptions, you can use this method
		/// to re-use that BuildPlayerOptions for generating the Build Report.
		/// </remarks>
		///
		/// <param name="buildPlayerOptions">The <see cref="UnityEditor.BuildPlayerOptions"/>
		/// that was used to create the build.</param>
		///
		/// <param name="customEditorLogPath">If your Unity Editor log file is not in
		/// the default path, specify it here. Otherwise, leave this null so that
		/// BuildReportTool will just use the default location of the Editor.log file.</param>
		///
		/// <returns>The full path and filename of the created Build Report XML file,
		/// or null if no Build Report was created.</returns>
		public static string CreateReport(BuildPlayerOptions buildPlayerOptions, string customEditorLogPath = null)
		{
			return CreateReport(buildPlayerOptions.scenes, buildPlayerOptions.locationPathName, buildPlayerOptions.target,
				customEditorLogPath);
		}
#endif

		/// <summary>
		/// Create and save a Build Report. This is meant to be used for users who have a
		/// custom build script, or is automating a project build command from the command line.
		///
		/// The Editor log needs to have build data for this to work,
		/// so only call this after <see cref="UnityEditor.BuildPipeline.BuildPlayer"/>.
		/// </summary>
		///
		/// <remarks>
		/// <para>If your custom build scripts override the project's build settings,
		/// this overload allows you to explicitly specify the list of scenes, the build
		/// location, and the build target yourself.</para>
		///
		/// <para>But if your build scripts didn't override the project's build settings,
		/// you can instead use <see cref="CreateReport(string)"/>.</para>
		/// </remarks>
		///
		/// <param name="scenes">Which scenes were included in the build. Can be set to null
		/// so that BuildReportTool will just use UnityEditor.EditorBuildSettings.scenes instead.
		/// If you specified your own list of scenes when building, you should pass them here.</param>
		///
		/// <param name="buildLocation">Where the build is saved to. Can be set to null so that
		/// BuildReportTool will just use UnityEditor.EditorUserBuildSettings.GetBuildLocation()
		/// instead. If you specified your own build location, you should pass it here.</param>
		///
		/// <param name="buildTarget">Type of build platform being made. You can just pass
		/// UnityEditor.EditorUserBuildSettings.activeBuildTarget if you didn't explicitly
		/// set this. If you specified your own build target, you should pass it here.</param>
		///
		/// <param name="customEditorLogPath">If your Unity Editor log file is not in the
		/// default path, specify it here. Otherwise, leave this null so that BuildReportTool
		/// will just use the default location of the Editor.log file.</param>
		///
		/// <returns>The full path and filename of the created Build Report XML file,
		/// or null if no Build Report was created.</returns>
		public static string CreateReport(string[] scenes, string buildLocation, BuildTarget buildTarget,
			string customEditorLogPath = null)
		{
			BuildReportTool.Util.BuildTargetOfLastBuild = buildTarget;

			var editorLogPathToUse = !string.IsNullOrEmpty(customEditorLogPath)
				                         ? customEditorLogPath
				                         : BuildReportTool.Util.UsedEditorLogPath;

			if (!DoesEditorLogHaveBuildInfo(editorLogPathToUse))
			{
				if (BuildReportTool.Util.IsDefaultEditorLogPathOverridden)
				{
					Debug.LogWarning(string.Format(NO_BUILD_INFO_OVERRIDDEN_LOG_WARNING, editorLogPathToUse,
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

				return null;
			}

			var timeGot = System.DateTime.Now;
			_timeReportGenerationStarted = new System.TimeSpan(timeGot.Ticks);

			_lastPathToBuiltProject = buildLocation;

			Init(ref _lastKnownBuildInfo, scenes, timeGot);

			if (BuildReportTool.Options.CalculateAssetDependencies)
			{
				if (_lastKnownAssetDependencies == null)
				{
					_lastKnownAssetDependencies = new BuildReportTool.AssetDependencies();
				}

				_lastKnownAssetDependencies.TimeGot = timeGot;
			}


			_lastEditorLogPath = editorLogPathToUse;

			if (BuildReportTool.Options.IncludeUnusedPrefabsInReportCreation)
			{
				RefreshListOfAllPrefabsUsedInAllScenesIncludedInBuild();
			}
			else
			{
				ClearListOfAllPrefabsUsedInAllScenes();
			}

			CommitAdditionalInfoToCache();

			CreateBuildReport(_lastKnownBuildInfo);

			var savedFilePath = OnFinishedGetValues(_lastKnownBuildInfo, _lastKnownAssetDependencies);

			return savedFilePath;
		}
	}
}