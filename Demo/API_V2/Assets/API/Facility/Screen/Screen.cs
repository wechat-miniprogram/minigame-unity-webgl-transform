using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Screen : Details
{
    private bool _isListening = false;
    private bool _isListening1 = false;
    private System.Random random = new System.Random();

    private readonly Action<OnUserCaptureScreenListenerResult> _onUserCaptureScreen = (res) =>
    {
        WX.ShowToast(new ShowToastOption { title = "截屏触发" });
        var result = "_onUserCaptureScreen\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };

    private readonly Action<OnScreenRecordingStateChangedListenerResult> _onScreenRecordingStateChanged =
        (res) =>
        {
            var result = "onScreenRecordingStateChanged\n" + JsonMapper.ToJson(res);
            GameManager.Instance.detailsController.AddResult(
                new ResultData() { initialContentText = result }
            );
        };

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, setScreenBrightness);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, setKeepScreenOn);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, onUserCaptureScreen);
        GameManager.Instance.detailsController.BindExtraButtonAction(
            3,
            onScreenRecordingStateChanged
        );
        GameManager.Instance.detailsController.BindExtraButtonAction(4, getScreenRecordingState);
        GameManager.Instance.detailsController.BindExtraButtonAction(5, getScreenBrightness);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        setVisualEffectOnCapture();
    }

    public void setVisualEffectOnCapture()
    {
        WX.SetVisualEffectOnCapture(
            new SetVisualEffectOnCaptureOption
            {
                visualEffect = "none",
                success = (res) =>
                {
                    WX.ShowToast(
                        new ShowToastOption()
                        {
                            title = "Access Success, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                },
                fail = (res) =>
                {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete");
                }
            }
        );
    }

    public void setScreenBrightness()
    {
        WX.SetScreenBrightness(
            new SetScreenBrightnessOption
            {
                value = random.NextDouble(),
                success = (res) =>
                {
                    WX.ShowToast(
                        new ShowToastOption()
                        {
                            title = "Access Success, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                },
                fail = (res) =>
                {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete");
                }
            }
        );
    }

    public void setKeepScreenOn()
    {
        WX.SetKeepScreenOn(
            new SetKeepScreenOnOption
            {
                keepScreenOn = true,
                success = (res) =>
                {
                    WX.ShowToast(
                        new ShowToastOption()
                        {
                            title = "Access Success, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                },
                fail = (res) =>
                {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete");
                }
            }
        );
    }

    public void onUserCaptureScreen()
    {
        if (!_isListening)
        {
            WX.OnUserCaptureScreen(_onUserCaptureScreen);
        }
        else
        {
            WX.OffUserCaptureScreen(_onUserCaptureScreen);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeExtraButtonText(
            2,
            _isListening ? "取消监听截屏" : "开始监听截屏"
        );
    }

    public void onScreenRecordingStateChanged()
    {
        if (!_isListening1)
        {
            WX.OnScreenRecordingStateChanged(_onScreenRecordingStateChanged);
        }
        else
        {
            WX.OffScreenRecordingStateChanged(_onScreenRecordingStateChanged);
        }
        _isListening1 = !_isListening1;
        GameManager.Instance.detailsController.ChangeExtraButtonText(
            3,
            _isListening1 ? "取消监听录屏" : "开始监听录屏"
        );
    }

    public void getScreenRecordingState()
    {
        WX.GetScreenRecordingState(
            new GetScreenRecordingStateOption
            {
                success = (res) =>
                {
                    WX.ShowModal(
                        new ShowModalOption()
                        {
                            content = "Access Success, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                },
                fail = (res) =>
                {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete");
                }
            }
        );
    }

    public void getScreenBrightness()
    {
        WX.GetScreenBrightness(
            new GetScreenBrightnessOption
            {
                success = (res) =>
                {
                    WX.ShowModal(
                        new ShowModalOption()
                        {
                            content = "Access Success, Result: " + JsonMapper.ToJson(res)
                        }
                    );
                },
                fail = (res) =>
                {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete");
                }
            }
        );
    }

    private void OnDestroy()
    {
        WX.OffUserCaptureScreen(_onUserCaptureScreen);
        WX.OffScreenRecordingStateChanged(_onScreenRecordingStateChanged);
    }
}
