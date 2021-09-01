using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using LitJson;

namespace WeChatWASM
{

    public class TextureSize
    {
        public int width;
        public int height;
    }

    public class WXTextureData4Js
    {
        public string p;
        public int w;
        public int h;
    }

    public class WXNotPotTextureData4Js
    {
        public string p;
    }

    public class JSTaskConf
    {
        public string dst;
        public string dataPath;
        public bool isAstcOnly;
        public bool lazyLoad;
        public List<QualityOptions> qualityList;
        public List<WXTextureData4Js> textureList;
        public List<WXTextureData4Js> noPotList;
    }



    public static class WXTextureManager
    {

        public static readonly string RecoverAssetsPath = "Assets/WX-WASM-SDK/Editor/TextureRecoverConfig.asset";

        public static int[] potList = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096 };

        public static ArrayList textureList;
        public static WXEditorScriptObject miniGameConf;
        public static Dictionary<int, TextureSize> textureSizeList;
        public static List<WXFormatItem> textureFormatList; //用于恢复

        public static List<WXFormatItem> noPotFormatList; //用于恢复
        public static ArrayList noPotList; //用于非POT图片的替换
        public static Dictionary<int, TextureSize> noPotSizeList;


        public static void Start()
        {

            miniGameConf = UnityUtil.GetEditorConf();

            if (string.IsNullOrEmpty(miniGameConf.ProjectConf.DST))
            {
                Debug.LogError("请先设置导出目录！");
                return;
            }

            textureList = new ArrayList();
            textureSizeList = new Dictionary<int, TextureSize>();
            textureFormatList = new List<WXFormatItem>();

            noPotList = new ArrayList();
            noPotSizeList = new Dictionary<int, TextureSize>();
            noPotFormatList = new List<WXFormatItem>();

            PicCompressor.ClearFailedTask();

            try
            {
                WXSpriteAtlasManager.Start();

                FindTexture();

                SavePathList();
                ManageTextures();

                if (miniGameConf.CompressTexture.LazyLoadNotPot)
                {
                    ManageNoPot();
                }

                WXSpriteAtlasManager.SaveManagedResult(WXSpriteAtlasManager.GetManagedSpriteDatas());

                SaveManagedResult();


            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                SavePathList();
            }

            PicCompressor.SaveFailedTask();


            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);


            if (miniGameConf.CompressTexture.TooManyFiles)
            {

                CreateJSTask();

            }
            else {
                DoGenerateImage();
            }


        }


        public static void CreateJSTask() {

            var list1 = new List<WXTextureData4Js>();

            if (textureList != null && textureList.Count > 0)
            {
                for (int i = 0; i < textureList.Count; i++)
                {

                    var size = textureSizeList[i];

                    list1.Add(new WXTextureData4Js()
                    {
                        p = textureList[i].ToString(),
                        w = size.width,
                        h = size.height
                    });

                }
            }


            var list2 = new List<WXTextureData4Js>();



            if (noPotList != null && noPotList.Count > 0)
            {
                for (int i = 0; i < noPotList.Count; i++)
                {

                    var size = noPotSizeList[i];

                    list2.Add(new WXTextureData4Js()
                    {
                        p = noPotList[i].ToString(),
                        w = size.width,
                        h = size.height
                    });
                }
                
            }

            var conf = new JSTaskConf()
            {
                dst = miniGameConf.ProjectConf.DST,
                dataPath = Application.dataPath,
                isAstcOnly = miniGameConf.CompressTexture.OnlyAstc,
                lazyLoad = miniGameConf.CompressTexture.LazyLoadNotPot,
                qualityList = miniGameConf.CompressTexture.QualityList,
                textureList = list1,
                noPotList = list2
            };

            File.WriteAllText(Application.dataPath+ "/WX-WASM-SDK/Editor/Node/conf.js", "module.exports = "+JsonMapper.ToJson(conf));

            Debug.LogWarning("请安装 Nodejs 然后进入WX-WASM-SDK/Editor/Node 目录用命令行，执行 ’node compressor.js‘ 来命令生成纹理。");

        }

        public static void DoGenerateImage()
        {

            for (int i = 0; i < textureList.Count; i++)
            {
                string p = (string)textureList[i];

                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", p);

                TextureSize textureSize = textureSizeList[i];

                GenerateImage(p, backupPath, textureSize.width, textureSize.height);
            }

            for (int i = 0; i < noPotList.Count; i++)
            {
                string p = (string)noPotList[i];

                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", p);

                TextureSize textureSize = noPotSizeList[i];

                GenerateImagePNG(p, backupPath, textureSize.width, textureSize.height);
            }
            
        }

        public static void FindTexture()
        {


            var list = AssetDatabase.FindAssets("t:texture", GetWorkingFolders());


            foreach (string guid in list)
            {

                bool isBad = false;
                var path = AssetDatabase.GUIDToAssetPath(guid);

                if (WXSpriteAtlasManager.spriteList.Contains(path))
                {
                    continue;
                }

                if (Regex.IsMatch(path.ToLower(), @"(\bcodeandweb\.com\b|\bexample\b|\.bak$|\bwx-wasm-sdk\b|\.ttf$|\beditor\b|\.rendertexture$)") || !Regex.IsMatch(path, @"^Assets\b"))
                {
                    continue;
                }


                if (Regex.IsMatch(path.ToLower(), @"(\.psd$)"))
                {
                    Debug.LogWarning(path + " psd 文件可能会导致转换失败，请避免使用该格式并注意查看是否正常展示。");

                    // isBad = true;
                }

                if (Regex.IsMatch(path.ToLower(), @"(\.tif$)"))
                {
                    Debug.LogWarning(path + " tif 文件可能会导致转换失败，请避免使用该格式并注意查看是否正常展示。");

                    //  isBad = true;
                }


                if (Regex.IsMatch(path.ToLower(), @"(\.gif$)"))
                {
                    Debug.LogWarning(path + " gif 文件不支持压缩纹理！");

                    isBad = true;
                }


                var texture = AssetDatabase.LoadAssetAtPath(path, typeof(Texture)) as Texture;
                if (texture == null)
                {
                    continue;
                }


                if (texture.isReadable)
                {
                    Debug.LogWarning(path + " readable 文件不支持压缩纹理！请尝试去掉readable。");

                    isBad = true;
                }

                TextureImporter texImport = AssetImporter.GetAtPath(path) as TextureImporter;
                if (texImport == null)
                {
                    continue;
                }

                var tips = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());

                if (texImport.textureType == TextureImporterType.SingleChannel)
                {
                    continue;
                }

                if (texImport.textureType == TextureImporterType.NormalMap || texImport.textureType == TextureImporterType.Lightmap)
                {

                    Debug.LogWarning("图片 ：" + path + " NormalMap或者Lightmap暂不支持压缩纹理。");
                    switch (tips.format)
                    {
                        case TextureImporterFormat.DXT5:
                        case TextureImporterFormat.DXT5Crunched:
                        case (TextureImporterFormat)(-1):
                            tips.format = TextureImporterFormat.RGBA32;
                            tips.overridden = true;
                            texImport.SetPlatformTextureSettings(tips);
                            AssetDatabase.ImportAsset(path);
                            break;
                    }
                    continue;
                }


                if (System.Array.IndexOf(potList, texture.width) == -1 || System.Array.IndexOf(potList, texture.height) == -1)
                {
                    Debug.LogWarning("图片 ：" + path + " 的宽高不是2的幂，因此不会被转化为压缩纹理！请改为POT或者使用图集！");

                    if (miniGameConf.CompressTexture.LazyLoadNotPot && !noPotList.Contains(path))
                    {
                        noPotList.Add(path);

                        noPotFormatList.Add(new WXFormatItem()
                        {
                            path = path,
                            format = tips.format
                        });
                        var index = noPotList.IndexOf(path);

                        noPotSizeList.Add(index, new TextureSize()
                        {
                            width = texture.width,
                            height = texture.height
                        });

                    }


                    continue;
                }


                if (isBad)
                {

                    // 移动端不支持DXT压缩纹理就不要跑到那个分支去了

                    if (tips.format == TextureImporterFormat.DXT1 || tips.format == TextureImporterFormat.DXT1Crunched || (tips.format == (TextureImporterFormat)(-1) && Regex.IsMatch(path.ToLower(), @"(\.jpg|\.jpeg$)")))
                    {
                        tips.format = TextureImporterFormat.RGB24;
                        tips.overridden = true;
                        texImport.SetPlatformTextureSettings(tips);
                        AssetDatabase.ImportAsset(path);
                    }
                    else if (tips.format == TextureImporterFormat.DXT5 || tips.format == TextureImporterFormat.DXT5Crunched || (tips.format == (TextureImporterFormat)(-1) && !Regex.IsMatch(path.ToLower(), @"(\.jpg|\.jpeg$)")))
                    {
                        tips.format = TextureImporterFormat.RGBA32;
                        tips.overridden = true;
                        texImport.SetPlatformTextureSettings(tips);
                        AssetDatabase.ImportAsset(path);
                    }

                    continue;
                }

                if (!textureList.Contains(path))
                {
                    textureList.Add(path);
                    var index = textureList.IndexOf(path);
                    textureSizeList.Add(index, new TextureSize()
                    {
                        width = texture.width,
                        height = texture.height
                    });

                    textureFormatList.Add(new WXFormatItem()
                    {
                        path = path,
                        format = tips.format
                    });

                }



            }


        }


        public static string GetManagedTextureDatas()
        {

            Dictionary<int, WXTextureData4Js> textureNanagedList = new Dictionary<int, WXTextureData4Js>();



            if (textureList != null && textureList.Count > 0)
            {
                for (int i = 0; i < textureList.Count; i++)
                {


                    var assstPath = textureList[i].ToString();

                    var id = i + 1; //都加了1避免0

                    var size = textureSizeList[i];

                    textureNanagedList.Add(id, new WXTextureData4Js()
                    {
                        p = Regex.Replace(assstPath, @"^Assets(\\|\/)", ""),
                        w = size.width,
                        h = size.height
                    });
                }
                return JsonMapper.ToJson(textureNanagedList);
            }
            return "";

        }

        public static string GetManagedNotPOTDatas()
        {

            Dictionary<int, WXNotPotTextureData4Js> textureNanagedList = new Dictionary<int, WXNotPotTextureData4Js>();

            if (noPotList != null && noPotList.Count > 0)
            {
                for (int i = 0; i < noPotList.Count; i++)
                {


                    var assstPath = noPotList[i].ToString();

                    var id = i + 1; //都加了1避免0


                    textureNanagedList.Add(id, new WXNotPotTextureData4Js()
                    {
                        p = Regex.Replace(assstPath, @"^Assets(\\|\/)", "")
                    });
                }
                return JsonMapper.ToJson(textureNanagedList);
            }
            return "";

        }


        public static void Recover()
        {
            miniGameConf = UnityUtil.GetEditorConf();

            var dst = miniGameConf.ProjectConf.DST;
            if (string.IsNullOrEmpty(dst))
            {
                Debug.LogError("请先选择导出目录！");
                return;
            }

            var conf = WXEditorWindow.LoadTextureRecoverConf();

            if (conf.textureList == null)
            {
                conf.textureList = new List<WXFormatItem>();
            }
            if (conf.spriteList == null)
            {
                conf.spriteList = new List<WXFormatItem>();
            }
            if (conf.noPotList == null)
            {
                conf.noPotList = new List<WXFormatItem>();
            }

            if (conf.textureList.Count == 0 && conf.spriteList.Count == 0 && conf.noPotList.Count == 0)
            {
                Debug.LogWarning("恢复信息为空，无需恢复。");
                return;
            }



            var list = new[] { conf.textureList, conf.spriteList, conf.noPotList };

            for (var i = 0; i < list.Length; i++)
            {

                var recoverSuccessList = new ArrayList();
                foreach (WXFormatItem item in list[i])
                {
                    var p = item.path;
                    var backupPath = Path.Combine(dst, "backup", p);

                    if (!File.Exists(backupPath))
                    {
                        Debug.LogWarning("文件：" + backupPath + "已经不存在！");
                        continue;
                    }
                    if (File.Exists(p))
                    {
                        File.Delete(p);
                    }
                    File.Move(backupPath, p);

                    TextureImporter texImport = AssetImporter.GetAtPath(p) as TextureImporter;


                    if (texImport == null)
                    {
                        continue;
                    }


                    var setting = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());

                    setting.overridden = true;

                    setting.format = item.format;

                    texImport.SetPlatformTextureSettings(setting);

                    AssetDatabase.ImportAsset(p);

                    recoverSuccessList.Add(item);

                }

                foreach (WXFormatItem item in recoverSuccessList)
                {
                    list[i].Remove(item);
                }


            }


            WXSpriteAtlasManager.Recover();

            EditorUtility.SetDirty(conf);

            miniGameConf.CompressTexture.NotPotTextureRes = "";
            miniGameConf.CompressTexture.TextureRes = "";
            miniGameConf.CompressTexture.SpriteRes = "";

            EditorUtility.SetDirty(miniGameConf);
            AssetDatabase.SaveAssets();

        }

        public static void SavePathList()
        {

            var conf = WXEditorWindow.LoadTextureRecoverConf();
            conf.textureList = textureFormatList;
            conf.spriteList = WXSpriteAtlasManager.textureFormatList;
            conf.noPotList = noPotFormatList;

            EditorUtility.SetDirty(conf);
            AssetDatabase.SaveAssets();


        }

        public static void SaveManagedResult()
        {

            var conf = UnityUtil.GetEditorConf();
            conf.CompressTexture.TextureRes = GetManagedTextureDatas();
            conf.CompressTexture.NotPotTextureRes = GetManagedNotPOTDatas();

            EditorUtility.SetDirty(conf);
            AssetDatabase.SaveAssets();

        }


        public static void GenerateImage(string src, string backupPath, int width, int height)
        {


            src = src.Replace("\\", "/");
            var fileName = src.Substring(src.LastIndexOf("/") + 1);
            var dstDir = Path.Combine(miniGameConf.ProjectConf.DST, WXEditorWindow.webglDir, src.Substring(0, src.LastIndexOf("/"))).Replace("\\", "/");



            var pngPath = Path.Combine(dstDir, fileName + ".png");



            PicCompressor.CompressPNG(backupPath, pngPath, width, height, () => {

                 PicCompressor.CompressASTC(pngPath, Path.Combine(dstDir, fileName + ".astc"));
                
                 if (!miniGameConf.CompressTexture.OnlyAstc)
                 {
                     PicCompressor.CompressETC2(pngPath, Path.Combine(dstDir, fileName + ".pkm"));
                     if (width == height)
                     {
                         PicCompressor.CompressPVRTC(pngPath, Path.Combine(dstDir, fileName + ".pvr"));
                     }

                     PicCompressor.CompressMinPNG(pngPath);
                 }
                
            });


        }


        public static void GenerateImagePNG(string src, string backupPath, int width, int height)
        {


            src = src.Replace("\\", "/");
            var fileName = src.Substring(src.LastIndexOf("/") + 1);
            var dstDir = Path.Combine(miniGameConf.ProjectConf.DST, WXEditorWindow.webglDir, src.Substring(0, src.LastIndexOf("/"))).Replace("\\", "/");

            var pngPath = Path.Combine(dstDir, fileName + ".png");



            PicCompressor.CompressPNG(backupPath, pngPath, width, height, () => {

                PicCompressor.CompressMinPNG(pngPath);

            });

        }


        public static void ManageNoPot()
        {
            // 目前最多按255*255=65025 张图片算


            if (noPotList.Count >= 255 * 255)
            {
                Debug.LogError("您的非POT图片数超出了限制！！");
                return;
            }

            // 执行替换图片逻辑
            for (int i = 0; i < noPotList.Count; i++)
            {

                string p = (string)noPotList[i];

                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", p);


                if (File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                }

                UnityUtil.CreateDir(new DirectoryInfo(backupPath).Parent.ToString());

                File.Copy(p, backupPath);

                TextureImporter texImport = AssetImporter.GetAtPath(p) as TextureImporter;

                var setting = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());

                setting.format = TextureImporterFormat.DXT1;

                texImport.SetPlatformTextureSettings(setting);

                texImport.isReadable = false;
                texImport.mipmapEnabled = false;

                AssetDatabase.ImportAsset(p);


                Texture2D texture2D;

                var isFlare = false;
                foreach (string flareDir in miniGameConf.CompressTexture.FlareDirList)
                {
                    if (p.Replace("\\", "/").IndexOf(flareDir) > -1)
                    {
                        isFlare = true;
                    }
                }


                byte[] bytes;

                if (texImport.spritesheet.Length == 0 && !isFlare)
                {

                    int id = i + 1; //这里加1是为了避免0

                    var onePlace = id % 255;
                    var tenPlace = id / 255;

                    texture2D = new Texture2D(8, 8, TextureFormat.RGB565, false);


                    bytes = new byte[texture2D.GetRawTextureData().Length];

                    bytes[0] = (byte)onePlace;
                    bytes[1] = (byte)tenPlace;

                    texture2D.LoadRawTextureData(bytes);

                    texture2D.Apply();

                    File.WriteAllBytes(p, texture2D.EncodeToPNG());

                }
                else
                {

                    // 图集
                    Debug.LogError("图片使用了图集，需要将其改成POT尺寸的图片：" + p);

                }


            }

            /*

            for (int i = 0; i < noPotList.Count; i++)
            {
                string p = (string)noPotList[i];

                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", p);

                TextureSize textureSize = noPotSizeList[i];

                GenerateImagePNG(p, backupPath, textureSize.width, textureSize.height);
            }
            */
        }

        public static void ManageTextures()
        {

            // 最多按255*255=65025 张图片算


            if (textureList.Count >= 255 * 255)
            {
                Debug.LogError("您的图片数超出了限制！！");
                return;
            }



            // 执行替换图片逻辑
            for (int i = 0; i < textureList.Count; i++)
            {

                string p = (string)textureList[i];

                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", p);


                if (File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                }

                UnityUtil.CreateDir(new DirectoryInfo(backupPath).Parent.ToString());

                File.Copy(p, backupPath);

                TextureImporter texImport = AssetImporter.GetAtPath(p) as TextureImporter;

                var setting = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());

                setting.format = TextureImporterFormat.DXT1;

                texImport.SetPlatformTextureSettings(setting);

                texImport.isReadable = false;
                texImport.mipmapEnabled = false;

                AssetDatabase.ImportAsset(p);

                TextureSize textureSize = textureSizeList[i];

                Texture2D texture2D;

                var isFlare = false;
                foreach (string flareDir in miniGameConf.CompressTexture.FlareDirList)
                {
                    if (p.Replace("\\", "/").IndexOf(flareDir) > -1)
                    {
                        isFlare = true;
                    }
                }


                byte[] bytes;

                if (texImport.spritesheet.Length == 0 && !isFlare)
                {

                    int id = i + 1; //这里加1是为了避免0

                    var onePlace = id % 255;
                    var tenPlace = id / 255;

                    texture2D = new Texture2D(4, 4, TextureFormat.RGB565, false);


                    bytes = new byte[texture2D.GetRawTextureData().Length];

                    bytes[0] = (byte)onePlace;
                    bytes[1] = (byte)tenPlace;

                    texture2D.LoadRawTextureData(bytes);

                }
                else
                {

                    // 图集
                    var tx = AssetDatabase.LoadAssetAtPath(p, typeof(Texture2D)) as Texture2D;

                    texture2D = new Texture2D(tx.width, tx.height, TextureFormat.RGBA4444, false);

                    bytes = new byte[texture2D.GetRawTextureData().Length];

                    WXSpriteAtlasManager.spriteList.Add(p);

                    var id = WXSpriteAtlasManager.spriteList.IndexOf(p) + 1;

                    WXSpriteAtlasManager.spriteAtlasMap.Add(id, p);

                    WXSpriteAtlasManager.textureSizeList.Add(id, new TextureSize()
                    {
                        width = textureSize.width,
                        height = textureSize.height
                    });

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

                }


                texture2D.Apply();

                File.WriteAllBytes(p, texture2D.EncodeToPNG());

            }

            /*

            for (int i = 0; i < textureList.Count; i++)
            {
                string p = (string)textureList[i];

                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", p);

                TextureSize textureSize = textureSizeList[i];

                GenerateImage(p, backupPath, textureSize.width, textureSize.height);
            }
            */
        }


        public static string[] GetWorkingFolders()
        {

            string[] folders = { "Assets" };

            if (miniGameConf.CompressTexture.SourceDirs.Count > 0)
            {
                folders = miniGameConf.CompressTexture.SourceDirs.ToArray();
            }

            return folders;

        }

        public static void TextureContinueConver(string srcPath)
        {

            if (!Directory.Exists(srcPath))
            {
                Debug.LogError("文件夹不存在！");
                return;
            }
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();

                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        TextureContinueConver(i.FullName);
                    }
                    else
                    {
                        var prefix = i.FullName.Substring(0, i.FullName.Length - 4);
                        if (i.Extension == ".png" && File.Exists(prefix + ".astc.txt") && !File.Exists(prefix + ".pkm.txt"))
                        {
                            var pngPath = i.FullName;
                            PicCompressor.CompressETC2(pngPath, prefix + ".pkm");

                            // 先都生成pvr，正常应该要按照宽高是否相等来判断是否需要生成
                            PicCompressor.CompressPVRTC(pngPath, prefix + ".pvr");

                            PicCompressor.CompressMinPNG(pngPath);
                        }

                    }
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }


        }



    }
}
