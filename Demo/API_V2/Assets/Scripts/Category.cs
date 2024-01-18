using UnityEngine;
using UnityEngine.UI;

public class Category : MonoBehaviour
{
    private RectTransform _contentRectTransform;

    [Header("Category Data")] 
    [SerializeField] private CategorySO categorySO;

    [Header("References")]
    [SerializeField] private Text categoryText;
    [SerializeField] private Image categoryImage;

    [Header("Entries")]
    [SerializeField] private GameObject entryPrefab;
    [SerializeField] private GameObject entries;
    
    [Header("Expand")]
    [SerializeField] private float unfoldAlpha = 0.5f;
    private bool _isExpanded = false;
    
    [Header("Button")]
    [SerializeField] private Button button;

    private void Awake()
    {
        // 获取父对象的 RectTransform 组件
        _contentRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    // 初始化 Category，设置对应的 CategorySO 和条目
    public void Init(CategorySO so)
    {
        categorySO = so;
        
        gameObject.name = categorySO.categoryName;
        categoryText.text = categorySO.categoryName;
        categoryImage.sprite = categorySO.categorySprite;
        
        // 为每个条目实例化一个预制体并初始化
        foreach (var entry in categorySO.entryList)
        {
            var entryObj = Instantiate(entryPrefab, entries.transform);
            entryObj.GetComponent<Entry>().Init(entry);
        }
    }

    // 设置颜色的透明度
    private static Color SetColorWithAlpha(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }
    
    // 点击事件处理
    public void OnClick()
    {
        // 切换展开状态
        _isExpanded = !_isExpanded;
        
        // 根据展开状态设置文本和图片的透明度
        categoryText.color = SetColorWithAlpha(categoryText.color, _isExpanded ? unfoldAlpha : 1f);
        categoryImage.color = SetColorWithAlpha(categoryImage.color, _isExpanded ? unfoldAlpha : 1f);

        // 根据展开状态设置条目的活跃状态
        entries.SetActive(_isExpanded);
        
        // 强制立即重新构建布局
        LayoutRebuilder.ForceRebuildLayoutImmediate(_contentRectTransform);
    }
}