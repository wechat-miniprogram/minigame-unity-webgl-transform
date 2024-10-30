using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class CallContainer : Details
{
    // data
    private class CloudCallContainerData
    {
        public string action;
    }

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, CloudCallContainerByInstance);
    }

    protected override void TestAPI(string[] args)
    {
        this.CloudCallContainer();
    }

    // 使用默认云开发操作实例调用云托管
    private void CloudCallContainer()
    {
        WX.cloud.Init(); // 注意初始化

        var data = new CloudCallContainerData()
        {
            action = "inc"
        };

        WX.cloud.CallContainer(new CallContainerParam()
        {
            config = new ICloudConfig()
            {
                env = "prod-xxx", // 云托管环境ID，通过创建云托管服务获取
            },
            path = "/api/count", // 服务路径
            header = new Dictionary<string, string>() // 设置请求的 header，header 中不能设置 Referer。content-type 默认为 application/json
            {
                { "X-WX-SERVICE", "express-hodt" }
            },
            method = "POST", // HTTP 请求方法
            data = JsonMapper.ToJson(data), // 请求数据
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallContainer Success: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallContainer Fail: " + JsonMapper.ToJson(res)
                });
            },
            complete = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallContainer Complete: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 新建云开发操作实例调用云托管
    private void CloudCallContainerByInstance()
    {
        var clo = WX.cloud.Cloud(new ICloudInstanceOptions()
        {
            resourceEnv = "cloud1-xxx", // 云开发环境ID，通过创建云开发环境获取
        });

        clo.Init(); // 注意初始化

        var data = new CloudCallContainerData()
        {
            action = "inc"
        };

        clo.CallContainer(new CallContainerParam()
        {
            config = new ICloudConfig()
            {
                env = "prod-xxx", // 云托管环境ID，通过创建云托管服务获取
            },
            path = "/api/count", // 服务路径
            header = new Dictionary<string, string>() // 设置请求的 header，header 中不能设置 Referer。content-type 默认为 application/json
            {
                { "X-WX-SERVICE", "express-hodt" }
            },
            method = "POST", // HTTP 请求方法
            data = JsonMapper.ToJson(data), // 请求数据
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallContainer Success: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallContainer Fail: " + JsonMapper.ToJson(res)
                });
            },
            complete = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallContainer Complete: " + JsonMapper.ToJson(res)
                });
            }
        });
    }
}
