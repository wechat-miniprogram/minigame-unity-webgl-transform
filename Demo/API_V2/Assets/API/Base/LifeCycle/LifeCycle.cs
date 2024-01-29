using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class LifeCycle : Details
{

    private bool _isListening = false;

    private readonly Action<OnShowListenerResult> _onShow = (res) => {
        var result = "onShow\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<GeneralCallbackResult> _onHide = (res) => {
        var result = "onHide\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (!_isListening) {
            WX.OnShow(_onShow);
            WX.OnHide(_onHide);
        } else {
            WX.OffShow(_onShow);
            WX.OffHide(_onHide);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消监听" : "开始监听");
    }
}
