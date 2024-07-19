using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_HeadDof : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.HeadDof");
		addMember(l,0,"NeckFrontBack");
		addMember(l,1,"NeckLeftRight");
		addMember(l,2,"NeckRollLeftRight");
		addMember(l,3,"HeadFrontBack");
		addMember(l,4,"HeadLeftRight");
		addMember(l,5,"HeadRollLeftRight");
		addMember(l,6,"LeftEyeDownUp");
		addMember(l,7,"LeftEyeInOut");
		addMember(l,8,"RightEyeDownUp");
		addMember(l,9,"RightEyeInOut");
		addMember(l,10,"JawDownUp");
		addMember(l,11,"JawLeftRight");
		addMember(l,12,"LastHeadDof");
		LuaDLL.lua_pop(l, 1);
	}
}
