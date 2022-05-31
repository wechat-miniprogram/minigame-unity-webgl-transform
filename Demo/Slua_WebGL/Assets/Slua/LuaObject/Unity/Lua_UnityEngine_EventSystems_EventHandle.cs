using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_EventHandle : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.EventSystems.EventHandle");
		addMember(l,0,"Unused");
		addMember(l,1,"Used");
		LuaDLL.lua_pop(l, 1);
	}
}
