using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Scripting_GarbageCollector_Mode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Scripting.GarbageCollector.Mode");
		addMember(l,0,"Disabled");
		addMember(l,1,"Enabled");
		addMember(l,2,"Manual");
		LuaDLL.lua_pop(l, 1);
	}
}
