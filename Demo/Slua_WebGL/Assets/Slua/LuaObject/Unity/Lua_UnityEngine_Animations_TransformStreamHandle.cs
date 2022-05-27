using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_TransformStreamHandle : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle o;
			o=new UnityEngine.Animations.TransformStreamHandle();
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
			UnityEngine.Animations.TransformStreamHandle self;
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
			UnityEngine.Animations.TransformStreamHandle self;
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
			UnityEngine.Animations.TransformStreamHandle self;
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
	static public int GetPosition(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
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
	static public int SetPosition(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetPosition(a1,a2);
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
	static public int GetRotation(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
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
	static public int SetRotation(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			self.SetRotation(a1,a2);
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
	static public int GetLocalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
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
	static public int SetLocalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetLocalPosition(a1,a2);
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
	static public int GetLocalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
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
	static public int SetLocalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			self.SetLocalRotation(a1,a2);
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
	static public int GetLocalScale(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
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
	static public int SetLocalScale(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetLocalScale(a1,a2);
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
	static public int GetPositionReadMask(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetPositionReadMask(a1);
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
	static public int GetRotationReadMask(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetRotationReadMask(a1);
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
	static public int GetScaleReadMask(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			var ret=self.GetScaleReadMask(a1);
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
			UnityEngine.Animations.TransformStreamHandle self;
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
	static public int SetLocalTRS(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			UnityEngine.Quaternion a3;
			checkType(l,4,out a3);
			UnityEngine.Vector3 a4;
			checkType(l,5,out a4);
			System.Boolean a5;
			checkType(l,6,out a5);
			self.SetLocalTRS(a1,a2,a3,a4,a5);
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
	static public int GetGlobalTR(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetGlobalTR(IntPtr l) {
		try {
			UnityEngine.Animations.TransformStreamHandle self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.AnimationStream a1;
			checkValueType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			UnityEngine.Quaternion a3;
			checkType(l,4,out a3);
			System.Boolean a4;
			checkType(l,5,out a4);
			self.SetGlobalTR(a1,a2,a3,a4);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.TransformStreamHandle");
		addMember(l,IsValid);
		addMember(l,Resolve);
		addMember(l,IsResolved);
		addMember(l,GetPosition);
		addMember(l,SetPosition);
		addMember(l,GetRotation);
		addMember(l,SetRotation);
		addMember(l,GetLocalPosition);
		addMember(l,SetLocalPosition);
		addMember(l,GetLocalRotation);
		addMember(l,SetLocalRotation);
		addMember(l,GetLocalScale);
		addMember(l,SetLocalScale);
		addMember(l,GetPositionReadMask);
		addMember(l,GetRotationReadMask);
		addMember(l,GetScaleReadMask);
		addMember(l,GetLocalTRS);
		addMember(l,SetLocalTRS);
		addMember(l,GetGlobalTR);
		addMember(l,SetGlobalTR);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Animations.TransformStreamHandle),typeof(System.ValueType));
	}
}
