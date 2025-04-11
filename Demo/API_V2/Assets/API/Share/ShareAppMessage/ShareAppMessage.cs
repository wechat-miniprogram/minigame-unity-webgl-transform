using UnityEngine;
using WeChatWASM;

public class ShareAppMessage : Details
{
    private string localImagePath;
    protected override void TestAPI(string[] args)
    {
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
            url = "https://picsum.photos/400/400?random=1",
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
            toCurrentGroup = toCurrentGroupValue
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
    }
}