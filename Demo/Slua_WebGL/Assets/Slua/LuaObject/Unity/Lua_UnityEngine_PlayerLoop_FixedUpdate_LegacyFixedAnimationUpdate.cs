using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_FixedUpdate_LegacyFixedAnimationUpdate : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.FixedUpdate.LegacyFixedAnimationUpdate o;
			o=new UnityEngine.PlayerLoop.FixedUpdate.LegacyFixedAnimationUpdate();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.FixedUpdate.LegacyFixedAnimationUpdate");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.FixedUpdate.LegacyFixedAnimationUpdate),typeof(System.ValueType));
	}
}
