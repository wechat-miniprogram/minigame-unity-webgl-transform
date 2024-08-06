using UnityEngine;
using WeChatWASM;

public class GameRecorder : Details
{
    private static WXGameRecorder _gameRecorder;

    void Start()
    {
        // 先判断客户端版本大于等于8.0.30，且基础库版本大于等于2.26.1，再使用该功能
        // 该功能无法在IOS高性能模式使用
        // 该功能无法在开发者工具使用
        // GameRecorder是全局唯一的
        if (_gameRecorder == null)
        {
            _gameRecorder = WX.GetGameRecorder();
        }

        _gameRecorder.On("timeUpdate", (res) =>
        {
            Debug.Log(res.currentTime);
        });
        _gameRecorder.On("start", (res) =>
        {
            Debug.Log("GameRecorder start");
        });

        _gameRecorder.On("pause", (res) =>
        {
            Debug.Log("GameRecorder pause");
        });
        _gameRecorder.On("resume", (res) =>
        {
            // IOS客户端resume事件有问题
            Debug.Log("GameRecorder resume");
        });
        _gameRecorder.On("stop", (res) =>
        {
            Debug.Log("GameRecorder stop:" + res.duration);
        });
        _gameRecorder.On("error", (res) =>
        {
            Debug.Log("GameRecorder error:" + JsonUtility.ToJson(res));
        });

        GameManager.Instance.detailsController.BindExtraButtonAction(0, PauseRecorder);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, ResumeRecorder);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, StopRecorder);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, ShareRecorder);
    }

    // 开始
    protected override void TestAPI(string[] args)
    {
        _gameRecorder.Start(new GameRecorderStartOption()
        {
            // hookBgm = false,
        });
    }

    // 暂停
    private void PauseRecorder()
    {
        _gameRecorder.Pause();
    }

    // 恢复
    private void ResumeRecorder()
    {
        _gameRecorder.Resume();
    }

    // 停止
    private void StopRecorder()
    {
        _gameRecorder.Stop();
    }

    // 分享
    private void ShareRecorder()
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

    public void OffEvent()
    {
        _gameRecorder.Off("timeUpdate");
        _gameRecorder.Off("start");
        _gameRecorder.Off("stop");
        _gameRecorder.Off("pause");
        _gameRecorder.Off("resume");
    }

    public void Destroy()
    {
        OffEvent();
        _gameRecorder.Stop();
    }
}