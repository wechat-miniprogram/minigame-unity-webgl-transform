using UnityEngine;

namespace UnityWebSocket.Demo
{
    public class UnityWebSocket : MonoBehaviour
    {
        public string address = "ws://127.0.0.1:8080";
        public string sendText = "Hello World!";
        public bool logMessage = true;

        private IWebSocket socket;

        private string log = "";
        private int sendCount;
        private int receiveCount;
        private Vector2 scrollPos;
        private Color green = new Color(0.1f, 1, 0.1f);
        private Color red = new Color(1f, 0.1f, 0.1f);
        private Color wait = new Color(0.7f, 0.3f, 0.3f);

        private void OnGUI()
        {
            var scale = UnityEngine.Screen.width / 800f;
            GUI.matrix = Matrix4x4.TRS(
                new Vector3(0, 0, 0),
                Quaternion.identity,
                new Vector3(scale, scale, 1)
            );
            var width = GUILayout.Width(UnityEngine.Screen.width / scale - 10);
            var w = UnityEngine.Screen.width / scale - 10;
            WebSocketState state = socket == null ? WebSocketState.Closed : socket.ReadyState;

            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = 26;

            GUILayout.BeginHorizontal();
            GUILayout.Label(
                "",
                GUILayout.Width(UnityEngine.Screen.width / scale - 100),
                GUILayout.Height(250)
            );
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label(
                "SDK Version: " + Settings.VERSION,
                style,
                GUILayout.Width(UnityEngine.Screen.width / scale - 300)
            );
            GUI.color = green;
            GUILayout.Label($"FPS: {fps:F2}", style, GUILayout.Width(300));
            GUI.color = Color.white;
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("State: ", style, GUILayout.Width(70));
            GUI.color =
                WebSocketState.Closed == state
                    ? red
                    : WebSocketState.Open == state
                        ? green
                        : wait;
            GUILayout.Label($"{state}", style, GUILayout.Width(300));
            GUI.color = Color.white;
            GUILayout.EndHorizontal();

            GUI.enabled = state == WebSocketState.Closed;
            GUILayout.Label("Address: ", style, width);
            style.normal.background = MakeTex(2, 2, Color.grey);
            address = GUILayout.TextField(address, style, width, GUILayout.Height(50));

            GUILayout.BeginHorizontal();
            style.alignment = TextAnchor.MiddleCenter;
            style.normal.background = MakeTex(2, 2, Color.grey);

            GUI.enabled = state == WebSocketState.Closed;
            if (
                GUILayout.Button(
                    state == WebSocketState.Connecting ? "Connecting..." : "Connect",
                    style,
                    GUILayout.Width(w / 2),
                    GUILayout.Height(45)
                )
            )
            {
                if (WebSocketState.Connecting != 0)
                {
                    AddLog(string.Format("something is wrong"));
                }
                socket = new WebSocket(address);
                socket.OnOpen += Socket_OnOpen;
                socket.OnMessage += Socket_OnMessage;
                socket.OnClose += Socket_OnClose;
                socket.OnError += Socket_OnError;
                AddLog(string.Format("Connecting..."));
                socket.ConnectAsync();
            }

            GUI.enabled = state == WebSocketState.Open;
            if (
                GUILayout.Button(
                    state == WebSocketState.Closing ? "Closing..." : "Close",
                    style,
                    GUILayout.Width(w / 2),
                    GUILayout.Height(45)
                )
            )
            {
                AddLog(string.Format("Closing..."));
                socket.CloseAsync();
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("", GUILayout.Width(UnityEngine.Screen.width), GUILayout.Height(20));
            GUILayout.EndHorizontal();

            style.alignment = TextAnchor.UpperLeft;
            style.normal.background = null;
            GUI.color = Color.white;
            GUILayout.Label("Text: ", style);
            style.normal.background = MakeTex(2, 2, Color.grey);
            sendText = GUILayout.TextArea(sendText, style, GUILayout.MinHeight(100), width);

            GUILayout.BeginHorizontal();
            style.alignment = TextAnchor.MiddleCenter;
            if (
                GUILayout.Button("Send", style, GUILayout.Width(w / 2), GUILayout.Height(45))
                && !string.IsNullOrEmpty(sendText)
            )
            {
                socket.SendAsync(sendText);
                AddLog(string.Format("Send: {0}", sendText));
                sendCount += 1;
            }
            if (
                GUILayout.Button("Send Bytes", style, GUILayout.Width(w / 2), GUILayout.Height(45))
                && !string.IsNullOrEmpty(sendText)
            )
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(sendText);
                socket.SendAsync(bytes);
                AddLog(string.Format("Send Bytes ({1}): {0}", sendText, bytes.Length));
                sendCount += 1;
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (
                GUILayout.Button("Send x100", style, GUILayout.Width(w / 2), GUILayout.Height(45))
                && !string.IsNullOrEmpty(sendText)
            )
            {
                for (int i = 0; i < 100; i++)
                {
                    var text = (i + 1).ToString() + ". " + sendText;
                    socket.SendAsync(text);
                    AddLog(string.Format("Send: {0}", text));
                    sendCount += 1;
                }
            }
            if (
                GUILayout.Button(
                    "Send Bytes x100",
                    style,
                    GUILayout.Width(w / 2),
                    GUILayout.Height(45)
                ) && !string.IsNullOrEmpty(sendText)
            )
            {
                for (int i = 0; i < 100; i++)
                {
                    var text = (i + 1).ToString() + ". " + sendText;
                    var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                    socket.SendAsync(bytes);
                    AddLog(string.Format("Send Bytes ({1}): {0}", text, bytes.Length));
                    sendCount += 1;
                }
            }

            GUILayout.EndHorizontal();

            GUI.enabled = true;
            // GUILayout.BeginHorizontal();
            // style.normal.background = null;
            // logMessage = GUILayout.Toggle(logMessage, "Log Message", style);
            // GUILayout.Label(string.Format("Send Count: {0}", sendCount), style);
            // GUILayout.Label(string.Format("Receive Count: {0}", receiveCount), style);
            // GUILayout.EndHorizontal();

            style.normal.background = MakeTex(2, 2, Color.grey);

            if (GUILayout.Button("Clear", style, GUILayout.Width(w), GUILayout.Height(45)))
            {
                log = "";
                receiveCount = 0;
                sendCount = 0;
            }
            style.alignment = TextAnchor.UpperLeft;
            scrollPos = GUILayout.BeginScrollView(
                scrollPos,
                GUILayout.MaxHeight(UnityEngine.Screen.height / scale - 270),
                width
            );
            style.normal.background = null;
            GUILayout.Label(log, style);
            GUILayout.EndScrollView();
        }

        private void AddLog(string str)
        {
            if (!logMessage)
                return;
            if (str.Length > 100)
                str = str.Substring(0, 100) + "...";
            log += str + "\n";
            if (log.Length > 22 * 1024)
            {
                log = log.Substring(log.Length - 22 * 1024);
            }
            scrollPos.y = int.MaxValue;
        }

        // 创建一个纹理
        private Texture2D MakeTex(int width, int height, Color col)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; i++)
                pix[i] = col;

            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();

            return result;
        }

        private void Socket_OnOpen(object sender, OpenEventArgs e)
        {
            AddLog(string.Format("Connected: {0}", address));
        }

        private void Socket_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.IsBinary)
            {
                AddLog(string.Format("Receive Bytes ({1}): {0}", e.Data, e.RawData.Length));
            }
            else if (e.IsText)
            {
                AddLog(string.Format("Receive: {0}", e.Data));
            }
            receiveCount += 1;
        }

        private void Socket_OnClose(object sender, CloseEventArgs e)
        {
            AddLog(string.Format("Closed: StatusCode: {0}, Reason: {1}", e.StatusCode, e.Reason));
        }

        private void Socket_OnError(object sender, ErrorEventArgs e)
        {
            AddLog(string.Format("Error: {0}", e.Message));
        }

        private void OnApplicationQuit()
        {
            if (socket != null && socket.ReadyState != WebSocketState.Closed)
            {
                socket.CloseAsync();
            }
        }

        private int frame = 0;
        private float time = 0;
        private float fps = 0;

        private void Update()
        {
            frame += 1;
            time += Time.deltaTime;
            if (time >= 0.5f)
            {
                fps = frame / time;
                frame = 0;
                time = 0;
            }
        }
    }
}
