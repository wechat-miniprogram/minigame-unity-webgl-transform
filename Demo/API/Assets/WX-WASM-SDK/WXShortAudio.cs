using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace WeChatWASM
{
    /// <summary>
    /// 适合几秒短音频播放
    /// </summary>
    public class WXShortAudioPlayer
    {

        private static WXShortAudioPlayer instance = null;

        public static WXShortAudioPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WXShortAudioPlayer();
                }
                return instance;
            }
        }

        /// <summary>
        /// 提前调用这个会预先去下载音频，减少延迟
        /// </summary>
        /// <param name="audios">音频列表，填Assets下的路径，如【”/audio/1.mp3“】</param>
        public void PreLoadAudio(string[] audios)
        {
            WXPreLoadShortAudio(string.Join(",",audios));
        }

        /// <summary>
        /// 播放短音频直接调用这个就好，调用的话会停止掉其他通过WXShortAudioPlayer播放的短音频，而从头播放这个音频
        /// </summary>
        /// <param name="audio">音频，填Assets下的路径，如”/audio/1.mp3”</param>
        /// <param name="volume">音量,1最大，0最小</param>
        /// <param name="loop">是否循环</param>
        public void StopOthersAndPlay(string audio,float volume, bool loop =false)
        {
            WXStopOthersAndPlay(audio,loop,volume);
        }

        /// <summary>
        /// 停止短音频播放
        /// </summary>
        /// <param name="audio">音频，填Assets下的路径，如”/audio/1.mp3”</param>
        public void Stop(string audio)
        {
            WXShortAudioPlayerStop(audio);
        }

        /// <summary>
        /// 销毁短音频，节省内存
        /// </summary>
        /// <param name="audio"音频，填Assets下的路径，如”/audio/1.mp3”></param>
        public void Destroy(string audio)
        {
            WXShortAudioPlayerDestroy(audio);
        }


        #region C#调用JS桥接方法
#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXPreLoadShortAudio(string audio);
#else
        private static void WXPreLoadShortAudio(string audio) {

        }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXStopOthersAndPlay(string audio,bool loop, float volume=1.0f);
#else
        private static void WXStopOthersAndPlay(string audio, bool loop, float volume = 1.0f)
        {
            Debug.Log(audio+" , play");
        }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXShortAudioPlayerStop(string audio);
#else
        private static void WXShortAudioPlayerStop(string audio)
        {

        }
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void WXShortAudioPlayerDestroy(string audio);
#else
        private static void WXShortAudioPlayerDestroy(string audio)
        {

        }
#endif
        #endregion
    }

}
