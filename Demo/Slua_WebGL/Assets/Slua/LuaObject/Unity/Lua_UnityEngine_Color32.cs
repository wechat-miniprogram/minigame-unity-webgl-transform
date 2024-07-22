using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Color32 : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Color32 o;
			System.Byte a1;
			checkType(l,2,out a1);
			System.Byte a2;
			checkType(l,3,out a2);
			System.Byte a3;
			checkType(l,4,out a3);
			System.Byte a4;
			checkType(l,5,out a4);
			o=new UnityEngine.Color32(a1,a2,a3,a4);
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
	static public int Lerp_s(IntPtr l) {
		try {
			UnityEngine.Color32 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Color32 a2;
			checkValueType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=UnityEngine.Color32.Lerp(a1,a2,a3);
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
	static public int LerpUnclamped_s(IntPtr l) {
		try {
			UnityEngine.Color32 a1;
			checkValueType(l,1,out a1);
			UnityEngine.Color32 a2;
			checkValueType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=UnityEngine.Color32.LerpUnclamped(a1,a2,a3);
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
	static public int get_r(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.r);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_r(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			System.Byte v;
			checkType(l,2,out v);
			self.r=v;
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
	static public int get_g(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.g);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_g(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			System.Byte v;
			checkType(l,2,out v);
			self.g=v;
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
	static public int get_b(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_b(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			System.Byte v;
			checkType(l,2,out v);
			self.b=v;
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
	static public int get_a(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.a);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_a(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			System.Byte v;
			checkType(l,2,out v);
			self.a=v;
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
	static public int getItem(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			var ret = self[v];
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
	static public int setItem(IntPtr l) {
		try {
			UnityEngine.Color32 self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			System.Byte c;
			checkType(l,3,out c);
			self[v]=c;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Color32");
		addMember(l,Lerp_s);
		addMember(l,LerpUnclamped_s);
		addMember(l,getItem);
		addMember(l,setItem);
		addMember(l,"r",get_r,set_r,true);
		addMember(l,"g",get_g,set_g,true);
		addMember(l,"b",get_b,set_b,true);
		addMember(l,"a",get_a,set_a,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Color32),typeof(System.ValueType));
	}
}
