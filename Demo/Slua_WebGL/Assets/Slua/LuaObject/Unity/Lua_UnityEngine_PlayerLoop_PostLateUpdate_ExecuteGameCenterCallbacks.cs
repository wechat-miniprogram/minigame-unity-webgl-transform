using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_PostLateUpdate_ExecuteGameCenterCallbacks : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.PostLateUpdate.ExecuteGameCenterCallbacks o;
			o=new UnityEngine.PlayerLoop.PostLateUpdate.ExecuteGameCenterCallbacks();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.PlayerLoop.PostLateUpdate.ExecuteGameCenterCallbacks");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.PostLateUpdate.ExecuteGameCenterCallbacks),typeof(System.ValueType));
	}
}
