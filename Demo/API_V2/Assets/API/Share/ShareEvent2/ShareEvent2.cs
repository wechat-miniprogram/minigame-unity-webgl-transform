using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class ShareEvent2 : Details
{

    private bool _isListeningHandoff = false;
    private bool _isListeningCopyUrl = false;
    private bool _isListeningAddToFavorites = false;

    private readonly Action<Action<OnHandoffListenerResult>> _onHandoff = (callback) =>
    {
        callback(new OnHandoffListenerResult
        {
            query = "xxxx"
        });
    };

    private readonly Action<Action<OnCopyUrlListenerResult>> _onCopyUrl = (callback) =>
    {
        callback(new OnCopyUrlListenerResult
        {
            query = "xx"
        });
    };

    private readonly Action<Action<OnAddToFavoritesListenerResult>> _onAddToFavorites = (callback) =>
    {
        callback(new OnAddToFavoritesListenerResult
        {
            title = "收藏标题",
            imageUrl = "xx",
            query = "key1=val1&key2=val2",
            disableForward = false
        });
    };

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, onCopyUrl);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, onAddToFavorites);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, getShareInfo);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, authPrivateMessage);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        onHandoff();
    }

    public void onHandoff()
    {
        if (!_isListeningHandoff)
        {
            WX.OnHandoff(_onHandoff);
        }
        else
        {
            WX.OffHandoff(_onHandoff);
        }
        _isListeningHandoff = !_isListeningHandoff;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListeningHandoff ? "取消监听在电脑上打开" : "开始监听在电脑上打开");
    }

    public void onCopyUrl()
    {
        if (!_isListeningCopyUrl)
        {
            WX.OnCopyUrl(_onCopyUrl);
        }
        else
        {
            WX.OffCopyUrl(_onCopyUrl);
        }
        _isListeningCopyUrl = !_isListeningCopyUrl;
        GameManager.Instance.detailsController.ChangeExtraButtonText(0, _isListeningCopyUrl ? "取消监听复制链接" : "开始监听复制链接");
    }

    public void onAddToFavorites()
    {
        if (!_isListeningAddToFavorites)
        {
            WX.OnAddToFavorites(_onAddToFavorites);
        }
        else
        {
            WX.OffAddToFavorites(_onAddToFavorites);
        }
        _isListeningAddToFavorites = !_isListeningAddToFavorites;
        GameManager.Instance.detailsController.ChangeExtraButtonText(1, _isListeningAddToFavorites ? "取消监听收藏" : "开始监听收藏");
    }

    public void getShareInfo()
    {
        WX.GetShareInfo(new GetShareInfoOption
        {
            shareTicket = "xxx",
            timeout = 2000,
            success = (res) =>
            {
                Debug.Log("success");
            },
            fail = (res) =>
            {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete");
            }
        });
    }

    public void authPrivateMessage()
    {
        WX.AuthPrivateMessage(new AuthPrivateMessageOption
        {
            shareTicket = "xxxxxx",
            success = (res) =>
            {
                Debug.Log("authPrivateMessage success" + JsonMapper.ToJson(res));
                // res
                // {
                //   errMsg: 'authPrivateMessage:ok'
                //   valid: true
                //   iv: 'xxxx',
                //   encryptedData: 'xxxxxx'
                // }
            },
            fail = (res) =>
            {
                Debug.Log("authPrivateMessage fail" + res.errMsg);
            }
        });
    }

    private void OnDestroy()
    {
        WX.OffHandoff(_onHandoff);
        WX.OffCopyUrl(_onCopyUrl);
        WX.OffAddToFavorites(_onAddToFavorites);
    }
}