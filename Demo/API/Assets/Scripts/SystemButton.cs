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

    private void OnDestroy()
    {
        GameClubButtonDestroy();
        FeedbackButtonDestroy();
    }
}
