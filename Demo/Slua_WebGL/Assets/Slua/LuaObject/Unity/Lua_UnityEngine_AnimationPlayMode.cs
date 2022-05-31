using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimationPlayMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AnimationPlayMode");
		addMember(l,0,"Stop");
		addMember(l,1,"Queue");
		addMember(l,2,"Mix");
		LuaDLL.lua_pop(l, 1);
	}
}
