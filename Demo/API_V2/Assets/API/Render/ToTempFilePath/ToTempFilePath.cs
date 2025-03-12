using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;
using LitJson;

public class ToTempFilePath : Details
{
    protected override void TestAPI(string[] args)
    {
        if (args[0] == "同步执行")
        {
            LoadCanvasToTempFilePathSync();
        }
        else
        {
            LoadCanvasToTempFilePath();
        }
    }

    // 异步
    private void LoadCanvasToTempFilePath()
    {// 根据options数组的索引获取值
        float x = GetOptionValue(1);
        float y = GetOptionValue(2);
        float width = GetOptionValue(3);
        float height = GetOptionValue(4);
        float destWidth = GetOptionValue(5);
        float destHeight = GetOptionValue(6);
        string fileType = GetOptionString(7, "png");
        float quality = GetOptionValue(8);

        string optionsInfo = $"当前参数值:\nx={x}\ny={y}\nwidth={width}\nheight={height}\ndestWidth={destWidth}\ndestHeight={destHeight}\nfileType={fileType}\nquality={quality}";

        WXCanvas.ToTempFilePath(new WXToTempFilePathParam()
        {
            x = (int)x,
            y = (int)y,
            width = (int)width,
            height = (int)height,
            destWidth = (int)destWidth,
            destHeight = (int)destHeight,
            fileType = fileType,
            quality = (int)quality,

            success = (result) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    title = "截图成功（异步）",
                    content = $"{optionsInfo}\n\n临时文件路径：\n{result.tempFilePath}",
                    showCancel = false,
                    confirmText = "展示截图",
                    success = (res) =>
                    {
                        WX.PreviewMedia(new PreviewMediaOption()
                        {
                            sources = new[] { new MediaSource { url = result.tempFilePath, type = "image" } },
                            current = 0,
                            success = (res) =>
                            {
                                Debug.Log("预览成功");
                            },
                            fail = (res) =>
                            {
                                Debug.Log("预览失败");
                            }
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

    // 同步
    private void LoadCanvasToTempFilePathSync()
    {

        // 根据options数组的索引获取值
        float x = GetOptionValue(1);
        float y = GetOptionValue(2);
        float width = GetOptionValue(3);
        float height = GetOptionValue(4);
        float destWidth = GetOptionValue(5);
        float destHeight = GetOptionValue(6);
        string fileType = GetOptionString(7, "png");
        float quality = GetOptionValue(8);

        string optionsInfo = $"当前参数值:\nx={x}\ny={y}\nwidth={width}\nheight={height}\ndestWidth={destWidth}\ndestHeight={destHeight}\nfileType={fileType}\nquality={quality}";

        var tempFilePath = WXCanvas.ToTempFilePathSync(new WXToTempFilePathSyncParam()
        {
            x = (int)x,
            y = (int)y,
            width = (int)width,
            height = (int)height,
            destWidth = (int)destWidth,
            destHeight = (int)destHeight,
            fileType = fileType,
            quality = (int)quality,
        });
        // 显示同步访问的结果
        WX.ShowModal(new ShowModalOption()
        {
            title = "截图成功（同步）",
            content = $"{optionsInfo}\n\n临时文件路径：\n{tempFilePath}",
            showCancel = false,
            confirmText = "展示截图",
            success = (res) =>
            {
                WX.PreviewMedia(new PreviewMediaOption()
                {
                    sources = new[] { new MediaSource { url = tempFilePath, type = "image" } },
                    current = 0,
                    success = (res) =>
                    {
                        Debug.Log("预览成功");
                    },
                    fail = (res) =>
                    {
                        Debug.Log("预览失败");
                    }
                });
            }
        });
    }
}