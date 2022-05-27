using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_CanvasUpdate : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.CanvasUpdate");
		addMember(l,0,"Prelayout");
		addMember(l,1,"Layout");
		addMember(l,2,"PostLayout");
		addMember(l,3,"PreRender");
		addMember(l,4,"LatePreRender");
		addMember(l,5,"MaxUpdateValue");
		LuaDLL.lua_pop(l, 1);
	}
}
