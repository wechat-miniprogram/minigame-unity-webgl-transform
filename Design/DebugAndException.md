# 错误调试与异常排查

本文阐述开发者在遇到转换后的游戏在开发者工具或真机遇到异常时就， 如何找到对应堆栈并解决问题。
## 如何排查程序中出现的异常
小游戏出现异常或错误时，通过以下方式打开console：
- 开发者工具：调试器->Console
- 真机：启动阶段点三下封面视频Logo，出现vconsole

         运行阶段点右上角->打开调试->出现vconsole

<image src='../image/debugexception4.png'/>

以文本方式打开导出目录/webgl/Build/xxx.symbols文件

<image src='../image/debugexception5.png'/>
通过日志的函数id找到对应的原始函数名，分析调用堆栈。


## 影响异常错误的导出选项
推荐配置(转换插件默认设置)

- Enable Exceptions: Explicitly Thrown Exceptions Only
- Debug Symbols: Yes
- Development Build: No

### Enable Exception
BuildSettings->Player Settings->Publish Settings->Enable Exceptions
选项表示Unity引擎捕捉哪种级别的异常
<image src='../image/debugexception1.png'/>
None：不捕捉任何异常，引擎或业务代码导致的异常都会抛出到WASM，并导致程序Crash。 该选项性能最高，但必须保证游戏不使用任何异常，try catch也失效无法捕捉任何异常。

Explicitly Thrown Exceptions Only：业务代码级别的异常将被引擎捕捉，此时try catch也是生效的，如果非致命异常(不在关键路径上)，逻辑代码可以继续。
推荐选择，因为鲁棒性最好，很难保证所有业务代码和第三方插件都不使用异常。

Full Without Stacktrace：捕捉引擎和业务代码级别的所有异常，但异常抛出时不带完整的堆栈信息。

Full With Stacktrace：捕捉引擎和业务代码的所有异常，且抛出异常时附带完整的堆栈信息。

注意：
> None性能最高，但此模式必须保证游戏代码(包括第三方插件)不使用异常，一旦命中异常及时Catch也无效，会直接导致程序终止。Explicitly Thrown Exceptions Only是几种选择中鲁棒性和信息提示较为均衡的，推荐发布使用。Full With Stacktrace会严重影响性能，切忌在发布版本中使用。

### Debug Symbols
BuildSettings->Player Settings->Publish Settings->DebugSymbols

<image src='../image/debugexception3.png'/>
Debug Symbols将产生函数id与函数名之间的映射关系，使用文本方式打开即可。 通常我们从异常log中找到函数id，此时可通过该文件找到C#源代码中的函数名。


### Development Build
<image src='../image/debugexception2.png'/>
Development Build会在异常产生时直接附带完整的函数名，无需通过Symbols文件即可找到对应C#源代码的函数。但此选项将会





