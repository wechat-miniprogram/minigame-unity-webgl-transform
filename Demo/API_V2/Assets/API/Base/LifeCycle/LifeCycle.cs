using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class LifeCycle : Details
{
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, getLaunchOptionsSync);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, getEnterOptionsSync);
    }
    private bool _isListening = false;

    private readonly Action<OnShowListenerResult> _onShow = (res) =>
    {
        var result = "OnShow\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };

    private readonly Action<GeneralCallbackResult> _onHide = (res) =>
    {
        var result = "OnHide\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };


    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (!_isListening)
        {
            WX.OnShow(_onShow);
            WX.OnHide(_onHide);
        }
        else
        {
            WX.OffShow(_onShow);
            WX.OffHide(_onHide);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListening ? "取消监听hide/show事件" : "开始监听hide/show事件"
        );
    }

    public void getLaunchOptionsSync()
    {
        var LaunchOptionsSync = WX.GetLaunchOptionsSync();
        var result = "GetLaunchOptionsSync\n" + JsonMapper.ToJson(LaunchOptionsSync);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    }

    public void getEnterOptionsSync()
    {
        var EnterOptionsSync = WX.GetEnterOptionsSync();
        var result = "GetEnterOptionsSync\n" + JsonMapper.ToJson(EnterOptionsSync);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );

    }

    private void OnDestroy()
    {
        WX.OffShow(_onShow);
        WX.OffHide(_onHide);
    }
}
