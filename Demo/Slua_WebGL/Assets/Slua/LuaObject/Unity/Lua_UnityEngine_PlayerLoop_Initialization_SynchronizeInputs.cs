using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_Initialization_SynchronizeInputs : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.Initialization.SynchronizeInputs o;
			o=new UnityEngine.PlayerLoop.Initialization.SynchronizeInputs();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.Initialization.SynchronizeInputs");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.Initialization.SynchronizeInputs),typeof(System.ValueType));
	}
}
