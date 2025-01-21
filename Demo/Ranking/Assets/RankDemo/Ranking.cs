using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WeChatWASM;

[System.Serializable]
public class OpenDataMessage
{
    // type 用于表明时间类型
    public string type;

    public string shareTicket;

    public int score;
}

public class Ranking : MonoBehaviour
{
    public Dropdown CanvasDropdown;
    public Button InitButton;
    public Button ShowButton;
    public Button ShareButton;
    public Button ReportButton;
    public Button TestMainButton; // 测试只有MainCanvas
    public Button TestMainWithSharedButton; // 测试MainCanvas和SharedCanvas一起
    public Button TestSharedButton; // 测试只有SharedCanvas
    public RawImage RankBody;
    public GameObject RankMask;
    public GameObject RankingBox;
    private CanvasType selectedCanvasType;
    private WXOpenDataContext openDataContext;

    void Start()
    {
        WX.InitSDK((code) =>
        {
            Init();
        });

        /**
         * 使用群排行功能需要特殊设置分享功能，详情可见链接
         * https://developers.weixin.qq.com/minigame/dev/guide/open-ability/share/share.html
         */
        WX.UpdateShareMenu(new UpdateShareMenuOption()
        {
            withShareTicket = true,
            isPrivateMessage = true,
        });

        /**
         * 群排行榜功能需要配合 WX.OnShow 来使用，整体流程为：
         * 1. WX.UpdateShareMenu 分享功能；
         * 2. 监听 WX.OnShow 回调，如果存在 shareTicket 且 query 里面带有启动特定 query 参数则为需要展示群排行的场景
         * 3. 调用 WX.ShowOpenData 和 WX.GetOpenDataContext().PostMessage 告知开放数据域侧需要展示群排行信息
         * 4. 开放数据域调用 wx.getGroupCloudStorage 接口拉取获取群同玩成员的游戏数据
         * 5. 将群同玩成员数据绘制到 sharedCanvas
         */
        WX.OnShow((res) =>
        {
            string shareTicket = res.shareTicket;
            Dictionary<string, string> query = res.query;

            if (!string.IsNullOrEmpty(shareTicket) && query != null && query["minigame_action"] == "show_group_list")
            {
                InitOpenDataContext();
                ShowOpenData();

                OpenDataMessage msgData = new OpenDataMessage();
                msgData.type = "showGroupFriendsRank";
                msgData.shareTicket = shareTicket;

                string msg = JsonUtility.ToJson(msgData);

                openDataContext.PostMessage(msg);
            }
        });
    }

    void InitOpenDataContext()
    {
        if (openDataContext == null)
        {
            openDataContext = WX.GetOpenDataContext(new OpenDataContextOption
            {
                sharedCanvasMode = selectedCanvasType
            });
        }
    }

    void ShowOpenData()
    {
        RankMask.SetActive(true);
        RankingBox.SetActive(true);
        // 
        // 注意这里传x,y,width,height是为了点击区域能正确点击，x,y 是距离屏幕左上角的距离，宽度传 (int)RankBody.rectTransform.rect.width是在canvas的UI Scale Mode为 Constant Pixel Size的情况下设置的。
        /**
         * 如果父元素占满整个窗口的话，pivot 设置为（0，0），rotation设置为180，则左上角就是离屏幕的距离
         * 注意这里传x,y,width,height是为了点击区域能正确点击，因为开放数据域并不是使用 Unity 进行渲染而是可以选择任意第三方渲染引擎
         * 所以开放数据域名要正确处理好事件处理，就需要明确告诉开放数据域，排行榜所在的纹理绘制在屏幕中的物理坐标系
         * 比如 iPhone Xs Max 的物理尺寸是 414 * 896，如果排行榜被绘制在屏幕中央且物理尺寸为 200 * 200，那么这里的 x,y,width,height应当是 107,348,200,200
         * x,y 是距离屏幕左上角的距离，宽度传 (int)RankBody.rectTransform.rect.width是在canvas的UI Scale Mode为 Constant Pixel Size的情况下设置的
         * 如果是Scale With Screen Size，且设置为以宽度作为缩放，则要这要做一下换算，比如canavs宽度为960，rawImage设置为200 则需要根据 referenceResolution 做一些换算
         * 不过不管是什么屏幕适配模式，这里的目的就是为了算出 RawImage 在屏幕中绝对的位置和尺寸
         */

        CanvasScaler scaler = gameObject.GetComponent<CanvasScaler>();
        var referenceResolution = scaler.referenceResolution;
        var p = RankBody.transform.position;

        WX.ShowOpenData(RankBody.texture, (int)p.x, Screen.height - (int)p.y, (int)((Screen.width / referenceResolution.x) * RankBody.rectTransform.rect.width), (int)((Screen.width / referenceResolution.x) * RankBody.rectTransform.rect.height));
    }

    // 测试MainCanvas导出图片
    private void MainToTempFilePath()
    {
        var info = WX.GetSystemInfoSync();
        Debug.Log("Test MainCanvas ToTempFilePath");
        WXCanvas.ToTempFilePath(new WXToTempFilePathParam()
        {
                success = (result) =>
                {
                    Debug.Log("MainCanvas ToTempFilePath success:" + JsonUtility.ToJson(result));
                    // Test PreviewImage
                    WX.PreviewImage(new PreviewImageOption
                    {
                        urls = new string[] {result.tempFilePath},
                        showmenu = true,
                        success = (res) => 
                        {
                            Debug.Log("MainCanvas PreviewImage success:" + JsonUtility.ToJson(result));
                        },
                        fail = (res) =>
                        {
                            Debug.Log("MainCanvas PreviewImage fail:" + JsonUtility.ToJson(result));
                        }
                    });
                },
                fail = (result) =>
                {
                    Debug.Log("MainCanvas ToTempFilePath fail:" + JsonUtility.ToJson(result));
                }
        });
    }

    // 测试SharedCanvas导出图片
    private void SharedToTempFilePath()
    {
        var info = WX.GetSystemInfoSync();
        Debug.Log("Test SharedCanvas ToTempFilePath");
        WXSharedCanvas.ToTempFilePath(new WXToTempFilePathParam()
        {
                success = (result) =>
                {
                    Debug.Log("SharedCanvas ToTempFilePath success:" + JsonUtility.ToJson(result));
                    // Test PreviewImage
                    WX.PreviewImage(new PreviewImageOption
                    {
                        urls = new string[] {result.tempFilePath},
                        showmenu = true,
                        success = (res) => 
                        {
                            Debug.Log("SharedCanvas PreviewImage success:" + JsonUtility.ToJson(result));
                        },
                        fail = (res) =>
                        {
                            Debug.Log("SharedCanvas PreviewImage fail:" + JsonUtility.ToJson(result));
                        }
                    });
                },
                fail = (result) =>
                {
                    Debug.Log("SharedCanvas ToTempFilePath fail:" + JsonUtility.ToJson(result));
                }
        });
    }

    void Init()
    {
        CanvasDropdown.onValueChanged.AddListener((int selectedIndex) =>
        {
            selectedCanvasType = (CanvasType)selectedIndex;
        });

        ShowButton.onClick.AddListener(() =>
        {
            InitOpenDataContext();
            ShowOpenData();

            OpenDataMessage msgData = new OpenDataMessage();
            msgData.type = "showFriendsRank";

            string msg = JsonUtility.ToJson(msgData);
            openDataContext.PostMessage(msg);
        });


        RankMask.GetComponent<Button>().onClick.AddListener(() =>
        {
            RankMask.SetActive(false);
            RankingBox.SetActive(false);
            WX.HideOpenData();
        });

        ShareButton.onClick.AddListener(() =>
        {
            WX.ShareAppMessage(new ShareAppMessageOption()
            {
                title = "最强战力排行榜！谁是第一？",
                query = "minigame_action=show_group_list",
                imageUrl = "https://mmgame.qpic.cn/image/5f9144af9f0e32d50fb878e5256d669fa1ae6fdec77550849bfee137be995d18/0",
            });
        });

        ReportButton.onClick.AddListener(() =>
        {
            OpenDataMessage msgData = new OpenDataMessage();
            msgData.type = "setUserRecord";
            msgData.score = Random.Range(1, 1000);

            string msg = JsonUtility.ToJson(msgData);

            Debug.Log(msg);
            InitOpenDataContext();
            openDataContext.PostMessage(msg);
        });

        InitButton.onClick.AddListener(InitOpenDataContext);
        TestMainButton.onClick.AddListener(MainToTempFilePath);
        TestMainWithSharedButton.onClick.AddListener(MainToTempFilePath);
        TestSharedButton.onClick.AddListener(SharedToTempFilePath);
    }
}
