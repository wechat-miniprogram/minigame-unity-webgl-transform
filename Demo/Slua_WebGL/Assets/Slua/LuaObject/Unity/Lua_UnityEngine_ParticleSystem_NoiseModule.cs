using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_NoiseModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule o;
			o=new UnityEngine.ParticleSystem.NoiseModule();
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
			UnityEngine.ParticleSystem.NoiseModule self;
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
			UnityEngine.ParticleSystem.NoiseModule self;
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
	static public int get_separateAxes(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.separateAxes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_separateAxes(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.separateAxes=v;
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
	static public int get_strength(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.strength);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_strength(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.strength=v;
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
	static public int get_strengthMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.strengthMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_strengthMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.strengthMultiplier=v;
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
	static public int get_strengthX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.strengthX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_strengthX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.strengthX=v;
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
	static public int get_strengthXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.strengthXMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_strengthXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.strengthXMultiplier=v;
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
	static public int get_strengthY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.strengthY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_strengthY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.strengthY=v;
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
	static public int get_strengthYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.strengthYMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_strengthYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.strengthYMultiplier=v;
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
	static public int get_strengthZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.strengthZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_strengthZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.strengthZ=v;
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
	static public int get_strengthZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.strengthZMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_strengthZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.strengthZMultiplier=v;
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
	static public int get_frequency(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.frequency);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_frequency(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.frequency=v;
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
			UnityEngine.ParticleSystem.NoiseModule self;
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
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			bool v;
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
	static public int get_octaveCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.octaveCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_octaveCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.octaveCount=v;
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
	static public int get_octaveMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.octaveMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_octaveMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.octaveMultiplier=v;
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
	static public int get_octaveScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.octaveScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_octaveScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.octaveScale=v;
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
	static public int get_quality(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.quality);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_quality(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemNoiseQuality v;
			v = (UnityEngine.ParticleSystemNoiseQuality)LuaDLL.luaL_checkinteger(l, 2);
			self.quality=v;
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
	static public int get_scrollSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.scrollSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_scrollSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.scrollSpeed=v;
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
	static public int get_scrollSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.scrollSpeedMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_scrollSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.scrollSpeedMultiplier=v;
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
	static public int get_remapEnabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remapEnabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remapEnabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.remapEnabled=v;
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
	static public int get_remap(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remap);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remap(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.remap=v;
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
	static public int get_remapMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remapMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remapMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.remapMultiplier=v;
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
	static public int get_remapX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remapX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remapX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.remapX=v;
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
	static public int get_remapXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remapXMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remapXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.remapXMultiplier=v;
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
	static public int get_remapY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remapY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remapY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.remapY=v;
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
	static public int get_remapYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remapYMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remapYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.remapYMultiplier=v;
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
	static public int get_remapZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remapZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remapZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.remapZ=v;
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
	static public int get_remapZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.remapZMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_remapZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.remapZMultiplier=v;
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
	static public int get_positionAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.positionAmount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_positionAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.positionAmount=v;
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
	static public int get_rotationAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rotationAmount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.rotationAmount=v;
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
	static public int get_sizeAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sizeAmount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sizeAmount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.NoiseModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.sizeAmount=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.NoiseModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"separateAxes",get_separateAxes,set_separateAxes,true);
		addMember(l,"strength",get_strength,set_strength,true);
		addMember(l,"strengthMultiplier",get_strengthMultiplier,set_strengthMultiplier,true);
		addMember(l,"strengthX",get_strengthX,set_strengthX,true);
		addMember(l,"strengthXMultiplier",get_strengthXMultiplier,set_strengthXMultiplier,true);
		addMember(l,"strengthY",get_strengthY,set_strengthY,true);
		addMember(l,"strengthYMultiplier",get_strengthYMultiplier,set_strengthYMultiplier,true);
		addMember(l,"strengthZ",get_strengthZ,set_strengthZ,true);
		addMember(l,"strengthZMultiplier",get_strengthZMultiplier,set_strengthZMultiplier,true);
		addMember(l,"frequency",get_frequency,set_frequency,true);
		addMember(l,"damping",get_damping,set_damping,true);
		addMember(l,"octaveCount",get_octaveCount,set_octaveCount,true);
		addMember(l,"octaveMultiplier",get_octaveMultiplier,set_octaveMultiplier,true);
		addMember(l,"octaveScale",get_octaveScale,set_octaveScale,true);
		addMember(l,"quality",get_quality,set_quality,true);
		addMember(l,"scrollSpeed",get_scrollSpeed,set_scrollSpeed,true);
		addMember(l,"scrollSpeedMultiplier",get_scrollSpeedMultiplier,set_scrollSpeedMultiplier,true);
		addMember(l,"remapEnabled",get_remapEnabled,set_remapEnabled,true);
		addMember(l,"remap",get_remap,set_remap,true);
		addMember(l,"remapMultiplier",get_remapMultiplier,set_remapMultiplier,true);
		addMember(l,"remapX",get_remapX,set_remapX,true);
		addMember(l,"remapXMultiplier",get_remapXMultiplier,set_remapXMultiplier,true);
		addMember(l,"remapY",get_remapY,set_remapY,true);
		addMember(l,"remapYMultiplier",get_remapYMultiplier,set_remapYMultiplier,true);
		addMember(l,"remapZ",get_remapZ,set_remapZ,true);
		addMember(l,"remapZMultiplier",get_remapZMultiplier,set_remapZMultiplier,true);
		addMember(l,"positionAmount",get_positionAmount,set_positionAmount,true);
		addMember(l,"rotationAmount",get_rotationAmount,set_rotationAmount,true);
		addMember(l,"sizeAmount",get_sizeAmount,set_sizeAmount,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.NoiseModule),typeof(System.ValueType));
	}
}
