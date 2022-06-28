using System;
using System.Runtime.InteropServices;

namespace WeChatWASM
{
    public class WXEnv
    {
        #region C#调用JS桥接方法
#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXGetUserDataPath();

        #endregion

        /// <summary>
        /// 微信提供了一个用户文件目录给开发者，开发者对这个目录有完全自由的读写权限。通过 WX.env.USER_DATA_PATH 可以获取到这个目录的路径。
        /// </summary>
        public string USER_DATA_PATH
        {
            get
            {
                return WXGetUserDataPath();
            }

        }
    }
}
