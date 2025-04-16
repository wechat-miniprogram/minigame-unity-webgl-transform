using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using WeChatWASM;

public class ReportEvent : Details
{
    // 测试 API
    protected override void TestAPI(string[] args)
    {
        Report(args[0], int.Parse(args[1]));
    }

    // 事件上报
    private void Report(string stringData, int intData)
    {
        var eventData = new Dictionary<string, string>
        {
            { "stringData", stringData },
            { "intData", intData.ToString() }
        };

        WX.ReportEvent("test", eventData);

        // 显示成功的提示
        WX.ShowToast(new ShowToastOption() { title = "事件已上传，可以到we分析平台中查看" });
    }
}
