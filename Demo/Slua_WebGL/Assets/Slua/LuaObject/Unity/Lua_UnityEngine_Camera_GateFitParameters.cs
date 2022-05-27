using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Camera_GateFitParameters : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Camera.GateFitParameters o;
			UnityEngine.Camera.GateFitMode a1;
			a1 = (UnityEngine.Camera.GateFitMode)LuaDLL.luaL_checkinteger(l, 2);
			System.Single a2;
			checkType(l,3,out a2);
			o=new UnityEngine.Camera.GateFitParameters(a1,a2);
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
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.Camera.GateFitParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.mode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mode(IntPtr l) {
		try {
			UnityEngine.Camera.GateFitParameters self;
			checkValueType(l,1,out self);
			UnityEngine.Camera.GateFitMode v;
			v = (UnityEngine.Camera.GateFitMode)LuaDLL.luaL_checkinteger(l, 2);
			self.mode=v;
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
	static public int get_aspect(IntPtr l) {
		try {
			UnityEngine.Camera.GateFitParameters self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.aspect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_aspect(IntPtr l) {
		try {
			UnityEngine.Camera.GateFitParameters self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.aspect=v;
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
		getTypeTable(l,"UnityEngine.Camera.GateFitParameters");
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"aspect",get_aspect,set_aspect,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Camera.GateFitParameters),typeof(System.ValueType));
	}
}
