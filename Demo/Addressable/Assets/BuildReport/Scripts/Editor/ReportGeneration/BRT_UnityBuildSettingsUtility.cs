#if UNITY_5 && (!UNITY_5_0 && !UNITY_5_1)
#define UNITY_5_2_AND_GREATER
#endif

#if UNITY_5 && (!UNITY_5_0 && !UNITY_5_1 && !UNITY_5_2)
#define UNITY_5_3_AND_GREATER
#endif

#if UNITY_4 || UNITY_5_0 || UNITY_5_1
#define UNITY_5_1_AND_LESSER
#endif

#if UNITY_4 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
#define UNITY_5_2_AND_LESSER
#endif

#if UNITY_4 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3
#define UNITY_5_3_AND_LESSER
#endif

#if UNITY_4 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4
#define UNITY_5_4_AND_LESSER
#endif

#if UNITY_4 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5
#define UNITY_5_5_AND_LESSER
#endif

#if !UNITY_2018
#define UNITY_2017_AND_LESSER
#endif

#if !UNITY_4 && !UNITY_5 && !UNITY_2017
#define UNITY_2018_AND_NEWER
#endif

using System.Collections.Generic;
#if !UNITY_5_1_AND_LESSER // 5.2 and greater
using System.Linq;
#endif
using UnityEditor;
using UnityEngine;

namespace BuildReportTool
{
	public static class UnityBuildSettingsUtility
	{
		// ================================================================================================

		public static GUIContent[] GetBuildSettingsCategoryListForDropdownBox()
		{
			// WARNING! changing contents here will require changing code in:
			//
			//  GetIdxFromBuildReportValues
			//  GetSettingsCategoryFromIdx
			//
			// as they rely on the array indices
			//
			return new[]
			{
				/* 0 */ new GUIContent("Windows"),
				/* 1 */ new GUIContent("Mac"),
				/* 2 */ new GUIContent("Linux"),

				/* 3 */ new GUIContent("Web"),
				/*  4 */ new GUIContent("Web GL"),

				/*  5 */ new GUIContent("iOS"),
				/*  6 */ new GUIContent("Android"),
				/*  7 */ new GUIContent("Blackberry"),

				/*  8 */ new GUIContent("Xbox 360"),
				/*  9 */ new GUIContent("Xbox One"),
				/* 10 */ new GUIContent("Playstation 3"),
				/* 11 */ new GUIContent("Playstation 4"),

				/* 12 */ new GUIContent("Playstation Vita (Native)"),

				/* 13 */ new GUIContent("Samsung TV"),
			};
		}


		public static int GetIdxFromBuildReportValues(BuildInfo buildReportToDisplay)
		{
			BuildSettingCategory b = ReportGenerator.GetBuildSettingCategoryFromBuildValues(buildReportToDisplay);

			switch (b)
			{
				case BuildSettingCategory.WindowsDesktopStandalone:
					return 0;
				case BuildSettingCategory.MacStandalone:
					return 1;
				case BuildSettingCategory.LinuxStandalone:
					return 2;

				case BuildSettingCategory.WebPlayer:
					return 3;
				case BuildSettingCategory.WebGL:
					return 4;

				case BuildSettingCategory.iOS:
					return 5;
				case BuildSettingCategory.Android:
					return 6;
				case BuildSettingCategory.Blackberry:
					return 7;

				case BuildSettingCategory.Xbox360:
					return 8;
				case BuildSettingCategory.XboxOne:
					return 9;
				case BuildSettingCategory.PS3:
					return 10;
				case BuildSettingCategory.PS4:
					return 11;

				case BuildSettingCategory.PSVita:
					return 12;

				case BuildSettingCategory.SamsungTV:
					return 13;
			}

			return -1;
		}

		public static BuildSettingCategory GetSettingsCategoryFromIdx(int idx)
		{
			switch (idx)
			{
				case 0:
					return BuildSettingCategory.WindowsDesktopStandalone;
				case 1:
					return BuildSettingCategory.MacStandalone;
				case 2:
					return BuildSettingCategory.LinuxStandalone;

				case 3:
					return BuildSettingCategory.WebPlayer;
				case 4:
					return BuildSettingCategory.WebGL;

				case 5:
					return BuildSettingCategory.iOS;
				case 6:
					return BuildSettingCategory.Android;
				case 7:
					return BuildSettingCategory.Blackberry;

				case 8:
					return BuildSettingCategory.Xbox360;
				case 9:
					return BuildSettingCategory.XboxOne;
				case 10:
					return BuildSettingCategory.PS3;
				case 11:
					return BuildSettingCategory.PS4;

				case 12:
					return BuildSettingCategory.PSVita;

				case 13:
					return BuildSettingCategory.SamsungTV;
			}

			return BuildSettingCategory.None;
		}

		public static string GetReadableBuildSettingCategory(BuildSettingCategory b)
		{
			switch (b)
			{
				case BuildSettingCategory.WindowsDesktopStandalone:
					return "Windows";

				case BuildSettingCategory.WindowsStoreApp:
					return "Windows Store App";

				case BuildSettingCategory.WindowsPhone8:
					return "Windows Phone 8";

				case BuildSettingCategory.MacStandalone:
					return "Mac";

				case BuildSettingCategory.LinuxStandalone:
					return "Linux";


				case BuildSettingCategory.WebPlayer:
					return "Web Player";


				case BuildSettingCategory.Xbox360:
					return "Xbox 360";
				case BuildSettingCategory.XboxOne:
					return "Xbox One";

				case BuildSettingCategory.PS3:
					return "Playstation 3";
				case BuildSettingCategory.PS4:
					return "Playstation 4";

				case BuildSettingCategory.PSVita:
					return "Playstation Vita (Native)";

				case BuildSettingCategory.PSM:
					return "Playstation Mobile";

				case BuildSettingCategory.WebGL:
					return "Web GL";
			}

			return b.ToString();
		}


		public static string GetReadableWebGLOptimizationLevel(string optimizationLevelCode)
		{
			switch (optimizationLevelCode)
			{
				case "1":
					return "1: Slow (fast builds)";
				case "2":
					return "2: Fast";
				case "3":
					return "3: Fastest (very slow builds)";
			}

			return optimizationLevelCode;
		}

		public static string GetReadableStackTraceType(string stackTraceType)
		{
			switch (stackTraceType)
			{
				case "ScriptOnly":
					return "Show stack trace of scripts only (no native code)";
				case "Full":
					return "Show stack trace of native code + scripts";
				default:
					return stackTraceType;
			}
		}

		// ================================================================================================

		public static void Populate(UnityBuildSettings settings)
		{
			PopulateGeneralSettings(settings);
			PopulateWebSettings(settings);
			PopulateStandaloneSettings(settings);
			PopulateMobileSettings(settings);
			PopulateTvDeviceSettings(settings);
			PopulateBigConsoleGen07Settings(settings);
			PopulateBigConsoleGen08Settings(settings);
		}


		public static void PopulateGeneralSettings(UnityBuildSettings settings)
		{
			settings.CompanyName = PlayerSettings.companyName;
			settings.ProductName = PlayerSettings.productName;

			settings.UsingAdvancedLicense = PlayerSettings.advancedLicense;


			// debug settings
			// ---------------------------------------------------------------
			settings.EnableDevelopmentBuild = EditorUserBuildSettings.development;
			settings.EnableDebugLog = PlayerSettings.usePlayerLog;
			settings.EnableSourceDebugging = EditorUserBuildSettings.allowDebugging;
			settings.EnableExplicitNullChecks = EditorUserBuildSettings.explicitNullChecks;

#if !UNITY_5_3_AND_LESSER
			settings.EnableExplicitDivideByZeroChecks = EditorUserBuildSettings.explicitDivideByZeroChecks;
#endif

#if !UNITY_4
			settings.EnableCrashReportApi = PlayerSettings.enableCrashReportAPI;
			settings.EnableInternalProfiler = PlayerSettings.enableInternalProfiler;
			settings.ActionOnDotNetUnhandledException = PlayerSettings.actionOnDotNetUnhandledException.ToString();
#endif

			settings.ConnectProfiler = EditorUserBuildSettings.connectProfiler;

#if UNITY_5_3_AND_GREATER
		// this setting actually started appearing in Unity 5.2.2 (it is not present in 5.2.1)
		// but our script compilation defines can't detect the patch number in the version,
		// so we have no choice but to restrict this to 5.3
		settings.ForceOptimizeScriptCompilation = EditorUserBuildSettings.forceOptimizeScriptCompilation;
#endif

#if UNITY_5_4_OR_NEWER
			settings.StackTraceForError = PlayerSettings.GetStackTraceLogType(LogType.Error).ToString();
			settings.StackTraceForAssert = PlayerSettings.GetStackTraceLogType(LogType.Assert).ToString();
			settings.StackTraceForWarning = PlayerSettings.GetStackTraceLogType(LogType.Warning).ToString();
			settings.StackTraceForLog = PlayerSettings.GetStackTraceLogType(LogType.Log).ToString();
			settings.StackTraceForException = PlayerSettings.GetStackTraceLogType(LogType.Exception).ToString();
#endif


			// build settings
			// ---------------------------------------------------------------

			settings.EnableHeadlessMode = EditorUserBuildSettings.enableHeadlessMode;
			settings.InstallInBuildFolder = EditorUserBuildSettings.installInBuildFolder;
#if !UNITY_4
			settings.ForceInstallation = EditorUserBuildSettings.forceInstallation;
			settings.BuildScriptsOnly = EditorUserBuildSettings.buildScriptsOnly;
			settings.BakeCollisionMeshes = PlayerSettings.bakeCollisionMeshes;
#endif

#if UNITY_4
		settings.StripPhysicsCode = PlayerSettings.stripPhysics;
#endif
			settings.StripUnusedMeshComponents = PlayerSettings.stripUnusedMeshComponents;

#if !UNITY_5_1_AND_LESSER // 5.2 and greater
			settings.StripEngineCode = PlayerSettings.stripEngineCode;
#endif


			// code settings
			// ---------------------------------------------------------------

			Dictionary<string, DldUtil.GetRspDefines.Entry> customDefines = DldUtil.GetRspDefines.GetDefines();

			List<string> defines = new List<string>();
			defines.AddRange(EditorUserBuildSettings.activeScriptCompilationDefines);


			foreach (KeyValuePair<string, DldUtil.GetRspDefines.Entry> customDefine in customDefines)
			{
				if (customDefine.Value.TimesDefinedInBuiltIn == 0)
				{
					defines.Add(customDefine.Key);
				}
			}

			settings.CompileDefines = defines.ToArray();


#if UNITY_2018_3_OR_NEWER
			settings.StrippingLevelUsed = PlayerSettings
			                              .GetManagedStrippingLevel(EditorUserBuildSettings.selectedBuildTargetGroup)
			                              .ToString();
#else
		settings.StrippingLevelUsed = PlayerSettings.strippingLevel.ToString();
#endif

#if UNITY_5_6_OR_NEWER
			settings.NETApiCompatibilityLevel = PlayerSettings
			                                    .GetApiCompatibilityLevel(EditorUserBuildSettings.selectedBuildTargetGroup)
			                                    .ToString();
#else
		settings.NETApiCompatibilityLevel = PlayerSettings.apiCompatibilityLevel.ToString();
#endif

			settings.AOTOptions = PlayerSettings.aotOptions;

#if UNITY_5_5_OR_NEWER
			settings.LocationUsageDescription = PlayerSettings.iOS.locationUsageDescription;
#else
		settings.LocationUsageDescription = PlayerSettings.locationUsageDescription;
#endif


			// rendering settings
			// ---------------------------------------------------------------
			settings.ColorSpaceUsed = PlayerSettings.colorSpace.ToString();
			settings.UseMultithreadedRendering = PlayerSettings.MTRendering;
			settings.UseGPUSkinning = PlayerSettings.gpuSkinning;
			settings.VisibleInBackground = PlayerSettings.visibleInBackground;

#if UNITY_5_4_OR_NEWER
			settings.UseGraphicsJobs = PlayerSettings.graphicsJobs;
#endif
#if UNITY_5_5_OR_NEWER
			settings.GraphicsJobsType = PlayerSettings.graphicsJobMode.ToString();
#endif

#if (UNITY_EDITOR_WIN || UNITY_EDITOR_OSX)
#if UNITY_5_5_OR_NEWER
			settings.RenderingPathUsed = UnityEditor.Rendering.EditorGraphicsSettings
			                                        .GetTierSettings(EditorUserBuildSettings.selectedBuildTargetGroup,
				                                        Graphics.activeTier).renderingPath.ToString();
#else
		settings.RenderingPathUsed = PlayerSettings.renderingPath.ToString();
#endif
#endif

#if !UNITY_5_1_AND_LESSER && !UNITY_2019_3_OR_NEWER // 5.2 to 2019.2
		settings.EnableVirtualRealitySupport = PlayerSettings.virtualRealitySupported;
#elif UNITY_2019_3_OR_NEWER
			settings.EnableVirtualRealitySupport = UnityEngine.XR.XRSettings.enabled;
#endif

			// collect all aspect ratios
			UnityEditor.AspectRatio[] aspectRatios =
			{
				UnityEditor.AspectRatio.Aspect4by3,
				UnityEditor.AspectRatio.Aspect5by4,
				UnityEditor.AspectRatio.Aspect16by9,
				UnityEditor.AspectRatio.Aspect16by10,
				UnityEditor.AspectRatio.AspectOthers
			};
			List<string> aspectRatiosList = new List<string>();
			for (int n = 0, len = aspectRatios.Length; n < len; ++n)
			{
				if (PlayerSettings.HasAspectRatio(aspectRatios[n]))
				{
					aspectRatiosList.Add(aspectRatios[n].ToString());
				}
			}

			if (aspectRatiosList.Count == 0)
			{
				aspectRatiosList.Add("none");
			}

			settings.AspectRatiosAllowed = aspectRatiosList.ToArray();

#if !UNITY_5_1_AND_LESSER // 5.2 and greater
			settings.GraphicsAPIsUsed = PlayerSettings.GetGraphicsAPIs(EditorUserBuildSettings.activeBuildTarget)
			                                          .Select(type => type.ToString()).ToArray();
#endif


			// shared settings
			// ---------------------------------------------------------------

			// shared between web and standalone
			settings.RunInBackground = PlayerSettings.runInBackground;
		}

		public static void PopulateWebSettings(UnityBuildSettings settings)
		{
			// web player settings
			// ---------------------------------------------------------------
#if UNITY_5_6_OR_NEWER
			settings.WebPlayerDefaultScreenWidth = 0;
			settings.WebPlayerDefaultScreenHeight = 0;

			settings.WebPlayerEnableStreaming = false;
			settings.WebPlayerDeployOffline = false;
#else
		settings.WebPlayerDefaultScreenWidth = PlayerSettings.defaultWebScreenWidth;
		settings.WebPlayerDefaultScreenHeight = PlayerSettings.defaultWebScreenHeight;

		settings.WebPlayerEnableStreaming = EditorUserBuildSettings.webPlayerStreamed;
		settings.WebPlayerDeployOffline = EditorUserBuildSettings.webPlayerOfflineDeployment;
#endif

#if UNITY_5_2_AND_LESSER
		settings.WebPlayerFirstStreamedLevelWithResources = PlayerSettings.firstStreamedLevelWithResources;
#else
			settings.WebPlayerFirstStreamedLevelWithResources = 0;
#endif

			// Web GL settings
			// ---------------------------------------------------------------

#if UNITY_5_3_AND_LESSER
		settings.WebGLOptimizationLevel = EditorUserBuildSettings.webGLOptimizationLevel.ToString();
#endif
#if UNITY_5_4_OR_NEWER && !UNITY_2019_1_OR_NEWER
		settings.WebGLUsePreBuiltUnityEngine = EditorUserBuildSettings.webGLUsePreBuiltUnityEngine;
#endif
#if UNITY_5_5_OR_NEWER
			settings.WebGLCompressionFormat = PlayerSettings.WebGL.compressionFormat.ToString();
			settings.WebGLAutoCacheAssetsData = PlayerSettings.WebGL.dataCaching;
			settings.WebGLCreateDebugSymbolsFile = PlayerSettings.WebGL.debugSymbols;
			settings.WebGLExceptionSupportType = PlayerSettings.WebGL.exceptionSupport.ToString();
			settings.WebGLMemorySize = PlayerSettings.WebGL.memorySize;
			settings.WebGLTemplatePath = PlayerSettings.WebGL.template;
#endif
		}

		public static void PopulateStandaloneSettings(UnityBuildSettings settings)
		{
			// standalone (windows/mac/linux) build settings
			// ---------------------------------------------------------------
#if !UNITY_2019_1_OR_NEWER
		settings.StandaloneResolutionDialogSettingUsed = PlayerSettings.displayResolutionDialog.ToString();
#endif
#if UNITY_2018_AND_NEWER
			settings.StandaloneFullScreenModeUsed = PlayerSettings.fullScreenMode.ToString();
#endif

			settings.StandaloneDefaultScreenWidth = PlayerSettings.defaultScreenWidth;
			settings.StandaloneDefaultScreenHeight = PlayerSettings.defaultScreenHeight;

#if UNITY_2017_AND_LESSER && !UNITY_2019_1_OR_NEWER
		settings.StandaloneFullScreenByDefault = PlayerSettings.defaultIsFullScreen;
#endif
#if !UNITY_5_2_AND_LESSER
			settings.StandaloneAllowFullScreenSwitch = PlayerSettings.allowFullscreenSwitch;
#endif

			settings.StandaloneCaptureSingleScreen = PlayerSettings.captureSingleScreen;

			settings.StandaloneForceSingleInstance = PlayerSettings.forceSingleInstance;
			settings.StandaloneEnableResizableWindow = PlayerSettings.resizableWindow;


			// windows only build settings
			// ---------------------------------------------------------------
#if UNITY_5_1_AND_LESSER
		settings.WinUseDirect3D11IfAvailable = PlayerSettings.useDirect3D11;
#endif

#if !UNITY_2017_3_OR_NEWER
		settings.WinDirect3D9FullscreenModeUsed = PlayerSettings.d3d9FullscreenMode.ToString();
#endif

#if !UNITY_4 && UNITY_2017_AND_LESSER && !UNITY_2019_1_OR_NEWER
		settings.WinDirect3D11FullscreenModeUsed = PlayerSettings.d3d11FullscreenMode.ToString();
#endif

#if UNITY_5_3_AND_LESSER
		settings.StandaloneUseStereoscopic3d = PlayerSettings.stereoscopic3D;
#endif


			// Windows Store App only build settings
			// ---------------------------------------------------------------
#if !UNITY_4 && !UNITY_2019_1_OR_NEWER
		settings.WSAGenerateReferenceProjects = EditorUserBuildSettings.wsaGenerateReferenceProjects;
#endif
#if UNITY_5_2_AND_GREATER
		settings.WSASDK = EditorUserBuildSettings.wsaSDK.ToString();
#endif


			// mac only build settings
			// ---------------------------------------------------------------
			settings.MacUseAppStoreValidation = PlayerSettings.useMacAppStoreValidation;
#if UNITY_2017_AND_LESSER && !UNITY_2019_1_OR_NEWER
		settings.MacFullscreenModeUsed = PlayerSettings.macFullscreenMode.ToString();
#endif
		}


		public static void PopulateMobileSettings(UnityBuildSettings settings)
		{
			// Mobile build settings
			// ---------------------------------------------------------------


#if UNITY_5_5_AND_LESSER
		settings.MobileBundleIdentifier =
 PlayerSettings.bundleIdentifier; // ("Bundle Identifier" in iOS, "Package Identifier" in Android)
#else
			settings.MobileBundleIdentifier =
				PlayerSettings.applicationIdentifier; // ("Bundle Identifier" in iOS, "Package Identifier" in Android)
#endif

			settings.MobileBundleVersion =
				PlayerSettings.bundleVersion; // ("Bundle Version" in iOS, "Version Name" in Android)
			settings.MobileHideStatusBar = PlayerSettings.statusBarHidden;

			settings.MobileAccelerometerFrequency = PlayerSettings.accelerometerFrequency;

			settings.MobileDefaultOrientationUsed = PlayerSettings.defaultInterfaceOrientation.ToString();
			settings.MobileEnableAutorotateToPortrait = PlayerSettings.allowedAutorotateToPortrait;
			settings.MobileEnableAutorotateToReversePortrait = PlayerSettings.allowedAutorotateToPortraitUpsideDown;
			settings.MobileEnableAutorotateToLandscapeLeft = PlayerSettings.allowedAutorotateToLandscapeLeft;
			settings.MobileEnableAutorotateToLandscapeRight = PlayerSettings.allowedAutorotateToLandscapeRight;
			settings.MobileEnableOSAutorotation = PlayerSettings.useAnimatedAutorotation;

			settings.Use32BitDisplayBuffer = PlayerSettings.use32BitDisplayBuffer;


			// iOS only build settings
			// ---------------------------------------------------------------

			// Unity 5: EditorUserBuildSettings.appendProject is removed
#if UNITY_4
		settings.iOSAppendedToProject = EditorUserBuildSettings.appendProject;
#endif

#if UNITY_5_5_OR_NEWER
			settings.iOSTargetOSVersion = PlayerSettings.iOS.targetOSVersionString;
#else
		settings.iOSTargetOSVersion = PlayerSettings.iOS.targetOSVersion.ToString();
#endif

			settings.iOSSymlinkLibraries = EditorUserBuildSettings.symlinkSources;
			settings.iOSAppDisplayName = PlayerSettings.iOS.applicationDisplayName;
			settings.iOSScriptCallOptimizationUsed = PlayerSettings.iOS.scriptCallOptimization.ToString();
			settings.iOSSDKVersionUsed = PlayerSettings.iOS.sdkVersion.ToString();
			settings.iOSTargetDevice = PlayerSettings.iOS.targetDevice.ToString();

#if UNITY_5_2_AND_LESSER
		settings.iOSTargetResolution = PlayerSettings.iOS.targetResolution.ToString();
#else
			// not sure what the equivalent is for PlayerSettings.iOS.targetResolution in Unity 5.3
			// Unity 5.3 has a Screen.resolutions but I don't know which of those in the array would be the iOS target resolution
#endif

			settings.iOSIsIconPrerendered = PlayerSettings.iOS.prerenderedIcon;
			settings.iOSRequiresPersistentWiFi = PlayerSettings.iOS.requiresPersistentWiFi.ToString();
			settings.iOSStatusBarStyle = PlayerSettings.iOS.statusBarStyle.ToString();

#if UNITY_4
		settings.iOSExitOnSuspend = PlayerSettings.iOS.exitOnSuspend;
#else
			settings.iOSAppInBackgroundBehavior = PlayerSettings.iOS.appInBackgroundBehavior.ToString();
#endif

			settings.iOSShowProgressBarInLoadingScreen = PlayerSettings.iOS.showActivityIndicatorOnLoading.ToString();

#if !UNITY_4
			settings.iOSLogObjCUncaughtExceptions = PlayerSettings.logObjCUncaughtExceptions;
#endif

#if UNITY_5_1_AND_LESSER
		settings.iOSTargetGraphics = PlayerSettings.targetIOSGraphics.ToString();
#else
			settings.iOSTargetGraphics = string.Join(",",
				PlayerSettings.GetGraphicsAPIs(BuildTarget.iOS).Select(type => type.ToString()).ToArray());
#endif

			// Android only build settings
			// ---------------------------------------------------------------

			settings.AndroidBuildSubtarget = EditorUserBuildSettings.androidBuildSubtarget.ToString();

			settings.AndroidUseAPKExpansionFiles = PlayerSettings.Android.useAPKExpansionFiles;

#if !UNITY_4
			settings.AndroidAsAndroidProject = EditorUserBuildSettings.exportAsGoogleAndroidProject;
			settings.AndroidIsGame = PlayerSettings.Android.androidIsGame;
			settings.AndroidTvCompatible = PlayerSettings.Android.androidTVCompatibility;
#endif

			settings.AndroidUseLicenseVerification = PlayerSettings.Android.licenseVerification;


#if UNITY_4
		settings.AndroidUse24BitDepthBuffer = PlayerSettings.Android.use24BitDepthBuffer;
#else
			settings.AndroidDisableDepthAndStencilBuffers = PlayerSettings.Android.disableDepthAndStencilBuffers;
#endif

			settings.AndroidVersionCode = PlayerSettings.Android.bundleVersionCode;

			settings.AndroidMinSDKVersion = PlayerSettings.Android.minSdkVersion.ToString();
#if UNITY_2018_AND_NEWER
			settings.AndroidTargetDevice = PlayerSettings.Android.targetArchitectures.ToString();
#else
		settings.AndroidTargetDevice = PlayerSettings.Android.targetDevice.ToString();
#endif

			settings.AndroidSplashScreenScaleMode = PlayerSettings.Android.splashScreenScale.ToString();

			settings.AndroidPreferredInstallLocation = PlayerSettings.Android.preferredInstallLocation.ToString();

			settings.AndroidForceInternetPermission = PlayerSettings.Android.forceInternetPermission;
			settings.AndroidForceSDCardPermission = PlayerSettings.Android.forceSDCardPermission;

			settings.AndroidShowProgressBarInLoadingScreen =
				PlayerSettings.Android.showActivityIndicatorOnLoading.ToString();

			settings.AndroidKeyAliasName = PlayerSettings.Android.keyaliasName;
			settings.AndroidKeystoreName = PlayerSettings.Android.keystoreName;


#if UNITY_5_3_AND_LESSER // blackberry build option no longer in Unity 5.4
		// BlackBerry only build settings
		// ---------------------------------------------------------------

		settings.BlackBerryBuildSubtarget = EditorUserBuildSettings.blackberryBuildSubtarget.ToString();
		settings.BlackBerryBuildType = EditorUserBuildSettings.blackberryBuildType.ToString();

#if !UNITY_5
		settings.BlackBerryAuthorID = PlayerSettings.BlackBerry.authorId;
#endif
		settings.BlackBerryDeviceAddress = PlayerSettings.BlackBerry.deviceAddress;

		settings.BlackBerrySaveLogPath = PlayerSettings.BlackBerry.saveLogPath;
		settings.BlackBerryTokenPath = PlayerSettings.BlackBerry.tokenPath;

		settings.BlackBerryTokenAuthor = PlayerSettings.BlackBerry.tokenAuthor;
		settings.BlackBerryTokenExpiration = PlayerSettings.BlackBerry.tokenExpires;

		settings.BlackBerryHasCamPermissions = PlayerSettings.BlackBerry.HasCameraPermissions();
		settings.BlackBerryHasMicPermissions = PlayerSettings.BlackBerry.HasMicrophonePermissions();
		settings.BlackBerryHasGpsPermissions = PlayerSettings.BlackBerry.HasGPSPermissions();
		settings.BlackBerryHasIdPermissions = PlayerSettings.BlackBerry.HasIdentificationPermissions();
		settings.BlackBerryHasSharedPermissions = PlayerSettings.BlackBerry.HasSharedPermissions();
#endif
		}


		public static void PopulateTvDeviceSettings(UnityBuildSettings settings)
		{
			// no more Samsung TV in Unity 2017.3 or greater

#if UNITY_4 || UNITY_5 || (UNITY_2017 && !UNITY_2017_3_OR_NEWER)
		settings.SamsungTVDeviceAddress = PlayerSettings.SamsungTV.deviceAddress;
#if !UNITY_4
		settings.SamsungTVAuthor = PlayerSettings.SamsungTV.productAuthor;
		settings.SamsungTVAuthorEmail = PlayerSettings.SamsungTV.productAuthorEmail;
		settings.SamsungTVAuthorWebsiteUrl = PlayerSettings.SamsungTV.productLink;
		settings.SamsungTVCategory = PlayerSettings.SamsungTV.productCategory.ToString();
		settings.SamsungTVDescription = PlayerSettings.SamsungTV.productDescription;
#endif
#endif
		}


		public static void PopulateBigConsoleGen07Settings(UnityBuildSettings settings)
		{
			// XBox 360 build settings
			// ---------------------------------------------------------------

#if UNITY_5_5_OR_NEWER
			// In Unity 5.5, API for Xbox 360 is still there but build options
			// do not allow Xbox 360 anymore, so we don't bother with it
#else
		settings.Xbox360BuildSubtarget = EditorUserBuildSettings.xboxBuildSubtarget.ToString();
		settings.Xbox360RunMethod = EditorUserBuildSettings.xboxRunMethod.ToString();

		settings.Xbox360TitleId = PlayerSettings.xboxTitleId;
		settings.Xbox360ImageXexFilePath = PlayerSettings.xboxImageXexFilePath;
		settings.Xbox360SpaFilePath = PlayerSettings.xboxSpaFilePath;

		settings.Xbox360AutoGenerateSpa = PlayerSettings.xboxGenerateSpa;
		settings.Xbox360EnableKinect = PlayerSettings.xboxEnableKinect;
		settings.Xbox360EnableKinectAutoTracking = PlayerSettings.xboxEnableKinectAutoTracking;
		settings.Xbox360EnableSpeech = PlayerSettings.xboxEnableSpeech;
		settings.Xbox360EnableAvatar = PlayerSettings.xboxEnableAvatar;

		settings.Xbox360SpeechDB = PlayerSettings.xboxSpeechDB;

		settings.Xbox360AdditionalTitleMemSize = PlayerSettings.xboxAdditionalTitleMemorySize;

		settings.Xbox360DeployKinectResources = PlayerSettings.xboxDeployKinectResources;
		settings.Xbox360DeployKinectHeadOrientation = PlayerSettings.xboxDeployKinectHeadOrientation;
		settings.Xbox360DeployKinectHeadPosition = PlayerSettings.xboxDeployKinectHeadPosition;
#endif


			// Playstation devices build settings
			// ---------------------------------------------------------------

#if UNITY_5_5_OR_NEWER
			// In Unity 5.5, EditorUserBuildSettings.sceBuildSubtarget is removed
#else
		settings.SCEBuildSubtarget = EditorUserBuildSettings.sceBuildSubtarget.ToString();
#endif

#if !UNITY_4
			settings.CompressBuildWithPsArc = EditorUserBuildSettings.compressWithPsArc;
			settings.NeedSubmissionMaterials = EditorUserBuildSettings.needSubmissionMaterials;
#endif

			// PS3 build settings
			// ---------------------------------------------------------------

			// paths
#if UNITY_5_5_OR_NEWER
			// no more PS3 support in Unity 5.5 and greater

#elif !UNITY_5
		settings.PS3TitleConfigFilePath = PlayerSettings.ps3TitleConfigPath;
		settings.PS3DLCConfigFilePath = PlayerSettings.ps3DLCConfigPath;
		settings.PS3ThumbnailFilePath = PlayerSettings.ps3ThumbnailPath;
		settings.PS3BackgroundImageFilePath = PlayerSettings.ps3BackgroundPath;
		settings.PS3BackgroundSoundFilePath = PlayerSettings.ps3SoundPath;
		settings.PS3TrophyPackagePath = PlayerSettings.ps3TrophyPackagePath;

		settings.PS3InTrialMode = PlayerSettings.ps3TrialMode;

		settings.PS3BootCheckMaxSaveGameSizeKB = PlayerSettings.ps3BootCheckMaxSaveGameSizeKB;

		settings.PS3SaveGameSlots = PlayerSettings.ps3SaveGameSlots;

		settings.PS3NpCommsId = PlayerSettings.ps3TrophyCommId;
		settings.PS3NpCommsSig = PlayerSettings.ps3TrophyCommSig;
		settings.PS3VideoMemoryForVertexBuffers = PlayerSettings.PS3.videoMemoryForVertexBuffers;
#else
		settings.PS3TitleConfigFilePath = PlayerSettings.PS3.titleConfigPath;
		settings.PS3DLCConfigFilePath = PlayerSettings.PS3.dlcConfigPath;
		settings.PS3ThumbnailFilePath = PlayerSettings.PS3.thumbnailPath;
		settings.PS3BackgroundImageFilePath = PlayerSettings.PS3.backgroundPath;
		settings.PS3BackgroundSoundFilePath = PlayerSettings.PS3.soundPath;
		settings.PS3TrophyPackagePath = PlayerSettings.PS3.npTrophyPackagePath;

		settings.PS3InTrialMode = PlayerSettings.PS3.trialMode;

		settings.PS3NpCommsId = PlayerSettings.PS3.npTrophyCommId;
		settings.PS3NpCommsSig = PlayerSettings.PS3.npTrophyCommSig;

		settings.PS3DisableDolbyEncoding = PlayerSettings.PS3.DisableDolbyEncoding;
		settings.PS3EnableMoveSupport = PlayerSettings.PS3.EnableMoveSupport;
		settings.PS3UseSPUForUmbra = PlayerSettings.PS3.UseSPUForUmbra;
		settings.PS3EnableVerboseMemoryStats = PlayerSettings.PS3.EnableVerboseMemoryStats;
		settings.PS3VideoMemoryForAudio = PlayerSettings.PS3.videoMemoryForAudio;
		settings.PS3BootCheckMaxSaveGameSizeKB = PlayerSettings.PS3.bootCheckMaxSaveGameSizeKB;

		settings.PS3SaveGameSlots = PlayerSettings.PS3.saveGameSlots;
		settings.PS3NpAgeRating = PlayerSettings.PS3.npAgeRating;
		settings.PS3VideoMemoryForVertexBuffers = PlayerSettings.PS3.videoMemoryForVertexBuffers;
#endif


			// PS Vita build settings
			// ---------------------------------------------------------------

#if !UNITY_2018_3_OR_NEWER // PS Vita removed in 2018.3
#if UNITY_4
		settings.PSVTrophyPackagePath = PlayerSettings.psp2NPTrophyPackPath;
		settings.PSVParamSfxPath = PlayerSettings.psp2ParamSfxPath;

		settings.PSVNpCommsId = PlayerSettings.psp2NPCommsID;
		settings.PSVNpCommsSig = PlayerSettings.psp2NPCommsSig;
#else
		settings.PSVTrophyPackagePath = PlayerSettings.PSVita.npTrophyPackPath;
		settings.PSVParamSfxPath = PlayerSettings.PSVita.paramSfxPath;

		settings.PSVNpCommsId = PlayerSettings.PSVita.npCommunicationsID;
		settings.PSVNpCommsSig = PlayerSettings.PSVita.npCommsSig;


		settings.PSVBuildSubtarget = EditorUserBuildSettings.psp2BuildSubtarget.ToString();

		settings.PSVShortTitle = PlayerSettings.PSVita.shortTitle;
		settings.PSVAppVersion = PlayerSettings.PSVita.appVersion;
		settings.PSVMasterVersion = PlayerSettings.PSVita.masterVersion;
		settings.PSVAppCategory = PlayerSettings.PSVita.category.ToString();
		settings.PSVContentId = PlayerSettings.PSVita.contentID;

		settings.PSVNpAgeRating = PlayerSettings.PSVita.npAgeRating.ToString();
		settings.PSVParentalLevel = PlayerSettings.PSVita.parentalLevel.ToString();

		settings.PSVDrmType = PlayerSettings.PSVita.drmType.ToString();
		settings.PSVUpgradable = PlayerSettings.PSVita.upgradable;
		settings.PSVTvBootMode = PlayerSettings.PSVita.tvBootMode.ToString();
		settings.PSVAcquireBgm = PlayerSettings.PSVita.acquireBGM;
#if UNITY_5_2_AND_LESSER
		settings.PSVAllowTwitterDialog = PlayerSettings.PSVita.AllowTwitterDialog;
#endif

		settings.PSVMediaCapacity = PlayerSettings.PSVita.mediaCapacity.ToString();
		settings.PSVStorageType = PlayerSettings.PSVita.storageType.ToString();
		settings.PSVTvDisableEmu = PlayerSettings.PSVita.tvDisableEmu;
		settings.PSVNpSupportGbmOrGjp = PlayerSettings.PSVita.npSupportGBMorGJP;
		settings.PSVPowerMode = PlayerSettings.PSVita.powerMode.ToString();
#if UNITY_5_2_AND_LESSER
		settings.PSVUseLibLocation = PlayerSettings.PSVita.useLibLocation;
#endif

		settings.PSVHealthWarning = PlayerSettings.PSVita.healthWarning;
		settings.PSVEnterButtonAssignment = PlayerSettings.PSVita.enterButtonAssignment.ToString();

		settings.PSVInfoBarColor = PlayerSettings.PSVita.infoBarColor;
		settings.PSVShowInfoBarOnStartup = PlayerSettings.PSVita.infoBarOnStartup;
		settings.PSVSaveDataQuota = PlayerSettings.PSVita.saveDataQuota;

		// paths
		settings.PSVPatchChangeInfoPath = PlayerSettings.PSVita.patchChangeInfoPath;
		settings.PSVPatchOriginalPackPath = PlayerSettings.PSVita.patchOriginalPackage;
		settings.PSVKeystoneFilePath = PlayerSettings.PSVita.keystoneFile;
		settings.PSVLiveAreaBgImagePath = PlayerSettings.PSVita.liveAreaBackroundPath;
		settings.PSVLiveAreaGateImagePath = PlayerSettings.PSVita.liveAreaGatePath;
		settings.PSVCustomLiveAreaPath = PlayerSettings.PSVita.liveAreaPath;
		settings.PSVLiveAreaTrialPath = PlayerSettings.PSVita.liveAreaTrialPath;

		settings.PSVManualPath = PlayerSettings.PSVita.manualPath;
#endif
#endif
		}

		public static void PopulateBigConsoleGen08Settings(UnityBuildSettings settings)
		{
#if !UNITY_4
			// Xbox One build settings
			// ---------------------------------------------------------------
			settings.XboxOneDeployMethod = EditorUserBuildSettings.xboxOneDeployMethod.ToString();
			settings.XboxOneTitleId = PlayerSettings.XboxOne.TitleId;
			settings.XboxOneContentId = PlayerSettings.XboxOne.ContentId;
			settings.XboxOneProductId = PlayerSettings.XboxOne.ProductId;

#if UNITY_5_5_AND_LESSER
		settings.XboxOneSandboxId = PlayerSettings.XboxOne.SandboxId;
#endif

			settings.XboxOneServiceConfigId = PlayerSettings.XboxOne.SCID;
			settings.XboxOneVersion = PlayerSettings.XboxOne.Version;
			settings.XboxOneIsContentPackage = PlayerSettings.XboxOne.IsContentPackage;

			settings.XboxOneDescription = PlayerSettings.XboxOne.Description;

			settings.XboxOnePackagingEncryptionLevel = PlayerSettings.XboxOne.PackagingEncryption.ToString();

			settings.XboxOneAllowedProductIds = PlayerSettings.XboxOne.AllowedProductIds;

			settings.XboxOneDisableKinectGpuReservation = PlayerSettings.XboxOne.DisableKinectGpuReservation;
			settings.XboxOneEnableVariableGPU = PlayerSettings.XboxOne.EnableVariableGPU;
			settings.XboxOneStreamingInstallLaunchRange = EditorUserBuildSettings.streamingInstallLaunchRange;
			settings.XboxOnePersistentLocalStorageSize = PlayerSettings.XboxOne.PersistentLocalStorageSize;

			settings.XboxOneSocketNames = PlayerSettings.XboxOne.SocketNames;

			settings.XboxOneGameOsOverridePath = PlayerSettings.XboxOne.GameOsOverridePath;
			settings.XboxOneAppManifestOverridePath = PlayerSettings.XboxOne.AppManifestOverridePath;
			settings.XboxOnePackagingOverridePath = PlayerSettings.XboxOne.PackagingOverridePath;


			// PS4 build settings
			// ---------------------------------------------------------------
			settings.PS4BuildSubtarget = EditorUserBuildSettings.ps4BuildSubtarget.ToString();

			settings.PS4AppParameter1 = PlayerSettings.PS4.applicationParameter1;
			settings.PS4AppParameter2 = PlayerSettings.PS4.applicationParameter2;
			settings.PS4AppParameter3 = PlayerSettings.PS4.applicationParameter3;
			settings.PS4AppParameter4 = PlayerSettings.PS4.applicationParameter4;

			settings.PS4AppType = PlayerSettings.PS4.appType;
			settings.PS4AppVersion = PlayerSettings.PS4.appVersion;
			settings.PS4Category = PlayerSettings.PS4.category.ToString();
			settings.PS4ContentId = PlayerSettings.PS4.contentID;
			settings.PS4MasterVersion = PlayerSettings.PS4.masterVersion;

			settings.PS4EnterButtonAssignment = PlayerSettings.PS4.enterButtonAssignment.ToString();
			settings.PS4RemotePlayKeyAssignment = PlayerSettings.PS4.remotePlayKeyAssignment.ToString();

			settings.PS4VideoOutPixelFormat = PlayerSettings.PS4.videoOutPixelFormat.ToString();
#if UNITY_5_5_OR_NEWER
			settings.PS4VideoOutResolution = string.Format("Width: {0} ReprojectionRate: {1}",
				PlayerSettings.PS4.videoOutInitialWidth, PlayerSettings.PS4.videoOutReprojectionRate);
#else
		settings.PS4VideoOutResolution = PlayerSettings.PS4.videoOutResolution.ToString();
#endif

			settings.PS4MonoEnvVars = PlayerSettings.PS4.monoEnv;

			settings.PS4NpAgeRating = PlayerSettings.PS4.npAgeRating.ToString();
			settings.PS4ParentalLevel = PlayerSettings.PS4.parentalLevel.ToString();

			settings.PS4EnablePlayerPrefsSupport = PlayerSettings.PS4.playerPrefsSupport;

			settings.PS4EnableFriendPushNotifications = PlayerSettings.PS4.pnFriends;
			settings.PS4EnablePresencePushNotifications = PlayerSettings.PS4.pnPresence;
			settings.PS4EnableSessionPushNotifications = PlayerSettings.PS4.pnSessions;
			settings.PS4EnableGameCustomDataPushNotifications = PlayerSettings.PS4.pnGameCustomData;

			// paths
			settings.PS4BgImagePath = PlayerSettings.PS4.BackgroundImagePath;
			settings.PS4BgMusicPath = PlayerSettings.PS4.BGMPath;
			settings.PS4StartupImagePath = PlayerSettings.PS4.StartupImagePath;
			settings.PS4ParamSfxPath = PlayerSettings.PS4.paramSfxPath;
			settings.PS4NpTitleDatPath = PlayerSettings.PS4.NPtitleDatPath;
			settings.PS4NpTrophyPackagePath = PlayerSettings.PS4.npTrophyPackPath;
			settings.PS4PronunciationSigPath = PlayerSettings.PS4.PronunciationSIGPath;
			settings.PS4PronunciationXmlPath = PlayerSettings.PS4.PronunciationXMLPath;
			settings.PS4SaveDataImagePath = PlayerSettings.PS4.SaveDataImagePath;
			settings.PS4ShareFilePath = PlayerSettings.PS4.ShareFilePath;
#endif
		}
	}
}