using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ColorGamut : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ColorGamut");
		addMember(l,0,"sRGB");
		addMember(l,1,"Rec709");
		addMember(l,2,"Rec2020");
		addMember(l,3,"DisplayP3");
		addMember(l,4,"HDR10");
		addMember(l,5,"DolbyHDR");
		LuaDLL.lua_pop(l, 1);
	}
}
