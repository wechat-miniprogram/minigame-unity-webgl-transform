using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PointerType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.PointerType");
		addMember(l,0,"Mouse");
		addMember(l,1,"Touch");
		addMember(l,2,"Pen");
		LuaDLL.lua_pop(l, 1);
	}
}
