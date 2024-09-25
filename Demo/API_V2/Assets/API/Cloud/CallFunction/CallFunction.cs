using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class CallFunction : Details
{
    // data
    private class CloudCallFunctionData
    {
        public int NormalData;
        public string WeRunData;
        public string BigData1;
        public string BigData2;
        public CloudCallFunctionDataObj Obj;
    }
    private class CloudCallFunctionDataObj
    {
        public string BigData3;
        public string ShareInfo;
    }

    private string CloudID; // 通过其他接口获取的CloudID

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, CloudCallFunctionByInstance);

        WX.GetUserInfo(new GetUserInfoOption() // 获取敏感数据对应的CloudID
        {
            success = (res) =>
            {
                CloudID = res.cloudID;
            }
        });
    }

    protected override void TestAPI(string[] args)
    {
        this.CloudCallFunction();
    }

    // 使用默认云开发操作实例调用云函数
    private void CloudCallFunction()
    {
        WX.cloud.Init(); // 注意初始化

        var obj = new CloudCallFunctionDataObj()
        {
            BigData3 = WX.cloud.CDN(new ICDNFilePathSpec()
            {
                type = "filePath", // 此项必填filePath
                filePath = "/7865-xxx-xxx-xxx/xxx.png", // 替换为实际的文件路径
            }), // 参数为文件路径定义对象
            ShareInfo = WX.cloud.CloudID(CloudID), // 通过其他接口获取的CloudID
        };
        var data = new CloudCallFunctionData()
        {
            NormalData = 111,
            WeRunData = WX.cloud.CloudID(CloudID), // 通过其他接口获取的CloudID
            BigData1 = WX.cloud.CDN("some large string"), // 参数为字符串
            BigData2 = WX.cloud.CDN(new byte[] { 1, 2, 3, 4 }), // 参数为byte[]
            Obj = obj,
        };

        WX.cloud.CallFunction(new CallFunctionParam()
        {
            name = "myFunction", // 须在云函数侧创建对应函数
            data = data,
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallFunction Success: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallFunction Fail: " + JsonMapper.ToJson(res)
                });
            },
            complete = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallFunction Complete: " + JsonMapper.ToJson(res)
                });
            }
        });
    }

    // 新建云开发操作实例调用云函数
    private void CloudCallFunctionByInstance()
    {
        var clo = WX.cloud.Cloud(new ICloudInstanceOptions()
        {
            resourceEnv = "cloud1-xxx", // 云开发环境ID，通过创建云开发环境获取
        });

        clo.Init(); // 注意初始化

        var obj = new CloudCallFunctionDataObj()
        {
            BigData3 = clo.CDN(new ICDNFilePathSpec()
            {
                type = "filePath", // 此项必填filePath
                filePath = "/7865-xxx-xxx-xxx/xxx.png", // 替换为实际的文件路径
            }), // 参数为文件路径定义对象
            ShareInfo = clo.CloudID(CloudID), // 通过其他接口获取的CloudID
        };
        var data = new CloudCallFunctionData()
        {
            NormalData = 111,
            WeRunData = clo.CloudID(CloudID), // 通过其他接口获取的CloudID
            BigData1 = clo.CDN("some large string"), // 参数为字符串
            BigData2 = clo.CDN(new byte[] { 1, 2, 3, 4 }), // 参数为byte[]
            Obj = obj,
        };

        clo.CallFunction(new CallFunctionParam()
        {
            name = "myFunction", // 须在云函数侧创建对应函数
            data = data,
            success = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallFunction Success: " + JsonMapper.ToJson(res)
                });
            },
            fail = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallFunction Fail: " + JsonMapper.ToJson(res)
                });
            },
            complete = (res) =>
            {
                WX.ShowModal(new ShowModalOption()
                {
                    content = "Cloud CallFunction Complete: " + JsonMapper.ToJson(res)
                });
            }
        });
    }
}
