using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace WeChatWASM {
  public class CleanFileCacheParams {
    public string callbackId;
    public ReleaseResult result;
  }
  public class FileCacheCommonParams {
    public string callbackId;
    public bool result;
  }
  public class WXFileCacheCleanTask {
#if UNITY_WEBGL
    [DllImport("__Internal")]
#endif
    private static extern string WXCleanFileCache(int fileSize);
#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
        private static extern string WXCleanAllFileCache();
#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
    private static extern string WXRemoveFile(string path);


    public Action<ReleaseResult> OnCleanFileCacheAction;
    public Action<bool> OnCleanAllFileCacheAction;
    public Action<bool> OnRemoveFileAction;
    public static Dictionary<string, WXFileCacheCleanTask> Dict = new Dictionary<string, WXFileCacheCleanTask>();
    public WXFileCacheCleanTask(int fileSize, Action<ReleaseResult> action = null) {
      var id = WXCleanFileCache(fileSize);
      Dict.Add(id, this);
      OnCleanFileCacheAction+=action;
    }
    public WXFileCacheCleanTask(bool removeAll, Action<bool> action = null) {
      var id = WXCleanAllFileCache();
      Dict.Add(id, this);
      OnCleanAllFileCacheAction+=action;
    }
    public WXFileCacheCleanTask(string path, Action<bool> action = null) {
      var id = WXRemoveFile(path);
      Dict.Add(id, this);
      OnRemoveFileAction+=action;
    }
  }
}