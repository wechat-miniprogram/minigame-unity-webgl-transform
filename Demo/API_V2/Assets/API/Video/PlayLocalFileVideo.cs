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
    }

    private void DownloadFileVideo()
    {
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
                    var filePath = fs.SaveFileSync(res.tempFilePath, WX.env.USER_DATA_PATH + "/video.mp4");
                    LoadAndPlayVideo(filePath);
                }
            },
            fail = (res) =>
            {
                Debug.Log("WX.DownloadFile fail");
            },
            complete = (res) =>
            {
                Debug.Log("WX.DownloadFile complete");
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
        DownloadFileVideo();
    }

    private void OnDestroy()
    {
        CleanupVideo();
    }
}