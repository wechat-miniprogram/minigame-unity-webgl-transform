using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class ToTempFilePath : Details
{
    protected override void TestAPI(string[] args)
    {
        LoadCanvasToTempFilePath();
    }
    private void LoadCanvasToTempFilePath()
    {// 根据options数组的索引获取值
        float x = GetOptionValue(0);
        float y = GetOptionValue(1);
        float width = GetOptionValue(2);
        float height = GetOptionValue(3);
        float destWidth = GetOptionValue(4);
        float destHeight = GetOptionValue(5);
        string fileType = GetOptionString(6, "png");
        float quality = GetOptionValue(7);

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
                    title = "截图成功",
                    content = $"{optionsInfo}\n\n临时文件路径：{result.tempFilePath}",
                    showCancel = false,
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
                        var fileManager = WX.GetFileSystemManager();
                        fileManager.Access(new AccessParam()
                        {
                            path = result.tempFilePath,
                            success = (res) =>
                            {
                                Debug.Log("文件存在");
                            },
                            fail = (res) =>
                            {
                                Debug.Log("文件不存在");
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
}