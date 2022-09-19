using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace WeChatWASM
{
    /// <summary>
    /// 音频类，详见 https://developers.weixin.qq.com/minigame/dev/api/media/audio/InnerAudioContext.html
    /// </summary>
    public class WXInnerAudioContext
    {

        public Hashtable ht = new Hashtable();

        #region C#调用JS桥接方法
#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextSetBool(string id,string key, bool value);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextSetString(string id,string key, string value);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextSetFloat(string id,string key, float value);



#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern float WXInnerAudioContextGetFloat(string id, string key);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern bool WXInnerAudioContextGetBool(string id, string key);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextPlay(string id);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextPause(string id);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextStop(string id);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextSeek(string id, float position);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextDestroy(string id);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextAddListener(string id, string key);


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXInnerAudioContextRemoveListener(string id, string key);


        #endregion

        private bool _autoplay = false;
        private bool _loop = false;
        private string _src = "";
        private float _startTime = 0;
        private float _volume = 1;
        private float _oldVolume = 1;
        private float _playbackRate = 1;
        private bool _isPlaying = false;
        private bool isWaiting = false;
        private bool isWaitingPlay = false;
        private bool isWaitingStop = false;
        private bool isWaitingPause = false;
        private Action _onCanplay;
        private Action _onPlay;
        private Action _onPause;
        private Action _onStop;
        private Action _onEnded;
        private Action _onTimeUpdate;
        private Action _onError;
        private Action _onWaiting;
        private Action _onSeeking;
        private Action _onSeeked;

#if UNITY_WEBGL && !UNITY_EDITOR
        private static readonly bool isWebGLPlayer = true;
#else
        private static readonly bool isWebGLPlayer = false;
#endif

        public static Dictionary<string, WXInnerAudioContext> Dict = new Dictionary<string, WXInnerAudioContext>();

        public string instanceId;
        public WXInnerAudioContext(string id, InnerAudioContextParam param)
        {
            instanceId = id;
            _src = param.src;
            _autoplay = param.autoplay;
            _startTime = param.startTime;
            _volume = param.volume;
            _oldVolume = _volume;
            _loop = param.loop;
            _playbackRate = param.playbackRate;
            Dict.Add(id, this);

            OnPlay(()=> {
                _isPlaying = true;
            });

            OnEnded(()=> {
                _isPlaying = false;
            });

            OnPause(()=> {
                _isPlaying = false;
            });

            OnStop(()=> {
                _isPlaying = false;
            });

#if UNITY_EDITOR
            _isPlaying = autoplay;
#endif

        }

        /// <summary>
        /// 内部函数,请不要调用
        /// </summary>
        /// <param name="key"></param>
        public void _HandleCallBack(string key)
        {
            switch (key){
                case "onCanplay":
                    _onCanplay?.Invoke();
                    break;
                case "onPlay":
                    _onPlay?.Invoke();
                    break;
                case "onPause":
                    _onPause?.Invoke();
                    break;
                case "onStop":
                    _onStop?.Invoke();
                    break;
                case "onEnded":
                    _onEnded?.Invoke();
                    break;
                case "onTimeUpdate":
                    _onTimeUpdate?.Invoke();
                    break;
                case "onError":
                    _onError?.Invoke();
                    break;
                case "onWaiting":
                    _onWaiting?.Invoke();
                    break;
                case "onSeeking":
                    _onSeeking?.Invoke();
                    break;
                case "onSeeked":
                    _onSeeked?.Invoke();
                    break;
            }
                
        }

        /// <summary>
        /// 是否自动开始播放，默认为 false
        /// </summary>
        public bool autoplay
        {
            get
            {
                return _autoplay;
            }
            set
            {
                if (!isWebGLPlayer)
                {
                    ht["autoplay"] = value;
                }
                else {
                    WXInnerAudioContextSetBool(instanceId, "autoplay", value);
                }
                
                _autoplay = value;
            }

        }

        /// <summary>
        /// 音频资源的地址，用于直接播放。可以设置为网络地址，或者unity中的本地路径如 Assets/xx.wav，运行时会自动和配置的音频地址前缀做拼接得到最终线上地址
        /// </summary>
        public string src
        {
            get
            {
                return _src;
            }
            set
            {
                if (!isWebGLPlayer)
                {
                    ht["src"] = value;
                }
                else {
                    WXInnerAudioContextSetString(instanceId, "src", value);
                }
                
                _src = value;
            }
        }

        /// <summary>
        /// 开始播放的位置（单位：s），默认为 0
        /// </summary>
        public float startTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (!isWebGLPlayer)
                {
                    ht["startTime"] = value;
                }
                else {
                    WXInnerAudioContextSetFloat(instanceId, "startTime", value);
                }
                _startTime = value;
            }
        }

        /// <summary>
        /// 是否循环播放，默认为 false
        /// </summary>
        public bool loop
        {
            get
            {
                return _loop;
            }
            set
            {
                if (!isWebGLPlayer)
                {
                    ht["loop"] = value;
                }
                else {
                    WXInnerAudioContextSetBool(instanceId, "loop", value);
                }
                
                _loop = value;
            }

        }

        /// <summary>
        /// 音量。范围 0~1。默认为 1
        /// </summary>
        public float volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (!isWebGLPlayer)
                {
                    ht["volume"] = value;
                }
                else {
                    if (!isWaiting) {
                        isWaiting = true;
                        WXSDKManagerHandler.Instance.StartCoroutine(DoSetVolume());
                    }
                    
                }
                _oldVolume = value;
                _volume = value;
            }
        }

        IEnumerator DoSetVolume()
        {
            //这里unity音频音量设置太频繁，延迟0.5秒后再执行
            yield return new WaitForSeconds(0.5f);
            WXInnerAudioContextSetFloat(instanceId, "volume", _volume);
            isWaiting = false;
        }

        /// <summary>
        /// 静音，静音时将音量设置为 0，取消静音则恢复原来的音量
        /// </summary>
        public bool mute
        {
            get
            {
                return _volume == 0;
            }
            set
            {
                if (!isWebGLPlayer)
                {
                    ht["volume"] = value ? 0 : _oldVolume;
                }
                else
                {
                   WXInnerAudioContextSetFloat(instanceId, "volume", value ? 0 : _oldVolume);
                }

                _volume = value ? 0 : _oldVolume;

            }
        }


        /// <summary>
        /// 播放速度。范围 0.5-2.0，默认为 1。（Android 需要 6 及以上版本）
        /// </summary>
        public float playbackRate
        {
            get
            {
                return _playbackRate;
            }
            set
            {
                if (!isWebGLPlayer)
                {
                    ht["playbackRate"] = value;
                }
                else {
                    WXInnerAudioContextSetFloat(instanceId, "playbackRate", value);
                }
                
                _playbackRate = value;
            }
        }

        /// <summary>
        /// 当前音频的长度（单位 s）。只有在当前有合法的 src 时返回（只读）
        /// </summary>
        public float duration
        {
            get
            {
                if (!isWebGLPlayer) {
                    var v = ht["duration"];
                    if (v == null)
                    {
                        v = 0f;
                    }
                    return (float)v;
                }
                return WXInnerAudioContextGetFloat(instanceId, "duration");
            }
        }

        /// <summary>
        /// 当前音频的播放位置（单位 s）。只有在当前有合法的 src 时返回，时间保留小数点后 6 位（只读）
        /// </summary>
        public float currentTime
        {
            get
            {
                if (!isWebGLPlayer)
                {
                    var v = ht["currentTime"];
                    if (v == null)
                    {
                        v = 0f;
                    }
                    return (float)v;
                }
                return WXInnerAudioContextGetFloat(instanceId, "currentTime");
            }
        }

        /// <summary>
        /// 当前音频的播放位置（单位 s）。只有在当前有合法的 src 时返回，时间保留小数点后 6 位（只读）
        /// </summary>
        public float buffered
        {
            get
            {
                if(!isWebGLPlayer)
                {
                    var v = ht["buffered"];
                    if (v == null)
                    {
                        v = 0f;
                    }
                    return (float)v;
                }
                return WXInnerAudioContextGetFloat(instanceId, "buffered");
            }
        }

        /// <summary>
        /// 当前是是否暂停或停止状态（只读）
        /// </summary>
        public bool paused
        {
            get
            {
                if (!isWebGLPlayer) {
                    var v = ht["paused"];
                    if (v == null)
                    {
                        v = false;
                    }
                    return (bool)v;
                }

                return WXInnerAudioContextGetBool(instanceId, "paused");
            }
        }


        public bool isPlaying
        {
            get
            {
                return _isPlaying;
            }
        }

        /// <summary>
        /// 播放
        /// </summary>
        public void Play()
        {
            if (isWebGLPlayer)
            {
                if (!isWaitingPlay)
                {
                    isWaitingPlay = true;
                    WXSDKManagerHandler.Instance.StartCoroutine(DoPlay());
                }
                return;
            }

           
            Debug.Log(_src + " 音频播放了，这里就不真的播放了。");
            ht["paused"] = false;
            _HandleCallBack("onPlay");

        }

        IEnumerator DoPlay()
        {
            //这里unity音频调用太频繁，延迟0.1秒后再执行
            yield return new WaitForSeconds(0.1f);
            WXInnerAudioContextPlay(instanceId);
            isWaitingPlay = false;
        }

        /// <summary>
        /// 暂停。暂停后的音频再播放会从暂停处开始播放
        /// </summary>
        public void Pause()
        {
            if (isWebGLPlayer)
            {
                if (!isWaitingPause)
                {
                    isWaitingPause = true;
                    WXSDKManagerHandler.Instance.StartCoroutine(DoPause());
                }
                return;
            }
            Debug.Log(_src + " 音频暂停了");
            ht["paused"] = true;
            _HandleCallBack("onPause");
        }

        IEnumerator DoPause()
        {
            //这里unity音频调用太频繁，延迟0.1秒后再执行
            yield return new WaitForSeconds(0.1f);
            WXInnerAudioContextPause(instanceId);
            isWaitingPause = false;
        }

        /// <summary>
        /// 停止。停止后的音频再播放会从头开始播放。
        /// </summary>
        public void Stop()
        {
            if (isWebGLPlayer)
            {
                if (!isWaitingStop)
                {
                    isWaitingStop = true;
                    WXSDKManagerHandler.Instance.StartCoroutine(DoStop());
                }
                return;
            }
            Debug.Log(_src + " 音频停止了");
            ht["paused"] = false;
            _HandleCallBack("onStop");

        }

        IEnumerator DoStop()
        {
            //这里unity音频调用太频繁，延迟0.1秒后再执行
            yield return new WaitForSeconds(0.1f);
            WXInnerAudioContextStop(instanceId);
            isWaitingStop = false;
        }

        /// <summary>
        /// 跳转到指定位置
        /// </summary>
        public void Seek(float position)
        {
            if (isWebGLPlayer)
            {
                WXInnerAudioContextSeek(instanceId, position);
                return;
            }
            Debug.Log(_src + " 音频跳转播放");
        }

        /// <summary>
        /// 销毁当前实例
        /// </summary>
        public void Destroy()
        {
            if (isWebGLPlayer)
            {
                WXInnerAudioContextDestroy(instanceId);
            }
            else {
                Debug.Log(_src + " 音频销毁！");
            }
            Dict.Remove(instanceId);
        }

        /// <summary>
        /// 监听音频进入可以播放状态的事件。但不保证后面可以流畅播放
        /// </summary>
        public void OnCanplay(Action action)
        {
            
            if (_onCanplay == null)
            {
                if (isWebGLPlayer) {
                    WXInnerAudioContextAddListener(instanceId, "onCanplay");
                }
                
            }
            _onCanplay += action;
        }

        /// <summary>
        /// 监听音频进入可以播放状态的事件。但不保证后面可以流畅播放,action 为空表示移除全部事件监听
        /// </summary>
        public void OffCanplay(Action action = null)
        {
            if (action == null)
            {
                _onCanplay = null;
            }
            else
            {
                _onCanplay -= action;
            }
            if (_onCanplay == null)
            {
                if (isWebGLPlayer)
                {
                    WXInnerAudioContextRemoveListener(instanceId, "offCanplay");
                }
            }

        }

        /// <summary>
        /// 监听音频播放事件
        /// </summary>
        public void OnPlay(Action action)
        {

            if (_onPlay == null)
            {
                if (isWebGLPlayer)
                {
                    WXInnerAudioContextAddListener(instanceId, "onPlay");
                }
            }
            _onPlay += action;
        }

        /// <summary>
        /// 取消监听音频播放事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffPlay(Action action = null)
        {
            if (action == null)
            {
                _onPlay = null;
            }
            else
            {
                _onPlay -= action;
            }
            if (_onPlay == null)
            {
                if (isWebGLPlayer)
                {
                    WXInnerAudioContextRemoveListener(instanceId, "offPlay");
                }
            }

        }

        /// <summary>
        /// 监听音频暂停事件
        /// </summary>
        public void OnPause(Action action)
        {

            if (_onPause == null)
            {
                if (isWebGLPlayer)
                {
                    WXInnerAudioContextAddListener(instanceId, "onPause");
                }
            }
            _onPause += action;
        }

        /// <summary>
        /// 取消监听音频暂停事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffPause(Action action = null)
        {
            if (action == null)
            {
                _onPause = null;
            }
            else
            {
                _onPause -= action;
            }
            if (_onPause == null)
            {
                if (isWebGLPlayer)
                {
                    WXInnerAudioContextRemoveListener(instanceId, "offPause");
                }
            }
        }

        /// <summary>
        /// 监听音频暂停事件
        /// </summary>
        public void OnStop(Action action)
        {

            if (_onStop == null)
            {
                if (isWebGLPlayer) {
                    WXInnerAudioContextAddListener(instanceId, "onStop");
                }
                
            }
            _onStop += action;
        }

        /// <summary>
        /// 取消监听音频暂停事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffStop(Action action = null)
        {
            if (action == null)
            {
                _onStop = null;
            }
            else
            {
                _onStop -= action;
            }
            if (_onStop == null)
            {
                if (isWebGLPlayer)
                {
                    WXInnerAudioContextRemoveListener(instanceId, "offStop");
                }
            }
        }

        /// <summary>
        /// 监听音频自然播放至结束的事件
        /// </summary>
        public void OnEnded(Action action)
        {

            if (_onEnded == null)
            {
                if (isWebGLPlayer) {
                    WXInnerAudioContextAddListener(instanceId, "onEnded");
                }
                
            }
            _onEnded += action;
        }

        /// <summary>
        /// 取消监听音频自然播放至结束的事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffEnded(Action action = null)
        {
            if (action == null)
            {
                _onEnded = null;
            }
            else
            {
                _onEnded -= action;
            }
            if (_onEnded == null)
            {
                if (isWebGLPlayer)
                {
                    WXInnerAudioContextRemoveListener(instanceId, "offEnded");
                }
                    
            }
        }

        /// <summary>
        /// 监听音频播放进度更新事件
        /// </summary>
        public void OnTimeUpdate(Action action)
        {

            if (_onTimeUpdate == null)
            {
                if (isWebGLPlayer) {
                    WXInnerAudioContextAddListener(instanceId, "onTimeUpdate");
                }
                
            }
            _onTimeUpdate += action;
        }

        /// <summary>
        /// 取消监听音频播放进度更新事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffTimeUpdate(Action action = null)
        {
            if (action == null)
            {
                _onTimeUpdate = null;
            }
            else
            {
                _onTimeUpdate -= action;
            }
            if (_onTimeUpdate == null)
            {
                if (isWebGLPlayer) {
                    WXInnerAudioContextRemoveListener(instanceId, "offTimeUpdate");
                }
                
            }
        }

        /// <summary>
        /// 监听音频播放错误事件
        /// </summary>
        public void OnError(Action action)
        {

            if (_onError == null)
            {
                if (isWebGLPlayer) {
                    WXInnerAudioContextAddListener(instanceId, "onError");
                }
                
            }
            _onError += action;
        }

        /// <summary>
        /// 取消监听音频播放错误事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffError(Action action = null)
        {
            if (action == null)
            {
                _onError = null;
            }
            else
            {
                _onError -= action;
            }
            if (_onError == null)
            {
                if (isWebGLPlayer) {
                    WXInnerAudioContextRemoveListener(instanceId, "offError");
                }
            }
        }

        /// <summary>
        /// 监听音频加载中事件。当音频因为数据不足，需要停下来加载时会触发
        /// </summary>
        public void OnWaiting(Action action)
        {

            if (_onWaiting == null)
            {
                if (isWebGLPlayer) {
                    WXInnerAudioContextAddListener(instanceId, "onWaiting");
                }
                
            }
            _onWaiting += action;
        }

        /// <summary>
        /// 取消监听音频加载中事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffWaiting(Action action = null)
        {
            if (action == null)
            {
                _onWaiting = null;
            }
            else
            {
                _onWaiting -= action;
            }
            if (_onWaiting == null)
            {
                if (isWebGLPlayer)
                {
                    WXInnerAudioContextRemoveListener(instanceId, "offWaiting");
                }
                    
            }
        }

        /// <summary>
        /// 监听音频进行跳转操作的事件
        /// </summary>
        public void OnSeeking(Action action)
        {

            if (_onSeeking == null && isWebGLPlayer)
            {
                WXInnerAudioContextAddListener(instanceId, "onSeeking");
            }
            _onSeeking += action;
        }

        /// <summary>
        /// 取消监听音频进行跳转操作的事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffSeeking(Action action = null)
        {
            if (action == null)
            {
                _onSeeking = null;
            }
            else
            {
                _onSeeking -= action;
            }
            if (_onSeeking == null && isWebGLPlayer)
            {
                WXInnerAudioContextRemoveListener(instanceId, "offSeeking");
            }
        }

        /// <summary>
        /// 监听音频完成跳转操作的事件
        /// </summary>
        public void OnSeeked(Action action)
        {

            if (_onSeeked == null && isWebGLPlayer)
            {
                WXInnerAudioContextAddListener(instanceId, "onSeeked");
            }
            _onSeeked += action;
        }

        /// <summary>
        /// 取消监听音频完成跳转操作的事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffSeeked(Action action = null)
        {
            if (action == null)
            {
                _onSeeked = null;
            }
            else
            {
                _onSeeked -= action;
            }
            if (_onSeeked == null && isWebGLPlayer)
            {
                WXInnerAudioContextRemoveListener(instanceId, "offSeeked");
            }
        }

    }
}
