using UnityEngine;
using WeChatWASM;

public class BannerAd : Details
{
    private WXBannerAd _bannerAd;
    
    private bool _isShow = false;
    
    private void Start()
    {
        // 绑定按钮事件
        GameManager.Instance.detailsController.BindExtraButtonAction(0, SwitchAdState);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, DestroyAd);
    }

    // 创建预设的 Banner 广告组件并挂载事件
    // 如需自定义style请调用WX.CreateBannerAd(WXCreateBannerAdParam param)接口
    protected override void TestAPI(string[] args)
    {
        // adUnitId 请填写自己的广告位 ID
        // 创建预设的 Banner 广告
        _bannerAd = WX.CreateFixedBottomMiddleBannerAd("adunit-xxxxxxxxxxxxxxxx", 30, 200);
        
        _bannerAd.OnLoad((res) =>
        {
            WX.ShowModal(new ShowModalOption()
            {
                content = "BannerAd OnLoad Result:" + JsonUtility.ToJson(res)
            });
        });
        _bannerAd.OnError((res) =>
        {
            WX.ShowModal(new ShowModalOption()
            {
                content = "BannerAd onError Result:" + JsonUtility.ToJson(res)
            });
        });
        _bannerAd.OnResize((res) =>
        {
            WX.ShowModal(new ShowModalOption()
            {
                content = "BannerAd onResize Result:" + JsonUtility.ToJson(res)
            });
        });
        
        WX.ShowToast(new ShowToastOption()
        {
            title = "已创建广告"
        });
    }

    // 切换广告显示状态
    private void SwitchAdState()
    {
        if (_isShow)
        {
            // 隐藏广告
            _bannerAd.Hide();
            WX.ShowToast(new ShowToastOption()
            {
                title = "已隐藏广告"
            });
        }
        else
        {
            // 展示广告
            _bannerAd.Show();
            WX.ShowToast(new ShowToastOption()
            {
                title = "已展示广告"
            });
        }
    }

    // 销毁广告
    private void DestroyAd()
    {
        _bannerAd.Destroy();
        WX.ShowToast(new ShowToastOption()
        {
            title = "已销毁广告"
        });
    }

    private void OnDestroy()
    {
        _bannerAd.Destroy();
    }
}
