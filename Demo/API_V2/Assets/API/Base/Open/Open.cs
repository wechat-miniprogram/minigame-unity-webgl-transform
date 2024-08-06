using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Open : Details
{
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, openAppAuthorizeSetting);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        openSystemBluetoothSetting();
    }

    public void openSystemBluetoothSetting()
    {
        WX.OpenSystemBluetoothSetting(new OpenSystemBluetoothSettingOption
        {
            success = (res) =>
            {
                Debug.Log("success!");
            },
            fail = (res) =>
            {
                Debug.Log("fail:" + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete!");
            }
        });
    }

    public void openAppAuthorizeSetting()
    {
        WX.OpenAppAuthorizeSetting(new OpenAppAuthorizeSettingOption
        {
            success = (res) =>
            {
                Debug.Log("success!");
            },
            fail = (res) =>
            {
                Debug.Log("fail:" + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete!");
            }
        });
    }
}