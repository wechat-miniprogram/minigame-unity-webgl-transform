using System;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Video : Details
{
    private WXVideo _video;

    private readonly Action _onEnded = () =>
    {
        const string result = "【Video】OnEnded";
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };
    private readonly Action<WXVideoError> _onError = (res) =>
    {
        var result = "【Video】OnError: " + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };
    private readonly Action _onPause = () =>
    {
        const string result = "【Video】OnPause";
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };
    private readonly Action _onPlay = () =>
    {
        const string result = "【Video】OnPlay";
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };
    private readonly Action<WXVideoProgress> _onProgress = (res) =>
    {
        var result = "【Video】OnProgress: " + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };
    private readonly Action<WXVideoTimeUpdate> _onTimeUpdate = (res) =>
    {
        var result = "【Video】OnTimeUpdate: " + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };
    private readonly Action _onWaiting = () =>
    {
        const string result = "【Video】OnWaiting";
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ChangeMuteState);
    }

    // 创建视频
    protected override void TestAPI(string[] args)
    {
        if (_video != null)
        {
            _video.Destroy();
        }
        var createVideoOption = new CreateVideoOption()
        {
            x = GetOptionValue<double>(0),
            y = GetOptionValue<double>(1),
            width = GetOptionValue<double>(2),
            height = GetOptionValue<double>(3),
            src = args[4] == "示例视频" ? "http://wxsnsdy.tc.qq.com/105/20210/snsdyvideodownload?filekey=30280201010421301f0201690402534804102ca905ce620b1241b726bc41dcff44e00204012882540400&bizid=1023&hy=SH&fileparam=302c020101042530230204136ffd93020457e3c4ff02024ef202031e8d7f02030f42400204045a320a0201000400" : "",
            poster = args[5] == "示例封面" ? "https://mmgame.qpic.cn/image/b4e70a6cba5ccad456667d85c3c0ea3c02e4f879a9705ed75071595a3e9f4ca0/0" : "",
            initialTime = GetOptionValue<double>(6),
            playbackRate = GetOptionValue<double>(7),
            live = GetOptionValue<bool>(8),
            objectFit = GetOptionString(9),
            controls = GetOptionValue<bool>(10),
            showProgress = GetOptionValue<bool>(11),
            showProgressInControlMode = GetOptionValue<bool>(12),
            backgroundColor = GetOptionString(13),
            autoplay = GetOptionValue<bool>(14),
            loop = GetOptionValue<bool>(15),
            muted = GetOptionValue<bool>(16),
            obeyMuteSwitch = GetOptionValue<bool>(17),
            enableProgressGesture = GetOptionValue<bool>(18),
            enablePlayGesture = GetOptionValue<bool>(19),
            showCenterPlayBtn = GetOptionValue<bool>(20),
            underGameView = GetOptionValue<bool>(21),
            autoPauseIfNavigate = GetOptionValue<bool>(22),
            autoPauseIfOpenNative = GetOptionValue<bool>(23),
        };
        _video = WX.CreateVideo(createVideoOption);
        _video.OnEnded(_onEnded);
        _video.OnError(_onError);
        _video.OnPause(_onPause);
        _video.OnPlay(_onPlay);
        _video.OnProgress(_onProgress);
        _video.OnTimeUpdate(_onTimeUpdate);
        _video.OnWaiting(_onWaiting);
    }

    private void ChangeMuteState()
    {
        if (_video == null)
        {
            WX.ShowModal(new ShowModalOption() { content = "请先创建视频" });
            return;
        }

        // 确保 muted 属性存在
        _video.muted ??= false;

        _video.muted = !_video.muted.Value;
        GameManager.Instance.detailsController.ChangeExtraButtonText(0, _video.muted.Value ? "取消静音" : "静音");
        var result = "【Video】Mute state changed: " + _video.muted.Value;
        WX.ShowModal(new ShowModalOption() { content = result });
    }

    private void OnDestroy()
    {
        if (_video != null)
        {
            _video.Destroy();
        }
    }
}
