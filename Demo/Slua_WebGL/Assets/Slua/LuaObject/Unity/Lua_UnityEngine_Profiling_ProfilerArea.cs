using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Profiling_ProfilerArea : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Profiling.ProfilerArea");
		addMember(l,0,"CPU");
		addMember(l,1,"GPU");
		addMember(l,2,"Rendering");
		addMember(l,3,"Memory");
		addMember(l,4,"Audio");
		addMember(l,5,"Video");
		addMember(l,6,"Physics");
		addMember(l,7,"Physics2D");
		addMember(l,8,"NetworkMessages");
		addMember(l,9,"NetworkOperations");
		addMember(l,10,"UI");
		addMember(l,11,"UIDetails");
		addMember(l,12,"GlobalIllumination");
		addMember(l,13,"VirtualTexturing");
		LuaDLL.lua_pop(l, 1);
	}
}
