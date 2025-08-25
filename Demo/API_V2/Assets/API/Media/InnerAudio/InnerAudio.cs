using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class InnerAudio : Details
{
    WXInnerAudioContext music;
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, pause);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, stop);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, seek);
    }

    protected override void TestAPI(string[] args)
    {
        music = WX.CreateInnerAudioContext(new InnerAudioContextParam() {
           src = "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211827/CallMeTeenTop.mp3",
           needDownload = true //表示等下载完之后再播放，便于后续复用，无延迟
        });
        music.OnCanplay(() =>
        {
           Debug.Log("OnCanplay");
           music.Play();
        });
    }


    //暂停
    public void pause()
    {
         Debug.Log("pause");
         music.Pause();
    }

    //停止
    public void stop()
    {
        Debug.Log("stop");
        music.Stop();

    }

    //跳转
    public void seek()
    {

        Debug.Log("seek");
        music.Seek(3);
    }

    private void OnDestroy()
    {
        Debug.Log("音频示例 OnDestroy");
        music.Stop();
        music.Destroy();
    }
}
