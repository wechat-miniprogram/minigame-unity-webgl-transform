using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Location : Details
{
    // 测试 API
    protected override void TestAPI(string[] args)
    {
        getFuzzyLocation();
    }

    public void getFuzzyLocation() {
        WX.GetFuzzyLocation(new GetFuzzyLocationOption
        {
            type = "wgs84",
            success = (res) => 
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Access Success, Result: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                Debug.Log("fail:" + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("complete!");
            }
        }); 
    }
}
