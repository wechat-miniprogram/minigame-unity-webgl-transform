using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_HideFlags : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"UnityEngine.HideFlags");
		addMember(l,0,"None");
		addMember(l,1,"HideInHierarchy");
		addMember(l,2,"HideInInspector");
		addMember(l,4,"DontSaveInEditor");
		addMember(l,8,"NotEditable");
		addMember(l,16,"DontSaveInBuild");
		addMember(l,32,"DontUnloadUnusedAsset");
		addMember(l,52,"DontSave");
		addMember(l,61,"HideAndDontSave");
		LuaDLL.lua_pop(l, 1);
	}
}
