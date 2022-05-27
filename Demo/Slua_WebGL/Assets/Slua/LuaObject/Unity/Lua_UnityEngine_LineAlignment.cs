using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_LineAlignment : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.LineAlignment");
		addMember(l,0,"View");
		addMember(l,1,"Local");
		addMember(l,1,"TransformZ");
		LuaDLL.lua_pop(l, 1);
	}
}
