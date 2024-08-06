using UnityEngine;
using UnityEngine.UI;

public class OptionDropdownHandler : MonoBehaviour
{
    private Dropdown _dropdown;

    private Details _details;
    [SerializeField] private int dropdownIndex;

    [SerializeField] private Text optionNameText;

    private void Awake()
    {
        // 获取 Dropdown 组件
        _dropdown = GetComponent<Dropdown>();
    }

    private void Start()
    {
        // 为 Dropdown 添加值改变事件监听器
        _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // 初始化 OptionDropdownHandler，设置对应的 Details 和下拉框索引
    public void Init(Details details, int dropdownIndex)
    {
        _details = details;
        this.dropdownIndex = dropdownIndex;

        // 设置选项名称文本
        optionNameText.text = _details.entrySO.optionList[dropdownIndex].optionName;
        // 清除并添加可用选项
        _dropdown.ClearOptions();
        _dropdown.AddOptions(_details.entrySO.optionList[dropdownIndex].availableOptions);
    }

    // 处理下拉框值改变事件
    private void OnDropdownValueChanged(int selectedIndex)
    {
        _details.OnDropdownValueChanged(dropdownIndex, selectedIndex);
    }
}