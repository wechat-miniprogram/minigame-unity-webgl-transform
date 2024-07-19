using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_ContentSizeFitter : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutHorizontal(IntPtr l) {
		try {
			UnityEngine.UI.ContentSizeFitter self=(UnityEngine.UI.ContentSizeFitter)checkSelf(l);
			self.SetLayoutHorizontal();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLayoutVertical(IntPtr l) {
		try {
			UnityEngine.UI.ContentSizeFitter self=(UnityEngine.UI.ContentSizeFitter)checkSelf(l);
			self.SetLayoutVertical();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_horizontalFit(IntPtr l) {
		try {
			UnityEngine.UI.ContentSizeFitter self=(UnityEngine.UI.ContentSizeFitter)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.horizontalFit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_horizontalFit(IntPtr l) {
		try {
			UnityEngine.UI.ContentSizeFitter self=(UnityEngine.UI.ContentSizeFitter)checkSelf(l);
			UnityEngine.UI.ContentSizeFitter.FitMode v;
			v = (UnityEngine.UI.ContentSizeFitter.FitMode)LuaDLL.luaL_checkinteger(l, 2);
			self.horizontalFit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_verticalFit(IntPtr l) {
		try {
			UnityEngine.UI.ContentSizeFitter self=(UnityEngine.UI.ContentSizeFitter)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.verticalFit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_verticalFit(IntPtr l) {
		try {
			UnityEngine.UI.ContentSizeFitter self=(UnityEngine.UI.ContentSizeFitter)checkSelf(l);
			UnityEngine.UI.ContentSizeFitter.FitMode v;
			v = (UnityEngine.UI.ContentSizeFitter.FitMode)LuaDLL.luaL_checkinteger(l, 2);
			self.verticalFit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.ContentSizeFitter");
		addMember(l,SetLayoutHorizontal);
		addMember(l,SetLayoutVertical);
		addMember(l,"horizontalFit",get_horizontalFit,set_horizontalFit,true);
		addMember(l,"verticalFit",get_verticalFit,set_verticalFit,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.ContentSizeFitter),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
