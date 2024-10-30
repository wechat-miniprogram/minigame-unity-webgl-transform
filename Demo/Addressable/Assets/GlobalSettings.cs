using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GlobalSettings : MonoBehaviour
{
    // 原同步写法
    // public Object testInstantiatePrefab;

    // Addressabe: prefab引用
    public List<AssetReference> testInstantiatePrefabs;

    public void Click()
    {
        if (testInstantiatePrefabs == null || testInstantiatePrefabs.Count == 0)
        {
            return;
        }
        var timeInSec = (int)UnityEngine.Time.realtimeSinceStartup;
        var index = timeInSec % testInstantiatePrefabs.Count;
        var prefab = testInstantiatePrefabs[index];

        // 原同步写法
        // Instantiate(GetComponent<GlobalSettings>().prefab);

        // Addressabe 方式1:  实例化
        prefab
            .InstantiateAsync(new Vector3(70.0f, 60.0f, 40.0f), Quaternion.identity)
            .Completed += (obj) =>
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.LogWarning("Instantiate from addresabe complete");
            }
        };
        // Addressabe 方式2： 只加载到内存：
        // AssetReference.LoadAssetAsync<GameObject>();
    }
}
