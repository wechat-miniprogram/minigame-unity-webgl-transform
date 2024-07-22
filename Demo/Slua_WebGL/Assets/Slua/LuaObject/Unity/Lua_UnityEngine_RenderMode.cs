using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RenderMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.RenderMode");
		addMember(l,0,"ScreenSpaceOverlay");
		addMember(l,1,"ScreenSpaceCamera");
		addMember(l,2,"WorldSpace");
		LuaDLL.lua_pop(l, 1);
	}
}
