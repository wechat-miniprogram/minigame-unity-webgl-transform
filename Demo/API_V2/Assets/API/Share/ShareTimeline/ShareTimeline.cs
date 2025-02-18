using WeChatWASM;
using System;


public class ShareTimeline : Details
{
    protected override void TestAPI(string[] args)
    {
        onShareTimeline();
    }

    private bool _isListeningShareTimeline = false;
    private readonly Action<Action<OnShareTimelineListenerResult>> _onShareTimelineCallback = (
        callback
    ) =>
    {
        callback(
            new OnShareTimelineListenerResult
            {
                imageUrl = "xxx",
                imagePreviewUrl = "yy",
                imagePreviewUrlId = "xx",
                imageUrlId = "xxx",
                path = "xx",
                query = "xx",
                title = "test",
            }
        );
    };
    public void onShareTimeline()
    {
        if (!_isListeningShareTimeline)
        {
            WX.OnShareTimeline(_onShareTimelineCallback);
        }
        else
        {
            WX.OffShareTimeline(_onShareTimelineCallback);
        }
        _isListeningShareTimeline = !_isListeningShareTimeline;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListeningShareTimeline ? "取消监听分享到朋友圈" : "开始监听分享到朋友圈"
        );
    }
    private void OnDestroy()
    {
        WX.OffShareTimeline(_onShareTimelineCallback);
    }
}
