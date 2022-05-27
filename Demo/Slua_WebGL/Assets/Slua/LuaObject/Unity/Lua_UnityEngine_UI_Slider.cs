using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Slider : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetValueWithoutNotify(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetValueWithoutNotify(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Rebuild(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.UI.CanvasUpdate a1;
			a1 = (UnityEngine.UI.CanvasUpdate)LuaDLL.luaL_checkinteger(l, 2);
			self.Rebuild(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LayoutComplete(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			self.LayoutComplete();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GraphicUpdateComplete(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			self.GraphicUpdateComplete();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnPointerDown(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerDown(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnDrag(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnMove(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.EventSystems.AxisEventData a1;
			checkType(l,2,out a1);
			self.OnMove(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindSelectableOnLeft(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			var ret=self.FindSelectableOnLeft();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindSelectableOnRight(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			var ret=self.FindSelectableOnRight();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindSelectableOnUp(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			var ret=self.FindSelectableOnUp();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindSelectableOnDown(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			var ret=self.FindSelectableOnDown();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnInitializePotentialDrag(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetDirection(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.UI.Slider.Direction a1;
			a1 = (UnityEngine.UI.Slider.Direction)LuaDLL.luaL_checkinteger(l, 2);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.SetDirection(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fillRect(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fillRect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fillRect(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.fillRect=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_handleRect(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.handleRect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_handleRect(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.RectTransform v;
			checkType(l,2,out v);
			self.handleRect=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_direction(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.direction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_direction(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.UI.Slider.Direction v;
			v = (UnityEngine.UI.Slider.Direction)LuaDLL.luaL_checkinteger(l, 2);
			self.direction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minValue(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minValue);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minValue(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.minValue=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxValue(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxValue);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxValue(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxValue=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_wholeNumbers(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.wholeNumbers);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_wholeNumbers(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.wholeNumbers=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_value(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.value);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_value(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.value=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_normalizedValue(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.normalizedValue);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_normalizedValue(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.normalizedValue=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_onValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onValueChanged);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_onValueChanged(IntPtr l) {
		try {
			UnityEngine.UI.Slider self=(UnityEngine.UI.Slider)checkSelf(l);
			UnityEngine.UI.Slider.SliderEvent v;
			checkType(l,2,out v);
			self.onValueChanged=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Slider");
		addMember(l,SetValueWithoutNotify);
		addMember(l,Rebuild);
		addMember(l,LayoutComplete);
		addMember(l,GraphicUpdateComplete);
		addMember(l,OnPointerDown);
		addMember(l,OnDrag);
		addMember(l,OnMove);
		addMember(l,FindSelectableOnLeft);
		addMember(l,FindSelectableOnRight);
		addMember(l,FindSelectableOnUp);
		addMember(l,FindSelectableOnDown);
		addMember(l,OnInitializePotentialDrag);
		addMember(l,SetDirection);
		addMember(l,"fillRect",get_fillRect,set_fillRect,true);
		addMember(l,"handleRect",get_handleRect,set_handleRect,true);
		addMember(l,"direction",get_direction,set_direction,true);
		addMember(l,"minValue",get_minValue,set_minValue,true);
		addMember(l,"maxValue",get_maxValue,set_maxValue,true);
		addMember(l,"wholeNumbers",get_wholeNumbers,set_wholeNumbers,true);
		addMember(l,"value",get_value,set_value,true);
		addMember(l,"normalizedValue",get_normalizedValue,set_normalizedValue,true);
		addMember(l,"onValueChanged",get_onValueChanged,set_onValueChanged,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Slider),typeof(UnityEngine.UI.Selectable));
	}
}
