using System;
namespace WeChatWASM
{
    //插屏广告组件广告,详见 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/ad/interstitialAd-ad.html
    public class WXInterstitialAd : WXBaseAd, IWXADCloseable
    {
        public WXInterstitialAd(string id) : base(id)
        {

        }
        public Action onCloseAction;

        /// <summary>
        /// 加载插屏广告
        /// </summary>
        public void Load(Action<WXTextResponse> success = null, Action<WXADErrorResponse> failed = null)
        {
            WXSDKManagerHandler.Instance.ADLoad(instanceId, WXCallBackHandler.Add(success), WXCallBackHandler.Add(failed));
        }

        /// <summary>
        /// 监听插屏广告关闭事件
        /// </summary>
        /// <param name="action">插屏广告关闭事件的回调函数</param>
        public void OnClose(Action action)
        {
            onCloseAction += action;
        }

        /// <summary>
        /// 取消监听插屏广告关闭事件
        /// </summary>
        /// <param name="action">插屏广告关闭事件的回调函数</param>
        public void OffClose(Action action)
        {
            onCloseAction -= action;
        }

        public void OnCloseCallback()
        {
            onCloseAction?.Invoke();
        }
    }
}