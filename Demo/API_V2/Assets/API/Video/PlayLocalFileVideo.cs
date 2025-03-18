using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;
using WeChatWASM;

public class PlayLocalFileVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private string localVideoPath;
    
    private void Awake()
    {
        // 获取或添加VideoPlayer组件
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer == null)
        {
            videoPlayer = gameObject.AddComponent<VideoPlayer>();
        }
        
        // 配置VideoPlayer
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = false;
        
        // 设置本地视频路径
        localVideoPath = WX.env.USER_DATA_PATH + "/video.mp4";
    }

    private void CheckAndPlayVideo()
    {
        // 获取文件系统管理器
        var fs = WX.GetFileSystemManager();
        
        // 使用微信文件系统的方法检查文件是否存在
        fs.Access(new AccessParam()
        {
            path = localVideoPath,
            success = (res) => 
            {
                Debug.Log("本地视频文件已存在，直接播放");
                // 文件存在，直接播放
                LoadAndPlayVideo(localVideoPath);
            },
            fail = (res) => 
            {
                Debug.Log("本地视频文件不存在，需要下载: " + res.errMsg);
                // 文件不存在，需要下载
                DownloadFileVideo();
            }
        });
    }

    private void DownloadFileVideo()
    {
        WX.ShowLoading(new ShowLoadingOption()
        {
            title = "视频下载中...",
            mask = true,
            success = (res) =>
            {
                Debug.Log("Loading indicator shown successfully");
            },
            fail = (res) =>
            {
                Debug.Log("Failed to show loading indicator: " + res.errMsg);
            },
        });
        
        WX.DownloadFile(new DownloadFileOption()
        {
            url = "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20190812/video.mp4",
            success = (res) =>
            {
                Debug.Log("WX.DownloadFile success");
                if (res.statusCode == 200)
                {
                    Debug.Log(res.tempFilePath);
                    var fs = WX.GetFileSystemManager();
                    var filePath = fs.SaveFileSync(res.tempFilePath, localVideoPath);
                    LoadAndPlayVideo(filePath);
                }
            },
            fail = (res) =>
            {
                Debug.Log("WX.DownloadFile fail: " + res.errMsg);
                HideLoadingIndicator();
            },
            complete = (res) =>
            {
                Debug.Log("WX.DownloadFile complete");
                HideLoadingIndicator();
            }
        });
    }
    
    // 隐藏加载提示的方法
    private void HideLoadingIndicator()
    {
        WX.HideLoading(new HideLoadingOption()
        {
            success = (res) =>
            {
                Debug.Log("Loading indicator hidden successfully");
            },
            fail = (res) =>
            {
                Debug.LogError("Failed to hide loading indicator: " + res.errMsg);
            }
        });
    }

    void LoadAndPlayVideo(string localFilePath)
    {
        // 设置视频文件路径
        videoPlayer.url = localFilePath;
        
        // 准备和播放视频
        videoPlayer.prepareCompleted += PrepareCompleted;
        videoPlayer.Prepare();
    }
    
    void PrepareCompleted(VideoPlayer vp)
    {
        Debug.Log("Video prepared, starting playback");
        vp.Play();
    }
    
    private void CleanupVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.url = string.Empty;
        }
    }
    
    private void Start()
    {
        // 检查本地是否有文件，如果没有则下载
        CheckAndPlayVideo();
    }

    private void OnDestroy()
    {
        CleanupVideo();
    }
}