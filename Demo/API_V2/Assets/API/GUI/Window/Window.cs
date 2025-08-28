using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Window : Details
{
    private bool _isListening = false;
    private float timer = 0f;
    private float interval = 5f; // 定时器间隔

    private readonly Action<OnWindowResizeListenerResult> _onWindowResize = (res) =>
    {
        var result = "onWindowResize\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(
            new ResultData() { initialContentText = result }
        );
    };

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (!_isListening)
        {
            WX.OnWindowResize(_onWindowResize);
        }
        else
        {
            WX.OffWindowResize(_onWindowResize);
        }
        _isListening = !_isListening;
        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isListening ? "取消监听" : "开始监听"
        );
    }

    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, setDeviceOrientation);
    }

    private void Update()
    {
        if(timer >= 20f){
            timer += Time.deltaTime; // 每帧累加时间
            Debug.Log(timer);
        }
        if (timer >= interval + 20)
        {
                Debug.Log("定时器触发！");
                WX.SetDeviceOrientation(new SetDeviceOrientationOption()
                {
                    value = "portrait",
                });
                timer = 0f; // 重置计时器（如果是周期性触发则不需要重置）
        }
    }

    private void setDeviceOrientation()
    {
        Debug.Log("设置为横屏");
        WX.SetDeviceOrientation(new SetDeviceOrientationOption()
        {
            value = "landscape",
        });

        timer = 20f;
    }
    private void OnDestroy()
    {
        WX.OffWindowResize(_onWindowResize);
    }
}
