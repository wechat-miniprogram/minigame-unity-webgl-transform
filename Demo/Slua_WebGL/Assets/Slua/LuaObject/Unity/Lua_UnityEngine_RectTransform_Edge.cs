using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RectTransform_Edge : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.RectTransform.Edge");
		addMember(l,0,"Left");
		addMember(l,1,"Right");
		addMember(l,2,"Top");
		addMember(l,3,"Bottom");
		LuaDLL.lua_pop(l, 1);
	}
}
