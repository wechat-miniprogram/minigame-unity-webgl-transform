using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace WeChatWASM
{
    public class WXVideo
    {


#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoPlay(string id);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoAddListener(string id, string key);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoDestroy(string id);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoExitFullScreen(string id);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoPause(string id);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoRequestFullScreen(string id,int direction);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoSeek(string id, int time);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoStop(string id);

#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern void WXVideoRemoveListener(string id, string key);



#if UNITY_WEBGL && !UNITY_EDITOR
        private static readonly bool isWebGLPlayer = true;
#else
        private static readonly bool isWebGLPlayer = false;
#endif


        private bool isWaitingPlay = false;
        private bool isWaitingStop = false;
        private bool isWaitingPause = false;
        private bool _isPlaying = false;

        private Action _onPlay = null;
        private Action _onPause = null;
        private Action _onEnded = null;
        private Action<WXVideoTimeUpdate> _onTimeUpdate = null;
        private Action<WXVideoProgress> _onProgress = null;
        
        private Action _onError = null;
        private Action _onWaiting = null;
        private Action _onSeeking = null;
        private Action _onSeeked = null;

        private WXCreateVideoParam param;


        public string instanceId;

        //内部使用，请不要访问这个
        public static Dictionary<string, WXVideo> _Dict = new Dictionary<string, WXVideo>();

        public WXVideo(string id, WXCreateVideoParam param)
        {
            instanceId = id;
            this.param = param;
            _Dict.Add(id, this);

            OnPlay(() => {
                _isPlaying = true;
            });


            OnEnded(() => {
                _isPlaying = false;
            });

            OnPause(() => {
                _isPlaying = false;
            });

#if UNITY_EDITOR
            _isPlaying = param.autoplay;
#endif
        }


        /// <summary>
        /// 内部函数,请不要调用
        /// </summary>
        /// <param name="key"></param>
        public void _HandleCallBack(WXVideoCallback res)
        {
            switch (res.errMsg)
            {
                case "onPlay":
                    _onPlay?.Invoke();
                    break;
                case "onPause":
                    _onPause?.Invoke();
                    break;
                case "onEnded":
                    _onEnded?.Invoke();
                    break;
                case "onTimeUpdate":
                    _onTimeUpdate?.Invoke(new WXVideoTimeUpdate() {
                        position = res.position,
                        duration = res.duration
                    });
                    break;
                case "onProgress":
                    _onProgress?.Invoke(new WXVideoProgress() {
                        buffered = res.buffered,
                        duration = res.duration
                    });
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
        /// 是否正在播放
        /// </summary>
        public bool isPlaying
        {
            get
            {
                return _isPlaying;
            }
        }

        /// <summary>
        /// 播放视频
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


            Debug.Log(param.src + " 视频播放了，这里就不真的播放了。");
            _HandleCallBack(new WXVideoCallback() {
                errMsg= "onPlay"
            });

        }

        private IEnumerator DoPlay()
        {
            //这里unity音频调用太频繁，延迟0.1秒后再执行
            yield return new WaitForSeconds(0.1f);
            WXVideoPlay(instanceId);
            isWaitingPlay = false;
        }

        /// <summary>
        /// 监听视频播放事件
        /// </summary>
        public void OnPlay(Action action)
        {

            if (_onPlay == null)
            {
                if (isWebGLPlayer)
                {
                    WXVideoAddListener(instanceId, "onPlay");
                }
            }
            _onPlay += action;
        }


        /// <summary>
        /// 取消监听视频播放事件,action 为空表示移除全部事件监听
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
                    WXVideoRemoveListener(instanceId, "offPlay");
                }
            }

        }


        /// <summary>
        /// 监听视频播放到末尾事件
        /// </summary>
        public void OnEnded(Action action)
        {

            if (_onEnded == null)
            {
                if (isWebGLPlayer)
                {
                    WXVideoAddListener(instanceId, "onEnded");
                }

            }
            _onEnded += action;
        }


        /// <summary>
        /// 取消监听视频播放到末尾事件
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
                    WXVideoRemoveListener(instanceId, "offEnded");
                }

            }
        }


        /// <summary>
        /// 监听视频错误事件
        /// </summary>
        public void OnError(Action action)
        {

            if (_onError == null)
            {
                if (isWebGLPlayer)
                {
                    WXVideoAddListener(instanceId, "onError");
                }

            }
            _onError += action;
        }


        /// <summary>
        /// 取消监听视频错误事件,action 为空表示移除全部事件监听
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
                if (isWebGLPlayer)
                {
                    WXVideoRemoveListener(instanceId, "offError");
                }
            }
        }

        /// <summary>
        /// 监听视频暂停事件
        /// </summary>
        public void OnPause(Action action)
        {

            if (_onPause == null)
            {
                if (isWebGLPlayer)
                {
                    WXVideoAddListener(instanceId, "onPause");
                }
            }
            _onPause += action;
        }

        /// <summary>
        /// 取消监听视频暂停事件,action 为空表示移除全部事件监听
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
                    WXVideoRemoveListener(instanceId, "offPause");
                }
            }
        }

        /// <summary>
        /// 监听视频由于需要缓冲下一帧而停止时触发
        /// </summary>
        public void OnWaiting(Action action)
        {

            if (_onWaiting == null)
            {
                if (isWebGLPlayer)
                {
                    WXVideoAddListener(instanceId, "onWaiting");
                }

            }
            _onWaiting += action;
        }

        /// <summary>
        /// 取消监听视频由于需要缓冲下一帧而停止时触发,action 为空表示移除全部事件监听
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
                    WXVideoRemoveListener(instanceId, "offWaiting");
                }

            }
        }

        /// <summary>
        /// 销毁当前实例
        /// </summary>
        public void Destroy()
        {
            if (isWebGLPlayer)
            {
                WXVideoDestroy(instanceId);
            }
            else
            {
                Debug.Log(param.src + " 视频销毁！");
            }
            _Dict.Remove(instanceId);
        }

        /// <summary>
        /// 视频退出全屏
        /// </summary>
        public void ExitFullScreen() {
            if (isWebGLPlayer)
            {
                WXVideoExitFullScreen(instanceId);
            }
            else
            {
                Debug.Log(param.src + " 视频退出全屏！");
            }
        }

        /// <summary>
        /// 暂停
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
            Debug.Log(param.src + " 视频暂停了");

            _HandleCallBack(new WXVideoCallback()
            {
                errMsg = "onPause"
            });
        }

        IEnumerator DoPause()
        {
            //这里调用太频繁，延迟0.1秒后再执行
            yield return new WaitForSeconds(0.1f);
            WXVideoPause(instanceId);
            isWaitingPause = false;
        }

        /// <summary>
        /// 视频全屏
        /// </summary>
        /// <param name="direction">设置全屏时视频的方向 0: 正常竖向, 90: 屏幕逆时针90度 . -90: 屏幕顺时针90度</param>
        public void RequestFullScreen(int direction) {
            if (isWebGLPlayer)
            {
                WXVideoRequestFullScreen(instanceId, direction);
            }
            else
            {
                Debug.Log(param.src + " 视频全屏！");
            }
        }

        /// <summary>
        /// 视频跳转
        /// </summary>
        /// <param name="time">视频跳转到指定位置，单位为 s 秒</param>
        public void Seek(int time)
        {
            WXVideoSeek(instanceId, time);
        }


        /// <summary>
        /// 停止视频
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
            Debug.Log(param.src + " 音频停止了");

        }

        IEnumerator DoStop()
        {
            //这里unity调用太频繁，延迟0.1秒后再执行
            yield return new WaitForSeconds(0.1f);
            WXVideoStop(instanceId);
            isWaitingStop = false;
        }


        /// <summary>
        /// 监听视频播放进度更新事件
        /// </summary>
        /// <param name="action"></param>
        public void OnTimeUpdate(Action<WXVideoTimeUpdate> action)
        {

            if (_onTimeUpdate == null)
            {
                if (isWebGLPlayer)
                {
                    WXVideoAddListener(instanceId, "onTimeUpdate");
                }

            }
            _onTimeUpdate += action;
        }

        /// <summary>
        /// 取消监听视频播放进度更新事件,action 为空表示移除全部事件监听
        /// </summary>
        public void OffTimeUpdate(Action<WXVideoTimeUpdate> action = null)
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
                if (isWebGLPlayer)
                {
                    WXVideoRemoveListener(instanceId, "offTimeUpdate");
                }

            }
        }

        /// <summary>
        /// 监听视频下载（缓冲）事件
        /// </summary>
        /// <param name="action"></param>
        public void OnProgress(Action<WXVideoProgress> action)
        {

            if (_onTimeUpdate == null)
            {
                if (isWebGLPlayer)
                {
                    WXVideoAddListener(instanceId, "onProgress");
                }

            }
            _onProgress += action;
        }

        /// <summary>
        /// 取消监听视频下载（缓冲）事件 ,action 为空表示移除全部事件监听
        /// </summary>
        public void OffProgress(Action<WXVideoProgress> action = null)
        {
            if (action == null)
            {
                _onProgress = null;
            }
            else
            {
                _onProgress -= action;
            }
            if (_onProgress == null)
            {
                if (isWebGLPlayer)
                {
                    WXVideoRemoveListener(instanceId, "offProgress");
                }

            }
        }

    }
}
