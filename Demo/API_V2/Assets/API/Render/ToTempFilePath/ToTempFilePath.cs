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
    {
var sys = WX.GetSystemInfoSync();
        string sysInfo = string.Format(
            "屏幕信息:\nscreenWidth:{0}\nscreenHeight:{1}\nwindowWidth:{2}\nwindowHeight:{3}\n",
            sys.screenWidth, sys.screenHeight, sys.windowWidth, sys.windowHeight
        );

        
        WXCanvas.ToTempFilePath(new WXToTempFilePathParam()
        {
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
                //完成处理
            },
        });
    }
}