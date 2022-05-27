using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UIElements_PanelRaycaster : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Raycast(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelRaycaster self=(UnityEngine.UIElements.PanelRaycaster)checkSelf(l);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_panel(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelRaycaster self=(UnityEngine.UIElements.PanelRaycaster)checkSelf(l);
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
			UnityEngine.UIElements.PanelRaycaster self=(UnityEngine.UIElements.PanelRaycaster)checkSelf(l);
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sortOrderPriority(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelRaycaster self=(UnityEngine.UIElements.PanelRaycaster)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sortOrderPriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_renderOrderPriority(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelRaycaster self=(UnityEngine.UIElements.PanelRaycaster)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.renderOrderPriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_eventCamera(IntPtr l) {
		try {
			UnityEngine.UIElements.PanelRaycaster self=(UnityEngine.UIElements.PanelRaycaster)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.eventCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UIElements.PanelRaycaster");
		addMember(l,Raycast);
		addMember(l,"panel",get_panel,set_panel,true);
		addMember(l,"sortOrderPriority",get_sortOrderPriority,null,true);
		addMember(l,"renderOrderPriority",get_renderOrderPriority,null,true);
		addMember(l,"eventCamera",get_eventCamera,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UIElements.PanelRaycaster),typeof(UnityEngine.EventSystems.BaseRaycaster));
	}
}
