using UnityEngine;
using UnityEngine.UI;

public class Entry : MonoBehaviour
{
    [Header("Entry Data")]
    [SerializeField]
    private EntrySO entrySO;

    [Header("References")]
    [SerializeField]
    private Text entryNameText;

    private Button _button;

    private void Awake()
    {
        // 获取 Button 组件
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        // 为按钮添加点击事件监听器
        _button.onClick.AddListener(OnClick);
    }

    // 初始化 Entry，设置对应的 EntrySO 和文本
    public void Init(EntrySO so)
    {
        entrySO = so;
        entryNameText.text = entrySO.entryName;
        gameObject.name = entrySO.entryName;
    }

    // 点击事件处理
    private void OnClick()
    {
        switch (entrySO)
        {
            case SceneEntrySO sceneEntrySO:
                // 加载对应的场景
                GameManager.Instance.LoadScene(sceneEntrySO.AbilitySceneName);
                break;
            case DetailsEntrySO detailsEntrySO:
                // 切换画布
                GameManager.Instance.SwitchCanvas();
                // 初始化详情控制器
                GameManager.Instance.detailsController.Init(detailsEntrySO);
                break;
            default:
                Debug.LogError("Unknown Entry Type");
                break;
        }
    }
}
