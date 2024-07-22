using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Image_OriginHorizontal : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Image.OriginHorizontal");
		addMember(l,0,"Left");
		addMember(l,1,"Right");
		LuaDLL.lua_pop(l, 1);
	}
}
