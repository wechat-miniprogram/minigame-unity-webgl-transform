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

### Enable Exceptions
BuildSettings->Player Settings->Publish Settings->Enable Exceptions
选项表示Unity引擎捕捉哪种级别的异常
<image src='../image/debugexception1.png'/>
**什么是异常级别？ 简单来说，就是确定哪些异常由引擎捕捉，未被捕捉的异常将抛给WASM虚拟机，最终会导致VM结束。**

以代码为例
``` C#
        // 程序捕捉异常
        try
        {
            GameObject go = null;
            Debug.Log(go.name);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }

        // 程序未捕捉异常
        GameObject go2 = null;
        Debug.Log(go2.name);
```
这段代码有两处异常： 1. 程序捕捉并打印的异常，  2.程序未捕捉异常

**None**：

异常捕捉：不捕捉任何异常，引擎或业务代码导致的异常都会抛出到WASM，并导致程序Crash。 该选项性能最高，但必须保证游戏不使用任何异常，**try catch也无法捕捉任何异常**。从下图看到程序在第1个Exception产生时已终止，代码是无法catch该异常的。

异常信息：取决于虚拟机，在开发者工具有出现详细堆栈，在真机环境则无。
<image src='../image/debugexception9.png'/>


**Explicitly Thrown Exceptions Only**：

异常捕捉： 游戏代码的异常将被捕捉，如果非致命异常(不在关键路径上)，逻辑代码可以继续。try catch有效。

异常信息：Debug.Log等函数等与未捕捉异常可输出简要的异常信息。
<image src='../image/debugexception8.png'/>


**Full Without Stacktrace**：

异常捕捉： 同"Explicitly Thrown Exceptions Only", 且引擎runtime也会增加异常捕捉。

异常信息： Debug.Log等函数与未捕捉异常都只有输出简要的异常信息。
<image src='../image/debugexception7.png'/>


**Full With Stacktrace**：

异常捕捉： 同"Full Without Stacktrace"

异常信息：  Debug.Log等函数得到完整的堆栈，未捕捉异常只有简要的异常信息。
<image src='../image/debugexception6.png'/>

注意：
> None性能最高，但此模式必须保证游戏代码(包括第三方插件)不使用异常，一旦命中异常即使catch也无效，会直接导致程序终止。Explicitly Thrown Exceptions Only是几种选择中鲁棒性和信息提示较为均衡的，推荐发布使用。Full With Stacktrace会严重影响性能，切忌在发布版本中使用。

### Debug Symbols
BuildSettings->Player Settings->Publish Settings->DebugSymbols

<image src='../image/debugexception3.png'/>
Debug Symbols将产生函数id与函数名之间的映射关系，使用文本方式打开即可。 通常我们从异常log中找到函数id，此时可通过该文件找到C#源代码中的函数名。

### Development Build
<image src='../image/debugexception2.png'/>
Development Build会在异常产生时直接附带完整的函数名，无需通过Symbols文件即可找到对应C#源代码的函数。但此选项将会





