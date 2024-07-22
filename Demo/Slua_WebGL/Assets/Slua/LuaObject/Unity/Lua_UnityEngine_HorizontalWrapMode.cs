using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_HorizontalWrapMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.HorizontalWrapMode");
		addMember(l,0,"Wrap");
		addMember(l,1,"Overflow");
		LuaDLL.lua_pop(l, 1);
	}
}
