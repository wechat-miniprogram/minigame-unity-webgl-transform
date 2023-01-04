using System;
using System.Collections.Generic;
using UnityEngine;

namespace WeChatWASM
{
    /* 
     *  Use Example:
     *  WeChatWASM.UDPClient udpclient = new WeChatWASM.UDPClient("119.28.188.49", 7890);
        udpclient.SetCallBack((bytes) =>
        {
            Debug.Log($"Udp OnMessage {bytes.Length}");
        },
        (closeReason) =>
        {
            Debug.LogError($"Udp OnClose {closeReason}");
        },
        (errorMessage) =>
        {
            Debug.LogError($"Udp OnError {errorMessage}");
        }
        );
        var bytes = System.Text.Encoding.UTF8.GetBytes("Hello World");
        udpclient.Send(bytes, 0, bytes.Length);
    */
    public class UDPClient
    {
        public int socketId = 0;
        private Action<byte[]> udpMessageCallback;
        private Action<string> udpCloseCallback;
        private Action<string> udpErrorCallback;
        public UDPClient(string ip, int remotePort, int localPort = 0)
        {
            socketId = WeChatWASM.WX.CreateUDPSocket(ip, remotePort, localPort);
            UDPSocketManager.Instance.AddClient(this);
        }
        public void SetCallBack(Action<byte[]> udpMessageCallback,
            Action<string>  udpCloseCallback,
            Action<string>  udpErrorCallback)
        {
            this.udpMessageCallback = udpMessageCallback;
            this.udpCloseCallback = udpCloseCallback;
            this.udpErrorCallback = udpErrorCallback;
        }
        public void Send(byte[] buffer, int offset, int length)
        {
            WeChatWASM.WX.SendUDPSocket(socketId, buffer, offset, length);
        }

        public void OnMessage(byte[] data)
        {
            if (this.udpMessageCallback != null) this.udpMessageCallback(data);
        }

        public void OnClose(string reason)
        {
            if (this.udpCloseCallback != null) this.udpCloseCallback(reason);
        }

        public void OnError(string errorMessage)
        {
            if (this.udpErrorCallback != null) this.udpErrorCallback(errorMessage);
        }
        public void Destroy()
        {
            WeChatWASM.WX.CloseUDPSocket(this.socketId);
            UDPSocketManager.Instance.DeleteClient(this);
        }

    }


    public class UDPSocketManager
    {
        private Dictionary<int, UDPClient> instances = new Dictionary<int, UDPClient>();
        public static UDPSocketManager Instance = new UDPSocketManager();
        public UDPSocketManager()
        {
        }
        public void OnMessage(int socketId, byte[] data)
        {
            {
                UDPClient client;
                if (instances.TryGetValue(socketId, out client))
                {
                    client.OnMessage(data);
                }
                else
                {
                    Debug.LogError($"UDPClient not found {socketId}");
                }
            }
        }
        public void OnClose(int socketId, string closeReason)
        {
            UDPClient client;
            if (instances.TryGetValue(socketId, out client))
            {
                client.OnClose(closeReason);
            }
            else
            {
                Debug.LogError($"UDPClient not found {socketId}");
            }

        }

        public void OnError(int socketId, string errorMessage)
        {
            UDPClient client;
            if (instances.TryGetValue(socketId, out client))
            {
                client.OnError(errorMessage);
            }
            else
            {
                Debug.LogError($"UDPClient not found {socketId}");
            }
        }
        public void AddClient(UDPClient client)
        {
            instances.Add(client.socketId, client);
        }
        public void DeleteClient(UDPClient client)
        {
            if (instances.ContainsKey(client.socketId))
            {
                instances.Remove(client.socketId);
            }
        }
    }
}
