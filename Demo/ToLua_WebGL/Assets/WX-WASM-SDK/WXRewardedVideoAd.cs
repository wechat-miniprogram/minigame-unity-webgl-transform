using System;

namespace WeChatWASM
{
    /// <summary>
    /// 激励视频广告，详见 https://developers.weixin.qq.com/minigame/dev/guide/open-ability/ad/rewarded-video-ad.html
    /// </summary>
    public class WXRewardedVideoAd : WXBaseAd, IWXAdVideoCloseable
    {
        public WXRewardedVideoAd(string id) : base(id)
        {

        }

        public void OnCloseCallback(WXRewardedVideoAdOnCloseResponse res)
        {
            onCloseAction?.Invoke(res);
        }


        public Action<WXRewardedVideoAdOnCloseResponse> onCloseAction;
        /// <summary>
        /// 加载激励视频广告
        /// </summary>
        public void Load(Action<WXTextResponse> success = null, Action<WXADErrorResponse> failed = null)
        {
            WXSDKManagerHandler.Instance.ADLoad(instanceId, WXCallBackHandler.Add(success), WXCallBackHandler.Add(failed));
        }

        /// <summary>
        /// 监听用户点击 关闭广告 按钮的事件。
        /// </summary>
        /// <param name="action">用户点击 关闭广告 按钮的事件的回调函数</param>
        public void OnClose(Action<WXRewardedVideoAdOnCloseResponse> action)
        {
            onCloseAction += action;
        }

        /// <summary>
        /// //取消监听用户点击 关闭广告 按钮的事件
        /// </summary>
        /// <param name="action">用户点击 关闭广告 按钮的事件的回调函数</param>
        public void OffClose(Action<WXRewardedVideoAdOnCloseResponse> action)
        {
            onCloseAction -= action;
        }


    }
}

