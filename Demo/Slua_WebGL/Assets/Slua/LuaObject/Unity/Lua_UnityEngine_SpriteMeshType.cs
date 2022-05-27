using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SpriteMeshType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SpriteMeshType");
		addMember(l,0,"FullRect");
		addMember(l,1,"Tight");
		LuaDLL.lua_pop(l, 1);
	}
}
