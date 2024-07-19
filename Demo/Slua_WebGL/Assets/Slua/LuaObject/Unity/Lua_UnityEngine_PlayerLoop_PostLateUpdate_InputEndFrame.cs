using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_PostLateUpdate_InputEndFrame : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.PostLateUpdate.InputEndFrame o;
			o=new UnityEngine.PlayerLoop.PostLateUpdate.InputEndFrame();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.PostLateUpdate.InputEndFrame");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.PostLateUpdate.InputEndFrame),typeof(System.ValueType));
	}
}
