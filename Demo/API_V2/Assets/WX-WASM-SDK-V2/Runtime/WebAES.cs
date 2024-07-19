#if WEIXINMINIGAME && TUANJIE_2022_3_OR_NEWER
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using AOT;
using UnityEditor;
using UnityEngine;

namespace WeChatWASM
{
    public class WebAES
    {
        public static byte[] EncryptedBytes;
        public static byte[] DecryptedBytes;
        public static bool initialized;
        public static System.IntPtr keyPtr, ivPtr;
        public delegate void AesCallback(int enc, System.IntPtr resPtr, int resSize);

        [DllImport("__Internal")]
        public static extern void WebAesInitialize(
            int mode,
            System.IntPtr keyPtr, int keySize,
            System.IntPtr ivPtr, int ivSize,
            AesCallback encCallback, AesCallback decCallback,
            int counter = 0, int segmentSize = 0);
        [DllImport("__Internal")]
        public static extern void WebAesFinalize();
        [DllImport("__Internal")]
        public static extern void WebAesEncrypt(System.IntPtr plainBytesPtr, int size, int needPad);
        [DllImport("__Internal")]
        public static extern void WebAesDecrypt(System.IntPtr encryptedBytesPtr, int size, int needStrip);

        // TODO: consider passing a unique id so that we can initialize multiple instances.
        public static void Initialize(System.Security.Cryptography.CipherMode mode, byte[] key,
            byte[] iv, int counter = 0, int segmentSize = 0)
        {
            if (initialized)
            {
                Debug.Log("Already initialized! Please call Finalize() before initialize again.");
                return;
            }
            if (mode == CipherMode.CTS)
            {
                Debug.LogError("CTS not supported!");
                return;
            }

            int keySize = key.Length;
            keyPtr = Marshal.AllocHGlobal(keySize);
            Marshal.Copy(key, 0, keyPtr, keySize);

            int ivSize = iv.Length;
            ivPtr = Marshal.AllocHGlobal(ivSize);
            Marshal.Copy(iv, 0, ivPtr, ivSize);
            WebAesInitialize(
                (int)mode,
                keyPtr, keySize, ivPtr, ivSize,
                OnAecCrypto, OnAecCrypto,
                counter, segmentSize);
            initialized = true;
        }

        [MonoPInvokeCallback(typeof(AesCallback))]
        public static void OnAecCrypto(int enc, System.IntPtr resPtr, int resSize)
        {
            byte[] res = new byte[resSize];
            Marshal.Copy(resPtr, res, 0, resSize);
            if (enc == 1)
            {
                EncryptedBytes = res;
            }
            else
            {
                DecryptedBytes = res;
            }
        }

        // TODO: consider passing a unique id so we can destroy by instance.
        public static void Finalize()
        {
            EncryptedBytes = null;
            DecryptedBytes = null;
            Marshal.FreeHGlobal(keyPtr);
            Marshal.FreeHGlobal(ivPtr);
            initialized = false;
            WebAesFinalize();
        }

        // Use UTF-8 as it is used as default format for StreamReader
        public static byte[] Encode(string plainStr, bool needPad = true)
        {
            var bytes = Encoding.UTF8.GetBytes(plainStr);
            var bytesPtr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, bytesPtr, bytes.Length);
            WebAesEncrypt(bytesPtr, bytes.Length, needPad ? 1 : 0);
            Marshal.FreeHGlobal(bytesPtr);
            return EncryptedBytes;
        }

        public static string Decode(byte[] bytes, bool needStrip = true)
        {
            var bytesPtr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, bytesPtr, bytes.Length);
            WebAesDecrypt(bytesPtr, bytes.Length, needStrip ? 1 : 0);
            Marshal.FreeHGlobal(bytesPtr);
            return Encoding.UTF8.GetString(DecryptedBytes);
        }
    }
}
#endif