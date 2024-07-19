using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_LayoutUtility : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetMinSize_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.LayoutUtility.GetMinSize(a1,a2);
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
	static public int GetPreferredSize_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.LayoutUtility.GetPreferredSize(a1,a2);
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
	static public int GetFlexibleSize_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			var ret=UnityEngine.UI.LayoutUtility.GetFlexibleSize(a1,a2);
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
	static public int GetMinWidth_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.LayoutUtility.GetMinWidth(a1);
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
	static public int GetPreferredWidth_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.LayoutUtility.GetPreferredWidth(a1);
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
	static public int GetFlexibleWidth_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.LayoutUtility.GetFlexibleWidth(a1);
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
	static public int GetMinHeight_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.LayoutUtility.GetMinHeight(a1);
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
	static public int GetPreferredHeight_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.LayoutUtility.GetPreferredHeight(a1);
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
	static public int GetFlexibleHeight_s(IntPtr l) {
		try {
			UnityEngine.RectTransform a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.LayoutUtility.GetFlexibleHeight(a1);
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
	static public int GetLayoutProperty_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.RectTransform a1;
				checkType(l,1,out a1);
				System.Func<UnityEngine.UI.ILayoutElement,System.Single> a2;
				checkDelegate(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=UnityEngine.UI.LayoutUtility.GetLayoutProperty(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.RectTransform a1;
				checkType(l,1,out a1);
				System.Func<UnityEngine.UI.ILayoutElement,System.Single> a2;
				checkDelegate(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.UI.ILayoutElement a4;
				var ret=UnityEngine.UI.LayoutUtility.GetLayoutProperty(a1,a2,a3,out a4);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a4);
				return 3;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetLayoutProperty to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.LayoutUtility");
		addMember(l,GetMinSize_s);
		addMember(l,GetPreferredSize_s);
		addMember(l,GetFlexibleSize_s);
		addMember(l,GetMinWidth_s);
		addMember(l,GetPreferredWidth_s);
		addMember(l,GetFlexibleWidth_s);
		addMember(l,GetMinHeight_s);
		addMember(l,GetPreferredHeight_s);
		addMember(l,GetFlexibleHeight_s);
		addMember(l,GetLayoutProperty_s);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.LayoutUtility));
	}
}
