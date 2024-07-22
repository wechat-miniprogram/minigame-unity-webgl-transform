using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_CanvasUpdateRegistry : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RegisterCanvasElementForLayoutRebuild_s(IntPtr l) {
		try {
			UnityEngine.UI.ICanvasElement a1;
			checkType(l,1,out a1);
			UnityEngine.UI.CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int TryRegisterCanvasElementForLayoutRebuild_s(IntPtr l) {
		try {
			UnityEngine.UI.ICanvasElement a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.CanvasUpdateRegistry.TryRegisterCanvasElementForLayoutRebuild(a1);
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
	static public int RegisterCanvasElementForGraphicRebuild_s(IntPtr l) {
		try {
			UnityEngine.UI.ICanvasElement a1;
			checkType(l,1,out a1);
			UnityEngine.UI.CanvasUpdateRegistry.RegisterCanvasElementForGraphicRebuild(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int TryRegisterCanvasElementForGraphicRebuild_s(IntPtr l) {
		try {
			UnityEngine.UI.ICanvasElement a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.UI.CanvasUpdateRegistry.TryRegisterCanvasElementForGraphicRebuild(a1);
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
	static public int UnRegisterCanvasElementForRebuild_s(IntPtr l) {
		try {
			UnityEngine.UI.ICanvasElement a1;
			checkType(l,1,out a1);
			UnityEngine.UI.CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsRebuildingLayout_s(IntPtr l) {
		try {
			var ret=UnityEngine.UI.CanvasUpdateRegistry.IsRebuildingLayout();
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
	static public int IsRebuildingGraphics_s(IntPtr l) {
		try {
			var ret=UnityEngine.UI.CanvasUpdateRegistry.IsRebuildingGraphics();
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
	static public int get_instance(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.UI.CanvasUpdateRegistry.instance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.CanvasUpdateRegistry");
		addMember(l,RegisterCanvasElementForLayoutRebuild_s);
		addMember(l,TryRegisterCanvasElementForLayoutRebuild_s);
		addMember(l,RegisterCanvasElementForGraphicRebuild_s);
		addMember(l,TryRegisterCanvasElementForGraphicRebuild_s);
		addMember(l,UnRegisterCanvasElementForRebuild_s);
		addMember(l,IsRebuildingLayout_s);
		addMember(l,IsRebuildingGraphics_s);
		addMember(l,"instance",get_instance,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.CanvasUpdateRegistry));
	}
}
