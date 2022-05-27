using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animations_AnimationHumanStream : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream o;
			o=new UnityEngine.Animations.AnimationHumanStream();
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
	static public int GetMuscle(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.MuscleHandle a1;
			checkValueType(l,2,out a1);
			var ret=self.GetMuscle(a1);
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
	static public int SetMuscle(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.Animations.MuscleHandle a1;
			checkValueType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetMuscle(a1,a2);
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
	static public int ResetToStancePose(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			self.ResetToStancePose();
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
	static public int GetGoalPositionFromPose(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetGoalPositionFromPose(a1);
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
	static public int GetGoalRotationFromPose(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetGoalRotationFromPose(a1);
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
	static public int GetGoalLocalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetGoalLocalPosition(a1);
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
	static public int SetGoalLocalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetGoalLocalPosition(a1,a2);
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
	static public int GetGoalLocalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetGoalLocalRotation(a1);
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
	static public int SetGoalLocalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			self.SetGoalLocalRotation(a1,a2);
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
	static public int GetGoalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetGoalPosition(a1);
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
	static public int SetGoalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetGoalPosition(a1,a2);
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
	static public int GetGoalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetGoalRotation(a1);
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
	static public int SetGoalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			self.SetGoalRotation(a1,a2);
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
	static public int SetGoalWeightPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetGoalWeightPosition(a1,a2);
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
	static public int SetGoalWeightRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetGoalWeightRotation(a1,a2);
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
	static public int GetGoalWeightPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetGoalWeightPosition(a1);
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
	static public int GetGoalWeightRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetGoalWeightRotation(a1);
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
	static public int GetHintPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKHint a1;
			a1 = (UnityEngine.AvatarIKHint)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetHintPosition(a1);
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
	static public int SetHintPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKHint a1;
			a1 = (UnityEngine.AvatarIKHint)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetHintPosition(a1,a2);
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
	static public int SetHintWeightPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKHint a1;
			a1 = (UnityEngine.AvatarIKHint)LuaDLL.luaL_checkinteger(l, 2);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetHintWeightPosition(a1,a2);
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
	static public int GetHintWeightPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.AvatarIKHint a1;
			a1 = (UnityEngine.AvatarIKHint)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetHintWeightPosition(a1);
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
	static public int SetLookAtPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			self.SetLookAtPosition(a1);
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
	static public int SetLookAtClampWeight(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetLookAtClampWeight(a1);
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
	static public int SetLookAtBodyWeight(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetLookAtBodyWeight(a1);
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
	static public int SetLookAtHeadWeight(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetLookAtHeadWeight(a1);
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
	static public int SetLookAtEyesWeight(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			System.Single a1;
			checkType(l,2,out a1);
			self.SetLookAtEyesWeight(a1);
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
	static public int SolveIK(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			self.SolveIK();
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
	static public int get_isValid(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isValid);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_humanScale(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.humanScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_leftFootHeight(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.leftFootHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rightFootHeight(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rightFootHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bodyLocalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bodyLocalPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bodyLocalPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.bodyLocalPosition=v;
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
	static public int get_bodyLocalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bodyLocalRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bodyLocalRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.bodyLocalRotation=v;
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
	static public int get_bodyPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bodyPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bodyPosition(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.bodyPosition=v;
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
	static public int get_bodyRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.bodyRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_bodyRotation(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.bodyRotation=v;
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
	static public int get_leftFootVelocity(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.leftFootVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rightFootVelocity(IntPtr l) {
		try {
			UnityEngine.Animations.AnimationHumanStream self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.rightFootVelocity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animations.AnimationHumanStream");
		addMember(l,GetMuscle);
		addMember(l,SetMuscle);
		addMember(l,ResetToStancePose);
		addMember(l,GetGoalPositionFromPose);
		addMember(l,GetGoalRotationFromPose);
		addMember(l,GetGoalLocalPosition);
		addMember(l,SetGoalLocalPosition);
		addMember(l,GetGoalLocalRotation);
		addMember(l,SetGoalLocalRotation);
		addMember(l,GetGoalPosition);
		addMember(l,SetGoalPosition);
		addMember(l,GetGoalRotation);
		addMember(l,SetGoalRotation);
		addMember(l,SetGoalWeightPosition);
		addMember(l,SetGoalWeightRotation);
		addMember(l,GetGoalWeightPosition);
		addMember(l,GetGoalWeightRotation);
		addMember(l,GetHintPosition);
		addMember(l,SetHintPosition);
		addMember(l,SetHintWeightPosition);
		addMember(l,GetHintWeightPosition);
		addMember(l,SetLookAtPosition);
		addMember(l,SetLookAtClampWeight);
		addMember(l,SetLookAtBodyWeight);
		addMember(l,SetLookAtHeadWeight);
		addMember(l,SetLookAtEyesWeight);
		addMember(l,SolveIK);
		addMember(l,"isValid",get_isValid,null,true);
		addMember(l,"humanScale",get_humanScale,null,true);
		addMember(l,"leftFootHeight",get_leftFootHeight,null,true);
		addMember(l,"rightFootHeight",get_rightFootHeight,null,true);
		addMember(l,"bodyLocalPosition",get_bodyLocalPosition,set_bodyLocalPosition,true);
		addMember(l,"bodyLocalRotation",get_bodyLocalRotation,set_bodyLocalRotation,true);
		addMember(l,"bodyPosition",get_bodyPosition,set_bodyPosition,true);
		addMember(l,"bodyRotation",get_bodyRotation,set_bodyRotation,true);
		addMember(l,"leftFootVelocity",get_leftFootVelocity,null,true);
		addMember(l,"rightFootVelocity",get_rightFootVelocity,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Animations.AnimationHumanStream),typeof(System.ValueType));
	}
}
