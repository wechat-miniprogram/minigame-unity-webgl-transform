using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_EventSystems_PointerInputModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsPointerOverGameObject(IntPtr l) {
		try {
			UnityEngine.EventSystems.PointerInputModule self=(UnityEngine.EventSystems.PointerInputModule)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.IsPointerOverGameObject(a1);
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
	static public int get_kMouseLeftId(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.EventSystems.PointerInputModule.kMouseLeftId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_kMouseRightId(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.EventSystems.PointerInputModule.kMouseRightId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_kMouseMiddleId(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.EventSystems.PointerInputModule.kMouseMiddleId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_kFakeTouchesId(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.EventSystems.PointerInputModule.kFakeTouchesId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.PointerInputModule");
		addMember(l,IsPointerOverGameObject);
		addMember(l,"kMouseLeftId",get_kMouseLeftId,null,false);
		addMember(l,"kMouseRightId",get_kMouseRightId,null,false);
		addMember(l,"kMouseMiddleId",get_kMouseMiddleId,null,false);
		addMember(l,"kFakeTouchesId",get_kFakeTouchesId,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.PointerInputModule),typeof(UnityEngine.EventSystems.BaseInputModule));
	}
}
