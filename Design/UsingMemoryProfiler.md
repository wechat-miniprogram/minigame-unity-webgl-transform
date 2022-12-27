# 使用MemoryProfiler内存分析

## 概述
利用MemoryProfiler，我们可以分析UnityHeap(CPU主内存)的详细分配堆栈与统计数值

## 步骤
1. 导出选项时勾选"Profiling Funcs"与"Profiling Memory"
<img src='../image/memoryprofiler1.png' width="800"/>

2. 在微信开发者工具运行游戏，过程中会自动记录所有内存分配数据

3. 在微信开发者工具中选择gameContext, 并在Console输入命令: GameGlobal.memprofiler.onDump()
<img src='../image/memoryprofiler2.png' width="600"/>

   Unity将自启动监听端口34999等待调试链接，对于WebGL版本会启动websockify.js(用于websocket转发)。
此时，导出的WebGL游戏在浏览器时能自动连接到Unity Profiler。

4. 将位于游戏缓存目录下的csv内存数据拖拽并导入到sqlite数据库， 推荐使用[DB Browser for SQLite](https://sqlitebrowser.org/)
   <img src='../image/memoryprofiler3.png' width="600"/>
   <img src='../image/memoryprofiler4.png' width="400"/>

5. 对表格执行格式化换行
update alloc_used set callback=replace(callback, 'at ', x'0a'


6. 使用常规SQL进行数据分析
<img src='../image/memoryprofiler5.png' width="800"/>

其中：
- callback: 堆栈
- count: 当前存活的分配次数
- size: 当前使用内存
- malloc: 总分配次数
- free: 总释放次数
典型地, 我们可以通过size进行排序分析内存最大占用的堆栈情况

常见的数据分配堆栈特征：

Unity 2021:
```
 所有内存： select sum(size) from alloc_used

 AssetBundle Storage Memory: select *sum(size)* from alloc_used where callback like "%AssetBundle_LoadFromMemory%" or callback like "%OnFinishReceiveData%" or callback like "%AssetBundleLoadFromStream%"


 AssetBundle Info:  select * from alloc_used where callback like "%get_assetBundle%"

 Lua: select * from alloc_used where callback like "%luaY_parser%" or callback like "%luaH_resize%" or callback like "%luaM_realloc%"

 Shader: select * from alloc_used where callback like "%ShaderLab%"

 IL2CPP runtime: select sum(size) from alloc_used where callback like "%MetadataCache%"

 MipMap: select * from alloc_used where callback like "%Mipmap%"

Other： select * from alloc_used where callback not like "%xxx%" or callback not like "%xxx%"
 ```


