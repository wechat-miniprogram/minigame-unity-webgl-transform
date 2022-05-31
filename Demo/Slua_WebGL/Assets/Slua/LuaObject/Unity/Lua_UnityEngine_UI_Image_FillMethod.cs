using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Image_FillMethod : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Image.FillMethod");
		addMember(l,0,"Horizontal");
		addMember(l,1,"Vertical");
		addMember(l,2,"Radial90");
		addMember(l,3,"Radial180");
		addMember(l,4,"Radial360");
		LuaDLL.lua_pop(l, 1);
	}
}
