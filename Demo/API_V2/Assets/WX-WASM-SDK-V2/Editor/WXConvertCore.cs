using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using LitJson;
using UnityEditor.Build;
using System.Linq;

namespace WeChatWASM
{
    public class WXConvertCore
    {

        static WXConvertCore()
        {
            // Init();
        }

        public static void Init()
        {
            SDKFilePath = Path.Combine(UnityUtil.GetWxSDKRootPath(), "Runtime", "wechat-default", "unity-sdk", "index.js");
            string templateHeader = "PROJECT:";
#if TUANJIE_2022_3_OR_NEWER
            PlayerSettings.WeixinMiniGame.threadsSupport = false;
            PlayerSettings.runInBackground = false;
            PlayerSettings.WeixinMiniGame.compressionFormat = WeixinMiniGameCompressionFormat.Disabled;
            if(UnityUtil.GetEngineVersion() == UnityUtil.EngineVersion.Tuanjie)
            {
                var absolutePath = Path.GetFullPath("Packages/com.qq.weixin.minigame/WebGLTemplates/WXTemplate2022TJ");
                PlayerSettings.WeixinMiniGame.template = $"PATH:{absolutePath}";
            }
            else
            {
                PlayerSettings.WeixinMiniGame.template = $"{templateHeader}WXTemplate2022TJ";
            }
            PlayerSettings.WeixinMiniGame.linkerTarget = WeixinMiniGameLinkerTarget.Wasm;
            PlayerSettings.WeixinMiniGame.dataCaching = false;
            PlayerSettings.WeixinMiniGame.debugSymbolMode = WeixinMiniGameDebugSymbolMode.External;
#else
            PlayerSettings.WebGL.threadsSupport = false;
            PlayerSettings.runInBackground = false;
            PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
#if UNITY_2022_3_OR_NEWER
        PlayerSettings.WebGL.template = $"{templateHeader}WXTemplate2022";
#elif UNITY_2020_1_OR_NEWER
            PlayerSettings.WebGL.template = $"{templateHeader}WXTemplate2020";
#else
            PlayerSettings.WebGL.template = $"{templateHeader}WXTemplate";
#endif
            PlayerSettings.WebGL.linkerTarget = WebGLLinkerTarget.Wasm;
            PlayerSettings.WebGL.dataCaching = false;
#if UNITY_2021_2_OR_NEWER
            PlayerSettings.WebGL.debugSymbolMode = WebGLDebugSymbolMode.External;
#else
            PlayerSettings.WebGL.debugSymbols = true;
#endif
#endif
            EditorSettings.spritePackerMode = SpritePackerMode.AlwaysOnAtlas;
        }

        public enum WXExportError
        {
            SUCCEED = 0,
            NODE_NOT_FOUND = 1,
            BUILD_WEBGL_FAILED = 2,
        }

        public static WXEditorScriptObject config => UnityUtil.GetEditorConf();
        public static string webglDir = "webgl"; // 导出的webgl目录
        public static string miniGameDir = "minigame"; // 生成小游戏的目录
        public static string audioDir = "Assets"; // 音频资源目录
        public static string frameworkDir = "framework";
        public static string dataFileSize = string.Empty;
        public static string codeMd5 = string.Empty;
        public static string dataMd5 = string.Empty;
        private static string SDKFilePath = string.Empty;
        public static string defaultImgSrc = "Assets/WX-WASM-SDK-V2/Runtime/wechat-default/images/background.jpg";
        public static bool UseIL2CPP
        {
            get
            {
#if TUANJIE_2022_3_OR_NEWER
                return PlayerSettings.GetScriptingBackend(BuildTargetGroup.WeixinMiniGame) == ScriptingImplementation.IL2CPP;
#else
                return true;
#endif
            }
        }
        // 可以调用这个来集成
        public static WXExportError DoExport(bool buildWebGL = true)
        {
            if (!CheckSDK())
            {
                Debug.LogError("若游戏曾使用旧版本微信SDK，需删除 Assets/WX-WASM-SDK 文件夹后再导入最新工具包。");
                return WXExportError.BUILD_WEBGL_FAILED;
            }
            CheckBuildTarget();
            Init();
            // JSLib
            SettingWXTextureMinJSLib();
            UpdateGraphicAPI();
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();

            if (config.ProjectConf.DST == string.Empty)
            {
                Debug.LogError("请先配置游戏导出路径");
                return WXExportError.BUILD_WEBGL_FAILED;
            }
            else
            {
                // 仅删除StreamingAssets目录
                if (config.CompileOptions.DeleteStreamingAssets)
                {
                    UnityUtil.DelectDir(Path.Combine(config.ProjectConf.DST, webglDir + "/StreamingAssets"));
                }

                if (buildWebGL && Build() != 0)
                {
                    return WXExportError.BUILD_WEBGL_FAILED;
                }

                if (WXExtEnvDef.GETDEF("UNITY_2021_2_OR_NEWER") && !config.CompileOptions.DevelopBuild)
                {
                    // 如果是2021版本，官方symbols产生有BUG，这里需要用工具将函数名提取出来
                    var symFile1 = "";
                    if(!UseIL2CPP)
                    {
                        symFile1 = Path.Combine(config.ProjectConf.DST, webglDir, "Code", "wwwroot", "_framework", "dotnet.native.js.symbols");
                    }
                    else
                    {
                        var rootPath = Directory.GetParent(Application.dataPath).FullName;
                        string webglDir = WXExtEnvDef.GETDEF("WEIXINMINIGAME") ? "WeixinMiniGame" : "WebGL";
                        symFile1 = Path.Combine(rootPath, "Library", "Bee", "artifacts", webglDir, "build", "debug_WebGL_wasm", "build.js.symbols");
                    }
                    WeChatWASM.UnityUtil.preprocessSymbols(symFile1, GetWebGLSymbolPath());
                    // WeChatWASM.UnityUtil.preprocessSymbols(GetWebGLSymbolPath());
                }

                ConvertCode();
                if (!UseIL2CPP)
                {
                    ConvertDotnetCode();
                }
                string dataFilePath = GetWebGLDataPath();
                string wxTextDataDir = WXAssetsTextTools.GetTextMinDataDir();
                string dataFilePathBackupDir = $"{wxTextDataDir}{WXAssetsTextTools.DS}slim";
                string dataFilePathBackupPath = $"{dataFilePathBackupDir}{WXAssetsTextTools.DS}backup.txt";
                if (!Directory.Exists(dataFilePathBackupDir))
                {
                    Directory.CreateDirectory(dataFilePathBackupDir);
                }
                if (File.Exists(dataFilePathBackupPath))
                {
                    File.Delete(dataFilePathBackupPath);
                }
                File.Copy(dataFilePath, dataFilePathBackupPath);

                if (UseIL2CPP && config.CompileOptions.fbslim && !IsInstantGameAutoStreaming())
                {
                    WXAssetsTextTools.FirstBundleSlim(dataFilePath, (result, info) =>
                    {
                        if (!result)
                        {
                            Debug.LogWarning("[首资源包跳过优化]：因处理失败自动跳过" + info);
                        }

                        finishExport();
                    });
                }
                else
                {
                    finishExport();
                }
            }
            return WXExportError.SUCCEED;
        }

        private static void CheckBuildTarget()
        {
            if (UnityUtil.GetEngineVersion() == UnityUtil.EngineVersion.Unity)
            {
                EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);
            }
            else
            {
#if TUANJIE_2022_3_OR_NEWER
                EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WeixinMiniGame, BuildTarget.WeixinMiniGame);
#endif
            }
        }

        public static void UpdateGraphicAPI()
        {
            GraphicsDeviceType[] targets = new GraphicsDeviceType[] { };
#if PLATFORM_WEIXINMINIGAME
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.WeixinMiniGame, false);
            if (config.CompileOptions.Webgl2)
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.WeixinMiniGame, new GraphicsDeviceType[] { GraphicsDeviceType.OpenGLES3 });
            }
            else
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.WeixinMiniGame, new GraphicsDeviceType[] { GraphicsDeviceType.OpenGLES2 });
            }
#else
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.WebGL, false);
            if (config.CompileOptions.Webgl2)
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, new GraphicsDeviceType[] { GraphicsDeviceType.OpenGLES3 });
            }
            else
            {
                PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, new GraphicsDeviceType[] { GraphicsDeviceType.OpenGLES2 });
            }
#endif
        }

        /// <summary>
        /// 移除输入js代码字符串中所有以prefix为前缀的函数的函数体，function与函数名之间仅允许有一个空格
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="prefix">函数前缀</param>
        /// <returns>处理后的字符串</returns>
        public static string RemoveFunctionsWithPrefix(string input, string prefix)
        {
            StringBuilder output = new StringBuilder();

            int braceCount = 0;
            int lastIndex = 0;
            int index = input.IndexOf("function " + prefix);

            while (index != -1)
            {
                output.Append(input, lastIndex, index - lastIndex);
                lastIndex = index;

                while (input[lastIndex] != '{')
                {
                    lastIndex++;
                }

                braceCount = 1;
                ++lastIndex;

                while (braceCount > 0)
                {
                    if (input[lastIndex] == '{')
                    {
                        ++braceCount;
                    }
                    else if (input[lastIndex] == '}')
                    {
                        --braceCount;
                    }
                    ++lastIndex;
                }

                index = input.IndexOf("function " + prefix, lastIndex);
            }

            output.Append(input, lastIndex, input.Length - lastIndex);

            return output.ToString();
        }

        
        private static void ConvertDotnetCode()
        {
            CompressAssemblyBrotli();
            ConvertDotnetRuntimeCode();
            ConvertDotnetFrameworkCode();
        }

        private static void ConvertDotnetRuntimeCode()
        {
            var runtimePath = GetWeixinMiniGameFilePath("jsModuleRuntime")[0];
            var dotnetJs = File.ReadAllText(runtimePath, Encoding.UTF8);

            Rule[] rules =
            {
                new Rule()
                {
                    old = "await *WebAssembly\\.instantiate\\(\\w*,",
                    newStr = $"await WebAssembly.instantiate(Module[\"wasmPath\"],",
                },
                new Rule()
                {
                    old = "['\"]Expected methodFullName if trace is instrumented['\"]\\);?",
                    newStr = "'Expected methodFullName if trace is instrumented'); return;",
                }
            };
            foreach (var rule in rules)
            {
                if (ShowMatchFailedWarning(dotnetJs, rule.old, "runtime") == false) {
                    dotnetJs = Regex.Replace(dotnetJs, rule.old, rule.newStr);
                }
            }

            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, frameworkDir, Path.GetFileName(runtimePath)), dotnetJs, new UTF8Encoding(false));
        }

        private static void CompressAssemblyBrotli()
        {
            GetWeixinMiniGameFilePath("assembly").ToList().ForEach(assembly => UnityUtil.brotli(assembly, assembly + ".br", "8"));
        }

        private static void ConvertDotnetFrameworkCode()
        {
            var target = "webgl.wasm.framework.unityweb.js";
            var dotnetJsPath =
                Path.Combine(config.ProjectConf.DST, webglDir, "Code", "wwwroot", "_framework", "dotnet.js");
            var dotnetJs = File.ReadAllText(dotnetJsPath, Encoding.UTF8);
            // todo: handle dotnet js
            Rule[] rules =
                {
                    new Rule()
                    {
                        old = "import\\.meta\\.url",
                        newStr = $"pathToFileURL('/{frameworkDir}/webgl.wasm.framework.unityweb.js')",
                    },
                    new Rule()
                    {
                        old = " *(\\w*) *= *(\\w*)\\(\"js-module-runtime\"\\) *, *(\\w*) *= *(\\w*)\\(\"js-module-native\"\\)",
                        newStr = $" $1 = $2(\"js-module-runtime\"), $3 = $4(\"js-module-native\"); $1.resolvedUrl = \"{Path.GetFileName(GetWeixinMiniGameFilePath("jsModuleRuntime")[0])}\";$3.resolvedUrl = \"{Path.GetFileName(GetWeixinMiniGameFilePath("jsModuleNative")[0])}\";",
                    },
                    new Rule()
                    {
                        old = "export *\\{ *(.*) *as *default *,(.*) *as *dotnet *,(.*) *as *exit *\\} *;",
                        newStr = "return {legacyEntrypoint: $1, dotnet: $2, exit: $3}",
                    },
                    new Rule()
                    { // add symbol property for monoToBlazorAssetTypeMap
                        old = "\"js-module-runtime\": *\"dotnetjs\", *\"js-module-threads\": *\"dotnetjs\"",
                        newStr = "\"js-module-runtime\": \"dotnetjs\", \"js-module-threads\": \"dotnetjs\", \"symbols\": \"symbols\"",
                    },
                    new Rule()
                    {
                        old = "_e *\\|\\| *\"function\" *== *typeof *globalThis.URL[\\s\\S]*asm-features\"\\);",
                        newStr = ""
                    },
                    new Rule()
                    {
                        old = "if *\\(!\\(ENVIRONMENT_IS_SHELL *\\|\\| *typeof *globalThis.URL *=== *\"function\"\\)\\)[\\s\\S]*BigInt64Array *API. *Please *use *a *modern *version. *See *also *https:\\/\\/aka.ms\\/dotnet\\-wasm\\-features\"\\);",
                        newStr = ""
                    }
                };
            foreach (var rule in rules)
            {
                if (ShowMatchFailedWarning(dotnetJs, rule.old, "dotnet") == false) {
                    dotnetJs = Regex.Replace(dotnetJs, rule.old, rule.newStr);
                }
            }
            var header = @"WebAssembly.validate = () => true;
const dotnet = (function () {";
            var footer = @"})();

function pathToFileURL(path) {
    return `file://${path}`;
}

const wxFetchFile = async (url, config) => new Promise((resolve, reject) => {
    const folderPath = `${GameGlobal.manager.PLUGIN_CACHE_PATH}/${config.hash}`;
    const filePath = `${folderPath}/${config.filename}`;
    const fs = wx.getFileSystemManager();
    var readFile = fs.readFile;
    const readFileInfo = {
        filePath: filePath,
        success: async (res) => {
            resolve(res.data);
        },
        fail: (err) => {
            reject(err);
        }
    }
    if (config.brotli) {
        readFile = fs.readCompressedFile;
        readFileInfo.compressionAlgorithm = 'br';
    }
    const downloadFileInfo = {
        url: url,
        success: (res) => {
            if (res.statusCode === 200) {
                try {
                    fs.accessSync(folderPath);
                } catch (e) {
                    fs.mkdirSync(folderPath, true);
                }
                saveFile(res.tempFilePath, filePath, res.dataLength);
            } else {
                reject(res);
            }
        },
        fail: (err) => {
            reject(err);
        }
    };
    const saveFile = (tempFilePath, filePath, dataLength, retry = 0) => {
        try {
            fs.saveFileSync(tempFilePath, filePath);
            readFile(readFileInfo);
        } catch (e) {
            if (e.message === 'saveFileSync:fail exceeded the maximum size of the file storage limit') {
                if (retry < 3) {
                    GameGlobal.manager.cleanCache(dataLength).then(() => {
                        saveFile(tempFilePath, filePath, dataLength, ++retry);
                    });
                } else {
                    GameGlobal.manager.cleanAllCache().then(() => {
                        wx.downloadFile(downloadFileInfo);
                    });
                }
            } else {
                reject(e);
            }
        }
    };
    // if not use cache or cache not exists, download file
    fs.access({
        path: filePath,
        success: (res) => {
            if (config.cache && res.errMsg === 'access:ok') {
                readFile(readFileInfo);
            } else {
                wx.downloadFile(downloadFileInfo);
            }
        },
        fail: (err) => {
            wx.downloadFile(downloadFileInfo);
        }
    });
});

dotnet.dotnet.withResourceLoader((resourceType, assetName, url, requestHash, behavior) => {
    const remoteUrl = `${GameGlobal.unityNamespace.DATA_CDN}Code/wwwroot/_framework/${assetName}`;
    switch (resourceType) {
        case 'dotnetjs':
            return assetName;
        case 'manifest':
            return new Promise((resolve, reject) => {
                wx.request({
                    url: remoteUrl,
                    success: (res) => {
                        resolve({
                            json: async () => res.data,
                            headers: {
                                get: () => undefined
                            }
                        });
                    },
                    fail: (err) => {
                        reject(err);
                    }
                });
            });
        case 'symbols':
        case 'dotnetwasm':
            return new Promise((resolve, reject) => {
                resolve({
                    arrayBuffer: async () => undefined,
                    status: 200,
                    ok: true
                })
            });
        case 'assembly':
            const config = {
                filename: assetName + '.br',
                cache: true,
                hash: requestHash,
                brotli: true
            };
            return wxFetchFile(remoteUrl + '.br', config).then(res => ({
                arrayBuffer: async () => res,
                status: 200,
                ok: true,
            }));
        default:
            return url;
    }
});
var executed = false;
var unityFramework = function (module) {
    if (executed) return;
    executed = true;
    module['noInitialRun'] = true;
    return (dotnet.legacyEntrypoint(module)).then(() => {
        module['callMain']();
    });
};
if (typeof exports === 'object' && typeof module === 'object') module.exports = unityFramework;
else if (typeof define === 'function' && define['amd']) define([], function () {
    return unityFramework;
});
else if (typeof exports === 'object') exports['unityFramework'] = unityFramework;
GameGlobal.unityNamespace.UnityModule = unityFramework;";
            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, frameworkDir, target), header + dotnetJs + footer, new UTF8Encoding(false));
        }

        private static void ConvertCode()
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to adapt framework. Dst: " + config.ProjectConf.DST);

            UnityUtil.DelectDir(Path.Combine(config.ProjectConf.DST, miniGameDir));
            string text = String.Empty;
            var target = "webgl.wasm.framework.unityweb.js";
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                if (UseIL2CPP)
                {
                    text = File.ReadAllText(Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.framework.js"), Encoding.UTF8);
                }
                else
                {
                    var frameworkPath = GetWeixinMiniGameFilePath("jsModuleNative")[0];
                    target = Path.GetFileName(frameworkPath);
                    text = File.ReadAllText(frameworkPath, Encoding.UTF8);
                }
            }
            else
            {
                text = File.ReadAllText(Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.wasm.framework.unityweb"), Encoding.UTF8);
            }
            int i;
            for (i = 0; i < ReplaceRules.rules.Length; i++)
            {
                var rule = ReplaceRules.rules[i];
                // text = Regex.Replace(text, rule.old, rule.newStr);
                if (ShowMatchFailedWarning(text, rule.old, "WXReplaceRules") == false) {
                    text = Regex.Replace(text, rule.old, rule.newStr);
                }
            }
           string[] prefixs =
            {
                "_JS_Video_",
                //"jsVideo",
                "_JS_Sound_",
                "jsAudio",
                "_JS_MobileKeyboard_",
                "_JS_MobileKeybard_"
            };
            foreach (var prefix in prefixs)
            {
                text = RemoveFunctionsWithPrefix(text, prefix);
            }
#if PLATFORM_WEIXINMINIGAME
            if (PlayerSettings.WeixinMiniGame.exceptionSupport == WeixinMiniGameExceptionSupport.None)
#else
            if (PlayerSettings.WebGL.exceptionSupport == WebGLExceptionSupport.None)
#endif
            {
                Rule[] rules =
                {
                    new Rule()
                    {
                        old = "console.log\\(\"Exception at",
                        newStr = "if(Module.IsWxGame);console.log(\"Exception at",
                    },
                    new Rule()
                    {
                        old = "throw ptr",
                        newStr = "if(Module.IsWxGame)window.WXWASMSDK.WXUncaughtException(true);else throw ptr",
                    },
                };
                foreach (var rule in rules)
                {
                    text = Regex.Replace(text, rule.old, rule.newStr);
                }
            }

            if (text.Contains("UnityModule"))
            {
                text += ";GameGlobal.unityNamespace.UnityModule = UnityModule;";
            }
            else if (text.Contains("unityFramework"))
            {
                text += ";GameGlobal.unityNamespace.UnityModule = unityFramework;";
            }
            else if (text.Contains("tuanjieFramework"))
            {
                text += ";GameGlobal.unityNamespace.UnityModule = tuanjieFramework;";
            }
            else if (UseIL2CPP)
            {
                if (text.StartsWith("(") && text.EndsWith(")"))
                {
                    text = text.Substring(1, text.Length - 2);
                }

                text = "GameGlobal.unityNamespace.UnityModule = " + text;
            }

            if (!Directory.Exists(Path.Combine(config.ProjectConf.DST, miniGameDir)))
            {
                Directory.CreateDirectory(Path.Combine(config.ProjectConf.DST, miniGameDir));
            }

            if (!Directory.Exists(Path.Combine(config.ProjectConf.DST, miniGameDir, frameworkDir)))
            {
                Directory.CreateDirectory(Path.Combine(config.ProjectConf.DST, miniGameDir, frameworkDir));
            }

            var header = "var OriginalAudioContext = window.AudioContext || window.webkitAudioContext;window.AudioContext = function() {if (this instanceof window.AudioContext) {return wx.createWebAudioContext();} else {return new OriginalAudioContext();}};";
            
            if (config.CompileOptions.DevelopBuild)
            {
                header = header + RenderAnalysisRules.header;
                for (i = 0; i < RenderAnalysisRules.rules.Length; i++)
                {
                    var rule = RenderAnalysisRules.rules[i];
                    text = Regex.Replace(text, rule.old, rule.newStr);
                }
            }

            text = header + text;

            var targetPath = Path.Combine(config.ProjectConf.DST, miniGameDir, target);
            if (!UseIL2CPP)
            {
                targetPath = Path.Combine(config.ProjectConf.DST, miniGameDir, frameworkDir, target);
                Rule[] nativeRules =
                {
                    new Rule()
                    {
                        old = "if\\(Module\\.IsWxGame\\)return Math\\.random\\(\\)\\*256\\|0;abort\\(\"randomDevice\"\\)",
                        newStr = "{if(Module.IsWxGame)return Math.random()*256|0;abort(\"randomDevice\")}"
                    },
                    new Rule()
                    {
                        old = "var *_scriptDir *= *import\\.meta\\.url;",
                        newStr = $"var _scriptDir = \"file:///framework/webgl.wasm.framework.unityweb.js\"",
                    },
                    new Rule()
                    {
                        old = "import\\.meta\\.url",
                        newStr = "_scriptDir"
                    },
                    new Rule()
                    {
                        old = "Module\\[['\"](HEAP[U,F,1-9]*)['\"]\\] *=",
                        newStr = "Module['$1'] = GameGlobal.unityNamespace.Module['$1'] =",
                    },
                    new Rule()
                    {
                        old = "return *handleException\\(e\\);?",
                        newStr = "return handleException(e);} finally {if (ABORT === true) return; if (Module.calledMainCb) Module.calledMainCb(); if (GameGlobal.unityNamespace.enableProfileStats) {setTimeout(() => {SendMessage('WXSDKManagerHandler', 'OpenProfileStats');}, 10000);}"
                    },
                    new Rule()
                    {
                        old = "function *callMain\\(args *= *\\[\\]\\)",
                        newStr = "Object.keys(Module).forEach(key=>{if(!(key in Object.keys(GameGlobal.unityNamespace.Module))){GameGlobal.unityNamespace.Module[key]=Module[key];}});function callMain(args = [])"
                    },
                };
                foreach (var rule in nativeRules)
                {
                    if (ShowMatchFailedWarning(text, rule.old, "native") == false) {
                        text = Regex.Replace(text, rule.old, rule.newStr);
                    } 
                }
            }

            File.WriteAllText(targetPath, text, new UTF8Encoding(false));

            UnityEngine.Debug.LogFormat("[Converter]  adapt framework done! ");
        }

        private static int Build()
        {
#if PLATFORM_WEIXINMINIGAME
            PlayerSettings.WeixinMiniGame.emscriptenArgs = string.Empty;
            if (WXExtEnvDef.GETDEF("UNITY_2021_2_OR_NEWER"))
            {
                // PlayerSettings.WeixinMiniGame.emscriptenArgs += " -s EXPORTED_FUNCTIONS=_main,_sbrk,_emscripten_stack_get_base,_emscripten_stack_get_end";
                PlayerSettings.WeixinMiniGame.emscriptenArgs += " -s EXPORTED_FUNCTIONS=_sbrk,_emscripten_stack_get_base,_emscripten_stack_get_end -s ERROR_ON_UNDEFINED_SYMBOLS=0";
            }

#else
            PlayerSettings.WebGL.emscriptenArgs = string.Empty;
            if (WXExtEnvDef.GETDEF("UNITY_2021_2_OR_NEWER"))
            {
                PlayerSettings.WebGL.emscriptenArgs += " -s EXPORTED_FUNCTIONS=_sbrk,_emscripten_stack_get_base,_emscripten_stack_get_end -s ERROR_ON_UNDEFINED_SYMBOLS=0";
#if UNITY_2021_2_5
                    PlayerSettings.WebGL.emscriptenArgs += ",_main";
#endif
            }
#endif
            PlayerSettings.runInBackground = false;
            if (config.ProjectConf.MemorySize != 0)
            {
                if (config.ProjectConf.MemorySize >= 1024)
                {
                    UnityEngine.Debug.LogErrorFormat($"UnityHeap必须小于1024，请查看GIT文档<a href=\"https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/OptimizationMemory.md\">优化Unity WebGL的内存</a>");
                    return -1;
                }
                else if (config.ProjectConf.MemorySize >= 500)
                {
                    UnityEngine.Debug.LogWarningFormat($"UnityHeap大于500M时，32位Android与iOS普通模式较大概率启动失败，中轻度游戏建议小于该值。请查看GIT文档<a href=\"https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/OptimizationMemory.md\">优化Unity WebGL的内存</a>");
                }
#if PLATFORM_WEIXINMINIGAME
                PlayerSettings.WeixinMiniGame.emscriptenArgs += $" -s TOTAL_MEMORY={config.ProjectConf.MemorySize}MB";
#else
                PlayerSettings.WebGL.emscriptenArgs += $" -s TOTAL_MEMORY={config.ProjectConf.MemorySize}MB";
#endif
            }

#if PLATFORM_WEIXINMINIGAME
            if (config.CompileOptions.ProfilingMemory)
            {
                PlayerSettings.WeixinMiniGame.emscriptenArgs += " --memoryprofiler ";
            }

            if (config.CompileOptions.profilingFuncs)
            {
                PlayerSettings.WeixinMiniGame.emscriptenArgs += " --profiling-funcs ";
            }

#if UNITY_2021_2_OR_NEWER
#if UNITY_2022_1_OR_NEWER
            // 默认更改为OptimizeSize，减少代码包体积
            PlayerSettings.SetIl2CppCodeGeneration(NamedBuildTarget.WeixinMiniGame, config.CompileOptions.Il2CppOptimizeSize ? Il2CppCodeGeneration.OptimizeSize : Il2CppCodeGeneration.OptimizeSpeed);
#else
            EditorUserBuildSettings.il2CppCodeGeneration = config.CompileOptions.Il2CppOptimizeSize ? Il2CppCodeGeneration.OptimizeSize : Il2CppCodeGeneration.OptimizeSpeed;
#endif
#endif
            UnityEngine.Debug.Log("[Builder] Starting to build WeixinMiniGame project ... ");
            UnityEngine.Debug.Log("PlayerSettings.WeixinMiniGame.emscriptenArgs : " + PlayerSettings.WeixinMiniGame.emscriptenArgs);
#else
            if (config.CompileOptions.ProfilingMemory)
            {
                PlayerSettings.WebGL.emscriptenArgs += " --memoryprofiler ";
            }

            if (config.CompileOptions.profilingFuncs)
            {
                PlayerSettings.WebGL.emscriptenArgs += " --profiling-funcs ";
            }

            string original_EXPORTED_RUNTIME_METHODS = "\"ccall\",\"cwrap\",\"stackTrace\",\"addRunDependency\",\"removeRunDependency\",\"FS_createPath\",\"FS_createDataFile\",\"stackTrace\",\"writeStackCookie\",\"checkStackCookie\"";
            // 添加额外的EXPORTED_RUNTIME_METHODS
            string additional_EXPORTED_RUNTIME_METHODS = ",\"lengthBytesUTF8\",\"stringToUTF8\"";
            PlayerSettings.WebGL.emscriptenArgs += " -s EXPORTED_RUNTIME_METHODS='[" + original_EXPORTED_RUNTIME_METHODS + additional_EXPORTED_RUNTIME_METHODS + "]'";

#if UNITY_2021_2_OR_NEWER
#if UNITY_2022_1_OR_NEWER
                // 默认更改为OptimizeSize，减少代码包体积
            PlayerSettings.SetIl2CppCodeGeneration(NamedBuildTarget.WebGL, config.CompileOptions.Il2CppOptimizeSize ? Il2CppCodeGeneration.OptimizeSize : Il2CppCodeGeneration.OptimizeSpeed);
#else
            EditorUserBuildSettings.il2CppCodeGeneration = config.CompileOptions.Il2CppOptimizeSize ? Il2CppCodeGeneration.OptimizeSize : Il2CppCodeGeneration.OptimizeSpeed;
#endif
#endif
            UnityEngine.Debug.Log("[Builder] Starting to build WebGL project ... ");
            UnityEngine.Debug.Log("PlayerSettings.WebGL.emscriptenArgs : " + PlayerSettings.WebGL.emscriptenArgs);
#endif


            // PlayerSettings.WebGL.memorySize = memorySize;
            BuildOptions option = BuildOptions.None;

            if (config.CompileOptions.DevelopBuild)
            {
                option |= BuildOptions.Development;
            }

            if (config.CompileOptions.AutoProfile)
            {
                option |= BuildOptions.ConnectWithProfiler;
            }

            if (config.CompileOptions.ScriptOnly)
            {
                option |= BuildOptions.BuildScriptsOnly;
            }
#if UNITY_2021_2_OR_NEWER
            if (config.CompileOptions.CleanBuild)
            {
                option |= BuildOptions.CleanBuildCache;
            }
#endif
#if TUANJIE_2022_3_OR_NEWER
            if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.WeixinMiniGame)
            {
                UnityEngine.Debug.LogFormat("[Builder] Current target is: {0}, switching to: {1}", EditorUserBuildSettings.activeBuildTarget, BuildTarget.WeixinMiniGame);
                if (!EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WeixinMiniGame, BuildTarget.WeixinMiniGame))
                {
                    UnityEngine.Debug.LogFormat("[Builder] Switching to {0}/{1} failed!", BuildTargetGroup.WeixinMiniGame, BuildTarget.WeixinMiniGame);
                    return -1;
                }
            }

            var projDir = Path.Combine(config.ProjectConf.DST, webglDir);

            var result = BuildPipeline.BuildPlayer(GetScenePaths(), projDir, BuildTarget.WeixinMiniGame, option);
            if (result.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                UnityEngine.Debug.LogFormat("[Builder] BuildPlayer failed. emscriptenArgs:{0}", PlayerSettings.WeixinMiniGame.emscriptenArgs);
                return -1;
            }
#else
            if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.WebGL)
            {
                UnityEngine.Debug.LogFormat("[Builder] Current target is: {0}, switching to: {1}", EditorUserBuildSettings.activeBuildTarget, BuildTarget.WebGL);
                if (!EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL))
                {
                    UnityEngine.Debug.LogFormat("[Builder] Switching to {0}/{1} failed!", BuildTargetGroup.WebGL, BuildTarget.WebGL);
                    return -1;
                }
            }

            var projDir = Path.Combine(config.ProjectConf.DST, webglDir);

            var result = BuildPipeline.BuildPlayer(GetScenePaths(), projDir, BuildTarget.WebGL, option);
            if (result.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                UnityEngine.Debug.LogFormat("[Builder] BuildPlayer failed. emscriptenArgs:{0}", PlayerSettings.WebGL.emscriptenArgs);
                return -1;
            }
#endif
            UnityEngine.Debug.LogFormat("[Builder] Done: " + projDir);
            return 0;
        }

        private static string GetWebGLDataPath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.data");
            }
            else
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.data.unityweb");
            }
        }

        private static string[] GetWeixinMiniGameFilePath(string key)
        {
            var bootJson = Path.Combine(config.ProjectConf.DST, webglDir, "Code", "wwwroot", "_framework", "blazor.boot.json");
            var boot = JsonMapper.ToObject(File.ReadAllText(bootJson, Encoding.UTF8));
            return boot["resources"][key].Keys.Select(file => Path.Combine(config.ProjectConf.DST, webglDir, "Code", "wwwroot", "_framework", file)).ToArray();
        }

        private static void finishExport()
        {
            int code = GenerateBinFile();
            if (code == 0)
            {
                convertDataPackage(false);
                UnityEngine.Debug.LogFormat("[Converter] All done!");
                //ShowNotification(new GUIContent("转换完成"));
            }
            else
            {
                convertDataPackage(true);
            }
        }
        /// <summary>
        /// 等brotli之后，统计下资源包加brotli压缩后代码包是否超过了20M（小游戏代码分包总大小限制）
        /// </summary>
        private static void convertDataPackage(bool brotliError)
        {
            var baseDataFilename = dataMd5 + ".webgl.data.unityweb.bin";
            var webglDirPath = Path.Combine(config.ProjectConf.DST, webglDir);
            var minigameDirPath = Path.Combine(config.ProjectConf.DST, miniGameDir);
            var minigameDataPath = Path.Combine(minigameDirPath, "data-package");
            // 未压缩的包名
            var originDataFilename = baseDataFilename + ".txt";
            var originMinigameDataPath = Path.Combine(minigameDataPath, originDataFilename);
            var originTempDataPath = Path.Combine(webglDirPath, originDataFilename);
            // br压缩的资源包名
            var brDataFilename = baseDataFilename + ".br";
            var brMinigameDataPath = Path.Combine(minigameDataPath, brDataFilename);
            var tempDataBrPath = Path.Combine(webglDirPath, brDataFilename);

            // 资源文件名
            var dataFilename = originDataFilename;
            // 原始webgl的资源路径，即webgl/build目录下的资源名
            var sourceDataPath = GetWebGLDataPath();
            // webgl目录下的资源路径
            var tempDataPath = originTempDataPath;
            var dataPackageBrotliRet = 0;
            // 如果brotli失败，使用CDN加载
            if (brotliError)
            {
                // brotli失败后，因为无法知道wasmcode大小，则得不到最终小游戏总包体大小。不能使用小游戏分包加载资源，还原成cdn的方式。
                if (config.ProjectConf.assetLoadType == 1)
                {
                    UnityEngine.Debug.LogWarning("brotli失败，无法检测文件大小，请上传资源文件到CDN");
                    config.ProjectConf.assetLoadType = 0;
                }

                // ShowNotification(new GUIContent("Brotli压缩失败，请到转出目录手动压缩！！！"));
                Debug.LogError("Brotli压缩失败，请到转出目录手动压缩！");
            }
            // 需要压缩资源包
            if (!!config.ProjectConf.compressDataPackage)
            {
                dataFilename = brDataFilename;
                tempDataPath = tempDataBrPath;
                UnityEngine.Debug.LogFormat("[Compressing] Starting to compress datapackage");
                dataPackageBrotliRet = Brotlib(dataFilename, sourceDataPath, tempDataPath);
                Debug.Log("[Compressing] compress ret = " + dataPackageBrotliRet);
                // 若压缩资源包失败，回退未压缩状态
                if (dataPackageBrotliRet != 0)
                {
                    config.ProjectConf.compressDataPackage = false;
                    dataFilename = originDataFilename;
                    tempDataPath = originTempDataPath;
                }
            }

            // 不需要压缩资源包或压缩失败
            if (!config.ProjectConf.compressDataPackage || dataPackageBrotliRet != 0)
            {
                // 将资源包从Build目录复制一份作为未压缩资源
                File.Copy(sourceDataPath, tempDataPath, true);
            }

            // 用小游戏分包加载时，需要计算是否未超过20M
            if (config.ProjectConf.assetLoadType == 1)
            {
                // 计算wasm包大小
                var brcodePath = Path.Combine(minigameDirPath, "wasmcode", codeMd5 + ".webgl.wasm.code.unityweb.wasm.br");
                var brcodeInfo = new FileInfo(brcodePath);
                var brcodeSize = brcodeInfo.Length;
                // 计算首资源包大小
                var tempDataInfo = new FileInfo(tempDataPath);
                var tempFileSize = tempDataInfo.Length.ToString();
                // 胶水层及sdk可能占一定大小，粗略按照1M来算，则剩余19M
                if (brcodeSize + int.Parse(tempFileSize) > (20 - 1) * 1024 * 1024)
                {
                    config.ProjectConf.assetLoadType = 0;
                    Debug.LogError("资源文件过大，不适宜用放小游戏包内加载，请上传资源文件到CDN");
                }
                else
                {
                    // 小游戏分包加载时，压缩成功且总大小符合要求，将br文件copy到小游戏目录
                    File.Copy(tempDataPath, config.ProjectConf.compressDataPackage ? brMinigameDataPath : originMinigameDataPath, true);
                }
            }
            checkNeedRmovePackageParallelPreload();

            // 设置InstantGame的首资源包路径，上传用
            FirstBundlePath = tempDataPath;

            var loadDataFromCdn = config.ProjectConf.assetLoadType == 0;
            Rule[] rules =
            {
                new Rule()
                {
                    old = "$DEPLOY_URL",
                    newStr = config.ProjectConf.CDN,
                },
                new Rule()
                {
                    old = "$LOAD_DATA_FROM_SUBPACKAGE",
                    newStr = loadDataFromCdn ? "false" : "true",
                },
                new Rule()
                {
                    old = "$COMPRESS_DATA_PACKAGE",
                    newStr = config.ProjectConf.compressDataPackage ? "true" : "false",
                }
            };
            string[] files = { "game.js", "game.json", "project.config.json", "check-version.js" };
            ReplaceFileContent(files, rules);
        }

        private static void checkNeedRmovePackageParallelPreload()
        {
            // cdn下载时不需要填写并行下载配置
            if (config.ProjectConf.assetLoadType == 0)
            {
                var filePath = Path.Combine(config.ProjectConf.DST, miniGameDir, "game.json");

                string content = File.ReadAllText(filePath, Encoding.UTF8);
                JsonData gameJson = JsonMapper.ToObject(content);
                JsonWriter writer = new JsonWriter();
                writer.IndentValue = 2;
                writer.PrettyPrint = true;
                gameJson["parallelPreloadSubpackages"].Remove(gameJson["parallelPreloadSubpackages"][1]);

                // 将配置写回到文件夹
                gameJson.ToJson(writer);
                File.WriteAllText(filePath, writer.TextWriter.ToString());
            }
        }

        /// <summary>
        /// 对文件做内容替换
        /// </summary>
        /// <param name="files"></param>
        /// <param name="replaceList"></param>
        public static void ReplaceFileContent(string[] files, Rule[] replaceList)
        {
            if (files.Length != 0 && replaceList.Length != 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    var filePath = Path.Combine(config.ProjectConf.DST, miniGameDir, files[i]);
                    string text = File.ReadAllText(filePath, Encoding.UTF8);
                    for (int j = 0; j < replaceList.Length; j++)
                    {
                        var rule = replaceList[j];
                        text = text.Replace(rule.old, rule.newStr);
                    }

                    File.WriteAllText(filePath, text, new UTF8Encoding(false));
                }
            }
        }

        private static string GetWebGLCodePath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                if (UseIL2CPP)
                {
                    return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.wasm");
                }
                else
                {
                    return GetWeixinMiniGameFilePath("wasmNative")[0];
                }
            }
            else
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.wasm.code.unityweb");
            }
        }

        private static bool CopyDirectory(string SourcePath, string DestinationPath, bool overwriteexisting)
        {
            bool ret = false;
            var separator = Path.DirectorySeparatorChar;
            var ignoreFiles = new List<string>() { "unityNamespace.js" };

            // eventEmitter - 改名为event-emitter
            // loading和libs 是可交互视频用到的文件，先下掉可交互方案
            var ignoreDirs = new List<string>() { "eventEmitter", "loading", "libs" };
            try
            {
                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                    {
                        Directory.CreateDirectory(DestinationPath);
                    }
                    else
                    {
                        // 已经存在，删掉目录下无用的文件
                        foreach (string filename in ignoreFiles)
                        {
                            var filepath = Path.Combine(DestinationPath, filename);
                            if (File.Exists(filepath))
                            {
                                File.Delete(filepath);
                            }
                        }

                        foreach (string dir in ignoreDirs)
                        {
                            var dirpath = Path.Combine(DestinationPath, dir);
                            if (Directory.Exists(dirpath))
                            {
                                Directory.Delete(dirpath);
                            }
                        }
                    }

                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        if (flinfo.Extension == ".meta" || ignoreFiles.Contains(flinfo.Name))
                        {
                            continue;
                        }
                        flinfo.CopyTo(Path.Combine(DestinationPath, flinfo.Name), overwriteexisting);
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (ignoreDirs.Contains(drinfo.Name))
                        {
                            continue;
                        }
                        if (CopyDirectory(drs, Path.Combine(DestinationPath, drinfo.Name), overwriteexisting) == false)
                        {
                            ret = false;
                        }
                    }
                }

                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                UnityEngine.Debug.LogError(ex);
            }

            return ret;
        }

        public static string FirstBundlePath = "";
        public static int GenerateBinFile(bool isFromConvert = false)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to genarate md5 and copy files");

            var codePath = GetWebGLCodePath();
            codeMd5 = UnityUtil.BuildFileMd5(codePath);
            var dataPath = GetWebGLDataPath();
            dataMd5 = UnityUtil.BuildFileMd5(dataPath);
            var symbolPath = GetWebGLSymbolPath();

            RemoveOldAssetPackage(Path.Combine(config.ProjectConf.DST, webglDir));
            RemoveOldAssetPackage(Path.Combine(config.ProjectConf.DST, webglDir + "-min"));
            // CopyDirectory(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default"), Path.Combine(config.ProjectConf.DST, miniGameDir), true);
            CopyDirectory(Path.Combine(UnityUtil.GetWxSDKRootPath(), "Runtime", "wechat-default"), Path.Combine(config.ProjectConf.DST, miniGameDir), true);
            // FIX: 2021.2版本生成symbol有bug，导出时生成symbol报错，有symbol才copy
            // 代码分包需要symbol文件以进行增量更新
            if (File.Exists(symbolPath))
            {
                File.Copy(symbolPath, Path.Combine(config.ProjectConf.DST, miniGameDir, "webgl.wasm.symbols.unityweb"), true);
            }

            var info = new FileInfo(dataPath);
            dataFileSize = info.Length.ToString();
            UnityEngine.Debug.LogFormat("[Converter] that to genarate md5 and copy files ended");
            ModifyWeChatConfigs(isFromConvert);
            ModifySDKFile();
            ClearFriendRelationCode();

            // 如果没有StreamingAssets目录，默认生成
            if (!Directory.Exists(Path.Combine(config.ProjectConf.DST, webglDir, "StreamingAssets")))
            {
                Directory.CreateDirectory(Path.Combine(config.ProjectConf.DST, webglDir, "StreamingAssets"));
            }
            return Brotlib(codeMd5 + ".webgl.wasm.code.unityweb.wasm.br", codePath, Path.Combine(config.ProjectConf.DST, miniGameDir, "wasmcode", codeMd5 + ".webgl.wasm.code.unityweb.wasm.br"));
        }

        private static int Brotlib(string filename, string sourcePath, string targetPath)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to generate Brotlib file");
            var cachePath = Path.Combine(config.ProjectConf.DST, webglDir, filename);
            var shortFilename = filename.Substring(filename.IndexOf('.') + 1);

            // 如果code没有发生过变化，则不再进行br压缩
            if (File.Exists(cachePath))
            {
                File.Copy(cachePath, targetPath, true);
                return 0;
            }

            // 删除旧的br压缩文件
            if (Directory.Exists(Path.Combine(config.ProjectConf.DST, webglDir)))
            {
                foreach (string path in Directory.GetFiles(Path.Combine(config.ProjectConf.DST, webglDir)))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    if (fileInfo.Name.Contains(shortFilename))
                    {
                        File.Delete(fileInfo.FullName);
                    }
                }
            }
            UnityUtil.brotli(sourcePath, targetPath);
            if (targetPath != cachePath)
            {
                File.Copy(targetPath, cachePath, true);
            }
            return 0;
        }


        /// <summary>
        /// 如果没有使用好友关系链的话，自动删掉无用代码
        /// </summary>
        private static void ClearFriendRelationCode()
        {
            var filePath = Path.Combine(config.ProjectConf.DST, miniGameDir, "game.json");

            string content = File.ReadAllText(filePath, Encoding.UTF8);
            JsonData gameJson = JsonMapper.ToObject(content);

            if (!config.SDKOptions.UseFriendRelation || !config.SDKOptions.UseMiniGameChat)
            {
                JsonWriter writer = new JsonWriter();
                writer.IndentValue = 2;
                writer.PrettyPrint = true;

                // 将 game.json 里面关系链相关的配置删除
                if (!config.SDKOptions.UseFriendRelation)
                {
                    gameJson.Remove("openDataContext");
                    gameJson["plugins"].Remove("Layout");

                    // 删除 open-data 相应的文件夹
                    string openDataDir = Path.Combine(config.ProjectConf.DST, miniGameDir, "open-data");
                    UnityUtil.DelectDir(openDataDir);
                    Directory.Delete(openDataDir, true);
                }

                if (!config.SDKOptions.UseMiniGameChat)
                {
                    gameJson["plugins"].Remove("MiniGameChat");
                    UnityEngine.Debug.Log(gameJson["plugins"]);
                }

                // 将配置写回到文件夹
                gameJson.ToJson(writer);
                File.WriteAllText(filePath, writer.TextWriter.ToString());
            }
        }


        private static void ModifySDKFile()
        {
            var config = UnityUtil.GetEditorConf();
            string content = File.ReadAllText(SDKFilePath, Encoding.UTF8);
            content = content.Replace("$unityVersion$", Application.unityVersion);
            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, "unity-sdk", "index.js"), content, Encoding.UTF8);
            // content = File.ReadAllText(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "storage.js"), Encoding.UTF8);
            content = File.ReadAllText(Path.Combine(UnityUtil.GetWxSDKRootPath(), "Runtime", "wechat-default", "unity-sdk", "storage.js"), Encoding.UTF8);
            var PreLoadKeys = config.PlayerPrefsKeys.Count > 0 ? JsonMapper.ToJson(config.PlayerPrefsKeys) : "[]";
            content = content.Replace("'$PreLoadKeys'", PreLoadKeys);
            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, "unity-sdk", "storage.js"), content, Encoding.UTF8);
            // 修改纹理dxt
            // content = File.ReadAllText(Path.Combine(Application.dataPath, "WX-WASM-SDK-V2", "Runtime", "wechat-default", "unity-sdk", "texture.js"), Encoding.UTF8);
            content = File.ReadAllText(Path.Combine(UnityUtil.GetWxSDKRootPath(), "Runtime", "wechat-default", "unity-sdk", "texture.js"), Encoding.UTF8);
            File.WriteAllText(Path.Combine(config.ProjectConf.DST, miniGameDir, "unity-sdk", "texture.js"), content, Encoding.UTF8);
        }

        public static string HandleLoadingImage()
        {
            var info = AssetDatabase.LoadAssetAtPath<Texture>(config.ProjectConf.bgImageSrc);
            var oldFilename = Path.GetFileName(defaultImgSrc);
            var newFilename = Path.GetFileName(config.ProjectConf.bgImageSrc);
            if (config.ProjectConf.bgImageSrc != defaultImgSrc)
            {
                // 图片宽高不能超过2048
                if (info.width > 2048 || info.height > 2048)
                {
                    throw new Exception("封面图宽高不可超过2048");
                }

                File.Delete(Path.Combine(config.ProjectConf.DST, miniGameDir, "images", oldFilename));
                File.Copy(config.ProjectConf.bgImageSrc, Path.Combine(config.ProjectConf.DST, miniGameDir, "images", newFilename), true);
                return "images/" + Path.GetFileName(config.ProjectConf.bgImageSrc);
            }
            else
            {
                return "images/" + Path.GetFileName(defaultImgSrc);
            }
        }
        /// <summary>
        /// 按;分隔字符串，将分隔后每一项作为字符串用,连接
        /// eg: input "i1;i2;i3" => output: `"i1", "i2", "i3"`
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        public static string GetArrayString(string inp)
        {
            var result = string.Empty;
            var iterms = new List<string>(inp.Split(new char[] { ';' }));
            iterms.ForEach((iterm) =>
            {
                if (!string.IsNullOrEmpty(iterm.Trim()))
                {
                    result += "\"" + iterm.Trim() + "\", ";
                }
            });
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Substring(0, result.Length - 2);
            }

            return result;
        }
        private class PreloadFile
        {
            public PreloadFile(string fn, string rp)
            {
                fileName = fn;
                relativePath = rp;
            }

            public string fileName;
            public string relativePath;
        }

        /// <summary>
        /// 从webgl目录模糊搜索preloadfiles中的文件，作为预下载的列表
        /// </summary>
        private static string GetPreloadList(string strPreloadfiles)
        {
            if (strPreloadfiles == string.Empty)
            {
                return string.Empty;
            }

            string preloadList = string.Empty;
            var streamingAssetsPath = Path.Combine(config.ProjectConf.DST, webglDir + "/StreamingAssets");
            var fileNames = strPreloadfiles.Split(new char[] { ';' });
            List<PreloadFile> preloadFiles = new List<PreloadFile>();
            foreach (var fileName in fileNames)
            {
                if (fileName.Trim() == string.Empty)
                {
                    continue;
                }

                preloadFiles.Add(new PreloadFile(fileName, string.Empty));
            }

            if (Directory.Exists(streamingAssetsPath))
            {
                foreach (string path in Directory.GetFiles(streamingAssetsPath, "*", SearchOption.AllDirectories))
                {
                    FileInfo fileInfo = new FileInfo(path);
                    foreach (var preloadFile in preloadFiles)
                    {
                        if (fileInfo.Name.Contains(preloadFile.fileName))
                        {
                            // 相对于StreamingAssets的路径
                            var relativePath = path.Substring(streamingAssetsPath.Length + 1).Replace('\\', '/');
                            preloadFile.relativePath = relativePath;
                            break;
                        }
                    }
                }
            }
            else
            {
                UnityEngine.Debug.LogError("没有找到StreamingAssets目录， 无法生成预下载列表");
            }

            foreach (var preloadFile in preloadFiles)
            {
                if (preloadFile.relativePath == string.Empty)
                {
                    UnityEngine.Debug.LogError($"并非所有预下载的文件都被找到，剩余：{preloadFile.fileName}");
                    continue;
                }

                preloadList += "\"" + preloadFile.relativePath + "\", \r";
            }

            return preloadList;
        }


        public static void ModifyWeChatConfigs(bool isFromConvert = false)
        {
            UnityEngine.Debug.LogFormat("[Converter] Starting to modify configs");

            var config = UnityUtil.GetEditorConf();

            var PRELOAD_LIST = GetPreloadList(config.ProjectConf.preloadFiles);
            var imgSrc = HandleLoadingImage();

            var bundlePathIdentifierStr = GetArrayString(config.ProjectConf.bundlePathIdentifier);
            var excludeFileExtensionsStr = GetArrayString(config.ProjectConf.bundleExcludeExtensions);

            var screenOrientation = new List<string>() { "portrait", "landscape", "landscapeLeft", "landscapeRight" }[(int)config.ProjectConf.Orientation];

            Rule[] replaceArrayList = ReplaceRules.GenRules(new string[] {
                config.ProjectConf.projectName == string.Empty ? "webgl" : config.ProjectConf.projectName,
                config.ProjectConf.Appid,
                screenOrientation,
                config.CompileOptions.enableIOSPerformancePlus ? "true" : "false",
                config.ProjectConf.VideoUrl,
                codeMd5,
                dataMd5,
                config.ProjectConf.StreamCDN,
                config.ProjectConf.CDN + "/Assets",
                PRELOAD_LIST,
                imgSrc,
                config.ProjectConf.HideAfterCallMain ? "true" : "false",
                config.ProjectConf.bundleHashLength.ToString(),
                bundlePathIdentifierStr,
                excludeFileExtensionsStr,
                config.CompileOptions.Webgl2 ? "2" : "1",
                Application.unityVersion,
                WXExtEnvDef.pluginVersion,
                config.ProjectConf.dataFileSubPrefix,
                config.ProjectConf.maxStorage.ToString(),
                config.ProjectConf.defaultReleaseSize.ToString(),
                config.ProjectConf.texturesHashLength.ToString(),
                config.ProjectConf.texturesPath,
                config.ProjectConf.needCacheTextures ? "true" : "false",
                config.ProjectConf.loadingBarWidth.ToString(),
                config.ProjectConf.needCheckUpdate ? "true" : "false",
                GetColorSpace(),
                config.ProjectConf.disableHighPerformanceFallback ? "true" : "false",
                config.SDKOptions.PreloadWXFont ? "true" : "false",
                config.CompileOptions.showMonitorSuggestModal ? "true" : "false",
                config.CompileOptions.enableProfileStats ? "true" : "false",
                config.CompileOptions.iOSAutoGCInterval.ToString(),
                dataFileSize,
                IsInstantGameAutoStreaming() ? "true" : "false",
                (config.CompileOptions.DevelopBuild && config.CompileOptions.enableRenderAnalysis) ? "true" : "false",
                config.ProjectConf.IOSDevicePixelRatio.ToString(),
                UseIL2CPP ? "" : "/framework",
                UseIL2CPP ? "false" : "true",
            });

            List<Rule> replaceList = new List<Rule>(replaceArrayList);
            List<string> files = new List<string> { "game.js", "game.json", "project.config.json", "unity-namespace.js", "check-version.js" };

            ReplaceFileContent(files.ToArray(), replaceList.ToArray());

            UnityEngine.Debug.LogFormat("[Converter] that to modify configs ended");
        }

        /// <summary>
        /// 获取当前工程颜色空间
        /// </summary>
        /// <returns></returns>
        private static string GetColorSpace()
        {
            switch (PlayerSettings.colorSpace)
            {
                case ColorSpace.Gamma:
                    return "Gamma";
                case ColorSpace.Linear:
                    return "Linear";
                case ColorSpace.Uninitialized:
                    return "Uninitialized";
                default:
                    return "Unknow";
            }
        }

        /// <summary>
        /// 删掉导出目录webgl目录下旧资源包
        /// </summary>
        private static void RemoveOldAssetPackage(string dstDir)
        {
            try
            {
                if (Directory.Exists(dstDir))
                {
                    foreach (string path in Directory.GetFiles(dstDir))
                    {
                        FileInfo fileInfo = new FileInfo(path);
                        if (fileInfo.Name.Contains("webgl.data.unityweb.bin.txt") || fileInfo.Name.Contains("webgl.data.unityweb.bin.br"))
                        {
                            File.Delete(fileInfo.FullName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex);
            }
        }

        private static string GetWebGLSymbolPath()
        {
            if (WXExtEnvDef.GETDEF("UNITY_2020_1_OR_NEWER"))
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.symbols.json");
            }
            else
            {
                return Path.Combine(config.ProjectConf.DST, webglDir, "Build", "webgl.wasm.symbols.unityweb");
            }
        }

        private static string[] GetScenePaths()
        {
            List<string> scenes = new List<string>();
            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                var scene = EditorBuildSettings.scenes[i];
                UnityEngine.Debug.LogFormat("[Builder] Scenes [{0}]: {1}, [{2}]", i, scene.path, scene.enabled ? "x" : " ");

                if (scene.enabled)
                {
                    scenes.Add(scene.path);
                }
            }

            return scenes.ToArray();
        }

        /// <summary>
        /// 兼容 WebGL1 WebGL2 Linear Gamma 配置 Assets/WX-WASM-SDK/Plugins
        /// </summary>
        private static void SettingWXTextureMinJSLib()
        {
            string[] jsLibs;
            string DS = WXAssetsTextTools.DS;
            if (UnityUtil.GetSDKMode() == UnityUtil.SDKMode.Package)
            {
                jsLibs = new string[]
                {
                $"Packages{DS}com.qq.weixin.minigame{DS}Runtime{DS}Plugins{DS}SDK-WX-TextureMin-JS-WEBGL1.jslib",
                $"Packages{DS}com.qq.weixin.minigame{DS}Runtime{DS}Plugins{DS}SDK-WX-TextureMin-JS-WEBGL2.jslib",
                $"Packages{DS}com.qq.weixin.minigame{DS}Runtime{DS}Plugins{DS}SDK-WX-TextureMin-JS-WEBGL2-Linear.jslib",
                };
            }
            else
            {
                string jsLibRootDir = $"Assets{DS}WX-WASM-SDK-V2{DS}Runtime{DS}Plugins{DS}";

                // 下方顺序不可变动
                 jsLibs = new string[]
                 {
                     $"{jsLibRootDir}SDK-WX-TextureMin-JS-WEBGL1.jslib",
                     $"{jsLibRootDir}SDK-WX-TextureMin-JS-WEBGL2.jslib",
                     $"{jsLibRootDir}SDK-WX-TextureMin-JS-WEBGL2-Linear.jslib",
                 };
            }       
            int index = 0;
            if (config.CompileOptions.Webgl2)
            {
                if (PlayerSettings.colorSpace == ColorSpace.Linear)
                {
                    index = 2;
                }
                else
                {
                    index = 1;
                }
            }

            for (int i = 0; i < jsLibs.Length; i++)
            {
                var importer = AssetImporter.GetAtPath(jsLibs[i]) as PluginImporter;
                bool value = i == index;
#if PLATFORM_WEIXINMINIGAME
                importer.SetCompatibleWithPlatform(BuildTarget.WeixinMiniGame, value);
#else
                importer.SetCompatibleWithPlatform(BuildTarget.WebGL, value);
#endif
                importer.SaveAndReimport();
            }
        }

        public static bool IsInstantGameAutoStreaming()
        {
            if (string.IsNullOrEmpty(GetInstantGameAutoStreamingCDN()))
            {
                return false;
            }
            return true;
        }

        public static bool CheckSDK()
        {
            string dir = Path.Combine(Application.dataPath, "WX-WASM-SDK");
            if (Directory.Exists(dir))
            {
                return false;
            }
            return true;
        }

        public static string GetInstantGameAutoStreamingCDN()
        {
#if UNITY_INSTANTGAME
            string cdn = Unity.InstantGame.IGBuildPipeline.GetInstantGameCDNRoot();
            return cdn;
#else
            return "";
#endif
        }

        public static bool ShowMatchFailedWarning(string text, string rule, string file)
        {
            if (Regex.IsMatch(text, rule) == false) {
                Debug.LogWarning($"UnMatched {file} rule: {rule}");
                return true;
            }
            return false;
        }
    }

}
