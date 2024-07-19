using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_IPointerEnterHandler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnPointerEnter(IntPtr l) {
		try {
			UnityEngine.EventSystems.IPointerEnterHandler self=(UnityEngine.EventSystems.IPointerEnterHandler)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerEnter(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.IPointerEnterHandler");
		addMember(l,OnPointerEnter);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.IPointerEnterHandler));
	}
}
