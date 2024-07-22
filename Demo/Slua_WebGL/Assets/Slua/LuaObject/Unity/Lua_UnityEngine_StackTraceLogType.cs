using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_StackTraceLogType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.StackTraceLogType");
		addMember(l,0,"None");
		addMember(l,1,"ScriptOnly");
		addMember(l,2,"Full");
		LuaDLL.lua_pop(l, 1);
	}
}
