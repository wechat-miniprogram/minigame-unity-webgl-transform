using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class InnerAudio : Details
{
    protected override void TestAPI(string[] args)
    {
        var music = WX.CreateInnerAudioContext(new InnerAudioContextParam() {
           src = "https://res.wx.qq.com/wechatgame/product/webpack/userupload/20220901/211827/CallMeTeenTop.mp3",
           needDownload = true //表示等下载完之后再播放，便于后续复用，无延迟
        });
        music.OnCanplay(() =>
        {
           Debug.Log("OnCanplay");
           music.Play();
        });
    }

}
