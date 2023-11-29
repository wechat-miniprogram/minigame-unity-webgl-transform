# 启动剧情演示Demo

## 打开工程

请使用 Unity Editor 打开 Demo/LaunchOpera 工程，推荐使用 2021.3.16。

修改工程中导出面板 `AppID` 与 `导出目录` 即可，CDN可以无需关注（因为使用包内加载），直接导出微信小游戏并使用微信开发者工具打开 `minigame` 目录。

## 说明

1. `Assets/Script/LaunchOpera.cs` 定义了 C# 中的一些交互；

2. JavaScript 的代码位于 `Assets/WX-WASM-SDK-V2/Runtime/wechat-default/game.js` 大约 225 行开始;

其中 `wechat-default` 目录是导出微信小游戏的模板目录，因此在该目录中修改未来会影响导出的 `minigame` 目录内容，并且跟随项目的代码版本管理；

3. 运行中的几个按钮介绍：
- `Reset to new User` : 设置为新用户。即清理当前游戏本地的非新用户标识，再次访问小游戏时将以新用户身份进入，可正常观看启动剧情内容；
- `Sync Demo` : 同步演示模式。同步模式中，如果用户非新用户，则完全不进行启动剧情，将直接进入默认的游戏界面；
- `Async Demo` : 异步演示模式。异步模式中，启动剧情一定启用，并固定播放一段 “Logo” 视频，在播放 “Logo” 视频期间进行异步的判断是否为新用户决定后续的视频是否播放。
- `Custom Progress Demo` : 开启自定义外显进度条，开启后，启动剧情播放期间底部的进度条将最终停留在自定义的位置（85%），停留在 85% 是由于底部进度条前 70% 是对应启动剧情期间的小游戏默认的首场情加载进度条，留给开发者剩余 30% 自定义来反馈游戏首场景之后的游戏定义的进度条逻辑。

4. 剧情结束后会弹出一个 Toast 提示框，对应 `Assets/Script/LaunchOpera.cs` 大约 70 行定义的结束回调，游戏代码中可准确得知何时结束启动剧情以此来做出相应的UI反馈。

## 文档

更多内容请前往「启动剧情」相关说明文档页面：[https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/LaunchOpera.md](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/LaunchOpera.md)