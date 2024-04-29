using System;
using System.Collections.Generic;
using UnityEngine;
using WeChatWASM;
using System.Collections;
using System.Threading;
public class SystemButton : Details
{
    private WXFeedbackButton _feedbackButton;
    private WXGameClubButton _gameClubButton;

    private void Start()
    {
        var result = WX.GetLaunchOptionsSync();
        Debug.Log(JsonUtility.ToJson(result));

        StartCoroutine(CreateGameClubButton(1.0f));
        StartCoroutine(CreateFeedbackButton(1.0f));

        WX.GetSetting(new GetSettingOption()
        {
            withSubscriptions = true,
            success = (res) =>
            {
                Dictionary<string, string> itemSettings = res.subscriptionsSetting.itemSettings;
                // 是否已授权过SYS_MSG_TYPE_INTERACTIVE，授权过不再展示按钮
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

        GameManager.Instance.detailsController.BindExtraButtonAction(0, GameClubButtonSwitch);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, FeedbackButtonSwitch);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, RequestSubscribeSystemMessage);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, OpenCustomerServiceChat);
    }

    IEnumerator CreateGameClubButton(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector2 size = GameManager.Instance.detailsController.GetInitialButtonSize();
        Vector2 position = GameManager.Instance.detailsController.GetButtonPosition(0);
        var systemInfo = WX.GetSystemInfoSync();
        _gameClubButton = WX.CreateGameClubButton(new WXCreateGameClubButtonParam()
        {
            type = GameClubButtonType.text,
            style = new GameClubButtonStyle()
            {
                left = Math.Abs((int)(position.x / systemInfo.pixelRatio)),
                top = Math.Abs((int)(position.y / systemInfo.pixelRatio)),
                width = (int)(size.x * systemInfo.screenWidth / 1080f),
                height = (int)(size.y * systemInfo.screenWidth / 1080f),
            }
        });
    }

    IEnumerator CreateFeedbackButton(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector2 size = GameManager.Instance.detailsController.GetInitialButtonSize();
        Vector2 position = GameManager.Instance.detailsController.GetButtonPosition(1);
        var systemInfo = WX.GetSystemInfoSync();
        _feedbackButton = WX.CreateFeedbackButton(new CreateOpenSettingButtonOption()
        {
            type = "text",
            text = "",
            style = new OptionStyle()
            {
                left = Math.Abs((int)(position.x / systemInfo.pixelRatio)),
                top = Math.Abs((int)(position.y / systemInfo.pixelRatio)),
                width = (int)(size.x * systemInfo.screenWidth / 1080f),
                height = (int)(size.y * systemInfo.screenWidth / 1080f),
            }
        });
    }

    // 进入客服会话
    protected override void TestAPI(string[] args)
    {
        WX.OpenCustomerServiceConversation(new OpenCustomerServiceConversationOption
        {
            sessionFrom = "sessionFrom_test",
            showMessageCard = true,
            sendMessageTitle = "客服咨询",
        });
    }

    private bool _isGameClubShow = false;

    // 切换游戏圈按钮显示/隐藏
    private void GameClubButtonSwitch()
    {
        // if (_isGameClubShow)
        // {
        //     // 显示游戏圈按钮
        //     _gameClubButton.Show();
        //     GameManager.Instance.detailsController.ChangeExtraButtonText(0, "隐藏游戏圈按钮");
        // }
        // else
        // {
        //     // 隐藏游戏圈按钮
        //     _gameClubButton.Hide();
        //     GameManager.Instance.detailsController.ChangeExtraButtonText(0, "显示游戏圈按钮");
        // }
        // _isGameClubShow = !_isGameClubShow;
    }

    private bool _isFeedbackShow = true;

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
        WX.RequestSubscribeSystemMessage(new RequestSubscribeSystemMessageOption()
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
        });
    }

    // 打开微信客服
    private void OpenCustomerServiceChat()
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


    private void FeedbackButtonOnTap()
    {
        _feedbackButton.OnTap((res) =>
        {
            Debug.Log("FeedbackButton.OnTap");
        });
    }

    private void FeedbackButtonOffTap()
    {
        _feedbackButton.OffTap();
    }

    private void FeedbackButtonChangeText()
    {
        _feedbackButton.text = "跳转到意见反馈页面";
    }


    private void GameClubButtonDestroy()
    {
        Debug.Log("gameclub destroy");
        _gameClubButton.Destroy();
    }

    private void FeedbackButtonDestroy()
    {
        Debug.Log("feedback destroy");
        _feedbackButton.Destroy();
    }

    public void Destroy()
    {
        if (_gameClubButton != null)
        {
            _gameClubButton.Hide();
            GameClubButtonDestroy();
            _gameClubButton = null;
        }
        if (_feedbackButton != null)
        {
            _feedbackButton.Hide();
            FeedbackButtonDestroy();
            _feedbackButton = null;
        }
    }
}
