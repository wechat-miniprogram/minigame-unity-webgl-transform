using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Profiling_Memory_Experimental_CaptureFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Profiling.Memory.Experimental.CaptureFlags");
		addMember(l,1,"ManagedObjects");
		addMember(l,2,"NativeObjects");
		addMember(l,4,"NativeAllocations");
		addMember(l,8,"NativeAllocationSites");
		addMember(l,16,"NativeStackTraces");
		LuaDLL.lua_pop(l, 1);
	}
}
