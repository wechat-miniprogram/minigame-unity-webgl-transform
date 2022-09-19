using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Collections;

namespace WeChatWASM
{

    [Serializable]
    public class WXProjectConf
    {
        /// <summary>
        /// 小游戏项目名
        /// </summary>
        public string projectName;
        /// <summary>
        /// 游戏appid
        /// </summary>
        public string Appid;
        /// <summary>
        /// 游戏资源CDN
        /// </summary>
        public string CDN;
        /// <summary>
        ///  首包资源加载方式
        /// </summary>
        public int assetLoadType;
        /// <summary>
        /// 视频url
        /// </summary>
        public string VideoUrl;
        /// <summary>
        /// 导出路径(绝对路径)
        /// </summary>
        public string DST = "";
        /// <summary>
        /// AB包CDN地址
        /// </summary>
        public string StreamCDN = "";
        /// <summary>
        /// bundle的hash长度
        /// </summary>
        public int bundleHashLength = 32;
        /// <summary>
        /// 路径中包含什么标识符表示下载bundle，需要自动缓存
        /// </summary>
        public string bundlePathIdentifier = "StreamingAssets;";
        /// <summary>
        /// 排除路径下指定类型文件不缓存
        /// </summary>
        public string bundleExcludeExtensions = "json;";
        /// <summary>
        /// Assets目录对应CDN地址
        /// </summary>
        public string AssetsUrl = "";

        /// <summary>
        /// 游戏内存大小(MB)
        /// </summary>
        public int MemorySize = 256;

        /// <summary>
        /// callmain完成后是否立即隐藏加载封面
        /// </summary>
        public bool HideAfterCallMain = true;

        /// <summary>
        /// 预下载列表
        /// </summary>
        public string preloadFiles = "";

        /// <summary>
        /// 游戏方向
        /// </summary>
        public WXScreenOritation Orientation = WXScreenOritation.Portrait;

        /// <summary>
        /// 启动视频封面图/背景图
        /// </summary>
        public string bgImageSrc = "Assets/WX-WASM-SDK/wechat-default/images/background.jpg";

        /// <summary>
        /// 拼接在DATA_CDN和首包资源文件名的路径，用于首包资源没放到DATA_CDN根目录的情况
        /// </summary>
        public string dataFileSubPrefix = "";

        /// <summary>
        /// 最大缓存容量，单位MB
        /// </summary>
        public int maxStorage = 200;

        /// <summary>
        /// 清理缓存时默认额外清理的大小，单位Bytes，默认值30MB
        /// </summary>
        public int defaultReleaseSize = 31457280;

        /// <summary>
        /// 纹理中hash长度
        /// </summary>
        public int texturesHashLength = 8;

        /// <summary>
        /// 纹理存储路径
        /// </summary>
        public string texturesPath = "Assets/Textures";

        /// <summary>
        /// 是否缓存纹理
        /// </summary>
        public bool needCacheTextures = true;

        /// <summary>
        /// 加载进度条的宽度，默认240
        /// </summary>
        public int loadingBarWidth = 240;

        /// <summary>
        /// 是否需要启动时自动检查小游戏是否有新版本
        /// </summary>
        public bool needCheckUpdate = false;
    }

    [Serializable]
    public class CompressTexture
    {
        /// <summary>
        /// 自动将图片尺寸减小一半
        /// </summary>
        public bool halfSize = false;
        /// <summary>
        /// 使用pc端压缩纹理
        /// </summary>
        public bool useDXT5 = false;
        /// <summary>
        /// bundle文件后缀
        /// </summary>
        public string bundleSuffix = "bundle";
        /// <summary>
        /// 是否加载bundle时同时加载对应纹理
        /// </summary>
        public bool parallelWithBundle = false;
        /// <summary>
        /// 自定义bundle路径
        /// </summary>
        public string bundleDir;
        /// <summary>
        /// 自定义生成目录路径
        /// </summary>
        public string dstMinDir;
    }

    [Serializable]
    public class SDKOptions
    {
        /// <summary>
        /// 使用微信音频API
        /// </summary>
        public bool UseAudioApi = false;
        /// <summary>
        /// 使用好友关系链
        /// </summary>
        public bool UseFriendRelation = false;
        /// <summary>
        /// 使用压缩纹理替换(beta)
        /// </summary>
        public bool UseCompressedTexture = false;
    }

    [Serializable]
    public class CompileOptions
    {
        /// <summary>
        /// Development Build
        /// </summary>
        public bool DevelopBuild = false;
        /// <summary>
        /// Autoconnect Profiler
        /// </summary>
        public bool AutoProfile = false;
        /// <summary>
        /// Scripts Only Build
        /// </summary>
        public bool ScriptOnly = false;
        /// <summary>
		/// Profiling Funcs
		/// </summary>
        public bool profilingFuncs = false;
        /// <summary>
        /// WebGL2.0
        /// </summary>
        public bool Webgl2 = false;
        /// <summary>
        /// DeleteStreamingAssets
        /// </summary>
        public bool DeleteStreamingAssets = true;
        /// <summary>
        /// ProfilingMemory
        /// </summary>
        public bool ProfilingMemory = false;
    }


    public enum WXScreenOritation
    {
        Portrait, Landscape, LandscapeLeft, LandscapeRight
    };

    public class WXEditorScriptObject : ScriptableObject
    {

        public WXProjectConf ProjectConf;
        public SDKOptions SDKOptions;
        public CompileOptions CompileOptions;
        /// <summary>
        /// 压缩纹理配置
        /// </summary>
        public CompressTexture CompressTexture;
        /// <summary>
        /// 小游戏里会预先加载的key
        /// </summary>
        public List<string> PlayerPrefsKeys = new List<string>();
    }


}
