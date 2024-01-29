using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Interact : Details
{
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, showModal);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, showLoading);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, showActionSheet);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, hideToast);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, hideLoading);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        showToast();
    }

    public void showToast() {
        WX.ShowToast(new ShowToastOption 
        {
            title = "showToast",
            duration = 5000,
            success = (res) => 
            {
                Debug.Log(res);
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

    public void showModal() {
        WX.ShowModal(new ShowModalOption 
        {
            title = "showModal",
            content = "show",
            showCancel = true,
            cancelText = "取消",
            confirmText = "确定",
            success = (res) => 
            {
                Debug.Log("success");
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

    public void showLoading() {
        WX.ShowLoading(new ShowLoadingOption 
        {
            title = "showLoading",
            success = (res) => 
            {
                Debug.Log("success");
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

    public void showActionSheet() {
        WX.ShowActionSheet(new ShowActionSheetOption
        {
            alertText = "showActionSheet",
            itemList = new string[] {"1", "2", "3"},
            success = (res) => 
            {
                Debug.Log("success");
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

    public void hideToast() {
        WX.HideToast(new HideToastOption
        {
            success = (res) => 
            {
                Debug.Log("success");
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

    public void hideLoading() {
        WX.HideLoading(new HideLoadingOption
        {
            success = (res) => 
            {
                Debug.Log("success");
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
