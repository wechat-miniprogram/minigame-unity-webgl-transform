# 自定义SDK调用
  微信SDK提供了`WX.CallJSFunction`与`WX.CallJSFunctionWithReturn`接口实现了简单的第三方SDK调用，支持可序列化为JSON的**任意数量的参数**与**返回值**。

  其中，JS侧的实际调用逻辑为`GameGlobal.sdkName.functionName(args)`，所以在调用之前需要保证**SDK位于`GameGlobal`下**且**SDK中含有该名称的函数**。

  在`WX.CallJSFunctionWithReturn`中，会将函数返回值转换为JSON后传回，若无返回值则传回`""`。

  如需更加复杂的调用，可参考[WebGL：与浏览器脚本交互](https://docs.unity3d.com/cn/2018.4/Manual/webgl-interactingwithbrowserscripting.html)进行自定义定制。

## 版本要求
`转换插件 >= 202406062127`

## 代码示例

- CS侧调用（`"sdk"`、`"testFunction"`、`TestFunctionOption`仅作为演示，请依实际情况更改）

```csharp
WeChatWASM.WX.CallJSFunction("sdk", "testFunction", new TestFunctionOption
{
    type = "text",
    text = "反馈",
    style = new OptionStyle()
    {
        left = 10,
        top = 10,
        width = 100,
        height = 100,
        backgroundColor = "#ff0000",
        color = "#ffffff",
        textAlign = "center",
        fontSize = 20,
        borderRadius = 10,
        lineHeight = 100,
    }
});
```

- JS侧挂载SDK（`"sdk"`、`sdk`仅作为演示，请依实际情况更改）
  可配合[构建模版能力](https://wechat-miniprogram.github.io/minigame-unity-webgl-transform/Design/BuildTemplate.html)使用。

```js
  GameGlobal["sdk"] = sdk;
```
