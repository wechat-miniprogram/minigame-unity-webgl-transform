using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_FingerDof : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.FingerDof");
		addMember(l,0,"ProximalDownUp");
		addMember(l,1,"ProximalInOut");
		addMember(l,2,"IntermediateCloseOpen");
		addMember(l,3,"DistalCloseOpen");
		addMember(l,4,"LastFingerDof");
		LuaDLL.lua_pop(l, 1);
	}
}
