using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_IDeselectHandler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnDeselect(IntPtr l) {
		try {
			UnityEngine.EventSystems.IDeselectHandler self=(UnityEngine.EventSystems.IDeselectHandler)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnDeselect(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.IDeselectHandler");
		addMember(l,OnDeselect);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.IDeselectHandler));
	}
}
