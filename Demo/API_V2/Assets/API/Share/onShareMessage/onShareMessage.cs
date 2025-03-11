using WeChatWASM;
using System;
using LitJson;
using UnityEngine;

public class onShareMessage : Details
{
    protected override void TestAPI(string[] args)
    {
        updateShareMenu();
    }
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, onShareAppMessage);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, ShareAppMessage);
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
    }
    public void onShareAppMessage()
    {
        var defaultParam = new WXShareAppMessageParam
        {
            title = "转发标题",
            imageUrl = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
            query = "key1=val1&key2=val2"
        };
        WX.OnShareAppMessage(defaultParam);
    }

    public void offShareAppMessage()
    {
        var defaultParam = new WXShareAppMessageParam
        {
            title = default,
            imageUrl = "xxx",
            query = "key1=val1&key2=val2"
        };
        WX.OnShareAppMessage(defaultParam);
    }

    private void ShareAppMessage()
    {
        WX.ShareAppMessage(new ShareAppMessageOption() { title = "小游戏分享" });
    }
    private void OnDestroy()
    {
        offShareAppMessage();
    }
}