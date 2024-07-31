# MiniGameConfig.asset 配置文件说明

位于 `Assets/WX-WASM-SDK-V2/Editor/MiniGameConfig.asset` 即为 WXSDK 的导出配置文件，其中部分配置可在微信小游戏导出面板中可视化配置，本节将对配置文件中各项字段进行说明，开发者可直接修改其配置内容。

## Project Config

| 字段 | 类型  | 说明 |
| --- | --- | --- |
| projectName | string | 项目名称。 |
| Appid | string | 微信小游戏Appid，前往 https://mp.weixin.qq.com/ 注册获得。 |
| CDN | string | 游戏CDN前缀。 |
| assetLoadType | int | 首资源包加载方式，0: CDN加载；1: 小游戏包内加载。 |
| compressDataPackage | bool | 将首包资源Brotli压缩, 降低资源大小. 注意: 首次启动耗时可能会增加200ms, 仅推荐使用小游戏分包加载时节省包体大小使用。 |
| VideoUrl | string | 加载阶段视频URL，可缺省。 |
| DST  | string | 导出路径。 |
| StreamCDN  | string | 已废弃。 |
| bundleHashLength | int | 自定义Bundle文件名中hash部分长度，默认值32，用于缓存控制。 |
| bundlePathIdentifier | string | 路径中包含特定标识符开始下载bundle，将被自动缓存。半角分号分隔。 |
| bundleExcludeExtensions | string | 排除路径下指定类型文件不缓存。半角分号分隔。 |
| *AssetsUrl | string | Assets目录对应CDN地址。 |
| MemorySize: 256 | int | 游戏内存大小(MB)。 |
| HideAfterCallMain | bool | callmain完成后是否立即隐藏加载封面。 |
| preloadFiles | string | 预下载列表。半角分号分隔。 |
| Orientation | int | 设备方向，0:Portrait; 1:Landscape; 2:LandscapeLeft; 3:LandscapeRight。 |
| bgImageSrc | string | 启动背景图。 |
| dataFileSubPrefix | string | 拼接在DATA_CDN和首包资源文件名的路径，用于首包资源没放到DATA_CDN根目录的情况。 |
| maxStorage | int | 最大缓存容量，单位MB，设置后若接近容量阈值将自动回收。 |
| defaultReleaseSize | int | 清理缓存时默认额外清理的大小，单位Bytes，默认值30MB。 |
| *texturesHashLength | int | 微信压缩纹理工具处理的尾部hash长度，用于识别缓存。 |
| texturesPath | string | 微信压缩纹理工具处理的纹理CDN拼接路径。 |
| needCacheTextures | bool | 是否缓存微信压缩纹理工具处理的贴图资源。 |
| loadingBarWidth | int | 加载进度条的宽度，默认240。 |
| needCheckUpdate | bool | 是否需要启动时自动检查小游戏是否有新版本。 |
| disableHighPerformanceFallback | bool | 是否禁止开启高性能模式后在不支持的iOS设备上回退为普通模式，注意：不要随意修改，只有开通高性能模式后并确认不回退才修改。 |
| IOSDevicePixelRatio | float | IOS限制固定的分辨率，以减少内存，但是会降低游戏画面品质。 | 

## SDKOptions:

| 字段 | 类型  | 说明 |
| --- | --- | --- |
| UseFriendRelation | bool | 是否使用好友关系链。 |
| UseCompressedTexture | bool | 已废弃。 |
| UseMiniGameChat | bool | 是否使用社交组件。 |
| PreloadWXFont | bool | 是否使用预载系统字体。 |

## CompileOptions: 

| 字段 | 类型  | 说明 |
| --- | --- | --- |
| DevelopBuild | bool | Development Build. |
| AutoProfile | bool | Autoconnect Profiler. |
| ScriptOnly | bool | Scripts Only Build. |
| Il2CppOptimizeSize | bool | 对应于Il2CppCodeGeneration选项，勾选时使用OptimizeSize(默认推荐)，生成代码小15%左右，取消勾选则使用OptimizeSpeed。游戏中大量泛型集合的高频访问建议OptimizeSpeed，在使用HybridCLR等第三方组件时只能用OptimizeSpeed。(Dotnet Runtime模式下该选项无效)。 |
| profilingFuncs | bool | Profiling Funcs. |
| Webgl2 | bool | WebGL2.0 |
| fbslim | bool | 导出时自动清理UnityEditor默认打包但游戏项目从未使用的资源，瘦身首包资源体积。（团结引擎已无需开启该能力）。 |
| DeleteStreamingAssets | bool | Clear Streaming Assets. |
| ProfilingMemory | bool | Profiling Memory. |
| CleanBuild | bool | Clean WebGL Build. |
| CustomNodePath | string | 已废弃。 |
| showMonitorSuggestModal | bool | 是否显示最佳实践检测弹框。 |
| enableProfileStats | bool | 是否显示性能面板。 |
| enableRenderAnalysis | bool | 是否显示渲染分析日志（develop build才生效）。 |
| iOSAutoGCInterval | int | iOS高性能模式自动GC间隔(毫秒)。 |
| enableIOSPerformancePlus | bool | 是否使用iOS高性能Plus。 |
| brotliMT: 1 | bool | 是否使用brotli多线程压缩 |

## CompressTexture:

以下是微信压缩纹理工具涉及配置，如未使用微信压缩纹理工具可以不予设置。

| 字段 | 类型  | 说明 |
| --- | --- | --- |
| halfSize | bool | 已废弃。|
| useDXT5 | bool | 是否开启PC压缩纹理。 |
| bundleSuffix | string | 已废弃。|
| parallelWithBundle | int | 已废弃。 |
| bundleDir | string | 自定义AB包目录路径。 |
| dstMinDir | string | 压缩纹理产物输出目录。 |
| debugMode | bool | 是否开启仅ASTC模式。 |
| force | bool | 是否强制重新执行。 |


## PlayerPrefsKeys:

使用PlayerPref接口时传入的key，此处设置将预先加载。

## FontOptions:

字体相关配置。

| 字段 | 类型  | 说明 |
| --- | --- | --- |
|CJK_Unified_Ideographs | bool | - |
|C0_Controls_and_Basic_Latin | bool | - |
|CJK_Symbols_and_Punctuation | bool | - |
|General_Punctuation | bool | - |
|Enclosed_CJK_Letters_and_Months | bool | - |
|Vertical_Forms | bool | - |
|CJK_Compatibility_Forms | bool | - |
|Miscellaneous_Symbols | bool | - |
|CJK_Compatibility | bool | - |
|Halfwidth_and_Fullwidth_Forms | bool | - |
|Dingbats | bool | - |
|Letterlike_Symbols | bool | - |
|Enclosed_Alphanumerics | bool | - |
|Number_Forms | bool | - |
|Currency_Symbols | bool | - |
|Arrows | bool | - |
|Geometric_Shapes | bool | - |
|Mathematical_Operators | bool | - |
|CustomUnicode | bool | - |