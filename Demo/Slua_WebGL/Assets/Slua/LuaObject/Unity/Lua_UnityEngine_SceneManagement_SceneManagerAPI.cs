using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_SceneManagement_SceneManagerAPI : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_overrideAPI(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.SceneManagement.SceneManagerAPI.overrideAPI);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_overrideAPI(IntPtr l) {
		try {
			UnityEngine.SceneManagement.SceneManagerAPI v;
			checkType(l,2,out v);
			UnityEngine.SceneManagement.SceneManagerAPI.overrideAPI=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.SceneManagement.SceneManagerAPI");
		addMember(l,"overrideAPI",get_overrideAPI,set_overrideAPI,false);
		createTypeMetatable(l,null, typeof(UnityEngine.SceneManagement.SceneManagerAPI));
	}
}
