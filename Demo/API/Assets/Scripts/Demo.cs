using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class Demo : MonoBehaviour
{
    public WXRewardedVideoAd ad;
    public WXInnerAudioContext inneraudio;
    public Text txtUserInfo;
    public WXFileSystemManager fs = new WXFileSystemManager();
    public WeChatWASM.WXEnv env = new WXEnv();
    // Start is called before the first frame update
    void Start()
    {
        WX.InitSDK((code)=> {

            // 打印屏幕信息
            var systemInfo = WeChatWASM.WX.GetSystemInfoSync();
            Debug.Log($"{systemInfo.screenWidth}:{systemInfo.screenHeight}, {systemInfo.windowWidth}:{systemInfo.windowHeight}, {systemInfo.pixelRatio}");

            // 获取文件系统
            var statOption = new WXStatOption();
            statOption.path = env.USER_DATA_PATH + "/__GAME_FILE_CACHE";
            statOption.recursive = true;
            statOption.success = (succ) => {
                Debug.Log($"stat success");
                foreach(var file in succ.stats)
                {
                    Debug.Log($"stat info. {file.path}, " +
                        $"{file.stats.size}，" +
                        $"{file.stats.mode}，" +
                        $"{file.stats.lastAccessedTime}，" +
                        $"{file.stats.lastModifiedTime}");
                }
            };
            statOption.complete = (complete) => {
                Debug.Log($"stat complete");
            };
            statOption.fail = (fail) => {
                Debug.Log($"stat fail {fail.errMsg}");
            };
            Debug.Log($"stat invoke. Path:{statOption.path}");
            fs.Stat(statOption);


            // 预先创建广告实例
            Debug.Log("初始化成功！");
            ad = WX.CreateRewardedVideoAd(new WXCreateRewardedVideoAdParam()
            {
                adUnitId = "xxxxxxxx" //自己申请广告单元ID
            });
            ad.OnError((r)=> {
                Debug.Log("ad error:"+r.errMsg);
            });
            ad.OnClose((r)=> {
                Debug.Log("ad close:" + r.isEnded);
            });

            // 创建用户信息获取按钮，在底部1/3区域创建一个透明区域
            // 首次获取会弹出用户授权窗口, 可通过右上角-设置-权限管理用户的授权记录
            var canvasWith = (int)(systemInfo.screenWidth * systemInfo.pixelRatio);
            var canvasHeight = (int)(systemInfo.screenHeight * systemInfo.pixelRatio);
            var button = WX.CreateUserInfoButton(0, canvasHeight * 2 / 3, canvasWith, canvasHeight / 3, "zh_CN", false);
            button.OnTap((userInfoButonRet) =>
            {
                txtUserInfo.text = $"nickName：{userInfoButonRet.userInfo.nickName}， avartar:{userInfoButonRet.userInfo.avatarUrl}";
            });

        });

    }

    public void OnEnterOptionsClick()
    {
        var options = WX.GetEnterOptionsSync();
        Debug.Log("GetEnterOptionsSync scene:" + options.scene);
    }

    public void OnAdClick()
    {
        ad.Show();
    }

    public void OnShareClick()
    {
        WX.ShareAppMessage(new ShareAppMessageOption()
        {
            title = "分享标题xxx",
            imageUrl = "https://inews.gtimg.com/newsapp_bt/0/12171811596_909/0",

        });
    }

    public void OnPayClick()
    {
        WX.RequestMidasPayment(new RequestMidasPaymentOption()
        {
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
    }


    public void OnPlayInnerAudio()
    {
        inneraudio = WX.CreateInnerAudioContext(new InnerAudioContextParam()
        {
            src = "Sounds/Seagull 002.wav",
            needDownload = true,
        });
        inneraudio.OnEnded(() =>
        {
            Debug.Log("OnEnded called, play again");
            inneraudio.Play();
        });
        inneraudio.OnCanplay(() =>
        {
            Debug.Log("OnCanplay called");
            inneraudio.Play();
        }); 
    } 

    public void OnStopInnerAudio()
    {
        inneraudio.Stop();
    }

    public void OnReportEventClick()
    {
        Dictionary<string, int> videoReport = new Dictionary<string, int>();
        videoReport.Add("video_maidian", 1);
        Debug.Log("video maidian 1");
        WX.ReportEvent("exptnormal", videoReport);
    }

    public void OnCreateUserInfoButton()
    {
        //var opt = new GetSettingOption();
        //opt.complete = (ret) => {
        //    Debug.Log("OnGetUserInfo complete");
        //};
        //opt.fail = (ret) => {
        //    Debug.Log("OnGetUserInfo fail");
        //};
        //opt.success = (ret) => {
        //    Debug.Log("OnGetUserInfo succ");
        //    foreach(var autoSetting in ret.authSetting)
        //    {
        //        Debug.Log($"autoSetting {autoSetting.Key}, {autoSetting.Value}");
        //    }
        //    if(!ret.authSetting.ContainsKey("wx.getUserInfo"))
        //    {

        //    }
            
        //};
        //WeChatWASM.WX.GetSetting(opt);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
