using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class BatteryAndClipboard : Details
{

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, getBatteryInfo);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, getClipboardData);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, setClipboardData);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        getBatteryInfoSync();
    }

    public void getBatteryInfoSync()
    {
        var res = WX.GetBatteryInfoSync();

        WX.ShowModal(new ShowModalOption()
        {
            content = "Access Success, Result: " + JsonMapper.ToJson(res)
        });
    }

    public void getBatteryInfo()
    {
        WX.GetBatteryInfo(new GetBatteryInfoOption
        {
            success = (res) =>
            {
                Debug.Log("success" + JsonUtility.ToJson(res));
            },
            fail = (res) =>
            {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void getClipboardData()
    {
        WX.GetClipboardData(new GetClipboardDataOption
        {
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Access Success, Result: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void setClipboardData()
    {
        WX.SetClipboardData(new SetClipboardDataOption
        {
            data = "123",
            success = (res) =>
            {
                Debug.Log(JsonUtility.ToJson(res));
            },
            fail = (res) =>
            {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }
}