using WeChatWASM;
using System;
using LitJson;
using UnityEngine;

public class onShareAppMessage : Details
{
    protected override void TestAPI(string[] args)
    {
        OnShareAppMessage();
    }
        public void OnShareAppMessage()
    {
        var defaultParam = new WXShareAppMessageParam
        {
            title = "转发标题",
            imageUrl = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
            query = "key1=val1&key2=val2"
        };
        WX.OnShareAppMessage(defaultParam);
    }
    public void OffShareAppMessage()
    {
        var defaultParam = new WXShareAppMessageParam
        {
            title = default,
            imageUrl = "xxx",
            query = "key1=val1&key2=val2"
        };
        WX.OnShareAppMessage(defaultParam);
    }
    private void OnDestroy()
    {
        OffShareAppMessage();
    }
}