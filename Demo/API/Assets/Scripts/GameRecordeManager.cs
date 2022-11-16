using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class GameRecordeManager : MonoBehaviour
{
    private WXGameRecorder gameRecorder;

    void Start()
    {

        WX.InitSDK((code) =>
        {
            // 获取系统信息
            var systemInfo = WeChatWASM.WX.GetSystemInfoSync();

            // TODO 先判断客户端是安卓，且客户端版本大于等于8.0.28，且基础库版本大于等于2.26.1，再使用该功能

            gameRecorder = WX.GetGameRecorder();

            gameRecorder.On("timeUpdate", (res) =>
            {
                Debug.Log(res.currentTime);
            });
            gameRecorder.On("start", (res) =>
            {
                Debug.Log("gameRecorder start");
            });
            gameRecorder.On("stop", (res) =>
            {
                Debug.Log("gameRecorder stop:" + res.duration);
            });

            var canvasWith = (int)(systemInfo.screenWidth * systemInfo.pixelRatio);
            var shareButtonHeight = (int)(canvasWith / 1080f * 120f);
            // 分享接口必须在touchEnd里触发
            WX.OnTouchEnd((res) =>
            {
                // 判断 pageX 和 pageY 的位置是否在分享按钮的位置
                if (res.changedTouches[0].pageY < shareButtonHeight)
                {
                    this.ShareRecorder();
                }
            });
        });
    }

    public void StartRecorder()
    {
        gameRecorder.Start(new GameRecorderStartOption()
        {
            hookBgm = false,
        });
    }

    public void StopRecorder()
    {
        gameRecorder.Stop();
    }

    public void PauseRecorder()
    {
        gameRecorder.Pause();
    }

    public void ResumeRecorder()
    {
        gameRecorder.Resume();
    }

    public void ShareRecorder()
    {
        WX.OperateGameRecorderVideo(new operateGameRecorderOption()
        {
            title = "游戏标题",
            desc = "游戏简介",
            timeRange = new int[][] {
              new int[] { 0, 2000 },
              new int[] { 5000, 8000 },
            },
            query = "test=123456",
        });
    }

    public void offEvent()
    {
        gameRecorder.Off("timeUpdate");
        gameRecorder.Off("start");
        gameRecorder.Off("stop");
    }
}