using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimationBlendMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AnimationBlendMode");
		addMember(l,0,"Blend");
		addMember(l,1,"Additive");
		LuaDLL.lua_pop(l, 1);
	}
}
