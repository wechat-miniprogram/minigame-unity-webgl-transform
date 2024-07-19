using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_WrapMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.WrapMode");
		addMember(l,0,"Default");
		addMember(l,1,"Once");
		addMember(l,1,"Clamp");
		addMember(l,2,"Loop");
		addMember(l,4,"PingPong");
		addMember(l,8,"ClampForever");
		LuaDLL.lua_pop(l, 1);
	}
}
