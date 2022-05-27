using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Toggle : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Rebuild(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
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
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
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
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
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
	static public int SetIsOnWithoutNotify(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.SetIsOnWithoutNotify(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnPointerClick(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerClick(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnSubmit(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_toggleTransition(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.toggleTransition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_toggleTransition(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			UnityEngine.UI.Toggle.ToggleTransition v;
			v = (UnityEngine.UI.Toggle.ToggleTransition)LuaDLL.luaL_checkinteger(l, 2);
			self.toggleTransition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_graphic(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.graphic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_graphic(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			UnityEngine.UI.Graphic v;
			checkType(l,2,out v);
			self.graphic=v;
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
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
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
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			UnityEngine.UI.Toggle.ToggleEvent v;
			checkType(l,2,out v);
			self.onValueChanged=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_group(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.group);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_group(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			UnityEngine.UI.ToggleGroup v;
			checkType(l,2,out v);
			self.group=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isOn(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isOn);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isOn(IntPtr l) {
		try {
			UnityEngine.UI.Toggle self=(UnityEngine.UI.Toggle)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.isOn=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Toggle");
		addMember(l,Rebuild);
		addMember(l,LayoutComplete);
		addMember(l,GraphicUpdateComplete);
		addMember(l,SetIsOnWithoutNotify);
		addMember(l,OnPointerClick);
		addMember(l,OnSubmit);
		addMember(l,"toggleTransition",get_toggleTransition,set_toggleTransition,true);
		addMember(l,"graphic",get_graphic,set_graphic,true);
		addMember(l,"onValueChanged",get_onValueChanged,set_onValueChanged,true);
		addMember(l,"group",get_group,set_group,true);
		addMember(l,"isOn",get_isOn,set_isOn,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Toggle),typeof(UnityEngine.UI.Selectable));
	}
}
