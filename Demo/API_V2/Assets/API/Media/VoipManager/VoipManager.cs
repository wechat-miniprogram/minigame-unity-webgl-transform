using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class VoipManager : Details
{
    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ExitVoIPChat);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        JoinVoIPChat();
    }

    public void JoinVoIPChat()
    {
        WX.JoinVoIPChat(
            new JoinVoIPChatOption()
            {
                signature = "xxxxxxxx",
                nonceStr = "xxxxxxx",
                timeStamp = 111111,
                groupId = "xxxxxxxx",
                success = (res) =>
                {
                    Debug.Log("JoinVoIPChat success");
                    Debug.Log(JsonUtility.ToJson(res));
                },
                fail = (res) =>
                {
                    Debug.Log("JoinVoIPChat fail");
                    Debug.Log(JsonUtility.ToJson(res));
                },
                complete = (res) =>
                {
                    Debug.Log("JoinVoIPChat complete");
                    Debug.Log(JsonUtility.ToJson(res));
                },
            }
        );

        WX.OnVoIPChatInterrupted(
            (res) =>
            {
                Debug.Log("OnVoIPChatInterrupted");
                Debug.Log(JsonUtility.ToJson(res));
            }
        );

        WX.OnVoIPChatMembersChanged(
            (res) =>
            {
                Debug.Log("OnVoIPChatMembersChanged");
                Debug.Log(JsonUtility.ToJson(res));
            }
        );

        WX.OnVoIPChatSpeakersChanged(
            (res) =>
            {
                Debug.Log("OnVoIPChatSpeakersChanged");
                Debug.Log(JsonUtility.ToJson(res));
            }
        );

        WX.OnVoIPChatStateChanged(
            (res) =>
            {
                Debug.Log("OnVoIPChatStateChanged");
                Debug.Log(JsonUtility.ToJson(res));
            }
        );
    }

    public void ExitVoIPChat()
    {
        WX.ExitVoIPChat(
            new ExitVoIPChatOption()
            {
                success = (res) =>
                {
                    Debug.Log("ExitVoIPChat success");
                    Debug.Log(JsonUtility.ToJson(res));
                },
                fail = (res) =>
                {
                    Debug.Log("ExitVoIPChat fail");
                    Debug.Log(JsonUtility.ToJson(res));
                },
                complete = (res) =>
                {
                    Debug.Log("ExitVoIPChat complete");
                    Debug.Log(JsonUtility.ToJson(res));
                },
            }
        );
    }
}
