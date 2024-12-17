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
        Debug.Log("screenWidth:" + sys.screenWidth);
        Debug.Log("screenHeight:" + sys.screenHeight);
        Debug.Log("windowWidth:" + sys.windowWidth);
        Debug.Log("windowHeight:" + sys.windowHeight);

        Debug.Log("UnityEngine.Screen.width;" + UnityEngine.Screen.width);
        Debug.Log("UnityEngine.Screen.height;" + UnityEngine.Screen.height);

        int ShareHeight = UnityEngine.Screen.height / 3;
        WXCanvas.ToTempFilePath(new WXToTempFilePathParam()
        {
            x = (UnityEngine.Screen.width - ShareHeight) / 2,
            y = ShareHeight,
            width = ShareHeight,
            height = ShareHeight,
            destWidth = ShareHeight,
            destHeight = ShareHeight,
            success = (result) =>
            {
                Debug.Log("ToTempFilePath success" + JsonUtility.ToJson(result));
                WX.ShareAppMessage(new ShareAppMessageOption()
                {
                    title = "这是你的标题",
                    imageUrl = result.tempFilePath,
                });
            },
            fail = (result) =>
            {
                Debug.Log("ToTempFilePath fail" + JsonUtility.ToJson(result));
            },
            complete = (result) =>
            {
                Debug.Log("ToTempFilePath complete" + JsonUtility.ToJson(result));
            },
        });
    }
}