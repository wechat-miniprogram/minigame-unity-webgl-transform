using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class BLE : Details
{

    private bool _isListening = false;

    private readonly Action<OnBLEMTUChangeListenerResult> _onBLEMTUChange = (res) => {
        var result = "onBLEMTUChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnBLEConnectionStateChangeListenerResult> _onBLEConnectionStateChange = (res) => {
        var result = "onBLEConnectionStateChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnBLECharacteristicValueChangeListenerResult> _onBLECharacteristicValueChange = (res) => {
        var result = "onBLECharacteristicValueChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };


    private void Start()
    {
        // 监听蓝牙低功耗的最大传输单元变化事件（仅安卓触发）
        WX.OnBLEMTUChange(_onBLEMTUChange);

        // 监听蓝牙低功耗连接状态改变事件。包括开发者主动连接或断开连接，设备丢失，连接异常断开等等
        WX.OnBLEConnectionStateChange(_onBLEConnectionStateChange);

        // 监听蓝牙低功耗设备的特征值变化事件。
        WX.OnBLECharacteristicValueChange(_onBLECharacteristicValueChange);

        GameManager.Instance.detailsController.BindExtraButtonAction(0, writeBLECharacteristicValue);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, setBLEMTU);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, readBLECharacteristicValue);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, notifyBLECharacteristicValueChange);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, getBLEMTU);
        GameManager.Instance.detailsController.BindExtraButtonAction(5, getBLEDeviceServices);
        GameManager.Instance.detailsController.BindExtraButtonAction(6, getBLEDeviceRSSI);
        GameManager.Instance.detailsController.BindExtraButtonAction(7, getBLEDeviceCharacteristics);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        createBLEConnection();
    }

    public void createBLEConnection() {
        if (!_isListening) {
            WX.CreateBLEConnection(new CreateBLEConnectionOption 
            {
                deviceId = "xxx",
                timeout = 20000,
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
        } else {
            WX.CloseBLEConnection(new CloseBLEConnectionOption 
            {
                deviceId = "xxx",
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
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "断开连接" : "开始连接");
    }

    // 目前会报param.value类型错误，已知问题，等待修复
    public void writeBLECharacteristicValue() {
        WX.WriteBLECharacteristicValue(new WriteBLECharacteristicValueOption 
        {
            deviceId = "xxx",
            serviceId = "xxx",
            characteristicId = "xxx",
            value = new byte[] {1, 2, 3},
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

    public void setBLEMTU() {
        WX.SetBLEMTU(new SetBLEMTUOption 
        {
            deviceId = "xx",
            mtu = 100,
            success = (res) => {
                Debug.Log("success " + JsonMapper.ToJson(res));
            },
            fail = (res) => {
                Debug.Log("fail" + res.mtu);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });
    }

    public void readBLECharacteristicValue() {
        WX.ReadBLECharacteristicValue(new ReadBLECharacteristicValueOption 
        {
            deviceId = "xx",
            serviceId = "xx",
            characteristicId = "xx",
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

    public void notifyBLECharacteristicValueChange() {
        WX.NotifyBLECharacteristicValueChange(new NotifyBLECharacteristicValueChangeOption {
            deviceId = "xx",
            serviceId = "xx",
            characteristicId = "xx",
            state = true,
            type = "indication",
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

    public void getBLEMTU() {
        WX.GetBLEMTU(new GetBLEMTUOption 
        {
            deviceId = "xx",
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

    public void getBLEDeviceServices() {
        WX.GetBLEDeviceServices(new GetBLEDeviceServicesOption 
        {
            deviceId = "xx",
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

    public void getBLEDeviceRSSI() {
        WX.GetBLEDeviceRSSI(new GetBLEDeviceRSSIOption 
        {
            deviceId = "xx",
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

    public void getBLEDeviceCharacteristics() {
        WX.GetBLEDeviceCharacteristics(new GetBLEDeviceCharacteristicsOption 
        {
            deviceId = "xx",
            serviceId = "xx",
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

    private void OnDestroy() {
        WX.OffBLEMTUChange(_onBLEMTUChange);
        WX.OffBLEConnectionStateChange(_onBLEConnectionStateChange);
        WX.OffBLECharacteristicValueChange();
    }
}

