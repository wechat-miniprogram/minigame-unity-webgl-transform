#if UNITY_EDITOR
using System;
using UnityEditor;
using System.IO;
using System.Linq;

public class FolderRenameProcessor : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(
        string[] importedAssets,
        string[] deletedAssets,
        string[] movedAssets,
        string[] movedFromAssetPaths
    )
    {
        // 重命名文件夹下的脚本与SO
        foreach (var movedAsset in movedAssets)
        {
            // 跳过非文件夹
            if (!AssetDatabase.IsValidFolder(movedAsset))
                continue;

            // 跳过非 Assets/API 下的文件夹
            if (!IsSubdirectory(movedAsset, "Assets/API"))
                continue;

            var newFolderName = Path.GetFileName(movedAsset);

            var filePaths = Directory.GetFiles(movedAsset);

            // 检查是否存在挂载 SceneEntrySO 的 .asset 文件
            bool hasSceneEntrySO = filePaths.Any(filePath =>
            {
                if (Path.GetExtension(filePath) != ".asset")
                    return false;

                var asset = AssetDatabase.LoadAssetAtPath<SceneEntrySO>(filePath);
                return asset != null;
            });

            foreach (var filePath in filePaths)
            {
                var fileExtension = Path.GetExtension(filePath);
                string newFileName;

                switch (fileExtension)
                {
                    case ".cs":
                        if (hasSceneEntrySO) continue; // SceneEntrySO 时跳过 .cs 文件
                        newFileName = newFolderName + fileExtension;
                        break;
                    case ".asset":
                        newFileName = newFolderName + "SO" + fileExtension;
                        break;
                    default:
                        continue; // 跳过其他文件类型
                }

                var newFilePath = Path.Combine(movedAsset, newFileName);

                // 重命名文件
                AssetDatabase.MoveAsset(filePath, newFilePath);
            }
        }
    }

    private static bool IsSubdirectory(string folderPath, string parentFolderPath)
    {
        // 获取绝对路径
        var absoluteFolderPath = Path.GetFullPath(folderPath);
        var absoluteParentFolderPath = Path.GetFullPath(parentFolderPath);

        // 确保路径以目录分隔符结尾
        if (!absoluteParentFolderPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
        {
            absoluteParentFolderPath += Path.DirectorySeparatorChar;
        }

        // 判断第一个文件夹的路径是否以第二个文件夹的路径开头
        return absoluteFolderPath.StartsWith(
            absoluteParentFolderPath,
            StringComparison.OrdinalIgnoreCase
        );
    }
}
#endif
