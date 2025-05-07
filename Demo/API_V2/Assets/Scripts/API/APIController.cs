using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

public class APIController : MonoBehaviour
{
    [Header("API Data")]
    [SerializeField]
    private APISO apiSO;

    [Header("Elements")]
    [SerializeField]
    private GameObject categoryPrefab;

    [SerializeField]
    private Transform apiCategoriesTransform;

    [SerializeField]
    private Transform nativeAbilityCategoriesTransform;

    [Header("Title Transform")]
    [SerializeField]
    private RectTransform title;

    private void Start()
    {
        Init();

        // 不能放到Init里 Editor会报错
        // 根据系统安全区域调整标题的位置
        title.anchoredPosition = new Vector2(
            title.anchoredPosition.x,
            -125f - (float)GameManager.Instance.WindowInfo.safeArea.top
        );
    }

    // 清除子物体
    private static void ClearChild(Transform parent)
    {
        var childCount = parent.childCount;

        // 从后往前遍历子物体 否则会导致索引错误
        for (var i = childCount - 1; i >= 0; i--)
        {
            var child = parent.GetChild(i);
            DestroyImmediate(child.gameObject);
        }
    }

    // 初始化 APIController，创建分类和能力
    public void Init()
    {
        ClearChild(apiCategoriesTransform);
        ClearChild(nativeAbilityCategoriesTransform);

        // 根据分类顺序创建API类别
        apiSO.categoryList.Sort((x, y) => x.categoryOrder.CompareTo(y.categoryOrder));
        // 为每个分类实例化一个预制体并初始化
        foreach (var category in apiSO.categoryList)
        {
            var categoryObj = Instantiate(categoryPrefab, apiCategoriesTransform);
            categoryObj.GetComponent<Category>().Init(category);
        }

        // 根据分类顺序创建原生能力类别
        apiSO.nativeAbilityList.Sort((x, y) => x.categoryOrder.CompareTo(y.categoryOrder));
        // 为每个分类实例化一个预制体并初始化
        foreach (var category in apiSO.nativeAbilityList)
        {
            var categoryObj = Instantiate(categoryPrefab, nativeAbilityCategoriesTransform);
            categoryObj.GetComponent<Category>().Init(category);
        }

#if UNITY_EDITOR
        if (!EditorApplication.isPlaying)
        {
            SaveCurrentScene();
        }
#endif
    }

#if UNITY_EDITOR
    private static void SaveCurrentScene()
    {
        // 获取当前场景
        var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        // 保存场景
        if (!string.IsNullOrEmpty(currentScene.path))
        {
            EditorSceneManager.SaveScene(currentScene);
            Debug.Log("Scene saved: " + currentScene.name);
        }
        else
        {
            Debug.LogWarning("Current scene has not been saved yet.");
        }
    }
#endif
}
