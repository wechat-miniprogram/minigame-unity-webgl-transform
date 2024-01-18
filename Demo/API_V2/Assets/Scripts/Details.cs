using UnityEngine;

public abstract class Details : MonoBehaviour
{
    public EntrySO entrySO;

    // 用于存储选项的数组
    protected string[] options;

    // 初始化 Details，设置对应的 EntrySO 和选项
    public void Init(EntrySO so)
    {
        entrySO = so;
        options = new string[entrySO.optionList.Count];
        for (var i = 0; i < options.Length; i++)
        {
            options[i] = entrySO.optionList[i].availableOptions[0];
        }
    }

    // 当下拉框值改变时，更新对应的选项
    public void OnDropdownValueChanged(int dropdownIndex, int optionIndex)
    {
        var selectedOption = entrySO.optionList[dropdownIndex].availableOptions[optionIndex];
        
        options[dropdownIndex] = selectedOption;
    }
    
    // 运行测试 API
    public void Run()
    {
        TestAPI(options);
    }

    // 抽象方法，由子类实现具体的测试 API 逻辑
    protected abstract void TestAPI(string[] args);
}