using WeChatWASM;
using System;
using LitJson;

public class onShareMessage : Details
{
    private readonly Action<OnShareMessageToFriendListenerResult> _onShareMessageToFriend = (res) =>
{
    var result = "onShareMessageToFriend\n" + JsonMapper.ToJson(res);
    GameManager.Instance.detailsController.AddResult(
        new ResultData() { initialContentText = result }
    );
};

    private readonly Action<Action<WXShareAppMessageParam>> _onShareAppMessageCallback = (
    callback
) =>
{
    callback(
        new WXShareAppMessageParam
        {
            title = "转发标题",
            imageUrl = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
            query = "key1=val1&key2=val2"
        }
    );
};
    protected override void TestAPI(string[] args)
    {
        onShareMessageToFriend();
    }
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, onShareAppMessage);

    }
    public void onShareMessageToFriend()
    {
        WX.OnShareMessageToFriend(_onShareMessageToFriend);
    }
    public void onShareAppMessage()
    {
        var defaultParam = new WXShareAppMessageParam
        {
            title = "转发标题",
            imageUrl = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
            query = "key1=val1&key2=val2"
        };
        WX.OnShareAppMessage(defaultParam, _onShareAppMessageCallback);
    }
}