
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        public string atlasPath;
        public Rect rect;
    }

    public class WXSpriteAtlasManager
    {


        public static Dictionary<int, string> spriteAtlasMap;
        public static ArrayList spriteList;
        public static Dictionary<int, TextureSize> textureSizeList;
        public static List<WXFormatItem> textureFormatList; //用于恢复
        public static WXEditorScriptObject miniGameConf;

        public static void Start()
        {
            miniGameConf = UnityUtil.GetEditorConf();

            SpriteAtlasUtility.PackAllAtlases(BuildTarget.WebGL);

            var list = AssetDatabase.FindAssets("t:spriteatlas", WXTextureManager.GetWorkingFolders());


            spriteList = new ArrayList();
            spriteAtlasMap = new Dictionary<int, string>();
            textureSizeList = new Dictionary<int, TextureSize>();
            textureFormatList = new List<WXFormatItem>();


            foreach (string guid in list)
            {

                var path = AssetDatabase.GUIDToAssetPath(guid);

                SpriteAtlas spriteAtlas = AssetDatabase.LoadAssetAtPath(path, typeof(SpriteAtlas)) as SpriteAtlas;

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


                FileInfo fi = new FileInfo(Path.Combine(miniGameConf.ProjectConf.DST, WXEditorWindow.webglDir, path));

                UnityUtil.CreateDir(fi.DirectoryName);


                Sprite[] sprites = new Sprite[spriteAtlas.spriteCount];
                spriteAtlas.GetSprites(sprites);

                var pathList = new string[sprites.Length];
                var i = 0;
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
                }


                foreach (Sprite s in sprites) {

                    var spritePath = AssetDatabase.GetAssetPath(s.texture);
                    if (string.IsNullOrEmpty(spritePath)) {
                        continue;
                    }
                    pathList[i] = spritePath;
                    if (spriteList.Contains(spritePath))
                    {
                        Debug.LogError("图片：" + spritePath + " 被多个图集重复使用了！这是不允许的，请修正！");
                        continue;
                    }

                    spriteList.Add(spritePath);

                    TextureImporter texImport = AssetImporter.GetAtPath(spritePath) as TextureImporter;

                    var t = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());

                    textureFormatList.Add(new WXFormatItem()
                    {
                        path = spritePath,
                        format = t.format
                    });

                    var index = spriteList.IndexOf(spritePath);
                    ReplaceTexture(spritePath, index + 1); //避免0的id

                    i++;

                }

                AssetDatabase.Refresh();

                SpriteAtlasUtility.PackAtlases(new SpriteAtlas[] { spriteAtlas }, BuildTarget.WebGL);

                tips.format = TextureImporterFormat.DXT1;
                spriteAtlas.SetPlatformSettings(tips);

                SaveSpriteAtlasKey(spriteAtlas,path);


                tips.format = TextureImporterFormat.RGBA32;
                spriteAtlas.SetPlatformSettings(tips);

                GeneratePNG(path, fi.DirectoryName, pathList);

                tips.format = TextureImporterFormat.DXT1;
                spriteAtlas.SetPlatformSettings(tips);


                sats.readable = false;
                spriteAtlas.SetTextureSettings(sats);
            }

        }

        public static void SaveManagedResult(string result)
        {

            var conf = UnityUtil.GetEditorConf();
            conf.CompressTexture.SpriteRes = result;

            EditorUtility.SetDirty(conf);
            AssetDatabase.SaveAssets();


        }


        public static string GetManagedSpriteDatas()
        {

            if (spriteAtlasMap.Count>0) {
                var result = new Dictionary<int, WXTextureData4Js>();
                foreach (var item in spriteAtlasMap) {
                    result.Add(item.Key, new WXTextureData4Js() {
                        p = Regex.Replace(item.Value, @"^Assets(\\|\/)", ""),
                        w = textureSizeList[item.Key].width,
                        h = textureSizeList[item.Key].height
                    });
                }

                return JsonMapper.ToJson(result);
            }
            return "";

        }


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

                textureSizeList.Add((int)id, new TextureSize()
                {
                    width = tx.width,
                    height = tx.height
                });


            }

        }

        public static void Recover() {
            var list = AssetDatabase.FindAssets("t:spriteatlas", WXTextureManager.GetWorkingFolders());

            foreach (string guid in list)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                SpriteAtlas spriteAtlas = AssetDatabase.LoadAssetAtPath(path, typeof(SpriteAtlas)) as SpriteAtlas;
                TextureImporterPlatformSettings tips = spriteAtlas.GetPlatformSettings(BuildTarget.WebGL.ToString());
                tips.overridden = true;
                tips.format = TextureImporterFormat.RGBA32;
                spriteAtlas.SetPlatformSettings(tips);
            }

        }


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
                x = width * left,
                y = height * bottom,
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

        public static void GeneratePNG(string spriteAtlasPath, string dirPath, string[] spriteList)
        {

            SpriteAtlas spriteAtlas = AssetDatabase.LoadAssetAtPath(spriteAtlasPath, typeof(SpriteAtlas)) as SpriteAtlas;

            Texture2D[] atlasTextures = GetPreviewTexture(spriteAtlas);

            Sprite[] sprites = new Sprite[spriteAtlas.spriteCount];
            spriteAtlas.GetSprites(sprites);

            foreach (string spritePath in spriteList)
            {
                if (string.IsNullOrEmpty(spritePath)) {
                    continue;
                }
                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", spritePath);
                if (File.Exists(backupPath + ".r")) {
                    File.Delete(backupPath + ".r");
                }
                File.Move(spritePath,backupPath+".r");
                File.Delete(spritePath);
                File.Move(backupPath,spritePath);
                TextureImporter texImport = AssetImporter.GetAtPath(spritePath) as TextureImporter;

                var tips = texImport.GetPlatformTextureSettings(BuildTarget.WebGL.ToString());
                tips.overridden = true;
                tips.format = TextureImporterFormat.RGBA32;

                texImport.isReadable = true;
                texImport.mipmapEnabled = false;

                texImport.SetPlatformTextureSettings(tips);
            }
            //这里要重新导入一遍是因替换回来了黑图
            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);

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

                    var suvs = SpriteUtility.GetSpriteUVs(s,false);

                    var sTx = s.texture;
                    var sRect = GetRect(suvs,sTx.width,sTx.height);
                    var uvs = SpriteUtility.GetSpriteUVs(s, true);
                    var dstRect = GetRect(uvs,tx.width,tx.height);

                    int hd = (int)dstRect.y;
                    int wd = (int)dstRect.x;


                    for(int hs = 0; hs< sRect.height; hs++)
                    {

                        for (int ws = 0; ws < sRect.width; ws++)
                        {
                            var color = sTx.GetPixel(ws+ (int)sRect.x, hs+ (int)sRect.y);
                            texture2D.SetPixel(wd+ws,hd+hs,color);

                        }
                    }


                }


                texture2D.Apply();
                string tmpPath = string.Format("{0}/{1}_{2}.tmp.png", dirPath, spriteAtlas.name, i);
                File.WriteAllBytes(tmpPath, texture2D.EncodeToPNG());
                string pngPath = string.Format("{0}/{1}_{2}.png", dirPath, spriteAtlas.name, i);
                bool needPvr = tx.width == tx.height;
                PicCompressor.CompressPNG(tmpPath, pngPath + ".png", tx.width, tx.height,()=> {


                    PicCompressor.CompressASTC(pngPath + ".png", pngPath + ".astc");

                    if (!WXTextureManager.miniGameConf.CompressTexture.OnlyAstc)
                    {
                        PicCompressor.CompressETC2(pngPath + ".png", pngPath + ".pkm");
                        if (needPvr)
                        {
                            PicCompressor.CompressPVRTC(pngPath + ".png", pngPath + ".pvr");
                        }

                        PicCompressor.CompressMinPNG(pngPath + ".png");
                    }

                    File.Delete(tmpPath);

                });

            }


            foreach (string spritePath in spriteList)
            {
                if (string.IsNullOrEmpty(spritePath)) {
                    continue;
                }
                var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", spritePath);
                File.Move(spritePath, backupPath);
                File.Delete(spritePath);
                File.Move(backupPath + ".r", spritePath);
            }



        }

        public static void ReplaceTexture(string path, int id)
        {

            // sprite atlas 这里的图片数最多为16*16*16=4096张 因为一个像素点为RGBA4444

            if (id > 16 * 16 * 16)
            {
                Debug.LogError("Sprite Atlas 包含的图片太多！不能多于4096张图！");
                return;
            }

            var tx = AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;
            var colors = tx.GetPixels32(0);
            var width = tx.width;
            var height = tx.height;
            int top = height - 1;
            int bottom = 0;
            int left = width - 1;
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
                    if (i >= left && i < right && h >= top && h <= bottom)
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


            var backupPath = Path.Combine(miniGameConf.ProjectConf.DST, "backup", path);

            if (File.Exists(backupPath))
            {
                File.Delete(backupPath);
            }

            UnityUtil.CreateDir(new DirectoryInfo(backupPath).Parent.ToString());

            File.Copy(path, backupPath);





            File.WriteAllBytes(path, texture2D.EncodeToPNG());

            //TextureImporter texImport = AssetImporter.GetAtPath(path) as TextureImporter;
            //texImport.isReadable = false;

        }


    }
}
