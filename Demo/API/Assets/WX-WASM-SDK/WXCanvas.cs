using System.Runtime.InteropServices;
using UnityEngine;
using LitJson;

namespace WeChatWASM
{
    /// <summary>
    /// 调用客户端的canvas
    /// </summary>
    public class WXCanvas
    {

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern string WXToTempFilePathSync(string conf);
        
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXToTempFilePath(string conf, string s, string f, string c);

        /// <summary>
        /// 同步的将当前 Canvas 保存为一个临时文件
        /// 华为机型分享有已知bug，推荐使用异步版本
        /// </summary>
        /// <returns>canvas 生成的临时文件路径 (本地路径)</returns>
        public static string ToTempFilePathSync(WXToTempFilePathSyncParam param = null)
        {
            return WXToTempFilePathSync(param == null ? "" : JsonUtility.ToJson(param));
        }

        /// <summary>
        /// 异步的将当前 Canvas 保存为一个临时文件
        /// </summary>
        public static void ToTempFilePath(WXToTempFilePathParam param = null)
        {
            WXToTempFilePath(JsonUtility.ToJson(param), WXCallBackHandler.Add(param.success), WXCallBackHandler.Add(param.fail), WXCallBackHandler.Add(param.complete));
        }
    }
}
