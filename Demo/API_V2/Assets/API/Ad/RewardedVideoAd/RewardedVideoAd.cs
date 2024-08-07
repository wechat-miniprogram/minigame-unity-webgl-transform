using UnityEngine;
using WeChatWASM;

public class RewardedVideoAd : Details
{
    private WXRewardedVideoAd _rewardedVideoAd;

    private void Start()
    {
        // 绑定按钮事件
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ShowAd);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, DestroyAd);
    }

    // 创建激励视频广告组件并挂载事件、预加载广告
    protected override void TestAPI(string[] args)
    {
        // 创建激励视频广告组件
        _rewardedVideoAd = WX.CreateRewardedVideoAd(
            new WXCreateRewardedVideoAdParam()
            {
                // adUnitId 请填写自己的广告位 ID
                adUnitId = "adunit-xxxxxxxxxxxxxxxx"
            }
        );

        _rewardedVideoAd.OnLoad(
            (res) =>
            {
                WX.ShowModal(
                    new ShowModalOption()
                    {
                        content = "RewardedVideoAd OnLoad Result:" + JsonUtility.ToJson(res)
                    }
                );
            }
        );
        _rewardedVideoAd.OnError(
            (res) =>
            {
                WX.ShowModal(
                    new ShowModalOption()
                    {
                        content = "RewardedVideoAd onError Result:" + JsonUtility.ToJson(res)
                    }
                );
            }
        );
        _rewardedVideoAd.OnClose(
            (res) =>
            {
                WX.ShowModal(
                    new ShowModalOption()
                    {
                        content = "RewardedVideoAd onClose Result:" + JsonUtility.ToJson(res)
                    }
                );
            }
        );
        // 预加载广告
        _rewardedVideoAd.Load();

        WX.ShowToast(new ShowToastOption() { title = "已创建并加载广告" });
    }

    // 展示广告
    private void ShowAd()
    {
        _rewardedVideoAd.Show();
        WX.ShowToast(new ShowToastOption() { title = "已展示广告" });
    }

    // 销毁广告
    private void DestroyAd()
    {
        _rewardedVideoAd.Destroy();
        WX.ShowToast(new ShowToastOption() { title = "已销毁广告" });
    }

    private void OnDestroy()
    {
        _rewardedVideoAd.Destroy();
    }
}
