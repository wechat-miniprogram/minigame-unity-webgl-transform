using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemAnimationMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemAnimationMode");
		addMember(l,0,"Grid");
		addMember(l,1,"Sprites");
		LuaDLL.lua_pop(l, 1);
	}
}
