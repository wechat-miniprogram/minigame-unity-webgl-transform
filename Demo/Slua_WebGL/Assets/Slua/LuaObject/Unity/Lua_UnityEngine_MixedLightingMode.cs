using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_MixedLightingMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.MixedLightingMode");
		addMember(l,0,"IndirectOnly");
		addMember(l,1,"Subtractive");
		addMember(l,2,"Shadowmask");
		LuaDLL.lua_pop(l, 1);
	}
}
