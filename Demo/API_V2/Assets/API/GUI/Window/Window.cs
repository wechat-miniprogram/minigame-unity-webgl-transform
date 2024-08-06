using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Window : Details
{
    private bool _isListening = false;

    private readonly Action<OnWindowResizeListenerResult> _onWindowResize = (res) =>
    {
        var result = "onWindowResize\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (!_isListening)
        {
            WX.OnWindowResize(_onWindowResize);
        }
        else
        {
            WX.OffWindowResize(_onWindowResize);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消监听" : "开始监听");
    }

    private void OnDestroy()
    {
        WX.OffWindowResize(_onWindowResize);
    }
}