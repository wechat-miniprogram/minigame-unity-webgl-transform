using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_TransformSceneHandle : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Animations.TransformSceneHandle o;
			o=new UnityEngine.Animations.TransformSceneHandle();
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
			UnityEngine.Animations.TransformSceneHandle self;
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
	static public int GetPosition(IntPtr l) {
		try {
			UnityEngine.Animations.TransformSceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetPosition(a1);
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
	static public int GetLocalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.TransformSceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetLocalPosition(a1);
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
	static public int GetRotation(IntPtr l) {
		try {
			UnityEngine.Animations.TransformSceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetRotation(a1);
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
	static public int GetLocalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.TransformSceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetLocalRotation(a1);
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
	static public int GetLocalScale(IntPtr l) {
		try {
			UnityEngine.Animations.TransformSceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetLocalScale(a1);
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
	static public int GetLocalTRS(IntPtr l) {
		try {
			UnityEngine.Animations.TransformSceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Vector3 a2;
			UnityEngine.Quaternion a3;
			UnityEngine.Vector3 a4;
			self.GetLocalTRS(a1,out a2,out a3,out a4);
			pushValue(l,true);
			pushValue(l,a2);
			pushValue(l,a3);
			pushValue(l,a4);
			setBack(l,self);
			return 4;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGlobalTR(IntPtr l) {
		try {
			UnityEngine.Animations.TransformSceneHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Vector3 a2;
			UnityEngine.Quaternion a3;
			self.GetGlobalTR(a1,out a2,out a3);
			pushValue(l,true);
			pushValue(l,a2);
			pushValue(l,a3);
			setBack(l,self);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.TransformSceneHandle");
		addMember(l,IsValid);
		addMember(l,GetPosition);
		addMember(l,GetLocalPosition);
		addMember(l,GetRotation);
		addMember(l,GetLocalRotation);
		addMember(l,GetLocalScale);
		addMember(l,GetLocalTRS);
		addMember(l,GetGlobalTR);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Animations.TransformSceneHandle),typeof(System.ValueType));
	}
}
