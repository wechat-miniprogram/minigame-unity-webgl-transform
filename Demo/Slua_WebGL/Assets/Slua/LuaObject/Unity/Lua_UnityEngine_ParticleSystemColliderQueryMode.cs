using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemColliderQueryMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemColliderQueryMode");
		addMember(l,0,"Disabled");
		addMember(l,1,"One");
		addMember(l,2,"All");
		LuaDLL.lua_pop(l, 1);
	}
}
