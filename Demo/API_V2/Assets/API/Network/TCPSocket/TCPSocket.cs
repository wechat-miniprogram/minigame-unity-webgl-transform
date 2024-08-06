using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;

public class TCPSocket : Details
{
    private WXTCPSocket _tcpSocket;

    private bool _connected = false;

    // 数据
    private string _stringData1 = "String Data";
    private string _stringData2 = "123\n";


    private byte[] _bufferData1 = { 66, 117, 102, 102, 101, 114, 32, 68, 97, 116, 97, 32 };
    private byte[] _bufferData2 = { 0xab, 0x05, 0xd7, 0x05 };
    private byte[] _bufferData3 = new byte[8];

    private void Start()
    {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, connect);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, write);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, close);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        if (_tcpSocket == null)
        {
            _tcpSocket = WX.CreateTCPSocket();

            Debug.Log("tcpSocket: " + JsonUtility.ToJson(_tcpSocket));

            _tcpSocket.OnMessage((res) =>
            {
                Debug.Log("onMessage: " + JsonUtility.ToJson(res));
            });

            _tcpSocket.OnConnect((res) =>
            {
                Debug.Log("onConnect: " + JsonUtility.ToJson(res));
            });

            _tcpSocket.OnError((res) =>
            {
                Debug.Log("onError: " + JsonUtility.ToJson(res));
            });

            _tcpSocket.OnClose((res) =>
            {
                Debug.Log("onClose: " + JsonUtility.ToJson(res));
            });
        }
        else
        {
            Debug.LogError("tcp实例已初始化");
        }

    }

    private void close()
    {
        if (_tcpSocket != null && _connected)
        {
            _tcpSocket.Close();
            _connected = false;
            _tcpSocket = null;
        }
        else
        {
            Debug.LogError("关闭失败：tcp实例未初始化或未连接");
        }

    }


    private void connect()
    {
        if (_tcpSocket != null && !_connected)
        {
            _tcpSocket.Connect(new TCPSocketConnectOption()
            {
                address = "www.oooceanworld.com",
                port = 8101
            });
            _connected = true;
        }
        else
        {
            Debug.LogError("连接失败：tcp实例未初始化或已连接");
        }
    }

    private void write()
    {
        if (_tcpSocket != null && _connected)
        {
            if (options[0] == "String")
            {
                Debug.Log("test 1: " + _stringData1);
                _tcpSocket.Write(_stringData1);
                Debug.Log("test 2: " + _stringData2);
                _tcpSocket.Write(_stringData2);
            }
            else
            {
                Debug.Log("test 1: " + _bufferData1);
                _tcpSocket.Write(_bufferData1);
                Debug.Log("test 2: " + _bufferData2);
                _tcpSocket.Write(_bufferData2);
                Debug.Log("test 3: " + _bufferData3);
                _tcpSocket.Write(_bufferData3);
            }
        }
        else
        {
            Debug.LogError("发送失败：tcp实例未初始化或未连接");
        }
    }
}