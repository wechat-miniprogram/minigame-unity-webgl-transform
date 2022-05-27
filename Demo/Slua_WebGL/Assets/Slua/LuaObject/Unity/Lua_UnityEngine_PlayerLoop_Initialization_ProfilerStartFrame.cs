using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_Initialization_ProfilerStartFrame : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.Initialization.ProfilerStartFrame o;
			o=new UnityEngine.PlayerLoop.Initialization.ProfilerStartFrame();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.Initialization.ProfilerStartFrame");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.Initialization.ProfilerStartFrame),typeof(System.ValueType));
	}
}
