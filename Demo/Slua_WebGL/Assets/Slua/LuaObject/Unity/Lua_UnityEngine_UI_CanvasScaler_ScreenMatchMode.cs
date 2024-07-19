using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_CanvasScaler_ScreenMatchMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.CanvasScaler.ScreenMatchMode");
		addMember(l,0,"MatchWidthOrHeight");
		addMember(l,1,"Expand");
		addMember(l,2,"Shrink");
		LuaDLL.lua_pop(l, 1);
	}
}
