using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using WeChatWASM;
public class UDPSocket : Details {
    private WXUDPSocket _udpSocket;
    private bool _connected = false;

    // 数据
    private string _stringData = "hello, how are you";
    private byte[] _bufferData = { 66, 117, 102, 102, 101, 114, 32, 68, 97, 116, 97, 32 };

    private void Start() {
        GameManager.Instance.detailsController.BindExtraButtonAction(0, connect);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, write);
        GameManager.Instance.detailsController.BindExtraButtonAction(2, send);
        GameManager.Instance.detailsController.BindExtraButtonAction(3, close);
    }

    // 测试 API
    protected override void TestAPI(string[] args) {
        if (_udpSocket == null) {
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
        } else {
            Debug.LogError("udp实例已初始化");
        }
    }

    private void connect() {
        if (_udpSocket != null && !_connected) {
            _udpSocket.Connect(new UDPSocketConnectOption() {
                address = "www.oooceanworld.com",
                port = 8101
            });
            _connected = true;
        } else {
            Debug.LogError("连接失败：udp实例未初始化或已连接");
        }
    }

    private void write() {
        if (_udpSocket != null && _connected) {
            Debug.LogError("接口有bug暂未修复 当前为placeholder");
            /*
            UDPSocketWriteOption option = new UDPSocketWriteOption()
            {
                address = "www.oooceanworld.com",
                port = 8101
            };
            if (options[0] == "String")
            {
                option.message = _stringData;
            }
            else
            {
                option.message = _bufferData;
            }
            _udpSocket.Write(option);
            */
        } else {
            Debug.LogError("write失败：udp实例未初始化或未连接");
        }
    }

    private void send() {
        if (_udpSocket != null) {
            UDPSocketSendOption option = new UDPSocketSendOption() {
                address = "www.oooceanworld.com",
                port = 8101
            };
            if (options[0] == "String") {
                option.message = _stringData;
            } else {
                option.message = _bufferData;
            }
            _udpSocket.Send(option);
            Debug.Log("Message: " + option.message);
        } else {
            Debug.LogError("send失败：udp实例未初始化");
        }
    }

    private void close() {
        if (_udpSocket != null && _connected) {
            _udpSocket.Close();
            _connected = false;
            _udpSocket = null;
        } else {
            Debug.LogError("关闭失败：udp实例未初始化或未连接");
        }
    }
}