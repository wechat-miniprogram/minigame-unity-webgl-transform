using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimatorCullingMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AnimatorCullingMode");
		addMember(l,0,"AlwaysAnimate");
		addMember(l,1,"CullUpdateTransforms");
		addMember(l,1,"BasedOnRenderers");
		addMember(l,2,"CullCompletely");
		LuaDLL.lua_pop(l, 1);
	}
}
