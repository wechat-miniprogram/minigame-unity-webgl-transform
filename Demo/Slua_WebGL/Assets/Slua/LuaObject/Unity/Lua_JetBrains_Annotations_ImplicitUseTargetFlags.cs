using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_JetBrains_Annotations_ImplicitUseTargetFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"JetBrains.Annotations.ImplicitUseTargetFlags");
		addMember(l,1,"Default");
		addMember(l,1,"Itself");
		addMember(l,2,"Members");
		addMember(l,3,"WithMembers");
		LuaDLL.lua_pop(l, 1);
	}
}
