using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class Demo : MonoBehaviour
{
    public Button buttonGetEnterOptions;
    public Button buttonAd;
    public Button buttonPay;
    public Button buttonShare;
    public Button buttonPlayAudio;
    public Button buttonStopAudio;
    // Start is called before the first frame update
    void Start()
    {
        WX.InitSDK((code)=> {
            Debug.Log("初始化成功！");
            buttonGetEnterOptions.onClick.AddListener(() =>
            {
                var options = WX.GetEnterOptionsSync();
                Debug.Log("GetEnterOptionsSync scene:" + options.scene);
            });
            var ad = WX.CreateRewardedVideoAd(new WXCreateRewardedVideoAdParam()
            {
                adUnitId = "xxxxxxxx" //自己申请广告单元ID
            });
            ad.OnError((r)=> {
                Debug.Log("ad error:"+r.errMsg);
            });
            ad.OnClose((r)=> {
                Debug.Log("ad close:" + r.isEnded);
            });
            buttonAd.onClick.AddListener(() => {
                ad.Show();
            });
            buttonPay.onClick.AddListener(() => {
                WX.RequestMidasPayment(new RequestMidasPaymentOption() {
                    mode = "game",
                    env = 0,
                    offerId = "xxxx", //在米大师侧申请的应用 id
                    currencyType = "CNY",
                    success = (res) => {
                        Debug.Log("pay success!");
                    },
                    fail = (res) => {
                        Debug.Log("pay fail:" + res.errMsg);
                    }
                });
            });
            buttonShare.onClick.AddListener(() => {
                WX.ShareAppMessage(new ShareAppMessageOption()
                {
                    title = "分享标题xxx",
                    imageUrl = "https://inews.gtimg.com/newsapp_bt/0/12171811596_909/0",

                });
            });
            var audio = WX.CreateInnerAudioContext(new InnerAudioContextParam()
            {
                src = "Sounds/Seagull 002.wav",
                needDownload = true,
            });
            buttonPlayAudio.onClick.AddListener(()=> {
                audio.Play();
            });
            buttonStopAudio.onClick.AddListener(()=> {
                audio.Stop();
            });


        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
