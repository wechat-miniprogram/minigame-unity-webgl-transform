using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class Download : Details
{

    private WXDownloadTask _downloadTask;

    private readonly Action<DownloadTaskOnHeadersReceivedListenerResult> _onHeadersReceived = (res) => {
        var result = "onHeadersReceived\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    private readonly Action<DownloadTaskOnProgressUpdateListenerResult> _onProgressUpdate = (res) => {
        var result = "onProgressUpdate\n" + JsonMapper.ToJson(res);
        GameManager.Instance.detailsController.AddResult(new ResultData()
        {
            initialContentText = result
        });
    };

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        // 填入具体的url和其它参数
        _downloadTask = WX.DownloadFile(new DownloadFileOption 
        {
            url = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
            success = (res) => {
                // Debug.Log(JsonMapper.ToJson(res));
                
            },
            fail = (res) => {
                Debug.Log("fail: " + res.errMsg);
            },
            complete = (res) => {
                Debug.Log("complete");
            }
        });

        _downloadTask.OnHeadersReceived(_onHeadersReceived);
        _downloadTask.OnProgressUpdate(_onProgressUpdate);
    }

    public void abort() {
        _downloadTask.Abort();
    }
}

