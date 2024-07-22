using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_TestTools_CoveredSequencePoint : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint o;
			o=new UnityEngine.TestTools.CoveredSequencePoint();
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
			UnityEngine.TestTools.CoveredSequencePoint self;
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
			UnityEngine.TestTools.CoveredSequencePoint self;
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
	static public int get_ilOffset(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.ilOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ilOffset(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.ilOffset=v;
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
	static public int get_hitCount(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.hitCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_hitCount(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.hitCount=v;
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
	static public int get_filename(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.filename);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_filename(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			System.String v;
			checkType(l,2,out v);
			self.filename=v;
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
	static public int get_line(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.line);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_line(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.line=v;
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
	static public int get_column(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.column);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_column(IntPtr l) {
		try {
			UnityEngine.TestTools.CoveredSequencePoint self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.column=v;
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
		getTypeTable(l,"UnityEngine.TestTools.CoveredSequencePoint");
		addMember(l,"method",get_method,set_method,true);
		addMember(l,"ilOffset",get_ilOffset,set_ilOffset,true);
		addMember(l,"hitCount",get_hitCount,set_hitCount,true);
		addMember(l,"filename",get_filename,set_filename,true);
		addMember(l,"line",get_line,set_line,true);
		addMember(l,"column",get_column,set_column,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.TestTools.CoveredSequencePoint),typeof(System.ValueType));
	}
}
