using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class Demo : MonoBehaviour
{
    public Text txtUserInfo;
    public Text txtTestWXFont;
    public WXFileSystemManager fs = new WXFileSystemManager();
    public WeChatWASM.WXEnv env = new WXEnv();
    private WXUserInfoButton infoButton;

    void Start()
    {
        WX.InitSDK((code) =>
        {
            // 打印屏幕信息
            var systemInfo = WX.GetSystemInfoSync();
            Debug.Log($"{systemInfo.screenWidth}:{systemInfo.screenHeight}, {systemInfo.windowWidth}:{systemInfo.windowHeight}, {systemInfo.pixelRatio}");

            // 创建用户信息获取按钮，在底部区域创建一个300高度的透明区域
            // 首次获取会弹出用户授权窗口, 可通过右上角-设置-权限管理用户的授权记录
            var canvasWith = (int)(systemInfo.screenWidth * systemInfo.pixelRatio);
            var canvasHeight = (int)(systemInfo.screenHeight * systemInfo.pixelRatio);
            var buttonHeight = (int)(canvasWith / 1080f * 300f);
            infoButton = WX.CreateUserInfoButton(0, canvasHeight - buttonHeight, canvasWith, buttonHeight, "zh_CN", false);
            infoButton.OnTap((userInfoButonRet) =>
            {
                Debug.Log(JsonUtility.ToJson(userInfoButonRet.userInfo));
                txtUserInfo.text = $"nickName：{userInfoButonRet.userInfo.nickName}， avartar:{userInfoButonRet.userInfo.avatarUrl}";
            });
            Debug.Log("infoButton Created");

            // fallbackFont作为旧版本微信或者无法获得系统字体文件时的备选CDN URL
            var fallbackFont = Application.streamingAssetsPath + "/Fz.ttf";
            WeChatWASM.WX.GetWXFont(fallbackFont, (font) =>
            {
                if (font != null)
                {
                    txtTestWXFont.font = font;
                }
            });
        });
    }

    public void OnEnterOptionsClick()
    {
        var options = WX.GetEnterOptionsSync();
        Debug.Log("GetEnterOptionsSync scene:" + options.scene);
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

        Debug.Log($"PlayerPrefs mystringkey:{PlayerPrefs.GetString("mystringkey")}");
        Debug.Log($"PlayerPrefs myintkey:{PlayerPrefs.GetInt("myintkey")}");
        Debug.Log($"PlayerPrefs myfloatkey:{PlayerPrefs.GetFloat("myfloatkey")}");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
        if (infoButton != null)
        {
            infoButton.Destroy();
            Debug.Log("infoButton Destroy");
        }
    }
}
