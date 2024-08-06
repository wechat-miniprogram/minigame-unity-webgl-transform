using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Upload : Details
{
    private WXUploadTask _uploadTask;

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        // 需要修改url
        WX.ChooseMedia(new ChooseMediaOption()
        {
            count = 1,
            mediaType = new String[] { "image" },
            sourceType = new String[] { "album" },
            sizeType = new String[] { "compressed" },
            success = (res) =>
            {
                Debug.Log(JsonUtility.ToJson(res));
                _uploadTask = WX.UploadFile(new UploadFileOption()
                {
                    url = "https://developers.weixin.qq.com/minigame/dev/api/render/image/wx.createImage.html",
                    filePath = res.tempFiles[0].tempFilePath,
                    name = "data",
                    success = (res) =>
                    {
                        Debug.Log("success: " + JsonUtility.ToJson(res));
                    },
                    fail = (res) =>
                    {
                        Debug.Log("fail: " + JsonUtility.ToJson(res));
                    },
                    complete = (res) =>
                    {
                        Debug.Log("complete");
                    }
                });
            },
            fail = (res) =>
            {
                Debug.Log("fail: " + JsonUtility.ToJson(res));
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }


}