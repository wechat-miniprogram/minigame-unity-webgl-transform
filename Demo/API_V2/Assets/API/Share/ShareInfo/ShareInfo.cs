using WeChatWASM;
using UnityEngine;

public class ShareInfo : Details

{
    protected override void TestAPI(string[] args)
    {
        getShareInfo();
    }
    public void getShareInfo()
    {
        WX.GetShareInfo(
            new GetShareInfoOption
            {
                shareTicket = "xxx",
                timeout = 2000,
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
