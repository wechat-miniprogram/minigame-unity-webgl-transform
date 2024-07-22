using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ArmDof : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.ArmDof");
		addMember(l,0,"ShoulderDownUp");
		addMember(l,1,"ShoulderFrontBack");
		addMember(l,2,"ArmDownUp");
		addMember(l,3,"ArmFrontBack");
		addMember(l,4,"ArmRollInOut");
		addMember(l,5,"ForeArmCloseOpen");
		addMember(l,6,"ForeArmRollInOut");
		addMember(l,7,"HandDownUp");
		addMember(l,8,"HandInOut");
		addMember(l,9,"LastArmDof");
		LuaDLL.lua_pop(l, 1);
	}
}
