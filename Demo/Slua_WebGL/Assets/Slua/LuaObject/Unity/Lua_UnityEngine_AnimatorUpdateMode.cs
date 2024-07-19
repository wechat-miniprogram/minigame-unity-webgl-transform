using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimatorUpdateMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AnimatorUpdateMode");
		addMember(l,0,"Normal");
		addMember(l,1,"AnimatePhysics");
		addMember(l,2,"UnscaledTime");
		LuaDLL.lua_pop(l, 1);
	}
}
