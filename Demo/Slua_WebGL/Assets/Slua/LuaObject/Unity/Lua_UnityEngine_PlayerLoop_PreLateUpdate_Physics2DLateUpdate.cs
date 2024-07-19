using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_PreLateUpdate_Physics2DLateUpdate : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.PreLateUpdate.Physics2DLateUpdate o;
			o=new UnityEngine.PlayerLoop.PreLateUpdate.Physics2DLateUpdate();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.PreLateUpdate.Physics2DLateUpdate");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.PreLateUpdate.Physics2DLateUpdate),typeof(System.ValueType));
	}
}
