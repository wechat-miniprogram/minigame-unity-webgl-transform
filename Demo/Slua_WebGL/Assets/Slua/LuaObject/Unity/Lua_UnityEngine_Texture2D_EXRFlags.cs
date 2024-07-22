using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Texture2D_EXRFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.Texture2D.EXRFlags");
		addMember(l,0,"None");
		addMember(l,1,"OutputAsFloat");
		addMember(l,2,"CompressZIP");
		addMember(l,4,"CompressRLE");
		addMember(l,8,"CompressPIZ");
		LuaDLL.lua_pop(l, 1);
	}
}
