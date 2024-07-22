using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_Physics2DRaycaster : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Raycast(IntPtr l) {
		try {
			UnityEngine.EventSystems.Physics2DRaycaster self=(UnityEngine.EventSystems.Physics2DRaycaster)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> a2;
			checkType(l,3,out a2);
			self.Raycast(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.Physics2DRaycaster");
		addMember(l,Raycast);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.Physics2DRaycaster),typeof(UnityEngine.EventSystems.PhysicsRaycaster));
	}
}
