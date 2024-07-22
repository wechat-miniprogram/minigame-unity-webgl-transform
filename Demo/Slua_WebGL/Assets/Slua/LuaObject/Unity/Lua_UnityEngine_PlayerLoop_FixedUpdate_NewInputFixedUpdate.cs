using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_FixedUpdate_NewInputFixedUpdate : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.FixedUpdate.NewInputFixedUpdate o;
			o=new UnityEngine.PlayerLoop.FixedUpdate.NewInputFixedUpdate();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.FixedUpdate.NewInputFixedUpdate");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.FixedUpdate.NewInputFixedUpdate),typeof(System.ValueType));
	}
}
