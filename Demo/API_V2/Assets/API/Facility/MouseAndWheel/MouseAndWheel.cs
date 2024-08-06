using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class MouseAndWheel : Details
{

    private bool _isListening = false;

    private readonly Action<OnMouseDownListenerResult> _onMouseUp = (res) =>
    {
        var result = "onMouseUp\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnMouseMoveListenerResult> _onMouseMove = (res) =>
    {
        var result = "onMouseMove\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnMouseDownListenerResult> _onMouseDown = (res) =>
    {
        var result = "onMouseDown\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnWheelListenerResult> _onWheel = (res) =>
    {
        var result = "onWheel\n" + JsonMapper.ToJson(res);
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
            WX.OnMouseUp(_onMouseUp);
            WX.OnMouseDown(_onMouseDown);
            WX.OnMouseMove(_onMouseMove);
            WX.OnWheel(_onWheel);
        }
        else
        {
            WX.OffMouseUp(_onMouseUp);
            WX.OffMouseDown(_onMouseDown);
            WX.OffMouseMove(_onMouseMove);
            WX.OffWheel(_onWheel);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消监听" : "开始监听");
    }

    private void OnDestroy()
    {
        WX.OffMouseUp(_onMouseUp);
        WX.OffMouseDown(_onMouseDown);
        WX.OffMouseMove(_onMouseMove);
        WX.OffWheel(_onWheel);
    }
}