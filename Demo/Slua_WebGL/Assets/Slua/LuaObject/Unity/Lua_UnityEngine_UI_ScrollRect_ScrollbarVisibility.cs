using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ScrollRect_ScrollbarVisibility : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.ScrollRect.ScrollbarVisibility");
		addMember(l,0,"Permanent");
		addMember(l,1,"AutoHide");
		addMember(l,2,"AutoHideAndExpandViewport");
		LuaDLL.lua_pop(l, 1);
	}
}
