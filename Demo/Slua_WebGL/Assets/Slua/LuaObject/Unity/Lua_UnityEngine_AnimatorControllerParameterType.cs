using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimatorControllerParameterType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AnimatorControllerParameterType");
		addMember(l,1,"Float");
		addMember(l,3,"Int");
		addMember(l,4,"Bool");
		addMember(l,9,"Trigger");
		LuaDLL.lua_pop(l, 1);
	}
}
