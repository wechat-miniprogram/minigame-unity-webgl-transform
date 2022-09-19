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
        WX.InitSDK((code) =>
        {

            // 打印屏幕信息
            var systemInfo = WeChatWASM.WX.GetSystemInfoSync();
            Debug.Log($"{systemInfo.screenWidth}:{systemInfo.screenHeight}, {systemInfo.windowWidth}:{systemInfo.windowHeight}, {systemInfo.pixelRatio}");

            // 预先创建广告实例
            Debug.Log("初始化成功！");
            ad = WX.CreateRewardedVideoAd(new WXCreateRewardedVideoAdParam()
            {
                adUnitId = "xxxxxxxx" //自己申请广告单元ID
            });
            ad.OnError((r) =>
            {
                Debug.Log("ad error:" + r.errMsg);
            });
            ad.OnClose((r) =>
            {
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
            success = (res) =>
            {
                Debug.Log("pay success!");
            },
            fail = (res) =>
            {
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

    public void OnFileSystemManagerClick()
    {
        // 扫描文件系统目录
        fs.Stat(new WXStatOption
        {
            path = env.USER_DATA_PATH + "/__GAME_FILE_CACHE",
            recursive = true,
            success = (succ) =>
            {
                Debug.Log($"stat success");
                foreach (var file in succ.stats)
                {
                    Debug.Log($"stat info. {file.path}, " +
                        $"{file.stats.size}，" +
                        $"{file.stats.mode}，" +
                        $"{file.stats.lastAccessedTime}，" +
                        $"{file.stats.lastModifiedTime}");
                }
            },
            fail = (fail) =>
            {
                Debug.Log($"stat fail {fail.errMsg}");
            }
        });

        // 同步接口创建目录（请勿在游戏过程中频繁调用同步接口）
        var errMsg = fs.MkdirSync(env.USER_DATA_PATH + "/mydir", true);

        // 异步写入文件
        fs.WriteFile(new WriteFileParam
        {
            filePath = env.USER_DATA_PATH + "/mydir/myfile.txt",
            encoding = "utf8",
            data = System.Text.Encoding.UTF8.GetBytes("Test FileSystemManager"),
            success = (succ) =>
            {
                Debug.Log($"WriteFile succ {succ.errMsg}");
                 // 异步读取文件
                fs.ReadFile(new ReadFileParam
                {
                    filePath = env.USER_DATA_PATH + "/mydir/myfile.txt",
                    encoding = "utf8",
                    success = (succ) =>
                    {
                        Debug.Log($"ReadFile succ. stringData(utf8):{succ.stringData}");
                    },
                    fail = (fail) =>
                    {
                        Debug.Log($"ReadFile fail {fail.errMsg}");
                    }
                });

                // 异步以无编码(二进制)方式读取
                fs.ReadFile(new ReadFileParam
                {
                    filePath = env.USER_DATA_PATH + "/mydir/myfile.txt",
                    encoding = "",
                    success = (succ) =>
                    {
                        Debug.Log($"ReadFile succ. data(binary):{succ.binData.Length}, stringData(utf8):{System.Text.Encoding.UTF8.GetString(succ.binData)}");
                    },
                    fail = (fail) =>
                    {
                        Debug.Log($"ReadFile fail {fail.errMsg}");
                    }
                });

            },
            fail = (fail) =>
            {
                Debug.Log($"WriteFile fail {fail.errMsg}");
            },
            complete = null
        });
    }

    public void OnPlayerPrefClick()
    {
        // 注意！！！ PlayerPrefs为同步接口，iOS高性能模式下为"跨进程"同步调用，会阻塞游戏线程，请避免频繁调用
        PlayerPrefs.SetString("mystringkey", "myestringvalue");
        PlayerPrefs.SetInt("myintkey", 123);
        PlayerPrefs.SetFloat("myfloatkey", 1.23f);

        Debug.Log($"PlayerPrefs mystringkey:{ PlayerPrefs.GetString("mystringkey")}");
        Debug.Log($"PlayerPrefs myintkey:{ PlayerPrefs.GetInt("myintkey")}");
        Debug.Log($"PlayerPrefs myfloatkey:{ PlayerPrefs.GetFloat("myfloatkey")}"); 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
