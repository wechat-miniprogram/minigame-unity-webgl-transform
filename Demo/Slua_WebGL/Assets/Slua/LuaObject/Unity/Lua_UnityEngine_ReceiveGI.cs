using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ReceiveGI : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ReceiveGI");
		addMember(l,1,"Lightmaps");
		addMember(l,2,"LightProbes");
		LuaDLL.lua_pop(l, 1);
	}
}
