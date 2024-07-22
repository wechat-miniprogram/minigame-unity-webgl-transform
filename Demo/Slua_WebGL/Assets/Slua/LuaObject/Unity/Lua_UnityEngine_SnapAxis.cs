using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SnapAxis : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SnapAxis");
		addMember(l,0,"None");
		addMember(l,1,"X");
		addMember(l,2,"Y");
		addMember(l,4,"Z");
		addMember(l,7,"All");
		LuaDLL.lua_pop(l, 1);
	}
}
