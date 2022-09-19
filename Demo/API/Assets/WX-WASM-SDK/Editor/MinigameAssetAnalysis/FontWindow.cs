using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WeChatWASM.Analysis
{
    public class FontWindow : BaseWindow<FontWindow>
    {
        private AssetDataTable m_table;
        private List<FontInfo> selectedObjects;
        private List<FontInfo> originalInfos;
        private List<FontInfo> renderInfos;

        public class AssetDataTable : CommonTable<FontInfo>
        {
            public AssetDataTable(List<FontInfo> datas,
                CommonTableColumn<FontInfo>[] cs,
                FilterMethod<FontInfo> onfilter,
                SelectMethod<FontInfo> onselect = null)
                : base(datas, cs, onfilter, onselect)
            {
            }
        }

        public FontWindow() : base()
        {
            if (m_table == null)
            {
                var datas = new List<FontInfo>();
                var cols = GetViewColumn();
                m_table = new AssetDataTable(datas, cols, OnFilter, OnRowSelect);
            }
        }

        public CommonTableColumn<FontInfo>[] GetViewColumn()
        {
            var cols = new CommonTableColumn<FontInfo>[]
            {
                new CommonTableColumn<FontInfo>
                {
                    headerContent = new GUIContent("name"),
                    canSort = true,
                    minWidth = 170,
                    width = 170,
                    Compare = (a,b) => -a.name.CompareTo(b.name),
                    DrawCell = (rect, data) => EditorGUI.LabelField(rect, data.name)
                },
                new CommonTableColumn<FontInfo>
                {
                    headerContent = new GUIContent("path"),
                    canSort = true,
                    minWidth = 350,
                    width = 350,
                    Compare = (a,b) => -a.assetPath.CompareTo(b.assetPath),
                    DrawCell = (rect, data) => EditorGUI.LabelField(rect, data.assetPath)
                }
            };

            return cols;
        }

        public void OnRowSelect(List<FontInfo> datas)
        {
            currentAssetPathList = datas.Select((info) => info.assetPath).ToArray();
            selectedObjects = new List<FontInfo>(datas);
            var list = new List<Font>();
        }

        private bool OnFilter(FontInfo data, string std)
        {
            string name = std;
            if (name.Length == 0)
            {
                return true;
            }
            return data.name.ToLower().IndexOf(name.ToLower()) > -1;
        }

        public override void RefreshTable()
        {
            if (needUpdateMainContent)
            {
                needUpdateMainContent = false;
                var cols = GetViewColumn();
                m_table = new AssetDataTable(renderInfos, cols, OnFilter, OnRowSelect);
            }
            m_table.OnGUI();
        }

        public override void DrawOptionArea()
        {
            GUILayout.Space(40);
            if (GUILayout.Button("搜索字体文件", GUILayout.Width(160), GUILayout.Height(40)))
            {
                CollectAssets();
            }
        }

        public void CollectAssets(Boolean needRefreshCurrentFolder = true)
        {
            if (needRefreshCurrentFolder)
            {
                this.currentFolder = GetCurrentFolder();
            }
            originalInfos = new List<FontInfo>();
            var guids = AssetDatabase.FindAssets("t:font", new[] { this.currentFolder });
            var count = guids.Length;
            var current = 0;
            foreach (string guid in guids)
            {
                current++;
                EditorUtility.DisplayCancelableProgressBar("search font", "searching " + current, (float)current / count);
                var obj = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(guid));
                var filePath = AssetDatabase.GetAssetPath(obj);
                originalInfos.Add(new FontInfo(obj, filePath));
            }

            EditorUtility.ClearProgressBar();

            renderInfos = new List<FontInfo>(originalInfos);

            needUpdateMainContent = true;
            Selection.objects = null;
        }
    }

    public class FontInfo
    {
        public string assetPath;
        public string name;

        public FontInfo(Font info, string assetPath)
        {
            this.assetPath = assetPath;
            this.name = info.name;
        }
    }
}