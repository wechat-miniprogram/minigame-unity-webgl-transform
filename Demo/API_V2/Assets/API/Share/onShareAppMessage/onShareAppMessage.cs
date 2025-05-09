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
                query = "key1=val1&key2=val2"
            }
        );
        Debug.Log("回调callback");
    };
    private bool _isListeningShare = false;
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
                query = "key1=val1&key2=val2"
            };
            WX.OnShareAppMessage(defaultParam, _onShareAppMessageCallback);
            Debug.Log("触发监听转发");
        }
        else
        {
            var defaultParam = new WXShareAppMessageParam
            {
                title = default,
                imageUrl = "xxx",
                query = "key1=val1&key2=val2"
            };
            WX.OnShareAppMessage(defaultParam);
            Debug.Log("取消监听转发");
        }

        _isListeningShare = !_isListeningShare;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListeningShare ? "取消监听转发" : "开始监听转发"
        );
    }
}