using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.PlayMode");
		addMember(l,0,"StopSameLayer");
		addMember(l,4,"StopAll");
		LuaDLL.lua_pop(l, 1);
	}
}
