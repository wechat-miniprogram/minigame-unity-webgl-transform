using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemForceFieldShape : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemForceFieldShape");
		addMember(l,0,"Sphere");
		addMember(l,1,"Hemisphere");
		addMember(l,2,"Cylinder");
		addMember(l,3,"Box");
		LuaDLL.lua_pop(l, 1);
	}
}
