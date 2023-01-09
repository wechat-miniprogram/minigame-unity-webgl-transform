using UnityEngine;
using System.Runtime.InteropServices;
using System;
using LitJson;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace WeChatWASM
{
    public class WXUploadTask
    {
        private string instanceId;
        public WXUploadTask(string id)
        {
            instanceId = id;
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUploadTaskAbort(string id);          
        public void Abort(string id){
            WXUploadTaskAbort(instanceId);
        }

        #if UNITY_WEBGL
                [DllImport("__Internal")]
        #endif
        private static extern void WXUploadTaskOffHeadersReceived(string id);
        public void OffHeadersReceived(Action<OnHeadersReceivedCallbackResult> callback){
            if(OnHeadersReceivedActionList == null){
                OnHeadersReceivedActionList = new Dictionary<string,Action<OnHeadersReceivedCallbackResult>>();
            }
            if(OnHeadersReceivedActionList.ContainsKey(instanceId)){
                OnHeadersReceivedActionList[instanceId] -= callback;
                if(OnHeadersReceivedActionList[instanceId] == null){
                    WXUploadTaskOffHeadersReceived(instanceId);
                }
            }
        }

        #if UNITY_WEBGL
                [DllImport("__Internal")]
        #endif
        private static extern void WXUploadTaskOffProgressUpdate(string id);
        public void OffProgressUpdate(Action<UploadTaskOnProgressUpdateCallbackResult> callback){
            if(OnProgressUpdateActionList == null){
                OnProgressUpdateActionList = new Dictionary<string,Action<UploadTaskOnProgressUpdateCallbackResult>>();
            }
            if(OnProgressUpdateActionList.ContainsKey(instanceId)){
                OnProgressUpdateActionList[instanceId] -= callback;
                if(OnProgressUpdateActionList[instanceId] == null){
                    WXUploadTaskOffProgressUpdate(instanceId);
                }
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUploadTaskOnHeadersReceived(string id);
        public static Dictionary<string,Action<OnHeadersReceivedCallbackResult>> OnHeadersReceivedActionList;
        public void OnHeadersReceived(Action<OnHeadersReceivedCallbackResult> callback){
            if(OnHeadersReceivedActionList == null){
                OnHeadersReceivedActionList = new Dictionary<string,Action<OnHeadersReceivedCallbackResult>>();
            }
            if(OnHeadersReceivedActionList.ContainsKey(instanceId)){
                OnHeadersReceivedActionList[instanceId] += callback;
            }else{
                OnHeadersReceivedActionList.Add(instanceId,callback);
                WXUploadTaskOnHeadersReceived(instanceId);
            }
        }

        #if UNITY_WEBGL
        [DllImport("__Internal")]
        #endif
        private static extern void WXUploadTaskOnProgressUpdate(string id);
        public static Dictionary<string,Action<UploadTaskOnProgressUpdateCallbackResult>> OnProgressUpdateActionList;
        public void OnProgressUpdate(Action<UploadTaskOnProgressUpdateCallbackResult> callback){
            if(OnProgressUpdateActionList == null){
                OnProgressUpdateActionList = new Dictionary<string,Action<UploadTaskOnProgressUpdateCallbackResult>>();
            }
            if(OnProgressUpdateActionList.ContainsKey(instanceId)){
                OnProgressUpdateActionList[instanceId] += callback;
            }else{
                OnProgressUpdateActionList.Add(instanceId,callback);
                WXUploadTaskOnProgressUpdate(instanceId);
            }
        }
    }

    [Preserve]
    public class UploadFileOption {
            /// <summary> 
            /// 要上传文件资源的路径 (本地路径)
            /// </summary>
                public string filePath;
            /// <summary> 
            /// 文件对应的 key，开发者在服务端可以通过这个 key 获取文件的二进制内容
            /// </summary>
                public string name;
            /// <summary> 
            /// 开发者服务器地址
            /// </summary>
                public string url;
            /// <summary> 
            /// 接口调用结束的回调函数（调用成功、失败都会执行）
            /// </summary>
                public Action<GeneralCallbackResult> complete;
            /// <summary> 
            /// 接口调用失败的回调函数
            /// </summary>
                public Action<GeneralCallbackResult> fail;
            /// <summary> 
            /// HTTP 请求中其他额外的 form data
            /// </summary>
                public Dictionary<string,string> formData;
            /// <summary> 
            /// HTTP 请求 Header，Header 中不能设置 Referer
            /// </summary>
                public Dictionary<string,string> header;
            /// <summary> 
            /// 接口调用成功的回调函数
            /// </summary>
                public Action<UploadFileSuccessCallbackResult> success;
            /// <summary> 
            /// 需要基础库： `2.10.0`
            /// 超时时间，单位为毫秒
            /// </summary>
                public double timeout;
    }
    [Preserve]
    public class UploadFileSuccessCallbackResult {
            /// <summary> 
            /// 开发者服务器返回的数据
            /// </summary>
                public string data;
            /// <summary> 
            /// 开发者服务器返回的 HTTP 状态码
            /// </summary>
                public double statusCode;

                public string errMsg;
    }
    [Preserve]
    public class OnHeadersReceivedCallbackResult {
            /// <summary> 
            /// 开发者服务器返回的 HTTP Response Header
            /// </summary>
                public Dictionary<string,string> header;
    }
    [Preserve]
    public class UploadTaskOnProgressUpdateCallbackResult {
            /// <summary> 
            /// 上传进度百分比
            /// </summary>
                public double progress;
            /// <summary> 
            /// 预期需要上传的数据总长度，单位 Bytes
            /// </summary>
                public double totalBytesExpectedToSend;
            /// <summary> 
            /// 已经上传的数据长度，单位 Bytes
            /// </summary>
                public double totalBytesSent;
    }
}
