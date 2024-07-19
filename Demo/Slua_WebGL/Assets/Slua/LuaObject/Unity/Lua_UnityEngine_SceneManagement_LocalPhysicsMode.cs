using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SceneManagement_LocalPhysicsMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SceneManagement.LocalPhysicsMode");
		addMember(l,0,"None");
		addMember(l,1,"Physics2D");
		addMember(l,2,"Physics3D");
		LuaDLL.lua_pop(l, 1);
	}
}
