using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_ForceOverLifetimeModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule o;
			o=new UnityEngine.ParticleSystem.ForceOverLifetimeModule();
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
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.enabled);
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
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
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
	static public int get_x(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.x);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_x(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.x=v;
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
	static public int get_y(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.y);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_y(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.y=v;
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
	static public int get_z(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.z);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_z(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.z=v;
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
	static public int get_xMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.xMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_xMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.xMultiplier=v;
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
	static public int get_yMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.yMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_yMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.yMultiplier=v;
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
	static public int get_zMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.zMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_zMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.zMultiplier=v;
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
	static public int get_space(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.space);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_space(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemSimulationSpace v;
			v = (UnityEngine.ParticleSystemSimulationSpace)LuaDLL.luaL_checkinteger(l, 2);
			self.space=v;
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
	static public int get_randomized(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.randomized);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_randomized(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.ForceOverLifetimeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.randomized=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.ForceOverLifetimeModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"x",get_x,set_x,true);
		addMember(l,"y",get_y,set_y,true);
		addMember(l,"z",get_z,set_z,true);
		addMember(l,"xMultiplier",get_xMultiplier,set_xMultiplier,true);
		addMember(l,"yMultiplier",get_yMultiplier,set_yMultiplier,true);
		addMember(l,"zMultiplier",get_zMultiplier,set_zMultiplier,true);
		addMember(l,"space",get_space,set_space,true);
		addMember(l,"randomized",get_randomized,set_randomized,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.ForceOverLifetimeModule),typeof(System.ValueType));
	}
}
