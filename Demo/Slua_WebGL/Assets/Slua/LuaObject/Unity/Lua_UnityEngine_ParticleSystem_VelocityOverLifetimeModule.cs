using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_VelocityOverLifetimeModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule o;
			o=new UnityEngine.ParticleSystem.VelocityOverLifetimeModule();
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
	static public int get_orbitalX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.orbitalX=v;
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
	static public int get_orbitalY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.orbitalY=v;
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
	static public int get_orbitalZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.orbitalZ=v;
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
	static public int get_orbitalXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalXMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.orbitalXMultiplier=v;
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
	static public int get_orbitalYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalYMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.orbitalYMultiplier=v;
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
	static public int get_orbitalZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalZMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.orbitalZMultiplier=v;
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
	static public int get_orbitalOffsetX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalOffsetX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalOffsetX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.orbitalOffsetX=v;
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
	static public int get_orbitalOffsetY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalOffsetY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalOffsetY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.orbitalOffsetY=v;
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
	static public int get_orbitalOffsetZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalOffsetZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalOffsetZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.orbitalOffsetZ=v;
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
	static public int get_orbitalOffsetXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalOffsetXMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalOffsetXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.orbitalOffsetXMultiplier=v;
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
	static public int get_orbitalOffsetYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalOffsetYMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalOffsetYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.orbitalOffsetYMultiplier=v;
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
	static public int get_orbitalOffsetZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.orbitalOffsetZMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_orbitalOffsetZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.orbitalOffsetZMultiplier=v;
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
	static public int get_radial(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.radial);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radial(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.radial=v;
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
	static public int get_radialMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.radialMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radialMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.radialMultiplier=v;
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
	static public int get_speedModifier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.speedModifier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_speedModifier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.speedModifier=v;
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
	static public int get_speedModifierMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.speedModifierMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_speedModifierMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.speedModifierMultiplier=v;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
			UnityEngine.ParticleSystem.VelocityOverLifetimeModule self;
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.VelocityOverLifetimeModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"x",get_x,set_x,true);
		addMember(l,"y",get_y,set_y,true);
		addMember(l,"z",get_z,set_z,true);
		addMember(l,"xMultiplier",get_xMultiplier,set_xMultiplier,true);
		addMember(l,"yMultiplier",get_yMultiplier,set_yMultiplier,true);
		addMember(l,"zMultiplier",get_zMultiplier,set_zMultiplier,true);
		addMember(l,"orbitalX",get_orbitalX,set_orbitalX,true);
		addMember(l,"orbitalY",get_orbitalY,set_orbitalY,true);
		addMember(l,"orbitalZ",get_orbitalZ,set_orbitalZ,true);
		addMember(l,"orbitalXMultiplier",get_orbitalXMultiplier,set_orbitalXMultiplier,true);
		addMember(l,"orbitalYMultiplier",get_orbitalYMultiplier,set_orbitalYMultiplier,true);
		addMember(l,"orbitalZMultiplier",get_orbitalZMultiplier,set_orbitalZMultiplier,true);
		addMember(l,"orbitalOffsetX",get_orbitalOffsetX,set_orbitalOffsetX,true);
		addMember(l,"orbitalOffsetY",get_orbitalOffsetY,set_orbitalOffsetY,true);
		addMember(l,"orbitalOffsetZ",get_orbitalOffsetZ,set_orbitalOffsetZ,true);
		addMember(l,"orbitalOffsetXMultiplier",get_orbitalOffsetXMultiplier,set_orbitalOffsetXMultiplier,true);
		addMember(l,"orbitalOffsetYMultiplier",get_orbitalOffsetYMultiplier,set_orbitalOffsetYMultiplier,true);
		addMember(l,"orbitalOffsetZMultiplier",get_orbitalOffsetZMultiplier,set_orbitalOffsetZMultiplier,true);
		addMember(l,"radial",get_radial,set_radial,true);
		addMember(l,"radialMultiplier",get_radialMultiplier,set_radialMultiplier,true);
		addMember(l,"speedModifier",get_speedModifier,set_speedModifier,true);
		addMember(l,"speedModifierMultiplier",get_speedModifierMultiplier,set_speedModifierMultiplier,true);
		addMember(l,"space",get_space,set_space,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.VelocityOverLifetimeModule),typeof(System.ValueType));
	}
}
