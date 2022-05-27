using System.Runtime.InteropServices;
using UnityEngine;

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

        /// <summary>
        /// 同步的将当前 Canvas 保存为一个临时文件
        /// </summary>
        /// <returns>canvas 生成的临时文件路径 (本地路径)</returns>
        public static string ToTempFilePathSync(WXToTempFilePathParam param = null)
        {
            return WXToTempFilePathSync(param == null ? "" : JsonUtility.ToJson(param));
        }
    }
}
