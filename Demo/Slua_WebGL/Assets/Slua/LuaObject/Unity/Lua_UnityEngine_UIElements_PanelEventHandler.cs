using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UIElements_PanelEventHandler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnSelect(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSelect(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnDeselect(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnPointerMove(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerMove(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnPointerUp(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerUp(a1);
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
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
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
	static public int OnSubmit(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
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
	static public int OnCancel(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnCancel(a1);
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
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
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
	static public int OnScroll(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnScroll(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_panel(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.panel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_panel(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelEventHandler self=(UnityEngine.UIElements.PanelEventHandler)checkSelf(l);
			UnityEngine.UIElements.IPanel v;
			checkType(l,2,out v);
			self.panel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UIElements.PanelEventHandler");
		addMember(l,OnSelect);
		addMember(l,OnDeselect);
		addMember(l,OnPointerMove);
		addMember(l,OnPointerUp);
		addMember(l,OnPointerDown);
		addMember(l,OnSubmit);
		addMember(l,OnCancel);
		addMember(l,OnMove);
		addMember(l,OnScroll);
		addMember(l,"panel",get_panel,set_panel,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UIElements.PanelEventHandler),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
