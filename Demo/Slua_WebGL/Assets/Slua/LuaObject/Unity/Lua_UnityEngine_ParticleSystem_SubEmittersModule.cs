using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_SubEmittersModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule o;
			o=new UnityEngine.ParticleSystem.SubEmittersModule();
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
	static public int AddSubEmitter(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				UnityEngine.ParticleSystem.SubEmittersModule self;
				checkValueType(l,1,out self);
				UnityEngine.ParticleSystem a1;
				checkType(l,2,out a1);
				UnityEngine.ParticleSystemSubEmitterType a2;
				a2 = (UnityEngine.ParticleSystemSubEmitterType)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.ParticleSystemSubEmitterProperties a3;
				a3 = (UnityEngine.ParticleSystemSubEmitterProperties)LuaDLL.luaL_checkinteger(l, 4);
				self.AddSubEmitter(a1,a2,a3);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(argc==5){
				UnityEngine.ParticleSystem.SubEmittersModule self;
				checkValueType(l,1,out self);
				UnityEngine.ParticleSystem a1;
				checkType(l,2,out a1);
				UnityEngine.ParticleSystemSubEmitterType a2;
				a2 = (UnityEngine.ParticleSystemSubEmitterType)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.ParticleSystemSubEmitterProperties a3;
				a3 = (UnityEngine.ParticleSystemSubEmitterProperties)LuaDLL.luaL_checkinteger(l, 4);
				System.Single a4;
				checkType(l,5,out a4);
				self.AddSubEmitter(a1,a2,a3,a4);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddSubEmitter to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveSubEmitter(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(int))){
				UnityEngine.ParticleSystem.SubEmittersModule self;
				checkValueType(l,1,out self);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.RemoveSubEmitter(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.ParticleSystem))){
				UnityEngine.ParticleSystem.SubEmittersModule self;
				checkValueType(l,1,out self);
				UnityEngine.ParticleSystem a1;
				checkType(l,2,out a1);
				self.RemoveSubEmitter(a1);
				pushValue(l,true);
				setBack(l,self);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function RemoveSubEmitter to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetSubEmitterSystem(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.ParticleSystem a2;
			checkType(l,3,out a2);
			self.SetSubEmitterSystem(a1,a2);
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
	static public int SetSubEmitterType(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.ParticleSystemSubEmitterType a2;
			a2 = (UnityEngine.ParticleSystemSubEmitterType)LuaDLL.luaL_checkinteger(l, 3);
			self.SetSubEmitterType(a1,a2);
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
	static public int SetSubEmitterProperties(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			UnityEngine.ParticleSystemSubEmitterProperties a2;
			a2 = (UnityEngine.ParticleSystemSubEmitterProperties)LuaDLL.luaL_checkinteger(l, 3);
			self.SetSubEmitterProperties(a1,a2);
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
	static public int SetSubEmitterEmitProbability(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetSubEmitterEmitProbability(a1,a2);
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
	static public int GetSubEmitterSystem(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSubEmitterSystem(a1);
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
	static public int GetSubEmitterType(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSubEmitterType(a1);
			pushValue(l,true);
			pushEnum(l,(int)ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSubEmitterProperties(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSubEmitterProperties(a1);
			pushValue(l,true);
			pushEnum(l,(int)ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSubEmitterEmitProbability(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetSubEmitterEmitProbability(a1);
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
			UnityEngine.ParticleSystem.SubEmittersModule self;
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
			UnityEngine.ParticleSystem.SubEmittersModule self;
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
	static public int get_subEmittersCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.SubEmittersModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.subEmittersCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.SubEmittersModule");
		addMember(l,AddSubEmitter);
		addMember(l,RemoveSubEmitter);
		addMember(l,SetSubEmitterSystem);
		addMember(l,SetSubEmitterType);
		addMember(l,SetSubEmitterProperties);
		addMember(l,SetSubEmitterEmitProbability);
		addMember(l,GetSubEmitterSystem);
		addMember(l,GetSubEmitterType);
		addMember(l,GetSubEmitterProperties);
		addMember(l,GetSubEmitterEmitProbability);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"subEmittersCount",get_subEmittersCount,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.SubEmittersModule),typeof(System.ValueType));
	}
}
