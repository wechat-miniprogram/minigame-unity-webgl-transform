using UnityEngine;

using WeChatWASM;

public class ADManager : MonoBehaviour
{
    public WXBannerAd BannerAd;
    public WXRewardedVideoAd RewardedVideoAd;
    public WXCustomAd CustomAd;

    private void Start()
    {
        WX.InitSDK((code) =>
        {
            CreateBannerAd();

            CreateRewardedVideoAd();

            CreateCustomAd();
        });
    }

    private void CreateBannerAd()
    {
        BannerAd = WX.CreateFixedBottomMiddleBannerAd("adunit-xxxxxxxxxxxxxxxx", 30, 200);
    }

    public void ShowBannerAd()
    {
        BannerAd.Show();
    }

    public void HideBannerAd()
    {
        BannerAd.Hide();
    }

    public void DestroyBannerAd()
    {
        BannerAd.Destroy();
    }

    private void CreateRewardedVideoAd()
    {
        RewardedVideoAd = WX.CreateRewardedVideoAd(new WXCreateRewardedVideoAdParam()
        {
            adUnitId = "adunit-xxxxxxxxxxxxxxxx",
        });
        RewardedVideoAd.OnLoad((res) =>
        {
            Debug.Log("RewardedVideoAd.OnLoad:" + JsonUtility.ToJson(res));
            var reportShareBehaviorRes = RewardedVideoAd.ReportShareBehavior(new RequestAdReportShareBehaviorParam()
            {
                operation = 1,
                currentShow = 1,
                strategy = 0,
                shareValue = res.shareValue,
                rewardValue = res.rewardValue,
                depositAmount = 100,
            });
            Debug.Log("ReportShareBehavior.Res:" + JsonUtility.ToJson(reportShareBehaviorRes));
        });
        RewardedVideoAd.OnError((err) =>
        {
            Debug.Log("RewardedVideoAd.OnError:" + JsonUtility.ToJson(err));
        });
        RewardedVideoAd.OnClose((res) =>
        {
            Debug.Log("RewardedVideoAd.OnClose:" + JsonUtility.ToJson(res));
        });
        RewardedVideoAd.Load();
    }

    public void ShowRewardedVideoAd()
    {
        RewardedVideoAd.Show();
    }

    public void DestroyRewardedVideoAd()
    {
        RewardedVideoAd.Destroy();
    }

    private void CreateCustomAd()
    {
        CustomAd = WX.CreateCustomAd(new WXCreateCustomAdParam()
        {
            adUnitId = "adunit-xxxxxxxxxxxxxxxx",
            adIntervals = 30,
            style = {
                left = 0,
                top = 100,
            },
        });
        CustomAd.OnLoad((res) =>
        {
            Debug.Log("CustomAd.OnLoad:" + JsonUtility.ToJson(res));
        });
        CustomAd.OnError((res) =>
        {
            Debug.Log("CustomAd.onError:" + JsonUtility.ToJson(res));
        });
        CustomAd.OnHide(() =>
        {
            Debug.Log("CustomAd.onHide:");
        });
        CustomAd.OnClose(() =>
        {
            Debug.Log("CustomAd.onClose");
        });
    }

    public void ShowCustomAd()
    {
        CustomAd.Show();
    }

    public void HideCustomAd()
    {
        CustomAd.Hide();
    }

    public void DestroyCustomAd()
    {
        CustomAd.Destroy();
    }

    private void OnDestroy()
    {
        DestroyBannerAd();
        DestroyRewardedVideoAd();
        DestroyCustomAd();
    }
}
