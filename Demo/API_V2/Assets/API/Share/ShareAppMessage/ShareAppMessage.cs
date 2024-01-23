using UnityEngine;
using WeChatWASM;

public class ShareAppMessage: Details
{
    // 测试 API
    protected override void TestAPI(string[] args) {
        Share();        
    }

    // 分享
    private void Share() {
        WX.ShareAppMessage(new ShareAppMessageOption() {
            title = "小游戏分享"
        });
    }
    
}
