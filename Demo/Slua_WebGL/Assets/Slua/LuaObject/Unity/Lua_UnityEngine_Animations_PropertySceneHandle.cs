using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_PropertySceneHandle : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Animations.PropertySceneHandle o;
			o=new UnityEngine.Animations.PropertySceneHandle();
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
	static public int IsValid(IntPtr l) {
		try {
			UnityEngine.Animations.PropertySceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.IsValid(a1);
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
	static public int Resolve(IntPtr l) {
		try {
			UnityEngine.Animations.PropertySceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			self.Resolve(a1);
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
	static public int IsResolved(IntPtr l) {
		try {
			UnityEngine.Animations.PropertySceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.IsResolved(a1);
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
	static public int GetFloat(IntPtr l) {
		try {
			UnityEngine.Animations.PropertySceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetFloat(a1);
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
	static public int GetInt(IntPtr l) {
		try {
			UnityEngine.Animations.PropertySceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetInt(a1);
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
	static public int GetBool(IntPtr l) {
		try {
			UnityEngine.Animations.PropertySceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetBool(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.PropertySceneHandle");
		addMember(l,IsValid);
		addMember(l,Resolve);
		addMember(l,IsResolved);
		addMember(l,GetFloat);
		addMember(l,GetInt);
		addMember(l,GetBool);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Animations.PropertySceneHandle),typeof(System.ValueType));
	}
}
