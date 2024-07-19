using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemCullingMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemCullingMode");
		addMember(l,0,"Automatic");
		addMember(l,1,"PauseAndCatchup");
		addMember(l,2,"Pause");
		addMember(l,3,"AlwaysSimulate");
		LuaDLL.lua_pop(l, 1);
	}
}
