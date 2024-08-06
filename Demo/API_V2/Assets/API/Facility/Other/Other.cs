using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Other : Details {

    private bool _isListening = false;

    private readonly Action<OnMemoryWarningListenerResult> _onMemoryWarning = (res) => {
        var result = "onMemoryWarning\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData() {
            initialContentText = result
        });
    };


    private void Start() {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, scanCode);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, vibrateShort);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, vibrateLong);
    }

    // 测试 API
    protected override void TestAPI(string[] args) {
        memoryWarning();
    }

    public void memoryWarning() {
        if (!_isListening) {
            WX.OnMemoryWarning(_onMemoryWarning);
        } else {
            WX.OffMemoryWarning(_onMemoryWarning);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消监听内存告警" : "开始监听内存告警");
    }

    public void scanCode() {
        WX.ScanCode(new ScanCodeOption {
            onlyFromCamera = false,
            scanType = new string[] { "barCode", "qrcode" },
            success = (res) => {
                Debug.Log("success " + JsonMapper.ToJson(res));
            },
            fail = (res) => {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void vibrateShort() {
        WX.VibrateShort(new VibrateShortOption {
            type = "heavy",
            success = (res) => {
                Debug.Log("success ");
            },
            fail = (res) => {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void vibrateLong() {
        WX.VibrateLong(new VibrateLongOption {
            success = (res) => {
                Debug.Log("success ");
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
        WX.OffMemoryWarning(_onMemoryWarning);
    }
}