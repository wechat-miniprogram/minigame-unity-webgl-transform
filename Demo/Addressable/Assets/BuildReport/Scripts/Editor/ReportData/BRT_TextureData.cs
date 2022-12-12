using System.Collections.Generic;
using UnityEngine;

namespace BuildReportTool
{
	[System.Serializable, System.Xml.Serialization.XmlRoot("TextureData")]
	public class BRT_TextureData : MonoBehaviour
	{
		// ==================================================================================

		public struct Entry
		{
			/// <summary>
			/// Filename and path of the texture.
			/// </summary>
			public string AssetPath;

			/// <summary>
			/// Broad category whether this image is used as a Texture, GUI, Sprite, Cursor, Lightmap, etc.
			/// </summary>
			public string TextureType;

			/// <summary>
			/// Image format upon import (DXT, PVRTC, RGBA32 uncompressed, etc.)
			/// </summary>
			public string TextureFormat;

			/// <summary>
			/// Maps to UnityEditor.TextureImporterCompression (only in Unity 5.5+)
			/// </summary>
			public string CompressionType;

			/// <summary>
			/// Maps to UnityEditor.TextureImporter.compressionQuality goes from 0 to 100
			/// </summary>
			public int CompressionQuality;

			/// <summary>
			/// Note: only in Unity 5.5+
			/// </summary>
			public bool CompressionIsCrunched;

			/// <summary>
			/// Maps to UnityEditor.TextureImporter.maxTextureSize
			/// </summary>
			public int MaxTextureSize;

			/// <summary>
			/// How the image is resized if height/width isn't a power of two, if at all.
			/// </summary>
			public string NPotScale;

			public bool IsReadable;

			/// <summary>
			/// Maps to UnityEditor.TextureImporter.mipmapEnabled
			/// </summary>
			public bool MipMapGenerated;

			/// <summary>
			/// Whether repeated or clamped.
			/// </summary>
			public string WrapMode;

			/// <summary>
			/// true: sRGB false: Linear.
			/// For Unity 5.4 and below: maps to UnityEditor.TextureImporter.linearTexture (inverted value).
			/// For Unity 5.5 and above: maps to UnityEditor.TextureImporter.sRGBTexture.
			/// </summary>
			public bool IsSRGB;

			/// <summary>
			/// Image width, but if NPotScale is used, this will be the power of two value that it was resized to.
			/// </summary>
			public int ImportedWidth;

			/// <summary>
			/// Image height, but if NPotScale is used, this will be the power of two value that it was resized to.
			/// </summary>
			public int ImportedHeight;

			/// <summary>
			/// Actual image width, before the NPotScale setting resized it.
			/// </summary>
			public int RealWidth;

			/// <summary>
			/// Actual image height, before the NPotScale setting resized it.
			/// </summary>
			public int RealHeight;

			public static Entry Empty
			{
				get
				{
					Entry empty;
					empty.AssetPath = null;
					empty.TextureType = null;
					empty.TextureFormat = null;
					empty.CompressionType = null;
					empty.CompressionQuality = 0;
					empty.CompressionIsCrunched = false;
					empty.MaxTextureSize = 0;
					empty.NPotScale = null;
					empty.IsReadable = false;
					empty.MipMapGenerated = false;
					empty.WrapMode = null;
					empty.IsSRGB = false;
					empty.ImportedWidth = 0;
					empty.ImportedHeight = 0;
					empty.RealWidth = 0;
					empty.RealHeight = 0;
					return empty;
				}
			}
		}

		// ==================================================================================

		Dictionary<string, Entry> _textureData = new Dictionary<string, Entry>();

		public List<string> Assets;
		public List<Entry> Data;

		public Dictionary<string, Entry> GetTextureData()
		{
			return _textureData;
		}

		// ==================================================================================

		public void OnBeforeSave()
		{
			if (Assets != null)
			{
				Assets.Clear();
			}
			else
			{
				Assets = new List<string>();
			}

			Assets.AddRange(_textureData.Keys);

			if (Data != null)
			{
				Data.Clear();
			}
			else
			{
				Data = new List<Entry>();
			}

			Data.AddRange(_textureData.Values);
		}

		public void OnAfterLoad()
		{
			_textureData.Clear();

			var len = Mathf.Min(Assets.Count, Data.Count);
			for (int n = 0; n < len; ++n)
			{
				_textureData.Add(Assets[n], Data[n]);
			}
		}

		// ==================================================================================
	}
}