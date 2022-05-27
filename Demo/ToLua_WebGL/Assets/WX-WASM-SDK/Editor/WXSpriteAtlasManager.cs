using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using LitJson;
using UnityEditor;
using UnityEditor.Sprites;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace WeChatWASM
{
    public class WXSpriteData {
        public Rect rect;
    }

    public class WXSpriteAtlasCachedDataItem {
        public int width;
        public int height;
        public string dataHash;
        public int id;
    }

    public class WXSpriteAtlasCachedSprite{
        public string path;
        public string hash;
    }

    public class WXSpriteAtlasCacheData
    {

        public string altasHash;
        public string pathHash;
        public WXSpriteAtlasCachedSprite[] sprites;
        public WXSpriteAtlasCachedDataItem[] datas;

    }

    public class WXSpriteAtlasManager
    {


        public static Dictionary<int, string> spriteAtlasMap;
        public static Dictionary<int, WXTextureData> textureDataList;
        public static WXEditorScriptObject miniGameConf;
        public static Dictionary<string, WXSpriteData> spriteDataList;


        public static Dictionary<int, string> spriteAtlasList; //用来保存图集
        public static List<string> spriteItemList; //用来保存单个图

        public static void Init() {

            spriteAtlasMap = new Dictionary<int, string>();
            textureDataList = new Dictionary<int, WXTextureData>();
            spriteDataList = new Dictionary<string, WXSpriteData>();

            spriteAtlasList = new Dictionary<int, string>();
            spriteItemList = new List<string>();
        }


        public static void Start()
        {
            
            miniGameConf = UnityUtil.GetEditorConf();

            SpriteAtlasUtility.PackAllAtlases(BuildTarget.WebGL);

            var list = AssetDatabase.FindAssets("t:spriteatlas", WXTextureManager.GetWorkingFolders());
            list = list.GroupBy(p => p).Select(p => p.Key).ToArray();

            var cachedPath = new ArrayList();

            foreach (string guid in list)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);

                var isCacheAvailable = HandleSpriteAtlasCache(path);

                if (isCacheAvailable)
                {
                    cachedPath.Add(path);

                }

            }


            foreach (string guid in list)
            {

                var path = AssetDatabase.GUIDToAssetPath(guid);

                if (cachedPath.IndexOf(path) !=-1) {
                    
                    continue;
                }


                Debug.Log("no cache spriteatlas:"+path);

                SpriteAtlas spriteAtlas = AssetDatabase.LoadAssetAtPath(path, typeof(SpriteAtlas)) as SpriteAtlas;

                Sprite[] sprites = new Sprite[spriteAtlas.spriteCount];
                spriteAtlas.GetSprites(sprites);


                var backupPath = Path.Combine(WXTextureManager.textureDstDir, "backup", path);
                UnityUtil.CreateDir(new DirectoryInfo(backupPath).Parent.ToString());
                File.Copy(path, backupPath, true);

                TextureImporterPlatformSettings tips = spriteAtlas.GetPlatformSettings(BuildTarget.WebGL.ToString());
                tips.overridden = true;
                tips.format = TextureImporterFormat.RGBA32;
                spriteAtlas.SetPlatformSettings(tips);

                var sats = spriteAtlas.GetTextureSettings();
                sats.generateMipMaps = false;
                sats.readable = false;
                spriteAtlas.SetTextureSettings(sats);

                var sps = spriteAtlas.GetPackingSettings();
                sps.enableRotation = false;
                sps.enableTightPacking = false;
                spriteAtlas.SetPackingSettings(sps);

                

                foreach (Sprite s in sprites)
                {

                    var spritePath = AssetDatabase.GetAssetPath(s.texture);
                    if (string.IsNullOrEmpty(spritePath))
                    {
                        continue;
                    }

                    TextureImporter texImport = AssetImporter.GetAtPath(spritePath) as TextureImporter;

                    if (!texImport.isReadable)
                    {
                        texImport.isReadable = true;
                        AssetDatabase.ImportAsset(spritePath);
                    }
                    var key = AssetDatabase.GetAssetPath(s.texture);
                    spriteDataList.Add(key,new WXSpriteData() {

                        rect = GetRect(SpriteUtility.GetSpriteUVs(s, false),s.texture.width, s.texture.height)

                    });


                }

                var cacheData = new WXSpriteAtlasCacheData();
                cacheData.sprites = new WXSpriteAtlasCachedSprite[sprites.Length];

                foreach (Sprite s in sprites) {

                    var spritePath = AssetDatabase.GetAssetPath(s.texture);
                    if (string.IsNullOrEmpty(spritePath)) {
                        continue;
                    }
                    if (spriteItemList.Contains(spritePath))
                    {
                        UnityEngine.Debug.LogError("图片：" + spritePath + " 被多个图集重复使用了！这是不允许的，请修正！");
                        continue;
                    }

                    spriteItemList.Add(spritePath);


                    ReplaceTexture(spritePath, 0);


                }

                AssetDatabase.Refresh();  //需要刷新一边，不然获取的key会有问题


                SpriteAtlasUtility.PackAtlases(new SpriteAtlas[] { spriteAtlas }, BuildTarget.WebGL);


                tips.format = TextureImporterFormat.RGBA32;
                spriteAtlas.SetPlatformSettings(tips);

                GeneratePNG(path, cacheData);


                tips.format = TextureImporterFormat.DXT1;
                spriteAtlas.SetPlatformSettings(tips);


                sats.readable = false;
                spriteAtlas.SetTextureSettings(sats);

                //AssetDatabase.ImportAsset(path);


                var cacheText = File.ReadAllText(path);
                cacheText = Regex.Replace(cacheText, @"(m_TextureFormat:) \d{1,2}", @"$1 10");

                cacheData.altasHash = UnityUtil.GetMd5Str(cacheText);

                var cacheConfPath = Path.Combine(WXTextureManager.textureDstDir, "spriteAtlas", path + ".json");
                UnityUtil.CreateDir(new DirectoryInfo(cacheConfPath).Parent.ToString());
                File.WriteAllText(cacheConfPath, JsonMapper.ToJson(cacheData));

            }

        }

        public static int AddPath2SpriteAtlasList(string path)
        {
            int i = 1; //从1开始避免0
            while (true)
            {
                if (!spriteAtlasList.ContainsKey(i))
                {
                    spriteAtlasList.Add(i, path);
                    return i;
                }
                i++;
            }
        }

        public static void AddPath2SpriteAtlasList(string path,int id)
        {
            spriteAtlasList.Add(id,path);
        }



        public static bool PathIsInSpriteAtlas(string path) {
            return spriteItemList.Contains(path);
        }

        public static bool HandleSpriteAtlasCache(string path) {
            var cachePath = Path.Combine(WXTextureManager.textureDstDir, "spriteAtlas", path + ".json");
            if (!File.Exists(cachePath))
            {
                return false;
            }

            SpriteAtlas spriteAtlas = AssetDatabase.LoadAssetAtPath(path, typeof(SpriteAtlas)) as SpriteAtlas;

            Sprite[] sprites = new Sprite[spriteAtlas.spriteCount];
            spriteAtlas.GetSprites(sprites);

            var isAvailable = true;
            var cacheData = JsonMapper.ToObject<WXSpriteAtlasCacheData>(File.ReadAllText(cachePath));
            if (cacheData.sprites.Length !=sprites.Length) {
                isAvailable =  false;
            }

            var spriteAtlasMd5 = UnityUtil.GetMd5Str(File.ReadAllText(path));
            if (spriteAtlasMd5 != cacheData.altasHash) {
                isAvailable = false;
            }

            var spriteHashes = new string[cacheData.sprites.Length];
            var spritePaths = new string[cacheData.sprites.Length];
            for (var i=0;i<spriteHashes.Length;i++) {
                spriteHashes[i] = cacheData.sprites[i].hash;
                spritePaths[i] = cacheData.sprites[i].path;
            }

            foreach (var sprite in sprites) {
                if (ArrayUtility.IndexOf(spriteHashes, sprite.texture.imageContentsHash.ToString())==-1) {
                    isAvailable = false;
                    break;
                }
            }



            if (!isAvailable)
            {

                foreach (var sprite in sprites)
                {
                    var index = ArrayUtility.IndexOf(spriteHashes, sprite.texture.imageContentsHash.ToString());
                    if (index != -1)
                    {
                        var texturePath = Path.Combine(WXTextureManager.textureDstDir, "backup", spritePaths[index]);
                        if (!File.Exists(texturePath))
                        {
                            Debug.LogError("恢复文件已丢失，请手动还原图片：" + spritePaths[index]);
                        }
                        else
                        {
                            File.Copy(texturePath, spritePaths[index], true);
                            File.Delete(texturePath);
                        }
                    }
                }

                File.Delete(cachePath);

            }
            else {

                for (var i=0; i<cacheData.datas.Length; i++) {

                    var data = cacheData.datas[i];

                    spriteAtlasMap.Add(data.id, path.Replace(".spriteatlas", "_" + i + ".png"));

                    var item = new WXTextureData()
                    {

                        width = data.width,
                        height = data.height,
                        fileName = spriteAtlas.name + "_" + i,
                        dataHash = data.dataHash,
                        pathHash = cacheData.pathHash,
                        path = ""

                    };

                    textureDataList.Add(data.id, item);

                    AddPath2SpriteAtlasList(path, data.id); //就是为了占位，不要让别的图把这个id占了

                    if (!WXTextureManager.miniGameConf.CompressTexture.TooManyFiles)
                    {
                        DoGeneratePNG(item);
                    }

                }

                

                foreach (var item in cacheData.sprites) {
                    spriteItemList.Add(item.path);
                }

                

            }

            

            return isAvailable;
        }

        public static void SaveManagedResult()
        {

            var conf = UnityUtil.GetEditorConf();
            conf.CompressTexture.SpriteRes = GetManagedSpriteDatas();

            EditorUtility.SetDirty(conf);
            AssetDatabase.SaveAssets();


        }


        public static string GetManagedSpriteDatas()
        {

            if (spriteAtlasMap.Count>0) {
                var result = new Dictionary<int, WXTextureData4Js>();
                foreach (var item in spriteAtlasMap) {
                    var data = textureDataList[item.Key];
                    result.Add(item.Key, new WXTextureData4Js() {
                        p = string.Format("{0}/{1}.{2}",data.pathHash,data.fileName,data.dataHash),
                        w = textureDataList[item.Key].width,
                        h = textureDataList[item.Key].height
                    });
                }

                return JsonMapper.ToJson(result);
            }
            return "";

        }

        public static void SaveSpriteAtlasKey(int id,int index,string path,int width,int height) {
            spriteAtlasMap.Add(id, path.Replace(".spriteatlas", "_" + index + ".png"));

            textureDataList.Add(id, new WXTextureData()
            {
                width = width,
                height = height
            });
        }

        /*
        public static void SaveSpriteAtlasKey(SpriteAtlas spriteAtlas, string path) {
            var txs = GetPreviewTexture(spriteAtlas);
            for (var i = 0; i < txs.Length; i++) {
                var tx = txs[i];
                var bytes = tx.GetRawTextureData();
                var bitTex = System.Convert.ToString(bytes[1], 2).PadLeft(8, '0') + System.Convert.ToString(bytes[0],2).PadLeft(8, '0');

                var r = System.Convert.ToInt32(bitTex.Substring(0, 5), 2);
                var g = System.Convert.ToInt32(bitTex.Substring(5, 6), 2);
                var b = System.Convert.ToInt32(bitTex.Substring(11, 5), 2);
                var id = System.Math.Round(r * 1f / 31 * 15) *16*16 + System.Math.Round(g * 1f / 63 * 15)*16 + System.Math.Round(b * 1f / 31 * 15);


                spriteAtlasMap.Add((int)id, path.Replace(".spriteatlas", "_"+i+".png"));

                textureDataList.Add((int)id, new WXTextureData()
                {
                    width = tx.width,
                    height = tx.height
                });


            }

        }
        */

        public static Rect GetRect(Vector2[] uvs, int width, int height)
        {
            // 左下角是（0，0）

            float left = uvs[0].x;
            float right = uvs[0].x;
            float top = uvs[0].y;
            float bottom = uvs[0].y;
            foreach (Vector2 vector2 in uvs)
            {


                var x = vector2.x;
                var y = vector2.y;

                if (x < left)
                {
                    left = x;
                }
                if (x > right)
                {
                    right = x;
                }
                if (y < bottom)
                {
                    bottom = y;
                }
                if (y > top)
                {
                    top = y;
                }
            }

            return new Rect()
            {
                x = (float)System.Math.Round(width * left),
                y = (float)System.Math.Round(height * bottom),
                width = width * (right - left),
                height = height * (top - bottom)
            };

        }

        public static Texture2D[] GetPreviewTexture(SpriteAtlas atlas) {
            SpriteAtlasUtility.PackAtlases(new SpriteAtlas[] { atlas }, EditorUserBuildSettings.activeBuildTarget);
            MethodInfo getPreviewTextureMI = typeof(SpriteAtlasExtensions).GetMethod("GetPreviewTextures", BindingFlags.Static | BindingFlags.NonPublic);
            Texture2D[] atlasTextures = (Texture2D[])getPreviewTextureMI.Invoke(null, new Object[] { atlas });
            return atlasTextures;
        }

        public static void CompressPNGCallback(string filePrefix, bool needPvr, bool needMin) {


            if (!File.Exists(filePrefix + ".astc.txt")) {
                PicCompressor.CompressASTC(filePrefix + ".png", filePrefix + ".astc");
            }
            

            if (!WXTextureManager.miniGameConf.CompressTexture.OnlyAstc)
            {
                if (!File.Exists(filePrefix + ".pkm.txt")) {
                    PicCompressor.CompressETC2(filePrefix + ".png", filePrefix + ".pkm");
                }

                if (WXTextureManager.miniGameConf.CompressTexture.useDXT5 && !File.Exists(filePrefix + ".dds.txt"))
                {
                    PicCompressor.CompressDXT5(filePrefix + ".png", filePrefix + ".dds");
                }

                if (needPvr && !File.Exists(filePrefix + ".pvr.txt"))
                {
                    PicCompressor.CompressPVRTC(filePrefix + ".png", filePrefix + ".pvr");
                }
                if (needMin) {
                    PicCompressor.CompressMinPNG(filePrefix + ".png");
                }
                
            }

        }

        public static int GetIdByAtlasPath(string path, int index) {

            foreach (var item in spriteAtlasMap) {
                if (item.Value == path.Replace(".spriteatlas", "_" + index + ".png"))
                {
                    return item.Key;
                }
            }
            UnityEngine.Debug.LogError("SpriteAtlas查找Id失败");
            return 0;

        }

        public static void DoGeneratePNG(WXTextureData item) {


            var dstDir = Path.Combine(WXTextureManager.textureDstDir, WXEditorWindow.webglDir, "Assets/Textures", item.pathHash).Replace("\\", "/");
            var tmpDir = Path.Combine(WXTextureManager.textureDstDir, "spriteAtlas", item.pathHash).Replace("\\", "/");


            var tmpPath = string.Format("{0}/{1}.{2}.png", tmpDir, item.fileName, item.dataHash);
            string filePrefix = string.Format("{0}/{1}.{2}", dstDir, item.fileName, item.dataHash);
            string pngPath = filePrefix + ".png";
            UnityUtil.CreateDir(dstDir);

            bool needPvr = item.width == item.height && System.Array.IndexOf(WXTextureManager.potList, item.width) > -1;
            if (!File.Exists(pngPath))
            {
                PicCompressor.CompressPNG(tmpPath, pngPath, item.width, item.height, () =>
                {
                    CompressPNGCallback(filePrefix, needPvr, true);
                });
            }
            else
            {
                CompressPNGCallback(filePrefix, needPvr, true);
            }



        }

        public static void GeneratePNG(string spriteAtlasPath, WXSpriteAtlasCacheData cacheData)
        {

            SpriteAtlas spriteAtlas = AssetDatabase.LoadAssetAtPath(spriteAtlasPath, typeof(SpriteAtlas)) as SpriteAtlas;

            Texture2D[] atlasTextures = GetPreviewTexture(spriteAtlas);

            Sprite[] sprites = new Sprite[spriteAtlas.spriteCount];
            spriteAtlas.GetSprites(sprites);

            cacheData.datas = new WXSpriteAtlasCachedDataItem[atlasTextures.Length];



            foreach (Sprite s in sprites) {
                var spritePath = AssetDatabase.GetAssetPath(s.texture);
                if (string.IsNullOrEmpty(spritePath))
                {
                    continue;
                }
                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", spritePath);
                if (File.Exists(backupPath + ".r"))
                {
                    File.Delete(backupPath + ".r");
                }
                File.Move(spritePath, backupPath + ".r");
                File.Delete(spritePath);
                File.Copy(backupPath, spritePath);
                TextureImporter texImport = AssetImporter.GetAtPath(spritePath) as TextureImporter;

                var tips = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());
                tips.overridden = true;
                tips.format = TextureImporterFormat.RGBA32;

                texImport.isReadable = true;
                texImport.mipmapEnabled = false;

                texImport.SetPlatformTextureSettings(tips);

                AssetDatabase.ImportAsset(spritePath);
            }

            //这里要重新导入一遍是因替换回来了黑图
            //AssetDatabase.Refresh();
            

            var spriteAtlasDir = spriteAtlasPath.Substring(0, spriteAtlasPath.LastIndexOf("/"));
            var dirMd5 = UnityUtil.GetMd5Str(spriteAtlasDir).Substring(0, 8);

            cacheData.pathHash = dirMd5;
            int j = 0;

            string[] FirstSpriteList = new string[atlasTextures.Length];
            for (int i=0; i<atlasTextures.Length; i++) {

                var tx = atlasTextures[i];
                var texture2D = new Texture2D(tx.width, tx.height, TextureFormat.RGBA32, false);

                texture2D.LoadRawTextureData(new byte[texture2D.GetRawTextureData().Length]);
                var id = tx.GetInstanceID();

                
                foreach (Sprite s in sprites) {

                    var sid = SpriteUtility.GetSpriteTexture(s, true).GetInstanceID();
                    
                    if(sid != id)
                    {
                        continue;
                    }

                    //var suvs = SpriteUtility.GetSpriteUVs(s,false);

                    var sTx = s.texture;
                    var key = AssetDatabase.GetAssetPath(s.texture);
                    var sRect = spriteDataList[key].rect;
                    

                    var uvs = SpriteUtility.GetSpriteUVs(s, true);
                    var dstRect = GetRect(uvs,tx.width,tx.height);

                    int hd = (int)dstRect.y;
                    int wd = (int)dstRect.x;


                    var spritePath = AssetDatabase.GetAssetPath(s.texture);


                    /*
                    for (int hs = 0; hs< sRect.height; hs++)
                    {

                        for (int ws = 0; ws < sRect.width; ws++)
                        {

                            var y = hs + (int)System.Math.Round(sRect.y);
                            if (y >= spriteDataList[key].height) {
                                y--;
                            }
                            var x = ws + (int)System.Math.Round(sRect.x);
                            if (x >= spriteDataList[key].width) {
                                x--;
                            }
                            var color = colors[y * spriteDataList[key].width + x];
                           
                            texture2D.SetPixel(wd+ws,hd+hs,color);

                        }

                    }*/

                    for (int hs = 0; hs < sRect.height; hs++)
                    {

                        for (int ws = 0; ws < sRect.width; ws++)
                        {
                            var color = sTx.GetPixel(ws + (int)sRect.x, hs + (int)sRect.y);
                            texture2D.SetPixel(wd + ws, hd + hs, color);

                        }
                    }



                    if (dstRect.x == 0 && dstRect.y == 0)
                    {

                        int spriteAtlasId = AddPath2SpriteAtlasList(spriteAtlasPath);
                        SaveSpriteAtlasKey(spriteAtlasId, i, spriteAtlasPath, tx.width, tx.height);

                        ReplaceTexture(spritePath, spriteAtlasId);

                        FirstSpriteList[i] = spritePath;

                        AssetDatabase.ImportAsset(spritePath);

                    }

                    cacheData.sprites[j] = new WXSpriteAtlasCachedSprite()
                    {
                        path = spritePath,
                        hash = s.texture.imageContentsHash.ToString()
                    };

                    spriteDataList.Remove(key);

                    j++;


                }


                texture2D.Apply();


                var dataMd5 = UnityUtil.GetMd5Str(texture2D.GetRawTextureData()).Substring(0,8);

                var tmpDir = Path.Combine(WXTextureManager.textureDstDir, "spriteAtlas", dirMd5).Replace("\\", "/");

                
                var tmpPath = string.Format("{0}/{1}_{2}.{3}.png", tmpDir, spriteAtlas.name, i, dataMd5);

               
                UnityUtil.CreateDir(tmpDir);

                var altasId = GetIdByAtlasPath(spriteAtlasPath,i);

                textureDataList[altasId].dataHash = dataMd5;
                textureDataList[altasId].pathHash = dirMd5;
                textureDataList[altasId].fileName = spriteAtlas.name+"_"+i;
                textureDataList[altasId].width = tx.width;
                textureDataList[altasId].height = tx.height;


                cacheData.datas[i] = new WXSpriteAtlasCachedDataItem()
                {
                    width = tx.width,
                    height = tx.height,
                    dataHash = dataMd5,
                    id = altasId
                };


                if (!File.Exists(tmpPath))
                {
                    File.WriteAllBytes(tmpPath, texture2D.EncodeToPNG());
                }


                if (!WXTextureManager.miniGameConf.CompressTexture.TooManyFiles)
                {
                    DoGeneratePNG(textureDataList[altasId]);
                }



            }


            foreach (Sprite s in sprites)
            {
                var spritePath = AssetDatabase.GetAssetPath(s.texture);
                if (string.IsNullOrEmpty(spritePath))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(spritePath))
                {
                    continue;
                }
                if (FirstSpriteList.Contains(spritePath))
                {
                    continue;
                }
                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", spritePath);
                File.Delete(spritePath);
                File.Move(backupPath + ".r", spritePath);

            }

            
        }

        public static void ReplaceTexture(string path, int id)
        {

            // sprite atlas 这里的图片数最多为16*16*16=4096张 因为一个像素点为RGBA4444

            if (id > 16 * 16 * 16)
            {
                UnityEngine.Debug.LogError("Sprite Atlas 包含的图片太多！不能多于4096张图！");
                return;
            }

            var tx = AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;
            var colors = tx.GetPixels32(0);
            var width = tx.width;
            var height = tx.height;
            int top = height-1;
            int bottom = 0;
            int left = width-1;
            int right = 0;


            for (int h = 0; h < height; h++)
            {
                for (int i = 0; i < width; i++)
                {
                    var color = colors[i + (h * width)];
                    if (color.a != 0)
                    {
                        if (i < left)
                        {
                            left = i;
                        }
                        if (i > right)
                        {
                            right = i;
                        }
                        if (h > bottom)
                        {
                            bottom = h;
                        }
                        if (h < top)
                        {
                            top = h;
                        }
                    }
                }
            }


            var hit = false;

            var r = id / (16 * 16);
            var g = (id / 16) % 16;
            var b = id % 16;

            var texture2D = new Texture2D(width, height, TextureFormat.RGBA4444, false);

            for (int h = 0; h < height; h++)
            {
                for (int i = 0; i < width; i++)
                {
                    Color color;
                    if (i >= left && i <= right && h >= top && h <= bottom)
                    {

                        //非透明区域
                        if (!hit)
                        {
                            hit = true;
                            color = new Color()
                            {
                                r = (float)r / 15,
                                g = (float)g / 15,
                                b = (float)b / 15,
                                a = 1
                            };
                        }
                        else
                        {
                            color = new Color()
                            {
                                r = 0,
                                g = 0,
                                b = 0,
                                a = 1
                            };
                        }

                    }
                    else
                    {
                        //透明区域
                        color = new Color()
                        {
                            r = 0,
                            g = 0,
                            b = 0,
                            a = 0
                        };
                    }

                    texture2D.SetPixel(i, h, color);

                }
            }


            if (id == 0) {

                var backupPath = Path.Combine(WXTextureManager.textureDstDir, "backup", path);

                if (File.Exists(backupPath))
                {
                    File.Delete(backupPath);
                }

                UnityUtil.CreateDir(new DirectoryInfo(backupPath).Parent.ToString());
                File.Copy(path, backupPath);
            }

            File.WriteAllBytes(path, texture2D.EncodeToPNG());


        }


    }
}
