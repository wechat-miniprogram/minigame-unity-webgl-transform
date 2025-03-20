using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Menu : Details
{
    private bool SetMenuStyles = false;
    private bool setStatusBarStyles = false;
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(
            0,
            getMenuButtonBoundingClientRect
        );
        GameManager.Instance.detailsController.BindExtraButtonAction(1, setStatusBarStyle);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        setMenuStyle();
    }
    public void setMenuStyle()
    {
        if (!SetMenuStyles)
        {
            WX.SetMenuStyle(
                new SetMenuStyleOption
                {
                    style = "dark",
                    success = (res) =>
                    {
                        WX.ShowToast(new ShowToastOption { title = "设置成功dark" });
                    },
                    fail = (res) =>
                    {
                        Debug.Log("fail:" + res.errMsg);
                    },
                    complete = (res) =>
                    {
                        Debug.Log("complete!");
                    }
                }
            );
        }
        else
        {
            WX.SetMenuStyle(
                new SetMenuStyleOption
                {
                    style = "light",
                    success = (res) =>
                    {
                        WX.ShowToast(new ShowToastOption { title = "设置成功light" });
                    },
                    fail = (res) =>
                    {
                        Debug.Log("fail:" + res.errMsg);
                    },
                    complete = (res) =>
                    {
                        Debug.Log("complete!");
                    }
                }
            );
        }
        SetMenuStyles = !SetMenuStyles;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            SetMenuStyles ? "设置菜单栏浅色" : "设置菜单栏深色"
        );

    }

    public void getMenuButtonBoundingClientRect()
    {
        var res = WX.GetMenuButtonBoundingClientRect();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
        );
    }

    public void setStatusBarStyle()
    {
        if (!setStatusBarStyles)
        {
            WX.SetStatusBarStyle(
                new SetStatusBarStyleOption
                {
                    style = "white",
                    success = (res) =>
                    {
                        WX.ShowToast(new ShowToastOption { title = "设置成功White" });
                    },
                    fail = (res) =>
                    {
                        Debug.Log("fail:" + res.errMsg);
                    },
                    complete = (res) =>
                    {
                        Debug.Log("complete!");
                    }
                }
            );
        }
        else
        {
            WX.SetStatusBarStyle(
                new SetStatusBarStyleOption
                {
                    style = "black",
                    success = (res) =>
                    {
                        WX.ShowToast(new ShowToastOption { title = "设置成功Black" });
                    },
                    fail = (res) =>
                    {
                        Debug.Log("fail:" + res.errMsg);
                    },
                    complete = (res) =>
                    {
                        Debug.Log("complete!");
                    }
                }
            );
        }
        setStatusBarStyles = !setStatusBarStyles;
        GameManager.Instance.detailsController.ChangeExtraButtonText(1,
            setStatusBarStyles ? "设置状态栏深色" : "设置状态栏白色"
        );
    }

    private void OnDestroy()
    {
        WX.SetStatusBarStyle(
                new SetStatusBarStyleOption
                {
                    style = "white",
                }
            );
    }
}
