using UnityEngine;
using System.Runtime.InteropServices;
using System;
using LitJson;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace WeChatWASM
{
    /// <summary>
    /// 游戏对局回放
    /// </summary>
    public class WXGameRecorder
    {
        private string instanceId;
        public static Dictionary<string, Action<GameRecorderCallbackRes>> OnActionList = new Dictionary<string, Action<GameRecorderCallbackRes>>();
        public WXGameRecorder(string id)
        {
            instanceId = id;
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WX_GameRecorderOff(string id, string eventType);
        public void Off(string eventType)
        {
            if (OnActionList.ContainsKey(eventType))
            {
                OnActionList[eventType] = null;
                WX_GameRecorderOff(instanceId, eventType);
            }
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WX_GameRecorderOn(string id, string eventType);
        public void On(string eventType, Action<GameRecorderCallbackRes> callback = null)
        {
            OnActionList.Add(eventType, callback);
            WX_GameRecorderOn(instanceId, eventType);
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WX_GameRecorderStart(string id, string option);
        public void Start(GameRecorderStartOption option)
        {
            WX_GameRecorderStart(instanceId, JsonMapper.ToJson(option));
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WX_GameRecorderAbort(string id);
        public void Abort()
        {
            WX_GameRecorderAbort(instanceId);
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WX_GameRecorderPause(string id);
        public void Pause()
        {
            WX_GameRecorderPause(instanceId);
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WX_GameRecorderResume(string id);
        public void Resume()
        {
            WX_GameRecorderResume(instanceId);
        }

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WX_GameRecorderStop(string id);
        public void Stop()
        {
            WX_GameRecorderStop(instanceId);
        }
    }

    [Preserve]
    public class GameRecorderStartOption
    {
        /// <summary> 
        /// 视频比特率（kbps），默认值1000，最大值 3000，最小值 600
        /// </summary>
        public double bitrate = 1000;
        /// <summary> 
        /// 视频的时长限制，单位为秒（s）。最大值 7200，最小值 5，到达指定时长后不会再录入。但还需要手动调用 [GameRecorder.stop()](https://developers.weixin.qq.com/minigame/dev/api/game-recorder/GameRecorder.stop.html) 来结束录制。
        /// </summary>
        public double duration = 7200;
        /// <summary> 
        /// 视频 fps
        /// </summary>
        public double fps = 24;
        /// <summary> 
        /// 视频关键帧间隔
        /// </summary>
        public double gop = 12;
        /// <summary> 
        /// 需要基础库： `2.10.0`
        /// 
        /// 是否录制游戏音效（仅iOS支持）
        /// </summary>
        public bool hookBgm = true;
    }

    [Preserve]
    public class GameRecorderCallbackRes
    {
        public float currentTime;
        public int code;
        public string message;
        public float duration;
    }

    [Preserve]
    public class GameRecorderCallback
    {
        public string eventType;
        public string result;
    }

    [Preserve]
    public class operateGameRecorderOption
    {
        /// <summary> 
        /// 分享的对局回放打开后的标题内容
        /// </summary>
        public string title = "";
        /// <summary> 
        /// 分享的对局回放打开后的描述内容
        /// </summary>
        public string desc = "";
        /// <summary> 
        /// 分享的对局回放打开后跳转小游戏的 query
        /// </summary>
        public string query = "";
        /// <summary> 
        /// 分享的对局回放打开后跳转小游戏的 path （独立分包路径）
        /// </summary>
        public string path = "";
        /// <summary> 
        /// 对局回放背景音乐的地址
        /// </summary>
        public string bgm = "";
        /// <summary> 
        /// 对局回放的剪辑区间，是一个二维数组，单位 ms（毫秒）
        /// </summary>
        public int[][] timeRange = null;
        /// <summary> 
        /// 对局回放的音量大小，最小0，最大1
        /// </summary>
        public double volume = 1;
        /// <summary> 
        /// 对局回放的播放速率，只能设置以下几个值: 0.3, 0.5, 1, 1.5, 2, 2.5, 3
        /// </summary>
        public double number = 1;
        /// <summary> 
        /// 如果原始视频文件中有音频，是否与新传入的bgm混音，默认为false，表示不混音，只保留一个音轨，值为true时表示原始音频与传入的bgm混音
        /// </summary>
        public bool audioMix = false;
    }
}