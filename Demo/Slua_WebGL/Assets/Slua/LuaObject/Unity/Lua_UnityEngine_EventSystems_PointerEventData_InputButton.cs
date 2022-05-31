using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_PointerEventData_InputButton : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.EventSystems.PointerEventData.InputButton");
		addMember(l,0,"Left");
		addMember(l,1,"Right");
		addMember(l,2,"Middle");
		LuaDLL.lua_pop(l, 1);
	}
}
