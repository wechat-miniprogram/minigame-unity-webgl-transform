using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Unity_Profiling_ProfilerCategoryColor : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"Unity.Profiling.ProfilerCategoryColor");
		addMember(l,0,"Render");
		addMember(l,1,"Scripts");
		addMember(l,2,"BurstJobs");
		addMember(l,3,"Other");
		addMember(l,4,"Physics");
		addMember(l,5,"Animation");
		addMember(l,6,"Audio");
		addMember(l,7,"AudioJob");
		addMember(l,8,"AudioUpdateJob");
		addMember(l,9,"Lighting");
		addMember(l,10,"GC");
		addMember(l,11,"VSync");
		addMember(l,12,"Memory");
		addMember(l,13,"Internal");
		addMember(l,14,"UI");
		addMember(l,15,"Build");
		addMember(l,16,"Input");
		LuaDLL.lua_pop(l, 1);
	}
}
