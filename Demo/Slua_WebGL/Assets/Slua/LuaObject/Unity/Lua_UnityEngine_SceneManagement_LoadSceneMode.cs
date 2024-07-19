using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SceneManagement_LoadSceneMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SceneManagement.LoadSceneMode");
		addMember(l,0,"Single");
		addMember(l,1,"Additive");
		LuaDLL.lua_pop(l, 1);
	}
}
