using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemGameObjectFilter : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemGameObjectFilter");
		addMember(l,0,"LayerMask");
		addMember(l,1,"List");
		addMember(l,2,"LayerMaskAndList");
		LuaDLL.lua_pop(l, 1);
	}
}
