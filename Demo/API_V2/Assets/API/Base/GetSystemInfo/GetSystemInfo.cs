using LitJson;
using WeChatWASM;

public class GetInfo : Details
{
    private void Start()
    {
        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, getAppAuthorizeSetting);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, getDeviceInfo);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, getWindowInfo);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, getAppBaseInfo);
        // GameManager.Instance.detailsController.BindExtraButtonAction(1, getSystemInfoSync);
        // GameManager.Instance.detailsController.BindExtraButtonAction(2, getSystemInfoAsync);
        // GameManager.Instance.detailsController.BindExtraButtonAction(3, getSystemInfo);
        GameManager.Instance.detailsController.BindExtraButtonAction(4, getLaunchOptionsSync);
        GameManager.Instance.detailsController.BindExtraButtonAction(5, getEnterOptionsSync);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        getSystemSetting();
    }

    public void getSystemSetting()
    {
        var res = WX.GetSystemSetting();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
        );
    }

    public void getAppAuthorizeSetting()
    {
        var res = WX.GetAppAuthorizeSetting();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
        );
    }

    public void getDeviceInfo()
    {
        var res = WX.GetDeviceInfo();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
        );
    }

    public void getWindowInfo()
    {
        var res = WX.GetWindowInfo();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
        );
    }

    public void getAppBaseInfo()
    {
        var res = WX.GetAppBaseInfo();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
        );
    }

    // public void getSystemInfoSync()
    // {
    //     var res = WX.GetSystemInfoSync();
    //
    //     // 访问成功，显示结果
    //     WX.ShowModal(
    //         new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
    //     );
    // }
    //
    // public void getSystemInfoAsync()
    // {
    //     WX.GetSystemInfoAsync(
    //         new GetSystemInfoAsyncOption
    //         {
    //             success = (res) =>
    //             {
    //                 WX.ShowModal(
    //                     new ShowModalOption()
    //                     {
    //                         content = "Access Success, Result: " + JsonMapper.ToJson(res)
    //                     }
    //                 );
    //             },
    //             fail = (res) =>
    //             {
    //                 Debug.Log("fail:" + res.errMsg);
    //             },
    //             complete = (res) =>
    //             {
    //                 Debug.Log("complete!");
    //             }
    //         }
    //     );
    // }
    //
    // public void getSystemInfo()
    // {
    //     WX.GetSystemInfo(
    //         new GetSystemInfoOption
    //         {
    //             success = (res) =>
    //             {
    //                 WX.ShowModal(
    //                     new ShowModalOption()
    //                     {
    //                         content = "Access Success, Result: " + JsonMapper.ToJson(res)
    //                     }
    //                 );
    //             },
    //             fail = (res) =>
    //             {
    //                 Debug.Log("fail:" + res.errMsg);
    //             },
    //             complete = (res) =>
    //             {
    //                 Debug.Log("complete!");
    //             }
    //         }
    //     );
    // }

    public void getLaunchOptionsSync()
    {
        var res = WX.GetLaunchOptionsSync();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
        );
    }

    public void getEnterOptionsSync()
    {
        var res = WX.GetEnterOptionsSync();

        // 访问成功，显示结果
        WX.ShowModal(
            new ShowModalOption() { content = "Access Success, Result: " + JsonMapper.ToJson(res) }
        );
    }
}
