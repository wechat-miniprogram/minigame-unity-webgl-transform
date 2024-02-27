using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class BLEPeripheral : Details
{

    private bool _isListening = false;
    private BLEPeripheralServer _server;

    private readonly Action<OnBLEPeripheralConnectionStateChangedListenerResult> _onBLEPeripheralConnectionStateChanged = (res) => {
        var result = "onBLEPeripheralConnectionStateChanged\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnCharacteristicReadRequestListenerResult> _onCharacteristicReadRequest = (res) => {
        var result = "onCharacteristicReadRequest\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnCharacteristicSubscribedListenerResult> _onCharacteristicSubscribed = (res) => {
        var result = "onCharacteristicSubscribed\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnCharacteristicSubscribedListenerResult> _onCharacteristicUnsubscribed = (res) => {
        var result = "onCharacteristicUnsubscribed\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnCharacteristicWriteRequestListenerResult> _onCharacteristicWriteRequest = (res) => {
        var result = "onCharacteristicWriteRequest\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private void Start()
    {
        WX.CreateBLEPeripheralServer(new CreateBLEPeripheralServerOption 
        {
            success = (res) => {
                Debug.Log("success " + JsonMapper.ToJson(res));
                _server = res.server;
            },
            fail = (res) => {
                Debug.Log("fail" + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });

        // 监听当前外围设备被连接或断开连接事件
        WX.OnBLEPeripheralConnectionStateChanged(_onBLEPeripheralConnectionStateChanged);

        GameManager.Instance.detailsController.BindExtraButtonAction(0, removeService);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, startAdvertising);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, stopAdvertising);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, writeCharacteristicValue);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, listen);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        addService();
    }

    public void addService() {
        var permission1 = new CharacteristicPermission {
            readable = true,
            writeable = true
        };

        var properties1 = new CharacteristicProperties {
            write = true,
            read = true,
            notify = true,
            indicate = true
        };

        var descriptorpermission1 = new DescriptorPermission {
            read = true,
            write = true,
        };

        var descriptors1 = new Descriptor {
            uuid = "zz",
            permission = descriptorpermission1,
            value = new byte[] {1, 2, 3}
        };

        var characteristics1 = new Characteristic {
            uuid = "yy",
            descriptors = new Descriptor[] { descriptors1 },
            permission = permission1,
            properties = properties1,
        };

       var service1 = new BLEPeripheralService {
            uuid = "xx",
            characteristics = new Characteristic[] { characteristics1 }
       };

       _server.addService(new AddServiceOption 
       {
            service = service1,
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

    public void removeService() {
        _server.removeService(new RemoveServiceOption 
        {
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

    public void startAdvertising() {
        var beacon1 = new BeaconInfoObj {
            major = 100,
            minor = 90,
            uuid = "zzzzz",
            measuredPower = 1000
        };

        var manufacturerData1 = new ManufacturerData {
            manufacturerId = "0x1111",
            manufacturerSpecificData = new byte[] {1, 2, 3}
        };

        var advertiseRequest1 = new AdvertiseReqObj {
            beacon = beacon1,
            connectable = true,
            deviceName = "x",
            manufacturerData = new ManufacturerData[] { manufacturerData1 },
            serviceUuids = new string[] {"xx", "yy", "aa"}
        };

        _server.startAdvertising(new StartAdvertisingObject 
        {
            advertiseRequest = advertiseRequest1,
            powerLevel = "medium",
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

    public void stopAdvertising() {
        _server.stopAdvertising(new StopAdvertisingOption 
        {
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

    public void writeCharacteristicValue() {
        _server.writeCharacteristicValue(new WriteCharacteristicValueObject 
        {
            characteristicId = "xx",
            needNotify = true,
            serviceId = "yy",
            value = new byte[] {1, 2, 3},
            callbackId = 100,
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

    public void listen() {
        if (!_isListening) {
            _server.onCharacteristicReadRequest(_onCharacteristicReadRequest);
            _server.onCharacteristicSubscribed(_onCharacteristicSubscribed);
            _server.onCharacteristicUnsubscribed(_onCharacteristicUnsubscribed);
            _server.onCharacteristicWriteRequest(_onCharacteristicWriteRequest);
        } else {
            _server.offCharacteristicReadRequest(_onCharacteristicReadRequest);
            _server.offCharacteristicSubscribed(_onCharacteristicSubscribed);
            _server.offCharacteristicUnsubscribed(_onCharacteristicUnsubscribed);
            _server.offCharacteristicWriteRequest(_onCharacteristicWriteRequest);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeExtraButtonText(4, _isListening ? "取消监听" : "开始监听");
    }

    private void OnDestroy() {
        WX.OffBLEPeripheralConnectionStateChanged(_onBLEPeripheralConnectionStateChanged);
        _server.offCharacteristicReadRequest(_onCharacteristicReadRequest);
        _server.offCharacteristicSubscribed(_onCharacteristicSubscribed);
        _server.offCharacteristicUnsubscribed(_onCharacteristicUnsubscribed);
        _server.offCharacteristicWriteRequest(_onCharacteristicWriteRequest);
        _server = null;
    }
}

