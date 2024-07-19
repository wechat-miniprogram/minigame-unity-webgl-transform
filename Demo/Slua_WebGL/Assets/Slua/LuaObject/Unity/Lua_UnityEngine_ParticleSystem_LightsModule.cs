using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_LightsModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule o;
			o=new UnityEngine.ParticleSystem.LightsModule();
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
			UnityEngine.ParticleSystem.LightsModule self;
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
			UnityEngine.ParticleSystem.LightsModule self;
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
	static public int get_ratio(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.ratio);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ratio(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.ratio=v;
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
	static public int get_useRandomDistribution(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useRandomDistribution);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useRandomDistribution(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useRandomDistribution=v;
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
	static public int get_light(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.light);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_light(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			UnityEngine.Light v;
			checkType(l,2,out v);
			self.light=v;
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
	static public int get_useParticleColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useParticleColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useParticleColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useParticleColor=v;
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
	static public int get_sizeAffectsRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sizeAffectsRange);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sizeAffectsRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.sizeAffectsRange=v;
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
	static public int get_alphaAffectsIntensity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.alphaAffectsIntensity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alphaAffectsIntensity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.alphaAffectsIntensity=v;
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
			UnityEngine.ParticleSystem.LightsModule self;
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
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.range=v;
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
	static public int get_rangeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rangeMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rangeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.rangeMultiplier=v;
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
	static public int get_intensity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.intensity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_intensity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.intensity=v;
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
	static public int get_intensityMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.intensityMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_intensityMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.intensityMultiplier=v;
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
	static public int get_maxLights(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maxLights);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxLights(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LightsModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.maxLights=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.LightsModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"ratio",get_ratio,set_ratio,true);
		addMember(l,"useRandomDistribution",get_useRandomDistribution,set_useRandomDistribution,true);
		addMember(l,"light",get_light,set_light,true);
		addMember(l,"useParticleColor",get_useParticleColor,set_useParticleColor,true);
		addMember(l,"sizeAffectsRange",get_sizeAffectsRange,set_sizeAffectsRange,true);
		addMember(l,"alphaAffectsIntensity",get_alphaAffectsIntensity,set_alphaAffectsIntensity,true);
		addMember(l,"range",get_range,set_range,true);
		addMember(l,"rangeMultiplier",get_rangeMultiplier,set_rangeMultiplier,true);
		addMember(l,"intensity",get_intensity,set_intensity,true);
		addMember(l,"intensityMultiplier",get_intensityMultiplier,set_intensityMultiplier,true);
		addMember(l,"maxLights",get_maxLights,set_maxLights,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.LightsModule),typeof(System.ValueType));
	}
}
