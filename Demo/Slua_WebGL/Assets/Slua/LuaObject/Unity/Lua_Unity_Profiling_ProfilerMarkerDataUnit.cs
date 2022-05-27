using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_ProfilerMarkerDataUnit : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Unity.Profiling.ProfilerMarkerDataUnit");
		addMember(l,0,"Undefined");
		addMember(l,1,"TimeNanoseconds");
		addMember(l,2,"Bytes");
		addMember(l,3,"Count");
		addMember(l,4,"Percent");
		addMember(l,5,"FrequencyHz");
		LuaDLL.lua_pop(l, 1);
	}
}
