using System;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Error : Details
{

    private bool _isListening = false;

    private readonly Action<OnUnhandledRejectionListenerResult> _onUnhandledRejection = (res) => {
        var result = "onUnhandledRejection\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<WeChatWASM.Error> _onError = (res) => {
        var result = "onError\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<GeneralCallbackResult> _onAudioInterruptionEnd = (res) => {
        var result = "onAudioInterruptionEnd\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<GeneralCallbackResult> _onAudioInterruptionBegin = (res) => {
        var result = "onAudioInterruptionBegin\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (!_isListening) {
            WX.OnUnhandledRejection(_onUnhandledRejection);
            WX.OnError(_onError);
            WX.OnAudioInterruptionEnd(_onAudioInterruptionEnd);
            WX.OnAudioInterruptionBegin(_onAudioInterruptionBegin);
        } else {
            WX.OffUnhandledRejection(_onUnhandledRejection);
            WX.OffError(_onError);
            WX.OffAudioInterruptionEnd(_onAudioInterruptionEnd);
            WX.OffAudioInterruptionBegin(_onAudioInterruptionBegin);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消监听" : "开始监听");
    }


    private void OnDestroy()
    {
        WX.OffUnhandledRejection(_onUnhandledRejection);
        WX.OffError(_onError);
        WX.OffAudioInterruptionEnd(_onAudioInterruptionEnd);
        WX.OffAudioInterruptionBegin(_onAudioInterruptionBegin);
    }
}
