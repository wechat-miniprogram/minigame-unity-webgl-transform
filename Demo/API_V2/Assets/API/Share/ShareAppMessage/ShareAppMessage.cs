using WeChatWASM;
using System;
using LitJson;
using UnityEngine;

public class ShareAppMessage : Details
{
    protected override void TestAPI(string[] args)
    {
        updateShareMenu();
    }
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ShareAppMessages);
    }
    public void updateShareMenu()
    {
        var parameter = new UpdatableMessageFrontEndParameter[]
        {
            new UpdatableMessageFrontEndParameter { name = "xxx", value = "yyy" },
            new UpdatableMessageFrontEndParameter { name = "zz", value = "kk" }
        };

        var info = new UpdatableMessageFrontEndTemplateInfo { parameterList = parameter, templateId = "模板id" };

        WX.UpdateShareMenu(
            new UpdateShareMenuOption
            {
                isPrivateMessage = true,
                isUpdatableMessage = true,
                activityId = "xxx",
                templateInfo = info,
                success = (res) =>
                {
                    WX.ShowToast(new ShowToastOption { title = "设置成功" });
                },
                fail = (res) =>
                {
                    Debug.Log("fail" + res.errMsg);
                },
                complete = (res) =>
                {
                    Debug.Log("complete");
                }
            }
        );
        WX.OnShow((res) =>
                    {
                        Debug.Log("Scene:" + res.scene);
                        Debug.Log("shareTicket:" + res.shareTicket);
                        Debug.Log("chatType:" + res.chatType);
                    });
    }

    private void ShareAppMessages()
    {
        WX.ShareAppMessage(new ShareAppMessageOption() { title = "小游戏分享" });
    }
}