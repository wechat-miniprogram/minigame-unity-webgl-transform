using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ScrollRect_MovementType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.ScrollRect.MovementType");
		addMember(l,0,"Unrestricted");
		addMember(l,1,"Elastic");
		addMember(l,2,"Clamped");
		LuaDLL.lua_pop(l, 1);
	}
}
