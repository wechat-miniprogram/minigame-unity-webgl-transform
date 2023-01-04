using UnityEngine;
using System.Runtime.InteropServices;
using System;
using LitJson;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace WeChatWASM
{
    /// <summary>
    /// 微信相机
    /// </summary>
    public class WXCamera
    {
        private string instanceId;
        public WXCamera(string id)
        {
            instanceId = id;
        }

        /// <summary>
        /// [Camera.closeFrameChange()](https://developers.weixin.qq.com/minigame/dev/api/media/camera/Camera.closeFrameChange.html)
        /// 需要基础库： `2.9.0`
        /// 关闭监听帧数据
        /// </summary>
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXCameraCloseFrameChange(string id);          
        public void CloseFrameChange(){
            WXCameraCloseFrameChange(instanceId);
        }

        /// <summary>
        /// [Camera.destroy()](https://developers.weixin.qq.com/minigame/dev/api/media/camera/Camera.destroy.html)
        /// 需要基础库： `2.9.0`
        /// 销毁相机
        /// </summary>
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXCameraDestroy(string id);          
        public void Destroy(){
            WXCameraDestroy(instanceId);
        }

        /// <summary>
        /// [Camera.listenFrameChange()](https://developers.weixin.qq.com/minigame/dev/api/media/camera/Camera.listenFrameChange.html)
        /// 需要基础库： `2.9.0`
        /// 开启监听帧数据
        /// </summary>
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXCameraListenFrameChange(string id);          
        public void ListenFrameChange(){
            WXCameraListenFrameChange(instanceId);
        }
        
        /// <summary>
        /// [Camera.onAuthCancel(function callback)](https://developers.weixin.qq.com/minigame/dev/api/media/camera/Camera.onAuthCancel.html)
        /// 需要基础库： `2.9.0`
        /// 监听用户不允许授权使用摄像头的情况
        /// </summary>
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXCameraOnAuthCancel(string id);
        public static Dictionary<string,Action> OnAuthCancelActionList;            
        public void OnAuthCancel(Action callback){
            if(OnAuthCancelActionList == null){
                OnAuthCancelActionList = new Dictionary<string,Action>();
            }
            if(OnAuthCancelActionList.ContainsKey(instanceId)){
                OnAuthCancelActionList[instanceId] += callback;
            }else{
                OnAuthCancelActionList.Add(instanceId, callback);
                WXCameraOnAuthCancel(instanceId);
            }
        }

        /// <summary>
        /// [Camera.onCameraFrame(function callback)](https://developers.weixin.qq.com/minigame/dev/api/media/camera/Camera.onCameraFrame.html)
        /// 需要基础库： `2.9.0`
        /// 监听摄像头实时帧数据
        /// </summary>
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXCameraOnCameraFrame(string id);
        public static Dictionary<string,Action<OnCameraFrameCallbackResult>> OnCameraFrameActionList;            
        public void OnCameraFrame(Action<OnCameraFrameCallbackResult> callback){
            if(OnCameraFrameActionList == null){
                OnCameraFrameActionList = new Dictionary<string,Action<OnCameraFrameCallbackResult>>();
            }
            if(OnCameraFrameActionList.ContainsKey(instanceId)){
                OnCameraFrameActionList[instanceId] += callback;
            }else{
                OnCameraFrameActionList.Add(instanceId, callback);
                WXCameraOnCameraFrame(instanceId);
            }
        }
        
        /// <summary>
        /// [Camera.onStop(function callback)](https://developers.weixin.qq.com/minigame/dev/api/media/camera/Camera.onStop.html)
        /// 需要基础库： `2.9.0`
        /// 监听摄像头非正常终止事件，如退出后台等情况
        /// </summary>
        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXCameraOnStop(string id);
        public static Dictionary<string,Action> OnStopActionList;            
        public void OnStop(Action callback){
            if(OnStopActionList == null){
                OnStopActionList = new Dictionary<string,Action>();
            }
            if (OnStopActionList.ContainsKey(instanceId)){
                OnStopActionList[instanceId] += callback;
            }else{
                OnStopActionList.Add(instanceId, callback);
                WXCameraOnStop(instanceId);
            }
        }
    }

    [Preserve]
    public class OnCameraFrameCallbackResult
    {
        /// <summary> 
        /// 图像像素点数据，一维数组，每四项表示一个像素点的 rgba
        /// </summary>
        public byte[] data;
        /// <summary> 
        /// 图像数据矩形的高度
        /// </summary>
        public int height;
        /// <summary> 
        /// 图像数据矩形的宽度
        /// </summary>
        public int width;
    }
    [Preserve]
    public class CreateCameraOption {
        /// <summary> 
        /// 接口调用结束的回调函数（调用成功、失败都会执行）
        /// </summary>
        public Action<GeneralCallbackResult> complete;
        /// <summary> 
        /// 摄像头朝向，值为 front, back
        /// </summary>
        public string devicePosition = "back";
        /// <summary> 
        /// 接口调用失败的回调函数
        /// </summary>
        public Action<GeneralCallbackResult> fail;
        /// <summary> 
        /// 闪光灯，值为 auto, on, off
        /// </summary>
        public string flash = "auto";
        /// <summary> 
        /// 相机的高度
        /// </summary>
        public double height = 150f;
        /// <summary> 
        /// 帧数据图像尺寸，值为 small, medium, large
        /// </summary>
        public string size = "small";
        /// <summary> 
        /// 接口调用成功的回调函数
        /// </summary>
        public Action<GeneralCallbackResult> success;
        /// <summary> 
        /// 相机的宽度
        /// </summary>
        public double width = 300f;
        /// <summary> 
        /// 相机的左上角横坐标
        /// </summary>
        public double x = 0f;
        /// <summary> 
        /// 相机的左上角纵坐标
        /// </summary>
        public double y = 0f;
    }
}