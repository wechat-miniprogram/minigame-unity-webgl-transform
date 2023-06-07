using UnityEngine;

using WeChatWASM;

public class ChatManager : MonoBehaviour
{
    private static WXChat WxChat = null;

    private void Start()
    {
        WX.InitSDK((code) =>
        {
            CreateChat();
        });
    }

    private void CreateChat()
    {
        if (WxChat != null)
        {
            // 已创建
            Debug.Log("已创建");
            return;
        }

        WxChat = WX.CreateMiniGameChat();

        if (WxChat == null)
        {
            // 创建失败
            return;
        }

        WxChat.On("ready", (res) =>
        {
            Debug.Log("wxChat ready");
        });

        WxChat.On("show", (res) =>
        {
            Debug.Log("wxChat show");
        });

        WxChat.On("hide", (res) =>
        {
            Debug.Log("wxChat hide");
        });

        WxChat.On("open", (res) =>
        {
            Debug.Log("wxChat open");
        });

        WxChat.On("close", (res) =>
        {
            Debug.Log("wxChat close");
        });

        WxChat.On("interact", (res) =>
        {
            Debug.Log("wxChat interact");
            Debug.Log(JsonUtility.ToJson(res));

            // TODO 处理互动消息
        });

        WxChat.On("authorize", (res) =>
        {
            Debug.Log("wxChat authorize");
            Debug.Log(JsonUtility.ToJson(res));

            // TODO 传rawData给后台，后台计算出signature后设置
            WxChat.SetChatSignature("test signature");
        });
    }

    public void Show()
    {
        if (WxChat != null)
        {
            WxChat.Show();
        }
    }

    public void Hide()
    {
        if (WxChat != null)
        {
            WxChat.Hide();
        }
    }

    public void SetTabs()
    {
        if (WxChat != null)
        {
            WxChat.SetTabs(new string[] { "chat", "player" });
        }
    }

    public void Open()
    {
        if (WxChat != null)
        {
            WxChat.Open();
        }
    }

    private void OnDestroy()
    {
        Hide();
    }
}
