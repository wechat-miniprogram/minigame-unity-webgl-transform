using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemStopAction : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemStopAction");
		addMember(l,0,"None");
		addMember(l,1,"Disable");
		addMember(l,2,"Destroy");
		addMember(l,3,"Callback");
		LuaDLL.lua_pop(l, 1);
	}
}
