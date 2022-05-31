using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_OperatingSystemFamily : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.OperatingSystemFamily");
		addMember(l,0,"Other");
		addMember(l,1,"MacOSX");
		addMember(l,2,"Windows");
		addMember(l,3,"Linux");
		LuaDLL.lua_pop(l, 1);
	}
}
