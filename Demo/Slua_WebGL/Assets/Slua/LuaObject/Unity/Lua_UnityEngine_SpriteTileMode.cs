using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SpriteTileMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SpriteTileMode");
		addMember(l,0,"Continuous");
		addMember(l,1,"Adaptive");
		LuaDLL.lua_pop(l, 1);
	}
}
