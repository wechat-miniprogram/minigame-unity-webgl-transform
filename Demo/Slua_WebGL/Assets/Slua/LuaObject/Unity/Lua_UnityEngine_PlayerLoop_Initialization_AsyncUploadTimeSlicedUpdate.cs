using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_Initialization_AsyncUploadTimeSlicedUpdate : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.Initialization.AsyncUploadTimeSlicedUpdate o;
			o=new UnityEngine.PlayerLoop.Initialization.AsyncUploadTimeSlicedUpdate();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.Initialization.AsyncUploadTimeSlicedUpdate");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.Initialization.AsyncUploadTimeSlicedUpdate),typeof(System.ValueType));
	}
}
