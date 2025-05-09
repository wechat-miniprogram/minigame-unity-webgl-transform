using WeChatWASM;
using UnityEngine;

public class ShowShareImageMenu : Details
{
    private string localImagePath;
    private string tempImagePath;

    protected override void TestAPI(string[] args)
    {
        if (GetOptionString(0, "") == "本地路径")
        {
            DownloadFileImage(true);
        }
        else
        {
            DownloadFileImage(false);
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

    private void DownloadFileImage(bool saveAsLocal)
    {
        ShowLoading();
        WX.DownloadFile(new DownloadFileOption()
        {
            url = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
            success = (res) =>
            {
                Debug.Log("WX.DownloadFile success");
                if (res.statusCode == 200)
                {
                    tempImagePath = res.tempFilePath;
                    
                    if (saveAsLocal)
                    {
                        var fs = WX.GetFileSystemManager();
                        // 将临时文件保存为本地缓存文件
                        localImagePath = fs.SaveFileSync(res.tempFilePath, WX.env.USER_DATA_PATH + "/shareImage.jpg");
                        Debug.Log($"本地缓存文件保存路径: {localImagePath}");
                    }
                    else
                    {
                        Debug.Log($"临时文件路径: {tempImagePath}");
                    }
                    showShareImageMenu();
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

    public void showShareImageMenu()
    {
        string pathType = GetOptionString(0, "");
        bool needShowEntrance = GetOptionBool(1, false);
        string entrancePath = GetOptionString(2, "");

        string imagePath = pathType == "本地路径" ? localImagePath : tempImagePath;

        WX.ShowShareImageMenu(
            new ShowShareImageMenuOption
            {
                path = imagePath,
                needShowEntrance = needShowEntrance,
                entrancePath = entrancePath,
                success = (res) =>
                {
                    Debug.Log("success");
                },
                fail = (res) =>
                {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete");
                }
            }
        );
    }

    private void OnDestroy()
    {
        // 清理本地文件
        if (!string.IsNullOrEmpty(localImagePath))
        {
            var fs = WX.GetFileSystemManager();
            fs.UnlinkSync(localImagePath);
            Debug.Log("清理本地图片成功");
        }
    }
}