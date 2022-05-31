using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RenderTextureMemoryless : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.RenderTextureMemoryless");
		addMember(l,0,"None");
		addMember(l,1,"Color");
		addMember(l,2,"Depth");
		addMember(l,4,"MSAA");
		LuaDLL.lua_pop(l, 1);
	}
}
