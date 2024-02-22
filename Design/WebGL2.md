# WebGL2.0渲染支持说明
 
## 适合使用场景
WebGL 是一种用于在 Web 浏览器中渲染图形的 API，基于 OpenGL ES 图形库的功能。WebGL 1.0 大致与 OpenGL ES 2.0 功能相匹配，而 WebGL 2.0 大致与 OpenGL ES 3.0 功能相匹配。
根据游戏项目统计，我们发现相对于WebGL1，更适合以下游戏需求:
- 线性颜色空间渲染
- 使用GPU Instancing提高渲染性能
- 使用SRP Batcher提高渲染性能
- 使用URP PostProcessing效果提升品质
- 存在大量依赖OpenGL ES 3.0以上的Shader难以降低


## 用户占比
Unity WebGL较多渲染优化特性依赖WebGL2.0, 因此这里需要针对该特性在小游戏环境的支持进一步说明。
- 小游戏Android平台在8.0.24(2022年中版本)已支持WebGL2, 用户占比>85%（2022.12），最新占比请查阅[基础库版本分布](https://developers.weixin.qq.com/minigame/dev/guide/runtime/client-lib/version.html)。
- 小游戏iOS高性能模式需要iOS系统版本>=15.0，用户占比>75%（2022.12）
- 小游戏[高性能+模式](https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-high-performance-plus.html)可以支持iOS系统版本>=14.0用户使用WebGL2

## 已知兼容问题
 - iOS高性能使用WebGL2会存在较多问题，平台暂不保证所有能力完善，开发者务必验证游戏所用到的特性支持情况。
 - 对于WebGL2, [高性能+模式](https://developers.weixin.qq.com/minigame/dev/guide/performance/perf-high-performance-plus.html)有更好的兼容性。
   
 如遇到问题请与小游戏研发助手(微信号:minigamedevop08)联系详细排查。 
 
### iOS高性能模式开启GPU Instance，模型闪烁/消失/不绘制等问题
  - **原因**：iOS WebKit对webGL2的支持存在问题，当uniform变量过多时，会出现绘制不正确、不绘制、效率变低等现象；
  - **解决方法**：

    1. 减少shader中Instance Props的大小；
    2. shader中添加instancing_options选项（可参考[Unity官方文档](https://docs.unity3d.com/Manual/gpu-instancing-shader.html)说明）

  		- assumeuniformscaling：开启后，默认object缩放为均匀缩放，uniform可以减少sizeof(mat4x4) * instance count的大小
  		- forcemaxcount:batchSize：限制每次draw call的instance数量
	
    3. 根据机型分级，使用GPU instance特性或合批处理（已知iPhone7p及以下机型需要进一步限制instance count）

### iOS高性能模式DrawMeshInstanced显示错乱
    
   - **原因**：iOS WebKit对webGL2的支持存在问题，当批次较大时出现显示错误
   - **解决方法**：
       iOS降低DrawMeshInstanced的参数matrices、count为32或更小的值

## 参考文档
- Unity官方文档-[WebGL 图形](https://docs.unity3d.com/cn/2021.2/Manual/webgl-graphics.html)

