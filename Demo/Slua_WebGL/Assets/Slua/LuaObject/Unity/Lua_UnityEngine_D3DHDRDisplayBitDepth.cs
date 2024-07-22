using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_D3DHDRDisplayBitDepth : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.D3DHDRDisplayBitDepth");
		addMember(l,0,"D3DHDRDisplayBitDepth10");
		addMember(l,1,"D3DHDRDisplayBitDepth16");
		LuaDLL.lua_pop(l, 1);
	}
}
