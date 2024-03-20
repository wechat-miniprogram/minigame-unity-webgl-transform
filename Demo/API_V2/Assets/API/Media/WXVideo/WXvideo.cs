using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class WXvideo : Details
{
    private WXVideo _video = null;
    // 测试 API
    protected override void TestAPI(string[] args)
    {
        AutoPlayVideo();
    }

    private void AutoPlayVideo()
    { 
        var systemInfo = WX.GetSystemInfoSync();
        _video = WX.CreateVideo(new WXCreateVideoParam() {
            src = "http://wxsnsdy.tc.qq.com/105/20210/snsdyvideodownload?filekey=30280201010421301f0201690402534804102ca905ce620b1241b726bc41dcff44e00204012882540400&bizid=1023&hy=SH&fileparam=302c020101042530230204136ffd93020457e3c4ff02024ef202031e8d7f02030f42400204045a320a0201000400",
            controls = false,
            showProgress = false,
            showProgressInControlMode = false,
            autoplay = true,
            showCenterPlayBtn = false,
            underGameView = false,
            x = 0,
            y = 450,
            width = ((int)systemInfo.screenWidth),
            height = 300,
        });
        _video.Play();
        _video.OnPlay(() => {
            Debug.Log("video on play");
        });
        _video.OnError(() => {
            Debug.Log("video on error");
        });
    }

    public void Destroy() {
        if (_video != null) {
            _video.Destroy();
        }
    }
}
