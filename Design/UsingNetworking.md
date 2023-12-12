# 网络通信适配

由于安全性的影响，JavaScript 代码没有直接访问 IP 套接字来实现网络连接。因此，该.NET 网络类（System.Net 命名空间中的一切，特别是**_System.Net.Sockets_**）在 WebGL 中不能工作。UnityEngine.Network\* 类也是这样，编译 WebGL 时将找不到这些类。

## HTTP 通信

Unity 支持在 WebGL 中使用 UnityWebRequest 类。

### 使用方式

以下为使用协程方式发送 GET、POST 请求到服务器的示例：

```C#
 IEnumerator Get()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get("https://mysite.com");

        yield return webRequest.SendWebRequest();
       if (webRequest.isHttpError||webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
        }

    }

    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        //键值对
        form.AddField("key", "value");
        form.AddField("name","mafanwei");
        form.AddField("blog","qwe25878");

        UnityWebRequest webRequest = UnityWebRequest.Post("https://mysite.com",form);

        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError||webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
```

特别地，在 Unity WebGL 环境下禁止使用以下代码：

```C#
while(!www.isDone) {}
```

不能阻止线程等待 UnityWebRequest 下载完成，否则您的应用程序将冻结。因为 WebGL 采用单线程机制，并且由于 JavaScript 中的 网络 API 是异步的，所以除非您将控制权交回给浏览器，否则下载永远不会完成。取而代之的做法是使用协程和 yield 语句等待下载完成。

## TCP 网络通信

如果游戏使用 TCP 进行网络通信，在 Unity WebGL 中开发者可以使用微信基础库中的TCPSocket（**需要微信基础库3.1.1**），也可以使用 Websocket 进行替代。

### TCPSocket

注意：出于应用场景考虑，TCPSocket.OnMessage表现与文档不一致。

```c#
/// <summary>
/// [TCPSocket.onMessage(function listener)](https://developers.weixin.qq.com/minigame/dev/api/network/tcp/TCPSocket.onMessage.html)
/// 监听当接收到数据的时触发该事件
/// needInfo: 是否需要返回localInfo和remoteInfo，设置为 false 时这两个字段会返回null，设置为 true 会降低性能，请按需使用
/// 多次使用OnMessage时needInfo以第一个OnMessage为准，OffMessage()移除所有回调后再次OnMessage可重新设置needInfo
/// </summary>
public void OnMessage(Action<TCPSocketOnMessageListenerResult> listener, bool needInfo = false)
```

使用举例：

```c#
using System.Text;
using UnityEngine;
using WeChatWASM;
using LitJson;

public class TCPTest : MonoBehaviour
{
    void Start()
    {
      	// 初始化WXSDK
         WX.InitSDK((int code) =>
         {
             Debug.Log("InitSDK code: " + code);
             TestTCPSocket();
         });
    }

    void TestTCPSocket()
    {
        Debug.Log("TestTCPSocket");
        // 创建TCPSocket
        WXTCPSocket tcp = WX.CreateTCPSocket();
      	
      	// 注册回调
        tcp.OnConnect(res =>
        {
            Debug.Log("tcp 连接成功");
          	//连接成功时发送数据
            tcp.Write("TCP Write Test");
        });
        tcp.OnError(res =>
        {
            Debug.Log("tcp 连接失败" + JsonMapper.ToJson(res));
            WX.ShowModal(new ShowModalOption()
            {
                content = res.errMsg
            });
        });
        // 注意OnMessage参数与文档不同
        tcp.OnMessage(res =>
        {
            Debug.Log("tcp 消息" + JsonMapper.ToJson(res));
            WX.ShowModal(new ShowModalOption()
            {
                content = Encoding.UTF8.GetString(res.message)
            });
        }, true);
				
      	// 在给定的套接字上启动连接，请按需更改地址与端口
        tcp.Connect(new TCPSocketConnectOption()
        {
            address = "www.example.com",
            port = 8848
        });
    }
}

```



### WebSocket

#### 客户端

支持 Unity Websocket 的第三方插件比较多，可以从 Github 或 AssetStore 找到。这里以[UnityWebSocket](https://github.com/psygames/UnityWebSocket)为例。

```C#
// 命名空间
using UnityWebSocket;

// 创建实例
string address = "ws://echo.websocket.org";
WebSocket socket = new WebSocket(address);

// 注册回调
socket.OnOpen += OnOpen;
socket.OnClose += OnClose;
socket.OnMessage += OnMessage;
socket.OnError += OnError;
// 连接
socket.ConnectAsync();
// 发送 string 类型数据
socket.SendAsync(str);
// 或者 发送 byte[] 类型数据（建议使用）
socket.SendAsync(bytes);
// 关闭连接
socket.CloseAsync();
```
UnityWebSocket需要对WebSocket.jslib做两处修改([新版本](https://github.com/psygames/UnityWebSocket)无需修改，感谢@psygames)：
1. instance.ws.onmessage函数将分支"else if (ev.data instanceof Blob)"挪到最后
2. WebSocketSend函数中"HEAPU8"改为"buffer"

可参考[WebSocket Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo/UnityWebSocket_WebGL)

#### 服务端

如果服务端使用 TCP 接入，则需要使用 WSS<-->TCP 的代理层。解决方案也很多：
- 使用 Ngnix、 [websockify-js](https://github.com/novnc/websockify-js)/[websockify](https://github.com/novnc/websockify)做反向代理（推荐）
- 改造原有TCP服务兼容wss服务

***特别地，在处理WebSocket数据包时，请注意数据的“粘包”问题，需要游戏服务器自行处理。***

## UDP 网络通信

微信基础库支持UDPSocket类。

注意：出于应用场景考虑，TCPSocket.OnMessage表现与文档不一致。

```c#
/// <summary>
/// [UDPSocket.onMessage(function listener)](https://developers.weixin.qq.com/minigame/dev/api/network/udp/UDPSocket.onMessage.html)
/// 监听收到消息的事件
/// needInfo: 是否需要返回localInfo和remoteInfo，设置为 false 时这两个字段会返回null，设置为 true 会降低性能，请按需使用
/// 多次使用OnMessage时needInfo以第一个OnMessage为准，OffMessage()移除所有回调后再次OnMessage可重新设置needInfo
/// </summary>
public void OnMessage(Action<UDPSocketOnMessageListenerResult> listener, bool needInfo = false)
```

使用举例：

```c#
using System.Text;
using UnityEngine;
using WeChatWASM;
using LitJson;

public class UDPTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("Start");
         WX.InitSDK((int code) =>
         {
             Debug.Log("InitSDK code: " + code);
             TestUDPSocket();
         });
    }

    void TestUDPSocket()
    {
        Debug.Log("TestUDPSocket");
        // 创建UDPSocket
        var udp = WX.CreateUDPSocket();
				// 注册回调
        udp.OnMessage(res => 
        {
            Debug.Log("udp 消息" + JsonMapper.ToJson(res));
            WX.ShowModal(new ShowModalOption()
            {
                content = Encoding.UTF8.GetString(res.message)
            });
        });
      	// 绑定端口
        udp.Bind();
        // 向指定的 IP 和 port 发送消息，请按需更改地址和端口
        udp.Send(new UDPSocketSendOption()
        {
            address = "www.example.com",
            port = 8848,
            message = "UDP Send Test"
        });
    }
}

```




## 注意事项
微信小游戏的网络需要提前在MP后台[配置安全域名](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/network.html)，以及使用带证书的HTTPS、WSS协议。

经常有开发者问道：“为什么开发者工具正常，真机访问异常” 或者 “打开调试时正常，但关闭时异常”，通常是由于安全域名与SSL证书：
- 微信开发者工具，默认不检验安全域名、SSL证书；通过详情-本地设置-关闭“不检验合法域名、HTTPS证书”进行自查
- 真机环境下，默认会检查安全域名；开启调试时不检验安全域名

也有开发者问道：“开发阶段还没SSL证书可以跑起来吗？” 、"开发阶段只有内网IP没正式域名，导致MP无法登记安全域名能跑起来吗？" 答案是肯定的：
- 微信开发者工具 or 使用调试模式的真机环境, 无需登记安全域名，也可以使用HTTP/WS等不带SSL证书的协议
- 正式上线必须使用HTTPS/WSS等带SSL证书的协议，因为上线后不可能也让玩家打开调试模式

### 安全域名

1. 真机预览时，默认检验安全域名，通过手机端小游戏右上角菜单-“开启调试”不检查安全域名
2. 微信开发者工具，默认不检验安全域名、SSL证书；通过详情-本地设置-关闭“不检验合法域名、HTTPS证书”会强制检查
3. 上线版本的网络请求必须[配置安全域名](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/network.html)。在 mp.weixin.qq.com 后台，**_开发-开发管理-开发设置-服务器域名_**进行设置。如果是 HTTP 请求请设置到 request、download合法域名，Websocket 请求请设置到 socket 合法域名。

### SSL证书

访问HTTPS请求时，请检查SSL证书请确认是否过期，使用如通过[在线工具](https://myssl.com/ssl.html)检测。

真机预览时，只要用了HTTPS/WSS必然需要SSL证书，无法关闭；如无SSL证书或正式域名，可通过打开调试+HTTP/WS协议进行开发。



