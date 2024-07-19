using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SpritePackingMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SpritePackingMode");
		addMember(l,0,"Tight");
		addMember(l,1,"Rectangle");
		LuaDLL.lua_pop(l, 1);
	}
}
