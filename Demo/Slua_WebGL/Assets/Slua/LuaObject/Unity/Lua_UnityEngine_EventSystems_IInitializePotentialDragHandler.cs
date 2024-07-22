using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_IInitializePotentialDragHandler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnInitializePotentialDrag(IntPtr l) {
		try {
			UnityEngine.EventSystems.IInitializePotentialDragHandler self=(UnityEngine.EventSystems.IInitializePotentialDragHandler)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnInitializePotentialDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.IInitializePotentialDragHandler");
		addMember(l,OnInitializePotentialDrag);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.IInitializePotentialDragHandler));
	}
}
