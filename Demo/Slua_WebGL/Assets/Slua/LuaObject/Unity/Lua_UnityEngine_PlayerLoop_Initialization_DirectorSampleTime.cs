using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_Initialization_DirectorSampleTime : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.Initialization.DirectorSampleTime o;
			o=new UnityEngine.PlayerLoop.Initialization.DirectorSampleTime();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.Initialization.DirectorSampleTime");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.Initialization.DirectorSampleTime),typeof(System.ValueType));
	}
}
