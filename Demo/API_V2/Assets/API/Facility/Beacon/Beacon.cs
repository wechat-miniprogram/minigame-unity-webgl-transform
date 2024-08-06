using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Beacon : Details
{

    private bool _isListening = false;

    private readonly Action<OnBeaconUpdateListenerResult> _onBeaconUpdate = (res) =>
    {
        var result = "onBeaconUpdate\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<OnBeaconServiceChangeListenerResult> _onBeaconServiceChange = (res) =>
    {
        var result = "onBeaconServiceChange\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, getBeacons);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (!_isListening)
        {
            startBeaconDiscovery();
            WX.OnBeaconUpdate(_onBeaconUpdate);
            WX.OnBeaconServiceChange(_onBeaconServiceChange);
        }
        else
        {
            stopBeaconDiscovery();
            WX.OffBeaconUpdate(_onBeaconUpdate);
            WX.OffBeaconServiceChange(_onBeaconServiceChange);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(_isListening ? "取消搜索" : "开始搜索");
    }

    public void startBeaconDiscovery()
    {
        //需要更改uuids才能监测到蓝牙-信标
        WX.StartBeaconDiscovery(new StartBeaconDiscoveryOption
        {
            uuids = new string[] { "xxxxxxxxxx" },
            success = (res) =>
            {
                Debug.Log(JsonUtility.ToJson(res));
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

    public void stopBeaconDiscovery()
    {
        WX.StopBeaconDiscovery(new StopBeaconDiscoveryOption
        {
            success = (res) =>
            {
                Debug.Log(JsonUtility.ToJson(res));
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

    public void getBeacons()
    {
        WX.GetBeacons(new GetBeaconsOption
        {
            success = (res) =>
            {
                Debug.Log(JsonUtility.ToJson(res));
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
        stopBeaconDiscovery();
        WX.OffBeaconUpdate(_onBeaconUpdate);
        WX.OffBeaconServiceChange(_onBeaconServiceChange);
    }
}