# 屏幕适配

## 安全区域适配
小游戏的屏幕适配与unity游戏适配常见手机屏幕没有区别。常见的适配方式都可以在小游中使用。区别的是一些屏幕信息的获取。
如安全区域的获取需调用 WX.GetSystemInfoSync得到其中的安全区域。
如下是适配刘海屏（这里以竖屏游戏按高度适配为例）的示例：
```
        var info = WX.GetSystemInfoSync();
        float py = (float)info.safeArea.top / (float)info.windowHeight;
        // Rootrect初始时设置其Anchor，使其与父节点一样大，也就是屏幕的大小
        // 调整屏幕移到刘海屏下面, 
        Rootrect.anchorMin = new Vector2((float)info.safeArea.left / (float)info.windowWidth, -(float)info.safeArea.top / (float)info.windowHeight );
        // 重新计算缩放，让高度占满刘海屏以下的区域
        cs.referenceResolution = new Vector2(cs.referenceResolution.x, cs.referenceResolution.y * (1.0f+py));
```

## 高分辨屏下模糊问题
因为 Unity 2019.3之前的版本对高分辨屏适配不是很好。会出现画面模糊的情况，所以最好选择`Unity 2019.3`之后的版本来构建你的游戏。如果游戏不能升级版本，也可以引入[SDK](./WX_SDK.md)，在初始化SDK后，SDK会自动对页面做一个兼容适配，避免模糊的问题。
```
//初始化SDK
WX.InitSDK((int code)=> {
// 你的主逻辑
}); 
```   