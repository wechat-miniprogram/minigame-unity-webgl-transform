using System;
using System.Xml;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using UnityEditorInternal;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class InjectionBlackListGenerator : EditorWindow
{
    public static string blackListFilePath = CustomSettings.injectionFilesPath + "InjectionBlackList.txt";
    public static Action onBlackListGenerated;

    static string pathsInfoSavedPath;
    static HashSet<string> specifiedDropType = new HashSet<string>
    {
    };
    const string nestRegex = @"     (?<=
                                        (?<!/{2,}.*)                #Ignore Comment
                                    )
                                    (
                                        (?<=class\s+)               #Capture class name
                                        (\b(\w+)\b)
                                        |
                                        (?<=struct\s+)              #Capture struct name
                                        (\b(\w+)\b)
                                        |
                                        (?<=namespace\s+)           #Capture namespace name
                                        ((\b(\w+)\b\.?){1,})
                                    )";/// match class or struct
    const string namespaceRegex = @"(?<=
                                        (?<=
                                            (?<!/{2,}.*)            #Ignore Comment
                                        )
                                        namespace\s+
                                    )";/// match namespace Name
    List<string> paths;
    ReorderableList pathUIList;
    Vector2 scrollPosition = Vector2.zero;
    HashSet<string> blackList = new HashSet<string>();
    Dictionary<string, System.Action<HashSet<string>, string>> assetExtentions = new Dictionary<string, System.Action<HashSet<string>, string>>
    {
        { "*.cs", SearchTypeInCSFile },
        { "*.dll", SearchTypeInAssembly },
    };

#if ENABLE_LUA_INJECTION
    [MenuItem("Lua/Generate LuaInjection BlackList")]
#endif
    public static void Open()
    {
        GetWindow<InjectionBlackListGenerator>("LuaInjection", true);
    }

    void OnListHeaderGUI(Rect rect)
    {
        EditorGUI.LabelField(rect, "Scripts Path");
    }

    void OnListElementGUI(Rect rect, int index, bool isactive, bool isfocused)
    {
        const float GAP = 5;

        string info = paths[index];
        rect.y++;

        Rect r = rect;
        r.width = 16;
        r.height = 18;
        r.xMin = r.xMax + GAP;
        r.xMax = rect.xMax - 50 - GAP;
        GUI.enabled = false;
        info = GUI.TextField(r, info);
        GUI.enabled = true;

        r.xMin = r.xMax + GAP;
        r.width = 50;
        if (GUI.Button(r, "Select"))
        {
            var path = SelectFolder();
            if (path != null)
            {
                paths[index] = path;
            }
        }
    }

    string SelectFolder()
    {
        string dataPath = Application.dataPath;
        string selectedPath = EditorUtility.OpenFolderPanel("Path", dataPath, "");
        if (!string.IsNullOrEmpty(selectedPath))
        {
            return GetRelativePath(selectedPath);
        }
        return null;
    }

    string GetRelativePath(string absolutePath)
    {
        if (absolutePath.StartsWith(Application.dataPath))
        {
            return "Assets/" + absolutePath.Substring(Application.dataPath.Length + 1);
        }
        else
        {
            ShowNotification(new GUIContent("不能在Assets目录之外!"));
        }
        return null;
    }

    void AddNewPath()
    {
        string path = SelectFolder();
        if (!string.IsNullOrEmpty(path))
        {
            paths.Add(path);
        }
    }

    void InitFilterListDrawer()
    {
        if (pathUIList != null)
        {
            return;
        }

        pathUIList = new ReorderableList(paths, typeof(string));
        pathUIList.drawElementCallback = OnListElementGUI;
        pathUIList.drawHeaderCallback = OnListHeaderGUI;
        pathUIList.draggable = true;
        pathUIList.elementHeight = 22;
        pathUIList.onAddCallback = (list) => AddNewPath();
    }

    void OnGUI()
    {
        InitPathsInfo();
        InitFilterListDrawer();

        bool execGenerate = false;
        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        {
            if (GUILayout.Button("Add", EditorStyles.toolbarButton))
            {
                AddNewPath();
            }
            if (GUILayout.Button("Save", EditorStyles.toolbarButton))
            {
                SavePathsInfo();
            }
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Generate", EditorStyles.toolbarButton))
            {
                execGenerate = true;
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginVertical();
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            {
                pathUIList.DoLayoutList();
            }
            GUILayout.EndScrollView();
        }
        GUILayout.EndVertical();

        if (execGenerate)
        {
            Generate();
            Close();
        }
    }

    void Generate()
    {
        if (paths.Count == 0)
        {
            EditorUtility.DisplayDialog("提示", "没有选中任何可跳过的路径", "确定");
            return;
        }
        blackList.Clear();

        foreach (var path in paths)
        {
            foreach (var extention in assetExtentions)
            {
                var files = from fileName in Directory.GetFiles(path, extention.Key, SearchOption.AllDirectories)
                            let validFullFileName = fileName.Replace("\\", "/")
                            let bEditorScriptFile = validFullFileName.Contains("/Editor/")
                            //let bToluaGeneratedFile = validFullFileName.Contains("/GenerateWrapFiles/")
                            where !bEditorScriptFile /*&& !bToluaGeneratedFile*/
                            select validFullFileName;

                int index = 0;
                foreach (var fileFullPath in files)
                {
                    EditorUtility.DisplayProgressBar("Searching", fileFullPath, (float)index / files.Count());
                    extention.Value(blackList, fileFullPath);
                    ++index;
                }
                EditorUtility.ClearProgressBar();
            }
        }

        blackList.UnionWith(specifiedDropType);
        SaveBlackList();
        SavePathsInfo();

        if (onBlackListGenerated != null)
        {
            onBlackListGenerated();
        }
        onBlackListGenerated = null;
        Debug.Log("BlackList Generated!!!");
    }

    static void SearchTypeInCSFile(HashSet<string> typeSet, string fileFullPath)
    {
        var fileContent = File.ReadAllText(fileFullPath);
        if (string.IsNullOrEmpty(fileContent))
        {
            return;
        }

        int nestCount = 0;
        int lastTypeMatchedIndex = 0;
        Stack<int> nestIndexStack = new Stack<int>();
        Stack<string> nestStack = new Stack<string>();

        var matchResult = Regex.Match(fileContent, nestRegex, RegexOptions.IgnorePatternWhitespace);
        while (matchResult.Success)
        {
            string typeName = matchResult.Value;
            if (string.IsNullOrEmpty(typeName))
            {
                matchResult = matchResult.NextMatch();
                continue;
            }

            lastTypeMatchedIndex = nestIndexStack.Count > 0 ? nestIndexStack.Peek() : 0;
            string matchSubString = fileContent.Substring(lastTypeMatchedIndex, matchResult.Index - lastTypeMatchedIndex);
            var beginBraceMatchResult = Regex.Matches(matchSubString, "(?<!/{2,}.*){");
            var endBraceMatchResult = Regex.Matches(matchSubString, "(?<!/{2,}.*)}");
            int compareTag = beginBraceMatchResult.Count - endBraceMatchResult.Count;
            bool bNamespaceMatched = Regex.IsMatch(matchSubString, namespaceRegex, RegexOptions.IgnorePatternWhitespace);
            nestIndexStack.Push(matchResult.Index);

            if (compareTag == 0)
            {
                nestStack.Clear();
                nestCount = 0;
            }
            else if (compareTag >= nestCount)
            {
                if (compareTag == nestCount)
                {
                    nestStack.Pop();
                }
                if (compareTag > nestCount)
                {
                    nestCount++;
                }
                nestIndexStack.Pop();
            }
            else if (compareTag < nestCount && compareTag > 0)
            {
                int searchedStackCount = nestStack.Count - compareTag;
                for (int i = 0; i < searchedStackCount; ++i)
                {
                    nestStack.Pop();
                }
                nestCount = nestStack.Count;
                if (nestCount > 0)
                {
                    nestIndexStack.Pop();
                }
            }

            string prefix = "";
            foreach (var name in nestStack)
            {
                prefix = name + prefix;
            }
            string typeFullName = prefix + typeName;
            if (!typeSet.Contains(typeFullName) && !bNamespaceMatched)
            {
                typeSet.Add(typeFullName);
            }

            string nestTag = (bNamespaceMatched ? "." : "+");
            nestStack.Push(typeName + nestTag);
            matchResult = matchResult.NextMatch();
        }
    }

    static void SearchTypeInAssembly(HashSet<string> typeSet, string assemblyPath)
    {
        Assembly assembly = null;
        try
        {
            assembly = Assembly.LoadFile(assemblyPath);
        }
        catch { }

        if (assembly == null)
        {
            return;
        }

        try
        {
            foreach (Type t in assembly.GetTypes())
            {
                bool bNotPrimitiveType = t.IsClass || (t.IsValueType && !t.IsPrimitive && !t.IsEnum);
                bool bCustomType = bNotPrimitiveType && !t.FullName.Contains("<");
                if (bCustomType && !typeSet.Contains(t.FullName) && !t.ContainsGenericParameters)
                {
                    typeSet.Add(t.FullName);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    void InitPathsInfo()
    {
        if (pathsInfoSavedPath == null)
        {
            pathsInfoSavedPath = CustomSettings.injectionFilesPath + "LuaInjectionSkipPaths.txt";
        }
        if (paths != null)
        {
            return;
        }

        if (File.Exists(pathsInfoSavedPath))
        {
            paths = new List<string>(File.ReadAllLines(pathsInfoSavedPath));
        }
        else
        {
            paths = new List<string>();
            string toluaPath = GetRelativePath(CustomSettings.injectionFilesPath.Substring(0, CustomSettings.injectionFilesPath.Length - "Injection/".Length));
            paths.Add(toluaPath + "Core/");
            paths.Add(toluaPath + "Injection/");
            paths.Add(toluaPath + "Misc/");
            paths.Add(toluaPath + "Injection/");
            paths.Add(toluaPath + "Misc/");
            paths.Add(Application.dataPath + "/Plugins/");
            paths.Add(CustomSettings.toluaBaseType);
            paths.Add(GetRelativePath(CustomSettings.saveDir));
        }
    }

    void SavePathsInfo()
    {
        File.WriteAllLines(pathsInfoSavedPath, paths.ToArray());
        AssetDatabase.Refresh();
    }

    void SaveBlackList()
    {
        try
        {
            if (File.Exists(blackListFilePath))
            {
                File.Delete(blackListFilePath);
            }
            File.WriteAllLines(blackListFilePath, blackList.ToArray());
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }

        AssetDatabase.Refresh();
    }
}