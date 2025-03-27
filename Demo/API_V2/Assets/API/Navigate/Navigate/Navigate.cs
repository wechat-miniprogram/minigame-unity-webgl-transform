using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Navigate : Details
{
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, navigateToMiniProgram);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, exitMiniProgram);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, backMiniProgram);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        restartMiniProgram();
    }

    public void restartMiniProgram()
    {
        WX.RestartMiniProgram(new RestartMiniProgramOption { });
    }

    public void navigateToMiniProgram()
    {
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();
        myDictionary.Add("key1", "value1");
        myDictionary.Add("key2", "value2");
        WX.NavigateToMiniProgram(
            new NavigateToMiniProgramOption()
            {
                appId = "wx7a727ff7d940bb3f",
                path = "?id=123",
                extraData = myDictionary,
                envVersion = "develop",
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
            }
        );
    }

    public void exitMiniProgram()
    {
        WX.ExitMiniProgram(new ExitMiniProgramOption { });
    }

    public void backMiniProgram()
    {
        Debug.Log("触发返回到上一个小程序");
        WX.NavigateBackMiniProgram(new NavigateBackMiniProgramOption {
                success = (res) =>
                {
                    Debug.Log("success: " + JsonUtility.ToJson(res));
                },
                fail = (res) =>
                {
                    WX.ShowModal(
                    new ShowModalOption()
                    {
                        content = "BannerAd OnLoad Result:" + JsonUtility.ToJson(res)
                    }
                );
                },
                complete = (res) =>
                {
                    Debug.Log("complete");
                }
        });
    }
}
