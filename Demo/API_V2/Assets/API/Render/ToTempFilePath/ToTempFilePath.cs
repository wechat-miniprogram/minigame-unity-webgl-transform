using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class ToTempFilePath : Details
{
    private void Start()
    {
        LogCurrentOptions();
    }

    protected override void TestAPI(string[] args)
    {
        LogCurrentOptions();    // 执行API前打印当前值
        LoadCanvasToTempFilePath();
    }

    /// <summary>
    /// 当下拉菜单值改变时的回调方法
    /// </summary>
    /// <param name="dropdownIndex">下拉菜单索引</param>
    /// <param name="optionIndex">选项索引</param>
    public new void OnDropdownValueChanged(int dropdownIndex, int optionIndex)
    {
        base.OnDropdownValueChanged(dropdownIndex, optionIndex);
        string newValue = entrySO.optionList[dropdownIndex].availableOptions[optionIndex];
        UpdateOption(dropdownIndex, newValue);
        LogCurrentOptions();
    }


    private float GetOptionValue(int optionIndex, float defaultValue = 0f)
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

    private void LoadCanvasToTempFilePath()
    {
        var sys = WX.GetSystemInfoSync();
        string sysInfo = string.Format(
            "屏幕信息:\nscreenWidth:{0}\nscreenHeight:{1}\nwindowWidth:{2}\nwindowHeight:{3}\n",
            sys.screenWidth, sys.screenHeight, sys.windowWidth, sys.windowHeight
        );

        // 根据options数组的索引获取值
        float x = GetOptionValue(0);
        float y = GetOptionValue(1);
        float width = GetOptionValue(2);
        float height = GetOptionValue(3);

        Debug.Log($"Using values: x={x}, y={y}, width={width}, height={height}");

        WXCanvas.ToTempFilePath(new WXToTempFilePathParam()
        {
            x = (int)x,
            y = (int)y,
            width = (int)width,
            height = (int)height,
            success = (result) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    title = "截图成功",
                    content = "临时文件路径：" + result.tempFilePath + "\n\n" + sysInfo,
                    showCancel = false,
                    success = (res) =>
                    {
                        WX.ShareAppMessage(new ShareAppMessageOption()
                        {
                            title = "这是你的标题",
                            imageUrl = result.tempFilePath,
                        });
                    }
                });
            },
            fail = (result) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    title = "截图失败",
                    content = JsonUtility.ToJson(result),
                    showCancel = false
                });
            },
            complete = (result) =>
            {
                Debug.Log("complete");
            },
        });
    }

    // 打印当前选项的值
    private void LogCurrentOptions()
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

    // 更新指定索引的选项值
    public void UpdateOption(int optionIndex, string value)
    {
        if (options != null && optionIndex < options.Length)
        {
            options[optionIndex] = value;
        }
        else
        {
            Debug.Log($"Cannot update option {optionIndex}: Invalid index or options not initialized");
        }
    }

    // 更新所有选项值
    public void UpdateValues()
    {
        // 直接从entrySO中获取值并更新
        for (int i = 0; i < entrySO.optionList.Count; i++)
        {
            string value = entrySO.optionList[i].availableOptions[0];
            UpdateOption(i, value); // 更新对应索引选项值
        }
    }
}