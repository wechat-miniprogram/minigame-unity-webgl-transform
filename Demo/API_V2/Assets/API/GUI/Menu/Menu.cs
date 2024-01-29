using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Menu : Details
{
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, getMenuButtonBoundingClientRect);
        GameManager.Instance.detailsController.BindExtraButtonAction(0, setStatusBarStyle);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        setMenuStyle();
    }

    public void setMenuStyle() {
        WX.SetMenuStyle(new SetMenuStyleOption
        {
            style = "light",
            success = (res) => 
            {
                WX.ShowToast(new ShowToastOption
                {
                    title = "设置成功"
                });
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

    public void getMenuButtonBoundingClientRect() {
        var res = WX.GetMenuButtonBoundingClientRect();

        // 访问成功，显示结果
        WX.ShowModal(new ShowModalOption()
        {
            content = "Access Success, Result: " + JsonMapper.ToJson(res)
        });
    }

    public void setStatusBarStyle() {
        WX.SetStatusBarStyle(new SetStatusBarStyleOption
        {
            style = "black",
            success = (res) => 
            {
                WX.ShowToast(new ShowToastOption
                {
                    title = "设置成功"
                });
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
