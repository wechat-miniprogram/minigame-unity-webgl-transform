using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RectTransform_Axis : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.RectTransform.Axis");
		addMember(l,0,"Horizontal");
		addMember(l,1,"Vertical");
		LuaDLL.lua_pop(l, 1);
	}
}
