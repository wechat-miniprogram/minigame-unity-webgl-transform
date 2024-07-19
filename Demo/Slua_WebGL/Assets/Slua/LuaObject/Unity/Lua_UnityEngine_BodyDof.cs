using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_BodyDof : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.BodyDof");
		addMember(l,0,"SpineFrontBack");
		addMember(l,1,"SpineLeftRight");
		addMember(l,2,"SpineRollLeftRight");
		addMember(l,3,"ChestFrontBack");
		addMember(l,4,"ChestLeftRight");
		addMember(l,5,"ChestRollLeftRight");
		addMember(l,6,"UpperChestFrontBack");
		addMember(l,7,"UpperChestLeftRight");
		addMember(l,8,"UpperChestRollLeftRight");
		addMember(l,9,"LastBodyDof");
		LuaDLL.lua_pop(l, 1);
	}
}
