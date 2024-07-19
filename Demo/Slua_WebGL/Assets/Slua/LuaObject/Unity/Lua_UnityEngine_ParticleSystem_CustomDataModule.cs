using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_ParticleSystem_CustomDataModule : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule o;
			o=new UnityEngine.ParticleSystem.CustomDataModule();
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
	static public int SetMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCustomData a1;
			a1 = (UnityEngine.ParticleSystemCustomData)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.ParticleSystemCustomDataMode a2;
			a2 = (UnityEngine.ParticleSystemCustomDataMode)LuaDLL.luaL_checkinteger(l, 3);
			self.SetMode(a1,a2);
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
	static public int GetMode(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCustomData a1;
			a1 = (UnityEngine.ParticleSystemCustomData)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetMode(a1);
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
	static public int SetVectorComponentCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCustomData a1;
			a1 = (UnityEngine.ParticleSystemCustomData)LuaDLL.luaL_checkinteger(l, 2);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.SetVectorComponentCount(a1,a2);
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
	static public int GetVectorComponentCount(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCustomData a1;
			a1 = (UnityEngine.ParticleSystemCustomData)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetVectorComponentCount(a1);
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
	static public int SetVector(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCustomData a1;
			a1 = (UnityEngine.ParticleSystemCustomData)LuaDLL.luaL_checkinteger(l, 2);
			System.Int32 a2;
			checkType(l,3,out a2);
			UnityEngine.ParticleSystem.MinMaxCurve a3;
			checkValueType(l,4,out a3);
			self.SetVector(a1,a2,a3);
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
	static public int GetVector(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCustomData a1;
			a1 = (UnityEngine.ParticleSystemCustomData)LuaDLL.luaL_checkinteger(l, 2);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.GetVector(a1,a2);
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
	static public int SetColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCustomData a1;
			a1 = (UnityEngine.ParticleSystemCustomData)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.ParticleSystem.MinMaxGradient a2;
			checkValueType(l,3,out a2);
			self.SetColor(a1,a2);
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
	static public int GetColor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.CustomDataModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemCustomData a1;
			a1 = (UnityEngine.ParticleSystemCustomData)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetColor(a1);
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
			UnityEngine.ParticleSystem.CustomDataModule self;
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
			UnityEngine.ParticleSystem.CustomDataModule self;
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.CustomDataModule");
		addMember(l,SetMode);
		addMember(l,GetMode);
		addMember(l,SetVectorComponentCount);
		addMember(l,GetVectorComponentCount);
		addMember(l,SetVector);
		addMember(l,GetVector);
		addMember(l,SetColor);
		addMember(l,GetColor);
		addMember(l,"enabled",get_enabled,set_enabled,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.CustomDataModule),typeof(System.ValueType));
	}
}
