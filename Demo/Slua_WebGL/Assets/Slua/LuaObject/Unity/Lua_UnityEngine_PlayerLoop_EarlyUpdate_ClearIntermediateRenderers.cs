using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_EarlyUpdate_ClearIntermediateRenderers : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.EarlyUpdate.ClearIntermediateRenderers o;
			o=new UnityEngine.PlayerLoop.EarlyUpdate.ClearIntermediateRenderers();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.EarlyUpdate.ClearIntermediateRenderers");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.EarlyUpdate.ClearIntermediateRenderers),typeof(System.ValueType));
	}
}
