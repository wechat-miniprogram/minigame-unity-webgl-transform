using UnityEngine;
using WeChatWASM;

public class ShareMenu : Details
{
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, hideShareMenu);
    }
    protected override void TestAPI(string[] args)
    {
        showShareMenu();
    }

    public void showShareMenu()
    {
        WX.ShowShareMenu(
            new ShowShareMenuOption
            {
                withShareTicket = true,
                menus = new string[] { "shareAppMessage", "shareTimeline" },
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

    public void hideShareMenu()
    {
        WX.HideShareMenu(
            new HideShareMenuOption
            {
                menus = new string[] { "shareAppMessage", "shareTimeline" },
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