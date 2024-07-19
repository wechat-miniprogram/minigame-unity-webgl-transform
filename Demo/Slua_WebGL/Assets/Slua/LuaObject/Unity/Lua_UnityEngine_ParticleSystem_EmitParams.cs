using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_EmitParams : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams o;
			o=new UnityEngine.ParticleSystem.EmitParams();
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
	static public int ResetPosition(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetPosition();
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
	static public int ResetVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetVelocity();
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
	static public int ResetAxisOfRotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetAxisOfRotation();
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
	static public int ResetRotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetRotation();
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
	static public int ResetAngularVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetAngularVelocity();
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
	static public int ResetStartSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetStartSize();
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
	static public int ResetStartColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetStartColor();
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
	static public int ResetRandomSeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetRandomSeed();
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
	static public int ResetStartLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetStartLifetime();
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
	static public int ResetMeshIndex(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			self.ResetMeshIndex();
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
	static public int get_particle(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.particle);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_particle(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.Particle v;
			checkValueType(l,2,out v);
			self.particle=v;
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
	static public int get_position(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.position);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_position(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.position=v;
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
	static public int get_applyShapeToPosition(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.applyShapeToPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_applyShapeToPosition(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.applyShapeToPosition=v;
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
	static public int get_velocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.velocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_velocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.velocity=v;
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
	static public int get_startLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startLifetime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startLifetime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startLifetime=v;
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
	static public int get_startSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startSize=v;
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
	static public int get_startSize3D(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSize3D);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSize3D(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.startSize3D=v;
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
	static public int get_axisOfRotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.axisOfRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_axisOfRotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.axisOfRotation=v;
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
	static public int get_rotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.rotation=v;
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
	static public int get_rotation3D(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rotation3D);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotation3D(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.rotation3D=v;
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
	static public int get_angularVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.angularVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_angularVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.angularVelocity=v;
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
	static public int get_angularVelocity3D(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.angularVelocity3D);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_angularVelocity3D(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.angularVelocity3D=v;
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
	static public int get_startColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startColor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			UnityEngine.Color32 v;
			checkValueType(l,2,out v);
			self.startColor=v;
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
	static public int get_randomSeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.randomSeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_randomSeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			System.UInt32 v;
			checkType(l,2,out v);
			self.randomSeed=v;
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
	static public int set_meshIndex(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.EmitParams self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.meshIndex=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.EmitParams");
		addMember(l,ResetPosition);
		addMember(l,ResetVelocity);
		addMember(l,ResetAxisOfRotation);
		addMember(l,ResetRotation);
		addMember(l,ResetAngularVelocity);
		addMember(l,ResetStartSize);
		addMember(l,ResetStartColor);
		addMember(l,ResetRandomSeed);
		addMember(l,ResetStartLifetime);
		addMember(l,ResetMeshIndex);
		addMember(l,"particle",get_particle,set_particle,true);
		addMember(l,"position",get_position,set_position,true);
		addMember(l,"applyShapeToPosition",get_applyShapeToPosition,set_applyShapeToPosition,true);
		addMember(l,"velocity",get_velocity,set_velocity,true);
		addMember(l,"startLifetime",get_startLifetime,set_startLifetime,true);
		addMember(l,"startSize",get_startSize,set_startSize,true);
		addMember(l,"startSize3D",get_startSize3D,set_startSize3D,true);
		addMember(l,"axisOfRotation",get_axisOfRotation,set_axisOfRotation,true);
		addMember(l,"rotation",get_rotation,set_rotation,true);
		addMember(l,"rotation3D",get_rotation3D,set_rotation3D,true);
		addMember(l,"angularVelocity",get_angularVelocity,set_angularVelocity,true);
		addMember(l,"angularVelocity3D",get_angularVelocity3D,set_angularVelocity3D,true);
		addMember(l,"startColor",get_startColor,set_startColor,true);
		addMember(l,"randomSeed",get_randomSeed,set_randomSeed,true);
		addMember(l,"meshIndex",null,set_meshIndex,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.EmitParams),typeof(System.ValueType));
	}
}
