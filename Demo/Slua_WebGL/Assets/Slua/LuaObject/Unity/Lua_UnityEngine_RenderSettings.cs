using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_RenderSettings : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fog(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.fog);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fog(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.fog=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fogStartDistance(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.fogStartDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fogStartDistance(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.fogStartDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fogEndDistance(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.fogEndDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fogEndDistance(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.fogEndDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fogMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.RenderSettings.fogMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fogMode(IntPtr l) {
		try {
			UnityEngine.FogMode v;
			v = (UnityEngine.FogMode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.RenderSettings.fogMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fogColor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.fogColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fogColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.fogColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fogDensity(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.fogDensity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fogDensity(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.fogDensity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ambientMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.RenderSettings.ambientMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ambientMode(IntPtr l) {
		try {
			UnityEngine.Rendering.AmbientMode v;
			v = (UnityEngine.Rendering.AmbientMode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.RenderSettings.ambientMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ambientSkyColor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.ambientSkyColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ambientSkyColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.ambientSkyColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ambientEquatorColor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.ambientEquatorColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ambientEquatorColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.ambientEquatorColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ambientGroundColor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.ambientGroundColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ambientGroundColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.ambientGroundColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ambientIntensity(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.ambientIntensity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ambientIntensity(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.ambientIntensity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ambientLight(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.ambientLight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ambientLight(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.ambientLight=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_subtractiveShadowColor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.subtractiveShadowColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_subtractiveShadowColor(IntPtr l) {
		try {
			UnityEngine.Color v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.subtractiveShadowColor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_skybox(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.skybox);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_skybox(IntPtr l) {
		try {
			UnityEngine.Material v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.skybox=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sun(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.sun);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sun(IntPtr l) {
		try {
			UnityEngine.Light v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.sun=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_ambientProbe(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.ambientProbe);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ambientProbe(IntPtr l) {
		try {
			UnityEngine.Rendering.SphericalHarmonicsL2 v;
			checkValueType(l,2,out v);
			UnityEngine.RenderSettings.ambientProbe=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_customReflection(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.customReflection);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_customReflection(IntPtr l) {
		try {
			UnityEngine.Texture v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.customReflection=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reflectionIntensity(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.reflectionIntensity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reflectionIntensity(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.reflectionIntensity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_reflectionBounces(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.reflectionBounces);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_reflectionBounces(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.reflectionBounces=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultReflectionMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.RenderSettings.defaultReflectionMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultReflectionMode(IntPtr l) {
		try {
			UnityEngine.Rendering.DefaultReflectionMode v;
			v = (UnityEngine.Rendering.DefaultReflectionMode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.RenderSettings.defaultReflectionMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultReflectionResolution(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.defaultReflectionResolution);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultReflectionResolution(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.defaultReflectionResolution=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_haloStrength(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.haloStrength);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_haloStrength(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.haloStrength=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flareStrength(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.flareStrength);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_flareStrength(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.flareStrength=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flareFadeSpeed(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.RenderSettings.flareFadeSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_flareFadeSpeed(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.RenderSettings.flareFadeSpeed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.RenderSettings");
		addMember(l,"fog",get_fog,set_fog,false);
		addMember(l,"fogStartDistance",get_fogStartDistance,set_fogStartDistance,false);
		addMember(l,"fogEndDistance",get_fogEndDistance,set_fogEndDistance,false);
		addMember(l,"fogMode",get_fogMode,set_fogMode,false);
		addMember(l,"fogColor",get_fogColor,set_fogColor,false);
		addMember(l,"fogDensity",get_fogDensity,SLua.RenderSettingsEx.set_fogDensity,false);
		addMember(l,"ambientMode",get_ambientMode,set_ambientMode,false);
		addMember(l,"ambientSkyColor",get_ambientSkyColor,set_ambientSkyColor,false);
		addMember(l,"ambientEquatorColor",get_ambientEquatorColor,set_ambientEquatorColor,false);
		addMember(l,"ambientGroundColor",get_ambientGroundColor,set_ambientGroundColor,false);
		addMember(l,"ambientIntensity",get_ambientIntensity,set_ambientIntensity,false);
		addMember(l,"ambientLight",get_ambientLight,set_ambientLight,false);
		addMember(l,"subtractiveShadowColor",get_subtractiveShadowColor,set_subtractiveShadowColor,false);
		addMember(l,"skybox",get_skybox,set_skybox,false);
		addMember(l,"sun",get_sun,set_sun,false);
		addMember(l,"ambientProbe",get_ambientProbe,set_ambientProbe,false);
		addMember(l,"customReflection",get_customReflection,set_customReflection,false);
		addMember(l,"reflectionIntensity",get_reflectionIntensity,set_reflectionIntensity,false);
		addMember(l,"reflectionBounces",get_reflectionBounces,set_reflectionBounces,false);
		addMember(l,"defaultReflectionMode",get_defaultReflectionMode,set_defaultReflectionMode,false);
		addMember(l,"defaultReflectionResolution",get_defaultReflectionResolution,set_defaultReflectionResolution,false);
		addMember(l,"haloStrength",get_haloStrength,set_haloStrength,false);
		addMember(l,"flareStrength",get_flareStrength,set_flareStrength,false);
		addMember(l,"flareFadeSpeed",get_flareFadeSpeed,set_flareFadeSpeed,false);
		createTypeMetatable(l,null, typeof(UnityEngine.RenderSettings),typeof(UnityEngine.Object));
	}
}
