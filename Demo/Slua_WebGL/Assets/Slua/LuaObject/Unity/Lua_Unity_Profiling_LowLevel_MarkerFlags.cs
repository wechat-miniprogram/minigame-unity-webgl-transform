using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_LowLevel_MarkerFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Unity.Profiling.LowLevel.MarkerFlags");
		addMember(l,0,"Default");
		addMember(l,2,"Script");
		addMember(l,4,"AvailabilityEditor");
		addMember(l,16,"Warning");
		addMember(l,32,"ScriptInvoke");
		addMember(l,64,"ScriptDeepProfiler");
		addMember(l,128,"Counter");
		addMember(l,256,"SampleGPU");
		LuaDLL.lua_pop(l, 1);
	}
}
