using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Performance : Details
{
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, reportPerformance);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        triggerGC();
    }

    public void triggerGC()
    {
        WX.TriggerGC();
        WX.ShowToast(new ShowToastOption()
        {
            title = "成功调用triggerGC"
        });
    }

    public void reportPerformance()
    {
        WX.ReportPerformance(1101, 6880, "custom");
        WX.ShowToast(new ShowToastOption()
        {
            title = "成功上报"
        });
    }


}