using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_TimeUpdate_WaitForLastPresentationAndUpdateTime : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.TimeUpdate.WaitForLastPresentationAndUpdateTime o;
			o=new UnityEngine.PlayerLoop.TimeUpdate.WaitForLastPresentationAndUpdateTime();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.TimeUpdate.WaitForLastPresentationAndUpdateTime");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.TimeUpdate.WaitForLastPresentationAndUpdateTime),typeof(System.ValueType));
	}
}
