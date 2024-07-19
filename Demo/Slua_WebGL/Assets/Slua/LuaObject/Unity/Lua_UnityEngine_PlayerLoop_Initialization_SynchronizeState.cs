using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_Initialization_SynchronizeState : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.Initialization.SynchronizeState o;
			o=new UnityEngine.PlayerLoop.Initialization.SynchronizeState();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.Initialization.SynchronizeState");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.Initialization.SynchronizeState),typeof(System.ValueType));
	}
}
