using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Slider_SliderEvent : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.Slider.SliderEvent o;
			o=new UnityEngine.UI.Slider.SliderEvent();
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
		LuaUnityEvent_float.reg(l);
		getTypeTable(l,"UnityEngine.UI.Slider.SliderEvent");
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.Slider.SliderEvent),typeof(LuaUnityEvent_float));
	}
}
