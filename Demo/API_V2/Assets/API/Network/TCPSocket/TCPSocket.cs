using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class TCPSocket : Details
{
    private WXTCPSocket _tcpSocket;

    private void Start() {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, connect);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, close);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        _tcpSocket = WX.CreateTCPSocket();
        Debug.Log("tcpSocket: " + JsonUtility.ToJson(_tcpSocket));

        _tcpSocket.OnConnect((res) => {
            Debug.Log("onConnect: " + JsonUtility.ToJson(res));
        });

        _tcpSocket.OnError((res) => {
            Debug.Log("onError: " + JsonUtility.ToJson(res));
        });

        _tcpSocket.OnClose((res) => {
            Debug.Log("onClose: " + JsonUtility.ToJson(res));
        });

        _tcpSocket.OnMessage((res) => {
            Debug.Log("onMessage: " + JsonUtility.ToJson(res));
        });
    }

    private void connect() {
        _tcpSocket.Connect(new TCPSocketConnectOption() {
            address = "192.168.193.2",
            port = 8848
        });
    }

    private void close() {
        _tcpSocket.Close();
    }
}

