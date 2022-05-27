using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WeChatWASM.Analysis
{
    public class AudioWindow : BaseWindow<AudioWindow>
    {
        private AssetDataTable m_table;
        private List<AudioInfo> selectedObjects;
        private List<AudioInfo> originalInfos;
        private List<AudioInfo> renderInfos;

        public class AssetDataTable : CommonTable<AudioInfo>
        {
            public AssetDataTable(List<AudioInfo> datas,
                CommonTableColumn<AudioInfo>[] cs,
                FilterMethod<AudioInfo> onfilter,
                SelectMethod<AudioInfo> onselect = null)
                : base(datas, cs, onfilter, onselect)
            {
            }
        }

        public AudioWindow() : base()
        {
            if (m_table == null)
            {
                var datas = new List<AudioInfo>();
                var cols = GetViewColumn();
                m_table = new AssetDataTable(datas, cols, OnFilter, OnRowSelect);
            }
        }

        public CommonTableColumn<AudioInfo>[] GetViewColumn()
        {
            var cols = new CommonTableColumn<AudioInfo>[]
            {
                new CommonTableColumn<AudioInfo>
                {
                    headerContent = new GUIContent("name"),
                    canSort = true,
                    minWidth = 170,
                    width = 170,
                    Compare = (a,b) => -a.name.CompareTo(b.name),
                    DrawCell = (rect, data) => EditorGUI.LabelField(rect, data.name)
                },
                new CommonTableColumn<AudioInfo>
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

        public void OnRowSelect(List<AudioInfo> datas)
        {
            currentAssetPathList = datas.Select((info) => info.assetPath).ToArray();
            selectedObjects = new List<AudioInfo>(datas);
            var list = new List<AudioClip>();
            foreach (var data in datas)
            {
                var info = data._info;
                list.Add(info);
            }
            Selection.objects = list.ToArray();
        }

        private bool OnFilter(AudioInfo data, string std)
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
            if (GUILayout.Button("搜索音频文件", GUILayout.Width(160), GUILayout.Height(40)))
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
            originalInfos = new List<AudioInfo>();
            var guids = AssetDatabase.FindAssets("t:audioclip", new[] { this.currentFolder });
            var count = guids.Length;
            var current = 0;
            foreach (string guid in guids)
            {
                current++;
                EditorUtility.DisplayCancelableProgressBar("search Audio", "searching " + current, (float)current / count);
                var obj = AssetDatabase.LoadAssetAtPath<AudioClip>(AssetDatabase.GUIDToAssetPath(guid));
                var filePath = AssetDatabase.GetAssetPath(obj);
                originalInfos.Add(new AudioInfo(obj, filePath));
            }

            EditorUtility.ClearProgressBar();

            renderInfos = new List<AudioInfo>(originalInfos);

            needUpdateMainContent = true;
            Selection.objects = null;
        }
    }

    public class AudioInfo
    {
        public string assetPath;
        public string name;
        public AudioClip _info;

        public AudioInfo(AudioClip info, string assetPath)
        {
            this._info = info;
            this.assetPath = assetPath;
            this.name = info.name;
        }
    }
}