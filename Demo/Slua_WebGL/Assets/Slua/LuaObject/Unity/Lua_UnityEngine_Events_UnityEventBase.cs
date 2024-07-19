using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Events_UnityEventBase : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetPersistentEventCount(IntPtr l) {
		try {
			UnityEngine.Events.UnityEventBase self=(UnityEngine.Events.UnityEventBase)checkSelf(l);
			var ret=self.GetPersistentEventCount();
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
	static public int GetPersistentTarget(IntPtr l) {
		try {
			UnityEngine.Events.UnityEventBase self=(UnityEngine.Events.UnityEventBase)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPersistentTarget(a1);
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
	static public int GetPersistentMethodName(IntPtr l) {
		try {
			UnityEngine.Events.UnityEventBase self=(UnityEngine.Events.UnityEventBase)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPersistentMethodName(a1);
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
	static public int SetPersistentListenerState(IntPtr l) {
		try {
			UnityEngine.Events.UnityEventBase self=(UnityEngine.Events.UnityEventBase)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Events.UnityEventCallState a2;
			a2 = (UnityEngine.Events.UnityEventCallState)LuaDLL.luaL_checkinteger(l, 3);
			self.SetPersistentListenerState(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetPersistentListenerState(IntPtr l) {
		try {
			UnityEngine.Events.UnityEventBase self=(UnityEngine.Events.UnityEventBase)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPersistentListenerState(a1);
			pushValue(l,true);
			pushEnum(l,(int)ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveAllListeners(IntPtr l) {
		try {
			UnityEngine.Events.UnityEventBase self=(UnityEngine.Events.UnityEventBase)checkSelf(l);
			self.RemoveAllListeners();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetValidMethodInfo_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(System.Object),typeof(string),typeof(System.Type[]))){
				System.Object a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.Type[] a3;
				checkArray(l,3,out a3);
				var ret=UnityEngine.Events.UnityEventBase.GetValidMethodInfo(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Type),typeof(string),typeof(System.Type[]))){
				System.Type a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				System.Type[] a3;
				checkArray(l,3,out a3);
				var ret=UnityEngine.Events.UnityEventBase.GetValidMethodInfo(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetValidMethodInfo to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Events.UnityEventBase");
		addMember(l,GetPersistentEventCount);
		addMember(l,GetPersistentTarget);
		addMember(l,GetPersistentMethodName);
		addMember(l,SetPersistentListenerState);
		addMember(l,GetPersistentListenerState);
		addMember(l,RemoveAllListeners);
		addMember(l,GetValidMethodInfo_s);
		createTypeMetatable(l,null, typeof(UnityEngine.Events.UnityEventBase));
	}
}
