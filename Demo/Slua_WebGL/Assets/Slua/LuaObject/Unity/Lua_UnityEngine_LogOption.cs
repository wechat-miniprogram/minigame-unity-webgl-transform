using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_LogOption : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.LogOption");
		addMember(l,0,"None");
		addMember(l,1,"NoStacktrace");
		LuaDLL.lua_pop(l, 1);
	}
}
