using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ArticulationDrive : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive o;
			o=new UnityEngine.ArticulationDrive();
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
	static public int get_lowerLimit(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lowerLimit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lowerLimit(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.lowerLimit=v;
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
	static public int get_upperLimit(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.upperLimit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_upperLimit(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.upperLimit=v;
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
	static public int get_stiffness(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.stiffness);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_stiffness(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.stiffness=v;
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
	static public int get_damping(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.damping);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_damping(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.damping=v;
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
	static public int get_forceLimit(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.forceLimit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_forceLimit(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.forceLimit=v;
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
	static public int get_target(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.target);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_target(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.target=v;
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
	static public int get_targetVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.targetVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_targetVelocity(IntPtr l) {
		try {
			UnityEngine.ArticulationDrive self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.targetVelocity=v;
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
		getTypeTable(l,"UnityEngine.ArticulationDrive");
		addMember(l,"lowerLimit",get_lowerLimit,set_lowerLimit,true);
		addMember(l,"upperLimit",get_upperLimit,set_upperLimit,true);
		addMember(l,"stiffness",get_stiffness,set_stiffness,true);
		addMember(l,"damping",get_damping,set_damping,true);
		addMember(l,"forceLimit",get_forceLimit,set_forceLimit,true);
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"targetVelocity",get_targetVelocity,set_targetVelocity,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ArticulationDrive),typeof(System.ValueType));
	}
}
