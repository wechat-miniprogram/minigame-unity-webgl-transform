using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_AimConstraint_WorldUpType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Animations.AimConstraint.WorldUpType");
		addMember(l,0,"SceneUp");
		addMember(l,1,"ObjectUp");
		addMember(l,2,"ObjectRotationUp");
		addMember(l,3,"Vector");
		addMember(l,4,"None");
		LuaDLL.lua_pop(l, 1);
	}
}
