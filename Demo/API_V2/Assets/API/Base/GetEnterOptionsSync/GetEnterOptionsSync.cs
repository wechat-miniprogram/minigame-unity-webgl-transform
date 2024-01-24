using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class GetEnterOptionsSync : Details
{
    // 测试 API
    protected override void TestAPI(string[] args)
    {
        getEnterOptionsSync();
    }
    public void getEnterOptionsSync()
    {
        var res = WX.GetEnterOptionsSync();

        // 结果显示
        var result = JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    }
}
