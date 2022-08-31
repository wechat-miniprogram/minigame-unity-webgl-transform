# 资源部署与缓存
在转换完成后，会在导出路径下生成如下目录
```bash
.
├── backup
├── minigame
└── webgl
```
- webgl目录为游戏对应的webgl版本。
- minigame目录为转化后的小游戏代码。
- 如果使用纹理压缩会生成backup目录用于存放原始纹理。

其中webgl目录结构如下：

```bash
.
├── 01367b188873c923.webgl.data.unityweb.bin.txt
├── Assets
│   ├── 15032.wav
│   ├── Audio
│   └── Textures
├── Build
│   ├── UnityLoader.js
│   ├── webgl.data.unityweb
│   ├── webgl.json
│   ├── webgl.wasm.code.unityweb
│   ├── webgl.wasm.framework.unityweb
│   └── webgl.wasm.symbols.unityweb
├── StreamingAssets
│   └── AssetBundles
├── index.html
└── texture-config.js
```
## 资源部署
**导出目录中，webgl目录如下三个文件和目录是可能需要远程部署的资源：**
```bash
.
├── 01367b188873c923.webgl.data.unityweb.bin.txt
├── Assets
├── StreamingAssets
```

### 首资源包
首资源包即`01367b188873c923.webgl.data.unityweb.bin.txt`，包含**Unity builtin + 勾选的导出场景 + Resources**资源。
注意：加载方式取决于导出选项中的`首包资源加载方式`。同时由于小游戏总包体不能超过**20MB**，实际首包资源加载方式会根据包体决定，更多信息可查看[UnityLoader-首包资源加载方式](UsingLoader.md)
- 小游戏分包：因需要统计总包体大小，当导出时wasm代码brotli压缩正常的前提下，如果wasm代码+首包资源小于20MB，可使用小游戏分包加载，此时**不需要将首包资源部署到服务器**。
- CDN：当不使用小游戏分包时，需要部署到服务器。

### Assets
如果有用到纹理压缩和微信音频API，导出插件自动生成。将此目录部署到服务器即可

### StreamingAssets
AssetBundle和Addressables资源目录。
如果是用的AA，构建时默认打包到StreamingAssets目录下。但如果是用的AB，或者自定义了bundle的生成目录，需要将bundle移动到StreamingAssets目录

### 资源服务器注意事项
1. 针对txt文件进行开启Brotli或gzip压缩，**首资源包有非常高的压缩率**
2. 小游戏资源下载并发数为10，超过时底层自动排队
3. 单个请求文件最大**不超过100MB，超时默认为60s**
4. 网络安全域名、跨域、SSL等问题请参考文档[网络通信适配](UsingNetworking.md)

## 资源缓存
这里主要讲UnityLoader的资源缓存策略。

### 资源缓存规则

请阅读[资源缓存](FileCache.md)
