# 网络通信适配

由于安全性的影响，JavaScript代码没有直接访问IP套接字来实现网络连接。因此，该.NET网络类（System.Net命名空间中的一切，特别是***System.Net.Sockets***）在WebGL中不能工作。UnityEngine.Network* 类也是这样，编译WebGL时将找不到这些类。

## HTTP通信
Unity 支持在 WebGL 中使用 UnityWebRequest 类。

### 使用方式
以下为使用协程方式发送GET、POST请求到服务器的示例：
``` C#
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
特别地，在Unity WebGL环境下禁止使用以下代码：
``` C#
while(!www.isDone) {}
```
不能阻止线程等待 UnityWebRequest 下载完成，否则您的应用程序将冻结。因为 WebGL 采用单线程机制，并且由于 JavaScript 中的 网络API 是异步的，所以除非您将控制权交回给浏览器，否则下载永远不会完成。取而代之的做法是使用协程和 yield 语句等待下载完成。


## TCP网络通信
如果游戏使用TCP进行网络通信，在Unity WebGL中开发者需要使用Websocket进行替代。

### 客户端
支持Unity Websocket的第三方插件比较多，可以从Github或AssetStore找到。这里以[UnityWebSocket](https://github.com/psygames/UnityWebSocket)为例。

``` C#
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

### 服务端
如果服务端使用TCP接入，则需要使用WSS<-->TCP的代理层。解决方案也很多，比如使用Ngnix做反向代理，也可以使用集成的代理服务器, 对于后者开发中可以使用
[websockify-js](https://github.com/novnc/websockify-js)/[websockify](https://github.com/novnc/websockify)


## 注意事项

### 安全域名
网络请求必须[配置安全域名](https://developers.weixin.qq.com/minigame/dev/guide/base-ability/network.html)。在mp.weixin.qq.com后台，***开发-开发管理-开发设置-服务器域名***进行设置。如果是HTTP请求请设置到request合法域名，Websocket请求请设置到socket合法域名。

### 跨域
为了在 WebGL 中访问跨域 Web 资源，您尝试访问的服务器需要使用跨源资源共享 (CORS) 对此跨域 Web 资源进行授权。

如果您尝试使用 UnityWebRequest 来访问内容，但远程服务器未正确设置或配置 CORS，浏览器控制台中将显示如下错误：
> Cross-Origin Request Blocked: The Same Origin Policy disallows reading the remote resource at http://myserver.com/.This can be fixed by moving the resource to the same domain or enabling CORS.

添加 Access-Control 标头，以允许 Unity WebGL 从任何源点访问 Web 服务器上的资源：该示例包括常见的请求标头，并允许 GET、POST 或 OPTIONS 方法：
``` json
 "Access-Control-Allow-Credentials": "true",
 "Access-Control-Allow-Headers": "Accept, X-Access-Token, 
X-Application-Name, > X-Request-Sent-Time",
"Access-Control-Allow-Methods": "GET, POST, OPTIONS",
"Access-Control-Allow-Origin": "*", 
``` 
如果是资源云服务器，通常厂商的后台管理支持直接设置不验证跨域。
