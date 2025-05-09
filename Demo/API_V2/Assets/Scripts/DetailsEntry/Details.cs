using UnityEngine;

public abstract class Details : MonoBehaviour
{
    public DetailsEntrySO entrySO;

    // 用于存储选项的数组
    protected string[] options;

    // 初始化 Details，设置对应的 EntrySO 和选项
    public void Init(DetailsEntrySO so)
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

    protected float GetOptionValue(int optionIndex, float defaultValue = 0f)
    {
        if (options != null && optionIndex < options.Length)
        {
            if (float.TryParse(options[optionIndex], out float value))
            {
                return value;
            }
        }
        return defaultValue;
    }
    //获得选项String类型值
    protected string GetOptionString(int optionIndex, string defaultValue = "")
    {
        if (options != null && optionIndex < options.Length)
        {
            return options[optionIndex];
        }
        return defaultValue;
    }
    //获得选项Bool类型值
    protected bool GetOptionBool(int optionIndex, bool defaultValue)
    {
        return options != null && optionIndex < options.Length && bool.TryParse(options[optionIndex], out bool value)
            ? value
            : defaultValue;
    }
    // 打印当前选项的值
    protected void LogCurrentOptions()
    {
        if (options != null)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Debug.Log($"Option {i}: {options[i]}");
            }
        }
        else
        {
            Debug.Log("Options array is null");
        }
    }
}
