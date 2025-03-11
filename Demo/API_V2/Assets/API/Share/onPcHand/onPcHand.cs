using WeChatWASM;
using System;

public class onPcHand : Details
{
    private bool _isListeningHandoff = false;
    private readonly Action<Action<OnHandoffListenerResult>> _onHandoff = (callback) =>
{
    callback(new OnHandoffListenerResult { query = "xxxx" });
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
