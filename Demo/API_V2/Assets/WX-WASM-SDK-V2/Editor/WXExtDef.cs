using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace WeChatWASM
{
    // WX-EXT-DEF
    [InitializeOnLoad]
    public class WXExtDef
    {
        static WXExtDef()
        {
            Init();
        }

        private static void Init()
        {
            WXExtEnvDef.pluginVersion = WXPluginVersion.pluginVersion;
#if UNITY_2018_1_OR_NEWER
            WXExtEnvDef.SETDEF("UNITY_2018_1_OR_NEWER", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2018_1_OR_NEWER", false);
#endif

#if UNITY_2020_1_OR_NEWER
            WXExtEnvDef.SETDEF("UNITY_2020_1_OR_NEWER", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2020_1_OR_NEWER", false);
#endif

#if UNITY_2021_1_OR_NEWER
            WXExtEnvDef.SETDEF("UNITY_2021_1_OR_NEWER", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2021_1_OR_NEWER", false);
#endif
#if UNITY_2021_2_OR_NEWER
            WXExtEnvDef.SETDEF("UNITY_2021_2_OR_NEWER", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2021_2_OR_NEWER", false);
#endif
#if UNITY_2021_3_OR_NEWER
            WXExtEnvDef.SETDEF("UNITY_2021_3_OR_NEWER", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2021_3_OR_NEWER", false);
#endif
#if UNITY_EDITOR_OSX
            WXExtEnvDef.SETDEF("UNITY_EDITOR_OSX", true);
#else
            WXExtEnvDef.SETDEF("UNITY_EDITOR_OSX", false);
#endif
#if UNITY_EDITOR_LINUX
            WXExtEnvDef.SETDEF("UNITY_EDITOR_LINUX", true);
#else
            WXExtEnvDef.SETDEF("UNITY_EDITOR_LINUX", false);
#endif
#if UNITY_2020
            WXExtEnvDef.SETDEF("UNITY_2020", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2020", false);
#endif
#if UNITY_2021
            WXExtEnvDef.SETDEF("UNITY_2021", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2021", false);
#endif
#if UNITY_2022
            WXExtEnvDef.SETDEF("UNITY_2022", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2022", false);
#endif
#if UNITY_2022_2_OR_NEWER
            WXExtEnvDef.SETDEF("UNITY_2022_2_OR_NEWER", true);
#else
            WXExtEnvDef.SETDEF("UNITY_2022_2_OR_NEWER", false);
#endif
#if UNITY_INSTANTGAME
            WXExtEnvDef.SETDEF("UNITY_INSTANTGAME", true);
#else
            WXExtEnvDef.SETDEF("UNITY_INSTANTGAME", false);
#endif
#if WEIXINMINIGAME
            WXExtEnvDef.SETDEF("WEIXINMINIGAME", true);
#else
            WXExtEnvDef.SETDEF("WEIXINMINIGAME", false);
#endif
#if TUANJIE_2022_3_OR_NEWER
            WXExtEnvDef.SETDEF("TUANJIE_2022_3_OR_NEWER", true);
#else
            WXExtEnvDef.SETDEF("TUANJIE_2022_3_OR_NEWER", false);
#endif
#if PLATFORM_WEIXINMINIGAME
            WXExtEnvDef.SETDEF("PLATFORM_WEIXINMINIGAME", true);
#else
            WXExtEnvDef.SETDEF("PLATFORM_WEIXINMINIGAME", false);
#endif
            RegisterController();
        }

        private static void RegisterController()
        {
            //             WXExtEnvDef.RegisterAction("WXEditorWindow.Init", (args) =>
            //             {
            // #if UNITY_2021_2_OR_NEWER
            //                 PlayerSettings.WebGL.debugSymbolMode = WebGLDebugSymbolMode.External;
            // #else
            //                 PlayerSettings.WebGL.debugSymbols = true;
            // #endif
            //                 return null;
            //             });
            WXExtEnvDef.RegisterAction("WXConvertCore.UseIL2CPP", (args) =>
            {
                return WXConvertCore.UseIL2CPP;
            });
            WXExtEnvDef.RegisterAction("UnityUtil.GetWxSDKRootPath", (args) =>
            {
#if UNITY_2018
                return Path.Combine(Application.dataPath, "WX-WASM-SDK-V2");
#else
                var packageInfo = UnityEditor.PackageManager.PackageInfo.FindForAssembly(typeof(WXExtEnvDef).Assembly);
                if (packageInfo == null)
                {
                    return Path.Combine(Application.dataPath, "WX-WASM-SDK-V2");
                }
                string packagePath = packageInfo.assetPath;
                if (packageInfo.name == "WXSDK")
                {
                    packagePath += "/Resources";
                }
                DirectoryInfo dir = new DirectoryInfo(packagePath);
                return dir.FullName;
#endif
            });
            WXExtEnvDef.RegisterAction("UnityUtil.IsAssets", (args) =>
            {
#if UNITY_2018
                return true;
#else
                var packageInfo = UnityEditor.PackageManager.PackageInfo.FindForAssembly(typeof(WXExtEnvDef).Assembly);
                if (packageInfo == null)
                {
                    return true;
                }
                return false;
#endif
            });
        }
    }
}