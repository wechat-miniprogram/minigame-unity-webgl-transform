using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.IMGUI.Controls;
using System.Collections.Generic;
using System.IO;

//public abstract class BaseWindow
//{

//}
namespace WeChatWASM.Analysis
{
    public class BaseWindow<T> where T : class, new()
    {
        //private AssetDataTable m_table;
        Vector2 assetListScrollPosition = Vector2.zero;

        float splitterPos = 1000;
        Rect splitterRect;
        float splitterWidth = 5;
        bool dragging;

        Vector2 refrenceListScrollPostion = Vector2.zero;

        public EditorWindow win;

        public string currentFolder;
        public Boolean needRefreshCurrentFolder;

        public string[] currentAssetPathList;
        public AssetTreeView assetTreeView;
        public List<string> selectedAssetGuid = new List<string>();
        public static ReferenceFinderData assetRefrenceDatas = new ReferenceFinderData();
        public Boolean initializedRefrenceData = false;

        public TreeViewState treeViewState;

        // 是否需要刷新扫描结果
        public Boolean needUpdateMainContent = false;
        // 是否更新资源引用结果
        public Boolean needUpdateAssetTree = false;

        // 单例
        public static T instance;
        public static readonly object locker = new object();

        public BaseWindow()
        {
            win = AnalysisWindow.GetCurrentWindow();

            if (!initializedRefrenceData)
            {
                if (!assetRefrenceDatas.ReadFromCache())
                {
                    assetRefrenceDatas.CollectDependenciesInfo();
                }
                initializedRefrenceData = true;
            }
        }

        public static T GetInstance()
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new T();
                }
            }
            return instance;
        }

        public void Show()
        {
            GUILayout.BeginHorizontal();

            DrawOptionBtn();
            DrawMainContent();
            DrawSplitter();
            DrawReferenceLayout();

            GUILayout.EndHorizontal();
        }

        public void DrawOptionBtn()
        {
            GUILayout.BeginVertical();

            DrawOptionArea();

            GUILayout.EndVertical();
        }

        public virtual void DrawOptionArea()
        {

        }

        public string GetCurrentFolder()
        {
            string path = "Assets";

            foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }
            return path;
        }

        public void DrawMainContent()
        {
            assetListScrollPosition = GUILayout.BeginScrollView(assetListScrollPosition, GUILayout.Width(splitterPos), GUILayout.MinWidth(splitterPos), GUILayout.MaxWidth(splitterPos));
            RefreshTable();
            GUILayout.EndScrollView();
        }

        public virtual void RefreshTable()
        {
        }

        public void DrawSplitter()
        {
            // splitter
            GUILayout.Box("",
                 GUILayout.Width(splitterWidth),
                 GUILayout.MaxWidth(splitterWidth),
                 GUILayout.MinWidth(splitterWidth),
                 GUILayout.ExpandHeight(true));
            splitterRect = GUILayoutUtility.GetLastRect();

            if (Event.current != null)
            {
                switch (Event.current.rawType)
                {
                    case EventType.MouseDown:
                        if (splitterRect.Contains(Event.current.mousePosition))
                        {
                            dragging = true;
                        }
                        break;
                    case EventType.MouseDrag:
                        if (dragging)
                        {
                            splitterPos += Event.current.delta.x;
                            win.Repaint();
                        }
                        break;
                    case EventType.MouseUp:
                        if (dragging)
                        {
                            dragging = false;
                        }
                        break;
                }
            }
        }

        public void DrawReferenceLayout()
        {
            GUILayout.BeginVertical();
            if (GUILayout.Button("检查依赖", GUILayout.Width(160), GUILayout.Height(40)))
            {
                if (currentAssetPathList.Length > 0)
                {
                    selectedAssetGuid.Clear();
                    selectedAssetGuid.Add(AssetDatabase.AssetPathToGUID(currentAssetPathList[0]));
                    needUpdateAssetTree = true;
                }
            }
            var btnRect = GUILayoutUtility.GetLastRect();

            // asset reference
            var scrollViewWidth = win.position.width - splitterRect.xMax;
            var scrollViewY = btnRect.yMax + 5;

            refrenceListScrollPostion = GUILayout.BeginScrollView(refrenceListScrollPostion, GUILayout.Width(scrollViewWidth), GUILayout.MinWidth(scrollViewWidth), GUILayout.MaxWidth(scrollViewWidth), GUILayout.ExpandHeight(true));
            UpdateAssetTree();
            if (assetTreeView != null)
            {
                var rect = GUILayoutUtility.GetRect(0f, Screen.width, 0f, Screen.height);
                if (Event.current.type != EventType.Layout)
                {
                    assetTreeView.OnGUI(rect);
                }
            }
            GUILayout.EndScrollView();

            GUILayout.EndVertical();
        }

        public void UpdateAssetTree()
        {
            if (needUpdateAssetTree && selectedAssetGuid.Count != 0)
            {
                var root = SelectedAssetGuidToRootItem(selectedAssetGuid);
                if (assetTreeView == null)
                {
                    if (treeViewState == null)
                    {
                        treeViewState = new TreeViewState();
                    }
                    var headerState = AssetTreeView.CreateDefaultMultiColumnHeaderState(win.position.width - splitterRect.x);
                    var multiColumnHeader = new MultiColumnHeader(headerState);
                    assetTreeView = new AssetTreeView(treeViewState, multiColumnHeader);
                }
                assetTreeView.assetRoot = root;
                assetTreeView.CollapseAll();
                assetTreeView.Reload();
                needUpdateAssetTree = false;
            }
        }

        //生成root相关
        private HashSet<string> updatedAssetSet = new HashSet<string>();
        //通过选择资源列表生成TreeView的根节点
        private AssetViewItem SelectedAssetGuidToRootItem(List<string> selectedAssetGuid)
        {
            updatedAssetSet.Clear();
            int elementCount = 0;
            var root = new AssetViewItem { id = elementCount, depth = -1, displayName = "Root", data = null };
            int depth = 0;
            foreach (var childGuid in selectedAssetGuid)
            {
                root.AddChild(CreateTree(childGuid, ref elementCount, depth));
            }
            updatedAssetSet.Clear();
            return root;
        }
        //通过每个节点的数据生成子节点
        private AssetViewItem CreateTree(string guid, ref int elementCount, int _depth)
        {
            if (!updatedAssetSet.Contains(guid))
            {
                assetRefrenceDatas.UpdateAssetState(guid);
                updatedAssetSet.Add(guid);
            }
            ++elementCount;
            var referenceData = assetRefrenceDatas.assetDict[guid];
            var root = new AssetViewItem { id = elementCount, displayName = referenceData.name, data = referenceData, depth = _depth };
            var childGuids = referenceData.references;
            foreach (var childGuid in childGuids)
            {
                root.AddChild(CreateTree(childGuid, ref elementCount, _depth + 1));
            }
            return root;
        }
    }
}