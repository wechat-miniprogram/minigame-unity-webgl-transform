using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class BluetoothDevice : Details
{

    private bool _isListening = false;
    private bool _isListeningDiscovery = false;

    private readonly Action<OnBluetoothDeviceFoundListenerResult> _onBluetoothDeviceFound = (res) =>
    {
        var result = "onBluetoothDeviceFound\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnBluetoothAdapterStateChangeListenerResult> _onBluetoothAdapterStateChange = (res) =>
    {
        var result = "onBluetoothAdapterStateChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };


    private void Start()
    {
        // 监听搜索到新设备的事件
        WX.OnBluetoothDeviceFound(_onBluetoothDeviceFound);

        // 监听蓝牙适配器状态变化事件
        WX.OnBluetoothAdapterStateChange(_onBluetoothAdapterStateChange);


        GameManager.Instance.detailsController.BindExtraButtonAction(0, bluetoothDevicesDiscovery);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, makeBluetoothPair);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, isBluetoothDevicePaired);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, getConnectedBluetoothDevices);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, getBluetoothDevices);
        GameManager.Instance.detailsController.BindExtraButtonAction(5, getBluetoothAdapterState);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        BluetoothAdapter();
    }

    public void BluetoothAdapter()
    {
        if (!_isListening)
        {
            WX.OpenBluetoothAdapter(new OpenBluetoothAdapterOption
            {
                mode = "peripheral",
                success = (res) =>
                {
                    Debug.Log("success " + JsonMapper.ToJson(res));
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
        else
        {
            WX.CloseBluetoothAdapter(new CloseBluetoothAdapterOption
            {
                success = (res) =>
                {
                    Debug.Log("success " + JsonMapper.ToJson(res));
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
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "关闭蓝牙模块" : "初始化蓝牙模块");
    }

    public void bluetoothDevicesDiscovery()
    {
        if (!_isListeningDiscovery)
        {
            WX.StartBluetoothDevicesDiscovery(new StartBluetoothDevicesDiscoveryOption
            {
                success = (res) =>
                {
                    Debug.Log("success " + JsonMapper.ToJson(res));
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
        else
        {
            WX.StopBluetoothDevicesDiscovery(new StopBluetoothDevicesDiscoveryOption
            {
                success = (res) =>
                {
                    Debug.Log("success " + JsonMapper.ToJson(res));
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
        _isListeningDiscovery = !_isListeningDiscovery;
        GameManager.Instance.detailsController.ChangeExtraButtonText(0, _isListeningDiscovery ? "停止搜寻蓝牙设备" : "开始搜寻蓝牙设备");
    }

    public void makeBluetoothPair()
    {
        WX.MakeBluetoothPair(new MakeBluetoothPairOption
        {
            deviceId = "xxx",
            pin = "xxx",
            timeout = 20000,
            success = (res) =>
            {
                Debug.Log("success " + JsonMapper.ToJson(res));
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

    public void isBluetoothDevicePaired()
    {
        WX.IsBluetoothDevicePaired(new IsBluetoothDevicePairedOption
        {
            deviceId = "xx",
            success = (res) =>
            {
                Debug.Log("success " + JsonMapper.ToJson(res));
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

    public void getConnectedBluetoothDevices()
    {
        WX.GetConnectedBluetoothDevices(new GetConnectedBluetoothDevicesOption
        {
            services = new string[] { "xx", "yy" },
            success = (res) =>
            {
                Debug.Log("success " + JsonMapper.ToJson(res));
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

    public void getBluetoothDevices()
    {
        WX.GetBluetoothDevices(new GetBluetoothDevicesOption
        {
            success = (res) =>
            {
                Debug.Log("success " + JsonMapper.ToJson(res));
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

    public void getBluetoothAdapterState()
    {
        WX.GetBluetoothAdapterState(new GetBluetoothAdapterStateOption
        {
            success = (res) =>
            {
                Debug.Log("success " + JsonMapper.ToJson(res));
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

    private void OnDestroy()
    {
        WX.OffBluetoothDeviceFound(_onBluetoothDeviceFound);
        WX.OffBluetoothAdapterStateChange(_onBluetoothAdapterStateChange);
    }
}