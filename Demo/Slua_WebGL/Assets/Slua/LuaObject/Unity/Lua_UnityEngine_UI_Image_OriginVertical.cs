using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Image_OriginVertical : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.UI.Image.OriginVertical");
		addMember(l,0,"Bottom");
		addMember(l,1,"Top");
		LuaDLL.lua_pop(l, 1);
	}
}
