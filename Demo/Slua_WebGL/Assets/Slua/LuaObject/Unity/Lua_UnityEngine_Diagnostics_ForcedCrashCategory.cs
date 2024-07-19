using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Diagnostics_ForcedCrashCategory : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Diagnostics.ForcedCrashCategory");
		addMember(l,0,"AccessViolation");
		addMember(l,1,"FatalError");
		addMember(l,2,"Abort");
		addMember(l,3,"PureVirtualFunction");
		addMember(l,4,"MonoAbort");
		LuaDLL.lua_pop(l, 1);
	}
}
