using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class TCPSocket : Details
{
    private WXTCPSocket _tcpSocket;

    // 数据
    private string _stringData1 = "String Data";
    private string _stringData2 = "123\n";
    

    private byte[] _bufferData1 = { 66, 117, 102, 102, 101, 114, 32, 68, 97, 116, 97, 32 };
    private byte[] _bufferData2 = { 0xab, 0x05, 0xd7, 0x05 };
    private byte[] _bufferData3 = new byte[8];

    private int[] _bufferData4 = { 66, 117, 102, 102, 101, 114, 32, 68, 97, 116, 97, 32 };
    private int[] _bufferData5 = { 0xab, 0x05, 0xd7, 0x05 };
    private int[] _bufferData6 = new int[8];


    private void Start() {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, connect);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, close);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, write);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, writeBuffer);
    }

    // 测试 API
    protected override void TestAPI(string[] args)
    {
        _tcpSocket = WX.CreateTCPSocket();
        Debug.Log("tcpSocket: " + JsonUtility.ToJson(_tcpSocket));

        _tcpSocket.OnMessage((res) => {
            Debug.Log("onMessage: " + JsonUtility.ToJson(res));
        });

        _tcpSocket.OnConnect((res) => {
            Debug.Log("onConnect: " + JsonUtility.ToJson(res));
        });

        _tcpSocket.OnError((res) => {
            Debug.Log("onError: " + JsonUtility.ToJson(res));
        });

        _tcpSocket.OnClose((res) => {
            Debug.Log("onClose: " + JsonUtility.ToJson(res));
        });
    }

    private void connect() {
        Debug.Log("connect test start");
        _tcpSocket.Connect(new TCPSocketConnectOption() {
            address = "www.oooceanworld.com", port = 8101
        });
    }

    private void close() {
        Debug.Log("close test start");
        _tcpSocket.Close();
    }

    private void write() {
        Debug.Log("write string test start: "+_stringData);
        _tcpSocket.Write(_stringData);
    }

    private void writeBuffer()
    {
        Debug.Log("write buffer test start:");
        Debug.Log("test 1: "+_bufferData1);
        _tcpSocket.Write(_bufferData1);
        Debug.Log("test 2: " + _bufferData2);
        _tcpSocket.Write(_bufferData2);
        Debug.Log("test 3: " + _bufferData3);
        _tcpSocket.Write(_bufferData3);
        Debug.Log("test 4: " + _bufferData4);
        _tcpSocket.Write(_bufferData4);
        Debug.Log("test 5: " + _bufferData5);
        _tcpSocket.Write(_bufferData5);
        Debug.Log("test 6: " + _bufferData6);
        _tcpSocket.Write(_bufferData6);
    }
}

