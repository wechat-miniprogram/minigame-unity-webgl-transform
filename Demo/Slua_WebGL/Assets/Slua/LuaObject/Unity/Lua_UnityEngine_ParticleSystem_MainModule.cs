using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_MainModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule o;
			o=new UnityEngine.ParticleSystem.MainModule();
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
	static public int get_emitterVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.emitterVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_emitterVelocity(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.emitterVelocity=v;
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
	static public int get_duration(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.duration);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_duration(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.duration=v;
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
	static public int get_loop(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.loop);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_loop(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.loop=v;
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
	static public int get_prewarm(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.prewarm);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_prewarm(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.prewarm=v;
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
	static public int get_startDelay(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startDelay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startDelay(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startDelay=v;
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
	static public int get_startDelayMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startDelayMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startDelayMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startDelayMultiplier=v;
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
			UnityEngine.ParticleSystem.MainModule self;
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
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
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
	static public int get_startLifetimeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startLifetimeMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startLifetimeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startLifetimeMultiplier=v;
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
	static public int get_startSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startSpeed=v;
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
	static public int get_startSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSpeedMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSpeedMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startSpeedMultiplier=v;
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
			UnityEngine.ParticleSystem.MainModule self;
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
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			bool v;
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
	static public int get_startSize(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
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
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
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
	static public int get_startSizeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSizeMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSizeMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startSizeMultiplier=v;
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
	static public int get_startSizeX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSizeX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSizeX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startSizeX=v;
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
	static public int get_startSizeXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSizeXMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSizeXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startSizeXMultiplier=v;
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
	static public int get_startSizeY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSizeY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSizeY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startSizeY=v;
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
	static public int get_startSizeYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSizeYMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSizeYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startSizeYMultiplier=v;
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
	static public int get_startSizeZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSizeZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSizeZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startSizeZ=v;
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
	static public int get_startSizeZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startSizeZMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startSizeZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startSizeZMultiplier=v;
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
	static public int get_startRotation3D(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotation3D);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotation3D(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.startRotation3D=v;
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
	static public int get_startRotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startRotation=v;
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
	static public int get_startRotationMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotationMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotationMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startRotationMultiplier=v;
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
	static public int get_startRotationX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotationX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotationX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startRotationX=v;
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
	static public int get_startRotationXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotationXMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotationXMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startRotationXMultiplier=v;
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
	static public int get_startRotationY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotationY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotationY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startRotationY=v;
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
	static public int get_startRotationYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotationYMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotationYMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startRotationYMultiplier=v;
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
	static public int get_startRotationZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotationZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotationZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.startRotationZ=v;
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
	static public int get_startRotationZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.startRotationZMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_startRotationZMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.startRotationZMultiplier=v;
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
	static public int get_flipRotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.flipRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_flipRotation(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.flipRotation=v;
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
			UnityEngine.ParticleSystem.MainModule self;
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
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxGradient v;
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
	static public int get_gravityModifier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.gravityModifier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gravityModifier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.gravityModifier=v;
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
	static public int get_gravityModifierMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.gravityModifierMultiplier);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_gravityModifierMultiplier(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.gravityModifierMultiplier=v;
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
	static public int get_simulationSpace(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.simulationSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_simulationSpace(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemSimulationSpace v;
			v = (UnityEngine.ParticleSystemSimulationSpace)LuaDLL.luaL_checkinteger(l, 2);
			self.simulationSpace=v;
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
	static public int get_customSimulationSpace(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.customSimulationSpace);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_customSimulationSpace(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.customSimulationSpace=v;
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
	static public int get_simulationSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.simulationSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_simulationSpeed(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.simulationSpeed=v;
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
	static public int get_useUnscaledTime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useUnscaledTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useUnscaledTime(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.useUnscaledTime=v;
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
	static public int get_scalingMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.scalingMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_scalingMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemScalingMode v;
			v = (UnityEngine.ParticleSystemScalingMode)LuaDLL.luaL_checkinteger(l, 2);
			self.scalingMode=v;
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
	static public int get_playOnAwake(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.playOnAwake);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_playOnAwake(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.playOnAwake=v;
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
	static public int get_maxParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maxParticles);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxParticles(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.maxParticles=v;
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
	static public int get_emitterVelocityMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.emitterVelocityMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_emitterVelocityMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemEmitterVelocityMode v;
			v = (UnityEngine.ParticleSystemEmitterVelocityMode)LuaDLL.luaL_checkinteger(l, 2);
			self.emitterVelocityMode=v;
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
	static public int get_stopAction(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.stopAction);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_stopAction(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemStopAction v;
			v = (UnityEngine.ParticleSystemStopAction)LuaDLL.luaL_checkinteger(l, 2);
			self.stopAction=v;
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
	static public int get_ringBufferMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.ringBufferMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ringBufferMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemRingBufferMode v;
			v = (UnityEngine.ParticleSystemRingBufferMode)LuaDLL.luaL_checkinteger(l, 2);
			self.ringBufferMode=v;
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
	static public int get_ringBufferLoopRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.ringBufferLoopRange);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_ringBufferLoopRange(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.Vector2 v;
			checkType(l,2,out v);
			self.ringBufferLoopRange=v;
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
	static public int get_cullingMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.cullingMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cullingMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.MainModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCullingMode v;
			v = (UnityEngine.ParticleSystemCullingMode)LuaDLL.luaL_checkinteger(l, 2);
			self.cullingMode=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.MainModule");
		addMember(l,"emitterVelocity",get_emitterVelocity,set_emitterVelocity,true);
		addMember(l,"duration",get_duration,set_duration,true);
		addMember(l,"loop",get_loop,set_loop,true);
		addMember(l,"prewarm",get_prewarm,set_prewarm,true);
		addMember(l,"startDelay",get_startDelay,set_startDelay,true);
		addMember(l,"startDelayMultiplier",get_startDelayMultiplier,set_startDelayMultiplier,true);
		addMember(l,"startLifetime",get_startLifetime,set_startLifetime,true);
		addMember(l,"startLifetimeMultiplier",get_startLifetimeMultiplier,set_startLifetimeMultiplier,true);
		addMember(l,"startSpeed",get_startSpeed,set_startSpeed,true);
		addMember(l,"startSpeedMultiplier",get_startSpeedMultiplier,set_startSpeedMultiplier,true);
		addMember(l,"startSize3D",get_startSize3D,set_startSize3D,true);
		addMember(l,"startSize",get_startSize,set_startSize,true);
		addMember(l,"startSizeMultiplier",get_startSizeMultiplier,set_startSizeMultiplier,true);
		addMember(l,"startSizeX",get_startSizeX,set_startSizeX,true);
		addMember(l,"startSizeXMultiplier",get_startSizeXMultiplier,set_startSizeXMultiplier,true);
		addMember(l,"startSizeY",get_startSizeY,set_startSizeY,true);
		addMember(l,"startSizeYMultiplier",get_startSizeYMultiplier,set_startSizeYMultiplier,true);
		addMember(l,"startSizeZ",get_startSizeZ,set_startSizeZ,true);
		addMember(l,"startSizeZMultiplier",get_startSizeZMultiplier,set_startSizeZMultiplier,true);
		addMember(l,"startRotation3D",get_startRotation3D,set_startRotation3D,true);
		addMember(l,"startRotation",get_startRotation,set_startRotation,true);
		addMember(l,"startRotationMultiplier",get_startRotationMultiplier,set_startRotationMultiplier,true);
		addMember(l,"startRotationX",get_startRotationX,set_startRotationX,true);
		addMember(l,"startRotationXMultiplier",get_startRotationXMultiplier,set_startRotationXMultiplier,true);
		addMember(l,"startRotationY",get_startRotationY,set_startRotationY,true);
		addMember(l,"startRotationYMultiplier",get_startRotationYMultiplier,set_startRotationYMultiplier,true);
		addMember(l,"startRotationZ",get_startRotationZ,set_startRotationZ,true);
		addMember(l,"startRotationZMultiplier",get_startRotationZMultiplier,set_startRotationZMultiplier,true);
		addMember(l,"flipRotation",get_flipRotation,set_flipRotation,true);
		addMember(l,"startColor",get_startColor,set_startColor,true);
		addMember(l,"gravityModifier",get_gravityModifier,set_gravityModifier,true);
		addMember(l,"gravityModifierMultiplier",get_gravityModifierMultiplier,set_gravityModifierMultiplier,true);
		addMember(l,"simulationSpace",get_simulationSpace,set_simulationSpace,true);
		addMember(l,"customSimulationSpace",get_customSimulationSpace,set_customSimulationSpace,true);
		addMember(l,"simulationSpeed",get_simulationSpeed,set_simulationSpeed,true);
		addMember(l,"useUnscaledTime",get_useUnscaledTime,set_useUnscaledTime,true);
		addMember(l,"scalingMode",get_scalingMode,set_scalingMode,true);
		addMember(l,"playOnAwake",get_playOnAwake,set_playOnAwake,true);
		addMember(l,"maxParticles",get_maxParticles,set_maxParticles,true);
		addMember(l,"emitterVelocityMode",get_emitterVelocityMode,set_emitterVelocityMode,true);
		addMember(l,"stopAction",get_stopAction,set_stopAction,true);
		addMember(l,"ringBufferMode",get_ringBufferMode,set_ringBufferMode,true);
		addMember(l,"ringBufferLoopRange",get_ringBufferLoopRange,set_ringBufferLoopRange,true);
		addMember(l,"cullingMode",get_cullingMode,set_cullingMode,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.MainModule),typeof(System.ValueType));
	}
}
