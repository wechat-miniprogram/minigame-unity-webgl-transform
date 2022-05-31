using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_EventTriggerType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.EventSystems.EventTriggerType");
		addMember(l,0,"PointerEnter");
		addMember(l,1,"PointerExit");
		addMember(l,2,"PointerDown");
		addMember(l,3,"PointerUp");
		addMember(l,4,"PointerClick");
		addMember(l,5,"Drag");
		addMember(l,6,"Drop");
		addMember(l,7,"Scroll");
		addMember(l,8,"UpdateSelected");
		addMember(l,9,"Select");
		addMember(l,10,"Deselect");
		addMember(l,11,"Move");
		addMember(l,12,"InitializePotentialDrag");
		addMember(l,13,"BeginDrag");
		addMember(l,14,"EndDrag");
		addMember(l,15,"Submit");
		addMember(l,16,"Cancel");
		LuaDLL.lua_pop(l, 1);
	}
}
