using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_HDRDisplaySupportFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.HDRDisplaySupportFlags");
		addMember(l,0,"None");
		addMember(l,1,"Supported");
		addMember(l,2,"RuntimeSwitchable");
		addMember(l,4,"AutomaticTonemapping");
		LuaDLL.lua_pop(l, 1);
	}
}
