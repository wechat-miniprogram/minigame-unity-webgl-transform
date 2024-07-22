using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_ISubmitHandler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnSubmit(IntPtr l) {
		try {
			UnityEngine.EventSystems.ISubmitHandler self=(UnityEngine.EventSystems.ISubmitHandler)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSubmit(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.ISubmitHandler");
		addMember(l,OnSubmit);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.ISubmitHandler));
	}
}
