using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Menu : Details
{
    private bool isMenuStyleDark = false;
    private bool isStatusBarStyleBlack = false;
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
        string style = isMenuStyleDark ? "light" : "dark";
        string toastMessage = $"设置{(isMenuStyleDark ? "浅色" : "深色")}菜单样式完成";
        
        WX.SetMenuStyle(
            new SetMenuStyleOption
            {
                style = style,
                success = (res) =>
                {
                    WX.ShowToast(new ShowToastOption { title = toastMessage, icon = "none"});
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

        isMenuStyleDark = !isMenuStyleDark;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            isMenuStyleDark ? "设置菜单栏浅色" : "设置菜单栏深色"
        );
    }

    public void getMenuButtonBoundingClientRect()
    {
        var res = WX.GetMenuButtonBoundingClientRect();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "GetMenuButtonBoundingClientRect, Result: " + JsonMapper.ToJson(res) }
        );
    }

    public void setStatusBarStyle()
    {
        string style = !isStatusBarStyleBlack ? "black" : "white";  // 修改逻辑
        string toastMessage = $"设置状态栏{(!isStatusBarStyleBlack ? "深色" : "白色")}样式完成";  // 修改逻辑

        WX.SetStatusBarStyle(
            new SetStatusBarStyleOption
            {
                style = style,
                success = (res) =>
                {
                    WX.ShowToast(new ShowToastOption { title = toastMessage, icon = "none"});
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

        isStatusBarStyleBlack = !isStatusBarStyleBlack;
        GameManager.Instance.detailsController.ChangeExtraButtonText(1,
            !isStatusBarStyleBlack ? "设置状态栏深色" : "设置状态栏白色"  // 修改逻辑
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