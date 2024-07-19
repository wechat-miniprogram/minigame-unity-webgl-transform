using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnisotropicFiltering : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AnisotropicFiltering");
		addMember(l,0,"Disable");
		addMember(l,1,"Enable");
		addMember(l,2,"ForceEnable");
		LuaDLL.lua_pop(l, 1);
	}
}
