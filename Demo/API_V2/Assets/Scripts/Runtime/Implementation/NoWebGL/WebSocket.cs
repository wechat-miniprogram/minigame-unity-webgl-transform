#if !NET_LEGACY && (UNITY_EDITOR || !UNITY_WEBGL)
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.IO;

namespace UnityWebSocket
{
    public class WebSocket : IWebSocket
    {
        public string Address { get; private set; }

        public WebSocketState ReadyState
        {
            get
            {
                if (socket == null)
                    return WebSocketState.Closed;
                switch (socket.State)
                {
                    case System.Net.WebSockets.WebSocketState.Closed:
                    case System.Net.WebSockets.WebSocketState.None:
                        return WebSocketState.Closed;
                    case System.Net.WebSockets.WebSocketState.CloseReceived:
                    case System.Net.WebSockets.WebSocketState.CloseSent:
                        return WebSocketState.Closing;
                    case System.Net.WebSockets.WebSocketState.Connecting:
                        return WebSocketState.Connecting;
                    case System.Net.WebSockets.WebSocketState.Open:
                        return WebSocketState.Open;
                }
                return WebSocketState.Closed;
            }
        }

        public event EventHandler<OpenEventArgs> OnOpen;
        public event EventHandler<CloseEventArgs> OnClose;
        public event EventHandler<ErrorEventArgs> OnError;
        public event EventHandler<MessageEventArgs> OnMessage;

        private ClientWebSocket socket;
        private bool isOpening => socket != null && socket.State == System.Net.WebSockets.WebSocketState.Open;

        #region APIs
        public WebSocket(string address)
        {
            this.Address = address;
        }

        public void ConnectAsync()
        {
#if !UNITY_WEB_SOCKET_ENABLE_ASYNC
            WebSocketManager.Instance.Add(this);
#endif
            if (socket != null)
            {
                HandleError(new Exception("Socket is busy."));
                return;
            }
            socket = new ClientWebSocket();
            socket.Options.AddSubProtocol("binary");
            Task.Run(ConnectTask);
        }

        public void CloseAsync()
        {
            if (!isOpening) return;
            SendBufferAsync(new SendBuffer(null, WebSocketMessageType.Close));
        }

        public void SendAsync(byte[] data)
        {
            if (!isOpening) return;
            var buffer = new SendBuffer(data, WebSocketMessageType.Binary);
            SendBufferAsync(buffer);
        }

        public void SendAsync(string text)
        {
            if (!isOpening) return;
            var data = Encoding.UTF8.GetBytes(text);
            var buffer = new SendBuffer(data, WebSocketMessageType.Text);
            SendBufferAsync(buffer);
        }
        #endregion


        private async Task ConnectTask()
        {
            Log("Connect Task Begin ...");

            try
            {
                var uri = new Uri(Address);
                await socket.ConnectAsync(uri, CancellationToken.None);
            }
            catch (Exception e)
            {
                HandleError(e);
                HandleClose((ushort)CloseStatusCode.Abnormal, e.Message);
                SocketDispose();
                return;
            }

            HandleOpen();

            Log("Connect Task End !");

            await ReceiveTask();
        }

        class SendBuffer
        {
            public byte[] data;
            public WebSocketMessageType type;
            public SendBuffer(byte[] data, WebSocketMessageType type)
            {
                this.data = data;
                this.type = type;
            }
        }

        private object sendQueueLock = new object();
        private Queue<SendBuffer> sendQueue = new Queue<SendBuffer>();
        private bool isSendTaskRunning;

        private void SendBufferAsync(SendBuffer buffer)
        {
            if (isSendTaskRunning)
            {
                lock (sendQueueLock)
                {
                    if (buffer.type == WebSocketMessageType.Close)
                    {
                        sendQueue.Clear();
                    }
                    sendQueue.Enqueue(buffer);
                }
            }
            else
            {
                isSendTaskRunning = true;
                sendQueue.Enqueue(buffer);
                Task.Run(SendTask);
            }
        }

        private async Task SendTask()
        {
            Log("Send Task Begin ...");

            try
            {
                SendBuffer buffer = null;
                while (sendQueue.Count > 0 && isOpening)
                {
                    lock (sendQueueLock)
                    {
                        buffer = sendQueue.Dequeue();
                    }
                    if (buffer.type == WebSocketMessageType.Close)
                    {
                        Log($"Close Send Begin ...");
                        await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Normal Closure", CancellationToken.None);
                        Log($"Close Send End !");
                    }
                    else
                    {
                        Log($"Send, type: {buffer.type}, size: {buffer.data.Length}, queue left: {sendQueue.Count}");
                        await socket.SendAsync(new ArraySegment<byte>(buffer.data), buffer.type, true, CancellationToken.None);
                    }
                }
            }
            catch (Exception e)
            {
                HandleError(e);
            }
            finally
            {
                isSendTaskRunning = false;
            }

            Log("Send Task End !");
        }

        private async Task ReceiveTask()
        {
            Log("Receive Task Begin ...");

            string closeReason = "";
            ushort closeCode = 0;
            bool isClosed = false;
            var segment = new ArraySegment<byte>(new byte[8192]);
            var ms = new MemoryStream();

            try
            {
                while (!isClosed)
                {
                    var result = await socket.ReceiveAsync(segment, CancellationToken.None);
                    ms.Write(segment.Array, 0, result.Count);
                    if (!result.EndOfMessage) continue;
                    var data = ms.ToArray();
                    ms.SetLength(0);
                    switch (result.MessageType)
                    {
                        case WebSocketMessageType.Binary:
                            HandleMessage(Opcode.Binary, data);
                            break;
                        case WebSocketMessageType.Text:
                            HandleMessage(Opcode.Text, data);
                            break;
                        case WebSocketMessageType.Close:
                            isClosed = true;
                            closeCode = (ushort)result.CloseStatus;
                            closeReason = result.CloseStatusDescription;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                HandleError(e);
                closeCode = (ushort)CloseStatusCode.Abnormal;
                closeReason = e.Message;
            }
            finally
            {
                ms.Close();
            }

            HandleClose(closeCode, closeReason);
            SocketDispose();

            Log("Receive Task End !");
        }

        private void SocketDispose()
        {
            sendQueue.Clear();
            socket.Dispose();
            socket = null;
        }

        private void HandleOpen()
        {
            Log("OnOpen");
#if !UNITY_WEB_SOCKET_ENABLE_ASYNC
            HandleEventSync(new OpenEventArgs());
#else
            OnOpen?.Invoke(this, new OpenEventArgs());
#endif
        }

        private void HandleMessage(Opcode opcode, byte[] rawData)
        {
            Log($"OnMessage, type: {opcode}, size: {rawData.Length}");
#if !UNITY_WEB_SOCKET_ENABLE_ASYNC
            HandleEventSync(new MessageEventArgs(opcode, rawData));
#else
            OnMessage?.Invoke(this, new MessageEventArgs(opcode, rawData));
#endif
        }

        private void HandleClose(ushort code, string reason)
        {
            Log($"OnClose, code: {code}, reason: {reason}");
#if !UNITY_WEB_SOCKET_ENABLE_ASYNC
            HandleEventSync(new CloseEventArgs(code, reason));
#else
            OnClose?.Invoke(this, new CloseEventArgs(code, reason));
#endif
        }

        private void HandleError(Exception exception)
        {
            Log("OnError, error: " + exception.Message);
#if !UNITY_WEB_SOCKET_ENABLE_ASYNC
            HandleEventSync(new ErrorEventArgs(exception.Message));
#else
            OnError?.Invoke(this, new ErrorEventArgs(exception.Message));
#endif
        }

#if !UNITY_WEB_SOCKET_ENABLE_ASYNC
        private readonly Queue<EventArgs> eventQueue = new Queue<EventArgs>();
        private readonly object eventQueueLock = new object();
        private void HandleEventSync(EventArgs eventArgs)
        {
            lock (eventQueueLock)
            {
                eventQueue.Enqueue(eventArgs);
            }
        }

        internal void Update()
        {
            EventArgs e;
            while (eventQueue.Count > 0)
            {
                lock (eventQueueLock)
                {
                    e = eventQueue.Dequeue();
                }

                if (e is CloseEventArgs)
                {
                    OnClose?.Invoke(this, e as CloseEventArgs);
                    WebSocketManager.Instance.Remove(this);
                }
                else if (e is OpenEventArgs)
                {
                    OnOpen?.Invoke(this, e as OpenEventArgs);
                }
                else if (e is MessageEventArgs)
                {
                    OnMessage?.Invoke(this, e as MessageEventArgs);
                }
                else if (e is ErrorEventArgs)
                {
                    OnError?.Invoke(this, e as ErrorEventArgs);
                }
            }
        }
#endif

        [System.Diagnostics.Conditional("UNITY_WEB_SOCKET_LOG")]
        static void Log(string msg)
        {
            UnityEngine.Debug.Log($"<color=yellow>[UnityWebSocket]</color>" +
                $"<color=green>[T-{Thread.CurrentThread.ManagedThreadId:D3}]</color>" +
                $"<color=red>[{DateTime.Now.TimeOfDay}]</color>" +
                $" {msg}");
        }
    }
}
#endif
