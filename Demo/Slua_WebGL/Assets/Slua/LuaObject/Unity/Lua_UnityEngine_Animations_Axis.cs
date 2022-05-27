using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_Axis : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Animations.Axis");
		addMember(l,0,"None");
		addMember(l,1,"X");
		addMember(l,2,"Y");
		addMember(l,4,"Z");
		LuaDLL.lua_pop(l, 1);
	}
}
