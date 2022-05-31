using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemMeshDistribution : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemMeshDistribution");
		addMember(l,0,"UniformRandom");
		addMember(l,1,"NonUniformRandom");
		LuaDLL.lua_pop(l, 1);
	}
}
