using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_LowLevel_ProfilerMarkerDataType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Unity.Profiling.LowLevel.ProfilerMarkerDataType");
		addMember(l,2,"Int32");
		addMember(l,3,"UInt32");
		addMember(l,4,"Int64");
		addMember(l,5,"UInt64");
		addMember(l,6,"Float");
		addMember(l,7,"Double");
		addMember(l,9,"String16");
		addMember(l,11,"Blob8");
		LuaDLL.lua_pop(l, 1);
	}
}
