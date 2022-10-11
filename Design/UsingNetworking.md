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

如果游戏使用 TCP 进行网络通信，在 Unity WebGL 中开发者需要使用 Websocket 进行替代。

### 客户端

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
使用此插件需要对WebSocket.jslib做两处修改：
1. instance.ws.onmessage函数将分支"else if (ev.data instanceof Blob)"挪到最后
2. WebSocketSend函数中"HEAPU8"改为"buffer"

修改版本可参考[WebSocket Demo](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/tree/main/Demo/UnityWebSocket_WebGL)

### 服务端

如果服务端使用 TCP 接入，则需要使用 WSS<-->TCP 的代理层。解决方案也很多，比如使用 Ngnix 做反向代理，也可以使用集成的代理服务器, 对于后者开发中可以使用
[websockify-js](https://github.com/novnc/websockify-js)/[websockify](https://github.com/novnc/websockify)


## 注意事项

### 安全域名

1. 开发、测试阶段做真机预览时，可以通过手机端小游戏右上角菜单-“开启调试”不检查安全域名
2. 开发者工具预览时，可通过“详情-本地设置-不检验合法域名“不检查安全域名
3. 上线版本的网络请求必须[配置安全域名](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/network.html)。在 mp.weixin.qq.com 后台，**_开发-开发管理-开发设置-服务器域名_**进行设置。如果是 HTTP 请求请设置到 request、download合法域名，Websocket 请求请设置到 socket 合法域名。

### 跨域(iOS高性能模式)

为了在 WebGL 中访问跨域 Web 资源，您尝试访问的服务器需要使用跨源资源共享 (CORS) 对此跨域 Web 资源进行授权。
服务器需添加 Access-Control 标头，以允许 Unity WebGL 从任何源点访问 Web 服务器上的资源，包括常见的响应头，并允许 GET、POST 或 OPTIONS 方法：
```json
"Access-Control-Allow-Credentials": "true",
"Access-Control-Expose-Headers": "Content-Length, Content-Encoding",
"Access-Control-Allow-Headers": "Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time, Content-Type",
"Access-Control-Allow-Methods": "GET, POST, OPTIONS",
"Access-Control-Allow-Origin": "*",
```


### SSL证书

访问HTTPS请求时，请检查SSL证书请确认是否过期，使用如通过[在线工具](https://myssl.com/ssl.html)检测。


