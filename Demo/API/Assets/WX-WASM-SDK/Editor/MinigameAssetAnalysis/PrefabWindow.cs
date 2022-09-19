using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WeChatWASM.Analysis
{
    public class PrefabWindow : BaseWindow<PrefabWindow>
    {
        private AssetDataTable m_table;
        private List<PrefabInfo> selectedObjects;
        private List<PrefabInfo> originalInfos;
        private List<PrefabInfo> renderInfos;

        public class AssetDataTable : CommonTable<PrefabInfo>
        {
            public AssetDataTable(List<PrefabInfo> datas,
                CommonTableColumn<PrefabInfo>[] cs,
                FilterMethod<PrefabInfo> onfilter,
                SelectMethod<PrefabInfo> onselect = null)
                : base(datas, cs, onfilter, onselect)
            {
            }
        }

        public PrefabWindow() : base()
        {
            if (m_table == null)
            {
                var datas = new List<PrefabInfo>();
                var cols = GetViewColumn();
                m_table = new AssetDataTable(datas, cols, OnFilter, OnRowSelect);
            }
        }

        public CommonTableColumn<PrefabInfo>[] GetViewColumn()
        {
            var cols = new CommonTableColumn<PrefabInfo>[]
            {
                new CommonTableColumn<PrefabInfo>
                {
                    headerContent = new GUIContent("name"),
                    canSort = true,
                    minWidth = 210,
                    width = 210,
                    Compare = (a,b) => -a.name.CompareTo(b.name),
                    DrawCell = (rect, data) => EditorGUI.LabelField(rect, data.name)
                },
                new CommonTableColumn<PrefabInfo>
                {
                    headerContent = new GUIContent("path"),
                    canSort = true,
                    minWidth = 650,
                    width = 650,
                    Compare = (a,b) => -a.assetPath.CompareTo(b.assetPath),
                    DrawCell = (rect, data) => EditorGUI.LabelField(rect, data.assetPath)
                }
            };

            return cols;
        }

        public void OnRowSelect(List<PrefabInfo> datas)
        {
            currentAssetPathList = datas.Select((info) => info.assetPath).ToArray();
            selectedObjects = new List<PrefabInfo>(datas);
            var list = new List<GameObject>();
            foreach (var data in datas)
            {
                var info = data._info;
                list.Add(info);
            }
            Selection.objects = list.ToArray();
        }

        private bool OnFilter(PrefabInfo data, string std)
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
            if (GUILayout.Button("搜索prefab", GUILayout.Width(160), GUILayout.Height(40)))
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

            originalInfos = new List<PrefabInfo>();
            var guids = AssetDatabase.FindAssets("t:prefab", new[] { this.currentFolder });
            var count = guids.Length;
            var current = 0;
            foreach (string guid in guids)
            {
                current++;
                EditorUtility.DisplayCancelableProgressBar("search prefab", "searching " + current, (float)current / count);
                var obj = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guid));
                PrefabAssetType pType = PrefabUtility.GetPrefabAssetType(obj);
                if (pType == PrefabAssetType.Regular)
                {
                    var filePath = AssetDatabase.GetAssetPath(obj);
                    originalInfos.Add(new PrefabInfo(obj, filePath));
                }
            }

            EditorUtility.ClearProgressBar();

            renderInfos = new List<PrefabInfo>(originalInfos);

            needUpdateMainContent = true;
            Selection.objects = null;
        }
    }

    public class PrefabInfo
    {
        public string assetPath;
        public string name;
        public GameObject _info;

        public PrefabInfo(GameObject info, string assetPath)
        {
            this._info = info;
            this.assetPath = assetPath;
            this.name = info.name;
        }
    }
}