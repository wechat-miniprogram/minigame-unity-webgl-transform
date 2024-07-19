using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_ProfilerCategoryFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Unity.Profiling.ProfilerCategoryFlags");
		addMember(l,0,"None");
		addMember(l,1,"Builtin");
		LuaDLL.lua_pop(l, 1);
	}
}
