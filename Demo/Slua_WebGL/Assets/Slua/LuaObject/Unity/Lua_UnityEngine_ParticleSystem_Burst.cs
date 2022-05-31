using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_Burst : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.ParticleSystem.Burst o;
			if(matchType(l,argc,2,typeof(float),typeof(System.Int16))){
				System.Single a1;
				checkType(l,2,out a1);
				System.Int16 a2;
				checkType(l,3,out a2);
				o=new UnityEngine.ParticleSystem.Burst(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==4){
				System.Single a1;
				checkType(l,2,out a1);
				System.Int16 a2;
				checkType(l,3,out a2);
				System.Int16 a3;
				checkType(l,4,out a3);
				o=new UnityEngine.ParticleSystem.Burst(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==6){
				System.Single a1;
				checkType(l,2,out a1);
				System.Int16 a2;
				checkType(l,3,out a2);
				System.Int16 a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				o=new UnityEngine.ParticleSystem.Burst(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(float),typeof(UnityEngine.ParticleSystem.MinMaxCurve))){
				System.Single a1;
				checkType(l,2,out a1);
				UnityEngine.ParticleSystem.MinMaxCurve a2;
				checkValueType(l,3,out a2);
				o=new UnityEngine.ParticleSystem.Burst(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==5){
				System.Single a1;
				checkType(l,2,out a1);
				UnityEngine.ParticleSystem.MinMaxCurve a2;
				checkValueType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				o=new UnityEngine.ParticleSystem.Burst(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new UnityEngine.ParticleSystem.Burst();
				pushValue(l,true);
				pushObject(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_time(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.time);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_time(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.time=v;
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
	static public int get_count(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.count);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_count(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.count=v;
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
	static public int get_minCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.minCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_minCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			System.Int16 v;
			checkType(l,2,out v);
			self.minCount=v;
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
	static public int get_maxCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.maxCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_maxCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			System.Int16 v;
			checkType(l,2,out v);
			self.maxCount=v;
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
	static public int get_cycleCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cycleCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cycleCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			int v;
			checkType(l,2,out v);
			self.cycleCount=v;
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
	static public int get_repeatInterval(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.repeatInterval);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_repeatInterval(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.repeatInterval=v;
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
	static public int get_probability(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.probability);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_probability(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.Burst self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.probability=v;
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
		getTypeTable(l,"UnityEngine.ParticleSystem.Burst");
		addMember(l,"time",get_time,set_time,true);
		addMember(l,"count",get_count,set_count,true);
		addMember(l,"minCount",get_minCount,set_minCount,true);
		addMember(l,"maxCount",get_maxCount,set_maxCount,true);
		addMember(l,"cycleCount",get_cycleCount,set_cycleCount,true);
		addMember(l,"repeatInterval",get_repeatInterval,set_repeatInterval,true);
		addMember(l,"probability",get_probability,set_probability,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.Burst),typeof(System.ValueType));
	}
}
