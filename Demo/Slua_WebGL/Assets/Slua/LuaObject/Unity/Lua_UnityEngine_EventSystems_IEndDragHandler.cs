using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_IEndDragHandler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnEndDrag(IntPtr l) {
		try {
			UnityEngine.EventSystems.IEndDragHandler self=(UnityEngine.EventSystems.IEndDragHandler)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnEndDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.IEndDragHandler");
		addMember(l,OnEndDrag);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.IEndDragHandler));
	}
}
