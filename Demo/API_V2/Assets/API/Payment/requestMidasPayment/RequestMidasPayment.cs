using System;
using WeChatWASM;
using UnityEngine;
public class RequestMidasPayment : Details {
    // 测试 API
    protected override void TestAPI(string[] args) {
        pay();
    }
    public void pay() {
        // 补充自己的信息，才能使用
        WX.RequestMidasPayment(new RequestMidasPaymentOption() {
            mode = "game",
            env = 0,
            offerId = "xxxx", //在米大师侧申请的应用 id
            currencyType = "CNY",
            success = (res) => {
                Debug.Log("pay success!");
            },
            fail = (res) => {
                Debug.Log("pay fail:" + res.errMsg);
            }
        });

        // 显示成功的提示
        WX.ShowToast(new ShowToastOption() {
            title = "已调用虚拟支付"
        });
    }
}