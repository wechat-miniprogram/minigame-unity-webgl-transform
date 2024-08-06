using UnityEngine;

using WeChatWASM;

public class ChatManager : Details {
    private static WXChat WxChat = null;

    private void Start() {
        CreateChat();

        // 绑定额外的按钮操作
        GameManager.Instance.detailsController.BindExtraButtonAction(0, Hide);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, Open);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, Close);
    }

    // 测试 API
    protected override void TestAPI(string[] args) {
        Show();
    }

    private void CreateChat() {
        if (WxChat != null) {
            // 已创建
            Debug.Log("已创建");
            return;
        }

        WxChat = WX.CreateMiniGameChat();

        if (WxChat == null) {
            // 创建失败
            Debug.Log("WXchat is null");
            return;
        }

        WxChat.On("ready", (res) => {
            Debug.Log("wxChat ready");
            SetTabs();
        });

        WxChat.On("show", (res) => {
            Debug.Log("wxChat show");
        });

        WxChat.On("hide", (res) => {
            Debug.Log("wxChat hide");
        });

        WxChat.On("open", (res) => {
            Debug.Log("wxChat open");
        });

        WxChat.On("close", (res) => {
            Debug.Log("wxChat close");
        });

        WxChat.On("interact", (res) => {
            Debug.Log("wxChat interact");
            Debug.Log(JsonUtility.ToJson(res));

            // TODO 处理互动消息
        });

        WxChat.On("authorize", (res) => {
            Debug.Log("wxChat authorize");
            Debug.Log(JsonUtility.ToJson(res));

            // TODO 传rawData给后台，后台计算出signature后设置
            WxChat.SetChatSignature("test signature");
        });
    }

    public void Show() {
        if (WxChat != null) {
            WxChat.Show();
        }
    }

    public void Hide() {
        if (WxChat != null) {
            WxChat.Hide();
        }
    }

    public void SetTabs() {
        if (WxChat != null) {
            WxChat.SetTabs(new string[] { "chat", "player" });
        }
    }

    public void Open() {
        if (WxChat != null) {
            WxChat.Open();
        }
    }

    public void Close() {
        if (WxChat != null) {
            WxChat.Close();
        }
    }

    public void Destroy() {
        Hide();
    }
}