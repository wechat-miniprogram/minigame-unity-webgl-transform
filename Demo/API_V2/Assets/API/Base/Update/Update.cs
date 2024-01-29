using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Update : Details
{
    private WXUpdateManager _updateManager;

    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, updateManagerDemo);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        updateWeChatApp();
    }

    public void updateWeChatApp()
    {
        WX.UpdateWeChatApp(new UpdateWeChatAppOption
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

    public void updateManagerDemo() 
    {
        _updateManager = WX.GetUpdateManager();

        _updateManager.OnCheckForUpdate((res) => {
            // 请求完新版本信息的回调
            Debug.Log("Isupdate: " + res.hasUpdate);
        });

        _updateManager.OnUpdateReady((r) => {
            Debug.Log("ready" + r);
            WX.ShowModal(new ShowModalOption 
            {
                title = "更新提示",
                content = "新版本已经准备好，是否重启应用？",
                success = (res) => {
                    if (res.confirm) {
                        // 新的版本已经下载好，调用 applyUpdate 应用新版本并重启
                        _updateManager.ApplyUpdate();
                    }
                }
            });
        });

        _updateManager.OnUpdateFailed((res) => {
            // 新版本下载失败
            Debug.Log("fail" + res);
        });
    }
}
