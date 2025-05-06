using UnityEngine;
using UnityEngine.UI;

public class NativeAbility : MonoBehaviour
{
    [Header("Native Ability Data")]
    [SerializeField]
    private NativeAbilitySO nativeAbilitySO;

    [Header("References")]
    [SerializeField]
    private Text abilityText;
    [SerializeField]
    private Image abilityImage;

    [Header("Content")]
    [SerializeField]
    private GameObject entries;
    [SerializeField]
    private GameObject entryPrefab;

    [Header("Ability Content")]
    [SerializeField]
    private GameObject abilityContent;  // ability预制体的父物体
    [SerializeField]
    private GameObject abilityPrefab;   // ability预制体

    [Header("Expand")]
    [SerializeField]
    private float unfoldAlpha = 0.5f;
    private bool _isExpanded = false;

    [Header("Button")]
    [SerializeField]
    private Button button;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void Init(NativeAbilitySO so)
    {
        nativeAbilitySO = so;

        gameObject.name = nativeAbilitySO.abilityName;
        abilityText.text = nativeAbilitySO.abilityName;
        abilityImage.sprite = nativeAbilitySO.abilitySprite;

        // 初始化子条目
        if (nativeAbilitySO.entryList != null && nativeAbilitySO.entryList.Count > 0)
        {
            entries.SetActive(false);  // 初始时隐藏
            nativeAbilitySO.entryList.Sort((x, y) => x.entryOrder.CompareTo(y.entryOrder));
            foreach (var entry in nativeAbilitySO.entryList)
            {
                var entryObj = Instantiate(entryPrefab, entries.transform);
                entryObj.GetComponent<Entry>().Init(entry);
            }
        }
        else
        {
            entries.SetActive(false);
        }

        // 初始化 ability 预制体
        if (nativeAbilitySO.abilityList != null && nativeAbilitySO.abilityList.Count > 0)
        {
            abilityContent.SetActive(false);  // 初始时隐藏
            nativeAbilitySO.abilityList.Sort((x, y) => x.abilityOrder.CompareTo(y.abilityOrder));
            foreach (var ability in nativeAbilitySO.abilityList)
            {
                var abilityObj = Instantiate(abilityPrefab, abilityContent.transform);
                abilityObj.GetComponent<Ability>().Init(ability);
            }
        }
        else
        {
            abilityContent.SetActive(false);
        }
    }

    private static Color SetColorWithAlpha(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }

    public void OnClick()
    {
        _isExpanded = !_isExpanded;

        // 设置透明度
        abilityText.color = SetColorWithAlpha(abilityText.color, _isExpanded ? unfoldAlpha : 1f);
        abilityImage.color = SetColorWithAlpha(abilityImage.color, _isExpanded ? unfoldAlpha : 1f);

        // 显示/隐藏子条目
        if (entries != null && nativeAbilitySO.entryList != null && nativeAbilitySO.entryList.Count > 0)
        {
            entries.SetActive(_isExpanded);
        }

        // 显示/隐藏 ability 预制体
        if (abilityContent != null && nativeAbilitySO.abilityList != null && nativeAbilitySO.abilityList.Count > 0)
        {
            abilityContent.SetActive(_isExpanded);
        }
        /*
                // 如果有场景需要加载
                if (!string.IsNullOrEmpty(nativeAbilitySO.abilitySceneName))
                {
                    GameManager.Instance.LoadScene(nativeAbilitySO.abilitySceneName);
                }
        */
        // 强制刷新布局
        var contentRectTransform = transform.parent.GetComponent<RectTransform>();
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRectTransform);
    }
}
