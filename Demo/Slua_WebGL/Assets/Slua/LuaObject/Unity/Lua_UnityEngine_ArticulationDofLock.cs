using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ArticulationDofLock : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ArticulationDofLock");
		addMember(l,0,"LockedMotion");
		addMember(l,1,"LimitedMotion");
		addMember(l,2,"FreeMotion");
		LuaDLL.lua_pop(l, 1);
	}
}
