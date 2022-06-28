using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace WeChatWASM {
  public class WXGameClubButton
  {
    #region C#调用JS桥接方法
#if UNITY_WEBGL
    [DllImport("__Internal")]
#endif
    private static extern void WXGameClubButtonDestroy(string id);
#if UNITY_WEBGL
    [DllImport("__Internal")]
#endif
    private static extern void WXGameClubButtonHide(string id);
#if UNITY_WEBGL
    [DllImport("__Internal")]
#endif
    private static extern void WXGameClubButtonSetProperty(string id, string key, string value);
#if UNITY_WEBGL
    [DllImport("__Internal")]
#endif
    private static extern void WXGameClubButtonShow(string id);
#if UNITY_WEBGL
    [DllImport("__Internal")]
#endif
    private static extern void WXGameClubButtonAddListener(string id, string key);
#if UNITY_WEBGL
    [DllImport("__Internal")]
#endif
    private static extern void WXGameClubButtonRemoveListener(string id, string key);
    
    #endregion

    public Hashtable ht = new Hashtable();
    public string instanceId;
    public WXGameClubButtonStyle style;
    public static Dictionary<string, WXGameClubButton> Dict = new Dictionary<string, WXGameClubButton>();
    private Action _onTap;
    private GameClubButtonIcon _icon;
    private GameClubButtonType _type;
    private string _text;
    private string _image;


#if UNITY_WEBGL && !UNITY_EDITOR
    private static readonly bool isWebGL = true;
#else
    private static readonly bool isWebGL = false;
#endif

    public WXGameClubButton(string id, GameClubButtonStyle style)
    {
      instanceId = id;
      this.style = new WXGameClubButtonStyle(id, style);
      Dict.Add(id, this);
    }

    public GameClubButtonIcon icon
    {
      get
      {
        return _icon;
      }
      set
      {
        if (_type == GameClubButtonType.image) {
          if (!isWebGL) {
            ht["icon"] = value;
          } else {
            WXGameClubButtonSetProperty(instanceId, "icon", value.ToString());
          }
          _icon = value;
        }
      }
    }

    public GameClubButtonType type
    {
      get
      {
        return _type;
      }
      set
      {
        if (_type != value) {
          if (!isWebGL) {
            ht["type"] = value;
          } else {
            WXGameClubButtonSetProperty(instanceId, "type", value.ToString());
          }
          _type = value;
        }
      }
    }

    public string text
    {
      get
      {
        return _text;
      }
      set
      {
        if (_type == GameClubButtonType.text) {
          if (!isWebGL) {
            ht["text"] = value;
          } else {
            WXGameClubButtonSetProperty(instanceId, "text", value);
          }
          _text = value;
        }
      }
    }

    public string image
    {
      get
      {
        return _image;
      }
      set
      {
        if (_type == GameClubButtonType.image) {
          if (!isWebGL) {
            ht["image"] = value;
          } else {
            WXGameClubButtonSetProperty(instanceId, "image", value);
          }
          _image = value;
        }
      }
    }

    public WXGameClubButtonStyle styleObj
    {
      get
      {
        return style;
      }
      set
      {
        var props = value.GetType().GetProperties();
        var styleProps = style.GetType().GetProperties();
        // 遍历样式值，逐个设置
        foreach (var prop in props)
        {
          foreach (var styleProp in styleProps)
          {
            // styleObj是原始对象，不需要手动设置值
            if (styleProp.Name == prop.Name && styleProp.Name != "styleObj") {
              styleProp.SetValue(style, prop.GetValue(value));
            }
          }
        }
      }
    }

    public void Destroy()
    {
      if (isWebGL) {
        WXGameClubButtonDestroy(instanceId);
      } else {
        Debug.Log("游戏圈按钮destroy");
      }
      Dict.Remove(instanceId);
    }
    public void Hide()
    {
      if (isWebGL) {
        WXGameClubButtonHide(instanceId);
      } else {
        Debug.Log("游戏圈按钮hide");
      }
    }
    public void Show()
    {
      if (isWebGL) {
        WXGameClubButtonShow(instanceId);
      } else {
        Debug.Log("游戏圈按钮show");
      }
    }
    public void OnTap(Action action)
    {
      if (_onTap == null) {
        if (isWebGL) {
          WXGameClubButtonAddListener(instanceId, "onTap");
        }
      }
      _onTap += action;
    }

    public void OffTap(Action action = null)
    {
      if (action == null) {
        _onTap = null;
      }
      else
      {
        _onTap -= action;
      }
      if (_onTap == null) {
        if (isWebGL) {
          WXGameClubButtonRemoveListener(instanceId, "offTap");
        }
      }
    }
    public void _HandleCallBack(string key)
    {
      switch (key) {
        case "onTap":
          _onTap?.Invoke();
          break;
      }
    }
  }

  public class WXGameClubButtonStyle
  {
    private GameClubButtonStyle style;
    private string instanceId;
    public WXGameClubButtonStyle(string id, GameClubButtonStyle style)
    {
      instanceId = id;
      this.style = style;
    }

    public GameClubButtonStyle styleObj
    {
      get
      {
        return style;
      }
    }

    public int left
    {
      get
      {
        return style.left;
      }
      set
      {
        style.left = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeInt(instanceId, "left", value);
      }
    }

    public int top
    {
      get
      {
        return style.top;
      }
      set
      {
        style.top = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeInt(instanceId, "top", value);
      }
    }

    public int width
    {
      get
      {
        return style.width;
      }
      set
      {
        style.width = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeInt(instanceId, "width", value);
      }
    }

    public int height
    {
      get
      {
        return style.height;
      }
      set
      {
        style.height = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeInt(instanceId, "height", value);
      }
    }

    public int borderWidth
    {
      get
      {
        return style.borderWidth;
      }
      set
      {
        style.borderWidth = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeInt(instanceId, "borderWidth", value);
      }
    }

    public int borderRadius
    {
      get
      {
        return style.borderRadius;
      }
      set
      {
        style.borderRadius = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeInt(instanceId, "borderRadius", value);
      }
    }

    public int fontSize
    {
      get
      {
        return style.fontSize;
      }
      set
      {
        style.fontSize = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeInt(instanceId, "fontSize", value);
      }
    }

    public int lineHeight
    {
      get
      {
        return style.lineHeight;
      }
      set
      {
        style.lineHeight = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeInt(instanceId, "lineHeight", value);
      }
    }

    public string backgroundColor
    {
      get
      {
        return style.backgroundColor;
      }
      set
      {
        style.backgroundColor = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeStr(instanceId, "backgroundColor", value);
      }
    }

    public string borderColor
    {
      get
      {
        return style.borderColor;
      }
      set
      {
        style.borderColor = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeStr(instanceId, "borderColor", value);
      }
    }

    public string color
    {
      get
      {
        return style.color;
      }
      set
      {
        style.color = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeStr(instanceId, "color", value);
      }
    }

    public GameClubButtonTextAlign textAlign
    {
      get
      {
        return style.textAlign;
      }
      set
      {
        style.textAlign = value;
        WXSDKManagerHandler.Instance.GameClubStyleChangeStr(instanceId, "textAlign", value.ToString());
      }
    }
  }
}