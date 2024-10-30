using UnityEngine;

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
    private GameObject abilityPrefab;

    [SerializeField]
    private Transform abilitiesTransform;

    [Header("Title Transform")]
    [SerializeField]
    private RectTransform title;

    private void Start()
    {
        Init();
        // 根据系统安全区域调整标题的位置
        title.anchoredPosition = new Vector2(
            title.anchoredPosition.x,
            -125f - (float)GameManager.Instance.WindowInfo.safeArea.top
        );
    }

    // 清除所有分类
    private void ClearCategories()
    {
        var childCount = apiCategoriesTransform.childCount;

        for (var i = childCount - 1; i >= 0; i--)
        {
            var child = apiCategoriesTransform.GetChild(i);
            DestroyImmediate(child.gameObject);
        }
    }

    // 清除所有能力
    private void ClearAbilities()
    {
        var childCount = abilitiesTransform.childCount;

        for (var i = childCount - 1; i >= 0; i--)
        {
            var child = abilitiesTransform.GetChild(i);
            DestroyImmediate(child.gameObject);
        }
    }

    // 初始化 APIController，创建分类和能力
    public void Init()
    {
        ClearCategories();
        ClearAbilities();

        // 为每个分类实例化一个预制体并初始化
        foreach (var category in apiSO.categoryList)
        {
            var categoryObj = Instantiate(categoryPrefab, apiCategoriesTransform);
            categoryObj.GetComponent<Category>().Init(category);
        }

        // 为每个能力实例化一个预制体并初始化
        foreach (var ability in apiSO.abilityList)
        {
            var abilityObj = Instantiate(abilityPrefab, abilitiesTransform);
            abilityObj.GetComponent<Ability>().Init(ability);
        }
    }
}
