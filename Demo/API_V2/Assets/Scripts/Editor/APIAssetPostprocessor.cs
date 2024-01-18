#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using System.Linq;

public class APIAssetPostprocessor : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        var addedAssets = importedAssets.Concat(movedAssets).ToArray();
        
        foreach (var assetPath in addedAssets)
        {
            // 跳过非法路径
            if (!File.Exists(assetPath)) continue;
            
            switch (Path.GetExtension(assetPath))
            {
                case ".asset":
                {
                    var apiSO = AssetDatabase.LoadAssetAtPath<APISO>(assetPath);
                    var categorySO = AssetDatabase.LoadAssetAtPath<CategorySO>(assetPath);
                    var entrySO = AssetDatabase.LoadAssetAtPath<EntrySO>(assetPath);
                    var abilitySO = AssetDatabase.LoadAssetAtPath<AbilitySO>(assetPath);

                    if (apiSO != null)
                    {
                        UpdateAPISO(apiSO);
                    }
                    else if (categorySO != null)
                    {
                        UpdateAPISO(GetAPISOFromParentPath(assetPath));
                        UpdateCategorySO(categorySO);
                    }
                    else if (entrySO != null)
                    {
                        UpdateCategorySO(GetCategorySOFromParentPath(assetPath));
                        UpdateEntrySO(entrySO);
                    }
                    else if (abilitySO != null) 
                    {
                        UpdateAPISO(GetAPISOFromParentPath(assetPath));
                        // UpdateAbilitySO(abilitySO);
                    }

                    break;
                }
                case ".cs":
                {
                    var entrySO = GetEntrySOFromSamePath(assetPath);

                    if (entrySO) UpdateEntrySO(entrySO);

                    break;
                }
            }
        }

        var removedAssets = deletedAssets.Concat(movedFromAssetPaths).ToArray();
        foreach (var assetPath in removedAssets)
        {
            // 跳过非法路径
            if (!File.Exists(assetPath)) continue;

            var apiSO = GetAPISOFromParentPath(assetPath);
            var categorySO = GetCategorySOFromParentPath(assetPath);
            var entrySO = GetEntrySOFromSamePath(assetPath);

            if(apiSO) UpdateAPISO(apiSO);
            if(categorySO) UpdateCategorySO(categorySO);
            if(entrySO) UpdateEntrySO(entrySO);
        }
    }


    public static void UpdateAPISO(APISO apiSO)
    {
        if (apiSO == null) return;

        var assetDirectory = Path.GetDirectoryName(AssetDatabase.GetAssetPath(apiSO));
        var subdirectories = Directory.GetDirectories(assetDirectory);

        apiSO.categoryList.Clear();
        apiSO.abilityList.Clear();

        foreach (var subdirectory in subdirectories)
        {
            var allFiles = Directory.GetFiles(subdirectory);

            foreach (var file in allFiles)
            {
                // 只考虑 .asset 文件
                if (Path.GetExtension(file) != ".asset") continue;
                
                var categorySO = AssetDatabase.LoadAssetAtPath<CategorySO>(file);
                if (categorySO != null)
                {
                    apiSO.categoryList.Add(categorySO);
                }

                var abilitySO = AssetDatabase.LoadAssetAtPath<AbilitySO>(file);
                if (abilitySO != null)
                {
                    apiSO.abilityList.Add(abilitySO);
                }
            }
        }

        EditorUtility.SetDirty(apiSO);
    }

    public static void UpdateCategorySO(CategorySO categorySO)
    {
        if (categorySO == null) return;

        var assetDirectory = Path.GetDirectoryName(AssetDatabase.GetAssetPath(categorySO));
        var subdirectories = Directory.GetDirectories(assetDirectory);

        categorySO.entryList.Clear();

        foreach (var subdirectory in subdirectories)
        {
            var allFiles = Directory.GetFiles(subdirectory);

            foreach (var file in allFiles)
            {
                // 只考虑 .asset 文件
                if (Path.GetExtension(file) != ".asset") continue;
                
                var entrySO = AssetDatabase.LoadAssetAtPath<EntrySO>(file);
                if (entrySO != null)
                {
                    categorySO.entryList.Add(entrySO);
                }
            }
        }

        EditorUtility.SetDirty(categorySO);
    }

    public static void UpdateEntrySO(EntrySO entrySO)
    {
        if (entrySO == null) return;
        
        var assetDirectory = Path.GetDirectoryName(AssetDatabase.GetAssetPath(entrySO));
        // 获取与 EntrySO 相同目录下的所有 C# 脚本文件（.cs）
        var scriptFiles = Directory.GetFiles(assetDirectory, "*.cs", SearchOption.TopDirectoryOnly);

        entrySO.EntryScriptType = null;
        
        // 遍历所有脚本文件，检查是否包含 Details 子类
        foreach (string scriptFile in scriptFiles)
        {
            var script = AssetDatabase.LoadAssetAtPath<MonoScript>(scriptFile);
            var scriptType = script.GetClass();

            // 如果找到 Details 子类，将其添加到 entrySO.entryScriptType
            if (scriptType != null && scriptType.IsSubclassOf(typeof(Details)) && !scriptType.IsAbstract)
            {
                entrySO.EntryScriptType = scriptType;
            }
        }

        EditorUtility.SetDirty(entrySO);
    }

    private static APISO GetAPISOFromParentPath(string path)
    {
        var parentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(path));
        
        if (parentDirectory == null) return null;
        
        var allFiles = Directory.GetFiles(parentDirectory);

        foreach (var file in allFiles)
        {
            // 只考虑 .asset 文件
            if (Path.GetExtension(file) != ".asset") continue;
            
            var apiSO = AssetDatabase.LoadAssetAtPath<APISO>(file);
            if (apiSO != null)
            {
                return apiSO;
            }
        }

        return null;
    }

    private static CategorySO GetCategorySOFromParentPath(string path)
    {
        var parentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(path));
        
        if (parentDirectory == null) return null;
        
        var allFiles = Directory.GetFiles(parentDirectory);

        foreach (var file in allFiles)
        {
            if (Path.GetExtension(file) != ".asset") continue; // 只考虑 .asset 文件
            
            var categorySO = AssetDatabase.LoadAssetAtPath<CategorySO>(file);
            if (categorySO != null)
            {
                return categorySO;
            }
        }

        return null;
    }

    private static EntrySO GetEntrySOFromSamePath(string path)
    {
        var assetDirectory = Path.GetDirectoryName(path);
        
        if (assetDirectory == null) return null;
        
        var allFiles = Directory.GetFiles(assetDirectory);

        foreach (var file in allFiles)
        {
            if (Path.GetExtension(file) != ".asset") continue; // 只考虑 .asset 文件
            
            var entrySO = AssetDatabase.LoadAssetAtPath<EntrySO>(file);
            if (entrySO != null)
            {
                return entrySO;
            }
        }

        return null;
    }
}
#endif