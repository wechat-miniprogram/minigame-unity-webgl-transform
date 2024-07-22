using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Camera_GateFitMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Camera.GateFitMode");
		addMember(l,0,"None");
		addMember(l,1,"Vertical");
		addMember(l,2,"Horizontal");
		addMember(l,3,"Fill");
		addMember(l,4,"Overscan");
		LuaDLL.lua_pop(l, 1);
	}
}
