using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_VerticalWrapMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.VerticalWrapMode");
		addMember(l,0,"Truncate");
		addMember(l,1,"Overflow");
		LuaDLL.lua_pop(l, 1);
	}
}
