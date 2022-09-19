using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace WeChatWASM.Analysis
{
    public static class OptimizeTexture
    {
        static string CACHE_PATH = "Library/AssetImporterbak";
        public static Boolean CheckNeedOptimization(Texture texture, out TextureImporter textureImporter)
        {
            var textureWindow = TextureWindow.GetInstance();
            string path = AssetDatabase.GetAssetPath(texture);
            textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            if (!textureImporter || !texture)
            {
                return false;
            }
            var _info = textureImporter.GetPlatformTextureSettings("WebGL");
            if (textureWindow.checkMipMap)
            {
                if (!textureImporter.mipmapEnabled)
                {
                    return false;
                }
            }
            if (textureWindow.formatError)
            {
                var list = new List<TextureImporterFormat>() { TextureImporterFormat.DXT5, TextureImporterFormat.DXT5Crunched, TextureImporterFormat.DXT1, TextureImporterFormat.DXT1Crunched };
                var format = _info.format == TextureImporterFormat.Automatic ? textureImporter.GetAutomaticFormat("WebGL") : _info.format;
                if (!(!IsPowerOfTwo(texture.width) || !IsPowerOfTwo(texture.height)))
                {
                    return false;
                }
            }
            if (textureWindow.checkIsReadable)
            {
                if (!textureImporter.isReadable)
                {
                    return false;
                }
            }
            if (textureWindow.checkMaxSize)
            {
                if (!(_info.maxTextureSize >= 512))
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }

        public static void Optimize(List<TextureInfo> textureInfos)
        {
            RecordSettings(textureInfos);
            var textureWindow = TextureWindow.GetInstance();
            var totalCount = textureInfos.Count;
            var idx = 0;
            var changedTextures = new List<Texture>();
            foreach (var info in textureInfos)
            {
                idx++;
                TextureImporter textureImporter = AssetImporter.GetAtPath(info.assetPath) as TextureImporter;
                TextureImporterPlatformSettings settings = new TextureImporterPlatformSettings();
                settings.overridden = true;
                int maxRect = Math.Max(info.width, info.height) / 2;
                var needReImport = false;
                if (textureWindow.disableReadable)
                {
                    needReImport = true;
                    textureImporter.isReadable = false;
                }
                if (textureWindow.disableMipmap)
                {
                    needReImport = true;
                    textureImporter.mipmapEnabled = false;
                }
                if (textureWindow.changeMaxSize)
                {
                    needReImport = true;
                    if (textureWindow.selectedMaxSizeIdx == 0)
                    {
                        settings.maxTextureSize = getMaxSize(maxRect);
                        //textureImporter.maxTextureSize = getMaxSize(maxRect);
                    }
                    else
                    {
                        settings.maxTextureSize = int.Parse(textureWindow.maxSizeOptions[textureWindow.selectedMaxSizeIdx]);
                        //textureImporter.maxTextureSize = int.Parse(textureWindow.maxSizeOptions[textureWindow.selectedMaxSizeIdx]);
                    }
                }
                if (textureWindow.changeFormat)
                {
                    needReImport = true;
                    var formatMap = textureWindow.formatMap;
                    var list = new List<string>(formatMap.Keys);
                    var i = textureWindow.textureFormatSelected;
                    TextureImporterFormat format = formatMap[list[i]];
                    settings.name = "WebGL";
                    settings.format = format;

                }
                if (needReImport)
                {
                    var tex = AssetDatabase.LoadAssetAtPath<Texture>(info.assetPath);
                    changedTextures.Add(tex);
                    EditorUtility.DisplayCancelableProgressBar("Recover", "Reading Cache " + idx, (float)idx / totalCount);
                    textureImporter.SetPlatformTextureSettings(settings);
                    textureImporter.SaveAndReimport();
                    AssetDatabase.ImportAsset(info.assetPath);
                }
            }
            //Undo.RecordObjects(changedTextures.ToArray(), "optimize");
            EditorUtility.ClearProgressBar();
        }

        private static int getMaxSize(int size)
        {
            if (size <= 32)
            {
                return 32;
            }
            else if (size > 32 && size <= 64)
            {
                return 64;
            }
            else if (size > 64 && size <= 128)
            {
                return 128;
            }
            else if (size > 128 && size <= 256)
            {
                return 256;
            }
            else if (size > 256 && size <= 512)
            {
                return 512;
            }
            else if (size > 512 && size <= 1024)
            {
                return 1024;
            }
            return 1024;
        }

        public static void RecordSettings(List<TextureInfo> textureInfos)
        {
            if (textureInfos.Count == 0)
            {
                return;
            }
            if (File.Exists(CACHE_PATH))
            {
                File.Delete(CACHE_PATH);
            }
            var guids = new List<string>();
            var importsettings = new List<BaseInfo>();
            foreach (var info in textureInfos)
            {
                var textInfo = new BaseInfo();
                textInfo.assetPath = info.assetPath;
                textInfo.maxTextureSize = info.maxTextureSize;
                textInfo.mipmapEnabled = info.mipmapEnabled;
                textInfo.isReadable = info.isReadable;
                textInfo._webglFormat = info._webglFormat;
                guids.Add(AssetDatabase.AssetPathToGUID(info.assetPath));
                importsettings.Add(textInfo);
            }
            using (FileStream fs = File.OpenWrite(CACHE_PATH))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, guids);
                bf.Serialize(fs, importsettings);
            }
        }

        public static void Recover(List<TextureInfo> textureInfos)
        {
            if (File.Exists(CACHE_PATH))
            {
                var guids = new List<string>();
                var importSettings = new List<BaseInfo>();
                using (FileStream fs = File.OpenRead(CACHE_PATH))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    guids = (List<string>)bf.Deserialize(fs);
                    importSettings = (List<BaseInfo>)bf.Deserialize(fs);
                }

                var totalCount = textureInfos.Count;
                for (int i = 0; i < totalCount; i++)
                {
                    string path = textureInfos[i].assetPath;
                    if (!string.IsNullOrEmpty(path))
                    {
                        TextureImporterPlatformSettings settings = new TextureImporterPlatformSettings();
                        EditorUtility.DisplayCancelableProgressBar("Recover", "Reading Cache " + i, (float)i / totalCount);
                        TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
                        BaseInfo info = importSettings[i];
                        textureImporter.maxTextureSize = info.maxTextureSize;
                        textureImporter.mipmapEnabled = info.mipmapEnabled;
                        textureImporter.isReadable = info.isReadable;
                        settings.name = "WebGL";
                        settings.format = info._webglFormat;
                        textureImporter.SetPlatformTextureSettings(settings);
                        textureImporter.SaveAndReimport();
                        AssetDatabase.ImportAsset(path);
                    }
                }
                File.Delete(CACHE_PATH);
                EditorUtility.ClearProgressBar();
            }
            //Debug.Log("call undo");

            //var list = new List<Texture>();
            //foreach (var data in textureInfos)
            //{
            //    var texture = data.texture;
            //    list.Add(texture);
            //}
            //Selection.objects = list.ToArray();

            //Undo.PerformUndo();
        }
    }
}