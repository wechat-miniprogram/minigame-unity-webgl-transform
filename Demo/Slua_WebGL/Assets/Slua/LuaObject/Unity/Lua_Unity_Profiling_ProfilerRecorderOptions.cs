using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_ProfilerRecorderOptions : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Unity.Profiling.ProfilerRecorderOptions");
		addMember(l,0,"None");
		addMember(l,1,"StartImmediately");
		addMember(l,2,"KeepAliveDuringDomainReload");
		addMember(l,4,"CollectOnlyOnCurrentThread");
		addMember(l,8,"WrapAroundWhenCapacityReached");
		addMember(l,16,"SumAllSamplesInFrame");
		addMember(l,24,"Default");
		addMember(l,64,"GpuRecorder");
		LuaDLL.lua_pop(l, 1);
	}
}
