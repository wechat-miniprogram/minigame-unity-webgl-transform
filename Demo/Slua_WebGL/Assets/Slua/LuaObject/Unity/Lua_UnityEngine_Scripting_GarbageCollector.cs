using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Scripting_GarbageCollector : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CollectIncremental_s(IntPtr l) {
		try {
			System.UInt64 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Scripting.GarbageCollector.CollectIncremental(a1);
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
	static public int get_GCMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Scripting.GarbageCollector.GCMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_GCMode(IntPtr l) {
		try {
			UnityEngine.Scripting.GarbageCollector.Mode v;
			v = (UnityEngine.Scripting.GarbageCollector.Mode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Scripting.GarbageCollector.GCMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isIncremental(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Scripting.GarbageCollector.isIncremental);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_incrementalTimeSliceNanoseconds(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Scripting.GarbageCollector.incrementalTimeSliceNanoseconds);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_incrementalTimeSliceNanoseconds(IntPtr l) {
		try {
			System.UInt64 v;
			checkType(l,2,out v);
			UnityEngine.Scripting.GarbageCollector.incrementalTimeSliceNanoseconds=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Scripting.GarbageCollector");
		addMember(l,CollectIncremental_s);
		addMember(l,"GCMode",get_GCMode,set_GCMode,false);
		addMember(l,"isIncremental",get_isIncremental,null,false);
		addMember(l,"incrementalTimeSliceNanoseconds",get_incrementalTimeSliceNanoseconds,set_incrementalTimeSliceNanoseconds,false);
		createTypeMetatable(l,null, typeof(UnityEngine.Scripting.GarbageCollector));
	}
}
