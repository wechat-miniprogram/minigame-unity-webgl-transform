using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_QualitySettings : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IncreaseLevel_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==0){
				UnityEngine.QualitySettings.IncreaseLevel();
				pushValue(l,true);
				return 1;
			}
			else if(argc==1){
				System.Boolean a1;
				checkType(l,1,out a1);
				UnityEngine.QualitySettings.IncreaseLevel(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function IncreaseLevel to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DecreaseLevel_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==0){
				UnityEngine.QualitySettings.DecreaseLevel();
				pushValue(l,true);
				return 1;
			}
			else if(argc==1){
				System.Boolean a1;
				checkType(l,1,out a1);
				UnityEngine.QualitySettings.DecreaseLevel(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function DecreaseLevel to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetQualityLevel_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.Int32 a1;
				checkType(l,1,out a1);
				UnityEngine.QualitySettings.SetQualityLevel(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				System.Int32 a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				UnityEngine.QualitySettings.SetQualityLevel(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetQualityLevel to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLODSettings_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			UnityEngine.QualitySettings.SetLODSettings(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetRenderPipelineAssetAt_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.QualitySettings.GetRenderPipelineAssetAt(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetQualityLevel_s(IntPtr l) {
		try {
			var ret=UnityEngine.QualitySettings.GetQualityLevel();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetQualitySettings_s(IntPtr l) {
		try {
			var ret=UnityEngine.QualitySettings.GetQualitySettings();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pixelLightCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.pixelLightCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pixelLightCount(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.pixelLightCount=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadows(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.QualitySettings.shadows);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadows(IntPtr l) {
		try {
			UnityEngine.ShadowQuality v;
			v = (UnityEngine.ShadowQuality)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.QualitySettings.shadows=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowProjection(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.QualitySettings.shadowProjection);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowProjection(IntPtr l) {
		try {
			UnityEngine.ShadowProjection v;
			v = (UnityEngine.ShadowProjection)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.QualitySettings.shadowProjection=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowCascades(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.shadowCascades);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowCascades(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.shadowCascades=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowDistance(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.shadowDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowDistance(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.shadowDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowResolution(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.QualitySettings.shadowResolution);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowResolution(IntPtr l) {
		try {
			UnityEngine.ShadowResolution v;
			v = (UnityEngine.ShadowResolution)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.QualitySettings.shadowResolution=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowmaskMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.QualitySettings.shadowmaskMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowmaskMode(IntPtr l) {
		try {
			UnityEngine.ShadowmaskMode v;
			v = (UnityEngine.ShadowmaskMode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.QualitySettings.shadowmaskMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowNearPlaneOffset(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.shadowNearPlaneOffset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowNearPlaneOffset(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.shadowNearPlaneOffset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowCascade2Split(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.shadowCascade2Split);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowCascade2Split(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.shadowCascade2Split=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_shadowCascade4Split(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.shadowCascade4Split);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_shadowCascade4Split(IntPtr l) {
		try {
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.shadowCascade4Split=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lodBias(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.lodBias);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lodBias(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.lodBias=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_anisotropicFiltering(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.QualitySettings.anisotropicFiltering);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_anisotropicFiltering(IntPtr l) {
		try {
			UnityEngine.AnisotropicFiltering v;
			v = (UnityEngine.AnisotropicFiltering)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.QualitySettings.anisotropicFiltering=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_masterTextureLimit(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.masterTextureLimit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_masterTextureLimit(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.masterTextureLimit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maximumLODLevel(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.maximumLODLevel);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maximumLODLevel(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.maximumLODLevel=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_particleRaycastBudget(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.particleRaycastBudget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_particleRaycastBudget(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.particleRaycastBudget=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_softParticles(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.softParticles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_softParticles(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.softParticles=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_softVegetation(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.softVegetation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_softVegetation(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.softVegetation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_vSyncCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.vSyncCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_vSyncCount(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.vSyncCount=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_antiAliasing(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.antiAliasing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_antiAliasing(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.antiAliasing=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_asyncUploadTimeSlice(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.asyncUploadTimeSlice);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_asyncUploadTimeSlice(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.asyncUploadTimeSlice=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_asyncUploadBufferSize(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.asyncUploadBufferSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_asyncUploadBufferSize(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.asyncUploadBufferSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_asyncUploadPersistentBuffer(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.asyncUploadPersistentBuffer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_asyncUploadPersistentBuffer(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.asyncUploadPersistentBuffer=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_realtimeReflectionProbes(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.realtimeReflectionProbes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_realtimeReflectionProbes(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.realtimeReflectionProbes=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_billboardsFaceCameraPosition(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.billboardsFaceCameraPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_billboardsFaceCameraPosition(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.billboardsFaceCameraPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_resolutionScalingFixedDPIFactor(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.resolutionScalingFixedDPIFactor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_resolutionScalingFixedDPIFactor(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.resolutionScalingFixedDPIFactor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_renderPipeline(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.renderPipeline);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_renderPipeline(IntPtr l) {
		try {
			UnityEngine.Rendering.RenderPipelineAsset v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.renderPipeline=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_skinWeights(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.QualitySettings.skinWeights);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_skinWeights(IntPtr l) {
		try {
			UnityEngine.SkinWeights v;
			v = (UnityEngine.SkinWeights)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.QualitySettings.skinWeights=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_streamingMipmapsActive(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.streamingMipmapsActive);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_streamingMipmapsActive(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.streamingMipmapsActive=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_streamingMipmapsMemoryBudget(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.streamingMipmapsMemoryBudget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_streamingMipmapsMemoryBudget(IntPtr l) {
		try {
			float v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.streamingMipmapsMemoryBudget=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_streamingMipmapsMaxLevelReduction(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.streamingMipmapsMaxLevelReduction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_streamingMipmapsMaxLevelReduction(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.streamingMipmapsMaxLevelReduction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_streamingMipmapsAddAllCameras(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.streamingMipmapsAddAllCameras);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_streamingMipmapsAddAllCameras(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.streamingMipmapsAddAllCameras=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_streamingMipmapsMaxFileIORequests(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.streamingMipmapsMaxFileIORequests);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_streamingMipmapsMaxFileIORequests(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.streamingMipmapsMaxFileIORequests=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxQueuedFrames(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.maxQueuedFrames);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxQueuedFrames(IntPtr l) {
		try {
			int v;
			checkType(l,2,out v);
			UnityEngine.QualitySettings.maxQueuedFrames=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_names(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.QualitySettings.names);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_desiredColorSpace(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.QualitySettings.desiredColorSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_activeColorSpace(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.QualitySettings.activeColorSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.QualitySettings");
		addMember(l,IncreaseLevel_s);
		addMember(l,DecreaseLevel_s);
		addMember(l,SetQualityLevel_s);
		addMember(l,SetLODSettings_s);
		addMember(l,GetRenderPipelineAssetAt_s);
		addMember(l,GetQualityLevel_s);
		addMember(l,GetQualitySettings_s);
		addMember(l,"pixelLightCount",get_pixelLightCount,set_pixelLightCount,false);
		addMember(l,"shadows",get_shadows,set_shadows,false);
		addMember(l,"shadowProjection",get_shadowProjection,set_shadowProjection,false);
		addMember(l,"shadowCascades",get_shadowCascades,set_shadowCascades,false);
		addMember(l,"shadowDistance",get_shadowDistance,set_shadowDistance,false);
		addMember(l,"shadowResolution",get_shadowResolution,set_shadowResolution,false);
		addMember(l,"shadowmaskMode",get_shadowmaskMode,set_shadowmaskMode,false);
		addMember(l,"shadowNearPlaneOffset",get_shadowNearPlaneOffset,set_shadowNearPlaneOffset,false);
		addMember(l,"shadowCascade2Split",get_shadowCascade2Split,set_shadowCascade2Split,false);
		addMember(l,"shadowCascade4Split",get_shadowCascade4Split,set_shadowCascade4Split,false);
		addMember(l,"lodBias",get_lodBias,set_lodBias,false);
		addMember(l,"anisotropicFiltering",get_anisotropicFiltering,set_anisotropicFiltering,false);
		addMember(l,"masterTextureLimit",get_masterTextureLimit,set_masterTextureLimit,false);
		addMember(l,"maximumLODLevel",get_maximumLODLevel,set_maximumLODLevel,false);
		addMember(l,"particleRaycastBudget",get_particleRaycastBudget,set_particleRaycastBudget,false);
		addMember(l,"softParticles",get_softParticles,set_softParticles,false);
		addMember(l,"softVegetation",get_softVegetation,set_softVegetation,false);
		addMember(l,"vSyncCount",get_vSyncCount,set_vSyncCount,false);
		addMember(l,"antiAliasing",get_antiAliasing,set_antiAliasing,false);
		addMember(l,"asyncUploadTimeSlice",get_asyncUploadTimeSlice,set_asyncUploadTimeSlice,false);
		addMember(l,"asyncUploadBufferSize",get_asyncUploadBufferSize,set_asyncUploadBufferSize,false);
		addMember(l,"asyncUploadPersistentBuffer",get_asyncUploadPersistentBuffer,set_asyncUploadPersistentBuffer,false);
		addMember(l,"realtimeReflectionProbes",get_realtimeReflectionProbes,set_realtimeReflectionProbes,false);
		addMember(l,"billboardsFaceCameraPosition",get_billboardsFaceCameraPosition,set_billboardsFaceCameraPosition,false);
		addMember(l,"resolutionScalingFixedDPIFactor",get_resolutionScalingFixedDPIFactor,set_resolutionScalingFixedDPIFactor,false);
		addMember(l,"renderPipeline",get_renderPipeline,set_renderPipeline,false);
		addMember(l,"skinWeights",get_skinWeights,set_skinWeights,false);
		addMember(l,"streamingMipmapsActive",get_streamingMipmapsActive,set_streamingMipmapsActive,false);
		addMember(l,"streamingMipmapsMemoryBudget",get_streamingMipmapsMemoryBudget,set_streamingMipmapsMemoryBudget,false);
		addMember(l,"streamingMipmapsMaxLevelReduction",get_streamingMipmapsMaxLevelReduction,set_streamingMipmapsMaxLevelReduction,false);
		addMember(l,"streamingMipmapsAddAllCameras",get_streamingMipmapsAddAllCameras,set_streamingMipmapsAddAllCameras,false);
		addMember(l,"streamingMipmapsMaxFileIORequests",get_streamingMipmapsMaxFileIORequests,set_streamingMipmapsMaxFileIORequests,false);
		addMember(l,"maxQueuedFrames",get_maxQueuedFrames,set_maxQueuedFrames,false);
		addMember(l,"names",get_names,null,false);
		addMember(l,"desiredColorSpace",get_desiredColorSpace,null,false);
		addMember(l,"activeColorSpace",get_activeColorSpace,null,false);
		createTypeMetatable(l,null, typeof(UnityEngine.QualitySettings),typeof(UnityEngine.Object));
	}
}
