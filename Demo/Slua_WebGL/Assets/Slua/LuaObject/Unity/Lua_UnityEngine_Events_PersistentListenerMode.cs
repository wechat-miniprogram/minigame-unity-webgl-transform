using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Events_PersistentListenerMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Events.PersistentListenerMode");
		addMember(l,0,"EventDefined");
		addMember(l,1,"Void");
		addMember(l,2,"Object");
		addMember(l,3,"Int");
		addMember(l,4,"Float");
		addMember(l,5,"String");
		addMember(l,6,"Bool");
		LuaDLL.lua_pop(l, 1);
	}
}
