using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Animator : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetFloat(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetFloat(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetFloat(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetFloat to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetFloat(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.SetFloat(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.SetFloat(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float),typeof(float),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				self.SetFloat(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float),typeof(float),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				self.SetFloat(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetFloat to call");
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
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetBool(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetBool(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetBool to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetBool(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(bool))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.SetBool(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(bool))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				self.SetBool(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetBool to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetInteger(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetInteger(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetInteger(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetInteger to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetInteger(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetInteger(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.SetInteger(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetInteger to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetTrigger(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.SetTrigger(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.SetTrigger(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetTrigger to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ResetTrigger(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.ResetTrigger(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.ResetTrigger(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function ResetTrigger to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsParameterControlledByCurve(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.IsParameterControlledByCurve(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.IsParameterControlledByCurve(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function IsParameterControlledByCurve to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetIKPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetIKPosition(a1);
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
	static public int SetIKPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetIKPosition(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetIKRotation(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetIKRotation(a1);
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
	static public int SetIKRotation(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			self.SetIKRotation(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetIKPositionWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetIKPositionWeight(a1);
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
	static public int SetIKPositionWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetIKPositionWeight(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetIKRotationWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetIKRotationWeight(a1);
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
	static public int SetIKRotationWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKGoal a1;
			a1 = (UnityEngine.AvatarIKGoal)LuaDLL.luaL_checkinteger(l, 2);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetIKRotationWeight(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetIKHintPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKHint a1;
			a1 = (UnityEngine.AvatarIKHint)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetIKHintPosition(a1);
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
	static public int SetIKHintPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKHint a1;
			a1 = (UnityEngine.AvatarIKHint)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			self.SetIKHintPosition(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetIKHintPositionWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKHint a1;
			a1 = (UnityEngine.AvatarIKHint)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetIKHintPositionWeight(a1);
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
	static public int SetIKHintPositionWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarIKHint a1;
			a1 = (UnityEngine.AvatarIKHint)LuaDLL.luaL_checkinteger(l, 2);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetIKHintPositionWeight(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLookAtPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			self.SetLookAtPosition(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLookAtWeight(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				self.SetLookAtWeight(a1);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.SetLookAtWeight(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.SetLookAtWeight(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				self.SetLookAtWeight(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(argc==6){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Single a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				self.SetLookAtWeight(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SetLookAtWeight to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetBoneLocalRotation(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.HumanBodyBones a1;
			a1 = (UnityEngine.HumanBodyBones)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Quaternion a2;
			checkType(l,3,out a2);
			self.SetBoneLocalRotation(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetBehaviour(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			var ret=self.GetBehaviour<UnityEngine.StateMachineBehaviour>();
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
	static public int GetBehaviours(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				var ret=self.GetBehaviours<UnityEngine.StateMachineBehaviour>();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				var ret=self.GetBehaviours(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetBehaviours to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetLayerName(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetLayerName(a1);
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
	static public int GetLayerIndex(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetLayerIndex(a1);
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
	static public int GetLayerWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetLayerWeight(a1);
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
	static public int SetLayerWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetLayerWeight(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetCurrentAnimatorStateInfo(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetCurrentAnimatorStateInfo(a1);
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
	static public int GetNextAnimatorStateInfo(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetNextAnimatorStateInfo(a1);
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
	static public int GetAnimatorTransitionInfo(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetAnimatorTransitionInfo(a1);
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
	static public int GetCurrentAnimatorClipInfoCount(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetCurrentAnimatorClipInfoCount(a1);
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
	static public int GetNextAnimatorClipInfoCount(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetNextAnimatorClipInfoCount(a1);
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
	static public int GetCurrentAnimatorClipInfo(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetCurrentAnimatorClipInfo(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.AnimatorClipInfo> a2;
				checkType(l,3,out a2);
				self.GetCurrentAnimatorClipInfo(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetCurrentAnimatorClipInfo to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetNextAnimatorClipInfo(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				var ret=self.GetNextAnimatorClipInfo(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.AnimatorClipInfo> a2;
				checkType(l,3,out a2);
				self.GetNextAnimatorClipInfo(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetNextAnimatorClipInfo to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsInTransition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.IsInTransition(a1);
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
	static public int GetParameter(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.GetParameter(a1);
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
	static public int MatchTarget(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==6){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Quaternion a2;
				checkType(l,3,out a2);
				UnityEngine.AvatarTarget a3;
				a3 = (UnityEngine.AvatarTarget)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.MatchTargetWeightMask a4;
				checkValueType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				self.MatchTarget(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(argc==7){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Quaternion a2;
				checkType(l,3,out a2);
				UnityEngine.AvatarTarget a3;
				a3 = (UnityEngine.AvatarTarget)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.MatchTargetWeightMask a4;
				checkValueType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				self.MatchTarget(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(argc==8){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Quaternion a2;
				checkType(l,3,out a2);
				UnityEngine.AvatarTarget a3;
				a3 = (UnityEngine.AvatarTarget)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.MatchTargetWeightMask a4;
				checkValueType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				System.Single a6;
				checkType(l,7,out a6);
				System.Boolean a7;
				checkType(l,8,out a7);
				self.MatchTarget(a1,a2,a3,a4,a5,a6,a7);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function MatchTarget to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int InterruptMatchTarget(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				self.InterruptMatchTarget();
				pushValue(l,true);
				return 1;
			}
			else if(argc==2){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				self.InterruptMatchTarget(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function InterruptMatchTarget to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CrossFadeInFixedTime(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.CrossFadeInFixedTime(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.CrossFadeInFixedTime(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.CrossFadeInFixedTime(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.CrossFadeInFixedTime(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				self.CrossFadeInFixedTime(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				self.CrossFadeInFixedTime(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float),typeof(int),typeof(float),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				self.CrossFadeInFixedTime(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float),typeof(int),typeof(float),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				self.CrossFadeInFixedTime(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CrossFadeInFixedTime to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int WriteDefaultValues(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			self.WriteDefaultValues();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CrossFade(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.CrossFade(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				self.CrossFade(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.CrossFade(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				self.CrossFade(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				self.CrossFade(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				self.CrossFade(a1,a2,a3,a4);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(float),typeof(int),typeof(float),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				self.CrossFade(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(float),typeof(int),typeof(float),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Int32 a3;
				checkType(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Single a5;
				checkType(l,6,out a5);
				self.CrossFade(a1,a2,a3,a4,a5);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CrossFade to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int PlayInFixedTime(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.PlayInFixedTime(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.PlayInFixedTime(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.PlayInFixedTime(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.PlayInFixedTime(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.PlayInFixedTime(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.PlayInFixedTime(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function PlayInFixedTime to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Play(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(string))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.Play(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				self.Play(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.Play(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				self.Play(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.Play(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(int),typeof(int),typeof(float))){
				UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
				System.Int32 a1;
				checkType(l,2,out a1);
				System.Int32 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				self.Play(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Play to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetTarget(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AvatarTarget a1;
			a1 = (UnityEngine.AvatarTarget)LuaDLL.luaL_checkinteger(l, 2);
			System.Single a2;
			checkType(l,3,out a2);
			self.SetTarget(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetBoneTransform(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.HumanBodyBones a1;
			a1 = (UnityEngine.HumanBodyBones)LuaDLL.luaL_checkinteger(l, 2);
			var ret=self.GetBoneTransform(a1);
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
	static public int StartPlayback(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			self.StartPlayback();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StopPlayback(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			self.StopPlayback();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StartRecording(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.StartRecording(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StopRecording(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			self.StopRecording();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int HasState(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.HasState(a1,a2);
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
	static public int Update(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			self.Update(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Rebind(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			self.Rebind();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ApplyBuiltinRootMotion(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			self.ApplyBuiltinRootMotion();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int StringToHash_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Animator.StringToHash(a1);
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
	static public int get_isOptimizable(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isOptimizable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isHuman(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isHuman);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasRootMotion(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasRootMotion);
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
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
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
	static public int get_isInitialized(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isInitialized);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_deltaPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.deltaPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_deltaRotation(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.deltaRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_velocity(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
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
	static public int get_angularVelocity(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
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
	static public int get_rootPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rootPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rootPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.rootPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rootRotation(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rootRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_rootRotation(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.rootRotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_applyRootMotion(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.applyRootMotion);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_applyRootMotion(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.applyRootMotion=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_updateMode(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.updateMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_updateMode(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AnimatorUpdateMode v;
			v = (UnityEngine.AnimatorUpdateMode)LuaDLL.luaL_checkinteger(l, 2);
			self.updateMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasTransformHierarchy(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasTransformHierarchy);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gravityWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.gravityWeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_bodyPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
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
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.bodyPosition=v;
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
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
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
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.bodyRotation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_stabilizeFeet(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.stabilizeFeet);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_stabilizeFeet(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.stabilizeFeet=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_layerCount(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.layerCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_parameters(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.parameters);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_parameterCount(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.parameterCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_feetPivotActive(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.feetPivotActive);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_feetPivotActive(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.feetPivotActive=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pivotWeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pivotWeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_pivotPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pivotPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isMatchingTarget(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isMatchingTarget);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_speed(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.speed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_speed(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.speed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_targetPosition(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.targetPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_targetRotation(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.targetRotation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cullingMode(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
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
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.AnimatorCullingMode v;
			v = (UnityEngine.AnimatorCullingMode)LuaDLL.luaL_checkinteger(l, 2);
			self.cullingMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_playbackTime(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.playbackTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_playbackTime(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.playbackTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_recorderStartTime(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.recorderStartTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_recorderStartTime(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.recorderStartTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_recorderStopTime(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.recorderStopTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_recorderStopTime(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.recorderStopTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_recorderMode(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.recorderMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_runtimeAnimatorController(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.runtimeAnimatorController);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_runtimeAnimatorController(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.RuntimeAnimatorController v;
			checkType(l,2,out v);
			self.runtimeAnimatorController=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_hasBoundPlayables(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.hasBoundPlayables);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_avatar(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.avatar);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_avatar(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			UnityEngine.Avatar v;
			checkType(l,2,out v);
			self.avatar=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_playableGraph(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.playableGraph);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_layersAffectMassCenter(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.layersAffectMassCenter);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_layersAffectMassCenter(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.layersAffectMassCenter=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_leftFeetBottomHeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.leftFeetBottomHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_rightFeetBottomHeight(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.rightFeetBottomHeight);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_logWarnings(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.logWarnings);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_logWarnings(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.logWarnings=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_fireEvents(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fireEvents);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_fireEvents(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.fireEvents=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_keepAnimatorControllerStateOnDisable(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.keepAnimatorControllerStateOnDisable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_keepAnimatorControllerStateOnDisable(IntPtr l) {
		try {
			UnityEngine.Animator self=(UnityEngine.Animator)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.keepAnimatorControllerStateOnDisable=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Animator");
		addMember(l,GetFloat);
		addMember(l,SetFloat);
		addMember(l,GetBool);
		addMember(l,SetBool);
		addMember(l,GetInteger);
		addMember(l,SetInteger);
		addMember(l,SetTrigger);
		addMember(l,ResetTrigger);
		addMember(l,IsParameterControlledByCurve);
		addMember(l,GetIKPosition);
		addMember(l,SetIKPosition);
		addMember(l,GetIKRotation);
		addMember(l,SetIKRotation);
		addMember(l,GetIKPositionWeight);
		addMember(l,SetIKPositionWeight);
		addMember(l,GetIKRotationWeight);
		addMember(l,SetIKRotationWeight);
		addMember(l,GetIKHintPosition);
		addMember(l,SetIKHintPosition);
		addMember(l,GetIKHintPositionWeight);
		addMember(l,SetIKHintPositionWeight);
		addMember(l,SetLookAtPosition);
		addMember(l,SetLookAtWeight);
		addMember(l,SetBoneLocalRotation);
		addMember(l,GetBehaviour);
		addMember(l,GetBehaviours);
		addMember(l,GetLayerName);
		addMember(l,GetLayerIndex);
		addMember(l,GetLayerWeight);
		addMember(l,SetLayerWeight);
		addMember(l,GetCurrentAnimatorStateInfo);
		addMember(l,GetNextAnimatorStateInfo);
		addMember(l,GetAnimatorTransitionInfo);
		addMember(l,GetCurrentAnimatorClipInfoCount);
		addMember(l,GetNextAnimatorClipInfoCount);
		addMember(l,GetCurrentAnimatorClipInfo);
		addMember(l,GetNextAnimatorClipInfo);
		addMember(l,IsInTransition);
		addMember(l,GetParameter);
		addMember(l,MatchTarget);
		addMember(l,InterruptMatchTarget);
		addMember(l,CrossFadeInFixedTime);
		addMember(l,WriteDefaultValues);
		addMember(l,CrossFade);
		addMember(l,PlayInFixedTime);
		addMember(l,Play);
		addMember(l,SetTarget);
		addMember(l,GetBoneTransform);
		addMember(l,StartPlayback);
		addMember(l,StopPlayback);
		addMember(l,StartRecording);
		addMember(l,StopRecording);
		addMember(l,HasState);
		addMember(l,Update);
		addMember(l,Rebind);
		addMember(l,ApplyBuiltinRootMotion);
		addMember(l,StringToHash_s);
		addMember(l,"isOptimizable",get_isOptimizable,null,true);
		addMember(l,"isHuman",get_isHuman,null,true);
		addMember(l,"hasRootMotion",get_hasRootMotion,null,true);
		addMember(l,"humanScale",get_humanScale,null,true);
		addMember(l,"isInitialized",get_isInitialized,null,true);
		addMember(l,"deltaPosition",get_deltaPosition,null,true);
		addMember(l,"deltaRotation",get_deltaRotation,null,true);
		addMember(l,"velocity",get_velocity,null,true);
		addMember(l,"angularVelocity",get_angularVelocity,null,true);
		addMember(l,"rootPosition",get_rootPosition,set_rootPosition,true);
		addMember(l,"rootRotation",get_rootRotation,set_rootRotation,true);
		addMember(l,"applyRootMotion",get_applyRootMotion,set_applyRootMotion,true);
		addMember(l,"updateMode",get_updateMode,set_updateMode,true);
		addMember(l,"hasTransformHierarchy",get_hasTransformHierarchy,null,true);
		addMember(l,"gravityWeight",get_gravityWeight,null,true);
		addMember(l,"bodyPosition",get_bodyPosition,set_bodyPosition,true);
		addMember(l,"bodyRotation",get_bodyRotation,set_bodyRotation,true);
		addMember(l,"stabilizeFeet",get_stabilizeFeet,set_stabilizeFeet,true);
		addMember(l,"layerCount",get_layerCount,null,true);
		addMember(l,"parameters",get_parameters,null,true);
		addMember(l,"parameterCount",get_parameterCount,null,true);
		addMember(l,"feetPivotActive",get_feetPivotActive,set_feetPivotActive,true);
		addMember(l,"pivotWeight",get_pivotWeight,null,true);
		addMember(l,"pivotPosition",get_pivotPosition,null,true);
		addMember(l,"isMatchingTarget",get_isMatchingTarget,null,true);
		addMember(l,"speed",get_speed,set_speed,true);
		addMember(l,"targetPosition",get_targetPosition,null,true);
		addMember(l,"targetRotation",get_targetRotation,null,true);
		addMember(l,"cullingMode",get_cullingMode,set_cullingMode,true);
		addMember(l,"playbackTime",get_playbackTime,set_playbackTime,true);
		addMember(l,"recorderStartTime",get_recorderStartTime,set_recorderStartTime,true);
		addMember(l,"recorderStopTime",get_recorderStopTime,set_recorderStopTime,true);
		addMember(l,"recorderMode",get_recorderMode,null,true);
		addMember(l,"runtimeAnimatorController",get_runtimeAnimatorController,set_runtimeAnimatorController,true);
		addMember(l,"hasBoundPlayables",get_hasBoundPlayables,null,true);
		addMember(l,"avatar",get_avatar,set_avatar,true);
		addMember(l,"playableGraph",get_playableGraph,null,true);
		addMember(l,"layersAffectMassCenter",get_layersAffectMassCenter,set_layersAffectMassCenter,true);
		addMember(l,"leftFeetBottomHeight",get_leftFeetBottomHeight,null,true);
		addMember(l,"rightFeetBottomHeight",get_rightFeetBottomHeight,null,true);
		addMember(l,"logWarnings",get_logWarnings,set_logWarnings,true);
		addMember(l,"fireEvents",get_fireEvents,set_fireEvents,true);
		addMember(l,"keepAnimatorControllerStateOnDisable",get_keepAnimatorControllerStateOnDisable,set_keepAnimatorControllerStateOnDisable,true);
		createTypeMetatable(l,null, typeof(UnityEngine.Animator),typeof(UnityEngine.Behaviour));
	}
}
