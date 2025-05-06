using WeChatWASM;
using UnityEngine;
using LitJson;
using System;
using UnityEditor;

public class ShareInfo : Details
{
    private static bool isSetupInitialized = false;
    private string CloudID;

    protected override void TestAPI(string[] args)
    {
        if (!isSetupInitialized)
        {
            GetShareInfoButton();
            isSetupInitialized = true;
        }
        else
        {
            Debug.Log("Share setup already initialized, skip initialization.");
        }
    }

    // 分享信息按钮
    private void GetShareInfoButton()
    {
        InitCloudFunction();//初始化云函数
        WX.UpdateShareMenu(new UpdateShareMenuOption
        {
            withShareTicket = true,
            success = (res) =>
            {
                Debug.Log("分享菜单配置成功");
            },
            fail = (res) =>
            {
                Debug.Log("分享菜单配置失败");
            }
        });
        WX.OnShow((res) =>
        {
            Debug.Log("Scene:" + res.scene);
            Debug.Log("shareTicket:" + res.shareTicket);
            Debug.Log("chatType:" + res.chatType);

            GetShareInfo(res.shareTicket);
        });
    }

    // 获取分享Shareticket信息
    private void GetShareInfo(string shareTicket)
    {
        if (string.IsNullOrEmpty(shareTicket))
        {
            Debug.LogError("shareTicket is empty!");
            return;
        }
        
        // 获取转发详细信息
        WX.GetShareInfo(
            new GetShareInfoOption
            {
                shareTicket = shareTicket,
                timeout = 2000,
                success = (res) =>
                {
                    Debug.Log("GetShareInfo success");
                    Debug.Log("encryptedData:" + res.encryptedData);
                    Debug.Log("iv:" + res.iv);
                    Debug.Log("CloudID:" + res.cloudID);
                    CloudID = res.cloudID;
                    CloudCallFunction();// 传入CloudID调用
                },
                fail = (res) =>
                {
                    Debug.Log("GetShareInfo fail:" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("GetShareInfo complete");
                }
            }
        );

        // 从基础库 v2.17.3 开始，推荐用 wx.getGroupEnterInfo 替代wx.getShareInfo接口
        WX.GetGroupEnterInfo(new GetGroupEnterInfoOption
        {
            success = (res) =>
            {
                Debug.Log("GetGroupEnterInfo success");
                Debug.Log("errMsg:" + res.errMsg);
                Debug.Log("encryptedData:" + res.encryptedData);
                Debug.Log("iv:" + res.iv);
                Debug.Log("CloudID:" + res.cloudID);
                //CloudID = res.cloudID;
                //CloudCallFunction();// 传入CloudID调用
            },
            fail = (res) =>
            {
                Debug.Log("GetGroupEnterInfo fail:" + res.errMsg);
            },
            complete = (res) =>
            {
                Debug.Log("GetGroupEnterInfo complete");
            }
        });
    }
    // 初始化云函数
    private void InitCloudFunction()
    {
        WX.cloud.Init(new ICloudConfig
        {
            env = "dev-h504y"//需填入 云开发环境ID
        }); 
    }
    // data
    private class CloudCallFunctionData
    {
        public string shareCloudData;
    }

    // 调用云函数
    private void CloudCallFunction()
    {
        var data = new CloudCallFunctionData()
        {
            shareCloudData = WX.cloud.CloudID(CloudID), // 通过GetShareInfo接口获取的CloudID
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
}