# 配置构建模板

## 简介
团结/Unity快适配项目最终导出 `minigame` 目录即为微信小游戏代码包，使用微信开发者工具打开并上传。该部分主要由 JavaScript、JSON、WASM及图片资源构成。在实际的游戏开发中，开发者存在需要对 minigame 目录中产物做一些定制化的修改，这些修改同时也要跟随项目内容一起进行代码托管。为此微信提供配置构建模板的能力。

## 结构说明

- 在Package Manager导入WXSDK模式下的目录 `Packages/com.qq.weixin.minigame/Runtime/wechat-default`
- 以及在Assets导入资源模式下的目录 `Assets/WX-WASM-SDK-V2/Runtime/wechat-default`

两个目录中的 `wechat-default` 是项目的基础模板，基础模板不建议开发者进行编辑，因为随着新的SDK的更新覆盖也将失去其修改内容。

开发者需要手动创建 `Assets/WX-WASM-SDK-V2/Editor/template` 目录，在 `template/minigame` 目录中的资源内容将会按照完整的层级结构覆盖到最终的 `minigame` 的导出目录中。

**直观的结构：**

```
# 游戏工程目录
Assets
├─ WX-WASM-SDK-V2
│  ├─ Editor
│  │  ├─ template      # 自行创建该目录内容
│  │  │  ├─ minigame
│  │  │  │  └─ ...     # 需要被覆盖的资源文件
│  │  │  └─ plugin.cs  # 可缺省创建，请阅读「构建模板前后不同时机的钩子」小节
│  │  └─ ...
│  └─ ...
└─ ...

# WXSDK目录
Packages/com.qq.weixin.minigame 或 Assets/WX-WASM-SDK-V2
├─ Runtime
│  ├─ wechat-default   # 基础模板
│  └─ ...
└─ ...

# 导出资源目录（转换微信小游戏产物）
wechat
├─ minigame      # 基础模板 + template（合并结果）
│  └─ ...
└─ webgl
```

值得注意的是，基础模板（wechat-default）并不是一个可以运行的标准JavaScript代码包，因为其中包含了大量的占位符将在导出时根据项目不同的实际情况作出替换，因此开发者在 `template/minigame` 创建用于覆盖的脚本时，应该以 `wechat-defalut` 中的脚本为修改基准，而不是导出的资源目录 `wechat/minigame` 中的资源作为参考。如此一来你自定义模板也将适应占位符的内容作出最终的结果变更。

## 新版本SDK引起的冲突提醒

随着WXSDK的更新，如果你覆盖过 `wechat-defalut` 中的关键脚本，那么在新版本WXSDK导入后可能会引起部分功能表现异常，因此WXSDK将识别到关键脚本发生更新且被开发者自定义覆盖的情况下作出警告。（只会检查 .js .json 文件冲突，图片文件不会检查）

- **在WXSDK初始化时（引擎启动、或导入新的WXSDK时）作出检查**

  检查异常时将在Unity控制台中给出详细的冲突信息；

- **在导出微信小游戏时作出检查**

  检查异常时将终止导出，并在Unity控制台中给出详细的冲突信息。

### 消除冲突提醒

观察到异常提醒后开发者需要根据提醒前往对比冲突的脚本内容**自行适配**，当冲突的自定义模板文件较冲突前发生变化后提醒也将自动消除。

## JSON配置合并

时常开发者需要对 `game.json` 或 `project.config.json` 配置文件内容的做针对性的修改，当然使用后面小节提及的[钩子能力](#构建模板前后不同时机的钩子)可以很万能的做出内容修改，但这毕竟需要开发者进行一定的代码编写。构建模板能力为开发者提供了一个JSON配置合并能力，只需要自定义模板目录放置JSON，并且只填写你关注的字段，构建模板能够自动帮你完成相同JSON文件的字段合并。

支持合并的文件为：

- game.json
- project.config.json

合并规则：Key-Value 字段将在**末位**节点新增或覆盖，Array 将整节点新增或覆盖。

例如：

自定义模板 `.../Editor/template/minigame/game.json` ：
```json
{
  "test": "abc123",           // 最终模板将新增该字段与值
  "plugins": {
    "UnityPlugin": {
      "version": "1.2.52"     // 最终模板仅变更该版本号
    }
  },
  "subpackages": [            // 最终模板会因该字段为数组类型，将整节点替换
    "..."
  ]
}
```

## 构建模板前后不同时机的钩子

有时候简单的覆盖可能并不能满足开发者复杂的修改需要，在构建时提供的不同时机钩子允许开发者使用C#代码来替换或变更是更灵活自由的方案，我们提供了 [BuildTemplateHelper](#buildtemplatehelper介绍) 工具类来便捷的获得三个目录的绝对路径。

### 钩子介绍

在构建模板中通常需要以下几个阶段的钩子：

<img src="/image/buildtemplateprocess.png" width="90%" />

### 使用钩子

为了统一约定，推荐开发者创建位于 `Assets/WX-WASM-SDK-V2/Editor/template/plugin.cs` 脚本来执行构建模板相关的设计。

```
# 游戏工程目录
Assets
├─ WX-WASM-SDK-V2
│  ├─ Editor
│  │  ├─ template
│  │  │  ├─ minigame
│  │  │  │  └─ ...
│  │  │  └─ plugin.cs  # 请创建该文件并编写钩子逻辑
│  │  └─ ...
│  └─ ...
└─ ...
```

样例：

```c#
// plugin.cs
using System.IO;
using UnityEngine;
using WeChatWASM;

/// <summary>
/// 构建生命周期回调钩子
/// 注意事项：
///     请创建脚本在 Editor (子)目录下；
///     回调钩子请使用 public 声明成员函数
/// </summary>
public class PluginDemo : LifeCycleBase
{

    public override void afterCopyDefault()
    {
        // code...
        Debug.Log("afterCopyDefault");
    }

    public override void beforeCopyDefault()
    {
        // 可使用 Exception 阻止继续构建导出
        throw new System.Exception("Build Failed.");
    }

    public override void beforeCoverTemplate()
    {
        // 读取你的自定义模板目录并对其中的资源做动态修改
        var tmp = BuildTemplateHelper.CustomTemplateDir;
        using (
          FileStream file = new FileStream(
            Path.Combine(tmp, "newFile.js"),
            FileMode.Create, FileAccess.Write))
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLineAsync("Your Code Content.");
            }
        }
        // 尽管你在导出期间动态的创建/修改了自定义模板中的资源
        // 在导出结束后WXSDK会自动恢复你的修改
    }
}


```

### BuildTemplateHelper介绍

BuildTemplateHelper 为你便捷的提供了各个目录的绝对路径：

```c#
// wechat-default（标准模板）
// 位于 WXSDK 目录下标准模板绝对路径
string baseDir = BuildTemplateHelper.BaseDir;


// template（自定义模板）
// 游戏工程中 Assets/WX-WASM-SDK-V2/Editor/template/minigame 绝对路径
string templateDir = BuildTemplateHelper.CustomTemplateDir;


// wechat/minigame（导出产物）
// 开发者在导出面板配置的导出路径的微信开发者工具打开的 minigame(默认) 绝对路径
string outDir = BuildTemplateHelper.DstMinigameDir;
```

搭配[钩子介绍](#钩子介绍)小节中的不同阶段，可以任意的对你的 `wechat-default（标准模板）`、`template（自定义模板）`、`wechat/minigame（导出产物）` 中进行新的脚本创建、已有脚本中局部代码的文本替换（例如使用正则替换）甚至是图片等资源的变更。

在导出期间修改你的自定义模板，在结束导出后不会真实的影响你的游戏工程内容，WXSDK已经为你还原，这对于你托管项目代码很便捷。