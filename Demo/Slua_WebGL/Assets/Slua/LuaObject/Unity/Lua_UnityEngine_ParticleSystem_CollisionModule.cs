using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_CollisionModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule o;
			o=new UnityEngine.ParticleSystem.CollisionModule();
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
	static public int AddPlane(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			UnityEngine.Transform a1;
			checkType(l,2,out a1);
			self.AddPlane(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemovePlane(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.ParticleSystem.CollisionModule self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.RemovePlane(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Transform))){
				UnityEngine.ParticleSystem.CollisionModule self;
				checkValueType(l,1,out self);
				UnityEngine.Transform a1;
				checkType(l,2,out a1);
				self.RemovePlane(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function RemovePlane to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPlane(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.Transform a2;
			checkType(l,3,out a2);
			self.SetPlane(a1,a2);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetPlane(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetPlane(a1);
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
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
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
			UnityEngine.ParticleSystem.CollisionModule self;
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
	static public int get_type(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.type);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_type(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCollisionType v;
			v = (UnityEngine.ParticleSystemCollisionType)LuaDLL.luaL_checkinteger(l, 2);
			self.type=v;
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
			UnityEngine.ParticleSystem.CollisionModule self;
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
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCollisionMode v;
			v = (UnityEngine.ParticleSystemCollisionMode)LuaDLL.luaL_checkinteger(l, 2);
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
	static public int get_dampen(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.dampen);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dampen(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.dampen=v;
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
	static public int get_dampenMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.dampenMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_dampenMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.dampenMultiplier=v;
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
	static public int get_bounce(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bounce);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bounce(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.bounce=v;
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
	static public int get_bounceMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bounceMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bounceMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.bounceMultiplier=v;
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
	static public int get_lifetimeLoss(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lifetimeLoss);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lifetimeLoss(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.lifetimeLoss=v;
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
	static public int get_lifetimeLossMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lifetimeLossMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lifetimeLossMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.lifetimeLossMultiplier=v;
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
	static public int get_minKillSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.minKillSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minKillSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.minKillSpeed=v;
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
	static public int get_maxKillSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maxKillSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxKillSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.maxKillSpeed=v;
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
	static public int get_collidesWith(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.collidesWith);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_collidesWith(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			UnityEngine.LayerMask v;
			checkValueType(l,2,out v);
			self.collidesWith=v;
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
	static public int get_enableDynamicColliders(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.enableDynamicColliders);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_enableDynamicColliders(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.enableDynamicColliders=v;
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
	static public int get_maxCollisionShapes(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maxCollisionShapes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxCollisionShapes(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.maxCollisionShapes=v;
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
			UnityEngine.ParticleSystem.CollisionModule self;
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
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCollisionQuality v;
			v = (UnityEngine.ParticleSystemCollisionQuality)LuaDLL.luaL_checkinteger(l, 2);
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
	static public int get_voxelSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.voxelSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_voxelSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.voxelSize=v;
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
	static public int get_radiusScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.radiusScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_radiusScale(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.radiusScale=v;
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
	static public int get_sendCollisionMessages(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.sendCollisionMessages);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_sendCollisionMessages(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.sendCollisionMessages=v;
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
	static public int get_colliderForce(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colliderForce);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_colliderForce(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.colliderForce=v;
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
	static public int get_multiplyColliderForceByCollisionAngle(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.multiplyColliderForceByCollisionAngle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_multiplyColliderForceByCollisionAngle(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.multiplyColliderForceByCollisionAngle=v;
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
	static public int get_multiplyColliderForceByParticleSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.multiplyColliderForceByParticleSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_multiplyColliderForceByParticleSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.multiplyColliderForceByParticleSpeed=v;
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
	static public int get_multiplyColliderForceByParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.multiplyColliderForceByParticleSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_multiplyColliderForceByParticleSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.multiplyColliderForceByParticleSize=v;
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
	static public int get_planeCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CollisionModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.planeCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.CollisionModule");
		addMember(l,AddPlane);
		addMember(l,RemovePlane);
		addMember(l,SetPlane);
		addMember(l,GetPlane);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"type",get_type,set_type,true);
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"dampen",get_dampen,set_dampen,true);
		addMember(l,"dampenMultiplier",get_dampenMultiplier,set_dampenMultiplier,true);
		addMember(l,"bounce",get_bounce,set_bounce,true);
		addMember(l,"bounceMultiplier",get_bounceMultiplier,set_bounceMultiplier,true);
		addMember(l,"lifetimeLoss",get_lifetimeLoss,set_lifetimeLoss,true);
		addMember(l,"lifetimeLossMultiplier",get_lifetimeLossMultiplier,set_lifetimeLossMultiplier,true);
		addMember(l,"minKillSpeed",get_minKillSpeed,set_minKillSpeed,true);
		addMember(l,"maxKillSpeed",get_maxKillSpeed,set_maxKillSpeed,true);
		addMember(l,"collidesWith",get_collidesWith,set_collidesWith,true);
		addMember(l,"enableDynamicColliders",get_enableDynamicColliders,set_enableDynamicColliders,true);
		addMember(l,"maxCollisionShapes",get_maxCollisionShapes,set_maxCollisionShapes,true);
		addMember(l,"quality",get_quality,set_quality,true);
		addMember(l,"voxelSize",get_voxelSize,set_voxelSize,true);
		addMember(l,"radiusScale",get_radiusScale,set_radiusScale,true);
		addMember(l,"sendCollisionMessages",get_sendCollisionMessages,set_sendCollisionMessages,true);
		addMember(l,"colliderForce",get_colliderForce,set_colliderForce,true);
		addMember(l,"multiplyColliderForceByCollisionAngle",get_multiplyColliderForceByCollisionAngle,set_multiplyColliderForceByCollisionAngle,true);
		addMember(l,"multiplyColliderForceByParticleSpeed",get_multiplyColliderForceByParticleSpeed,set_multiplyColliderForceByParticleSpeed,true);
		addMember(l,"multiplyColliderForceByParticleSize",get_multiplyColliderForceByParticleSize,set_multiplyColliderForceByParticleSize,true);
		addMember(l,"planeCount",get_planeCount,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.CollisionModule),typeof(System.ValueType));
	}
}
