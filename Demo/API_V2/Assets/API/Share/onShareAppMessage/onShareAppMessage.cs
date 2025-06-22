using WeChatWASM;
using System;
using LitJson;
using UnityEngine;

public class onShareAppMessage : Details
{
    private readonly Action<Action<WXShareAppMessageParam>> _onShareAppMessageCallback = (
        callback
    ) =>
    {
        callback(
            new WXShareAppMessageParam
            {
                title = "转发标题2",
                imageUrl = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
                query = "key1=val1"
            }
        );
    };
    private bool _isListeningShare = false;

    private readonly Action<OnShowListenerResult> _onShow = (res) =>
    {
        var result = "onShow\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };

    private readonly Action<GeneralCallbackResult> _onHide = (res) =>
    {
        var result = "onHide\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };
    protected override void TestAPI(string[] args)
    {
        OnShareAppMessage();
    }
    public void OnShareAppMessage()
    {
        if (!_isListeningShare)
        {
            var defaultParam = new WXShareAppMessageParam
            {
                title = "转发标题1",
                imageUrl = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
                query = "key1=val1"
            };
            WX.OnShareAppMessage(defaultParam, _onShareAppMessageCallback);
            WX.ShowToast(new ShowToastOption
            {
                title = "开始监听转发",
                icon = "none"
            });
            WX.OnShow(_onShow);
            WX.OnHide(_onHide);
        }
        else
        {
            var defaultParam = new WXShareAppMessageParam
            {
                title = default,
                imageUrl = "xxx",
                query = "key1=val1"
            };
            WX.OnShareAppMessage(defaultParam);
            WX.ShowToast(new ShowToastOption
            {
                title = "取消监听转发",
                icon = "none"
            });
            WX.OffShow(_onShow);
            WX.OffHide(_onHide);
        }

        _isListeningShare = !_isListeningShare;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListeningShare ? "取消监听转发" : "开始监听转发"
        );
    }
}