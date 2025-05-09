using WeChatWASM;
using System;
using UnityEngine;

public class ShareTimeline : Details
{
    private bool _isListeningShareTimeline = false;
    private Action<Action<OnShareTimelineListenerResult>> _onShareTimelineCallback;
    private string localImagePath;

    protected override void TestAPI(string[] args)
    {
        // 如果已经在监听中，只执行切换监听的操作
        if (_isListeningShareTimeline)
        {
            onShareTimeline();
            return;
        }

        // 根据参数决定是否需要下载本地图片
        if (GetOptionString(1, "") == "本地图片文件路径")
        {
            DownloadFileImage();
        }
        else
        {
            InitializeTimelineCallback();
            onShareTimeline();
        }
    }

    private void ShowLoading()
    {
        WX.ShowLoading(new ShowLoadingOption()
        {
            title = "正在下载图片...",
            mask = true
        });
    }

    private void HideLoading()
    {
        WX.HideLoading(new HideLoadingOption());
    }

    private void DownloadFileImage()
    {
        ShowLoading();
        WX.DownloadFile(new DownloadFileOption()
        {
            url = "https://picsum.photos/400/400?random=1",
            success = (res) =>
            {
                Debug.Log("WX.DownloadFile success");
                if (res.statusCode == 200)
                {
                    Debug.Log(res.tempFilePath);
                    var fs = WX.GetFileSystemManager();
                    // 将临时文件保存为本地缓存文件
                    localImagePath = fs.SaveFileSync(res.tempFilePath, WX.env.USER_DATA_PATH + "/timelineImage.jpg");
                    Debug.Log($"本地缓存文件保存路径: {localImagePath}");
                    InitializeTimelineCallback();
                    onShareTimeline();
                }
            },
            fail = (res) =>
            {
                Debug.Log("WX.DownloadFile fail");
            },
            complete = (res) =>
            {
                Debug.Log("WX.DownloadFile complete");
                HideLoading();
            }
        });
    }

    private void InitializeTimelineCallback()
    {
        string title = GetOptionString(0, "");
        string imageUrl = GetOptionString(1, "");
        string imageUrlId = GetOptionString(2, "");
        string imagePreviewUrl = GetOptionString(3, "");
        string imagePreviewUrlId = GetOptionString(4, "");

        // 如果使用本地图片，替换为本地路径
        if (imageUrl == "本地图片文件路径")
        {
            imageUrl = localImagePath;
        }

        _onShareTimelineCallback = (callback) =>
        {
            callback(
                new OnShareTimelineListenerResult
                {
                    title = title,
                    imageUrl = imageUrl,
                    imageUrlId = imageUrlId,
                    imagePreviewUrl = imagePreviewUrl,
                    imagePreviewUrlId = imagePreviewUrlId
                }
            );
            Debug.Log($"朋友圈分享回调参数 - 标题: {title}, 图片URL: {imageUrl}, 图片ID: {imageUrlId}, 预览图URL: {imagePreviewUrl}, 预览图ID: {imagePreviewUrlId}");
        };
    }

    public void onShareTimeline()
    {
        if (!_isListeningShareTimeline)
        {
            WX.OnShareTimeline(_onShareTimelineCallback);
            Debug.Log("开始监听朋友圈分享");
            // 添加开始监听时的提示
            WX.ShowToast(new ShowToastOption()
            {
                title = "已开启朋友圈分享监听",
                icon = "none",
                duration = 1500
            });
        }
        else
        {
            WX.OffShareTimeline(_onShareTimelineCallback);
            Debug.Log("取消监听朋友圈分享");
            // 添加取消监听时的提示
            WX.ShowToast(new ShowToastOption()
            {
                title = "已取消朋友圈分享监听",
                icon = "none",
                duration = 1500
            });
        }
        _isListeningShareTimeline = !_isListeningShareTimeline;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListeningShareTimeline ? "取消监听分享到朋友圈" : "开始监听分享到朋友圈"
        );
    }

    private void OnDestroy()
    {
        if (_isListeningShareTimeline)
        {
            WX.OffShareTimeline(_onShareTimelineCallback);
            Debug.Log("清理朋友圈分享监听");
        }

        // 清理本地文件
        if (!string.IsNullOrEmpty(localImagePath))
        {
            var fs = WX.GetFileSystemManager();
            fs.UnlinkSync(localImagePath);
            Debug.Log("清理本地图片成功");
        }
    }
}