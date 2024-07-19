using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_RectMask2D : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsRaycastLocationValid(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
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
	static public int PerformClipping(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			self.PerformClipping();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UpdateClipSoftness(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			self.UpdateClipSoftness();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddClippable(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			UnityEngine.UI.IClippable a1;
			checkType(l,2,out a1);
			self.AddClippable(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveClippable(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			UnityEngine.UI.IClippable a1;
			checkType(l,2,out a1);
			self.RemoveClippable(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_padding(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.padding);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_padding(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			UnityEngine.Vector4 v;
			checkType(l,2,out v);
			self.padding=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_softness(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.softness);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_softness(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			UnityEngine.Vector2Int v;
			checkValueType(l,2,out v);
			self.softness=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_canvasRect(IntPtr l) {
		try {
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.canvasRect);
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
			UnityEngine.UI.RectMask2D self=(UnityEngine.UI.RectMask2D)checkSelf(l);
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
		getTypeTable(l,"UnityEngine.UI.RectMask2D");
		addMember(l,IsRaycastLocationValid);
		addMember(l,PerformClipping);
		addMember(l,UpdateClipSoftness);
		addMember(l,AddClippable);
		addMember(l,RemoveClippable);
		addMember(l,"padding",get_padding,set_padding,true);
		addMember(l,"softness",get_softness,set_softness,true);
		addMember(l,"canvasRect",get_canvasRect,null,true);
		addMember(l,"rectTransform",get_rectTransform,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.RectMask2D),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
