using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_CanvasScaler_ScaleMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.CanvasScaler.ScaleMode");
		addMember(l,0,"ConstantPixelSize");
		addMember(l,1,"ScaleWithScreenSize");
		addMember(l,2,"ConstantPhysicalSize");
		LuaDLL.lua_pop(l, 1);
	}
}
