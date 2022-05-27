using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_IClippable : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RecalculateClipping(IntPtr l) {
		try {
			UnityEngine.UI.IClippable self=(UnityEngine.UI.IClippable)checkSelf(l);
			self.RecalculateClipping();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Cull(IntPtr l) {
		try {
			UnityEngine.UI.IClippable self=(UnityEngine.UI.IClippable)checkSelf(l);
			UnityEngine.Rect a1;
			checkValueType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.Cull(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetClipRect(IntPtr l) {
		try {
			UnityEngine.UI.IClippable self=(UnityEngine.UI.IClippable)checkSelf(l);
			UnityEngine.Rect a1;
			checkValueType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.SetClipRect(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetClipSoftness(IntPtr l) {
		try {
			UnityEngine.UI.IClippable self=(UnityEngine.UI.IClippable)checkSelf(l);
			UnityEngine.Vector2 a1;
			checkType(l,2,out a1);
			self.SetClipSoftness(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gameObject(IntPtr l) {
		try {
			UnityEngine.UI.IClippable self=(UnityEngine.UI.IClippable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.gameObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rectTransform(IntPtr l) {
		try {
			UnityEngine.UI.IClippable self=(UnityEngine.UI.IClippable)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rectTransform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.IClippable");
		addMember(l,RecalculateClipping);
		addMember(l,Cull);
		addMember(l,SetClipRect);
		addMember(l,SetClipSoftness);
		addMember(l,"gameObject",get_gameObject,null,true);
		addMember(l,"rectTransform",get_rectTransform,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.IClippable));
	}
}
