using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Camera_SceneViewFilterMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Camera.SceneViewFilterMode");
		addMember(l,0,"Off");
		addMember(l,1,"ShowFiltered");
		LuaDLL.lua_pop(l, 1);
	}
}
