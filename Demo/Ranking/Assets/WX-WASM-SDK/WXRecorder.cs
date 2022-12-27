using UnityEngine;
using System.Runtime.InteropServices;
using System;
using LitJson;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace WeChatWASM
{
    public class WXRecorderManager
    {
        private string instanceId;
        public WXRecorderManager(string id)
        {
            instanceId = id;
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_OnRecorderError(string id);
        public static Dictionary<string,Action> OnRecorderErrorActionList;
        public void OnError(Action callback){
            if(OnRecorderErrorActionList == null){
                OnRecorderErrorActionList = new Dictionary<string,Action>();
            }
            if(OnRecorderErrorActionList.ContainsKey(instanceId)){
                OnRecorderErrorActionList[instanceId] += callback;
            }else{
                OnRecorderErrorActionList.Add(instanceId,callback);
                WX_OnRecorderError(instanceId);
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_OnRecorderFrameRecorded(string id);
        public static Dictionary<string,Action<OnFrameRecordedCallbackResult>> OnRecorderFrameRecordedActionList;
        public void OnFrameRecorded(Action<OnFrameRecordedCallbackResult> callback){
            if(OnRecorderFrameRecordedActionList == null){
                OnRecorderFrameRecordedActionList = new Dictionary<string,Action<OnFrameRecordedCallbackResult>>();
            }
            if(OnRecorderFrameRecordedActionList.ContainsKey(instanceId)){
                OnRecorderFrameRecordedActionList[instanceId] += callback;
            }else{
                OnRecorderFrameRecordedActionList.Add(instanceId,callback);
                WX_OnRecorderFrameRecorded(instanceId);
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_OnRecorderInterruptionBegin(string id);
        public static Dictionary<string,Action> OnRecorderInterruptionBeginActionList;
        public void OnInterruptionBegin(Action callback){
            if(OnRecorderInterruptionBeginActionList == null){
                OnRecorderInterruptionBeginActionList = new Dictionary<string,Action>();
            }
            if(OnRecorderInterruptionBeginActionList.ContainsKey(instanceId)){
                OnRecorderInterruptionBeginActionList[instanceId] += callback;
            }else{
                OnRecorderInterruptionBeginActionList.Add(instanceId,callback);
                WX_OnRecorderInterruptionBegin(instanceId);
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_OnRecorderInterruptionEnd(string id);
        public static Dictionary<string,Action> OnRecorderInterruptionEndActionList;
        public void OnInterruptionEnd(Action callback){
            if(OnRecorderInterruptionEndActionList == null){
                OnRecorderInterruptionEndActionList = new Dictionary<string,Action>();
            }
            if(OnRecorderInterruptionEndActionList.ContainsKey(instanceId)){
                OnRecorderInterruptionEndActionList[instanceId] += callback;
            }else{
                OnRecorderInterruptionEndActionList.Add(instanceId,callback);
                WX_OnRecorderInterruptionEnd(instanceId);
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_OnRecorderPause(string id);
        public static Dictionary<string,Action> OnRecorderPauseActionList;
        public void OnPause(Action callback){
            if(OnRecorderPauseActionList == null){
                OnRecorderPauseActionList = new Dictionary<string,Action>();
            }
            if(OnRecorderPauseActionList.ContainsKey(instanceId)){
                OnRecorderPauseActionList[instanceId] += callback;
            }else{
                OnRecorderPauseActionList.Add(instanceId,callback);
                WX_OnRecorderPause(instanceId);
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_OnRecorderResume(string id);
        public static Dictionary<string,Action> OnRecorderResumeActionList;
        public void OnResume(Action callback){
            if(OnRecorderResumeActionList == null){
                OnRecorderResumeActionList = new Dictionary<string,Action>();
            }
            if(OnRecorderResumeActionList.ContainsKey(instanceId)){
                OnRecorderResumeActionList[instanceId] += callback;
            }else{
                OnRecorderResumeActionList.Add(instanceId,callback);
                WX_OnRecorderResume(instanceId);
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_OnRecorderStart(string id);
        public static Dictionary<string,Action> OnRecorderStartActionList;
        public void OnStart(Action callback){
            if(OnRecorderStartActionList == null){
                OnRecorderStartActionList = new Dictionary<string,Action>();
            }
            if(OnRecorderStartActionList.ContainsKey(instanceId)){
                OnRecorderStartActionList[instanceId] += callback;
            }else{
                OnRecorderStartActionList.Add(instanceId,callback);
                WX_OnRecorderStart(instanceId);
            }
        }
        
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_OnRecorderStop(string id);
        public static Dictionary<string,Action<OnStopCallbackResult>> OnRecorderStopActionList;
        public void OnStop(Action<OnStopCallbackResult> callback){
            if(OnRecorderStopActionList == null){
                OnRecorderStopActionList = new Dictionary<string,Action<OnStopCallbackResult>>();
            }
            if(OnRecorderStopActionList.ContainsKey(instanceId)){
                OnRecorderStopActionList[instanceId] += callback;
            }else{
                OnRecorderStopActionList.Add(instanceId,callback);
                WX_OnRecorderStop(instanceId);
            }
        }
        
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_RecorderPause(string id);          
        public void Pause(){
            WX_RecorderPause(instanceId);
        }
        
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_RecorderResume(string id);          
        public void Resume(){
            WX_RecorderResume(instanceId);
        }
        
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_RecorderStart(string id, string option);          
        public void Start(RecorderManagerStartOption option){
            WX_RecorderStart(instanceId, JsonMapper.ToJson(option));
        }
        
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WX_RecorderStop(string id);          
        public void Stop(){
            WX_RecorderStop(instanceId);
        }
    }

    [Preserve]
    public class OnFrameRecordedCallbackResult {
            /// <summary> 
            /// 录音分片数据
            /// </summary>
                public byte[] frameBuffer;
            /// <summary> 
            /// 当前帧是否正常录音结束前的最后一帧
            /// </summary>
                public bool isLastFrame;
    }
    [Preserve]
    public class OnFrameRecordedBufferCallbackResult {
            /// <summary> 
            /// 录音分片数据长度
            /// </summary>
                public long frameBufferLength;
            /// <summary> 
            /// 当前帧是否正常录音结束前的最后一帧
            /// </summary>
                public bool isLastFrame;
    }
    [Preserve]
    public class OnStopCallbackResult {
            /// <summary> 
            /// 录音总时长，单位：ms
            /// </summary>
                public double duration;
            /// <summary> 
            /// 录音文件大小，单位：Byte
            /// </summary>
                public double fileSize;
            /// <summary> 
            /// 录音文件的临时路径 (本地路径)
            /// </summary>
                public string tempFilePath;
    }
    [Preserve]
    public class RecorderManagerStartOption {
            /// <summary> 
            /// 需要基础库： `2.1.0`
            /// 指定录音的音频输入源，可通过 [wx.getAvailableAudioSources()](https://developers.weixin.qq.com/minigame/dev/api/media/audio/wx.getAvailableAudioSources.html) 获取当前可用的音频源
            /// 可选值：
            /// - 'auto': 自动设置，默认使用手机麦克风，插上耳麦后自动切换使用耳机麦克风，所有平台适用;
            /// - 'buildInMic': 手机麦克风，仅限 iOS;
            /// - 'headsetMic': 有线耳机麦克风，仅限 iOS;
            /// - 'mic': 麦克风（没插耳麦时是手机麦克风，插耳麦时是耳机麦克风），仅限 Android;
            /// - 'camcorder': 同 mic，适用于录制音视频内容，仅限 Android;
            /// - 'voice_communication': 同 mic，适用于实时沟通，仅限 Android;
            /// - 'voice_recognition': 同 mic，适用于语音识别，仅限 Android;
            /// </summary>
                public string audioSource;
            /// <summary> 
            /// 录音的时长，单位 ms，最大值 600000（10 分钟）
            /// </summary>
                public double duration;
            /// <summary> 
            /// 编码码率，有效值见下表格
            /// </summary>
                public double encodeBitRate;
            /// <summary> 
            /// 音频格式
            /// 可选值：
            /// - 'mp3': mp3 格式;
            /// - 'aac': aac 格式;
            /// - 'wav': wav 格式;
            /// - 'PCM': pcm 格式;
            /// </summary>
                public string format;
            /// <summary> 
            /// 指定帧大小，单位 KB。传入 frameSize 后，每录制指定帧大小的内容后，会回调录制的文件内容，不指定则不会回调。暂仅支持 mp3、pcm 格式。
            /// </summary>
                public double frameSize;
            /// <summary> 
            /// 录音通道数
            /// 可选值：
            /// - 1: 1 个通道;
            /// - 2: 2 个通道;
            /// </summary>
                public double numberOfChannels;
            /// <summary> 
            /// 采样率（pc不支持）
            /// 可选值：
            /// - 8000: 8000 采样率;
            /// - 11025: 11025 采样率;
            /// - 12000: 12000 采样率;
            /// - 16000: 16000 采样率;
            /// - 22050: 22050 采样率;
            /// - 24000: 24000 采样率;
            /// - 32000: 32000 采样率;
            /// - 44100: 44100 采样率;
            /// - 48000: 48000 采样率;
            /// </summary>
                public double sampleRate;
    }
}
