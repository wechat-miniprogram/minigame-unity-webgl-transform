using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_PreUpdate_UpdateVideo : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.PreUpdate.UpdateVideo o;
			o=new UnityEngine.PlayerLoop.PreUpdate.UpdateVideo();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.PreUpdate.UpdateVideo");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.PreUpdate.UpdateVideo),typeof(System.ValueType));
	}
}
