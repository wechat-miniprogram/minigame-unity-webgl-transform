using System;
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

    protected T? GetOptionValue<T>(int optionIndex) where T : struct
    {
        if (options != null && optionIndex < options.Length)
        {
            // 如果选项是 "null"，则返回 null
            if (options[optionIndex] == "null")
            {
                return null;
            }
            
            // 根据类型进行转换
            if (typeof(T) == typeof(bool))
            {
                if (bool.TryParse(options[optionIndex], out var boolValue))
                {
                    return (T)(object)boolValue;
                }
            }
            else if (typeof(T) == typeof(int))
            {
                if (int.TryParse(options[optionIndex], out var intValue))
                {
                    return (T)(object)intValue;
                }
            }
            else if (typeof(T) == typeof(float))
            {
                if (float.TryParse(options[optionIndex], out var floatValue))
                {
                    return (T)(object)floatValue;
                }
            }
            else if (typeof(T) == typeof(long))
            {
                if (long.TryParse(options[optionIndex], out var longValue))
                {
                    return (T)(object)longValue;
                }
            }
            else if (typeof(T) == typeof(double))
            {
                if (double.TryParse(options[optionIndex], out var doubleValue))
                {
                    return (T)(object)doubleValue;
                }
            }
        }
        return null;
    }

    //获得选项String类型值
    protected string GetOptionString(int optionIndex)
    {
        if (options != null && optionIndex < options.Length)
        {
            // 如果选项是 "null"，则返回 null
            if (options[optionIndex] == "null")
            {
                return null;
            }
            return options[optionIndex];
        }
        return null;
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
