using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_HumanPartDof : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.HumanPartDof");
		addMember(l,0,"Body");
		addMember(l,1,"Head");
		addMember(l,2,"LeftLeg");
		addMember(l,3,"RightLeg");
		addMember(l,4,"LeftArm");
		addMember(l,5,"RightArm");
		addMember(l,6,"LeftThumb");
		addMember(l,7,"LeftIndex");
		addMember(l,8,"LeftMiddle");
		addMember(l,9,"LeftRing");
		addMember(l,10,"LeftLittle");
		addMember(l,11,"RightThumb");
		addMember(l,12,"RightIndex");
		addMember(l,13,"RightMiddle");
		addMember(l,14,"RightRing");
		addMember(l,15,"RightLittle");
		addMember(l,16,"LastHumanPartDof");
		LuaDLL.lua_pop(l, 1);
	}
}
