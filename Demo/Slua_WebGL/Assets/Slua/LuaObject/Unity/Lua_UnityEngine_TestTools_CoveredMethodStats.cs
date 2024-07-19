using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TestTools_CoveredMethodStats : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredMethodStats o;
			o=new UnityEngine.TestTools.CoveredMethodStats();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_method(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredMethodStats self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.method);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_method(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredMethodStats self;
			checkValueType(l,1,out self);
			System.Reflection.MethodBase v;
			checkType(l,2,out v);
			self.method=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_totalSequencePoints(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredMethodStats self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.totalSequencePoints);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_totalSequencePoints(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredMethodStats self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.totalSequencePoints=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uncoveredSequencePoints(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredMethodStats self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.uncoveredSequencePoints);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uncoveredSequencePoints(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredMethodStats self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.uncoveredSequencePoints=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.TestTools.CoveredMethodStats");
		addMember(l,"method",get_method,set_method,true);
		addMember(l,"totalSequencePoints",get_totalSequencePoints,set_totalSequencePoints,true);
		addMember(l,"uncoveredSequencePoints",get_uncoveredSequencePoints,set_uncoveredSequencePoints,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.TestTools.CoveredMethodStats),typeof(System.ValueType));
	}
}
