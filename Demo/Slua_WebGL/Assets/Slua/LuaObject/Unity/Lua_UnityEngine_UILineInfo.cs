using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UILineInfo : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UILineInfo o;
			o=new UnityEngine.UILineInfo();
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
	static public int get_startCharIdx(IntPtr l) {
		try {
			UnityEngine.UILineInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startCharIdx);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startCharIdx(IntPtr l) {
		try {
			UnityEngine.UILineInfo self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.startCharIdx=v;
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
	static public int get_height(IntPtr l) {
		try {
			UnityEngine.UILineInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.height);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_height(IntPtr l) {
		try {
			UnityEngine.UILineInfo self;
			checkValueType(l,1,out self);
			System.Int32 v;
			checkType(l,2,out v);
			self.height=v;
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
	static public int get_topY(IntPtr l) {
		try {
			UnityEngine.UILineInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.topY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_topY(IntPtr l) {
		try {
			UnityEngine.UILineInfo self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.topY=v;
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
	static public int get_leading(IntPtr l) {
		try {
			UnityEngine.UILineInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.leading);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_leading(IntPtr l) {
		try {
			UnityEngine.UILineInfo self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.leading=v;
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
		getTypeTable(l,"UnityEngine.UILineInfo");
		addMember(l,"startCharIdx",get_startCharIdx,set_startCharIdx,true);
		addMember(l,"height",get_height,set_height,true);
		addMember(l,"topY",get_topY,set_topY,true);
		addMember(l,"leading",get_leading,set_leading,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UILineInfo),typeof(System.ValueType));
	}
}
