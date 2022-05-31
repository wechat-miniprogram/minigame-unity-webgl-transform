using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_MoveDirection : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.EventSystems.MoveDirection");
		addMember(l,0,"Left");
		addMember(l,1,"Up");
		addMember(l,2,"Right");
		addMember(l,3,"Down");
		addMember(l,4,"None");
		LuaDLL.lua_pop(l, 1);
	}
}
