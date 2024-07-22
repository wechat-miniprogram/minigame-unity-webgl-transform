using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystemRenderer : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetMeshes(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Mesh[] a1;
			checkArray(l,2,out a1);
			var ret=self.GetMeshes(a1);
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
	static public int SetMeshes(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				UnityEngine.Mesh[] a1;
				checkArray(l,2,out a1);
				self.SetMeshes(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				UnityEngine.Mesh[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetMeshes(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetMeshes to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetMeshWeightings(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			System.Single[] a1;
			checkArray(l,2,out a1);
			var ret=self.GetMeshWeightings(a1);
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
	static public int SetMeshWeightings(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				System.Single[] a1;
				checkArray(l,2,out a1);
				self.SetMeshWeightings(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				System.Single[] a1;
				checkArray(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetMeshWeightings(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetMeshWeightings to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BakeMesh(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.BakeMesh(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				UnityEngine.Camera a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.BakeMesh(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function BakeMesh to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BakeTrailsMesh(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.BakeTrailsMesh(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
				UnityEngine.Mesh a1;
				checkType(l,2,out a1);
				UnityEngine.Camera a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.BakeTrailsMesh(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function BakeTrailsMesh to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetActiveVertexStreams(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.ParticleSystemVertexStream> a1;
			checkType(l,2,out a1);
			self.SetActiveVertexStreams(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetActiveVertexStreams(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			System.Collections.Generic.List<UnityEngine.ParticleSystemVertexStream> a1;
			checkType(l,2,out a1);
			self.GetActiveVertexStreams(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_alignment(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.alignment);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_alignment(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.ParticleSystemRenderSpace v;
			v = (UnityEngine.ParticleSystemRenderSpace)LuaDLL.luaL_checkinteger(l, 2);
			self.alignment=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_renderMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.renderMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_renderMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.ParticleSystemRenderMode v;
			v = (UnityEngine.ParticleSystemRenderMode)LuaDLL.luaL_checkinteger(l, 2);
			self.renderMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_meshDistribution(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.meshDistribution);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_meshDistribution(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.ParticleSystemMeshDistribution v;
			v = (UnityEngine.ParticleSystemMeshDistribution)LuaDLL.luaL_checkinteger(l, 2);
			self.meshDistribution=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sortMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.sortMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sortMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.ParticleSystemSortMode v;
			v = (UnityEngine.ParticleSystemSortMode)LuaDLL.luaL_checkinteger(l, 2);
			self.sortMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lengthScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lengthScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lengthScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.lengthScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_velocityScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.velocityScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_velocityScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.velocityScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cameraVelocityScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cameraVelocityScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cameraVelocityScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.cameraVelocityScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_normalDirection(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.normalDirection);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_normalDirection(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.normalDirection=v;
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
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
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
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.shadowBias=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sortingFudge(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sortingFudge);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sortingFudge(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.sortingFudge=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_minParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.minParticleSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.minParticleSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maxParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.maxParticleSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.maxParticleSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pivot(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pivot);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_pivot(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.pivot=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_flip(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.flip);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_flip(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.flip=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_maskInteraction(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.maskInteraction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maskInteraction(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.SpriteMaskInteraction v;
			v = (UnityEngine.SpriteMaskInteraction)LuaDLL.luaL_checkinteger(l, 2);
			self.maskInteraction=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_trailMaterial(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.trailMaterial);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_trailMaterial(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Material v;
			checkType(l,2,out v);
			self.trailMaterial=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_enableGPUInstancing(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.enableGPUInstancing);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enableGPUInstancing(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.enableGPUInstancing=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_allowRoll(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.allowRoll);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_allowRoll(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.allowRoll=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_freeformStretching(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.freeformStretching);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_freeformStretching(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.freeformStretching=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rotateWithStretchDirection(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rotateWithStretchDirection);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotateWithStretchDirection(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.rotateWithStretchDirection=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_mesh(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.mesh);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_mesh(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			UnityEngine.Mesh v;
			checkType(l,2,out v);
			self.mesh=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_meshCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.meshCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_activeVertexStreamsCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystemRenderer self=(UnityEngine.ParticleSystemRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.activeVertexStreamsCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystemRenderer");
		addMember(l,GetMeshes);
		addMember(l,SetMeshes);
		addMember(l,GetMeshWeightings);
		addMember(l,SetMeshWeightings);
		addMember(l,BakeMesh);
		addMember(l,BakeTrailsMesh);
		addMember(l,SetActiveVertexStreams);
		addMember(l,GetActiveVertexStreams);
		addMember(l,"alignment",get_alignment,set_alignment,true);
		addMember(l,"renderMode",get_renderMode,set_renderMode,true);
		addMember(l,"meshDistribution",get_meshDistribution,set_meshDistribution,true);
		addMember(l,"sortMode",get_sortMode,set_sortMode,true);
		addMember(l,"lengthScale",get_lengthScale,set_lengthScale,true);
		addMember(l,"velocityScale",get_velocityScale,set_velocityScale,true);
		addMember(l,"cameraVelocityScale",get_cameraVelocityScale,set_cameraVelocityScale,true);
		addMember(l,"normalDirection",get_normalDirection,set_normalDirection,true);
		addMember(l,"shadowBias",get_shadowBias,set_shadowBias,true);
		addMember(l,"sortingFudge",get_sortingFudge,set_sortingFudge,true);
		addMember(l,"minParticleSize",get_minParticleSize,set_minParticleSize,true);
		addMember(l,"maxParticleSize",get_maxParticleSize,set_maxParticleSize,true);
		addMember(l,"pivot",get_pivot,set_pivot,true);
		addMember(l,"flip",get_flip,set_flip,true);
		addMember(l,"maskInteraction",get_maskInteraction,set_maskInteraction,true);
		addMember(l,"trailMaterial",get_trailMaterial,set_trailMaterial,true);
		addMember(l,"enableGPUInstancing",get_enableGPUInstancing,set_enableGPUInstancing,true);
		addMember(l,"allowRoll",get_allowRoll,set_allowRoll,true);
		addMember(l,"freeformStretching",get_freeformStretching,set_freeformStretching,true);
		addMember(l,"rotateWithStretchDirection",get_rotateWithStretchDirection,set_rotateWithStretchDirection,true);
		addMember(l,"mesh",get_mesh,set_mesh,true);
		addMember(l,"meshCount",get_meshCount,null,true);
		addMember(l,"activeVertexStreamsCount",get_activeVertexStreamsCount,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.ParticleSystemRenderer),typeof(UnityEngine.Renderer));
	}
}
