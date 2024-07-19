using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_WebCamFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.WebCamFlags");
		addMember(l,1,"FrontFacing");
		addMember(l,2,"AutoFocusPointSupported");
		LuaDLL.lua_pop(l, 1);
	}
}
