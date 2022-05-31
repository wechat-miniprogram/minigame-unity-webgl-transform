using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemRingBufferMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ParticleSystemRingBufferMode");
		addMember(l,0,"Disabled");
		addMember(l,1,"PauseUntilReplaced");
		addMember(l,2,"LoopUntilReplaced");
		LuaDLL.lua_pop(l, 1);
	}
}
