using UnityEngine;
using WeChatWASM;

public class setShareMenu : Details
{
    protected override void TestAPI(string[] args)
    {
        updateShareMenu();
    }
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, setMessageToFriendQuery);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, setHandoffQuery);
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
    public void setMessageToFriendQuery()
    {
        var isSuccess = WX.SetMessageToFriendQuery(
            new SetMessageToFriendQueryOption { shareMessageToFriendScene = 1, query = "abcd" }
        );
        WX.ShowToast(new ShowToastOption { title = isSuccess ? "true" : "false" });
    }

    public void setHandoffQuery()
    {
        var isSuccess = WX.SetHandoffQuery("xxx");
        WX.ShowToast(new ShowToastOption { title = isSuccess ? "true" : "false" });
    }
}