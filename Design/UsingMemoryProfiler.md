# 使用MemoryProfiler内存分析

## 概述
利用MemoryProfiler，我们可以分析UnityHeap(CPU主内存)的详细分配堆栈与统计数值

## 步骤
1. 导出选项时勾选"Profiling Funcs"与"Profiling Memory"
<img src='../image/memoryprofiler1.png' width="800"/>

2. 在微信开发者工具运行游戏，过程中会自动记录所有内存分配数据

3. 在微信开发者工具中选择gameContext, 并在Console输入命令: GameGlobal.memprofiler.onDump()
<img src='../image/memoryprofiler2.png' width="600"/>

4. 将位于游戏缓存目录/usr/下的csv内存数据拖拽并导入到sqlite数据库， 推荐使用[DB Browser for SQLite](https://sqlitebrowser.org/)
   <img src='../image/memoryprofiler3.png' width="600"/>
   <img src='../image/memoryprofiler4.png' width="400"/>

5. 对表格执行格式化换行
update alloc_used set callback=replace(callback, 'at ', x'0a'

## 数据分析
### 浏览数据
典型地，我们可以通过size进行排序分析内存最大占用的堆栈情况
<img src='../image/memoryprofiler5.png' width="800"/>

其中：
- callback: 堆栈
- count: 当前存活的分配次数
- size: 当前使用内存
- malloc: 总分配次数
- free: 总释放次数

### SQL统计分析
我们可以在"执行SQL"窗口使用SQL进行数据统计和分析，常见的callback分配堆栈特征：

Unity 2021:
```
 所有内存： select sum(size) from alloc_used

 AssetBundle Storage Memory: select sum(size) from alloc_used where callback like "%AssetBundle_LoadFromMemory%" or callback like "%OnFinishReceiveData%" or callback like "%AssetBundleLoadFromStream%"


 AssetBundle Info:  select * from alloc_used where callback like "%get_assetBundle%"

 Lua: select * from alloc_used where callback like "%luaY_parser%" or callback like "%luaH_resize%" or callback like "%luaM_realloc%"

 Shader: select * from alloc_used where callback like "%ShaderLab%"

 IL2CPP runtime: select sum(size) from alloc_used where callback like "%MetadataCache%"

 MipMap: select * from alloc_used where callback like "%Mipmap%"

Other： select * from alloc_used where callback not like "%xxx%" or callback not like "%xxx%"
 ```
 
 Unity 2018~2020：
 ```
 AssetBundle Storage Memory: select * from alloc_used where callback like "%AssetBundleLoadFromStreamAsyncOperation%" 
 
 AssetBundle Info: select * from alloc_used where callback like "%get_assetBundle%"
 
 Lua： select * from alloc_used where callback like "%luaY_parser%" or callback like "%luaH_resize%" or callback like "%luaM_realloc%" 
 
 Shader: select * from alloc_used where callback like "%ShaderFromSerializedShader%"
 
 IL2CPP runtime: select * from alloc_used where callback like "%MetadataCache%" -19M
 
 动画数据： select  * from alloc_used where callback like "%AnimationClip%" -7MB

 Other： select * from alloc_used where callback not like "%xxx%" or callback not like "%xxx%"
 ```
 
 除了常见的堆栈特征外，我们也可以根据业务自己的使用特点来进行SQL分析。


