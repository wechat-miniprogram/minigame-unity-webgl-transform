namespace BuildReportTool
{
	[System.Serializable]
	public class UnityBuildSettings
	{
		public string CompanyName; // PlayerSettings.companyName
		public string ProductName; // PlayerSettings.productName

		public bool UsingAdvancedLicense; // PlayerSettings.advancedLicense / Application.HasProLicense() ?


		// debug settings
		// ---------------------------------------------------------------

		public bool EnableDevelopmentBuild; // EditorUserBuildSettings.development / Debug.isDebugBuild
		public bool EnableDebugLog; // PlayerSettings.usePlayerLog
		public bool EnableSourceDebugging; // EditorUserBuildSettings.allowDebugging
		public bool EnableExplicitNullChecks; // EditorUserBuildSettings.explicitNullChecks
		public bool EnableExplicitDivideByZeroChecks; // Unity 5.4: EditorUserBuildSettings.explicitDivideByZeroChecks

		public bool EnableCrashReportApi; // PlayerSettings.enableCrashReportAPI
		public bool EnableInternalProfiler; // PlayerSettings.enableInternalProfiler
		public bool ConnectProfiler; // EditorUserBuildSettings.connectProfiler

		public string ActionOnDotNetUnhandledException; // Unity 5: PlayerSettings.actionOnDotNetUnhandledException

		public bool ForceOptimizeScriptCompilation; // Unity 5.2.2: EditorUserBuildSettings.forceOptimizeScriptCompilation

		public string StackTraceForError; // PlayerSettings.GetStackTraceLogType(LogType.Error)
		public string StackTraceForAssert; // PlayerSettings.GetStackTraceLogType(LogType.Assert)
		public string StackTraceForWarning; // PlayerSettings.GetStackTraceLogType(LogType.Warning)
		public string StackTraceForLog; // PlayerSettings.GetStackTraceLogType(LogType.Log)
		public string StackTraceForException; // PlayerSettings.GetStackTraceLogType(LogType.Exception)


		// build settings
		// ---------------------------------------------------------------

		public bool EnableHeadlessMode; // EditorUserBuildSettings.enableHeadlessMode
		public bool InstallInBuildFolder; // EditorUserBuildSettings.installInBuildFolder
		public bool ForceInstallation; // EditorUserBuildSettings.forceInstallation
		public bool BuildScriptsOnly; // EditorUserBuildSettings.buildScriptsOnly
		public bool StripPhysicsCode; // in Unity 4: PlayerSettings.stripPhysics. Removed in Unity 5
		public bool BakeCollisionMeshes; // Unity 5: PlayerSettings.bakeCollisionMeshes
		public bool StripUnusedMeshComponents; // PlayerSettings.stripUnusedMeshComponents
		public bool StripEngineCode; // PlayerSettings.stripEngineCode


		// code settings
		// ---------------------------------------------------------------

		public string[] CompileDefines; // EditorUserBuildSettings.activeScriptCompilationDefines

		public string StrippingLevelUsed; // PlayerSettings.strippingLevel

		public string NETApiCompatibilityLevel; // PlayerSettings.apiCompatibilityLevel

		public string AOTOptions; // PlayerSettings.aotOptions

		public string LocationUsageDescription; // PlayerSettings.locationUsageDescription


		// rendering settings
		// ---------------------------------------------------------------

		public string ColorSpaceUsed; // PlayerSettings.colorSpace

		public bool UseMultithreadedRendering; // PlayerSettings.MTRendering

		// in Unity 3: only xbox 360 has this with PlayerSettings.xboxSkinOnGPU
		// in Unity 4, this is PlayerSettings.gpuSkinning
		public bool UseGPUSkinning;

		public bool UseGraphicsJobs; // PlayerSettings.graphicsJobs

		public string GraphicsJobsType; // PlayerSettings.graphicsJobMode

		public string RenderingPathUsed; // Unity 4: PlayerSettings.renderingPath

		public bool VisibleInBackground; // PlayerSettings.visibleInBackground

		public string[] AspectRatiosAllowed; // PlayerSettings.HasAspectRatio

		public string[] GraphicsAPIsUsed; // Unity 5.3: PlayerSettings.GetGraphicsAPIs

		public bool EnableVirtualRealitySupport; // PlayerSettings.virtualRealitySupported


		// web player settings
		// ---------------------------------------------------------------

		public int WebPlayerDefaultScreenWidth; // PlayerSettings.defaultWebScreenWidth
		public int WebPlayerDefaultScreenHeight; // PlayerSettings.defaultWebScreenHeight

		public bool WebPlayerEnableStreaming; // EditorUserBuildSettings.webPlayerStreamed
		public bool WebPlayerDeployOffline; // EditorUserBuildSettings.webPlayerOfflineDeployment

		public int
			WebPlayerFirstStreamedLevelWithResources; // PlayerSettings.firstStreamedLevelWithResources. Removed in Unity 5.3


		// WebGL settings
		// ---------------------------------------------------------------
		public string WebGLOptimizationLevel; // EditorUserBuildSettings.webGLOptimizationLevel

		public bool WebGLUsePreBuiltUnityEngine; // EditorUserBuildSettings.webGLUsePreBuiltUnityEngine

		public string WebGLCompressionFormat; // PlayerSettings.WebGL.compressionFormat

		public bool WebGLAutoCacheAssetsData; // PlayerSettings.WebGL.dataCaching

		public bool WebGLCreateDebugSymbolsFile; // PlayerSettings.WebGL.debugSymbols

		public string WebGLExceptionSupportType; // PlayerSettings.WebGL.exceptionSupport

		public int WebGLMemorySize; // PlayerSettings.WebGL.memorySize

		public string WebGLTemplatePath; // PlayerSettings.WebGL.template


		// flash player settings
		// ---------------------------------------------------------------
		// Unity 5: Flash support is dropped

		//public string FlashBuildSubtarget; // EditorUserBuildSettings.flashBuildSubtarget


		// shared by web and desktop
		// ---------------------------------------------------------------
		public bool RunInBackground; // PlayerSettings.runInBackground


		// desktop (windows/mac/linux) build settings
		// ---------------------------------------------------------------

		public string StandaloneResolutionDialogSettingUsed; // PlayerSettings.displayResolutionDialog
		public string StandaloneFullScreenModeUsed; // PlayerSettings.fullScreenMode. Unity 2018.1

		public int StandaloneDefaultScreenWidth; // PlayerSettings.defaultScreenWidth
		public int StandaloneDefaultScreenHeight; // PlayerSettings.defaultScreenHeight

		public bool
			StandaloneFullScreenByDefault; // PlayerSettings.defaultIsFullScreen. Removed in Unity 2018 in favor of PlayerSettings.fullScreenMode

		public bool StandaloneAllowFullScreenSwitch; // PlayerSettings.allowFullscreenSwitch. Unity 5.3

		public bool StandaloneCaptureSingleScreen; // PlayerSettings.captureSingleScreen

		public bool StandaloneForceSingleInstance; // Unity 4: PlayerSettings.forceSingleInstance
		public bool StandaloneEnableResizableWindow; // Unity 4: PlayerSettings.resizableWindow


		public bool
			StandaloneUseStereoscopic3d; // PlayerSettings.stereoscopic3D. Removed in Unity 2017 in favor of VREditor.GetStereoDeviceEnabled


		// windows only build settings
		// ---------------------------------------------------------------

		public bool
			WinUseDirect3D11IfAvailable; // Unity 4: PlayerSettings.useDirect3D11. Removed in Unity 5.3 in favor of PlayerSettings.GetGraphicsAPIs

		public string
			WinDirect3D9FullscreenModeUsed; // PlayerSettings.d3d9FullscreenMode. Removed in Unity 2017. in 2018 use PlayerSettings.fullScreenMode

		public string
			WinDirect3D11FullscreenModeUsed; // PlayerSettings.d3d11FullscreenMode. Removed in Unity 2018 in favor of PlayerSettings.fullScreenMode


		// mac only build settings
		// ---------------------------------------------------------------

		public bool MacUseAppStoreValidation; // PlayerSettings.useMacAppStoreValidation

		public string
			MacFullscreenModeUsed; // PlayerSettings.macFullscreenMode. Removed in Unity 2018 in favor of PlayerSettings.fullScreenMode


		// Windows Store App only build settings
		// ---------------------------------------------------------------

		public bool WSAGenerateReferenceProjects; // EditorUserBuildSettings.metroGenerateReferenceProjects

		public string WSASDK; // EditorUserBuildSettings.wsaSDK


		// Mobile build settings
		// ---------------------------------------------------------------

		public string
			MobileBundleIdentifier; // PlayerSettings.bundleIdentifier ("Bundle Identifier" in iOS, "Package Identifier" in Android)

		public string
			MobileBundleVersion; // PlayerSettings.bundleVersion ("Bundle Version" in iOS, "Version Name" in Android)

		public bool MobileHideStatusBar; // PlayerSettings.statusBarHidden

		public int MobileAccelerometerFrequency; // PlayerSettings.accelerometerFrequency

		public string MobileDefaultOrientationUsed; // PlayerSettings.defaultInterfaceOrientation
		public bool MobileEnableAutorotateToPortrait; // PlayerSettings.allowedAutorotateToPortrait
		public bool MobileEnableAutorotateToReversePortrait; // PlayerSettings.allowedAutorotateToPortraitUpsideDown
		public bool MobileEnableAutorotateToLandscapeLeft; // PlayerSettings.allowedAutorotateToLandscapeLeft
		public bool MobileEnableAutorotateToLandscapeRight; // PlayerSettings.allowedAutorotateToLandscapeRight
		public bool MobileEnableOSAutorotation; // PlayerSettings.useOSAutorotation

		public bool Use32BitDisplayBuffer; // PlayerSettings.use32BitDisplayBuffer


		// iOS only build settings
		// ---------------------------------------------------------------

		// Unity 5: EditorUserBuildSettings.appendProject is removed
		public bool iOSAppendedToProject; // EditorUserBuildSettings.appendProject
		public bool iOSSymlinkLibraries; // EditorUserBuildSettings.symlinkLibraries

		public string iOSAppDisplayName; // PlayerSettings.iOS.applicationDisplayName

		public string iOSScriptCallOptimizationUsed; // PlayerSettings.iOS.scriptCallOptimization

		public string iOSSDKVersionUsed; // PlayerSettings.iOS.sdkVersion
		public string iOSTargetOSVersion; // PlayerSettings.iOS.targetOSVersion

		public string iOSTargetDevice; // PlayerSettings.iOS.targetDevice
		public string iOSTargetResolution; // PlayerSettings.iOS.targetResolution. Removed in Unity 5.3

		public bool iOSIsIconPrerendered; // PlayerSettings.iOS.prerenderedIcon

		public string iOSRequiresPersistentWiFi; // PlayerSettings.iOS.requiresPersistentWiFi

		public string iOSStatusBarStyle; // PlayerSettings.iOS.statusBarStyle


		// Unity 5: PlayerSettings.iOS.exitOnSuspend is replaced with PlayerSettings.iOS.appInBackgroundBehavior
		public bool iOSExitOnSuspend; // PlayerSettings.iOS.exitOnSuspend

		public string
			iOSAppInBackgroundBehavior; // PlayerSettings.iOS.appInBackgroundBehavior (undocumented as of Unity 5.0.0f4)


		public bool iOSLogObjCUncaughtExceptions; // PlayerSettings.logObjCUncaughtExceptions


		public string iOSShowProgressBarInLoadingScreen; // PlayerSettings.iOS.showActivityIndicatorOnLoading

		public string iOSTargetGraphics; // PlayerSettings.targetIOSGraphics. Removed in Unity 5.3


		// Android only build settings
		// ---------------------------------------------------------------

		public string AndroidBuildSubtarget; // EditorUserBuildSettings.androidBuildSubtarget

		public bool AndroidUseAPKExpansionFiles; // PlayerSettings.Android.useAPKExpansionFiles

		public bool AndroidAsAndroidProject; // EditorUserBuildSettings.exportAsGoogleAndroidProject

		public bool AndroidUseLicenseVerification; // PlayerSettings.Android.licenseVerification


		public bool AndroidIsGame; // Unity 5: PlayerSettings.Android.androidIsGame
		public bool AndroidTvCompatible; // Unity 5: PlayerSettings.Android.androidTVCompatibility


		// Unity 5: PlayerSettings.Android.use24BitDepthBuffer is replaced with PlayerSettings.Android.disableDepthAndStencilBuffers
		public bool AndroidUse24BitDepthBuffer; // PlayerSettings.Android.use24BitDepthBuffer
		public bool AndroidDisableDepthAndStencilBuffers; // PlayerSettings.Android.disableDepthAndStencilBuffers


		public int AndroidVersionCode; // PlayerSettings.Android.bundleVersionCode

		public string AndroidMinSDKVersion; // PlayerSettings.Android.minSdkVersion
		public string AndroidTargetDevice; // PlayerSettings.Android.targetDevice

		public string AndroidSplashScreenScaleMode; // PlayerSettings.Android.splashScreenScale

		public string AndroidPreferredInstallLocation; // PlayerSettings.Android.preferredInstallLocation

		public bool AndroidForceInternetPermission; // PlayerSettings.Android.forceInternetPermission
		public bool AndroidForceSDCardPermission; // PlayerSettings.Android.forceSDCardPermission

		public string AndroidShowProgressBarInLoadingScreen; // PlayerSettings.Android.showActivityIndicatorOnLoading

		public string AndroidKeyAliasName; // PlayerSettings.Android.keyaliasName
		public string AndroidKeystoreName; // PlayerSettings.Android.keystoreName


		// BlackBerry only build settings
		// ---------------------------------------------------------------

		public string BlackBerryBuildSubtarget; // EditorUserBuildSettings.blackberryBuildSubtarget
		public string BlackBerryBuildType; // EditorUserBuildSettings.blackberryBuildType

		// Unity 5: PlayerSettings.BlackBerry.authorId removed
		public string BlackBerryAuthorID; // PlayerSettings.BlackBerry.authorId
		public string BlackBerryDeviceAddress; // PlayerSettings.BlackBerry.deviceAddress

		public string BlackBerrySaveLogPath; // PlayerSettings.BlackBerry.saveLogPath
		public string BlackBerryTokenPath; // PlayerSettings.BlackBerry.tokenPath

		public string BlackBerryTokenAuthor; // PlayerSettings.BlackBerry.tokenAuthor
		public string BlackBerryTokenExpiration; // PlayerSettings.BlackBerry.tokenExpires

		public bool BlackBerryHasCamPermissions; // PlayerSettings.BlackBerry.HasCameraPermissions()
		public bool BlackBerryHasMicPermissions; // PlayerSettings.BlackBerry.HasMicrophonePermissions()
		public bool BlackBerryHasGpsPermissions; // PlayerSettings.BlackBerry.HasGPSPermissions()
		public bool BlackBerryHasIdPermissions; // PlayerSettings.BlackBerry.HasIdentificationPermissions()
		public bool BlackBerryHasSharedPermissions; // PlayerSettings.BlackBerry.HasSharedPermissions()


		// XBox 360 build settings
		// ---------------------------------------------------------------

		public string Xbox360BuildSubtarget; // EditorUserBuildSettings.xboxBuildSubtarget
		public string Xbox360RunMethod; // EditorUserBuildSettings.xboxRunMethod

		public string Xbox360TitleId; // PlayerSettings.xboxTitleId

		public string Xbox360ImageXexFilePath; // PlayerSettings.xboxImageXexFilePath
		public string Xbox360SpaFilePath; // PlayerSettings.xboxSpaFilePath

		public bool Xbox360AutoGenerateSpa; // PlayerSettings.xboxGenerateSpa

		public bool Xbox360EnableKinect; // PlayerSettings.xboxEnableKinect
		public bool Xbox360EnableKinectAutoTracking; // PlayerSettings.xboxEnableKinectAutoTracking
		public bool Xbox360EnableSpeech; // PlayerSettings.xboxEnableSpeech
		public bool Xbox360EnableAvatar; // PlayerSettings.xboxEnableAvatar

		public uint Xbox360SpeechDB; // PlayerSettings.xboxSpeechDB

		public int Xbox360AdditionalTitleMemSize; // PlayerSettings.xboxAdditionalTitleMemorySize

		public bool Xbox360DeployKinectResources; // PlayerSettings.xboxDeployKinectResources
		public bool Xbox360DeployKinectHeadOrientation; // PlayerSettings.xboxDeployKinectHeadOrientation
		public bool Xbox360DeployKinectHeadPosition; // PlayerSettings.xboxDeployKinectHeadPosition


		// XBox One build settings
		// ---------------------------------------------------------------

		public string XboxOneDeployMethod; // EditorUserBuildSettings.xboxOneDeployMethod
		public string XboxOneTitleId; // PlayerSettings.XboxOne.TitleId
		public string XboxOneContentId; // PlayerSettings.XboxOne.ContentId
		public string XboxOneProductId; // PlayerSettings.XboxOne.ProductId
		public string XboxOneSandboxId; // PlayerSettings.XboxOne.SandboxId
		public string XboxOneServiceConfigId; // PlayerSettings.XboxOne.SCID
		public string XboxOneVersion; // PlayerSettings.XboxOne.Version
		public bool XboxOneIsContentPackage; // PlayerSettings.XboxOne.IsContentPackage

		public string XboxOneDescription; // PlayerSettings.XboxOne.Description

		public string XboxOnePackagingEncryptionLevel; // PlayerSettings.XboxOne.PackagingEncryption

		public string[] XboxOneAllowedProductIds; // PlayerSettings.XboxOne.AllowedProductIds

		public bool XboxOneDisableKinectGpuReservation; // PlayerSettings.XboxOne.DisableKinectGpuReservation
		public bool XboxOneEnableVariableGPU; // PlayerSettings.XboxOne.EnableVariableGPU
		public int XboxOneStreamingInstallLaunchRange; // EditorUserBuildSettings.streamingInstallLaunchRange
		public uint XboxOnePersistentLocalStorageSize; // PlayerSettings.XboxOne.PersistentLocalStorageSize

		public string[] XboxOneSocketNames; // PlayerSettings.XboxOne.SocketNames

		public string XboxOneGameOsOverridePath; // PlayerSettings.XboxOne.GameOsOverridePath
		public string XboxOneAppManifestOverridePath; // PlayerSettings.XboxOne.AppManifestOverridePath
		public string XboxOnePackagingOverridePath; // PlayerSettings.XboxOne.PackagingOverridePath


		// used in PS3, but don't know which other Playstation platforms it also applies to
		public bool CompressBuildWithPsArc; // EditorUserBuildSettings.compressWithPsArc

		public bool NeedSubmissionMaterials; // EditorUserBuildSettings.needSubmissionMaterials

		// PS3 build settings
		// ---------------------------------------------------------------


		public string SCEBuildSubtarget; // EditorUserBuildSettings.sceBuildSubtarget

		// paths
		public string PS3TitleConfigFilePath; // PlayerSettings.ps3TitleConfigPath
		public string PS3DLCConfigFilePath; // PlayerSettings.ps3DLCConfigPath
		public string PS3ThumbnailFilePath; // PlayerSettings.ps3ThumbnailPath
		public string PS3BackgroundImageFilePath; // PlayerSettings.ps3BackgroundPath
		public string PS3BackgroundSoundFilePath; // PlayerSettings.ps3SoundPath
		public string PS3TrophyPackagePath; // PlayerSettings.ps3TrophyPackagePath

		public bool PS3InTrialMode; // PlayerSettings.ps3TrialMode
		public bool PS3DisableDolbyEncoding; // Unity 5: PlayerSettings.PS3.DisableDolbyEncoding
		public bool PS3EnableMoveSupport; // Unity 5: PlayerSettings.PS3.EnableMoveSupport
		public bool PS3UseSPUForUmbra; // Unity 5: PlayerSettings.PS3.UseSPUForUmbra
		public bool PS3EnableVerboseMemoryStats; // Unity 5: PlayerSettings.PS3.EnableVerboseMemoryStats

		public int PS3VideoMemoryForAudio; // Unity 5: PlayerSettings.PS3.videoMemoryForAudio
		public int PS3VideoMemoryForVertexBuffers; // PlayerSettings.PS3.videoMemoryForVertexBuffers
		public int PS3BootCheckMaxSaveGameSizeKB; // PlayerSettings.ps3BootCheckMaxSaveGameSizeKB

		public int PS3SaveGameSlots; // PlayerSettings.ps3SaveGameSlots

		public string PS3NpCommsId; // PlayerSettings.ps3TrophyCommId
		public string PS3NpCommsSig; // PlayerSettings.ps3TrophyCommSig
		public int PS3NpAgeRating; // Unity 5: PlayerSettings.PS3.npAgeRating


		// PS4 build settings
		// ---------------------------------------------------------------

		public string PS4BuildSubtarget; // EditorUserBuildSettings.ps4BuildSubtarget

		public int PS4AppParameter1; // PlayerSettings.PS4.applicationParameter1
		public int PS4AppParameter2; // PlayerSettings.PS4.applicationParameter2
		public int PS4AppParameter3; // PlayerSettings.PS4.applicationParameter3
		public int PS4AppParameter4; // PlayerSettings.PS4.applicationParameter4

		public int PS4AppType; // PlayerSettings.PS4.appType
		public string PS4AppVersion; // PlayerSettings.PS4.appVersion
		public string PS4Category; // PlayerSettings.PS4.category
		public string PS4ContentId; // PlayerSettings.PS4.contentID
		public string PS4MasterVersion; // PlayerSettings.PS4.masterVersion

		public string PS4EnterButtonAssignment; // PlayerSettings.PS4.enterButtonAssignment
		public string PS4RemotePlayKeyAssignment; // PlayerSettings.PS4.remotePlayKeyAssignment

		public string PS4VideoOutPixelFormat; // PlayerSettings.PS4.videoOutPixelFormat
		public string PS4VideoOutResolution; // PlayerSettings.PS4.videoOutResolution

		public string PS4MonoEnvVars; // PlayerSettings.PS4.monoEnv

		public string PS4NpAgeRating; // PlayerSettings.PS4.npAgeRating
		public string PS4ParentalLevel; // PlayerSettings.PS4.parentalLevel

		public bool PS4EnablePlayerPrefsSupport; // PlayerSettings.PS4.playerPrefsSupport

		public bool PS4EnableFriendPushNotifications; // PlayerSettings.PS4.pnFriends
		public bool PS4EnablePresencePushNotifications; // PlayerSettings.PS4.pnPresence
		public bool PS4EnableSessionPushNotifications; // PlayerSettings.PS4.pnSessions
		public bool PS4EnableGameCustomDataPushNotifications; // PlayerSettings.PS4.pnGameCustomData

		// paths
		public string PS4BgImagePath; // PlayerSettings.PS4.BackgroundImagePath
		public string PS4BgMusicPath; // PlayerSettings.PS4.BGMPath
		public string PS4StartupImagePath; // PlayerSettings.PS4.StartupImagePath
		public string PS4ParamSfxPath; // PlayerSettings.PS4.paramSfxPath
		public string PS4NpTitleDatPath; // PlayerSettings.PS4.NPtitleDatPath
		public string PS4NpTrophyPackagePath; // PlayerSettings.PS4.npTrophyPackPath
		public string PS4PronunciationSigPath; // PlayerSettings.PS4.PronunciationSIGPath
		public string PS4PronunciationXmlPath; // PlayerSettings.PS4.PronunciationXMLPath
		public string PS4SaveDataImagePath; // PlayerSettings.PS4.SaveDataImagePath
		public string PS4ShareFilePath; // PlayerSettings.PS4.ShareFilePath


		// PS Vita build settings
		// ---------------------------------------------------------------

		public string
			PSVTrophyPackagePath; // PlayerSettings.psp2NPTrophyPackPath (Unity 5: PlayerSettings.PSVita.npTrophyPackPath)

		public string PSVParamSfxPath; // PlayerSettings.psp2ParamSfxPath (Unity 5: PlayerSettings.PSVita.paramSfxPath)


		public string PSVNpCommsId; // PlayerSettings.psp2NPCommsID (Unity 5: PlayerSettings.PSVita.npCommunicationsID)
		public string PSVNpCommsSig; // PlayerSettings.psp2NPCommsSig (Unity 5: PlayerSettings.PSVita.npCommsSig)


		// new values in Unity 5:

		public string PSVBuildSubtarget; // EditorUserBuildSettings.psp2BuildSubtarget

		public string PSVShortTitle; // PlayerSettings.PSVita.shortTitle
		public string PSVAppVersion; // PlayerSettings.PSVita.appVersion
		public string PSVMasterVersion; // PlayerSettings.PSVita.masterVersion
		public string PSVAppCategory; // PlayerSettings.PSVita.category
		public string PSVContentId; // PlayerSettings.PSVita.contentID

		public string PSVNpAgeRating; // PlayerSettings.PSVita.npAgeRating
		public string PSVParentalLevel; // PlayerSettings.PSVita.parentalLevel

		public string PSVDrmType; // PlayerSettings.PSVita.drmType
		public bool PSVUpgradable; // PlayerSettings.PSVita.upgradable
		public string PSVTvBootMode; // PlayerSettings.PSVita.tvBootMode
		public bool PSVAcquireBgm; // PlayerSettings.PSVita.acquireBGM
		public bool PSVAllowTwitterDialog; // PlayerSettings.PSVita.AllowTwitterDialog

		public string PSVMediaCapacity; // PlayerSettings.PSVita.mediaCapacity
		public string PSVStorageType; // PlayerSettings.PSVita.storageType
		public bool PSVTvDisableEmu; // PlayerSettings.PSVita.tvDisableEmu
		public bool PSVNpSupportGbmOrGjp; // PlayerSettings.PSVita.npSupportGBMorGJP
		public string PSVPowerMode; // PlayerSettings.PSVita.powerMode
		public bool PSVUseLibLocation; // PlayerSettings.PSVita.useLibLocation

		public bool PSVHealthWarning; // PlayerSettings.PSVita.healthWarning
		public string PSVEnterButtonAssignment; // PlayerSettings.PSVita.enterButtonAssignment

		public bool PSVInfoBarColor; // PlayerSettings.PSVita.infoBarColor
		public bool PSVShowInfoBarOnStartup; // PlayerSettings.PSVita.infoBarOnStartup
		public int PSVSaveDataQuota; // PlayerSettings.PSVita.saveDataQuota

		// paths
		public string PSVPatchChangeInfoPath; // PlayerSettings.PSVita.patchChangeInfoPath
		public string PSVPatchOriginalPackPath; // PlayerSettings.PSVita.patchOriginalPackage
		public string PSVKeystoneFilePath; // PlayerSettings.PSVita.keystoneFile
		public string PSVLiveAreaBgImagePath; // PlayerSettings.PSVita.liveAreaBackroundPath
		public string PSVLiveAreaGateImagePath; // PlayerSettings.PSVita.liveAreaGatePath
		public string PSVCustomLiveAreaPath; // PlayerSettings.PSVita.liveAreaPath
		public string PSVLiveAreaTrialPath; // PlayerSettings.PSVita.liveAreaTrialPath

		public string PSVManualPath; // PlayerSettings.PSVita.manualPath


		// Samsung TV build settings
		// ---------------------------------------------------------------

		public string SamsungTVDeviceAddress; // PlayerSettings.SamsungTV.deviceAddress
		public string SamsungTVAuthor; // PlayerSettings.SamsungTV.productAuthor
		public string SamsungTVAuthorEmail; // PlayerSettings.SamsungTV.productAuthorEmail
		public string SamsungTVAuthorWebsiteUrl; // PlayerSettings.SamsungTV.productLink
		public string SamsungTVCategory; // PlayerSettings.SamsungTV.productCategory
		public string SamsungTVDescription; // PlayerSettings.SamsungTV.productDescription


		// Derived Values
		// ---------------------------------------------------------------


		public bool HasValues
		{
			get { return !string.IsNullOrEmpty(CompanyName) && !string.IsNullOrEmpty(NETApiCompatibilityLevel); }
		}
	}
}