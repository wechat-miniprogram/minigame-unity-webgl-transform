using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using LitJson;

namespace WeChatWASM
{

    public class WXTextureData4Js
    {
        public string p;
        public int w;
        public int h;
    }


    public class JSTaskConf
    {
        public string dst;
        public string dataPath;
        public bool isAstcOnly;
        public bool lazyLoad;
        public List<QualityOptions> qualityList;
        public List<WXTextureData> textureList;
        public List<WXTextureData> spriteAtlasList;
    }



    public static class WXTextureManager
    {
        public static int[] potList = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096 };

        public static ArrayList textureList;
        public static WXEditorScriptObject miniGameConf;
        public static Dictionary<int, WXTextureData> textureDataList;
        public static Dictionary<int, WXTextureData> textureAtlasDataList;

        public static WXTextureCacheObject wxTextureCacheObject;

        public static ArrayList textureAtlasList;

        public static string textureDstDir; //纹理的导出目录

        public static string UnityPngDir = "UnityPng"; //需要直接用unity导出图片的，会比较慢用不了多线程

        public static void Init() {

            miniGameConf = UnityUtil.GetEditorConf();
            wxTextureCacheObject = UnityUtil.GetTextureCacheConf();

            textureList = new ArrayList();
            textureDataList = new Dictionary<int, WXTextureData>();


            textureAtlasList = new ArrayList();
            textureAtlasDataList = new Dictionary<int, WXTextureData>();

            textureDstDir = string.IsNullOrEmpty(miniGameConf.CompressTexture.DstDir) ? miniGameConf.ProjectConf.DST : miniGameConf.CompressTexture.DstDir;


        }


        public static void Start()
        {


#if UNITY_EDITOR_WIN
#if UNITY_2020_1_OR_NEWER
            if (VersionControlSettings.mode == "Hidden Meta Files") {
                UnityEngine.Debug.LogError("VersionControlSettings.mode 不能设置为 Hidden Meta Files，请设置为Visible Meta Files");
                return;
            }
#else
            if (UnityEditor.EditorSettings.externalVersionControl == "Hidden Meta Files") {
                UnityEngine.Debug.LogError("externalVersionControl 不能设置为 Hidden Meta Files，请设置为Visible Meta Files");
                return;
            }
#endif
#endif
            Init();
            WXSpriteAtlasManager.Init();




            if (string.IsNullOrEmpty(miniGameConf.ProjectConf.DST))
            {
                UnityEngine.Debug.LogError("请先设置导出目录！");
                return;
            }



            InitCacheObject();

            WXSpriteAtlasManager.Start();

            FindTexture();

            

            ManageTextures();

            ManageTextureAltas();


            WXSpriteAtlasManager.SaveManagedResult();

            SaveManagedResult();

            AssetDatabase.Refresh();

            CreateJSTask();

            if (!miniGameConf.CompressTexture.TooManyFiles)
            {
                DoGenerateImage();

            }

            WriteResult();

            UnityEngine.Debug.LogError("如果您使用了Flare，NGUI的图集，SpriteRender，请将对应的纹理的目录配置在`微信小游戏 / 包体瘦身--压缩纹理 / 设置Flare或NGUI图集或SpriteRender纹理目录`中，否则会展示异常，如果没有使用可忽略本条提示。");

        }

        public static void WriteResult() {


            var conf = UnityUtil.GetEditorConf();
            var dst = conf.ProjectConf.DST;

            UnityUtil.CreateDir(dst+ "/" + WXEditorWindow.webglDir);
            UnityUtil.CreateDir(dst + "/" + WXEditorWindow.miniGameDir);

            var DATA_Texture_Infos = string.IsNullOrWhiteSpace(conf.CompressTexture.TextureRes) ? "\"\"" : conf.CompressTexture.TextureRes;
            var DATA_SpriteAtlas_Infos = string.IsNullOrWhiteSpace(conf.CompressTexture.SpriteRes) ? "\"\"" : conf.CompressTexture.SpriteRes;

            var content = "const TextureConfig = " + DATA_Texture_Infos + ";const SpriteAtlasConfig = " + DATA_SpriteAtlas_Infos + "; GameGlobal.TextureConfig = TextureConfig;GameGlobal.SpriteAtlasConfig = SpriteAtlasConfig;";

            File.WriteAllText(dst+ "/" + WXEditorWindow.webglDir + "/texture-config.js", content , new System.Text.UTF8Encoding(false));

            File.WriteAllText(dst + "/" + WXEditorWindow.miniGameDir+ "/texture-config.js", content, new System.Text.UTF8Encoding(false));

        }

        private static void InitCacheObject() {


            if (wxTextureCacheObject.textureAtlasList != null)
                foreach (var item in wxTextureCacheObject.textureAtlasList) {
                    FileInfo fin = new FileInfo(item.path);
                    if (fin.LastWriteTime.ToString() == item.lastWriteTime)
                    {
                        WXSpriteAtlasManager.AddPath2SpriteList(item.path,item.id);

                        textureAtlasDataList.Add(item.id-1, item);

                        WXSpriteAtlasManager.spriteAtlasMap.Add(item.id, item.path);

                        WXSpriteAtlasManager.textureDataList.Add(item.id, item);
                    }
                       
                }

        }

        public static string ReplaceMetaFormat(string path, string text, string targetType) {
            if (Regex.IsMatch(text, @"(buildTarget: WebGL[\s\S]*?textureFormat:) (-\d{1,2}|\d{1,2})([\s\S]*?overridden:) \d"))
            {

                text = Regex.Replace(text,
                    @"(buildTarget: WebGL[\s\S]*?textureFormat:) (-\d{1,2}|\d{1,2})([\s\S]*?overridden:) \d",
                    @"$1 " + targetType + "$3 1");

            } else if (Regex.IsMatch(text, @"(((\s*)-(?:[^-]*?)? buildTarget:)(?: DefaultTexturePlatform)([\s\S]*?textureFormat: )(?:-\d{1,2}|\d{1,2})([\s\S]*?overridden:)(?: \d)(?=\3[^\s]))")) {

                text = Regex.Replace(text,
                    @"(((\s*)-(?:[^-]*?)? buildTarget:)(?: DefaultTexturePlatform)([\s\S]*?textureFormat: )(?:-\d{1,2}|\d{1,2})([\s\S]*?overridden:)(?: \d)?(?=\3[^\s]))",
                    @"$1$2 WebGL$4 " + 10 + "$5 1");
            }
            else if (Regex.IsMatch(text, @"(((\s*)-(?:[^-]*?)? buildTarget:)(?: DefaultTexturePlatform)([\s\S]*?textureFormat: )(?:-\d{1,2}|\d{1,2})([\s\S]*?overridden:)(?: \d)([\s\S]*?[^\s])(?=\3[^\s]))"))
            {
                text = Regex.Replace(text,
                    @"(((\s*)-(?:[^-]*?)? buildTarget:)(?: DefaultTexturePlatform)([\s\S]*?textureFormat: )(?:-\d{1,2}|\d{1,2})([\s\S]*?overridden:)(?: \d)([\s\S]*?[^\s])(?=\3[^\s]))",
                    @"$1$2 WebGL$4 " + targetType + "$5 1$6");
            }
            else if (!Regex.IsMatch(text, @"\bplatformSettings:") && Regex.IsMatch(text, @"\btextureFormat: (?:-?\d{1,2})"))
            {
#if UNITY_2019_1_OR_NEWER
                text = Regex.Replace(text, @"\btextureFormat: (?:-?\d{1,2})", "$0\n" +
                    @"  platformSettings:
  - serializedVersion: 3
    buildTarget: WebGL
    maxTextureSize: 2048
    resizeAlgorithm: 0
    textureFormat: " + targetType + @"
    textureCompression: 1
    compressionQuality: 50
    crunchedCompression: 0
    allowsAlphaSplitting: 0
    overridden: 1
    androidETC2FallbackOverride: 0
    forceMaximumCompressionQuality_BC6H_BC7: 0"
                    );
#else
               text = Regex.Replace(text, @"\btextureFormat: (?:-?\d{1,2})","$0\n" +
                    @"  platformSettings:
  - serializedVersion: 2
    buildTarget: WebGL
    maxTextureSize: 2048
    resizeAlgorithm: 0
    textureFormat: "+targetType+@"
    textureCompression: 1
    compressionQuality: 50
    crunchedCompression: 0
    allowsAlphaSplitting: 0
    overridden: 1
    androidETC2FallbackOverride: 0"
                    );
#endif
            }
            else {

                UnityEngine.Debug.LogError("文件：" + path + " 的格式有误，请手动勾选 override for WEBGL 然后再重试！");

            }
            return text;
        }


        public static void CreateJSTask() {

            var list = new List<WXTextureData>();
            var list2 = new List<WXTextureData>();

            foreach (var item in textureDataList) {
                list.Add(item.Value);
            }

            foreach (var item in textureAtlasDataList) {
                list.Add(item.Value);
            }

            foreach (var item in WXSpriteAtlasManager.textureDataList)
            {
                list2.Add(item.Value);
            }

            var conf = new JSTaskConf()
            {
                dst = textureDstDir,
                dataPath = Application.dataPath,
                isAstcOnly = miniGameConf.CompressTexture.OnlyAstc,
                qualityList = miniGameConf.CompressTexture.QualityList,
                textureList = list,
                spriteAtlasList = list2
            };



            File.WriteAllText(Application.dataPath+ "/WX-WASM-SDK/Editor/Node/conf.js", "module.exports = "+JsonMapper.ToJson(conf));

            if (miniGameConf.CompressTexture.TooManyFiles)
            {
                UnityEngine.Debug.LogError("最后一步请安装 Nodejs 然后进入WX-WASM-SDK/Editor/Node 目录用命令行，执行 ’node compress_astc_only.js‘ (开发阶段使用) 或 ’node compress_all.js‘（上线时候使用） 命令来生成纹理。");

            }



        }

        public static void DoGenerateImage()
        {

            foreach (var item in textureDataList)
            {
                GenerateImage(item.Value);
            }

            foreach (var item in textureAtlasDataList)
            {
                GenerateImage(item.Value);
            }




        }

        public static void FindTexture()
        {


            var list = AssetDatabase.FindAssets("t:texture", GetWorkingFolders());


            foreach (string guid in list)
            {

                bool isBad = false;
                bool needUnityPng = false;
                var path = AssetDatabase.GUIDToAssetPath(guid);


                if (WXSpriteAtlasManager.PathIsInSpriteAtlas(path))
                {
                    continue;
                }

                if (Regex.IsMatch(path.ToLower(), @"(\bcodeandweb\.com\b|\bexample\b|\.bak$|\bwx-wasm-sdk\b|\.ttf$|\beditor\b|\.rendertexture$)") || !Regex.IsMatch(path, @"^Assets\b"))
                {
                    continue;
                }


                if (Regex.IsMatch(path.ToLower(), @"(\.psd$)"))
                {
                    needUnityPng = true;
                    // isBad = true;
                }

                if (Regex.IsMatch(path.ToLower(), @"(\.tif$)"))
                {
                    UnityEngine.Debug.LogWarning(path + " tif 文件可能会导致转换失败，请避免使用该格式并注意查看是否正常展示。");

                    //  isBad = true;
                }


                if (Regex.IsMatch(path.ToLower(), @"(\.gif$)"))
                {
                    UnityEngine.Debug.LogWarning(path + " gif 文件不支持压缩纹理！");

                    isBad = true;
                }


                var texture = AssetDatabase.LoadAssetAtPath(path, typeof(Texture)) as Texture;
                if (texture == null)
                {
                    continue;
                }


                if (texture.isReadable)
                {
                    UnityEngine.Debug.LogWarning(path + " readable 文件不支持压缩纹理！请尝试去掉readable。");

                    isBad = true;
                }

                

                TextureImporter texImport = AssetImporter.GetAtPath(path) as TextureImporter;

                if (texImport == null)
                {
                    continue;
                }


                if (texImport.textureShape == TextureImporterShape.TextureCube) {
                    isBad = true;
                }

                var tips = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());

                if (texImport.textureType == TextureImporterType.SingleChannel)
                {
                    continue;
                }

                if (texImport.textureType == TextureImporterType.NormalMap || texImport.textureType == TextureImporterType.Lightmap)
                {

                    UnityEngine.Debug.LogWarning("图片 ：" + path + " NormalMap或者Lightmap暂不支持压缩纹理。");
                    isBad = true;
                }
                else if (!string.IsNullOrEmpty(texImport.spritePackingTag)) {

                    isBad = true;
                    UnityEngine.Debug.LogError("图片 ：" + path + " 使用了spritePacker，请改为使用sprite atlas！否则不能使用压缩纹理！");
                }

                var isTextureAtlas = false;

                if (!isBad)
                {

                    if (System.Array.IndexOf(potList, texture.width) == -1 || System.Array.IndexOf(potList, texture.height) == -1)
                    {
                        foreach (string dir in miniGameConf.CompressTexture.FlareDirList)
                        {
                            if (path.Replace("\\", "/").IndexOf(dir) > -1)
                            {
                                isTextureAtlas = true;
                            }
                        }

                        if (isTextureAtlas)
                        {
                            isBad = true;
                            UnityEngine.Debug.LogWarning("图片 ：" + path + " 的宽高不是2的幂，因此不会被转化为压缩纹理！请改为POT或者使用图集！");
                        }
                        else if (texture.wrapMode == TextureWrapMode.Repeat)
                        {
                            isBad = true;
                            UnityEngine.Debug.LogWarning("图片 ：" + path + " 的wrapMode 为Repeat，因此不会被转化为压缩纹理！请改为Clamp！");
                        }
                    }
                    else if(texture.wrapMode == TextureWrapMode.Repeat){
                        isTextureAtlas = true;
                        UnityEngine.Debug.LogWarning("图片 ：" + path + " 的wrapMode 为Repeat，建议改为Clamp！");
                    }
                    

                }





                if (isBad)
                {

                    // 移动端不支持DXT压缩纹理就不要跑到那个分支去了
                    var backupPath = Path.Combine(textureDstDir, "backup", path);

                    UnityUtil.CreateDir(new DirectoryInfo(backupPath).Parent.ToString());

                    File.Copy(path+".meta",backupPath+".meta",true);

                    if (tips.format == TextureImporterFormat.DXT1 || tips.format == TextureImporterFormat.DXT1Crunched || (tips.format == (TextureImporterFormat)(-1) && Regex.IsMatch(path.ToLower(), @"(\.jpg|\.jpeg$)")))
                    {
                        
                        var text = File.ReadAllText(path + ".meta");
                        text = ReplaceMetaFormat(path, text, "7");
                        File.WriteAllText(path+".meta", text);
                        
                        
                    }
                    else if (tips.format == TextureImporterFormat.DXT5 || tips.format == TextureImporterFormat.DXT5Crunched || (tips.format == (TextureImporterFormat)(-1) && !Regex.IsMatch(path.ToLower(), @"(\.jpg|\.jpeg$)")))
                    {

                        var text = File.ReadAllText(path + ".meta");
                        text = ReplaceMetaFormat(path, text,
                            texImport.textureType == TextureImporterType.NormalMap || texImport.textureType == TextureImporterType.Lightmap ? "4" : "2");
                        File.WriteAllText(path + ".meta", text);
                        
                    }

                    continue;
                }


                if (!isTextureAtlas) {
                    foreach (string dir in miniGameConf.CompressTexture.FlareDirList)
                    {
                        if (path.Replace("\\", "/").IndexOf(dir) > -1)
                        {
                            isTextureAtlas = true;
                        }
                    }
                }

                
                if (texImport.alphaSource == TextureImporterAlphaSource.FromGrayScale)
                {

                    needUnityPng = true;
                }


                if (isTextureAtlas || texImport.spritesheet.Length > 0) {

                    var index = textureAtlasList.Add(path);
                    var newIndex = index;
                    while (textureAtlasDataList.ContainsKey(newIndex))
                    {
                        newIndex++; //id可能被占了
                    }

                    
                    textureAtlasDataList.Add(newIndex, new WXTextureData() {

                        width = texture.width,
                        height = texture.height,
                        dataHash = texture.imageContentsHash.ToString().Substring(0, 8),
                        path = path,
                        needUnityPng = needUnityPng
                    });

                    continue;
                }


                if (!textureList.Contains(path))
                {
                    
                    var index = textureList.Add(path);
                    textureDataList.Add(index, new WXTextureData()
                    {

                        width = texture.width,
                        height = texture.height,
                        dataHash = texture.imageContentsHash.ToString().Substring(0, 8),
                        path = path,
                        needUnityPng = needUnityPng

                    });


                }



            }


        }


        public static string GetManagedTextureDatas()
        {

            Dictionary<int, WXTextureData4Js> textureManagedList = new Dictionary<int, WXTextureData4Js>();



            if (textureList != null)
            {
                for (int i = 0; i < textureList.Count; i++)
                {

                    var data = textureDataList[i];

                    textureManagedList.Add(data.id, new WXTextureData4Js()
                    {
                        p = data.pathHash + "/" + data.fileName + "." + data.dataHash,
                        w = data.width,
                        h = data.height
                    });
                }

                return JsonMapper.ToJson(textureManagedList);
            }

            return "";

        }





        public static void Recover()
        {

            UnityEngine.Debug.Log("开始恢复");
            Init();


            var dst = textureDstDir;
            if (string.IsNullOrEmpty(dst))
            {
                UnityEngine.Debug.LogError("请先选择导出目录！");
                return;
            }




            UnityUtil.CopyDir(Path.Combine(dst, "backup", "Assets"), Application.dataPath);




            //WXSpriteAtlasManager.Recover();

            miniGameConf.CompressTexture.TextureRes = "";
            miniGameConf.CompressTexture.SpriteRes = "";

            wxTextureCacheObject = UnityUtil.GetTextureCacheConf();
            wxTextureCacheObject.textureAtlasList = null;
            wxTextureCacheObject.textureList = null;


            EditorUtility.SetDirty(miniGameConf);
            EditorUtility.SetDirty(wxTextureCacheObject);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            UnityEngine.Debug.Log("结束恢复！");
        }



        public static void SaveManagedResult()
        {

            var conf = UnityUtil.GetEditorConf();
            conf.CompressTexture.TextureRes = GetManagedTextureDatas();

            var textureCacheList = new List<WXTextureData>();
            foreach (var item in textureDataList) {
                textureCacheList.Add(item.Value);
            }
            


            var atlasList = new List<WXTextureData>();
            foreach (var item in textureAtlasDataList)
            {
                atlasList.Add(item.Value);
            }

            wxTextureCacheObject.textureList = textureCacheList;
            wxTextureCacheObject.textureAtlasList = atlasList;


            EditorUtility.SetDirty(conf);
            EditorUtility.SetDirty(wxTextureCacheObject);
            AssetDatabase.SaveAssets();

        }

        public static void CompressImageCallback(string pngPath, string filePrefix, int width, int height, bool needMin)
        {

            if (!File.Exists(filePrefix + ".astc.txt"))
            {
                PicCompressor.CompressASTC(pngPath, filePrefix + ".astc");
            }

            if (!miniGameConf.CompressTexture.OnlyAstc)
            {

                if (!File.Exists(filePrefix + ".pkm.txt"))
                {
                    PicCompressor.CompressETC2(pngPath, filePrefix + ".pkm");
                }

                if (width == height && !File.Exists(filePrefix + ".pvr.txt"))
                {
                    PicCompressor.CompressPVRTC(pngPath, filePrefix + ".pvr");
                }

                if (needMin)
                {
                    PicCompressor.CompressMinPNG(pngPath);
                }
            }

        }

        public static void GenerateUnityPng(string path) {

            TextureImporter texImport = AssetImporter.GetAtPath(path) as TextureImporter;

            var tips = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());

            if (tips.format!= TextureImporterFormat.RGBA32) {
                tips.format = TextureImporterFormat.RGBA32;
                tips.overridden = true;
                texImport.SetPlatformTextureSettings(tips);
                
            }
            texImport.isReadable = true;
            texImport.SaveAndReimport();
            

            var tx2d = AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;
            var bytes = tx2d.EncodeToPNG();

            path = path.Replace("\\", "/")+".png";
            var srcDir = path.Substring(0, path.LastIndexOf("/"));
            var dstDir = Path.Combine(textureDstDir, UnityPngDir,  srcDir);

            UnityUtil.CreateDir(dstDir);
            File.WriteAllBytes(Path.Combine(textureDstDir, UnityPngDir, path), bytes);

        }

        public static void GenerateImage(WXTextureData data)
        {

            var fileMd5 = data.dataHash;
            var src = data.path.Replace("\\", "/");
            var dirMd5 = data.pathHash;

            var fileName = data.fileName;
            var dstDir = Path.Combine(textureDstDir, WXEditorWindow.webglDir, "Assets/Textures/", dirMd5).Replace("\\", "/");
            var filePrefix = dstDir + "/" + fileName + "." + fileMd5;

            var backupPath = Path.Combine(textureDstDir, data.needUnityPng ? UnityPngDir : "backup" , data.path).Replace("\\", "/") + (data.needUnityPng ? ".png" : "");

            var pngPath = filePrefix+".png";

            if (File.Exists(pngPath))
            {
                CompressImageCallback(pngPath, filePrefix, data.width, data.height, false);
            }
            else {
                PicCompressor.CompressPNG(backupPath, pngPath, data.width, data.height, () => {

                    CompressImageCallback(pngPath, filePrefix, data.width, data.height, true);

                });
            }

        }


        public static void SaveCacheInfo(int id,  WXTextureData item, string type) {

            var path = item.path.Replace("\\", "/");
            var fileName = path.Substring(path.LastIndexOf("/") + 1);
            fileName = fileName.Substring(0, fileName.LastIndexOf("."));
            var srcDir = path.Substring(0, path.LastIndexOf("/"));
            var dirMd5 = UnityUtil.GetMd5Str(srcDir).Substring(0, 8);
            var list = textureDataList;
            if (type == "ATLAS") {
                list = textureAtlasDataList;
            }

            item.pathHash = dirMd5;
            item.fileName = fileName;
            item.path = path;

            list[id].height = item.height;
            list[id].width = item.width;
            list[id].fileName = item.fileName;
            list[id].path = item.path;
            list[id].id = item.id;
            list[id].lastWriteTime = item.lastWriteTime;
            list[id].pathHash = item.pathHash;
            list[id].dataHash = item.dataHash;

        }


        public static void ManageTextureAltas() {
            // 最多按255*255=65025 张图片算

            if (textureAtlasList.Count >= 255 * 255)
            {
                UnityEngine.Debug.LogError("您的图集数超出了限制！！");
                return;
            }

            Dictionary<string, int> path2AtlasDataIndex = new Dictionary<string, int>();
            foreach (var item in textureAtlasDataList) {
                path2AtlasDataIndex.Add(item.Value.path,item.Key);
            }


            // 执行替换图片逻辑
            for (int i = 0; i < textureAtlasList.Count; i++)
            {

                string p = (string)textureAtlasList[i];
                int textureAtlasDataIndex = path2AtlasDataIndex[p];

                var tx = AssetDatabase.LoadAssetAtPath(p, typeof(Texture2D)) as Texture2D;

                var text = File.ReadAllText(p + ".meta");

                var backupPath = Path.Combine(textureDstDir, "backup", p);


                UnityUtil.CreateDir(new DirectoryInfo(backupPath).Parent.ToString());

                File.Copy(p, backupPath, true);
                File.Copy(p + ".meta", backupPath + ".meta", true);

                if (textureAtlasDataList[textureAtlasDataIndex].needUnityPng)
                {
                    GenerateUnityPng(p);
                }

                text = ReplaceMetaFormat(p, text, "10");

                text = Regex.Replace(text, @"(isReadable: )\d", @"$1 0");
                text = Regex.Replace(text, @"(enableMipMap: )\d", @"$1 0");

                File.WriteAllText(p + ".meta", text);

                Texture2D texture2D;
                byte[] bytes;


                
                texture2D = new Texture2D(tx.width, tx.height, TextureFormat.RGBA4444, false);

                bytes = new byte[texture2D.GetRawTextureData().Length];

                var id = WXSpriteAtlasManager.AddPath2SpriteList(p);



                var r = id / (16 * 16);
                var g = (id / 16) % 16;
                var b = id % 16;

                texture2D.LoadRawTextureData(bytes);

                texture2D.SetPixel(0, 0, new Color()
                {
                    r = (float)r / 15,
                    g = (float)g / 15,
                    b = (float)b / 15
                });


                

                int width = tx.width;
                int height = tx.height;
                string dataHash = tx.imageContentsHash.ToString().Substring(0, 8);

                texture2D.Apply();

                

                File.WriteAllBytes(p, texture2D.EncodeToPNG());
                FileInfo fi = new FileInfo(p);

                SaveCacheInfo(textureAtlasDataIndex,
                    new WXTextureData
                {

                    width = width,
                    height = height,
                    dataHash = dataHash,
                    lastWriteTime = fi.LastWriteTime.ToString(),
                    id = id,
                    path = p
                },
                    "ATLAS"
                );

                WXSpriteAtlasManager.spriteAtlasMap.Add(id, p);

                WXSpriteAtlasManager.textureDataList.Add(id, textureAtlasDataList[i]);

            }
        }

        public static void ManageTextures()
        {

            // 最多按255*255=65025 张图片算


            if (textureList.Count >= 255 * 255)
            {
                UnityEngine.Debug.LogError("您的图片数超出了限制！！");
                return;
            }

            var textureCachePath2CacheObjectMap = new Dictionary<string, int>();
            wxTextureCacheObject = UnityUtil.GetTextureCacheConf();
            if (wxTextureCacheObject.textureList != null)
                for (var i = 0; i < wxTextureCacheObject.textureList.Count; i++)
                {

                    textureCachePath2CacheObjectMap.Add(wxTextureCacheObject.textureList[i].path, i);

                }

            Dictionary<int, string> placeholderId2PathMap = new Dictionary<int, string>();
            Dictionary<string, int> path2PlaceholderIdMap = new Dictionary<string, int>();
            List<string> cachedPathList = new List<string>();

            //先把调整次序，避免cache的id乱了
            for (int i = 0; i < textureList.Count; i++)
            {
                string p = (string)textureList[i];
                if (!textureCachePath2CacheObjectMap.ContainsKey(p)) {
                    int newIndex = i;
                    while (placeholderId2PathMap.ContainsKey(newIndex)) {
                        newIndex++;
                    }
                    path2PlaceholderIdMap.Add(p,newIndex);
                    placeholderId2PathMap.Add(newIndex, p);
                    continue;
                }
                var index = textureCachePath2CacheObjectMap[p];
                var item = wxTextureCacheObject.textureList[index];
                FileInfo fin = new FileInfo(p);
                if ( fin.LastWriteTime.ToString() == item.lastWriteTime)
                {
                    var itemRealId = item.id - 1;
                    cachedPathList.Add(p);
                    //说明是已经处理过的，不用再替换和生成纹理
                    if (itemRealId == i)
                    {
                        path2PlaceholderIdMap[p] = i;
                        placeholderId2PathMap[i] = p;
                    }
                    else if (placeholderId2PathMap.ContainsKey(itemRealId))
                    {
                        //id被前面的图给占用了
                        var tmpPath = placeholderId2PathMap[itemRealId];
                        path2PlaceholderIdMap[p] = itemRealId;
                        placeholderId2PathMap[itemRealId] = p;

                        int newIndex = i;
                        while (placeholderId2PathMap.ContainsKey(newIndex))
                        {
                            newIndex++;
                        }

                        path2PlaceholderIdMap[tmpPath] = newIndex;
                        placeholderId2PathMap[newIndex] = tmpPath;
                        
                    }
                    else {
                        path2PlaceholderIdMap[p] = itemRealId;
                        placeholderId2PathMap[itemRealId] = p;
                    }

                }
                else {
                    path2PlaceholderIdMap[p] = i;
                    placeholderId2PathMap[i] = p;

                }

            }
        

                // 执行替换图片逻辑
            for (int i = 0; i < textureList.Count; i++)
            {

                string p = (string)textureList[i];


                if (cachedPathList.IndexOf(p)>-1) {
                    //说明是已经处理过的，不用再替换和生成纹理
                    var index = textureCachePath2CacheObjectMap[p];
                    var item = wxTextureCacheObject.textureList[index];
                    SaveCacheInfo(i, item, "POT");
                    continue;

                }

                var tx = AssetDatabase.LoadAssetAtPath(p, typeof(Texture2D)) as Texture2D;

                int width = tx.width;
                int height = tx.height;

                string dataHash = tx.imageContentsHash.ToString().Substring(0, 8);

                if (miniGameConf.CompressTexture.halfSize) {
                    width = width / 2;
                    height = height / 2;
                    dataHash += "_";
                }
                

                

                var text = File.ReadAllText(p + ".meta");

                var backupPath = Path.Combine(textureDstDir, "backup", p);


                UnityUtil.CreateDir(new DirectoryInfo(backupPath).Parent.ToString());

                File.Copy(p, backupPath, true);
                File.Copy(p + ".meta", backupPath + ".meta", true);

                if (textureDataList[i].needUnityPng) {
                    GenerateUnityPng(p);
                }



                text = ReplaceMetaFormat(p, text, "10");

                text = Regex.Replace(text, @"(isReadable: )\d", @"$1 0");
                text = Regex.Replace(text, @"(enableMipMap: )\d", @"$1 0");

                File.WriteAllText(p + ".meta", text);

                Texture2D texture2D;

                byte[] bytes;


                int id = path2PlaceholderIdMap[p] + 1; //这里加1是为了避免0

                var onePlace = id % 255;
                var tenPlace = id / 255;

                texture2D = new Texture2D(4, 4, TextureFormat.RGB565, false);


                bytes = new byte[texture2D.GetRawTextureData().Length];

                bytes[0] = (byte)onePlace;
                bytes[1] = (byte)tenPlace;



                texture2D.LoadRawTextureData(bytes);



                texture2D.Apply();

                

                File.WriteAllBytes(p, texture2D.EncodeToPNG());
                FileInfo fi = new FileInfo(p);
                

                SaveCacheInfo(i, new WXTextureData
                {

                    width = width,
                    height = height,
                    dataHash = dataHash,
                    lastWriteTime = fi.LastWriteTime.ToString(),
                    id = id,
                    path = p

                }, "POT"
                );
            }

        }


        public static string[] GetWorkingFolders()
        {
            miniGameConf = UnityUtil.GetEditorConf();
            string[] folders = { "Assets" };

            if (miniGameConf.CompressTexture.SourceDirs.Count > 0)
            {
                folders = miniGameConf.CompressTexture.SourceDirs.ToArray();
            }

            return folders;

        }



    }
}
