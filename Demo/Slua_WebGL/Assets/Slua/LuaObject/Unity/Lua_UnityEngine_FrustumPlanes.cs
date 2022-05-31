using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_FrustumPlanes : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes o;
			o=new UnityEngine.FrustumPlanes();
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
	static public int get_left(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.left);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_left(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.left=v;
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
	static public int get_right(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.right);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_right(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.right=v;
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
	static public int get_bottom(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bottom);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bottom(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.bottom=v;
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
	static public int get_top(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.top);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_top(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.top=v;
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
	static public int get_zNear(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.zNear);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_zNear(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.zNear=v;
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
	static public int get_zFar(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.zFar);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_zFar(IntPtr l) {
		try {
			UnityEngine.FrustumPlanes self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.zFar=v;
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
		getTypeTable(l,"UnityEngine.FrustumPlanes");
		addMember(l,"left",get_left,set_left,true);
		addMember(l,"right",get_right,set_right,true);
		addMember(l,"bottom",get_bottom,set_bottom,true);
		addMember(l,"top",get_top,set_top,true);
		addMember(l,"zNear",get_zNear,set_zNear,true);
		addMember(l,"zFar",get_zFar,set_zFar,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.FrustumPlanes),typeof(System.ValueType));
	}
}
