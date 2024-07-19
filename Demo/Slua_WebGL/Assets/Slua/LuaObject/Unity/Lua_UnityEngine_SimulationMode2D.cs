using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SimulationMode2D : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SimulationMode2D");
		addMember(l,0,"FixedUpdate");
		addMember(l,1,"Update");
		addMember(l,2,"Script");
		LuaDLL.lua_pop(l, 1);
	}
}
