using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace WeChatWASM
{
    /// <summary>
    /// 云函数，调用前必须先Init初始化
    /// </summary>
    public class Cloud
    {
        #region C#调用JS桥接方法
#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        
        private static extern void WXCallFunction(string name,string data,string conf,string s,string f,string c);
#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXCallFunctionInit(string conf);
        #endregion

        /// <summary>
        /// 初始化，详见 https://developers.weixin.qq.com/minigame/dev/wxcloud/reference-sdk-api/init/client.init.html
        /// </summary>
        /// <param name="param"></param>
        public void Init(CallFunctionInitParam param)
        {
            WXCallFunctionInit(JsonUtility.ToJson(param));
        }

        /// <summary>
        /// 调用云函数,详见 https://developers.weixin.qq.com/minigame/dev/wxcloud/reference-sdk-api/functions/Cloud.callFunction.html 
        /// </summary>
        /// <param name="param"></param>
        /// <example>
        //WX.cloud.Init(new CallFunctionInitParam()
        //{
        //    env = "product",
        //        traceUser = false
        //    });

        //    var p = new C()
        //    {
        //        content = "haha"
        //    };
        //WX.cloud.CallFunction(new CallFunctionParam()
        //{
        //    name = "msgSecCheck",
        //        data = JsonUtility.ToJson(p),
        //        success = (res) => {
        //            Debug.Log("success");
        //            Debug.Log(res.result);
        //        },
        //        fail = (res) => {
        //            Debug.Log("fail");
        //            Debug.Log(res.errMsg);
        //        },
        //        complete = (res) => {
        //            Debug.Log("complete");
        //            Debug.Log(res.result);
        //        }
        //    });
        /// </example>
        public void CallFunction(CallFunctionParam param)
        {
            WXCallFunction(param.name,param.data,
                param.config == null ? "" : JsonUtility.ToJson(param.config),
                WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }


    }
}