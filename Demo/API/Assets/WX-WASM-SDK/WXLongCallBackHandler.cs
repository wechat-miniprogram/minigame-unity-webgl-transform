using System;
using System.Collections;
using UnityEngine;

namespace WeChatWASM
{

    /// <summary>
    /// 长时间才返回的用这个
    /// </summary>
    class WXLongCallBackHandler
    {

        //用于暂存回调
        private static readonly Hashtable responseHT = new Hashtable();


        //用于作为回调id的一部分
        private static int htCounter = 0;


        private static int GenarateCallbackId()
        {
            if (htCounter > 10000000)
            {
                htCounter = 0;
            }
            htCounter++;

            return htCounter;
        }


        public static string Add<T>(Action<T> callback) where T : WXBaseResponse
        {
            if(callback == null)
            {
                return "";
            }
            int id = GenarateCallbackId();
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var timestamp = Convert.ToInt64(ts.TotalSeconds);
            var key = timestamp.ToString() + '-' + id;
            responseHT.Add(key,callback);
            return key;
        }


        public static void InvokeResponseCallback<T>(string str) where T : WXBaseResponse
        {
            if (str != null)
            {
                T res = JsonUtility.FromJson<T>(str);

                var id = res.callbackId;

                if (responseHT[id] != null)
                {
                    var callback = (Action<T>)responseHT[id];
                    callback(res);
                    responseHT.Remove(id);
                }
            }
        }


    }

    
}
