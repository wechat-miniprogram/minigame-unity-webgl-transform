using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class RealtimeLog : Details {
    private WXRealtimeLogManager _log;

    private void Start() {
        _log = WX.GetRealtimeLogManager();
        _log.AddFilterMsg("test");

        GameManager.Instance.detailsController.BindExtraButtonAction(0, warn);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, error);
    }

    // 测试 API
    protected override void TestAPI(string[] args) {
        _log.Info("info msg");
    }

    private void error() {
        _log.Error("error msg");
    }

    private void warn() {
        _log.Warn("warn msg");
    }
}