using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_MatchTargetWeightMask : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.MatchTargetWeightMask o;
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			o=new UnityEngine.MatchTargetWeightMask(a1,a2);
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
	static public int get_positionXYZWeight(IntPtr l) {
		try {
			UnityEngine.MatchTargetWeightMask self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.positionXYZWeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_positionXYZWeight(IntPtr l) {
		try {
			UnityEngine.MatchTargetWeightMask self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.positionXYZWeight=v;
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
	static public int get_rotationWeight(IntPtr l) {
		try {
			UnityEngine.MatchTargetWeightMask self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rotationWeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rotationWeight(IntPtr l) {
		try {
			UnityEngine.MatchTargetWeightMask self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.rotationWeight=v;
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
		getTypeTable(l,"UnityEngine.MatchTargetWeightMask");
		addMember(l,"positionXYZWeight",get_positionXYZWeight,set_positionXYZWeight,true);
		addMember(l,"rotationWeight",get_rotationWeight,set_rotationWeight,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.MatchTargetWeightMask),typeof(System.ValueType));
	}
}
