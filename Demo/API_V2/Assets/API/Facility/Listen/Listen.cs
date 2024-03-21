using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Listen : Details
{

    private bool _isListeningAccelerometer = false;
    private bool _isListeningCompass = false;
    private bool _isListeningDeviceMotion = false;
    private bool _isPortrait = true;
    private bool _isListeningGyroscope = false;

    private readonly Action<OnAccelerometerChangeListenerResult> _onAccelerometerChange = (res) => {
        var result = "onAccelerometerChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnCompassChangeListenerResult> _onCompassChange = (res) => {
        var result = "onCompassChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnDeviceMotionChangeListenerResult> _onDeviceMotionChange = (res) => {
        var result = "onDeviceMotionChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnDeviceOrientationChangeListenerResult> _onDeviceOrientationChange = (res) => {
        var result = "onDeviceOrientationChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnGyroscopeChangeListenerResult> _onGyroscopeChange = (res) => {
        var result = "onGyroscopeChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private void Start()
    {
        // 监听转屏事件
        WX.OnDeviceOrientationChange(_onDeviceOrientationChange);

        GameManager.Instance.detailsController.BindExtraButtonAction(0, Compass);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, DeviceMotion);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, DeviceOrientation);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, Gyroscope);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        Accelerometer();
    }

    public void Accelerometer() {
        if (!_isListeningAccelerometer) {
            WX.StartAccelerometer(new StartAccelerometerOption
            {
                interval = "normal",
                success = (res) => {
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Access Success, Result: " + JsonMapper.ToJson(res)
                    });
                },
                fail = (res) => {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) => {
                    Debug.Log("complete");
                }
            });
            WX.OnAccelerometerChange(_onAccelerometerChange);
        } else {
            WX.StopAccelerometer(new StopAccelerometerOption
            {
                success = (res) => {
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Access Success, Result: " + JsonMapper.ToJson(res)
                    });
                },
                fail = (res) => {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) => {
                    Debug.Log("complete");
                }
            });
            WX.OffAccelerometerChange(_onAccelerometerChange);
        }
        _isListeningAccelerometer = !_isListeningAccelerometer;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListeningAccelerometer ? "取消监听加速度" : "开始监听加速度");
    }

    public void Compass() {
        if (!_isListeningCompass) {
            WX.StartCompass(new StartCompassOption
            {
                success = (res) => {
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Access Success, Result: " + JsonMapper.ToJson(res)
                    });
                },
                fail = (res) => {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) => {
                    Debug.Log("complete");
                }
            });
            WX.OnCompassChange(_onCompassChange);
        } else {
            WX.StopCompass(new StopCompassOption
            {
                success = (res) => {
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Access Success, Result: " + JsonMapper.ToJson(res)
                    });
                },
                fail = (res) => {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) => {
                    Debug.Log("complete");
                }
            });
            WX.OffCompassChange(_onCompassChange);
        }
        _isListeningCompass = !_isListeningCompass;
        GameManager.Instance.detailsController.ChangeExtraButtonText(0, _isListeningCompass ? "取消监听罗盘" : "开始监听罗盘");
    }

    public void DeviceMotion() {
        if (!_isListeningDeviceMotion) {
            WX.StartDeviceMotionListening(new StartDeviceMotionListeningOption
            {
                interval = "normal",
                success = (res) => {
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Access Success, Result: " + JsonMapper.ToJson(res)
                    });
                },
                fail = (res) => {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) => {
                    Debug.Log("complete");
                }
            });
            WX.OnDeviceMotionChange(_onDeviceMotionChange);
        } else {
            WX.StopDeviceMotionListening(new StopDeviceMotionListeningOption
            {
                success = (res) => {
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Access Success, Result: " + JsonMapper.ToJson(res)
                    });
                },
                fail = (res) => {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) => {
                    Debug.Log("complete");
                }
            });
            WX.OffDeviceMotionChange(_onDeviceMotionChange);
        }
        _isListeningDeviceMotion = !_isListeningDeviceMotion;
        GameManager.Instance.detailsController.ChangeExtraButtonText(1, _isListeningDeviceMotion ? "取消监听设备方向" : "开始监听设备方向");
    }

    public void DeviceOrientation() {
        WX.SetDeviceOrientation(new SetDeviceOrientationOption
        {
            value = !_isPortrait ? "portrait" : "landscape",
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
        _isPortrait = !_isPortrait;
    }

    public void Gyroscope() {
        if (!_isListeningGyroscope) {
            WX.StartGyroscope(new StartGyroscopeOption
            {
                interval = "normal",
                success = (res) => {
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Access Success, Result: " + JsonMapper.ToJson(res)
                    });
                },
                fail = (res) => {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) => {
                    Debug.Log("complete");
                }
            });
            WX.OnGyroscopeChange(_onGyroscopeChange);
        } else {
            WX.StopGyroscope(new StopGyroscopeOption
            {
                success = (res) => {
                    WX.ShowToast(new ShowToastOption()
                    {
                        title = "Access Success, Result: " + JsonMapper.ToJson(res)
                    });
                },
                fail = (res) => {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) => {
                    Debug.Log("complete");
                }
            });
            WX.OffGyroscopeChange(_onGyroscopeChange);
        }
        _isListeningGyroscope = !_isListeningGyroscope;
        GameManager.Instance.detailsController.ChangeExtraButtonText(3, _isListeningGyroscope ? "取消监听陀螺仪" : "开始监听陀螺仪");
    }

    private void OnDestroy() {
        WX.OffDeviceOrientationChange(_onDeviceOrientationChange);
        WX.OffAccelerometerChange(_onAccelerometerChange);
        WX.OffCompassChange(_onCompassChange);
        WX.OffDeviceMotionChange(_onDeviceMotionChange);
        WX.OffGyroscopeChange(_onGyroscopeChange);
    }
}

