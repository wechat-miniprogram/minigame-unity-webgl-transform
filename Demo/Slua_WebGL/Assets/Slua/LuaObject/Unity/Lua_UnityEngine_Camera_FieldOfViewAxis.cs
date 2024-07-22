using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Camera_FieldOfViewAxis : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Camera.FieldOfViewAxis");
		addMember(l,0,"Vertical");
		addMember(l,1,"Horizontal");
		LuaDLL.lua_pop(l, 1);
	}
}
