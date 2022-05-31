using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_AnimationTriggers : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers o;
			o=new UnityEngine.UI.AnimationTriggers();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_normalTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.normalTrigger);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_normalTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.normalTrigger=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_highlightedTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.highlightedTrigger);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_highlightedTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.highlightedTrigger=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pressedTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pressedTrigger);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pressedTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.pressedTrigger=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_selectedTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.selectedTrigger);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_selectedTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.selectedTrigger=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_disabledTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.disabledTrigger);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_disabledTrigger(IntPtr l) {
		try {
			UnityEngine.UI.AnimationTriggers self=(UnityEngine.UI.AnimationTriggers)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.disabledTrigger=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.AnimationTriggers");
		addMember(l,"normalTrigger",get_normalTrigger,set_normalTrigger,true);
		addMember(l,"highlightedTrigger",get_highlightedTrigger,set_highlightedTrigger,true);
		addMember(l,"pressedTrigger",get_pressedTrigger,set_pressedTrigger,true);
		addMember(l,"selectedTrigger",get_selectedTrigger,set_selectedTrigger,true);
		addMember(l,"disabledTrigger",get_disabledTrigger,set_disabledTrigger,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UI.AnimationTriggers));
	}
}
