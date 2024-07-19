using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_TrailModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule o;
			o=new UnityEngine.ParticleSystem.TrailModule();
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
			UnityEngine.ParticleSystem.TrailModule self;
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
			UnityEngine.ParticleSystem.TrailModule self;
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
	static public int get_mode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
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
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemTrailMode v;
			v = (UnityEngine.ParticleSystemTrailMode)LuaDLL.luaL_checkinteger(l, 2);
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
	static public int get_ratio(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
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
			UnityEngine.ParticleSystem.TrailModule self;
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
	static public int get_lifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lifetime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.lifetime=v;
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
	static public int get_lifetimeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lifetimeMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lifetimeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.lifetimeMultiplier=v;
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
	static public int get_minVertexDistance(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.minVertexDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minVertexDistance(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.minVertexDistance=v;
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
	static public int get_textureMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.textureMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_textureMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemTrailTextureMode v;
			v = (UnityEngine.ParticleSystemTrailTextureMode)LuaDLL.luaL_checkinteger(l, 2);
			self.textureMode=v;
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
	static public int get_worldSpace(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.worldSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_worldSpace(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.worldSpace=v;
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
	static public int get_dieWithParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.dieWithParticles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dieWithParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.dieWithParticles=v;
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
	static public int get_sizeAffectsWidth(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sizeAffectsWidth);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sizeAffectsWidth(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.sizeAffectsWidth=v;
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
	static public int get_sizeAffectsLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sizeAffectsLifetime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sizeAffectsLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.sizeAffectsLifetime=v;
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
	static public int get_inheritParticleColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.inheritParticleColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_inheritParticleColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.inheritParticleColor=v;
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
	static public int get_colorOverLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colorOverLifetime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colorOverLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxGradient v;
			checkValueType(l,2,out v);
			self.colorOverLifetime=v;
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
	static public int get_widthOverTrail(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.widthOverTrail);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_widthOverTrail(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.widthOverTrail=v;
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
	static public int get_widthOverTrailMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.widthOverTrailMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_widthOverTrailMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.widthOverTrailMultiplier=v;
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
	static public int get_colorOverTrail(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colorOverTrail);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colorOverTrail(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxGradient v;
			checkValueType(l,2,out v);
			self.colorOverTrail=v;
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
	static public int get_generateLightingData(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.generateLightingData);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_generateLightingData(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.generateLightingData=v;
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
	static public int get_ribbonCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.ribbonCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ribbonCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.ribbonCount=v;
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
	static public int get_shadowBias(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.shadowBias);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowBias(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.shadowBias=v;
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
	static public int get_splitSubEmitterRibbons(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.splitSubEmitterRibbons);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_splitSubEmitterRibbons(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.splitSubEmitterRibbons=v;
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
	static public int get_attachRibbonsToTransform(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.attachRibbonsToTransform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_attachRibbonsToTransform(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.TrailModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.attachRibbonsToTransform=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.TrailModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"ratio",get_ratio,set_ratio,true);
		addMember(l,"lifetime",get_lifetime,set_lifetime,true);
		addMember(l,"lifetimeMultiplier",get_lifetimeMultiplier,set_lifetimeMultiplier,true);
		addMember(l,"minVertexDistance",get_minVertexDistance,set_minVertexDistance,true);
		addMember(l,"textureMode",get_textureMode,set_textureMode,true);
		addMember(l,"worldSpace",get_worldSpace,set_worldSpace,true);
		addMember(l,"dieWithParticles",get_dieWithParticles,set_dieWithParticles,true);
		addMember(l,"sizeAffectsWidth",get_sizeAffectsWidth,set_sizeAffectsWidth,true);
		addMember(l,"sizeAffectsLifetime",get_sizeAffectsLifetime,set_sizeAffectsLifetime,true);
		addMember(l,"inheritParticleColor",get_inheritParticleColor,set_inheritParticleColor,true);
		addMember(l,"colorOverLifetime",get_colorOverLifetime,set_colorOverLifetime,true);
		addMember(l,"widthOverTrail",get_widthOverTrail,set_widthOverTrail,true);
		addMember(l,"widthOverTrailMultiplier",get_widthOverTrailMultiplier,set_widthOverTrailMultiplier,true);
		addMember(l,"colorOverTrail",get_colorOverTrail,set_colorOverTrail,true);
		addMember(l,"generateLightingData",get_generateLightingData,set_generateLightingData,true);
		addMember(l,"ribbonCount",get_ribbonCount,set_ribbonCount,true);
		addMember(l,"shadowBias",get_shadowBias,set_shadowBias,true);
		addMember(l,"splitSubEmitterRibbons",get_splitSubEmitterRibbons,set_splitSubEmitterRibbons,true);
		addMember(l,"attachRibbonsToTransform",get_attachRibbonsToTransform,set_attachRibbonsToTransform,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.TrailModule),typeof(System.ValueType));
	}
}
