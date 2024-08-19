using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class Render : Details
{
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, loadFont);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        setFPS();
    }

    public void setFPS()
    {
        Application.targetFrameRate = 30;
    }

    public void loadFont()
    {
        var font = WX.LoadFont("TencentSans-W7.subset.ttf");
        Debug.Log(font);
    }

    public void Destroy()
    {
        Application.targetFrameRate = 60;
    }
}
