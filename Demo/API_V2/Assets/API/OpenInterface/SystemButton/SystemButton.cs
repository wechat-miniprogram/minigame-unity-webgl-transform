using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;

public class SystemButton : Details
{
    private WXFeedbackButton _feedbackButton;

    private void Start()
    {
        var result = WX.GetLaunchOptionsSync();
        Debug.Log(JsonUtility.ToJson(result));

        StartCoroutine(CreateFeedbackButton(1.0f));

        WX.GetSetting(
            new GetSettingOption()
            {
                withSubscriptions = true,
                success = (res) =>
                {
                    Dictionary<string, string> itemSettings = res.subscriptionsSetting.itemSettings;
                    // 是否已授权过SYS_MSG_TYPE_INTERACTIVE，授权过不再展示按钮
                    if (
                        itemSettings.ContainsKey("SYS_MSG_TYPE_INTERACTIVE")
                        && itemSettings["SYS_MSG_TYPE_INTERACTIVE"] == "accept"
                    )
                    {
                        GameObject requestSubscribeButton = GameObject.Find(
                            "RequestSubscribeSystemMessage"
                        );
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
            }
        );

        GameManager.Instance.detailsController.BindExtraButtonAction(0, FeedbackButtonSwitch);
        GameManager.Instance.detailsController.BindExtraButtonAction(
            1,
            RequestSubscribeSystemMessage
        );
        GameManager.Instance.detailsController.BindExtraButtonAction(2, OpenCustomerServiceChat);
    }

    IEnumerator CreateFeedbackButton(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector2 size = GameManager.Instance.detailsController.GetInitialButtonSize();
        Vector2 position = GameManager.Instance.detailsController.GetButtonPosition(0);
        var windowInfo = GameManager.Instance.WindowInfo;
        _feedbackButton = WX.CreateFeedbackButton(
            new CreateOpenSettingButtonOption()
            {
                type = "text",
                text = "",
                style = new OptionStyle()
                {
                    left = Math.Abs((int)(position.x / windowInfo.pixelRatio)),
                    top = Math.Abs((int)(position.y / windowInfo.pixelRatio)),
                    width = (int)(size.x * windowInfo.screenWidth / 1080f),
                    height = (int)(size.y * windowInfo.screenWidth / 1080f),
                }
            }
        );
    }

    // 进入客服会话
    protected override void TestAPI(string[] args)
    {
        WX.OpenCustomerServiceConversation(
            new OpenCustomerServiceConversationOption
            {
                sessionFrom = "sessionFrom_test",
                showMessageCard = true,
                sendMessageTitle = "客服咨询",
            }
        );
    }

    // private bool _isFeedbackShow = true;

    // 切换意见反馈按钮显示/隐藏
    private void FeedbackButtonSwitch()
    {
        // if (_isFeedbackShow)
        // {
        //     // 隐藏意见反馈按钮
        //     _feedbackButton.Hide();
        //     GameManager.Instance.detailsController.ChangeExtraButtonText(1, "显示意见反馈按钮");
        // }
        // else
        // {
        //     // 显示意见反馈按钮
        //     _feedbackButton.Show();
        //     GameManager.Instance.detailsController.ChangeExtraButtonText(1, "隐藏意见反馈按钮");
        // }
        // _isFeedbackShow = !_isFeedbackShow;
    }

    // 调起小游戏系统订阅消息界面
    private void RequestSubscribeSystemMessage()
    {
        WX.RequestSubscribeSystemMessage(
            new RequestSubscribeSystemMessageOption()
            {
                msgTypeList = new string[] { "SYS_MSG_TYPE_INTERACTIVE" },
                success = (res) =>
                {
                    Debug.Log(res);
                },
                fail = (res) =>
                {
                    Debug.Log(JsonUtility.ToJson(res));
                }
            }
        );
    }

    // 打开微信客服
    private void OpenCustomerServiceChat()
    {
        WX.OpenCustomerServiceChat(
            new OpenCustomerServiceChatOption()
            {
                extInfo = new ExtInfoOption() { url = "https://www.qq.com/" },
                corpId = "123",
            }
        );
    }

    private void FeedbackButtonOnTap()
    {
        _feedbackButton.OnTap(
            (res) =>
            {
                Debug.Log("FeedbackButton.OnTap");
            }
        );
    }

    private void FeedbackButtonOffTap()
    {
        _feedbackButton.OffTap();
    }

    private void FeedbackButtonChangeText()
    {
        _feedbackButton.text = "跳转到意见反馈页面";
    }

    private void FeedbackButtonDestroy()
    {
        Debug.Log("feedback destroy");
        _feedbackButton.Destroy();
    }

    public void Destroy()
    {
        if (_feedbackButton != null)
        {
            _feedbackButton.Hide();
            FeedbackButtonDestroy();
            _feedbackButton = null;
        }
    }
}
