using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_CanvasGroup : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsRaycastLocationValid(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			UnityEngine.Camera a2;
			checkType(l,3,out a2);
			var ret=self.IsRaycastLocationValid(a1,a2);
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
	static public int get_alpha(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.alpha);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alpha(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.alpha=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_interactable(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.interactable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_interactable(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.interactable=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_blocksRaycasts(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.blocksRaycasts);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_blocksRaycasts(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.blocksRaycasts=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ignoreParentGroups(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ignoreParentGroups);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ignoreParentGroups(IntPtr l) {
		try {
			UnityEngine.CanvasGroup self=(UnityEngine.CanvasGroup)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.ignoreParentGroups=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.CanvasGroup");
		addMember(l,IsRaycastLocationValid);
		addMember(l,"alpha",get_alpha,set_alpha,true);
		addMember(l,"interactable",get_interactable,set_interactable,true);
		addMember(l,"blocksRaycasts",get_blocksRaycasts,set_blocksRaycasts,true);
		addMember(l,"ignoreParentGroups",get_ignoreParentGroups,set_ignoreParentGroups,true);
		createTypeMetatable(l,null, typeof(UnityEngine.CanvasGroup),typeof(UnityEngine.Behaviour));
	}
}
