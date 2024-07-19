using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_LifetimeByEmitterSpeedModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule o;
			o=new UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule();
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
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule self;
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
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule self;
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
	static public int get_curve(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.curve);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_curve(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.curve=v;
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
	static public int get_curveMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.curveMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_curveMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.curveMultiplier=v;
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
	static public int get_range(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.range);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_range(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.range=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"curve",get_curve,set_curve,true);
		addMember(l,"curveMultiplier",get_curveMultiplier,set_curveMultiplier,true);
		addMember(l,"range",get_range,set_range,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule),typeof(System.ValueType));
	}
}
