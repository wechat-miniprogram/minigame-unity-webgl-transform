using UnityEngine;
using WeChatWASM;
using LitJson;

public class PrivateMessage : Details
{
    protected override void TestAPI(string[] args)
    {

    }
        public void authPrivateMessage()
    {
        WX.AuthPrivateMessage(
            new AuthPrivateMessageOption
            {
                shareTicket = "xxxxxx",
                success = (res) =>
                {
                    Debug.Log("authPrivateMessage success" + JsonMapper.ToJson(res));
                    // res
                    // {
                    //   errMsg: 'authPrivateMessage:ok'
                    //   valid: true
                    //   iv: 'xxxx',
                    //   encryptedData: 'xxxxxx'
                    // }
                },
                fail = (res) =>
                {
                    Debug.Log("authPrivateMessage fail" + res.errMsg);
                }
            }
        );
    }
}
