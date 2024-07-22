using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemAnimationRowMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemAnimationRowMode");
		addMember(l,0,"Custom");
		addMember(l,1,"Random");
		addMember(l,2,"MeshIndex");
		LuaDLL.lua_pop(l, 1);
	}
}
