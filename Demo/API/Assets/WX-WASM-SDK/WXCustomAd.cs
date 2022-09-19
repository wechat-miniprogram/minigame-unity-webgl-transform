using System;
namespace WeChatWASM
{

    /// <summary>
    /// 插屏广告组件广告,详见 https://developers.weixin.qq.com/minigame/dev/api/ad/CustomAd.html
    /// </summary>
    public class WXCustomAd : WXBaseAd, IWXADCloseable
    {
        public WXAdCustomStyle style;
        public WXCustomAd(string id, CustomStyle style) : base(id)
        {
            this.style = new WXAdCustomStyle(id,style);
        }
        public Action onCloseAction;

        public void OnCloseCallback()
        {
            onCloseAction?.Invoke();
        }


        /// <summary>
        /// 监听广告关闭事件
        /// </summary>
        /// <param name="action">广告关闭事件的回调函数</param>
        public void OnClose(Action action)
        {
            onCloseAction += action;
        }

        /// <summary>
        /// 取消监听广告关闭事件
        /// </summary>
        /// <param name="action">广告关闭事件的回调函数</param>
        public void OffClose(Action action)
        {
            onCloseAction -= action;
        }

        /// <summary>
        /// 隐藏原生模板广告。（某些模板广告无法隐藏）
        /// </summary>
        /// <param name="success">成功回调</param>
        /// <param name="failed">失败回调</param>
        public void Hide(Action<WXTextResponse> success = null, Action<WXTextResponse> failed = null)
        {
            WXSDKManagerHandler.Instance.HideAd(instanceId, WXCallBackHandler.Add(success), WXCallBackHandler.Add(failed));
        }

    }
}
