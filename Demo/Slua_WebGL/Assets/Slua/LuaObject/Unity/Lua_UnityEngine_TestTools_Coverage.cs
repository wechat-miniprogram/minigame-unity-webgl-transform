using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TestTools_Coverage : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSequencePointsFor_s(IntPtr l) {
		try {
			System.Reflection.MethodBase a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.TestTools.Coverage.GetSequencePointsFor(a1);
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
	static public int GetStatsFor_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(System.Reflection.MethodBase))){
				System.Reflection.MethodBase a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.TestTools.Coverage.GetStatsFor(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Reflection.MethodBase[]))){
				System.Reflection.MethodBase[] a1;
				checkArray(l,1,out a1);
				var ret=UnityEngine.TestTools.Coverage.GetStatsFor(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Type))){
				System.Type a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.TestTools.Coverage.GetStatsFor(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetStatsFor to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetStatsForAllCoveredMethods_s(IntPtr l) {
		try {
			var ret=UnityEngine.TestTools.Coverage.GetStatsForAllCoveredMethods();
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
	static public int ResetFor_s(IntPtr l) {
		try {
			System.Reflection.MethodBase a1;
			checkType(l,1,out a1);
			UnityEngine.TestTools.Coverage.ResetFor(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ResetAll_s(IntPtr l) {
		try {
			UnityEngine.TestTools.Coverage.ResetAll();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enabled(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.TestTools.Coverage.enabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enabled(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.TestTools.Coverage.enabled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.TestTools.Coverage");
		addMember(l,GetSequencePointsFor_s);
		addMember(l,GetStatsFor_s);
		addMember(l,GetStatsForAllCoveredMethods_s);
		addMember(l,ResetFor_s);
		addMember(l,ResetAll_s);
		addMember(l,"enabled",get_enabled,set_enabled,false);
		createTypeMetatable(l,null, typeof(UnityEngine.TestTools.Coverage));
	}
}
