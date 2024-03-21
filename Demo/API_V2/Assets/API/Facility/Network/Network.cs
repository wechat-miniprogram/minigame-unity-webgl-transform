using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Network : Details
{

    private bool _isListening = false;

    private readonly Action<OnNetworkWeakChangeListenerResult> _onNetworkWeakChange = (res) => {
        var result = "onNetworkWeakChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnNetworkStatusChangeListenerResult> _onNetworkStatusChange = (res) => {
        var result = "onNetworkStatusChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };


    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, getNetworkType);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, getLocalIPAddress);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (!_isListening) {
            WX.OnNetworkWeakChange(_onNetworkWeakChange);
            WX.OnNetworkStatusChange(_onNetworkStatusChange);
        } else {
            WX.OffNetworkWeakChange(_onNetworkWeakChange);
            WX.OffNetworkStatusChange(_onNetworkStatusChange);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消监听" : "开始监听");
    }

    public void getNetworkType() {
        WX.GetNetworkType(new GetNetworkTypeOption
        {
            success = (res) => {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Access Success, Result: " + JsonMapper.ToJson(res)
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

    public void getLocalIPAddress() {
        WX.GetLocalIPAddress(new GetLocalIPAddressOption
        {
            success = (res) => {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Access Success, Result: " + JsonMapper.ToJson(res)
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

    private void OnDestroy() {
        WX.OffNetworkWeakChange(_onNetworkWeakChange);
        WX.OffNetworkStatusChange(_onNetworkStatusChange);
    }
}

