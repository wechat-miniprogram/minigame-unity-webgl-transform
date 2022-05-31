using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_DurationUnit : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.DurationUnit");
		addMember(l,0,"Fixed");
		addMember(l,1,"Normalized");
		LuaDLL.lua_pop(l, 1);
	}
}
