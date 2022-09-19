using System;
namespace WeChatWASM
{
    public class WXOpenDataContext
    {
        /// <summary>
        /// 向开放数据域发送消息
        /// </summary>
        /// <param name="msg">要发送的消息</param>
        public void PostMessage(string msg)
        {
            WXSDKManagerHandler.Instance.OpenDataContextPostMessage(msg);
        }
    }
}
