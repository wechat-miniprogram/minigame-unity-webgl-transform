using UnityEngine;
using WeChatWASM;

public class ShareMenu : Details
{
    private bool _isShowingShare = false;

    protected override void TestAPI(string[] args)
    {
        showShareMenu();
    }

    public void showShareMenu()
    {
        _isShowingShare = !_isShowingShare;

        if (_isShowingShare)
        {
            WX.ShowShareMenu(
                new ShowShareMenuOption
                {
                    withShareTicket = true,
                    menus = new string[] { "shareAppMessage", "shareTimeline" },
                    success = (res) =>
                    {
                        ShowToast("已显示转发按钮");
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
        else
        {
            WX.HideShareMenu(
                new HideShareMenuOption
                {
                    menus = new string[] { "shareAppMessage", "shareTimeline" },
                    success = (res) =>
                    {
                        ShowToast("已隐藏转发按钮");
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

        GameManager.Instance.detailsController.ChangeInitialButtonText(
            _isShowingShare ? "隐藏转发按钮" : "显示转发按钮"
        );
    }

    private void ShowToast(string message)
    {
        WX.ShowToast(new ShowToastOption()
        {
            title = message,
            icon = "none",
            duration = 1500,
            mask = false
        });
    }

    private void OnDestroy()
    {
        WX.ShowShareMenu(
            new ShowShareMenuOption
            {
                withShareTicket = true,
                menus = new string[] { "shareAppMessage", "shareTimeline" },
            }
        );
    }
}