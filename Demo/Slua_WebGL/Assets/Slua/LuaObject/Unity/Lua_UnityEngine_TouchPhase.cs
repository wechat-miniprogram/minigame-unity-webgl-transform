using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TouchPhase : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.TouchPhase");
		addMember(l,0,"Began");
		addMember(l,1,"Moved");
		addMember(l,2,"Stationary");
		addMember(l,3,"Ended");
		addMember(l,4,"Canceled");
		LuaDLL.lua_pop(l, 1);
	}
}
