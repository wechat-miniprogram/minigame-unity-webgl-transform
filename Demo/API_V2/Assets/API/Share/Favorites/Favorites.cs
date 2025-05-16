using WeChatWASM;
using System;
using UnityEngine;

public class Favorites : Details
{
    private bool _isListeningAddToFavorites = false;
    private Action<Action<OnAddToFavoritesListenerResult>> _onAddToFavorites;
    private string localImagePath;

    protected override void TestAPI(string[] args)
    {
        // 如果已经在监听中，只执行切换监听的操作，避免重复下载
        if (_isListeningAddToFavorites)
        {
            onAddToFavorites();
            return;
        }

        // 根据对应参数，执行DownloadFileImage()下载图片
        if (GetOptionString(1, "") == "本地图片文件路径")
        {
            DownloadFileImage();
        }
        else
        {
            InitializeFavoritesCallback();
            onAddToFavorites();
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
                    localImagePath = fs.SaveFileSync(res.tempFilePath, WX.env.USER_DATA_PATH + "/favoriteImage.jpg");
                    Debug.Log($"本地缓存文件保存路径: {localImagePath}");
                    InitializeFavoritesCallback();
                    onAddToFavorites();
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

    //设置收藏回调函数
    private void InitializeFavoritesCallback()
    {
        string title = GetOptionString(0, "");
        string imageUrl = GetOptionString(1, "");
        bool disableForward = !GetOptionBool(2, false);
        string query = GetOptionString(3, "");

        if (imageUrl == "本地图片文件路径")
        {
            imageUrl = localImagePath;
        }

        _onAddToFavorites = (callback) =>
        {
            callback(
                new OnAddToFavoritesListenerResult
                {
                    title = title,
                    imageUrl = imageUrl,
                    disableForward = disableForward,
                    query = query
                }
            );
            Debug.Log($"收藏回调参数 - 标题: {title}, 图片URL: {imageUrl}, 禁止转发: {disableForward}, Query: {query}");
        };
    }

    //切换收藏监听状态
    public void onAddToFavorites()
    {
        if (!_isListeningAddToFavorites)
        {
            WX.OnAddToFavorites(_onAddToFavorites);
            Debug.Log("开始监听收藏");
            // 添加开始监听时的提示
            WX.ShowToast(new ShowToastOption()
            {
                title = "已开启收藏监听",
                icon = "none",
                duration = 1500
            });
        }
        else
        {
            WX.OffAddToFavorites(_onAddToFavorites);
            Debug.Log("取消监听收藏");
            // 添加取消监听时的提示
            WX.ShowToast(new ShowToastOption()
            {
                title = "已取消收藏监听",
                icon = "none",
                duration = 1500
            });
        }
        _isListeningAddToFavorites = !_isListeningAddToFavorites;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListeningAddToFavorites ? "取消监听收藏" : "开始监听收藏"
        );
    }

    private void OnDestroy()
    {
        if (_isListeningAddToFavorites)
        {
            WX.OffAddToFavorites(_onAddToFavorites);
            Debug.Log("清理收藏监听");
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