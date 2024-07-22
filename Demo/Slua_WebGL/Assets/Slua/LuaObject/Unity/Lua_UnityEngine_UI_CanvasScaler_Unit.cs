using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_CanvasScaler_Unit : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.CanvasScaler.Unit");
		addMember(l,0,"Centimeters");
		addMember(l,1,"Millimeters");
		addMember(l,2,"Inches");
		addMember(l,3,"Points");
		addMember(l,4,"Picas");
		LuaDLL.lua_pop(l, 1);
	}
}
