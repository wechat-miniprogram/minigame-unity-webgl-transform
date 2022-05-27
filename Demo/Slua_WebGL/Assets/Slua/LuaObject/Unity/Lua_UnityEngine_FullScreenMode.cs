using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_FullScreenMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.FullScreenMode");
		addMember(l,0,"ExclusiveFullScreen");
		addMember(l,1,"FullScreenWindow");
		addMember(l,2,"MaximizedWindow");
		addMember(l,3,"Windowed");
		LuaDLL.lua_pop(l, 1);
	}
}
