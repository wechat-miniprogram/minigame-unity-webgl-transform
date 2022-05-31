using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_LocationServiceStatus : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.LocationServiceStatus");
		addMember(l,0,"Stopped");
		addMember(l,1,"Initializing");
		addMember(l,2,"Running");
		addMember(l,3,"Failed");
		LuaDLL.lua_pop(l, 1);
	}
}
