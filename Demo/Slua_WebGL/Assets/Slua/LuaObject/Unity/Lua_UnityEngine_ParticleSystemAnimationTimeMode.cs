using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemAnimationTimeMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemAnimationTimeMode");
		addMember(l,0,"Lifetime");
		addMember(l,1,"Speed");
		addMember(l,2,"FPS");
		LuaDLL.lua_pop(l, 1);
	}
}
