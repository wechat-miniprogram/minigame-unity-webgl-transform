using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ShadowObjectsFilter : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ShadowObjectsFilter");
		addMember(l,0,"AllObjects");
		addMember(l,1,"DynamicOnly");
		addMember(l,2,"StaticOnly");
		LuaDLL.lua_pop(l, 1);
	}
}
