using System;
using System.Collections.Generic;
using UnityEngine;

namespace WeChatWASM
{
    /// <summary>
    /// 广告的基类
    /// </summary>
    public class WXBaseAd
    {
        public string instanceId;

        public static Dictionary<string, WXBaseAd> Dict = new Dictionary<string, WXBaseAd>();

        public Action<WXADErrorResponse> onErrorAction;

        public Action<WXADLoadResponse> onLoadActon;




        public WXBaseAd(string id)
        {
            instanceId = id;
            Dict.Add(id, this);
        }


        /// <summary>
        /// 显示广告。
        /// </summary>
        /// <param name="success">成功回调</param>
        /// <param name="failed">失败回调</param>
        public void Show(Action<WXTextResponse> success = null, Action<WXTextResponse> failed = null)
        {

            WXSDKManagerHandler.Instance.ShowAd(instanceId, WXCallBackHandler.Add(success), WXCallBackHandler.Add(failed));
        }

        /// <summary>
        /// 显示广告。
        /// </summary>
        /// <param name="success">成功回调</param>
        /// <param name="failed">失败回调</param>
        public void Show(string branchId, string branchDim, Action<WXTextResponse> success = null, Action<WXTextResponse> failed = null)
        {

            WXSDKManagerHandler.Instance.ShowAd(instanceId, branchId, branchDim, WXCallBackHandler.Add(success), WXCallBackHandler.Add(failed));
        }

        /// <summary>
        /// 监听广告错误事件。
        /// </summary>
        /// <param name="action">广告错误事件的回调函数,可详见 https://developers.weixin.qq.com/minigame/dev/api/ad/BannerAd.onError.html</param>
        public void OnError(Action<WXADErrorResponse> action)
        {
            onErrorAction += action;
        }

        /// <summary>
        /// 监听 banner 广告加载事件。
        /// </summary>
        /// <param name="action">广告加载事件的回调函数</param>
        public void OnLoad(Action<WXADLoadResponse> action)
        {
            onLoadActon += action;
        }


        /// <summary>
        /// 取消监听广告错误事件
        /// </summary>
        /// <param name="action">广告错误事件的回调函数</param>
        public void OffError(Action<WXADErrorResponse> action)
        {
            onErrorAction -= action;
        }

        /// <summary>
        /// 取消监听广告加载事件
        /// </summary>
        /// <param name="action">广告加载事件的回调函数</param>
        public void OffLoad(Action<WXADLoadResponse> action)
        {
            onLoadActon -= action;
        }

        /// <summary>
        /// 销毁广告,如果是激励视频广告且multiton参数默认设置为false,则请慎用Destroy,调用后，后续可能无法再创建激励视频广告
        /// </summary>
        public void Destroy()
        {
            WXSDKManagerHandler.Instance.ADDestroy(instanceId);
            Dict.Remove(instanceId);
        }

    }

}

