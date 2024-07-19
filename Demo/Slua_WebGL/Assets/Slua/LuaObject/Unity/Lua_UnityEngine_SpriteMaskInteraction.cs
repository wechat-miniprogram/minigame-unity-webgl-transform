using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SpriteMaskInteraction : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SpriteMaskInteraction");
		addMember(l,0,"None");
		addMember(l,1,"VisibleInsideMask");
		addMember(l,2,"VisibleOutsideMask");
		LuaDLL.lua_pop(l, 1);
	}
}
