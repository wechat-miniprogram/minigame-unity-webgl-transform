using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AudioVelocityUpdateMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AudioVelocityUpdateMode");
		addMember(l,0,"Auto");
		addMember(l,1,"Fixed");
		addMember(l,2,"Dynamic");
		LuaDLL.lua_pop(l, 1);
	}
}
