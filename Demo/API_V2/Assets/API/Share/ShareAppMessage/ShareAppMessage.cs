using UnityEngine;
using WeChatWASM;
using System;
using LitJson;

public class ShareAppMessage : Details
{
    private bool _isListening = false;

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

    private string localImagePath;
    protected override void TestAPI(string[] args)
    {
        if (!_isListening)
        {
            WX.OnShow(_onShow);
            WX.OnHide(_onHide);
        }
        else
        {
            WX.OffShow(_onShow);
            WX.OffHide(_onHide);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListening ? "取消监听" : "开始监听"
        );
        if (GetOptionString(1, "") == "本地图片文件路径")
        {
            DownloadFileImage();
        }
        else
        {
            shareAppMessage();
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
            url = "https://mmgame.qpic.cn/image/b941692c4de1a46c180c84569cc24c20389bf176794048becdf2421e61483fd0/0",
            success = (res) =>
            {
                Debug.Log("WX.DownloadFile success");
                if (res.statusCode == 200)
                {
                    Debug.Log(res.tempFilePath);
                    var fs = WX.GetFileSystemManager();
                    // 将临时文件保存为本地缓存文件
                    localImagePath = fs.SaveFileSync(res.tempFilePath, WX.env.USER_DATA_PATH + "/shareImage.jpg");
                    Debug.Log($"本地缓存文件保存路径: {localImagePath}");
                    shareAppMessage();
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


    private void shareAppMessage()
    {
        string title = GetOptionString(0, "");
        string imageUrl = GetOptionString(1, "");
        string imageUrlId = GetOptionString(2, "");
        bool toCurrentGroupValue = GetOptionBool(3, true);
        string query = GetOptionString(4, "");

        //SO里面的配置参数
        string contentText = $"分享参数信息：\n" +
                        $"标题：{title}\n" +
                        $"图片URL：{imageUrl}\n" +
                        $"图片ID：{imageUrlId}\n" +
                        $"是否分享到当前群：{toCurrentGroupValue}\n" +
                        $"分享参数：{query}";

        // 如果选择了本地图片文件路径，使用下载保存到本地的文件路径
        if (imageUrl == "本地图片文件路径")
        {
            imageUrl = localImagePath;
        }

        WX.ShareAppMessage(new ShareAppMessageOption()
        {
            title = title,
            imageUrl = imageUrl,
            imageUrlId = imageUrlId,
            toCurrentGroup = toCurrentGroupValue,
            query = query,
        });

        WX.ShowModal(new ShowModalOption()
        {
            title = "分享成功",
            content = contentText,
            showCancel = false,
            confirmText = "好的",
            success = (res) =>
            {
                Debug.Log("分享成功");
            },
            fail = (res) =>
            {
                Debug.Log("分享失败");
            }
        });
    }

    private void OnDestroy()
    {
        // 清理文件
        if (!string.IsNullOrEmpty(localImagePath))
        {
            var fs = WX.GetFileSystemManager();
            fs.UnlinkSync(localImagePath);
            Debug.Log("清理本地图片成功");
        }
        WX.OffShow(_onShow);
        WX.OffHide(_onHide);
    }
}