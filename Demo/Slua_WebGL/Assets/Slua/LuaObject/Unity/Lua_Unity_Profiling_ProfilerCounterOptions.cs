using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_ProfilerCounterOptions : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Unity.Profiling.ProfilerCounterOptions");
		addMember(l,0,"None");
		addMember(l,2,"FlushOnEndOfFrame");
		addMember(l,4,"ResetToZeroOnFlush");
		LuaDLL.lua_pop(l, 1);
	}
}
