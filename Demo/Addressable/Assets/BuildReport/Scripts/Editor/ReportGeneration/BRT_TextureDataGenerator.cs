using UnityEditor;
using UnityEngine;

namespace BuildReportTool
{
	public static class TextureDataGenerator
	{
		// create a BRT_TextureData, populate it with all images of the project
		// by going through all the files in BuildInfo.UsedAssets.All, looping through that
		// and checking if the Name matches what we expect image files to be (Util.IsTextureFile())

		static BRT_TextureData.Entry CreateEntry(string assetPath, string platform)
		{
			BRT_TextureData.Entry result;
			result.AssetPath = assetPath;

			var assetImporter = AssetImporter.GetAtPath(assetPath);
			if (assetImporter == null)
			{
				return BRT_TextureData.Entry.Empty;
			}

			if (!(assetImporter as TextureImporter))
			{
				return BRT_TextureData.Entry.Empty;
			}

			var textureImporter = (TextureImporter) assetImporter;

			result.TextureType = textureImporter.textureType.ToString();

			if (!string.IsNullOrEmpty(platform))
			{
				int maxTextureSize;
				TextureImporterFormat textureFormat;
				int compressionQuality;

				textureImporter.GetPlatformTextureSettings(platform, out maxTextureSize, out textureFormat,
					out compressionQuality);
				result.TextureFormat = textureFormat.ToString();
				result.CompressionQuality = compressionQuality;
				result.MaxTextureSize = maxTextureSize;
			}
			else
			{
#if UNITY_5_5_OR_NEWER
				// for Unity 5.5+, platform arg should have a value
				// and we use that for the GetPlatformTextureSettings
				// but since platform is empty, we can only get the default setting
				result.TextureFormat = textureImporter.GetDefaultPlatformTextureSettings().format.ToString();
#else
				// (only in Unity 5.0 to 5.4) (not in Unity 5.5)
				result.TextureFormat = textureImporter.textureFormat.ToString();
#endif
				result.CompressionQuality = textureImporter.compressionQuality;
				result.MaxTextureSize = textureImporter.maxTextureSize;
			}

			result.CompressionType = null; // no compression type in Unity 5.4 and below
			result.CompressionIsCrunched = false; // no crunch compression in Unity 5.4 and below

			//textureImporter.GetAutomaticFormat()

			result.NPotScale = textureImporter.npotScale.ToString();
			result.IsReadable = textureImporter.isReadable;
			result.MipMapGenerated = textureImporter.mipmapEnabled;
			result.WrapMode = textureImporter.wrapMode.ToString();
#if UNITY_5_5_OR_NEWER
			result.IsSRGB = textureImporter.sRGBTexture;
#else
			result.IsSRGB = !textureImporter.linearTexture; // obsolete in Unity 5.5
#endif

			var loadedTexture = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Texture)) as Texture;
			if (loadedTexture != null)
			{
				result.ImportedWidth = loadedTexture.width;
				result.ImportedHeight = loadedTexture.height;
			}
			else
			{
				result.ImportedWidth = 0;
				result.ImportedHeight = 0;
			}

			result.RealWidth = 0;
			result.RealHeight = 0;

			return result;
		}
	}
}