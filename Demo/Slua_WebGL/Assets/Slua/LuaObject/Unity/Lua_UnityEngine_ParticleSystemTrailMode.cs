using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemTrailMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemTrailMode");
		addMember(l,0,"PerParticle");
		addMember(l,1,"Ribbon");
		LuaDLL.lua_pop(l, 1);
	}
}
