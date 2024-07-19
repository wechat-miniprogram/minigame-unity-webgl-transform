using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_CustomStreamPropertyType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Animations.CustomStreamPropertyType");
		addMember(l,5,"Float");
		addMember(l,6,"Bool");
		addMember(l,10,"Int");
		LuaDLL.lua_pop(l, 1);
	}
}
