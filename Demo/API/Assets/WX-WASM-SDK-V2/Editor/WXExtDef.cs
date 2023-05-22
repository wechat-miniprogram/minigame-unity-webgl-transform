using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
            RegisterController();
        }

        private static void RegisterController()
        {
            WXExtEnvDef.RegisterAction("WXEditorWindow.Init", (args) =>
            {
#if UNITY_2021_2_OR_NEWER
                PlayerSettings.WebGL.debugSymbolMode = WebGLDebugSymbolMode.Embedded;
#else
                PlayerSettings.WebGL.debugSymbols = true;
#endif
                return null;
            });

            WXExtEnvDef.RegisterAction("WXEditorWindow.Build", (args) =>
            {
#if UNITY_2021_2_OR_NEWER
            // 默认更改为OptimizeSize，减少代码包体积
            EditorUserBuildSettings.il2CppCodeGeneration = UnityEditor.Build.Il2CppCodeGeneration.OptimizeSize;
#endif
                return null;
            });
        }
    }
}