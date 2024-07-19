using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RefreshRate : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.RefreshRate o;
			o=new UnityEngine.RefreshRate();
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
	static public int get_numerator(IntPtr l) {
		try {
			UnityEngine.RefreshRate self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.numerator);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_numerator(IntPtr l) {
		try {
			UnityEngine.RefreshRate self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.numerator=v;
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
	static public int get_denominator(IntPtr l) {
		try {
			UnityEngine.RefreshRate self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.denominator);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_denominator(IntPtr l) {
		try {
			UnityEngine.RefreshRate self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.denominator=v;
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
	static public int get_value(IntPtr l) {
		try {
			UnityEngine.RefreshRate self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.value);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.RefreshRate");
		addMember(l,"numerator",get_numerator,set_numerator,true);
		addMember(l,"denominator",get_denominator,set_denominator,true);
		addMember(l,"value",get_value,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.RefreshRate),typeof(System.ValueType));
	}
}
