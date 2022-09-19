using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace WeChatWASM {
  public class LaunchProgressParams {
    public string callbackId;
    public string res;
  }
  public class WXLaunchEventListener {
#if UNITY_WEBGL
        [DllImport("__Internal")]
#endif
    private static extern string WXOnLaunchProgress();

    public Action<LaunchEvent> OnLaunchProgressAction;
    public static Dictionary<string, WXLaunchEventListener> Dict = new Dictionary<string, WXLaunchEventListener>();

    public WXLaunchEventListener(Action<LaunchEvent> action) {
      var id = WXOnLaunchProgress();
      Dict.Add(id, this);
      OnLaunchProgressAction+=action;
    }
  }
}