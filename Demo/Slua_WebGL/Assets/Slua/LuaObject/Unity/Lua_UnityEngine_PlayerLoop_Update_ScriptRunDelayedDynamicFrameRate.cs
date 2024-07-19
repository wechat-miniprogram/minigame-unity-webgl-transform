using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_Update_ScriptRunDelayedDynamicFrameRate : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.Update.ScriptRunDelayedDynamicFrameRate o;
			o=new UnityEngine.PlayerLoop.Update.ScriptRunDelayedDynamicFrameRate();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.Update.ScriptRunDelayedDynamicFrameRate");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.Update.ScriptRunDelayedDynamicFrameRate),typeof(System.ValueType));
	}
}
