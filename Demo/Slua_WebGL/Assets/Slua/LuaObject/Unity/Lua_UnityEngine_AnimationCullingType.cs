using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AnimationCullingType : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.AnimationCullingType");
		addMember(l,0,"AlwaysAnimate");
		addMember(l,1,"BasedOnRenderers");
		addMember(l,2,"BasedOnClipBounds");
		addMember(l,3,"BasedOnUserBounds");
		LuaDLL.lua_pop(l, 1);
	}
}
