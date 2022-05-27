using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SpriteSortPoint : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SpriteSortPoint");
		addMember(l,0,"Center");
		addMember(l,1,"Pivot");
		LuaDLL.lua_pop(l, 1);
	}
}
