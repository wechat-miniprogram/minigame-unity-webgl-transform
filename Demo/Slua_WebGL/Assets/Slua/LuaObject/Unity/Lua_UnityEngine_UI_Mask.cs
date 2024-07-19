using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_Mask : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int MaskEnabled(IntPtr l) {
		try {
			UnityEngine.UI.Mask self=(UnityEngine.UI.Mask)checkSelf(l);
			var ret=self.MaskEnabled();
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
	static public int IsRaycastLocationValid(IntPtr l) {
		try {
			UnityEngine.UI.Mask self=(UnityEngine.UI.Mask)checkSelf(l);
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
	static public int GetModifiedMaterial(IntPtr l) {
		try {
			UnityEngine.UI.Mask self=(UnityEngine.UI.Mask)checkSelf(l);
			UnityEngine.Material a1;
			checkType(l,2,out a1);
			var ret=self.GetModifiedMaterial(a1);
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
	static public int get_rectTransform(IntPtr l) {
		try {
			UnityEngine.UI.Mask self=(UnityEngine.UI.Mask)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rectTransform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_showMaskGraphic(IntPtr l) {
		try {
			UnityEngine.UI.Mask self=(UnityEngine.UI.Mask)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.showMaskGraphic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_showMaskGraphic(IntPtr l) {
		try {
			UnityEngine.UI.Mask self=(UnityEngine.UI.Mask)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.showMaskGraphic=v;
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
			UnityEngine.UI.Mask self=(UnityEngine.UI.Mask)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.graphic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Mask");
		addMember(l,MaskEnabled);
		addMember(l,IsRaycastLocationValid);
		addMember(l,GetModifiedMaterial);
		addMember(l,"rectTransform",get_rectTransform,null,true);
		addMember(l,"showMaskGraphic",get_showMaskGraphic,set_showMaskGraphic,true);
		addMember(l,"graphic",get_graphic,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Mask),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
