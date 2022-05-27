using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_LegDof : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.LegDof");
		addMember(l,0,"UpperLegFrontBack");
		addMember(l,1,"UpperLegInOut");
		addMember(l,2,"UpperLegRollInOut");
		addMember(l,3,"LegCloseOpen");
		addMember(l,4,"LegRollInOut");
		addMember(l,5,"FootCloseOpen");
		addMember(l,6,"FootInOut");
		addMember(l,7,"ToesUpDown");
		addMember(l,8,"LastLegDof");
		LuaDLL.lua_pop(l, 1);
	}
}
