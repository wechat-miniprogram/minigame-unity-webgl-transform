using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Image_Type : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Image.Type");
		addMember(l,0,"Simple");
		addMember(l,1,"Sliced");
		addMember(l,2,"Tiled");
		addMember(l,3,"Filled");
		LuaDLL.lua_pop(l, 1);
	}
}
