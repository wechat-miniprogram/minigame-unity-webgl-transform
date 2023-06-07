using UnityEngine;
using WeChatWASM;

public class GameRecordeManager : MonoBehaviour
{
    private static WXGameRecorder GameRecorder;

    void Start()
    {
        WX.InitSDK((code) =>
        {
            if (GameRecorder != null)
            {
                // 已创建
                Debug.Log("已创建");
                return;
            }
            // 获取系统信息
            var systemInfo = WX.GetSystemInfoSync();

            // 先判断客户端版本大于等于8.0.30，且基础库版本大于等于2.26.1，再使用该功能
            // 该功能无法在IOS高性能模式使用
            // 该功能无法在开发者工具使用
            // GameRecorder是全局唯一的
            GameRecorder = WX.GetGameRecorder();

            GameRecorder.On("timeUpdate", (res) =>
            {
                Debug.Log(res.currentTime);
            });
            GameRecorder.On("start", (res) =>
            {
                Debug.Log("GameRecorder start");
            });
            GameRecorder.On("pause", (res) =>
            {
                Debug.Log("GameRecorder pause");
            });
            GameRecorder.On("resume", (res) =>
            {
                // IOS客户端resume事件有问题
                Debug.Log("GameRecorder resume");
            });
            GameRecorder.On("stop", (res) =>
            {
                Debug.Log("GameRecorder stop:" + res.duration);
            });
            GameRecorder.On("error", (res) =>
            {
                Debug.Log("GameRecorder error:" + JsonUtility.ToJson(res));
            });

            var canvasWith = (int)(systemInfo.screenWidth * systemInfo.pixelRatio);
            var shareButtonHeight = (int)(canvasWith / 1080f * 120f);
            // 分享接口必须在touchEnd里触发
            WX.OnTouchEnd((res) =>
            {
                // 判断 pageX 和 pageY 的位置是否在分享按钮的位置
                if (res.changedTouches[0].pageY < shareButtonHeight)
                {
                    ShareRecorder();
                }
            });
        });
    }

    public void StartRecorder()
    {
        GameRecorder.Start(new GameRecorderStartOption()
        {
            hookBgm = false,
        });
    }

    public void StopRecorder()
    {
        GameRecorder.Stop();
    }

    public void PauseRecorder()
    {
        GameRecorder.Pause();
    }

    public void ResumeRecorder()
    {
        GameRecorder.Resume();
    }

    public void ShareRecorder()
    {
        WX.OperateGameRecorderVideo(new OperateGameRecorderVideoOption()
        {
            title = "游戏标题",
            desc = "游戏简介",
            timeRange = new double[][] {
              new double[] { 0, 2000 },
              new double[] { 5000, 8000 },
            },
            query = "test=123456",
        });
    }

    public void offEvent()
    {
        GameRecorder.Off("timeUpdate");
        GameRecorder.Off("start");
        GameRecorder.Off("stop");
        GameRecorder.Off("pause");
        GameRecorder.Off("resume");
    }

    private void OnDestroy()
    {
        GameRecorder.Stop();
    }
}