using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TextAnchor : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.TextAnchor");
		addMember(l,0,"UpperLeft");
		addMember(l,1,"UpperCenter");
		addMember(l,2,"UpperRight");
		addMember(l,3,"MiddleLeft");
		addMember(l,4,"MiddleCenter");
		addMember(l,5,"MiddleRight");
		addMember(l,6,"LowerLeft");
		addMember(l,7,"LowerCenter");
		addMember(l,8,"LowerRight");
		LuaDLL.lua_pop(l, 1);
	}
}
