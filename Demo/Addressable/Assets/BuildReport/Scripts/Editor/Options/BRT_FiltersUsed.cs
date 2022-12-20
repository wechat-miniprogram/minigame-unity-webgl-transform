#if UNITY_EDITOR

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace BuildReportTool
{
	public class FiltersUsed
	{
		static readonly FileFilterGroup DefaultFileFilters = new FileFilterGroup(CreateDefaultFileFilters());

		static FileFilterGroup GetDefaultFileFilterGroup()
		{
			return DefaultFileFilters;
		}

		static FileFilters[] CreateDefaultFileFilters()
		{
			return new[]
			{
				new FileFilters("Textures",
					new[]
					{
						".psd",
						".jpg",
						".jpeg",
						".gif",
						".png",
						".tiff",
						".tif",
						".tga",
						".bmp",
						".dds",
						".exr",
						".iff",
						".pict",
						"Built-in Texture2D:" // Unity-generated sprite atlases
					}),
				new FileFilters("Models",
					new[]
					{
						".fbx",
						".dae",
						".mb",
						".ma",
						".max",
						".blend",
						".obj",
						".3ds",
						".dxf"
					}),
				new FileFilters("Prefabs",
					new[]
					{
						".prefab"
					}),
				new FileFilters("Animation",
					new[]
					{
						".anim",
						".controller",
						".mask"
					}),
				new FileFilters("Movies",
					new[]
					{
						".mov",
						".mpg",
						".mpeg",
						".mp4",
						".avi",
						".asf"
					}),
				new FileFilters("Materials",
					new[]
					{
						".mat",
						".sbsar",
						".cubemap",
						".flare",
						"Built-in Material:"
					}),
				new FileFilters("Shaders",
					new[]
					{
						".shader",
						".compute",
						".cginc",
						"Built-in Shader:"
					}),
				new FileFilters("GUI",
					new[]
					{
						".guiskin",
						".fontsettings",
						".ttf",
						".dfont",
						".otf"
					}),
				new FileFilters("Sounds",
					new[]
					{
						".mixer",
						".wav",
						".mp3",
						".ogg",
						".aif",
						".xm",
						".mod",
						".it",
						".s3m"
					}),
				new FileFilters("Scripts",
					new[]
					{
						".cs",
						".js",
						".boo",
						"Built-in MonoScript:"
					}),
				new FileFilters("Plugins",
					new[]
					{
						".dll", // Windows
						".bundle", // Mac
						".so", // Android (C++) or Linux
						".jar", // Android (Java)
						".a", // iOS
						".m", // iOS
						".mm", // iOS
						".c", // iOS
						".cpp" // iOS
					}),
				new FileFilters("Text",
					new[]
					{
						".txt",
						".bytes",
						".html",
						".htm",
						".xml",
						".yaml",
						".json",
						".log"
					}),
				new FileFilters("Misc",
					new[]
					{
						".asset",
						".physicmaterial",
						".unity"
					}),
				new FileFilters("Standard Assets",
					new[]
					{
						"/Standard Assets/"
					}),
				new FileFilters("\"Resources\" Assets",
					new[]
					{
						"/Resources/"
					}),
				new FileFilters("Streaming Assets",
					new[]
					{
						"Assets/StreamingAssets/"
					}),
				new FileFilters("Editor",
					new[]
					{
						"/Editor/"
					}),
				new FileFilters("Version Control",
					new[]
					{
						"/.svn/",
						"/.git/",
						"/.cvs/"
					}),
				new FileFilters("Built-in Assets",
					new[]
					{
						"Built-in"
					}),
				new FileFilters("Useless Files",
					new[]
					{
						"\"Thumbs.db\"",
						"\".DS_Store\"",
						"\"._.DS_Store\""
					})
			};
		}

		static void SaveFileFilterGroupToFile(string saveFilePath, FileFilterGroup filterGroup)
		{
			XmlSerializer x = new XmlSerializer(typeof(FileFilterGroup));

			saveFilePath = saveFilePath.Replace("\\", "/");

			TextWriter writer = new StreamWriter(saveFilePath);
			x.Serialize(writer, filterGroup);
			writer.Close();

			Debug.Log("Build Report Tool: Saved File Filter Group at \"" + saveFilePath + "\"");
		}

		static FileFilterGroup AttemptLoadFileFiltersFromFile(string filePath)
		{
			FileFilterGroup ret;

			XmlSerializer x = new XmlSerializer(typeof(FileFilterGroup));

			using (FileStream fs = new FileStream(filePath, FileMode.Open))
			{
				XmlReader reader = new XmlTextReader(fs);
				ret = (FileFilterGroup) x.Deserialize(reader);
				fs.Close();
			}

			return ret;
		}

		const string FILE_FILTERS_USED_FILENAME = "FileFiltersUsed.xml";

		public static string GetProperFileFilterGroupToUseFilePath()
		{
			return GetProperFileFilterGroupToUseFilePath(BuildReportTool.Options.BuildReportSavePath);
		}

		public static string GetProperFileFilterGroupToUseFilePath(string userFileFilterSavePath)
		{
			// attempt to get from Assets/BuildReport/Config/FileFiltersUsed.xml
			// if none, attempt to get from ~/UnityBuildReports/FileFiltersUsed.xml
			// if no dice, create a new FileFiltersUsed.xml in ~/UnityBuildReports/ and use that

			// attempt to get from default Build Report Tool folder: Assets/BuildReport/Config/FileFiltersUsed.xml

			string fileFilterGroupAtDefaultAssetsPath =
				BuildReportTool.Options.BUILD_REPORT_TOOL_DEFAULT_PATH + "/" + FILE_FILTERS_USED_FILENAME;

			if (File.Exists(fileFilterGroupAtDefaultAssetsPath))
			{
				return fileFilterGroupAtDefaultAssetsPath;
			}


			// search for Build Report Tool folder in all subfolders of Assets folder and look for file there
			// maybe shouldn't do this? it's recursive and could be slow on project with hundreds of folders...
/*
		string assetFolderPath = BuildReportTool.Util.FindAssetFolder(Application.dataPath, BuildReportTool.Config.BUILD_REPORT_TOOL_DEFAULT_FOLDER_NAME);
		if (!string.IsNullOrEmpty(assetFolderPath))
		{
			string fileFilterGroupAtFoundAssetsPath = assetFolderPath + "/" + FILE_FILTERS_USED_FILENAME;

			if (File.Exists(fileFilterGroupAtFoundAssetsPath))
			{
				return fileFilterGroupAtFoundAssetsPath;
			}
		}
*/

			string fileFilterGroupAtUserPersonalFolder = userFileFilterSavePath + "/" + FILE_FILTERS_USED_FILENAME;
			if (File.Exists(fileFilterGroupAtUserPersonalFolder))
			{
				//Debug.Log("will use file filter from user folder: " + fileFilterGroupAtUserPersonalFolder);
				return fileFilterGroupAtUserPersonalFolder;
			}

			string fileFilterGroupAtUserPersonalFolderDefaultName =
				BuildReportTool.Util.GetUserHomeFolder() + "/" + BuildReportTool.Options.BUILD_REPORTS_DEFAULT_FOLDER_NAME +
				"/" + FILE_FILTERS_USED_FILENAME;
			if (File.Exists(fileFilterGroupAtUserPersonalFolderDefaultName))
			{
				//Debug.Log("will use file filter from default user folder: " + fileFilterGroupAtUserPersonalFolderDefaultName);
				return fileFilterGroupAtUserPersonalFolderDefaultName;
			}

			// no dice. create a file filter group xml file at user personal folder
			if (!Directory.Exists(userFileFilterSavePath))
			{
				Debug.Log("Created a new Build Report File Filter Config XML File at " + userFileFilterSavePath);
				Directory.CreateDirectory(userFileFilterSavePath);
			}

			SaveFileFilterGroupToFile(fileFilterGroupAtUserPersonalFolder, DefaultFileFilters);
			return fileFilterGroupAtUserPersonalFolder;
		}


		public static FileFilterGroup GetProperFileFilterGroupToUse()
		{
			return GetProperFileFilterGroupToUse(BuildReportTool.Options.BuildReportSavePath);
		}

		public static FileFilterGroup GetProperFileFilterGroupToUse(string userFileFilterSavePath)
		{
			string fileFilterGroupPath = GetProperFileFilterGroupToUseFilePath(userFileFilterSavePath);

			//Debug.Log("fileFilterGroupPath: " + fileFilterGroupPath);

			FileFilterGroup ret = AttemptLoadFileFiltersFromFile(fileFilterGroupPath);

			if (ret != null)
			{
				return ret;
			}

			Debug.LogError("Build Report Tool: Could not find proper File Filter Group to use.");
			return null;
		}
	}
} // namespace BuildReportTool

#endif