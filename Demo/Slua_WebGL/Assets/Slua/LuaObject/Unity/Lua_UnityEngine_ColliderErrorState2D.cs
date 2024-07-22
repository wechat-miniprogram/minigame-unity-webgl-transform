using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ColliderErrorState2D : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ColliderErrorState2D");
		addMember(l,0,"None");
		addMember(l,1,"NoShapes");
		addMember(l,2,"RemovedShapes");
		LuaDLL.lua_pop(l, 1);
	}
}
