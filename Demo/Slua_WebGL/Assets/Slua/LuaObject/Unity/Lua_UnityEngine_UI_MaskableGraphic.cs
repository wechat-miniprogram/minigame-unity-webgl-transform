using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_MaskableGraphic : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetModifiedMaterial(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
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
	static public int Cull(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
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
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
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
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
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
	static public int RecalculateClipping(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
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
	static public int RecalculateMasking(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			self.RecalculateMasking();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_onCullStateChanged(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.onCullStateChanged);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_onCullStateChanged(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			UnityEngine.UI.MaskableGraphic.CullStateChangedEvent v;
			checkType(l,2,out v);
			self.onCullStateChanged=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maskable(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maskable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maskable(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.maskable=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isMaskingGraphic(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isMaskingGraphic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isMaskingGraphic(IntPtr l) {
		try {
			UnityEngine.UI.MaskableGraphic self=(UnityEngine.UI.MaskableGraphic)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.isMaskingGraphic=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.MaskableGraphic");
		addMember(l,GetModifiedMaterial);
		addMember(l,Cull);
		addMember(l,SetClipRect);
		addMember(l,SetClipSoftness);
		addMember(l,RecalculateClipping);
		addMember(l,RecalculateMasking);
		addMember(l,"onCullStateChanged",get_onCullStateChanged,set_onCullStateChanged,true);
		addMember(l,"maskable",get_maskable,set_maskable,true);
		addMember(l,"isMaskingGraphic",get_isMaskingGraphic,set_isMaskingGraphic,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.MaskableGraphic),typeof(UnityEngine.UI.Graphic));
	}
}
