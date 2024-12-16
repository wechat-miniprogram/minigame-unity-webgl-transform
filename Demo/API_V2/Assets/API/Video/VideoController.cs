using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using WeChatWASM;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // 关联 VideoPlayer 组件
    public Button playButton; // 关联播放按钮
    public Button pauseButton; // 关联暂停按钮
    public string[] videoUrls; // 视频路径
    private int currentVideoIndex = 0;

    void Start()
    {
        // 设置视频路径
        videoPlayer.url = videoUrls[currentVideoIndex];

        // 添加按钮点击事件
        playButton.onClick.AddListener(PlayVideo);
        pauseButton.onClick.AddListener(PauseVideo);

        // 添加视频播放完成事件
        videoPlayer.loopPointReached += OnVideoEnd;
        
    }

    void PlayVideo()
    {
        if (videoPlayer.isPaused)
        {
            videoPlayer.Play(); // 如果视频已暂停，则继续播放
        }
    }

    void PauseVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause(); // 暂停视频
        }
    }

    // 视频播放完成时调用的方法
    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("视频播放完成");

        // 增加当前视频索引
        currentVideoIndex++;

        // 检查是否还有下一个视频
        if (currentVideoIndex < videoUrls.Length)
        {
            videoPlayer.url = videoUrls[currentVideoIndex]; // 设置下一个视频的 URL
        }
        else
        {
            currentVideoIndex = 0; // 如果没有下一个视频，重置索引（可选）
        }
        videoPlayer.url = videoUrls[currentVideoIndex];
        videoPlayer.Play(); // 播放下一个视频
    }
}
