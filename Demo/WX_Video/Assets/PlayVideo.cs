using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class PlayVideo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        this.AutoPlayVideo();
    }

    private void AutoPlayVideo()
    {
        WX.InitSDK((int code) => {
            var systemInfo = WX.GetSystemInfoSync();
            var video = WX.CreateVideo(new WXCreateVideoParam() {
                src = "http://wxsnsdy.tc.qq.com/105/20210/snsdyvideodownload?filekey=30280201010421301f0201690402534804102ca905ce620b1241b726bc41dcff44e00204012882540400&bizid=1023&hy=SH&fileparam=302c020101042530230204136ffd93020457e3c4ff02024ef202031e8d7f02030f42400204045a320a0201000400",
                controls = false,
                showProgress = false,
                showProgressInControlMode = false,
                autoplay = true,
                showCenterPlayBtn = false,
                underGameView = true,
                width = ((int)systemInfo.screenWidth),
                height = ((int)systemInfo.screenHeight),
            });
            video.OnPlay(() => {
                Debug.Log("video on play");
            });
            video.OnError(() => {
                Debug.Log("video on error");
            });
        });
    }

    private void OnClick()
    {
        Debug.Log("click");
    }
}
