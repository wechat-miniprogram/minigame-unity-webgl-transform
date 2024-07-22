using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemShapeTextureChannel : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemShapeTextureChannel");
		addMember(l,0,"Red");
		addMember(l,1,"Green");
		addMember(l,2,"Blue");
		addMember(l,3,"Alpha");
		LuaDLL.lua_pop(l, 1);
	}
}
