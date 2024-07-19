using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UICharInfo : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.UICharInfo o;
			o=new UnityEngine.UICharInfo();
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
	static public int get_cursorPos(IntPtr l) {
		try {
			UnityEngine.UICharInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cursorPos);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cursorPos(IntPtr l) {
		try {
			UnityEngine.UICharInfo self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.cursorPos=v;
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
	static public int get_charWidth(IntPtr l) {
		try {
			UnityEngine.UICharInfo self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.charWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_charWidth(IntPtr l) {
		try {
			UnityEngine.UICharInfo self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.charWidth=v;
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
		getTypeTable(l,"UnityEngine.UICharInfo");
		addMember(l,"cursorPos",get_cursorPos,set_cursorPos,true);
		addMember(l,"charWidth",get_charWidth,set_charWidth,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.UICharInfo),typeof(System.ValueType));
	}
}
