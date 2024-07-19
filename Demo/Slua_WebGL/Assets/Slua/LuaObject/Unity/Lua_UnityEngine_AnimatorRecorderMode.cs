using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimatorRecorderMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AnimatorRecorderMode");
		addMember(l,0,"Offline");
		addMember(l,1,"Playback");
		addMember(l,2,"Record");
		LuaDLL.lua_pop(l, 1);
	}
}
