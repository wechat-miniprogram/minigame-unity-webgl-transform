using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_JetBrains_Annotations_AssertionConditionType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"JetBrains.Annotations.AssertionConditionType");
		addMember(l,0,"IS_TRUE");
		addMember(l,1,"IS_FALSE");
		addMember(l,2,"IS_NULL");
		addMember(l,3,"IS_NOT_NULL");
		LuaDLL.lua_pop(l, 1);
	}
}
