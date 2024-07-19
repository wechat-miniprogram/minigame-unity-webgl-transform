using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_EarlyUpdate_UpdateKinect : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.EarlyUpdate.UpdateKinect o;
			o=new UnityEngine.PlayerLoop.EarlyUpdate.UpdateKinect();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.EarlyUpdate.UpdateKinect");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.EarlyUpdate.UpdateKinect),typeof(System.ValueType));
	}
}
