using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ToggleGroup : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int NotifyToggleOn(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			UnityEngine.UI.Toggle a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.NotifyToggleOn(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnregisterToggle(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			UnityEngine.UI.Toggle a1;
			checkType(l,2,out a1);
			self.UnregisterToggle(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RegisterToggle(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			UnityEngine.UI.Toggle a1;
			checkType(l,2,out a1);
			self.RegisterToggle(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int EnsureValidState(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			self.EnsureValidState();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AnyTogglesOn(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			var ret=self.AnyTogglesOn();
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
	static public int ActiveToggles(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			var ret=self.ActiveToggles();
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
	static public int GetFirstActiveToggle(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			var ret=self.GetFirstActiveToggle();
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
	static public int SetAllTogglesOff(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.SetAllTogglesOff(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_allowSwitchOff(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.allowSwitchOff);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_allowSwitchOff(IntPtr l) {
		try {
			UnityEngine.UI.ToggleGroup self=(UnityEngine.UI.ToggleGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.allowSwitchOff=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ToggleGroup");
		addMember(l,NotifyToggleOn);
		addMember(l,UnregisterToggle);
		addMember(l,RegisterToggle);
		addMember(l,EnsureValidState);
		addMember(l,AnyTogglesOn);
		addMember(l,ActiveToggles);
		addMember(l,GetFirstActiveToggle);
		addMember(l,SetAllTogglesOff);
		addMember(l,"allowSwitchOff",get_allowSwitchOff,set_allowSwitchOff,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ToggleGroup),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
