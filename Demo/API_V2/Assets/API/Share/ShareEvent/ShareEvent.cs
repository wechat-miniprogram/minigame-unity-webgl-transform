using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class ShareEvent : Details
{

    private bool _isListeningShareTimeline = false;

    private readonly Action<Action<OnShareTimelineListenerResult>> _onShareTimelineCallback = (callback) => {
        callback(new OnShareTimelineListenerResult 
        {
            imageUrl = "xxx",
            imagePreviewUrl = "yy",
            imagePreviewUrlId = "xx",
            imageUrlId = "xxx",
            path = "xx",
            query = "xx",
            title = "test",
        });
    };

    private readonly Action<OnShareMessageToFriendListenerResult> _onShareMessageToFriend = (res) => {
        var result = "onShareMessageToFriend\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<Action<WXShareAppMessageParam>> _onShareAppMessageCallback = (callback) => {
        callback(new WXShareAppMessageParam 
        {
            title = "转发标题",
            imageUrl = "xx",
            query = "key1=val1&key2=val2"
        });
    };


    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, showShareMenu);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, hideShareMenu);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, showShareImageMenu);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, setMessageToFriendQuery);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, setHandoffQuery);
        GameManager.Instance.detailsController.BindExtraButtonAction(5, onShareTimeline);
        GameManager.Instance.detailsController.BindExtraButtonAction(6, onShareMessageToFriend);
        GameManager.Instance.detailsController.BindExtraButtonAction(7, onShareAppMessage);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
       updateShareMenu();
    }

    public void updateShareMenu() {
        var parameter = new UpdatableMessageFrontEndParameter[] {
                new UpdatableMessageFrontEndParameter {
                    name = "xxx",
                    value = "yyy"
                },
                new UpdatableMessageFrontEndParameter {
                    name = "zz",
                    value = "kk"
                }
        };

        var info = new UpdatableMessageFrontEndTemplateInfo{
            parameterList = parameter
        };

        WX.UpdateShareMenu(new UpdateShareMenuOption
        {
            isPrivateMessage = true,
            activityId = "xxx",
            templateInfo = info,
            success = (res) => {
                WX.ShowToast(new ShowToastOption 
                {
                    title = "设置成功"
                });
            },
            fail = (res) => {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void showShareMenu() {
        WX.ShowShareMenu(new ShowShareMenuOption 
        {
            withShareTicket = true,
            menus = new string[] {"shareAppMessage", "shareTimeline"},
            success = (res) => {
               Debug.Log("success");
            },
            fail = (res) => {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void hideShareMenu() {
        WX.HideShareMenu(new HideShareMenuOption 
        {
            menus = new string[] {"shareAppMessage", "shareTimeline"},
            success = (res) => {
               Debug.Log("success");
            },
            fail = (res) => {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void showShareImageMenu() {
        WX.DownloadFile(new DownloadFileOption 
        {
            url = "xxxxx",
            success = (res) => {
                WX.ShowShareImageMenu(new ShowShareImageMenuOption 
                {
                    path = res.tempFilePath,
                    style = "default",
                    success = (res2) => {
                        Debug.Log("success");
                    },
                    fail = (res2) => {
                        Debug.Log("fail" + res.errMsg);
                    },
                    complete = (res2) => {
                        Debug.Log("complete");
                    }
                });
            }
        });
    }

    public void setMessageToFriendQuery() {
        var isSuccess = WX.SetMessageToFriendQuery(new SetMessageToFriendQueryOption 
        {
            shareMessageToFriendScene = 1,
            query = "abcd"
        });
         WX.ShowToast(new ShowToastOption 
        {
            title = isSuccess ? "true" : "false" 
        });
    }

    public void setHandoffQuery() {
        var isSuccess = WX.SetHandoffQuery("xxx");
         WX.ShowToast(new ShowToastOption 
        {
            title = isSuccess ? "true" : "false" 
        });
    }

    public void onShareTimeline() {
        if (!_isListeningShareTimeline) {
            WX.OnShareTimeline(_onShareTimelineCallback);
        } else {
            WX.OffShareTimeline(_onShareTimelineCallback);
        }
        _isListeningShareTimeline = !_isListeningShareTimeline;
        GameManager.Instance.detailsController.ChangeExtraButtonText(5, _isListeningShareTimeline ? "取消监听分享到朋友圈" : "开始监听分享到朋友圈");
    }

    public void onShareMessageToFriend() {
        WX.OnShareMessageToFriend(_onShareMessageToFriend);
    }

    public void onShareAppMessage() {
        var defaultParam = new WXShareAppMessageParam 
        {
            title = "转发标题",
            imageUrl = "xx",
            query = "key1=val1&key2=val2"
        };
        WX.OnShareAppMessage(defaultParam, _onShareAppMessageCallback);
    }

    private void OnDestroy() {
        WX.OffShareTimeline(_onShareTimelineCallback);
    }
}

