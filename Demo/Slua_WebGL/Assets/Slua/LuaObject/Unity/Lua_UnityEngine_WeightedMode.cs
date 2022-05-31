using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_WeightedMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.WeightedMode");
		addMember(l,0,"None");
		addMember(l,1,"In");
		addMember(l,2,"Out");
		addMember(l,3,"Both");
		LuaDLL.lua_pop(l, 1);
	}
}
