# 视频demo
部分游戏需要在视频上面盖交互元素，比如跳过播放的按钮

1. 实现原理
默认视频层级最高，会盖住游戏画面。通过修改小游戏视频创建时的参数`underGameView=true`实现视频在游戏画布之下播放。
画布有内容的地方显示游戏画面，没内容的地方显示视频。

https://developers.weixin.qq.com/minigame/dev/api/media/video/wx.createVideo.html

2. unity配置
- 主相机clearFlag改成solidColor，颜色改为黑色
- 将此工程下的Plugins/TransparentBackGround.jslib放入你的工程

3. 小游戏配置
- 修改minigame/unity-sdk/video.js，新版插件会自动修改
```
WXCreateVideo(conf) {
  const id = new Date().getTime()
    .toString(32) + Math.random().toString(32);
  // 增加这之间部分代码
  const params = JSON.parse(conf);
  if (params.underGameView) {
    GameGlobal.enableTransparentCanvas = true;
  }
  videos[id] = wx.createVideo(params);
  // 增加这之间代码
  return id;
},
WXVideoAddListener(id, key) {
  if (videos[id]) {
    videos[id][key]((e) => {
      moduleHelper.send('OnVideoCallback', JSON.stringify({
        callbackId: id,
        errMsg: key,
        position: e && e.position,
        buffered: e && e.buffered,
        duration: e && e.duration,
      }));
      if (key === 'onError') {
        GameGlobal.enableTransparentCanvas = false; // 增加这行
        console.error(e);
      }
    });
  } else {
    console.error(msg, id);
  }
},
WXVideoDestroy(id) {
  if (videos[id]) {
    videos[id].destroy();
  } else {
    console.error(msg, id);
  }
  GameGlobal.enableTransparentCanvas = false; // 增加这行
},
```

配置参考：https://support.unity.com/hc/en-us/articles/208892946-How-can-I-make-the-canvas-transparent-on-WebGL-
修改了下清理规则，否则可能导致正常情况下游戏画面异常。