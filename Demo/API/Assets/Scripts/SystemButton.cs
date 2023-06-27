using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WeChatWASM;

public class SystemButton : MonoBehaviour
{
    private WXFeedbackButton FeedbackButton;
    private WXGameClubButton GameClubButton;
    private WeChatWASM.SystemInfo SystemInfo;

    void Start()
    {
        WX.InitSDK((code) =>
        {
            SystemInfo = WX.GetSystemInfoSync();

            CreateGameClubButton();

            CreateFeedbackButton();

            var result = WX.GetLaunchOptionsSync();
            Debug.Log(JsonUtility.ToJson(result));

            WX.GetSetting(new GetSettingOption()
            {
                withSubscriptions = true,
                success = (res) =>
                {
                    Dictionary<string, string> itemSettings = res.subscriptionsSetting.itemSettings;
                    // 是否已授权过SYS_MSG_TYPE_INTERACTIVE，授权过不在乎展示按钮
                    if (itemSettings.ContainsKey("SYS_MSG_TYPE_INTERACTIVE") && itemSettings["SYS_MSG_TYPE_INTERACTIVE"] == "accept")
                    {
                        GameObject requestSubscribeButton = GameObject.Find("RequestSubscribeSystemMessage");
                        if (requestSubscribeButton != null)
                        {
                            requestSubscribeButton.SetActive(false);
                        }
                    }
                },
                fail = (res) =>
                {
                    Debug.Log("GetSetting fail" + JsonUtility.ToJson(res));
                }
            });
        });
    }

    private void CreateGameClubButton()
    {
        var screenWidth = (int)SystemInfo.screenWidth;
        GameClubButton = WX.CreateGameClubButton(new WXCreateGameClubButtonParam()
        {
            type = GameClubButtonType.image,
            text = "游戏圈",
            icon = GameClubButtonIcon.white,
            style = new GameClubButtonStyle()
            {
                left = screenWidth - 40 - 10,
                top = 200,
                width = 40,
                height = 40,
            }
        });
    }

    public void GameClubButtonShow()
    {
        GameClubButton.Show();
    }

    public void GameClubButtonHide()
    {
        GameClubButton.Hide();
    }

    private void GameClubButtonDestroy()
    {
        GameClubButton.Destroy();
    }

    public void OpenCustomerServiceConversation()
    {
        WX.OpenCustomerServiceConversation(new OpenCustomerServiceConversationOption
        {
            sessionFrom = "sessionFrom_test",
            showMessageCard = true,
            sendMessageTitle = "客服咨询",
        });
    }

    private void CreateFeedbackButton()
    {
        FeedbackButton = WX.CreateFeedbackButton(new CreateOpenSettingButtonOption()
        {
            type = "text",
            text = "打开意见反馈页面",
            style = new OptionStyle()
            {
                left = 10,
                top = 200,
                width = 200,
                height = 40,
                lineHeight = 40,
                backgroundColor = "#ff0000",
                color = "#ffffff",
                textAlign = "center",
                fontSize = 16,
                borderRadius = 4,
            }
        });
    }

    public void FeedbackButtonShow()
    {
        FeedbackButton.Show();
    }

    public void FeedbackButtonHide()
    {
        FeedbackButton.Hide();
    }

    public void FeedbackButtonOnTap()
    {
        FeedbackButton.OnTap((res) =>
        {
            Debug.Log("FeedbackButton.OnTap");
        });
    }

    public void FeedbackButtonOffTap()
    {
        FeedbackButton.OffTap();
    }

    public void FeedbackButtonChangeText()
    {
        FeedbackButton.text = "跳转到意见反馈页面";
    }

    private void FeedbackButtonDestroy()
    {
        FeedbackButton.Destroy();
    }

    public void RequestSubscribeSystemMessage()
    {
        WX.RequestSubscribeSystemMessage(new RequestSubscribeSystemMessageOption()
        {
            msgTypeList = new string[] { "SYS_MSG_TYPE_INTERACTIVE" },
            success = (res) => {
                Debug.Log(res);
            }
        });
    }

    public void OpenCustomerServiceChat()
    {
        WX.OpenCustomerServiceChat(new OpenCustomerServiceChatOption()
        {
            extInfo = new ExtInfoOption()
            {
                url = "https://www.qq.com/"
            },
            corpId = "123",
        });
    }

    private void OnDestroy()
    {
        GameClubButtonDestroy();
        FeedbackButtonDestroy();
    }
}
