using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_PostLateUpdate_ShaderHandleErrors : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.PostLateUpdate.ShaderHandleErrors o;
			o=new UnityEngine.PlayerLoop.PostLateUpdate.ShaderHandleErrors();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.PostLateUpdate.ShaderHandleErrors");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.PostLateUpdate.ShaderHandleErrors),typeof(System.ValueType));
	}
}
