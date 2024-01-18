# Unity WebGL 微信小游戏适配方案示例

​	Unity微信小游戏示例源码。

## 导入项目与配置

1. 克隆Unity WebGL 微信小游戏适配方案仓库源码

 ```
 git clone https://github.com/wechat-miniprogram/minigame-unity-webgl-transform.git
 ```

2. 使用Unity打开`/Demo/API`目录，API示例开发版本为`Unity 2018.4.36f1`。
3. 若Unity为2020及以前（如2019）版本，则需要在`/Assets/Scripts/Editor/PreBuildProcessing.cs`中配置Python环境变量。
4. 点击"工具栏——微信小游戏——转换小游戏"，填写自己的**游戏AppID**并设置**导出路径**，以及设置其他导出选项，之后点击"生成并转换"。
5. 使用[微信开发者工具](https://developers.weixin.qq.com/miniprogram/dev/devtools/download.html)打开`导出路径/minigame`。

## 目录结构

```
.
├── Assets                          // 资产目录
│   ├── API                         // API示例目录           
│   │   ├── FileSystem              // 文件系统目录
│   │   │   ├── Access              // Access目录
│   │   │   │   └── Access.cs       // Access实现脚本
│   │   │   └── ...                 // 其他API目录
│   │   └── ...                     // 其他类别目录
│   ├── Images                      // 图片资源目录
│   ├── Plugins
│   ├── Prefabs                     // 预制体目录
│   ├── Scenes                      // 场景目录
│   ├── Scripts                     // 脚本目录
│   └── WX-WASM-SDK-V2              // 微信小游戏适配插件目录
│   └── WebGLTemplates              // 微信小游戏适配插件目录
├── Packages            
├── ProjectSettings  
├── TextToolDatas 
├── .gitignore
├── LICENSE             
└── README.md   
```

## 注意

1. 对于有一个按钮的用例开发者仅需要关心`Details`子类的`TestAPI`函数。

   例如：`/Assets/API/FileSystem/Access/Access.cs`中的

   ```c#
       protected override void TestAPI(string[] args)

2. 有多个按钮的用例开发者需要关心`TestAPI`及其后紧挨着的n-1个函数（n为按钮数量）。

   例如：`/Assets/API/FileSystem/LocalCacheFile/LocalCacheFile.cs`中的

   ```c#
       ...
       protected override void TestAPI(string[] args) {...}
   		
       // 生成缓存文件
       private void GenerateCacheFile() {...}
   
       // 清空缓存文件
       private void ClearCacheFile() {...}
   
       // 获取缓存文件信息
       private void GetCacheFileInfo() {...}
       ...

