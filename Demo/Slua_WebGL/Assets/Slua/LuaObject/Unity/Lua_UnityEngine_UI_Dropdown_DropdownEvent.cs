using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Dropdown_DropdownEvent : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Dropdown.DropdownEvent o;
			o=new UnityEngine.UI.Dropdown.DropdownEvent();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		LuaUnityEvent_int.reg(l);
		getTypeTable(l,"UnityEngine.UI.Dropdown.DropdownEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Dropdown.DropdownEvent),typeof(LuaUnityEvent_int));
	}
}
