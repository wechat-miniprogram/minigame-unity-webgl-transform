# RenderOptimization
- 本文档主要关于 Unity WebGL 游戏在微信手机平台的渲染性能优化一些建议

>## WebGL1.0 还是 WebGL2.0
- WebGL2.0 基本兼容 WebGL1.0，但并不是完全向后兼容 WebGL1.0
- WebGL2.0 对系统有要求，用户占比和兼容性不如 1.0，可参考 [WebGL2.0渲染支持说明](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/WebGL2.md) 
- 对 Unity 而言，WebGL1.0 和 WebGL2.0 生成的 Shader 是不一样，各有优缺点
    - WebGL2.0 是用了 Uniform Buffer 来管理UnityPerDraw 和 UnityPerMaterial 属性，Unity内置Shader 有大量可能游戏用不上的冗余属性
    - WebGL1.0 用不到的材质属性会剔除掉
- 如果游戏内容不多，材质比较简单，游戏不依赖 GPU Instancing 等 WebGL2.0 的特性，那么 WebGL1.0 也足够
- 如果游戏需要依赖 GPU Instancing等 WebGL2.0 的特性，那么必须要用 WebGL2.0
- 并非用 WebGL2.0 的性能就一定比 WebGL1.0 的好，不一定，有条件的建议分别打对应的包，对比一下性能

>## 选择哪种渲染管线
- 微信小游戏 [推荐引擎版本](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform/blob/main/Design/UnityVersion.md) 都支持 SRP管线
- 现有的游戏原来是什么管线就什么管线，这里主要针对新开发的小游戏
- Unity 2019.3开始支持 URP 管线
- 如果是新开发的游戏，Unity 内置管线、SRP、URP、HDRP 到底怎么选 ？
    - 内置管线，适用于小游戏
        - 优点：默认选项，拿来即用，功能全面
        - 缺点：固定，不灵活，面向全平台，不够精简
    - SRP (Scriptable RP)，适用于小游戏
        - 优点：灵活，完全通过 C# 脚本定制渲染管线，冗余功能很少
        - 缺点：不能直接拿来用，需要通过 C#脚本开发渲染管线，对开发者要求高
    - URP (Universal RP) 基于 SRP 的通用渲染管线，适用于小游戏
        - 优点：拿来即用，简单配置即可，
        - 缺点：通用，冗余功能较多，不够精简
    - HDRP 高清渲染管线，适用于主机平台，不适用于小游戏
- 对于大多数开发者，建议使用 URP，当然 URP复杂的特性尽量少用，因为小游戏对性能要求还是比较高，
    - 对于用不到的特性，可以在 URP的基础上定制
- 对于对性能要求高且熟悉渲染的开发者，可以使用 SRP定制管线

>## 线性颜色空间 还是 Gamma 颜色空间
- 目前 Unity 只有在 WebGL2.0 才支持 线性颜色空间，如果是选择 WebGL1.0 必然是 Gamma 颜色空间
- 那么选择了 WebGL2.0，到底用线性还是Gamma 颜色空间呢？
- 光照计算尤其是 PBR需要在线性颜色空间进行，如果是 PBR渲染，线性颜色空间比较方便
- 但线性颜色空间，Unity会多一个全屏 Gamma矫正的 Pass，对性能会有比较明显的影响
    - 这个问题已经反馈给 Unity了，至少 Unity2021.3.23 的版本还是存在这个问题
- 因此，除非是 PBR光照，其余的都建议选择 Gamma 颜色空间

>## 渲染性能优化的一些建议
>>### 光照和阴影
- 如果没有光照和阴影的需要，确认游戏的光照(包括环境光)和阴影都是关闭的
    - 能不用光照，尽量不用，材质可参考 URP 的 Unlit shader  
- 如果需要光照和阴影的，那么尽量用烘焙 Lightmap，避免用实时光照
- 需要用到实时光的，一般建议只用一盏方向光，不要用额外的实时光
    - 额外的光照信息可以烘焙到 Lightmap
    - 光照材质尽量简单，避免使用 PBR光照，可参考 URP 的 SimpleLit Shader
    - Unity 的阴影默认使用 Cascade Shadow Map的 方案
        - 阴影生效的距离(离摄像机的)尽量设置小一些，远处物体不用阴影也难观察出来，这样阴影贴图可以小一点
        - 阴影贴图的大小越小越好，建议从256尝试是否合适，逐渐调大，最好不要超过1024
        - Cascade 级联数也是建议 1～2 级，1级能满足要求是最好的
        - 投射阴影 和 接受阴影的物体要区分开，有需要投射或接受阴影的物体才去设置
    - 如果地表是平的，那么用投射平面阴影的方式来表现阴影，不用 Unity的阴影方案，这样性能更好
- 烘焙 Lightmap 的时候可能会生成环境反射立体贴图，已经有 Lightmap，尽量不要再用环境反射立体贴图

>>### 材质和Shader 
- 避免使用 Unity默认的材质，当Inspector窗口的材质缺失，Unity会自动使用内置的默认材质
    - 可以通过 Unity 官网下载对应版本的 builtin_shaders 源码
    - 看下默认材质Shader 是什么，复制一份并尽可能简化，用来新建材质替代默认的材质
    - 好处是：默认的材质一般会有些冗余的设置，简化过的材质对性能更好，而且方便修改 
- 避免使用 Mask 材质 (像 Unity Mask 和 RectMask2D 组件)
    - 常见的头像用圆来做一个Mask 遮罩
    - 通常 Mask 可能会打断 UI系统的合批，或者对硬件优化不友好
    - 这种可以用网格化一个圆作为替代方案，在移动端性能更好
- 材质Shader 可能有 Stencil 蒙版的设置，一般是为了实现遮罩等效果用的，如果不需要建议在 Shader中注释掉 Stencil 相关代码，否则可能会有额外的API 调用开销
    - 在 iOS 15.4 系统，使用 Stencil 可能会导致一些渲染异常问题
- 避免使用 if、for 这种结构化语句
    - if 语句 可以尝试使用 step 内置函数替代，如果实在代替不了，而且 if语句比较短小，那也可以用，但如果if 语句很复杂的就不建议使用
- 如果用了 Shader Graph，建议检查一下最终生成的 shader代码，避免上述的 if、for 这种语句
- 注意浮点精度的使用，如果能用半精度 half 尽量用半精度，一般涉及到坐标值、uv 的定义或计算可能需要全精度的，其他的像颜色、法线等一般半精度就够了
- 减少不必要的材质变体
    - 检查 shader代码的`#pragma multi_compile`、`#pragma multi_compile_local`、`#pragma shader_feature`和`shader_feature_local` 语句，如果有用不到的关键字要记得删除掉
    - 详情可参考[Unity 着色器变体和关键字说明](https://docs.unity3d.com/cn/2020.2/Manual/SL-MultipleProgramVariants.html)

>>### 纹理设置
- 建议材质引用的纹理数尽量控制在 5 张以内
- 纹理的大小当然越小越好，对于单图，尽量不要超过 512；对于图集来说尽量不要超过1024
- 尽量使用压缩纹理，建议用 astc压缩，它有多种压缩格式，在满足画质情况下，尽量选择压缩比大的
    - 例如 astc8*8 比 astc4*4 压缩比更大，而且满足画质要求，那么就选择 astc8*8
- UI 一般考虑效果，不用压缩纹理，但有些 UI纹理的精细度可能要求不高，是可以尝试用压缩纹理，这样对内存、游戏加载速度都会有提升
- 对于图标等小图片，尽量合并成 Atlas 图集
- 如果启用 WebGL2.0，对于相同尺寸的纹理，可以考虑合并成 Texture2D Array

>>### 网格和蒙皮
- 如果游戏场景比较复杂，总面数比较高，比如超过 50万面，这时候要留意下顶点着色会不会成为瓶颈
    - 可以打个 App包，如果是 iOS包，那么可以通过 XCode抓帧工具，分析场景帧 Vertex Shading 和 Pixel Shading 的耗时，一般都是 Pixel Shading 占大头，如果 Vertex Shading 的时间和 Pixel Shading 差不多，意味着 Veretx Shading 有优化空间，可以尝试优化 顶点 Shader 或 降低总面数
- 如果有顶点蒙皮，像 Unity WebGL 目前还不支持 GPU skin，也不支持 CPU 多线程，如果顶点过多或骨骼数过多，很容易导致 CPU skin 成为瓶颈
    - 避免瓶颈的手段有: 减少模型面数(可以使用Mesh LOD)、减少骨骼数量、或者减少顶点的受影响的骨骼权重数
    - 后续的 Unity版本 可能会支持 GPU skin 或 多线程，但仍然是需要注意 skin 的开销

>>### DrawCall 相关
- Draw Call 的数量建议控制在 200个以内，对于大型游戏可以适当放宽一点，但尽量不要超过250个
- Unity 的统计里有 SetPass Call的概念，它与 Draw Call 是不同的概念，SetPass Call指的切换渲染状态的次数，SetPass Call 应当明显小于 Draw Call 数，这样表示材质复用的概率高
- 如果使用 WebGL2.0，尽量使用 GPU Instancing 实例化来合并 Draw Call
- 如果使用 WebGL2.0，URP 默认是开启 SRP Batcher，它并不能减少 Draw Call的数量，它的目的是减少渲染状态的切换。如果渲染状态比较多，那么 SRP Batcher 收益应该会比较明显，建议开发者具体测试一下 SRP Batcher的收益情况 (对比帧率、CPU利用率和内存使用).

>>### 摄像机 Camera
- 避免同时启用多于 2个的Camera，一般就主 Camera，至多额外加一个 UI Camera
    - 如果只用一个 Camera 绘制主场景和UI，那是最好，能够减少渲染的开销

>>### 渲染分辨率
- 如果手机发烫比较严重，可以适当调小一点渲染分辨率，看发烫是否有改善
    - 以 iOS为例，如果dpr（Device Pixel Ratio）默认是3.0，那么可以尝试设置 [2.0 ～ 2.5]
    - 这个方法可能会牺牲一点画质效果，需要画质和性能之前取一个平衡

>>### 后处理
- 后处理的销不小，加上 WebGL 游戏在可用内存和性能对比 App 有差距
- 不建议在微信小游戏使用后处理，除非后处理对画质很关键或游戏性能能支撑起后处理的开销

>>### 特效
- 避免大量的大屏幕的半透明特效重叠导致的 Overdraw，尤其是战斗释放技能时候，容易出现这种情形，需要留意 

## 参考文档
- [WebGL1.0 spec](https://registry.khronos.org/webgl/specs/latest/1.0/)
- [WebGL2.0 spec](https://registry.khronos.org/webgl/specs/latest/2.0/) 