using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Navigation_Mode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Navigation.Mode");
		addMember(l,0,"None");
		addMember(l,1,"Horizontal");
		addMember(l,2,"Vertical");
		addMember(l,3,"Automatic");
		addMember(l,4,"Explicit");
		LuaDLL.lua_pop(l, 1);
	}
}
