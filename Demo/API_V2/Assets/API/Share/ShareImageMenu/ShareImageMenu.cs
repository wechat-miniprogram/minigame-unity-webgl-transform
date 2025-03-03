using WeChatWASM;
using UnityEngine;

public class ShowShareImageMenu : Details
{
    protected override void TestAPI(string[] args)
    {
        showShareImageMenu();
    }
    public void showShareImageMenu()
    {
        WX.DownloadFile(
            new DownloadFileOption
            {
                url = "https://res.wx.qq.com/wxdoc/dist/assets/img/demo.ef5c5bef.jpg",
                success = (res) =>
                {
                    WX.ShowShareImageMenu(
                        new ShowShareImageMenuOption
                        {
                            path = res.tempFilePath,
                            style = "default",
                            success = (res) =>
                            {
                                Debug.Log("success");
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
            }
        );
    }
}