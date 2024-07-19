using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_MaskableGraphic_CullStateChangedEvent : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic.CullStateChangedEvent o;
			o=new UnityEngine.UI.MaskableGraphic.CullStateChangedEvent();
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
		LuaUnityEvent_bool.reg(l);
		getTypeTable(l,"UnityEngine.UI.MaskableGraphic.CullStateChangedEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.MaskableGraphic.CullStateChangedEvent),typeof(LuaUnityEvent_bool));
	}
}
