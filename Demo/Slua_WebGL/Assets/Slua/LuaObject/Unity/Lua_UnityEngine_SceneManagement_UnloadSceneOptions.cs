using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SceneManagement_UnloadSceneOptions : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.SceneManagement.UnloadSceneOptions");
		addMember(l,0,"None");
		addMember(l,1,"UnloadAllEmbeddedSceneObjects");
		LuaDLL.lua_pop(l, 1);
	}
}
