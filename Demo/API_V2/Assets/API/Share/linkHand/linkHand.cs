using WeChatWASM;
using System;

public class linkHand : Details
{
    private bool _isListeningCopyUrl = false;
    private readonly Action<Action<OnCopyUrlListenerResult>> _onCopyUrl = (callback) =>
    {
        callback(new OnCopyUrlListenerResult { query = "xx" });
    };

    protected override void TestAPI(string[] args)
    {
        onCopyUrl();
    }
    public void onCopyUrl()
    {
        if (!_isListeningCopyUrl)
        {
            WX.OnCopyUrl(_onCopyUrl);
        }
        else
        {
            WX.OffCopyUrl(_onCopyUrl);
        }
        _isListeningCopyUrl = !_isListeningCopyUrl;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListeningCopyUrl ? "取消监听复制链接" : "开始监听复制链接"
        );
    }
    private void OnDestroy()
    {
        WX.OffCopyUrl(_onCopyUrl);
    }
}