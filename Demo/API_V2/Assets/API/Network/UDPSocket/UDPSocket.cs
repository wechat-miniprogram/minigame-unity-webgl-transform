using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class UDPSocket : Details
{
    private WXUDPSocket _udpSocket;

    private void Start() {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, connect);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, close);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        _udpSocket = WX.CreateUDPSocket();
        var port = _udpSocket.Bind();

        Debug.Log("udpSocket: " + JsonUtility.ToJson(_udpSocket));

        _udpSocket.OnListening((res) => {
            Debug.Log("onListening: " + JsonUtility.ToJson(res));
        });

        _udpSocket.OnError((res) => {
            Debug.Log("onError: " + JsonUtility.ToJson(res));
        });

        _udpSocket.OnClose((res) => {
            Debug.Log("onClose: " + JsonUtility.ToJson(res));
        });

        _udpSocket.OnMessage((res) => {
            Debug.Log("onMessage: " + JsonUtility.ToJson(res));
        });
    }

    private void connect() {
        _udpSocket.Connect(new UDPSocketConnectOption() {
            address = "192.168.193.2",
            port = 8848
        });
    }

    private void close() {
        _udpSocket.Close();
    }
}

