#if WEIXINMINIGAME && TUANJIE_2022_3_OR_NEWER
using System;
using System.Runtime.InteropServices;

namespace WeChatWASM
{
    public class WebMD5
    {

        [DllImport("__Internal", EntryPoint = "_WebMD5")]
        private static extern void getMD5Bytes(IntPtr byteArray, int length, IntPtr result);

        public static byte[] GetMD5Bytes(byte[] input)
        {
            var inputLength = input.Length;
            var inputPtr = Marshal.AllocHGlobal(inputLength);
            Marshal.Copy(input, 0, inputPtr, inputLength);

            var resultPtr = Marshal.AllocHGlobal(16); // MD5 hash is 16 bytes

            getMD5Bytes(inputPtr, inputLength, resultPtr);

            byte[] result = new byte[16];
            Marshal.Copy(resultPtr, result, 0, 16);

            Marshal.FreeHGlobal(inputPtr);
            Marshal.FreeHGlobal(resultPtr);

            return result;
        }
    }
}
#endif