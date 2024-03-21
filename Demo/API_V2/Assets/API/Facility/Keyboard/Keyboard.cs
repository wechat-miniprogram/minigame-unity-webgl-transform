using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Keyboard : Details
{

    private bool _isListening = false;
    private System.Random random = new System.Random();

    private readonly Action<OnKeyDownListenerResult> _onKeyUp = (res) => {
        var result = "onKeyUp\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnKeyDownListenerResult> _onKeyDown = (res) => {
        var result = "onKeyDown\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnKeyboardInputListenerResult> _onKeyboardInput = (res) => {
        var result = "onKeyboardInput\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnKeyboardInputListenerResult> _onKeyboardComplete = (res) => {
        var result = "onKeyboardComplete\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnKeyboardInputListenerResult> _onKeyboardConfirm = (res) => {
        var result = "onKeyboardConfirm\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnKeyboardHeightChangeListenerResult> _onKeyboardHeightChange = (res) => {
        var result = "onKeyboardHeightChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };
    

    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, showKeyboard);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, updateKeyboard);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, hideKeyboard);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (!_isListening) {
            WX.OnKeyUp(_onKeyUp);
            WX.OnKeyDown(_onKeyDown);
            WX.OnKeyboardInput(_onKeyboardInput);
            WX.OnKeyboardHeightChange(_onKeyboardHeightChange);
            WX.OnKeyboardConfirm(_onKeyboardConfirm);
            WX.OnKeyboardComplete(_onKeyboardComplete);
        } else {
            WX.OffKeyUp(_onKeyUp);
            WX.OffKeyDown(_onKeyDown);
            WX.OffKeyboardInput(_onKeyboardInput);
            WX.OffKeyboardHeightChange(_onKeyboardHeightChange);
            WX.OffKeyboardConfirm(_onKeyboardConfirm);
            WX.OffKeyboardComplete(_onKeyboardComplete);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消监听" : "开始监听");
    }

    public void showKeyboard() 
    {
        WX.ShowKeyboard(new ShowKeyboardOption 
        {
            defaultValue = "test",
            maxLength = 20,
            multiple = true,
            confirmHold = false,
            confirmType = "done",
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

    public void updateKeyboard() {
        WX.UpdateKeyboard(new UpdateKeyboardOption
        {
            value = "test" + random.Next(0, 100),
            success = (res) => {
                Debug.Log("success");
                WX.ShowToast(new ShowToastOption
                {
                    title = "更改成功"
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

    public void hideKeyboard() {
        WX.HideKeyboard(new HideKeyboardOption
        {
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

    private void OnDestroy() 
    {
        WX.OffKeyUp(_onKeyUp);
        WX.OffKeyDown(_onKeyDown);
        WX.OffKeyboardInput(_onKeyboardInput);
        WX.OffKeyboardHeightChange(_onKeyboardHeightChange);
        WX.OffKeyboardConfirm(_onKeyboardConfirm);
        WX.OffKeyboardComplete(_onKeyboardComplete);
    }
}

