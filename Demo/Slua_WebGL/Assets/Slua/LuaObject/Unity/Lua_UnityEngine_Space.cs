using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Space : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Space");
		addMember(l,0,"World");
		addMember(l,1,"Self");
		LuaDLL.lua_pop(l, 1);
	}
}
