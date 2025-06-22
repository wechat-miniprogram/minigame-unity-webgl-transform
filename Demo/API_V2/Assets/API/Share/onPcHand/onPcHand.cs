using WeChatWASM;
using System;
using UnityEngine;

public class onPcHand : Details
{
    private bool _isListeningHandoff = false;
    private readonly Action<Action<OnHandoffListenerResult>> _onHandoff = (callback) =>
{
    var result = new OnHandoffListenerResult
        {
            query = "key1=value2&key2=value2"
        };
        callback(result);
        Debug.Log($"return query: {result.query}");
};

    protected override void TestAPI(string[] args)
    {
        onHandoff();
    }
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, setHandoffQuery);
    }
    public void onHandoff()
    {
        if (!_isListeningHandoff)
        {
            WX.OnHandoff(_onHandoff);
        }
        else
        {
            WX.OffHandoff(_onHandoff);
        }
        _isListeningHandoff = !_isListeningHandoff;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListeningHandoff ? "取消监听在电脑上打开" : "开始监听在电脑上打开"
        );
    }
    public void setHandoffQuery()
    {
        var isSuccess = WX.SetHandoffQuery("xxx");
        WX.ShowToast(new ShowToastOption { title = isSuccess ? "true" : "false" });
    }
    private void OnDestroy()
    {
        WX.OffHandoff(_onHandoff);
    }
}
