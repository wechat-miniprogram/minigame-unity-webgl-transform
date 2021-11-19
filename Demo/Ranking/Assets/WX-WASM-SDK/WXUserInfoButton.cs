using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace WeChatWASM
{
    public class WXUserInfoButton
    {
        private readonly string instanceId;

        private Action<WXUserInfoResponse> onTopCallback;

        public static Dictionary<string, WXUserInfoButton> Dict = new Dictionary<string,WXUserInfoButton>();

        #region C#调用JS桥接方法

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUserInfoButtonDestroy(string id);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUserInfoButtonHide(string id);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUserInfoButtonOffTap(string id);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUserInfoButtonOnTap(string id);

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUserInfoButtonShow(string id);


        #endregion


        public WXUserInfoButton(string id)
        {
            instanceId = id;
        }

        public void InvokeCallback(WXUserInfoResponse res)
        {
            onTopCallback?.Invoke(res);
        }


        #region 调用方法

        /// <summary>
        /// 销毁用户信息按钮
        /// </summary>
        public void Destroy()
        {
            WXUserInfoButtonDestroy(instanceId);
            if (Dict.ContainsKey(instanceId)) {
                Dict.Remove(instanceId);
            }
            
        }

        /// <summary>
        /// 隐藏用户信息按钮。
        /// </summary>
        public void Hide()
        {
            WXUserInfoButtonHide(instanceId);
        }

        /// <summary>
        /// 取消监听用户信息按钮的点击事件
        /// </summary>
        public void OffTap()
        {
            WXUserInfoButtonOffTap(instanceId);
            onTopCallback = null;
        }

        /// <summary>
        /// 监听用户信息按钮的点击事件
        /// </summary>
        /// <param name="action"></param>
        public void OnTap(Action<WXUserInfoResponse> action)
        {
            onTopCallback = action;
            WXUserInfoButtonOnTap(instanceId);
        }

        /// <summary>
        /// 显示用户信息按钮
        /// </summary>
        public void Show()
        {
            WXUserInfoButtonShow(instanceId);
        }

        #endregion

    }
}
