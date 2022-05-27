using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using UnityEngine.Profiling;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using System.Linq;

namespace WeChatWASM.Analysis
{
    public class TextureWindow : BaseWindow<TextureWindow>
    {
        private AssetDataTable m_table;

        //Vector2 assetListScrollPosition = Vector2.zero;

        public List<TextureInfo> textureInfos = new List<TextureInfo>();
        public List<TextureInfo> renderTextureInfos = new List<TextureInfo>();
        public List<TextureInfo> selectedTextureInfos = new List<TextureInfo>();

        // 检查规则
        public Boolean checkMipMap = false;
        public Boolean formatError = false;
        public Boolean checkIsReadable = false;
        public Boolean checkMaxSize = false;

        // checkbox
        public Boolean disableReadable = true;
        public Boolean disableMipmap = true;
        public Boolean changeMaxSize = true;
        public Boolean changeFormat = true;
        public int selectedMaxSizeIdx = 0;
        public string[] maxSizeOptions = new string[] { "自动减半", "32", "64", "128", "256", "512", "1024", "2048" };
        public int selectedFormat = 0;
        public Dictionary<string, TextureImporterFormat> formatMap = new Dictionary<string, TextureImporterFormat>() {
            { "Auto", TextureImporterFormat.Automatic },
            { "Alpha 8", TextureImporterFormat.Alpha8 },
            { "RGB 24 bit", TextureImporterFormat.RGB24 },
            { "RGBA 32 bit", TextureImporterFormat.RGBA32 },
            { "RGB 16 bit", TextureImporterFormat.RGB16 },
            { "R 16 bit", TextureImporterFormat.R16 },
            { "RGB Compressed DXT1", TextureImporterFormat.DXT1 },
            { "RGBA Compressed DXT5", TextureImporterFormat.DXT5 },
            { "RGB Crunched DXT1", TextureImporterFormat.DXT1Crunched },
            { "RGBA Crunched DXT5", TextureImporterFormat.DXT5Crunched },
            { "R 8", TextureImporterFormat.R8 }
        };


        // dropdown
        public string[] extOptions = new List<string>().ToArray();
        public int extSelected = 0;
        public string[] textureFormatOptions = new List<string>().ToArray();
        public int textureFormatSelected = 0;
        public string[] webglFormatOptions = new List<string>().ToArray();
        public int webglFormatSelected = 0;
        public string[] isReadableOptions = new string[] { "all", "true", "false" };
        public int isReadableSelected = 0;
        public string[] mipmapEnableOptions = new string[] { "all", "true", "false" };
        public int mipmapEnableSelected = 0;

        public TextureWindow() : base()
        {
            if (m_table == null)
            {
                var datas = new List<TextureInfo>();
                var cols = GetOverViewColumn();
                m_table = new AssetDataTable(datas, cols, OnFilter, OnRowSelect, OnSelectAllChange);
            }
        }

        public class AssetDataTable : CommonTable<TextureInfo>
        {
            public AssetDataTable(List<TextureInfo> datas,
                CommonTableColumn<TextureInfo>[] cs,
                FilterMethod<TextureInfo> onfilter,
                SelectMethod<TextureInfo> onselect = null,
                Action<Boolean> toggleSelectAll = null)
                : base(datas, cs, onfilter, onselect, toggleSelectAll)
            {
            }
        }

        public CommonTableColumn<TextureInfo>[] GetOverViewColumn()
        {
            //init columns
            var cols = new CommonTableColumn<TextureInfo>[]
            {
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("name"),       //header display name
                            canSort = true,                             //
                            minWidth = 170,
                            width = 170,
                            Compare = (a,b)=>-a.name.CompareTo(b.name),      //sort method
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.name),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("webglFormat"),//header display name
                            canSort = true,
                            width = 150,
                            minWidth = 90,
                            Compare = (a, b)=>-a.webglFormat.CompareTo(b.webglFormat),
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.webglFormat),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("memorySize"),//header display name
                            canSort = true,
                            width = 120,
                            minWidth = 120,
                            Compare = (a, b)=>-a._memorySize.CompareTo(b._memorySize),
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.memorySize.ToString()),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("maxTextureSize"),//header display name
                            canSort = true,
                            width = 90,
                            minWidth = 90,
                            Compare = (a, b)=>-a.maxTextureSize.CompareTo(b.maxTextureSize),
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.maxTextureSize.ToString()),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("width"),//header display name
                            canSort = true,
                            width = 90,
                            minWidth = 90,
                            Compare = (a, b)=>-a.width.CompareTo(b.width),
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.width.ToString()),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("height"),//header display name
                            canSort = true,
                            width = 90,
                            minWidth = 90,
                            Compare = (a, b)=>-a.height.CompareTo(b.height),
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.height.ToString()),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("extenstion"),//header display name
                            canSort = true,
                            width = 90,
                            minWidth = 90,
                            Compare = (a,b)=>-a.ext.CompareTo(b.ext),//sort method
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.ext),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("dimension"),//header display name
                            canSort = true,
                            width = 90,
                            minWidth = 90,
                            Compare = (a,b)=>-a.dimension.CompareTo(b.dimension),//sort method
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.dimension),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("textureType"),//header display name
                            canSort = true,
                            width = 90,
                            minWidth = 90,
                            Compare = (a,b)=>-a.textureType.CompareTo(b.textureType),//sort method
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.textureType),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("textureFormat"),//header display name
                            canSort = true,
                            width = 120,
                            minWidth = 120,
                            Compare = (a, b)=>-a.textureFormat.CompareTo(b.textureFormat),
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.textureFormat),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("isReadable"),//header display name
                            canSort = true,
                            width = 90,
                            minWidth = 90,
                            Compare = (a, b)=>-a.isReadable.CompareTo(b.isReadable),
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.isReadable.ToString()),
                        },
                        new CommonTableColumn<TextureInfo>
                        {
                            headerContent = new GUIContent("mipmapEnabled"),//header display name
                            canSort = true,
                            width = 90,
                            minWidth = 90,
                            Compare = (a, b)=>-a.mipmapEnabled.CompareTo(b.mipmapEnabled),
                            DrawCell = (rect,data)=>EditorGUI.LabelField(rect,data.mipmapEnabled.ToString()),
                        },
            };
            return cols;
        }

        private void OnRowSelect(List<TextureInfo> datas)
        {
            currentAssetPathList = datas.Select((info) => info.assetPath).ToArray();
            selectedTextureInfos = new List<TextureInfo>(datas);
            var list = new List<Texture>();
            foreach (var data in datas)
            {
                var texture = data.texture;
                list.Add(texture);
            }
            Selection.objects = list.ToArray();
        }

        private void OnSelectAllChange(Boolean isCheckAll)
        {
            if (!isCheckAll)
            {
                selectedTextureInfos = new List<TextureInfo>();
                Selection.objects = null;
            }
        }

        private bool OnFilter(TextureInfo data, string std)
        {
            string name = std;
            if (name.Length == 0)
            {
                return true;
            }
            return data.name.ToLower().IndexOf(name.ToLower()) > -1;
        }

        public override void DrawOptionArea()
        {
            GUILayout.Space(40);
            if (GUILayout.Button("搜索选中目录下资源", GUILayout.Width(160), GUILayout.Height(40)))
            {
                CollectAssets();
            }

            GUILayout.Label("搜索规则");
            checkMipMap = EditorGUILayout.ToggleLeft("已开启MipMap", checkMipMap);
            formatError = EditorGUILayout.ToggleLeft("NPOT", formatError);
            checkIsReadable = EditorGUILayout.ToggleLeft("isReadable", checkIsReadable);
            checkMaxSize = EditorGUILayout.ToggleLeft("MaxSize大于512", checkMaxSize);

            GUILayout.Space(10);

            if (GUILayout.Button("修复选中资源", GUILayout.Width(160), GUILayout.Height(40)))
            {
                if (selectedTextureInfos.Count > 0)
                {
                    OptimizeTexture.Optimize(selectedTextureInfos);
                    CollectAssets(false);
                }
            }
            if (GUILayout.Button("还原选中资源", GUILayout.Width(160), GUILayout.Height(40)))
            {
                OptimizeTexture.Recover(selectedTextureInfos);
                CollectAssets(false);
            }
            GUILayout.Label("修复规则");
            disableReadable = EditorGUILayout.ToggleLeft("禁用isReadable", disableReadable);
            disableMipmap = EditorGUILayout.ToggleLeft("禁用MipMap", disableMipmap);
            changeMaxSize = EditorGUILayout.ToggleLeft("优化MaxSize", changeMaxSize);
            changeFormat = EditorGUILayout.ToggleLeft("改变纹理压缩格式", changeFormat);
            if (changeMaxSize)
            {
                selectedMaxSizeIdx = EditorGUILayout.Popup("MaxSize", selectedMaxSizeIdx, maxSizeOptions);
            }
            if (changeFormat)
            {
                selectedFormat = EditorGUILayout.Popup("Format", selectedFormat, new List<string>(formatMap.Keys).ToArray());
            }

            //GUILayout.FlexibleSpace();
            GUILayout.Space(10);
            GUILayout.Label("列表筛选项");

            string ext = "";
            string webglFormat = "";
            string textureFormat = "";
            string isReadable = "";
            string mipmapEnable = "";

            if (extOptions.Length > 0)
            {
                var selected = 0;
                selected = EditorGUILayout.Popup("extension", extSelected, extOptions);
                if (selected != extSelected)
                {
                    needUpdateMainContent = true;
                }
                extSelected = selected;
                ext = extOptions[extSelected];
            }
            if (webglFormatOptions.Length > 0)
            {
                var selected = 0;
                selected = EditorGUILayout.Popup("webglformat", webglFormatSelected, webglFormatOptions);
                if (selected != webglFormatSelected)
                {
                    needUpdateMainContent = true;
                }
                webglFormatSelected = selected;
                webglFormat = webglFormatOptions[webglFormatSelected];
            }
            if (textureFormatOptions.Length > 0)
            {
                var selected = 0;
                selected = EditorGUILayout.Popup("textureFormat", textureFormatSelected, textureFormatOptions);
                if (selected != textureFormatSelected)
                {
                    needUpdateMainContent = true;
                }
                textureFormatSelected = selected;
                textureFormat = textureFormatOptions[textureFormatSelected];
            }
            if (isReadableOptions.Length > 0)
            {
                var selected = 0;
                selected = EditorGUILayout.Popup("isReadable", isReadableSelected, isReadableOptions);
                if (selected != isReadableSelected)
                {
                    needUpdateMainContent = true;
                }
                isReadableSelected = selected;
                isReadable = isReadableOptions[isReadableSelected];
            }
            if (mipmapEnableOptions.Length > 0)
            {
                var selected = 0;
                selected = EditorGUILayout.Popup("mipmapEnable", mipmapEnableSelected, mipmapEnableOptions);
                if (selected != mipmapEnableSelected)
                {
                    needUpdateMainContent = true;
                }
                mipmapEnableSelected = selected;
                mipmapEnable = mipmapEnableOptions[mipmapEnableSelected];
            }

            FilterAsset(ext, webglFormat, textureFormat, isReadable, mipmapEnable);

            GUILayout.Space(10);
            DrawOverview();

            GUILayout.FlexibleSpace();
        }

        public void DrawOverview()
        {
            GUILayout.Label("总览");
            EditorGUILayout.LabelField("资源个数", renderTextureInfos.Count.ToString());
            EditorGUILayout.LabelField("资源总内存", EditorUtility.FormatBytes(renderTextureInfos.Aggregate((long)0, (account, current) => account += current.originalMemorySize)));
        }

        public void CollectAssets(Boolean needRefreshCurrentFolder = true)
        {
            if (needRefreshCurrentFolder)
            {
                this.currentFolder = GetCurrentFolder();
            }
            var guids = AssetDatabase.FindAssets("t:texture", new[] { this.currentFolder });
            textureInfos = new List<TextureInfo>();
            var exts = new List<string>();
            var webglFormat = new List<string>();
            var count = guids.Length;
            var current = 0;

            foreach (string guid in guids)
            {
                current++;
                var texture = AssetDatabase.LoadAssetAtPath<Texture>(AssetDatabase.GUIDToAssetPath(guid));
                TextureImporter textureImporter;
                if (OptimizeTexture.CheckNeedOptimization(texture, out textureImporter))
                {
                    if (textureImporter)
                    {
                        EditorUtility.DisplayCancelableProgressBar("search texture", "searching " + current, (float)current / count);
                        exts.Add(Path.GetExtension(AssetDatabase.GetAssetPath(texture)).ToString());
                        webglFormat.Add(textureImporter.GetAutomaticFormat("WebGL").ToString());
                        textureInfos.Add(new TextureInfo(textureImporter, texture));
                    }
                }
            }

            EditorUtility.ClearProgressBar();
            renderTextureInfos = new List<TextureInfo>(textureInfos);
            extOptions = (string[])exts.Distinct().Prepend("all").ToArray();
            webglFormatOptions = (string[])webglFormat.Distinct().Prepend("all").ToArray();
            needUpdateMainContent = true;
            selectedTextureInfos = new List<TextureInfo>();
            Selection.objects = null;
        }

        public Boolean FilterAsset(string ext, string webglFormat, string textureFormat, string isReadable, string mipmapEnable)
        {
            var needFilteExt = !string.IsNullOrEmpty(ext) && ext != "all";
            var needFilteWebglFormat = !string.IsNullOrEmpty(webglFormat) && webglFormat != "all";
            var needFilteTextureFormat = !string.IsNullOrEmpty(textureFormat) && textureFormat != "all";
            var needFilteIsReadable = !string.IsNullOrEmpty(isReadable) && isReadable != "all";
            var needfilteMipmapEnable = !string.IsNullOrEmpty(mipmapEnable) && mipmapEnable != "all";
            renderTextureInfos = textureInfos.Where(info =>
            {
                var extValid = true;
                var webglFormatValid = true;
                var textureFormatValid = true;
                var isReadableValid = true;
                var mipmapValid = true;
                if (needFilteExt)
                {
                    extValid = info.ext.Equals(ext, StringComparison.InvariantCultureIgnoreCase);
                }
                if (needFilteWebglFormat)
                {
                    webglFormatValid = info.webglFormat.Equals(webglFormat, StringComparison.InvariantCultureIgnoreCase);
                }
                if (needFilteTextureFormat)
                {
                    textureFormatValid = info.textureFormat.Equals(textureFormat, StringComparison.InvariantCultureIgnoreCase);
                }
                if (needFilteIsReadable)
                {
                    isReadableValid = info.isReadable.ToString().Equals(isReadable, StringComparison.InvariantCultureIgnoreCase);
                }
                if (needfilteMipmapEnable)
                {
                    mipmapValid = info.mipmapEnabled.ToString().Equals(mipmapEnable, StringComparison.InvariantCultureIgnoreCase);
                }

                return extValid && webglFormatValid && textureFormatValid && isReadableValid && mipmapValid;
            }).ToList();
            return needFilteExt || needFilteWebglFormat || needFilteTextureFormat || needFilteIsReadable || needfilteMipmapEnable;
        }

        public override void RefreshTable()
        {
            if (needUpdateMainContent)
            {
                needUpdateMainContent = false;
                var cols = GetOverViewColumn();
                m_table = new AssetDataTable(renderTextureInfos, cols, OnFilter, OnRowSelect, OnSelectAllChange);
            }
            m_table.OnGUI();
        }
    }

    public class TextureInfo : BaseInfo
    {
        private TextureImporter _info;
        private Texture _texture;

        public TextureInfo()
        {

        }

        public Texture texture
        {
            get { return _texture; }
        }

        public TextureInfo(TextureImporter info, Texture texture)
        {
            var _info = info.GetPlatformTextureSettings("WebGL");
            this._info = info;
            this._texture = texture;
            this.mipmapEnabled = info.mipmapEnabled;
            //this.maxTextureSize = info.maxTextureSize;
            this.maxTextureSize = _info.maxTextureSize;
            this.textureFormat = info.textureCompression.ToString();
            if (_info.format == TextureImporterFormat.Automatic)
            {
                this._webglFormat = info.GetAutomaticFormat("WebGL");
            }
            else
            {
                this._webglFormat = _info.format;
            }
            this.webglFormat = this._webglFormat.ToString();
            this.textureType = info.textureType.ToString();
            this.sRGBTexture = info.sRGBTexture;
            this.isReadable = info.isReadable;
            this.compressionQuality = info.compressionQuality;
            this.assetPath = info.assetPath;
            this.width = texture.width;
            this.height = texture.height;
            this.originalMemorySize = Profiler.GetRuntimeMemorySizeLong(texture);
            this.memorySize = EditorUtility.FormatBytes(this.originalMemorySize);
            this._memorySize = this.originalMemorySize;
            this.name = texture.name;
            this.dimension = texture.dimension.ToString();
            this.ext = Path.GetExtension(AssetDatabase.GetAssetPath(texture)).ToString();
        }
    }

    [Serializable]
    public class BaseInfo
    {
        public bool mipmapEnabled;
        public int maxTextureSize;
        public string textureFormat;
        public string textureType;
        public bool sRGBTexture;
        public bool isReadable;
        public int compressionQuality;
        public string assetPath;
        public int width;
        public int height;
        public string memorySize;
        public long _memorySize;
        public string name;
        public TextureImporterFormat _webglFormat;
        public string webglFormat;
        public string dimension;
        public string ext;
        public long originalMemorySize;
    }
}