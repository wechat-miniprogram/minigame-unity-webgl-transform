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
2. CDN服务器开启跨域设置(否则**iOS可能会出现跨域加载失败**的情况)
3. MP开发者后台为CDN域名添加到"安全域名"
4. 小游戏资源下载并发数为10，超过时底层自动排队
5. 单个请求文件最大**不超过100MB，超时默认为60s**

## 资源缓存
这里主要讲UnityLoader的资源缓存策略。

### 资源缓存规则

- 首资源包自动缓存
- wasm代码自动缓存
- AB和AA特定情况下缓存

需要注意的是AB和AA的缓存规则
#### AB和AA缓存
如果请求URL包含StreamingAssets，则插件判定为是在下载bundle文件，会自动进行缓存提升二次启动速度。
所以需要自动缓存的文件，可放到StreamingAssets目录下。

但请注意以下几点：
1. 文件名需要带上hash [BuildAssetBundleOptions.AppendHashToAssetBundleName](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.AppendHashToAssetBundleName.html)，以便清理掉该文件的旧缓存。默认32位长度，如果游戏可通过导出选项中`Bundle名中Hash长度`来自定义。比如游戏自己计算了crc，可将`Bundle名中Hash长度`设置为crc长度。
2. 配置到不自动缓存文件类型中的文件，不会自动缓存，默认值是json，比如addressable打包后生成StreamingAssets/aa/WebGL/catalog.json，这个文件不会自动缓存。

### 资源淘汰规则
由于缓存目录最大不可超过200M，在下载资源包、下载AB包时，若剩余空间不足以缓存，会进行缓存淘汰。目前规则比较简单，如下：
1. 如果所需空间过大，超过最大限制：下载完成后不缓存文件，也不执行清理逻辑，直接返回下载内容。
2. 清理部分文件可以缓存新文件：按最近使用时间从前往后排序清理，直到清理出所需空间。
3. 如果去除hash后是同名文件（相同路径下同名）：清理掉旧的资源。