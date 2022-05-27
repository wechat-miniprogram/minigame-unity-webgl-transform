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

    }

    [Serializable]
    public class CompressTexture
    {
        /// <summary>
        /// 要选择的压缩纹理目录
        /// </summary>
        public List<string> SourceDirs = new List<string>() { "Assets" };
        public List<QualityOptions> QualityList = new List<QualityOptions>();
        public List<string> FlareDirList = new List<string>();
        public List<string> PVRTCFirstList = new List<string>();
        public string TextureRes;
        public string SpriteRes;
        /// <summary>
        /// 导出的图片存放路径
        /// </summary>
        public string DstDir;
        /// <summary>
        /// 若只生成ASTC，还需再点击生成ETC2和PVRTC和压缩的PNG纹理
        /// </summary>
        public bool OnlyAstc = true;

        /// <summary>
        /// Mac上unity工程太大时容易触发TooManyFiles错误
        /// </summary>
        public bool TooManyFiles = true;
        /// <summary>
        /// 自动将图片尺寸减小一半
        /// </summary>
        public bool halfSize = false;
        /// <summary>
        /// 使用pc端压缩纹理
        /// </summary>
        public bool useDXT5 = false;
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
    }

    [Serializable]
    public class QualityOptions
    {
        /// <summary>
        /// 设置压缩质量目录,绝对路径
        /// </summary>
        public string Path;
        /// <summary>
        /// 压缩质量默认65
        /// </summary>
        public int Quality = 65;
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
