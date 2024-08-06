using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
using UnityEngine.UI;


public class VideoDecoder : Details
{
    private WXVideoDecoder _videoDecoder;

    private readonly Action<string> _onStart = (res) =>
    {
        Debug.Log("videodecoder onStart " + JsonUtility.ToJson(res));
    };

    private readonly Action<string> _onStop = (res) =>
    {
        Debug.Log("videodecoder onStop " + JsonUtility.ToJson(res));
    };

    private readonly Action<string> _onSeek = (res) =>
    {
        Debug.Log("videodecoder onSeek " + JsonUtility.ToJson(res));
    };

    private readonly Action<string> _onBufferchange = (res) =>
    {
        Debug.Log("videodecoder onBufferchange " + JsonUtility.ToJson(res));
    };

    private readonly Action<string> _onEnded = (res) =>
    {
        // ended = true;
        Debug.Log("videodecoder onEnded " + JsonUtility.ToJson(res));
    };

    private void Start()
    {
        if (_videoDecoder == null)
        {
            _videoDecoder = WX.CreateVideoDecoder();
        }

        _videoDecoder.On("start", _onStart);
        _videoDecoder.On("stop", _onStop);
        _videoDecoder.On("seek", _onSeek);
        _videoDecoder.On("bufferchange", _onBufferchange);
        _videoDecoder.On("ended", _onEnded);


        GameManager.Instance.detailsController.BindExtraButtonAction(0, stop);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, seek);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, getFrameData);
    }

    // 开始
    protected override void TestAPI(string[] args)
    {
        _videoDecoder.Start(new VideoDecoderStartOption()
        {
            source = "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20190812/video.mp4",
            mode = 1,
            abortAudio = false,
            abortVideo = false,
        });
    }

    // 停止
    public void stop()
    {
        _videoDecoder.Stop();
    }

    public void seek()
    {
        _videoDecoder.Seek(12000);
    }

    public void getFrameData()
    {
        FrameDataOptions res = _videoDecoder.GetFrameData();
        Debug.Log(JsonMapper.ToJson(res.data));
        Debug.Log(res.pkPts);
        Debug.Log(res.pkDts);
        Debug.Log(res.width);
        Debug.Log(res.height);
    }

    private void OnDestroy()
    {
        if (_videoDecoder != null)
        {
            _videoDecoder.Off("start");
            _videoDecoder.Off("stop");
            _videoDecoder.Off("seek");
            _videoDecoder.Off("bufferchange");
            _videoDecoder.Off("ended");
            _videoDecoder.Remove();
        }
    }
}