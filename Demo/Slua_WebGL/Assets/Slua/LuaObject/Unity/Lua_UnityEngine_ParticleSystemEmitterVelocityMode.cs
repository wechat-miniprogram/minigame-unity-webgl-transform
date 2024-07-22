using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemEmitterVelocityMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemEmitterVelocityMode");
		addMember(l,0,"Transform");
		addMember(l,1,"Rigidbody");
		addMember(l,2,"Custom");
		LuaDLL.lua_pop(l, 1);
	}
}
