using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_CanvasScaler : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uiScaleMode(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.uiScaleMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uiScaleMode(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			UnityEngine.UI.CanvasScaler.ScaleMode v;
			v = (UnityEngine.UI.CanvasScaler.ScaleMode)LuaDLL.luaL_checkinteger(l, 2);
			self.uiScaleMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_referencePixelsPerUnit(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.referencePixelsPerUnit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_referencePixelsPerUnit(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.referencePixelsPerUnit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_scaleFactor(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.scaleFactor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_scaleFactor(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.scaleFactor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_referenceResolution(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.referenceResolution);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_referenceResolution(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.referenceResolution=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_screenMatchMode(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.screenMatchMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_screenMatchMode(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			UnityEngine.UI.CanvasScaler.ScreenMatchMode v;
			v = (UnityEngine.UI.CanvasScaler.ScreenMatchMode)LuaDLL.luaL_checkinteger(l, 2);
			self.screenMatchMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_matchWidthOrHeight(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.matchWidthOrHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_matchWidthOrHeight(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.matchWidthOrHeight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_physicalUnit(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.physicalUnit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_physicalUnit(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			UnityEngine.UI.CanvasScaler.Unit v;
			v = (UnityEngine.UI.CanvasScaler.Unit)LuaDLL.luaL_checkinteger(l, 2);
			self.physicalUnit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fallbackScreenDPI(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fallbackScreenDPI);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fallbackScreenDPI(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.fallbackScreenDPI=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultSpriteDPI(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultSpriteDPI);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultSpriteDPI(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.defaultSpriteDPI=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_dynamicPixelsPerUnit(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.dynamicPixelsPerUnit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dynamicPixelsPerUnit(IntPtr l) {
		try {
			UnityEngine.UI.CanvasScaler self=(UnityEngine.UI.CanvasScaler)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.dynamicPixelsPerUnit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.CanvasScaler");
		addMember(l,"uiScaleMode",get_uiScaleMode,set_uiScaleMode,true);
		addMember(l,"referencePixelsPerUnit",get_referencePixelsPerUnit,set_referencePixelsPerUnit,true);
		addMember(l,"scaleFactor",get_scaleFactor,set_scaleFactor,true);
		addMember(l,"referenceResolution",get_referenceResolution,set_referenceResolution,true);
		addMember(l,"screenMatchMode",get_screenMatchMode,set_screenMatchMode,true);
		addMember(l,"matchWidthOrHeight",get_matchWidthOrHeight,set_matchWidthOrHeight,true);
		addMember(l,"physicalUnit",get_physicalUnit,set_physicalUnit,true);
		addMember(l,"fallbackScreenDPI",get_fallbackScreenDPI,set_fallbackScreenDPI,true);
		addMember(l,"defaultSpriteDPI",get_defaultSpriteDPI,set_defaultSpriteDPI,true);
		addMember(l,"dynamicPixelsPerUnit",get_dynamicPixelsPerUnit,set_dynamicPixelsPerUnit,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.CanvasScaler),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
