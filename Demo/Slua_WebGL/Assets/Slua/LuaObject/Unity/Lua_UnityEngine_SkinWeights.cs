using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SkinWeights : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SkinWeights");
		addMember(l,1,"OneBone");
		addMember(l,2,"TwoBones");
		addMember(l,4,"FourBones");
		addMember(l,255,"Unlimited");
		LuaDLL.lua_pop(l, 1);
	}
}
