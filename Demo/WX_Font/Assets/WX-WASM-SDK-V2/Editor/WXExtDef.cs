using System.Collections;
using System.Collections.Generic;
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
#if UNITY_INSTANTGAME
            WXExtEnvDef.SETDEF("UNITY_INSTANTGAME", true);
#else
            WXExtEnvDef.SETDEF("UNITY_INSTANTGAME", false);
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

            WXExtEnvDef.RegisterAction("WXEditorWindow.Build", (args) =>
            {
#if UNITY_2021_2_OR_NEWER
#if UNITY_2022_1_OR_NEWER
                // 默认更改为OptimizeSize，减少代码包体积
                PlayerSettings.SetIl2CppCodeGeneration(UnityEditor.Build.NamedBuildTarget.WebGL, Il2CppCodeGeneration.OptimizeSize);
#else
                EditorUserBuildSettings.il2CppCodeGeneration = UnityEditor.Build.Il2CppCodeGeneration.OptimizeSize;
#endif
#endif
                return null;
            });
        }
    }
}