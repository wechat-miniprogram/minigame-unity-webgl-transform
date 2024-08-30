# 资源部署与缓存
在转换完成后，会在导出路径下生成如下目录
```bash
.
├── minigame
└── webgl
```
- webgl目录为游戏对应的webgl版本。
- minigame目录为转化后的小游戏代码。

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
注意：加载方式取决于导出选项中的`首包资源加载方式`。同时由于小游戏总包体不能超过**20MB**，实际首包资源加载方式会根据包体决定，更多信息可查看[UnityLoader-首包资源加载方式](UsingLoader.md#_3-3-首包资源加载方式)
- 小游戏分包：因需要统计总包体大小，当导出时wasm代码brotli压缩正常的前提下，如果wasm代码+首包资源小于20MB，可使用"小游戏包内"加载，此时**不需要将首包资源部署到服务器**。
- CDN：当不使用小游戏分包时，需要部署到服务器。

### Assets
如果有用到纹理压缩，导出插件自动生成。将此目录部署到服务器即可

### StreamingAssets
AssetBundle和Addressables资源目录。
如果是用的AA，构建时默认打包到StreamingAssets目录下。但如果是用的AB，或者自定义了bundle的生成目录，需要将bundle移动到StreamingAssets目录

### 资源服务器注意事项
1. 针对txt文件进行开启Brotli或gzip压缩，**首资源包有非常高的压缩率**
2. 小游戏资源下载并发数为10，超过时底层自动排队
3. 单个请求文件最大**不超过100MB，超时默认为60s**(理论最大值，实际游戏永远不要让单个文件这么大，考虑到玩家平均下载带宽，建议单文件2~5MB以内)
4. 网络安全域名、跨域、SSL等问题请参考文档[网络通信适配](UsingNetworking.md)

## 资源更新说明
> 请注意!!! bundle的配置文件，比如aa的`setting.json`和`catalog.json`，以及`AssetBundles`打包生成的配置文件通常没有带上hash，为了避免新版本发布时由于cdn缓存导致加载到旧版本资源，需要避免这些文件使用缓存。通常有以下两种方式避免。

1. 每次发新版本更换cdn路径，比如`version1/xxxx`,`version2/xxxx`
2. 不希望被缓存的文件，源站或者cdn加上不允许缓存的HTTP头，如`no-cache`，请自行查询对应cdn服务商文档进行设置

同时，由于通过HTTP请求的资源会自动缓存，不希望被缓存的文件请添加到缓存忽略目录，具体可阅读后续**资源缓存规则**文档

> 除非了解小程序更新机制，请勿删除旧版本资源，否则可能导致旧版本游戏的用户运行报错，具体请移步[版本更新](Update.md)

## 资源缓存
这里主要讲UnityLoader的资源缓存策略。

### 资源缓存规则

请阅读[资源缓存](FileCache.md)
