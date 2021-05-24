# 后端服务指引

## 后端服务模式

微信小游戏对后端服务无任何限制，可以根据自身需求选择，比如：

1. 自建后端：支持 websocket、HTTP 通信
2. 云开发：云开发可以降低运维、研发成本，详见[云开发-指引](https://developers.weixin.qq.com/miniprogram/dev/wxcloud/guide/)
3. 1、2 混合的模式

## 自建后端服务

登录态参考[登录态管理](https://developers.weixin.qq.com/minigame/dev/guide/open-ability/login.html)
通过 websocket 或者 HTTP 通信，理论上 App 和微信小游戏大部分后端服务可以直接复用

## 云开发

以实现一个服务端校验内容安全的云函数为例对云开发流程进行简单介绍，更多文档和示例请参考[云函数文档](https://developers.weixin.qq.com/minigame/dev/guide/)

> 注意：此示例仅供参考云函数使用流程，正常情况下对内容进行安全校验的逻辑应该是内容校验通过+内容存储到后端在同一个云函数中实现，避免直接调用存储接口绕开校验的情况出现。

1. 新建一个云函数的空工程
   云函数可以和前端的游戏逻辑独立创建为不同的项目。当然也可以在同一个项目中(project.config.json 中指定 cloudfunctionRoot，避免云函数代码被业务逻辑代码一同打包发布到外网)，以下示例为独立项目的模式
   <image src='../image/cf/init-cf-proj.jpg' width="800"/>
   <image src='../image/cf/cf-overview.png' width="800"/>
2. 该小游戏首次使用云开发需要先开通云开发
   <image src='../image/cf/open-cf.jpg' width="800"/>
   <image src='../image/cf/cf-free.jpg' width="800"/>

   > 云开发有一个基本的免费套餐，请求量达到一定上限后需要[配额调整](https://developers.weixin.qq.com/minigame/dev/wxcloud/billing/quota.html)或[申请代金券后更换配额套餐](https://developers.weixin.qq.com/minigame/dev/wxcloud/billing/voucher.html)

3. 实现一个云函数
   以“内容安全检查”云函数（msgSecCheck）为例，复制示例中 login 文件夹，重命名为 msgSecCheck，修改 index.js 中的内容实现服务端逻辑：

```Javascript
/*
 *  // msgSecCheck
 *  message Request {
 *      string content;
 *  }
 *  message Response {
 *      int code; // 返回码, 0:内容正常； 1:参数非法； 87014: 内容含有违法违规内容
 *  }
 */

const cloud = require('wx-server-sdk')

cloud.init({
    env: cloud.DYNAMIC_CURRENT_ENV
})

function Response(code) {
    return {
        code,
    }
}

exports.main = async (event, context) => {
    if (!event.content) return Response(1);
    try {
		// https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/sec-check/security.msgSecCheck.html
        await cloud.openapi.security.msgSecCheck({
            content: event.content,
        });
        return Response(0);
    } catch (e) {
        return Response(e.errorCode);
    }
}
```

修改 config.json，增加对 openapi.security.msgSecCheck 的声明，如没有用到 openapi 则无需修改 config.json:

```
  "permissions": {
    "openapi": [
        "security.msgSecCheck"
    ]
  }
```

> openapi 更多使用细节参考[云调用文档](https://developers.weixin.qq.com/minigame/dev/wxcloud/guide/openapi/openapi.html#%E4%BA%91%E8%B0%83%E7%94%A8)

4. 部署云函数

- 云函数可以同时存在多个环境（可自定义，如测试环境、生产环境。本示例为"product"），选中需要部署的云函数环境:
  <image src='../image/cf/choose-env.jpg' width="800"/>
- 选中需要部署的云函数(本示例为"msgSecCheck")，点击“创建并部署：云端安装依赖”（本云函数仅依赖了 wx-server-sdk 模块，选云端安装依赖即可；若使用了其他第三方 node 模块，则需要选“创建并部署：所有文件”）
  <image src='../image/cf/upload-cf.png' width="800"/>
- 等云函数部署完成(看工具的提示)，Console 可以输入调用云函数代码进行简单测试，或者右键云函数-开启云函数本地调试

```Javascript
wx.cloud.init({env:"product"})

wx.cloud.callFunction({
  name: 'msgSecCheck',
  data: {
    content: "hello cf"
  },
  success:function(res) {
  	console.log("call success", res);
	const isContentOk = (res.result && res.result && res.result.code === 0);
	console.log("IsContentOk", isContentOk)
  },
  fail: function(res){
	console.log("call fail", res);
  }
})
```
